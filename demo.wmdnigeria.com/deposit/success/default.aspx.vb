Imports System.Web
Imports System.IO
Imports System.Net
Imports System.Xml
Imports System.Data
Imports System.Text
Imports System.Xml.XPath
Imports System.Data.OleDb
Imports System.Web.Security
Imports System.Configuration
Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography

Public Class _default38
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

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

        If Session("Login") = True And Session("UserLoginUserType") = "WMD Inspector" Then
            Response.Redirect("../wmd-inspector/")

        ElseIf Session("Login") = True And Session("UserLoginUserType") = "CPI Inspector" Then
            Response.Redirect("../cpi-inspector/")

        ElseIf Session("Login") = True And Session("UserLoginUserType") = "Calibrator" Then
            Response.Redirect("../calibrator/")

        ElseIf Session("Login") = True And Session("UserLoginUserType") = "Authorized Verifier" Then
            Response.Redirect("../authorized-verifier/")

        End If


    End Sub

    Protected Sub OnlinePaymentHistory_Click(sender As Object, e As EventArgs) Handles OnlinePaymentHistory.Click
        Response.Redirect("https://skyecipg.skyebankng.com/MerchantCustomerView/MerchantCustomerReport.aspx?email=" + Session("UserLoginCompanyEmail") + "&mercID=04225")
    End Sub

    Protected Sub GoToDepositPage_Click(sender As Object, e As EventArgs) Handles GoToDepositPage.Click
        Response.Redirect("../")
    End Sub



    Private Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete

        'Online payment API Integration 
        Dim TransactionResponse As String = String.Empty
        If Not String.IsNullOrEmpty(Request.QueryString("OrderID")) And Not String.IsNullOrEmpty(Request.QueryString("TransactionReference")) Then

            ' Access the value in GET
            Dim ReturnedOrderID = Request.QueryString("OrderID")
            Dim TransactionReference = Request.QueryString("TransactionReference")
            Dim TransactionAmount = String.Empty

            Dim OrderIDD = String.Empty
            Dim Status = String.Empty
            Dim Amount = String.Empty
            Dim Dates = String.Empty
            Dim TransactionRef = String.Empty
            Dim PaymentRef = String.Empty
            Dim PaymentGateway = String.Empty
            Dim ResponseDescription = String.Empty

            If Not ReturnedOrderID = "" And Not TransactionReference = "" Then

                Try
                    ConnectDatabase()
                    Dim db As String = "SELECT * FROM deposits WHERE CompanyID='" & Session("UserLoginID") & "' AND orderID='" & ReturnedOrderID & "'"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)
                            Dim dt As New DataTable()
                            Dim ds As New DataSet()
                            da.Fill(ds, "deposits")
                            TransactionAmount = ds.Tables(0).Rows(0).Item("amountDeposit").ToString
                        End Using
                    End Using

                    Try
                        'Get Client Online Payment Status
                        Dim client As WebClient = New WebClient()
                        Dim URL As String = "https://skyecipg.skyebankng.com/MerchantServices/TransactionStatusCheck.ashx?MERCHANT_ID=04225&ORDER_ID=" + ReturnedOrderID + "&CURR_CODE=566&AMOUNT=" + TransactionAmount + ""

                        TransactionResponse = client.DownloadString(URL)
                    Catch e1 As WebException
                        TransactionResponse = e1.Message
                    Catch e2 As Exception
                        TransactionResponse = e2.Message
                    Finally

                        Try

                            Dim xmlReader As XmlReader = xmlReader.Create(New StringReader(TransactionResponse))
                            xmlReader.Read()
                            While xmlReader.Read()
                                'Dim strReader As String = xmlReader.Value
                                If xmlReader.Name = "OrderID" Then
                                    OrderIDD = xmlReader.ReadString()
                                End If
                                If xmlReader.Name = "Status" Then
                                    Status = xmlReader.ReadString()
                                End If
                                If xmlReader.Name = "Amount" Then
                                    Amount = xmlReader.ReadString()
                                End If
                                If xmlReader.Name = "TransactionRef" Then
                                    TransactionRef = xmlReader.ReadString()
                                End If
                                If xmlReader.Name = "PaymentRef" Then
                                    PaymentRef = xmlReader.ReadString()
                                End If
                                If xmlReader.Name = "PaymentGateway" Then
                                    PaymentGateway = xmlReader.ReadString()
                                End If

                            End While

                            If Status = "Successful" And Amount = Amount Then
                                Dim ApprovalStatus = "Approved"
                                Dim Confirmed = 1
                                Dim Narration = "Approved through Interswitch online payment gateway"
                                Dim strSQLs As String
                                strSQLs = "UPDATE deposits SET transactionReference='" & TransactionReference & "',paymentReference='" & PaymentRef & "',approvalStatus='" & ApprovalStatus & "',confirmed='" & Confirmed & "',approvalNarration='" & Narration & "',paymentGateway='" & PaymentGateway & "' WHERE companyName='" & Session("UserLoginCompanyName") & "' AND orderID='" & ReturnedOrderID & "'"
                                Dim cmds As New MySqlCommand(strSQLs, conn)
                                cmds.ExecuteNonQuery()

                                TransactionReferenceText.Text = TransactionRef
                                PaymentRefrence.Text = PaymentRef
                                AmountPaid.Text = Amount
                                OrderID.Text = ReturnedOrderID
                                PaymentReceipt.Text = "A copy of the receipt for this payment has been sent to your email (" + Session("UserLoginCompanyEmail") + ")."


                            Else
                                Response.Redirect("../?TransactionReference=" + TransactionReference + "&OrderID=" + ReturnedOrderID)

                            End If

                        Catch errorVariable As Exception
                            MessageBox.Show(Me, errorVariable.ToString())


                        End Try

                    End Try

                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                Finally
                    DisconnectDatabase()

                End Try

            End If
        Else
            Response.Redirect("../")
        End If
    End Sub
End Class