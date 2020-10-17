Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WebForms
Public Class _default42
    Inherits System.Web.UI.Page
    Public DatabaseDate As Date
    Public DateFrom As Date
    Public DateTo As Date


    Public RetrunData As New InstrumentsDataSet()
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
            SelectReport.Items.Insert(1, "State")
            SelectReport.Items.Insert(2, "Nationwide")
            SelectReport.Items.Insert(3, "Yearly")
            SelectReport.Items.FindByText("Nationwide").Selected = True


            Try
                ConnectDatabase()
                NationwideReport.LocalReport.DataSources.Clear()
                NationwideReport.Visible = False
                StateReport.LocalReport.DataSources.Clear()
                StateReport.Visible = False
                YearlyReport.LocalReport.DataSources.Clear()
                YearlyReport.Visible = False

                Dim database As String = "SELECT PA.ID,PA.paymentYear,PA.amountPaid,(PA.amountPaid) AS totalAmount,DR.state FROM payment PA, deviceregistration DR WHERE PA.accStatus='1' AND PA.paymentFor='Instrument Registration Invoice' OR PA.paymentFor='Annual Licensing Renewal Invoice' AND PA.paymentStatus='Paid' AND DR.transCode=PA.transCode GROUP BY PA.ID"
                Using cn As MySqlCommand = New MySqlCommand(database, conn)
                    Using da As New MySqlDataAdapter(cn)

                        da.Fill(RetrunData, "InstrumentTable")
                        Dim dt As New DataTable
                        Dim ds As New DataSet
                        da.Fill(dt)
                        da.Fill(ds)
                        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                            NoRecord.Visible = True
                        Else
                            NoRecord.Visible = False
                        End If
                        NationwideReport.ProcessingMode = ProcessingMode.Local
                        NationwideReport.LocalReport.ReportPath = Server.MapPath("NationwideInstrumentReport.rdlc")

                        Dim datasource As New ReportDataSource("InstrumentsDataSet", RetrunData.Tables(0))

                        NationwideReport.LocalReport.DataSources.Clear()
                        NationwideReport.LocalReport.DataSources.Add(datasource)
                        NationwideReport.Visible = True

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


        If SelectReport.SelectedItem.Text = "State" Then

            Try
                ConnectDatabase()
                NationwideReport.LocalReport.DataSources.Clear()
                NationwideReport.Visible = False
                StateReport.LocalReport.DataSources.Clear()
                StateReport.Visible = False
                YearlyReport.LocalReport.DataSources.Clear()
                YearlyReport.Visible = False

                'Dim db As String = "SELECT *,SUM(amountPaid) AS TotalAmount FROM payment WHERE accStatus='1' AND paymentFor='Instrument Registration Invoice' OR paymentFor='Annual Licensing Renewal Invoice'"
                Dim db As String = "SELECT PA.ID,PA.paymentYear,PA.amountPaid,(PA.amountPaid) AS totalAmount,DR.state FROM payment PA, deviceregistration DR WHERE PA.accStatus='1' AND PA.paymentFor='Instrument Registration Invoice' OR PA.paymentFor='Annual Licensing Renewal Invoice' AND PA.paymentStatus='Paid' AND DR.transCode=PA.transCode GROUP BY PA.ID"
                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)

                        da.Fill(RetrunData, "InstrumentTable")
                        Dim dt As New DataTable
                        Dim ds As New DataSet
                        da.Fill(dt)
                        da.Fill(ds)
                        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                            NoRecord.Visible = True
                        Else
                            NoRecord.Visible = False
                            'MessageBox.Show(Me, "There is data here!")
                        End If
                        StateReport.ProcessingMode = ProcessingMode.Local
                        StateReport.LocalReport.ReportPath = Server.MapPath("StateInstrumentReport.rdlc")

                        Dim datasource As New ReportDataSource("InstrumentsDataSet", RetrunData.Tables(0))

                        StateReport.LocalReport.DataSources.Clear()
                        StateReport.LocalReport.DataSources.Add(datasource)
                        StateReport.Visible = True

                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
            End Try

        ElseIf SelectReport.SelectedItem.Text = "Nationwide" Then

            Try
                ConnectDatabase()
                NationwideReport.LocalReport.DataSources.Clear()
                NationwideReport.Visible = False
                StateReport.LocalReport.DataSources.Clear()
                StateReport.Visible = False
                YearlyReport.LocalReport.DataSources.Clear()
                YearlyReport.Visible = False

                Dim database As String = "SELECT PA.ID,PA.paymentYear,PA.amountPaid,(PA.amountPaid) AS totalAmount,DR.state FROM payment PA, deviceregistration DR WHERE PA.accStatus='1' AND PA.paymentFor='Instrument Registration Invoice' OR PA.paymentFor='Annual Licensing Renewal Invoice' AND PA.paymentStatus='Paid' AND DR.transCode=PA.transCode GROUP BY PA.ID"
                Using cn As MySqlCommand = New MySqlCommand(database, conn)
                    Using da As New MySqlDataAdapter(cn)

                        da.Fill(RetrunData, "InstrumentTable")
                        Dim dt As New DataTable
                        Dim ds As New DataSet
                        da.Fill(dt)
                        da.Fill(ds)
                        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                            NoRecord.Visible = True
                        Else
                            NoRecord.Visible = False
                        End If
                        NationwideReport.ProcessingMode = ProcessingMode.Local
                        NationwideReport.LocalReport.ReportPath = Server.MapPath("NationwideInstrumentReport.rdlc")
                        Dim datasource As New ReportDataSource("InstrumentsDataSet", RetrunData.Tables(0))

                        NationwideReport.LocalReport.DataSources.Clear()
                        NationwideReport.LocalReport.DataSources.Add(datasource)
                        NationwideReport.Visible = True

                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
            End Try


        ElseIf SelectReport.SelectedItem.Text = "Yearly" Then

            Try
                ConnectDatabase()

                'Dim db As String = "SELECT deviceType, concat(deviceType,' : SN ',serialNumber) As Instrument FROM deviceregistration WHERE CompanyID='" & Session("UserLoginID") & "'"
                Dim db As String = "SELECT paymentYear FROM payment WHERE accStatus='1' AND paymentFor='Instrument Registration Invoice' OR paymentFor='Annual Licensing Renewal Invoice' AND paymentStatus='Paid' GROUP BY paymentYear"
                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)

                        'Get the list of rows needed into Session, so as to enable us retreive it later
                        Dim dt As New DataTable()
                        da.Fill(dt)

                        SelectReportParameter.DataSource = dt
                        SelectReportParameter.DataTextField = "paymentYear"
                        SelectReportParameter.DataValueField = "paymentYear"
                        SelectReportParameter.DataBind()
                        SelectReportParameter.Items.Insert(0, "...Select Year...")
                        SelectReportParameter.Visible = True
                        ReportParameterLabel.Visible = True
                        ReportParameterLabel.Text = "Year:"

                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
            End Try

            Try
                ConnectDatabase()
                NationwideReport.LocalReport.DataSources.Clear()
                NationwideReport.Visible = False
                StateReport.LocalReport.DataSources.Clear()
                StateReport.Visible = False
                YearlyReport.LocalReport.DataSources.Clear()
                YearlyReport.Visible = False


                Dim database As String = "SELECT PA.ID,PA.paymentYear,PA.amountPaid,(PA.amountPaid) AS totalAmount,DR.state FROM payment PA, deviceregistration DR WHERE PA.accStatus='1' AND PA.paymentFor='Instrument Registration Invoice' OR PA.paymentFor='Annual Licensing Renewal Invoice' AND PA.paymentStatus='Paid' AND DR.transCode=PA.transCode GROUP BY PA.ID"
                Using cn As MySqlCommand = New MySqlCommand(database, conn)
                    Using da As New MySqlDataAdapter(cn)

                        da.Fill(RetrunData, "InstrumentTable")
                        Dim dt As New DataTable
                        Dim ds As New DataSet
                        da.Fill(dt)
                        da.Fill(ds)
                        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                            NoRecord.Visible = True
                        Else
                            NoRecord.Visible = False
                        End If
                        YearlyReport.ProcessingMode = ProcessingMode.Local
                        YearlyReport.LocalReport.ReportPath = Server.MapPath("NationwideInstrumentReport.rdlc")

                        Dim datasource As New ReportDataSource("InstrumentsDataSet", RetrunData.Tables(0))

                        YearlyReport.LocalReport.DataSources.Clear()
                        YearlyReport.LocalReport.DataSources.Add(datasource)
                        YearlyReport.Visible = True

                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
        End Try

        End If

    End Sub

End Class