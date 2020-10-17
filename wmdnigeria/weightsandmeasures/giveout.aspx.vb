
Partial Class giveout
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim k1 As String = Request("f1")
            Dim k2 As String = Request("f2")
            Dim fn As String
            fn = "<a href='frontpagedisplay.aspx?msgid=" & k1 & "'><img src='frontdoc/" & k2 & "' width='150px' height='150px' align='left' style='border:1px solid #DBDBDB'/> </a>"""
            Response.Write(fn)
        Catch ex As Exception

        End Try
    End Sub
End Class
