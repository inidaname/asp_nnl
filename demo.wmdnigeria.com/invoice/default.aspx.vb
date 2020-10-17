Imports System.Web
Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Web.Security
Imports System.Configuration
Imports MySql.Data.MySqlClient


Public Class _default10
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

            If Session("Login") = True And Session("UserLoginUserType") = "WMD Inspector" Then
                Response.Redirect("../wmd-inspector/")

            ElseIf Session("Login") = True And Session("UserLoginUserType") = "CPI Inspector" Then
                Response.Redirect("../cpi-inspector/")

            ElseIf Session("Login") = True And Session("UserLoginUserType") = "Calibrator" Then
                Response.Redirect("../calibrator/")

            ElseIf Session("Login") = True And Session("UserLoginUserType") = "Authorized Verifier" Then
                Response.Redirect("../authorized-verifier/")

            End If

        End If

        Registration.Text = "REGISTER"
        FilterBills.Focus()
        Session.Add("OrderID", OrderID())

        NoRecord.Visible = False
        ProcessingData.Visible = False

        If Not IsPostBack = True Then

            'Get all payment items
            Try

                ConnectDatabase()
                Dim AccountStatus As String = "0"
                Dim PaymentStatus As String = "Unpaid"

                Dim db As String = "SELECT * FROM payment WHERE CompanyID='" & Session("UserLoginID") & "' AND accStatus='" & AccountStatus & "' AND paymentStatus='" & PaymentStatus & "'"

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)

                        Dim dt As New DataTable()
                        Dim ds As New DataSet()
                        da.Fill(dt)
                        da.Fill(ds, "payment")

                        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                            NoRecord.Visible = True
                        Else
                            NoRecord.Visible = False
                        End If

                        PaymentGridView.DataSource = dt
                        PaymentGridView.DataMember = "payment"
                        PaymentGridView.DataBind()
                        Cache("PaymentData") = dt
                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
            End Try



            'Get Outstanding Bill from Database
            Try
                ConnectDatabase()
                Dim Outstanding As String
                Dim db As String = "SELECT *, SUM(amountDue) AS OutstandingBill FROM payment WHERE CompanyID='" & Session("UserLoginID") & "' AND accStatus='0' AND paymentStatus='Unpaid'"

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)

                        'Get the list of rows needed into Session, so as to enable us retreive it later

                        Dim dt As New DataTable()
                        Dim ds As New DataSet()
                        da.Fill(dt)
                        da.Fill(ds, "payment")

                        Outstanding = ds.Tables(0).Rows(0).Item("OutstandingBill").ToString

                        'This code does everything partaining wallet
                        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                            OutstandingBill.Text = "0.00"
                            OutstandingBill.ForeColor = Drawing.Color.Black

                        Else
                            Try
                                If Outstanding <= 0 Then
                                    OutstandingBill.Text = "0.00"
                                    OutstandingBill.ForeColor = Drawing.Color.Black
                                ElseIf Outstanding >= 1 Then
                                    OutstandingBill.ForeColor = Drawing.Color.DarkRed

                                    Try
                                        OutstandingBill.Text = FormatNumber(Outstanding, 2, TriState.False, , TriState.True)
                                    Catch ex As Exception
                                        MessageBox.Show(Me, "Only digits and/or a decimal please.")
                                    End Try

                                End If
                            Catch ex As Exception
                                MessageBox.Show(Me, ex.Message)
                            End Try

                        End If

                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
            End Try


            'Get Wallet Balance
            Try
                ConnectDatabase()
                Dim db As String = "SELECT * FROM wallet WHERE CompanyName='" & Session("UserLoginCompanyName") & "'"

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)

                        'Get the list of rows needed into Session, so as to enable us retreive it later

                        Dim dt As New DataTable()
                        Dim ds As New DataSet()
                        da.Fill(dt)
                        da.Fill(ds, "wallet")

                        Dim TotalBalance = ds.Tables(0).Rows(0).Item("totalBalance").ToString
                        Session.Remove("TotalBalance")
                        Session.Add("TotalBalance", TotalBalance)
                        'This code does everything partaining wallet

                        Try
                            If TotalBalance <= 0 Then
                                OutstandingBill.Text = "0.00"
                                WalletBalance.ForeColor = Drawing.Color.DarkRed
                            ElseIf TotalBalance >= 1 Then
                                WalletBalance.ForeColor = Drawing.Color.Black

                                Try

                                    WalletBalance.Text = FormatNumber(TotalBalance, 2, TriState.False, , TriState.True)
                                Catch ex As Exception
                                    MessageBox.Show(Me, "Only digits and/or a decimal please.")
                                End Try

                            End If
                        Catch ex As Exception
                            MessageBox.Show(Me, ex.Message)
                        End Try

                    End Using
                End Using

            Catch ex As Exception
                'MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
            End Try

        Else


        End If


    End Sub

    Protected Sub InvoiceGridView_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        InvoiceGridView.PageIndex = e.NewPageIndex
        InvoiceGridView.DataSource = CType(Cache("InvoiceData"), DataTable)
        InvoiceGridView.DataBind()

    End Sub


    Protected Sub PaymentGridView_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        PaymentGridView.PageIndex = e.NewPageIndex
        PaymentGridView.DataSource = CType(Cache("PaymentData"), DataTable)
        PaymentGridView.DataBind()

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
                'This code do the loggin magic
                
                Dim Activity As String = Session("UserLoginName") & " User logged out!"
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


    Protected Sub FilterInvoice_SelectedIndexChanged(sender As Object, e As EventArgs)

        If FilterInvoice.SelectedValue = "Paid" Then
            PaymentGridView.Visible = False
            InvoiceGridView.Visible = True
            DocumentTitle.Text = "BILLS PAID"
            PaySelected.Visible = False
            RechargeAccount.Visible = False

            'Get all Invoice Items
            Try

                ConnectDatabase()
                Dim AcctStatus = 1
                Dim PaymentStatus = "Paid"

                Dim db As String = "SELECT *,(amountDue-amountPaid) AS Balance, SUM(amountPaid) AS TotalAmountPaid FROM payment WHERE CompanyID='" & Session("UserLoginID") & "' AND accStatus='" & AcctStatus & "' AND paymentStatus='" & PaymentStatus & "' GROUP BY orderID"

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)

                        Dim dt As New DataTable()
                        Dim ds As New DataSet()
                        da.Fill(dt)
                        da.Fill(ds, "payment")

                        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                            NoRecord.Visible = True
                        Else
                            NoRecord.Visible = False
                        End If

                        For Each Row As DataRow In ds.Tables(0).Rows

                        Next

                        InvoiceGridView.DataSource = dt
                        InvoiceGridView.DataMember = "payment"
                        InvoiceGridView.DataBind()
                        Cache("InvoiceData") = dt
                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
            End Try

        ElseIf FilterInvoice.SelectedValue = "Outstanding" Then
            InvoiceGridView.Visible = False
            PaymentGridView.Visible = True
            DocumentTitle.Text = "OUTSTANDING BILLS"
            PaySelected.Visible = True
            RechargeAccount.Visible = True
            'Get all payment items
            Try

                ConnectDatabase()
                Dim AcctStatus = 0
                Dim PaymentStatus As String = "Unpaid"

                Dim db As String = "SELECT * FROM payment WHERE CompanyID='" & Session("UserLoginID") & "' AND accStatus='" & AcctStatus & "' AND paymentStatus='" & PaymentStatus & "'"

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)

                        Dim dt As New DataTable()
                        Dim ds As New DataSet()
                        da.Fill(dt)
                        da.Fill(ds, "payment")
                        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                            NoRecord.Visible = True
                        Else
                            NoRecord.Visible = False
                        End If
                        PaymentGridView.DataSource = dt
                        PaymentGridView.DataMember = "payment"
                        PaymentGridView.DataBind()
                        Cache("PaymentData") = dt
                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
            End Try


        End If
    End Sub


    Protected Sub TransactionType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TransactionType.SelectedIndexChanged
       If FilterInvoice.SelectedValue = "Paid" Then
            PaymentGridView.Visible = False
            InvoiceGridView.Visible = True
            DocumentTitle.Text = "BILLS PAID"
            PaySelected.Visible = False
            RechargeAccount.Visible = False

            'Get all Invoice Items
            Try

                ConnectDatabase()
                Dim AcctStatus = 1
                Dim PaymentStatus = "Paid"

                Dim db As String = "SELECT *,(amountDue-amountPaid) AS Balance, SUM(amountPaid) AS TotalAmountPaid FROM payment WHERE CompanyID='" & Session("UserLoginID") & "' AND accStatus='" & AcctStatus & "' AND paymentStatus='" & PaymentStatus & "' AND paymentFor='" & TransactionType.SelectedValue & "' GROUP BY orderID"

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)

                        Dim dt As New DataTable()
                        Dim ds As New DataSet()
                        da.Fill(dt)
                        da.Fill(ds, "payment")

                        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                            NoRecord.Visible = True
                        Else
                            NoRecord.Visible = False
                        End If
                        InvoiceGridView.DataSource = dt
                        InvoiceGridView.DataMember = "payment"
                        InvoiceGridView.DataBind()
                        Cache("InvoiceData") = dt
                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
            End Try

        ElseIf FilterInvoice.SelectedValue = "Outstanding" Then
            InvoiceGridView.Visible = False
            PaymentGridView.Visible = True
            DocumentTitle.Text = "OUTSTANDING BILLS"
            PaySelected.Visible = True
            RechargeAccount.Visible = True
            'Get all payment items
            Try

                ConnectDatabase()
                Dim AcctStatus = 0
                Dim PaymentStatus As String = "Unpaid"

                Dim db As String = "SELECT * FROM payment WHERE CompanyID='" & Session("UserLoginID") & "' AND accStatus='" & AcctStatus & "' AND paymentStatus='" & PaymentStatus & "' AND paymentFor='" & TransactionType.SelectedValue & "'"

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)

                        Dim dt As New DataTable()
                        Dim ds As New DataSet()
                        da.Fill(dt)
                        da.Fill(ds, "payment")
                        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                            NoRecord.Visible = True
                        Else
                            NoRecord.Visible = False
                        End If
                        PaymentGridView.DataSource = dt
                        PaymentGridView.DataMember = "payment"
                        PaymentGridView.DataBind()
                        Cache("PaymentData") = dt
                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
            End Try

        End If
    End Sub



    Protected Sub FilterBill_Click(sender As Object, e As EventArgs) Handles FilterBill.Click
        If FilterInvoice.SelectedValue = "Paid" Then
            PaymentGridView.Visible = False
            InvoiceGridView.Visible = True
            DocumentTitle.Text = "BILLS PAID"
            PaySelected.Visible = False
            RechargeAccount.Visible = False

            'Get all Invoice Items
            Try
                ConnectDatabase()
                Dim AcctStatus = 1
                Dim PaymentStatus = "Paid"

                Dim db As String = "SELECT *,(amountDue-amountPaid) AS Balance, SUM(amountPaid) AS TotalAmountPaid FROM payment WHERE CompanyID='" & Session("UserLoginID") & "' AND accStatus='" & AcctStatus & "' AND paymentStatus='" & PaymentStatus & "' AND paymentFor='" & TransactionType.SelectedValue & "' AND orderID LIKE '%" & FilterBills.Text & "%' GROUP BY orderID"

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)

                        Dim dt As New DataTable()
                        Dim ds As New DataSet()
                        da.Fill(dt)
                        da.Fill(ds, "payment")

                        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                            NoRecord.Visible = True
                        Else
                            NoRecord.Visible = False
                        End If

                        InvoiceGridView.DataSource = dt
                        InvoiceGridView.DataMember = "payment"
                        InvoiceGridView.DataBind()
                        Cache("InvoiceData") = dt
                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
            End Try

        ElseIf FilterInvoice.SelectedValue = "Outstanding" Then
            InvoiceGridView.Visible = False
            PaymentGridView.Visible = True
            DocumentTitle.Text = "OUTSTANDING BILLS"
            PaySelected.Visible = True
            RechargeAccount.Visible = True
            'Get all payment items
            Try

                ConnectDatabase()
                Dim AcctStatus = 0
                Dim PaymentStatus As String = "Unpaid"

                Dim db As String = "SELECT * FROM payment WHERE CompanyID='" & Session("UserLoginID") & "' AND accStatus='" & AcctStatus & "' AND paymentStatus='" & PaymentStatus & "' AND paymentFor='" & TransactionType.SelectedValue & "' AND transCode LIKE '%" & FilterBills.Text & "%'"

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)

                        Dim dt As New DataTable()
                        Dim ds As New DataSet()
                        da.Fill(dt)
                        da.Fill(ds, "payment")

                        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                            NoRecord.Visible = True
                        Else
                            NoRecord.Visible = False
                        End If
                        PaymentGridView.DataSource = dt
                        PaymentGridView.DataMember = "payment"
                        PaymentGridView.DataBind()
                        Cache("PaymentData") = dt
                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
            End Try

        End If
    End Sub

    Protected Sub PaymentSelection_CheckedChanged(sender As Object, e As EventArgs)
        For Each row As GridViewRow In PaymentGridView.Rows
            Dim CheckedBox As CheckBox = row.FindControl("PaymentSelector")
            If CheckedBox IsNot Nothing AndAlso CheckedBox.Checked Then
                Dim TotalAmountSelected As Integer = TotalAmountSelected + TryCast(row.Cells(2).FindControl("AmountDue"), Label).Text
                Session.Add("TotalAmountSelected", TotalAmountSelected)
                AddUp.Value = AddUp.Value + row.Cells(3).Text + ", "
                ''FilterBills.Text = PaymentDescription
                Session.Add("PaymentDescription", AddUp.Value)
                Session.Add("PaymentPurpose", AddUp.Value)
                MessageBox.Show(Me, "Selected!")
            End If

        Next
    End Sub

    Protected Sub PaySelected_Click(sender As Object, e As EventArgs) Handles PaySelected.Click
        For Each row As GridViewRow In PaymentGridView.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
                If isChecked Then

                    Try

                        ConnectDatabase()

                        Dim db As String = "SELECT *, SUM(amountDeposit) AS WalletBalance FROM deposits WHERE CompanyID='" & Session("UserLoginID") & "' AND confirmed='1' AND approvalStatus='Approved'"

                        Using cn As MySqlCommand = New MySqlCommand(db, conn)
                            Using da As New MySqlDataAdapter(cn)

                                'Get the list of rows needed into Session, so as to enable us retreive it later
                                Dim dt As New DataTable()
                                Dim ds As New DataSet()
                                da.Fill(dt)
                                da.Fill(ds, "deposits")
                                Dim TransactionID As String = row.Cells(5).Text
                                Dim AmountDue As Decimal = TryCast(row.Cells(2).FindControl("AmountDue"), Label).Text 'row.Cells(2).Text .Replace(",", "")
                                Dim Narration As String = row.Cells(3).Text
                                Dim PaymentState As String = row.Cells(4).Text
                                Dim InvoiceDate As String = row.Cells(1).Text
                                Dim WalletAmount As String
                                WalletAmount = ds.Tables(0).Rows(0).Item("WalletBalance").ToString
                                If Not WalletAmount = "" Then
                                    WalletAmount = Decimal.Parse(WalletAmount)
                                End If
                                'Check if Amount or Balance in Deposit is thesame with Wallet Balance
                                If Session("TotalBalance") > 0 Then

                                    If Session("TotalBalance") = AmountDue Or Session("TotalBalance") > AmountDue Then
                                        Dim WalletBalanceAfterDeduction = Session("TotalBalance") - Session("TotalAmountSelected")
                                        'Update Payment Table

                                        Dim cmd As New MySqlCommand("UPDATE payment SET accStatus = @AccountStatus, amountPaid = @AmountPaid, paymentMode = @Mode, paymentDate = @Date, paymentYear = @Year, paymentTime = @Time, paymentStatus = @Status, orderID = @InvoiceNumber, walletBallance = @WalletBallanceAfterPayment, paymentDescription = @PaymentDescription WHERE companyID = @CompanyID AND transCode = @ReferenceCode")
                                        cmd.Connection = conn
                                        Dim AmountPaid = row.Cells(2).Text.Replace(",", "")

                                        cmd.Parameters.AddWithValue("@AccountStatus", "1")
                                        cmd.Parameters.AddWithValue("@AmountPaid", AmountDue)
                                        cmd.Parameters.AddWithValue("@Mode", "Wallet")
                                        cmd.Parameters.AddWithValue("@Date", TodaysDate())
                                        cmd.Parameters.AddWithValue("@Year", Today.Year())
                                        cmd.Parameters.AddWithValue("@Time", CurrentTim())
                                        cmd.Parameters.AddWithValue("@Status", "Paid")
                                        cmd.Parameters.AddWithValue("@InvoiceNumber", Session("OrderID"))
                                        cmd.Parameters.AddWithValue("@CompanyID", Session("UserLoginID"))
                                        cmd.Parameters.AddWithValue("@ReferenceCode", row.Cells(5).Text)
                                        cmd.Parameters.AddWithValue("@WalletBallanceAfterPayment", WalletBalanceAfterDeduction)
                                        cmd.Parameters.AddWithValue("@PaymentDescription", Session("PaymentDescription"))
                                        cmd.ExecuteNonQuery()
                                        'Update Wallet Balance
                                        Dim strSQLs As String
                                        strSQLs = "UPDATE wallet SET totalBalance='" & WalletBalanceAfterDeduction & "' WHERE companyName='" & Session("UserLoginCompanyName") & "'"
                                        Dim cmds As New MySqlCommand(strSQLs, conn)
                                        cmds.ExecuteNonQuery()

                                        Dim NoDelete = 1
                                        'Update the instrument table with the information
                                        Dim cmdv As New MySqlCommand
                                        cmdv.Connection = conn
                                        cmdv.CommandText = "UPDATE deviceregistration SET NoDelete='" & NoDelete & "' WHERE transCode='" & row.Cells(5).Text & "'"
                                        cmdv.ExecuteNonQuery()


                                        'Update device renewal table with the information
                                        Dim RenewalStatus = 1
                                        Dim cmdd As New MySqlCommand
                                        cmdd.Connection = conn
                                        cmdd.CommandText = "UPDATE devicerenewal SET renewalStatus='" & RenewalStatus & "' WHERE deviceReference='" & row.Cells(5).Text & "'"
                                        cmdd.ExecuteNonQuery()

                                        Dim TotalAmountPaid = row.Cells(2).Text

                                        WalletBalanceAfterDeduction = FormatNumber(WalletBalanceAfterDeduction, 2, TriState.False, , TriState.True)

                                        MessageBox.Show(Me, "Payment successful!  Wallet balance:  " & WalletBalanceAfterDeduction)
                                        'Send SMS Message
                                        tools.SendSMS(Me, GetSMSAPI(), GetSMSUsername(), GetSMSPassword(), BulkSMSDefaultSender(), SMSRecipientNumber(), BillingMessage())

                                        'Send email to user after application
                                        Dim InvoiceNumber = Session("OrderID")
                                        Dim InvoiceCompanyName = Session("UserLoginCompanyName")
                                        Dim InvoiceUsername = Session("UserLoginName")
                                        Dim CompanyAddress = Session("UserLoginCompanyAddress")
                                        Dim Amount = AmountDue
                                        Dim Total = Session("TotalAmountSelected")
                                        Amount = FormatNumber(Amount, 2, TriState.False, , TriState.True)
                                        Total = FormatNumber(Total, 2, TriState.False, , TriState.True)
                                        Dim Purpose = Session("PaymentDescription")

                                        Dim Subject = "INVOICE"
                                        'Dim Message = "Your Online Registration with Federal Ministry of Industry, Trade and Investment was successful. <div style=''><p> Below are your registration details:<p> <strong> Username: </strong>" + Username.Text + "<p> <strong> Company Name: </strong>" + CompanyName.Text + " <p> Kindly click the button below to login to your account.<p style='margin-top:50px;'> <strong>Thank you.</strong>"
                                        Dim Message = "<div style='width:620px;font-size:15px;background:rgb(255,255, 255);'><div style='padding-left:10px; width:590px;'><h4 style='padding:10px 0px;font-size:23px;width:100%;text-align:center;margin-top:-10px;'>" & Subject & "</span></h4> <h4 style='padding:10px 0px;font-size:17px;'><span style='float:right;font-size:13px;'>" + Date.Now + " </span></h4><div style='margin-bottom:10px;display:block;height:169px; width:100%;'><div style='width:45%;float:left;'><div style='font-weight:bolder;font-size:17px;padding:5px 0px;'>CLIENT DETAIL</div><p style='font-weight:bolder;font-size:15px;'>" + InvoiceCompanyName + " (" + InvoiceUsername + ")  </p><p style='font-weight:bolder;font-size:15px;'>" + CompanyAddress + "</p></div><div style='width:45%;float:right;'><div style='font-weight:bolder;font-size:17px;padding:5px 0px;'>ACCOUNT DETAIL</div><p style='font-weight:bolder;font-size:13px;'>ACCOUNT NAME: <span style='font-weight:normal;'>FEDERAL MINISTRY OF INDUSTRY, TRADE AND INVESTMENT WEIGHTS AND MEASURES DEPARTMENT</span></p><p style='font-weight:bolder;font-size:13px;'>ACCOUNT NUMBER: <span style='font-weight:normal;'>1750013688</span></p><p style='font-weight:bolder;font-size:13px;'>BANK NAME: <span style='font-weight:normal;'>SKYE BANK</span></p></div></div><div style='font-weight:bolder;font-size:17px;padding:5px 0px;'>INVOICE ITEM(S)</div><div style='width:69%;display:inline-block;font-weight:bolder;padding:10px 0px;border-bottom:1px solid rgb(200,200,200);color:rgb(100,100,100);'>Summary</div><div style='width:30%;display:inline-block;text-align:right;font-weight:bolder;padding:10px 0px;0px;border-bottom:1px solid rgb(200,200,200);color:rgb(100,100,100);'>Amount</div><div style='width:69%;display:inline-block;padding:10px 0px;'>" + Purpose + "</div><div style='width:30%;display:inline-block;text-align:right;padding:10px 0px;'>" + Amount + "</div><div style='width:100%;display:inline-block;padding:20px 0px;margin-left:-10px;padding-right:1px;text-align:right;font-weight:bolder;background:rgb(250,250,250);font-size:17px;'>Total: <span style='float:right;margin-left:50px;margin-right:0px;'>N" + Total + "</span></div></div><p><div style='margin-top:0px;width:600px;height:auto;padding:10px;color:rgb(20,20,20);text-align:left;font-size:13px;background:rgb(255,255,255);'><strong>PLEASE NOTE: </strong> <P>ALL BANK DEPOSIT MUST BE MADE WITH THE USERNAME NAME AS THE DEPOSITOR.<P>ALL PAYMENT(S) MADE ARE NON-REFUNDABLE.</div><p><a href='http://www.wmdnigeria.com/' style='text-decoration:none;width:auto;color:rgb(255,255,255);'><div style='margin-bottom:10px;padding: 5px 10px;width:100px;font-size: 14px;font-weight: bolder;line-height: 20px;text-align: center;cursor: pointer;border: 1px solid transparent;border-radius: 4px;background:rgb(54,127,169);color:rgb(255, 255, 255);'>Login Now</div> </div>"
                                        'Dim Message = "Your Export Permit Application on Federal Ministry of Industry, Trade and Investment Weights and Measures Department Web Portal was successful. <div style=''><p> Below are the Export Permit Application Details:<p> <strong> Reference Number: </strong>" + ExportReferenceCode + "<p> <strong> Company Name: </strong>" + Session("UserLoginCompanyName") + "<p> <strong> Permit Quarter : </strong>" + PermitQuarters.SelectedItem.Text + "<p> <strong> Exporter Name: </strong>" + ExporterName.Text + "<p> <strong> Export Quantity: </strong>" + ExportQuantity.Text + "<p> <strong> Amount Per Barrel: </strong>" + AmountPerBarrel.Text + "<p> <strong> Total Amount: </strong>" + FOBValue.Text + " <p> Kindly click the button below to login to your account.<p style='margin-top:50px;'> <strong>Thank you.</strong>"
                                        Dim MessageBody = "<html><head></head><body style='font-family:Tahoma; width:620px;font-size:13px;background:rgb(240,240, 240)'><div style='width:600px;height:70px;padding:10px;color:rgb(255, 255, 255);font-weight:bolder;text-align:center;font-size:20px;background:rgb(54,127,169);'><img src='http://www.wmdnigeria.com/images/coatofarm.png' width='70px' height='70px' align='left' style='margin-top:-10px;padding:0px;' /><p>Federal Ministry of Industry Trade and Investment <br><span style='font-size:17px;'>Commodities and Products Inspectorate Department (CPI)</span></div><div style='width:600px;font-size:13px;color:rgb(100,100,100);'><p> <div style='padding-left:10px; width:590px;'> <p>" & Message & "</div></div>           <p><div style='margin-top:100px;width:600px;height:auto;padding:10px;color:rgb(255, 255, 255);text-align:center;font-size:13px;background:rgb(54,127,169);'><strong>NOTICE: </strong>  The content of this e-mail is intended solely for the use of the individual or entity to whom it is addressed. If you have received this communication in error, beware that forwarding it, copying it or in any way disclosing its content to any other person or persons, is strictly prohibiting. If you have received this communication in error, please notify the author by replying this e-mail immediately.</div></body></html>"

                                        clsNotify.SendEmail(Session("UserLoginCompanyEmail"), Subject, MessageBody, AccountEmail(), True)

                                        'This code do the loggin magic
                                        Dim Activity As String = Session("UserLoginCompanyName") & " paid " & TotalAmountPaid & " being payment for " & Narration
                                        Dim comm As New MySqlCommand
                                        comm.Connection = conn
                                        comm.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("UserLoginID") & "','" & Activity & "','" & Session("UserLoginIPAddress") & "','" & ComputerName & "','" & osVersion() & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("UserLoginUserType") & "')"
                                        comm.ExecuteNonQuery()

                                        Response.AppendHeader("Refresh", "0;url=./")

                                    Else
                                        MessageBox.Show(Me, "You cannot pay for this invoice, not enough money in your account, please recharge your account and try again!")

                                    End If
                                Else
                                    MessageBox.Show(Me, "Your wallet is empty, you can not make payment, click on recharge my account to view your deposit record!")
                                End If


                            End Using
                        End Using

                    Catch ex As Exception
                        MessageBox.Show(Me, ex.Message)
                    Finally
                        DisconnectDatabase()
                    End Try
                Else
                    MessageBox.Show(Me, "Payment can not be made, no item is selected!")
                End If
            End If
        Next

    End Sub


    Protected Sub OnInvoiceSelectedIndexChanged(sender As Object, e As EventArgs)
        Dim OrderID As String = InvoiceGridView.SelectedRow.Cells(0).Text
        Response.Redirect("./invoice-printable/?/invoice/=" + OrderID)
        
    End Sub

    Protected Sub RechargeAccount_Click(sender As Object, e As EventArgs) Handles RechargeAccount.Click
        Response.Redirect("../deposit/")
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