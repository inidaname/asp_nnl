Imports Microsoft.VisualBasic
Imports System.Data

Public Class dropDownFiller
    Dim _ddlDown As DropDownList, _dsDB As DataSet, _fieldname As String, _uniqueName As String, _SQL As String, _defaultValue As String, _noDefaultValue As Boolean


    Property ddlDown As DropDownList
        Get
            Return _ddlDown
        End Get
        Set(value As DropDownList)
            _ddlDown = value
        End Set
    End Property

    Property dsDB As DataSet
        Get
            Return _dsDB
        End Get
        Set(value As DataSet)
            _dsDB = value
        End Set
    End Property

    Property fieldname As String
        Get
            Return _fieldname
        End Get
        Set(value As String)
            _fieldname = value
        End Set
    End Property

    Property uniqueName As String
        Get
            Return _uniqueName
        End Get
        Set(value As String)
            _uniqueName = value
        End Set
    End Property

    Property SQL As String
        Get
            Return _SQL
        End Get
        Set(value As String)
            _SQL = value
        End Set
    End Property

    Property defaultValue As String
        Get
            Return _defaultValue
        End Get
        Set(value As String)
            _defaultValue = value
        End Set
    End Property

    Property NoDefaultValue As Boolean
        Get
            Return _noDefaultValue
        End Get
        Set(value As Boolean)
            _noDefaultValue = value
        End Set
    End Property

End Class
