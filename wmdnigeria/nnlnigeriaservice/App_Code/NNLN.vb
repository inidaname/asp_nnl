Imports Microsoft.VisualBasic
Imports System.Data

Public Class NNLN
    Inherits smsXMobile.smsXMobile

    Public Function SendnMailBox(ByVal cBlast As MailContents) As Boolean
        Return SendMailDirect("mail.nnlnigeria.com", "sales@nnlnigeria.com", "nnl_2013_1234", cBlast.BodyM, cBlast.Subject, Net.Mail.DeliveryNotificationOptions.OnSuccess, Net.Mail.MailPriority.Normal, _
           cBlast.mailto, cBlast.mailfrom, cBlast.AttarchFiles, cBlast.mailbcc, cBlast.mailcc, cBlast.IsBodyHtml, cBlast.enableSSL)
    End Function

    Public Sub FormHistory(ByVal Message As String, ByVal IpAddres As String, Optional ByVal UserID As Int32 = 0, Optional ByVal companyID As Int32 = 0)
        Try
            Dim sd As String = "Insert into audit(RegDate,RegTime,UserID,companyID,Message,ipAddress) values(now(),now()," & UserID & "," & companyID & _
                "," & addbackslash(Message) & "," & addbackslash(IpAddres) & ") "
            ExecuteDatabase(sd)
        Catch ex As Exception
        End Try
    End Sub

    Public Function getWhereSQL(ByVal contrl As Control, ByRef search As String, ByVal useWilcard As Boolean) As String

        Dim xtxt As Control
        For Each xtxt In contrl.Controls
            If TypeOf xtxt Is TextBox Then
                Dim txt As TextBox = CType(xtxt, TextBox)

                If txt.ValidationGroup <> "" Then
                    Dim f() As String = txt.ValidationGroup.Split("|")

                    If search = "" Then
                        If txt.Text.Trim <> "" Then

                            If useWilcard = True Then
                                search = f(0) & " like " & addbackslash(txt.Text, , useWilcard)
                            Else
                                search = f(0) & "=" & addbackslash(txt.Text)
                            End If

                        End If
                    Else

                        If txt.Text.Trim <> "" Then
                            search &= " AND " & f(0) & "=" & addbackslash(txt.Text, , useWilcard)
                        End If
                    End If

                End If
            End If

            If TypeOf xtxt Is DropDownList Then
                Dim cbo As DropDownList = CType(xtxt, DropDownList)

                If cbo.ValidationGroup <> "" Then
                    Dim f() As String = cbo.ValidationGroup.Split("|")
                    Dim ffValues As String = cbo.Text

                    If cbo.SelectedIndex > 0 Then

                        If f.Length = 3 Then
                            ffValues = cbo.SelectedItem.Value
                        Else
                            ffValues = cbo.SelectedItem.Text
                        End If

                    End If

                    If f(0) <> "" AndAlso cbo.SelectedIndex > 0 Then

                        If search = "" Then

                            If ffValues.Trim <> "" Then
                                If useWilcard = True Then
                                    search = f(0) & " like " & addbackslash(ffValues, , useWilcard)
                                Else
                                    search = f(0) & "=" & addbackslash(ffValues)
                                End If

                            End If
                        Else

                            If ffValues.Trim <> "" Then
                                If useWilcard = True Then
                                    search &= " AND " & f(0) & " like " & addbackslash(ffValues, , useWilcard)
                                Else
                                    search &= " AND " & f(0) & "=" & addbackslash(ffValues)
                                End If

                            End If

                        End If

                    End If


                End If
            End If

        Next

        Return ""

    End Function

    Public Function checkControl(ByVal contrl As Control, ByRef FN As String, ByRef FV As String, ByRef FUpdate As String) As String

        Dim xtxt As Control
        For Each xtxt In contrl.Controls

            If TypeOf xtxt Is CheckBox Then
                Dim txt As CheckBox = CType(xtxt, CheckBox)
                If txt.Text = "" AndAlso txt.ValidationGroup <> "" Then
                    Dim f() As String = txt.ValidationGroup.Split("|")
                    If f.Length > 1 Then
                        Return f(1)
                    End If
                End If

                If txt.ValidationGroup <> "" Then
                    Dim f() As String = txt.ValidationGroup.Split("|")
                    If f(0) <> "" Then
                        If FN = "" Then
                            FN = f(0)
                            FV = IIf(txt.Checked = True, "1", "0")
                            FUpdate = FN & "=" & FV
                        Else
                            FN &= "," & f(0)
                            FV &= "," & IIf(txt.Checked = True, "1", "0")
                            FUpdate &= "," & f(0) & "=" & IIf(txt.Checked = True, "1", "0")
                        End If
                    End If
                End If
            End If


            If TypeOf xtxt Is TextBox Then
                Dim txt As TextBox = CType(xtxt, TextBox)
                If txt.Text.Trim = "" AndAlso txt.ValidationGroup <> "" Then
                    Dim f() As String = txt.ValidationGroup.Split("|")
                    If f.Length > 1 Then
                        Return f(1)
                    End If
                End If

                If txt.ValidationGroup <> "" Then
                    Dim f() As String = txt.ValidationGroup.Split("|")
                    If f(0) <> "" Then
                        If FN = "" Then
                            FN = f(0)
                            FV = addbackslash(txt.Text)
                            FUpdate = FN & "=" & FV
                        Else
                            FN &= "," & f(0)
                            FV &= "," & addbackslash(txt.Text)
                            FUpdate &= "," & f(0) & "=" & addbackslash(txt.Text)
                        End If
                    End If
                End If
            End If


            If TypeOf xtxt Is DropDownList Then
                Dim cbo As DropDownList = CType(xtxt, DropDownList)
                If cbo.SelectedIndex <= 0 Then
                    Dim f() As String = cbo.ValidationGroup.Split("|")
                    If f.Length > 1 Then
                        Return f(1)
                    End If
                End If

                If cbo.ValidationGroup <> "" Then
                    Dim f() As String = cbo.ValidationGroup.Split("|")
                    Dim ffValues As String = cbo.Text

                    If f.Length = 3 Then
                        ffValues = cbo.SelectedItem.Value
                    Else
                        ffValues = cbo.SelectedItem.Text
                    End If

                    If f(0) <> "" Then
                        If FN = "" Then
                            FN = f(0)
                            FV = addbackslash(ffValues)
                            FUpdate = FN & "=" & FV
                        Else
                            FN &= "," & f(0)
                            FV &= "," & addbackslash(ffValues)
                            FUpdate &= "," & f(0) & "=" & addbackslash(ffValues)
                        End If
                    End If

                End If
            End If

        Next

        Return ""

    End Function

    Public Sub resetFont(ByVal obj As Object, ByVal fontname As String, ByVal fontsize As Int16)
        Try
            Dim ctn As New System.Web.UI.Control

            For Each ctn In obj.Controls

                If TypeOf ctn Is System.Web.UI.WebControls.TextBox Then
                    Dim txt As TextBox = CType(ctn, TextBox)

                    If txt.ValidationGroup <> "" Then
                        txt.Font.Name = fontname
                        txt.Font.Size = fontsize
                    End If

                End If

                If TypeOf ctn Is System.Web.UI.WebControls.DropDownList Then
                    Dim cbod As DropDownList = CType(ctn, DropDownList)

                    If cbod.ValidationGroup <> "" Then
                        cbod.Font.Name = fontname
                        cbod.Font.Size = fontsize
                    End If

                End If

            Next

        Catch ex As Exception
        End Try
    End Sub

    Public Sub resetform(ByVal obj As Object, Optional ByVal ds As DataSet = Nothing)
        Try
            Dim ctn As New System.Web.UI.Control

            For Each ctn In obj.Controls

                If TypeOf ctn Is System.Web.UI.WebControls.TextBox Then
                    Dim txt As TextBox = CType(ctn, TextBox)

                    If ds IsNot Nothing Then
                        txt.Text = getValueSystem(ds, txt.ValidationGroup)
                        If txt.TextMode = TextBoxMode.Password Then
                            txt.Attributes.Add("value", txt.Text)
                        End If
                    Else
                        txt.Text = ""
                        If txt.TextMode = TextBoxMode.Password Then
                            txt.Attributes.Add("value", "")
                        End If
                    End If

                End If

                If TypeOf ctn Is System.Web.UI.WebControls.DropDownList Then
                    Dim cbod As DropDownList = CType(ctn, DropDownList)

                    If ds IsNot Nothing Then
                        cbod.SelectedIndex = getddlindexvalue(cbod, getValueSystem(ds, cbod.ValidationGroup))
                    Else

                        If cbod.Items.Count > 0 Then
                            cbod.SelectedIndex = 0
                        Else
                            cbod.Text = ""
                        End If
                    End If

                End If

                If TypeOf ctn Is System.Web.UI.WebControls.CheckBox Then
                    Dim chk As CheckBox = CType(ctn, CheckBox)

                    If ds IsNot Nothing Then
                        Dim f As String = getValueSystem(ds, chk.ValidationGroup)

                        If Val(f) > 0 Then
                            chk.Checked = True
                        Else
                            chk.Checked = False
                        End If
                    Else
                        chk.Checked = False
                    End If

                End If


            Next

        Catch ex As Exception
        End Try
    End Sub

    Public Function getFillCompany(ByVal companyID As String) As DataSet
        Return DataSetData("select companyName,streetAddress,cityID,LGAID,StateID,POBOX,companyEmail,companywebsite from companyregistration where sysID=" & Val(companyID))
    End Function

    Public Function getSummation(ByVal grd As GridView, ByVal colNumber As Int16) As String
        Dim sum As Single = 0
        Try
            For j As Long = 0 To grd.Rows.Count - 1
                sum += Val(grd.Rows(j).Cells(colNumber).Text)
            Next
        Catch ex As Exception
        End Try
        Return sum
    End Function

    Public Function getRowItemInds(ByVal ds As DataSet, ByVal rfield As String, ByVal sfield As String, ByVal svalue As String, Optional ByVal tblname As String = "") As String
        Try
            If String.IsNullOrEmpty(tblname) = True Then

                For k As Long = 0 To ds.Tables(0).Rows.Count - 1
                    With ds.Tables(0).Rows(k)
                        Dim sResult As String = .Item(sfield).ToString.Trim.ToLower
                        If sResult = svalue.Trim.ToLower Then
                            Return .Item(rfield)
                        End If
                    End With
                Next

            Else
                For k As Long = 0 To ds.Tables(tblname).Rows.Count - 1
                    With ds.Tables(tblname).Rows(k)
                        Dim sResult As String = .Item(sfield).ToString.Trim.ToLower
                        If sResult = svalue.Trim.ToLower Then
                            Return .Item(rfield)
                        End If
                    End With
                Next

            End If

            Return ""
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function getValueSystem(ByVal ds As DataSet, ByVal xms As String) As String
        Dim fValues As String = ""
        Try

            If xms <> "" Then

                Dim f() As String = xms.Split("|")
                Dim ffValues As String = ""

                Try

                    If f.Length = 3 Then

                        'If Val(f(2)) = 1 Then
                        '    fValues
                        'ElseIf Val(f(2)) = 2 Then

                        'ElseIf Val(f(2)) = 3 Then

                        'End If
                    Else
                        fValues = ds.Tables(0).Rows(0).Item(f(0))
                    End If

                Catch ex As Exception
                End Try

            End If

            Return fValues
        Catch ex As Exception
            Return fValues
        End Try
    End Function

    Public Function getDeviceType() As String
        Dim xTest As String
        xTest = "Select device type; Belt-Conveyor Scale Systems ;" & _
        "Automatic Bulk Weighing Systems;" & _
        "Weights;" & _
        "Automatic Weighing Systems;" & _
        "Liquid-Measuring Devices;" & _
        "Vehicle-Tank Meters;" & _
        "Liquefied Petroleum Gas and Anhydrous Ammonia Liquid-Measuring Devices;" & _
        "Hydrocarbon Gas Vapor-Measuring Devices;" & _
        "Cryogenic Liquid-Measuring Devices;" & _
        "Milk Meters;" & _
        "Water Meters;" & _
        "Mass Flow Meters;" & _
        "Carbon Dioxide Liquid-Measuring Devices;" & _
        "Hydrogen Gas-Measuring Devices – Tentative Code;" & _
        "Vehicle Tanks Used as Measures;" & _
        "Liquid Measures;" & _
        "Farm Milk Tanks;" & _
        "Measure-Containers;" & _
        "Graduates;" & _
        "Dry Measures;" & _
        "Berry Baskets and Boxes;" & _
        "Fabric-Measuring Devices;" & _
        "Wire- and Cordage-Measuring Devices;" & _
        "Linear Measures;" & _
        "Odometers;" & _
        "Taximeters;" & _
        "Timing Devices;" & _
        "Grain Moisture Meters;" & _
        "Near-Infrared Grain Analyzers;" & _
        "Multiple Dimension Measuring Devices"

        Return xTest
    End Function

    Public Function getDeviceType1() As String
        Dim xTest As String
        xTest = "None; Belt-Conveyor Scale Systems ;" & _
        "Automatic Bulk Weighing Systems;" & _
        "Weights;" & _
        "Automatic Weighing Systems;" & _
        "Liquid-Measuring Devices;" & _
        "Vehicle-Tank Meters;" & _
        "Liquefied Petroleum Gas and Anhydrous Ammonia Liquid-Measuring Devices;" & _
        "Hydrocarbon Gas Vapor-Measuring Devices;" & _
        "Cryogenic Liquid-Measuring Devices;" & _
        "Milk Meters;" & _
        "Water Meters;" & _
        "Mass Flow Meters;" & _
        "Carbon Dioxide Liquid-Measuring Devices;" & _
        "Hydrogen Gas-Measuring Devices – Tentative Code;" & _
        "Vehicle Tanks Used as Measures;" & _
        "Liquid Measures;" & _
        "Farm Milk Tanks;" & _
        "Measure-Containers;" & _
        "Graduates;" & _
        "Dry Measures;" & _
        "Berry Baskets and Boxes;" & _
        "Fabric-Measuring Devices;" & _
        "Wire- and Cordage-Measuring Devices;" & _
        "Linear Measures;" & _
        "Odometers;" & _
        "Taximeters;" & _
        "Timing Devices;" & _
        "Grain Moisture Meters;" & _
        "Near-Infrared Grain Analyzers;" & _
        "Multiple Dimension Measuring Devices"

        Return xTest
    End Function
End Class

Public Class MailContents
    Dim _mailto As Net.Mail.MailAddress
    Dim _mailfrom As Net.Mail.MailAddress
    Dim _mailcc As Net.Mail.MailAddress
    Dim _mailbcc As Net.Mail.MailAddress
    Dim _Subject As String
    Dim _AttarchFiles As String
    Dim _IsBodyHtml As Boolean
    Dim _Body As String
    Dim _enableSSL As Boolean

    Property enableSSL As Boolean 
        Get
            Return _enableSSL
        End Get
        Set(ByVal value As Boolean)
            _enableSSL = value
        End Set
    End Property

    Property Subject As String
        Get
            Return _Subject
        End Get
        Set(ByVal value As String)
            _Subject = value
        End Set
    End Property

    Property AttarchFiles As String
        Get
            Return _AttarchFiles
        End Get
        Set(ByVal value As String)
            _AttarchFiles = value
        End Set
    End Property

    Property BodyM As String
        Get
            Return _Body
        End Get
        Set(ByVal value As String)
            _Body = value
        End Set
    End Property


    Property mailto As Net.Mail.MailAddress
        Get
            Return _mailto
        End Get
        Set(ByVal value As Net.Mail.MailAddress)
            _mailto = value
        End Set
    End Property

    Property mailfrom As Net.Mail.MailAddress
        Get
            Return _mailfrom
        End Get
        Set(ByVal value As Net.Mail.MailAddress)
            _mailfrom = value
        End Set
    End Property

    Property mailcc As Net.Mail.MailAddress
        Get
            Return _mailcc
        End Get
        Set(ByVal value As Net.Mail.MailAddress)
            _mailcc = value
        End Set
    End Property

    Property mailbcc As Net.Mail.MailAddress
        Get
            Return _mailbcc
        End Get
        Set(ByVal value As Net.Mail.MailAddress)
            _mailbcc = value
        End Set
    End Property

    Property IsBodyHtml As Boolean
        Get
            Return _IsBodyHtml
        End Get
        Set(ByVal value As Boolean)
            _IsBodyHtml = value
        End Set
    End Property
End Class

