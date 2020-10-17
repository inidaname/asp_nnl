Public Class InstrumentsDataSet
    Inherits DataSet
    Private dt As DataTable
    Public Sub New()
        dt = New DataTable("InstrumentTable")
        dt.Columns.Add("state")
        dt.Columns.Add("paymentYear")
        dt.Columns.Add("totalAmount", GetType(Decimal))
        dt.AcceptChanges()
        Tables.Add(dt)
    End Sub

End Class
