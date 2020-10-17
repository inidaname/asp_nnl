Imports System.Net
Imports System.IO

Partial Class test
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try

            Dim request As HttpWebRequest = CType(WebRequest.Create("https://nnlnigeria.com/nnlrequestpool.aspx"), HttpWebRequest)
            'Dim request As HttpWebRequest = CType(WebRequest.Create("http://localhost/nnlnigeria/nnlrequestpool.aspx"), HttpWebRequest)

            'request.Credentials = New NetworkCredential("user", "pw")
            'request.Credentials=defa
            request.Method = "POST"

            Dim web1 As New System.Net.WebClient
            Dim sr1 As System.IO.StreamReader
            sr1 = New System.IO.StreamReader(web1.OpenRead(Server.MapPath("~/notificationrequest.txt")))
            'sr1 = New System.IO.StreamReader(web1.OpenRead(Server.MapPath("~/notificationrequest.txt")))

            Dim postData As String = sr1.ReadToEnd
            Dim byteArray() As Byte = Encoding.UTF8.GetBytes(postData)
            'request.ContentType = "application/x-www-form-urlencoded"
            request.ContentLength = byteArray.Length

            Dim dataStream As Stream = request.GetRequestStream()
            dataStream.Write(byteArray, 0, byteArray.Length)
            dataStream.Close()

            Dim response1 As WebResponse = request.GetResponse()
            'Response.Write((CType(response1, HttpWebResponse)).StatusDescription)
            dataStream = response1.GetResponseStream()

            Dim reader As New StreamReader(dataStream)
            Dim responseFromServer As String = Split(reader.ReadToEnd(), "!!!").ToArray(0).ToString

            Response.Write(responseFromServer)
            reader.Close()
            dataStream.Close()

        Catch ex As Exception
        End Try
    End Sub

End Class
