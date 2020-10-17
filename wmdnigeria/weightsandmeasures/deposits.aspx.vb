Imports System.Data

Partial Class deposits
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
            txtTranscode.Text = GenTool.GenerateRNDCode(True, True) & GenTool.GenerateUniqueCode & GenTool.GenerateRNDCode(True)

            txtOrderID.Text = Strings.Left(GenTool.GenerateUniqueCode & GenTool.GenerateRNDCode, 10)
            txtAmt.Text = txtAmt.Text.Replace(",", "")

            msgtext = GenTool.checkControl(Panel1, FN, FV, FUpdate)

            If msgtext <> "" Then Return

            Dim fStatus As Boolean = True

            Dim sql = "Insert into deposits(" & FN & ") Values (" & FV & ")"

            If GenTool.ExecuteDatabase(sql) = True Then

                GenTool.FormHistory(txtAmt.Text & " deposited", 0, Val(Session("ID")))

                msgtext = "Record Saved successfully"

                If GenTool.HasDatasetAnyRecord(dsFillCompany) = True Then
                    dsFillCompany = GenTool.getFillCompany(Session("ID"))
                End If

                If GenTool.HasDatasetAnyRecord(dsFillCompany) = False Then
                    With dsFillCompany.Tables(0).Rows(0)
                        GenTool.SendFinancialMail("DEPOSIT INVOICE", txtOrderID.Text, .Item("companyName").ToString, txtAmt.Text, "DEPOSIT", "DEPOSIT", .Item("companyEmail").ToString, "PENDING")
                    End With

                End If


                GenTool.resetform(Panel1)

                filldb("")
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

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If IsPostBack = False Then
            filldb("")
        End If
    End Sub

    Private Sub filldb(ByVal w As String)
        Dim ds As DataSet = GenTool.DataSetData("select CompanyName as 'Company Name' ,PayType as 'Payment Type',sDeposit as 'Deposited Amount',Narration,TransID,date_format(deposits.regDate,'%D-%M-%Y') as Date,DATE_FORMAT(deposits.RegTime, '%h:%i:%S %p') as Time,ApprovalStatus as 'Approval Status',ApprovalNarration,BankName as 'Bank Name'  from deposits,companyregistration where deposits.companyID=companyregistration.sysID AND deposits.companyID=" & Val(Session("ID")) & " " & w)
        Try
            grd.DataSource = ds.Tables(0)
            grd.DataBind()
        Catch ex As Exception
        End Try
    End Sub


    Protected Sub cboPayType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPayType.SelectedIndexChanged
        lblRec0.Visible = False
        txtbankname.Visible = False

        If cboPayType.SelectedIndex = 1 Then
            lblRec.Text = "Enter Reciept Number:"
        ElseIf cboPayType.SelectedIndex = 2 Then
            lblRec.Text = "Enter Cheque Number:"
            lblRec0.Visible = True
            txtbankname.Visible = True
        End If
    End Sub
End Class
