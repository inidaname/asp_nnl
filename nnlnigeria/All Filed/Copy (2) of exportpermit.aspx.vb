Imports System.Data

Partial Class exportpermit
    Inherits System.Web.UI.Page
    Dim GenTool As NNLN = xsmsCentralToolx.SetTool

    Property dsMain As DataSet
        Get
            Return CType(Session("dsmain"), DataSet)
        End Get
        Set(value As DataSet)
            Session("dsmain") = value
        End Set
    End Property

    Sub getAmtBrougForward()
        Try
            Dim sd As String = GenTool.getSingleValue("select sum(TotalAmtNig-amtUsedNGN) from exportpermit where Paid=1 AND companyID=" & Val(Session("ID")))
            lblAmtUsed.Text = Val(sd).ToString("$ #,#.00")
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

        If IsPostBack = False Then
            Page.Form.Attributes.Add("enctype", "multipart/form-data")
        End If
    End Sub

    Private Sub setupRest()
        Try
            cboPCF.Items.Clear()
            cboPCT.Items.Clear()

            cboPCF.Items.Add("Select Value")
            cboPCT.Items.Add("Select Value")
            For K As Int16 = 1 To 12
                cboPCF.Items.Add(MonthName(K))
                cboPCT.Items.Add(MonthName(K))
            Next

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Try

            If IsPostBack = False Then

                dsMain = GenTool.DataSetData("Select 'ID','Permit Name','Exporter Name','Product Description','Period Covered From','Period Covered To','Quantity','Measure','Export Port','Amt/Barrel','F.O.B Value(USD)','Calc. Qty' from quitsetup limit 0")
                dsMain.Tables(0).PrimaryKey = New DataColumn() {dsMain.Tables(0).Columns("ID")}

                txtID.Text = Session("ID")
                getAmtBrougForward()

                If dsLcountry Is Nothing OrElse dsLcountry.Tables.Count < 1 OrElse dsLcountry.Tables(0).Rows.Count < 1 Then
                    getCountry()
                End If

                getSystemSetup()

                setupRest()

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

            txtTranscode.Text = GenTool.GenerateGlobalUniqueCode & GenTool.GenerateUniqueCode & GenTool.GenerateRNDCode(True, True)

            If GenTool.ValidateEmail(txtemail.Text) = False Then
                msgtext = "Invalid email address"
                Return
            End If

            'If fileLetterPicture2.HasFile = True Then
            '    Dim extN As String = Guid.NewGuid.ToString & IO.Path.GetExtension(fileLetterPicture2.FileName)
            '    Dim fil As String = pathdoclink & "coverLetter/" & extN
            '    fileLetterPicture2.SaveAs(fil)
            '    Session.Add("fileLetterPicture2", extN)
            'End If

            'If fileLetterPicture3.HasFile = True Then
            '    Dim extN As String = Guid.NewGuid.ToString & IO.Path.GetExtension(fileLetterPicture3.FileName)
            '    Dim fil As String = pathdoclink & "coverLetter/" & extN
            '    fileLetterPicture3.SaveAs(fil)
            '    Session.Add("fileLetterPicture3", extN)
            'End If

            'If fileLetterPicture4.HasFile = True Then
            '    Dim extN As String = Guid.NewGuid.ToString & IO.Path.GetExtension(fileLetterPicture4.FileName)
            '    Dim fil As String = pathdoclink & "coverLetter/" & extN
            '    fileLetterPicture4.SaveAs(fil)
            '    Session.Add("fileLetterPicture4", extN)
            'End If

            'If fileLetterPicture5.HasFile = True Then
            '    Dim extN As String = Guid.NewGuid.ToString & IO.Path.GetExtension(fileLetterPicture5.FileName)
            '    Dim fil As String = pathdoclink & "coverLetter/" & extN
            '    fileLetterPicture5.SaveAs(fil)
            '    Session.Add("fileLetterPicture5", extN)
            'End If

            'If fileLetterPicture6.HasFile = True Then
            '    Dim extN As String = Guid.NewGuid.ToString & IO.Path.GetExtension(fileLetterPicture6.FileName)
            '    Dim fil As String = pathdoclink & "coverLetter/" & extN
            '    fileLetterPicture6.SaveAs(fil)
            '    Session.Add("fileLetterPicture6", extN)
            'End If

            txtpassportname1.Text = IIf(String.IsNullOrEmpty(Session("fileLetterPicture1")) = True, "", Session("fileLetterPicture1"))
            txtpassportname2.Text = IIf(String.IsNullOrEmpty(Session("fileLetterPicture2")) = True, "", Session("fileLetterPicture2"))
            txtpassportname3.Text = IIf(String.IsNullOrEmpty(Session("fileLetterPicture3")) = True, "", Session("fileLetterPicture3"))
            txtpassportname4.Text = IIf(String.IsNullOrEmpty(Session("fileLetterPicture4")) = True, "", Session("fileLetterPicture4"))
            txtpassportname5.Text = IIf(String.IsNullOrEmpty(Session("fileLetterPicture5")) = True, "", Session("fileLetterPicture5"))
            txtpassportname6.Text = IIf(String.IsNullOrEmpty(Session("fileLetterPicture6")) = True, "", Session("fileLetterPicture6"))

            getChange()

            If String.IsNullOrEmpty(txtFinalQty.Text) = True Then
                txtFinalQty.Text = "0"
            End If

            If chkMultiple.Checked = True Then
                If grd.Rows.Count < 1 Then
                    msgtext = "You have not added any application,please fill the form above and click ADD APPLICATION before you continue"
                End If
            End If

            txtID.Text = Session("ID")
            FN = ""
            FV = ""

            If chkMultiple.Checked = False Then
                Dim fs As String = "TerminalOperator;NoneTerminalOperator"
                msgtext = GenTool.generateSQL(Panel1, FN, FV, FUpdate, fs)
                FN &= ",TerminalOperator,NoneTerminalOperator"
                FV &= "," & IIf(RadioButton3.Checked = True, "1", "0") & "," & IIf(RadioButton4.Checked = True, "1", "0")
            Else
                Dim fs As String = "finalQuantity;TerminalOperator;NoneTerminalOperator;exportpermitName;exporterName;productnameforcast;periodCoveredFrom;periodCoveredTo;Measure;quantity;exportPort;amtPerBarrelUS;TotalamtUS"
                msgtext = GenTool.generateSQL(Panel1, FN, FV, FUpdate, fs)
                FN &= ",TerminalOperator,NoneTerminalOperator"
                FV &= "," & IIf(RadioButton3.Checked = True, "1", "0") & "," & IIf(RadioButton4.Checked = True, "1", "0")
            End If

            If msgtext <> "" Then Return

            Dim sql = "Insert into exportpermit(" & FN & ") Values (" & FV & ")"

            txtcompanyname.Text = Session("cname")
            getQueryString()

            If chkMultiple.Checked = True Then
                Session.Add("dsMainx", dsMain)
                Session.Add("FN", FN)
                Session.Add("FV", FV)
                Response.Redirect("exportappbulks.aspx?" & kbQuerytString)

            Else
                Session("exportp") = sql
                Response.Redirect("exportappdetails.aspx?" & kbQuerytString)
            End If

        Catch ex As Exception
            lblMsg.Text = ex.Message
        Finally
            lblMsg.Text = msgtext
            If msgtext <> "" Then MessageBox.Show(Panel1, msgtext)
        End Try
    End Sub

    Protected Sub btnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click
        fileLetterPicture1.Visible = False
        fileLetterPicture2.Visible = False
        fileLetterPicture3.Visible = False
        fileLetterPicture4.Visible = False
        fileLetterPicture5.Visible = False
        fileLetterPicture6.Visible = False
        GenTool.resetform(Panel1)
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
"                        </td>" & _
"                    <td align='left'>" & _
"                        " & "</td>" & _
"                </tr>" & _
"                <tr>" & _
"                    <td align='left' class='zebraodd' valign='middle'>" & _
"                        EXPORTER NAME</td>" & _
"                    <td align='left'>" & _
"                        " & txtAsnwer.Text & "</td>" & _
"                </tr>" & _
"                <tr>" & _
"                    <td align='left' class='zebraodd' valign='middle'>" & _
"                        </td>" & _
"                    <td align='left'>" & _
"                        </td>" & _
"                </tr>" & _
"                <tr>" & _
"                    <td align='left' class='zebraodd' valign='middle'>" & _
"                        PERIOD COVERED</td>" & _
"                    <td align='left'>" & _
"                        " & cboPCF.Text & " TO " & cboPCT.Text & "</td>" & _
"                </tr>" & _
"                <tr>" & _
"                    <td align='left' class='zebraodd' valign='middle'>" & _
"                        </td>" & _
"                    <td align='left'>" & _
"                        </td>" & _
"                </tr>" & _
"                <tr>" & _
"                    <td align='left' class='zebraodd' valign='middle'>" & _
"                        AMT IN US DOLLARS</td>" & _
"                    <td align='left'>" & _
"                        " & txtAmtUS.Text & "</td>" & _
"                </tr>" & _
"                <tr>" & _
"                    <td align='left' class='zebraodd' valign='middle'>" & _
"                         </td>" & _
"                    <td align='left'>" & _
"                        " & "</td>" & _
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

    Sub getChange()
        Try

            If cboqtyMeasure.SelectedIndex = 2 Then
                Try
                    txtFinalQty.Text = Val(txtQuatity.Text) * 7.1475121
                Catch ex As Exception
                End Try
            Else
                txtFinalQty.Text = txtQuatity.Text
            End If

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub txtQuatity_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQuatity.TextChanged, cboqtyMeasure.SelectedIndexChanged
        getChange()
    End Sub
 
    Protected Sub fileStuPicture_UploadedComplete(sender As Object, e As System.EventArgs) Handles fileLetterPicture1.UploadedComplete
        Try
            If fileLetterPicture1.HasFile = True Then
                Dim extN As String = Guid.NewGuid.ToString & IO.Path.GetExtension(fileLetterPicture1.FileName)
                Dim fil As String = pathdoclink & "coverLetter/" & extN
                fileLetterPicture1.SaveAs(fil)
                Session.Add("fileLetterPicture1", extN)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Dim kbQuerytString As String = ""

    Sub getQueryString()
        Try
            For Each ctn As Control In Panel1.Controls
                Try

                    If TypeOf ctn Is DropDownList Then
                        Dim cbo As DropDownList = CType(ctn, DropDownList)
                        If cbo.SelectedIndex > 0 Then
                            kbQuerytString &= "&" & cbo.ID & "=" & GenTool.Convert2PercentageFormat(cbo.SelectedItem.Text.ToUpper)
                        End If

                    ElseIf TypeOf ctn Is TextBox Then
                        Dim cbo As TextBox = CType(ctn, TextBox)
                        If String.IsNullOrEmpty(cbo.Text) = False Then
                            kbQuerytString &= "&" & cbo.ID & "=" & GenTool.Convert2PercentageFormat(cbo.Text.ToUpper)
                        End If
                    End If

                    If ctn.HasControls = True Then
                        getctlName(ctn)
                    End If
                Catch ex As Exception
                End Try
            Next

        Catch ex As Exception
        End Try
    End Sub

    Sub getctlName(ByVal ctn As Control)
        Try
            For Each ctn1 As Control In ctn.Controls


                If TypeOf ctn Is DropDownList Then
                    Dim cbo As DropDownList = CType(ctn, DropDownList)
                    If cbo.SelectedIndex > 0 Then
                        kbQuerytString &= "&" & cbo.ID & "=" & GenTool.Convert2PercentageFormat(cbo.Text.ToUpper)
                    End If

                ElseIf TypeOf ctn Is TextBox Then
                    Dim cbo As TextBox = CType(ctn, TextBox)
                    If String.IsNullOrEmpty(cbo.Text) = False Then
                        kbQuerytString &= "&" & cbo.ID & "=" & GenTool.Convert2PercentageFormat(cbo.Text.ToUpper)
                    End If
                End If

                If ctn1.HasControls = True Then
                    getctlName(ctn1)
                End If

            Next
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub chkMultiple_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkMultiple.CheckedChanged
        pnlDataView.Visible = chkMultiple.Checked
    End Sub

    Protected Sub CheckBox1_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged, CheckBox2.CheckedChanged, CheckBox3.CheckedChanged, _
        CheckBox4.CheckedChanged, CheckBox5.CheckedChanged, CheckBox6.CheckedChanged
        fileLetterPicture1.Visible = CheckBox1.Checked
        fileLetterPicture2.Visible = CheckBox2.Checked
        fileLetterPicture3.Visible = CheckBox3.Checked
        fileLetterPicture4.Visible = CheckBox4.Checked
        fileLetterPicture5.Visible = CheckBox5.Checked
        fileLetterPicture6.Visible = CheckBox6.Checked
    End Sub

    Protected Sub grd_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles grd.SelectedIndexChanged
        Try
            Dim ItemID As String = grd.SelectedRow.Cells(1).Text

            Dim dr As DataRow = dsMain.Tables(0).Rows.Find(ItemID)
            dr.Delete()
            grd.DataSource = dsMain.Tables(0)
            grd.DataBind()

        Catch ex As Exception
            GenTool.GrabError(ex.Message, Me.Title & "--grd_SelectedIndexChanged")
        End Try
    End Sub

    Protected Sub btnPreview0_Click(sender As Object, e As System.EventArgs) Handles btnPreview0.Click
        Dim msgtext As String = ""

        Try
            getChange()
            FUpdate = ""
            FV = ""
            FN = ""
            lblMsg.Text = ""

            txtTranscode.Text = GenTool.GenerateRNDCode(True, True) & GenTool.GenerateUniqueCode & GenTool.GenerateRNDCode(True)
            Dim fs As String = "TerminalOperator;NoneTerminalOperator;CertificateOfIncor;CompanyArticleMemo;LicenseByDPR;WeightMeters;OriginalBank;TaxClearance;docFiledTitle;docfilledBy;emaildocsigned;companyID;txtpassportname1;txtpassportname2;txtpassportname3;txtpassportname4;txtpassportname5;txtpassportname6"

            If Val(txtFinalQty.Text) = 0 Then
                txtFinalQty.Text = txtQuatity.Text
            End If

            msgtext = GenTool.generateSQL(Panel1, FN, FV, FUpdate, fs)

            If msgtext <> "" Then Return

            Dim dtRow As DataRow = dsMain.Tables(0).NewRow
            dtRow.BeginEdit()
            dtRow("ID") = (dsMain.Tables(0).Rows.Count + 1).ToString
            dtRow("Permit Name") = txtexportPermitName.Text
            dtRow("Exporter Name") = txtAsnwer.Text
            dtRow("Product Description") = txtProducName.Text
            dtRow("Period Covered From") = cboPCF.Text
            dtRow("Period Covered To") = cboPCT.Text
            dtRow("Quantity") = txtQuatity.Text
            dtRow("Measure") = cboqtyMeasure.SelectedItem.Text
            dtRow("Export Port") = txtusername17.Text
            dtRow("Amt/Barrel") = txtamtPerBarrel.Text
            dtRow("F.O.B Value(USD)") = txtAmtUS.Text
            dtRow("Calc. Qty") = txtFinalQty.Text

            dtRow.EndEdit()
            dsMain.Tables(0).Rows.Add(dtRow)
            grd.DataSource = dsMain.Tables(0)
            grd.DataBind()

            msgtext = "Appplication Stored Successfully"
            GenTool.resetform(Panel1)

            chkMultiple.Checked = True
            RadioButton1.Checked = True
            RadioButton3.Checked = True

            'txtexportPermitName.Text = ""
            'txtAsnwer.Text = ""
            'txtProducName.Text = ""
            'cboPCF.Text = ""
            'cboPCT.Text = ""
            'txtQuatity.Text = ""
            'txtusername17.Text = ""
            'txtamtPerBarrel.Text = ""
            'txtAmtUS.Text = ""
            'cboPCF.SelectedIndex = 0
            'cboPCT.SelectedIndex = 0
            'cboqtyMeasure.SelectedIndex = 0

        Catch ex As Exception
            lblMsg.Text = ex.Message
        Finally
            lblMsg.Text = msgtext
            If msgtext <> "" Then MessageBox.Show(Panel1, msgtext)
        End Try
    End Sub

    Protected Sub RadioButton3_CheckedChanged(sender As Object, e As System.EventArgs) Handles RadioButton3.CheckedChanged, RadioButton4.CheckedChanged
        If RadioButton3.Checked = True Then
            lbl4.Text = "*"
            lbl3.Text = "*"
        Else
            lbl4.Text = "&nbsp;"
            lbl3.Text = "&nbsp;"
        End If
    End Sub

    Protected Sub fileLetterPicture2_UploadedComplete(sender As Object, e As AjaxControlToolkit.AsyncFileUploadEventArgs) Handles fileLetterPicture2.UploadedComplete
        Try
            If fileLetterPicture2.HasFile = True Then
                Dim extN As String = Guid.NewGuid.ToString & IO.Path.GetExtension(fileLetterPicture2.FileName)
                Dim fil As String = pathdoclink & "coverLetter/" & extN
                fileLetterPicture2.SaveAs(fil)
                Session.Add("fileLetterPicture2", extN)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub fileLetterPicture3_UploadedComplete(sender As Object, e As AjaxControlToolkit.AsyncFileUploadEventArgs) Handles fileLetterPicture3.UploadedComplete
        Try
            If fileLetterPicture3.HasFile = True Then
                Dim extN As String = Guid.NewGuid.ToString & IO.Path.GetExtension(fileLetterPicture3.FileName)
                Dim fil As String = pathdoclink & "coverLetter/" & extN
                fileLetterPicture3.SaveAs(fil)
                Session.Add("fileLetterPicture3", extN)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub fileLetterPicture4_UploadedComplete(sender As Object, e As AjaxControlToolkit.AsyncFileUploadEventArgs) Handles fileLetterPicture4.UploadedComplete
        Try
            If fileLetterPicture4.HasFile = True Then
                Dim extN As String = Guid.NewGuid.ToString & IO.Path.GetExtension(fileLetterPicture4.FileName)
                Dim fil As String = pathdoclink & "coverLetter/" & extN
                fileLetterPicture4.SaveAs(fil)
                Session.Add("fileLetterPicture4", extN)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub fileLetterPicture5_UploadedComplete(sender As Object, e As AjaxControlToolkit.AsyncFileUploadEventArgs) Handles fileLetterPicture5.UploadedComplete
        Try
            If fileLetterPicture5.HasFile = True Then
                Dim extN As String = Guid.NewGuid.ToString & IO.Path.GetExtension(fileLetterPicture5.FileName)
                Dim fil As String = pathdoclink & "coverLetter/" & extN
                fileLetterPicture5.SaveAs(fil)
                Session.Add("fileLetterPicture5", extN)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub fileLetterPicture6_UploadedComplete(sender As Object, e As AjaxControlToolkit.AsyncFileUploadEventArgs) Handles fileLetterPicture6.UploadedComplete
        Try
            If fileLetterPicture6.HasFile = True Then
                Dim extN As String = Guid.NewGuid.ToString & IO.Path.GetExtension(fileLetterPicture6.FileName)
                Dim fil As String = pathdoclink & "coverLetter/" & extN
                fileLetterPicture6.SaveAs(fil)
                Session.Add("fileLetterPicture6", extN)
            End If
        Catch ex As Exception
        End Try
    End Sub


End Class
