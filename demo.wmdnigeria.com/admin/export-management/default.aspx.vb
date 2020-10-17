Imports System.Web
Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Data.OleDb
Imports System.Web.Security
Imports System.Configuration
Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography


Public Class _default18
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
            Response.Redirect("../dashboard/")
        End If
        'Enable or disable roles

        If Session("LoggedInAdminLoginInspectExportImport") = "0" Then
            InspectionTab.Visible = False
            InspectionContent.Visible = False
        Else
            InspectionTab.Visible = True
        End If
        If Session("LoggedInAdminLoginRecommendExportImport") = "0" Then
            RecommentionTab.Visible = False
        Else
            RecommentionTab.Visible = True
        End If
        If Session("LoggedInAdminLoginEndorseExportImport") = "0" Then
            EndorsementTab.Visible = False
        Else
            EndorsementTab.Visible = True
        End If

        If Session("LoggedInAdminLoginApproveExportImport") = "0" Then
            ApprovalTab.Visible = False
        Else
            ApprovalTab.Visible = True

        End If

        If Session("LoggedInAdminLoginEntryExportImport") = "0" Then
            EntryAuthorizationTab.Visible = False
        Else
            EntryAuthorizationTab.Visible = True

        End If

        'MessageBox.Show(Me, Session("LoggedInAdminLoginEntryExportImport"))

        If Session("LoggedInAdminLoginLoadingExportImport") = "0" Then
            ProductLoadingTab.Visible = False
        Else
            ProductLoadingTab.Visible = True

        End If


        If Session("LoggedInAdminLoginExitExportImport") = "0" Then
            ContainerExitTab.Visible = False
        Else
            ContainerExitTab.Visible = True

        End If


        If Session("LoggedInAdminLoginCompanyMgtRight") = "0" And Session("LoggedInAdminLoginInstrumentMgtRight") = "0" And Session("LoggedInAdminLoginStaticDataRight") = "0" And Session("LoggedInAdminLoginImportPermitManagement") = "0" And Session("LoggedInAdminLoginManageLot") = "0" And Session("LoggedInAdminLoginInvoiceReport") = "0" And Session("LoggedInAdminLoginReportRight") = "0" And Session("LoggedInAdminLoginDownloadCenter") = "0" And Session("LoggedInAdminLoginUploadNews") = "0" And Session("LoggedInAdminLoginUploadGallery") = "0" And Session("LoggedInAdminLoginSetupOffice") = "0" And Session("LoggedInAdminLoginQuizRight") = "0" And Session("LoggedInAdminLoginCareerRight") = "0" And Session("LoggedInAdminLoginInstrumentFee") = "0" And Session("LoggedInAdminLoginMeasurement") = "0" And Session("LoggedInAdminLoginInvoiceReport") = "0" And Session("LoggedInAdminLoginSettings") = "0" And Session("LoggedInAdminLoginExportDataReturn") = "0" Then
            DashboardLink.Visible = False
        End If


        TabOverallContainer.Visible = False


        ProductDescription.Enabled = False
        PeriodCoverFrom.Enabled = False
        PeriodCoverTo.Enabled = False
        ApprovalPermitQuarter.Enabled = False
        EndorsementPermitQuarter.Enabled = False
        RecommendationPermitQuarter.Enabled = False
        TerminaOperator.Enabled = False
        NonTerminalOperator.Enabled = False

        'Fetch the last export permit application
        If Not IsPostBack = True Then

            Try
                ConnectDatabase()



                Dim dbu As String = "SELECT * FROM exportpermit WHERE username='" & Session("UserLoginName") & "' "

                Using cnu As MySqlCommand = New MySqlCommand(dbu, conn)
                    Using dau As New MySqlDataAdapter(cnu)
                        'Fill data of logged in user into dataset

                        'Get the list of rows needed into Session, so as to enable us retreive it later
                        Dim dtm As New DataTable
                        dau.Fill(dtm)
                        Dim dsm As New DataSet
                        dau.Fill(dsm)
                        InspectionOfficer.Text = dsm.Tables(0).Rows(0).Item("inspectionOfficer").ToString
                        Dim InspectStatus = dsm.Tables(0).Rows(0).Item("inspectionStatus").ToString
                        If InspectStatus = "0" Then
                            InspectionStatus.Checked = True
                        ElseIf InspectStatus = "1" Then
                            InspectionStatus.Checked = False
                        End If
                        InspectionDate.Text = dsm.Tables(0).Rows(0).Item("inspectionOfficer").ToString
                        ProductDescription.Text = dsm.Tables(0).Rows(0).Item("productName").ToString
                        PeriodCoverFrom.Text = dsm.Tables(0).Rows(0).Item("periodCoveredFrom").ToString
                        PeriodCoverTo.Text = dsm.Tables(0).Rows(0).Item("periodCoveredTo").ToString
                        InspectionComment.Text = dsm.Tables(0).Rows(0).Item("inspectionComment").ToString
                        EndorsementPermitQuarter.Text = dsm.Tables(0).Rows(0).Item("permitQuarter").ToString
                        Dim EndorsemenStatus = dsm.Tables(0).Rows(0).Item("endorsementStatus").ToString
                        If EndorsemenStatus = "0" Then
                            EndorsementStatus.Checked = True
                        ElseIf EndorsemenStatus = "1" Then
                            EndorsementStatus.Checked = False
                        End If
                        EndorsedBy.Text = dsm.Tables(0).Rows(0).Item("endorsedBy").ToString
                        EndorsementComment.Text = dsm.Tables(0).Rows(0).Item("endorsedComment").ToString
                        RecommendationPermitQuarter.Text = dsm.Tables(0).Rows(0).Item("permitQuarter").ToString
                        Dim RecommendStatus = dsm.Tables(0).Rows(0).Item("recommendationStatus").ToString
                        If RecommendStatus = "0" Then
                            RecommendationStatus.Checked = True
                        ElseIf RecommendStatus = "1" Then
                            RecommendationStatus.Checked = False
                        End If
                        RecommendationDate.Text = dsm.Tables(0).Rows(0).Item("recommendationDate").ToString
                        RecommendationComment.Text = dsm.Tables(0).Rows(0).Item("recommendationComment").ToString
                        RecommendationBy.Text = dsm.Tables(0).Rows(0).Item("recommendationName").ToString


                        ApprovalPermitQuarter.Text = dsm.Tables(0).Rows(0).Item("permitQuarter").ToString
                        Dim ApproveStatus = dsm.Tables(0).Rows(0).Item("recommendationStatus").ToString
                        If ApproveStatus = "0" Then
                            ApprovalStatus.Checked = True
                        ElseIf ApproveStatus = "1" Then
                            ApprovalStatus.Checked = False
                        End If
                        ApprovalDate.Text = dsm.Tables(0).Rows(0).Item("approvalDate").ToString
                        ApprovalComment.Text = dsm.Tables(0).Rows(0).Item("approvalComment").ToString
                        ApprovedBy.Text = dsm.Tables(0).Rows(0).Item("approvalName").ToString

                    End Using
                End Using

            Catch ex As MySqlException
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
            End Try


            Try
                ConnectDatabase()
                Dim dbu As String = "SELECT * FROM company"
                Using cnu As MySqlCommand = New MySqlCommand(dbu, conn)
                    Using dau As New MySqlDataAdapter(cnu)
                        Dim dt As New DataTable
                        dau.Fill(dt)

                        SelectCompany.DataSource = dt
                        SelectCompany.DataTextField = "companyName"
                        SelectCompany.DataValueField = "ID"
                        SelectCompany.DataBind()

                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
            End Try

            Try
                ConnectDatabase()
                Dim dbu As String = "SELECT * FROM exportpermit WHERE companyID='" & SelectCompany.SelectedValue & "'"

                Using cnu As MySqlCommand = New MySqlCommand(dbu, conn)
                    Using dau As New MySqlDataAdapter(cnu)
                        'Fill data of logged in user into dataset

                        'Get the list of rows needed into Session, so as to enable us retreive it later
                        Dim dt As New DataTable
                        dau.Fill(dt)

                        SelectQuarter.DataSource = dt
                        SelectQuarter.DataTextField = "exportPermitName"
                        SelectQuarter.DataValueField = "ID"
                        SelectQuarter.DataBind()

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

    Protected Sub ShowPermitResult_Click(sender As Object, e As EventArgs) Handles ShowPermitResult.Click

        TabOverallContainer.Visible = False

        If SelectQuarter.Items.Count = 0 Then
            MessageBox.Show(Me, "The Selected Company has not applied for any Export Permit!")

        Else
            Try
                ConnectDatabase()

                Dim db As String = "SELECT * FROM exportpermit WHERE CompanyID='" & SelectCompany.SelectedValue & "' AND exportPermitName='" & SelectQuarter.SelectedItem.Text & "'"

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)
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

                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
            End Try

        End If

    End Sub


    Sub SelectCompany_SelectedIndexChanged(sender As Object, e As EventArgs)

        ExportPermitGridView.DataSource = Nothing
        ExportPermitGridView.DataBind()
        TabOverallContainer.Visible = False
        Try
            ConnectDatabase()

            Dim dbu As String = "SELECT * FROM exportpermit WHERE companyID='" & SelectCompany.SelectedValue & "'"

            Using cnu As MySqlCommand = New MySqlCommand(dbu, conn)
                Using dau As New MySqlDataAdapter(cnu)
                    Dim dt As New DataTable
                    dau.Fill(dt)

                    SelectQuarter.DataSource = dt
                    SelectQuarter.DataTextField = "exportPermitName"
                    SelectQuarter.DataValueField = "ID"
                    SelectQuarter.DataBind()

                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)
        Finally
            DisconnectDatabase()
        End Try

    End Sub

    Dim CertificateOfIncorporations, MemorandumOfAssociations, CurrentProductions, ConformityCertificates, BankReferences, ClearanceCertificates, ExportPermitApplications, EvidenceOfPayments, CompanyID, ApplicationID As String
    Dim FilePath As String = HttpContext.Current.Request.ApplicationPath & "File Manager\ExportPermitFiles\"
    'HttpContext.Current.Request.PhysicalApplicationPath & "File Manager\ExportPermitFiles\"

    Protected Sub OnExportSelectedIndexChanged(sender As Object, e As EventArgs)

        CompanyID = ExportPermitGridView.SelectedRow.Cells(0).Text
        ApplicationID = ExportPermitGridView.SelectedRow.Cells(1).Text
        Session.Add("ApplicationID", ApplicationID)

        Session.Add("CompanyID", CompanyID)
        TabOverallContainer.Visible = True

        Try
            ConnectDatabase()

            Dim dbu As String = "SELECT * FROM exportpermit WHERE companyID='" & CompanyID & "' AND referenceCode='" & ApplicationID & "' "

            Using cnu As MySqlCommand = New MySqlCommand(dbu, conn)
                Using dau As New MySqlDataAdapter(cnu)
                    Dim dtm As New DataTable
                    dau.Fill(dtm)
                    Dim dsm As New DataSet
                    dau.Fill(dsm)
                    'Inspection tab
                    InspectionOfficer.Text = dsm.Tables(0).Rows(0).Item("inspectionOfficer").ToString
                    Dim InspectStatus = dsm.Tables(0).Rows(0).Item("inspectionStatus").ToString
                    If InspectStatus = "0" Then
                        InspectionStatus.Checked = False
                    ElseIf InspectStatus = "1" Then
                        InspectionStatus.Checked = True
                    End If
                    InspectionDate.Text = dsm.Tables(0).Rows(0).Item("inspectionDate").ToString
                    ProductDescription.Text = dsm.Tables(0).Rows(0).Item("productName").ToString
                    PeriodCoverFrom.Text = dsm.Tables(0).Rows(0).Item("periodCoveredFrom").ToString
                    PeriodCoverTo.Text = dsm.Tables(0).Rows(0).Item("periodCoveredTo").ToString
                    InspectionComment.Text = dsm.Tables(0).Rows(0).Item("inspectorComment").ToString
                    'Endorsement tab
                    EndorsementPermitQuarter.Text = dsm.Tables(0).Rows(0).Item("exportPermitName").ToString
                    Dim EndorsemenStatus = dsm.Tables(0).Rows(0).Item("endorsedStatus").ToString
                    If EndorsemenStatus = "0" Then
                        EndorsementStatus.Checked = False
                    ElseIf EndorsemenStatus = "1" Then
                        EndorsementStatus.Checked = True
                    End If
                    EndorsementDate.Text = dsm.Tables(0).Rows(0).Item("endorsedDate").ToString
                    EndorsedBy.Text = dsm.Tables(0).Rows(0).Item("endorsedBy").ToString
                    EndorsementComment.Text = dsm.Tables(0).Rows(0).Item("endorsecomment").ToString
                    'Recommendation tab
                    RecommendationPermitQuarter.Text = dsm.Tables(0).Rows(0).Item("exportPermitName").ToString
                    Dim RecommendStatus = dsm.Tables(0).Rows(0).Item("recommendationStatus").ToString
                    If RecommendStatus = "0" Then
                        RecommendationStatus.Checked = False
                    ElseIf RecommendStatus = "1" Then
                        RecommendationStatus.Checked = True
                    End If
                    RecommendationDate.Text = dsm.Tables(0).Rows(0).Item("recommendationDate").ToString
                    RecommendationComment.Text = dsm.Tables(0).Rows(0).Item("recommendationComment").ToString
                    RecommendationBy.Text = dsm.Tables(0).Rows(0).Item("recommendationName").ToString
                    'Approval tab
                    ApprovalPermitQuarter.Text = dsm.Tables(0).Rows(0).Item("exportPermitName").ToString
                    Dim ApproveStatus = dsm.Tables(0).Rows(0).Item("approvalStatus").ToString

                    If ApproveStatus = "0" Then
                        ApprovalStatus.Checked = False
                    ElseIf ApproveStatus = "1" Then
                        ApprovalStatus.Checked = True
                    End If
                    ApprovalDate.Text = dsm.Tables(0).Rows(0).Item("approvalDate").ToString
                    ApprovalComment.Text = dsm.Tables(0).Rows(0).Item("approvalComment").ToString
                    ApprovedBy.Text = dsm.Tables(0).Rows(0).Item("approvalName").ToString
                    'Entry tab
                    EntryPermitQuarter.Text = dsm.Tables(0).Rows(0).Item("exportPermitName").ToString
                    Dim EntrStatus = dsm.Tables(0).Rows(0).Item("entryStatus").ToString

                    If EntrStatus = "0" Then
                        EntryStatus.Checked = False
                    ElseIf EntrStatus = "1" Then
                        EntryStatus.Checked = True
                    End If
                    EntryDate.Text = dsm.Tables(0).Rows(0).Item("entryDate").ToString
                    AuthorizationComment.Text = dsm.Tables(0).Rows(0).Item("entryComment").ToString
                    AuthorizedBy.Text = dsm.Tables(0).Rows(0).Item("entryName").ToString
                    'Loading tab
                    LoadingPermitQuarter.Text = dsm.Tables(0).Rows(0).Item("exportPermitName").ToString
                    Dim LoadinStatus = dsm.Tables(0).Rows(0).Item("loadingStatus").ToString

                    If LoadinStatus = "0" Then
                        LoadingStatus.Checked = False
                    ElseIf LoadinStatus = "1" Then
                        LoadingStatus.Checked = True
                    End If
                    LoadingDate.Text = dsm.Tables(0).Rows(0).Item("loadingDate").ToString
                    LoaderComment.Text = dsm.Tables(0).Rows(0).Item("loadingComment").ToString
                    LoadedBy.Text = dsm.Tables(0).Rows(0).Item("loadingName").ToString
                    'Exit tab
                    ExitPermitQuarter.Text = dsm.Tables(0).Rows(0).Item("exportPermitName").ToString
                    Dim ExiStatus = dsm.Tables(0).Rows(0).Item("loadingStatus").ToString

                    If ExiStatus = "0" Then
                        ExitStatus.Checked = False
                    ElseIf LoadinStatus = "1" Then
                        ExitStatus.Checked = True
                    End If
                    ExitDate.Text = dsm.Tables(0).Rows(0).Item("exitDate").ToString
                    ExitComment.Text = dsm.Tables(0).Rows(0).Item("exitComment").ToString
                    ExitBy.Text = dsm.Tables(0).Rows(0).Item("exitName").ToString

                    'Tab pages ends here

                    Dim TerminalStatus = dsm.Tables(0).Rows(0).Item("terminalOperator").ToString
                    If TerminalStatus = "0" Then
                        TerminaOperator.Checked = False
                    ElseIf TerminalStatus = "1" Then
                        TerminaOperator.Checked = True
                    End If

                    Dim ApprovalStatuss = dsm.Tables(0).Rows(0).Item("approvalStatus").ToString
                    If ApprovalStatuss = "0" Or ApprovalStatuss = Nothing Then
                        ApplicationStatusText.Text = "Application is Incomplete"
                    ElseIf ApprovalStatuss = "1" Then
                        ApplicationStatusText.Text = "Application Process Completed"
                    End If
                    CertificateOfIncorporations = dsm.Tables(0).Rows(0).Item("certificateOfIncorporation").ToString
                    Session.Add("CertificateOfIncoporations", CertificateOfIncorporations)
                    MemorandumOfAssociations = dsm.Tables(0).Rows(0).Item("memorandumOfAssociation").ToString
                    Session.Add("MemorandumOfAssociations", MemorandumOfAssociations)
                    CurrentProductions = dsm.Tables(0).Rows(0).Item("currentProduction").ToString
                    Session.Add("CurrentProductions", CurrentProductions)
                    ConformityCertificates = dsm.Tables(0).Rows(0).Item("conformityCertificate").ToString
                    Session.Add("ConformityCertificates", ConformityCertificates)
                    BankReferences = dsm.Tables(0).Rows(0).Item("bankReference").ToString
                    Session.Add("BankReferences", BankReferences)
                    ClearanceCertificates = dsm.Tables(0).Rows(0).Item("clearanceCertificate").ToString
                    Session.Add("ClearanceCertificates", ClearanceCertificates)
                    ExportPermitApplications = dsm.Tables(0).Rows(0).Item("exportPermitApplication").ToString
                    Session.Add("ExportPermitApplications", ExportPermitApplications)
                    EvidenceOfPayments = dsm.Tables(0).Rows(0).Item("evidenceOfPayment").ToString
                    Session.Add("EvidenceOfPayments", EvidenceOfPayments)

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)
        End Try


        If CertificateOfIncorporations = Nothing Then
            CertificateOfIncorporation.Enabled = False
            CertificateOfIncorporation.BackColor = Drawing.Color.DarkGray

        Else
            CertificateOfIncorporation.Enabled = True
            CertificateOfIncorporation.BackColor = Drawing.Color.Empty
        End If

        If MemorandumOfAssociations = Nothing Then
            MemorandumOfAssociation.Enabled = False
            MemorandumOfAssociation.BackColor = Drawing.Color.DarkGray

        Else
            MemorandumOfAssociation.Enabled = True
            MemorandumOfAssociation.BackColor = Drawing.Color.Empty
        End If

        If CurrentProductions = Nothing Then
            CurrentProduction.Enabled = False
            CurrentProduction.BackColor = Drawing.Color.DarkGray

        Else
            CurrentProduction.Enabled = True
            CurrentProduction.BackColor = Drawing.Color.Empty
        End If


        If ConformityCertificates = Nothing Then
            ConformityCertificate.Enabled = False
            ConformityCertificate.BackColor = Drawing.Color.DarkGray

        Else
            ConformityCertificate.Enabled = True
            ConformityCertificate.BackColor = Drawing.Color.Empty
        End If


        If BankReferences = Nothing Then
            BankReference.Enabled = False
            BankReference.BackColor = Drawing.Color.DarkGray

        Else
            BankReference.Enabled = True
            BankReference.BackColor = Drawing.Color.Empty
        End If



        If ClearanceCertificates = Nothing Then
            ClearanceCertificate.Enabled = False
            ClearanceCertificate.BackColor = Drawing.Color.DarkGray

        Else
            ClearanceCertificate.Enabled = True
            ClearanceCertificate.BackColor = Drawing.Color.Empty
        End If


        If ExportPermitApplications = Nothing Then
            ExportPermitApplication.Enabled = False
            ExportPermitApplication.BackColor = Drawing.Color.DarkGray

        Else
            ExportPermitApplication.Enabled = True
            ExportPermitApplication.BackColor = Drawing.Color.Empty
        End If

        If EvidenceOfPayments = Nothing Then
            EvidenceOfPayment.Enabled = False
            EvidenceOfPayment.BackColor = Drawing.Color.DarkGray

        Else
            EvidenceOfPayment.Enabled = True
            EvidenceOfPayment.BackColor = Drawing.Color.Empty
        End If

    End Sub


    Protected Sub CertificateOfIncorporation_Click(sender As Object, e As EventArgs) Handles CertificateOfIncorporation.Click
        Response.Redirect("../../" & FilePath & Session("CertificateOfIncorporations"), False)
    End Sub


    Protected Sub MemorandumOfAssociation_Click(sender As Object, e As EventArgs) Handles MemorandumOfAssociation.Click

        Response.Redirect("../../" & FilePath & Session("MemorandumOfAssociations"), False)
    End Sub

    Protected Sub CurrentProduction_Click(sender As Object, e As EventArgs) Handles CurrentProduction.Click
        Response.Redirect("../../" & FilePath & Session("CurrentProductions"), False)

    End Sub

    Protected Sub ConformityCertificate_Click(sender As Object, e As EventArgs) Handles ConformityCertificate.Click
        Response.Redirect("../../" & FilePath & Session("ConformityCertificates"), False)

    End Sub

    Protected Sub BankReference_Click(sender As Object, e As EventArgs) Handles BankReference.Click
        Response.Redirect("../../" & FilePath & Session("BankReferences"), False)

    End Sub

    Protected Sub ClearanceCertificate_Click(sender As Object, e As EventArgs) Handles ClearanceCertificate.Click
        Response.Redirect("../../" & FilePath & Session("ClearanceCertificates"), False)

    End Sub

    Protected Sub ExportPermitApplication_Click(sender As Object, e As EventArgs) Handles ExportPermitApplication.Click
        Response.Redirect("../../" & FilePath & Session("ExportPermitApplications"), False)

    End Sub

    Protected Sub EvidenceOfPayment_Click(sender As Object, e As EventArgs) Handles EvidenceOfPayment.Click
        Response.Redirect("../../" & FilePath & Session("EvidenceOfPayments"), True)

    End Sub



    Protected Sub SaveInspection_Click(sender As Object, e As EventArgs) Handles SaveInspection.Click
        Try
            ConnectDatabase()
            Dim InspectionCheck = ""
            If InspectionStatus.Checked = True Then
                InspectionCheck = "1"
            Else
                InspectionCheck = "0"
            End If
            Dim strSQL As String
            strSQL = "UPDATE exportpermit SET inspectionOfficer='" & InspectionOfficer.Text & "', inspectionDate='" & InspectionDate.Text & "', inspectionStatus='" & InspectionCheck & "', inspectorComment='" & InspectionComment.Text & "' WHERE companyID= '" & Session("CompanyID") & "' AND referenceCode ='" & Session("ApplicationID") & "'"
            Dim cmd As New MySqlCommand(strSQL, conn)
            cmd.ExecuteNonQuery()
            If InspectionStatus.Checked = True Then
                MessageBox.Show(Me, "Export permit application has been inspected")

            Else
                MessageBox.Show(Me, "Export Inspection has been saved!")

            End If

            'This code do the loggin magic
            Dim ComputerName = System.Net.Dns.GetHostEntry(Request.ServerVariables("remote_addr")).HostName
            Dim UserIP = Request.ServerVariables("REMOTE_ADDR")
            'Dim UserBrowser = Request.ServerVariables("HTTP_USER_AGENT") 'Request.UserAgent '
            Dim osVersion As String = System.Environment.OSVersion.ToString()

            If osVersion.Contains("Windows") Then
                osVersion = "Windows Operating System"
            End If
            If osVersion.Contains("MAC") Then
                osVersion = "MAC Operating System"
            End If
            If osVersion.Contains("X11") Then
                osVersion = "UNIX Operating System"
            End If
            If osVersion.Contains("Linux") Then
                osVersion = "LINUX Operating System"
            End If

            Dim Activity As String = Session("LoggedInAdminLoginUsername") & "  save inspection of  " & SelectCompany.SelectedItem.Text & "  " & Session("ApplicationID") & "  permit appliation"
            Dim coms As New MySqlCommand
            coms.Connection = conn
            coms.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("UserLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
            coms.ExecuteNonQuery()

        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)

        Finally
            DisconnectDatabase()

        End Try
    End Sub

    Protected Sub SaveEndorsement_Click(sender As Object, e As EventArgs) Handles SaveEndorsement.Click
        Try
            ConnectDatabase()
            Dim EndorsedCheck = ""
            If EndorsementStatus.Checked = True Then
                EndorsedCheck = "1"
            Else
                EndorsedCheck = "0"
            End If
            Dim strSQL As String
            strSQL = "UPDATE exportpermit SET endorsedBy='" & EndorsedBy.Text & "', endorsedDate='" & EndorsementDate.Text & "', endorsedStatus='" & EndorsedCheck & "', endorsecomment='" & EndorsementComment.Text & "' WHERE companyID= '" & Session("CompanyID") & "' AND referenceCode ='" & Session("ApplicationID") & "'"
            Dim cmd As New MySqlCommand(strSQL, conn)
            cmd.ExecuteNonQuery()
            If EndorsementStatus.Checked = True Then
                MessageBox.Show(Me, "Export permit has been endorsed!")
            Else
                MessageBox.Show(Me, "Export Permit endorsement has been saved!")

            End If

            Dim Activity As String = Session("LoggedInAdminLoginUsername") & "  endorsed permit application of " & Session("LoggedInAdminLoginCompanyName") & "  " & Session("ApplicationID")
            Dim coms As New MySqlCommand
            coms.Connection = conn
            coms.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("UserLoginIPAddress") & "','" & ComputerName() & "','" & osVersion() & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
            coms.ExecuteNonQuery()


        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)

        Finally
            DisconnectDatabase()

        End Try
    End Sub

    Protected Sub SaveRecommendation_Click(sender As Object, e As EventArgs) Handles SaveRecommendation.Click
        Try
            ConnectDatabase()
            Dim RecommendationCheck = ""
            If RecommendationStatus.Checked = True Then
                RecommendationCheck = "1"
            Else
                RecommendationCheck = "0"
            End If
            Dim strSQL As String
            strSQL = "UPDATE exportpermit SET recommendationName='" & RecommendationBy.Text & "', recommendationDate='" & RecommendationDate.Text & "', recommendationStatus='" & RecommendationCheck & "', recommendationComment='" & RecommendationComment.Text & "' WHERE companyID= '" & Session("CompanyID") & "' AND referenceCode ='" & Session("ApplicationID") & "'"
            Dim cmd As New MySqlCommand(strSQL, conn)
            cmd.ExecuteNonQuery()
            If RecommendationStatus.Checked = True Then
                MessageBox.Show(Me, "Export permit application has been recommended!")
            Else
                MessageBox.Show(Me, "Export permit application has been recommeded!")

            End If

            Dim Activity As String = Session("LoggedInAdminLoginUsername") & "  recommend " & Session("LoggedInAdminLoginCompanyName") & "  " & Session("ApplicationID") & " permit application"
            Dim coms As New MySqlCommand
            coms.Connection = conn
            coms.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("UserLoginIPAddress") & "','" & ComputerName() & "','" & osVersion() & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
            coms.ExecuteNonQuery()


        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)

        Finally
            DisconnectDatabase()

        End Try
    End Sub



    Protected Sub SaveApproval_Click(sender As Object, e As EventArgs) Handles SaveApproval.Click
        Try
            ConnectDatabase()
            Dim ApprovedCheck = ""
            If ApprovalStatus.Checked = True Then
                ApprovedCheck = "1"
            Else
                ApprovedCheck = "0"
            End If
            Dim strSQL As String
            strSQL = "UPDATE exportpermit SET approvalName='" & ApprovedBy.Text & "', approvalDate='" & ApprovalDate.Text & "', approvalStatus='" & ApprovedCheck & "', approvalComment='" & ApprovalComment.Text & "' WHERE companyID= '" & Session("CompanyID") & "' AND referenceCode ='" & Session("ApplicationID") & "'"
            Dim cmd As New MySqlCommand(strSQL, conn)
            cmd.ExecuteNonQuery()
            If ApprovalStatus.Checked = True Then
                MessageBox.Show(Me, "Export permit application has been approved!")
            Else
                MessageBox.Show(Me, "Export Permit has been approved!")

            End If

            Dim Activity As String = Session("LoggedInAdminLoginUsername") & "  approved " & Session("LoggedInAdminLoginCompanyName") & "  " & Session("ApplicationID") & "  permit application!"
            Dim coms As New MySqlCommand
            coms.Connection = conn
            coms.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("UserLoginIPAddress") & "','" & ComputerName() & "','" & osVersion() & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
            coms.ExecuteNonQuery()

        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)

        Finally
            DisconnectDatabase()

        End Try
    End Sub


    Protected Sub AuthorizeEntry_Click(sender As Object, e As EventArgs) Handles AuthorizeEntry.Click
        Try
            ConnectDatabase()
            Dim EntryCheck = ""
            If EntryStatus.Checked = True Then
                EntryCheck = "1"
            Else
                EntryCheck = "0"
            End If
            Dim strSQL As String
            strSQL = "UPDATE exportpermit SET entryName='" & AuthorizedBy.Text & "', entryDate='" & EntryDate.Text & "', entryStatus='" & EntryCheck & "', entryComment='" & AuthorizationComment.Text & "' WHERE companyID= '" & Session("CompanyID") & "' AND referenceCode ='" & Session("ApplicationID") & "'"
            Dim cmd As New MySqlCommand(strSQL, conn)
            cmd.ExecuteNonQuery()
            If EntryStatus.Checked = True Then
                MessageBox.Show(Me, "Export permit application has been authorized for entry!")
            Else
                MessageBox.Show(Me, "Export Permit has been authorized for entry!")

            End If

            Dim Activity As String = Session("LoggedInAdminLoginUsername") & "  authorized " & Session("LoggedInAdminLoginCompanyName") & "  " & Session("ApplicationID") & "  permit application!"
            Dim coms As New MySqlCommand
            coms.Connection = conn
            coms.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("UserLoginIPAddress") & "','" & ComputerName() & "','" & osVersion() & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
            coms.ExecuteNonQuery()

        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)

        Finally
            DisconnectDatabase()

        End Try
    End Sub



    Protected Sub ApproveLoading_Click(sender As Object, e As EventArgs) Handles ApproveLoading.Click
        Try
            ConnectDatabase()
            Dim LoadingCheck = ""
            If LoadingStatus.Checked = True Then
                LoadingCheck = "1"
            Else
                LoadingCheck = "0"
            End If
            Dim strSQL As String
            strSQL = "UPDATE exportpermit SET loadingName='" & LoadedBy.Text & "', loadingDate='" & LoadingDate.Text & "', loadingStatus='" & LoadingCheck & "', loadingComment='" & LoaderComment.Text & "' WHERE companyID= '" & Session("CompanyID") & "' AND referenceCode ='" & Session("ApplicationID") & "'"
            Dim cmd As New MySqlCommand(strSQL, conn)
            cmd.ExecuteNonQuery()
            If LoadingStatus.Checked = True Then
                MessageBox.Show(Me, "Export permit application has been approved for Loading!")
            Else
                MessageBox.Show(Me, "Export Permit approval for Loading has been saved!")

            End If

            Dim Activity As String = Session("LoggedInAdminLoginUsername") & "  authorized " & Session("LoggedInAdminLoginCompanyName") & "  " & Session("ApplicationID") & "  permit application!"
            Dim coms As New MySqlCommand
            coms.Connection = conn
            coms.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("UserLoginIPAddress") & "','" & ComputerName() & "','" & osVersion() & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
            coms.ExecuteNonQuery()

        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)

        Finally
            DisconnectDatabase()

        End Try
    End Sub



    Protected Sub ApproveExit_Click(sender As Object, e As EventArgs) Handles ApproveExit.Click
        Try
            ConnectDatabase()
            Dim ExitCheck = ""
            If ExitStatus.Checked = True Then
                ExitCheck = "1"
            Else
                ExitCheck = "0"
            End If
            Dim strSQL As String
            strSQL = "UPDATE exportpermit SET exitName='" & ExitBy.Text & "', exitDate='" & ExitDate.Text & "', approvalStatus='" & ExitCheck & "', exitComment='" & ExitComment.Text & "' WHERE companyID= '" & Session("CompanyID") & "' AND referenceCode ='" & Session("ApplicationID") & "'"
            Dim cmd As New MySqlCommand(strSQL, conn)
            cmd.ExecuteNonQuery()
            If ExitStatus.Checked = True Then
                MessageBox.Show(Me, "Export permit application has been approved for Exit")
            Else
                MessageBox.Show(Me, "Export Permit Exit approval has been saved!")

            End If

            Dim Activity As String = Session("LoggedInAdminLoginUsername") & "  authorized " & Session("LoggedInAdminLoginCompanyName") & "  " & Session("ApplicationID") & "  permit application!"
            Dim coms As New MySqlCommand
            coms.Connection = conn
            coms.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("UserLoginIPAddress") & "','" & ComputerName() & "','" & osVersion() & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
            coms.ExecuteNonQuery()

        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)

        Finally
            DisconnectDatabase()

        End Try
    End Sub


End Class