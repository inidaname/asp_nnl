Imports System.Net
Imports System.Web
Imports System.Xml
Imports System.Data
Imports System.Text
Imports System.Web.Security
Imports System.Globalization
Imports System.Configuration
Imports MySql.Data.MySqlClient
Imports System.Collections.Generic
Imports System.Security.Cryptography
Imports System.Web.Script.Serialization
Imports System.Web.Services

Public Class _default13
    Inherits System.Web.UI.Page

    Dim SelectedInstrumentSerialNo As String
    Dim OrderNumber = ""

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
        NoRecord.Visible = False
        ProcessingData.Visible = False

        MessageBox.Show(Me, Session("SelectedInstrumentCode"))
        If Not Session("SelectedInstrumentCode") = "" Then
            Try
                ConnectDatabase()

                Dim db As String = "SELECT * FROM deviceservices WHERE CompanyID='" & Session("UserLoginID") & "' AND transCode='" & Session("SelectedInstrumentCode") & "'"

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)

                        'Get the list of rows needed into Session, so as to enable us retreive it later

                        Dim dt As New DataTable()
                        Dim ds As New DataSet()
                        da.Fill(dt)
                        da.Fill(ds, "deviceservices")

                        InstrumentName.Text = ds.Tables(0).Rows(0).Item("deviceTypeAndNumber").ToString
                        CompanyName.Text = ds.Tables(0).Rows(0).Item("companyName").ToString
                        InstrumentServiceGroup.Text = ds.Tables(0).Rows(0).Item("serviceGroup").ToString

                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            End Try

                
            End If

        If Not IsPostBack = True Then
            RegisterService.Visible = True
            ContinueRegistration.Visible = False
            OrderNumber = OrderID()
            Try
                ConnectDatabase()

                'Dim db As String = "SELECT deviceType, concat(deviceType,' : SN ',serialNumber) As Instrument FROM deviceregistration WHERE CompanyID='" & Session("UserLoginID") & "'"
                Dim db As String = "SELECT deviceType FROM deviceregistration WHERE CompanyID='" & Session("UserLoginID") & "' GROUP BY deviceType ORDER BY deviceType"
                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)

                        'Get the list of rows needed into Session, so as to enable us retreive it later
                        Dim dt As New DataTable()
                        da.Fill(dt)

                        SelectInstrument.DataSource = dt
                        SelectInstrument.DataTextField = "deviceType"
                        SelectInstrument.DataValueField = "deviceType"
                        SelectInstrument.DataBind()
                        SelectInstrument.Items.Insert(0, "...Select Instrument...")

                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
            End Try

            'Display registered instrument services data in data gridview 
            Try
                ConnectDatabase()

                Dim db As String = "SELECT * FROM deviceservices WHERE CompanyID='" & Session("UserLoginID") & "'"

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)

                        'Get the list of rows needed into Session, so as to enable us retreive it later

                        Dim dt As New DataTable()
                        Dim ds As New DataSet()
                        da.Fill(dt)
                        da.Fill(ds, "deviceservices")

                        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                            NoRecord.Visible = True
                        Else
                            NoRecord.Visible = False
                        End If
                        InstrumentServicesGridView.DataSource = Nothing
                        InstrumentServicesGridView.DataBind()

                        InstrumentServicesGridView.DataSource = ds
                        InstrumentServicesGridView.DataMember = "deviceservices"
                        InstrumentServicesGridView.DataBind()
                        Cache("InstrumentServices") = dt

                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            End Try

        Else
           
        End If


    End Sub

    Protected Sub OnInstrumentSelectedIndexChanged(sender As Object, e As EventArgs)
        Dim Instrument As String = InstrumentServicesGridView.SelectedRow.Cells(0).Text
        Session.Remove("SelectedInstrumentCode")
        Session.Add("SelectedInstrumentCode", Instrument)

        'Response.AppendHeader("Refresh", "2;url=./#InstrumentServicesFeedback")
        Response.Redirect("./#InstrumentServicesFeedback", False)
       


    End Sub



    Protected Sub InstrumentServicesGridView_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles InstrumentServicesGridView.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim InstrumentServices As LinkButton
            InstrumentServices = CType(e.Row.Cells(7).Controls(0), LinkButton)
            If InstrumentServices.Text = "Instrument Services" Then
                InstrumentServices.Text = "Feedback"
                InstrumentServices.Enabled = True
            Else
                InstrumentServices.Enabled = False
                InstrumentServices.Text = "Status"
                InstrumentServices.ToolTip = "Application Approved, Click to Print Certificate"
            End If

        End If

    End Sub



    <System.Web.Script.Services.ScriptMethod(), System.Web.Services.WebMethod()>
    Public Shared Function SearchInstruments(ByVal prefixText As String, ByVal count As Integer) As List(Of String)
        ConnectDatabase()
        Dim Command As New MySqlCommand
        Command.CommandText = "SELECT serialNumber FROM deviceregistration WHERE  CompanyID='" & HttpContext.Current.Session("UserLoginID") & "' AND deviceType='" & HttpContext.Current.Session("SelectedInstrument") & "' AND serialNumber LIKE @SearchText"
        Command.Parameters.AddWithValue("@SearchText", "%" + prefixText + "%")
        Command.Connection = conn
        Dim Instruments As List(Of String) = New List(Of String)
        Dim reader As MySqlDataReader = Command.ExecuteReader
        While reader.Read
            Instruments.Add(reader("serialNumber").ToString)
        End While
        DisconnectDatabase()
        Return Instruments


    End Function


    Sub SelectInstrument_SelectedIndexChanged(sender As Object, e As EventArgs)

        If SelectInstrument.SelectedItem.Text = "...Select Instrument..." Then
            MessageBox.Show(Me, "Select a valid instrument!")
        Else
            Try
                ConnectDatabase()
                Dim db As String = "SELECT * FROM deviceregistration WHERE deviceType='" & SelectInstrument.SelectedValue & "'"
                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)
                        'Fill data of logged in user into dataset
                        Dim ds As New DataSet()
                        da.Fill(ds)
                        Session.Add("referenceCode", ds.Tables(0).Rows(0).Item("transCode").ToString)
                        Session.Remove("SelectedInstrument")
                        Session.Add("SelectedInstrument", SelectInstrument.SelectedValue)
                    End Using
                End Using
                'Trow errow is anything wrong with the code
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                'After execution of mysql query, disconnect database
                DisconnectDatabase()
            End Try
        End If

    End Sub

    Sub ServiceGroup_SelectedIndexChanged(sender As Object, e As EventArgs)

        If ServiceGroup.SelectedItem.Text = "...Select Service Group..." Then
            If SelectInstrument.SelectedItem.Text = "...Select Instrument..." Then
                MessageBox.Show(Me, " Select Instrument, Service Group AND Service Category")
                SelectServiceFee.ClearSelection()
                SelectServiceFee.SelectedIndex = 0
                ServiceCategory.ClearSelection()
                ServiceCategory.SelectedIndex = 0
            ElseIf Not SelectInstrument.SelectedItem.Text = "...Select Instrument..." Then
                MessageBox.Show(Me, " Select a Service Group")
                SelectServiceFee.ClearSelection()
                SelectServiceFee.SelectedIndex = 0
                ServiceCategory.ClearSelection()
                ServiceCategory.SelectedIndex = 0
            End If

        ElseIf ServiceGroup.SelectedItem.Text = "Instrument Services" Then
            ServiceCategoryPanel.Visible = False
            ServiceFeePanel.Visible = False
            'RegisterService.Text = "Proceed"
            ContinueRegistration.Visible = True
            RegisterService.Visible = False

        Else
            ContinueRegistration.Visible = False
            RegisterService.Visible = True

            ServiceCategoryPanel.Visible = True
            ServiceFeePanel.Visible = True
            'RegisterService.Text = "Register for Service"
            Try
                ConnectDatabase()

                Dim db As String = "SELECT * FROM feetable WHERE feegroup='" & ServiceGroup.SelectedValue & "' GROUP BY feeSubGroup ORDER BY feeSubGroup ASC"

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)
                        'Fill data of logged in user into dataset

                        Dim dt As New DataTable()
                        da.Fill(dt)

                        ServiceCategory.DataSource = dt
                        ServiceCategory.DataTextField = "feeSubGroup"
                        ServiceCategory.DataValueField = "ID"
                        ServiceCategory.DataBind()
                        ServiceCategory.Items.Insert(0, "...Select Service Category...")

                        SelectServiceFee.ClearSelection()
                        SelectServiceFee.SelectedIndex = 0
                    End Using
                End Using

                'Trow errow is anything is wrong with the code

            Catch ex As Exception

                MessageBox.Show(Me, ex.Message)

            Finally
                'After execution of mysql query, disconnect database
                DisconnectDatabase()
            End Try

        End If


    End Sub

    Sub ServiceCategory_SelectedIndexChanged(sender As Object, e As EventArgs)

        If ServiceCategory.SelectedItem.Text = "...Select Service Category..." Then

            If SelectInstrument.SelectedItem.Text = "...Select Instrument..." Or ServiceGroup.SelectedItem.Text = "...Select Service Group..." Then
                MessageBox.Show(Me, " Select Instrument, Service Group AND Service Category")
                SelectServiceFee.ClearSelection()
                SelectServiceFee.SelectedIndex = 0
                SelectServiceFee.ClearSelection()
                SelectServiceFee.SelectedIndex = 0
            ElseIf Not SelectInstrument.SelectedItem.Text = "...Select Instrument..." Then
                MessageBox.Show(Me, " Select a service category")
                SelectServiceFee.ClearSelection()
                SelectServiceFee.SelectedIndex = 0
                SelectServiceFee.ClearSelection()
                SelectServiceFee.SelectedIndex = 0
            End If

        Else

            Try
                ConnectDatabase()

                Dim db As String = "SELECT * FROM feetable WHERE feegroup='" & ServiceGroup.SelectedItem.Text & "' AND feeSubGroup='" & ServiceCategory.SelectedItem.Text & "'   ORDER BY feeSubGroup ASC"

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)
                        'Fill data of logged in user into dataset

                        Dim dt As New DataTable()
                        da.Fill(dt)

                        SelectServiceFee.DataSource = dt
                        SelectServiceFee.DataTextField = "measureRange"
                        SelectServiceFee.DataValueField = "ID"
                        SelectServiceFee.DataBind()
                        SelectServiceFee.Items.Insert(0, "...Select Service Fee...")
                    End Using
                End Using

                'Trow errow is anything is wrong with the code

            Catch ex As Exception

                MessageBox.Show(Me, ex.Message)

            Finally
                'After execution of mysql query, disconnect database
                DisconnectDatabase()
            End Try

        End If


    End Sub


    Sub ServiceFee_SelectedIndexChanged(sender As Object, e As EventArgs)

        If SelectServiceFee.SelectedItem.Text = "...Select Service Fee..." Then
            MessageBox.Show(Me, " Select a service fee")
        Else

            Try
                ConnectDatabase()

                Dim db As String = "SELECT * FROM feetable WHERE feegroup='" & ServiceGroup.SelectedItem.Text & "' AND feeSubGroup='" & ServiceCategory.SelectedItem.Text & "' AND measureRange='" & SelectServiceFee.SelectedItem.Text & "'  ORDER BY feeSubGroup ASC"

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)
                        'Fill data of logged in user into dataset

                        Dim ds As New DataSet()
                        da.Fill(ds)
                        MessageBox.Show(Me, ds.Tables(0).Rows(0).Item("amount").ToString)
                        Session.Add("AmountDue", ds.Tables(0).Rows(0).Item("amount").ToString)
                        ServiceAmount.Text = Session("AmountDue")
                        ServiceAmount.ForeColor = Drawing.Color.DarkRed

                    End Using
                End Using
                'Trow errow is anything is wrong with the code
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                'After execution of mysql query, disconnect database
                DisconnectDatabase()
            End Try

        End If


    End Sub

    Protected Sub RegisterService_Click(sender As Object, e As EventArgs) Handles RegisterService.Click
        If SelectInstrument.SelectedItem.Text = "...Select Instrument..." Then

            MessageBox.Show(Me, "You have not select option in one of the dropdown selection, please do so to continue!")
            SelectServiceFee.ClearSelection()
            SelectServiceFee.SelectedIndex = 0
            SelectServiceFee.BorderColor = Drawing.Color.DarkRed

        ElseIf ServiceGroup.SelectedValue = "Instrument Services" Then
           
            If SearchInstrument.Text = "" Or ServiceGroup.SelectedItem.Text = "...Select Service Group..." Then
                MessageBox.Show(Me, "You have not select option in one of the dropdown selection, please do so to continue!")
                SelectServiceFee.ClearSelection()
                SelectServiceFee.SelectedIndex = 0
                SelectServiceFee.BorderColor = Drawing.Color.DarkRed
            End If

        Else
           
            If SearchInstrument.Text = "" Or ServiceGroup.SelectedItem.Text = "...Select Service Group..." Or ServiceCategory.SelectedItem.Text = "...Select Service Category..." Or SelectServiceFee.SelectedItem.Text = "...Select Service Fee..." Then
                MessageBox.Show(Me, "You have not select option in one of the dropdown selection, please do so to continue!")
                SelectServiceFee.ClearSelection()
                SelectServiceFee.SelectedIndex = 0
                SelectServiceFee.BorderColor = Drawing.Color.DarkRed

            Else
                SelectServiceFee.BorderColor = Drawing.Color.Empty
                Try
                    ConnectDatabase()

                    Dim com As New MySqlCommand
                    com.Connection = conn
                    com.CommandText = "INSERT INTO deviceservices (companyID,companyName,deviceTypeAndNumber,serviceGroup,serviceCategory,serviceFee,amount,transCode,registrationDate,registrationTime) VALUE ('" & Session("UserLoginID") & "','" & Session("UserLoginCompanyName") & "','" & SelectInstrument.SelectedItem.Text & "','" & ServiceGroup.SelectedItem.Text & "','" & ServiceCategory.SelectedItem.Text & "','" & SelectServiceFee.SelectedItem.Text & "','" & Session("AmountDue") & "','" & Session("referenceCode") & "','" & TodaysDate() & "','" & CurrentTim() & "')"
                    com.ExecuteNonQuery()

                    Dim PaymentFor = ""

                    If ServiceGroup.SelectedItem.Text = "Approval of Pattern" Then
                        PaymentFor = "Pattern of Approval Bill"
                    ElseIf ServiceGroup.SelectedItem.Text = "Adjusting Fees" Then
                        PaymentFor = "Adjusting Fee Bill"
                    End If

                    Dim Narration = ServiceGroup.SelectedItem.Text & " Services for : " & SelectInstrument.SelectedItem.Text
                    Dim comp As New MySqlCommand
                    comp.Connection = conn
                    comp.CommandText = "INSERT INTO payment (companyID,companyName,transCode,amountDue,invoiceDate,invoiceTime,narration,orderId,paymentFor) VALUE ('" & Session("UserLoginID") & "','" & Session("UserLoginCompanyName") & "','" & Session("referenceCode") & "','" & Session("AmountDue") & "','" & TodaysDate() & "','" & CurrentTim() & "', '" & Narration & "','" & OrderNumber & "','" & PaymentFor & "')"
                    comp.ExecuteNonQuery()

                    MessageBox.Show(Me, "Instrument registered successfully for " & ServiceGroup.SelectedItem.Text & " Services")

                    Session.Remove("InstrumentName")
                    Session.Remove("InstrumentSerialNumber")
                    Session.Add("InstrumentName", SelectInstrument.SelectedItem.Text)
                    Session.Add("InstrumentSerialNumber", SearchInstrument.Text)
                    'Send SMS Message
                    tools.SendSMS(Me, GetSMSAPI(), GetSMSUsername(), GetSMSPassword(), BulkSMSDefaultSender(), SMSRecipientNumber(), InstrumentServiceMessage())

                    'Send email to user after application
                    Dim InvoiceNumber = OrderNumber
                    Dim InvoiceCompanyName = Session("UserLoginCompanyName")
                    Dim InvoiceUsername = Session("UserLoginName")
                    Dim CompanyAddress = Session("UserLoginCompanyAddress")
                    Dim Amount = Session("AmountDue")
                    Dim Total = Session("AmountDue")
                    Amount = FormatNumber(Amount, 2, TriState.False, , TriState.True)
                    Total = FormatNumber(Total, 2, TriState.False, , TriState.True)
                    Dim Purpose = PaymentFor.Replace("Invoice", "") + "  " + SelectInstrument.SelectedItem.Text

                    Dim Subject = PaymentFor
                    'Dim Message = "Your Online Registration with Federal Ministry of Industry, Trade and Investment was successful. <div style=''><p> Below are your registration details:<p> <strong> Username: </strong>" + Username.Text + "<p> <strong> Company Name: </strong>" + CompanyName.Text + " <p> Kindly click the button below to login to your account.<p style='margin-top:50px;'> <strong>Thank you.</strong>"
                    Dim Message = "<div style='width:620px;font-size:15px;background:rgb(255,255, 255);'><div style='padding-left:10px; width:590px;'><h4 style='padding:10px 0px;font-size:23px;width:100%;text-align:center;margin-top:-10px;'>" & Subject & "</span></h4> <h4 style='padding:10px 0px;font-size:17px;'><span style='float:right;font-size:13px;'>" + Date.Now + " </span></h4><div style='margin-bottom:10px;display:block;height:169px; width:100%;'><div style='width:45%;float:left;'><div style='font-weight:bolder;font-size:17px;padding:5px 0px;'>CLIENT DETAIL</div><p style='font-weight:bolder;font-size:15px;'>" + InvoiceCompanyName + " (" + InvoiceUsername + ")  </p><p style='font-weight:bolder;font-size:15px;'>" + CompanyAddress + "</p></div><div style='width:45%;float:right;'><div style='font-weight:bolder;font-size:17px;padding:5px 0px;'>ACCOUNT DETAIL</div><p style='font-weight:bolder;font-size:13px;'>ACCOUNT NAME: <span style='font-weight:normal;'>FEDERAL MINISTRY OF INDUSTRY, TRADE AND INVESTMENT WEIGHTS AND MEASURES DEPARTMENT</span></p><p style='font-weight:bolder;font-size:13px;'>ACCOUNT NUMBER: <span style='font-weight:normal;'>1750013688</span></p><p style='font-weight:bolder;font-size:13px;'>BANK NAME: <span style='font-weight:normal;'>SKYE BANK</span></p></div></div><div style='font-weight:bolder;font-size:17px;padding:5px 0px;'>INVOICE ITEM(S)</div><div style='width:69%;display:inline-block;font-weight:bolder;padding:10px 0px;border-bottom:1px solid rgb(200,200,200);color:rgb(100,100,100);'>Summary</div><div style='width:30%;display:inline-block;text-align:right;font-weight:bolder;padding:10px 0px;0px;border-bottom:1px solid rgb(200,200,200);color:rgb(100,100,100);'>Amount</div><div style='width:69%;display:inline-block;padding:10px 0px;'>" + Purpose + "</div><div style='width:30%;display:inline-block;text-align:right;padding:10px 0px;'>" + Amount + "</div><div style='width:100%;display:inline-block;padding:20px 0px;margin-left:-10px;padding-right:1px;text-align:right;font-weight:bolder;background:rgb(250,250,250);font-size:17px;'>Total: <span style='float:right;margin-left:50px;margin-right:0px;'>N" + Total + "</span></div></div><p><div style='margin-top:0px;width:600px;height:auto;padding:10px;color:rgb(20,20,20);text-align:left;font-size:13px;background:rgb(255,255,255);'><strong>PLEASE NOTE: </strong> <P>ALL BANK DEPOSIT MUST BE MADE WITH THE USERNAME NAME AS THE DEPOSITOR.<P>ALL PAYMENT(S) MADE ARE NON-REFUNDABLE.</div><p><a href='http://www.wmdnigeria.com/' style='text-decoration:none;width:auto;color:rgb(255,255,255);'><div style='margin-bottom:10px;padding: 5px 10px;width:100px;font-size: 14px;font-weight: bolder;line-height: 20px;text-align: center;cursor: pointer;border: 1px solid transparent;border-radius: 4px;background:rgb(54,127,169);color:rgb(255, 255, 255);'>Login Now</div> </div>"
                    'Dim Message = "Your Export Permit Application on Federal Ministry of Industry, Trade and Investment Weights and Measures Department Web Portal was successful. <div style=''><p> Below are the Export Permit Application Details:<p> <strong> Reference Number: </strong>" + ExportReferenceCode + "<p> <strong> Company Name: </strong>" + Session("UserLoginCompanyName") + "<p> <strong> Permit Quarter : </strong>" + PermitQuarters.SelectedItem.Text + "<p> <strong> Exporter Name: </strong>" + ExporterName.Text + "<p> <strong> Export Quantity: </strong>" + ExportQuantity.Text + "<p> <strong> Amount Per Barrel: </strong>" + AmountPerBarrel.Text + "<p> <strong> Total Amount: </strong>" + FOBValue.Text + " <p> Kindly click the button below to login to your account.<p style='margin-top:50px;'> <strong>Thank you.</strong>"
                    Dim MessageBody = "<html><head></head><body style='font-family:Tahoma; width:620px;font-size:13px;background:rgb(240,240, 240)'><div style='width:600px;height:70px;padding:10px;color:rgb(255, 255, 255);font-weight:bolder;text-align:center;font-size:20px;background:rgb(54,127,169);'><img src='http://www.wmdnigeria.com/images/coatofarm.png' width='70px' height='70px' align='left' style='margin-top:-10px;padding:0px;' /><p>Federal Ministry of Industry Trade and Investment <br><span style='font-size:17px;'>Commodities and Products Inspectorate Department (CPI)</span></div><div style='width:600px;font-size:13px;color:rgb(100,100,100);'><p> <div style='padding-left:10px; width:590px;'> <p>" & Message & "</div></div>           <p><div style='margin-top:100px;width:600px;height:auto;padding:10px;color:rgb(255, 255, 255);text-align:center;font-size:13px;background:rgb(54,127,169);'><strong>NOTICE: </strong>  The content of this e-mail is intended solely for the use of the individual or entity to whom it is addressed. If you have received this communication in error, beware that forwarding it, copying it or in any way disclosing its content to any other person or persons, is strictly prohibiting. If you have received this communication in error, please notify the author by replying this e-mail immediately.</div></body></html>"

                    clsNotify.SendEmail(Session("UserLoginCompanyEmail"), Subject, MessageBody, AccountEmail(), True)

                    'This code do the loggin magic
                    Dim Activity As String = Session("UserLoginCompanyName") & " registered " & SelectInstrument.SelectedItem.Text & " for " & ServiceGroup.SelectedItem.Text & " Services! "
                    Dim comm As New MySqlCommand
                    comm.Connection = conn
                    comm.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("UserLoginID") & "','" & Activity & "','" & Session("UserLoginIPAddress") & "','" & ComputerName() & "','" & osVersion() & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("UserLoginUserType") & "')"
                    comm.ExecuteNonQuery()
                    'Trow errow is anything is wrong with the code
                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                Finally
                    'After execution of mysql query, disconnect database
                    DisconnectDatabase()
                    Response.AppendHeader("Refresh", "0;url=./")
                End Try

            End If


        End If

    End Sub


    Protected Sub ProceedRegistration_Click(sender As Object, e As EventArgs) Handles ProceedRegistration.Click
        Try
            ConnectDatabase()

            Dim com As New MySqlCommand
            com.Connection = conn
            com.CommandText = "INSERT INTO deviceservices (companyID,companyName,deviceTypeAndNumber,serviceGroup,transCode,registrationDate,registrationTime) VALUE ('" & Session("UserLoginID") & "','" & Session("UserLoginCompanyName") & "','" & SelectInstrument.SelectedItem.Text & "','" & ServiceGroup.SelectedItem.Text & "','" & Session("referenceCode") & "','" & TodaysDate() & "','" & CurrentTim() & "')"
            com.ExecuteNonQuery()

            'This code do the loggin magic
            Dim Activity As String = Session("UserLoginCompanyName") & " registered " & SelectInstrument.SelectedItem.Text & " for " & ServiceGroup.SelectedItem.Text & " Services! "
            Dim comm As New MySqlCommand
            comm.Connection = conn
            comm.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("UserLoginID") & "','" & Activity & "','" & Session("UserLoginIPAddress") & "','" & ComputerName() & "','" & osVersion() & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("UserLoginUserType") & "')"
            comm.ExecuteNonQuery()
            'Trow errow is anything is wrong with the code
        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)
        Finally
            'After execution of mysql query, disconnect database
            DisconnectDatabase()
            Response.AppendHeader("Refresh", "0;url=./")
        End Try
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

    Protected Sub InstrumentServicesGridView_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        InstrumentServicesGridView.PageIndex = e.NewPageIndex
        InstrumentServicesGridView.DataSource = CType(Cache("InstrumentServices"), DataTable)
        InstrumentServicesGridView.DataBind()
    End Sub
End Class