Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://www.nnlnigeria.com/NNLWS")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class NNLWS
    Inherits System.Web.Services.WebService

    Dim GenTool As NNLN = xsmsCentralToolx.SetTool

#Region "Main Methods"

    Dim IsAdmin As Boolean

    <WebMethod()> _
    Public Function check4sysupdate(ByVal Username As String, ByVal computername As String, ByVal isFetch As Boolean) As String
        Try

            Dim sd As String = ""

            If isFetch = True Then
                sd = "Update systemupdate set DownloadFile=1 where sysName=" & GenTool.addbackslash(computername) & " And Username=" & GenTool.addbackslash(Username)
                GenTool.ExecuteDatabase(sd)
                sd = "OK"
            Else

                sd = "select updatePath from systemupdate where sysName=" & GenTool.addbackslash(computername) & " And Username=" & GenTool.addbackslash(Username)
                If GenTool.HasRows(sd) = False Then
                    sd = "insert into systemupdate(sysName,username,DownloadFile) Values (" & GenTool.addbackslash(computername) & "," & GenTool.addbackslash(Username) & ",0)"
                    GenTool.ExecuteDatabase(sd)
                End If

                sd = "select updatePath from systemupdate where sysName=" & GenTool.addbackslash(computername) & " And Username=" & GenTool.addbackslash(Username) & " AND DownloadFile=0"
                sd = GenTool.getSingleValue(sd)

                If sd <> "" Then
                    sd = docLink & "/nnlsysupdate/NNL NIGERIA.exe"

                End If

            End If

            Return sd

        Catch ex As Exception
            GenTool.GrabError(ex.Message, "check4sysupdate")
            Return ""
        End Try
    End Function

    <WebMethod()> _
    Public Function getUser(ByVal Username As String, ByVal password As String, ByVal computername As String) As DataSet
        Try

            Dim sql As String = "Select * from systemusers where recordstatus=0 AND username=" & GenTool.addbackslash(Username) & " AND userpwd=" & GenTool.addbackslash(password)
            Dim ds As DataSet = GenTool.DataSetData(sql)

            If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                GenTool.FormHistory("Downloaded account details on " & computername, computername, Val(ds.Tables(0).Rows(0).Item("sysID").ToString), 0)
                Dim sd As String = "select sysID from systemupdate where sysName=" & GenTool.addbackslash(computername) & " And Username=" & GenTool.addbackslash(Username)
                If GenTool.HasRows(sd) = False Then
                    sd = "insert into systemupdate(DownloadFile,sysName,username) Values (0," & GenTool.addbackslash(computername) & "," & GenTool.addbackslash(Username) & ")"
                    GenTool.ExecuteDatabase(sd)
                End If
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

            If checkuser(Username, password, 0, IsAdmin) = False Then Return Nothing

            Dim sql As String

            If GenTool.HasDatasetAnyRecord(dsLcountry) = True Then
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
    Public Function getSQLUpdate(ByVal Username As String, ByVal password As String, ByVal VersionNumber As Integer) As DataSet
        Try
            If checkuser(Username, password, 0, IsAdmin) = False Then Return Nothing
            Return GenTool.DataSetData("select softwaremgt.sysID,sqlCode from softwaremgt,softwaresqlmgt where softwaremgt.Status=0 AND softwaremgt.objID=softwaresqlmgt.sysID AND Version>" & VersionNumber)
        Catch ex As Exception
            Return Nothing
            GenTool.GrabError(ex.Message, "getSQLUpdate")
        End Try
    End Function

    <WebMethod()> _
    Public Function getAplicationUpdate(ByVal Username As String, ByVal password As String, ByVal VersionNumber As Integer, ByRef Min As Long, ByRef Max As Long) As DataSet
        Try

            If checkuser(Username, password, 0, IsAdmin) = False Then Return Nothing

            Dim sql As String

            If Min = 0 OrElse Max = 0 Then
                Dim ds As DataSet = GenTool.DataSetData("select min(softwaremgt.sysID),max(softwaremgt.sysID) from softwaremgt,softwaremgtdoc where softwaremgt.Status=1 AND softwaremgt.objID=softwaremgtdoc.sysID AND Version>" & VersionNumber)
                If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                    Min = Val(ds.Tables(0).Rows(0).Item(0))
                    Max = Val(ds.Tables(0).Rows(0).Item(1))
                    ds.Dispose()
                Else
                    Min = 1
                    Max = 5
                End If

                sql = "select softwaremgt.sysID,docName from softwaremgt,softwaremgtdoc where softwaremgt.Status=1 AND softwaremgt.objID=softwaremgtdoc.sysID AND softwaremgtdoc.sysID>=1 AND softwaremgtdoc.sysID<=5 AND Version>" & VersionNumber
            Else
                sql = "select softwaremgt.sysID,docName from softwaremgt,softwaremgtdoc where softwaremgt.Status=1 AND softwaremgt.objID=softwaremgtdoc.sysID AND softwaremgtdoc.sysID>=" & Min & " AND softwaremgtdoc.sysID<=" & Max & "  AND Version>" & VersionNumber
            End If

            Dim dsk As DataSet = GenTool.DataSetData(sql)

            Return dsk
        Catch ex As Exception
            GenTool.GrabError(ex.Message, "getAplicationUpdate")
            Return Nothing
        End Try
    End Function

    <WebMethod()> _
    Public Function getFeeSubGroup(ByVal Username As String, ByVal password As String, ByRef Min As Long, ByRef Max As Long) As DataSet
        Try

            If checkuser(Username, password, 0, IsAdmin) = False Then Return Nothing

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

            If checkuser(Username, password, 0, IsAdmin) = False Then Return Nothing

            If GenTool.HasDatasetAnyRecord(dscompleteFeeTable) = True Then
                getcompleteFeeTable()
            End If

            Dim sql As String

            If Min = 0 OrElse Max = 0 Then
                With dscompleteFeeTable.Tables(0)
                    Min = Val(.Rows(0).Item("sysID").ToString)
                    Max = Val(.Rows(.Rows.Count - 1).Item("sysID").ToString)
                End With

                sql = "sysID>=1 AND sysID<=100"
            Else
                sql = "sysID>=" & Min & " AND sysID<=" & Max
            End If

            Dim ds As DataSet = GenTool.getFromDataset(dscompleteFeeTable, sql)

            Return ds
        Catch ex As Exception
            GenTool.GrabError(ex.Message, "getMainSector-webservices")
            Return Nothing
        End Try
    End Function

    <WebMethod()> _
    Public Function getMainSubDeviceData(ByVal Username As String, ByVal password As String, ByRef Min As Long, ByRef Max As Long) As DataSet
        Try

            If checkuser(Username, password, 0, IsAdmin) = False Then Return Nothing

            Dim sql As String

            If Min = 0 OrElse Max = 0 Then
                Dim ds As DataSet = GenTool.DataSetData("select min(sysID),max(sysID) from mainsubdevice")
                If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                    Min = Val(ds.Tables(0).Rows(0).Item(0))
                    Max = Val(ds.Tables(0).Rows(0).Item(1))
                    ds.Dispose()
                Else
                    Min = 1
                    Max = 100
                End If

                sql = "select * from mainsubdevice where sysID>=1 AND sysID<=100"
            Else
                sql = "select * from mainsubdevice where  sysID>=" & Min & " AND sysID<=" & Max
            End If

            Dim dsk As DataSet = GenTool.DataSetData(sql)

            Return dsk
        Catch ex As Exception
            GenTool.GrabError(ex.Message, "mainsubdevice-webservices")
            Return Nothing
        End Try
    End Function

    <WebMethod()> _
    Public Function getDeticeType(ByVal Username As String, ByVal password As String, ByRef Min As Long, ByRef Max As Long) As DataSet
        Try

            If checkuser(Username, password, 0, IsAdmin) = False Then Return Nothing

            If GenTool.HasDatasetAnyRecord(dsDeviceType) = True Then
                getDeviceType()
            End If

            Dim sql As String

            If Min = 0 OrElse Max = 0 Then
                With dsDeviceType.Tables(0)
                    Min = Val(.Rows(0).Item("sysID").ToString)
                    Max = Val(.Rows(.Rows.Count - 1).Item("sysID").ToString)
                End With

                sql = "sysID>=1 AND sysID<=100"
            Else
                sql = "sysID>=" & Min & " AND sysID<=" & Max
            End If

            Dim ds As DataSet = GenTool.getFromDataset(dsDeviceType, sql)

            Return ds
        Catch ex As Exception
            GenTool.GrabError(ex.Message, "getDeticeType-webservices")
            Return Nothing
        End Try
    End Function

    <WebMethod()> _
    Public Function getMainDeviceData(ByVal Username As String, ByVal password As String, ByRef Min As Long, ByRef Max As Long) As DataSet
        Try

            If checkuser(Username, password, 0, IsAdmin) = False Then Return Nothing

            If GenTool.HasDatasetAnyRecord(dsMainDevice) = True Then
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

            If checkuser(Username, password, 0, IsAdmin) = False Then Return Nothing

            If GenTool.HasDatasetAnyRecord(dsFeeTable) = True Then
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
    Public Function getCompany(ByVal Username As String, ByVal password As String, ByRef Min As Long, ByRef Max As Long) As DataSet
        Try

            If checkuser(Username, password, 0, IsAdmin) = False Then Return Nothing

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
    Public Function getCityData(ByVal Username As String, ByVal password As String, ByRef Min As Long, ByRef Max As Long) As DataSet
        Try

            If checkuser(Username, password, 0, IsAdmin) = False Then Return Nothing

            If GenTool.HasDatasetAnyRecord(dsCity) = True Then
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

            If checkuser(Username, password, 0, IsAdmin) = False Then Return Nothing

            If GenTool.HasDatasetAnyRecord(dsState) = True Then
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

            If checkuser(Username, password, 0, IsAdmin) = False Then Return Nothing


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

            If checkuser(Username, password, 0, IsAdmin) = False Then Return Nothing


            If GenTool.HasDatasetAnyRecord(dsLGAState) = True Then
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
    Public Function getWholeDatabaseCounter(ByVal Username As String, ByVal password As String) As Integer
        Try

            If checkuser(Username, password, 0, IsAdmin) = False Then Return Nothing

            If IsAdmin = False Then Return 0

            If WholeDB.Count = 0 Then
                WholeDB.AddRange(GenTool.GetTables(GenTool.ConnectionString, smsXMobile.smsXMobile.DataBaseTypes.MySQl_Dotet).Split(";"))
            End If

            Return WholeDB.Count

        Catch ex As Exception
            GenTool.GrabError(ex.Message, "getWholeDatabaseCounter")
            Return 0
        End Try
    End Function
    <WebMethod()> _
    Public Function getWholeDatabase(ByVal Username As String, ByVal password As String, ByRef Min As Long, ByRef Max As Long, ByVal I As Integer) As DataSet
        Try

            If checkuser(Username, password, 0, IsAdmin) = False Then Return Nothing

            If IsAdmin = False Then Return Nothing

            If I < WholeDB.Count Then Return Nothing

            Dim ds As DataSet
            Dim sql As String

            If Min = 0 OrElse Max = 0 Then
                ds = GenTool.DataSetData("select min(sysID),max(sysID) from " & WholeDB.Item(I))
                If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                    Min = Val(ds.Tables(0).Rows(0).Item(0))
                    Max = Val(ds.Tables(0).Rows(0).Item(1))
                    ds.Dispose()
                End If

                sql = "select * from " & WholeDB.Item(I) & " where sysID>=1 AND sysID<=100  "
            Else
                sql = "select * from " & WholeDB.Item(I) & "  where sysID>=" & Min & " AND sysID<=" & Max
            End If

            ds = GenTool.DataSetData(sql)

            Return ds

        Catch ex As Exception
            GenTool.GrabError(ex.Message, "Whole Database")
            Return Nothing
        End Try
    End Function

    <WebMethod()> _
    Public Function getDevice(ByVal Username As String, ByVal password As String, ByRef Min As Long, ByRef Max As Long) As DataSet
        Try

            If checkuser(Username, password, 0, IsAdmin) = False Then Return Nothing

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

    Private Function checkuser(ByVal username As String, ByVal password As String, ByRef sysID As String, ByRef IsAdmin As Boolean) As Boolean
        Try
            If GenTool.HasDatasetAnyRecord(dsSystemUsers) = True Then
                getSystemUsers()
            End If

            Dim sql As String = "recordstatus=0 AND username=" & GenTool.addbackslash(username) & " AND userpwd=" & GenTool.addbackslash(password)

            If Val(sysID) > 0 Then
                sql = "sysID=" & Val(sysID.Split("|".ToArray(1)))
            End If

            Dim ds As DataSet = GenTool.getFromDataset(dsSystemUsers, sql)

            If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                sysID = ds.Tables(0).Rows(0).Item(0).ToString
                IsAdmin = IIf(Val(ds.Tables(0).Rows(0).Item("sysadminright").ToString) = 0, False, True)
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            GenTool.GrabError(ex.Message, "checkuser-web service")
            Return False
        End Try

    End Function

#End Region

#Region "Invioces"

    <WebMethod()> _
    Public Function getDebtedCompanyX(ByVal Username As String, ByVal password As String, ByVal noOfDays As Int16) As DataSet
        Try

            If checkuser(Username, password, 0, IsAdmin) = False Then Return Nothing

            Dim sql As String = "select companyName,streetAddress,POBOX,representativeName,companyEmail,telephone,mobilephone,max(DateRenewed) as 'Last Invioce Date',datediff(now(),max(DateRenewed)) as 'Pay Due Day' from companyregistration,companyrenewal where companyregistration.sysID=companyrenewal.CompID  group by CompID having datediff(now(),max(DateRenewed))>=" & noOfDays

            Return GenTool.DataSetData(sql)
        Catch ex As Exception
            GenTool.GrabError(ex.Message, "getDebtedCompanyX-webservices")
            Return Nothing
        End Try
    End Function

    <WebMethod()> _
    Public Function getDebtedCompany(ByVal Username As String, ByVal password As String, ByVal accountID As Long, ByVal noOfDays As Int16) As DataSet
        Try
            If checkuser(Username, password, 0, IsAdmin) = False Then Return Nothing

            Dim sql As String = "select companyName,streetAddress,POBOX,representativeName,companyEmail,telephone,mobilephone,max(DateRenewed) as 'Last Invioce Date',datediff(now(),max(DateRenewed)) as 'Pay Due Day' from companyregistration,companyrenewal where companyregistration.sysID=companyrenewal.CompID And companyregistration.sysID=" & accountID & "  group by CompID having datediff(now(),max(DateRenewed))>=" & noOfDays

            Return GenTool.DataSetData(sql)
        Catch ex As Exception
            GenTool.GrabError(ex.Message, "getDebtedCompany-webservices")
            Return Nothing
        End Try
    End Function

    <WebMethod()> _
    Public Function getDebtedDevicex(ByVal Username As String, ByVal password As String, ByVal noOfDays As Int16) As DataSet
        Try

            If checkuser(Username, password, 0, IsAdmin) = False Then Return Nothing

            Dim sql As String = "select companyregistration.sysID as SN,companyregistration.CompanyName,(select DeviceType from maindevicesection where sysid=typeOfDevice limit 1) as InstrumentType,ModelNumber,ManufactureNumber as M_Number,BarCode,DeviceAmount,ActualMeasure,DeviceCurrentStatus as DeviceStatus,CertificateNo,max(DateRenewed) as 'Last Invoice Date',datediff(now(),max(DateRenewed)) as 'Time Elapsed' ,(select stateName from tblstate where sysID=deviceregistration.StateID limit 1) as State,(select LGA from tbllga where sysID=deviceregistration.LGAID limit 1) as LGA,(select city from tblcity where sysID=deviceregistration.cityID limit 1) as City from deviceregistration,companyregistration,devicerenewal where companyregistration.sysID=AccountID and devicerenewal.DeviceID=deviceregistration.sysID And companyregistration.sysID=devicerenewal.CompID group by deviceregistration.sysID having datediff(now(),max(DateRenewed))>=" & 365 - noOfDays

            Return GenTool.DataSetData(sql)
        Catch ex As Exception
            GenTool.GrabError(ex.Message, "getDebtedDevicex-webservices")
            Return Nothing
        End Try

    End Function

    <WebMethod()> _
    Public Function getDebtedDevice(ByVal Username As String, ByVal password As String, ByVal accountID As Long, ByVal noOfDays As Int16) As DataSet
        Try

            If checkuser(Username, password, 0, IsAdmin) = False Then Return Nothing

            Dim sql As String = "select companyregistration.sysID as SN,companyregistration.CompanyName,(select DeviceType from maindevicesection where sysid=typeOfDevice limit 1) as InstrumentType,ModelNumber,ManufactureNumber as M_Number,BarCode,DeviceAmount,ActualMeasure,DeviceCurrentStatus as DeviceStatus,CertificateNo,max(DateRenewed) as 'Last Invoice Date',datediff(now(),max(DateRenewed)) as 'Day Elapsed' ,(select stateName from tblstate where sysID=deviceregistration.StateID limit 1) as State,(select LGA from tbllga where sysID=deviceregistration.LGAID limit 1) as LGA,(select city from tblcity where sysID=deviceregistration.cityID limit 1) as City from deviceregistration,companyregistration,devicerenewal where companyregistration.sysID=AccountID and devicerenewal.DeviceID=deviceregistration.sysID And companyregistration.sysID=devicerenewal.CompID AND AccountID=" & accountID & " group by deviceregistration.sysID having datediff(now(),max(DateRenewed))>=" & 365 - noOfDays

            Return GenTool.DataSetData(sql)
        Catch ex As Exception
            GenTool.GrabError(ex.Message, "getDebtedDevice-webservices")
            Return Nothing
        End Try
    End Function

    <WebMethod()> _
    Public Function getInvioces(ByVal Username As String, ByVal password As String, ByVal companyID As String, ByRef Min As Long, ByRef Max As Long) As DataSet
        Try

            If checkuser(Username, password, 0, IsAdmin) = False Then Return Nothing

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

    <WebMethod()> _
    Public Function getInviocesX(ByVal Username As String, ByVal password As String, ByRef Min As Long, ByRef Max As Long) As DataSet
        Try

            If checkuser(Username, password, 0, IsAdmin) = False Then Return Nothing

            Dim ds As DataSet
            Dim sql As String

            If Min = 0 OrElse Max = 0 Then
                ds = GenTool.DataSetData("select min(sysID),max(sysID) from paymentsheet ")
                If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                    Min = Val(ds.Tables(0).Rows(0).Item(0))
                    Max = Val(ds.Tables(0).Rows(0).Item(1))
                    ds.Dispose()
                End If

                sql = "select * from paymentsheet where sysID>=1 AND sysID<=100 "
            Else
                sql = "select * from paymentsheet  where sysID>=" & Min & " AND sysID<=" & Max
            End If

            ds = GenTool.DataSetData(sql)

            Return ds
        Catch ex As Exception
            GenTool.GrabError(ex.Message, "getInviocesX-webservices")
            Return Nothing
        End Try
    End Function

#End Region

#Region "Upload data Methods"

    <WebMethod()> _
    Public Function setdevice(ByVal Username As String, ByVal password As String, ByVal ds As DataSet) As String
        Return GenTool.saveDs2DB(ds, "deviceregistration", "TransCode", "sysID", True)
    End Function

    <WebMethod()> _
    Public Function setTestSheet(ByVal Username As String, ByVal password As String, ByVal ds As DataSet, ByVal computerNameID As String) As String
        Return GenTool.saveDs2DB(ds, computerNameID, "TransCode", "sysID", False)
    End Function

#End Region

#Region "KeyMovement"

    <WebMethod()> _
    Public Sub keyBaseMovement1(ByVal sysID As String, ByVal computername As String)
        Try
            If checkuser("", "", "|" & sysID, IsAdmin) = False Then Return

            GenTool.FormHistory("Reloaded All Company Static Data", computername, sysID, 0)
            AllStaticDate()
        Catch ex As Exception
        End Try
    End Sub

    <WebMethod()> _
    Public Sub keyBaseMovement2(ByVal sysID As String, ByVal computername As String)
        Try
            If checkuser("", "", "|" & sysID, IsAdmin) = False Then Return

            GenTool.FormHistory("Reloaded Device", computername, sysID, 0)
            GetDeviceSection()
        Catch ex As Exception
        End Try
    End Sub

    <WebMethod()> _
    Public Sub keyBaseMovement3(ByVal sysID As String, ByVal computername As String)
        Try
            If checkuser("", "", "|" & sysID, IsAdmin) = False Then Return
            GenTool.FormHistory("Reloaded Fee group", computername, sysID, 0)
            FeeGroup()
        Catch ex As Exception
        End Try
    End Sub

    <WebMethod()> _
    Public Sub keyBaseMovement4(ByVal sysID As String, ByVal computername As String)
        Try
            If checkuser("", "", "|" & sysID, IsAdmin) = False Then Return
            GenTool.FormHistory("Reloaded Frontpage", computername, sysID, 0)
            SetupFrontpage()
        Catch ex As Exception
        End Try
    End Sub

    <WebMethod()> _
    Public Sub keyBaseMovement5(ByVal sysID As String, ByVal computername As String)
        Try
            If checkuser("", "", "|" & sysID, IsAdmin) = False Then Return
            GenTool.FormHistory("Reloaded All Addresses", computername, sysID, 0)
            SetupAddress()
        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region "ISP Method"

    <WebMethod()> _
    Public Function getISPCompany(ByVal Username As String, ByVal password As String, ByVal ISPID As Integer, ByRef Min As Long, ByRef Max As Long) As DataSet
        Try

            If checkuser(Username, password, 0, IsAdmin) = False Then Return Nothing

            Dim ds As DataSet
            Dim sql As String
            Dim sql1 As String

            If Min = 0 OrElse Max = 0 Then

                If IsAdmin = True Then
                    sql1 = "select min(sysID),max(sysID) from companyregistration"
                Else
                    sql1 = "select min(companyregistration.sysID),max(companyregistration.sysID) from companyregistration,allocatedterminals where allocatedterminals.CompID=companyregistration.sysID AND allocatedterminals.ISPID=" & ISPID
                End If

                ds = GenTool.DataSetData(sql1)
                If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                    Min = Val(ds.Tables(0).Rows(0).Item(0))
                    Max = Val(ds.Tables(0).Rows(0).Item(1))
                    ds.Dispose()
                End If

                If IsAdmin = True Then
                    sql = "select  companyregistration.sysID, username, pwd, companyName, streetAddress, cityID, LGAID, StateID, POBOX, companyEmail, companywebsite, representativeName, telephone, mobilephone, faxNumber, filledBy, filledByTitle, filledBytelephone, filledByemail, DATE_FORMAT(RegDate, '%Y-%m-%d') as RegDate,DATE_FORMAT(RegTime, '%h:%i:%S') as RegTime, DATE_FORMAT(regDateModify, '%Y-%m-%d') as regDateModify, securityQuestions, securityAnswer, recordStatus, paid4Registration, companyregtype, transcode, companyregistration.RCNumber, totalDeposit from  companyregistration where  companyregistration.sysID>=1 AND companyregistration.sysID<=100 "
                Else
                    sql = " select  companyregistration.sysID, username, pwd, companyName, streetAddress, cityID, LGAID, StateID, POBOX, companyEmail, companywebsite, representativeName, telephone, mobilephone, faxNumber, filledBy, filledByTitle, filledBytelephone, filledByemail, DATE_FORMAT(RegDate, '%Y-%m-%d') as RegDate,DATE_FORMAT(RegTime, '%h:%i:%S') as RegTime, DATE_FORMAT(regDateModify, '%Y-%m-%d') as regDateModify, securityQuestions, securityAnswer, recordStatus, paid4Registration, companyregtype, transcode, companyregistration.RCNumber, totalDeposit from  companyregistration,allocatedterminals where allocatedterminals.CompID=companyregistration.sysID AND companyregistration.sysID>=1 AND companyregistration.sysID<=100 AND allocatedterminals.ISPID=" & ISPID
                End If

            Else

                If IsAdmin = True Then
                    sql = " select  companyregistration.sysID, username, pwd, companyName, streetAddress, cityID, LGAID, StateID, POBOX, companyEmail, companywebsite, representativeName, telephone, mobilephone, faxNumber, filledBy, filledByTitle, filledBytelephone, filledByemail, DATE_FORMAT(RegDate, '%Y-%m-%d') as RegDate,DATE_FORMAT(RegTime, '%h:%i:%S') as RegTime, DATE_FORMAT(regDateModify, '%Y-%m-%d') as regDateModify, securityQuestions, securityAnswer, recordStatus, paid4Registration, companyregtype, transcode, companyregistration.RCNumber, totalDeposit from  companyregistration where companyregistration.sysID>=" & Min & " AND companyregistration.sysID<=" & Max
                Else
                    sql = " select  companyregistration.sysID, username, pwd, companyName, streetAddress, cityID, LGAID, StateID, POBOX, companyEmail, companywebsite, representativeName, telephone, mobilephone, faxNumber, filledBy, filledByTitle, filledBytelephone, filledByemail, DATE_FORMAT(RegDate, '%Y-%m-%d') as RegDate,DATE_FORMAT(RegTime, '%h:%i:%S') as RegTime, DATE_FORMAT(regDateModify, '%Y-%m-%d') as regDateModify, securityQuestions, securityAnswer, recordStatus, paid4Registration, companyregtype, transcode, companyregistration.RCNumber, totalDeposit from  companyregistration,allocatedterminals where allocatedterminals.CompID=companyregistration.sysID  AND companyregistration.sysID>=" & Min & " AND companyregistration.sysID<=" & Max & " AND allocatedterminals.ISPID=" & ISPID
                End If

            End If

            ds = GenTool.DataSetData(sql)

            Return ds
        Catch ex As Exception
            GenTool.GrabError(ex.Message, "getISPCompany-webservices")
            Return Nothing
        End Try

    End Function

    <WebMethod()> _
    Public Function getCompanyDevice(ByVal Username As String, ByVal password As String, ByVal companyID As String, ByRef Min As Long, ByRef Max As Long) As DataSet
        Try

            If checkuser(Username, password, 0, IsAdmin) = False Then Return Nothing

            Dim ds As DataSet
            Dim sql As String

            If Min = 0 OrElse Max = 0 Then
                ds = GenTool.DataSetData("select min(sysID),max(sysID) from deviceregistration where AccountID=" & Val(companyID))
                If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                    Min = Val(ds.Tables(0).Rows(0).Item(0))
                    Max = Val(ds.Tables(0).Rows(0).Item(1))
                    ds.Dispose()
                End If

                sql = "select * from deviceregistration where sysID>=" & Min & " AND sysID<=" & Min + 100 & " AND AccountID=" & Val(companyID)
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
    Public Function getAllocatedLots(ByVal Username As String, ByVal password As String, ByVal companyID As String, ByRef Min As Long, ByRef Max As Long) As DataSet
        Try

            If checkuser(Username, password, 0, IsAdmin) = False Then Return Nothing

            Dim ds As DataSet
            Dim sql As String

            If Min = 0 OrElse Max = 0 Then
                ds = GenTool.DataSetData("select min(sysID),max(sysID) from allocatedlots where CompID=" & Val(companyID))
                If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                    Min = Val(ds.Tables(0).Rows(0).Item(0))
                    Max = Val(ds.Tables(0).Rows(0).Item(1))
                    ds.Dispose()
                End If

                sql = "select * from allocatedlots where sysID>=1 AND sysID<=100 AND CompID=" & Val(companyID)
            Else
                sql = "select * from allocatedlots  where sysID>=" & Min & " AND sysID<=" & Max & " AND CompID=" & Val(companyID)
            End If

            ds = GenTool.DataSetData(sql)

            Return ds
        Catch ex As Exception
            GenTool.GrabError(ex.Message, "getAllocatedLots-webservices")
            Return Nothing
        End Try
    End Function

    <WebMethod()> _
    Public Function getAllocatedTerminals(ByVal Username As String, ByVal password As String, ByVal companyID As String, ByRef Min As Long, ByRef Max As Long) As DataSet
        Try

            If checkuser(Username, password, 0, IsAdmin) = False Then Return Nothing

            Dim ds As DataSet
            Dim sql As String

            If Min = 0 OrElse Max = 0 Then
                ds = GenTool.DataSetData("select min(sysID),max(sysID) from allocatedterminals where CompID=" & Val(companyID))
                If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                    Min = Val(ds.Tables(0).Rows(0).Item(0))
                    Max = Val(ds.Tables(0).Rows(0).Item(1))
                    ds.Dispose()
                End If

                sql = "select * from allocatedterminals where sysID>=1 AND sysID<=100 AND CompID=" & Val(companyID)
            Else
                sql = "select * from allocatedterminals  where sysID>=" & Min & " AND sysID<=" & Max & " AND CompID=" & Val(companyID)
            End If

            ds = GenTool.DataSetData(sql)
            addFile(ds)

            Return ds
        Catch ex As Exception
            GenTool.GrabError(ex.Message, "getAllocatedLots-webservices")
            Return Nothing
        End Try
    End Function

    Private Sub addFile(ByRef ds As DataSet)
        Try
            For k As Integer = 0 To ds.Tables(0).Rows.Count - 1
                With ds.Tables(0).Rows(k)
                    .BeginEdit()
                    Dim fs As String = .Item("fabilityDBFilename").ToString
                    fs = GenTool.Base64Encode(fs, fs)
                    .Item("facilityDBSource") = fs
                    .Item("fabilityDBFilename") = .Item("fabilityDBFilename").ToString.Replace("\", "\\")
                    .AcceptChanges()
                End With
            Next

        Catch ex As Exception
        End Try
    End Sub

#End Region

End Class
