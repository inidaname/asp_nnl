Imports System.Data

Partial Class admexportpermit
    Inherits System.Web.UI.Page

    Dim GenTool As NNLN = xsmsCentralToolx.SetTool

    Protected Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init
        Try
            Dim sysDBUser As systemDBUsers = CType(Session("sysDBUser"), systemDBUsers)


            TabInspected.Enabled = sysDBUser.inspectexportimport
            TabEndorsed.Enabled = sysDBUser.endorseexportimport
            TabRecommeded.Enabled = sysDBUser.recommendexportimport
            TabApproved.Enabled = sysDBUser.approveexportimport

            btnimportexporthistory.Visible = sysDBUser.dataimportright

        Catch ex As Exception
        End Try

        If IsPostBack = False Then
            setupRest()
            Dim ds As DataSet = getCompany()
            Try
                If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then

                    cboCompany.DataValueField = "sysID"
                    cboCompany.DataTextField = "companyName"
                    cboCompany.DataSource = ds.Tables(0)
                    cboCompany.DataBind()
                    cboExportPermit.Items.Insert(0, "Select Export Permit")
                End If

            Catch ex As Exception
            Finally
                cboCompany.Items.Insert(0, "Select Company")
            End Try
        End If
    End Sub

    '<a href="#" onClick="window.open("http://www.w3schools.com","_blank","toolbar=yes, scrollbars=yes, resizable=yes, top=500, left=500, width=400, height=400");return false">Link text</a>

    Protected Sub cboCompany_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCompany.SelectedIndexChanged
        Try

            Dim sysDBUser As systemDBUsers = CType(Session("sysDBUser"), systemDBUsers)

            TabInspected.Enabled = sysDBUser.inspectexportimport
            TabEndorsed.Enabled = sysDBUser.endorseexportimport
            TabRecommeded.Enabled = sysDBUser.recommendexportimport
            TabApproved.Enabled = sysDBUser.approveexportimport

            Dim w2 As String = ""

            If sysDBUser.recommendexportimport = True AndAlso sysDBUser.inspectexportimport = True AndAlso sysDBUser.endorseexportimport = True AndAlso sysDBUser.approveexportimport = True Then

            ElseIf sysDBUser.inspectexportimport = True Then
                w2 = " AND inspStatus=0"
            ElseIf sysDBUser.endorseexportimport = True Then
                w2 = " AND endoresedStatus=0  AND inspStatus=1 "
            ElseIf sysDBUser.recommendexportimport = True Then
                w2 = " AND recommendationStatus=0 AND endoresedStatus=1  AND inspStatus=1 "
            ElseIf sysDBUser.approveexportimport = True Then
                w2 = " AND recommendationStatus=1 AND endoresedStatus=1  AND inspStatus=1 AND approvedStatus=0 "
            End If

            Dim sd As String = "select sysID as ID,exportpermitName as PermitQuarter,ExporterName,productnameforcast as 'Prod Desc/Grade',ExportPort,finalQuantity as ExportQty,concat(periodCoveredfrom, ' To ',periodCoveredTo) as 'Period Covered',TotalamtUS as 'F.O.B Value(USD)' from exportpermit where companyID=" & Val(cboCompany.SelectedValue.Split("|").ToArray(0)) & " " & w2

            Dim ds As DataSet = GenTool.DataSetData(sd)
            filldb(ds)

            cboExportPermit.Items.Clear()

            cboExportPermit.DataValueField = "ID"
            cboExportPermit.DataTextField = "PermitQuarter"
            cboExportPermit.DataSource = ds.Tables(0)
            cboExportPermit.DataBind()
            btnimportexporthistory.Visible = False
            btnResetR_Click(Nothing, Nothing)
            getApp()

        Catch ex As Exception
            GenTool.GrabError(ex.Message, "cboCompany_SelectedIndexChanged")
        Finally
            cboExportPermit.Items.Insert(0, "Select Export Permit")
        End Try
    End Sub

    Private Sub grdy_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grd.RowCreated
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                e.Row.Attributes("onmouseover") = "this.style.cursor='pointer';this.style.textDecoration='none';"
                e.Row.Attributes("onmouseout") = "this.style.textDecoration='none';"
                e.Row.ToolTip = "Click to select row"
                e.Row.Attributes("onclick") = Me.Page.ClientScript.GetPostBackClientHyperlink(Me.grd, "Select$" & e.Row.RowIndex)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub cboExportPermit_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboExportPermit.SelectedIndexChanged
        Try

            Dim sd As String = "select sysID as ID,exportpermitName as 'Permit Quarter',exporterName as 'Exporter Name',productnameforcast as 'Prod Desc/Grade',exportPort as 'Port Of Export' ,finalQuantity as Quantity,amtPerBarrelUS as 'Price/Barrel',TotalamtUS as 'F.O.B Value(USD)',If(inspStatus=0,'Not Inspected',if(inspStatus=2,'Rejected','Successful')) as Inspection,if(endoresedStatus=0,'Not Endorsed','Endorsed') as Endorsed,if(recommendationStatus=0,'Not Recommended','Recommended') as Recommendation,if(approvedStatus=0,'Not Approved','Approved') as Approval from exportpermit where companyID=" & Val(cboCompany.SelectedValue.Split("|").ToArray(0)) & " AND sysID=" & Val(cboExportPermit.SelectedValue)
            Dim ds As DataSet = GenTool.DataSetData(sd)
            filldb(ds)
            btnResetR_Click(Nothing, Nothing)

            btnimportexporthistory.Visible = Not cboExportPermit.SelectedIndex < 1

        Catch ex As Exception
        End Try
    End Sub

    Private Sub filldb(ByVal ds As DataSet)
        Try
            grd.DataSource = ds.Tables(0)
            grd.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Sub getApp()
        Try
            txtRecommendedBy.Text = Session("Fullname")
            txtInpectionOfficer.Text = Session("Fullname")
            txtEndordedBy.Text = Session("Fullname")
            txtApprovedBy.Text = Session("Fullname")
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub grd_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grd.PageIndexChanging
        grd.PageIndex = e.NewPageIndex
        cboCompany_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Protected Sub grd_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grd.SelectedIndexChanged
        Try

            txtExportID.Text = grd.SelectedRow.Cells(1).Text
            Dim fs As String = Server.HtmlDecode(grd.SelectedRow.Cells(2).Text)
            txtExportName.Text = fs
            lblProductE.Text = fs
            lblAPN.Text = fs
            lblProductA.Text = fs

            Dim ds As DataSet = GenTool.DataSetData("select * from exportpermit where sysID=" & Val(txtExportID.Text))
            If GenTool.HasDatasetRecords(ds) = True Then

                Try

                    GenTool.resetform(TabInspected, ds)
                    GenTool.resetform(TabEndorsed, ds)
                    GenTool.resetform(pnlRecommend, ds)
                    GenTool.resetform(TabApproved, ds)
                    GenTool.resetform(Panel2, ds)
                Catch ex As Exception
                End Try

                With ds.Tables(0).Rows(0)

                    getApp()
                    Dim sdf As String = ""

                    If String.IsNullOrEmpty(.Item("CoverLetterName1").ToString) = True Then
                        sdf = "select CoverLetterName1 from exportpermit where CoverLetterName1<>'' AND companyID=" & Val(cboCompany.SelectedValue.Split("|").ToArray(0)) & " Order by exportDate desc"
                        .Item("CoverLetterName1") = GenTool.getSingleValue(sdf)
                    End If

                    If String.IsNullOrEmpty(.Item("CoverLetterName2").ToString) = True Then
                        sdf = "select CoverLetterName2 from exportpermit where CoverLetterName2<>'' AND companyID=" & Val(cboCompany.SelectedValue.Split("|").ToArray(0)) & " Order by exportDate desc"
                        .Item("CoverLetterName2") = GenTool.getSingleValue(sdf)
                    End If

                    HView1.Enabled = IO.File.Exists(pathdoclink & "coverLetter\" & .Item("CoverLetterName1").ToString)
                    HView1.NavigateUrl = docLink & "coverLetter/" & .Item("CoverLetterName1").ToString
                    HView1.Attributes.Add("onclick", "window.open (this.href, 'popupwindow',  'width=600,height=600,scrollbars,resizable'); return false;")


                    HView2.Enabled = IO.File.Exists(pathdoclink & "coverLetter\" & .Item("CoverLetterName2").ToString)
                    HView2.NavigateUrl = docLink & "coverLetter/" & .Item("CoverLetterName2").ToString
                    HView2.Attributes.Add("onclick", "window.open (this.href, 'popupwindow',  'width=600,height=600,scrollbars,resizable'); return false;")

                    HView3.Enabled = IO.File.Exists(pathdoclink & "coverLetter\" & .Item("CoverLetterName3").ToString)
                    HView3.NavigateUrl = docLink & "coverLetter/" & .Item("CoverLetterName3").ToString
                    HView3.Attributes.Add("onclick", "window.open (this.href, 'popupwindow',  'width=600,height=600,scrollbars,resizable'); return false;")

                    HView4.Enabled = IO.File.Exists(pathdoclink & "coverLetter\" & .Item("CoverLetterName4").ToString)
                    HView4.NavigateUrl = docLink & "coverLetter/" & .Item("CoverLetterName4").ToString
                    HView1.Attributes.Add("onclick", "window.open (this.href, 'popupwindow',  'width=600,height=600,scrollbars,resizable'); return false;")

                    HView5.Enabled = IO.File.Exists(pathdoclink & "coverLetter\" & .Item("CoverLetterName5").ToString)
                    HView5.NavigateUrl = docLink & "coverLetter/" & .Item("CoverLetterName5").ToString
                    HView5.Attributes.Add("onclick", "window.open (this.href, 'popupwindow',  'width=600,height=600,scrollbars,resizable'); return false;")

                    HView6.Enabled = IO.File.Exists(pathdoclink & "coverLetter\" & .Item("CoverLetterName6").ToString)
                    HView6.NavigateUrl = docLink & "coverLetter/" & .Item("CoverLetterName6").ToString
                    HView6.Attributes.Add("onclick", "window.open (this.href, 'popupwindow',  'width=600,height=600,scrollbars,resizable'); return false;")

                    HView7.Enabled = IO.File.Exists(pathdoclink & "coverLetter\" & .Item("CoverLetterName7").ToString)
                    HView7.NavigateUrl = docLink & "coverLetter/" & .Item("CoverLetterName7").ToString
                    HView7.Attributes.Add("onclick", "window.open (this.href, 'popupwindow',  'width=600,height=600,scrollbars,resizable'); return false;")

                    HView8.Enabled = IO.File.Exists(pathdoclink & "coverLetter\" & .Item("CoverLetterName8").ToString)
                    HView8.NavigateUrl = docLink & "coverLetter/" & .Item("CoverLetterName8").ToString
                    HView8.Attributes.Add("onclick", "window.open (this.href, 'popupwindow',  'width=600,height=600,scrollbars,resizable'); return false;")

                    If RadioButton3.Checked = True Then
                        If HView1.Enabled = False OrElse HView2.Enabled = False OrElse HView3.Enabled = False OrElse HView4.Enabled = False OrElse HView5.Enabled = False OrElse HView6.Enabled = False OrElse HView7.Enabled = False OrElse HView8.Enabled = False Then
                            lbl7.Text = "INCOMPLETE!"
                        Else
                            lbl7.Text = "COMPLETED!"
                            lbl7.ForeColor = Drawing.Color.Black
                        End If
                    Else
                        If HView1.Enabled = False OrElse HView2.Enabled = False OrElse HView5.Enabled = False OrElse HView6.Enabled = False Then
                            lbl7.Text = "INCOMPLETE!"
                        Else
                            lbl7.Text = "COMPLETED!"
                            lbl7.ForeColor = Drawing.Color.Black
                        End If
                    End If

                End With

                Dim dsv As DataSet = GenTool.DataSetData("select productnameforcast,periodCoveredFrom,periodCoveredTo from exportpermit where sysID=" & Val(grd.SelectedRow.Cells(1).Text))
                If GenTool.HasDatasetRecords(dsv) = True Then
                    With dsv.Tables(0).Rows(0)
                        TextBox7.Text = .Item(0).ToString
                        cboPCF.SelectedIndex = GenTool.getddlindexvalue(cboPCF, .Item(1).ToString)
                        cboPCT.SelectedIndex = GenTool.getddlindexvalue(cboPCT, .Item(2).ToString)
                    End With
                End If

            Else

                GenTool.resetform(TabInspected)
                GenTool.resetform(TabEndorsed)
                GenTool.resetform(pnlRecommend)
                GenTool.resetform(TabApproved)
                GenTool.resetform(Panel2)
            End If


        Catch ex As Exception
            GenTool.GrabError("admexportpermit", ex.Message)
        End Try
    End Sub

    Dim FN As String = ""
    Dim FV As String = ""
    Dim FUpdate As String = ""

    Protected Sub btnRecommend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRecommend.Click
        Dim msg As String = ""
        Try

            If txtRecommendedBy.Text = "" Then
                msg = "The system couldnt assertain who is recommending this transaction,please re-login and try again"
                Return
            End If

            

            Dim Sql As String = "SELECT endoresedStatus from exportpermit where sysID=" & Val(txtExportID.Text)

            If Val(GenTool.getSingleValue(Sql)) < 1 Then
                msg = "This Permit has not being endorsed, please inspect,endorse it before recommendation"
                Return
            End If


            msg = GenTool.checkControl(pnlRecommend, FN, FV, FUpdate)

            If msg = "" Then
                Sql = "Update exportpermit set " & FUpdate & " where sysID=" & Val(txtExportID.Text)

                If GenTool.ExecuteDatabase(sql) = True Then

                    Dim DSV As DataSet = GenTool.DataSetData("SELECT exportPort,finalQuantity FROM exportpermit where sysID=" & Val(txtExportID.Text))
                    Dim exportPort As String = ""
                    Dim finalQuantity As String = ""
                    If GenTool.HasDatasetRecords(DSV) = True Then
                        With DSV.Tables(0).Rows(0)
                            exportPort = .Item(0).ToString
                            finalQuantity = .Item(1).ToString
                        End With
                    End If

                    If chkrecommend.Checked = True Then
                        sendmail("EXPORT PERMIT RECOMMENDED BY " & txtRecommendedBy.Text, "RECOMMENDED", txtRecommednComments.Text, finalQuantity, exportPort, txtRecommendDate.Text)
                        GenTool.FormHistory("EXPORT PERMIT :  " & txtExportName.Text & " WAS RECOMMENDED BY " & txtRecommendedBy.Text, Request.UserHostAddress, Val(Session("sysID")))
                    Else
                        sendmail("EXPORT PERMIT NOT RECOMMENDED", "NOT RECOMMENDED", txtRecommednComments.Text, finalQuantity, exportPort, txtRecommendDate.Text)
                        GenTool.FormHistory("EXPORT PERMIT :  " & txtExportName.Text & " WAS NOT RECOMMENDED BY " & txtRecommendedBy.Text, Request.UserHostAddress, Val(Session("sysID")))
                    End If

                    msg = "Record updated successfully"
                    cboCompany_SelectedIndexChanged(Nothing, Nothing)

                    btnResetR_Click(Nothing, Nothing)

                Else
                    msg = "Record update failed,please try again later"
                End If

                End If

        Catch ex As Exception
        Finally
            MessageBox.Show(UpdatePanel1, msg)
        End Try
    End Sub

    Protected Sub btnResetR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnResetR.Click
        GenTool.resetform(pnlRecommend, Nothing)
        lblAPN.Text = ""
        'lblAPNS.Text = ""
    End Sub

    Private Sub sendmail1(ByVal subject As String, exportPort As String, finalQuantity As String)
        Try
            Dim cBlast As New MailContents
            cBlast.AttarchFiles = ""
            cBlast.BodyM = getBody1(exportPort, finalQuantity)
            cBlast.IsBodyHtml = True
            cBlast.mailbcc = Nothing
            cBlast.mailcc = New Net.Mail.MailAddress("exportpermitapplication@wmdnigeria.com")
            cBlast.mailfrom = New Net.Mail.MailAddress("exportpermitapplication@wmdnigeria.com")
            cBlast.mailto = New Net.Mail.MailAddress(cboCompany.SelectedValue.Split("|").ToArray(1))
            cBlast.Subject = subject
            cBlast.enableSSL = False
            GenTool.SendnMailBox(cBlast)

        Catch ex As Exception
        End Try
    End Sub

    Private Sub sendmail(ByVal subject As String, ByVal MsgStatus As String, ByVal body As String, QUANTITY As String, PORTOFEXPORT As String, sDate As String)
        Try
            Dim cBlast As New MailContents
            cBlast.AttarchFiles = ""
            cBlast.BodyM = getBody(MsgStatus, body, QUANTITY, PORTOFEXPORT, sDate)
            cBlast.IsBodyHtml = True
            cBlast.mailbcc = Nothing
            cBlast.mailcc = New Net.Mail.MailAddress("exportpermitapplication@wmdnigeria.com")
            cBlast.mailfrom = New Net.Mail.MailAddress("exportpermitapplication@wmdnigeria.com")
            cBlast.mailto = New Net.Mail.MailAddress(cboCompany.SelectedValue.Split("|").ToArray(1))
            cBlast.Subject = subject
            cBlast.enableSSL = False
            GenTool.SendnMailBox(cBlast)

        Catch ex As Exception
        End Try
    End Sub

    Private Sub setupRest()
        Try

            cboPCF.Items.Clear()
            cboPCT.Items.Clear()

            cboPCF.Items.Add("select Value")
            cboPCT.Items.Add("select Value")
            For K As Int16 = 1 To 12
                cboPCF.Items.Add(MonthName(K))
                cboPCT.Items.Add(MonthName(K))
            Next

        Catch ex As Exception
        End Try
    End Sub

    Private Function getBody(ByVal MsgStatus As String, ByVal body As String, QUANTITY As String, PORTOFEXPORT As String, sDate As String) As String
        Return "<html>" & _
"<head>" & _
"    <title></title>" & _
"    <style type ='text/css'> " & _
"	body {" & _
"	   margin : 0px 0px 0px 0px;" & _
"	background:  white url('img/background4.png') repeat-x top left;" & _
"		}" & _
"    a.main_links {" & _
"      color: #5c5c5c;" & _
"      font-size: 11px;" & _
"      font-family: Verdana, Arial;" & _
"      margin: 0px 0px 0px 0px;" & _
"      font-weight: normal;" & _
"      }" & _
" " & _
"      a.main_links:hover {" & _
"      color: #333333 !important;" & _
"	  text-decoration: none;" & _
"      }" & _
"      " & _
"      toptoolbar" & _
"      {" & _
"      	margin: 0; padding: 0; background: #6895ab url('img/navbarbackground.png') repeat-x; font-size: 70%; width: 100%; border-top: 1px solid #40738b; position: relative; color: #333; float: left; clear: both;" & _
"      }" & _
"      " & _
"      .zebraeven { background-color: #fefefe; }" & _
"      .zebraodd  { background-color: #f7f5e7; }" & _
"      .datesub { PADDING-TOP: 6px; PADDING-BOTTOM: 6px; }" & _
"" & _
"    .datecontainer { FONT: 28px Trebuchet MS, Calibri, Verdana, Arial, Helvetica; padding-top: 3px; }" & _
"" & _
"    .boxcontainer { margin: 16px 0 16px 0; padding: 10px; BACKGROUND: #F2F2EB; -moz-border-radius: 12px 12px 0 0; -webkit-border-radius: 12px 12px 0 0;  border-radius: 12px 12px 0 0; }" & _
"" & _
"    .boxcontainerlabel { font-family: Candara, Trebuchet MS, Verdana, Calibri, Helvetica, sans-serif; font-size: 22px; font-weight: bold; color: #4e4e4e; margin-bottom: 8px; TEXT-SHADOW: 0 1px 0 rgba(255, 255, 255, 0.85); }" & _
"" & _
"    .boxcontainercontent { border: 2px SOLID #e2e2d6; background: white; padding: 10px; font-size: 12px;}" & _
"" & _
"    .boxcontainercontenttight { border: 2px SOLID #e2e2d6; background: white; font-size: 12px; }" & _
"" & _
"    .zebraeven { background-color: #fefefe; }" & _
"    .zebraodd  { background-color: #f7f5e7; }" & _
"    .redtext { COLOR: red; }" & _
"    .graytext { COLOR: #333333; }" & _
"" & _
"    .hlineheader { width: 100%; margin: 0; padding: 0; white-space: nowrap; color: #277dca; font-family: Candara, Trebuchet MS, Verdana, Calibri, Helvetica, Georgia,serif; text-decoration: none; font-size: 14px; font-weight: none; }" & _
"    .hlineheader th { margin: 0; padding: 0 8px 0 0; }" & _
"    .hlineheader td { font-size: 50%; margin: 0; padding: 0; }" & _
"    td.hlinelower { border-top: 1px solid #ececec; width: 100%; }" & _
"    .hlinegray { color: #626262 !important; }" & _
"" & _
"" & _
".subcontent { padding: 4px 0px 4px 4px; }" & _
".captchaholder { padding: 4px 0 4px 0; }" & _
"" & _
" toptoolbar               { margin: 0; padding: 0; background: #6895ab url('img/navbarbackground.png') repeat-x; font-size: 70%; width: 100%; border-top: 1px solid #40738b; position: relative; color: #333; float: left; clear: both; }" & _
" toptoolbar a             { color: white; font-weight: bold; font-family: 'trebuchet ms', verdana, helvetica, sans-serif; font-size: 16px; text-decoration: none; text-shadow:0 1px 0 rgba(0, 0, 0, 0.6); }" & _
" toptoolbarrightarea      { float: right; display: inline-block; margin-top: 0.2em; margin-right: 0.4em; height: 100%; }" & _
" toptoolbarrightareainset { display: inline-block; }" & _
" toptoolbar select        { border: 1px solid #cdc2ab; font-family: verdana, tahoma, sans-serif; font-size: 1em; margin: 5px 5px 0 0; }" & _
" toptoolbarlinklist { margin: 0; padding: 0; }" & _
" toptoolbarlinklist ul         {  }" & _
" toptoolbarlinklist li         { list-style-type: none; display: inline-block; float: left; margin: 0.2em 0 0 .8em; padding: 0; clear: none; }" & _
" toptoolbarlinklist li:hover   { background: url('img/topbarhoverarrow.png') no-repeat bottom center transparent; }" & _
" toptoolbarlinklist li.current { background: url('img/topbarcurrentarrow.png') no-repeat bottom center transparent; }	" & _
"" & _
".leftnavboxcontent         { border: 1px solid #cdc6b6; }" & _
".leftnavboxcontent a       { display: block; text-decoration: none; color: black; font-family: Verdana, Tahoma, sans-serif; font-size: 11px; border-bottom: 1px solid #f5f5f5; text-indent: 20px; padding: 0.375em; background-image: url('img/icon_folderyellow.gif'); background-repeat: no-repeat; background-position: 0.375em 0.25em; line-height: 140%; }" & _
".leftnavboxcontent a:hover { background-color: #fff8e9; color: #476ca4; }" & _
".searchboxcontainer { border: 4px SOLID rgba(204, 204, 204, 0.6); -moz-border-radius: 6px; -webkit-border-radius: 6px; border-radius: 6px; }" & _
".searchbox { border: 1px SOLID #cccccc; }" & _
".searchbuttoncontainer { float: right; height: 35px; vertical-align: top; }" & _
".searchbutton { -moz-border-radius: 7px 7px 7px 7px; -webkit-border-radius: 7px 7px 7px 7px; border-radius: 7px 7px 7px 7px; background: #7bc17a; color: white !important; display: inline-block; font-size: 11px; font-weight: bold; padding: 6px 12px 6px 12px; text-decoration: none; text-shadow: 1px 1px 1px rgba(0, 0, 0, 0.2); margin: 4px 5px 0px 0px; CURSOR: pointer; }" & _
".searchbutton:hover { background: #88cc85; color: white !important; }" & _
".searchbutton span { background: URL(img/searchpointer.png); display: inline; float: right; margin: 1px 0 0 5px; height: 13px; width: 12px; }" & _
".searchinputcontainer { height: 35px; outline: none; display: inline-block; width: 80%; }" & _
".searchquery { width: 100%; margin: 1px 0 0 0; background: url(img/icon_search.png) no-repeat 8px 6px; padding: 5px 6px 7px 30px; border: 0px; color: #d5d5d5; font-size: 18px; font-family: 'Lucida Grande','Helvetica Neue',Helvetica,Arial,Verdana,sans-serif; height: 20px; }" & _
".searchqueryactive { color: #666666 !important; }" & _
"" & _
"    .style1" & _
"    {" & _
"        width: 282px;" & _
"    }" & _
"    .style2" & _
"    {" & _
"        width: 137px;" & _
"    }" & _
"" & _
"    .style3" & _
"    {" & _
"        width: 90px;" & _
"    }" & _
"" & _
"    .style4" & _
"    {" & _
"        width: 137px;" & _
"        height: 32px;" & _
"    }" & _
"    .style5" & _
"    {" & _
"        width: 90px;" & _
"        height: 32px;" & _
"    }" & _
"" & _
"    .style9" & _
"    {" & _
"    }" & _
"    .style10" & _
"    {" & _
"        width: 678px;" & _
"        height: 162px;" & _
"    }" & _
"" & _
"    .style11" & _
"    {" & _
"        width: 164px;" & _
"    }" & _
"" & _
"    .style12" & _
"    {" & _
"        width: 734px;" & _
"    }" & _
"" & _
"    </style>" & _
"</head>" & _
"<body>" & _
"    <form id='form1' runat='server'>" & _
"    <center>" & _
"    <div class='boxcontainer' style='width:50%' >" & _
"        <div class='boxcontainerlabel'>" & _
"            EXPORT PERMIT DETAILS</div>" & _
"        <div id='renderpower' class='boxcontainercontent'>" & _
"            <table class='hlineheader'>" & _
"                <tr>" & _
"                    <th nowrap rowspan='2'>" & _
"                        General Information</th>" & _
"                    <td>" & _
"                        &nbsp;</td>" & _
"                </tr>" & _
"                <tr>" & _
"                    <td class='hlinelower'>" & _
"                        &nbsp;</td>" & _
"                </tr>" & _
"            </table>" & _
"            <table border='0' cellpadding='4' cellspacing='1' width='100%'>" & _
"                <tr>" & _
"                    <td align='left' class='zebraodd' valign='middle' width='200'>" & _
"                       COMPANY REG ID</td>" & _
"                    <td align='left'>" & _
"                        " & txtExportID.Text & "</td>" & _
"                </tr>" & _
"                <tr>" & _
"                    <td align='left' class='zebraodd' valign='middle'>" & _
"                        COMPANY NAME</td>" & _
"                    <td align='left'>" & _
"                        " & cboCompany.SelectedItem.Text & "</td>" & _
"                </tr>" & _
"                <tr>" & _
"                    <td align='left' class='zebraodd' valign='middle'>" & _
"                        EXPORT PERMIT QUARTER</td>" & _
"                    <td align='left'>" & _
"                        " & txtExportName.Text & "</td>" & _
"                </tr>" & _
"                <tr>" & _
"                    <td align='left' class='zebraodd' valign='middle'>" & _
"                        EXPORT QUANTITY</td>" & _
"                    <td align='left'>" & _
"                        " & QUANTITY & "</td>" & _
"                </tr>" & _
"                <tr>" & _
"                    <td align='left' class='zebraodd' valign='middle'>" & _
"                        PORT OF EXPORT</td>" & _
"                    <td align='left'>" & _
"                        " & PORTOFEXPORT & "</td>" & _
"                </tr>" & _
"                <tr>" & _
"                    <td align='left' class='zebraodd' valign='middle'>" & _
"                        STATUS</td>" & _
"                    <td align='left'>" & _
"                        " & MsgStatus & "</td>" & _
"                </tr>" & _
"                <tr>" & _
"                    <td align='left' class='zebraodd' valign='middle'>" & _
"                        TRANSACTION DATE</td>" & _
"                    <td align='left'>" & _
"                        " & sDate & "</td>" & _
"                </tr>" & _
"            </table>" & _
"            <br />" & _
"            <table class='hlineheader'>" & _
"                <tr>" & _
"                    <th nowrap rowspan='2'>" & _
"                        </th>" & _
"                    <td>" & _
"                        &nbsp;</td>" & _
"                </tr>" & _
"                <tr>" & _
"                    <td class='hlinelower'>" & _
"                        &nbsp;</td>" & _
"                </tr>" & _
"            </table>" & _
"            <table border='0' cellpadding='4' cellspacing='1' width='100%'>" & _
"                <tr>" & _
"                    <td align='left' valign='top'>" & _
"                       " & body & "</td>" & _
"                </tr>" & _
"            </table>" & _
"            <br />" & _
"        </div>" & _
"        </center>" & _
"    </form>" & _
"</body>" & _
"</html>"

    End Function

    Protected Sub btnResetI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnResetI.Click
        GenTool.resetform(pnlInspected, Nothing)
    End Sub

    Protected Sub btnInspected_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInspected.Click
        Dim msg As String = ""
        Try

            If txtInpectionOfficer.Text = "" Then
                msg = "The system couldnt assertain who is inspecting this transaction,please re-login and try again"
                Return
            End If
            Dim sql As String

            
            msg = GenTool.checkControl(pnlInspected, FN, FV, FUpdate)

            If msg = "" Then


                sql = "Update exportpermit set " & FUpdate & " where sysID=" & Val(txtExportID.Text)

                If GenTool.ExecuteDatabase(sql) = True Then

                    Dim DSV As DataSet = GenTool.DataSetData("SELECT exportPort,finalQuantity FROM exportpermit where sysID=" & Val(txtExportID.Text))
                    Dim exportPort As String = ""
                    Dim finalQuantity As String = ""
                    If GenTool.HasDatasetRecords(DSV) = True Then
                        With DSV.Tables(0).Rows(0)
                            exportPort = .Item(0).ToString
                            finalQuantity = .Item(1).ToString
                        End With
                    End If

                    If chkInspected.Checked = True Then
                        sendmail("EXPORT PERMIT INSPECTED BY " & txtInpectionOfficer.Text, "INSPECTED", txtInspComments.Text, finalQuantity, exportPort, txtDPTTo.Text)
                        GenTool.FormHistory("EXPORT PERMIT :  " & txtExportName.Text & " WAS INSPECTED BY " & txtInpectionOfficer.Text, Request.UserHostAddress, Val(Session("sysID")))
                    Else
                        sendmail("EXPORT PERMIT WAS NOT APPROVED FOR INSPECTION ", "NOT INSPECTED", txtInspComments.Text, finalQuantity, exportPort, txtDPTTo.Text)
                        GenTool.FormHistory("EXPORT PERMIT :  " & txtExportName.Text & " WAS NOT SATISFACTORY WITH INSPECTION BY " & txtInpectionOfficer.Text, Request.UserHostAddress, Val(Session("sysID")))
                    End If

                    msg = "Record updated successfully"
                    cboCompany_SelectedIndexChanged(Nothing, Nothing)

                    btnResetI_Click(Nothing, Nothing)

                Else
                    msg = "Record update failed,please try again later"
                End If

                End If

        Catch ex As Exception
        Finally
            MessageBox.Show(UpdatePanel1, msg)
        End Try
    End Sub

 
    Protected Sub btnApproved_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApproved.Click
        Dim msg As String = ""
        Try

 

            If txtApprovedBy.Text = "" Then
                msg = "The system couldnt assertain who is approving this transaction,please re-login and try again"
                Return
            End If


            Dim Sql As String = "SELECT recommendationStatus from exportpermit where sysID=" & Val(txtExportID.Text)

            If Val(GenTool.getSingleValue(Sql)) < 1 Then
                msg = "This Permit has not being recommended, please recommend it before approval"
                Return
            End If

            msg = GenTool.checkControl(pnlApproved, FN, FV, FUpdate)

            If msg = "" Then


                sql = "Update exportpermit set " & FUpdate & " where sysID=" & Val(txtExportID.Text)

                If GenTool.ExecuteDatabase(sql) = True Then

                    Dim DSV As DataSet = GenTool.DataSetData("SELECT exportPort,finalQuantity FROM exportpermit where sysID=" & Val(txtExportID.Text))
                    Dim exportPort As String = ""
                    Dim finalQuantity As String = ""
                    If GenTool.HasDatasetRecords(DSV) = True Then
                        With DSV.Tables(0).Rows(0)
                            exportPort = .Item(0).ToString
                            finalQuantity = .Item(1).ToString
                        End With
                    End If

                    If chkApproved.Checked = True Then
                        sendmail("EXPORT PERMIT APPROVED BY " & txtApprovedBy.Text, "APPROVED", txtApprovedComments.Text, finalQuantity, exportPort, txtApprovalDate.Text)

                        GenTool.FormHistory("EXPORT PERMIT :  " & txtExportName.Text & " WAS APPROVED BY " & txtApprovedBy.Text, Request.UserHostAddress, Val(Session("sysID")))

                    Else
                        sendmail("EXPORT PERMIT WAS NOT APPROVED", "NOT APPROVED", txtApprovedComments.Text, finalQuantity, exportPort, txtApprovalDate.Text)
                        GenTool.FormHistory("EXPORT PERMIT :  " & txtExportName.Text & " WAS NOT APPROVED BY " & txtApprovedBy.Text, Request.UserHostAddress, Val(Session("sysID")))
                    End If

                    msg = "Record updated successfully"
                    cboCompany_SelectedIndexChanged(Nothing, Nothing)

                    btnResetA_Click(Nothing, Nothing)

                Else
                    msg = "Record update failed,please try again later"
                End If

                End If

        Catch ex As Exception
        Finally
            MessageBox.Show(UpdatePanel1, msg)
        End Try
    End Sub

    Function getBody1(exportPort As String, finalQuantity As String) As String

        Return "</html><head>" & _
            "    <style type ='text/css'> " & _
            "@charset 'utf-8';" & _
"BODY {" & _
"	margin:0;" & _
"	padding:0;" & _
"	font-family: 'Century Gothic';" & _
"	font-size: 11px;" & _
"	color:#000;" & _
"	background:none" & _
"	}" & _
"img { " & _
"	border:0px;" & _
"	padding:0px;" & _
"	margin:0px;" & _
"}" & _
"a { text-decoration:none; color:#666" & _
"}" & _
"#page{ " & _
"	width:927px;" & _
"	height:686px; " & _
"	display:inline-block;" & _
"	padding: 0px;" & _
"	margin: 54px 0 0px 0;" & _
"	text-align:left;" & _
"	border:5px solid #000;" & _
"	font-weight:bold;" & _
"}" & _
"#page2{ " & _
"	width:448px;" & _
"	height:100%; " & _
"	display:inline-block;" & _
"	padding: 0px;" & _
"	margin: 54px 0 0px 0;" & _
"	text-align:left;" & _
"	border:5px solid #000;" & _
"}" & _
"#row1{" & _
"	width:100%;" & _
"	height:68px;" & _
"	border-bottom:1px #000 solid;" & _
"	margin:0;" & _
"	padding:0;" & _
"}" & _
"#row2{" & _
"	width:96%;" & _
"	height:25px;" & _
"	border-bottom:1px #000 solid;" & _
"	font-weight:bold;" & _
"	font-size:21px;" & _
"	color:#000;" & _
"	text-align:center;" & _
"	margin:0;" & _
"	padding:0px 0px 0px 40px;" & _
"}" & _
"#row3{" & _
"	width:96%;" & _
"	height:21px;" & _
"	border-bottom:1px #000 solid;" & _
"	text-align:center;" & _
"	margin:-2px 0 0 0;" & _
"	padding:0px 0px 0px 40px;" & _
"	display:inline-block;" & _
"	font-family:System;" & _
"	font-size:10px" & _
"}" & _
"#row4{" & _
"	width:100%;" & _
"	height:20px;" & _
"	border-bottom:2px #000 solid" & _
"}" & _
"#row5{" & _
"	width:100%;" & _
"	height:62px;" & _
"	border-bottom:2px #000 solid;" & _
"	margin:0;" & _
"	padding:0;" & _
"	background:#C2D697" & _
"}" & _
"#row6{" & _
"	width:100%;" & _
"	height:22px;" & _
"	border-bottom:1px #000 solid;" & _
"	text-align:center;" & _
"	margin:0;" & _
"	padding:0px 0px 0px 0px;" & _
"	display:inline-block" & _
"}" & _
"#row7{" & _
"	width:100%;" & _
"	height:20px;" & _
"	border-bottom:1px #000 solid" & _
"}" & _
"#row8{" & _
"	width:100%;" & _
"	height:20px;" & _
"	border:0;" & _
"	display:inline-block;" & _
"}" & _
"#row9{" & _
"	width:100%;" & _
"	height:19px;" & _
"	border-bottom:1px #000 solid;" & _
"	text-align:center;" & _
"	margin:0;" & _
"	padding:0px 0px 0px 0px;" & _
"	display:inline-block;" & _
"}" & _
"#row10{" & _
"	width:100%;" & _
"	height:19px;" & _
"	border-bottom:1px #000 solid;" & _
"	background:none;" & _
"	font-size:12px;" & _
"	text-align:center;" & _
"	background:#C4DAF1" & _
"}" & _
"#row11{" & _
"	width:100%;" & _
"	height:19px;" & _
"	border-bottom:1px #000 solid;" & _
"	background:none;" & _
"	font-size:12px;" & _
"	text-align:center;" & _
"}" & _
"#row12{" & _
"	width:100%;" & _
"	height:39px;" & _
"	border-bottom:1px #000 solid;" & _
"	border-top:1px #000 solid;" & _
"	font-size:12px;" & _
"	text-align:center;" & _
"	background:#C4DAF1" & _
"}" & _
"#row13{" & _
"	width:100%;" & _
"	height:59px;" & _
"	border-bottom:2px #000 solid;" & _
"	margin:0;" & _
"	padding:0;" & _
"}" & _
"#row14{" & _
"	width:100%;" & _
"	height:38px;" & _
"	border-bottom:2px #000 solid;" & _
"	margin:0;" & _
"	padding:0;" & _
"	font-size:13px;" & _
"	text-align:center;" & _
"	background:#C2D697" & _
"}" & _
"#row15{" & _
"	width:99%;" & _
"	height:88px;" & _
"	border-bottom:2px #000 solid;" & _
"	margin:0;" & _
"	padding:0;" & _
"	font-size:13px;" & _
"	text-align:justify;" & _
"	padding:6px 5px" & _
"}" & _
"#row16{" & _
"	width:99%;" & _
"	height:22px;" & _
"	margin:0;" & _
"	padding:0;" & _
"	font-size:14px;" & _
"	text-align:center;" & _
"	padding:8px 5px;" & _
"	background:url(" & docLink & "invoice/images/foot.jpg) 0px 0px repeat-x" & _
"}" & _
"#row17{" & _
"	width:100%;" & _
"	height:74px;" & _
"	margin:0;" & _
"	padding:0;" & _
"	font-size:14px;" & _
"	text-align:center;" & _
"	padding:0px 0px;" & _
"}" & _
"#row18{" & _
"	width:100%;" & _
"	height:97px;" & _
"	margin:0;" & _
"	padding:0;" & _
"	font-size:14px;" & _
"	text-align:center;" & _
"	padding:2px 0px;" & _
"	border-bottom:5px #000 solid;" & _
"	line-height:20px" & _
"}" & _
"#row19{" & _
"	width:100%;" & _
"	height:24px;" & _
"	margin:0;" & _
"	padding:0;" & _
"	font-size:22px;" & _
"	font-weight:bold;" & _
"	text-align:center;" & _
"	padding:2px 0px;" & _
"	border-bottom:5px #000 solid;" & _
"	background:#D8E5BA" & _
"}" & _
"#row20{" & _
"	width:100%;" & _
"	height:164px;" & _
"	margin:0;" & _
"	padding:0;" & _
"	font-size:12px;" & _
"	font-weight:bold;" & _
"	text-align:center;" & _
"	padding:0px 0px;" & _
"	border-bottom:2px #000 solid;" & _
"	display:inline-block;" & _
"	background:#D8E5BA" & _
"}" & _
"#row21{" & _
"	width:98%;" & _
"	height:63px;" & _
"	margin:0;" & _
"	padding:0;" & _
"	font-size:12px;" & _
"	font-weight:bold;" & _
"	text-align:center;" & _
"	padding:17px 4px;" & _
"	background:#C2D69B" & _
"}" & _
"#col1{" & _
"	width:149px;" & _
"	height:21px;" & _
"	float:left;" & _
"}" & _
"#col2{" & _
"	width:105px;" & _
"	height:18px;" & _
"	float:left;" & _
"	border-bottom:2px #000 solid;" & _
"	border-top:2px #000 solid;" & _
"	border-left:2px #000 solid;" & _
"	border-right:2px #000 solid;" & _
"	font-size:13px;" & _
"	text-align:right" & _
"}" & _
"#col3{" & _
"	width:166px;" & _
"	height:18px;" & _
"	float:left;" & _
"	border-bottom:2px #000 solid;" & _
"	border-top:2px #000 solid;" & _
"	border-right:2px #000 solid;" & _
"	font-size:13px;" & _
"	text-align:right" & _
"}" & _
"#col4{" & _
"	width:261px;" & _
"	height:18px;" & _
"	float:left;" & _
"}" & _
"#col5{" & _
"	width:137px;" & _
"	height:18px;" & _
"	float:left;" & _
"	border-bottom:2px #000 solid;" & _
"	border-top:2px #000 solid;" & _
"	border-right:1px #000 solid;" & _
"	border-left:2px #000 solid;" & _
"	font-size:13px;" & _
"	text-align:right" & _
"}" & _
"#col6{" & _
"	width:100px;" & _
"	height:18px;" & _
"	float:left;" & _
"	border-bottom:2px #000 solid;" & _
"	border-top:2px #000 solid;" & _
"	font-size:13px;" & _
"	margin:0;" & _
"	padding:0;" & _
"	text-align:left" & _
"}" & _
"#col7{" & _
"	width:687px;" & _
"	height:18px;" & _
"	float:left;" & _
"}" & _
"#col8{" & _
"	width:294px;" & _
"	height:18px;" & _
"	float:left;" & _
"	text-align:right;" & _
"	font-size:15px" & _
"}" & _
"#col9{" & _
"	width:128px;" & _
"	height:19px;" & _
"	float:left;" & _
"	border-bottom:2px #000 solid;" & _
"	border-right:2px #000 solid;" & _
"	border-left:2px #000 solid;" & _
"	font-size:13px;" & _
"	text-align:right" & _
"}" & _
"#col10{" & _
"	width:399px;" & _
"	height:19px;" & _
"	float:left;" & _
"	border-bottom:2px #000 solid;" & _
"	border-right:2px #000 solid;" & _
"	font-size:13px;" & _
"	text-align:right" & _
"}" & _
"#col11{" & _
"	width:100px;" & _
"	height:18px;" & _
"	float:left;" & _
"	text-align:left" & _
"}" & _
"#col12{" & _
"	width:128px;" & _
"	height:19px;" & _
"	float:left;" & _
"	border-top:2px #000 solid;" & _
"	border-right:2px #000 solid;" & _
"	border-left:2px #000 solid;" & _
"	font-size:13px;" & _
"	text-align:right" & _
"}" & _
"#col13{" & _
"	width:399px;" & _
"	height:19px;" & _
"	float:left;" & _
"	border-top:2px #000 solid;" & _
"	border-right:2px #000 solid;" & _
"	font-size:13px;" & _
"	text-align:right" & _
"}" & _
"#col14{" & _
"	width:294px;" & _
"	height:20px;" & _
"	float:left;" & _
"	border-right:2px #000 solid;" & _
"}" & _
"#col15{" & _
"	width:425px;" & _
"	height:20px;" & _
"	float:left;" & _
"	border-right:1px #000 solid;" & _
"}" & _
"#col16{" & _
"	width:154px;" & _
"	height:20px;" & _
"	float:left;" & _
"	border-right:1px #000 solid;" & _
"}" & _
"#col17{" & _
"	width:245px;" & _
"	height:20px;" & _
"	float:left;" & _
"	border-right:1px #000 solid;" & _
"}" & _
"#col18{" & _
"	width:100px;" & _
"	height:20px;" & _
"	float:left;" & _
"}" & _
"#col19{" & _
"	width:150px;" & _
"	height:29px;" & _
"	float:left;" & _
"	border-right:1px #000 solid;" & _
"	margin:0;" & _
"	padding:10px 0 0 0;" & _
"}" & _
"#col20{" & _
"	width:106px;" & _
"	height:29px;" & _
"	float:left;" & _
"	border-right:1px #000 solid;" & _
"	margin:0;" & _
"	padding:10px 0 0 0;" & _
"}" & _
"#col21{" & _
"	width:430px;" & _
"	height:29px;" & _
"	float:left;" & _
"	border-right:1px #000 solid;" & _
"	margin:0;" & _
"	padding:10px 0 0 0;" & _
"}" & _
"#col22{" & _
"	width:137px;" & _
"	height:29px;" & _
"	float:left;" & _
"	border-right:1px #000 solid;" & _
"	margin:0;" & _
"	padding:10px 0 0 0;" & _
"}" & _
"#col23{" & _
"	width:100px;" & _
"	height:29px;" & _
"	float:left;" & _
"	margin:0;" & _
"	padding:10px 0 0 0;" & _
"}" & _
"#col24{" & _
"	width:150px;" & _
"	height:19px;" & _
"	float:left;" & _
"	border-right:1px #000 solid;" & _
"	margin:0;" & _
"}" & _
"#col25{" & _
"	width:106px;" & _
"	height:19px;" & _
"	float:left;" & _
"	border-right:1px #000 solid;" & _
"	margin:0;" & _
"}" & _
"#col26{" & _
"	width:430px;" & _
"	height:19px;" & _
"	float:left;" & _
"	border-right:1px #000 solid;" & _
"	margin:0;" & _
"}" & _
"#col27{" & _
"	width:137px;" & _
"	height:19px;" & _
"	float:left;" & _
"	border-right:1px #000 solid;" & _
"	margin:0;" & _
"}" & _
"#col28{" & _
"	width:100px;" & _
"	height:19px;" & _
"	float:left;" & _
"	margin:0;" & _
"}" & _
"#col29{" & _
"	width:826px;" & _
"	height:60px;" & _
"	float:left;" & _
"	margin:0;" & _
"	text-align:right;" & _
"	font-size:12px;" & _
"	display:inline-block" & _
"}" & _
"#col30{" & _
"	width:101px;" & _
"	height:62px;" & _
"	float:left;" & _
"	margin:0;" & _
"}" & _
"#col31{" & _
"	width:100px;" & _
"	height:19px;" & _
"	float:left;" & _
"	margin:0;" & _
"	border-left:1px #000 solid;" & _
"	border-bottom:1px #000 solid;" & _
"	background:#00CCFF" & _
"}" & _
"#col32{" & _
"	width:826px;" & _
"	height:16px;" & _
"	float:left;" & _
"	margin:0;" & _
"	text-align:right;" & _
"	font-size:12px;" & _
"}" & _
"#col33{" & _
"	width:126px;" & _
"	height:19px;" & _
"	float:left;" & _
"	margin:0;" & _
"	text-align:right;" & _
"	font-size:14px;" & _
"	padding:5px 0 0 0;" & _
"}" & _
"#col34{" & _
"	width:559px;" & _
"	height:17px;" & _
"	float:left;" & _
"	margin:0;" & _
"	text-align:center;" & _
"	font-size:14px;" & _
"	padding:5px 0 0 0;" & _
"	border-top:1px #000 solid;" & _
"	border-bottom:1px #000 solid;" & _
"	border-left:1px #000 solid;" & _
"	border-right:1px #000 solid;" & _
"}" & _
"#col35{" & _
"	width:139px;" & _
"	height:19px;" & _
"	float:left;" & _
"	margin:0;" & _
"	text-align:right;" & _
"	font-size:14px;" & _
"	padding:5px 0 0 0;" & _
"}" & _
"#col36{" & _
"	width:448px;" & _
"	height:17px;" & _
"	float:left;" & _
"	margin:0;" & _
"	text-align:right;" & _
"	padding:0 0 0 0;" & _
"}" & _
"#col37{" & _
"	width:193px;" & _
"	height:19px;" & _
"	float:left;" & _
"	margin:0;" & _
"	text-align:right;" & _
"	padding:1px 4px 0 0;" & _
"}" & _
"#col38{" & _
"	width:251px;" & _
"	height:19px;" & _
"	float:left;" & _
"	margin:0;" & _
"	text-align:right;" & _
"	padding:0 0 0 0;" & _
"	border-bottom:1px #D6D7DB solid;" & _
"	background:#fff" & _
"}" & _
"" & _
"    </style>" & _
"</head>" & _
"<body>" & _
"<div align='center'>" & _
"<div id='page2'> " & _
"<div id='row17'><img src='" & docLink & "invoice/images/logo2.jpg'/></div>" & _
"<div id='row18'>FEDERAL MINISTRY OF INDUSTRY, TRADE AND INVESMENT" & _
"        COMMODITIES AND PRODUCTS INSPECTORATE DEPARTMENT" & _
"</div>" & _
"<div id='row19'>EXPORT PERMIT APPLICATION STATUS</div>" & _
"<div id='row20'>  " & _
"<div id='col36'>&nbsp;</div>" & _
"<div id='col37'>COMPANY REG ID:</div><div id='col38'>" & cboCompany.SelectedValue.Split("|").ToArray(0) & " </div> " & _
"<div id='col37'>COMPANY NAME:</div><div id='col38'>" & cboCompany.SelectedItem.Text & "</div>" & _
"<div id='col37'>EXPORT PERMIT QUARTER:</div><div id='col38'>" & txtExportName.Text & "</div>" & _
"<div id='col37'>EXPORT QUANTITY:</div><div id='col38'>" & finalQuantity & "</div>" & _
"<div id='col37'>PORT OF EXPORT:</div><div id='col38'>" & exportPort & "</div>" & _
"<div id='col37'>STATUS:</div><div id='col38'>" & "<font style='color:#F00'>APPLICATION REJECTED</font></div>" & _
"<div id='col37'>DATE:</div><div id='col38'>" & Now.ToString & "</div>" & _
"</div>" & _
"<div id='row38'>" & _
"<p align='left' class='MsoNormal'><b><span style='font-size:14.0pt'>COMMENT(S): " & txtInspComments.Text & "</span></b></p><br>" & _
"<p align='left' class='MsoNormal'><b><span style='font-size:12.0pt'>Thank you.<o:p></o:p></span></b></p><br>" & _
"<p align='right' class='MsoNormal'><b><span style='font-size:14.0pt'>" & txtInpectionOfficer.Text & "<o:p></o:p></span></b></p>" & _
"<p align='right' class='MsoNormal'><b><span style='font-size:14.0pt'>CPI Inspector<o:p></o:p></span></b></p>" & _
"</div>" & _
"<center>" & _
"<br />" & _
"</center>" & _
"</div>" & _
"</div>" & _
"</body> " & _
"</html>       "

    End Function

    Protected Sub btnResetA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnResetA.Click
        GenTool.resetform(pnlApproved, Nothing)
        lblProductA.Text = ""
        'lblStatusA.Text = ""
    End Sub

    Protected Sub btnEndorded_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEndorded.Click
        Dim msg As String = ""
        Try

            If txtEndordedBy.Text = "" Then
                msg = "The system couldnt assertain who is inspecting this transaction,please re-login and try again"
                Return
            End If

            Dim sql As String

            sql = "SELECT inspStatus from exportpermit where sysID=" & Val(txtExportID.Text)

            If Val(GenTool.getSingleValue(sql)) < 1 Then
                msg = "This Permit has not being inspected, please inspect before endorsement"
                Return
            End If

            msg = GenTool.checkControl(pnlEndorsed, FN, FV, FUpdate)

            If msg = "" Then


                sql = "Update exportpermit set " & FUpdate & " where sysID=" & Val(txtExportID.Text)

                If GenTool.ExecuteDatabase(sql) = True Then

                    Dim DSV As DataSet = GenTool.DataSetData("SELECT exportPort,finalQuantity FROM exportpermit where sysID=" & Val(txtExportID.Text))
                    Dim exportPort As String = ""
                    Dim finalQuantity As String = ""
                    If GenTool.HasDatasetRecords(DSV) = True Then
                        With DSV.Tables(0).Rows(0)
                            exportPort = .Item(0).ToString
                            finalQuantity = .Item(1).ToString
                        End With
                    End If

                    If chkEndorsed.Checked = True Then
                        sendmail("EXPORT PERMIT ENDORSED BY " & txtEndordedBy.Text, "ENDORSED", txtEndorsedComment.Text, finalQuantity, exportPort, txtInspDate.Text)

                        GenTool.FormHistory("EXPORT PERMIT :  " & txtExportName.Text & " WAS ENDORSED BY " & txtEndordedBy.Text, Request.UserHostAddress, Val(Session("sysID")))
                    Else
                        sendmail("EXPORT PERMIT WAS NOT ENDORSED", "NOT ENDORSED", txtEndorsedComment.Text, finalQuantity, exportPort, txtInspDate.Text)
                        GenTool.FormHistory("EXPORT PERMIT :  " & txtExportName.Text & " WAS NOT ENDORSED BY " & txtEndordedBy.Text, Request.UserHostAddress, Val(Session("sysID")))
                    End If

                    msg = "Record updated successfully"
                    cboCompany_SelectedIndexChanged(Nothing, Nothing)

                    btnResetE_Click(Nothing, Nothing)

                Else
                    msg = "Record update failed,please try again later"
                End If

                End If

        Catch ex As Exception
        Finally
            MessageBox.Show(UpdatePanel1, msg)
        End Try
    End Sub

    Protected Sub btnResetE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnResetE.Click
        GenTool.resetform(pnlEndorsed, Nothing)
        lblProductE.Text = ""
        'lblStatusE.Text = ""
    End Sub

    Protected Sub btnimportexporthistory_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnimportexporthistory.Click
        Try
            Session("xcID") = cboCompany.SelectedValue.Split("|").ToArray(0)
            Session("xcemail") = cboCompany.SelectedValue.Split("|").ToArray(1)
            Session("xcname") = cboCompany.SelectedItem.Text
            Session("xcexportname") = cboExportPermit.SelectedItem.Text
            Session("cexportID") = cboExportPermit.SelectedValue

            Response.Redirect("admimportexceldata.aspx")
        Catch ex As Exception
        End Try
    End Sub

    'Protected Sub btnView1_Click(sender As Object, e As System.EventArgs) Handles btnView1.Click, btnView2.Click, btnView3.Click, btnView4.Click, btnView5.Click, btnView6.Click
    '    Try
    '        Dim fil As String = docLink & "coverLetter/" & btnView1.ValidationGroup
    '        Response.Redirect(fil)
    '    Catch ex As Exception
    '    End Try
    '    Dim btnAA As Button = CType(sender, Button)
    'End Sub

   
    Protected Sub btnRejectInspection_Click(sender As Object, e As System.EventArgs) Handles btnRejectInspection.Click
        Dim msg As String = ""
        Try

            If txtInpectionOfficer.Text = "" Then
                msg = "The system couldnt assertain who is rejecting this inspection,please re-login and try again"
                Return
            End If
            Dim sql As String

            chkInspected.ValidationGroup = ""

            msg = GenTool.checkControl(pnlInspected, FN, FV, FUpdate)

            If msg = "" Then


                sql = "Update exportpermit set " & FUpdate & ",inspStatus=2 where sysID=" & Val(txtExportID.Text)

                If GenTool.ExecuteDatabase(sql) = True Then

                    Dim DSV As DataSet = GenTool.DataSetData("SELECT exportPort,finalQuantity FROM exportpermit where sysID=" & Val(txtExportID.Text))
                    Dim exportPort As String = ""
                    Dim finalQuantity As String = ""
                    If GenTool.HasDatasetRecords(DSV) = True Then
                        With DSV.Tables(0).Rows(0)
                            exportPort = .Item(0).ToString
                            finalQuantity = .Item(1).ToString
                        End With
                    End If

                
                    sendmail1("EXPORT PERMIT WAS NOT APPROVED FOR INSPECTION ", exportPort, finalQuantity)
                    GenTool.FormHistory("EXPORT PERMIT :  " & txtExportName.Text & " WAS NOT SATISFACTORY WITH INSPECTION BY " & txtInpectionOfficer.Text, Request.UserHostAddress, Val(Session("sysID")))

                    msg = "Record updated successfully"
                    cboCompany_SelectedIndexChanged(Nothing, Nothing)

                    btnResetI_Click(Nothing, Nothing)

                Else
                    msg = "Record update failed,please try again later"
                End If

            End If

        Catch ex As Exception
        Finally
            MessageBox.Show(UpdatePanel1, msg)
            chkInspected.ValidationGroup = "inspStatus"
        End Try
    End Sub
End Class
