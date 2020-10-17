Public Class MessageBox
    Public Shared Sub Show(ByVal pg As Control, ByVal sMessage As String)
        Try
            Dim jv As String = "alert('" & sMessage & "');"
            ScriptManager.RegisterClientScriptBlock(pg, pg.GetType(), "msg", jv, True)
        Catch ex As Exception
        End Try
    End Sub

End Class