Imports System.Web
Imports System.Data
Imports System.Text
Imports System.Web.Security
Imports System.Configuration
Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WebForms



Public Class _default21
    Inherits System.Web.UI.Page

    Public DatabaseDate As Date
    Public DateFrom As Date
    Public DateTo As Date


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




        NoRecord.Visible = False
        ProcessingData.Visible = False
        Parameter.Focus()
        'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "tmp2", "var t2 = document.getElementById('Parameter'); t2.focus();t2.value = t2.value;", True)
        'Parameter.select = Len(Parameter.Text)
        'Parameter.Attributes.AddAttributes()
        ShowReport.BackColor = Drawing.Color.Transparent
        ShowReport.BorderColor = Drawing.Color.Transparent



        If Not IsPostBack Then
            ReportCategoryPanel.Visible = False
            SelectReportCategory.Visible = False
            ReportCategoryLabel.Visible = False
            FilterDateFrom.Visible = False
            FilterDateTo.Visible = False
            GetDate.Visible = False

            'If the PageRequest QueryString LinkReportType is available'
            If Not String.IsNullOrEmpty(Request.QueryString("LinkReportType")) Then
                ' Access the value LinkReportType
                Dim LinkReportType = Request.QueryString("LinkReportType")

                If LinkReportType = "CompanyReport" Then
                    SelectReport.ClearSelection()
                    SelectReport.Items.Clear()
                    SelectReport.Items.Insert(0, "...Select Report Type...")
                    SelectReport.Items.Insert(1, "Company Report")
                    SelectReport.Items.Insert(2, "Instrument Report")
                    'SelectReport.Items.Insert(3, "Import Permit Report")
                    SelectReport.Items.Insert(3, "Export Permit Report")
                    SelectReport.Items.Insert(4, "Company Request Report")
                    SelectReport.Items.Insert(5, "Invoice Report")
                    SelectReport.Items.FindByText("Company Report").Selected = True

                    Parameter.Enabled = True
                    Parameter.BackColor = Drawing.Color.DarkGray

                    Try
                        ConnectDatabase()
                        CompanyRequestReport.LocalReport.DataSources.Clear()
                        CompanyRequestReport.Visible = False
                        ExportPermitReport.LocalReport.DataSources.Clear()
                        ExportPermitReport.Visible = False
                        InstrumentReport.LocalReport.DataSources.Clear()
                        InstrumentReport.Visible = False
                        InvoiceReport.LocalReport.DataSources.Clear()
                        InvoiceReport.Visible = False

                        Dim CompanyData As New CompanyDataSet()

                        Dim db As String = "SELECT * FROM company"
                        Using cn As MySqlCommand = New MySqlCommand(db, conn)
                            Using da As New MySqlDataAdapter(cn)

                                da.Fill(CompanyData, "CompanyTable")
                                Dim dt As New DataTable
                                da.Fill(dt)

                                If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                    NoRecord.Visible = True
                                Else
                                    NoRecord.Visible = False

                                    'MessageBox.Show(Me, "There is data here!")
                                End If
                                CompanyReport.ProcessingMode = ProcessingMode.Local
                                CompanyReport.LocalReport.ReportPath = Server.MapPath("CompanyReport.rdlc")

                                Dim datasource As New ReportDataSource("CompanyDataSet", CompanyData.Tables(0))

                                CompanyReport.LocalReport.DataSources.Clear()
                                CompanyReport.LocalReport.DataSources.Add(datasource)
                                CompanyReport.Visible = True

                            End Using
                        End Using
                    Catch ex As Exception
                        MessageBox.Show(Me, ex.Message)
                    Finally
                        DisconnectDatabase()
                    End Try


                ElseIf LinkReportType = "CompanyRequest" Then
                    SelectReport.ClearSelection()
                    SelectReport.Items.Clear()
                    SelectReport.Items.Insert(0, "...Select Report Type...")
                    SelectReport.Items.Insert(1, "Company Report")
                    SelectReport.Items.Insert(2, "Instrument Report")
                    'SelectReport.Items.Insert(3, "Import Permit Report")
                    SelectReport.Items.Insert(3, "Export Permit Report")
                    SelectReport.Items.Insert(4, "Company Request Report")
                    SelectReport.Items.Insert(5, "Invoice Report")
                    SelectReport.Items.FindByText("Company Request Report").Selected = True

                    Try
                        ConnectDatabase()
                        CompanyReport.LocalReport.DataSources.Clear()
                        CompanyReport.Visible = False
                        ExportPermitReport.LocalReport.DataSources.Clear()
                        ExportPermitReport.Visible = False
                        InstrumentReport.LocalReport.DataSources.Clear()
                        InstrumentReport.Visible = False
                        InvoiceReport.LocalReport.DataSources.Clear()
                        InvoiceReport.Visible = False

                        Dim InstrumentData As New CompanyRequestDataSet()

                        Dim db As String = "SELECT * FROM deviceregistration"
                        Using cn As MySqlCommand = New MySqlCommand(db, conn)
                            Using da As New MySqlDataAdapter(cn)

                                da.Fill(InstrumentData, "CompanyRequestTable")
                                Dim dt As New DataTable
                                da.Fill(dt)

                                If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                    NoRecord.Visible = True
                                Else
                                    NoRecord.Visible = False

                                    'MessageBox.Show(Me, "There is data here!")
                                End If
                                CompanyRequestReport.ProcessingMode = ProcessingMode.Local
                                CompanyRequestReport.LocalReport.ReportPath = Server.MapPath("CompanyRequestReport.rdlc")

                                Dim datasource As New ReportDataSource("CompanyRequestDataSet", InstrumentData.Tables(0))

                                CompanyRequestReport.LocalReport.DataSources.Clear()
                                CompanyRequestReport.LocalReport.DataSources.Add(datasource)
                                CompanyRequestReport.Visible = True

                            End Using
                        End Using
                    Catch ex As Exception
                        MessageBox.Show(Me, ex.Message)
                    Finally
                        DisconnectDatabase()
                    End Try



                ElseIf LinkReportType = "InstrumentReport" Then
                    SelectReport.ClearSelection()
                    SelectReport.Items.Clear()
                    SelectReport.Items.Insert(0, "...Select Report Type...")
                    SelectReport.Items.Insert(1, "Company Report")
                    SelectReport.Items.Insert(2, "Instrument Report")
                    'SelectReport.Items.Insert(3, "Import Permit Report")
                    SelectReport.Items.Insert(3, "Export Permit Report")
                    SelectReport.Items.Insert(4, "Company Request Report")
                    SelectReport.Items.Insert(5, "Invoice Report")
                    SelectReport.Items.FindByText("Instrument Report").Selected = True

                    Try
                        ConnectDatabase()
                        CompanyReport.LocalReport.DataSources.Clear()
                        CompanyReport.Visible = False
                        CompanyRequestReport.LocalReport.DataSources.Clear()
                        CompanyRequestReport.Visible = False
                        ExportPermitReport.LocalReport.DataSources.Clear()
                        ExportPermitReport.Visible = False
                        InstrumentReport.LocalReport.DataSources.Clear()
                        InstrumentReport.Visible = False
                        InvoiceReport.LocalReport.DataSources.Clear()
                        InvoiceReport.Visible = False

                        Dim InstrumentData As New InstrumentDataSets()

                        Dim db As String = "SELECT * FROM deviceregistration"
                        Using cn As MySqlCommand = New MySqlCommand(db, conn)
                            Using da As New MySqlDataAdapter(cn)

                                da.Fill(InstrumentData, "InstrumentTable")
                                Dim dt As New DataTable
                                da.Fill(dt)

                                If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                    NoRecord.Visible = True
                                Else
                                    NoRecord.Visible = False

                                    'MessageBox.Show(Me, "There is data here!")
                                End If
                                InstrumentReport.ProcessingMode = ProcessingMode.Local
                                InstrumentReport.LocalReport.ReportPath = Server.MapPath("InstrumentReports.rdlc")

                                Dim datasource As New ReportDataSource("InstrumentDataSets", InstrumentData.Tables(0))

                                InstrumentReport.LocalReport.DataSources.Clear()
                                InstrumentReport.LocalReport.DataSources.Add(datasource)
                                InstrumentReport.Visible = True

                            End Using
                        End Using
                    Catch ex As Exception
                        MessageBox.Show(Me, ex.Message)
                    Finally
                        DisconnectDatabase()
                    End Try


                ElseIf LinkReportType = "ExportPermitReport" Then
                    SelectReport.ClearSelection()
                    SelectReport.Items.Clear()
                    SelectReport.Items.Insert(0, "...Select Report Type...")
                    SelectReport.Items.Insert(1, "Company Report")
                    SelectReport.Items.Insert(2, "Instrument Report")
                    'SelectReport.Items.Insert(3, "Import Permit Report")
                    SelectReport.Items.Insert(3, "Export Permit Report")
                    SelectReport.Items.Insert(4, "Company Request Report")
                    SelectReport.Items.Insert(5, "Invoice Report")
                    SelectReport.Items.FindByText("Export Permit Report").Selected = True

                    Try
                        ConnectDatabase()
                        CompanyReport.LocalReport.DataSources.Clear()
                        CompanyReport.Visible = False
                        CompanyRequestReport.LocalReport.DataSources.Clear()
                        CompanyRequestReport.Visible = False
                        InstrumentReport.LocalReport.DataSources.Clear()
                        InstrumentReport.Visible = False
                        InvoiceReport.LocalReport.DataSources.Clear()
                        InvoiceReport.Visible = False

                        Dim exportData As New ExportPermitDataSet()
                        Dim db As String = "SELECT * FROM exportpermit"

                        Using cn As MySqlCommand = New MySqlCommand(db, conn)
                            Using da As New MySqlDataAdapter(cn)
                                da.Fill(exportData, "ExportPermitTable")
                                Dim dt As New DataTable
                                da.Fill(dt)
                                If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                    NoRecord.Visible = True
                                Else
                                    NoRecord.Visible = False
                                    ' MessageBox.Show(Me, "There is data here!")
                                End If

                                ExportPermitReport.ProcessingMode = ProcessingMode.Local
                                ExportPermitReport.LocalReport.ReportPath = Server.MapPath("ExportPermitReports.rdlc")

                                Dim datasource As New ReportDataSource("ExportPermitDataSet", exportData.Tables(0))
                                ExportPermitReport.LocalReport.DataSources.Clear()
                                ExportPermitReport.LocalReport.DataSources.Add(datasource)
                                ExportPermitReport.Visible = True
                            End Using
                        End Using
                    Catch ex As Exception
                        MessageBox.Show(Me, ex.Message)
                    Finally
                        DisconnectDatabase()
                    End Try

                ElseIf LinkReportType = "InvoiceReport" Then
                    SelectReport.ClearSelection()
                    SelectReport.Items.Clear()
                    SelectReport.Items.Insert(0, "...Select Report Type...")
                    SelectReport.Items.Insert(1, "Company Report")
                    SelectReport.Items.Insert(2, "Instrument Report")
                    'SelectReport.Items.Insert(3, "Import Permit Report")
                    SelectReport.Items.Insert(3, "Export Permit Report")
                    SelectReport.Items.Insert(4, "Company Request Report")
                    SelectReport.Items.Insert(5, "Invoice Report")
                    SelectReport.Items.FindByText("Invoice Report").Selected = True

                    Try

                        ConnectDatabase()
                        CompanyReport.LocalReport.DataSources.Clear()
                        CompanyReport.Visible = False
                        CompanyRequestReport.LocalReport.DataSources.Clear()
                        CompanyRequestReport.Visible = False
                        ExportPermitReport.LocalReport.DataSources.Clear()
                        ExportPermitReport.Visible = False
                        InstrumentReport.LocalReport.DataSources.Clear()
                        InstrumentReport.Visible = False
                        InvoiceReport.LocalReport.DataSources.Clear()
                        InvoiceReport.Visible = False

                        Dim InvoiceData As New InvoiceDataSets()

                        Dim db As String = "SELECT * FROM payment"
                        Using cn As MySqlCommand = New MySqlCommand(db, conn)
                            Using da As New MySqlDataAdapter(cn)

                                da.Fill(InvoiceData, "InvoiceTable")
                                Dim dt As New DataTable
                                da.Fill(dt)

                                If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                    NoRecord.Visible = True
                                Else
                                    NoRecord.Visible = False

                                    'MessageBox.Show(Me, "There is data here!")
                                End If

                                InvoiceReport.ProcessingMode = ProcessingMode.Local
                                InvoiceReport.LocalReport.ReportPath = Server.MapPath("InvoiceReports.rdlc")

                                Dim datasource As New ReportDataSource("InvoiceDataSets", InvoiceData.Tables(0))

                                InvoiceReport.LocalReport.DataSources.Clear()
                                InvoiceReport.LocalReport.DataSources.Add(datasource)
                                InvoiceReport.Visible = True

                            End Using
                        End Using
                    Catch ex As Exception
                        MessageBox.Show(Me, ex.Message)
                    Finally
                        DisconnectDatabase()
                    End Try


                ElseIf LinkReportType = "ContraventionNotice" Then
                    SelectReport.ClearSelection()
                    SelectReport.Items.Clear()
                    SelectReport.Items.Insert(0, "...Select Report Type...")
                    SelectReport.Items.Insert(1, "Company Report")
                    SelectReport.Items.Insert(2, "Instrument Report")
                    'SelectReport.Items.Insert(3, "Import Permit Report")
                    SelectReport.Items.Insert(3, "Export Permit Report")
                    SelectReport.Items.Insert(4, "Company Request Report")
                    SelectReport.Items.Insert(5, "Invoice Report")
                    SelectReport.Items.FindByText("Invoice Report").Selected = True

                    NoRecord.Visible = True


                End If

            Else
                SelectReport.ClearSelection()
                SelectReport.Items.Clear()
                SelectReport.Items.Insert(0, "...Select Report Type...")
                SelectReport.Items.Insert(1, "Company Report")
                SelectReport.Items.Insert(2, "Instrument Report")
                'SelectReport.Items.Insert(3, "Import Permit Report")
                SelectReport.Items.Insert(3, "Export Permit Report")
                SelectReport.Items.Insert(4, "Company Request Report")
                SelectReport.Items.Insert(5, "Invoice Report")
                SelectReport.Items.FindByText("Company Report").Selected = True

                SelectReportParameter.ClearSelection()
                SelectReportParameter.Items.Clear()
                SelectReportParameter.Visible = False
                ReportParameterLabel.Visible = False



                Try
                    ConnectDatabase()
                    CompanyRequestReport.LocalReport.DataSources.Clear()
                    CompanyRequestReport.Visible = False
                    ExportPermitReport.LocalReport.DataSources.Clear()
                    ExportPermitReport.Visible = False
                    InstrumentReport.LocalReport.DataSources.Clear()
                    InstrumentReport.Visible = False
                    InvoiceReport.LocalReport.DataSources.Clear()
                    InvoiceReport.Visible = False

                    ReportParameterLabel.Visible = True
                    SelectReportParameter.Visible = True

                    Parameter.Enabled = False
                    Parameter.BackColor = Drawing.Color.DarkGray



                    SelectReportParameter.Items.Insert(0, "...No Report Parameter...")

                    Dim CompanyData As New CompanyDataSet()

                    Dim db As String = "SELECT * FROM company"
                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)

                            da.Fill(CompanyData, "CompanyTable")
                            Dim dt As New DataTable
                            da.Fill(dt)

                            If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                NoRecord.Visible = True
                            Else
                                NoRecord.Visible = False

                                'MessageBox.Show(Me, "There is data here!")
                            End If
                            CompanyReport.ProcessingMode = ProcessingMode.Local
                            CompanyReport.LocalReport.ReportPath = Server.MapPath("CompanyReport.rdlc")

                            Dim datasource As New ReportDataSource("CompanyDataSet", CompanyData.Tables(0))

                            CompanyReport.LocalReport.DataSources.Clear()
                            CompanyReport.LocalReport.DataSources.Add(datasource)
                            CompanyReport.Visible = True

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

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete

    End Sub

    Protected Sub SelectReport_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SelectReport.SelectedIndexChanged


        If SelectReport.SelectedItem.Text = "Company Report" Then
            SelectReportParameter.ClearSelection()
            SelectReportParameter.Items.Clear()
            SelectReportParameter.Items.Insert(0, "...No Report Parameter...")
            SelectReportParameter.Visible = True
            ReportParameterLabel.Visible = True

            ReportCategoryPanel.Visible = False
            SelectReportCategory.Visible = False
            ReportCategoryLabel.Visible = False

            Parameter.Enabled = False
            Parameter.BackColor = Drawing.Color.DarkGray


            Try
                ConnectDatabase()
                CompanyRequestReport.LocalReport.DataSources.Clear()
                CompanyRequestReport.Visible = False
                ExportPermitReport.LocalReport.DataSources.Clear()
                ExportPermitReport.Visible = False
                InstrumentReport.LocalReport.DataSources.Clear()
                InstrumentReport.Visible = False
                InvoiceReport.LocalReport.DataSources.Clear()
                InvoiceReport.Visible = False

                Dim CompanyData As New CompanyDataSet()

                Dim db As String = "SELECT * FROM company"
                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)

                        da.Fill(CompanyData, "CompanyTable")
                        Dim dt As New DataTable
                        da.Fill(dt)

                        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                            NoRecord.Visible = True
                        Else
                            NoRecord.Visible = False

                            'MessageBox.Show(Me, "There is data here!")
                        End If
                        CompanyReport.ProcessingMode = ProcessingMode.Local
                        CompanyReport.LocalReport.ReportPath = Server.MapPath("CompanyReport.rdlc")

                        Dim datasource As New ReportDataSource("CompanyDataSet", CompanyData.Tables(0))

                        CompanyReport.LocalReport.DataSources.Clear()
                        CompanyReport.LocalReport.DataSources.Add(datasource)
                        CompanyReport.Visible = True

                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
            End Try


        ElseIf SelectReport.SelectedItem.Text = "Company Request Report" Then
            SelectReportParameter.ClearSelection()
            SelectReportParameter.Items.Clear()
            SelectReportParameter.Items.Insert(0, "...Select Report Parameter...")
            SelectReportParameter.Items.Insert(1, "Approval Pattern")
            SelectReportParameter.Items.Insert(2, "Initial Verification")
            SelectReportParameter.Visible = True
            ReportParameterLabel.Visible = True

            ReportCategoryPanel.Visible = False
            SelectReportCategory.Visible = False
            ReportCategoryLabel.Visible = False

            Parameter.Enabled = False
            Parameter.BackColor = Drawing.Color.DarkGray


            Try
                ConnectDatabase()
                CompanyReport.LocalReport.DataSources.Clear()
                CompanyReport.Visible = False
                ExportPermitReport.LocalReport.DataSources.Clear()
                ExportPermitReport.Visible = False
                InstrumentReport.LocalReport.DataSources.Clear()
                InstrumentReport.Visible = False
                InvoiceReport.LocalReport.DataSources.Clear()
                InvoiceReport.Visible = False

                Dim InstrumentData As New CompanyRequestDataSet()
                Dim ParameterString As Integer = 1

                Dim db As String = "SELECT * FROM deviceregistration WHERE applyForCertificate='" & ParameterString & "' OR applyForVerificationCert='" & ParameterString & "'"
                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)

                        da.Fill(InstrumentData, "CompanyRequestTable")
                        Dim dt As New DataTable
                        da.Fill(dt)

                        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                            NoRecord.Visible = True
                        Else
                            NoRecord.Visible = False

                            'MessageBox.Show(Me, "There is data here!")
                        End If
                        CompanyRequestReport.ProcessingMode = ProcessingMode.Local
                        CompanyRequestReport.LocalReport.ReportPath = Server.MapPath("CompanyRequestReport.rdlc")

                        Dim datasource As New ReportDataSource("CompanyRequestDataSet", InstrumentData.Tables(0))

                        CompanyRequestReport.LocalReport.DataSources.Clear()
                        CompanyRequestReport.LocalReport.DataSources.Add(datasource)
                        CompanyRequestReport.Visible = True

                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
            End Try

        ElseIf SelectReport.SelectedItem.Text = "Instrument Report" Then
            SelectReportParameter.ClearSelection()
            SelectReportParameter.Items.Clear()
            SelectReportParameter.Items.Insert(0, "...Select Report Parameter...")
            SelectReportParameter.Items.Insert(1, "Company Name")
            SelectReportParameter.Items.Insert(2, "Sector")
            SelectReportParameter.Items.Insert(3, "Instrument Category")
            SelectReportParameter.Items.Insert(4, "Instrument Type")
            SelectReportParameter.Items.Insert(5, "Measurement Range")
            SelectReportParameter.Items.Insert(6, "Registration Date")
            SelectReportParameter.Visible = True
            ReportParameterLabel.Visible = True

            ReportCategoryPanel.Visible = False
            SelectReportCategory.Visible = False
            ReportCategoryLabel.Visible = False

            Parameter.Enabled = True
            Parameter.BackColor = Drawing.Color.White

            Try
                ConnectDatabase()
                CompanyReport.LocalReport.DataSources.Clear()
                CompanyReport.Visible = False
                CompanyRequestReport.LocalReport.DataSources.Clear()
                CompanyRequestReport.Visible = False
                ExportPermitReport.LocalReport.DataSources.Clear()
                ExportPermitReport.Visible = False
                InstrumentReport.LocalReport.DataSources.Clear()
                InstrumentReport.Visible = False
                InvoiceReport.LocalReport.DataSources.Clear()
                InvoiceReport.Visible = False

                Dim InstrumentData As New InstrumentDataSets()

                Dim db As String = "SELECT * FROM deviceregistration"
                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)

                        da.Fill(InstrumentData, "InstrumentTable")
                        Dim dt As New DataTable
                        da.Fill(dt)

                        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                            NoRecord.Visible = True
                        Else
                            NoRecord.Visible = False

                            'MessageBox.Show(Me, "There is data here!")
                        End If
                        InstrumentReport.ProcessingMode = ProcessingMode.Local
                        InstrumentReport.LocalReport.ReportPath = Server.MapPath("InstrumentReports.rdlc")

                        Dim datasource As New ReportDataSource("InstrumentDataSets", InstrumentData.Tables(0))

                        InstrumentReport.LocalReport.DataSources.Clear()
                        InstrumentReport.LocalReport.DataSources.Add(datasource)
                        InstrumentReport.Visible = True

                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
            End Try

        ElseIf SelectReport.SelectedItem.Text = "Import Permit Report" Then
            SelectReportParameter.ClearSelection()
            SelectReportParameter.Items.Clear()
            SelectReportParameter.Visible = False
            ReportParameterLabel.Visible = False

            ReportCategoryPanel.Visible = False
            SelectReportCategory.Visible = False
            ReportCategoryLabel.Visible = False

            Parameter.Enabled = True
            Parameter.BackColor = Drawing.Color.White

            NoRecord.Visible = True

            CompanyReport.LocalReport.DataSources.Clear()
            CompanyReport.Visible = False
            CompanyRequestReport.LocalReport.DataSources.Clear()
            CompanyRequestReport.Visible = False
            ExportPermitReport.LocalReport.DataSources.Clear()
            ExportPermitReport.Visible = False
            InstrumentReport.LocalReport.DataSources.Clear()
            InstrumentReport.Visible = False
            InvoiceReport.LocalReport.DataSources.Clear()
            InvoiceReport.Visible = False

        ElseIf SelectReport.SelectedItem.Text = "Export Permit Report" Then
            SelectReportParameter.ClearSelection()
            SelectReportParameter.Items.Clear()
            SelectReportParameter.Items.Insert(0, "...Select Report Parameter...")
            SelectReportParameter.Items.Insert(1, "Permit Quarter")
            SelectReportParameter.Items.Insert(2, "Product Name")
            SelectReportParameter.Items.Insert(3, "Port of Export")
            SelectReportParameter.Items.Insert(4, "Application Type")
            SelectReportParameter.Items.Insert(5, "Registration Date")
            SelectReportParameter.Items.Insert(6, "Approval Date")
            SelectReportParameter.Visible = True
            ReportParameterLabel.Visible = True

            Parameter.Enabled = True
            Parameter.BackColor = Drawing.Color.White

            Try
                ConnectDatabase()
                CompanyReport.LocalReport.DataSources.Clear()
                CompanyReport.Visible = False
                CompanyRequestReport.LocalReport.DataSources.Clear()
                CompanyRequestReport.Visible = False
                InstrumentReport.LocalReport.DataSources.Clear()
                InstrumentReport.Visible = False
                InvoiceReport.LocalReport.DataSources.Clear()
                InvoiceReport.Visible = False

                Dim exportData As New ExportPermitDataSet()
                Dim db As String = "SELECT * FROM exportpermit"

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)
                        da.Fill(exportData, "ExportPermitTable")
                        Dim dt As New DataTable
                        da.Fill(dt)
                        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                            NoRecord.Visible = True
                        Else
                            NoRecord.Visible = False
                            ' MessageBox.Show(Me, "There is data here!")
                        End If

                        ExportPermitReport.ProcessingMode = ProcessingMode.Local
                        ExportPermitReport.LocalReport.ReportPath = Server.MapPath("ExportPermitReports.rdlc")

                        Dim datasource As New ReportDataSource("ExportPermitDataSet", exportData.Tables(0))
                        ExportPermitReport.LocalReport.DataSources.Clear()
                        ExportPermitReport.LocalReport.DataSources.Add(datasource)
                        ExportPermitReport.Visible = True
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
            End Try

        ElseIf SelectReport.SelectedItem.Text = "Invoice Report" Then

            ReportCategoryPanel.Visible = True
            SelectReportCategory.Visible = True
            ReportCategoryLabel.Visible = True

            SelectReportCategory.ClearSelection()
            SelectReportCategory.Items.Clear()
            SelectReportCategory.Items.Insert(0, "...Select Report Category...")
            SelectReportCategory.Items.Insert(1, "Registration Invoice")
            SelectReportCategory.Items.Insert(2, "Export Permit Invoice")
            SelectReportCategory.Items.Insert(3, "Instrument Registration Invoice")
            SelectReportCategory.Items.Insert(4, "Pattern of Approval Invoice")
            SelectReportCategory.Items.Insert(4, "Adjusting Fee Invoice")
            SelectReportCategory.Items.Insert(5, "Annual Licensing Invoice")
            SelectReportCategory.Items.Insert(6, "Instrument Penalty Invoice")
            SelectReportCategory.Items.Insert(7, "Export Permit Penalty Invoice")
            SelectReportCategory.Visible = True
            ReportCategoryLabel.Visible = True

            Parameter.Enabled = True
            Parameter.BackColor = Drawing.Color.White


            Try

                ConnectDatabase()
                CompanyReport.LocalReport.DataSources.Clear()
                CompanyReport.Visible = False
                CompanyRequestReport.LocalReport.DataSources.Clear()
                CompanyRequestReport.Visible = False
                ExportPermitReport.LocalReport.DataSources.Clear()
                ExportPermitReport.Visible = False
                InstrumentReport.LocalReport.DataSources.Clear()
                InstrumentReport.Visible = False
                InvoiceReport.LocalReport.DataSources.Clear()
                InvoiceReport.Visible = False

                Dim InvoiceData As New InvoiceDataSets()

                Dim db As String = "SELECT * FROM payment"
                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)

                        da.Fill(InvoiceData, "InvoiceTable")
                        Dim dt As New DataTable
                        da.Fill(dt)

                        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                            NoRecord.Visible = True
                        Else
                            NoRecord.Visible = False

                            'MessageBox.Show(Me, "There is data here!")
                        End If

                        InvoiceReport.ProcessingMode = ProcessingMode.Local
                        InvoiceReport.LocalReport.ReportPath = Server.MapPath("InvoiceReports.rdlc")

                        Dim datasource As New ReportDataSource("InvoiceDataSets", InvoiceData.Tables(0))

                        InvoiceReport.LocalReport.DataSources.Clear()
                        InvoiceReport.LocalReport.DataSources.Add(datasource)
                        InvoiceReport.Visible = True

                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
            End Try



        ElseIf SelectReport.SelectedItem.Text = "...Select Report Type..." Then
            MessageBox.Show(Me, "Please select a valid Report Type!")
            SelectReportParameter.ClearSelection()
            SelectReportParameter.Items.Clear()
            SelectReportParameter.Items.Insert(0, "...No Report Parameter...")
            SelectReportParameter.Visible = True
            ReportParameterLabel.Visible = True

            CompanyReport.LocalReport.DataSources.Clear()
            CompanyReport.Visible = False
            CompanyRequestReport.LocalReport.DataSources.Clear()
            CompanyRequestReport.Visible = False
            ExportPermitReport.LocalReport.DataSources.Clear()
            ExportPermitReport.Visible = False
            InstrumentReport.LocalReport.DataSources.Clear()
            InstrumentReport.Visible = False
            InvoiceReport.LocalReport.DataSources.Clear()
            InvoiceReport.Visible = False

            Parameter.Enabled = True
            Parameter.BackColor = Drawing.Color.White

            NoRecord.Visible = True

        ElseIf SelectReport.SelectedItem.Text = "Contravention Notice" Then
            SelectReportParameter.ClearSelection()
            SelectReportParameter.Items.Clear()
            SelectReportParameter.Visible = False
            ReportParameterLabel.Visible = False


            NoRecord.Visible = True

            CompanyReport.LocalReport.DataSources.Clear()
            CompanyReport.Visible = False
            CompanyRequestReport.LocalReport.DataSources.Clear()
            CompanyRequestReport.Visible = False
            ExportPermitReport.LocalReport.DataSources.Clear()
            ExportPermitReport.Visible = False
            InstrumentReport.LocalReport.DataSources.Clear()
            InstrumentReport.Visible = False
            InvoiceReport.LocalReport.DataSources.Clear()
            InvoiceReport.Visible = False

        End If


    End Sub



    Protected Sub SelectReportCategory_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SelectReportCategory.SelectedIndexChanged

        ReportCategoryPanel.Visible = True
        SelectReportCategory.Visible = True
        ReportCategoryLabel.Visible = True

        SelectReportParameter.ClearSelection()
        SelectReportParameter.Items.Clear()
        SelectReportParameter.Items.Insert(0, "...Select Report Parameter...")
        SelectReportParameter.Items.Insert(1, "Company Name")
        SelectReportParameter.Items.Insert(2, "Invoice Date")
        SelectReportParameter.Items.Insert(3, "Payment Status")
        SelectReportParameter.Items.Insert(4, "Payment Date")
        SelectReportParameter.Items.Insert(5, "Approval Status")
        SelectReportParameter.Items.Insert(6, "Approval Date")
        SelectReportParameter.Visible = True
        ReportParameterLabel.Visible = True

        Parameter.Enabled = True
        Parameter.BackColor = Drawing.Color.White

        If SelectReportCategory.SelectedItem.Text = "...Select Report Category..." Then

            MessageBox.Show(Me, "Please select a valid Report Category!")
            SelectReportParameter.ClearSelection()
            SelectReportParameter.Items.Clear()
            SelectReportParameter.Items.Insert(0, "...No Report Parameter...")
            SelectReportParameter.Visible = True
            ReportParameterLabel.Visible = True


            Try
                ConnectDatabase()
                CompanyRequestReport.LocalReport.DataSources.Clear()
                CompanyRequestReport.Visible = False
                ExportPermitReport.LocalReport.DataSources.Clear()
                ExportPermitReport.Visible = False
                InstrumentReport.LocalReport.DataSources.Clear()
                InstrumentReport.Visible = False
                InvoiceReport.LocalReport.DataSources.Clear()
                InvoiceReport.Visible = False
                
                Dim InvoiceData As New InvoiceDataSets()

                Dim db As String = "SELECT * FROM payment"
                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)

                        da.Fill(InvoiceData, "InvoiceTable")
                        Dim dt As New DataTable
                        da.Fill(dt)

                        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                            NoRecord.Visible = True
                        Else
                            NoRecord.Visible = False
                            'MessageBox.Show(Me, "There is data here!")
                        End If

                        InvoiceReport.ProcessingMode = ProcessingMode.Local
                        InvoiceReport.LocalReport.ReportPath = Server.MapPath("InvoiceReports.rdlc")

                        Dim datasource As New ReportDataSource("InvoiceDataSets", InvoiceData.Tables(0))

                        InvoiceReport.LocalReport.DataSources.Clear()
                        InvoiceReport.LocalReport.DataSources.Add(datasource)
                        InvoiceReport.Visible = True

                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
            End Try


        Else

            ReportCategoryPanel.Visible = True
            SelectReportCategory.Visible = True
            ReportCategoryLabel.Visible = True

            Try

                ConnectDatabase()
                CompanyReport.LocalReport.DataSources.Clear()
                CompanyReport.Visible = False
                CompanyRequestReport.LocalReport.DataSources.Clear()
                CompanyRequestReport.Visible = False
                ExportPermitReport.LocalReport.DataSources.Clear()
                ExportPermitReport.Visible = False
                InstrumentReport.LocalReport.DataSources.Clear()
                InstrumentReport.Visible = False
                InvoiceReport.LocalReport.DataSources.Clear()
                InvoiceReport.Visible = False

                Dim InvoiceData As New InvoiceDataSets()

                Dim db As String = "SELECT * FROM payment WHERE paymentFor = '" & SelectReportCategory.SelectedItem.Text & "'"
                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)

                        da.Fill(InvoiceData, "InvoiceTable")
                        Dim dt As New DataTable
                        da.Fill(dt)

                        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                            NoRecord.Visible = True
                        Else
                            NoRecord.Visible = False
                            'MessageBox.Show(Me, "There is data here!")
                        End If

                        InvoiceReport.ProcessingMode = ProcessingMode.Local
                        InvoiceReport.LocalReport.ReportPath = Server.MapPath("InvoiceReports.rdlc")

                        Dim datasource As New ReportDataSource("InvoiceDataSets", InvoiceData.Tables(0))

                        InvoiceReport.LocalReport.DataSources.Clear()
                        InvoiceReport.LocalReport.DataSources.Add(datasource)
                        InvoiceReport.Visible = True

                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
            End Try


        End If


    End Sub


    Protected Sub SelectReportParameter_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SelectReportParameter.SelectedIndexChanged

        If SelectReport.SelectedItem.Text = "Company Request Report" Then

            If SelectReportParameter.SelectedItem.Text = "...Select Report Parameter..." Then
                MessageBox.Show(Me, "Please select a valid Parameter!")

                CompanyReport.LocalReport.DataSources.Clear()
                CompanyReport.Visible = False
                CompanyRequestReport.LocalReport.DataSources.Clear()
                CompanyRequestReport.Visible = False
                ExportPermitReport.LocalReport.DataSources.Clear()
                ExportPermitReport.Visible = False
                InstrumentReport.LocalReport.DataSources.Clear()
                InstrumentReport.Visible = False
                InvoiceReport.LocalReport.DataSources.Clear()
                InvoiceReport.Visible = False

                NoRecord.Visible = True


            ElseIf SelectReportParameter.SelectedItem.Text = "Approval Pattern" Or SelectReportParameter.SelectedItem.Text = "Initial Verification" Then

                ConnectDatabase()
                CompanyReport.LocalReport.DataSources.Clear()
                CompanyReport.Visible = False
                ExportPermitReport.LocalReport.DataSources.Clear()
                ExportPermitReport.Visible = False
                InstrumentReport.LocalReport.DataSources.Clear()
                InstrumentReport.Visible = False
                InvoiceReport.LocalReport.DataSources.Clear()
                InvoiceReport.Visible = False

                Dim InstrumentData As New CompanyRequestDataSet()
                Dim ParameterString As Integer = 1

               
                If SelectReportParameter.SelectedItem.Text = "Approval Pattern" Then

                    Try
                        Dim db As String = "SELECT * FROM deviceregistration WHERE applyForCertificate='" & ParameterString & "'"
                        Using cn As MySqlCommand = New MySqlCommand(db, conn)
                            Using da As New MySqlDataAdapter(cn)

                                da.Fill(InstrumentData, "CompanyRequestTable")
                                Dim dt As New DataTable
                                da.Fill(dt)

                                If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                    NoRecord.Visible = True
                                Else
                                    NoRecord.Visible = False

                                    'MessageBox.Show(Me, "There is data here!")
                                End If
                                CompanyRequestReport.ProcessingMode = ProcessingMode.Local
                                CompanyRequestReport.LocalReport.ReportPath = Server.MapPath("CompanyRequestReport.rdlc")

                                Dim datasource As New ReportDataSource("CompanyRequestDataSet", InstrumentData.Tables(0))

                                CompanyRequestReport.LocalReport.DataSources.Clear()
                                CompanyRequestReport.LocalReport.DataSources.Add(datasource)
                                CompanyRequestReport.Visible = True

                            End Using
                        End Using
                    Catch ex As Exception
                        MessageBox.Show(Me, ex.Message)
                    Finally
                        DisconnectDatabase()
                    End Try

                ElseIf SelectReportParameter.SelectedItem.Text = "Initial Verification" Then
                    Try
                        Dim db As String = "SELECT * FROM deviceregistration WHERE applyForVerificationCert='" & ParameterString & "'"
                        Using cn As MySqlCommand = New MySqlCommand(db, conn)
                            Using da As New MySqlDataAdapter(cn)

                                da.Fill(InstrumentData, "CompanyRequestTable")
                                Dim dt As New DataTable
                                da.Fill(dt)

                                If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                    NoRecord.Visible = True
                                Else
                                    NoRecord.Visible = False

                                    'MessageBox.Show(Me, "There is data here!")
                                End If
                                CompanyRequestReport.ProcessingMode = ProcessingMode.Local
                                CompanyRequestReport.LocalReport.ReportPath = Server.MapPath("CompanyRequestReport.rdlc")

                                Dim datasource As New ReportDataSource("CompanyRequestDataSet", InstrumentData.Tables(0))

                                CompanyRequestReport.LocalReport.DataSources.Clear()
                                CompanyRequestReport.LocalReport.DataSources.Add(datasource)
                                CompanyRequestReport.Visible = True

                            End Using
                        End Using
                    Catch ex As Exception
                        MessageBox.Show(Me, ex.Message)
                    Finally
                        DisconnectDatabase()
                    End Try

                End If



            End If
        End If

        If SelectReportParameter.SelectedItem.Text.Contains("Date") Then
            Parameter.Visible = False
            FilterDateFrom.Visible = True
            FilterDateTo.Visible = True
            GetDate.Visible = True
            'ReportParameterLabel.Visible = False

        Else
            Parameter.Visible = True
            FilterDateFrom.Visible = False
            FilterDateTo.Visible = False
            GetDate.Visible = False
            'ParameterLabel.Visible = True

        End If

    End Sub



    Protected Sub ShowReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowReport.Click

        If SelectReport.SelectedItem.Text = "Instrument Report" Then

            If SelectReportParameter.SelectedItem.Text = "...Select Report Parameter..." Then
                MessageBox.Show(Me, "Please select a valid Parameter!")

                CompanyReport.LocalReport.DataSources.Clear()
                CompanyReport.Visible = False
                CompanyRequestReport.LocalReport.DataSources.Clear()
                CompanyRequestReport.Visible = False
                ExportPermitReport.LocalReport.DataSources.Clear()
                ExportPermitReport.Visible = False
                InstrumentReport.LocalReport.DataSources.Clear()
                InstrumentReport.Visible = False
                InvoiceReport.LocalReport.DataSources.Clear()
                InvoiceReport.Visible = False

                NoRecord.Visible = True


            ElseIf SelectReportParameter.SelectedItem.Text = "Company Name" Or SelectReportParameter.SelectedItem.Text = "Sector" Or SelectReportParameter.SelectedItem.Text = "Instrument Category" Or SelectReportParameter.SelectedItem.Text = "Instrument Type" Or SelectReportParameter.SelectedItem.Text = "Measurement Range" Or SelectReportParameter.SelectedItem.Text = "Registration Date" Then

                CompanyReport.LocalReport.DataSources.Clear()
                CompanyReport.Visible = False
                CompanyRequestReport.LocalReport.DataSources.Clear()
                CompanyRequestReport.Visible = False
                ExportPermitReport.LocalReport.DataSources.Clear()
                ExportPermitReport.Visible = False
                InstrumentReport.LocalReport.DataSources.Clear()
                InstrumentReport.Visible = False
                InvoiceReport.LocalReport.DataSources.Clear()
                InvoiceReport.Visible = False


                If SelectReportParameter.SelectedItem.Text = "Company Name" Then

                    Try
                        ConnectDatabase()

                        Dim InstrumentData As New InstrumentDataSets()

                        Dim db As String = "SELECT * FROM deviceregistration WHERE companyName LIKE '%" & Parameter.Text & "%'"
                        Using cn As MySqlCommand = New MySqlCommand(db, conn)
                            Using da As New MySqlDataAdapter(cn)

                                da.Fill(InstrumentData, "InstrumentTable")
                                Dim dt As New DataTable
                                da.Fill(dt)

                                If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                    NoRecord.Visible = True
                                Else
                                    NoRecord.Visible = False

                                    'MessageBox.Show(Me, "There is data here!")
                                End If
                                InstrumentReport.ProcessingMode = ProcessingMode.Local
                                InstrumentReport.LocalReport.ReportPath = Server.MapPath("InstrumentReports.rdlc")

                                Dim datasource As New ReportDataSource("InstrumentDataSets", InstrumentData.Tables(0))

                                InstrumentReport.LocalReport.DataSources.Clear()
                                InstrumentReport.LocalReport.DataSources.Add(datasource)
                                InstrumentReport.Visible = True

                            End Using
                        End Using
                    Catch ex As Exception
                        MessageBox.Show(Me, ex.Message)
                    Finally
                        DisconnectDatabase()
                    End Try

                ElseIf SelectReportParameter.SelectedItem.Text = "Sector" Then

                    Try
                        ConnectDatabase()

                        Dim InstrumentData As New InstrumentDataSets()

                        Dim db As String = "SELECT * FROM deviceregistration WHERE sector LIKE '%" & Parameter.Text & "%'"
                        Using cn As MySqlCommand = New MySqlCommand(db, conn)
                            Using da As New MySqlDataAdapter(cn)

                                da.Fill(InstrumentData, "InstrumentTable")
                                Dim dt As New DataTable
                                da.Fill(dt)

                                If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                    NoRecord.Visible = True
                                Else
                                    NoRecord.Visible = False

                                    'MessageBox.Show(Me, "There is data here!")
                                End If
                                InstrumentReport.ProcessingMode = ProcessingMode.Local
                                InstrumentReport.LocalReport.ReportPath = Server.MapPath("InstrumentReports.rdlc")

                                Dim datasource As New ReportDataSource("InstrumentDataSets", InstrumentData.Tables(0))

                                InstrumentReport.LocalReport.DataSources.Clear()
                                InstrumentReport.LocalReport.DataSources.Add(datasource)
                                InstrumentReport.Visible = True

                            End Using
                        End Using
                    Catch ex As Exception
                        MessageBox.Show(Me, ex.Message)
                    Finally
                        DisconnectDatabase()
                    End Try

                ElseIf SelectReportParameter.SelectedItem.Text = "Instrument Category" Then
                    Try
                        ConnectDatabase()

                        Dim InstrumentData As New InstrumentDataSets()

                        Dim db As String = "SELECT * FROM deviceregistration WHERE instrumentCategory LIKE '%" & Parameter.Text & "%'"
                        Using cn As MySqlCommand = New MySqlCommand(db, conn)
                            Using da As New MySqlDataAdapter(cn)

                                da.Fill(InstrumentData, "InstrumentTable")
                                Dim dt As New DataTable
                                da.Fill(dt)

                                If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                    NoRecord.Visible = True
                                Else
                                    NoRecord.Visible = False

                                    'MessageBox.Show(Me, "There is data here!")
                                End If
                                InstrumentReport.ProcessingMode = ProcessingMode.Local
                                InstrumentReport.LocalReport.ReportPath = Server.MapPath("InstrumentReports.rdlc")

                                Dim datasource As New ReportDataSource("InstrumentDataSets", InstrumentData.Tables(0))

                                InstrumentReport.LocalReport.DataSources.Clear()
                                InstrumentReport.LocalReport.DataSources.Add(datasource)
                                InstrumentReport.Visible = True

                            End Using
                        End Using
                    Catch ex As Exception
                        MessageBox.Show(Me, ex.Message)
                    Finally
                        DisconnectDatabase()
                    End Try

                ElseIf SelectReportParameter.SelectedItem.Text = "Instrument Type" Then
                    Try
                        ConnectDatabase()

                        Dim InstrumentData As New InstrumentDataSets()

                        Dim db As String = "SELECT * FROM deviceregistration WHERE deviceType LIKE '%" & Parameter.Text & "%'"
                        Using cn As MySqlCommand = New MySqlCommand(db, conn)
                            Using da As New MySqlDataAdapter(cn)

                                da.Fill(InstrumentData, "InstrumentTable")
                                Dim dt As New DataTable
                                da.Fill(dt)

                                If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                    NoRecord.Visible = True
                                Else
                                    NoRecord.Visible = False

                                    'MessageBox.Show(Me, "There is data here!")
                                End If
                                InstrumentReport.ProcessingMode = ProcessingMode.Local
                                InstrumentReport.LocalReport.ReportPath = Server.MapPath("InstrumentReports.rdlc")

                                Dim datasource As New ReportDataSource("InstrumentDataSets", InstrumentData.Tables(0))

                                InstrumentReport.LocalReport.DataSources.Clear()
                                InstrumentReport.LocalReport.DataSources.Add(datasource)
                                InstrumentReport.Visible = True

                            End Using
                        End Using
                    Catch ex As Exception
                        MessageBox.Show(Me, ex.Message)
                    Finally
                        DisconnectDatabase()
                    End Try

                ElseIf SelectReportParameter.SelectedItem.Text = "Measurement Range" Then
                    Try
                        ConnectDatabase()

                        Dim InstrumentData As New InstrumentDataSets()

                        Dim db As String = "SELECT * FROM deviceregistration WHERE measurementRange LIKE '%" & Parameter.Text & "%'"
                        Using cn As MySqlCommand = New MySqlCommand(db, conn)
                            Using da As New MySqlDataAdapter(cn)

                                da.Fill(InstrumentData, "InstrumentTable")
                                Dim dt As New DataTable
                                da.Fill(dt)

                                If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                    NoRecord.Visible = True
                                Else
                                    NoRecord.Visible = False

                                    'MessageBox.Show(Me, "There is data here!")
                                End If
                                InstrumentReport.ProcessingMode = ProcessingMode.Local
                                InstrumentReport.LocalReport.ReportPath = Server.MapPath("InstrumentReports.rdlc")

                                Dim datasource As New ReportDataSource("InstrumentDataSets", InstrumentData.Tables(0))

                                InstrumentReport.LocalReport.DataSources.Clear()
                                InstrumentReport.LocalReport.DataSources.Add(datasource)
                                InstrumentReport.Visible = True

                            End Using
                        End Using
                    Catch ex As Exception
                        MessageBox.Show(Me, ex.Message)
                    Finally
                        DisconnectDatabase()
                    End Try

                   

                End If

            End If

        ElseIf SelectReport.SelectedItem.Text = "Export Permit Report" Then


            If SelectReportParameter.SelectedItem.Text = "...Select Report Parameter..." Then
                MessageBox.Show(Me, "Please select a valid Parameter!")

                CompanyReport.LocalReport.DataSources.Clear()
                CompanyReport.Visible = False
                CompanyRequestReport.LocalReport.DataSources.Clear()
                CompanyRequestReport.Visible = False
                ExportPermitReport.LocalReport.DataSources.Clear()
                ExportPermitReport.Visible = False
                InstrumentReport.LocalReport.DataSources.Clear()
                InstrumentReport.Visible = False
                InvoiceReport.LocalReport.DataSources.Clear()
                InvoiceReport.Visible = False

                NoRecord.Visible = True


            ElseIf SelectReportParameter.SelectedItem.Text = "Permit Quarter" Or SelectReportParameter.SelectedItem.Text = "Product Name" Or SelectReportParameter.SelectedItem.Text = "Port of Export" Or SelectReportParameter.SelectedItem.Text = "Application Type" Or SelectReportParameter.SelectedItem.Text = "Registration Date" Or SelectReportParameter.SelectedItem.Text = "Approval Date" Then


                ConnectDatabase()
                CompanyReport.LocalReport.DataSources.Clear()
                CompanyReport.Visible = False
                CompanyRequestReport.LocalReport.DataSources.Clear()
                CompanyRequestReport.Visible = False
                InstrumentReport.LocalReport.DataSources.Clear()
                InstrumentReport.Visible = False
                InvoiceReport.LocalReport.DataSources.Clear()
                InvoiceReport.Visible = False

                If SelectReportParameter.SelectedItem.Text = "Permit Quarter" Then
                    Try
                        Dim exportData As New ExportPermitDataSet()
                        Dim db As String = "SELECT * FROM exportpermit WHERE exportPermitName LIKE '%" & Parameter.Text & "%'"

                        Using cn As MySqlCommand = New MySqlCommand(db, conn)
                            Using da As New MySqlDataAdapter(cn)
                                da.Fill(exportData, "ExportPermitTable")
                                Dim dt As New DataTable
                                da.Fill(dt)
                                If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                    NoRecord.Visible = True
                                Else
                                    NoRecord.Visible = False
                                    ' MessageBox.Show(Me, "There is data here!")
                                End If

                                ExportPermitReport.ProcessingMode = ProcessingMode.Local
                                ExportPermitReport.LocalReport.ReportPath = Server.MapPath("ExportPermitReports.rdlc")

                                Dim datasource As New ReportDataSource("ExportPermitDataSet", exportData.Tables(0))
                                ExportPermitReport.LocalReport.DataSources.Clear()
                                ExportPermitReport.LocalReport.DataSources.Add(datasource)
                                ExportPermitReport.Visible = True
                            End Using
                        End Using
                    Catch ex As Exception
                        MessageBox.Show(Me, ex.Message)
                    Finally
                        DisconnectDatabase()
                    End Try


                ElseIf SelectReportParameter.SelectedItem.Text = "Product Name" Then
                    Try
                        Dim exportData As New ExportPermitDataSet()
                        Dim db As String = "SELECT * FROM exportpermit WHERE productName LIKE '%" & Parameter.Text & "%'"

                        Using cn As MySqlCommand = New MySqlCommand(db, conn)
                            Using da As New MySqlDataAdapter(cn)
                                da.Fill(exportData, "ExportPermitTable")
                                Dim dt As New DataTable
                                da.Fill(dt)
                                If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                    NoRecord.Visible = True
                                Else
                                    NoRecord.Visible = False
                                    ' MessageBox.Show(Me, "There is data here!")
                                End If

                                ExportPermitReport.ProcessingMode = ProcessingMode.Local
                                ExportPermitReport.LocalReport.ReportPath = Server.MapPath("ExportPermitReports.rdlc")

                                Dim datasource As New ReportDataSource("ExportPermitDataSet", exportData.Tables(0))
                                ExportPermitReport.LocalReport.DataSources.Clear()
                                ExportPermitReport.LocalReport.DataSources.Add(datasource)
                                ExportPermitReport.Visible = True
                            End Using
                        End Using
                    Catch ex As Exception
                        MessageBox.Show(Me, ex.Message)
                    Finally
                        DisconnectDatabase()
                    End Try
                ElseIf SelectReportParameter.SelectedItem.Text = "Port of Export" Then
                    Try
                        Dim exportData As New ExportPermitDataSet()
                        Dim db As String = "SELECT * FROM exportpermit WHERE exportPort LIKE '%" & Parameter.Text & "%'"

                        Using cn As MySqlCommand = New MySqlCommand(db, conn)
                            Using da As New MySqlDataAdapter(cn)
                                da.Fill(exportData, "ExportPermitTable")
                                Dim dt As New DataTable
                                da.Fill(dt)
                                If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                    NoRecord.Visible = True
                                Else
                                    NoRecord.Visible = False
                                    ' MessageBox.Show(Me, "There is data here!")
                                End If

                                ExportPermitReport.ProcessingMode = ProcessingMode.Local
                                ExportPermitReport.LocalReport.ReportPath = Server.MapPath("ExportPermitReports.rdlc")

                                Dim datasource As New ReportDataSource("ExportPermitDataSet", exportData.Tables(0))
                                ExportPermitReport.LocalReport.DataSources.Clear()
                                ExportPermitReport.LocalReport.DataSources.Add(datasource)
                                ExportPermitReport.Visible = True
                            End Using
                        End Using
                    Catch ex As Exception
                        MessageBox.Show(Me, ex.Message)
                    Finally
                        DisconnectDatabase()
                    End Try
                ElseIf SelectReportParameter.SelectedItem.Text = "Application Type" Then
                    Try
                        Dim exportData As New ExportPermitDataSet()
                        Dim db As String = "SELECT * FROM exportpermit WHERE applicationType LIKE '%" & Parameter.Text & "%'"

                        Using cn As MySqlCommand = New MySqlCommand(db, conn)
                            Using da As New MySqlDataAdapter(cn)
                                da.Fill(exportData, "ExportPermitTable")
                                Dim dt As New DataTable
                                da.Fill(dt)
                                If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                    NoRecord.Visible = True
                                Else
                                    NoRecord.Visible = False
                                    ' MessageBox.Show(Me, "There is data here!")
                                End If

                                ExportPermitReport.ProcessingMode = ProcessingMode.Local
                                ExportPermitReport.LocalReport.ReportPath = Server.MapPath("ExportPermitReports.rdlc")

                                Dim datasource As New ReportDataSource("ExportPermitDataSet", exportData.Tables(0))
                                ExportPermitReport.LocalReport.DataSources.Clear()
                                ExportPermitReport.LocalReport.DataSources.Add(datasource)
                                ExportPermitReport.Visible = True
                            End Using
                        End Using
                    Catch ex As Exception
                        MessageBox.Show(Me, ex.Message)
                    Finally
                        DisconnectDatabase()
                    End Try
                 
                End If


            End If

        ElseIf SelectReport.SelectedItem.Text = "Invoice Report" Then

            If SelectReportParameter.SelectedItem.Text = "...Select Report Parameter..." Then
                MessageBox.Show(Me, "Please select a valid Parameter!")

                CompanyReport.LocalReport.DataSources.Clear()
                CompanyReport.Visible = False
                CompanyRequestReport.LocalReport.DataSources.Clear()
                CompanyRequestReport.Visible = False
                ExportPermitReport.LocalReport.DataSources.Clear()
                ExportPermitReport.Visible = False
                InstrumentReport.LocalReport.DataSources.Clear()
                InstrumentReport.Visible = False
                InvoiceReport.LocalReport.DataSources.Clear()
                InvoiceReport.Visible = False

                NoRecord.Visible = True


            ElseIf SelectReportParameter.SelectedItem.Text = "Company Name" Or SelectReportParameter.SelectedItem.Text = "Invoice Date" Or SelectReportParameter.SelectedItem.Text = "Payment Status" Or SelectReportParameter.SelectedItem.Text = "Payment Date" Or SelectReportParameter.SelectedItem.Text = "Approval Status" Or SelectReportParameter.SelectedItem.Text = "Approval Date" Then

                CompanyReport.LocalReport.DataSources.Clear()
                CompanyReport.Visible = False
                CompanyRequestReport.LocalReport.DataSources.Clear()
                CompanyRequestReport.Visible = False
                ExportPermitReport.LocalReport.DataSources.Clear()
                ExportPermitReport.Visible = False
                InstrumentReport.LocalReport.DataSources.Clear()
                InstrumentReport.Visible = False
                InvoiceReport.LocalReport.DataSources.Clear()
                InvoiceReport.Visible = False

                If SelectReportParameter.SelectedItem.Text = "Company Name" Then
                    Try
                        ConnectDatabase()

                        Dim InvoiceData As New InvoiceDataSets()

                        Dim db As String = "SELECT * FROM payment  WHERE paymentFor='" & SelectReportCategory.SelectedItem.Text & "' AND companyName LIKE '%" & Parameter.Text & "%'"
                        Using cn As MySqlCommand = New MySqlCommand(db, conn)
                            Using da As New MySqlDataAdapter(cn)

                                da.Fill(InvoiceData, "InvoiceTable")
                                Dim dt As New DataTable
                                da.Fill(dt)

                                If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                    NoRecord.Visible = True
                                Else
                                    NoRecord.Visible = False

                                    'MessageBox.Show(Me, "There is data here!")
                                End If

                                InvoiceReport.ProcessingMode = ProcessingMode.Local
                                InvoiceReport.LocalReport.ReportPath = Server.MapPath("InvoiceReports.rdlc")

                                Dim datasource As New ReportDataSource("InvoiceDataSets", InvoiceData.Tables(0))

                                InvoiceReport.LocalReport.DataSources.Clear()
                                InvoiceReport.LocalReport.DataSources.Add(datasource)
                                InvoiceReport.Visible = True

                            End Using
                        End Using
                    Catch ex As Exception
                        MessageBox.Show(Me, ex.Message)
                    Finally
                        DisconnectDatabase()
                    End Try


                ElseIf SelectReportParameter.SelectedItem.Text = "Payment Status" Then
                    Dim ParameterString As String

                    If Parameter.Text.Contains("Un") Or Parameter.Text.Contains("un") Then
                        ParameterString = "Unpaid"

                        Try
                            ConnectDatabase()

                            Dim InvoiceData As New InvoiceDataSets()

                            Dim db As String = "SELECT * FROM payment  WHERE paymentFor='" & SelectReportCategory.SelectedItem.Text & "' AND paymentStatus LIKE '%" & ParameterString & "%'"
                            Using cn As MySqlCommand = New MySqlCommand(db, conn)
                                Using da As New MySqlDataAdapter(cn)

                                    da.Fill(InvoiceData, "InvoiceTable")
                                    Dim dt As New DataTable
                                    da.Fill(dt)

                                    If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                        NoRecord.Visible = True
                                    Else
                                        NoRecord.Visible = False

                                        'MessageBox.Show(Me, "There is data here!")
                                    End If

                                    InvoiceReport.ProcessingMode = ProcessingMode.Local
                                    InvoiceReport.LocalReport.ReportPath = Server.MapPath("InvoiceReports.rdlc")

                                    Dim datasource As New ReportDataSource("InvoiceDataSets", InvoiceData.Tables(0))

                                    InvoiceReport.LocalReport.DataSources.Clear()
                                    InvoiceReport.LocalReport.DataSources.Add(datasource)
                                    InvoiceReport.Visible = True

                                End Using
                            End Using
                        Catch ex As Exception
                            MessageBox.Show(Me, ex.Message)
                        Finally
                            DisconnectDatabase()
                        End Try

                    ElseIf Parameter.Text.Contains("P") Or Parameter.Text.Contains("p") Or Parameter.Text.Contains("Pa") Or Parameter.Text.Contains("pa") Then
                        ParameterString = "paid"
                        Try
                            ConnectDatabase()

                            Dim InvoiceData As New InvoiceDataSets()

                            Dim db As String = "SELECT * FROM payment  WHERE paymentStatus = '" & ParameterString & "'"
                            Using cn As MySqlCommand = New MySqlCommand(db, conn)
                                Using da As New MySqlDataAdapter(cn)

                                    da.Fill(InvoiceData, "InvoiceTable")
                                    Dim dt As New DataTable
                                    da.Fill(dt)

                                    If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                        NoRecord.Visible = True
                                    Else
                                        NoRecord.Visible = False

                                        'MessageBox.Show(Me, "There is data here!")
                                    End If

                                    InvoiceReport.ProcessingMode = ProcessingMode.Local
                                    InvoiceReport.LocalReport.ReportPath = Server.MapPath("InvoiceReports.rdlc")

                                    Dim datasource As New ReportDataSource("InvoiceDataSets", InvoiceData.Tables(0))

                                    InvoiceReport.LocalReport.DataSources.Clear()
                                    InvoiceReport.LocalReport.DataSources.Add(datasource)
                                    InvoiceReport.Visible = True

                                End Using
                            End Using
                        Catch ex As Exception
                            MessageBox.Show(Me, ex.Message)
                        Finally
                            DisconnectDatabase()
                        End Try

                    End If

                   
                ElseIf SelectReportParameter.SelectedItem.Text = "Approval Status" Then
                    Try
                        ConnectDatabase()

                        Dim InvoiceData As New InvoiceDataSets()

                        Dim db As String = "SELECT * FROM payment  WHERE paymentFor='" & SelectReportCategory.SelectedItem.Text & "' AND approvalStatus LIKE '%" & Parameter.Text & "%'"
                        Using cn As MySqlCommand = New MySqlCommand(db, conn)
                            Using da As New MySqlDataAdapter(cn)

                                da.Fill(InvoiceData, "InvoiceTable")
                                Dim dt As New DataTable
                                da.Fill(dt)

                                If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                    NoRecord.Visible = True
                                Else
                                    NoRecord.Visible = False

                                    'MessageBox.Show(Me, "There is data here!")
                                End If

                                InvoiceReport.ProcessingMode = ProcessingMode.Local
                                InvoiceReport.LocalReport.ReportPath = Server.MapPath("InvoiceReports.rdlc")

                                Dim datasource As New ReportDataSource("InvoiceDataSets", InvoiceData.Tables(0))

                                InvoiceReport.LocalReport.DataSources.Clear()
                                InvoiceReport.LocalReport.DataSources.Add(datasource)
                                InvoiceReport.Visible = True

                            End Using
                        End Using
                    Catch ex As Exception
                        MessageBox.Show(Me, ex.Message)
                    Finally
                        DisconnectDatabase()
                    End Try

                End If

               
            End If


        ElseIf SelectReport.SelectedItem.Text = "...Select Report Type..." And SelectReportParameter.SelectedItem.Text = "...No Report Parameter..." Then
            MessageBox.Show(Me, "Please select a valid Report Type!")

            CompanyReport.LocalReport.DataSources.Clear()
            CompanyReport.Visible = False
            CompanyRequestReport.LocalReport.DataSources.Clear()
            CompanyRequestReport.Visible = False
            ExportPermitReport.LocalReport.DataSources.Clear()
            ExportPermitReport.Visible = False
            InstrumentReport.LocalReport.DataSources.Clear()
            InstrumentReport.Visible = False
            InvoiceReport.LocalReport.DataSources.Clear()
            InvoiceReport.Visible = False

            NoRecord.Visible = True


        End If


    End Sub

   

    Protected Sub GetDate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GetDate.Click

        If FilterDateFrom.Text = "" Or FilterDateTo.Text = "" Then
            MessageBox.Show(Me, "Date input cannot be left blank!")

        Else
            'MessageBox.Show(Me, CompareDateToDay() & "    " & CompareDateToMonth() & "    " & CompareDateToYear())


            Dim DateDifference

            Dim FormatStartDate = Date.ParseExact(FilterDateFrom.Text, "dd-MM-yyyy", Nothing)
            Dim FormatEndDate = Date.ParseExact(FilterDateTo.Text, "dd-MM-yyyy", Nothing)
            Dim DateFormat As String = "dd-MM-yyyy"
            Dim StartDate = FormatStartDate.ToString(DateFormat.ToString)
            Dim EndDate = FormatEndDate.ToString(DateFormat.ToString)



            Try
                Dim SelectedDate = Date.ParseExact(FilterDateFrom.Text, "dd-MM-yyyy", Nothing)
                Dim DateFormatDay As String = "dd"
                Dim DateFormatMonth As String = "MM"
                Dim DateFormatYear As String = "yyyy"
                Dim DateDay = SelectedDate.ToString(DateFormatDay.ToString)
                Dim DateMonth = SelectedDate.ToString(DateFormatMonth.ToString)
                Dim DateYear = SelectedDate.ToString(DateFormatYear.ToString)

                DateDifference = Date.ParseExact(FilterDateTo.Text, "dd-MM-yyyy", Nothing) - Date.ParseExact(FilterDateFrom.Text, "dd-MM-yyyy", Nothing)
                If DateDifference.ToString.Contains("-") Then

                    MessageBox.Show(Me, "Start Date cannot be higher than the End Date   " & DateDifference.ToString & " check the date to continue!")

                Else


                    If SelectReport.SelectedItem.Text = "Instrument Report" Then
                        If SelectReportParameter.SelectedItem.Text = "Registration Date" Then

                            CompanyReport.LocalReport.DataSources.Clear()
                            CompanyReport.Visible = False
                            CompanyRequestReport.LocalReport.DataSources.Clear()
                            CompanyRequestReport.Visible = False
                            ExportPermitReport.LocalReport.DataSources.Clear()
                            ExportPermitReport.Visible = False
                            InstrumentReport.LocalReport.DataSources.Clear()
                            InstrumentReport.Visible = False
                            InvoiceReport.LocalReport.DataSources.Clear()
                            InvoiceReport.Visible = False

                            Try
                                ConnectDatabase()

                                Dim InstrumentData As New InstrumentDataSets()
                                Dim db As String = "SELECT *, DATE_FORMAT(STR_TO_DATE(registrationDate, '%d-%m-%Y'), '%d-%m-%Y') As FormatedDate FROM deviceregistration WHERE DATE_FORMAT(STR_TO_DATE(registrationDate, '%d-%m-%Y'), '%d-%m-%Y') BETWEEN DATE_FORMAT(STR_TO_DATE('" & StartDate & "', '%d-%m-%Y'), '%d-%m-%Y') AND DATE_FORMAT(STR_TO_DATE('" & EndDate & "', '%d-%m-%Y'), '%d-%m-%Y')"
                                'Dim db As String = "SELECT *, STR_TO_DATE(registrationDate, '%d-%m-%Y') As FormatedDate, DATE_FORMAT(NOW(),'%d-%m-%Y') As Today FROM deviceregistration"
                                'Dim db As String = "SELECT *, registrationDate, DATE_FORMAT(registrationDate, '%d/%m/%Y') As FormatedDate, DATE_FORMAT(NOW(),'%d-%m-%Y') As Today FROM deviceregistration"
                                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                                    Using da As New MySqlDataAdapter(cn)

                                        da.Fill(InstrumentData, "InstrumentTable")
                                        Dim dt As New DataTable
                                        da.Fill(dt)

                                        Dim ds As New DataSet
                                        da.Fill(ds)

                                        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                            NoRecord.Visible = True

                                            InstrumentReport.Visible = True

                                        Else
                                            NoRecord.Visible = False


                                        End If

                                        'Dim TableDate = ds.Tables(0).Rows(0).Item("FormatedDate").ToString

                                        'MessageBox.Show(Me, "After convertion: " + TableDate & "  Start Date: " + StartDate & "  End Date : " + EndDate)

                                        InstrumentReport.ProcessingMode = ProcessingMode.Local
                                        InstrumentReport.LocalReport.ReportPath = Server.MapPath("InstrumentReports.rdlc")

                                        Dim datasource As New ReportDataSource("InstrumentDataSets", InstrumentData.Tables(0))

                                        InstrumentReport.LocalReport.DataSources.Clear()
                                        InstrumentReport.LocalReport.DataSources.Add(datasource)
                                        InstrumentReport.Visible = True


                                    End Using
                                End Using
                            Catch ex As Exception
                                MessageBox.Show(Me, ex.Message)
                            Finally
                                DisconnectDatabase()
                            End Try

                        End If

                    ElseIf SelectReport.SelectedItem.Text = "Export Permit Report" Then

                        CompanyReport.LocalReport.DataSources.Clear()
                        CompanyReport.Visible = False
                        CompanyRequestReport.LocalReport.DataSources.Clear()
                        CompanyRequestReport.Visible = False
                        ExportPermitReport.LocalReport.DataSources.Clear()
                        ExportPermitReport.Visible = False
                        InstrumentReport.LocalReport.DataSources.Clear()
                        InstrumentReport.Visible = False
                        InvoiceReport.LocalReport.DataSources.Clear()
                        InvoiceReport.Visible = False

                        If SelectReportParameter.SelectedItem.Text = "Registration Date" Then
                            Try
                                Dim exportData As New ExportPermitDataSet()
                                Dim db As String = "SELECT * FROM exportpermit WHERE DATE_FORMAT(STR_TO_DATE(registrationDate, '%d-%m-%Y'), '%d-%m-%Y') BETWEEN DATE_FORMAT(STR_TO_DATE('" & StartDate & "', '%d-%m-%Y'), '%d-%m-%Y') AND DATE_FORMAT(STR_TO_DATE('" & EndDate & "', '%d-%m-%Y'), '%d-%m-%Y')"

                                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                                    Using da As New MySqlDataAdapter(cn)
                                        da.Fill(exportData, "ExportPermitTable")
                                        Dim dt As New DataTable
                                        da.Fill(dt)
                                        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                            NoRecord.Visible = True
                                        Else
                                            NoRecord.Visible = False
                                            ' MessageBox.Show(Me, "There is data here!")
                                        End If


                                        ExportPermitReport.ProcessingMode = ProcessingMode.Local
                                        ExportPermitReport.LocalReport.ReportPath = Server.MapPath("ExportPermitReports.rdlc")

                                        Dim datasource As New ReportDataSource("ExportPermitDataSet", exportData.Tables(0))
                                        ExportPermitReport.LocalReport.DataSources.Clear()
                                        ExportPermitReport.LocalReport.DataSources.Add(datasource)
                                        ExportPermitReport.Visible = True
                                    End Using
                                End Using
                            Catch ex As Exception
                                MessageBox.Show(Me, ex.Message)
                            Finally
                                DisconnectDatabase()
                            End Try

                        ElseIf SelectReportParameter.SelectedItem.Text = "Approval Date" Then
                            Try
                                Dim exportData As New ExportPermitDataSet()
                                Dim db As String = "SELECT * FROM exportpermit WHERE DATE_FORMAT(STR_TO_DATE(approvalDate, '%d-%m-%Y'), '%d-%m-%Y') BETWEEN DATE_FORMAT(STR_TO_DATE('" & StartDate & "', '%d-%m-%Y'), '%d-%m-%Y') AND DATE_FORMAT(STR_TO_DATE('" & EndDate & "', '%d-%m-%Y'), '%d-%m-%Y')"

                                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                                    Using da As New MySqlDataAdapter(cn)
                                        da.Fill(exportData, "ExportPermitTable")
                                        Dim dt As New DataTable
                                        da.Fill(dt)
                                        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                            NoRecord.Visible = True
                                        Else
                                            NoRecord.Visible = False
                                            ' MessageBox.Show(Me, "There is data here!")
                                        End If

                                        ExportPermitReport.ProcessingMode = ProcessingMode.Local
                                        ExportPermitReport.LocalReport.ReportPath = Server.MapPath("ExportPermitReports.rdlc")

                                        Dim datasource As New ReportDataSource("ExportPermitDataSet", exportData.Tables(0))
                                        ExportPermitReport.LocalReport.DataSources.Clear()
                                        ExportPermitReport.LocalReport.DataSources.Add(datasource)
                                        ExportPermitReport.Visible = True
                                    End Using
                                End Using
                            Catch ex As Exception
                                MessageBox.Show(Me, ex.Message)
                            Finally
                                DisconnectDatabase()
                            End Try
                        End If

                    ElseIf SelectReport.SelectedItem.Text = "Invoice Report" Then

                        CompanyReport.LocalReport.DataSources.Clear()
                        CompanyReport.Visible = False
                        CompanyRequestReport.LocalReport.DataSources.Clear()
                        CompanyRequestReport.Visible = False
                        ExportPermitReport.LocalReport.DataSources.Clear()
                        ExportPermitReport.Visible = False
                        InstrumentReport.LocalReport.DataSources.Clear()
                        InstrumentReport.Visible = False
                        InvoiceReport.LocalReport.DataSources.Clear()
                        InvoiceReport.Visible = False

                        If SelectReportParameter.SelectedItem.Text = "Invoice Date" Then
                            Try
                                ConnectDatabase()

                                Dim InvoiceData As New InvoiceDataSets()

                                Dim db As String = "SELECT * FROM payment WHERE paymentFor='" & SelectReportCategory.SelectedItem.Text & "' AND DATE_FORMAT(STR_TO_DATE(invoiceDate, '%d-%m-%Y'), '%d-%m-%Y') BETWEEN DATE_FORMAT(STR_TO_DATE('" & StartDate & "', '%d-%m-%Y'), '%d-%m-%Y') AND DATE_FORMAT(STR_TO_DATE('" & EndDate & "', '%d-%m-%Y'), '%d-%m-%Y')"
                                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                                    Using da As New MySqlDataAdapter(cn)

                                        da.Fill(InvoiceData, "InvoiceTable")
                                        Dim dt As New DataTable
                                        da.Fill(dt)

                                        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                            NoRecord.Visible = True
                                        Else
                                            NoRecord.Visible = False

                                            'MessageBox.Show(Me, "There is data here!")
                                        End If

                                        InvoiceReport.ProcessingMode = ProcessingMode.Local
                                        InvoiceReport.LocalReport.ReportPath = Server.MapPath("InvoiceReports.rdlc")

                                        Dim datasource As New ReportDataSource("InvoiceDataSets", InvoiceData.Tables(0))

                                        InvoiceReport.LocalReport.DataSources.Clear()
                                        InvoiceReport.LocalReport.DataSources.Add(datasource)
                                        InvoiceReport.Visible = True

                                    End Using
                                End Using
                            Catch ex As Exception
                                MessageBox.Show(Me, ex.Message)
                            Finally
                                DisconnectDatabase()
                            End Try


                        ElseIf SelectReportParameter.SelectedItem.Text = "Payment Date" Then
                            Try
                                ConnectDatabase()

                                Dim InvoiceData As New InvoiceDataSets()

                                Dim db As String = "SELECT * FROM payment WHERE paymentFor='" & SelectReportCategory.SelectedItem.Text & "' AND DATE_FORMAT(STR_TO_DATE(paymentDate, '%d-%m-%Y'), '%d-%m-%Y') BETWEEN DATE_FORMAT(STR_TO_DATE('" & StartDate & "', '%d-%m-%Y'), '%d-%m-%Y') AND DATE_FORMAT(STR_TO_DATE('" & EndDate & "', '%d-%m-%Y'), '%d-%m-%Y')"
                                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                                    Using da As New MySqlDataAdapter(cn)

                                        da.Fill(InvoiceData, "InvoiceTable")
                                        Dim dt As New DataTable
                                        da.Fill(dt)

                                        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                            NoRecord.Visible = True
                                        Else
                                            NoRecord.Visible = False

                                            'MessageBox.Show(Me, "There is data here!")
                                        End If

                                        InvoiceReport.ProcessingMode = ProcessingMode.Local
                                        InvoiceReport.LocalReport.ReportPath = Server.MapPath("InvoiceReports.rdlc")

                                        Dim datasource As New ReportDataSource("InvoiceDataSets", InvoiceData.Tables(0))

                                        InvoiceReport.LocalReport.DataSources.Clear()
                                        InvoiceReport.LocalReport.DataSources.Add(datasource)
                                        InvoiceReport.Visible = True

                                    End Using
                                End Using
                            Catch ex As Exception
                                MessageBox.Show(Me, ex.Message)
                            Finally
                                DisconnectDatabase()
                            End Try


                        ElseIf SelectReportParameter.SelectedItem.Text = "Approval Date" Then
                            Try
                                ConnectDatabase()

                                Dim InvoiceData As New InvoiceDataSets()

                                Dim db As String = "SELECT * FROM payment WHERE paymentFor='" & SelectReportCategory.SelectedItem.Text & "' AND DATE_FORMAT(STR_TO_DATE(approvalDate, '%d-%m-%Y'), '%d-%m-%Y') BETWEEN DATE_FORMAT(STR_TO_DATE('" & StartDate & "', '%d-%m-%Y'), '%d-%m-%Y') AND DATE_FORMAT(STR_TO_DATE('" & EndDate & "', '%d-%m-%Y'), '%d-%m-%Y')"
                                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                                    Using da As New MySqlDataAdapter(cn)

                                        da.Fill(InvoiceData, "InvoiceTable")
                                        Dim dt As New DataTable
                                        da.Fill(dt)

                                        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                            NoRecord.Visible = True
                                        Else
                                            NoRecord.Visible = False

                                            'MessageBox.Show(Me, "There is data here!")
                                        End If

                                        InvoiceReport.ProcessingMode = ProcessingMode.Local
                                        InvoiceReport.LocalReport.ReportPath = Server.MapPath("InvoiceReports.rdlc")

                                        Dim datasource As New ReportDataSource("InvoiceDataSets", InvoiceData.Tables(0))

                                        InvoiceReport.LocalReport.DataSources.Clear()
                                        InvoiceReport.LocalReport.DataSources.Add(datasource)
                                        InvoiceReport.Visible = True

                                    End Using
                                End Using
                            Catch ex As Exception
                                MessageBox.Show(Me, ex.Message)
                            Finally
                                DisconnectDatabase()
                            End Try


                        End If


                    ElseIf SelectReport.SelectedItem.Text = "...Select Report Type..." And SelectReportParameter.SelectedItem.Text = "...No Report Parameter..." Then
                        MessageBox.Show(Me, "Please select a valid Report Type!")

                        CompanyReport.LocalReport.DataSources.Clear()
                        CompanyReport.Visible = False
                        CompanyRequestReport.LocalReport.DataSources.Clear()
                        CompanyRequestReport.Visible = False
                        ExportPermitReport.LocalReport.DataSources.Clear()
                        ExportPermitReport.Visible = False
                        InstrumentReport.LocalReport.DataSources.Clear()
                        InstrumentReport.Visible = False
                        InvoiceReport.LocalReport.DataSources.Clear()
                        InvoiceReport.Visible = False

                        NoRecord.Visible = True


                    End If

                End If


            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            End Try




        End If
         

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