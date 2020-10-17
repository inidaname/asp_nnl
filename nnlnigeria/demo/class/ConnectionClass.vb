Imports MySql.Data.MySqlClient

Module ConnectionClass

    Public conn As New MySqlConnection

    Public Sub ConnectDatabase()
        Try
            If conn.State = ConnectionState.Closed Then
                conn.ConnectionString = "server=localhost;port=3306;user id=root;password=;database=wmddb"

                conn.Open()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub DisconnectDatabase()
        Try
            conn.Close()
        Catch myerror As MySql.Data.MySqlClient.MySqlException

        End Try
    End Sub
End Module

