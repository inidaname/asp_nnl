Imports System.Data

Partial Class exportpermit
    Inherits System.Web.UI.Page
    Dim GenTool As NNLN = xsmsCentralToolx.SetTool

    Sub getAmtBrougForward()
        Try
            Dim sd As String = GenTool.getSingleValue("select sum(TotalAmtNig-amtUsedNGN) from exportpermit where Paid=1 AND companyID=" & Val(Session("ID")))
            lblAmtUsed.Text = Val(sd).ToString("N #,#.00")
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If String.IsNullOrEmpty(Session("ID")) = True Then
            Try
                Response.Redirect("Default.aspx?error=You have not login,please enter your credentials on the space provided and click login button. Register your account details if you are new")
            Catch ex As Exception
            End Try

        End If
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

            cboUC.DataTextField = "UCName"
            cboUC.DataValueField = "sysID"
            cboUC.DataSource = GenTool.DataSetData("select UCName,sysID from exportuc where companyID=" & Val(Session("ID"))).Tables(0)
            cboUC.DataBind()
            cboUC.Items.Insert(0, "Select Value")
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Try

            txtID.Text = Session("ID")

            If IsPostBack = False Then
                getAmtBrougForward()

                If dsLcountry Is Nothing OrElse dsLcountry.Tables.Count < 1 OrElse dsLcountry.Tables(0).Rows.Count < 1 Then
                    getCountry()
                End If

                getSystemSetup()

                Try
                    With dsSystemSetup.Tables(0).Rows(0)
                        txtamtPerBarrel.Text = .Item("AmtPerBarrel")
                        txtExchangeRate.Text = .Item("exchangeRate")
                    End With
                Catch ex As Exception
                End Try
                setupRest()

                cboCountry.Items.Clear()
                cboCountry.DataValueField = "sysID"
                cboCountry.DataTextField = "Country"
                cboCountry.DataSource = dsLcountry.Tables(0)
                cboCountry.DataBind()
                cboCountry.Items.Insert(0, "Select Country")

                resetform(True)

                Dim regType As String = Request("pg")

                If String.IsNullOrEmpty(regType) = False AndAlso regType = "edit" Then
                    Dim fsql As String = "select * from exportpermit where sysID=" & Val(Session("ID"))

                    Dim dsf As DataSet = GenTool.DataSetData(fsql)
                    resetform(True, dsf)
                    btnPreview_ConfirmButtonExtender.ConfirmText = "Are you SURE you want to UPDATE this record?"

                Else

                    btnPreview_ConfirmButtonExtender.ConfirmText = "Are you SURE you want to SAVE this record?"

                End If

            End If


        Catch ex As Exception
            CyMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub resetform(ByVal setFont As Boolean, Optional ByVal ds As DataSet = Nothing)
        Try
            Dim ctn As New System.Web.UI.Control


            For Each ctn In Panel1.Controls

                If TypeOf ctn Is System.Web.UI.WebControls.TextBox Then
                    Dim txt As TextBox = CType(ctn, TextBox)

                    If ds IsNot Nothing Then
                        txt.Text = GenTool.getValueSystem(ds, txt.ValidationGroup)
                        If txt.TextMode = TextBoxMode.Password Then
                            txt.Attributes.Add("value", txt.Text)
                        End If
                    Else
                        If setFont = False Then
                            txt.Text = ""
                        Else
                            txt.Font.Name = "Calibri"
                            txt.Font.Size = 10
                        End If
                    End If

                End If

                If TypeOf ctn Is System.Web.UI.WebControls.DropDownList Then
                    Dim cbod As DropDownList = CType(ctn, DropDownList)

                    If ds IsNot Nothing Then
                        cbod.SelectedIndex = GenTool.getddlindexvalue(cbod, GenTool.getValueSystem(ds, cbod.ValidationGroup))
                    Else
                        If setFont = False Then
                            If cbod.Items.Count > 0 Then
                                cbod.SelectedIndex = 0
                            Else
                                cbod.Text = ""
                            End If
                        Else
                            cbod.Font.Name = "Calibri"
                            cbod.Font.Size = 10
                        End If

                    End If
                End If

            Next

            If setFont = False Then
                lblMsg.Text = ""
            End If

         

        Catch ex As Exception
        End Try
    End Sub

    Dim FN As String = ""
    Dim FV As String = ""
    Dim FUpdate As String = ""

    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        Dim msgtext As String = ""

        Try

            FUpdate = ""
            FV = ""
            FN = ""
            lblMsg.Text = ""

            If String.IsNullOrEmpty(Session("email")) = True Then
                txtTranscode.Text = GenTool.GenerateRNDCode(True, True) & GenTool.GenerateUniqueCode & GenTool.GenerateRNDCode(True)
            End If

            msgtext = GenTool.checkControl(Panel1, FN, FV, FUpdate)

            If msgtext <> "" Then Return

            Dim fStatus As Boolean = True

            Dim sql = "Insert into exportpermit(" & FN & ") Values (" & FV & ")"


            If GenTool.ExecuteDatabase(sql) = True Then

                If fStatus = True Then

                    Dim orderID As String = Strings.Right(GenTool.GenerateRNDCode(True) & GenTool.GenerateUniqueCode, 10)

                    sql = "insert into paymentsheet(companyID,amountDue,regDate,regTime,narration,paymentName,accStatus,OrderId,transcode) Values (" & _
                     Val(Session("ID")) & "," & txtAmtNGN.Text.Replace(",", "") & ",now(),now(),'Export Permit Application'," & GenTool.addbackslash(Session("cname")) & ",0," _
                     & GenTool.addbackslash(orderID) & "," & GenTool.addbackslash(txtTranscode.Text) & ")"

                    If GenTool.ExecuteDatabase(sql) = True Then

                        sendmail(txtemail.Text)

                        msgtext = "Record created successfully"
                        Try
                            Session("Msg") = "Your Export Permit Fee = "
                            Session("Amt2pay") = Val(txtAmtNGN.Text).ToString("#,#.0000")
                            Response.Redirect("thankyou.aspx")
                        Catch ex As Exception
                        End Try

                    Else
                        msgtext = "Your registration can't contnue,there is account error, pls contact service line with your company details"
                        Return
                    End If

                Else
                    Try
                        msgtext = "Record updated successfully"
                        Response.Redirect("registerdevice.aspx")
                    Catch ex As Exception
                        MessageBox.Show(Me, ex.Message)
                    End Try
                End If

                resetform(False)

            Else
                msgtext = "The system was unable to save this record,check your entry and try again,if it continues contact admin"
            End If

        Catch ex As Exception
            lblMsg.Text = ex.Message
        Finally
            lblMsg.Text = msgtext
            If msgtext <> "" Then MessageBox.Show(Me, msgtext)
        End Try
    End Sub

    Protected Sub btnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click
        resetform(False)
    End Sub

    Private Sub sendmail(Optional ByVal email As String = "")
        Try
            Dim cBlast As New MailContents
            cBlast.AttarchFiles = ""
            cBlast.BodyM = getBody()
            cBlast.IsBodyHtml = True
            cBlast.mailbcc = Nothing
            cBlast.mailcc = New Net.Mail.MailAddress("operations@wmdnigeria.com")
            cBlast.mailfrom = New Net.Mail.MailAddress("operations@wmdnigeria.com")
            cBlast.mailto = New Net.Mail.MailAddress(email)
            cBlast.Subject = "Export Permit Applied"
            GenTool.SendnMailBox(cBlast)

        Catch ex As Exception
        End Try
    End Sub

    Private Function getBody() As String
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
"            EXPORT PERMIT APPLICATION</div>" & _
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
"                        TRANSACTION CODE</td>" & _
"                    <td align='left'>" & _
"                        " & txtTranscode.Text & "</td>" & _
"                </tr>" & _
"                <tr>" & _
"                    <td align='left' class='zebraodd' valign='middle'>" & _
"                        COMPANY NAME</td>" & _
"                    <td align='left'>" & _
"                        " & Session("cname") & "</td>" & _
"                </tr>" & _
"                <tr>" & _
"                    <td align='left' class='zebraodd' valign='middle'>" & _
"                        EXPORT Quarter</td>" & _
"                    <td align='left'>" & _
"                        " & txtexportPermitName.Text & "</td>" & _
"                </tr>" & _
"                <tr>" & _
"                    <td align='left' class='zebraodd' valign='middle'>" & _
"                        QUANTITY APPLIED IN BARRELS</td>" & _
"                    <td align='left'>" & _
"                        " & txtFinalQty.Text & "</td>" & _
"                </tr>" & _
"                <tr>" & _
"                    <td align='left' class='zebraodd' valign='middle'>" & _
"                        EXPORT MODE</td>" & _
"                    <td align='left'>" & _
"                        " & txtusername16.Text & "</td>" & _
"                </tr>" & _
"                <tr>" & _
"                    <td align='left' class='zebraodd' valign='middle'>" & _
"                        EXPORTER NAME</td>" & _
"                    <td align='left'>" & _
"                        " & txtAsnwer.Text & "</td>" & _
"                </tr>" & _
"                <tr>" & _
"                    <td align='left' class='zebraodd' valign='middle'>" & _
"                        DESTINATION COUNTRY</td>" & _
"                    <td align='left'>" & _
"                        " & cboCountry.Text & "</td>" & _
"                </tr>" & _
"                <tr>" & _
"                    <td align='left' class='zebraodd' valign='middle'>" & _
"                        PERIOD COVERED</td>" & _
"                    <td align='left'>" & _
"                        " & cboPCF.Text & " TO " & cboPCT.Text & "</td>" & _
"                </tr>" & _
"                <tr>" & _
"                    <td align='left' class='zebraodd' valign='middle'>" & _
"                        PROPOSED DATE OF EXPORT</td>" & _
"                    <td align='left'>" & _
"                        " & txtDPTTo.Text & "</td>" & _
"                </tr>" & _
"                <tr>" & _
"                    <td align='left' class='zebraodd' valign='middle'>" & _
"                        AMT IN US DOLLARS</td>" & _
"                    <td align='left'>" & _
"                        " & txtAmtUS.Text & "</td>" & _
"                </tr>" & _
"                <tr>" & _
"                    <td align='left' class='zebraodd' valign='middle'>" & _
"                        AMT IN NGN</td>" & _
"                    <td align='left'>" & _
"                        " & txtAmtNGN.Text & "</td>" & _
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
"                       " & "Welcome!<br> Please take time and register all your<a href='www.nnlnigeria.com/registerdevice.aspx'> devices.</a><br>Our staff will go round and verify all your registered devices for correctness and proper billing. Thanks" & "</td>" & _
"                </tr>" & _
"            </table>" & _
"            <br />" & _
"        </div>" & _
"        </center>" & _
"    </form>" & _
"</body>" & _
"</html>"

    End Function

    Protected Sub cboPCF_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPCF.SelectedIndexChanged
        If cboPCF.SelectedIndex + 2 < cboPCT.Items.Count Then
            cboPCT.SelectedIndex = cboPCF.SelectedIndex + 2
        End If
        If cboPCF.SelectedIndex = 0 Then
            cboPCT.SelectedIndex = 0
        End If
    End Sub

    Protected Sub txtQuatity_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQuatity.TextChanged
        Try

            If cboqtyMeasure.SelectedIndex = 2 Then
                Try
                    txtFinalQty.Text = Val(txtQuatity.Text) * 7.1475121
                Catch ex As Exception
                End Try
            Else
                txtFinalQty.Text = txtQuatity.Text
            End If

            txtAmtUS.Text = Val(txtamtPerBarrel.Text) * Val(txtFinalQty.Text)
            txtAmtNGN.Text = Val(txtExchangeRate.Text) * Val(txtAmtUS.Text)

        Catch ex As Exception
        End Try
    End Sub

 
End Class
