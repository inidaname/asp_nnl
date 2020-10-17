Imports System.Data.DataSet

Public Class InvoiceDataSet
    Inherits DataSet
    Private dt As DataTable
    Public Sub New()
        dt = New DataTable("InvoiceTable")
        dt.Columns.Add("transCode")
        dt.Columns.Add("amountDue", GetType(Decimal))
        dt.Columns.Add("narration")
        dt.Columns.Add("amountPaid", GetType(Decimal))
        dt.Columns.Add("paymentStatus")
        dt.Columns.Add("approvalStatus")
        dt.Columns.Add("orderId")
        dt.Columns.Add("invoiceDate")
        dt.Columns.Add("companyName")
        dt.AcceptChanges()
        Tables.Add(dt)
    End Sub
End Class
