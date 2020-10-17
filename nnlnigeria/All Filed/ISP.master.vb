
Partial Class ISP
    Inherits System.Web.UI.MasterPage


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim GenTool As NNLN = xsmsCentralToolx.SetTool

        If String.IsNullOrEmpty(Session("sysID")) = True OrElse String.IsNullOrEmpty(Session("isppermission")) OrElse GenTool.DecryptSQL(Session("isppermission")) <> "nnlnigeria" Then
            Try
                Response.Redirect("Admin.aspx?error=You have not login,please enter your credentials on the space provided and click login button.")
            Catch ex As Exception
            End Try
        End If
    End Sub
End Class

