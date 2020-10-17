Imports Microsoft.VisualBasic

Public Class xsmsCentralToolx

    Public Shared Function SetTool() As NNLN

        Dim genTool As New NNLN
        genTool.LocaldbServerName = "localhost"
        genTool.localdbName = "nnlnigeriaweb"
        genTool.LocaldbUsername = "nnlnigeria"
        genTool.LocaldbPassword = "nnl_2013"

        genTool._TypeOfDatabase = smsXMobile.smsXMobile.DataBaseTypes.MySQl_Dotet
        genTool.ConnectionString = genTool.GenConnString

        Return genTool

    End Function

    Public Shared Function setEmail() As NNLN

        Dim genTool As New NNLN
        genTool.LocaldbServerName = "localhost"
        genTool.localdbName = "nnlmailserver"
        genTool.LocaldbUsername = "nnlnigeria"
        genTool.LocaldbPassword = "nnl_2013"

        genTool._TypeOfDatabase = smsXMobile.smsXMobile.DataBaseTypes.MySQl_Dotet
        genTool.ConnectionString = genTool.GenConnString

        Return genTool

    End Function

    Public Shared Function setMySQLConn() As NNLN

        Dim genTool As New NNLN
        genTool.LocaldbServerName = "localhost"
        genTool.localdbName = "nnlnigeriaweb"
        genTool.LocaldbUsername = "nnlnigeria"
        genTool.LocaldbPassword = "nnl_2013"

        genTool._TypeOfDatabase = smsXMobile.smsXMobile.DataBaseTypes.MySQl_Dotet
        genTool.ConnectionString = genTool.GenConnString

        Return genTool

    End Function

    Public Shared Function setxMs() As NNLN

        Dim genTool As New NNLN
        genTool.LocaldbServerName = "localhost"
        genTool.localdbName = "nnlnigeriaweb"
        genTool.LocaldbUsername = "nnlnigeria"
        genTool.LocaldbPassword = "nnl_2013"

        genTool._TypeOfDatabase = smsXMobile.smsXMobile.DataBaseTypes.MySQl_Dotet
        genTool.ConnectionString = genTool.GenConnString

        Return genTool

    End Function
End Class

