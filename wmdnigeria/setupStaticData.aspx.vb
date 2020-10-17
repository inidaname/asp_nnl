
Partial Class setupStaticData
    Inherits System.Web.UI.Page

    Dim GenTool As NNLN = xsmsCentralToolx.SetTool

    Protected Sub imgBtnState_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnState.Click
        Try

            If dllSetupDate.SelectedIndex = 0 Then
                AllStaticDate()
            ElseIf dllSetupDate.SelectedIndex = 1 Then
                FeeGroup()

            ElseIf dllSetupDate.SelectedIndex = 2 Then
                SetupFrontpage()

            ElseIf dllSetupDate.SelectedIndex = 3 Then
                GetDeviceSection()
            ElseIf dllSetupDate.SelectedIndex = 4 Then
                SetupAddress()
            End If

            MessageBox.Show(Me, "Process was successfull")

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As System.EventArgs) Handles btnUpdate.Click
        Try
            If Val(txtamtPerBarrel.Text) = 0 OrElse Val(txtExchangeRate.Text) = 0 Then
                MessageBox.Show(Me, "Invalid Amount, All Fields Are Required")
                Return
            End If

            Dim sd As String = "update systemsetup set exchangeRate=" & Val(txtExchangeRate.Text) & ",AmtPerBarrel=" & Val(txtamtPerBarrel.Text)
            If GenTool.ExecuteDatabase(sd) = True Then
                MessageBox.Show(Me, "Record Updated Successfully")
            Else
                MessageBox.Show(Me, "Record Updated Failed")
            End If


        Catch ex As Exception
        End Try
    End Sub

    Protected Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init
        Try
            getSystemSetup()

            Try
                With dsSystemSetup.Tables(0).Rows(0)
                    txtamtPerBarrel.Text = .Item("AmtPerBarrel")
                    txtExchangeRate.Text = .Item("exchangeRate")
                End With
            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try
    End Sub
End Class
