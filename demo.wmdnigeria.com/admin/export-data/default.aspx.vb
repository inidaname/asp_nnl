Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WebForms



Public Class _default31
    Inherits System.Web.UI.Page
    Public DatabaseDate As Date
    Public DateFrom As Date
    Public DateTo As Date

    'Chart1.Series(0)("PointWidth") = "1.2"

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
        'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "tmp2", "var t2 = document.getElementById('Parameter'); t2.focus();t2.value = t2.value;", True)
        'Parameter.select = Len(Parameter.Text)
        'Parameter.Attributes.AddAttributes()
        ShowReport.BackColor = Drawing.Color.Transparent
        ShowReport.BorderColor = Drawing.Color.Transparent



        If Not IsPostBack Then
            FilterDateFrom.Visible = False
            FilterDateTo.Visible = False
            GetDate.Visible = False


            SelectReport.ClearSelection()
            SelectReport.Items.Clear()
            SelectReport.Items.Insert(0, "...Select Report Type...")
            SelectReport.Items.Insert(1, "Destination")
            SelectReport.Items.Insert(2, "Quarter")
            SelectReport.Items.Insert(2, "Company")
            SelectReport.Items.Insert(3, "Terminal")
            SelectReport.Items.Insert(4, "Export Permit")
            SelectReport.Items.FindByText("Quarter").Selected = True


            Try
                ConnectDatabase()
                Destination.LocalReport.DataSources.Clear()
                Destination.Visible = False
                Quarter.LocalReport.DataSources.Clear()
                Quarter.Visible = False
                Company.LocalReport.DataSources.Clear()
                Company.Visible = False
                Terminal.LocalReport.DataSources.Clear()
                Terminal.Visible = False
                ExportPermit.LocalReport.DataSources.Clear()
                ExportPermit.Visible = False

                Dim RetrunData As New ExportReturnDataSet()

                Dim db As String = "SELECT * FROM exportreturn"
                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)

                        da.Fill(RetrunData, "ExportReturnTable")
                        Dim dt As New DataTable
                        da.Fill(dt)

                        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                            NoRecord.Visible = True
                        Else
                            NoRecord.Visible = False

                            'MessageBox.Show(Me, "There is data here!")
                        End If
                        Destination.ProcessingMode = ProcessingMode.Local
                        Destination.LocalReport.ReportPath = Server.MapPath("QuarterReport.rdlc")

                        Dim datasource As New ReportDataSource("ExportReturnDataSet", RetrunData.Tables(0))

                        Destination.LocalReport.DataSources.Clear()
                        Destination.LocalReport.DataSources.Add(datasource)
                        Destination.Visible = True

                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
            End Try

        End If

    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete

    End Sub

    Protected Sub SelectReport_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SelectReport.SelectedIndexChanged


        If SelectReport.SelectedItem.Text = "Destination" Then

            If SelectReportParameter.SelectedItem.Text = "...Select Destination..." Then


            Else

                Try
                    ConnectDatabase()

                    Quarter.LocalReport.DataSources.Clear()
                    Quarter.Visible = False
                    Company.LocalReport.DataSources.Clear()
                    Company.Visible = False
                    Terminal.LocalReport.DataSources.Clear()
                    Terminal.Visible = False
                    ExportPermit.LocalReport.DataSources.Clear()
                    ExportPermit.Visible = False

                    SelectReportParameter.Visible = True
                    ReportParameterLabel.Visible = True

                    Dim RetrunData As New ExportReturnDataSet()

                    Dim db As String = "SELECT lifitingDestination FROM exportreturn GROUP BY lifitingDestination"
                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)

                            da.Fill(RetrunData, "ExportReturnTable")
                            Dim dt As New DataTable
                            da.Fill(dt)

                            If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                NoRecord.Visible = True
                            Else
                                NoRecord.Visible = False

                                'MessageBox.Show(Me, "There is data here!")
                            End If
                            Destination.ProcessingMode = ProcessingMode.Local
                            Destination.LocalReport.ReportPath = Server.MapPath("DestinationReport.rdlc")

                            Dim datasource As New ReportDataSource("ExportReturnDataSet", RetrunData.Tables(0))

                            Destination.LocalReport.DataSources.Clear()
                            Destination.LocalReport.DataSources.Add(datasource)
                            Destination.Visible = True

                        End Using
                    End Using
                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                Finally
                    DisconnectDatabase()
                End Try


            End If



        ElseIf SelectReport.SelectedItem.Text = "Quarter" Then

            Try
                ConnectDatabase()
                Destination.LocalReport.DataSources.Clear()
                Destination.Visible = False
                Company.LocalReport.DataSources.Clear()
                Company.Visible = False
                Terminal.LocalReport.DataSources.Clear()
                Terminal.Visible = False
                ExportPermit.LocalReport.DataSources.Clear()
                ExportPermit.Visible = False

                SelectReportParameter.Visible = False
                ReportParameterLabel.Visible = False

                Dim RetrunData As New ExportReturnDataSet()
                Dim ParameterString As Integer = 1

                Dim db As String = "SELECT * FROM exportreturn"
                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)

                        da.Fill(RetrunData, "ExportReturnTable")
                        Dim dt As New DataTable
                        da.Fill(dt)

                        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                            NoRecord.Visible = True
                        Else
                            NoRecord.Visible = False

                            'MessageBox.Show(Me, "There is data here!")
                        End If
                        Quarter.ProcessingMode = ProcessingMode.Local
                        Quarter.LocalReport.ReportPath = Server.MapPath("QuarterReport.rdlc")

                        Dim datasource As New ReportDataSource("ExportReturnDataSet", RetrunData.Tables(0))

                        Quarter.LocalReport.DataSources.Clear()
                        Quarter.LocalReport.DataSources.Add(datasource)
                        Quarter.Visible = True

                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
            End Try

        ElseIf SelectReport.SelectedItem.Text = "Company" Then


            Try
                ConnectDatabase()

                'Dim db As String = "SELECT deviceType, concat(deviceType,' : SN ',serialNumber) As Instrument FROM deviceregistration WHERE CompanyID='" & Session("UserLoginID") & "'"
                Dim db As String = "SELECT exporter FROM exportreturn WHERE NOT exporter='' GROUP BY exporter"
                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)

                        'Get the list of rows needed into Session, so as to enable us retreive it later
                        Dim dt As New DataTable()
                        da.Fill(dt)

                        SelectReportParameter.DataSource = dt
                        SelectReportParameter.DataTextField = "exporter"
                        SelectReportParameter.DataValueField = "exporter"
                        SelectReportParameter.DataBind()
                        SelectReportParameter.Items.Insert(0, "...Select Company...")
                        SelectReportParameter.Visible = True
                        ReportParameterLabel.Visible = True
                        ReportParameterLabel.Text = "Companies:"

                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
            End Try

            If SelectReportParameter.SelectedItem.Text = "...Select Company..." Then

            Else

                Try
                    ConnectDatabase()
                    Destination.LocalReport.DataSources.Clear()
                    Destination.Visible = False
                    Quarter.LocalReport.DataSources.Clear()
                    Quarter.Visible = False
                    Terminal.LocalReport.DataSources.Clear()
                    Terminal.Visible = False
                    ExportPermit.LocalReport.DataSources.Clear()
                    ExportPermit.Visible = False

                    Dim RetrunData As New ExportReturnDataSet()

                    Dim db As String = "SELECT * FROM exportreturn WHERE exporter='" & SelectReportParameter.SelectedValue & "' "
                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)

                            da.Fill(RetrunData, "ExportReturnTable")
                            Dim dt As New DataTable
                            da.Fill(dt)

                            If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                NoRecord.Visible = True
                            Else
                                NoRecord.Visible = False

                                'MessageBox.Show(Me, "There is data here!")
                            End If
                            Company.ProcessingMode = ProcessingMode.Local
                            Company.LocalReport.ReportPath = Server.MapPath("CompanyReports.rdlc")

                            Dim datasource As New ReportDataSource("ExportReturnDataSet", RetrunData.Tables(0))

                            Company.LocalReport.DataSources.Clear()
                            Company.LocalReport.DataSources.Add(datasource)
                            Company.Visible = True

                        End Using
                    End Using
                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                Finally
                    DisconnectDatabase()
                End Try

            End If


        ElseIf SelectReport.SelectedItem.Text = "Terminal" Then
            Destination.LocalReport.DataSources.Clear()
            Destination.Visible = False
            Quarter.LocalReport.DataSources.Clear()
            Quarter.Visible = False
            Company.LocalReport.DataSources.Clear()
            Company.Visible = False
            ExportPermit.LocalReport.DataSources.Clear()
            ExportPermit.Visible = False

            Try
                ConnectDatabase()

                'Dim db As String = "SELECT deviceType, concat(deviceType,' : SN ',serialNumber) As Instrument FROM deviceregistration WHERE CompanyID='" & Session("UserLoginID") & "'"
                Dim db As String = "SELECT stream FROM exportreturn WHERE NOT stream='' GROUP BY stream"
                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)

                        'Get the list of rows needed into Session, so as to enable us retreive it later
                        Dim dt As New DataTable()
                        da.Fill(dt)

                        SelectReportParameter.DataSource = dt
                        SelectReportParameter.DataTextField = "stream"
                        SelectReportParameter.DataValueField = "stream"
                        SelectReportParameter.DataBind()
                        SelectReportParameter.Items.Insert(0, "...Select Terminal...")
                        SelectReportParameter.Visible = True
                        ReportParameterLabel.Visible = True
                        ReportParameterLabel.Text = "Terminals:"


                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
            End Try

            If SelectReportParameter.SelectedItem.Text = "...Select Terminal..." Then

            Else
                Try
                    ConnectDatabase()

                    Dim RetrunData As New ExportReturnDataSet()
                    Dim db As String = "SELECT * FROM exportreturn WHERE stream='" & SelectReportParameter.SelectedValue & "'"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)
                            da.Fill(RetrunData, "ExportReturnTable")
                            Dim dt As New DataTable
                            da.Fill(dt)
                            If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                NoRecord.Visible = True
                            Else
                                NoRecord.Visible = False
                                ' MessageBox.Show(Me, "There is data here!")
                            End If

                            Terminal.ProcessingMode = ProcessingMode.Local
                            Terminal.LocalReport.ReportPath = Server.MapPath("TerminalReport.rdlc")

                            Dim datasource As New ReportDataSource("ExportReturnDataSet", RetrunData.Tables(0))
                            Terminal.LocalReport.DataSources.Clear()
                            Terminal.LocalReport.DataSources.Add(datasource)
                            Terminal.Visible = True
                        End Using
                    End Using
                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                Finally
                    DisconnectDatabase()
                End Try

            End If





        ElseIf SelectReport.SelectedItem.Text = "Export Permit" Then

            Destination.LocalReport.DataSources.Clear()
            Destination.Visible = False
            Quarter.LocalReport.DataSources.Clear()
            Quarter.Visible = False
            Company.LocalReport.DataSources.Clear()
            Company.Visible = False
            Terminal.LocalReport.DataSources.Clear()
            Terminal.Visible = False


            Try
                ConnectDatabase()
                Dim db As String = "SELECT exportPermitID,CONCAT(exporter, ' : ', exportPermitID) AS CompanyReference FROM exportreturn GROUP BY exportPermitID"
                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)

                        'Get the list of rows needed into Session, so as to enable us retreive it later
                        Dim dt As New DataTable()
                        da.Fill(dt)

                        SelectReportParameter.DataSource = dt
                        SelectReportParameter.DataTextField = "CompanyReference"
                        SelectReportParameter.DataValueField = "exportPermitID"
                        SelectReportParameter.DataBind()
                        SelectReportParameter.Items.Insert(0, "...Select Permit Reference...")
                        SelectReportParameter.Visible = True
                        ReportParameterLabel.Visible = True
                        ReportParameterLabel.Text = "Permit Refrences:"


                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
            End Try

            If SelectReportParameter.SelectedItem.Text = "...Select Permit Reference..." Then

            Else
                Try

                    ConnectDatabase()

                    Dim RetrunData As New ExportReturnDataSet()

                    Dim db As String = "SELECT * FROM exportreturn WHERE exportPermitID='" & SelectReportParameter.SelectedValue & "'"
                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)

                            da.Fill(RetrunData, "ExportReturnTable")
                            Dim dt As New DataTable
                            da.Fill(dt)

                            If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                NoRecord.Visible = True
                            Else
                                NoRecord.Visible = False

                                'MessageBox.Show(Me, "There is data here!")
                            End If

                            ExportPermit.ProcessingMode = ProcessingMode.Local
                            ExportPermit.LocalReport.ReportPath = Server.MapPath("ExportPermit.rdlc")

                            Dim datasource As New ReportDataSource("ExportReturnDataSet", RetrunData.Tables(0))

                            ExportPermit.LocalReport.DataSources.Clear()
                            ExportPermit.LocalReport.DataSources.Add(datasource)
                            ExportPermit.Visible = True

                        End Using
                    End Using
                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                Finally
                    DisconnectDatabase()
                End Try



            End If

        ElseIf SelectReport.SelectedItem.Text = "...Select Report Type..." Then
            MessageBox.Show(Me, "Please select a valid Report Type!")
            SelectReportParameter.ClearSelection()
            SelectReportParameter.Items.Clear()
            SelectReportParameter.Items.Insert(0, "...No Report Parameter...")
            SelectReportParameter.Visible = True
            ReportParameterLabel.Visible = True

            Destination.LocalReport.DataSources.Clear()
            Destination.Visible = False
            Quarter.LocalReport.DataSources.Clear()
            Quarter.Visible = False
            Company.LocalReport.DataSources.Clear()
            Company.Visible = False
            Terminal.LocalReport.DataSources.Clear()
            Terminal.Visible = False
            ExportPermit.LocalReport.DataSources.Clear()
            ExportPermit.Visible = False

            NoRecord.Visible = True

        End If


    End Sub


    Protected Sub SelectReportParameter_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SelectReportParameter.SelectedIndexChanged


        If SelectReport.SelectedItem.Text = "Destination" And Not SelectReportParameter.SelectedItem.Text = "...Select Destination..." Then

            Try
                ConnectDatabase()

                Quarter.LocalReport.DataSources.Clear()
                Quarter.Visible = False
                Company.LocalReport.DataSources.Clear()
                Company.Visible = False
                Terminal.LocalReport.DataSources.Clear()
                Terminal.Visible = False
                ExportPermit.LocalReport.DataSources.Clear()
                ExportPermit.Visible = False


                Dim RetrunData As New ExportReturnDataSet()

                Dim db As String = "SELECT * FROM exportreturn WHERE lifitingDestination='" & SelectReportParameter.SelectedValue & "' "
                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)

                        da.Fill(RetrunData, "ExportReturnTable")
                        Dim dt As New DataTable
                        da.Fill(dt)

                        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                            NoRecord.Visible = True
                        Else
                            NoRecord.Visible = False

                            'MessageBox.Show(Me, "There is data here!")
                        End If
                        Destination.ProcessingMode = ProcessingMode.Local
                        Destination.LocalReport.ReportPath = Server.MapPath("DestinationReport.rdlc")

                        Dim datasource As New ReportDataSource("ExportReturnDataSet", RetrunData.Tables(0))

                        Destination.LocalReport.DataSources.Clear()
                        Destination.LocalReport.DataSources.Add(datasource)
                        Destination.Visible = True

                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
            End Try



        ElseIf SelectReport.SelectedItem.Text = "Company" And Not SelectReportParameter.SelectedItem.Text = "...Select Company..." Then


            Try
                ConnectDatabase()
                Destination.LocalReport.DataSources.Clear()
                Destination.Visible = False
                Quarter.LocalReport.DataSources.Clear()
                Quarter.Visible = False
                Terminal.LocalReport.DataSources.Clear()
                Terminal.Visible = False
                ExportPermit.LocalReport.DataSources.Clear()
                ExportPermit.Visible = False

                Dim RetrunData As New ExportReturnDataSet()

                Dim db As String = "SELECT * FROM exportreturn WHERE exporter='" & SelectReportParameter.SelectedValue & "' "
                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)

                        da.Fill(RetrunData, "ExportReturnTable")
                        Dim dt As New DataTable
                        da.Fill(dt)

                        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                            NoRecord.Visible = True
                        Else
                            NoRecord.Visible = False

                            'MessageBox.Show(Me, "There is data here!")
                        End If
                        Company.ProcessingMode = ProcessingMode.Local
                        Company.LocalReport.ReportPath = Server.MapPath("CompanyReports.rdlc")

                        Dim datasource As New ReportDataSource("ExportReturnDataSet", RetrunData.Tables(0))

                        Company.LocalReport.DataSources.Clear()
                        Company.LocalReport.DataSources.Add(datasource)
                        Company.Visible = True

                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
            End Try


        ElseIf SelectReport.SelectedItem.Text = "Terminal" And Not SelectReportParameter.SelectedItem.Text = "...Select Terminal..." Then

            Try
                ConnectDatabase()
                Destination.LocalReport.DataSources.Clear()
                Destination.Visible = False
                Quarter.LocalReport.DataSources.Clear()
                Quarter.Visible = False
                Company.LocalReport.DataSources.Clear()
                Company.Visible = False
                ExportPermit.LocalReport.DataSources.Clear()
                ExportPermit.Visible = False

                Dim RetrunData As New ExportReturnDataSet()
                Dim db As String = "SELECT * FROM exportreturn WHERE stream='" & SelectReportParameter.SelectedValue & "'"

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)
                        da.Fill(RetrunData, "ExportReturnTable")
                        Dim dt As New DataTable
                        da.Fill(dt)
                        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                            NoRecord.Visible = True
                        Else
                            NoRecord.Visible = False
                            ' MessageBox.Show(Me, "There is data here!")
                        End If

                        Terminal.ProcessingMode = ProcessingMode.Local
                        Terminal.LocalReport.ReportPath = Server.MapPath("TerminalReport.rdlc")

                        Dim datasource As New ReportDataSource("ExportReturnDataSet", RetrunData.Tables(0))
                        Terminal.LocalReport.DataSources.Clear()
                        Terminal.LocalReport.DataSources.Add(datasource)
                        Terminal.Visible = True
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
            End Try


        ElseIf SelectReport.SelectedItem.Text = "Export Permit" And Not SelectReportParameter.SelectedItem.Text = "...Select Permit Reference..." Then

            Try

                ConnectDatabase()
                Destination.LocalReport.DataSources.Clear()
                Destination.Visible = False
                Quarter.LocalReport.DataSources.Clear()
                Quarter.Visible = False
                Company.LocalReport.DataSources.Clear()
                Company.Visible = False
                Terminal.LocalReport.DataSources.Clear()
                Terminal.Visible = False
                Dim RetrunData As New ExportReturnDataSet()

                Dim db As String = "SELECT * FROM exportreturn WHERE exportPermitID='" & SelectReportParameter.SelectedValue & "'"
                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)

                        da.Fill(RetrunData, "ExportReturnTable")
                        Dim dt As New DataTable
                        da.Fill(dt)

                        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                            NoRecord.Visible = True
                        Else
                            NoRecord.Visible = False

                            'MessageBox.Show(Me, "There is data here!")
                        End If

                        ExportPermit.ProcessingMode = ProcessingMode.Local
                        ExportPermit.LocalReport.ReportPath = Server.MapPath("ExportPermit.rdlc")

                        Dim datasource As New ReportDataSource("ExportReturnDataSet", RetrunData.Tables(0))

                        ExportPermit.LocalReport.DataSources.Clear()
                        ExportPermit.LocalReport.DataSources.Add(datasource)
                        ExportPermit.Visible = True

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

            Destination.LocalReport.DataSources.Clear()
            Destination.Visible = False
            Quarter.LocalReport.DataSources.Clear()
            Quarter.Visible = False
            Company.LocalReport.DataSources.Clear()
            Company.Visible = False
            Terminal.LocalReport.DataSources.Clear()
            Terminal.Visible = False
            ExportPermit.LocalReport.DataSources.Clear()
            ExportPermit.Visible = False

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


                    If SelectReport.SelectedItem.Text = "Destination" Then
                        If SelectReportParameter.SelectedItem.Text = "Registration Date" Then

                            Quarter.LocalReport.DataSources.Clear()
                            Quarter.Visible = False
                            Company.LocalReport.DataSources.Clear()
                            Company.Visible = False
                            Terminal.LocalReport.DataSources.Clear()
                            Terminal.Visible = False
                            ExportPermit.LocalReport.DataSources.Clear()
                            ExportPermit.Visible = False

                            Try
                                ConnectDatabase()

                                Dim RetrunData As New ExportReturnDataSet()
                                Dim db As String = "SELECT *, DATE_FORMAT(STR_TO_DATE(registrationDate, '%d-%m-%Y'), '%d-%m-%Y') As FormatedDate FROM deviceregistration WHERE DATE_FORMAT(STR_TO_DATE(registrationDate, '%d-%m-%Y'), '%d-%m-%Y') BETWEEN DATE_FORMAT(STR_TO_DATE('" & StartDate & "', '%d-%m-%Y'), '%d-%m-%Y') AND DATE_FORMAT(STR_TO_DATE('" & EndDate & "', '%d-%m-%Y'), '%d-%m-%Y')"
                                'Dim db As String = "SELECT *, STR_TO_DATE(registrationDate, '%d-%m-%Y') As FormatedDate, DATE_FORMAT(NOW(),'%d-%m-%Y') As Today FROM deviceregistration"
                                'Dim db As String = "SELECT *, registrationDate, DATE_FORMAT(registrationDate, '%d/%m/%Y') As FormatedDate, DATE_FORMAT(NOW(),'%d-%m-%Y') As Today FROM deviceregistration"
                                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                                    Using da As New MySqlDataAdapter(cn)

                                        da.Fill(RetrunData, "ExportReturnTable")
                                        Dim dt As New DataTable
                                        da.Fill(dt)

                                        Dim ds As New DataSet
                                        da.Fill(ds)

                                        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                            NoRecord.Visible = True

                                            Destination.Visible = True

                                        Else
                                            NoRecord.Visible = False


                                        End If

                                        Destination.ProcessingMode = ProcessingMode.Local
                                        Destination.LocalReport.ReportPath = Server.MapPath("Destination.rdlc")

                                        Dim datasource As New ReportDataSource("ExportReturnDataSet", RetrunData.Tables(0))

                                        Destination.LocalReport.DataSources.Clear()
                                        Destination.LocalReport.DataSources.Add(datasource)
                                        Destination.Visible = True


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

                        Destination.LocalReport.DataSources.Clear()
                        Destination.Visible = False
                        Quarter.LocalReport.DataSources.Clear()
                        Quarter.Visible = False
                        Company.LocalReport.DataSources.Clear()
                        Company.Visible = False
                        Terminal.LocalReport.DataSources.Clear()
                        Terminal.Visible = False
                        ExportPermit.LocalReport.DataSources.Clear()
                        ExportPermit.Visible = False

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