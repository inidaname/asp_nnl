Imports Microsoft.VisualBasic
Imports System.Data

Public Module dataGlobe

    Public dsCity As New DataSet
    Public dsState As New DataSet
    Public dsLGAState As New DataSet
    Public dsLcountry As New DataSet
    Public dsScaleGroup As New DataSet
    Public dsScaleGroupService As New DataSet

    Public dscompleteFeeTable As New DataSet

    Public WholeDB As New ArrayList

    Public dsSubGroup As New DataSet
    Public dsSubGroupService As New DataSet

    Public dsFeeTable As New DataSet
    Public dsFeeTableAll As New DataSet
    Public dsSystemSetup As New DataSet

    Public dsMainDevice As New DataSet
    Public dsMainSubDevice As New DataSet
    Public dsUserAccount As New DataSet

    Public dsDeviceType As New DataSet
    Public dsLotName As New DataSet
    Public dsFrontPageSetup As New DataSet
    Public dsFrontPageSetup1 As New DataSet

    Public dsfrontpagemain As New DataSet
    Public dsfrontpagemainFs4 As New DataSet

    Public dsSystemUsers As New DataSet

    Dim GenTool As smsXMobile.smsXMobile = xsmsCentralToolx.SetTool

    Public sysDBUser As systemDBUsers

    'Public docLink As String = "http://localhost/nnlnigeria/"
    'Public pathdoclink As String = "C:\inetpub\wwwroot\NNLNIGERIA\nnlnigeria\"

    Public docLink As String = "https://www.nnlnigeria.com/"
    Public pathdoclink As String = "C:\inetpub\wwwroot\"

#Region "LinkingMethod"

    Public Sub SetupFrontpage()
        getSystemSetup()
        getFrontPageSetup()
        getFrontPageSetup1()
        getLotName()
        getFrontPagemain()
    End Sub

    Public Sub SetupAddress()
        getCity()
        getState()
        getLGA()
        getCountry()
    End Sub

    Public Sub AllStaticDate()
        SetupFrontpage()
        SetupAddress()
        GetDeviceSection()
        FeeGroup()
    End Sub

    Public Sub GetDeviceSection()
        getMainDevice()
        getMainSubDevice()
        getSystemUsers()
        getDeviceType()
    End Sub

    Public Sub FeeGroup()
        getScaleGroup()
        getsubGroup()
        getFeeTable()
    End Sub

#End Region

#Region "DeviceRegistration"

    Public Sub getFrontPagemain()
        dsfrontpagemain = GenTool.DataSetData("select sysID,HeaderName,BriefMsg,FullMessage,sysImageName from frontpagemain where Status=1 order by sysID asc")
    End Sub

    Public Sub getMainSubDevice()
        Try
            Dim mDs As New DataSet
            Dim ds As DataSet = GenTool.DataSetData("select sysID from maindevice order by sysID")
            If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then

                For k As Int32 = 0 To ds.Tables(0).Rows.Count - 1
                    With ds.Tables(0).Rows(k)
                        If k <= ds.Tables(0).Rows.Count - 1 Then mDs.Tables.Add(.Item(0))
                        GenTool.daFill(mDs, "select DeviceName,sysID from mainsubdevice where GroupID=" & Val(.Item(0)), k)
                    End With
                Next

                dsMainSubDevice = mDs
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub getFrontPageSetup()
        Try
            dsFrontPageSetup = GenTool.DataSetData("select sysID,HeaderName,BodyMessage,HeaderCode from frontpagesetup where recordStatus=1")
        Catch ex As Exception
        End Try
    End Sub

    Public Sub getFrontPageSetup1()
        Try
            dsFrontPageSetup1 = GenTool.DataSetData("select FilePath,DisplayName from frontpagesetup1 where Status=1")
        Catch ex As Exception
        End Try
    End Sub

    Public Sub getLotName()
        Try
            dsLotName = GenTool.DataSetData("select * from allocatedlots")
        Catch ex As Exception
        End Try
    End Sub

    Public Sub getDeviceType()
        Try
            dsDeviceType = GenTool.DataSetData("select * from maindevicesection")
        Catch ex As Exception
        End Try
    End Sub

    Public Function getCompany() As DataSet
        Return GenTool.DataSetData("select concat(sysID,'|',companyEmail,'|',recordStatus) as sysID,companyName from companyregistration")
    End Function

    Public Sub getMainDevice()
        Try
            Dim ds As DataSet = GenTool.DataSetData("select DeviceCategory,sysID from maindevice order by DeviceCategory")
            If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                dsMainDevice = ds
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub getSystemSetup()
        Try
            Dim ds As DataSet = GenTool.DataSetData("select * from systemsetup")
            If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                dsSystemSetup = ds
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub getCountry()
        Try
            Dim ds As DataSet = GenTool.DataSetData("select country,sysID from tblcountry order by country")
            If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                dsLcountry = ds
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub getcompleteFeeTable()
        Try
            Dim ds As DataSet = GenTool.DataSetData("select ucase(HeaderName) as HeaderName,sysID,IsService from feegroup where recordStatus=0")
            If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                dscompleteFeeTable = ds
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub getScaleGroupService()
        Try
            Dim ds As DataSet = GenTool.DataSetData("select ucase(HeaderName) as HeaderName,sysID,IsService from feegroup where recordStatus=0 AND IsService=1 ")
            If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                dsScaleGroupService = ds
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub getScaleGroup()
        Try
            Dim ds As DataSet = GenTool.DataSetData("select ucase(HeaderName) as HeaderName,sysID,IsService from feegroup where recordStatus=0 AND IsService=0 ")
            If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                dsScaleGroup = ds
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub getGroupService()
        Try
            Dim mDs As New DataSet
            Dim ds As DataSet = GenTool.DataSetData("select sysID from feegroup where recordStatus=0 AND IsService=1")
            If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then

                For k As Int32 = 0 To ds.Tables(0).Rows.Count - 1
                    With ds.Tables(0).Rows(k)
                        If k <= ds.Tables(0).Rows.Count - 1 Then mDs.Tables.Add(.Item(0))
                        GenTool.daFill(mDs, "select ucase(subheading) as subheading,sysID from feesubgroup where recordStatus=0 AND feegroupID=" & Val(.Item(0)), k)
                    End With
                Next

                dsSubGroupService = mDs
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub getsubGroup()
        Try
            Dim mDs As New DataSet
            Dim ds As DataSet = GenTool.DataSetData("select sysID from feegroup where recordStatus=0 AND IsService=0")
            If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then

                For k As Int32 = 0 To ds.Tables(0).Rows.Count - 1
                    With ds.Tables(0).Rows(k)
                        If k <= ds.Tables(0).Rows.Count - 1 Then mDs.Tables.Add(.Item(0))
                        GenTool.daFill(mDs, "select ucase(subheading) as subheading,sysID from feesubgroup where recordStatus=0 AND feegroupID=" & Val(.Item(0)), k)
                    End With
                Next

                dsSubGroup = mDs
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub getFeeTable()
        Try
            dsFeeTableAll = GenTool.DataSetData("select measureRange,sysID,amount,feeSubGroupID,feeGroupID from feetable")
        Catch ex As Exception
        End Try

        Try
            Dim mDs As New DataSet
            Dim ds As DataSet = GenTool.DataSetData("select sysID,feegroupID from feesubgroup where feesubgroup.recordStatus=0 ")
            If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then

                For k As Int32 = 0 To ds.Tables(0).Rows.Count - 1
                    With ds.Tables(0).Rows(k)
                        If k <= ds.Tables(0).Rows.Count - 1 Then mDs.Tables.Add(.Item(0))
                        GenTool.daFill(mDs, "select measureRange,sysID,amount,feeSubGroupID,feeGroupID from feetable where feegroupID=" & Val(.Item(1)) & " AND feeSubGroupID=" & Val(.Item(0)) & "  order by measureRange", k)
                    End With
                Next

                dsFeeTable = mDs
            End If

        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region "Registration"

    Public Sub getSystemUsers()
        Try
            Dim ds As DataSet = GenTool.DataSetData("select * from systemusers where recordstatus=0")
            If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                dsSystemUsers = ds
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub getCity()
        Try
            Dim ds As DataSet = GenTool.DataSetData("select city,sysID from tblcity  order by city")
            If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                dsCity = ds
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub getState()
        Try
            Dim ds As DataSet = GenTool.DataSetData("select stateName,sysID from tblstate order by stateName")
            If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                dsState = ds
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub getLGA()
        Try
            Dim mDs As New DataSet
            Dim ds As DataSet = GenTool.DataSetData("select sysID,stateName from tblstate order by stateName")
            If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then

                For k As Int32 = 0 To ds.Tables(0).Rows.Count - 1
                    With ds.Tables(0).Rows(k)
                        If k <= ds.Tables(0).Rows.Count - 1 Then mDs.Tables.Add(.Item(1))
                        GenTool.daFill(mDs, "select LGA,sysID,stateID from tbllga where stateID=" & .Item(0) & "  order by LGA", k)

                    End With
                Next

                dsLGAState = mDs
            End If
        Catch ex As Exception
        End Try

    End Sub

#End Region

#Region "ExtraCode"


    Public Sub setDropDownWidth(ByVal bc As HttpBrowserCapabilities, ByVal witd1 As Int32, ByVal witd2 As Int32, ByRef ctrl As DropDownList)
        Try
            If bc.Browser.ToLower = "ie" OrElse bc.Browser.ToLower = "chrome" Then
                ctrl.Width = witd1
            ElseIf bc.Browser.ToLower = "safari" OrElse bc.Browser.ToLower = "firefox" Then
                ctrl.Width = witd2
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub setTextBoxWidth(ByVal bc As HttpBrowserCapabilities, ByVal witd1 As Int32, ByVal witd2 As Int32, ByRef ctrl As TextBox)
        Try
            If bc.Browser.ToLower = "ie" OrElse bc.Browser.ToLower = "chrome" OrElse bc.Browser.ToLower = "firefox" Then
                ctrl.Width = witd1
            ElseIf bc.Browser.ToLower = "safari" Then
                ctrl.Width = witd2
            End If
        Catch ex As Exception
        End Try
    End Sub

#End Region


End Module

