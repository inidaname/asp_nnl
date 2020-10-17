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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsNothing(Session("Login")) Or Not Session("Login") = "True" Then
             ProfileIcon.Visible = False
            Account.Text = "ACCOUNT"
            Logout.Text = "LOGIN"
            ToolBar.Visible = False
            HeaderPanel.Height = 110
            Response.Redirect("../")

            RegistrationPanel.Visible = True
        Else
            ProfileIcon.Visible = True
            Account.Text = Session("UserLoginName")
            Logout.Text = "LOGOUT"
            ToolBar.Visible = True

            RegistrationPanel.Visible = False

        End If

        Registration.Text = "REGISTER"

        DepositNarration.Text = "Wallet Deposit"



        If Not IsPostBack = True Then
            OrderIDText.Text = OrderID()

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

                        Cache("DepositData") = dt
                    End Using
                End Using

            Catch ex As Exception
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

        Catch ex As Exception
            'MessageBox.Show(Me, ex.Message)
        Finally
            DisconnectDatabase()
        End Try



    End Sub


    Protected Sub DepositGridView_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        InvoiceGridView.PageIndex = e.NewPageIndex
        InvoiceGridView.DataSource = CType(Cache("DepositData"), DataTable)
        InvoiceGridView.DataBind()

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
        Else

            'Log user out activity
            Try
                ConnectDatabase()
                Dim Activity As String = Session("UserLoginName") & " User logged out!"
                Dim com As New MySqlCommand
                com.Connection = conn
                com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("UserLoginID") & "','" & Activity & "','" & Session("UserLoginIPAddress") & "','" & ComputerName() & "','" & osVersion() & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("UserLoginUserType") & "')"
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


    Protected Sub PaymentType_IndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If DepositPaymentType.SelectedValue = "Cash" Then
            DepositChequeNumbe.Text = "Teller Number"
            BankName.Enabled = True
            BankName.BackColor = Drawing.Color.White
            DepositChequeorReceiptNumber.Enabled = True
            DepositChequeorReceiptNumber.BackColor = Drawing.Color.White
            SaveDeposit.Text = "Save Deposit"


        ElseIf DepositPaymentType.SelectedValue = "Cheque" Then

            DepositChequeNumbe.Text = "Cheque Number"
            BankName.Enabled = True
            BankName.BackColor = Drawing.Color.White
            DepositChequeorReceiptNumber.Enabled = True
            DepositChequeorReceiptNumber.BackColor = Drawing.Color.White
            SaveDeposit.Text = "Save Deposit"


        ElseIf DepositPaymentType.SelectedValue = "Online" Then
            DepositChequeNumbe.Text = "Reference Number"
            BankName.Enabled = False
            BankName.BackColor = Drawing.Color.DarkGray
            DepositChequeorReceiptNumber.Enabled = False
            DepositChequeorReceiptNumber.BackColor = Drawing.Color.DarkGray
            SaveDeposit.Text = "Continue"

        End If

    End Sub



    Protected Sub SaveDeposit_Click(sender As Object, e As EventArgs) Handles SaveDeposit.Click

        If DepositAmount.Text = "" Or DepositPaymentType.SelectedItem.Text.Contains("Select") Or BankName.SelectedItem.Text.Contains("Select") Then
            MessageBox.Show(Me, "Select a valid option and make sure the Amount field is not blank!")
        Else

            If DepositPaymentType.SelectedValue = "Online" Then
                tools.DoOnlinePayment(Me, DepositAmount.Text, OrderIDText.Text, DepositNarration.Text, Session("UserLoginCompanyEmail"))

            Else

                Try

                    ConnectDatabase()
                    Dim confirmed As Integer = 0
                    Dim com As New MySqlCommand
                    com.Connection = conn
                    com.CommandText = "INSERT INTO deposits (companyID,amountDeposit,narration,paymentMode,depositDate,depositTime,confirmed,transactionID,bankName,orderID,companyName) VALUE ('" & Session("UserLoginID") & "','" & DepositAmount.Text & "','" & DepositNarration.Text & "','" & DepositPaymentType.SelectedValue & "','" & TodaysDate() & "','" & CurrentTim() & "','" & confirmed & "','" & GenerateID() & "','" & BankName.SelectedItem.Text & "','" & OrderIDText.Text & "','" & Session("UserLoginCompanyName") & "')"
                    'com.CommandText = "INSERT INTO deposits (companyID,transCode,amountDue,invoiceDate,invoiceTime,narration,orderId) VALUE ('" & Session("UserLoginID") & "','" & UniqueID() & "','" & DepositAmount.Text & "','" & TodaysDate() & "','" & CurrentTim() & "', '" & DepositNarration.Text & "','" & OrderID() & "')"
                    com.ExecuteNonQuery()

                    MessageBox.Show(Me, DepositAmount.Text & " has been deposited to your account successfully, awaiting Administrator approval!")

                    Try
                        DepositAmount.Text = FormatNumber(DepositAmount.Text, 2, TriState.False, , TriState.True)
                    Catch ex As Exception
                        MessageBox.Show(Me, "Only digits and/or a decimal please.")
                    End Try
                    Session.Remove("AmountPaid")
                    Session.Add("AmountPaid", DepositAmount.Text)
                    'Send SMS Message
                    tools.SendSMS(Me, GetSMSAPI(), GetSMSUsername(), GetSMSPassword(), BulkSMSDefaultSender(), SMSRecipientNumber(), WalletMessage())
                    'Send email to user after registration
                    Dim Message = "Your Wallet Payment on Federal Ministry of Industry, Trade and Investment Weights and Measures Department Web Portal was successful.<p> Your Wallet Account will be credited once your payment has been confirmed and approved. <div style=''><p> Below are the Payment Details:<p> <strong> Reference Number: </strong>" + OrderIDText.Text + "<p> <strong> Company Name: </strong>" + Session("UserLoginCompanyName") + "<p> <strong> Amount Paid: </strong>" + DepositAmount.Text + "<p> <strong> Payment Mode: </strong>" + DepositPaymentType.SelectedItem.Text + " <p> Kindly click the button below to login to your account.<p style='margin-top:50px;'> <strong>Thank you.</strong>"
                    Dim Subject = "Notification: Wallet Payment was Successful!"
                    Dim MessageBody = "<html><head></head><body style='font-family:Tahoma; width:620px;font-size:13px;background:rgb(240,240, 240)'><div style='width:600px;height:70px;padding:10px;color:rgb(255, 255, 255);font-weight:bolder;text-align:center;font-size:20px;background:rgb(54,127,169);'><img src='http://www.wmdnigeria.com/images/icon.png' width='70px' height='70px' align='left' vspace='0' style='margin-top:-10px;padding:0px;' /><p>Federal Ministry of Industry Trade and Investment <br><span style='font-size:17px;'>Weights and Measures Department</span></div><div style='width:600px;font-size:13px;color:rgb(100,100,100);'><p> <div style='padding-left:10px; width:590px;'><p>" & Message & "</div> <a href='http://www.wmdnigeria.com/' style='text-decoration:none;width:auto;'><div style='margin-top:40px;padding: 5px 10px;width:100px;font-size: 14px;font-weight: bolder;line-height: 20px;text-align: center;cursor: pointer;border: 1px solid transparent;border-radius: 4px;background:rgb(54,127,169);color:rgb(255, 255, 255);'>Login Now</div> </div>           <p><div style='margin-top:20px;width:600px;height:auto;padding:10px;color:rgb(255, 255, 255);text-align:center;font-size:13px;background:rgb(54,127,169);'><strong>NOTICE: </strong>  The content of this e-mail is intended solely for the use of the individual or entity to whom it is addressed. If you have received this communication in error, beware that forwarding it, copying it or in any way disclosing its content to any other person or persons, is strictly prohibiting. If you have received this communication in error, please notify the author by replying this e-mail immediately.</div></body></html>"

                    clsNotify.SendEmail(Session("UserLoginCompanyEmail"), Subject, MessageBody, AccountEmail(), True)

                    'This code do the loggin magic
                    Dim ComputerName = System.Net.Dns.GetHostEntry(Request.ServerVariables("remote_addr")).HostName
                    Dim UserIP = Request.ServerVariables("REMOTE_ADDR")

                    Dim Activity As String = "Deposit of  " & DepositAmount.Text & " to " & BankName.SelectedItem.Text & " for: " & DepositNarration.Text
                    Dim comm As New MySqlCommand
                    comm.Connection = conn
                    comm.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("UserLoginID") & "','" & Activity & "','" & Session("UserLoginIPAddress") & "','" & ComputerName & "','" & osVersion() & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("UserLoginUserType") & "')"
                    comm.ExecuteNonQuery()
                    Response.AppendHeader("Refresh", "0;url=./")

                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                Finally
                    DisconnectDatabase()
                End Try
            End If
        End If

    End Sub
    Protected Sub FilterDeposit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FilterDeposit.SelectedIndexChanged
        If FilterDeposit.SelectedValue = "All" Then
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

            Catch ex As Exception
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

            Catch ex As Exception
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

            Catch ex As Exception
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

            Catch ex As Exception
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

            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            End Try
        End If
    End Sub

    Protected Sub FilterDepositButton_Click(sender As Object, e As EventArgs) Handles FilterDepositButton.Click

        If FilterDeposit.SelectedValue = "Date" Then

            
            If DateFrom.Text = "" Or DateTo.Text = "" Then
                MessageBox.Show(Me, "Date fields can not be left blank!")
                InvoiceGridView.DataSource = Nothing
                InvoiceGridView.DataBind()
            Else
                Dim DateDifference
                Dim FormatStartDate = Date.ParseExact(DateFrom.Text, "d-MM-yyyy", Nothing)
                Dim FormatEndDate = Date.ParseExact(DateTo.Text, "d-MM-yyyy", Nothing)
                Dim DateFormat As String = "dd-MM-yyyy"
                Dim StartDate = FormatStartDate.ToString(DateFormat.ToString)
                Dim EndDate = FormatEndDate.ToString(DateFormat.ToString)

                DateDifference = Date.ParseExact(DateTo.Text, "d-MM-yyyy", Nothing) - Date.ParseExact(DateFrom.Text, "d-MM-yyyy", Nothing)

                If DateDifference.ToString.Contains("-") Then
                    MessageBox.Show(Me, "Start Date cannot be higher than the End Date, check the date to continue!")
                Else

                    Try
                        ConnectDatabase()
                        Dim Mode = "Date"
                        Dim db As String = "SELECT * FROM deposits WHERE (CompanyID='" & Session("UserLoginID") & "') AND DATE_FORMAT(STR_TO_DATE(depositDate, '%d-%m-%Y'), '%d-%m-%Y') BETWEEN DATE_FORMAT(STR_TO_DATE('" & StartDate & "', '%d-%m-%Y'), '%d-%m-%Y') AND DATE_FORMAT(STR_TO_DATE('" & EndDate & "', '%d-%m-%Y'), '%d-%m-%Y')"
                        Using cn As MySqlCommand = New MySqlCommand(db, conn)
                            Using da As New MySqlDataAdapter(cn)
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

                    Catch ex As Exception
                        MessageBox.Show(Me, ex.Message)
                    End Try
                End If

            End If

        Else
            MessageBox.Show(Me, "Select Filter by Date from the dropdown!")
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

    Protected Sub ExportReturnIcon_Click(sender As Object, e As EventArgs) Handles ExportReturnIcon.Click
        Response.Redirect("../export-data-return/")
    End Sub

    Protected Sub ExportPermitIcon_Click(sender As Object, e As EventArgs) Handles ExportPermitIcon.Click
        Response.Redirect("../export-permit/")
    End Sub

    Protected Sub ReportsIcon_Click(sender As Object, e As EventArgs) Handles ReportIcon.Click
        Response.Redirect("../reports/")
    End Sub

End Class