Imports System.Web
Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Data.OleDb
Imports System.Web.Security
Imports System.Configuration
Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography

Public Class _default11
    Inherits System.Web.UI.Page

    'This is the function for calender

    'Protected Sub FromDate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles FromDate.Click
    Protected Sub FromDate_Click(sender As Object, e As EventArgs) Handles FromDate.Click
        CalendarFrom.Visible = True
        CalendarTo.Visible = False
    End Sub

    Protected Sub CalendarFrom_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim SelectedDate = CalendarFrom.SelectedDate.Date()
        Dim DateFormat As String = "d-MM-yyyy"

        FilterInvoiceByDateFrom.Text = SelectedDate.ToString(DateFormat.ToString)
        CalendarFrom.Visible = False
    End Sub



    'Protected Sub ToDate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToDate.Click
    Protected Sub ToDate_Click(sender As Object, e As EventArgs) Handles ToDate.Click
        CalendarTo.Visible = True
        CalendarFrom.Visible = False
    End Sub

    Protected Sub CalendarTo_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim SelectedDate = CalendarTo.SelectedDate.Date()
        Dim DateFormat As String = "d-MM-yyyy"

        FilterInvoiceByDateTo.Text = SelectedDate.ToString(DateFormat.ToString)
        CalendarTo.Visible = False
    End Sub



    Public Function GenerateRandomStringNumber(ByRef len As Integer, ByRef upper As Boolean) As String
        Dim rand As New Random()
        Dim allowableChars() As Char = "012345678986574231".ToCharArray()
        Dim final As String = String.Empty
        For i As Integer = 0 To len - 1
            final += allowableChars(rand.Next(allowableChars.Length - 1))
        Next

        Return IIf(upper, final.ToUpper(), final)



    End Function


    Public Function GenerateRandomStringNumbers(ByRef len As Integer, ByRef upper As Boolean) As String
        Dim rand As New Random()
        Dim allowableChars() As Char = "123456789".ToCharArray()
        Dim final As String = String.Empty
        For i As Integer = 0 To len - 1
            final += allowableChars(rand.Next(allowableChars.Length - 1))
        Next

        Return IIf(upper, final.ToUpper(), final)



    End Function


    Public Function GenerateRandomStringOrderID(ByRef len As Integer, ByRef upper As Boolean) As String
        Dim rand As New Random()
        Dim allowableChars() As Char = "265138904".ToCharArray()
        Dim final As String = String.Empty
        For i As Integer = 0 To len - 1
            final += allowableChars(rand.Next(allowableChars.Length - 1))
        Next

        Return IIf(upper, final.ToUpper(), final)



    End Function


    'Function to get today's date
    Public Function TodaysDate()
        Dim TodayDate As Date = DateTime.Now
        Dim DateFormat As String = "d-MM-yyyy"

        TodaysDate = TodayDate.ToString(DateFormat.ToString)

        'MessageBox.Show(Me, TodayDate.ToString(DateFormat.ToString))
    End Function
    'Function to get current time
    Public Function CurrentTim()

        Dim CurrentTime As DateTime = DateTime.Now
        Dim TimeFormat As String = "hh:mm tt"

        CurrentTim = CurrentTime.ToString(TimeFormat)

        'MessageBox.Show(Me, CurrentTime.ToString(TimeFormat))

    End Function

    Public Function GenerateID()

        GenerateID = GenerateRandomStringNumbers(2, False) & GenerateRandomStringNumber(12, False)

    End Function

    'This get client's browser type
    Public Function GetBrowserName() As String
        Dim userAgent As String = Request.UserAgent
        If userAgent.Contains("MSIE 5.0") Then
            Return "Internet Explorer 5.0"
        ElseIf userAgent.Contains("MSIE 6.0") Then
            Return "Internet Explorer 6.0"
        ElseIf userAgent.Contains("MSIE 7.0") Then
            Return "Internet Explorer 7.0"
        ElseIf userAgent.Contains("MSIE 8.0") Then
            Return "Internet Explorer 8.0"
        ElseIf userAgent.Contains("Firefox") Then
            Return userAgent.Substring(userAgent.IndexOf("Firefox")).Replace("/", " ")
        ElseIf userAgent.Contains("Opera") Then
            Return userAgent.Substring(userAgent.IndexOf("Opera"))
        ElseIf userAgent.Contains("Chrome") Then
            Dim agentPart As String = userAgent.Substring(userAgent.IndexOf("Chrome"))
            Return agentPart.Substring(0, agentPart.IndexOf("Safari") - 1).Replace("/", " ")
        ElseIf userAgent.Contains("Safari") Then
            Dim agentPart As String = userAgent.Substring(userAgent.IndexOf("Version"))
            Dim version As String = agentPart.Substring(0, agentPart.IndexOf("Safari") - 1).Replace("Version/", "")
            Return "Safari " & version
        ElseIf userAgent.Contains("Konqueror") Then
            Dim agentPart As String = userAgent.Substring(userAgent.IndexOf("Konqueror"))
            Return agentPart.Substring(0, agentPart.IndexOf(";")).Replace("/", " ")
        ElseIf userAgent.ToLower.Contains("bot") Or userAgent.ToLower.Contains("search") Then
            Return "Search Bot"
        End If
        Return "Unknown Browser or Bot"
    End Function

    Public Function OrderID()

        OrderID = GenerateRandomStringOrderID(11, False)

    End Function


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsNothing(Session("Login")) Or Not Session("Login") = "True" Then
            Logout.Text = "LOGIN"
            ToolBar.Visible = False
            ' Headers.Attributes("style") = "height:110px"
            HeaderPanel.Height = 110
            Response.Redirect("../")

            RegistrationPanel.Visible = True


        Else
            Logout.Text = "LOGOUT"
            ToolBar.Visible = True

            RegistrationPanel.Visible = False

        End If

        Registration.Text = "REGISTER"


        If Not IsPostBack = True Then
            Try
                ConnectDatabase()

                Dim db As String = "SELECT * FROM deposits WHERE CompanyID='" & Session("UserLoginID") & "'"

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)

                        'Get the list of rows needed into Session, so as to enable us retreive it later

                        Dim dt As New DataTable()
                        Dim ds As New DataSet()
                        da.Fill(dt)
                        da.Fill(ds, "deposits")

                        InvoiceGridView.DataSource = ds
                        InvoiceGridView.DataMember = "deposits"
                        InvoiceGridView.DataBind()



                    End Using
                End Using

            Catch ex As MySqlException
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
            End Try


        Else

        End If

        'This code does everything partaining wallet
       
        Try
            ConnectDatabase()

            Dim db As String = "SELECT * FROM wallet WHERE CompanyName='" & Session("UserLoginCompanyName") & "'"

            Using cn As MySqlCommand = New MySqlCommand(db, conn)
                Using da As New MySqlDataAdapter(cn)

                    'Get the list of rows needed into Session, so as to enable us retreive it later

                    Dim dt As New DataTable()
                    Dim ds As New DataSet()
                    da.Fill(dt)
                    da.Fill(ds, "deposits")

                    Dim WalletAmount = ds.Tables(0).Rows(0).Item("totalBalance").ToString
                    Try
                        If WalletAmount <= 0 Then
                            WalletBalance.ForeColor = Drawing.Color.DarkRed
                        ElseIf WalletAmount >= 1 Then
                            WalletBalance.ForeColor = Drawing.Color.Black
                        End If
                    Catch ex As Exception
                        MessageBox.Show(Me, ex.Message)
                    End Try



                    Try
                        WalletBalance.Text = FormatNumber(WalletAmount, 2, TriState.False, , TriState.True)
                    Catch ex As Exception
                        MessageBox.Show(Me, "Only digits and/or a decimal please.")
                    End Try



                End Using
            End Using

        Catch ex As MySqlException
            MessageBox.Show(Me, ex.Message)
        Finally
            DisconnectDatabase()
        End Try



    End Sub


    Protected Sub Registration_Click(sender As Object, e As EventArgs) Handles Registration.Click
        If (Session("Login")) Or (Session("Login")) = "True" Then
            Response.Redirect("../registration/")
            Logout_Click(sender, New EventArgs)


        Else
            Response.Redirect("../registration/")
        End If
    End Sub



    Protected Sub Logout_Click(sender As Object, e As EventArgs) Handles Logout.Click

        If IsNothing(Session("Login")) Then

            Response.Redirect("../")
            MessageBox.Show(Me, "You are already on the login page, please login")
        Else

            'Log user out activity
            Try
                ConnectDatabase()
                'This code do the loggin magic
                Dim ComputerName = System.Net.Dns.GetHostEntry(Request.ServerVariables("remote_addr")).HostName
                Dim UserIP = Request.ServerVariables("REMOTE_ADDR")
                'Dim UserBrowser = Request.ServerVariables("HTTP_USER_AGENT") 'Request.UserAgent '
                Dim osVersion As String = System.Environment.OSVersion.ToString()

                If osVersion.Contains("Windows") Then
                    osVersion = "Windows Operating System"
                End If
                If osVersion.Contains("MAC") Then
                    osVersion = "MAC Operating System"
                End If
                If osVersion.Contains("X11") Then
                    osVersion = "UNIX Operating System"
                End If
                If osVersion.Contains("Linux") Then
                    osVersion = "LINUX Operating System"
                End If


                Dim Activity As String = "User logged out!"
                Dim com As New MySqlCommand
                com.Connection = conn
                com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("UserLoginID") & "','" & Activity & "','" & Session("UserLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("UserLoginUserType") & "')"
                com.ExecuteNonQuery()


            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)

            Finally
                DisconnectDatabase()
            End Try

            Session("Login") = ""
            Session.Clear()
            Session.RemoveAll()
            Response.AppendHeader("Refresh", "0;url=./")

        End If

    End Sub


    Protected Sub SaveDeposit_Click(sender As Object, e As EventArgs) Handles SaveDeposit.Click
        Try

            ConnectDatabase()
            Dim confirmed As Integer = "0"
            Dim com As New MySqlCommand
            com.Connection = conn
            com.CommandText = "INSERT INTO deposits (companyID,amountDeposit,narration,paymentMode,depositDate,depositTime,confirmed,transactionID,bankName,orderID,companyName) VALUE ('" & Session("UserLoginID") & "','" & DepositAmount.Text & "','" & DepositNarration.Text & "','" & DepositPaymentType.SelectedValue & "','" & TodaysDate() & "','" & CurrentTim() & "','" & confirmed & "','" & GenerateID() & "','" & DepositBankName.Text & "','" & OrderID() & "','" & Session("UserLoginCompanyName") & "')"
            'com.CommandText = "INSERT INTO deposits (companyID,transCode,amountDue,invoiceDate,invoiceTime,narration,orderId) VALUE ('" & Session("UserLoginID") & "','" & UniqueID() & "','" & DepositAmount.Text & "','" & TodaysDate() & "','" & CurrentTim() & "', '" & DepositNarration.Text & "','" & OrderID() & "')"
            com.ExecuteNonQuery()


            'This code do the loggin magic
            Dim ComputerName = System.Net.Dns.GetHostEntry(Request.ServerVariables("remote_addr")).HostName
            Dim UserIP = Request.ServerVariables("REMOTE_ADDR")
            'Dim UserBrowser = Request.ServerVariables("HTTP_USER_AGENT") 'Request.UserAgent '
            Dim osVersion As String = System.Environment.OSVersion.ToString()

            If osVersion.Contains("Windows") Then
                osVersion = "Windows Operating System"
            End If
            If osVersion.Contains("MAC") Then
                osVersion = "MAC Operating System"
            End If
            If osVersion.Contains("X11") Then
                osVersion = "UNIX Operating System"
            End If
            If osVersion.Contains("Linux") Then
                osVersion = "LINUX Operating System"
            End If


            Dim Activity As String = "Deposit of  " & DepositAmount.Text & " to " & DepositBankName.Text & " for: " & DepositNarration.Text
            Dim comm As New MySqlCommand
            comm.Connection = conn
            comm.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("UserLoginID") & "','" & Activity & "','" & Session("UserLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("UserLoginUserType") & "')"
            comm.ExecuteNonQuery()





            MessageBox.Show(Me, "Amount has been deposited successfully")

            Response.Redirect("./", False)

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)
            MsgBox(ex.Message)
        Finally
            DisconnectDatabase()

        End Try
    End Sub

    Protected Sub FilterDepositButton_Click(sender As Object, e As EventArgs) Handles FilterDepositButton.Click

        If FilterDeposit.selectedValue = "All" Then

            Try
                ConnectDatabase()

                Dim db As String = "SELECT * FROM deposits WHERE CompanyID='" & Session("UserLoginID") & "'"

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)

                        'Get the list of rows needed into Session, so as to enable us retreive it later

                        Dim dt As New DataTable()
                        Dim ds As New DataSet()
                        da.Fill(dt)
                        da.Fill(ds, "deposits")

                        InvoiceGridView.DataSource = Nothing
                        InvoiceGridView.DataBind()

                        InvoiceGridView.DataSource = ds
                        InvoiceGridView.DataMember = "deposits"
                        InvoiceGridView.DataBind()



                    End Using
                End Using

            Catch ex As MySqlException
                MessageBox.Show(Me, ex.Message)
            End Try


        ElseIf FilterDeposit.SelectedValue = "Online" Then
            Try
                ConnectDatabase()
                Dim Mode = "Online"

                Dim db As String = "SELECT * FROM deposits WHERE CompanyID='" & Session("UserLoginID") & "' AND paymentMode='" & Mode & "'"

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)

                        'Get the list of rows needed into Session, so as to enable us retreive it later

                        Dim dt As New DataTable()
                        Dim ds As New DataSet()
                        da.Fill(dt)
                        da.Fill(ds, "deposits")

                        InvoiceGridView.DataSource = Nothing
                        InvoiceGridView.DataBind()

                        InvoiceGridView.DataSource = ds
                        InvoiceGridView.DataMember = "deposits"
                        InvoiceGridView.DataBind()



                    End Using
                End Using

            Catch ex As MySqlException
                MessageBox.Show(Me, ex.Message)
            End Try



        ElseIf FilterDeposit.SelectedValue = "Cash" Then
            Try
                ConnectDatabase()
                Dim Mode = "Cash"

                Dim db As String = "SELECT * FROM deposits WHERE CompanyID='" & Session("UserLoginID") & "' AND paymentMode='" & Mode & "'"

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)

                        'Get the list of rows needed into Session, so as to enable us retreive it later

                        Dim dt As New DataTable()
                        Dim ds As New DataSet()
                        da.Fill(dt)
                        da.Fill(ds, "deposits")

                        InvoiceGridView.DataSource = Nothing
                        InvoiceGridView.DataBind()

                        InvoiceGridView.DataSource = ds
                        InvoiceGridView.DataMember = "deposits"
                        InvoiceGridView.DataBind()



                    End Using
                End Using

            Catch ex As MySqlException
                MessageBox.Show(Me, ex.Message)
            End Try


        ElseIf FilterDeposit.SelectedValue = "Cheque" Then
            Try
                ConnectDatabase()
                Dim Mode = "Cheque"

                Dim db As String = "SELECT * FROM deposits WHERE CompanyID='" & Session("UserLoginID") & "' AND paymentMode='" & Mode & "'"

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)

                        'Get the list of rows needed into Session, so as to enable us retreive it later

                        Dim dt As New DataTable()
                        Dim ds As New DataSet()
                        da.Fill(dt)
                        da.Fill(ds, "deposits")

                        InvoiceGridView.DataSource = Nothing
                        InvoiceGridView.DataBind()

                        InvoiceGridView.DataSource = ds
                        InvoiceGridView.DataMember = "deposits"
                        InvoiceGridView.DataBind()



                    End Using
                End Using

            Catch ex As MySqlException
                MessageBox.Show(Me, ex.Message)
            End Try



        ElseIf FilterDeposit.SelectedValue = "Approved" Then
            Dim Approve As String = "Approved"
            Try
                ConnectDatabase()
                Dim Mode = "Date"

                Dim db As String = "SELECT * FROM deposits WHERE (CompanyID='" & Session("UserLoginID") & "') AND (approvalStatus ='" & Approve & "')"

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)

                        'Get the list of rows needed into Session, so as to enable us retreive it later

                        Dim dt As New DataTable()
                        Dim ds As New DataSet()
                        da.Fill(dt)
                        da.Fill(ds, "deposits")

                        InvoiceGridView.DataSource = Nothing
                        InvoiceGridView.DataBind()

                        InvoiceGridView.DataSource = ds
                        InvoiceGridView.DataMember = "deposits"
                        InvoiceGridView.DataBind()



                    End Using
                End Using

            Catch ex As MySqlException
                MessageBox.Show(Me, ex.Message)
            End Try


        ElseIf FilterDeposit.SelectedValue = "Date" Then

                If FilterInvoiceByDateFrom.Text = "" Or FilterInvoiceByDateTo.Text = "" Then

                    MessageBox.Show(Me, "Date Can not be left empty if you want to filter by date")

                    InvoiceGridView.DataSource = Nothing
                    InvoiceGridView.DataBind()

                Else
                    Try
                        ConnectDatabase()
                        Dim Mode = "Date"

                        Dim db As String = "SELECT * FROM deposits WHERE (CompanyID='" & Session("UserLoginID") & "') AND (depositDate BETWEEN ('" & FilterInvoiceByDateFrom.Text & "') AND ('" & FilterInvoiceByDateTo.Text & "'))"

                        Using cn As MySqlCommand = New MySqlCommand(db, conn)
                            Using da As New MySqlDataAdapter(cn)

                                'Get the list of rows needed into Session, so as to enable us retreive it later

                                Dim dt As New DataTable()
                                Dim ds As New DataSet()
                                da.Fill(dt)
                                da.Fill(ds, "deposits")

                                InvoiceGridView.DataSource = Nothing
                                InvoiceGridView.DataBind()

                                InvoiceGridView.DataSource = ds
                                InvoiceGridView.DataMember = "deposits"
                                InvoiceGridView.DataBind()



                            End Using
                        End Using

                    Catch ex As MySqlException
                        MessageBox.Show(Me, ex.Message)
                    End Try
                End If



            End If

    End Sub

    Protected Sub PaymentType_IndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If DepositPaymentType.SelectedValue = "Cash" Then
            DepositChequeNumbe.Text = "Teller Number"
            DepositBankName.Enabled = True
            DepositBankName.BackColor = Drawing.Color.White


        ElseIf DepositPaymentType.SelectedValue = "Cheque" Then

            DepositChequeNumbe.Text = "Cheque Number"
            DepositBankName.Enabled = True
            DepositBankName.BackColor = Drawing.Color.White

        ElseIf DepositPaymentType.SelectedValue = "Online" Then

            DepositChequeNumbe.Text = "Reference Number"
            DepositBankName.Enabled = False
            DepositBankName.BackColor = Drawing.Color.DarkGray


        End If

    End Sub


    Protected Sub ProfileIcon_Click(sender As Object, e As EventArgs) Handles ProfileIcon.Click
        Response.Redirect("../profile/")
    End Sub


    Protected Sub InvoiceIcon_Click(sender As Object, e As EventArgs) Handles InvoiceIcon.Click
        Response.Redirect("../invoice/")
    End Sub


    Protected Sub DepositIcon_Click(sender As Object, e As EventArgs) Handles DepositIcon.Click
        Response.Redirect("../deposit/")
    End Sub


    Protected Sub UploadIcon_Click(sender As Object, e As EventArgs) Handles UploadIcon.Click
        Response.Redirect("../upload/")
    End Sub


    Protected Sub InstrumentServicesIcon_Click(sender As Object, e As EventArgs) Handles InstrumentServicesicon.Click
        Response.Redirect("../instrument-services/")
    End Sub


    Protected Sub RegisterInstrumentIcon_Click(sender As Object, e As EventArgs) Handles RegisterInstrumentIcon.Click
        Response.Redirect("../register-instrument/")
    End Sub

    Protected Sub RequirementIcon_Click(sender As Object, e As EventArgs) Handles RequirementIcon.Click
        Response.Redirect("../requirements/")
    End Sub


    Protected Sub ImportPermitIcon_Click(sender As Object, e As EventArgs) Handles ImportPermitIcon.Click
        'Response.Redirect("../import-permit/")
    End Sub

    Protected Sub ExportPermitIcon_Click(sender As Object, e As EventArgs) Handles ExportPermitIcon.Click
        Response.Redirect("../export-permit/")
    End Sub

    Protected Sub ReportsIcon_Click(sender As Object, e As EventArgs) Handles ReportIcon.Click
        Response.Redirect("../reports/")
    End Sub





End Class