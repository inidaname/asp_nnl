Imports System.Data

Partial Class exportpermit
    Inherits System.Web.UI.Page


    Dim GenTool As NNLN = xsmsCentralToolx.SetTool

    Protected Sub btnSend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSend.Click
        Dim msgText As String = ""
        Try

            If String.IsNullOrEmpty(txtoldpass.Text) = True Then
                msgText = "Invalid Old password"
                Return
            End If

            If String.IsNullOrEmpty(txtPasswrod.Text) = True Then
                msgText = "Invalid New Password"
                Return
            End If

            If txtPasswrod.Text <> txtretryPassword.Text Then
                msgText = "Both password must be equal"
                Return
            End If

            Dim sd As String = "select sysID from companyregistration where sysID=" & Val(Session("ID")) & " AND pwd=" & GenTool.addbackslash(txtoldpass.Text)

            If Val(Session("isadmin")) = 1 Then
                sd = "select sysID from systemusers where sysID=" & Val(Session("sysID")) & " AND userpwd=" & GenTool.addbackslash(txtoldpass.Text)
            End If

            If GenTool.HasRows(sd) = False Then
                msgText = "Old password not found!"
                Return
            End If
 
            sd = "update companyregistration set pwd=" & GenTool.addbackslash(txtPasswrod.Text) & ",regDateModify=now() where sysID=" & Val(Session("ID"))

            If Val(Session("isadmin")) = 1 Then
                sd = "update systemusers set userpwd=" & GenTool.addbackslash(txtPasswrod.Text) & ",regDateModify=now() where sysID=" & Val(Session("sysID"))
            End If

            If GenTool.ExecuteDatabase(sd) = False Then
                msgText = "We couldnt make changes to your account at the moment,please try again later"
                Return
            End If

                    
            msgText = "Password updated successfully"
     
        Catch ex As Exception
        Finally
            lblMsg.Text = msgText
            MessageBox.Show(Me, msgText)
        End Try
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Session("isadmin") = Request("pg")
        Catch ex As Exception
        End Try
    End Sub
End Class
