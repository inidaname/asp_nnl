Imports System.Web
Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Data.OleDb
Imports System.Web.Security
Imports System.Configuration
Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography

Public Class _default20
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
            ApproveORDisapproveTab.Visible = True

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
                        SelectCompany.Items.Insert(0, "None")

                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
            End Try

            Try

                ConnectDatabase()
                Dim db As String = "SELECT * FROM deposits"

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)

                        'Get the list of rows needed into Session, so as to enable us retreive it later

                        Dim dt As New DataTable()
                        Dim ds As New DataSet()
                        da.Fill(dt)
                        da.Fill(ds, "deposits")

                        DepositPaymentGridView.DataSource = ds
                        DepositPaymentGridView.DataMember = "deposits"
                        DepositPaymentGridView.DataBind()

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

    Protected Sub SelectPaymentType_SelectedIndexChanged(Sender As Object, e As EventArgs)
        If SelectPayment.SelectedValue = "Deposit" Then
            If SelectCompany.SelectedItem.Text = "None" And AprrovedWaiting.SelectedValue = "None" Then
                Try

                    ConnectDatabase()

                    Dim db As String = "SELECT * FROM deposits ORDER BY ID DESC"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)

                            'Get the list of rows needed into Session, so as to enable us retreive it later

                            Dim dt As New DataTable()
                            Dim ds As New DataSet()
                            da.Fill(dt)
                            da.Fill(ds, "deposits")

                            If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                NoRecord.Visible = True
                            Else
                                NoRecord.Visible = False
                            End If
                            DepositPaymentGridView.DataSource = ds
                            DepositPaymentGridView.DataMember = "deposits"
                            DepositPaymentGridView.DataBind()



                        End Using
                    End Using

                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                Finally
                    DisconnectDatabase()
                End Try

            Else

                Try

                    ConnectDatabase()

                    Dim db As String = "SELECT * FROM deposits WHERE companyName='" & SelectCompany.SelectedItem.Text & "' AND approvalStatus='" & AprrovedWaiting.SelectedValue & "' ORDER BY ID DESC"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)

                            'Get the list of rows needed into Session, so as to enable us retreive it later

                            Dim dt As New DataTable()
                            Dim ds As New DataSet()
                            da.Fill(dt)
                            da.Fill(ds, "deposits")

                            If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                NoRecord.Visible = True
                            Else
                                NoRecord.Visible = False
                            End If
                             
                            DepositPaymentGridView.DataSource = ds
                            DepositPaymentGridView.DataMember = "deposits"
                            DepositPaymentGridView.DataBind()



                        End Using
                    End Using

                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                Finally
                    DisconnectDatabase()
                End Try
            End If

        

        End If


    End Sub



    Protected Sub SelectCompany_SelectedIndexChanged(Sender As Object, e As EventArgs)
        If SelectPayment.SelectedValue = "Deposit" And SelectCompany.SelectedItem.Text = "None" And AprrovedWaiting.SelectedValue = "None" Then
            Try

                ConnectDatabase()

                Dim db As String = "SELECT * FROM deposits ORDER BY ID DESC "

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)
                        Dim dt As New DataTable()
                        Dim ds As New DataSet()
                        da.Fill(dt)
                        da.Fill(ds, "deposits")
                        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                            NoRecord.Visible = True
                        Else
                            NoRecord.Visible = False
                        End If
                        DepositPaymentGridView.DataSource = ds
                        DepositPaymentGridView.DataMember = "deposits"
                        DepositPaymentGridView.DataBind()
                    End Using
                End Using

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                DisconnectDatabase()
            End Try

        ElseIf SelectPayment.SelectedValue = "Deposit" And SelectCompany.SelectedItem.Text = "None" And Not AprrovedWaiting.SelectedValue = "None" Then
            Try

                ConnectDatabase()

                Dim db As String = "SELECT * FROM deposits WHERE approvalStatus='" & AprrovedWaiting.SelectedValue & "' ORDER BY ID DESC "
                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)
                        Dim dt As New DataTable()
                        Dim ds As New DataSet()
                        da.Fill(dt)
                        da.Fill(ds, "deposits")

                        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                            NoRecord.Visible = True
                        Else
                            NoRecord.Visible = False
                        End If
                         
                        DepositPaymentGridView.DataSource = ds
                        DepositPaymentGridView.DataMember = "deposits"
                        DepositPaymentGridView.DataBind()
 
                    End Using
                End Using

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                DisconnectDatabase()
            End Try

        ElseIf SelectPayment.SelectedValue = "Deposit" And Not SelectCompany.SelectedItem.Text = "None" And AprrovedWaiting.SelectedValue = "None" Then
            Try

                ConnectDatabase()

                Dim db As String = "SELECT * FROM deposits WHERE companyName='" & SelectCompany.SelectedItem.Text & "' ORDER BY ID DESC "

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)
                        Dim dt As New DataTable()
                        Dim ds As New DataSet()
                        da.Fill(dt)
                        da.Fill(ds, "deposits")

                        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                            NoRecord.Visible = True
                        Else
                            NoRecord.Visible = False
                        End If
 
                        DepositPaymentGridView.DataSource = ds
                        DepositPaymentGridView.DataMember = "deposits"
                        DepositPaymentGridView.DataBind()
 
                    End Using
                End Using

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                DisconnectDatabase()
            End Try

        ElseIf SelectPayment.SelectedValue = "Deposit" And SelectCompany.SelectedItem.Text = "None" And Not AprrovedWaiting.SelectedValue = "None" Then
            Try

                ConnectDatabase()

                Dim db As String = "SELECT * FROM deposits WHERE approvalStatus='" & AprrovedWaiting.SelectedValue & "' AND companyName='" & SelectCompany.SelectedItem.Text & "'  ORDER BY ID DESC "

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)
                        Dim dt As New DataTable()
                        Dim ds As New DataSet()
                        da.Fill(dt)
                        da.Fill(ds, "deposits")

                        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                            NoRecord.Visible = True
                        Else
                            NoRecord.Visible = False
                        End If
                         
                        DepositPaymentGridView.DataSource = ds
                        DepositPaymentGridView.DataMember = "deposits"
                        DepositPaymentGridView.DataBind()
                    End Using
                End Using

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        ElseIf SelectPayment.SelectedValue = "Deposit" Then
            Try

                ConnectDatabase()

                Dim db As String = "SELECT * FROM deposits WHERE companyName='" & SelectCompany.SelectedItem.Text & "' AND approvalStatus='" & AprrovedWaiting.SelectedValue & "'  ORDER BY ID DESC "

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)
                        Dim dt As New DataTable()
                        Dim ds As New DataSet()
                        da.Fill(dt)
                        da.Fill(ds, "deposits")

                        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                            NoRecord.Visible = True
                        Else
                            NoRecord.Visible = False
                        End If
                         
                        DepositPaymentGridView.DataSource = ds
                        DepositPaymentGridView.DataMember = "deposits"
                        DepositPaymentGridView.DataBind()
                    End Using
                End Using

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If


    End Sub

    Dim CompanyNameCell, TransactionIDCell As String

    Protected Sub OnDepositSelectedIndexChanged(sender As Object, e As EventArgs)

        Try
            TransactionIDCell = DepositPaymentGridView.SelectedRow.Cells(1).Text
            'ApproveORDisapproveTab.Visible = True
            Approve.Checked = False
            Reject.Checked = False

            ConnectDatabase()
            Dim dbu As String = "SELECT * FROM deposits WHERE transactionID='" & TransactionIDCell & "' "
            Using cnu As MySqlCommand = New MySqlCommand(dbu, conn)
                Using dau As New MySqlDataAdapter(cnu)
                    Dim dtm As New DataTable
                    dau.Fill(dtm)
                    Dim dsm As New DataSet
                    dau.Fill(dsm)

                    CompanyName.Text = dsm.Tables(0).Rows(0).Item("companyName").ToString
                    TransactionAmount.Text = FormatNumber(dsm.Tables(0).Rows(0).Item("amountDeposit").ToString, 2, TriState.False, , TriState.True)
                    OrderID.Text = dsm.Tables(0).Rows(0).Item("orderID").ToString
                    PaymentType.Text = dsm.Tables(0).Rows(0).Item("paymentMode").ToString
                    TransactionID.Text = dsm.Tables(0).Rows(0).Item("transactionID").ToString
                    Dim ApprovalStatus = dsm.Tables(0).Rows(0).Item("approvalStatus").ToString
                    Dim Confirmed = dsm.Tables(0).Rows(0).Item("confirmed").ToString

                    Session.Remove("ApprovalConfirmed")
                    Session.Remove("ApprovalStatus")
                    Session.Add("ApprovalConfirmed", Confirmed)
                    Session.Add("ApprovalStatus", ApprovalStatus)

                    If Confirmed = "1" And ApprovalStatus = "Approved" Then
                        ApprovedOrNot.Checked = True
                    Else
                        ApprovedOrNot.Checked = False

                    End If
                    Narration.Text = dsm.Tables(0).Rows(0).Item("approvalNarration").ToString

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)
        End Try




    End Sub


    Sub ApprovalCheck_OnCheckedChanged(Sender As Object, e As EventArgs)

        If Approve.Checked = True Then
            ApprovedOrNot.Checked = True
            Narration.Text = "Confirmed and Approved"
        ElseIf Reject.Checked = True Then
            ApprovedOrNot.Checked = False
            Narration.Text = "Rejected!"
        End If


    End Sub


    Protected Sub SaveRecord_Click(sender As Object, e As EventArgs) Handles SaveRecord.Click


        If SelectPayment.SelectedValue = "Deposit" Then

            Try
                ConnectDatabase()
                Dim ApproveCheck = ""
                Dim RejectCheck = ""
                Dim Confirmed
                If ApprovedOrNot.Checked = True Then
                    ApproveCheck = "Approved"
                    Confirmed = "1"
                Else
                    ApproveCheck = "Waiting"
                    Confirmed = "0"
                End If

                'Update deposits table
                Dim strSQL As String
                strSQL = "UPDATE deposits SET approvalStatus='" & ApproveCheck & "', confirmed='" & Confirmed & "', approvalNarration='" & Narration.Text & "' WHERE companyName= '" & CompanyName.Text & "' AND transactionID ='" & TransactionID.Text & "'"
                Dim cmd As New MySqlCommand(strSQL, conn)
                cmd.ExecuteNonQuery()


                If ApprovedOrNot.Checked = True Then

                    'Select from Wallet Table
                    Dim MyAdapter As New MySqlDataAdapter

                    Dim SqlQuery = "SELECT * FROM wallet WHERE companyName= '" & CompanyName.Text & "';"

                    Dim Command As New MySqlCommand
                    Command.Connection = conn
                    Command.CommandText = SqlQuery
                    MyAdapter.SelectCommand = Command

                    Dim reader As MySqlDataReader

                    reader = Command.ExecuteReader
                    'Check if the credentials provided is in the database
                    If reader.HasRows = 0 Then

                        reader.Close()
                        'Insert Approved Deposit into Wallet into Wallet
                        Dim com As New MySqlCommand
                        com.Connection = conn
                        com.CommandText = "INSERT INTO wallet (companyName,totalBalance) VALUES ('" & CompanyName.Text & "','" & TransactionAmount.Text & "')"
                        com.ExecuteNonQuery()
                    Else
                        reader.Close()

                        'If ApprovedOrNot.Checked = True Then

                        If Session("ApprovalConfirmed") = "1" And Session("ApprovalStatus") = "Approved" Then

                            'Don't add the money into the Wallet if the deposit has already been approved before.
                            'MessageBox.Show(Me, "This deposit has been saved before!")
                             MessageBox.Show(Me, "This deposit has been approved before, becareful with what you do, so as to avoid loss!")
                        Else
                            Try
                                ConnectDatabase()
                                'Select Current Total Balance in in Wallet
                                Dim db As String = "SELECT * FROM wallet WHERE companyName= '" & CompanyName.Text & "'"
                                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                                    Using da As New MySqlDataAdapter(cn)

                                        Dim ds As New DataSet()
                                        da.Fill(ds)

                                        Dim WalletBalance = ds.Tables(0).Rows(0).Item("totalBalance").ToString

                                        Dim TotalBalance As Decimal = Decimal.Parse(TransactionAmount.Text) + Decimal.Parse(WalletBalance)

                                        'Update Wallet Balance
                                        Dim strSQLs As String
                                        strSQLs = "UPDATE wallet SET totalBalance='" & TotalBalance & "' WHERE companyName='" & CompanyName.Text & "'"
                                        Dim cmds As New MySqlCommand(strSQLs, conn)
                                        cmds.ExecuteNonQuery()

                                    End Using
                                End Using

                            Catch ex As Exception
                                MessageBox.Show(Me, ex.Message)
                            Finally
                                DisconnectDatabase()
                                reader.Close()
                            End Try

                        End If


                    End If

                    MessageBox.Show(Me, "Deposit has been approved succesffuly!")

                Else
                    MessageBox.Show(Me, "Deposit has been saved successfully!")

                End If
                 
                Dim Activity As String = Session("LoggedInAdminLoginUsername") & "  approve " & SelectCompany.SelectedItem.Text & " , deposit of  " & TransactionAmount.Text & "     (" & TransactionID & ")"
                Dim coms As New MySqlCommand
                coms.Connection = conn
                coms.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("UserLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                coms.ExecuteNonQuery()


            Catch ex As Exception

                MessageBox.Show(Me, ex.Message)

            Finally
                DisconnectDatabase()

            End Try

            Session.Remove("ApprovalConfirmed")
            Session.Remove("ApprovalStatus")

            CompanyName.Text = ""
            TransactionAmount.Text = ""
            OrderID.Text = ""
            PaymentType.Text = ""
            TransactionID.Text = ""
            Narration.Text = ""
            Approve.Checked = False
            Reject.Checked = False
            ApprovedOrNot.Checked = False
             

        ElseIf SelectPayment.SelectedValue = "Payment" Then

            If Session("PaymentPaymentStatus") = "Paid" Then
                If ApprovedOrNot.Checked = True Then
                    'Update Payment Table
                    Try
                        ConnectDatabase()
                        Dim ApprovalStatus = "Approved"
                        Dim LoggedName = Session("LoggedInAdminLoginSurName") & " " & Session("LoggedInAdminLoginOtherNames")
                        Dim strSQL As String
                        strSQL = "UPDATE payment SET approvalStatus='" & ApprovalStatus & "', approvalNarration='" & Narration.Text & "', approvalDate='" & TodaysDate() & "', approvalTime ='" & CurrentTim() & "', approvedBy ='" & LoggedName & "' WHERE transCode ='" & TransactionID.Text & "' AND orderId='" & OrderID.Text & "'"
                        Dim cmd As New MySqlCommand(strSQL, conn)
                        cmd.ExecuteNonQuery()

                        MessageBox.Show(Me, "Selected payment updated successfully!")

                    Catch ex As Exception
                        MessageBox.Show(Me, ex.Message)
                    Finally
                        DisconnectDatabase()
                    End Try
                Else
                    MessageBox.Show(Me, "Changes made to Selected payment saved successfully!")

                End If

            Else
                MessageBox.Show(Me, "You cannot approve an unpaid invoice!")

            End If

            End If
            Page.Response.AppendHeader("Refresh", "3; url=Login/Login.aspx")
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