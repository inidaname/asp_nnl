
Partial Class downloadsmember
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init
        Try
            dllDocType.Items.Clear()

            If sysDBUser.exportdatareturns = True Then
                dllDocType.Items.Add("Export Data Returns")
            End If

            If sysDBUser.piaexportdatareturns = True Then
                dllDocType.Items.Add("PIA Export Data Returns")
            End If

            If sysDBUser.otherdocright = True Then
                dllDocType.Items.Add("Other Documents")
            End If

        Catch ex As Exception
        End Try
    End Sub
End Class
