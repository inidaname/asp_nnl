Imports System
Imports System.IO
Imports System.Text
Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography

Module ConnectionClass
    'Database file
    Dim DatabaseFile As String = HttpContext.Current.Request.PhysicalApplicationPath & "databasefile\file.txt"


    Public conn As New MySqlConnection


    Private Function Decrypt(cipherText As String) As String
        Dim EncryptionKey As String = "MAKV2SPBNI99212"
        Dim cipherBytes As Byte() = Convert.FromBase64String(cipherText)
        Using encryptor As Aes = Aes.Create()
            Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D, _
             &H65, &H64, &H76, &H65, &H64, &H65, _
             &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write)
                    cs.Write(cipherBytes, 0, cipherBytes.Length)
                    cs.Close()
                End Using
                cipherText = Encoding.Unicode.GetString(ms.ToArray())
            End Using
        End Using
        Return cipherText
    End Function

    Public Function ReadALine(ByVal File_Path As String, ByVal TotalLine As Integer, ByVal Line2Read As Integer) As String
        Dim Buffer As Array
        Dim Line As String
        If TotalLine <= Line2Read Then
            Return "No Such Line in the specified file"
        End If
        Buffer = File.ReadAllLines(File_Path)
        Line = Buffer(Line2Read)
        Return Line
    End Function

    'This function read file lines 

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

    'Variables that get or read and store data from database file
    Private enc As System.Text.UTF8Encoding
    Private encryptor As ICryptoTransform
    Private decryptor As ICryptoTransform
    
    'To connect Database
    Public Sub ConnectDatabase()

        Dim DatabaseServer = (ReadALine(DatabaseFile, GetNumberOfLines(DatabaseFile), 0))
        Dim DatabasePort = (ReadALine(DatabaseFile, GetNumberOfLines(DatabaseFile), 1))
        Dim DatabaseUsername = (ReadALine(DatabaseFile, GetNumberOfLines(DatabaseFile), 2))
        Dim DatabasePassword = (ReadALine(DatabaseFile, GetNumberOfLines(DatabaseFile), 3))
        Dim DatabaseName = (ReadALine(DatabaseFile, GetNumberOfLines(DatabaseFile), 4))

        Dim DatabaseServerDecrypted = Decrypt(DatabaseServer.Trim())
        Dim DatabasePortDecrypted = Decrypt(DatabasePort.Trim())
        Dim DatabaseUsernameDecrypted = Decrypt(DatabaseUsername.Trim())
        Dim DatabasePasswordDecrypted = Decrypt(DatabasePassword.Trim())
        Dim DatabaseNameDecrypted = Decrypt(DatabaseName.Trim())

        Try
            If conn.State = ConnectionState.Closed Then
                'conn.ConnectionString = "server=localhost;port=3306;user id=root;password=;database=dbsabisab"
                'Connection to database server, using stored variable defined above
                conn.ConnectionString = "server=" & DatabaseServerDecrypted & ";port=" & DatabasePortDecrypted & ";user id=" & DatabaseUsernameDecrypted & ";password=" & DatabasePasswordDecrypted & ";database=" & DatabaseNameDecrypted & ""

                conn.Open()
                'MsgBox("Connection Successful" & DatabaseServerDecrypted & ", " & DatabasePortDecrypted & ", " & DatabaseUsernameDecrypted & ", " & DatabasePasswordDecrypted & ", " & DatabaseNameDecrypted)
            End If

        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    'To disconnect Database
    Public Sub DisconnectDatabase()
        Try
            conn.Close()
        Catch myerror As MySqlException

        End Try
    End Sub
End Module
