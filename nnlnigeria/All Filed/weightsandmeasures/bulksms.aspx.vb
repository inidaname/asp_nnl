
Partial Class bulksms
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Try
            Dim sendername, message, mobile, username, password, uniquecode, transCode, msgType As String
            sendername = Request("sender")
            message = Request("message")
            mobile = Request("mobile")
            username = Request("username")
            password = Request("password")
            uniquecode = Request("uniquecode")
            transCode = Request("transcode")
            msgType = Request("msgtype")

            Dim Link As String
            Link = "http://www.xmobileoffice.com/api/bulksms.aspx?username=aka&password=computernkasef&uniquecode=Xf48210020X56X10fX1164241411642414&sender=2toc&message=Activated&mobile=2348052420077"
            Dim GenTool As NNLN = xsmsCentralToolx.SetTool
            Link = GenTool.StringFromURL(Link)
            Response.Write(Link)

        Catch ex As Exception
            Response.Write("system error|3")
        End Try

    End Sub
End Class
