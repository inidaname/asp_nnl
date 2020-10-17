Imports System.Web
Imports System.Data
Imports System.Text
Imports System.Web.Security
Imports System.Configuration
Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WebForms

Public Class _default17
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
        FilterParameter.Focus()


        If Not IsPostBack Then

            NoRecord.Visible = False
            ProcessingData.Visible = False
            FilterParameter.Visible = False
            Filter.Visible = False
            DateFrom.Visible = False
            DateTo.Visible = False
            Try
                ConnectDatabase()
                InvoiceReport.LocalReport.DataSources.Clear()
                InvoiceReport.Visible = False

                InstrumentReport.LocalReport.DataSources.Clear()
                InstrumentReport.Visible = False

                Dim exportData As New ExportPermit()
                Dim db As String = "SELECT referenceCode,exportPermitName,exporterName,productName,exportPort,quantity,amountPerBarrelUS,totalAmountUS,applicationDate FROM exportpermit WHERE CompanyID='" & Session("UserLoginID") & "'"

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
                        ExportPermitReport.LocalReport.ReportPath = Server.MapPath("ExportPermitReport.rdlc")

                        Dim datasource As New ReportDataSource("ExportPermit", exportData.Tables(0))
                        ExportPermitReport.LocalReport.DataSources.Clear()
                        ExportPermitReport.LocalReport.DataSources.Add(datasource)

                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
            End Try

        End If

    End Sub

    Sub SelectReport_SelectedIndexChanged(Sender As Object, e As EventArgs)
        'This display Export Permit Report
        If SelectReportName.SelectedValue = "Export" Then
            FilterReport.Items.Clear()
            FilterReport.Items.Insert(0, "Display All Data")
            FilterReport.Items.Insert(1, "Permit Quarter")
            FilterReport.Items.Insert(2, "Export Port")
            FilterReport.Items.Insert(3, "Product Name")
            FilterReport.Items.Insert(4, "Export Permit Date")

            Try
                ConnectDatabase()
                InvoiceReport.LocalReport.DataSources.Clear()
                InvoiceReport.Visible = False

                InstrumentReport.LocalReport.DataSources.Clear()
                InstrumentReport.Visible = False

                Dim exportData As New ExportPermit()
                Dim db As String = "SELECT referenceCode,exportPermitName,exporterName,productName,exportPort,quantity,amountPerBarrelUS,totalAmountUS,applicationDate FROM exportpermit WHERE CompanyID='" & Session("UserLoginID") & "'"

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
                        ExportPermitReport.LocalReport.ReportPath = Server.MapPath("ExportPermitReport.rdlc")

                        Dim datasource As New ReportDataSource("ExportPermit", exportData.Tables(0))
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

            'This display Invoice Report
        ElseIf SelectReportName.SelectedValue = "Invoice" Then
            FilterReport.Items.Clear()
            FilterReport.Items.Insert(0, "Display All Data")
            FilterReport.Items.Insert(1, "Payment Status")
            FilterReport.Items.Insert(2, "Approval Status")
            FilterReport.Items.Insert(3, "Invoice Date")
            Try
                ConnectDatabase()
                Dim InvoiceData As New InvoiceDataSet()

                Dim db As String = "SELECT transCode,amountDue,narration,amountPaid,paymentStatus,approvalStatus,orderId,invoiceDate FROM payment WHERE CompanyID='" & Session("UserLoginID") & "'"
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
                        InvoiceReport.LocalReport.ReportPath = Server.MapPath("InvoiceReport.rdlc")

                        Dim datasource As New ReportDataSource("InvoiceDataSet", InvoiceData.Tables(0))
                        'Clear other reports
                        ExportPermitReport.LocalReport.DataSources.Clear()
                        ExportPermitReport.Visible = False

                        InstrumentReport.LocalReport.DataSources.Clear()
                        InstrumentReport.Visible = False

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

            'This display Instrument Registration Report
        ElseIf SelectReportName.SelectedValue = "Instrument" Then
            FilterReport.Items.Clear()
            FilterReport.Items.Insert(0, "Display All Data")
            FilterReport.Items.Insert(1, "Device Type")
            FilterReport.Items.Insert(2, "Registration Date")
            

            Try
                ConnectDatabase()

                Dim InstrumentData As New InstrumentDataSets()

                Dim db As String = "SELECT * FROM deviceregistration WHERE CompanyID='" & Session("UserLoginID") & "'"
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
                        InstrumentReport.LocalReport.ReportPath = Server.MapPath("InstrumentReport.rdlc")

                        Dim datasource As New ReportDataSource("InstrumentDataSet", InstrumentData.Tables(0))
                        'Clear other reports
                        ExportPermitReport.LocalReport.DataSources.Clear()
                        ExportPermitReport.Visible = False

                        InvoiceReport.LocalReport.DataSources.Clear()
                        InvoiceReport.Visible = False

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
    End Sub

    Sub FilterReport_SelectedIndexChanged(Sender As Object, e As EventArgs)
        If FilterReport.SelectedValue.Contains("Date") Then
            FilterParameter.Visible = False
            DateFrom.Visible = True
            DateTo.Visible = True
            Filter.Visible = True
            Filters.Visible = False

        ElseIf FilterReport.SelectedValue.Contains("Display All Data") Then
            FilterParameter.Visible = False
            Filter.Visible = False
            Filters.Visible = False
            DateFrom.Visible = False
            DateTo.Visible = False

        Else
            FilterParameter.Visible = True
            Filters.Visible = True
            Filter.Visible = False
            DateFrom.Visible = False
            DateTo.Visible = False
        End If


    End Sub

    Protected Sub Filters_Click(sender As Object, e As EventArgs) Handles Filters.Click

            If FilterReport.SelectedValue = "Display All Data" Then
                Try
                    ConnectDatabase()
                    InvoiceReport.LocalReport.DataSources.Clear()
                    InvoiceReport.Visible = False

                    InstrumentReport.LocalReport.DataSources.Clear()
                    InstrumentReport.Visible = False

                    Dim exportData As New ExportPermit()
                    Dim db As String = "SELECT referenceCode,exportPermitName,exporterName,productName,exportPort,quantity,amountPerBarrelUS,totalAmountUS,applicationDate FROM exportpermit WHERE CompanyID='" & Session("UserLoginID") & "'"

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
                            ExportPermitReport.LocalReport.ReportPath = Server.MapPath("ExportPermitReport.rdlc")

                            Dim datasource As New ReportDataSource("ExportPermit", exportData.Tables(0))
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


            ElseIf FilterReport.SelectedValue = "Permit Quarter" Then

                Try
                    ConnectDatabase()
                    InvoiceReport.LocalReport.DataSources.Clear()
                    InvoiceReport.Visible = False

                    InstrumentReport.LocalReport.DataSources.Clear()
                    InstrumentReport.Visible = False

                    Dim exportData As New ExportPermit()
                    Dim db As String = "SELECT referenceCode,exportPermitName,exporterName,productName,exportPort,quantity,amountPerBarrelUS,totalAmountUS,applicationDate FROM exportpermit WHERE CompanyID='" & Session("UserLoginID") & "' AND exportPermitName LIKE '%" & FilterParameter.Text & "%'"

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
                            ExportPermitReport.LocalReport.ReportPath = Server.MapPath("ExportPermitReport.rdlc")

                            Dim datasource As New ReportDataSource("ExportPermit", exportData.Tables(0))
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


            ElseIf FilterReport.SelectedValue = "Export Port" Then
                Try
                    ConnectDatabase()
                    InvoiceReport.LocalReport.DataSources.Clear()
                    InvoiceReport.Visible = False

                    InstrumentReport.LocalReport.DataSources.Clear()
                    InstrumentReport.Visible = False

                    Dim exportData As New ExportPermit()
                    Dim db As String = "SELECT referenceCode,exportPermitName,exporterName,productName,exportPort,quantity,amountPerBarrelUS,totalAmountUS,applicationDate FROM exportpermit WHERE CompanyID='" & Session("UserLoginID") & "' AND exportPort LIKE '%" & FilterParameter.Text & "%'"

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
                            ExportPermitReport.LocalReport.ReportPath = Server.MapPath("ExportPermitReport.rdlc")

                            Dim datasource As New ReportDataSource("ExportPermit", exportData.Tables(0))
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


            ElseIf FilterReport.SelectedValue = "Product Name" Then
                Try
                    ConnectDatabase()
                    InvoiceReport.LocalReport.DataSources.Clear()
                    InvoiceReport.Visible = False

                    InstrumentReport.LocalReport.DataSources.Clear()
                    InstrumentReport.Visible = False

                    Dim exportData As New ExportPermit()
                    Dim db As String = "SELECT referenceCode,exportPermitName,exporterName,productName,exportPort,quantity,amountPerBarrelUS,totalAmountUS,applicationDate FROM exportpermit WHERE CompanyID='" & Session("UserLoginID") & "' AND productName LIKE '%" & FilterParameter.Text & "%'"

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
                            ExportPermitReport.LocalReport.ReportPath = Server.MapPath("ExportPermitReport.rdlc")

                            Dim datasource As New ReportDataSource("ExportPermit", exportData.Tables(0))
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




                'Second one
            ElseIf FilterReport.SelectedValue = "Display All Data" Then

                Try
                    ConnectDatabase()

                    Dim InstrumentData As New InstrumentDataSets()

                    Dim db As String = "SELECT * FROM deviceregistration WHERE CompanyID='" & Session("UserLoginID") & "'"
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
                            InstrumentReport.LocalReport.ReportPath = Server.MapPath("InstrumentReport.rdlc")

                            Dim datasource As New ReportDataSource("InstrumentDataSet", InstrumentData.Tables(0))
                            'Clear other reports
                            ExportPermitReport.LocalReport.DataSources.Clear()
                            ExportPermitReport.Visible = False

                            InvoiceReport.LocalReport.DataSources.Clear()
                            InvoiceReport.Visible = False

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


            ElseIf FilterReport.SelectedValue = "Device Type" Then

                Try
                    ConnectDatabase()

                    Dim InstrumentData As New InstrumentDataSets()

                    Dim db As String = "SELECT * FROM deviceregistration WHERE CompanyID='" & Session("UserLoginID") & "'"
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
                            InstrumentReport.LocalReport.ReportPath = Server.MapPath("InstrumentReport.rdlc")

                            Dim datasource As New ReportDataSource("InstrumentDataSet", InstrumentData.Tables(0))
                            'Clear other reports
                            ExportPermitReport.LocalReport.DataSources.Clear()
                            ExportPermitReport.Visible = False

                            InvoiceReport.LocalReport.DataSources.Clear()
                            InvoiceReport.Visible = False

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


                'Third one
            ElseIf FilterReport.SelectedValue = "Display All Data" Then

                Try
                    ConnectDatabase()
                    Dim InvoiceData As New InvoiceDataSet()

                    Dim db As String = "SELECT transCode,amountDue,narration,amountPaid,paymentStatus,approvalStatus,orderId,invoiceDate FROM payment WHERE CompanyID='" & Session("UserLoginID") & "'"
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
                            InvoiceReport.LocalReport.ReportPath = Server.MapPath("InvoiceReport.rdlc")

                            Dim datasource As New ReportDataSource("InvoiceDataSet", InvoiceData.Tables(0))
                            'Clear other reports
                            ExportPermitReport.LocalReport.DataSources.Clear()
                            ExportPermitReport.Visible = False

                            InstrumentReport.LocalReport.DataSources.Clear()
                            InstrumentReport.Visible = False

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




            ElseIf FilterReport.SelectedValue = "Payment Status" Then

                Try
                    ConnectDatabase()
                    Dim InvoiceData As New InvoiceDataSet()

                    Dim db As String = "SELECT transCode,amountDue,narration,amountPaid,paymentStatus,approvalStatus,orderId,invoiceDate FROM payment WHERE CompanyID='" & Session("UserLoginID") & "' AND paymentStatus ='" & FilterParameter.Text & "'"
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
                            InvoiceReport.LocalReport.ReportPath = Server.MapPath("InvoiceReport.rdlc")

                            Dim datasource As New ReportDataSource("InvoiceDataSet", InvoiceData.Tables(0))
                            'Clear other reports
                            ExportPermitReport.LocalReport.DataSources.Clear()
                            ExportPermitReport.Visible = False

                            InstrumentReport.LocalReport.DataSources.Clear()
                            InstrumentReport.Visible = False

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



            ElseIf FilterReport.SelectedValue = "Approval Status" Then

                Try
                    ConnectDatabase()
                    Dim InvoiceData As New InvoiceDataSet()

                    Dim db As String = "SELECT transCode,amountDue,narration,amountPaid,paymentStatus,approvalStatus,orderId,invoiceDate FROM payment WHERE CompanyID='" & Session("UserLoginID") & "'  AND approvalStatus LIKE '%" & FilterParameter.Text & "%'"
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
                            InvoiceReport.LocalReport.ReportPath = Server.MapPath("InvoiceReport.rdlc")

                            Dim datasource As New ReportDataSource("InvoiceDataSet", InvoiceData.Tables(0))
                            'Clear other reports
                            ExportPermitReport.LocalReport.DataSources.Clear()
                            ExportPermitReport.Visible = False

                            InstrumentReport.LocalReport.DataSources.Clear()
                            InstrumentReport.Visible = False

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

    Protected Sub Filter_Click(sender As Object, e As EventArgs) Handles Filter.Click

        If DateFrom.Text = "" Or DateTo.Text = "" Then
            MessageBox.Show(Me, "Date box can not be empty, kindly enter date in the date boxes!")

        Else
            Dim DateDifference

            Dim FormatStartDate = Date.ParseExact(DateFrom.Text, "d-MM-yyyy", Nothing)
            Dim FormatEndDate = Date.ParseExact(DateTo.Text, "d-MM-yyyy", Nothing)
            Dim DateFormat As String = "dd-MM-yyyy"
            Dim StartDate = FormatStartDate.ToString(DateFormat.ToString)
            Dim EndDate = FormatEndDate.ToString(DateFormat.ToString)



            Try
                Dim SelectedDate = Date.ParseExact(DateFrom.Text, "d-MM-yyyy", Nothing)
                Dim DateFormatDay As String = "dd"
                Dim DateFormatMonth As String = "MM"
                Dim DateFormatYear As String = "yyyy"
                Dim DateDay = SelectedDate.ToString(DateFormatDay.ToString)
                Dim DateMonth = SelectedDate.ToString(DateFormatMonth.ToString)
                Dim DateYear = SelectedDate.ToString(DateFormatYear.ToString)

                DateDifference = Date.ParseExact(DateTo.Text, "d-MM-yyyy", Nothing) - Date.ParseExact(DateFrom.Text, "d-MM-yyyy", Nothing)

                If DateDifference.ToString.Contains("-") Then

                    MessageBox.Show(Me, "Start Date cannot be higher than the End Date   " & DateDifference.ToString & " check the date to continue!")

                Else

                    If FilterReport.SelectedValue = "Export Permit Date" Then
                        Try
                            ConnectDatabase()
                            InvoiceReport.LocalReport.DataSources.Clear()
                            InvoiceReport.Visible = False

                            InstrumentReport.LocalReport.DataSources.Clear()
                            InstrumentReport.Visible = False

                            Dim exportData As New ExportPermit()
                            Dim db As String = "SELECT referenceCode,exportPermitName,exporterName,productName,exportPort,quantity,amountPerBarrelUS,totalAmountUS,applicationDate FROM exportpermit WHERE CompanyID='" & Session("UserLoginID") & "' AND DATE_FORMAT(STR_TO_DATE(applicationDate, '%d-%m-%Y'), '%d-%m-%Y') BETWEEN DATE_FORMAT(STR_TO_DATE('" & StartDate & "', '%d-%m-%Y'), '%d-%m-%Y') AND DATE_FORMAT(STR_TO_DATE('" & EndDate & "', '%d-%m-%Y'), '%d-%m-%Y')"

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
                                    ExportPermitReport.LocalReport.ReportPath = Server.MapPath("ExportPermitReport.rdlc")

                                    Dim datasource As New ReportDataSource("ExportPermit", exportData.Tables(0))
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


                        'Second one

                    ElseIf FilterReport.SelectedValue = "Registration Date" Then

                        Try
                            ConnectDatabase()

                            Dim InstrumentData As New InstrumentDataSets()

                            Dim db As String = "SELECT * FROM deviceregistration WHERE CompanyID='" & Session("UserLoginID") & "' AND DATE_FORMAT(STR_TO_DATE(registrationDate, '%d-%m-%Y'), '%d-%m-%Y') BETWEEN DATE_FORMAT(STR_TO_DATE('" & StartDate & "', '%d-%m-%Y'), '%d-%m-%Y') AND DATE_FORMAT(STR_TO_DATE('" & EndDate & "', '%d-%m-%Y'), '%d-%m-%Y')"
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
                                    InstrumentReport.LocalReport.ReportPath = Server.MapPath("InstrumentReport.rdlc")

                                    Dim datasource As New ReportDataSource("InstrumentDataSet", InstrumentData.Tables(0))
                                    'Clear other reports
                                    ExportPermitReport.LocalReport.DataSources.Clear()
                                    ExportPermitReport.Visible = False

                                    InvoiceReport.LocalReport.DataSources.Clear()
                                    InvoiceReport.Visible = False

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


                        'Third one
                    ElseIf FilterReport.SelectedValue = "Invoice Date" Then

                        Try
                            ConnectDatabase()
                            Dim InvoiceData As New InvoiceDataSet()

                            Dim db As String = "SELECT transCode,amountDue,narration,amountPaid,paymentStatus,approvalStatus,orderId,invoiceDate FROM payment WHERE CompanyID='" & Session("UserLoginID") & "' AND DATE_FORMAT(STR_TO_DATE(invoiceDate, '%d-%m-%Y'), '%d-%m-%Y') BETWEEN DATE_FORMAT(STR_TO_DATE('" & StartDate & "', '%d-%m-%Y'), '%d-%m-%Y') AND DATE_FORMAT(STR_TO_DATE('" & EndDate & "', '%d-%m-%Y'), '%d-%m-%Y')"
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
                                    InvoiceReport.LocalReport.ReportPath = Server.MapPath("InvoiceReport.rdlc")

                                    Dim datasource As New ReportDataSource("InvoiceDataSet", InvoiceData.Tables(0))
                                    'Clear other reports
                                    ExportPermitReport.LocalReport.DataSources.Clear()
                                    ExportPermitReport.Visible = False

                                    InstrumentReport.LocalReport.DataSources.Clear()
                                    InstrumentReport.Visible = False

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
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            End Try

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


End Class