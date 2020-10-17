Public Class ExportReturnDataSet
    Inherits DataSet
    Private dt As DataTable
    Public Sub New()
        dt = New DataTable("ExportReturnTable")
        dt.Columns.Add("companyID", GetType(System.Int32))
        dt.Columns.Add("exporter")
        dt.Columns.Add("exportPermitID")
        dt.Columns.Add("exportQuarter")
        dt.Columns.Add("exportMonth")
        dt.Columns.Add("stream")
        dt.Columns.Add("bLadingDate")
        dt.Columns.Add("proceedVessel")
        dt.Columns.Add("proceedsDestination")
        dt.Columns.Add("proceedNGN", GetType(Decimal))
        dt.Columns.Add("proceedUSD", GetType(Decimal))
        dt.Columns.Add("pricePerBarrel")
        dt.Columns.Add("crudeType")
        dt.Columns.Add("liftingDestination")
        dt.Columns.Add("referenceID")
        dt.Columns.Add("status")
        dt.AcceptChanges()
        Tables.Add(dt)
    End Sub

End Class
