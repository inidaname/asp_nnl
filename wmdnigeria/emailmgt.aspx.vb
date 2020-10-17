Imports System.Data

Partial Class emailmgt
    Inherits System.Web.UI.Page
    Dim GenTool As NNLN = xsmsCentralToolx.setEmail

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        Try
            If IsPostBack = False Then
 
                filldb("")
                Try
                    cbosQuestion.Items.Clear()
                    cbosQuestion.DataTextField = "domainname"
                    cbosQuestion.DataValueField = "domainid"
                    cbosQuestion.DataSource = GenTool.DataSetData("select domainid,domainname from hm_domains").Tables(0)
                    cbosQuestion.DataBind()
                    cbosQuestion.Items.Insert(0, "Select Dormain Name")
                Catch ex As Exception
                End Try
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
    End Sub

    Dim FN As String = ""
    Dim FV As String = ""
    Dim FUpdate As String = ""

    Private Sub filldb(ByVal w As String)
        Dim ds As DataSet = GenTool.DataSetData("select accountid as ID,accountaddress as Email,accountpersonfirstname as Firstname,accountpersonlastname as Surname,domainname,accountlastlogontime as Date,accountactive as Status from hm_accounts,hm_domains where hm_accounts.accountdomainid=hm_domains.domainid  AND left(accountaddress,5)<>'admin' " & w)
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

            txtemailaddress.Text = txtuser.Text & "@" & cbosQuestion.SelectedItem.Text

            If String.IsNullOrEmpty(Session("emailID")) = True Then msgtext = GenTool.checkControl(Panel1, FN, FV, FUpdate)

            If msgtext <> "" Then Return

            If txtpwd.Text.Length < 6 AndAlso String.IsNullOrEmpty(Session("emailID")) = True Then
                msgtext = "Password character lenght must be 6 or above"
                Return
            End If

            If txtpwdR.Text <> txtpwd.Text AndAlso String.IsNullOrEmpty(Session("emailID")) = True Then
                msgtext = "Both password entered are not same"
                txtpwd.Text = ""
                txtpwdR.Text = ""
                Return
            End If

            If GenTool.ValidateEmail(txtemailaddress.Text) = False Then
                msgtext = "Invalid email address"
                Return
            End If

            Dim sql As String = ""

            Dim f As Integer = 0
            If chkIsActive.Checked = True Then
                f = 1
            End If

            If String.IsNullOrEmpty(Session("emailID")) = True Then

                If GenTool.HasRows("select accountdomainid from hm_accounts where accountaddress=" & GenTool.addbackslash(txtemailaddress.Text)) = True Then
                    msgtext = "Email address exist please choose another name"
                    Return
                End If


                sql = "insert into hm_accounts(accountdomainid,accountadminlevel,accountisad,accountaddress,accountpassword,accountactive,accountpwencryption,accountpersonfirstname,accountpersonlastname," & _
                    "accountaddomain,accountadusername,accountmaxsize,accountvacationmessageon,accountvacationmessage,accountvacationsubject,accountforwardenabled,accountforwardaddress" & _
                    ",accountforwardkeeporiginal,accountenablesignature,accountsignatureplaintext,accountsignaturehtml,accountlastlogontime,accountvacationexpires,accountvacationexpiredate) Values (" & _
                    Val(cbosQuestion.SelectedValue) & ",0,0," & GenTool.addbackslash(txtemailaddress.Text) & "," & GenTool.addbackslash(GenTool.MD5Encryptor(txtpwd.Text)) & "," & f & ",2," & _
                    GenTool.addbackslash(txtfirstname.Text) & "," & GenTool.addbackslash(txtsurname.Text) & ",'','',0,0,'','',0,'',0,0,'','',now(),0,'2008-02-10 00:00:00')"

                msgtext = "Email Address Created Successfully"

            Else
                If String.IsNullOrEmpty(txtpwd.Text) = False Then

                    If txtpwd.Text.Length < 6 Then
                        msgtext = "Password character lenght must be 6 or above"
                        Return
                    End If

                    If txtpwdR.Text <> txtpwd.Text Then
                        msgtext = "Both password entered are not same"
                        txtpwd.Text = ""
                        txtpwdR.Text = ""
                        Return
                    End If

                    sql = "Update hm_accounts set accountactive=" & f & ",accountpersonfirstname=" & GenTool.addbackslash(txtfirstname.Text) & _
                        ",accountpersonlastname=" & GenTool.addbackslash(txtsurname.Text) & ",accountpassword=" & GenTool.addbackslash(GenTool.MD5Encryptor(txtpwd.Text)) & _
                        ",accountpwencryption=2 where accountid=" & Val(Session("emailID"))
                Else
                    sql = "Update hm_accounts set accountactive=" & f & ",accountpersonfirstname=" & GenTool.addbackslash(txtfirstname.Text) & _
                         ",accountpersonlastname=" & GenTool.addbackslash(txtsurname.Text) & " where accountid=" & Val(Session("emailID"))
                End If

                msgtext = "Email Address Updated Successfully"
            End If


            If GenTool.ExecuteDatabase(sql) = True Then
                If String.IsNullOrEmpty(Session("emailID")) = True Then

                    Dim indexNumber As Integer = GenTool.getSingleValue("select accountid from hm_accounts where accountaddress=" & GenTool.addbackslash(txtemailaddress.Text))

                    Dim sf As New ArrayList
                    sf.Add("insert into `hm_imapfolders` (`folderaccountid`,`folderparentid`,`foldername`,`folderissubscribed`,`foldercreationtime`,`foldercurrentuid`) values (" & indexNumber & ",-1,'INBOX',1,now(),0);")
                    sf.Add("insert into `hm_imapfolders` (`folderaccountid`,`folderparentid`,`foldername`,`folderissubscribed`,`foldercreationtime`,`foldercurrentuid`) values (" & indexNumber & ",-1,'Drafts',1,now(),0);")
                    sf.Add("insert into `hm_imapfolders` (`folderaccountid`,`folderparentid`,`foldername`,`folderissubscribed`,`foldercreationtime`,`foldercurrentuid`) values (" & indexNumber & ",-1,'Trash',1,now(),0);")
                    sf.Add("insert into `hm_imapfolders` (`folderaccountid`,`folderparentid`,`foldername`,`folderissubscribed`,`foldercreationtime`,`foldercurrentuid`) values (" & indexNumber & ",-1,'Spam',1,now(),0);")

                    GenTool.ExecuteBulkSQL(sf)
                End If

                btnReset_Click(Nothing, Nothing)
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
        GenTool.resetform(Panel1)
        txtf1.Text = "0"
        txtf2.Text = "2"
        chkIsActive.Checked = True
        Session("emailID") = ""
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
        Session("emailID") = grd.SelectedRow.Cells(1).Text
        btnPreview_ConfirmButtonExtender.ConfirmText = "Are you SURE you want to UPDATE this record?"
        GenTool.resetform(Panel1, GenTool.DataSetData("select * from hm_accounts where accountid=" & Val(Session("emailID"))))
        Try
            Dim f() As String = txtemailaddress.Text.Split("@")
            txtuser.Text = f(0)
            cbosQuestion.SelectedIndex = GenTool.getddlindexvalue(cbosQuestion, f(1))
        Catch ex As Exception
        End Try


    End Sub

 

End Class
