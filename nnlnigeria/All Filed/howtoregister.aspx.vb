
Partial Class howtoregister
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Try
            Response.Redirect(docLink & "documents/howtoregister.pdf")
        Catch ex As Exception
        End Try
    End Sub
End Class
