
Partial Class administrators1
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If Request("error") <> "" Then
            MessageBox.Show(Me, Request("error"))
        End If

    End Sub
End Class
