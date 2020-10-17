Imports System.IO
Imports System.Net
Imports System.Xml
Imports System.Web
Imports System.Data
Imports System.Text
Imports System.Net.Mail
Imports System.Web.Security
Imports System.Globalization
Imports System.Configuration
Imports MySql.Data.MySqlClient
Imports System.Collections.Generic
Imports System.Security.Cryptography
Imports System.Web.Script.Serialization


Public Class _default7
    Inherits System.Web.UI.Page

    Dim OneYear As Integer = 365

    Dim SevenDaysReminder As Integer = 7
    Dim OneMonthReminder As Integer = 30
    Dim ThreeMonthsReminder As Integer = 90

    Dim YearCounter As Integer
    Dim RenewalYear = Today.Year
    Dim TodaysDate = Date.Today.ToString("d-MM-yyyy")
    Dim CompanyID, InstrumentDate, InstrumentSerialNo, InstrumentReferenceNo, RegisterCompanyAddress, UserNameOfCompany, UserEmail, ReferenceNumber, Sector, Instrument, InstrumentType, ModelName, SerialNo, MeasurementRang, ActualMeasure, TotalAmount, CompanyPhoneNumber, FillerPhoneNumber, UserNameUsername As String
    Dim DateDifference
    Dim SMSPhoneNumbers As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.AppendHeader("Refresh", "5;url=./")

        'Check for device that has reach its renewal time
        Try
            ConnectDatabase()
            Dim db As String = "SELECT * FROM deviceregistration"
            Using cn As MySqlCommand = New MySqlCommand(db, conn)
                Using da As New MySqlDataAdapter(cn)
                    Dim ds As New DataSet()
                    da.Fill(ds, "deviceregistration")
                    'Loop through all the registered instrument to check if its due for annual renewal
                    For Each Row As DataRow In ds.Tables(0).Rows

                        CompanyID = Row("companyID")
                        InstrumentDate = Row("registrationDate")
                        TodaysDate = Date.Today.ToString("d-MM-yyyy")
                        InstrumentSerialNo = Row("serialNumber")
                        InstrumentReferenceNo = Row("transCode")
                        RegisterCompanyAddress = Row("companyAddress")
                        UserNameOfCompany = Row("companyName")

                        UserEmail = Row("companyEmail")
                        ReferenceNumber = Row("transCode")
                        Sector = Row("sector")
                        Instrument = Row("instrumentCategory")
                        InstrumentType = Row("deviceType")
                        ModelName = Row("deviceModelName")
                        SerialNo = Row("serialNumber")
                        MeasurementRang = Row("measurementRange")
                        ActualMeasure = Row("actualMeasure")
                        TotalAmount = Row("deviceAmount")
                        YearCounter = Row("yearCounter")

                        Session.Add("InstrumentName", ModelName)
                        Session.Add("InstrumentSerialNumber", InstrumentSerialNo)

                        Dim dbc As String = "SELECT * FROM company WHERE ID='" & CompanyID & "'"
                        Using cnc As MySqlCommand = New MySqlCommand(dbc, conn)
                            Using dac As New MySqlDataAdapter(cnc)
                                Dim dsc As New DataSet()
                                dac.Fill(dsc, "company")
                                'Loop through all the registered instrument to check if its due for annual renewal
                                CompanyPhoneNumber = dsc.Tables(0).Rows(0).Item("companyPhoneNumber").ToString
                                FillerPhoneNumber = dsc.Tables(0).Rows(0).Item("filledByMobile").ToString
                                UserNameUsername = dsc.Tables(0).Rows(0).Item("username").ToString
                            End Using
                        End Using

                        'Check for difference between the Current Date and Instrument Registration Date

                        DateDifference = Date.ParseExact(TodaysDate, "d-MM-yyyy", Nothing) - Date.ParseExact(InstrumentDate, "d-MM-yyyy", Nothing)
                        DateDifference = DateDifference.ToString.Replace(".00:00:00", "")
                         'One month before the expiration day
                        If DateDifference.ToString = OneYear * YearCounter - OneMonthReminder Then

                            GetExpiredInstrument()

                            'Seven days before the expiration day
                        ElseIf DateDifference.ToString = OneYear * YearCounter - SevenDaysReminder Then

                            GetExpiredInstrument()

                            'One month before the expiration day
                        ElseIf DateDifference.ToString = OneYear * YearCounter Then

                            GetExpiredInstrument()
                            UpdateInstumentYearCount()

                            'Seven days after the expiration day
                        ElseIf DateDifference.ToString = OneYear * YearCounter + SevenDaysReminder Then
                            'Send reminder message
                            CheckRenewalStatus()
                            If CheckRenewalStatus().ToString = 0 Then
                                SendAnualLicensingRenewalMessage()
                            Else
                                MessageBox.Show(Me, "The User have paid for the Instrument")
                            End If

                            'One Month after the expiration day
                        ElseIf DateDifference.ToString = OneYear * YearCounter + SevenDaysReminder Then
                            CheckRenewalStatus()
                            If CheckRenewalStatus().ToString = 0 Then
                                SendAnualLicensingRenewalMessage()
                            Else
                                MessageBox.Show(Me, "The User have paid for the Instrument")
                            End If

                            '//
                        End If

                    Next
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)

        Finally
            DisconnectDatabase()
        End Try

    End Sub


    Public Sub GetExpiredInstrument()
        Try
            ConnectDatabase()
            Dim InvoiceCompanyName = UserNameOfCompany
            Dim InvoiceUsername = UserNameUsername
            Dim CompanyAddress = RegisterCompanyAddress
            Dim Amount = FormatNumber(TotalAmount, 2, TriState.False, , TriState.True)
            Dim Total = FormatNumber(TotalAmount, 2, TriState.False, , TriState.True)
            Dim Purpose = "Annual Licensing Renewal Fee" & Session("InstrumentName") & " with Nerial Number:" & Session("InstrumentSerialNumber")
            Dim Narration = "Annual Licensing Renewal Bill for " & Session("InstrumentName") & " with Nerial Number:" & Session("InstrumentSerialNumber")
            Dim PaymentFor = Purpose
            Dim SMSPhoneNumber = CompanyPhoneNumber & "," & FillerPhoneNumber

            Dim MyAdapter As New MySqlDataAdapter
            Dim SqlQuery = "SELECT * FROM devicerenewal WHERE deviceReference='" & ReferenceNumber & "' AND renewalYear='" & RenewalYear & "'"
            Dim Command As New MySqlCommand
            Command.Connection = conn
            Command.CommandText = SqlQuery
            MyAdapter.SelectCommand = Command
            Dim reader As MySqlDataReader
            reader = Command.ExecuteReader
            'Check if the User has apply for export permit before
            If reader.HasRows = 0 Then
                reader.Close()

                Dim TodayDate As Date = DateTime.Now
                Dim DateFormat As String = "dd-MM-yyyy"
                Dim TodayDates = TodayDate.ToString(DateFormat.ToString)

                Dim compa As New MySqlCommand
                compa.Connection = conn
                compa.CommandText = "INSERT INTO devicerenewal (companyID,dateRenewed,deviceReference,renewalYear) VALUE ('" & CompanyID & "','" & TodayDates & "','" & ReferenceNumber & "','" & RenewalYear & "')"
                compa.ExecuteNonQuery()

                Dim comp As New MySqlCommand
                comp.Connection = conn
                comp.CommandText = "INSERT INTO payment (companyID,companyName,transCode,amountDue,invoiceDate,invoiceTime,narration,paymentFor) VALUE ('" & CompanyID & "','" & UserNameOfCompany & "','" & ReferenceNumber & "','" & TotalAmount & "','" & TodayDates & "','" & CurrentTim() & "', '" & Narration & "','" & PaymentFor & "')"
                comp.ExecuteNonQuery()

                If DateDifference.ToString = OneYear * YearCounter - OneMonthReminder Then
                    'Send SMS Message
                    tools.SendSMS(Me, GetSMSAPI(), GetSMSUsername(), GetSMSPassword(), BulkSMSDefaultSender(), SMSPhoneNumber, OneMonthAnnualLicensingRenewalReminderMessage())
                    'Seven days before the expiration day
                ElseIf DateDifference.ToString = OneYear * YearCounter - SevenDaysReminder Then
                    'Send SMS Message
                    tools.SendSMS(Me, GetSMSAPI(), GetSMSUsername(), GetSMSPassword(), BulkSMSDefaultSender(), SMSPhoneNumber, OneWeekAnnualLicensingRenewalReminderMessage())
                    'One year expiration day
                ElseIf DateDifference.ToString = OneYear * YearCounter Then
                    'Send SMS Message
                    tools.SendSMS(Me, GetSMSAPI(), GetSMSUsername(), GetSMSPassword(), BulkSMSDefaultSender(), SMSPhoneNumber, AnnualLicensingRenewalReminderMessage())
                End If

                'Send email to user after registration
                Dim Message = "<div style='width:620px;font-size:15px;background:rgb(255,255, 255);'><div style='padding-left:10px; width:590px;'><h4 style='padding:10px 0px;font-size:23px;width:100%;text-align:center;margin-top:-10px;'>Annual Licensing Renewal Bill</span></h4> <h4 style='padding:10px 0px;font-size:17px;'><span style='float:right;font-size:13px;'>" + Date.Now + " </span></h4><div style='margin-bottom:10px;display:block;height:169px; width:100%;'><div style='width:45%;float:left;'><div style='font-weight:bolder;font-size:17px;padding:5px 0px;'>CLIENT DETAIL</div><p style='font-weight:bolder;font-size:15px;'>" + InvoiceCompanyName + " (" + InvoiceUsername + ")  </p><p style='font-weight:bolder;font-size:15px;'>" + CompanyAddress + "</p></div><div style='width:45%;float:right;'><div style='font-weight:bolder;font-size:17px;padding:5px 0px;'>ACCOUNT DETAIL</div><p style='font-weight:bolder;font-size:13px;'>ACCOUNT NAME: <span style='font-weight:normal;'>FEDERAL MINISTRY OF INDUSTRY, TRADE AND INVESTMENT WEIGHTS AND MEASURES DEPARTMENT</span></p><p style='font-weight:bolder;font-size:13px;'>ACCOUNT NUMBER: <span style='font-weight:normal;'>1750013688</span></p><p style='font-weight:bolder;font-size:13px;'>BANK NAME: <span style='font-weight:normal;'>SKYE BANK</span></p></div></div><div style='font-weight:bolder;font-size:17px;padding:5px 0px;'>INVOICE ITEM(S)</div><div style='width:69%;display:inline-block;font-weight:bolder;padding:10px 0px;border-bottom:1px solid rgb(200,200,200);color:rgb(100,100,100);'>Summary</div><div style='width:30%;display:inline-block;text-align:right;font-weight:bolder;padding:10px 0px;0px;border-bottom:1px solid rgb(200,200,200);color:rgb(100,100,100);'>Amount</div><div style='width:69%;display:inline-block;padding:10px 0px;'>" + Purpose + "</div><div style='width:30%;display:inline-block;text-align:right;padding:10px 0px;'>" + Amount + "</div><div style='width:100%;display:inline-block;padding:20px 0px;margin-left:-10px;padding-right:1px;text-align:right;font-weight:bolder;background:rgb(250,250,250);font-size:17px;'>Total: <span style='float:right;margin-left:50px;margin-right:0px;'>N" + Total + "</span></div></div><p><div style='margin-top:0px;width:600px;height:auto;padding:10px;color:rgb(20,20,20);text-align:left;font-size:13px;background:rgb(255,255,255);'><strong>PLEASE NOTE: </strong> <P>ALL BANK DEPOSIT MUST BE MADE WITH THE USERNAME NAME AS THE DEPOSITOR.<P>ALL PAYMENT(S) MADE ARE NON-REFUNDABLE.</div><p><a href='http://www.wmdnigeria.com/' style='text-decoration:none;width:auto;color:rgb(255,255,255);'><div style='margin-bottom:10px;padding: 5px 10px;width:100px;font-size: 14px;font-weight: bolder;line-height: 20px;text-align: center;cursor: pointer;border: 1px solid transparent;border-radius: 4px;background:rgb(54,127,169);color:rgb(255, 255, 255);'>Login Now</div> </div>"
                Dim Subject = "Reminder: Annual Licensing Renewal Bill"
                Dim MessageBody = "<html><head></head><body style='font-family:Tahoma; width:620px;font-size:13px;background:rgb(240,240, 240)'><div style='width:600px;height:70px;padding:10px;color:rgb(255, 255, 255);font-weight:bolder;text-align:center;font-size:20px;background:rgb(54,127,169);'><img src='http://www.wmdnigeria.com/images/icon.png' width='70px' height='70px' align='left' style='margin-top:-10px;padding:0px;' /><p>Federal Ministry of Industry Trade and Investment <br><span style='font-size:17px;'>Weights and Measures Department</span></div><div style='width:600px;font-size:13px;color:rgb(100,100,100);'><p> <div style='padding-left:10px; width:590px;'> <div style='font-weight:bolder;font-size:17px;'></div><p>" & Message & "</div></div> </div>           <p><div style='margin-top:100px;width:600px;height:auto;padding:10px;color:rgb(255, 255, 255);text-align:center;font-size:13px;background:rgb(54,127,169);'><strong>NOTICE: </strong>  The content of this e-mail is intended solely for the use of the individual or entity to whom it is addressed. If you have received this communication in error, beware that forwarding it, copying it or in any way disclosing its content to any other person or persons, is strictly prohibiting. If you have received this communication in error, please notify the author by replying this e-mail immediately.</div></body></html>"
                clsNotify.SendEmail(UserEmail, Subject, MessageBody, AccountEmail(), True)
            Else
                reader.Close()
                If DateDifference.ToString = OneYear * YearCounter - OneMonthReminder Then
                    'Send SMS Message
                    tools.SendSMS(Me, GetSMSAPI(), GetSMSUsername(), GetSMSPassword(), BulkSMSDefaultSender(), SMSPhoneNumber, OneMonthAnnualLicensingRenewalReminderMessage())
                    'Seven days before the expiration day
                ElseIf DateDifference.ToString = OneYear * YearCounter - SevenDaysReminder Then
                    'Send SMS Message
                    tools.SendSMS(Me, GetSMSAPI(), GetSMSUsername(), GetSMSPassword(), BulkSMSDefaultSender(), SMSPhoneNumber, OneWeekAnnualLicensingRenewalReminderMessage())
                ElseIf DateDifference.ToString = OneYear * YearCounter Then
                    'Send SMS Message
                    tools.SendSMS(Me, GetSMSAPI(), GetSMSUsername(), GetSMSPassword(), BulkSMSDefaultSender(), SMSPhoneNumber, AnnualLicensingRenewalReminderMessage())

                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)
        Finally
            DisconnectDatabase()
        End Try
    End Sub

    Public Function CheckRenewalStatus() As Integer
        Try
            ConnectDatabase()
            Dim db As String = "SELECT * FROM devicerenewal WHERE deviceReference='" & ReferenceNumber & "' AND renewalYear='" & RenewalYear & "'"
            Using cn As MySqlCommand = New MySqlCommand(db, conn)
                Using da As New MySqlDataAdapter(cn)
                    Dim ds As New DataSet()
                    da.Fill(ds, "devicerenewal")
                    CheckRenewalStatus = ds.Tables(0).Rows.Item("renewalStatus").ToString
                End Using
            End Using
            Return CheckRenewalStatus

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)
        Finally
            DisconnectDatabase()
        End Try
    End Function

    Public Sub UpdateInstumentYearCount()
        Try
            ConnectDatabase()
            Dim NewYearCounter = YearCounter + 1
            'Update Wallet Balance
            Dim strSQLs As String
            strSQLs = "UPDATE deviceregistration SET yearCounter='" & NewYearCounter & "' WHERE companyID='" & CompanyID & "' AND serialNumber='" & InstrumentSerialNo & "'"
            Dim cmds As New MySqlCommand(strSQLs, conn)
            cmds.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)
        Finally
            DisconnectDatabase()
        End Try
    End Sub


    Public Sub SendAnualLicensingRenewalMessage()
        'Send Annual Licensing Renewal Reminder Message
        Dim SMSPhoneNumber = CompanyPhoneNumber & "," & FillerPhoneNumber
        tools.SendSMS(Me, GetSMSAPI(), GetSMSUsername(), GetSMSPassword(), BulkSMSDefaultSender(), SMSPhoneNumber, AnnualLicensingRenewalReminderMessage())
    End Sub


End Class