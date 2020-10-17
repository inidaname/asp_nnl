Imports System.IO
Imports System.Web
Imports System.Text
Imports System.Security.Cryptography




Public Class _default4
    Inherits System.Web.UI.Page

    'Database file
     Dim DatabaseFile As String = HttpContext.Current.Request.PhysicalApplicationPath & "databasefile\file.txt"
    Private DatabaseFileContent() As String = Nothing

    Private Function Encrypt(clearText As String) As String
        Dim EncryptionKey As String = "MAKV2SPBNI99212"
        Dim clearBytes As Byte() = Encoding.Unicode.GetBytes(clearText)
        Using encryptor As Aes = Aes.Create()
            Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D, _
             &H65, &H64, &H76, &H65, &H64, &H65, _
             &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write)
                    cs.Write(clearBytes, 0, clearBytes.Length)
                    cs.Close()
                End Using
                clearText = Convert.ToBase64String(ms.ToArray())
            End Using
        End Using
        Return clearText
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsNothing(Session("LoggedInAdminLoginUsername")) Then
            MessageBox.Show(Me, "No Valid user login")

            Response.Redirect("../")

        Else

            'MessageBox.Show(Me, Session("LoggedInAdminLogin").ToString)

            'MessageBox.Show(Me, Session("LoggedInAdminLoginEmail") & " " & Session("LoggedInAdminLoginPassword") & " " & Session("LoggedInAdminLoginID") & " " & Session("LoggedInAdminLoginLastLogin"))

        End If



    End Sub


    Public Function GetNumberOfLines(ByVal file_path As String) As Integer
        Dim sr As New StreamReader(file_path)
        Dim NumberOfLines As Integer
        Do While sr.Peek >= 0
            sr.ReadLine()
            NumberOfLines += 1
        Loop
        Return NumberOfLines
        sr.Close()
        sr.Dispose()
    End Function


    Protected Sub ConnectDatabase_Click(sender As Object, e As EventArgs) Handles ConnectDatabase.Click

        Try
            'Check if there's no empty field and make sure the checkbox is checked
            If AgreetoConnect.Checked = False Or DatabaseServer.Text = "" Or DatabasePort.Text = "" Or DatabaseUsername.Text = "" Or DatabaseName.Text = "" Then

                MessageBox.Show(Me, "Cannot connect to database, Fill all the form and Check the box to Connect")

            Else

                'MessageBox.Show(Me, "Note: You will be disconnected from the current database and reconnect to new database")

                Dim DatabaseServerEncrypted = Me.Encrypt(DatabaseServer.Text.Trim())
                Dim DatabasePortEncrypted = Me.Encrypt(DatabasePort.Text.Trim())
                Dim DatabaseUsernameEncrypted = Me.Encrypt(DatabaseUsername.Text.Trim())
                Dim DatabasePasswordEncrypted = Me.Encrypt(DatabasePassword.Text.Trim())
                Dim DatabaseNameEncrypted = Me.Encrypt(DatabaseName.Text.Trim())

                'Read file and delete it so as to recreate and write fields value into it
                If System.IO.File.Exists(DatabaseFile) = True Then
                   
                    GetNumberOfLines(DatabaseFile)
                    Kill(DatabaseFile) 'Here is the mistake
                    'Delete file
                    System.IO.File.Delete(DatabaseFile)


                        ' Create a file to write to.  
                        Using objWriter As StreamWriter = File.CreateText(DatabaseFile)
                            objWriter.WriteLine(DatabaseServerEncrypted)
                            objWriter.WriteLine(DatabasePortEncrypted)
                            objWriter.WriteLine(DatabaseUsernameEncrypted)
                            objWriter.WriteLine(DatabasePasswordEncrypted)
                            objWriter.WriteLine(DatabaseNameEncrypted)
                            objWriter.Close()
                        End Using
                     

                Else
                    'If Database file is not found, create a new one and write fields value to it
                    'MessageBox.Show(Me, "Database file not found!")

                    ' Create a file to write to.  
                    Using objWriter As StreamWriter = File.CreateText(DatabaseFile)

                        objWriter.WriteLine(DatabaseServerEncrypted)
                        objWriter.WriteLine(DatabasePortEncrypted)
                        objWriter.WriteLine(DatabaseUsernameEncrypted)
                        objWriter.WriteLine(DatabasePasswordEncrypted)
                        objWriter.WriteLine(DatabaseNameEncrypted)
                        objWriter.Close()

                        'objWriter.WriteLine(DatabaseServer.Text)
                        'objWriter.WriteLine(DatabasePort.Text)
                        'objWriter.WriteLine(DatabaseUsername.Text)
                        'objWriter.WriteLine(DatabasePassword.Text)
                        'objWriter.WriteLine(DatabaseName.Text)
                        'objWriter.Close()
                    End Using
                End If
                'Response.AppendHeader("Refresh", "0;url=./")
            End If
        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)
        Finally

        End Try

    End Sub
End Class