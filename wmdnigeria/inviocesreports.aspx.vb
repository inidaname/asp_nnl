Imports System.Data

Partial Class invioces
    Inherits System.Web.UI.Page
    Dim GenTool As NNLN = xsmsCentralToolx.SetTool


    Private Sub filldb(SQL As String, sumColumn As Int16)

        Dim ds As DataSet = GenTool.DataSetData(SQL)

        Try

            grd.DataSource = ds.Tables(0)
            grd.DataBind()
            Dim sd As String = GenTool.getSummation(grd, sumColumn)
            lblMsg.Text = Val(sd).ToString("Total OutStanding Bill : #,#.00")

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            Dim sql As String = ""
            Dim w As String = ""
            If chkIncludeDate.Checked = True Then
                w &= " And paymentsheet.regDate>=" & GenTool.addbackslash(txtDPTFrom.Text) & "AND paymentsheet.regDate<=" & GenTool.addbackslash(txtDPTTo.Text)
            End If

            Dim f As Int16 = 7
            If cboQueryOptions.SelectedIndex = 0 Then
                sql = "Select (select DeviceType from maindevicesection where sysID=TypeOfDevice limit 1) as 'Instrument Type' ,Location,serialNumber as 'Serial Number',modelNumber as 'Model Number',amountDue as 'Fee Payable',AmountPaid as 'Amount Paid',amountDue-AmountPaid as 'Outstanding Fee',date_format(paymentsheet.regDate,'%D-%M-%Y') as 'Trans Date'  from paymentsheet,deviceregistration where  paymentsheet.companyID=deviceregistration.AccountID AND paymentsheet.TransCode=deviceregistration.TransCode AND  paymentsheet.narration='Annual Licensing Fee' "
            ElseIf cboQueryOptions.SelectedIndex = 1 Then
                sql = "Select (select DeviceType from maindevicesection where sysID=TypeOfDevice limit 1) as 'Instrument Type' ,Location,serialNumber as 'Serial Number',modelNumber as 'Model Number',AmountDue as 'Fee Payable',AmountPaid as 'Amount Paid',amountDue-AmountPaid as 'Outstanding Fee',date_format(paymentsheet.regDate,'%D-%M-%Y') as 'Trans Date'  from paymentsheet,deviceregistration where  paymentsheet.companyID=deviceregistration.AccountID AND paymentsheet.TransCode=deviceregistration.TransCode AND  paymentsheet.narration='PATTERN OF APPROVAL FEE' "

            Else
                sql = "Select   exportPort as 'Export Terminal',finalQuantity as 'Export Quantity',amountDue as 'Fee Payable(FOB)',AmountPaid as 'Amount Paid',amountDue-AmountPaid as 'Outstanding Fee',date_format(paymentsheet.regDate,'%D-%M-%Y') as 'Trans Date'  from paymentsheet,exportpermit where  paymentsheet.companyID=exportpermit.companyID  AND  paymentsheet.narration='Export Permit Application' "
                f = 5
            End If

            w &= " And paymentsheet.companyID=" & Val(Session("ID"))

            filldb(sql & " " & w, f)

        Catch ex As Exception
        End Try
    End Sub

 
End Class
