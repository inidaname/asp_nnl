Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://nnlnigeria.com/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class NNLWS
    Inherits System.Web.Services.WebService

    Dim GenTool As NNLN = xsmsCentralToolx.SetTool

    <WebMethod()> _
    Public Function getUser(ByVal Username As String, ByVal password As String, ByVal computername As String) As DataSet
        Try

            Dim sql As String = "Select * from systemusers where recordstatus=0 AND username=" & GenTool.addbackslash(Username) & " AND userpwd=" & GenTool.addbackslash(password)
            Dim ds As DataSet = GenTool.DataSetData(sql)

            If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                GenTool.FormHistory("Downloaded account details on " & computername, computername, Val(ds.Tables(0).Rows(0).Item("sysID").ToString), 0)
            Else
                GenTool.FormHistory("Invalid access on trying to downaload account details from " & computername, computername, 0, 0)
            End If

            Return ds

        Catch ex As Exception
            GenTool.GrabError(ex.Message, "getUser-webservices")
            Return Nothing
        End Try
    End Function

    <WebMethod()> _
    Public Function getCountrydata(ByVal Username As String, ByVal password As String, ByRef Min As Long, ByRef Max As Long) As DataSet
        Try

            If checkuser(Username, password, 0) = False Then Return Nothing

            Dim sql As String

            If dsLcountry Is Nothing OrElse dsLcountry.Tables.Count < 1 OrElse dsLcountry.Tables(0).Rows.Count < 1 Then
                getCountry()
            End If

            If Min = 0 OrElse Max = 0 Then
                With dsLcountry.Tables(0)
                    Min = Val(.Rows(0).Item("sysID").ToString)
                    Max = Val(.Rows(.Rows.Count - 1).Item("sysID").ToString)
                End With

                sql = "sysID>=1 AND sysID<=100"
            Else
                sql = "sysID>=" & Min & " AND sysID<=" & Max
            End If

            Dim ds As DataSet = GenTool.getFromDataset(dsLcountry, sql)

            Return ds
        Catch ex As Exception
            GenTool.GrabError(ex.Message, "getCountry-webservices")
            Return Nothing
        End Try
    End Function

    <WebMethod()> _
    Public Function getFeeSubGroup(ByVal Username As String, ByVal password As String, ByRef Min As Long, ByRef Max As Long) As DataSet
        Try

            If checkuser(Username, password, 0) = False Then Return Nothing

            Dim sql As String

            If Min = 0 OrElse Max = 0 Then
                Dim ds As DataSet = GenTool.DataSetData("select min(sysID),max(sysID) from feesubgroup")
                If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                    Min = Val(ds.Tables(0).Rows(0).Item(0))
                    Max = Val(ds.Tables(0).Rows(0).Item(1))
                    ds.Dispose()
                Else
                    Min = 1
                    Max = 100
                End If

                sql = "select * from feesubgroup where sysID>=1 AND sysID<=100"
            Else
                sql = "select * from feesubgroup where  sysID>=" & Min & " AND sysID<=" & Max
            End If

            Dim dsk As DataSet = GenTool.DataSetData(sql)

            Return dsk
        Catch ex As Exception
            GenTool.GrabError(ex.Message, "getMainSector-webservices")
            Return Nothing
        End Try
    End Function

    <WebMethod()> _
    Public Function getFeeMainGroup(ByVal Username As String, ByVal password As String, ByRef Min As Long, ByRef Max As Long) As DataSet
        Try

            If checkuser(Username, password, 0) = False Then Return Nothing

            If dsScaleGroup Is Nothing OrElse dsScaleGroup.Tables.Count < 1 OrElse dsScaleGroup.Tables(0).Rows.Count < 1 Then
                getScaleGroup()
            End If

            Dim sql As String

            If Min = 0 OrElse Max = 0 Then
                With dsScaleGroup.Tables(0)
                    Min = Val(.Rows(0).Item("sysID").ToString)
                    Max = Val(.Rows(.Rows.Count - 1).Item("sysID").ToString)
                End With

                sql = "sysID>=1 AND sysID<=100"
            Else
                sql = "sysID>=" & Min & " AND sysID<=" & Max
            End If

            Dim ds As DataSet = GenTool.getFromDataset(dsScaleGroup, sql)

            Return ds
        Catch ex As Exception
            GenTool.GrabError(ex.Message, "getMainSector-webservices")
            Return Nothing
        End Try
    End Function

    <WebMethod()> _
    Public Function getMainSubDeviceData(ByVal Username As String, ByVal password As String, ByRef Min As Long, ByRef Max As Long) As DataSet
        Try

            If checkuser(Username, password, 0) = False Then Return Nothing

            If dsMainSubDevice Is Nothing OrElse dsMainSubDevice.Tables.Count < 1 OrElse dsMainSubDevice.Tables(0).Rows.Count < 1 Then
                getMainSubDevice()
            End If

            Dim sql As String

            If Min = 0 OrElse Max = 0 Then
                With dsMainSubDevice.Tables(0)
                    Min = Val(.Rows(0).Item("sysID").ToString)
                    Max = Val(.Rows(.Rows.Count - 1).Item("sysID").ToString)
                End With

                sql = "sysID>=1 AND sysID<=100"
            Else
                sql = "sysID>=" & Min & " AND sysID<=" & Max
            End If

            Dim ds As DataSet = GenTool.getFromDataset(dsMainSubDevice, sql)

            Return ds
        Catch ex As Exception
            GenTool.GrabError(ex.Message, "getCity-webservices")
            Return Nothing
        End Try
    End Function

    <WebMethod()> _
    Public Function getMainDeviceData(ByVal Username As String, ByVal password As String, ByRef Min As Long, ByRef Max As Long) As DataSet
        Try

            If checkuser(Username, password, 0) = False Then Return Nothing

            If dsMainDevice Is Nothing OrElse dsMainDevice.Tables.Count < 1 OrElse dsMainDevice.Tables(0).Rows.Count < 1 Then
                getMainDevice()
            End If

            Dim sql As String

            If Min = 0 OrElse Max = 0 Then
                With dsMainDevice.Tables(0)
                    Min = Val(.Rows(0).Item("sysID").ToString)
                    Max = Val(.Rows(.Rows.Count - 1).Item("sysID").ToString)
                End With

                sql = "sysID>=1 AND sysID<=100"
            Else
                sql = "sysID>=" & Min & " AND sysID<=" & Max
            End If

            Dim ds As DataSet = GenTool.getFromDataset(dsMainDevice, sql)

            Return ds
        Catch ex As Exception
            GenTool.GrabError(ex.Message, "getCity-webservices")
            Return Nothing
        End Try
    End Function

    <WebMethod()> _
    Public Function getFeeTableData(ByVal Username As String, ByVal password As String, ByRef Min As Long, ByRef Max As Long) As DataSet
        Try

            If checkuser(Username, password, 0) = False Then Return Nothing

            If dsFeeTable Is Nothing OrElse dsFeeTable.Tables.Count < 1 OrElse dsFeeTable.Tables(0).Rows.Count < 1 Then
                getFeeTable()
            End If

            Dim sql As String

            If Min = 0 OrElse Max = 0 Then
                Dim ds As DataSet = GenTool.DataSetData("select min(sysID),max(sysID) from feetable")
                If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                    Min = Val(ds.Tables(0).Rows(0).Item(0))
                    Max = Val(ds.Tables(0).Rows(0).Item(1))
                    ds.Dispose()
                Else
                    Min = 1
                    Max = 100
                End If

                sql = "select * from feetable where sysID>=1 AND sysID<=100"
            Else
                sql = "select * from feetable where  sysID>=" & Min & " AND sysID<=" & Max
            End If

            Dim dsk As DataSet = GenTool.DataSetData(sql)

            Return dsk
        Catch ex As Exception
            GenTool.GrabError(ex.Message, "getCity-webservices")
            Return Nothing
        End Try
    End Function

    <WebMethod()> _
    Public Function getCityData(ByVal Username As String, ByVal password As String, ByRef Min As Long, ByRef Max As Long) As DataSet
        Try

            If checkuser(Username, password, 0) = False Then Return Nothing

            If dsCity Is Nothing OrElse dsCity.Tables.Count < 1 OrElse dsCity.Tables(0).Rows.Count < 1 Then
                getCity()
            End If

            Dim sql As String

            If Min = 0 OrElse Max = 0 Then
                With dsCity.Tables(0)
                    Min = Val(.Rows(0).Item("sysID").ToString)
                    Max = Val(.Rows(.Rows.Count - 1).Item("sysID").ToString)
                End With

                sql = "sysID>=1 AND sysID<=100"
            Else
                sql = "sysID>=" & Min & " AND sysID<=" & Max
            End If

            Dim ds As DataSet = GenTool.getFromDataset(dsCity, sql)

            Return ds
        Catch ex As Exception
            GenTool.GrabError(ex.Message, "getCity-webservices")
            Return Nothing
        End Try
    End Function

    <WebMethod()> _
    Public Function getStateData(ByVal Username As String, ByVal password As String, ByRef Min As Long, ByRef Max As Long) As DataSet
        Try

            If checkuser(Username, password, 0) = False Then Return Nothing

            If dsState Is Nothing OrElse dsState.Tables.Count < 1 OrElse dsState.Tables(0).Rows.Count < 1 Then
                getState()
            End If

            Dim sql As String

            If Min = 0 OrElse Max = 0 Then
                With dsState.Tables(0)
                    Min = Val(.Rows(0).Item("sysID").ToString)
                    Max = Val(.Rows(.Rows.Count - 1).Item("sysID").ToString)
                End With

                sql = "sysID>=1 AND sysID<=100"
            Else
                sql = "sysID>=" & Min & " AND sysID<=" & Max
            End If

            Dim ds As DataSet = GenTool.getFromDataset(dsState, sql)

            Return ds
        Catch ex As Exception
            GenTool.GrabError(ex.Message, "getState-webservices")
            Return Nothing
        End Try
    End Function

    <WebMethod()> _
    Public Function getLGAALLData(ByVal Username As String, ByVal password As String, ByRef Min As Long, ByRef Max As Long) As DataSet
        Try

            If checkuser(Username, password, 0) = False Then Return Nothing


            Dim sql As String, ds As DataSet

            If Min = 0 OrElse Max = 0 Then
                ds = GenTool.DataSetData("select min(sysID),max(sysID) from tbllga")
                If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                    Min = Val(ds.Tables(0).Rows(0).Item(0))
                    Max = Val(ds.Tables(0).Rows(0).Item(1))
                    ds.Dispose()
                End If

                sql = "select * from tbllga where sysID>=1 AND sysID<=100"
            Else
                sql = "select * from tbllga  where sysID>=" & Min & " AND sysID<=" & Max
            End If

            Return GenTool.DataSetData(sql)
        Catch ex As Exception
            GenTool.GrabError(ex.Message, "getLGAALLData-webservices")
            Return Nothing
        End Try
    End Function

    <WebMethod()> _
    Public Function getLGAData(ByVal Username As String, ByVal password As String, ByVal StateName As String, ByRef Min As Long, ByRef Max As Long) As DataSet
        Try

            If checkuser(Username, password, 0) = False Then Return Nothing


            If dsLGAState Is Nothing OrElse dsLGAState.Tables.Count < 1 OrElse dsLGAState.Tables(0).Rows.Count < 1 Then
                getLGA()
            End If

            Dim sql As String

            If Min = 0 OrElse Max = 0 Then
                With dsLGAState.Tables(StateName)
                    Min = Val(.Rows(0).Item("sysID").ToString)
                    Max = Val(.Rows(.Rows.Count - 1).Item("sysID").ToString)
                End With

                sql = "sysID>=1 AND sysID<=100"
            Else
                sql = "sysID>=" & Min & " AND sysID<=" & Max
            End If

            Dim ds As DataSet = GenTool.getFromDataset(dsLGAState, sql)

            Return ds
        Catch ex As Exception
            GenTool.GrabError(ex.Message, "getLGA-webservices")
            Return Nothing
        End Try
    End Function

    <WebMethod()> _
    Public Function getCompany(ByVal Username As String, ByVal password As String, ByRef Min As Long, ByRef Max As Long) As DataSet
        Try

            If checkuser(Username, password, 0) = False Then Return Nothing

            Dim ds As DataSet
            Dim sql As String

            If Min = 0 OrElse Max = 0 Then
                ds = GenTool.DataSetData("select min(sysID),max(sysID) from companyregistration")
                If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                    Min = Val(ds.Tables(0).Rows(0).Item(0))
                    Max = Val(ds.Tables(0).Rows(0).Item(1))
                    ds.Dispose()
                End If

                sql = "select * from companyregistration where sysID>=1 AND sysID<=100"
            Else
                sql = "select * from companyregistration  where sysID>=" & Min & " AND sysID<=" & Max
            End If

            ds = GenTool.DataSetData(sql)

            Return ds
        Catch ex As Exception
            GenTool.GrabError(ex.Message, "getCompany-webservices")
            Return Nothing
        End Try
    End Function

    <WebMethod()> _
    Public Function getDebtedDevice(ByVal Username As String, ByVal password As String, ByVal accountID As Long, ByVal noOfDays As Int16) As DataSet
        Try

            If checkuser(Username, password, 0) = False Then Return Nothing

            Dim sql As String = "select companyregistration.sysID,companyregistration.companyName,typeOfDevice,modelNumber,manufactureNumber,barCode,deviceAmount,actualMeasure from deviceregistration,companyregistration where companyregistration.sysID=AccountID AND datediff(now(),deviceregistration.regDate)>=" & noOfDays & " AND AccountID=" & accountID

            Return GenTool.DataSetData(sql)
        Catch ex As Exception
            GenTool.GrabError(ex.Message, "getCompany-webservices")
            Return Nothing
        End Try
    End Function

    <WebMethod()> _
    Public Function getCompanyDevice(ByVal Username As String, ByVal password As String, ByVal companyID As String, ByRef Min As Long, ByRef Max As Long) As DataSet
        Try

            If checkuser(Username, password, 0) = False Then Return Nothing

            Dim ds As DataSet
            Dim sql As String

            If Min = 0 OrElse Max = 0 Then
                ds = GenTool.DataSetData("select min(sysID),max(sysID) from deviceregistration where AccountID=" & Val(companyID))
                If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                    Min = Val(ds.Tables(0).Rows(0).Item(0))
                    Max = Val(ds.Tables(0).Rows(0).Item(1))
                    ds.Dispose()
                End If

                sql = "select * from deviceregistration where sysID>=1 AND sysID<=100 AND AccountID=" & Val(companyID)
            Else
                sql = "select * from deviceregistration  where sysID>=" & Min & " AND sysID<=" & Max & " AND AccountID=" & Val(companyID)
            End If

            ds = GenTool.DataSetData(sql)

            Return ds
        Catch ex As Exception
            GenTool.GrabError(ex.Message, "getCompanyDevice-webservices")
            Return Nothing
        End Try
    End Function

    <WebMethod()> _
    Public Function getDevice(ByVal Username As String, ByVal password As String, ByRef Min As Long, ByRef Max As Long) As DataSet
        Try

            If checkuser(Username, password, 0) = False Then Return Nothing

            Dim ds As DataSet
            Dim sql As String

            If Min = 0 OrElse Max = 0 Then
                ds = GenTool.DataSetData("select min(sysID),max(sysID) from deviceregistration")
                If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                    Min = Val(ds.Tables(0).Rows(0).Item(0))
                    Max = Val(ds.Tables(0).Rows(0).Item(1))
                    ds.Dispose()
                End If

                sql = "select * from deviceregistration where sysID>=1 AND sysID<=100  "
            Else
                sql = "select * from deviceregistration  where sysID>=" & Min & " AND sysID<=" & Max
            End If

            ds = GenTool.DataSetData(sql)

            Return ds
        Catch ex As Exception
            GenTool.GrabError(ex.Message, "getDevice-webservices")
            Return Nothing
        End Try
    End Function

    <WebMethod()> _
    Public Function getInvioces(ByVal Username As String, ByVal password As String, ByVal companyID As String, ByRef Min As Long, ByRef Max As Long) As DataSet
        Try

            If checkuser(Username, password, 0) = False Then Return Nothing

            Dim ds As DataSet
            Dim sql As String

            If Min = 0 OrElse Max = 0 Then
                ds = GenTool.DataSetData("select min(sysID),max(sysID) from paymentsheet where companyID=" & Val(companyID))
                If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                    Min = Val(ds.Tables(0).Rows(0).Item(0))
                    Max = Val(ds.Tables(0).Rows(0).Item(1))
                    ds.Dispose()
                End If

                sql = "select * from paymentsheet where sysID>=1 AND sysID<=100 AND companyID=" & Val(companyID)
            Else
                sql = "select * from paymentsheet  where sysID>=" & Min & " AND sysID<=" & Max & " AND companyID=" & Val(companyID)
            End If

            ds = GenTool.DataSetData(sql)

            Return ds
        Catch ex As Exception
            GenTool.GrabError(ex.Message, "getInvioces-webservices")
            Return Nothing
        End Try
    End Function

    Private Function checkuser(ByVal username As String, ByVal password As String, ByRef sysID As String) As Boolean
        Try
            If dsSystemUsers Is Nothing OrElse dsSystemUsers.Tables.Count < 1 OrElse dsSystemUsers.Tables(0).Rows.Count < 1 Then
                getSystemUsers()
            End If

            Dim sql As String = "recordstatus=0 AND username=" & GenTool.addbackslash(username) & " AND userpwd=" & GenTool.addbackslash(password)

            If Val(sysID) > 0 Then
                sql = "sysID=" & Val(sysID.Split("|".ToArray(1)))
            End If

            Dim ds As DataSet = GenTool.getFromDataset(dsSystemUsers, sql)

            If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                sysID = ds.Tables(0).Rows(0).Item(0).ToString
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            GenTool.GrabError(ex.Message, "checkuser-web service")
            Return False
        End Try

    End Function

    <WebMethod()> _
    Public Function setdevice(ByVal Username As String, ByVal password As String, ByVal ds As DataSet) As Boolean
        Return Nothing
    End Function

    <WebMethod()> _
    Public Function setTestSheet(ByVal Username As String, ByVal password As String, ByVal ds As DataSet) As Boolean
        Return Nothing
    End Function

#Region "KeyMovement"

    <WebMethod()> _
    Public Sub keyBaseMovement1(ByVal sysID As String, ByVal computername As String)
        Try
            If checkuser("", "", "|" & sysID) = False Then Return

            GenTool.FormHistory("Reloaded All Company Static Data", computername, sysID, 0)
            getCompanyStaticData()
        Catch ex As Exception
        End Try
    End Sub

    <WebMethod()> _
    Public Sub keyBaseMovement2(ByVal sysID As String, ByVal computername As String)
        Try
            If checkuser("", "", "|" & sysID) = False Then Return

            GenTool.FormHistory("Reloaded All Device Static Data", computername, sysID, 0)
            GetDeviceSection()
        Catch ex As Exception
        End Try
    End Sub

    <WebMethod()> _
    Public Sub keyBaseMovement3(ByVal sysID As String, ByVal computername As String)
        Try
            If checkuser("", "", "|" & sysID) = False Then Return
            GenTool.FormHistory("Reloaded All Fee Static Data", computername, sysID, 0)
            FeeGroup()
        Catch ex As Exception
        End Try
    End Sub

#End Region

End Class
