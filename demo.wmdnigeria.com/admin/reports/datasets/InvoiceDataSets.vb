
Imports System.Data.DataSet

Public Class InvoiceDataSets
    Inherits DataSet
    Private dt As DataTable
    Public Sub New()
        dt = New DataTable("InvoiceTable")
        dt.Columns.Add("companyName")
        dt.Columns.Add("transCode")
        dt.Columns.Add("narration")
        dt.Columns.Add("amountDue", GetType(Decimal))
        dt.Columns.Add("amountPaid", GetType(Decimal))
        dt.Columns.Add("paymentStatus")
        dt.Columns.Add("paymentDate")
        dt.Columns.Add("approvalStatus")
        dt.Columns.Add("approvalDate")
        dt.Columns.Add("orderId")
        dt.Columns.Add("invoiceDate")
        dt.AcceptChanges()
        Tables.Add(dt)
    End Sub
End Class

