
Partial Class companynoheader
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If String.IsNullOrEmpty(Session("ID")) = True AndAlso Val(Request("permit")) <> 2 Then
            Try
                Response.Redirect("Default.aspx?error=You have not login,please enter your credentials on the space provided and click login button. Register your account details if you are new")
            Catch ex As Exception
            End Try
        End If
    End Sub
End Class

