
Partial Class thankyou
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        lblMsg.Text = "Welcome " & Session("cname") & " !"
        Label2.Text = Session("Msg") & Session("Amt2pay")
    End Sub

    Protected Sub btnMakePay0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMakePay0.Click
        Try
            Response.Redirect("invioces.aspx")
        Catch ex As Exception
        End Try
    End Sub
End Class
