Imports System.Data

Partial Class admcompanymgt
    Inherits System.Web.UI.Page

    Dim GenTool As NNLN = xsmsCentralToolx.SetTool

    Dim dsFillCompany As New DataSet

    Sub populateData(Optional ByVal Iret As Boolean = False, Optional ByVal w As String = "")
        Dim sql As String = "select paymentsheet.sysID as ID,CompanyName,amountDue as Amount,Date_Format(paymentsheet.regDate,'%D-%M-%Y') as RegDate,DATE_FORMAT(paymentsheet.regTime, '%h:%i:%S %p') as RegTime,Date_Format(paymentreciept.regDate,'%D-%M-%Y') as PayDate,DATE_FORMAT(paymentreciept.regTime, '%h:%i:%S %p') as PayTime,paymentsheet.OrderId,paymentreciept.Narration,ApprovalStatus,payType,TransID,BankName,companyregistration.sysID as CompID from paymentsheet,companyregistration,paymentreciept  where paymentsheet.companyID=companyregistration.sysID and accStatus=2 AND paymentreciept.companyID=companyregistration.sysID " & w
        Dim ds As DataSet

        If Iret = False Then
            ds = GenTool.DataSetData(sql)
            filldb(grdappPay, ds)
        Else

            sql = "select deposits.sysID as ID,CompanyName,sDeposit as Amount,Date_Format(deposits.regDate,'%D-%M-%Y') as 'Desposit Date',DATE_FORMAT(deposits.regTime, '%h:%i:%S %p') as 'Desposit Time', OrderId,Narration,ApprovalStatus,payType,TransID,BankName,companyregistration.sysID as CompID from deposits,companyregistration  where  confirmed=0 AND deposits.companyID=companyregistration.sysID "
            ds = GenTool.DataSetData(sql)
            filldb(grdDeposit, ds)
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            If sysDBUser.companymgtright = False Then
                Try
                    Response.Redirect("administrators.aspx?error=You are not permited to view this interface")
                Catch ex As Exception
                End Try
            End If

        If IsPostBack = False Then
            Dim ds As DataSet = getCompany()
            populateData(False)
            populateData(True)
            Try
                If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then

                    cboCompany.DataValueField = "sysID"
                    cboCompany.DataTextField = "companyName"
                    cboCompany.DataSource = ds.Tables(0)
                    cboCompany.DataBind()
                    lblccount.Text = ds.Tables(0).Rows.Count.ToString & " Companies"
                End If

            Catch ex As Exception
            Finally
                cboCompany.Items.Insert(0, "Select Company")
            End Try
            End If

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub cboCompany_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCompany.SelectedIndexChanged
        Dim Sql As String = "select CompanyName,StreetAddress,POBOX,companyEmail as Email,companywebsite as Website,Telephone,if(RecordStatus=0,'Active' ,'Dormant') as AccStatus,(select count(sysID) from deviceregistration where AccountID=companyregistration.sysID) as RegDevices from companyregistration " & _
            " Where sysID=" & Val(cboCompany.SelectedValue.Split("|").ToArray(0))

        Dim ds As DataSet = GenTool.DataSetData(Sql)
        filldb(grd, ds)

        populateData(False, " AND paymentreciept.companyID=" & Val(cboCompany.SelectedValue.Split("|").ToArray(0)))

        btnUpdate.Enabled = Not cboCompany.SelectedIndex < 1
        Try
            chkStatus.Checked = IIf(ds.Tables(0).Rows(0).Item("AccStatus") = "Active", True, False)
        Catch ex As Exception
        End Try

    End Sub


    Private Sub filldb(ByVal grdX As GridView, ByVal ds As DataSet)
        Try
            grdX.DataSource = ds.Tables(0)
            grdX.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            Dim sql As String = "update companyregistration set recordStatus=" & IIf(chkStatus.Checked = True, 0, 1) & "  where sysID=" & Val(cboCompany.SelectedValue.Split("|").ToArray(0))

            If GenTool.ExecuteDatabase(sql) = True Then
                MessageBox.Show(Me, "Record updated successfully")

                If chkStatus.Checked = True Then
                    GenTool.FormHistory(cboCompany.SelectedItem.Text & " was enabled ", Request.UserHostAddress, Val(Session("sysID")))
                Else
                    GenTool.FormHistory(cboCompany.SelectedItem.Text & " was disabled ", Request.UserHostAddress, Val(Session("sysID")))
                End If
                cboCompany_SelectedIndexChanged(Nothing, Nothing)

                chkStatus.Checked = False

            Else
                MessageBox.Show(Me, "Record update failed")
            End If

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnSaveApproval_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveApproval.Click
        Try
            Dim fStatus As String
            If optApprove.Checked = True Then
                fStatus = "Approved"
            Else
                fStatus = "Rejected"
            End If

            Dim sql As String = "select sysID from paymentsheet where accStatus=2 AND sysID=" & Val(grdappPay.SelectedRow.Cells(1).Text)
            If GenTool.HasRows(sql) = False Then
                MessageBox.Show(Me, "The record you are trying to access has been attended by someone,please choose another record")
                GenTool.resetform(pnlRecommend)
                populateData()
                Return
            End If

            sql = "update paymentsheet set accStatus=4,UserID=" & Val(Session("sysID")) & ",AmountPaid=BookAmount,ApprovalNarration=" & _
             GenTool.addbackslash(txtAPpCC.Text) & ",ApprovalStatus=" & GenTool.addbackslash(fStatus) & "  where sysID=" & Val(grdappPay.SelectedRow.Cells(1).Text)

            If GenTool.ExecuteDatabase(sql) = True Then
                GenTool.FormHistory("Company Name :: " & txtCompanyName.Text & " Amount :: " & txtAmount.Text & " Status ::: " & fStatus, Request.UserHostAddress, Val(Session("sysID")))

                dsFillCompany = GenTool.getFillCompany(txtPayCID.Text)

                If GenTool.HasDatasetAnyRecord(dsFillCompany) = False Then

                    With dsFillCompany.Tables(0).Rows(0)
                        If optApprove.Checked = True Then
                            GenTool.SendFinancialMail("COMPANY PAYMENT APPROVAL STATUS", txtOrderIDPay.Text, .Item("companyName").ToString, txtAmount.Text, txtAPpCC.Text, "PAYMENT APPROVED", .Item("companyEmail").ToString, fStatus.ToUpper)
                        Else
                            GenTool.SendFinancialMail("COMPANY PAYMENT APPROVAL STATUS", txtOrderIDPay.Text, .Item("companyName").ToString, txtAmount.Text, txtAPpCC.Text, "PAYMENT REJECTED", .Item("companyEmail").ToString, fStatus.ToUpper)
                        End If

                    End With
                End If

                MessageBox.Show(Me, "Record updated successfully")
                GenTool.resetform(pnlRecommend)
                optApprove.Checked = True
                populateData()
            Else
                MessageBox.Show(Me, "Record save failed")
            End If

        Catch ex As Exception
            GenTool.GrabError(ex.Message, "btnSaveApproval_Click")
        End Try
    End Sub

 

    Protected Sub grdappPay_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdappPay.SelectedIndexChanged
        Try

            With grdappPay.SelectedRow
                txtCompanyName.Text = Server.HtmlDecode(.Cells(2).Text)
                txtAmount.Text = .Cells(3).Text
                txtOrderIDPay.Text = .Cells(8).Text
                txtTransID.Text = .Cells(12).Text
                txtPayType.Text = .Cells(11).Text
                txtPayCID.Text = .Cells(14).Text
            End With

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnSaveDeposit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveDeposit.Click
        Try
            Dim fStatus As String
            If optApprove.Checked = True Then
                fStatus = "Approved"
            Else
                fStatus = "Rejected"
            End If

            Dim sql As String = "select sysID from deposits where confirmed=1 AND sysID=" & Val(grdDeposit.SelectedRow.Cells(1).Text)
            If GenTool.HasRows(sql) = True Then
                MessageBox.Show(Me, "The record you are trying to access has been attended by someone,please choose another record")
                GenTool.resetform(pnlVerificationSheet)
                populateData(True)
                Return
            End If

            sql = "update deposits set confirmed=1,UserID=" & Val(Session("sysID")) & ",ApprovalNarration=" & _
             GenTool.addbackslash(TXTNarrationdepo.Text) & ",ApprovalStatus=" & GenTool.addbackslash(fStatus) & "  where sysID=" & Val(grdDeposit.SelectedRow.Cells(1).Text)

            If GenTool.ExecuteDatabase(sql) = True Then
                GenTool.FormHistory("Company Name :: " & txtdcn.Text & " Amount :: " & txtdamt.Text & " Status ::: " & fStatus, Request.UserHostAddress, Val(Session("sysID")))

                dsFillCompany = GenTool.getFillCompany(txtDepositCID.Text)

                If GenTool.HasDatasetAnyRecord(dsFillCompany) = False Then

                    With dsFillCompany.Tables(0).Rows(0)
                        If optApprove.Checked = True Then
                            GenTool.SendFinancialMail("COMPANY DEPOSIT APPROVAL STATUS", txtOrderIDDeposit.Text, .Item("companyName").ToString, txtdamt.Text, TXTNarrationdepo.Text, "DEPOSIT APPROVED", .Item("companyEmail").ToString, fStatus.ToUpper)
                        Else
                            GenTool.SendFinancialMail("COMPANY DEPOSIT APPROVAL STATUS", txtOrderIDDeposit.Text, .Item("companyName").ToString, txtdamt.Text, TXTNarrationdepo.Text, "DEPOSIT REJECTED", .Item("companyEmail").ToString, fStatus.ToUpper)
                        End If

                    End With
                End If

                MessageBox.Show(Me, "Record updated successfully")
                GenTool.resetform(pnlVerificationSheet)
                optDApp.Checked = True
                populateData(True)
            Else
                MessageBox.Show(Me, "Record save failed")
            End If

        Catch ex As Exception
            GenTool.GrabError(ex.Message, "btnSaveDeposit_Click")
        End Try
    End Sub

    Private Sub grdappPay_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdappPay.RowCreated
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                e.Row.Attributes("onmouseover") = "this.style.cursor='pointer';this.style.textDecoration='none';"
                e.Row.Attributes("onmouseout") = "this.style.textDecoration='none';"
                e.Row.ToolTip = "Click to select row"
                e.Row.Attributes("onclick") = Me.Page.ClientScript.GetPostBackClientHyperlink(Me.grdappPay, "Select$" & e.Row.RowIndex)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub grdDeposit_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdDeposit.PageIndexChanging
        Try
            grdDeposit.PageIndex = e.NewPageIndex
            populateData(True)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub grdDeposit_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdDeposit.RowCreated
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                e.Row.Attributes("onmouseover") = "this.style.cursor='pointer';this.style.textDecoration='none';"
                e.Row.Attributes("onmouseout") = "this.style.textDecoration='none';"
                e.Row.ToolTip = "Click to select row"
                e.Row.Attributes("onclick") = Me.Page.ClientScript.GetPostBackClientHyperlink(Me.grdDeposit, "Select$" & e.Row.RowIndex)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub grdDeposit_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDeposit.SelectedIndexChanged
        Try

            With grdDeposit.SelectedRow
                txtdcn.Text = Server.HtmlDecode(.Cells(2).Text)
                txtdamt.Text = .Cells(3).Text
                txtOrderIDDeposit.Text = .Cells(6).Text
                txtdpaytype.Text = .Cells(9).Text
                txtdtransID.Text = .Cells(10).Text
                txtDepositCID.Text = .Cells(12).Text
            End With

        Catch ex As Exception
        End Try
    End Sub
 
    Protected Sub grdappPay_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdappPay.PageIndexChanging
        grdappPay.PageIndex = e.NewPageIndex
        populateData(False)
    End Sub
End Class
