Imports System.Data

Partial Class admnewuser
    Inherits System.Web.UI.Page

    Dim GenTool As NNLN = xsmsCentralToolx.SetTool

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        Try
            If IsPostBack = False Then

                resetform(True)

                Dim regType As String = Request("pg")

                If Val(regType) = 1 Then
                    Panel3.Visible = True
                    filldb("")
                Else
                    Panel3.Visible = False
                End If


            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub goHideContents()
        txtpwdR.Attributes.Add("value", txtpwd.Text)

        txtuser.Enabled = False
        txtpwd.Enabled = False
        txtpwdR.Enabled = False

        cbosQuestion.Enabled = False
        txtAsnwer.Enabled = False

    End Sub

    Private Sub resetform(ByVal setFont As Boolean, Optional ByVal ds As DataSet = Nothing)
        Try
            Dim ctn As New System.Web.UI.Control


            For Each ctn In Panel1.Controls

                If TypeOf ctn Is System.Web.UI.WebControls.CheckBox Then
                    Dim txt As CheckBox = CType(ctn, CheckBox)

                    If ds IsNot Nothing Then
                        Dim sf As String = GenTool.getValueSystem(ds, txt.ValidationGroup)

                        If Val(sf) = 1 Then
                            txt.Checked = True
                        Else
                            txt.Checked = False
                        End If

                    Else
                        If setFont = False Then
                            txt.Checked = False
                        Else
                            txt.Font.Name = "Calibri"
                            txt.Font.Size = 10
                        End If
                    End If

                End If

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
                txtpwd.Attributes.Add("value", "")
                txtpwdR.Attributes.Add("value", "")
                txtpwd.Text = ""
                txtpwdR.Text = ""
                lblMsg.Text = ""
                Session("userid") = ""
            End If

            If ds IsNot Nothing Then
                btnPreview_ConfirmButtonExtender.ConfirmText = "Are you SURE you want to UPDATE this record?"

            Else
                btnPreview_ConfirmButtonExtender.ConfirmText = "Are you SURE you want to SAVE this record?"
            End If

        Catch ex As Exception
        End Try
    End Sub

    Dim FN As String = ""
    Dim FV As String = ""
    Dim FUpdate As String = ""

    Private Sub filldb(ByVal w As String)
        Dim ds As DataSet = GenTool.DataSetData("select sysID as ID,Username,Surname,Firstname,Othernames,Companyname,Phone,Email,ContacAddress from systemusers where sysID<>-0908939 " & w)
        Try
            grd.DataSource = ds.Tables(0)
            grd.DataBind()

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        Dim msgtext As String = ""

        Try

            FUpdate = ""
            FV = ""
            FN = ""
            lblMsg.Text = ""

            msgtext = GenTool.checkControl(Panel1, FN, FV, FUpdate)

            If msgtext <> "" Then Return

            If txtpwd.Text.Length < 6 AndAlso String.IsNullOrEmpty(Session("userid")) = True Then
                msgtext = "Password character lenght must be 6 or above"
                Return
            End If

            If txtpwdR.Text <> txtpwd.Text AndAlso String.IsNullOrEmpty(Session("userid")) = True Then
                msgtext = "Both password entered are not same"
                txtpwd.Text = ""
                txtpwdR.Text = ""
                Return
            End If

            If GenTool.ValidateEmail(txtemail.Text) = False Then
                msgtext = "Invalid company email address"
                Return
            End If


            Dim sql = "Insert into systemusers(" & FN & ") Values (" & FV & ")"

            Dim TellNew As Boolean

            If String.IsNullOrEmpty(Session("userid")) = True Then

                If GenTool.HasRows("select sysID from systemusers where username=" & GenTool.addbackslash(txtuser.Text)) = True Then
                    msgtext = "Username already exist please choose another name"
                    Return
                End If

                If GenTool.HasRows("select sysID from systemusers where email=" & GenTool.addbackslash(txtemail.Text)) = True Then
                    msgtext = "company email already exist please choose another email"
                    Return
                End If

                msgtext = "Record created successfully"

                TellNew = True

            Else

                sql = "Update systemusers set " & FUpdate & " where sysID=" & Val(Session("userid"))
                msgtext = "Record updated successfully"

                TellNew = False
            End If

            If GenTool.ExecuteDatabase(sql) = True Then

                If TellNew = True Then
                    sendmail()

                    Try
                        Response.Redirect("managelots.aspx?pg=1&cid=" & grd.SelectedRow.Cells(6).Text)
                    Catch ex As Exception
                    End Try

                End If

                resetform(False)
                filldb("")
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack Then
            If Not String.IsNullOrEmpty(txtpwd.Text.Trim()) Then
                txtpwd.Attributes.Add("value", txtpwd.Text)
            End If
            If Not String.IsNullOrEmpty(txtpwdR.Text.Trim()) Then
                txtpwdR.Attributes.Add("value", txtpwdR.Text)
            End If
        End If
    End Sub

    Private Sub sendmail()
        Try
            Dim cBlast As New MailContents
            cBlast.AttarchFiles = ""
            cBlast.BodyM = getBody()
            cBlast.IsBodyHtml = True
            cBlast.mailbcc = Nothing
            cBlast.mailcc = New Net.Mail.MailAddress("operations@wmdnigeria.com")
            cBlast.mailfrom = New Net.Mail.MailAddress("operations@wmdnigeria.com")
            cBlast.mailto = New Net.Mail.MailAddress(txtemail.Text)
            cBlast.Subject = "USER ACCOUNT"
            GenTool.SendnMailBox(cBlast)

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub grd_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grd.PageIndexChanging
        grd.PageIndex = e.NewPageIndex
        filldb("")
    End Sub

    Private Sub grd_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grd.RowCreated
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

    Protected Sub grd_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grd.SelectedIndexChanged
        Session("userid") = grd.SelectedRow.Cells(1).Text
        btnPreview_ConfirmButtonExtender.ConfirmText = "Are you SURE you want to UPDATE this record?"
        resetform(True, GenTool.DataSetData("select * from systemusers where sysID=" & Val(Session("userid"))))
        btnISP.Visible = chkISP.Checked
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            Dim w As String = ""

            If cboSearch.SelectedIndex > 0 Then
                w = " AND " & cboSearch.Text & "=" & GenTool.addbackslash(txtSearch.Text)
                filldb(w)
            End If
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
"            USER REGISTRATION DETAILS</div>" & _
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
"                        " & IIf(Session("userid") = "", GenTool.getSingleValue("select sysID from systemusers where username=" & GenTool.addbackslash(txtuser.Text)), Session("userid")) & "</td>" & _
"                </tr>" & _
"                <tr>" & _
"                    <td align='left' class='zebraodd' valign='middle'>" & _
"                        USER FULLNAME</td>" & _
"                    <td align='left'>" & _
"                        " & txtsurname.Text & " " & txtfirstname.Text & " " & txtothername.Text & "</td>" & _
"                </tr>" & _
"                <tr>" & _
"                    <td align='left' class='zebraodd' valign='middle'>" & _
"                        USERNAME</td>" & _
"                    <td align='left'>" & _
"                        " & txtuser.Text & "</td>" & _
"                </tr>" & _
"                <tr>" & _
"                    <td align='left' class='zebraodd' valign='middle'>" & _
"                        PASSWORD</td>" & _
"                    <td align='left'>" & _
"                        " & txtpwd.Text & "</td>" & _
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
"                       " & "Welcome!<br> Please keep your username and password for future reference!" & "</td>" & _
"                </tr>" & _
"            </table>" & _
"            <br />" & _
"        </div>" & _
"        </center>" & _
"    </form>" & _
"</body>" & _
"</html>"

    End Function

    Protected Sub btnISP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnISP.Click
        Try
            Response.Redirect("managelots.aspx?pg=1&cid=" & grd.SelectedRow.Cells(6).Text)
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub chkISP9_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkISP9.CheckedChanged

    End Sub
End Class
