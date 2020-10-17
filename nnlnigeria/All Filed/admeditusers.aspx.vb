
Partial Class admeditusers
    Inherits System.Web.UI.Page
    Dim GenTool As NNLN = xsmsCentralToolx.SetTool

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If String.IsNullOrEmpty(Session("sysid")) = True Then
            Try
                Response.Redirect("admin.aspx?error=You have not login,please enter your credentials on the space provided and click login button.")
            Catch ex As Exception
            End Try
        End If
    End Sub
End Class
