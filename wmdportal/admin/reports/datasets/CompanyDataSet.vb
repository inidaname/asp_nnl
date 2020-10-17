Public Class CompanyDataSet
    Inherits DataSet
    Private dt As DataTable
    Public Sub New()
        dt = New DataTable("CompanyTable")
        dt.Columns.Add("username")
        dt.Columns.Add("companyName")
        dt.Columns.Add("RCNumber")
        dt.Columns.Add("companyAddress")
        dt.Columns.Add("companyPhoneNumber")
        dt.Columns.Add("companyEmail")
        dt.Columns.Add("representativeName")
        dt.Columns.Add("mobileNumber")
        dt.Columns.Add("registrationDate")
        dt.Columns.Add("registrationTime")
        dt.AcceptChanges()
        Tables.Add(dt)
    End Sub

End Class
