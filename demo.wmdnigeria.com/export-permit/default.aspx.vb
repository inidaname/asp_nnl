Imports System.Web
Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Data.OleDb
Imports System.Web.Security
Imports System.Configuration
Imports MySql.Data.MySqlClient

Public Class _default15
    Inherits System.Web.UI.Page


    Sub ScrollPageToTop()
        Dim strScroll As String
        strScroll = "<script language='javascript'>" & Environment.NewLine & "window.scrollTo(0,0);</script>"
        ClientScript.RegisterStartupScript(Me.GetType, "ScrollToTop", strScroll.ToString)
    End Sub

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
                Response.Redirect("./wmd-inspector/")

            ElseIf Session("Login") = True And Session("UserLoginUserType") = "CPI Inspector" Then
                Response.Redirect("./cpi-inspector/")

            ElseIf Session("Login") = True And Session("UserLoginUserType") = "Calibrator" Then
                Response.Redirect("./calibrator/")

            ElseIf Session("Login") = True And Session("UserLoginUserType") = "Authorized Verifier" Then
                Response.Redirect("./authorized-verifier/")

            End If
        End If



        Registration.Text = "REGISTER"

        PeriodCoveredFrom.Enabled = False
        PeriodCoveredTo.Enabled = False
        TerminaOperator.Checked = True
        MainExportPermitApplication.Checked = True
        MainExportPermitApplication.Enabled = False
        SupplimentExportPermitApplication.Enabled = False


        If Not IsPostBack = True Then
            'SearchExportPermit.Focus()
            ScrollPageToTop()
            OrderNumber = OrderID()
            'PermitQuarters.Items.Insert("...Select Permit Quarter...", 0)
            'PermitQuarters.Items.Insert("1st Quarter / " & Today.Year, 1)
            'PermitQuarters.Items.Insert("2nd Quarter / " & Today.Year, 2)
            'PermitQuarters.Items.Insert("3rd Quarter / " & Today.Year, 3)
            'PermitQuarters.Items.Insert("4th Quarter / " & Today.Year, 4)

            Dim Options As ListItemCollection = New ListItemCollection()
            Options.Add(New ListItem("...Select Permit Quarter...", "...Select Permit Quarter..."))
            Options.Add(New ListItem("1st Quarter / " & Today.Year, "1st Quarter / " & Today.Year))
            Options.Add(New ListItem("2nd Quarter / " & Today.Year, "2nd Quarter / " & Today.Year))
            Options.Add(New ListItem("3rd Quarter / " & Today.Year, "3rd Quarter / " & Today.Year))
            Options.Add(New ListItem("4th Quarter / " & Today.Year, "4th Quarter / " & Today.Year))

            Me.PermitQuarters.DataSource = Options
            Me.PermitQuarters.DataBind()

            PermitQuarters.Items.FindByText("...Select Permit Quarter...").Selected = True


            EvidenceOfPayment.Enabled = True
            Try
                ConnectDatabase()

                Dim db As String = "SELECT * FROM exportpermit WHERE CompanyID='" & Session("UserLoginID") & "'"

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)

                        'Get the list of rows needed into Session, so as to enable us retreive it later

                        Dim dt As New DataTable()
                        Dim ds As New DataSet()
                        da.Fill(dt)
                        da.Fill(ds, "exportpermit")

                        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                            NoRecord.Visible = True
                        Else
                            NoRecord.Visible = False
                        End If
                        Dim PermitStatus = ds.Tables(0).Rows(0).Item("approvalStatus").ToString
                        If PermitStatus = 0 Then
                            'ExportPermitGridView.Rows.(0).Text()

                        Else

                        End If
                        ExportPermitGridView.DataSource = Nothing
                        ExportPermitGridView.DataBind()

                        ExportPermitGridView.DataSource = ds
                        ExportPermitGridView.DataMember = "exportpermit"
                        ExportPermitGridView.DataBind()
                        Cache("ExportData") = dt

                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
            End Try

        Else
        End If
        NoRecord.Visible = False
        ProcessingData.Visible = False

    End Sub


    Protected Sub ExportPermitGridView_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles ExportPermitGridView.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim ApprovalStatus As LinkButton
            ApprovalStatus = CType(e.Row.Cells(8).Controls(0), LinkButton)
            If ApprovalStatus.Text = 0 Then
                ApprovalStatus.Text = "Waiting"
                ApprovalStatus.Enabled = False

            ElseIf ApprovalStatus.Text = 1 Then
                ApprovalStatus.Text = "View Certificate"
                ApprovalStatus.Enabled = True
                ApprovalStatus.ToolTip = "Application Approved, Click to Print Certificate"
            End If

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


    Protected Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Response.Redirect("./")
    End Sub

    Dim UploadPath As String = HttpContext.Current.Request.PhysicalApplicationPath & "File Manager\ExportPermitFiles\"

    Protected Sub FreshApplication_Click(sender As Object, e As EventArgs) Handles FreshApplication.Click
        ExportApplication.Visible = True

    End Sub
    Protected Sub SearchPermit_Click(sender As Object, e As EventArgs) Handles SearchPermit.Click
        ExportApplication.Visible = False
        Try
            ConnectDatabase()

            Dim db As String = "SELECT * FROM exportpermit WHERE CompanyID='" & Session("UserLoginID") & "' AND referenceCode LIKE '%" & SearchExportPermit.Text & "%'"

            Using cn As MySqlCommand = New MySqlCommand(db, conn)
                Using da As New MySqlDataAdapter(cn)

                    'Get the list of rows needed into Session, so as to enable us retreive it later

                    Dim dt As New DataTable()
                    Dim ds As New DataSet()
                    da.Fill(dt)
                    da.Fill(ds, "exportpermit")

                    If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                        NoRecord.Visible = True
                    Else
                        NoRecord.Visible = False
                    End If
                    ExportPermitGridView.DataSource = Nothing
                    ExportPermitGridView.DataBind()

                    ExportPermitGridView.DataSource = ds
                    ExportPermitGridView.DataMember = "exportpermit"
                    ExportPermitGridView.DataBind()
                    Cache("ExportData") = dt



                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)
        Finally
            DisconnectDatabase()
            SearchExportPermit.Focus()
        End Try

    End Sub

    Protected Sub OnInvoiceSelectedIndexChanged(sender As Object, e As EventArgs)
        Dim ExportPermitReference As String = ExportPermitGridView.SelectedRow.Cells(0).Text
        Response.Redirect("./export-permit-certificate/?/printable-certificate/=" + ExportPermitReference)
        

    End Sub


    Dim ExportPermitApplicationType As String

    Protected Sub CompleteProcess_Click(Sender As Object, e As EventArgs) Handles CompleteProcess.Click
        If ExportQuantity.Text = "" Or PermitQuarters.Text = "" Or ExporterName.Text = "" Or ProductDescription.Text = "" Or PeriodCoveredFrom.Text = "" Or PeriodCoveredTo.Text = "" Or Measure.Text = "" Or ExportQuantity.Text = "" Or ExportPort.Text = "" Or AmountPerBarrel.Text = "" Or FillerFullName.Text = "" Or FillerEmailAddress.Text = "" Then
            MessageBox.Show(Me, "Note: All fields are required!")
        Else
            If Agree.Checked = True Then

                Dim fileExt As String
                fileExt = System.IO.Path.GetExtension(EvidenceOfPayment.FileName)

                If (fileExt = ".pdf" Or fileExt = ".doc" Or fileExt = ".docx" Or fileExt = ".xlsx" Or fileExt = ".xls" Or fileExt = ".jpg" Or fileExt = ".png" Or fileExt = ".jpeg" Or fileExt = ".bmp") Then

                    Try
                        EvidenceOfPayment.SaveAs(UploadPath & EvidenceOfPayment.FileName)

                        'Insert details into the database if file to upload meets our requirements
                        Try

                            ConnectDatabase()

                            Dim TerminalOperatorString As String
                            If TerminaOperator.Checked = True Then
                                TerminalOperatorString = "1"

                            Else
                                TerminalOperatorString = "0"
                            End If

                            If MainExportPermitApplication.Checked = True Then
                                ExportPermitApplicationType = "Main"

                            ElseIf SupplimentExportPermitApplication.Checked = False Then

                                ExportPermitApplicationType = "Suppliment"
                            End If

                            Dim ExportReferenceCode = referenceCode()

                            Dim com As New MySqlCommand
                            com.Connection = conn
                            com.CommandText = "INSERT INTO exportpermit (companyID,exportpermitName,exporterName,productName,periodCoveredFrom,periodCoveredTo,measure,quantity,exportPort,amountPerBarrelUS,totalAmountUS,terminalOperator,formFilledTitle,formFilledBy,formFilledByEmail,certificateOfIncorporation,memorandumOfAssociation,currentProduction,conformityCertificate,bankReference,clearanceCertificate,exportPermitApplication,evidenceOfPayment,referenceCode,applicationDate,applicationTime,applicationType) VALUES('" & Session("UserLoginID") & "','" & PermitQuarters.SelectedItem.Text & "','" & ExporterName.Text & "','" & ProductDescription.Text & "','" & PeriodCoveredFrom.SelectedItem.Text & "','" & PeriodCoveredTo.SelectedItem.Text & "','" & Measure.Text & "','" & ExportQuantity.Text & "','" & ExportPort.Text & "','" & AmountPerBarrel.Text & "','" & FOBValue.Text & "','" & TerminalOperatorString & "','" & FillerTitle.Text & "','" & FillerFullName.Text & "','" & FillerEmailAddress.Text & "','" & CertificateOfIncorporation.FileName & "','" & MemorandumOfAssociation.FileName & "','" & CurrentProduction.FileName & "','" & ConformityCertificate.FileName & "','" & BankReference.FileName & "','" & ClearanceCertificate.FileName & "','" & ExportPermitApplication.FileName & "','" & EvidenceOfPayment.FileName & "','" & referenceCode() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & ExportPermitApplicationType & "')"
                            com.ExecuteNonQuery()

                            Dim Narration As String = "Export Permit Application Fee"
                            Dim comp As New MySqlCommand
                            comp.Connection = conn
                            comp.CommandText = "INSERT INTO payment (companyID,companyName,transCode,amountDue,invoiceDate,invoiceTime,narration,orderId) VALUE ('" & Session("UserLoginID") & "','" & Session("UserLoginUsername") & "','" & ExportReferenceCode & "','" & FOBValue.Text & "','" & TodaysDate() & "','" & CurrentTim() & "', '" & Narration & "')"
                            comp.ExecuteNonQuery()

                            Try
                                FOBValue.Text = FormatNumber(FOBValue.Text, 2, TriState.False, , TriState.True)
                            Catch ex As Exception
                                MessageBox.Show(Me, "Only digits and/or a decimal please.")
                            End Try


                            'Send email to user after application
                            Dim InvoiceNumber = OrderNumber
                            Dim InvoiceCompanyName = Session("UserLoginCompanyName")
                            Dim InvoiceUsername = Session("UserLoginName")
                            Dim CompanyAddress = Session("UserLoginCompanyAddress")
                            Dim Amount = FOBValue.Text
                            Dim Total = FOBValue.Text
                            Amount = FormatNumber(Amount, 2, TriState.False, , TriState.True)
                            Total = FormatNumber(Total, 2, TriState.False, , TriState.True)
                            Dim Purpose = "Export Permit Application for " + PermitQuarters.SelectedItem.Text

                            Dim Subject = "Export Permit Application Bill!"
                            'Dim Message = "Your Online Registration with Federal Ministry of Industry, Trade and Investment was successful. <div style=''><p> Below are your registration details:<p> <strong> Username: </strong>" + Username.Text + "<p> <strong> Company Name: </strong>" + CompanyName.Text + " <p> Kindly click the button below to login to your account.<p style='margin-top:50px;'> <strong>Thank you.</strong>"
                            Dim Message = "<div style='width:620px;font-size:15px;background:rgb(255,255, 255);'><div style='padding-left:10px; width:590px;'><h4 style='padding:10px 0px;font-size:23px;width:100%;text-align:center;margin-top:-10px;'>" & Subject & "</span></h4> <h4 style='padding:10px 0px;font-size:17px;'><span style='float:right;font-size:13px;'>" + Date.Now + " </span></h4><div style='margin-bottom:10px;display:block;height:169px; width:100%;'><div style='width:45%;float:left;'><div style='font-weight:bolder;font-size:17px;padding:5px 0px;'>CLIENT DETAIL</div><p style='font-weight:bolder;font-size:15px;'>" + InvoiceCompanyName + " (" + InvoiceUsername + ")  </p><p style='font-weight:bolder;font-size:15px;'>" + CompanyAddress + "</p></div><div style='width:45%;float:right;'><div style='font-weight:bolder;font-size:17px;padding:5px 0px;'>ACCOUNT DETAIL</div><p style='font-weight:bolder;font-size:13px;'>ACCOUNT NAME: <span style='font-weight:normal;'>FEDERAL MINISTRY OF INDUSTRY, TRADE AND INVESTMENT WEIGHTS AND MEASURES DEPARTMENT</span></p><p style='font-weight:bolder;font-size:13px;'>ACCOUNT NUMBER: <span style='font-weight:normal;'>1750013688</span></p><p style='font-weight:bolder;font-size:13px;'>BANK NAME: <span style='font-weight:normal;'>SKYE BANK</span></p></div></div><div style='font-weight:bolder;font-size:17px;padding:5px 0px;'>INVOICE ITEM(S)</div><div style='width:69%;display:inline-block;font-weight:bolder;padding:10px 0px;border-bottom:1px solid rgb(200,200,200);color:rgb(100,100,100);'>Summary</div><div style='width:30%;display:inline-block;text-align:right;font-weight:bolder;padding:10px 0px;0px;border-bottom:1px solid rgb(200,200,200);color:rgb(100,100,100);'>Amount</div><div style='width:69%;display:inline-block;padding:10px 0px;'>" + Purpose + "</div><div style='width:30%;display:inline-block;text-align:right;padding:10px 0px;'>" + Amount + "</div><div style='width:100%;display:inline-block;padding:20px 0px;margin-left:-10px;padding-right:1px;text-align:right;font-weight:bolder;background:rgb(250,250,250);font-size:17px;'>Total: <span style='float:right;margin-left:50px;margin-right:0px;'>N" + Total + "</span></div></div><p><div style='margin-top:0px;width:600px;height:auto;padding:10px;color:rgb(20,20,20);text-align:left;font-size:13px;background:rgb(255,255,255);'><strong>PLEASE NOTE: </strong> <P>ALL BANK DEPOSIT MUST BE MADE WITH THE USERNAME NAME AS THE DEPOSITOR.<P>ALL PAYMENT(S) MADE ARE NON-REFUNDABLE.</div><p><a href='http://www.wmdnigeria.com/' style='text-decoration:none;width:auto;color:rgb(255,255,255);'><div style='margin-bottom:10px;padding: 5px 10px;width:100px;font-size: 14px;font-weight: bolder;line-height: 20px;text-align: center;cursor: pointer;border: 1px solid transparent;border-radius: 4px;background:rgb(54,127,169);color:rgb(255, 255, 255);'>Login Now</div> </div>"
                            'Dim Message = "Your Export Permit Application on Federal Ministry of Industry, Trade and Investment Weights and Measures Department Web Portal was successful. <div style=''><p> Below are the Export Permit Application Details:<p> <strong> Reference Number: </strong>" + ExportReferenceCode + "<p> <strong> Company Name: </strong>" + Session("UserLoginCompanyName") + "<p> <strong> Permit Quarter : </strong>" + PermitQuarters.SelectedItem.Text + "<p> <strong> Exporter Name: </strong>" + ExporterName.Text + "<p> <strong> Export Quantity: </strong>" + ExportQuantity.Text + "<p> <strong> Amount Per Barrel: </strong>" + AmountPerBarrel.Text + "<p> <strong> Total Amount: </strong>" + FOBValue.Text + " <p> Kindly click the button below to login to your account.<p style='margin-top:50px;'> <strong>Thank you.</strong>"
                            Dim MessageBody = "<html><head></head><body style='font-family:Tahoma; width:620px;font-size:13px;background:rgb(240,240, 240)'><div style='width:600px;height:70px;padding:10px;color:rgb(255, 255, 255);font-weight:bolder;text-align:center;font-size:20px;background:rgb(54,127,169);'><img src='http://www.wmdnigeria.com/images/coatofarm.png' width='70px' height='70px' align='left' style='margin-top:-10px;padding:0px;' /><p>Federal Ministry of Industry Trade and Investment <br><span style='font-size:17px;'>Commodities and Products Inspectorate Department (CPI)</span></div><div style='width:600px;font-size:13px;color:rgb(100,100,100);'><p> <div style='padding-left:10px; width:590px;'> <p>" & Message & "</div></div>           <p><div style='margin-top:100px;width:600px;height:auto;padding:10px;color:rgb(255, 255, 255);text-align:center;font-size:13px;background:rgb(54,127,169);'><strong>NOTICE: </strong>  The content of this e-mail is intended solely for the use of the individual or entity to whom it is addressed. If you have received this communication in error, beware that forwarding it, copying it or in any way disclosing its content to any other person or persons, is strictly prohibiting. If you have received this communication in error, please notify the author by replying this e-mail immediately.</div></body></html>"

                            clsNotify.SendEmail(Session("UserLoginCompanyEmail"), Subject, MessageBody, AccountEmail(), True)


                            'This code do the loggin magic
                           
                            Dim Activity As String = "Applied for Export Permit"
                            Dim comm As New MySqlCommand
                            comm.Connection = conn
                            comm.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("UserLoginID") & "','" & Activity & "','" & Session("UserLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("UserLoginUserType") & "')"
                            comm.ExecuteNonQuery()

                            MessageBox.Show(Me, "You have successfully applied for Export Permit")
                            Response.AppendHeader("Refresh", "0;url=./")

                        Catch ex As Exception
                            MessageBox.Show(Me, ex.Message)
                        Finally
                            DisconnectDatabase()

                        End Try

                    Catch ex As Exception
                        MessageBox.Show(Me, "ERROR: " & ex.Message.ToString())
                    End Try

                Else
                    MessageBox.Show(Me, "ERROR: File type not allowed! Contact Administrator for correct File Type")
                End If

            Else

                MessageBox.Show(Me, "ERROR: Accept Declaration Statement by checking declaration box")

            End If

        End If
    End Sub

    Protected Sub AmountPerBarrel_TextChanged(Sender As Object, e As EventArgs) Handles FOBValue.TextChanged

        If ExportQuantity.Text = "" Then
            MessageBox.Show(Me, "Enter a Value in Export Quantity Box")

        Else
            Try
                Dim GetFOBValue As Double = ExportQuantity.Text * AmountPerBarrel.Text
                FOBValue.Text = Format(GetFOBValue, "0.00")
                ExporterName.Focus()
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            End Try
        End If


    End Sub

    Protected Sub ExportQuantity_TextChanged(Sender As Object, e As EventArgs) Handles ExportQuantity.TextChanged

        If AmountPerBarrel.Text = "" Then
            AmountPerBarrel.Focus()
        Else
            Try

                Dim GetFOBValue As Double = ExportQuantity.Text * AmountPerBarrel.Text
                FOBValue.Text = Format(GetFOBValue, "0.00")
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            End Try
        End If

    End Sub

    Dim LastQuarterRegisteredDate As String
    Dim SelectedPermitQuareter As String
    Dim SelectedPermitQuareterYear As String
    Dim CurrentYear = Date.Now.Year

    Protected Sub PermitQuarter_SelectedIndexChanged(Sender As Object, e As EventArgs) Handles PeriodCoveredFrom.SelectedIndexChanged

        Try
            If PermitQuarters.SelectedItem.Text.Contains("1st") Then

                PeriodCoveredFrom.SelectedValue = "1"
                PeriodCoveredTo.SelectedValue = "3"

            ElseIf PermitQuarters.SelectedItem.Text.Contains("2nd") Then

                PeriodCoveredFrom.SelectedValue = "4"
                PeriodCoveredTo.SelectedValue = "6"

            ElseIf PermitQuarters.SelectedItem.Text.Contains("3rd") Then

                PeriodCoveredFrom.SelectedValue = "7"
                PeriodCoveredTo.SelectedValue = "9"

            ElseIf PermitQuarters.SelectedItem.Text.Contains("4th") Then

                PeriodCoveredFrom.SelectedValue = "10"
                PeriodCoveredTo.SelectedValue = "12"


            Else
                MessageBox.Show(Me, "Select a valid Permit Quarters")
            End If

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)
        End Try


        'This code check if Export Permit Quarter has been registered before by the same User / applicant
        Try

            ConnectDatabase()

            Dim MyAdapter As New MySqlDataAdapter
            Dim SqlQuery = "SELECT * FROM exportpermit WHERE companyID='" & Session("UserLoginID") & "' AND exportPermitName='" & PermitQuarters.SelectedItem.Text & "';"
            Dim Command As New MySqlCommand
            Command.Connection = conn
            Command.CommandText = SqlQuery
            MyAdapter.SelectCommand = Command

            Dim reader As MySqlDataReader
            reader = Command.ExecuteReader
            'Check if the User has apply for export permit before
            If reader.HasRows = 0 Then

                MessageBox.Show(Me, "This User has not applied for this export permit before")
                MainExportPermitApplication.Checked = True
                SupplimentExportPermitApplication.Checked = False
                reader.Close()

            Else
                reader.Close()

                'This code compare Registered Export Permit Quarter Date with the current date so has to detect if its double then add it to supliment Mode if its existing
                Try

                    Dim db As String = "SELECT * FROM exportpermit WHERE companyID='" & Session("UserLoginID") & "' AND exportPermitName='" & PermitQuarters.SelectedItem.Text & "'"
                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)
                            'Get the list of rows needed into dataset, so as to enable us retrieve it later
                            Dim ds As New DataSet()
                            da.Fill(ds)
                            Try

                                Dim DateOfLastRegistration As String = ds.Tables(0).Rows(0).Item("applicationDate").ToString
                                Dim LastQuarterRegistered As Date = Date.ParseExact(DateOfLastRegistration, "dd-MM-yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                                'Dim LastQuarterRegistered As Date = Date.Parse(LastQuarterRegistered)
                                LastQuarterRegisteredDate = LastQuarterRegistered.Year
                                If LastQuarterRegisteredDate = CurrentYear Then
                                    MessageBox.Show(Me, "Application for the same quarter found, application has switch to Supliment Mode, Select a different Quarter to Continue: " & CurrentYear & "    " & LastQuarterRegisteredDate)
                                    SupplimentExportPermitApplication.Checked = True
                                    MainExportPermitApplication.Checked = False

                                End If
                            Catch ex As Exception
                                MessageBox.Show(Me, ex.Message)
                            End Try
                        End Using
                    End Using

                Catch ex As MySqlException
                    MessageBox.Show(Me, ex.Message)
                End Try
            End If


        Catch ex As Exception
            MessageBox.Show(Me, "Database Connection Error: " & ex.Message)

        Finally
            DisconnectDatabase()
        End Try

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

    Protected Sub ExportPermitGridView_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        ExportPermitGridView.PageIndex = e.NewPageIndex
        ExportPermitGridView.DataSource = CType(Cache("ExportData"), DataTable)
        ExportPermitGridView.DataBind()
    End Sub
End Class