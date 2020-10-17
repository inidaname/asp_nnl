
Partial Class logout
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Try
            Dim pg As String = Request("pg")
          
            Session.Clear()

            If Val(pg) = 1 Then
                Response.Redirect("~/admin.aspx")
            Else
                Response.Redirect("~/Default.aspx")
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
