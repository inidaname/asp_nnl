Imports System.Data

Partial Class exportpermit
    Inherits System.Web.UI.Page


    Dim GenTool As NNLN = xsmsCentralToolx.SetTool

    Protected Sub btnSend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSend.Click
        Dim msgText As String = ""
        Try


            If String.IsNullOrEmpty(txtuser.Text) = True Then
                msgText = "Invalid username"
                Return
            End If

            If cbosQuestion.SelectedIndex < 1 Then
                msgText = "You have not selected security question"
                Return
            End If

            If String.IsNullOrEmpty(txtAnswer.Text) = True Then
                msgText = "Invalid security answer"
                Return
            End If

            Dim sd As String = "select sysID,companyEmail from companyregistration where securityQuestions=" & GenTool.addbackslash(cbosQuestion.Text) & _
                " AND securityAnswer=" & GenTool.addbackslash(txtAnswer.Text) & " AND username=" & GenTool.addbackslash(txtuser.Text)

            If Val(Session("fpassword")) = 2 Then
                sd = "select sysID,email from systemusers where securityquestion=" & GenTool.addbackslash(cbosQuestion.Text) & _
                " AND securityAnswer=" & GenTool.addbackslash(txtAnswer.Text) & " AND username=" & GenTool.addbackslash(txtuser.Text)
            End If

            Dim ds As DataSet = GenTool.DataSetData(sd)
            If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then

                With ds.Tables(0).Rows(0)

                    Dim sysID As String = .Item(0)
                    Dim pwd As String = GenTool.GenerateRNDCode(True)
                    Dim email As String = .Item(1)
                    Dim m_Body As String = getContent(pwd)


                    Dim cBlast As New MailContents
                    cBlast.AttarchFiles = ""
                    cBlast.BodyM = getContent(pwd)
                    cBlast.IsBodyHtml = True
                    cBlast.mailbcc = Nothing
                    cBlast.mailcc = New Net.Mail.MailAddress("sales@nnlnigeria.com")
                    cBlast.mailfrom = New Net.Mail.MailAddress("info@nnlnigeria.com")
                    cBlast.mailto = New Net.Mail.MailAddress(email)
                    cBlast.Subject = "Password Recovery"

                    sd = "update companyregistration set pwd=" & GenTool.addbackslash(pwd) & ",regDateModify=now() where sysID=" & Val(sysID)
                    If Val(Session("fpassword")) = 2 Then
                        sd = "update systemusers set userpwd=" & GenTool.addbackslash(pwd) & ",regDateModify=now() where sysID=" & Val(sysID)
                    End If

                    If GenTool.ExecuteDatabase(sd) = False Then
                        msgText = "We couldnt make changes to your account at the moment,please try again later"
                        Return
                    End If

                    If GenTool.SendnMailBox(cBlast) = True Then
                        msgText = "We have sent your password to " & email
                        cbosQuestion.SelectedIndex = 0
                        txtAnswer.Text = ""
                        txtuser.Text = ""
                    Else
                        msgText = "We could't send a message to " & email & ", please contact our customer care"
                    End If
                End With

                ds.Dispose()
            Else
                msgText = "Credentials entered was not found."
            End If

        Catch ex As Exception
        Finally
            lblMsg.Text = msgText
            MessageBox.Show(Me, msgText)
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim pgk As String = Request("pg")

            If pgk = "admin" Then
                Session("fpassword") = "2"
            End If
        Catch ex As Exception
        End Try
    End Sub

    Function getContent(ByVal pwd As String) As String
        Return "<html>" & _
              "<head>" & _
              "<title></title>" & _
              "</head>" & _
              "<body>" & _
              "<form action=''>" & _
              "<div style='font-family: Calibri; font-size: medium; font-weight: bold'>Username</div>" & txtuser.Text & "<div><hr/></div><div style='font-family: Calibri; font-size: medium; font-weight: bold'>Password</div>" & pwd & "<div><hr/></div><div style='font-family: Calibri; font-size: medium; font-weight: bold'>Site Address</div><a href='www.nnlnigeria.com'>www.nnlnigeria.com</a><div></div>" & _
              "</form>" & _
              "</body>" & _
              "</html>"
    End Function
End Class
