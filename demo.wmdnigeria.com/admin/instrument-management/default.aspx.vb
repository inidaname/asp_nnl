Imports System.Web
Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Data.OleDb
Imports System.Web.Security
Imports System.Configuration
Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography

Public Class _default19
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Check if Admin login session is active, if its not return to Login page
        loggedUser.Text = Session("LoggedInAdminLoginUsername")

        If IsNothing(Session("LoggedInAdminLoginUsername")) Then
            MessageBox.Show(Me, "No Valid user login")

            Response.Redirect("../")

        Else

        End If
        'Check if the logged in user have an admin account or staff Account, if its admin display all icons. if its staff, display only allowed right


        If Not Session("LoggedInAdminLoginAccountType") = "" And Session("LoggedInAdminLoginCompanyMgtRight") = "0" Then
            CompanyManagementLink.Visible = False
        End If
        If Not Session("LoggedInAdminLoginAccountType") = "" And Session("LoggedInAdminLoginInstrumentMgtRight") = "0" Then
            InstrumentManagementLink.Visible = False
        End If
        If Not Session("LoggedInAdminLoginAccountType") = "" And Session("LoggedInAdminLoginStaticDataRight") = "0" Then
            StaticDataLink.Visible = False
        End If
        If Not Session("LoggedInAdminLoginAccountType") = "" And Session("LoggedInAdminLoginImportPermitManagement") = "0" Then
            ImportPermitManagementLink.Visible = False
        End If
        If Not Session("LoggedInAdminLoginAccountType") = "" And Session("LoggedInAdminLoginReportRight") = "0" Then
            ReportingLink.Visible = False
        End If
        If Not Session("LoggedInAdminLoginAccountType") = "" And Session("LoggedInAdminLoginArchiveRight") = "0" Then
            FileManagerLink.Visible = False
        End If
        If Not Session("LoggedInAdminLoginAccountType") = "" And Session("LoggedInAdminLoginExportDataReturn") = "0" Then
            ExportDataLink.Visible = False
        End If
        If Not Session("LoggedInAdminLoginAccountType") = "" And Session("LoggedInAdminLoginExportPermitManagement") = "0" Then
            ExportPermitManagementLink.Visible = False
        End If



        If Not IsPostBack = True Then

            'TabOverallContainer.Visible = False

            Try
                ConnectDatabase()
                Dim dbu As String = "SELECT * FROM company"
                Using cnu As MySqlCommand = New MySqlCommand(dbu, conn)
                    Using dau As New MySqlDataAdapter(cnu)
                        'Fill data of logged in user into dataset

                        'Get the list of rows needed into Session, so as to enable us retreive it later
                        Dim dt As New DataTable
                        dau.Fill(dt)

                        SelectCompany.DataSource = dt
                        SelectCompany.DataTextField = "companyName"
                        SelectCompany.DataValueField = "ID"
                        SelectCompany.DataBind()

                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
            End Try


            Try
                ConnectDatabase()

                Dim db As String = "SELECT * FROM deviceregistration WHERE companyID='" & SelectCompany.SelectedValue & "'"

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)
                        'Fill data of logged in user into dataset

                        'Get the list of rows needed into Session, so as to enable us retreive it later
                        Dim dt As New DataTable
                        da.Fill(dt)
                        SelectInstrument.DataSource = dt
                        SelectInstrument.DataTextField = "deviceType"
                        SelectInstrument.DataValueField = "ID"
                        SelectInstrument.DataBind()

                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
            End Try



            'Display payment data in data gridview 
            Try
                ConnectDatabase()

                Dim db As String = "SELECT *, concat(deviceType,' : SN ',modelNumber) As InstrumentAndModel FROM deviceregistration WHERE companyID='" & SelectCompany.SelectedValue & "'"

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)

                        'Get the list of rows needed into Session, so as to enable us retreive it later

                        Dim dt As New DataTable()
                        da.Fill(dt)

                        RegisteredInstrumentGridView.DataSource = Nothing
                        RegisteredInstrumentGridView.DataBind()

                        RegisteredInstrumentGridView.DataSource = dt
                        RegisteredInstrumentGridView.DataMember = "deviceregistration"
                        RegisteredInstrumentGridView.DataBind()

                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
            End Try

            NoRecord.Visible = False
            ProcessingData.Visible = False


        Else

        End If


    End Sub


    Protected Sub OnInstrumentSelectedIndexChanged(sender As Object, e As EventArgs)

        Dim InstrumentName = RegisteredInstrumentGridView.SelectedRow.Cells(0).Text

        Instrument.Text = RegisteredInstrumentGridView.SelectedRow.Cells(3).Text
        Session.Add("InstrumentSelected", InstrumentName)
        Dim InstrumentSerialNo = RegisteredInstrumentGridView.SelectedRow.Cells(3).Text
        Session.Add("SelectedInstrumentSerialNo", InstrumentSerialNo)

        Dim Amount = RegisteredInstrumentGridView.SelectedRow.Cells(4).Text
        Dim TransactionID = RegisteredInstrumentGridView.SelectedRow.Cells(5).Text
        Session.Add("TransCode", InstrumentSerialNo)
        Try
            ConnectDatabase()

            Dim dbu As String = "SELECT * FROM devicetestsheet WHERE instrumentSerialNo='" & InstrumentSerialNo & "'"
            Using cnu As MySqlCommand = New MySqlCommand(dbu, conn)
                Using dau As New MySqlDataAdapter(cnu)
                    'Fill data of logged in user into dataset
                    Dim dsm As New DataSet
                    dau.Fill(dsm)
                    Dim dt As New DataTable
                    dau.Fill(dt)

                    If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                        SaveInstrument.Text = "Save Device Verification"
                        'MessageBox.Show(Me, "There's no row here guy!")
                    Else
                        SaveInstrument.Text = "Update Device Verification"
                        StandardGuage.Text = dsm.Tables(0).Rows(0).Item("standardMeasure").ToString
                        VerifiedGuage.Text = dsm.Tables(0).Rows(0).Item("verifiedMeasure").ToString
                        GuageName.Text = dsm.Tables(0).Rows(0).Item("measureType").ToString
                        Comment.Text = dsm.Tables(0).Rows(0).Item("comments").ToString
                        InstrumentTag.Text = dsm.Tables(0).Rows(0).Item("deviceCurrentState").ToString
                        Instrument.Text = dsm.Tables(0).Rows(0).Item("instrumentSerialNo").ToString
                        VerificationDate.Text = dsm.Tables(0).Rows(0).Item("registrationDate").ToString

                    End If

                End Using
            End Using

        Catch ex As Exception
        End Try

        Try
            Dim db As String = "SELECT * FROM devicelegalnotices WHERE deviceID='" & InstrumentSerialNo & "'"

            Using cn As MySqlCommand = New MySqlCommand(db, conn)
                Using da As New MySqlDataAdapter(cn)
                    Dim ds As New DataSet
                    da.Fill(ds)
                    NoticeHeading.Text = ds.Tables(0).Rows(0).Item("heading").ToString
                    NoticeBody.Text = ds.Tables(0).Rows(0).Item("notices").ToString

                End Using
            End Using


        Catch ex As Exception

        End Try



        'Display payment data in data gridview 
        Try
            Dim db As String = "SELECT * FROM payment WHERE transCode='" & TransactionID & "'"
            Using cn As MySqlCommand = New MySqlCommand(db, conn)
                Using da As New MySqlDataAdapter(cn)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                        NoRecord.Visible = True
                    Else
                        NoRecord.Visible = False
                    End If

                    TabOverallContainer.Visible = True
                    InstrumentInvoiceGridView.DataSource = Nothing
                    InstrumentInvoiceGridView.DataBind()

                    InstrumentInvoiceGridView.DataSource = dt
                    InstrumentInvoiceGridView.DataMember = "payment"
                    InstrumentInvoiceGridView.DataBind()

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)
        Finally
            DisconnectDatabase()
        End Try

    End Sub


    Sub SelectCompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SelectCompany.SelectedIndexChanged

        RegisteredInstrumentGridView.DataSource = Nothing
        RegisteredInstrumentGridView.DataBind()
        TabOverallContainer.Visible = False
        Try
            ConnectDatabase()
            Dim db As String = "SELECT * FROM deviceregistration WHERE companyID='" & SelectCompany.SelectedValue & "'"
            Using cn As MySqlCommand = New MySqlCommand(db, conn)
                Using da As New MySqlDataAdapter(cn)
                    Dim ds As New DataSet
                    da.Fill(ds)
                    Dim DeviceID = ds.Tables(0).Rows(0).Item("subDeviceID").ToString
                    Dim dbu As String = "SELECT * FROM devicesub WHERE deviceType='" & DeviceID & "'"
                    Using cnu As MySqlCommand = New MySqlCommand(dbu, conn)
                        Using dau As New MySqlDataAdapter(cnu)
                            'Fill data of logged in user into dataset

                            'Get the list of rows needed into Session, so as to enable us retreive it later
                            Dim dt As New DataTable
                            dau.Fill(dt)
                            If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                NoRecord.Visible = True
                            Else
                                NoRecord.Visible = False
                            End If

                            RegisteredInstrumentGridView.DataSource = Nothing
                            RegisteredInstrumentGridView.DataBind()

                            RegisteredInstrumentGridView.DataSource = dt
                            RegisteredInstrumentGridView.DataMember = "deviceregistration"
                            RegisteredInstrumentGridView.DataBind()

                        End Using
                    End Using

                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)
        
        End Try

        Try
           
            Dim db As String = "SELECT * FROM deviceregistration WHERE companyID='" & SelectCompany.SelectedValue & "'"

            Using cn As MySqlCommand = New MySqlCommand(db, conn)
                Using da As New MySqlDataAdapter(cn)
                    'Fill data of logged in user into dataset

                    'Get the list of rows needed into Session, so as to enable us retreive it later
                    Dim ds As New DataSet
                    da.Fill(ds)
                    SelectInstrument.DataSource = ds
                    SelectInstrument.DataTextField = "deviceType"
                    SelectInstrument.DataValueField = "ID"
                    SelectInstrument.DataBind()

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)
        Finally
            DisconnectDatabase()
        End Try



    End Sub

    Protected Sub ShowPermitResult_Click(sender As Object, e As EventArgs) Handles ShowPermitResult.Click

        RegisteredInstrumentGridView.DataSource = Nothing
        RegisteredInstrumentGridView.DataBind()
        TabOverallContainer.Visible = False
        Try
            ConnectDatabase()

            Dim dbu As String = "SELECT * FROM deviceregistration WHERE companyID='" & SelectCompany.SelectedValue & "' AND deviceType='" & SelectInstrument.SelectedItem.Text & "'"

            Using cnu As MySqlCommand = New MySqlCommand(dbu, conn)
                Using dau As New MySqlDataAdapter(cnu)
                    Dim dt As New DataTable
                    dau.Fill(dt)
                    If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                        NoRecord.Visible = True
                    Else
                        NoRecord.Visible = False
                    End If

                    RegisteredInstrumentGridView.DataSource = Nothing
                    RegisteredInstrumentGridView.DataBind()

                    RegisteredInstrumentGridView.DataSource = dt
                    RegisteredInstrumentGridView.DataMember = "deviceregistration"
                    RegisteredInstrumentGridView.DataBind()

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)
        Finally
            DisconnectDatabase()
        End Try
    End Sub

    Protected Sub SaveInstrument_Click(sender As Object, e As EventArgs) Handles SaveInstrument.Click
        If SaveInstrument.Text = "Save Device Verification" Then

            Try
                ConnectDatabase()

                Dim coms As New MySqlCommand
                coms.Connection = conn
                coms.CommandText = "INSERT INTO devicetestsheet (standardMeasure,verifiedMeasure,measureType,userID,registrationDate,registrationTime,instrumentSerialNo,deviceCurrentState,comments) VALUES ('" & StandardGuage.Text & "','" & VerifiedGuage.Text & "','" & GuageName.Text & "','" & Session("LoggedInAdminLoginUsername") & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Instrument.Text & "','" & InstrumentTag.Text & "','" & Comment.Text & "')"
                coms.ExecuteNonQuery()

                Dim Activity As String = Session("LoggedInAdminLoginUsername") & "  verified " & SelectCompany.SelectedItem.Text & " , Instrument Name: " & Session("InstrumentSelected") & " , Instrument ID: " & Session("SelectedInstrumentSerialNo") & " Instrument"
                Dim com As New MySqlCommand
                com.Connection = conn
                com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("UserLoginIPAddress") & "','" & ComputerName() & "','" & osVersion() & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                com.ExecuteNonQuery()

                MessageBox.Show(Me, "Instrument test / verification data saved successfuly!")
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)

            Finally
                DisconnectDatabase()
            End Try

        ElseIf SaveInstrument.Text = "Update Device Verification" Then
            Try
                ConnectDatabase()

                Dim strSQL As String
                strSQL = "UPDATE devicetestsheet SET standardMeasure='" & StandardGuage.Text & "' WHERE deviceID= '" & Session("SelectedInstrumentSerialNo") & "' AND tranScode= '" & Session("TransCode") & "'"
                Dim cmd As New MySqlCommand(strSQL, conn)
                cmd.ExecuteNonQuery()
                MessageBox.Show(Me, "Instrument test / verification data updated successfuly!")
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
            End Try
        End If
       
    End Sub

    Protected Sub SendLegalNotice_Click(sender As Object, e As EventArgs) Handles SendLegalNotice.Click

        Try
            ConnectDatabase()

            Dim coms As New MySqlCommand
            coms.Connection = conn
            coms.CommandText = "INSERT INTO devicelegalnotices (heading,notices,userID,registrationDate,registrationTime,deviceID) VALUES ('" & NoticeHeading.Text & "','" & NoticeBody.Text & "','" & Session("LoggedInAdminLoginUsername") & "', '" & TodaysDate() & "','" & CurrentTim() & "','" & Session("SelectedInstrumentSerialNo") & "')"
            coms.ExecuteNonQuery()

            Dim Activity As String = Session("LoggedInAdminLoginUsername") & "  send legal notice to!" & SelectCompany.SelectedItem.Text & " , Instrument Name: " & Session("InstrumentSelected") & " , Instrument ID: " & Session("SelectedInstrumentSerialNo")
            Dim com As New MySqlCommand
            com.Connection = conn
            com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("UserLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
            com.ExecuteNonQuery()

            MessageBox.Show(Me, "Legal notice sent successfully!")
        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)

        Finally
            DisconnectDatabase()
        End Try

        Response.Redirect("./", False)
    End Sub


    Protected Sub LogoutAdmin_Click(sender As Object, e As EventArgs) Handles LogoutAdmin.Click
        Try
            ConnectDatabase()
            MessageBox.Show(Me, "Please wait while you are logged out! Thank you!")
            Session("LoggedInAdminLoginUsername") = ""
            Session.Clear()
            Session.RemoveAll()

            Dim Activity As String = Session("LoggedInAdminLoginUsername") & "  Logout!"
            Dim coms As New MySqlCommand
            coms.Connection = conn
            coms.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("UserLoginIPAddress") & "','" & ComputerName() & "','" & osVersion() & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
            coms.ExecuteNonQuery()

            Response.AppendHeader("Refresh", "0;url=./")
        Catch ex As Exception
        End Try
    End Sub

End Class