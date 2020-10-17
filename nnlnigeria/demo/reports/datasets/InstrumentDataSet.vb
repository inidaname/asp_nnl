Imports System.Data.DataSet

Public Class InstrumentDataSet
    Inherits DataSet
    Private dt As DataTable
    Public Sub New()
        dt = New DataTable("InstrumentTable")
        dt.Columns.Add("deviceType")
        dt.Columns.Add("deviceModelName")
        dt.Columns.Add("modelNumber")
        dt.Columns.Add("serialNumber")
        dt.Columns.Add("deviceAmount", GetType(Decimal))
        dt.Columns.Add("transCode")
        dt.Columns.Add("registrationDate")
        dt.Columns.Add("registrationTime")
        dt.Columns.Add("companyName")
        dt.AcceptChanges()
        Tables.Add(dt)
    End Sub
End Class
