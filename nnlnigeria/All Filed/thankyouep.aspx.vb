
Partial Class thankyou
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        lblMsg.Text = "Congratulations " & Session("cname") & " your application is acknowledged, the status of your application would be communicated to you as soon as possible"
    End Sub
End Class
