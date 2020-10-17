Public Class ExportPermitDataSet
    Inherits DataSet
    Private dt As DataTable
    Public Sub New()
        dt = New DataTable("ExportPermitTable")
        dt.Columns.Add("referenceCode")
        dt.Columns.Add("exportPermitName")
        dt.Columns.Add("exporterName")
        dt.Columns.Add("productName")
        dt.Columns.Add("quantity")
        dt.Columns.Add("measure")
        dt.Columns.Add("amountPerBarrelUS", GetType(Decimal))
        dt.Columns.Add("totalAmountUS", GetType(Decimal))
        dt.Columns.Add("exportPort")
        dt.Columns.Add("applicationType")
        dt.Columns.Add("applicationDate")
        dt.Columns.Add("paid")
        dt.Columns.Add("approvalStatus")
        dt.Columns.Add("approvalDate")
        dt.AcceptChanges()
        Tables.Add(dt)
    End Sub

End Class
