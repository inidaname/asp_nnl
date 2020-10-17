Imports System.Data

Partial Class payment
    Inherits System.Web.UI.Page
    Dim GenTool As NNLN = xsmsCentralToolx.SetTool

    Dim FN As String = ""
    Dim FV As String = ""
    Dim FUpdate As String = ""

    Dim dsFillCompany As New DataSet

    Protected Sub btnPayment_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPayment.Click
        Dim msgtext As String = ""

        Try

            FUpdate = ""
            FV = ""
            FN = ""

            txtID.Text = Session("ID")
            txtPID.Text = Session("mkid")


            txtTranscode.Text = GenTool.GenerateRNDCode(True, True) & GenTool.GenerateUniqueCode & GenTool.GenerateRNDCode(True)
            If String.IsNullOrEmpty(txtOrderID.Text) = True Then txtOrderID.Text = Strings.Left(GenTool.GenerateUniqueCode & GenTool.GenerateRNDCode, 10)

            txtWallet.Text = GenTool.getSingleValue("select totalDeposit from companyregistration where sysID=" & Val(Session("ID")))

            If Val(Session("tkamtsum")) > Val(txtWallet.Text) AndAlso cboPayType.SelectedIndex = 1 Then
                msgtext = "Amount deposited is less than what you are paying,please fund your account and continue"
                Return
            End If

            Dim f1() As String
            Dim f2() As String
            Dim f3() As String
            Dim f4() As String
            Dim narration As String = ""

            Dim sf As New ArrayList
            Dim sql As String = ""


            f4 = Split(Session("sysnarration"), "||+=+")

            f1 = Split(Session("mkid"), "||+=+")
            f2 = Split(Session("sysnarration"), "||+=+")
            f3 = Split(Session("tkamt"), "||+=+")

            For k As Integer = 0 To f1.Length - 1

                FUpdate = ""
                FV = ""
                FN = ""
                txtPID.Text = Val(f1(k))
                txtAmt.Text = Val(f3(k))

                msgtext = GenTool.checkControl(Panel1, FN, FV, FUpdate)
                If msgtext <> "" Then Return

                sql = "Insert into paymentreciept(" & FN & ") Values (" & FV & ")"
                sf.Add(sql)

                If String.IsNullOrEmpty(narration) = True Then
                    narration = f4(k)
                Else
                    narration &= ControlChars.CrLf & f4(k)
                End If

            Next

            If GenTool.ExecuteBulkSQL(sf) = True Then

                For k As Integer = 0 To f1.Length - 1
                    txtAmt.Text = Val(f3(k))

                    GenTool.FormHistory(txtAmt.Text & " payment", 0, Val(Session("ID")))

                    msgtext = "Record Saved successfully"

                    If GenTool.HasDatasetAnyRecord(dsFillCompany) = True Then
                        dsFillCompany = GenTool.getFillCompany(Session("ID"))
                    End If

                    If GenTool.HasDatasetAnyRecord(dsFillCompany) = False Then
                        With dsFillCompany.Tables(0).Rows(0)
                            GenTool.SendFinancialMail("PAYMENT NOTICE ALERT", txtOrderID.Text, .Item("companyName").ToString, txtAmt.Text, "PAYMENT MADE BY " & cboPayType.Text.ToUpper, "PAYMENT", .Item("companyEmail").ToString, "AWAITING APPROVAL", "Payment Receipt")
                        End With

                    End If
                Next

                Try
                    If cboPayType.SelectedIndex = 4 Then
                        If f1.Length > 1 Then
                            narration = "General Service/Registration Payment"
                        End If

                        GenTool.DoOnlinePayment(Me, Session("tkamtsum"), Strings.Left(GenTool.GenerateUniqueCode & GenTool.GenerateRNDCode, 10), narration, Session("email"))
                    End If
                Catch ex As Exception
                End Try

                GenTool.resetform(Panel1)
            Else
                msgtext = "Record save failed"
            End If

        Catch ex As Exception
            msgtext = ex.Message
        Finally
            If msgtext <> "" Then MessageBox.Show(Me, msgtext)
        End Try
    End Sub

    Protected Sub btnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click
        GenTool.resetform(Panel1)
    End Sub

    Protected Sub cboPayType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPayType.SelectedIndexChanged
        lblRec0.Visible = False
        txtbankname.Visible = False
        chkOk.Checked = False
        txtonlineOrderID.Text = ""

        txtCode.ReadOnly = False
        If cboPayType.SelectedIndex = 2 Then
            lblRec.Text = "Enter Reciept Number:"
        ElseIf cboPayType.SelectedIndex = 3 Then
            lblRec.Text = "Enter Cheque Number:"
            lblRec0.Visible = True
            txtbankname.Visible = True
        ElseIf cboPayType.SelectedIndex = 1 Then
            chkOk.Checked = True
        ElseIf cboPayType.SelectedIndex = 4 Then
            txtCode.Text = Strings.Left(GenTool.GenerateUniqueCode & GenTool.GenerateRNDCode, 12)
            txtonlineOrderID.Text = txtCode.Text
            txtCode.ReadOnly = True
        End If

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Try
            If String.IsNullOrEmpty(Session("mkid")) = True Then
                Response.Redirect("Default.aspx")
            End If
        Catch ex As Exception
        End Try

        If IsPostBack = False Then
            txtAmt.Text = Session("tkamtsum")
            txtWallet.Text = GenTool.getSingleValue("select totalDeposit from companyregistration where sysID=" & Val(Session("ID")))
        End If
    End Sub
End Class
