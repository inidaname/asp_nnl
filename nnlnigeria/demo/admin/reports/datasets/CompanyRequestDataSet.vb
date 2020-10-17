Public Class CompanyRequestDataSet
    Inherits DataSet
    Private dt As DataTable
    Public Sub New()
        dt = New DataTable("CompanyRequestTable")
        dt.Columns.Add("companyName")
        dt.Columns.Add("transCode")
        dt.Columns.Add("sector")
        dt.Columns.Add("instrumentCategory")
        dt.Columns.Add("deviceType")
        dt.Columns.Add("deviceModelName")
        dt.Columns.Add("modelNumber")
        dt.Columns.Add("serialNumber")
        dt.Columns.Add("measurementRange")
        dt.Columns.Add("actualMeasure", GetType(Int64))
        dt.Columns.Add("deviceAmount", GetType(Decimal))
        dt.Columns.Add("registrationDate")
        dt.Columns.Add("registrationTime")
        dt.AcceptChanges()
        Tables.Add(dt)
    End Sub

End Class
