<%@ WebHandler Language="VB" Class="upload3" %>

Imports System
Imports System.Web
Imports System.IO

Public Class upload3 : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

        Dim postedFile As HttpPostedFile = context.Request.Files("Filedata")

 

        Dim savepath As String = ""

        Dim tempPath As String = ""

        tempPath = System.Configuration.ConfigurationManager.AppSettings("FolderPath")

        savepath = context.Server.MapPath(tempPath)

        Dim filename As String = postedFile.FileName

        If Not Directory.Exists(savepath) Then

            Directory.CreateDirectory(savepath)

        End If

 

        postedFile.SaveAs((savepath & "\") + filename)

        context.Response.Write((tempPath & "/") + filename)

        context.Response.StatusCode = 200

    End Sub

 

    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable

        Get

            Return False

        End Get

    End Property

 

End Class