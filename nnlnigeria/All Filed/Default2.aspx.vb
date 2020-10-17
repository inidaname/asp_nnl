
Partial Class _Default
    Inherits System.Web.UI.Page

    Dim GenTool As smsXMobile.smsXMobile = xsmsCentralToolx.SetTool
    'Protected Sub btnnewSubscription_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnnewSubscription.Click
    '    Try
    '        If GenTool.ValidateEmail(txtemail.Text) = False Then
    '            MessageBox.Show(Me, "Invalid email address")
    '        Else
    '            Dim sd As String = "Select sysID from emailsubs where email=" & GenTool.addbackslash(txtemail.Text)

    '            If GenTool.HasRows(sd) = False Then
    '                sd = "insert into `emailsubs`(email, regDate) values (" & GenTool.addbackslash(txtemail.Text) & ",now())"
    '                If GenTool.ExecuteDatabase(sd) = True Then
    '                    MessageBox.Show(Me, "Thanks")
    '                    txtemail.Text = ""
    '                Else
    '                    MessageBox.Show(Me, "We couldnt save your email,please try again later")
    '                End If
    '            Else
    '                MessageBox.Show(Me, "Email address already subscribe, thank you!")
    '                txtemail.Text = ""
    '            End If

    '        End If
    '    Catch ex As Exception
    '    End Try
    'End Sub
     
  
End Class
