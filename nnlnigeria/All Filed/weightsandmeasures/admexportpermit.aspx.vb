Imports System.Data

Partial Class admexportpermit
    Inherits System.Web.UI.Page

    Dim GenTool As NNLN = xsmsCentralToolx.SetTool

    Protected Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init
        Try
            TabRecommeded.Visible = sysDBUser.recommendexportimport
            TabInspected.Visible = sysDBUser.inspectexportimport
            TabEndorsed.Visible = sysDBUser.endorseexportimport
            TabApproved.Visible = sysDBUser.approveexportimport

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

    Protected Sub cboCompany_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCompany.SelectedIndexChanged
        Try
            Dim sd As String = "select sysID as ID,exportpermitName as PermitQuarter,ExporterName,productnameforcast as 'Prod Desc/Grade',date_format(ExportDate,'%D-%M-%Y') as ExportDate,ExportPort,finalQuantity as ExportQty,concat(periodCoveredfrom, ' To ',periodCoveredTo) as 'Period Covered',TotalamtUS as 'F.O.B Value(USD)',ExportMode from exportpermit where companyID=" & Val(cboCompany.SelectedValue.Split("|").ToArray(0))

            Dim ds As DataSet = GenTool.DataSetData(sd)
            filldb(ds)

            cboExportPermit.Items.Clear()

            cboExportPermit.DataValueField = "ID"
            cboExportPermit.DataTextField = "PermitName"
            cboExportPermit.DataSource = ds.Tables(0)
            cboExportPermit.DataBind()
            btnimportexporthistory.Visible = False
            btnResetR_Click(Nothing, Nothing)

        Catch ex As Exception
            GenTool.GrabError(ex.Message, "cboCompany_SelectedIndexChanged")
        Finally
            cboExportPermit.Items.Insert(0, "Select Export Permit")
        End Try
    End Sub

    Protected Sub cboExportPermit_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboExportPermit.SelectedIndexChanged
        Try

            Dim sd As String = "select sysID as ID,exportpermitName as PermitName,ExporterName,date_format(ExportDate,'%D-%M-%Y') as ExportDate,finalQuantity as Quantity,destCountry as 'Dest Country',ExportMode,if(recommendationStatus=0,'Not Recommended','Recommeded') as Recommendation,If(inspStatus=0,'Not Inspected','Inspected') as Inspection,if(endoresedStatus=0,'Not Endorsed','Endorsed') as Endorsed,if(approvedStatus=0,'Not Approved','Approved') as Approval from exportpermit where companyID=" & Val(cboCompany.SelectedValue.Split("|").ToArray(0)) & " AND sysID=" & Val(cboExportPermit.SelectedValue)
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

    Protected Sub grd_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grd.SelectedIndexChanged
        Try
            txtExportID.Text = grd.SelectedRow.Cells(1).Text
            txtExportName.Text = grd.SelectedRow.Cells(2).Text

            lblAPN.Text = grd.SelectedRow.Cells(2).Text
            lblAPNS.Text = grd.SelectedRow.Cells(8).Text

            lblProductE.Text = lblAPN.Text
            lblStatusE.Text = grd.SelectedRow.Cells(10).Text

            lblProductA.Text = lblAPN.Text
            lblStatusA.Text = grd.SelectedRow.Cells(11).Text

            Dim ds As DataSet = GenTool.DataSetData("select * from exportpermit where sysID=" & Val(txtExportID.Text))

            GenTool.resetform(pnlRecommend, ds)
            GenTool.resetform(TabInspected, ds)
            GenTool.resetform(TabEndorsed, ds)
            GenTool.resetform(TabApproved, ds)


        Catch ex As Exception
        End Try
    End Sub

    Dim FN As String = ""
    Dim FV As String = ""
    Dim FUpdate As String = ""

    Protected Sub btnRecommend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRecommend.Click
        Dim msg As String = ""
        Try

            If txtRecommendedBy.Text = "" Then
                txtRecommendedBy.Text = Session("Fullname")
            End If

            If txtRecommendedBy.Text = "" Then
                msg = "The system couldnt assertain who is recommending this transaction,please re-login and try again"
                Return
            End If

            msg = GenTool.checkControl(pnlRecommend, FN, FV, FUpdate)

            If msg = "" Then
                Dim sql As String

                sql = "Update exportpermit set " & FUpdate & " where sysID=" & Val(txtExportID.Text)

                If GenTool.ExecuteDatabase(sql) = True Then

                    If chkrecommend.Checked = True Then
                        sendmail("EXPORT PERMIT RECOMMENDED BY " & txtRecommendedBy.Text, "RECOMMENDATION", txtRecommednComments.Text)
                        GenTool.FormHistory("EXPORT PERMIT :  " & txtExportName.Text & " WAS RECOMMENDED BY " & txtRecommendedBy.Text, Request.UserHostAddress, Val(Session("sysID")))
                    Else
                        sendmail("EXPORT PERMIT NOT RECOMMENDED", "RECOMMENDATION", txtRecommednComments.Text)
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
        lblAPNS.Text = ""
    End Sub


    Private Sub sendmail(ByVal subject As String, ByVal MsgStatus As String, ByVal body As String)
        Try
            Dim cBlast As New MailContents
            cBlast.AttarchFiles = ""
            cBlast.BodyM = getBody(MsgStatus, body)
            cBlast.IsBodyHtml = True
            cBlast.mailbcc = Nothing
            cBlast.mailcc = New Net.Mail.MailAddress("operations@wmdnigeria.com")
            cBlast.mailfrom = New Net.Mail.MailAddress("operations@wmdnigeria.com")
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


            If dsLcountry Is Nothing OrElse dsLcountry.Tables.Count < 1 OrElse dsLcountry.Tables(0).Rows.Count < 1 Then
                getCountry()
            End If

            cboCountry.Items.Clear()
            cboCountry.DataValueField = "sysID"
            cboCountry.DataTextField = "Country"
            cboCountry.DataSource = dsLcountry.Tables(0)
            cboCountry.DataBind()
            cboCountry.Items.Insert(0, "Select Country")

        Catch ex As Exception
        End Try
    End Sub

    Private Function getBody(ByVal MsgStatus As String, ByVal body As String) As String
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
"                        REG ID</td>" & _
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
"                        EXPORT PERMIT NAME</td>" & _
"                    <td align='left'>" & _
"                        " & txtExportName.Text & "</td>" & _
"                </tr>" & _
"                <tr>" & _
"                    <td align='left' class='zebraodd' valign='middle'>" & _
"                        STATUS</td>" & _
"                    <td align='left'>" & _
"                        " & MsgStatus & "</td>" & _
"                </tr>" & _
"            </table>" & _
"            <br />" & _
"            <table class='hlineheader'>" & _
"                <tr>" & _
"                    <th nowrap rowspan='2'>" & _
"                        WELCOME!</th>" & _
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
                txtInpectionOfficer.Text = Session("Fullname")
            End If

            If txtInpectionOfficer.Text = "" Then
                msg = "The system couldnt assertain who is inspecting this transaction,please re-login and try again"
                Return
            End If
            Dim sql As String

            sql = "SELECT recommendationStatus from exportpermit where sysID=" & Val(txtExportID.Text)

            If Val(GenTool.getSingleValue(sql)) < 1 Then
                msg = "This Permit has not being recommeded, please recommend it before inspection"
                Return
            End If

            msg = GenTool.checkControl(pnlInspected, FN, FV, FUpdate)

            If msg = "" Then


                sql = "Update exportpermit set " & FUpdate & " where sysID=" & Val(txtExportID.Text)

                If GenTool.ExecuteDatabase(sql) = True Then



                    If chkInspected.Checked = True Then
                        sendmail("EXPORT PERMIT INSPECTED BY " & txtInpectionOfficer.Text, "INSPECTION", txtInspComments.Text)
                        GenTool.FormHistory("EXPORT PERMIT :  " & txtExportName.Text & " WAS INSPECTED BY " & txtInpectionOfficer.Text, Request.UserHostAddress, Val(Session("sysID")))
                    Else
                        sendmail("EXPORT PERMIT WAS NOT APPROVED FOR INSPECTION ", "INSPECTION", txtInspComments.Text)
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
                txtApprovedBy.Text = Session("Fullname")
            End If

            If txtApprovedBy.Text = "" Then
                msg = "The system couldnt assertain who is approving this transaction,please re-login and try again"
                Return
            End If

            Dim sql As String

            sql = "SELECT endoresedStatus from exportpermit where sysID=" & Val(txtExportID.Text)

            If Val(GenTool.getSingleValue(Sql)) < 1 Then
                msg = "This Permit has not being endorsed, please recommend,inspect.endorse it before approval"
                Return
            End If

            msg = GenTool.checkControl(pnlApproved, FN, FV, FUpdate)

            If msg = "" Then


                sql = "Update exportpermit set " & FUpdate & " where sysID=" & Val(txtExportID.Text)

                If GenTool.ExecuteDatabase(sql) = True Then

                    If chkApproved.Checked = True Then
                        sendmail("EXPORT PERMIT APPROVED BY " & txtApprovedBy.Text, "APPROVAL", txtApprovedComments.Text)

                        GenTool.FormHistory("EXPORT PERMIT :  " & txtExportName.Text & " WAS APPROVED BY " & txtApprovedBy.Text, Request.UserHostAddress, Val(Session("sysID")))

                    Else
                        sendmail("EXPORT PERMIT WAS NOT APPROVED", "APPROVAL", txtApprovedComments.Text)
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

    Protected Sub btnResetA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnResetA.Click
        GenTool.resetform(pnlApproved, Nothing)
        lblProductA.Text = ""
        lblStatusA.Text = ""
    End Sub

    Protected Sub btnEndorded_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEndorded.Click
        Dim msg As String = ""
        Try

            If txtEndordedBy.Text = "" Then
                txtEndordedBy.Text = Session("Fullname")
            End If

            If txtEndordedBy.Text = "" Then
                msg = "The system couldnt assertain who is inspecting this transaction,please re-login and try again"
                Return
            End If

            Dim sql As String

            sql = "SELECT inspStatus from exportpermit where sysID=" & Val(txtExportID.Text)

            If Val(GenTool.getSingleValue(sql)) < 1 Then
                msg = "This Permit has not being inspected, please recommend,inspect it before endorsement"
                Return
            End If

            msg = GenTool.checkControl(pnlInspected, FN, FV, FUpdate)

            If msg = "" Then


                sql = "Update exportpermit set " & FUpdate & " where sysID=" & Val(txtExportID.Text)

                If GenTool.ExecuteDatabase(sql) = True Then

                    If chkEndorsed.Checked = True Then
                        sendmail("EXPORT PERMIT ENDORSED BY " & txtEndordedBy.Text, "ENDORSEMENT", txtEndorsedComment.Text)

                        GenTool.FormHistory("EXPORT PERMIT :  " & txtExportName.Text & " WAS ENDORSED BY " & txtEndordedBy.Text, Request.UserHostAddress, Val(Session("sysID")))
                    Else
                        sendmail("EXPORT PERMIT WAS NOT ENDORSED", "ENDORSEMENT", txtEndorsedComment.Text)
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
        lblStatusE.Text = ""
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
End Class
