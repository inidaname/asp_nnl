Imports System.IO
Imports System.Net
Imports System.Web
Imports System.Data
Imports System.Text
Imports System.Web.UI
Imports System.Drawing
Imports System.Data.OleDb
Imports System.Web.Security
Imports System.Configuration
Imports MySql.Data.MySqlClient
Imports System.Drawing.Drawing2D
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Security.Cryptography


Public Class _default8
    Inherits System.Web.UI.Page
    Dim ds As New DataSet
    Dim ComputerName, UserIP, osVersion As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Check if Admin login session is active, if its not return to Login page
        loggedUser.Text = Session("LoggedInAdminLoginUsername")

        If IsNothing(Session("LoggedInAdminLoginUsername")) Then
            Response.Redirect("../")

        Else

        End If


        'Check if the logged in user have an admin account or staff Account, if its admin display all icons. if its staff, display only allowed right

        If Session("LoggedInAdminLoginAccountType") = "Staff" Then
            UserPanel.Visible = False
        End If
        If Session("LoggedInAdminLoginAccountType") = "Other" Then
            UserPanel.Visible = False
        End If


        If Not Session("LoggedInAdminLoginAccountType") = "" And Session("LoggedInAdminLoginCompanyMgtRight") = "0" Then
            CompanyManagementLink.Visible = False
        End If
        If Not Session("LoggedInAdminLoginAccountType") = "" And Session("LoggedInAdminLoginInstrumentMgtRight") = "0" Then
            InstrumentManagementLink.Visible = False
        End If
        If Not Session("LoggedInAdminLoginAccountType") = "" And Session("LoggedInAdminLoginStaticDataRight") = "0" Then
            StaticDataLink.Visible = False
            StaticData.Visible = False
        End If
        If Not Session("LoggedInAdminLoginAccountType") = "" And Session("LoggedInAdminLoginImportPermitManagement") = "0" Then
            ImportPermitManagementLink.Visible = False
        End If
        If Not Session("LoggedInAdminLoginAccountType") = "" And Session("LoggedInAdminLoginExportPermitManagement") = "0" Then
            ExportPermitManagementLink.Visible = False
        End If
        If Not Session("LoggedInAdminLoginAccountType") = "" And Session("LoggedInAdminLoginManageLot") = "0" Then
            LotTable.Visible = False
            LotsAllocation.Visible = False


        End If
        If Not Session("LoggedInAdminLoginAccountType") = "" And Session("LoggedInAdminLoginInvoiceReport") = "0" Then
            InvoiceReport.Visible = False

        End If
        If Not Session("LoggedInAdminLoginAccountType") = "" And Session("LoggedInAdminLoginReportRight") = "0" Then
            ReportingPanel.Visible = False

        End If

        If Not Session("LoggedInAdminLoginAccountType") = "" And Session("LoggedInAdminLoginDownloadCenter") = "0" Then
            DownloadCenter.Visible = False
            FileManagerLink.Visible = False
            FileManagerPanel.Visible = False

        End If
        If Not Session("LoggedInAdminLoginAccountType") = "" And Session("LoggedInAdminLoginUploadNews") = "0" Then
            UploadNews.Visible = False

        End If
        If Not Session("LoggedInAdminLoginAccountType") = "" And Session("LoggedInAdminLoginUploadGallery") = "0" Then
            UploadPicture.Visible = False

        End If
        If Not Session("LoggedInAdminLoginAccountType") = "" And Session("LoggedInAdminLoginSetupOffice") = "0" Then
            setupOffice.Visible = False

        End If
        If Not Session("LoggedInAdminLoginAccountType") = "" And Session("LoggedInAdminLoginQuizRight") = "0" Then
            UploadQuiz.Visible = False

        End If
        If Not Session("LoggedInAdminLoginAccountType") = "" And Session("LoggedInAdminLoginCareerRight") = "0" Then
            UploadCareer.Visible = False

        End If
        If Not Session("LoggedInAdminLoginAccountType") = "" And Session("LoggedInAdminLoginInstrumentFee") = "0" Then
            InstrumentFee.Visible = False

        End If
        If Not Session("LoggedInAdminLoginAccountType") = "" And Session("LoggedInAdminLoginMeasurement") = "0" Then
            Measurement.Visible = False

        End If

        If Not Session("LoggedInAdminLoginAccountType") = "" And Session("LoggedInAdminLoginInvoiceReport") = "0" Then
            InvoiceReport.Visible = False
            ReportingLink.Visible = False
        End If

        If Not Session("LoggedInAdminLoginAccountType") = "" And Session("LoggedInAdminLoginSettings") = "0" Then
            SettingsPanel.Visible = False
        End If

        If Not Session("LoggedInAdminLoginAccountType") = "" And Session("LoggedInAdminLoginExportDataReturn") = "0" Then
            ExportDataLink.Visible = False
        End If

        If Session("LoggedInAdminLoginCompanyMgtRight") = "0" And Session("LoggedInAdminLoginInstrumentMgtRight") = "0" And Session("LoggedInAdminLoginStaticDataRight") = "0" And Session("LoggedInAdminLoginImportPermitManagement") = "0" And Session("LoggedInAdminLoginManageLot") = "0" And Session("LoggedInAdminLoginInvoiceReport") = "0" And Session("LoggedInAdminLoginReportRight") = "0" And Session("LoggedInAdminLoginDownloadCenter") = "0" And Session("LoggedInAdminLoginUploadNews") = "0" And Session("LoggedInAdminLoginUploadGallery") = "0" And Session("LoggedInAdminLoginSetupOffice") = "0" And Session("LoggedInAdminLoginQuizRight") = "0" And Session("LoggedInAdminLoginCareerRight") = "0" And Session("LoggedInAdminLoginInstrumentFee") = "0" And Session("LoggedInAdminLoginMeasurement") = "0" And Session("LoggedInAdminLoginInvoiceReport") = "0" And Session("LoggedInAdminLoginSettings") = "0" And Session("LoggedInAdminLoginExportDataReturn") = "0" And Session("LoggedInAdminLoginExportPermitManagement") = "1" Then
            DashboardLink.Visible = False
            Response.Redirect("../export-management")
        End If

         

        Try
            DownloadLogs.Text = "Download User Logs"

            ConnectDatabase()
            Dim Mode = "Userlogs"

            Dim db As String = "SELECT * FROM userlog ORDER BY ID DESC"

            Using cn As MySqlCommand = New MySqlCommand(db, conn)
                Using da As New MySqlDataAdapter(cn)

                    'Get the list of rows needed into Session, so as to enable us retreive it later

                    Dim dt As New DataTable()
                    Dim ds As New DataSet()
                    da.Fill(dt)
                    da.Fill(ds, "userlog")

                    'UserLogsGrid.DataSource = Nothing
                    'UserLogsGrid.DataBind()

                    UserLogsGrid.DataSource = ds
                    UserLogsGrid.DataMember = "userlog"
                    UserLogsGrid.DataBind()
                    Cache("UserLogData") = dt



                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)
        End Try

        Try
            Dim db As String = "SELECT * FROM gallerygroups"

            Using cn As MySqlCommand = New MySqlCommand(db, conn)
                Using da As New MySqlDataAdapter(cn)

                    'Get the list of rows needed into Session, so as to enable us retreive it later

                    Dim dt As New DataTable()
                    Dim ds As New DataSet()
                    da.Fill(dt)
                    da.Fill(ds)

                    PictureGalleryGroup.DataSource = dt
                    PictureGalleryGroup.DataTextField = "groups"
                    PictureGalleryGroup.DataValueField = "ID"
                    PictureGalleryGroup.DataBind()


                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)
        End Try

        If Not IsPostBack Then
            Try
                Dim db As String = "SELECT companyEmail,username FROM company ORDER BY username"

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)
                        'Get the list of rows needed into Session, so as to enable us retreive it later
                        Dim dt As New DataTable()
                        da.Fill(dt)
                        RecipientName.DataSource = dt
                        RecipientName.DataTextField = "username"
                        RecipientName.DataValueField = "companyEmail"
                        RecipientName.DataBind()
                        RecipientName.Items.Insert(0, "...Select All Registered Users...")

                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            End Try

            Try
                Dim db As String = "SELECT companyPhoneNumber,username FROM company ORDER BY username"

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)
                        'Get the list of rows needed into Session, so as to enable us retreive it later
                        Dim dt As New DataTable()
                        da.Fill(dt)
                        SMSRecipients.DataSource = dt
                        SMSRecipients.DataTextField = "username"
                        SMSRecipients.DataValueField = "companyPhoneNumber"
                        SMSRecipients.DataBind()
                        SMSRecipients.Items.Insert(0, "...Select All Registered Users...")

                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            End Try
        End If

    End Sub


    Protected Sub UserLogsGrid_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        UserLogsGrid.PageIndex = e.NewPageIndex
        UserLogsGrid.DataSource = CType(Cache("UserLogData"), DataTable)
        UserLogsGrid.DataBind()


        VisitorLogsGrid.DataSource = Nothing
        VisitorLogsGrid.DataBind()
    End Sub

    Protected Sub VisitorsLogGrid_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        VisitorLogsGrid.PageIndex = e.NewPageIndex
        VisitorLogsGrid.DataSource = CType(Cache("VisitorLogData"), DataTable)
        VisitorLogsGrid.DataBind()

        UserLogsGrid.DataSource = Nothing
        UserLogsGrid.DataBind()
    End Sub

    Protected Sub ViewLog_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ViewLog.Click
        If SelectLogs.SelectedValue = "User" Then

            DownloadLogs.Text = "Download User Logs"
            Try
                ConnectDatabase()
                Dim Mode = "Userlogs"

                Dim db As String = "SELECT * FROM userlog ORDER BY ID DESC"

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)

                        'Get the list of rows needed into Session, so as to enable us retreive it later

                        Dim dt As New DataTable()
                        Dim ds As New DataSet()
                        da.Fill(dt)
                        da.Fill(ds, "userlog")

                        VisitorLogsGrid.DataSource = Nothing
                        VisitorLogsGrid.DataBind()
                        Cache.Remove("VisitorLogData")

                        UserLogsGrid.DataSource = ds
                        UserLogsGrid.DataMember = "userlog"
                        UserLogsGrid.DataBind()
                        Cache("UserLogData") = dt



                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
            End Try

        Else
            DownloadLogs.Text = "Download Visitor Logs"
            Try
                ConnectDatabase()
                Dim db As String = "SELECT * FROM visitorslog ORDER BY ID DESC"

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)

                        'Get the list of rows needed into Session, so as to enable us retreive it later

                        Dim dt As New DataTable()
                        Dim ds As New DataSet()
                        da.Fill(dt)
                        da.Fill(ds, "visitorslog")

                        UserLogsGrid.DataSource = Nothing
                        UserLogsGrid.DataBind()
                        '("UserLogData") = Nothing
                        Cache.Remove("UserLogData")

                        VisitorLogsGrid.DataSource = ds
                        VisitorLogsGrid.DataMember = "visitorslog"
                        VisitorLogsGrid.DataBind()
                        Cache("VisitorLogData") = dt



                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
            End Try

        End If


    End Sub

    Public Overloads Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)

        ' Verifies that the control is rendered
    End Sub

    Protected Sub DownloadLogs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DownloadLogs.Click

        If SelectLogs.SelectedValue = "User" Then

            Response.Clear()
            Response.Buffer = True

            Response.AddHeader("content-disposition",
            "attachment;filename=UserLogs.xls")
            Response.Charset = ""
            Response.ContentType = "application/vnd.ms-excel"

            Dim sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)

            UserLogsGrid.AllowPaging = False
            UserLogsGrid.DataBind()
            UserLogsGrid.Attributes.Add("style", "grid")

            UserLogsGrid.RenderControl(hw)

            'style to format numbers to string
            Dim style As String = "<style>.textmode{mso-number-format:\@;}</style>"
            Response.Write(style)
            Response.Output.Write(sw.ToString())
            Response.Flush()
            Response.End()

        ElseIf SelectLogs.SelectedValue = "Visitor" Then

            Try
                ConnectDatabase()
                Dim db As String = "SELECT * FROM visitorslog ORDER BY ID DESC"

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)

                        'Get the list of rows needed into Session, so as to enable us retreive it later

                        Dim dt As New DataTable()
                        Dim ds As New DataSet()
                        da.Fill(dt)
                        da.Fill(ds, "visitorslog")

                        UserLogsGrid.DataSource = Nothing
                        UserLogsGrid.DataBind()
                        '("UserLogData") = Nothing
                        Cache.Remove("UserLogData")

                        VisitorLogsGrid.DataSource = ds
                        VisitorLogsGrid.DataMember = "visitorslog"
                        VisitorLogsGrid.DataBind()
                        Cache("VisitorLogData") = dt



                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
            End Try



            Response.Clear()
            Response.Buffer = True

            Response.AddHeader("content-disposition",
            "attachment;filename=VisitorLogs.xls")
            Response.Charset = ""
            Response.ContentType = "application/vnd.ms-excel"

            Dim sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)

            VisitorLogsGrid.AllowPaging = False
            VisitorLogsGrid.DataBind()
            VisitorLogsGrid.Attributes.Add("style", "grid")

            VisitorLogsGrid.RenderControl(hw)

            'style to format numbers to string
            Dim style As String = "<style>.textmode{mso-number-format:\@;}</style>"
            Response.Write(style)
            Response.Output.Write(sw.ToString())
            Response.Flush()
            Response.End()

             

        End If

        
    End Sub

    'Load all data after page load is complete
    Private Sub _default8_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        If IsPostBack = False Then
            Try
                ConnectDatabase()

                Try
                    Dim db As String = "SELECT * FROM admin"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)
 
                            Dim dt As New DataTable()
                            Dim ds As New DataSet()
                            da.Fill(dt)
                            da.Fill(ds)

                            SelectUser.DataSource = dt
                            SelectUser.DataTextField = "username"
                            SelectUser.DataValueField = "ID"
                            SelectUser.DataBind()

                        End Using
                    End Using

                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                End Try


                Try

                    Dim db As String = "SELECT * FROM lots"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)
 
                            Dim dt As New DataTable()
                            da.Fill(dt)

                            Dim ds As New DataSet()
                            da.Fill(ds)

                            SelectLotToEdit.DataSource = dt
                            SelectLotToEdit.DataTextField = "lotName"
                            SelectLotToEdit.DataValueField = "ID"
                            SelectLotToEdit.DataBind()

                            SelectLotName.DataSource = dt
                            SelectLotName.DataTextField = "lotName"
                            SelectLotName.DataValueField = "ID"
                            SelectLotName.DataBind()

                        End Using
                    End Using

                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                End Try


                Try

                    Dim db As String = "SELECT * FROM terminals"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)
 
                            Dim dt As New DataTable()
                            da.Fill(dt)

                            Dim ds As New DataSet()
                            da.Fill(ds)

                            TerminalName.DataSource = dt
                            TerminalName.DataTextField = "terminalName"
                            TerminalName.DataValueField = "ID"
                            TerminalName.DataBind()


                        End Using
                    End Using

                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                End Try

                Try

                    Dim db As String = "SELECT * FROM downloadcenter"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)
 
                            Dim dt As New DataTable()
                            Dim ds As New DataSet()
                            da.Fill(dt)
                            da.Fill(ds)

                            SelectFileDownload.DataSource = dt
                            SelectFileDownload.DataTextField = "fileName"
                            SelectFileDownload.DataValueField = "ID"
                            SelectFileDownload.DataBind()

                        End Using
                    End Using

                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                End Try


                'Load data into select News Header
                Try

                    Dim db As String = "SELECT * FROM article"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)

                            Dim dt As New DataTable()
                            Dim ds As New DataSet()
                            da.Fill(dt)
                            da.Fill(ds)

                            SelectNewHeader.DataSource = dt
                            SelectNewHeader.DataTextField = "articleTitle"
                            SelectNewHeader.DataValueField = "ID"
                            SelectNewHeader.DataBind()

                        End Using
                    End Using

                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                End Try


                'Load data into select Picture Gallery
                Try

                    Dim db As String = "SELECT * FROM gallery"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)
 
                            Dim dt As New DataTable()
                            Dim ds As New DataSet()
                            da.Fill(dt)
                            da.Fill(ds)

                            SelectPictureGallery.DataSource = dt
                            SelectPictureGallery.DataTextField = "caption"
                            SelectPictureGallery.DataValueField = "ID"
                            SelectPictureGallery.DataBind()

                        End Using
                    End Using

                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                End Try



                'Load data into State Address Office
                Try

                    Dim db As String = "SELECT * FROM state ORDER BY state ASC"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)

                            Dim dt As New DataTable()
                            Dim ds As New DataSet()
                            da.Fill(dt)
                            da.Fill(ds)

                            SelectOfficeState.DataSource = dt
                            SelectOfficeState.DataTextField = "state"
                            SelectOfficeState.DataValueField = "ID"
                            SelectOfficeState.DataBind()

                        End Using
                    End Using

                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                End Try



                'Load data into State Office Select Dropdown
                Try

                    Dim db As String = "SELECT * FROM statecontacts  ORDER BY state ASC"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)
 
                            Dim dt As New DataTable()
                            Dim ds As New DataSet()
                            da.Fill(dt)
                            da.Fill(ds)

                            SelectStateOffice.DataSource = dt
                            SelectStateOffice.DataTextField = "state"
                            SelectStateOffice.DataValueField = "ID"
                            SelectStateOffice.DataBind()

                        End Using
                    End Using

                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                End Try



                'This populate state
                Try
                    ConnectDatabase()

                    Dim db As String = "SELECT * FROM state"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)
                          
                            Dim dt As New DataTable()
                            da.Fill(dt)
                            UploadedStates.DataSource = dt
                            UploadedStates.DataTextField = "state"
                            UploadedStates.DataValueField = "ID"
                            UploadedStates.DataBind()

                        End Using
                    End Using

                    'Trow errow is anything is wrong with the code

                Catch ex As Exception

                    MessageBox.Show(Me, ex.Message)

                Finally
                    'After execution of mysql query, disconnect database
                    DisconnectDatabase()
                End Try


                'This populate Fee Group
                Try
                    ConnectDatabase()

                    Dim db As String = "SELECT * FROM feegroup"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)
                           
                            Dim dt As New DataTable()
                            da.Fill(dt)
                            ModifyFeeGroup.DataSource = dt
                            ModifyFeeGroup.DataTextField = "feeGroup"
                            ModifyFeeGroup.DataValueField = "ID"
                            ModifyFeeGroup.DataBind()

                            SelectFeeGroup.DataSource = dt
                            SelectFeeGroup.DataTextField = "feeGroup"
                            SelectFeeGroup.DataValueField = "ID"
                            SelectFeeGroup.DataBind()


                            SelectFeeGroupFee.DataSource = dt
                            SelectFeeGroupFee.DataTextField = "feeGroup"
                            SelectFeeGroupFee.DataValueField = "ID"
                            SelectFeeGroupFee.DataBind()

                        End Using
                    End Using

                Catch ex As Exception

                    MessageBox.Show(Me, ex.Message)

                Finally
                    'After execution of mysql query, disconnect database
                    DisconnectDatabase()
                End Try


                'This populate Fee Group Sub
                Try
                    ConnectDatabase()

                    Dim db As String = "SELECT * FROM feesubgroup"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)
                            'Fill data of logged in user into dataset

                            Dim dt As New DataTable()
                            da.Fill(dt)
                            SelectFeeSub.DataSource = dt
                            SelectFeeSub.DataTextField = "groupSub"
                            SelectFeeSub.DataValueField = "ID"
                            SelectFeeSub.DataBind()

                            SelectFeeSubFee.DataSource = dt
                            SelectFeeSubFee.DataTextField = "groupSub"
                            SelectFeeSubFee.DataValueField = "ID"
                            SelectFeeSubFee.DataBind()

                        End Using
                    End Using
 
                Catch ex As Exception

                    MessageBox.Show(Me, ex.Message)

                Finally
                    'After execution of mysql query, disconnect database
                    DisconnectDatabase()
                End Try


                'This populate Fee Group Sub
                Try
                    ConnectDatabase()

                    Dim db As String = "SELECT * FROM feetable"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)
                            'Fill data of logged in user into dataset

                            Dim dt As New DataTable()
                            da.Fill(dt)
                            SelectMeasureRange.DataSource = dt
                            SelectMeasureRange.DataTextField = "measureRange"
                            SelectMeasureRange.DataValueField = "ID"
                            SelectMeasureRange.DataBind()

                            FeeDescription.DataSource = dt
                            FeeDescription.DataTextField = "measureRange"
                            FeeDescription.DataValueField = "ID"
                            FeeDescription.DataBind()


                        End Using
                    End Using
                     
                Catch ex As Exception

                    MessageBox.Show(Me, ex.Message)

                Finally
                    'After execution of mysql query, disconnect database
                    DisconnectDatabase()
                End Try



                'This populate Sector
                Try
                    ConnectDatabase()

                    Dim db As String = "SELECT * FROM sector"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)
 
                            Dim dt As New DataTable()
                            da.Fill(dt)
                            ModifySector.DataSource = dt
                            ModifySector.DataTextField = "sector"
                            ModifySector.DataValueField = "ID"
                            ModifySector.DataBind()

                            SelectSector.DataSource = dt
                            SelectSector.DataTextField = "sector"
                            SelectSector.DataValueField = "ID"
                            SelectSector.DataBind()

                            SelectSectorAdd.DataSource = dt
                            SelectSectorAdd.DataTextField = "sector"
                            SelectSectorAdd.DataValueField = "ID"
                            SelectSectorAdd.DataBind()

                            FeeSector.DataSource = dt
                            FeeSector.DataTextField = "sector"
                            FeeSector.DataValueField = "ID"
                            FeeSector.DataBind()

                        End Using
                    End Using
 
                Catch ex As Exception

                    MessageBox.Show(Me, ex.Message)

                Finally
                    'After execution of mysql query, disconnect database
                    DisconnectDatabase()
                End Try


                'This populate device or instrument category 
                Try
                    ConnectDatabase()

                    Dim db As String = "SELECT * FROM devicecategories ORDER BY deviceCategory ASC"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)
                           
                            Dim dt As New DataTable()
                            da.Fill(dt)
                            ModifyInstrumentCategory.DataSource = dt
                            ModifyInstrumentCategory.DataTextField = "deviceCategory"
                            ModifyInstrumentCategory.DataValueField = "ID"
                            ModifyInstrumentCategory.DataBind()

                            'SelectInstrumentCategoryAdd.DataSource = dt
                            'SelectInstrumentCategoryAdd.DataTextField = "deviceCategory"
                            'SelectInstrumentCategoryAdd.DataValueField = "ID"
                            'SelectInstrumentCategoryAdd.DataBind()


                            SelectInstrumentCategory.DataSource = dt
                            SelectInstrumentCategory.DataTextField = "deviceCategory"
                            SelectInstrumentCategory.DataValueField = "ID"
                            SelectInstrumentCategory.DataBind()


                            'FeeInstrumentCategory.DataSource = dt
                            'FeeInstrumentCategory.DataTextField = "deviceCategory"
                            'FeeInstrumentCategory.DataValueField = "ID"
                            'FeeInstrumentCategory.DataBind()

                        End Using
                    End Using
 
                Catch ex As Exception

                    MessageBox.Show(Me, ex.Message)

                Finally
                    'After execution of mysql query, disconnect database
                    DisconnectDatabase()
                End Try


                'This populate device or instrument category 
                Try
                    ConnectDatabase()

                    Dim db As String = "SELECT * FROM devicesub ORDER BY deviceType ASC"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)
                           
                            Dim dt As New DataTable()
                            da.Fill(dt)

                            ModifyInstrumentSubCategory.DataSource = dt
                            ModifyInstrumentSubCategory.DataTextField = "deviceType"
                            ModifyInstrumentSubCategory.DataValueField = "ID"
                            ModifyInstrumentSubCategory.DataBind()

                            ModifyInstrumentFee.DataSource = dt
                            ModifyInstrumentFee.DataTextField = "deviceType"
                            ModifyInstrumentFee.DataValueField = "ID"
                            ModifyInstrumentFee.DataBind()

                            'SelectInstrumentSubCategory.DataSource = dt
                            'SelectInstrumentSubCategory.DataTextField = "deviceType"
                            'SelectInstrumentSubCategory.DataValueField = "ID"
                            'SelectInstrumentSubCategory.DataBind()

                            DeviceTypeMeasurement.DataSource = dt
                            DeviceTypeMeasurement.DataTextField = "deviceType"
                            DeviceTypeMeasurement.DataValueField = "ID"
                            DeviceTypeMeasurement.DataBind()

                            'FeeInstrumentSub.DataSource = dt
                            'FeeInstrumentSub.DataTextField = "deviceType"
                            'FeeInstrumentSub.DataValueField = "ID"
                            'FeeInstrumentSub.DataBind()

                        End Using
                    End Using
                     
                Catch ex As Exception

                    MessageBox.Show(Me, ex.Message)

                Finally
                    'After execution of mysql query, disconnect database
                    DisconnectDatabase()
                End Try



                'This populate device or instrument category 
                Try
                    ConnectDatabase()

                    Dim db As String = "SELECT * FROM devicemeasurement"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)
                             
                            Dim dt As New DataTable()
                            da.Fill(dt)

                            'FeeMeasurement.DataSource = dt
                            'FeeMeasurement.DataTextField = "measureName"
                            'FeeMeasurement.DataValueField = "ID"
                            'FeeMeasurement.DataBind()
                            'FeeMeasurement.Items.Insert(0, "None")
                            'FeeMeasurement.Items.FindByText("None").Selected = True

                        End Using
                    End Using
                     
                Catch ex As Exception

                    MessageBox.Show(Me, ex.Message)

                Finally
                    'After execution of mysql query, disconnect database
                    DisconnectDatabase()
                End Try



                'This populate Measurement 
                Try
                    ConnectDatabase()

                    Dim db As String = "SELECT * FROM measurement"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)
                            
                            Dim dt As New DataTable()
                            da.Fill(dt)

                            ModifyMeasureMeasurement.DataSource = dt
                            ModifyMeasureMeasurement.DataTextField = "measureName"
                            ModifyMeasureMeasurement.DataValueField = "ID"
                            ModifyMeasureMeasurement.DataBind()

                            SelectMeasureMeasurements.DataSource = dt
                            SelectMeasureMeasurements.DataTextField = "measureName"
                            SelectMeasureMeasurements.DataValueField = "ID"
                            SelectMeasureMeasurements.DataBind()

                        End Using
                    End Using
                     
                Catch ex As Exception

                    MessageBox.Show(Me, ex.Message)

                Finally
                    'After execution of mysql query, disconnect database
                    DisconnectDatabase()
                End Try


                'This populate Device Measurement 
                Try
                    ConnectDatabase()

                    Dim db As String = "SELECT * FROM devicemeasurement"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)
 
                            Dim dt As New DataTable()
                            da.Fill(dt)

                            ModifyMeasurement.DataSource = dt
                            ModifyMeasurement.DataTextField = "deviceType"
                            ModifyMeasurement.DataValueField = "ID"
                            ModifyMeasurement.DataBind()

                        End Using
                    End Using
 
                Catch ex As Exception

                    MessageBox.Show(Me, ex.Message)

                Finally
                    'After execution of mysql query, disconnect database
                    DisconnectDatabase()
                End Try
 
                'This is the end of the line
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)

            Finally
                DisconnectDatabase()
            End Try
        Else


        End If

    End Sub




    Protected Sub LogoutAdmin_Click(sender As Object, e As EventArgs) Handles LogoutAdmin.Click

        'Log user out activity
        Try
            ConnectDatabase()

            Dim Activity As String = "Admin User logged out!"
            Dim com As New MySqlCommand
            com.Connection = conn
            com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
            com.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)

        Finally
            DisconnectDatabase()
        End Try

        Session("LoggedInAdminLoginUsername") = ""
        Session.Clear()
        Session.RemoveAll()

        Response.AppendHeader("Refresh", "0;url=./")


    End Sub

    Public Sub EnableOrDisable()

        If ModifyCompanyManagementRight.Checked = True Then
            ModifyCompanyManagementRight.Text = "1"

        End If

        If ModifyInstrumentManagementRight.Checked = True Then
            ModifyInstrumentManagementRight.Text = "1"
        End If

        If ModifyStaticDataRight.Checked = True Then
            ModifyStaticDataRight.Text = "1"

        End If

        If ModifyLotsManagementRight.Checked = True Then
            ModifyLotsManagementRight.Text = "1"
        End If

        If ModifyInvoiceReportRight.Checked = True Then
            ModifyInvoiceReportRight.Text = "1"


        End If

        If ModifyReportsRight.Checked = True Then
            ModifyReportsRight.Text = "1"

        End If

        If ModifyExportPermitManagement.Checked = True Then
            ModifyExportPermitManagement.Text = "1"

        End If

        If ModifyImportPermitManagement.Checked = True Then
            ModifyImportPermitManagement.Text = "1"

        End If

        If ModifyDownloadManagerRight.Checked = True Then
            ModifyDownloadManagerRight.Text = "1"

        End If

        If ModifyUploadNewsRight.Checked = True Then
            ModifyUploadNewsRight.Text = "1"
        End If

        If ModifyOtherDocumentsRight.Checked = True Then
            ModifyOtherDocumentsRight.Text = "1"

        End If

        If ModifyUploadPictureRight.Checked = True Then
            ModifyUploadPictureRight.Text = "1"
        End If

        If ModifySetupOfficeRight.Checked = True Then
            ModifySetupOfficeRight.Text = "1"

        End If

        If ModifyExportImportExitRight.Checked = True Then
            ModifyExportImportExitRight.Text = "1"

        End If

        If ModifyExportImportLoadingRight.Checked = True Then
            ModifyExportImportLoadingRight.Text = "1"

        End If


        If ModifyExportImportEntryRight.Checked = True Then
            ModifyExportImportEntryRight.Text = "1"

        End If



        If ModifyExportImportApprovalRight.Checked = True Then
            ModifyExportImportApprovalRight.Text = "1"

        End If

        If ModifyExportImportInspectionRight.Checked = True Then
            ModifyExportImportInspectionRight.Text = "1"

        End If

        If ModifyExportImportEndorseRight.Checked = True Then
            ModifyExportImportEndorseRight.Text = "1"

        End If

        If ModifyExportImportRecomendRight.Checked = True Then
            ModifyExportImportRecomendRight.Text = "1"

        End If

        If ModifyArchiveAccessRight.Checked = True Then
            ModifyArchiveAccessRight.Text = "1"

        End If

        If ModifyUploadQuizRight.Checked = True Then
            ModifyUploadQuizRight.Text = "1"

        End If

        If ModifyUploadCareerRight.Checked = True Then
            ModifyUploadCareerRight.Text = "1"
        End If

        If ModifyInstrumentFeeRight.Checked = True Then
            ModifyInstrumentFeeRight.Text = "1"

        End If

        If ModifyMeasurementRight.Checked = True Then
            ModifyMeasurementRight.Text = "1"


        End If


        If CompanyManagementRight.Checked = True Then
            CompanyManagementRight.Text = "1"

        End If

        If InstrumentManagementRight.Checked = True Then
            InstrumentManagementRight.Text = "1"
        End If

        If StaticDataRights.Checked = True Then
            StaticDataRights.Text = "1"

        End If

        If LotsManagementRight.Checked = True Then
            LotsManagementRight.Text = "1"
        End If

        If InvoiceReportRight.Checked = True Then
            InvoiceReportRight.Text = "1"


        End If

        If ReportsRight.Checked = True Then
            ReportsRight.Text = "1"

        End If

        If ExportPermitManagement.Checked = True Then
            ExportPermitManagement.Text = "1"

        End If

        If ImportPermitManagement.Checked = True Then
            ImportPermitManagement.Text = "1"

        End If

        If DownloadManagerRight.Checked = True Then
            DownloadManagerRight.Text = "1"

        End If

        If UploadNewsRight.Checked = True Then
            UploadNewsRight.Text = "1"
        End If

        If OtherDocumentsRight.Checked = True Then
            OtherDocumentsRight.Text = "1"

        End If

        If UploadPictureRight.Checked = True Then
            UploadPictureRight.Text = "1"
        End If

        If SetupOfficeRight.Checked = True Then
            SetupOfficeRight.Text = "1"

        End If

        If ExportImportExitRight.Checked = True Then
            ExportImportExitRight.Text = "1"

        End If


        If ExportImportLoadingRight.Checked = True Then
            ExportImportLoadingRight.Text = "1"

        End If


        If ExportImportEntryRight.Checked = True Then
            ExportImportEntryRight.Text = "1"

        End If

        If ExportImportApprovalRight.Checked = True Then
            ExportImportApprovalRight.Text = "1"

        End If

        If ExportImportInspectionRight.Checked = True Then
            ExportImportInspectionRight.Text = "1"

        End If

        If ExportImportEndorseRight.Checked = True Then
            ExportImportEndorseRight.Text = "1"

        End If

        If ExportImportRecomendRight.Checked = True Then
            ExportImportRecomendRight.Text = "1"

        End If

        If ArchiveAccessRight.Checked = True Then
            ArchiveAccessRight.Text = "1"

        End If

        If UploadQuizRight.Checked = True Then
            UploadQuizRight.Text = "1"

        End If

        If UploadCareerRight.Checked = True Then
            UploadCareerRight.Text = "1"
        End If

        If InstrumentFeeRight.Checked = True Then
            InstrumentFeeRight.Text = "1"

        End If

        If MeasurementRight.Checked = True Then
            MeasurementRight.Text = "1"

        End If

        If ExportImportEntryRight.Checked = True Then
            ExportImportEntryRight.Text = "1"

        End If

        If ExportImportExitRight.Checked = True Then
            ExportImportExitRight.Text = "1"

        End If

        If ExportImportLoadingRight.Checked = True Then
            ExportImportLoadingRight.Text = "1"

        End If


        If Settings.Checked = True Then
            Settings.Text = "1"

        End If

        If ExportDataReturn.Checked = True Then
            ExportDataReturn.Text = "1"

        End If


    End Sub

    Protected Sub RegisterNewAdmin_Click(sender As Object, e As EventArgs) Handles RegisterNewAdmin.Click
        EnableOrDisable()

        If Me.Username.Text = "" Or Password.Text = "" Or ConfirmPassword.Text = "" Or Me.SecurityQuestion.Text = "" Or Me.SecurityAnswer.Text = "" Or Me.CompanyName.Text & "','" & Me.Surname.Text = "" Or Me.OtherNames.Text = "" Or Me.Address.Text = "" Or Me.Mobile.Text = "" Or Me.EmailAddress.Text = "" Or Me.Mobile.Text = "" Or Me.AccountType.Text = "" Then
            MessageBox.Show(Me, "Error: All fields are required!")
        ElseIf Password.Text = ConfirmPassword.Text Then
            Dim AdapterCheck As New MySqlDataAdapter
            Dim SqlQueryCheck = "SELECT * FROM admin WHERE username='" & Username.Text & "' OR email='" & EmailAddress.Text & "' OR phone='" & Mobile.Text & "'"
            Dim CommandCheck As New MySqlCommand
            CommandCheck.Connection = conn
            CommandCheck.CommandText = SqlQueryCheck
            AdapterCheck.SelectCommand = CommandCheck
            Dim readerCheck As MySqlDataReader
            readerCheck = CommandCheck.ExecuteReader
            'Check if the credentials provided is in the database
            If readerCheck.HasRows = 0 Then
                readerCheck.Close()

                Try
                    Dim HashedPassword As String
                    Dim EncodeMe As String = ConfirmPassword.Text
                    HashedPassword = getSHA512Hash(EncodeMe)
                    ConnectDatabase()

                    Dim cmd As New MySqlCommand
                    cmd.Connection = conn
                    cmd.CommandText = "INSERT INTO admin (username,password,securityQuestion,securityAnswer,companyName,surname,otherNames,contactAddress,phone,email,accountType,companyMgtRight,instrumentMgtRight,staticDataRight,manageLot,invoiceReport,reportRight,exportPermitMgt,importPermitMgt,downloadCenter,uploadNews,otherDocRight,uploadGallery,setupOffice,exitExportImport,loadingExportImport,entryExportImport,approveExportImport,inspectExportImport,endorseExportImport,recommendExportImport,archiveRight,quizRight,careerRight,instrumentFee,measurement,settings,exportDataReturn)  VALUES ('" & Me.Username.Text & "','" & HashedPassword & "','" & Me.SecurityQuestion.Text & "','" & Me.SecurityAnswer.Text & "','" & Me.CompanyName.Text & "','" & Me.Surname.Text & "','" & Me.OtherNames.Text & "','" & Me.Address.Text & "','" & Me.Mobile.Text & "','" & Me.EmailAddress.Text & "','" & Me.AccountType.SelectedValue & "','" & Me.CompanyManagementRight.Text & "','" & Me.InstrumentManagementRight.Text & "','" & Me.StaticDataRights.Text & "','" & Me.LotsManagementRight.Text & "','" & Me.InvoiceReportRight.Text & "','" & Me.ReportsRight.Text & "','" & Me.ExportPermitManagement.Text & "','" & Me.ImportPermitManagement.Text & "','" & Me.DownloadManagerRight.Text & "','" & Me.UploadNewsRight.Text & "','" & Me.OtherDocumentsRight.Text & "','" & Me.UploadPictureRight.Text & "','" & Me.SetupOfficeRight.Text & "','" & Me.ExportImportExitRight.Text & "','" & Me.ExportImportLoadingRight.Text & "','" & Me.ExportImportEntryRight.Text & "','" & Me.ExportImportApprovalRight.Text & "','" & Me.ExportImportInspectionRight.Text & "','" & Me.ExportImportEndorseRight.Text & "','" & Me.ExportImportRecomendRight.Text & "','" & Me.ArchiveAccessRight.Text & "','" & Me.UploadQuizRight.Text & "','" & Me.UploadCareerRight.Text & "','" & Me.InstrumentFeeRight.Text & "','" & Me.MeasurementRight.Text & "','" & Me.Settings.Text & "','" & Me.ExportDataReturn.Text & "')"

                    cmd.ExecuteNonQuery()
                    MessageBox.Show(Me, "User has been registered successfully, you can now login with your login credentrial")

                    Response.AppendHeader("Refresh", "0;url=./#create-user")

                    Dim Activity As String = "New " & AccountType.SelectedItem.Text & " has been regsitered by " & Session("LoggedInAdminLoginUsername")
                    Dim com As New MySqlCommand
                    com.Connection = conn
                    com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                    com.ExecuteNonQuery()
               
                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                Finally
                    DisconnectDatabase()
                    Response.AppendHeader("Refresh", "0;url=./#create-user")
                End Try
            Else
                readerCheck.Close()
                MessageBox.Show(Me, "User with either the E-mail or Phone Number or Username provided is already existing!")
            End If

        Else
            MessageBox.Show(Me, "Password do not match!")
        End If

     End Sub

    Sub AccountType_SelectedIndexChanged(sender As Object, e As EventArgs)

        If AccountType.SelectedValue = "Admin" Then

            CompanyManagementRight.Checked = True
            InstrumentManagementRight.Checked = True
            StaticDataRights.Checked = True
            LotsManagementRight.Checked = True
            InvoiceReportRight.Checked = True
            ReportsRight.Checked = True
            ExportPermitManagement.Checked = True
            ImportPermitManagement.Checked = True
            DownloadManagerRight.Checked = True
            UploadNewsRight.Checked = True
            OtherDocumentsRight.Checked = True
            UploadPictureRight.Checked = True
            SetupOfficeRight.Checked = True
            ExportImportExitRight.Checked = True
            ExportImportLoadingRight.Checked = True
            ExportImportEntryRight.Checked = True
            ExportImportApprovalRight.Checked = True
            ExportImportInspectionRight.Checked = True
            ExportImportEndorseRight.Checked = True
            ExportImportRecomendRight.Checked = True
            ArchiveAccessRight.Checked = True
            UploadQuizRight.Checked = True
            UploadCareerRight.Checked = True
            InstrumentFeeRight.Checked = True
            MeasurementRight.Checked = True
            Settings.Checked = True
            ExportDataReturn.Checked = True

            CompanyManagementRight.Text = "1"
            InstrumentManagementRight.Text = "1"
            StaticDataRights.Text = "1"
            LotsManagementRight.Text = "1"
            InvoiceReportRight.Text = "1"
            ReportsRight.Text = "1"
            ExportPermitManagement.Text = "1"
            ImportPermitManagement.Text = "1"
            DownloadManagerRight.Text = "1"
            UploadNewsRight.Text = "1"
            OtherDocumentsRight.Text = "1"
            UploadPictureRight.Text = "1"
            SetupOfficeRight.Text = "1"
            ExportImportExitRight.Text = "1"
            ExportImportLoadingRight.Text = "1"
            ExportImportEntryRight.Text = "1"
            ExportImportApprovalRight.Text = "1"
            ExportImportInspectionRight.Text = "1"
            ExportImportEndorseRight.Text = "1"
            ExportImportRecomendRight.Text = "1"
            ArchiveAccessRight.Text = "1"
            UploadQuizRight.Text = "1"
            UploadCareerRight.Text = "1"
            InstrumentFeeRight.Text = "1"
            MeasurementRight.Text = "1"
            Settings.Text = "1"
            ExportDataReturn.Text = "1"

        ElseIf AccountType.SelectedValue = "Minister" Then

            CompanyManagementRight.Checked = True
            InstrumentManagementRight.Checked = True
            StaticDataRights.Checked = True
            LotsManagementRight.Checked = True
            InvoiceReportRight.Checked = True
            ReportsRight.Checked = True
            ExportPermitManagement.Checked = True
            ImportPermitManagement.Checked = True
            DownloadManagerRight.Checked = True
            UploadNewsRight.Checked = True
            OtherDocumentsRight.Checked = True
            UploadPictureRight.Checked = True
            SetupOfficeRight.Checked = True
            ExportImportExitRight.Checked = True
            ExportImportLoadingRight.Checked = True
            ExportImportEntryRight.Checked = True
            ExportImportApprovalRight.Checked = True
            ExportImportInspectionRight.Checked = True
            ExportImportEndorseRight.Checked = True
            ExportImportRecomendRight.Checked = True
            ArchiveAccessRight.Checked = True
            UploadQuizRight.Checked = True
            UploadCareerRight.Checked = True
            InstrumentFeeRight.Checked = True
            MeasurementRight.Checked = True
            Settings.Checked = True
            ExportDataReturn.Checked = True

            CompanyManagementRight.Text = "1"
            InstrumentManagementRight.Text = "1"
            StaticDataRights.Text = "1"
            LotsManagementRight.Text = "1"
            InvoiceReportRight.Text = "1"
            ReportsRight.Text = "1"
            ExportPermitManagement.Text = "1"
            ImportPermitManagement.Text = "1"
            DownloadManagerRight.Text = "1"
            UploadNewsRight.Text = "1"
            OtherDocumentsRight.Text = "1"
            UploadPictureRight.Text = "1"
            SetupOfficeRight.Text = "1"
            ExportImportExitRight.Text = "1"
            ExportImportLoadingRight.Text = "1"
            ExportImportEntryRight.Text = "1"
            ExportImportApprovalRight.Text = "1"
            ExportImportInspectionRight.Text = "1"
            ExportImportEndorseRight.Text = "1"
            ExportImportRecomendRight.Text = "1"
            ArchiveAccessRight.Text = "1"
            UploadQuizRight.Text = "1"
            UploadCareerRight.Text = "1"
            InstrumentFeeRight.Text = "1"
            MeasurementRight.Text = "1"
            Settings.Text = "1"
            ExportDataReturn.Text = "1"

        ElseIf AccountType.SelectedValue = "Staff" Then

            CompanyManagementRight.Checked = False
            InstrumentManagementRight.Checked = False
            StaticDataRights.Checked = False
            LotsManagementRight.Checked = True
            InvoiceReportRight.Checked = False
            ReportsRight.Checked = False
            ExportPermitManagement.Checked = False
            ImportPermitManagement.Checked = False
            DownloadManagerRight.Checked = True
            UploadNewsRight.Checked = False
            OtherDocumentsRight.Checked = False
            UploadPictureRight.Checked = False
            SetupOfficeRight.Checked = True
            ExportImportExitRight.Checked = False
            ExportImportLoadingRight.Checked = False
            ExportImportEntryRight.Checked = False
            ExportImportApprovalRight.Checked = False
            ExportImportInspectionRight.Checked = False
            ExportImportEndorseRight.Checked = False
            ExportImportRecomendRight.Checked = False
            ArchiveAccessRight.Checked = False
            UploadQuizRight.Checked = True
            UploadCareerRight.Checked = False
            InstrumentFeeRight.Checked = False
            MeasurementRight.Checked = False
            Settings.Checked = False
            ExportDataReturn.Checked = False


            CompanyManagementRight.Text = "0"
            InstrumentManagementRight.Text = "0"
            StaticDataRights.Text = "0"
            LotsManagementRight.Text = "1"
            InvoiceReportRight.Text = "0"
            ReportsRight.Text = "0"
            ExportPermitManagement.Text = "0"
            ImportPermitManagement.Text = "0"
            DownloadManagerRight.Text = "1"
            UploadNewsRight.Text = "0"
            OtherDocumentsRight.Text = "0"
            UploadPictureRight.Text = "0"
            SetupOfficeRight.Text = "1"
            ExportImportExitRight.Text = "0"
            ExportImportLoadingRight.Text = "0"
            ExportImportEntryRight.Text = "0"
            ExportImportApprovalRight.Text = "0"
            ExportImportInspectionRight.Text = "0"
            ExportImportEndorseRight.Text = "0"
            ExportImportRecomendRight.Text = "0"
            ArchiveAccessRight.Text = "0"
            UploadQuizRight.Text = "1"
            UploadCareerRight.Text = "0"
            InstrumentFeeRight.Text = "0"
            MeasurementRight.Text = "0"
            Settings.Text = "0"
            ExportDataReturn.Text = "0"


        ElseIf AccountType.SelectedValue = "Other" Then

            CompanyManagementRight.Checked = False
            InstrumentManagementRight.Checked = False
            StaticDataRights.Checked = False
            LotsManagementRight.Checked = False
            InvoiceReportRight.Checked = False
            ReportsRight.Checked = False
            ExportPermitManagement.Checked = True
            ImportPermitManagement.Checked = False
            DownloadManagerRight.Checked = False
            UploadNewsRight.Checked = False
            OtherDocumentsRight.Checked = False
            UploadPictureRight.Checked = False
            SetupOfficeRight.Checked = False
            ExportImportExitRight.Checked = True
            ExportImportLoadingRight.Checked = True
            ExportImportEntryRight.Checked = True
            ExportImportApprovalRight.Checked = False
            ExportImportInspectionRight.Checked = False
            ExportImportEndorseRight.Checked = False
            ExportImportRecomendRight.Checked = False
            ArchiveAccessRight.Checked = False
            UploadQuizRight.Checked = False
            UploadCareerRight.Checked = False
            InstrumentFeeRight.Checked = False
            MeasurementRight.Checked = False
            Settings.Checked = False
            ExportDataReturn.Checked = False

            CompanyManagementRight.Text = "0"
            InstrumentManagementRight.Text = "0"
            StaticDataRights.Text = "0"
            LotsManagementRight.Text = "0"
            InvoiceReportRight.Text = "0"
            ReportsRight.Text = "0"
            ExportPermitManagement.Text = "1"
            ImportPermitManagement.Text = "0"
            DownloadManagerRight.Text = "0"
            UploadNewsRight.Text = "0"
            OtherDocumentsRight.Text = "0"
            UploadPictureRight.Text = "0"
            SetupOfficeRight.Text = "0"
            ExportImportExitRight.Text = "1"
            ExportImportLoadingRight.Text = "1"
            ExportImportEntryRight.Text = "1"
            ExportImportApprovalRight.Text = "0"
            ExportImportInspectionRight.Text = "0"
            ExportImportEndorseRight.Text = "0"
            ExportImportRecomendRight.Text = "0"
            ArchiveAccessRight.Text = "0"
            UploadQuizRight.Text = "0"
            UploadCareerRight.Text = "0"
            InstrumentFeeRight.Text = "0"
            MeasurementRight.Text = "0"
            Settings.Text = "0"
            ExportDataReturn.Text = "0"

        End If
     End Sub

    Protected Sub SaveUserInfo_Click(sender As Object, e As EventArgs) Handles SaveUserInfo.Click
        EnableOrDisable()
        Try

            Dim HashedPassword As String
            Dim EncodeMe As String = ModifyConfirmPassword.Text
            HashedPassword = getSHA512Hash(EncodeMe)
            ConnectDatabase()


            ViewState("ViewStateConfirmPassword") = ModifyCompanyName.Text

            Dim ToKnowPassword As String = ViewState("ViewStateConfirmPassword").ToString()

            If ModifyPassword.Text = "" And Not ModifyConfirmPassword.Text = "" Or Not ModifyPassword.Text = "" And ModifyConfirmPassword.Text = "" Then
                MessageBox.Show(Me, "Password do not match! Kindly reconfirm your password if you want to change it, if not leave the two box empty!")

            ElseIf ModifyPassword.Text = "" And ModifyConfirmPassword.Text = "" Then
                Dim strSQL As String
                strSQL = "UPDATE admin SET companyName='" & ModifyCompanyName.Text & "', surname='" & ModifySurname.Text & "', otherNames='" & ModifyOtherNames.Text & "', contactAddress='" & ModifyAddress.Text & "', securityQuestion='" & ModifySecurityQuestion.SelectedItem.Text & "', securityAnswer='" & ModifySecurityAnswer.Text & "', accountType='" & ModifyAccountType.SelectedItem.Text & "', companyMgtRight='" & Me.ModifyCompanyManagementRight.Text & "', instrumentMgtRight='" & Me.ModifyInstrumentManagementRight.Text & "', staticDataRight='" & Me.ModifyStaticDataRight.Text & "', manageLot='" & Me.ModifyLotsManagementRight.Text & "', invoiceReport='" & Me.ModifyInvoiceReportRight.Text & "', reportRight='" & Me.ModifyReportsRight.Text & "', exportPermitMgt='" & Me.ModifyExportPermitManagement.Text & "', importPermitMgt='" & Me.ModifyImportPermitManagement.Text & "', downloadCenter='" & Me.ModifyDownloadManagerRight.Text & "', uploadNews='" & Me.ModifyUploadNewsRight.Text & "', otherDocRight='" & Me.ModifyOtherDocumentsRight.Text & "', uploadGallery='" & Me.ModifyUploadPictureRight.Text & "', setupOffice='" & Me.ModifySetupOfficeRight.Text & "', exitExportImport='" & Me.ModifyExportImportExitRight.Text & "', loadingExportImport='" & Me.ModifyExportImportLoadingRight.Text & "', entryExportImport='" & Me.ModifyExportImportEntryRight.Text & "', approveExportImport='" & Me.ModifyExportImportApprovalRight.Text & "', inspectExportImport='" & Me.ModifyExportImportInspectionRight.Text & "', endorseExportImport='" & Me.ModifyExportImportEndorseRight.Text & "', recommendExportImport='" & Me.ModifyExportImportRecomendRight.Text & "', archiveRight='" & Me.ModifyArchiveAccessRight.Text & "', quizRight='" & Me.ModifyUploadQuizRight.Text & "', careerRight='" & Me.ModifyUploadCareerRight.Text & "', instrumentFee='" & Me.ModifyInstrumentFeeRight.Text & "', measurement='" & Me.ModifyMeasurementRight.Text & "', settings='" & Me.ModifySettings.Text & "', exportDataReturn='" & Me.ModifyExportDataReturn.Text & "' WHERE ID='" & SelectUser.SelectedValue & "'"
                Dim cmd As New MySqlCommand(strSQL, conn)
                cmd.ExecuteNonQuery()

            ElseIf ModifyPassword.Text = ModifyConfirmPassword.Text Then
                Dim strSQL As String
                strSQL = "UPDATE admin SET password='" & HashedPassword & "', companyName='" & ModifyCompanyName.Text & "', surname='" & ModifySurname.Text & "', otherNames='" & ModifyOtherNames.Text & "', contactAddress='" & ModifyAddress.Text & "', securityQuestion='" & ModifySecurityQuestion.SelectedItem.Text & "', securityAnswer='" & ModifySecurityAnswer.Text & "', accountType='" & ModifyAccountType.SelectedItem.Text & "', companyMgtRight='" & Me.ModifyCompanyManagementRight.Text & "', instrumentMgtRight='" & Me.ModifyInstrumentManagementRight.Text & "', staticDataRight='" & Me.ModifyStaticDataRight.Text & "', manageLot='" & Me.ModifyLotsManagementRight.Text & "', invoiceReport='" & Me.ModifyInvoiceReportRight.Text & "', reportRight='" & Me.ModifyReportsRight.Text & "', exportPermitMgt='" & Me.ModifyExportPermitManagement.Text & "', importPermitMgt='" & Me.ModifyImportPermitManagement.Text & "', downloadCenter='" & Me.ModifyDownloadManagerRight.Text & "', uploadNews='" & Me.ModifyUploadNewsRight.Text & "', otherDocRight='" & Me.ModifyOtherDocumentsRight.Text & "', uploadGallery='" & Me.ModifyUploadPictureRight.Text & "', setupOffice='" & Me.ModifySetupOfficeRight.Text & "', exitExportImport='" & Me.ModifyExportImportExitRight.Text & "', loadingExportImport='" & Me.ModifyExportImportLoadingRight.Text & "', entryExportImport='" & Me.ModifyExportImportEntryRight.Text & "', approveExportImport='" & Me.ModifyExportImportApprovalRight.Text & "', inspectExportImport='" & Me.ModifyExportImportInspectionRight.Text & "', endorseExportImport='" & Me.ModifyExportImportEndorseRight.Text & "', recommendExportImport='" & Me.ModifyExportImportRecomendRight.Text & "', archiveRight='" & Me.ModifyArchiveAccessRight.Text & "', quizRight='" & Me.ModifyUploadQuizRight.Text & "', careerRight='" & Me.ModifyUploadCareerRight.Text & "', instrumentFee='" & Me.ModifyInstrumentFeeRight.Text & "', measurement='" & Me.ModifyMeasurementRight.Text & "', settings='" & Me.ModifySettings.Text & "', exportDataReturn='" & Me.ModifyExportDataReturn.Text & "' WHERE ID='" & SelectUser.SelectedValue & "'"
                Dim cmd As New MySqlCommand(strSQL, conn)
                cmd.ExecuteNonQuery()

            End If



            Try
                Dim Activity As String = SelectUser.SelectedItem.Text & "account has been updated by " & Session("LoggedInAdminLoginUsername")
                Dim com As New MySqlCommand
                com.Connection = conn
                com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                com.ExecuteNonQuery()


            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            End Try

            MessageBox.Show(Me, "User Account Updated Successfully! " & SelectUser.SelectedValue & " " & ToKnowPassword)
        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)

        Finally
            DisconnectDatabase()

        End Try

        Response.AppendHeader("Refresh", "0;url=./#modify-user")
    End Sub

    Protected Sub DeleteUser_Click(sender As Object, e As EventArgs) Handles DeleteUser.Click


        If SelectUser.SelectedItem.Text = "Admin" Then

            MessageBox.Show(Me, "Admin Account can not be deleted, becareful")

        Else

            Try

                ConnectDatabase()

                Dim cmd As New MySqlCommand

                cmd.Connection = conn
                cmd.CommandText = "DELETE FROM admin WHERE ID='" & SelectUser.SelectedValue & "'"

                cmd.ExecuteNonQuery()

                Try
                    Dim Activity As String = SelectUser.SelectedItem.Text & "account has been deleted by " & Session("LoggedInAdminLoginUsername")
                    Dim com As New MySqlCommand
                    com.Connection = conn
                    com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                    com.ExecuteNonQuery()


                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                End Try


                MessageBox.Show(Me, "User Account has been deleted Successfully!")

            Catch ex As Exception

                MessageBox.Show(Me, ex.Message)

            Finally
                DisconnectDatabase()

            End Try

        End If
        'LogoutAdmin_Click(sender, New System.EventArgs())

        Response.AppendHeader("Refresh", "0;url=./#modify-user")
    End Sub


    Protected Sub CreateNewLot_Click(sender As Object, e As EventArgs) Handles CreateNewLot.Click

        Try
            ConnectDatabase()
            Dim cmd As New MySqlCommand

            cmd.Connection = conn
            cmd.CommandText = "INSERT INTO lots (lotName) VALUES ('" & NewLotName.Text & "')"

            cmd.ExecuteNonQuery()
            Try
                Dim Activity As String = "A new lot has been registered by " & Session("LoggedInAdminLoginUsername")
                Dim com As New MySqlCommand
                com.Connection = conn
                com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                com.ExecuteNonQuery()


            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            End Try

            MessageBox.Show(Me, "Lots has been added successfully!")


        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)
        Finally
            DisconnectDatabase()
        End Try
        Response.AppendHeader("Refresh", "0;url=./#lot-table")
    End Sub




    'This save lot back to the database after editing
    Protected Sub SaveEditedLot_Click(sender As Object, e As EventArgs) Handles SaveEditedLot.Click

        Try

            ConnectDatabase()

            Dim cmd As New MySqlCommand

            cmd.Connection = conn
            cmd.CommandText = "UPDATE lots SET lotName='" & EditLotName.Text & "' WHERE ID='" & SelectLotToEdit.SelectedValue & "'"

            cmd.ExecuteNonQuery()

            Try
                Dim Activity As String = SelectLotToEdit.SelectedItem.Text & " lot has been updated by " & Session("LoggedInAdminLoginUsername")
                Dim com As New MySqlCommand
                com.Connection = conn
                com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                com.ExecuteNonQuery()


            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            End Try

            MessageBox.Show(Me, "Lots has been updated successfully!")

        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)

            'Response.Redirect(HttpContext.Current.Request.Url.ToString(), True)
            Response.AppendHeader("Refresh", "0;url=./#lot-table")
        Finally
            DisconnectDatabase()
        End Try
    End Sub


    'Register new Allocation
    Protected Sub RegisterAllocation_Click(sender As Object, e As EventArgs) Handles RegisterAllocation.Click


        Try
            ConnectDatabase()
            Dim cmd As New MySqlCommand

            cmd.Connection = conn
            cmd.CommandText = "INSERT INTO terminals (LotID,TerminalName,TerminalOwner,RCNumber,Location,companyID,facilityDBFilename,ISPID) VALUES ('" & SelectLotName.SelectedValue & "','" & Terminal.Text & "','" & LotTerminalOwner.Text & "','" & LotTerminalRCNumber.Text & "','" & LotTerminalLocation.Text & "','" & LotTerminalFacilityDatabase.FileName & "', '" & LotTerminalActiveISP.Text & "')"

            cmd.ExecuteNonQuery()
            Try
                Dim Activity As String = Terminal.Text & " Terminal has been registered by " & Session("LoggedInAdminLoginUsername")
                Dim com As New MySqlCommand
                com.Connection = conn
                com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                com.ExecuteNonQuery()


            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            End Try

            MessageBox.Show(Me, "Termina Allocation has been registered successfully!")


        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)

        Finally
            DisconnectDatabase()
        End Try

        Response.AppendHeader("Refresh", "0;url=./#lots-allocation")
    End Sub



    Protected Sub SaveLotAllocation_Click(sender As Object, e As EventArgs) Handles SaveLotAllocation.Click

        Try

            ConnectDatabase()

            Dim cmd As New MySqlCommand

            cmd.Connection = conn
            cmd.CommandText = "UPDATE terminals SET LotID='" & SelectLotName.SelectedValue & "',TerminalName ='" & Terminal.Text & "',TerminalOwner ='" & LotTerminalOwner.Text & "',RCNumber ='" & LotTerminalRCNumber.Text & "',Location ='" & LotTerminalLocation.Text & "',facilityDBFilename ='" & LotTerminalFacilityDatabase.FileName & "',ISPID ='" & LotTerminalActiveISP.Text & "'"

            cmd.ExecuteNonQuery()

            Try
                Dim Activity As String = TerminalName.SelectedItem.Text & " Terminal has been updated by " & Session("LoggedInAdminLoginUsername")
                Dim com As New MySqlCommand
                com.Connection = conn
                com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                com.ExecuteNonQuery()


            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            End Try

            MessageBox.Show(Me, "Terminal has been saved to the table successfully!")

        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)

        Finally
            DisconnectDatabase()

        End Try

        Response.AppendHeader("Refresh", "0;url=./#lots-allocation")


    End Sub

    Dim DownloadCenterPath As String = HttpContext.Current.Request.PhysicalApplicationPath & "File Manager\DownloadCenter\"
    Dim DisplayorHide As String

    Protected Sub UploadDownloadFIle_Click(sender As Object, e As EventArgs) Handles UploadDownloadFile.Click

        If FileMemberType.Text = "" Or FileDownloadDescription.Text = "" Then
            MessageBox.Show(Me, "No field can be left Blank")

        Else

            If FileDownloadUpload.HasFile Then
                Dim fileExt As String
                fileExt = System.IO.Path.GetExtension(FileDownloadUpload.FileName)

                If (fileExt = ".pdf" Or fileExt = ".doc" Or fileExt = ".docx" Or fileExt = ".xlsx") Then
                    Try
                        FileDownloadUpload.SaveAs(DownloadCenterPath & FileDownloadUpload.FileName)

                        'Insert details into the database if file to upload meets our requirements
                        Try
                            If DisplayDownloadFile.Checked = True Then

                                DisplayorHide = "1"
                            Else
                                DisplayorHide = "0"
                            End If

                            ConnectDatabase()

                            Dim cmd As New MySqlCommand

                            cmd.Connection = conn
                            cmd.CommandText = "INSERT INTO downloadcenter (downloadType,fileName,recordStatus,description) VALUES('" & FileMemberType.Text & "','" & FileDownloadUpload.FileName & "','" & DisplayorHide & "', '" & FileDownloadDescription.Text & "')"

                            cmd.ExecuteNonQuery()
                            MessageBox.Show(Me, "File has been uploaded successfully to download center!")

                            Try
                                Dim Activity As String = FileDownloadUpload.FileName & " has been Uploaded by " & Session("LoggedInAdminLoginUsername")
                                Dim com As New MySqlCommand
                                com.Connection = conn
                                com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                                com.ExecuteNonQuery()


                            Catch ex As Exception
                                MessageBox.Show(Me, ex.Message)
                            End Try

                        Catch ex As Exception

                            MessageBox.Show(Me, ex.Message)

                        End Try

                    Catch ex As Exception
                        MessageBox.Show(Me, "ERROR: " & ex.Message.ToString())

                    Finally
                        DisconnectDatabase()
                    End Try

                Else
                    MessageBox.Show(Me, "ERROR: File type not allowed! Contact Administrator for correct File Type")
                    Try
                        Dim Activity As String = Session("LoggedInAdminLoginUsername") & " tried to upload an unacceptable file (" & FileDownloadUpload.FileName & ")!"
                        Dim com As New MySqlCommand
                        com.Connection = conn
                        com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                        com.ExecuteNonQuery()


                    Catch ex As Exception
                        MessageBox.Show(Me, ex.Message)
                    End Try

                End If
            Else
                MessageBox.Show(Me, "You have not select any file, please select file to upload.")
            End If


        End If
        Response.AppendHeader("Refresh", "0;url=./#download-center")

    End Sub

    Protected Sub SaveDownloadFIle_Click(sender As Object, e As EventArgs) Handles SaveDownloadFile.Click


        If FileDownloadUpload.HasFile Then
            Dim fileExt As String
            fileExt = System.IO.Path.GetExtension(FileDownloadUpload.FileName)

            If (fileExt = ".pdf" Or fileExt = ".doc" Or fileExt = ".docx" Or fileExt = ".xlsx") Then
                Try
                    FileDownloadUpload.SaveAs(DownloadCenterPath & FileDownloadUpload.FileName)

                    'Insert details into the database if file to upload meets our requirements
                    Try
                        If DisplayDownloadFile.Checked = True Then

                            DisplayorHide = "1"
                        Else
                            DisplayorHide = "0"
                        End If

                        ConnectDatabase()

                        Dim cmd As New MySqlCommand

                        cmd.Connection = conn
                        cmd.CommandText = "UPDATE downloadcenter SET downloadType='" & FileMemberType.Text & "',fileName='" & FileDownloadUpload.FileName & "',recordStatus='" & DisplayorHide & "',description='" & FileDownloadDescription.Text & "' WHERE fileName='" & SelectFileDownload.SelectedItem.Text & "'"

                        cmd.ExecuteNonQuery()
                        Try
                            Dim Activity As String = Session("LoggedInAdminLoginUsername") & " update download center file (" & FileDownloadUpload.FileName & ")"
                            Dim com As New MySqlCommand
                            com.Connection = conn
                            com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                            com.ExecuteNonQuery()


                        Catch ex As Exception
                            MessageBox.Show(Me, ex.Message)
                        End Try

                        MessageBox.Show(Me, "Your change has been saved successfully!")


                    Catch ex As Exception

                        MessageBox.Show(Me, ex.Message)
                    Finally
                        DisconnectDatabase()
                    End Try

                Catch ex As Exception
                    FileDownloadName.Text = "ERROR: " & ex.Message.ToString()
                End Try


            Else
                MessageBox.Show(Me, "ERROR: File type not allowed! Contact Administrator for correct File Type")
                Try
                    Dim Activity As String = Session("LoggedInAdminLoginUsername") & "tried to update an existing file to an unacceptable file!" & FileDownloadUpload.FileName & " "
                    Dim com As New MySqlCommand
                    com.Connection = conn
                    com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                    com.ExecuteNonQuery()


                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                End Try


            End If

        Else

            Try
                If DisplayDownloadFile.Checked = True Then

                    DisplayorHide = "1"
                Else
                    DisplayorHide = "0"
                End If

                ConnectDatabase()

                Dim cmd As New MySqlCommand

                cmd.Connection = conn
                cmd.CommandText = "UPDATE downloadcenter SET downloadType='" & FileMemberType.Text & "',fileName='" & FileDownloadName.Text & "',recordStatus='" & DisplayorHide & "',description='" & FileDownloadDescription.Text & "' WHERE fileName='" & SelectFileDownload.SelectedItem.Text & "'"

                cmd.ExecuteNonQuery()
                Try
                    Dim Activity As String = Session("LoggedInAdminLoginUsername") & " updated " & SelectFileDownload.SelectedItem.Text & "to" & FileDownloadName.Text
                    Dim com As New MySqlCommand
                    com.Connection = conn
                    com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                    com.ExecuteNonQuery()


                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                End Try

                MessageBox.Show(Me, "File has been saved successfully!")

            Catch ex As Exception

                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()

            End Try
        End If
        Response.AppendHeader("Refresh", "0;url=./#download-center")
    End Sub

    'News or article upload area
    Dim ArticleImagePath As String = HttpContext.Current.Request.PhysicalApplicationPath & "images\article\"

    Protected Sub UploadHomepageArticle_Click(sender As Object, e As EventArgs) Handles UploadHomepageArticle.Click

        If ArticleHeader.Text = "" Or ArticleBody.Text = "" Or ArticleGroup.SelectedItem.Text = "" Then
            MessageBox.Show(Me, "No field can be left Blank")
        Else

            If UploadArticlePicture.HasFile Then
                Dim fileExt As String
                fileExt = System.IO.Path.GetExtension(UploadArticlePicture.FileName)

                If (fileExt = ".gif" Or fileExt = ".jpg" Or fileExt = ".jpeg" Or fileExt = ".png") Then
                    Try
                        UploadArticlePicture.SaveAs(ArticleImagePath & UploadArticlePicture.FileName)

                        'Insert details into the database if file to upload meets our requirements
                        Dim ArticleStatuss As String
                        If ArticleStatus.Checked = True Then
                            ArticleStatuss = "1"
                        Else
                            ArticleStatuss = "0"
                        End If
                        ConnectDatabase()
                        Dim cmd As New MySqlCommand

                        cmd.Connection = conn
                        cmd.CommandText = "INSERT INTO article (articleTitle,article,status,uploadDate,uploadTime,imageLink,articleGroup) VALUES('" & ArticleHeader.Text & "','" & ArticleBody.Text & "','" & ArticleStatuss & "','" & TodaysDate() & "','" & CurrentTim() & "','" & UploadArticlePicture.FileName & "','" & ArticleGroup.SelectedItem.Text & "')"
                        cmd.ExecuteNonQuery()

                        MessageBox.Show(Me, "Article has been uploaded successfully!")

                        Dim Activity As String = Session("LoggedInAdminLoginUsername") & " upload an article to homepage (" & ArticleHeader.Text & ")!"
                        Dim com As New MySqlCommand
                        com.Connection = conn
                        com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                        com.ExecuteNonQuery()

                        Response.AppendHeader("Refresh", "0;url=./#upload-news")
                    Catch ex As Exception
                        MessageBox.Show(Me, "ERROR: " & ex.Message.ToString())

                    Finally
                        DisconnectDatabase()
                        Response.AppendHeader("Refresh", "0;url=./#upload-news")
                    End Try
                Else
                    MessageBox.Show(Me, "ERROR: File type not allowed! Contact Administrator for correct File Type")
                End If
            Else
                MessageBox.Show(Me, "You have not select any file, please select file to upload.")
            End If

        End If

    End Sub

    'Save article after editing it
    Protected Sub SaveHomepageArticle_Click(sender As Object, e As EventArgs) Handles SaveHomepageArticle.Click

        If ArticleHeader.Text = "" Or ArticleBody.Text = "" Or ArticleGroup.Text = "" Then
            MessageBox.Show(Me, "No field can be left Blank")

        Else

            If UploadArticlePicture.HasFile Then
                Dim fileExt As String
                fileExt = System.IO.Path.GetExtension(UploadArticlePicture.FileName)

                If (fileExt = ".gif" Or fileExt = ".jpg" Or fileExt = ".jpeg" Or fileExt = ".png") Then
                    Try
                        UploadArticlePicture.SaveAs(ArticleImagePath & UploadArticlePicture.FileName)

                        'Insert details into the database if file to upload meets our requirements
                        Dim ArticleStatuss As String

                        If ArticleStatus.Checked = True Then
                            ArticleStatuss = "1"
                        Else
                            ArticleStatuss = "0"
                        End If

                        ConnectDatabase()

                        Dim cmd As New MySqlCommand

                        cmd.Connection = conn
                        cmd.CommandText = "UPDATE article SET articleTitle='" & ArticleHeader.Text & "',article ='" & ArticleBody.Text & "',status ='" & ArticleStatuss & "',uploadDate ='" & Today.Date.ToString & "',uploadTime='" & TimeOfDay.ToString & "',imageLink='" & UploadArticlePicture.FileName & "',articleGroup ='" & ArticleGroup.SelectedItem.Text & "' WHERE articleTitle='" & SelectNewHeader.SelectedItem.Text & "'"

                        cmd.ExecuteNonQuery()

                        Dim Activity As String = Session("LoggedInAdminLoginUsername") & " updated " & SelectNewHeader.SelectedItem.Text & "to " & ArticleHeader.Text
                        Dim com As New MySqlCommand
                        com.Connection = conn
                        com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                        com.ExecuteNonQuery()


                        MessageBox.Show(Me, "Changes made to article has been saved successfully!")


                    Catch ex As Exception
                        MessageBox.Show(Me, "ERROR: " & ex.Message.ToString())

                    Finally
                        DisconnectDatabase()
                        Response.AppendHeader("Refresh", "0;url=./#upload-news")
                    End Try

                Else
                    MessageBox.Show(Me, "ERROR: File type not allowed! Contact Administrator for correct File Type")
                End If

            Else

                Try
                    Dim ArticleStatuss As String

                    If ArticleStatus.Checked = True Then
                        ArticleStatuss = "1"
                    Else
                        ArticleStatuss = "0"
                    End If

                    ConnectDatabase()

                    Dim cmd As New MySqlCommand

                    cmd.Connection = conn
                    cmd.CommandText = "UPDATE article SET articleTitle='" & ArticleHeader.Text & "',article ='" & ArticleBody.Text & "',status ='" & ArticleStatuss & "',uploadDate ='" & Today.Date.ToString & "',uploadTime='" & TimeOfDay.ToString & "',imageLink='" & ArticlePictureLink.Text & "',articleGroup ='" & ArticleGroup.SelectedItem.Text & "' WHERE articleTitle='" & SelectNewHeader.SelectedItem.Text & "'"

                    cmd.ExecuteNonQuery()
                    MessageBox.Show(Me, "Article has been Updated successfully!")

                    Try
                        Dim Activity As String = Session("LoggedInAdminLoginUsername") & " updated " & SelectNewHeader.SelectedItem.Text & "to " & ArticleHeader.Text
                        Dim com As New MySqlCommand
                        com.Connection = conn
                        com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                        com.ExecuteNonQuery()

                        Response.AppendHeader("Refresh", "0;url=./#upload-news")

                    Catch ex As Exception
                        MessageBox.Show(Me, ex.Message)
                    End Try

                Catch ex As Exception

                    MessageBox.Show(Me, ex.Message)

                Finally
                    DisconnectDatabase()

                End Try

            End If


        End If
        Response.AppendHeader("Refresh", "0;url=./#upload-news")

    End Sub


    'Article delete button
    Protected Sub DeleteHomepageArticle_Click(sender As Object, e As EventArgs) Handles DeleteHomepageArticle.Click

        Try

            ConnectDatabase()

            Dim cmd As New MySqlCommand

            cmd.Connection = conn
            cmd.CommandText = "DELETE FROM article WHERE ID='" & SelectNewHeader.SelectedValue & "'"

            cmd.ExecuteNonQuery()
            Try
                Dim Activity As String = Session("LoggedInAdminLoginUsername") & " delete " & "to " & ArticleHeader.Text & " article form homepage"
                Dim com As New MySqlCommand
                com.Connection = conn
                com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                com.ExecuteNonQuery()


            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            End Try

            MessageBox.Show(Me, "Article has has been deleted Successfully, it will no more display on the home or news page!")

        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)

        Finally
            DisconnectDatabase()

        End Try
        Response.AppendHeader("Refresh", "0;url=./#upload-news")
    End Sub


    'Picture gallery upload area
    Dim PictureGalleryPath As String = HttpContext.Current.Request.PhysicalApplicationPath & "images\gallery\"


    Protected Sub CreateGalleryGroup_Click(sender As Object, e As EventArgs) Handles CreateGalleryGroup.Click

        Try
            ConnectDatabase()

            Dim MyAdapter As New MySqlDataAdapter

            Dim SqlQuery = "SELECT * FROM gallerygroups WHERE groups= '" & GalleryGroup.Text & "';"
            Dim Command As New MySqlCommand
            Command.Connection = conn
            Command.CommandText = SqlQuery
            MyAdapter.SelectCommand = Command
            Dim reader As MySqlDataReader
            reader = Command.ExecuteReader
            'Check if the credentials provided is in the database
            If reader.HasRows >= 1 Then
                reader.Close()
                MessageBox.Show(Me, "No group yet!")

                'Log user activity
                Dim Activity As String = Session("LoggedInAdminLoginUsername") & " attempt to create a photo album named:  " & RecoverySearchNumber.Text
                Dim com As New MySqlCommand
                com.Connection = conn
                com.CommandText = "INSERT INTO userlog (activity,IPAddress,machineName,deviceType,browserName,logdate,logtime) VALUES ('" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "')"
                com.ExecuteNonQuery()

            Else
                reader.Close()

                Dim GalleryGroups = GalleryGroup.Text.Replace(" ", "-")

                Dim cmd As New MySqlCommand
                cmd.Connection = conn
                cmd.CommandText = "INSERT INTO gallerygroups (groups) VALUES('" & GalleryGroups & "')"
                cmd.ExecuteNonQuery()

                Dim Activity As String = Session("LoggedInAdminLoginUsername") & " create photo album: " & GalleryGroups & ""
                Dim com As New MySqlCommand
                com.Connection = conn
                com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                com.ExecuteNonQuery()
                MessageBox.Show(Me, "Photo Album has been created successfully!")

            End If

        Catch ex As Exception
            MessageBox.Show(Me, "ERROR: " & ex.Message.ToString())
        Finally
            DisconnectDatabase()
        End Try

        Response.AppendHeader("Refresh", "0;url=./#upload-picture")

    End Sub



    Protected Sub GalleryUpload_Click(sender As Object, e As EventArgs) Handles GalleryUpload.Click

        If PictureGalleryGroup.Text = "" Then
            MessageBox.Show(Me, "No field can be left Blank")

        Else

            If UploadPictureGallery.HasFile Then
                Dim fileExt As String
                fileExt = System.IO.Path.GetExtension(UploadPictureGallery.FileName)

                If (fileExt = ".gif" Or fileExt = ".jpg" Or fileExt = ".jpeg" Or fileExt = ".png") Then

                    Try
                        UploadPictureGallery.SaveAs(PictureGalleryPath & UploadPictureGallery.FileName)

                        Dim thumbimage As Bitmap
                        Dim originalimage As Bitmap

                        Dim width As Integer = 250 '# this is the max width of the new image
                        Dim height As Integer = 250 '# this is the max height of the new image
                        Dim newwidth As Integer
                        Dim newheight As Integer

                        originalimage = System.Drawing.Image.FromFile(PictureGalleryPath & UploadPictureGallery.FileName)

                        If originalimage.Width > originalimage.Height Then
                            newheight = originalimage.Height / originalimage.Width * height
                            newwidth = width
                        Else
                            newheight = height
                            newwidth = originalimage.Width / originalimage.Height * width
                        End If

                        thumbimage = New Bitmap(newwidth, newheight)

                        Dim gr As Graphics = Graphics.FromImage(thumbimage)
                        gr.DrawImage(originalimage, 0, 0, newwidth, newheight)


                        thumbimage.Save(PictureGalleryPath & "thumbnails\" & UploadPictureGallery.FileName, System.Drawing.Imaging.ImageFormat.Png)


                        'ResizeBitmap(PictureGalleryPath & "thumbnails\" & UploadPictureGallery.FileName, 500, 500)

                        'Insert details into the database if file to upload meets our requirements

                        Dim PcitureDisplayStatus As String

                        If DisplayPictureGallery.Checked = True Then
                            PcitureDisplayStatus = "1"
                        Else
                            PcitureDisplayStatus = "0"
                        End If

                        ConnectDatabase()

                        Dim cmd As New MySqlCommand

                        cmd.Connection = conn
                        cmd.CommandText = "INSERT INTO gallery (photoName,groups,caption,status) VALUES('" & UploadPictureGallery.FileName & "','" & PictureGalleryGroup.SelectedItem.Text & "','" & PictureGalleryCaption.Text & "','" & PcitureDisplayStatus & "')"

                        cmd.ExecuteNonQuery()


                        Dim Activity As String = Session("LoggedInAdminLoginUsername") & " upload " & UploadPictureGallery.FileName & "to " & PictureGalleryGroup.SelectedItem.Text
                        Dim com As New MySqlCommand
                        com.Connection = conn
                        com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                        com.ExecuteNonQuery()


                        MessageBox.Show(Me, "Picture has been uploaded successfully!")



                    Catch ex As Exception
                        MessageBox.Show(Me, "ERROR: " & ex.Message.ToString())
                    Finally
                        DisconnectDatabase()
                    End Try

                Else
                    MessageBox.Show(Me, "ERROR: Only image file is allowed!")
                End If
            Else
                MessageBox.Show(Me, "Select image to upload please!")
            End If


        End If
        Response.AppendHeader("Refresh", "0;url=./#upload-picture")

    End Sub


    'Save article after editing it
    Protected Sub SaveGallery_Click(sender As Object, e As EventArgs) Handles SaveGallery.Click


        If UploadPictureGallery.HasFile Then
            Dim fileExt As String
            fileExt = System.IO.Path.GetExtension(UploadPictureGallery.FileName)

            If (fileExt = ".gif" Or fileExt = ".jpg" Or fileExt = ".jpeg" Or fileExt = ".png") Then
                Try
                    UploadPictureGallery.SaveAs(PictureGalleryPath & UploadPictureGallery.FileName)

                    Dim thumbimage As Bitmap
                    Dim originalimage As Bitmap

                    Dim width As Integer = 250 '# this is the max width of the new image
                    Dim height As Integer = 250 '# this is the max height of the new image
                    Dim newwidth As Integer
                    Dim newheight As Integer

                    originalimage = System.Drawing.Image.FromFile(PictureGalleryPath & UploadPictureGallery.FileName)

                    If originalimage.Width > originalimage.Height Then
                        newheight = originalimage.Height / originalimage.Width * height
                        newwidth = width
                    Else
                        newheight = height
                        newwidth = originalimage.Width / originalimage.Height * width
                    End If

                    thumbimage = New Bitmap(newwidth, newheight)

                    Dim gr As Graphics = Graphics.FromImage(thumbimage)
                    gr.DrawImage(originalimage, 0, 0, newwidth, newheight)


                    thumbimage.Save(PictureGalleryPath & "thumbnails\" & UploadPictureGallery.FileName, System.Drawing.Imaging.ImageFormat.Png)


                    'Insert details into the database if file to upload meets our requirements
                    Dim PcitureDisplayStatus As String
                    If DisplayPictureGallery.Checked = True Then
                        PcitureDisplayStatus = "1"
                    Else
                        PcitureDisplayStatus = "0"
                    End If

                    ConnectDatabase()

                    Dim cmd As New MySqlCommand

                    cmd.Connection = conn
                    cmd.CommandText = "UPDATE gallery SET photoName='" & UploadPictureGallery.FileName & "',groups='" & PictureGalleryGroup.SelectedItem.Text & "',caption='" & PictureGalleryCaption.Text & "',status='" & PcitureDisplayStatus & "' WHERE caption='" & SelectPictureGallery.SelectedItem.Text & "'"
                    cmd.ExecuteNonQuery()

                    Dim Activity As String = Session("LoggedInAdminLoginUsername") & " update " & UploadPictureGallery.FileName
                    Dim com As New MySqlCommand
                    com.Connection = conn
                    com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                    com.ExecuteNonQuery()

                    Dim DeletePictureFromGallery = PictureGalleryPath & PictureGalleryLink.Text

                    If System.IO.File.Exists(DeletePictureFromGallery) = True Then
                        'Delete selected picture from the folder
                        System.IO.File.Delete(DeletePictureFromGallery)
                        MessageBox.Show(Me, "Picture has been replace with the new one successfully!")
                    End If


                Catch ex As Exception
                    MessageBox.Show(Me, "ERROR: " & ex.Message.ToString())
                Finally
                    DisconnectDatabase()

                End Try

            Else
                MessageBox.Show(Me, "ERROR: File type not allowed! Contact Administrator for correct File Type")
            End If
        Else

            Try
                Dim PcitureDisplayStatus As String

                If DisplayPictureGallery.Checked = True Then
                    PcitureDisplayStatus = "1"
                Else
                    PcitureDisplayStatus = "0"
                End If

                ConnectDatabase()

                Dim cmd As New MySqlCommand

                cmd.Connection = conn
                cmd.CommandText = "UPDATE gallery SET photoName='" & PictureGalleryLink.Text & "',groups='" & PictureGalleryGroup.SelectedItem.Text & "',caption='" & PictureGalleryCaption.Text & "',status='" & PcitureDisplayStatus & "' WHERE caption='" & SelectPictureGallery.SelectedItem.Text & "'"

                cmd.ExecuteNonQuery()

                Dim Activity As String = Session("LoggedInAdminLoginUsername") & " update " & SelectPictureGallery.SelectedItem.Text
                Dim com As New MySqlCommand
                com.Connection = conn
                com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                com.ExecuteNonQuery()


                MessageBox.Show(Me, "Picture has been Updated successfully!")


            Catch ex As Exception

                MessageBox.Show(Me, ex.Message)

            Finally
                DisconnectDatabase()
            End Try
        End If

        Response.AppendHeader("Refresh", "0;url=./#upload-picture")
    End Sub


    'Photo Gallery Picture delete button
    Protected Sub DeleteGallery_Click(sender As Object, e As EventArgs) Handles DeleteGallery.Click

        Try

            ConnectDatabase()

            Dim cmd As New MySqlCommand

            cmd.Connection = conn
            cmd.CommandText = "DELETE FROM gallery WHERE ID='" & SelectPictureGallery.SelectedValue & "'"

            cmd.ExecuteNonQuery()

            Dim Activity As String = Session("LoggedInAdminLoginUsername") & " delete " & SelectPictureGallery.SelectedItem.Text
            Dim com As New MySqlCommand
            com.Connection = conn
            com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
            com.ExecuteNonQuery()

            Dim DeletePictureFromGallery = PictureGalleryPath & PictureGalleryLink.Text
            If System.IO.File.Exists(DeletePictureFromGallery) = True Then
                'Delete selected picture from the folder

                System.IO.File.Delete(DeletePictureFromGallery)

                MessageBox.Show(Me, "The selected picture has successfully been deleted from Photo Gallery!")
            Else
                MessageBox.Show(Me, "The selected picture not found in Photo Gallery!")

            End If

        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)

        Finally
            DisconnectDatabase()

        End Try
        Response.AppendHeader("Refresh", "0;url=./#upload-picture")
    End Sub


    'Register State Address
    Protected Sub AddStateAddress_Click(sender As Object, e As EventArgs) Handles AddStateAddress.Click

        Try
            ConnectDatabase()
            Dim cmd As New MySqlCommand
            Dim DisplayAddres As String

            If DisplayAddress.Checked = True Then
                DisplayAddres = "1"
            Else
                DisplayAddres = "0"
            End If

            cmd.Connection = conn
            cmd.CommandText = "INSERT INTO statecontacts (state,Address,contactPersonName,contactPersonMobile,status,emailAddress) VALUES ('" & SelectOfficeState.SelectedItem.Text & "','" & OfficeAddress.Text & "','" & StateContactPersonName.Text & "','" & StateContactPersonMobile.Text & "','" & DisplayAddres & "','" & OfficeEmailAddress.Text & "')"

            cmd.ExecuteNonQuery()
            Try
                Dim Activity As String = Session("LoggedInAdminLoginUsername") & " add " & OfficeAddress.Text & " to State Office"
                Dim com As New MySqlCommand
                com.Connection = conn
                com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                com.ExecuteNonQuery()


            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            End Try
            MessageBox.Show(Me, "State Contact Address has been added successfully!")

        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)
        Finally
            DisconnectDatabase()

        End Try
        Response.AppendHeader("Refresh", "0;url=./#setup-office")
    End Sub



    Protected Sub SaveStateAddress_Click(sender As Object, e As EventArgs) Handles SaveStateAddress.Click

        Try
            ConnectDatabase()
            Dim DisplayAddres As String

            If DisplayAddress.Checked = True Then
                DisplayAddres = "1"
            Else
                DisplayAddres = "0"
            End If


            Dim cmd As New MySqlCommand

            cmd.Connection = conn
            cmd.CommandText = "UPDATE statecontacts SET state='" & SelectOfficeState.SelectedItem.Text & "',Address='" & OfficeAddress.Text & "',contactPersonName='" & StateContactPersonName.Text & "',contactPersonMobile='" & StateContactPersonMobile.Text & "',status='" & DisplayAddres & "' WHERE state='" & SelectStateOffice.SelectedItem.Text & "' "
            cmd.ExecuteNonQuery()

            Try
                Dim Activity As String = Session("LoggedInAdminLoginUsername") & " update " & SelectOfficeState.SelectedItem.Text & " state office to " & OfficeAddress.Text
                Dim com As New MySqlCommand
                com.Connection = conn
                com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                com.ExecuteNonQuery()


            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            End Try
            MessageBox.Show(Me, "State Contact Address has been updated successfully!")


        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)
        Finally
            DisconnectDatabase()
        End Try
        Response.AppendHeader("Refresh", "0;url=./#setup-office")
    End Sub


    'Contact Address Delete Button
    Protected Sub DeleteStateAddress_Click(sender As Object, e As EventArgs) Handles DeleteStateAddress.Click

        Try

            ConnectDatabase()

            Dim cmd As New MySqlCommand

            cmd.Connection = conn
            cmd.CommandText = "DELETE FROM stateaddress WHERE ID='" & SelectStateOffice.SelectedValue & "'"

            cmd.ExecuteNonQuery()
            Try
                Dim Activity As String = Session("LoggedInAdminLoginUsername") & " delete " & SelectStateOffice.SelectedItem.Text
                Dim com As New MySqlCommand
                com.Connection = conn
                com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                com.ExecuteNonQuery()


            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            End Try
        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)
        End Try
        Response.AppendHeader("Refresh", "0;url=./#setup-office")
    End Sub


    'Delete all rows in State
    Protected Sub DeleteStates_Click(sender As Object, e As EventArgs) Handles DeleteStates.Click

        Try

            ConnectDatabase()

            Dim cmd As New MySqlCommand

            cmd.Connection = conn
            cmd.CommandText = "TRUNCATE state"
            cmd.ExecuteNonQuery()
            Try
                Dim Activity As String = Session("LoggedInAdminLoginUsername") & " delete all states from database"
                Dim com As New MySqlCommand
                com.Connection = conn
                com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                com.ExecuteNonQuery()


            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            End Try
            MessageBox.Show(Me, "All states deleted successfully, please re-upload!")

        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)

        Finally
            DisconnectDatabase()

        End Try
        Response.AppendHeader("Refresh", "0;url=./#setup-office")
    End Sub



    'Delete all rows in LGA
    Protected Sub DeleteLGA_Click(sender As Object, e As EventArgs) Handles DeleteLGA.Click

        Try

            ConnectDatabase()

            Dim cmd As New MySqlCommand

            cmd.Connection = conn
            cmd.CommandText = "TRUNCATE lga"

            cmd.ExecuteNonQuery()

            MessageBox.Show(Me, "Local Government Area Deleted successfully, please re-upload!")

            Try
                Dim Activity As String = Session("LoggedInAdminLoginUsername") & " delete all Local Government"
                Dim com As New MySqlCommand
                com.Connection = conn
                com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                com.ExecuteNonQuery()


            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            End Try
        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)

        Finally
            DisconnectDatabase()

        End Try
        Response.AppendHeader("Refresh", "0;url=./#setup-office")
    End Sub



    'Delete all rows in LGA
    Protected Sub DeleteCities_Click(sender As Object, e As EventArgs) Handles DeleteCities.Click

        Try

            ConnectDatabase()

            Dim cmd As New MySqlCommand

            cmd.Connection = conn
            cmd.CommandText = "TRUNCATE city"

            cmd.ExecuteNonQuery()
            Try
                Dim Activity As String = Session("LoggedInAdminLoginUsername") & " delete all cities"
                Dim com As New MySqlCommand
                com.Connection = conn
                com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                com.ExecuteNonQuery()


            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            End Try
            MessageBox.Show(Me, "All cities deleted successfully, please upload cities")

        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)

        Finally
            DisconnectDatabase()

        End Try
        Response.AppendHeader("Refresh", "0;url=./#setup-office")
    End Sub

    'Save Fee Group  button
    Protected Sub AddFeeGroup_Click(sender As Object, e As EventArgs) Handles AddFeeGroup.Click
        Try
            Dim FeeGroupIsServices As String

            If FeeGroupIsService.Checked = True Then
                FeeGroupIsServices = "1"
            Else
                FeeGroupIsServices = "0"
            End If

            ConnectDatabase()

            Dim cmd As New MySqlCommand

            cmd.Connection = conn
            cmd.CommandText = "INSERT INTO feegroup (feeGroup,isService) VALUES ('" & FeeGroup.Text & "', '" & FeeGroupIsServices & "')"

            cmd.ExecuteNonQuery()
            Try
                Dim Activity As String = Session("LoggedInAdminLoginUsername") & " add " & FeeGroup.Text & " to fee group"
                Dim com As New MySqlCommand
                com.Connection = conn
                com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                com.ExecuteNonQuery()


            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            End Try
            MessageBox.Show(Me, "Fee Group Added Successfully?")
        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)

        Finally
            DisconnectDatabase()

        End Try
        Response.AppendHeader("Refresh", "0;url=./#fee-group-sub")
    End Sub


    'Save Fee Group  button
    Protected Sub SaveFeeGroup_Click(sender As Object, e As EventArgs) Handles SaveFeeGroup.Click

        Try
            Dim FeeGroupIsServices As String

            If FeeGroupIsService.Checked = True Then
                FeeGroupIsServices = "1"
            Else
                FeeGroupIsServices = "0"
            End If

            ConnectDatabase()

            Dim cmd As New MySqlCommand

            cmd.Connection = conn
            cmd.CommandText = "UPDATE feegroup SET feeGroup='" & FeeGroup.Text & "', isService='" & FeeGroupIsServices & "'"

            cmd.ExecuteNonQuery()
            Try
                Dim Activity As String = Session("LoggedInAdminLoginUsername") & " update " & FeeGroup.Text & " fee group !"
                Dim com As New MySqlCommand
                com.Connection = conn
                com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                com.ExecuteNonQuery()


            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            End Try
            MessageBox.Show(Me, "Fee Group Updated Successfully?")
        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)

        Finally
            DisconnectDatabase()

        End Try
        Response.AppendHeader("Refresh", "0;url=./#fee-group-sub")
    End Sub



    'Delete Fee Group
    Protected Sub DeleteFeeGroup_Click(sender As Object, e As EventArgs) Handles DeleteFeeGroup.Click

        Try

            ConnectDatabase()

            Dim cmd As New MySqlCommand

            cmd.Connection = conn
            cmd.CommandText = "DELETE FROM feegroup WHERE feeGroup='" & ModifyFeeGroup.SelectedItem.Text & "'"

            cmd.ExecuteNonQuery()
            Try
                Dim Activity As String = Session("LoggedInAdminLoginUsername") & " delete " & ModifyFeeGroup.SelectedItem.Text & " from fee group"
                Dim com As New MySqlCommand
                com.Connection = conn
                com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                com.ExecuteNonQuery()


            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            End Try
            MessageBox.Show(Me, "Fee Group Deleted Successfully!")
        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)

        Finally
            DisconnectDatabase()

        End Try
        Response.AppendHeader("Refresh", "0;url=./#fee-group-sub")
    End Sub


    'Add Fee Sub button
    Protected Sub AddFeeSub_Click(sender As Object, e As EventArgs) Handles AddFeeSub.Click
        Try

            ConnectDatabase()

            Dim cmd As New MySqlCommand

            cmd.Connection = conn
            cmd.CommandText = "INSERT INTO feesubgroup (feeGroup,groupSub) VALUES ('" & SelectFeeGroup.SelectedItem.Text & "', '" & FeeSub.Text & "')"

            cmd.ExecuteNonQuery()

            Try
                Dim Activity As String = Session("LoggedInAdminLoginUsername") & " add " & FeeSub.Text & " to fee sub"
                Dim com As New MySqlCommand
                com.Connection = conn
                com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                com.ExecuteNonQuery()


            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            End Try
            MessageBox.Show(Me, "Fee Group Sub uploaded Successfully?")
        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)

        Finally
            DisconnectDatabase()

        End Try
        Response.AppendHeader("Refresh", "0;url=./#fee-group-sub")
    End Sub



    'Save Fee Sub button
    Protected Sub SaveFeeSub_Click(sender As Object, e As EventArgs) Handles SaveFeeSub.Click

        Try
            Dim FeeGroupIsServices As String

            If FeeGroupIsService.Checked = True Then
                FeeGroupIsServices = "1"
            Else
                FeeGroupIsServices = "0"
            End If

            ConnectDatabase()

            Dim cmd As New MySqlCommand

            cmd.Connection = conn
            cmd.CommandText = "UPDATE feesubgroup SET feeGroup='" & SelectFeeGroup.SelectedItem.Text & "', groupSub='" & FeeSub.Text & "' WHERE groupSub='" & SelectFeeSub.SelectedItem.Text & "'"

            cmd.ExecuteNonQuery()
            Try
                Dim Activity As String = Session("LoggedInAdminLoginUsername") & " update " & SelectFeeSub.SelectedItem.Text & " fee sub"
                Dim com As New MySqlCommand
                com.Connection = conn
                com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                com.ExecuteNonQuery()

            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            End Try
            MessageBox.Show(Me, "Fee Group Updated Successfully?")
        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)

        Finally
            DisconnectDatabase()

        End Try
        Response.AppendHeader("Refresh", "0;url=./#fee-group-sub")
    End Sub



    'Delete Fee Group Sub
    Protected Sub DeleteFeeSub_Click(sender As Object, e As EventArgs) Handles DeleteFeeSub.Click

        Try

            ConnectDatabase()

            Dim cmd As New MySqlCommand

            cmd.Connection = conn
            cmd.CommandText = "DELETE FROM feesubgroup WHERE groupSub='" & SelectFeeSub.SelectedItem.Text & "'"

            cmd.ExecuteNonQuery()

            Try
                Dim Activity As String = Session("LoggedInAdminLoginUsername") & " delete " & SelectFeeSub.SelectedItem.Text
                Dim com As New MySqlCommand
                com.Connection = conn
                com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                com.ExecuteNonQuery()


            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            End Try
            MessageBox.Show(Me, "Fee Group Deleted Successfully!")
        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)

        Finally
            DisconnectDatabase()

        End Try
        Response.AppendHeader("Refresh", "0;url=./#fee-group-sub")
    End Sub


    'Add Fee to the Fee Section Table
    Protected Sub AddFee_Click(sender As Object, e As EventArgs) Handles AddFee.Click
        Try

            ConnectDatabase()

            Dim cmd As New MySqlCommand

            cmd.Connection = conn
            cmd.CommandText = "INSERT INTO feetable (feeGroup,feeSubGroup,instrumentCategory,instrumentSubCategory,measureRange,amount,charges,renewal,securityDeposit,calibrationFee) VALUES ('" & SelectFeeGroupFee.SelectedItem.Text & "','" & SelectFeeSubFee.SelectedItem.Text & "','" & SelectInstrumentCategory.SelectedItem.Text & "','" & SelectInstrumentSubCategory.SelectedItem.Text & "','" & MeasureRange.Text & "','" & MainCharge.Text & "','" & OtherCharges.Text & "','" & RenewalFee.Text & "','" & SecurityDeposit.Text & "','" & CalibrationFee.Text & "')"

            cmd.ExecuteNonQuery()
            Try
                Dim Activity As String = Session("LoggedInAdminLoginUsername") & " add " & MeasureRange.Text & " to fee table"
                Dim com As New MySqlCommand
                com.Connection = conn
                com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                com.ExecuteNonQuery()


            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            End Try
            MessageBox.Show(Me, "Fee has been uploaded successfully into Fee Table!")
        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)

        Finally
            DisconnectDatabase()

        End Try
        Response.AppendHeader("Refresh", "0;url=./#fee-section")
    End Sub



    'Save fee button
    Protected Sub SaveFee_Click(sender As Object, e As EventArgs) Handles SaveFee.Click

        Try

            ConnectDatabase()

            Dim cmd As New MySqlCommand

            cmd.Connection = conn
            cmd.CommandText = "UPDATE feetable SET feeGroup='" & SelectFeeGroupFee.SelectedItem.Text & "',feeSubGroup'" & SelectFeeSubFee.SelectedItem.Text & "',instrumentCategory=='" & SelectInstrumentCategory.SelectedItem.Text & "',instrumentSubCategory='" & SelectInstrumentSubCategory.SelectedItem.Text & "',measureRange='" & MeasureRange.Text & "',amount='" & MainCharge.Text & "',charges='" & OtherCharges.Text & "',renewal='" & RenewalFee.Text & "',securityDeposit='" & SecurityDeposit.Text & "',calibrationFee='" & CalibrationFee.Text & "' WHERE measureRange ='" & SelectMeasureRange.SelectedItem.Text & "'"

            cmd.ExecuteNonQuery()
            Try
                Dim Activity As String = Session("LoggedInAdminLoginUsername") & " update " & SelectMeasureRange.SelectedItem.Text
                Dim com As New MySqlCommand
                com.Connection = conn
                com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                com.ExecuteNonQuery()


            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            End Try
            MessageBox.Show(Me, "Fee Table Updated Successfully?")
        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)

        Finally
            DisconnectDatabase()

        End Try
        Response.AppendHeader("Refresh", "0;url=./#fee-section")
    End Sub



    'Delete From Fee Table
    Protected Sub DeleteFee_Click(sender As Object, e As EventArgs) Handles DeleteFee.Click

        Try

            ConnectDatabase()

            Dim cmd As New MySqlCommand

            cmd.Connection = conn
            cmd.CommandText = "DELETE FROM feetable WHERE measureRange='" & SelectMeasureRange.SelectedItem.Text & "'"

            cmd.ExecuteNonQuery()
            Try
                Dim Activity As String = Session("LoggedInAdminLoginUsername") & " delete " & SelectMeasureRange.SelectedItem.Text
                Dim com As New MySqlCommand
                com.Connection = conn
                com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                com.ExecuteNonQuery()


            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            End Try
            MessageBox.Show(Me, "Fee has been Deleted Successfully from Fee Table!")
        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)

        Finally
            DisconnectDatabase()

        End Try
        Response.AppendHeader("Refresh", "0;url=./#fee-section")
    End Sub


    'Add sector
    Protected Sub AddSector_Click(sender As Object, e As EventArgs) Handles AddSector.Click
        Try

            ConnectDatabase()

            Dim cmd As New MySqlCommand

            cmd.Connection = conn
            cmd.CommandText = "INSERT INTO sector (sector) VALUES ('" & Sector.Text & "')"

            cmd.ExecuteNonQuery()
            Try
                Dim Activity As String = Session("LoggedInAdminLoginUsername") & " add " & Sector.Text & " to sector"
                Dim com As New MySqlCommand
                com.Connection = conn
                com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                com.ExecuteNonQuery()


            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            End Try
            MessageBox.Show(Me, "Sector added successfully?")
        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)

        Finally
            DisconnectDatabase()

        End Try
        Response.AppendHeader("Refresh", "0;url=./#upload-instrument")

    End Sub


    'Delete Sector
    Protected Sub DeleteSector_Click(sender As Object, e As EventArgs) Handles DeleteSector.Click

        Try

            ConnectDatabase()

            Dim cmd As New MySqlCommand

            cmd.Connection = conn
            cmd.CommandText = "DELETE FROM sector WHERE sector='" & ModifySector.SelectedItem.Text & "'"

            cmd.ExecuteNonQuery()
            Try
                Dim Activity As String = Session("LoggedInAdminLoginUsername") & " delete " & ModifySector.SelectedItem.Text
                Dim com As New MySqlCommand
                com.Connection = conn
                com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                com.ExecuteNonQuery()


            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            End Try
            MessageBox.Show(Me, "Sector has been deleted successfully!")
        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)

        Finally
            DisconnectDatabase()

        End Try
        Response.AppendHeader("Refresh", "0;url=./#upload-instrument")
    End Sub


    'Add Instrument Category
    Protected Sub AddInstrumentCategory_Click(sender As Object, e As EventArgs) Handles AddInstrumentCategory.Click
        Try

            ConnectDatabase()

            Dim cmd As New MySqlCommand

            cmd.Connection = conn
            cmd.CommandText = "INSERT INTO devicecategories (deviceCategory,sector) VALUES ('" & InstrumentCategory.Text & "','" & SelectSector.SelectedItem.Text & "')"

            cmd.ExecuteNonQuery()
            Try
                Dim Activity As String = Session("LoggedInAdminLoginUsername") & " add " & InstrumentCategory.Text & " to instrument category"
                Dim com As New MySqlCommand
                com.Connection = conn
                com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                com.ExecuteNonQuery()


            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            End Try
            MessageBox.Show(Me, "Device category added successfully?")
        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)

        Finally
            DisconnectDatabase()

        End Try
        Response.AppendHeader("Refresh", "0;url=./#upload-instrument")
    End Sub



    'Save Instrument Category
    Protected Sub SaveInstrumentCategory_Click(sender As Object, e As EventArgs) Handles SaveInstrumentCategory.Click

        Try

            ConnectDatabase()

            Dim cmd As New MySqlCommand

            cmd.Connection = conn
            cmd.CommandText = "UPDATE devicecategories SET deviceCategory='" & InstrumentCategory.Text & "',sector='" & SelectSector.SelectedItem.Text & "' WHERE deviceCategory='" & ModifyInstrumentCategory.SelectedItem.Text & "'"

            cmd.ExecuteNonQuery()
            Try
                Dim Activity As String = Session("LoggedInAdminLoginUsername") & " update " & ModifyInstrumentCategory.SelectedItem.Text & " to " & InstrumentCategory.Text
                Dim com As New MySqlCommand
                com.Connection = conn
                com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                com.ExecuteNonQuery()


            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            End Try
            MessageBox.Show(Me, "Instrument Category Updated Successfully?")
        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)

        Finally
            DisconnectDatabase()

        End Try
        Response.AppendHeader("Refresh", "0;url=./#upload-instrument")
    End Sub



    'Delete Instrument Category
    Protected Sub DeleteInstrumentCategory_Click(sender As Object, e As EventArgs) Handles DeleteInstrumentCategory.Click

        Try

            ConnectDatabase()

            Dim cmd As New MySqlCommand

            cmd.Connection = conn
            cmd.CommandText = "DELETE FROM devicecategories WHERE deviceCategory='" & ModifyInstrumentCategory.SelectedItem.Text & "'"

            cmd.ExecuteNonQuery()
            Try
                Dim Activity As String = Session("LoggedInAdminLoginUsername") & " delete " & ModifyInstrumentCategory.SelectedItem.Text
                Dim com As New MySqlCommand
                com.Connection = conn
                com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                com.ExecuteNonQuery()


            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            End Try
            MessageBox.Show(Me, "Device Category has been deleted successfully!")
        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)

        Finally
            DisconnectDatabase()

        End Try
        Response.AppendHeader("Refresh", "0;url=./#upload-instrument")
    End Sub



    'Add Instrument Sub Category
    Protected Sub AddInstrumentSubCategory_Click(sender As Object, e As EventArgs) Handles AddInstrumentSubCategory.Click
        Try

            ConnectDatabase()

            Dim cmd As New MySqlCommand

            cmd.Connection = conn
            cmd.CommandText = "INSERT INTO devicesub (deviceCategory,sector,deviceType) VALUES ('" & SelectInstrumentCategoryAdd.SelectedItem.Text & "','" & SelectSectorAdd.SelectedItem.Text & "','" & InstrumentSubCategory.Text & "')"

            cmd.ExecuteNonQuery()
            MessageBox.Show(Me, "Device sub category added successfully?")
        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)

        Finally
            DisconnectDatabase()

        End Try
        Response.AppendHeader("Refresh", "0;url=./#upload-instrument")
    End Sub



    'Save Instrument Sub Category
    Protected Sub SaveInstrumentSubCategory_Click(sender As Object, e As EventArgs) Handles SaveInstrumentSubCategory.Click

        Try

            ConnectDatabase()

            Dim cmd As New MySqlCommand

            cmd.Connection = conn
            cmd.CommandText = "UPDATE devicesub SET deviceType='" & InstrumentSubCategory.Text & "',deviceCategory='" & SelectInstrumentCategoryAdd.SelectedItem.Text & "',sector='" & SelectSectorAdd.SelectedItem.Text & "' WHERE deviceType='" & ModifyInstrumentSubCategory.SelectedItem.Text & "'"

            cmd.ExecuteNonQuery()
            Try
                Dim Activity As String = Session("LoggedInAdminLoginUsername") & " update " & ModifyInstrumentSubCategory.SelectedItem.Text & " to " & InstrumentSubCategory.Text
                Dim com As New MySqlCommand
                com.Connection = conn
                com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                com.ExecuteNonQuery()


            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            End Try
            MessageBox.Show(Me, "Instrument Sub Category Updated Successfully?")
        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)

        Finally
            DisconnectDatabase()

        End Try
        Response.AppendHeader("Refresh", "0;url=./#upload-instrument")
    End Sub



    'Delete Instrument Category
    Protected Sub DeleteInstrumentSubCategory_Click(sender As Object, e As EventArgs) Handles DeleteInstrumentSubCategory.Click

        Try

            ConnectDatabase()

            Dim cmd As New MySqlCommand

            cmd.Connection = conn
            cmd.CommandText = "DELETE FROM devicesub WHERE deviceType='" & ModifyInstrumentSubCategory.SelectedItem.Text & "'"

            cmd.ExecuteNonQuery()
            Try
                Dim Activity As String = Session("LoggedInAdminLoginUsername") & " delete " & ModifyInstrumentSubCategory.SelectedItem.Text & " from device sub"
                Dim com As New MySqlCommand
                com.Connection = conn
                com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                com.ExecuteNonQuery()


            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            End Try
            MessageBox.Show(Me, "Device Sub Category has been deleted successfully!")
        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)

        Finally
            DisconnectDatabase()

        End Try
        Response.AppendHeader("Refresh", "0;url=./#upload-instrument")
    End Sub



    'Add Measurement
    Protected Sub AddMeasurement_Click(sender As Object, e As EventArgs) Handles AddMeasurement.Click
        Try

            ConnectDatabase()

            Dim cmd As New MySqlCommand

            cmd.Connection = conn
            cmd.CommandText = "INSERT INTO measurement (measureName,measureValue) VALUES ('" & MeasureMeasurement.Text & "','" & MeasureMeasurementValue.Text & "')"

            cmd.ExecuteNonQuery()
            Try
                Dim Activity As String = Session("LoggedInAdminLoginUsername") & " add " & MeasureMeasurement.Text & " to Measurement"

                Dim com As New MySqlCommand
                com.Connection = conn
                com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                com.ExecuteNonQuery()


            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            End Try
            MessageBox.Show(Me, "Measurement added successfully?")
        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)

        Finally
            DisconnectDatabase()

        End Try
        Response.AppendHeader("Refresh", "0;url=./#measurement")
    End Sub


    'Delete Measurement
    Protected Sub DeleteMeasurement_Click(sender As Object, e As EventArgs) Handles DeleteMeasurement.Click

        Try

            ConnectDatabase()

            Dim cmd As New MySqlCommand

            cmd.Connection = conn
            cmd.CommandText = "DELETE FROM measurement WHERE measureName='" & ModifyMeasureMeasurement.SelectedItem.Text & "'"

            cmd.ExecuteNonQuery()
            Try
                Dim Activity As String = Session("LoggedInAdminLoginUsername") & " delete " & ModifyInstrumentSubCategory.SelectedItem.Text & " from Measurement"
                Dim com As New MySqlCommand
                com.Connection = conn
                com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                com.ExecuteNonQuery()


            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            End Try
            MessageBox.Show(Me, "Measurement has been deleted successfully!")
        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)

        Finally
            DisconnectDatabase()

        End Try
        Response.AppendHeader("Refresh", "0;url=./#measurement")
    End Sub




    'Add Measurement
    Protected Sub AddDeviceMeasurement_Click(sender As Object, e As EventArgs) Handles AddDeviceMeasurement.Click
        Try

            ConnectDatabase()

            Dim cmd As New MySqlCommand

            cmd.Connection = conn
            cmd.CommandText = "INSERT INTO devicemeasurement (measureName,measureValue,deviceType) VALUES ('" & SelectMeasureMeasurements.SelectedItem.Text & "','" & MeasurementValue.Text & "','" & DeviceTypeMeasurement.SelectedItem.Text & "')"

            cmd.ExecuteNonQuery()
            Try
                Dim Activity As String = Session("LoggedInAdminLoginUsername") & " add " & DeviceTypeMeasurement.SelectedItem.Text & " to device measurement"
                Dim com As New MySqlCommand
                com.Connection = conn
                com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                com.ExecuteNonQuery()


            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            End Try
            MessageBox.Show(Me, "Device Measurement added successfully?")
        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)

        Finally
            DisconnectDatabase()

        End Try
        Response.AppendHeader("Refresh", "0;url=./#measurement")
    End Sub


    'Delete Measurement
    Protected Sub DeleteDeviceMeasurement_Click(sender As Object, e As EventArgs) Handles DeleteDeviceMeasurement.Click

        Try

            ConnectDatabase()

            Dim cmd As New MySqlCommand

            cmd.Connection = conn
            cmd.CommandText = "DELETE FROM devicemeasurement WHERE deviceType='" & ModifyMeasurement.SelectedItem.Text & "'"

            cmd.ExecuteNonQuery()
            Try
                Dim Activity As String = Session("LoggedInAdminLoginUsername") & " delete " & ModifyMeasurement.SelectedItem.Text & " from device measurement"
                Dim com As New MySqlCommand
                com.Connection = conn
                com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                com.ExecuteNonQuery()


            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            End Try
            MessageBox.Show(Me, "Device Measurement has been deleted successfully!")
        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)

        Finally
            DisconnectDatabase()

        End Try
        Response.AppendHeader("Refresh", "0;url=./#measurement")
    End Sub






    'This populate user account editing section on select account name
    Sub AdminSelectUserIndex_Changed(sender As Object, e As EventArgs)

        Try
            Dim db As String = "SELECT * FROM admin WHERE username = '" & SelectUser.SelectedItem.Text & "'"

            Using cn As MySqlCommand = New MySqlCommand(db, conn)
                Using da As New MySqlDataAdapter(cn)
                    'Fill data of logged in user into dataset

                    'Get the list of rows needed into Session, so as to enable us retreive it later

                    Dim dt As New DataTable()
                    da.Fill(dt)

                    Dim ds As New DataSet()
                    da.Fill(ds)

                    ModifySecurityQuestion.DataSource = dt
                    ModifySecurityQuestion.DataTextField = "securityQuestion"
                    ModifySecurityQuestion.DataValueField = "ID"
                    ModifySecurityQuestion.DataBind()

                    ModifySecurityAnswer.Text = ds.Tables(0).Rows(0).Item("securityAnswer").ToString
                    ModifyCompanyName.Text = ds.Tables(0).Rows(0).Item("companyName").ToString
                    ModifySurname.Text = ds.Tables(0).Rows(0).Item("surname").ToString
                    ModifyOtherNames.Text = ds.Tables(0).Rows(0).Item("otherNames").ToString
                    ModifyAddress.Text = ds.Tables(0).Rows(0).Item("contactAddress").ToString
                    ModifyMobile.Text = ds.Tables(0).Rows(0).Item("phone").ToString
                    ModifyEmailAddress.Text = ds.Tables(0).Rows(0).Item("email").ToString

                    ModifyAccountType.DataSource = dt
                    ModifyAccountType.DataTextField = "accountType"
                    ModifyAccountType.DataValueField = "ID"
                    ModifyAccountType.DataBind()

                    Dim companyMgtRight As String = ds.Tables(0).Rows(0).Item("companyMgtRight").ToString
                    Dim instrumentMgtRight As String = ds.Tables(0).Rows(0).Item("instrumentMgtRight").ToString
                    Dim staticDataRight As String = ds.Tables(0).Rows(0).Item("staticDataRight").ToString
                    Dim manageLot As String = ds.Tables(0).Rows(0).Item("manageLot").ToString
                    Dim invoiceReport As String = ds.Tables(0).Rows(0).Item("invoiceReport").ToString
                    Dim reportRight As String = ds.Tables(0).Rows(0).Item("reportRight").ToString
                    Dim exportPermitMgt As String = ds.Tables(0).Rows(0).Item("exportPermitMgt").ToString
                    Dim importPermitMgt As String = ds.Tables(0).Rows(0).Item("importPermitMgt").ToString
                    Dim downloadCenter As String = ds.Tables(0).Rows(0).Item("downloadCenter").ToString
                    Dim uploadNews As String = ds.Tables(0).Rows(0).Item("uploadNews").ToString
                    Dim otherDocRight As String = ds.Tables(0).Rows(0).Item("otherDocRight").ToString
                    Dim uploadGallery As String = ds.Tables(0).Rows(0).Item("uploadGallery").ToString
                    Dim setupOffice As String = ds.Tables(0).Rows(0).Item("setupOffice").ToString
                    Dim approveExportImport As String = ds.Tables(0).Rows(0).Item("approveExportImport").ToString
                    Dim inspectExportImport As String = ds.Tables(0).Rows(0).Item("inspectExportImport").ToString
                    Dim endorseExportImport As String = ds.Tables(0).Rows(0).Item("endorseExportImport").ToString
                    Dim recommendExportImport As String = ds.Tables(0).Rows(0).Item("recommendExportImport").ToString
                    Dim archiveRight As String = ds.Tables(0).Rows(0).Item("archiveRight").ToString
                    Dim quizRight As String = ds.Tables(0).Rows(0).Item("quizRight").ToString
                    Dim careerRight As String = ds.Tables(0).Rows(0).Item("careerRight").ToString
                    Dim instrumentFee As String = ds.Tables(0).Rows(0).Item("instrumentFee").ToString
                    Dim measurement = ds.Tables(0).Rows(0).Item("measurement").ToString



                    If companyMgtRight = "1" Then
                        ModifyCompanyManagementRight.Checked = True

                    Else

                        ModifyCompanyManagementRight.Checked = False

                    End If

                    If instrumentMgtRight = "1" Then
                        ModifyInstrumentManagementRight.Checked = True

                    Else
                        ModifyInstrumentManagementRight.Checked = False

                    End If

                    If staticDataRight = "1" Then
                        ModifyStaticDataRight.Checked = True

                    Else
                        ModifyStaticDataRight.Checked = False

                    End If


                    If manageLot = "1" Then
                        ModifyLotsManagementRight.Checked = True

                    Else
                        ModifyLotsManagementRight.Checked = False

                    End If


                    If invoiceReport = "1" Then
                        ModifyInvoiceReportRight.Checked = True

                    Else
                        ModifyInvoiceReportRight.Checked = False

                    End If


                    If reportRight = "1" Then
                        ModifyReportsRight.Checked = True

                    Else
                        ModifyReportsRight.Checked = False

                    End If


                    If exportPermitMgt = "1" Then
                        ModifyExportPermitManagement.Checked = True

                    Else
                        ModifyExportPermitManagement.Checked = False

                    End If


                    If importPermitMgt = "1" Then
                        ImportPermitManagement.Checked = True

                    Else
                        ModifyImportPermitManagement.Checked = False

                    End If


                    If downloadCenter = "1" Then
                        ModifyDownloadManagerRight.Checked = True

                    Else
                        ModifyDownloadManagerRight.Checked = False

                    End If


                    If uploadNews = "1" Then
                        ModifyUploadNewsRight.Checked = True

                    Else
                        ModifyUploadNewsRight.Checked = False

                    End If


                    If otherDocRight = "1" Then
                        ModifyOtherDocumentsRight.Checked = True

                    Else
                        ModifyOtherDocumentsRight.Checked = False

                    End If


                    If uploadGallery = "1" Then
                        ModifyUploadPictureRight.Checked = True

                    Else
                        ModifyUploadPictureRight.Checked = False

                    End If


                    If setupOffice = "1" Then
                        ModifySetupOfficeRight.Checked = True

                    Else
                        ModifySetupOfficeRight.Checked = False

                    End If


                    If approveExportImport = "1" Then
                        ModifyExportImportApprovalRight.Checked = True

                    Else
                        ModifyExportImportApprovalRight.Checked = False

                    End If


                    If inspectExportImport = "1" Then
                        ModifyExportImportInspectionRight.Checked = True

                    Else
                        ModifyExportImportInspectionRight.Checked = False

                    End If


                    If endorseExportImport = "1" Then
                        ModifyExportImportEndorseRight.Checked = True

                    Else
                        ModifyExportImportEndorseRight.Checked = False

                    End If


                    If recommendExportImport = "1" Then
                        ModifyExportImportRecomendRight.Checked = True

                    Else
                        ModifyExportImportRecomendRight.Checked = False

                    End If


                    If archiveRight = "1" Then
                        ModifyArchiveAccessRight.Checked = True

                    Else
                        ModifyArchiveAccessRight.Checked = False

                    End If


                    If quizRight = "1" Then
                        ModifyUploadQuizRight.Checked = True

                    Else
                        ModifyUploadQuizRight.Checked = False

                    End If


                    If careerRight = "1" Then
                        ModifyUploadCareerRight.Checked = True

                    Else
                        ModifyUploadCareerRight.Checked = False

                    End If


                    If instrumentFee = "1" Then
                        ModifyInstrumentFeeRight.Checked = True

                    Else
                        ModifyInstrumentFeeRight.Checked = False

                    End If


                    If measurement = "1" Then
                        ModifyMeasurementRight.Checked = True

                    Else
                        ModifyMeasurementRight.Checked = False
                    End If



                End Using
            End Using

            'Trow error is anything wrong with the code

        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)

        Finally
            'After execution of mysql query, disconnect database
            DisconnectDatabase()
        End Try



    End Sub


    'All dropdown filler or select populator
    Sub SelectLotToEdit_Changed(sender As Object, e As EventArgs)

        'Populate Lots section and make selected lot name editable
        Try
            ConnectDatabase()

            Dim db As String = "SELECT * FROM lots WHERE ID='" & SelectLotToEdit.SelectedValue & "' "

            Using cn As MySqlCommand = New MySqlCommand(db, conn)
                Using da As New MySqlDataAdapter(cn)
                    'Fill data of logged in user into dataset

                    'Get the list of rows needed into Session, so as to enable us retrieve it later

                    Dim dt As New DataTable()
                    da.Fill(dt)

                    Dim ds As New DataSet()
                    da.Fill(ds)

                    EditLotName.Text = ds.Tables(0).Rows(0).Item("lotName").ToString


                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)

        End Try


    End Sub



    Sub TerminalName_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            ConnectDatabase()

            Dim db As String = "SELECT * FROM terminals WHERE ID='" & TerminalName.SelectedValue & "' "

            Using cn As MySqlCommand = New MySqlCommand(db, conn)

                Using da As New MySqlDataAdapter(cn)
                    'Fill data of logged in user into dataset

                    'Get the list of rows needed into Session, so as to enable us retrieve it later

                    Dim dt As New DataTable()
                    da.Fill(dt)

                    Dim ds As New DataSet()
                    da.Fill(ds)


                    Terminal.Text = ds.Tables(0).Rows(0).Item("terminalName").ToString
                    LotTerminalRCNumber.Text = ds.Tables(0).Rows(0).Item("RCNumber").ToString
                    Dim LotID = ds.Tables(0).Rows(0).Item("LotID").ToString

                    LotTerminalOwner.Text = ds.Tables(0).Rows(0).Item("TerminalOwner").ToString
                    LotTerminalLocation.Text = ds.Tables(0).Rows(0).Item("Location").ToString

                    'SelectLotTerminalCompany.DataSource = dt
                    'SelectLotTerminalCompany.DataTextField = "companyID"
                    'SelectLotTerminalCompany.DataValueField = "ID"
                    'SelectLotTerminalCompany.DataBind()

                    LotTerminalActiveISP.Text = ds.Tables(0).Rows(0).Item("ISPID").ToString



                    Dim dbl As String = "SELECT * FROM lots"

                    Using cnl As MySqlCommand = New MySqlCommand(dbl, conn)
                        Using dal As New MySqlDataAdapter(cnl)
                            'Fill data of logged in user into dataset

                            'Get the list of rows needed into Session, so as to enable us retrieve it later

                            Dim dtl As New DataTable()
                            dal.Fill(dtl)

                            SelectLotName.DataSource = dtl
                            SelectLotName.DataTextField = "lotName"
                            SelectLotName.DataValueField = "ID"
                            SelectLotName.DataBind()
                            SelectLotName.SelectedValue = LotID
                        End Using
                    End Using


                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)
        End Try




    End Sub

    'This populate Download Center Select Information
    Sub DownloadCenter_SelectedIndexChanged(sender As Object, e As EventArgs)



        Try
            ConnectDatabase()

            Dim db As String = "SELECT * FROM downloadcenter WHERE fileName='" & SelectFileDownload.SelectedItem.Text & "'"

            Using cn As MySqlCommand = New MySqlCommand(db, conn)

                Using da As New MySqlDataAdapter(cn)
                    'Fill data of logged in user into dataset
                    FileDownloadDescription.Text = ""
                    FileDownloadName.Text = ""

                    'Get the list of rows needed into dataset, so as to enable us retrieve it later

                    Dim dt As New DataTable()
                    da.Fill(dt)

                    Dim ds As New DataSet()
                    da.Fill(ds)

                    Try
                        FileDownloadName.Text = ds.Tables(0).Rows(0).Item("fileName").ToString
                        FileDownloadDescription.Text = ds.Tables(0).Rows(0).Item("description").ToString
                        Dim DisplayHide As String = ds.Tables(0).Rows(0).Item("recordStatus").ToString
                        Dim downloadType As String = ds.Tables(0).Rows(0).Item("downloadType").ToString

                        'FileMemberType.SelectedItem.Text = downloadType

                        FileMemberType.ClearSelection()
                        FileMemberType.Items.FindByText(downloadType.ToString).Selected = True

                        If DisplayHide = "0" Then
                            DisplayDownloadFile.Checked = False

                        ElseIf DisplayHide = "1" Then
                            DisplayDownloadFile.Checked = True
                        End If

                    Catch ex As Exception
                        MessageBox.Show(Me, ex.Message)
                    End Try

                End Using
            End Using

        Catch ex As MySqlException
            MessageBox.Show(Me, ex.Message)
        End Try




    End Sub




    'This populate Download Center Select Information
    Sub ArticleHeader_SelectedIndexChanged(sender As Object, e As EventArgs)



        Try
            ConnectDatabase()

            Dim db As String = "SELECT * FROM article WHERE articleTitle='" & SelectNewHeader.SelectedItem.Text & "'"

            Using cn As MySqlCommand = New MySqlCommand(db, conn)

                Using da As New MySqlDataAdapter(cn)
                    'Get the list of rows needed into dataset, so as to enable us retrieve it later

                    Dim dt As New DataTable()
                    da.Fill(dt)

                    Dim ds As New DataSet()
                    da.Fill(ds)

                    Try
                        ArticleHeader.Text = ds.Tables(0).Rows(0).Item("articleTItle").ToString
                        ArticleBody.Text = ds.Tables(0).Rows(0).Item("article").ToString
                        ArticlePictureLink.Text = ds.Tables(0).Rows(0).Item("imageLink").ToString
                        Dim HompageDisplay As String = ds.Tables(0).Rows(0).Item("status").ToString
                        Dim ArticleGroups As String = ds.Tables(0).Rows(0).Item("articleGroup").ToString

                        ArticleGroup.ClearSelection()
                        ArticleGroup.Items.FindByText(ArticleGroups.ToString).Selected = True

                        If HompageDisplay = "0" Then
                            ArticleStatus.Checked = False

                        ElseIf HompageDisplay = "1" Then
                            ArticleStatus.Checked = True
                        End If


                    Catch ex As Exception
                        MessageBox.Show(Me, ex.Message)

                    End Try

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)
        End Try




    End Sub



    'This populate Download Center Select Information
    Sub PictureGallery_SelectedIndexChanged(sender As Object, e As EventArgs)



        Try
            ConnectDatabase()

            Dim db As String = "SELECT * FROM gallery WHERE caption='" & SelectPictureGallery.SelectedItem.Text & "'"

            Using cn As MySqlCommand = New MySqlCommand(db, conn)

                Using da As New MySqlDataAdapter(cn)
                    'Get the list of rows needed into dataset, so as to enable us retrieve it later

                    Dim dt As New DataTable()
                    da.Fill(dt)

                    Dim ds As New DataSet()
                    da.Fill(ds)

                    Try
                        PictureGalleryCaption.Text = ds.Tables(0).Rows(0).Item("caption").ToString
                        PictureGalleryLink.Text = ds.Tables(0).Rows(0).Item("photoName").ToString
                        Dim GalleryDisplay As String = ds.Tables(0).Rows(0).Item("status").ToString
                        Dim GalleryGroup As String = ds.Tables(0).Rows(0).Item("groups").ToString

                        PictureGalleryGroup.ClearSelection()
                        PictureGalleryGroup.Items.FindByText(GalleryGroup.ToString).Selected = True

                        If GalleryDisplay = "0" Then
                            DisplayPictureGallery.Checked = False

                        ElseIf GalleryDisplay = "1" Then
                            DisplayPictureGallery.Checked = True
                        End If


                    Catch ex As Exception
                        MessageBox.Show(Me, ex.Message)
                    End Try

                End Using
            End Using

        Catch ex As MySqlException
            MessageBox.Show(Me, ex.Message)
        End Try




    End Sub


    'This populate Download Center Select Information
    Sub StateContact_SelectedIndexChanged(sender As Object, e As EventArgs)



        Try
            ConnectDatabase()

            Dim db As String = "SELECT * FROM statecontacts WHERE state='" & SelectStateOffice.SelectedItem.Text & "'"

            Using cn As MySqlCommand = New MySqlCommand(db, conn)

                Using da As New MySqlDataAdapter(cn)
                    'Get the list of rows needed into dataset, so as to enable us retrieve it later

                    Dim dt As New DataTable()
                    da.Fill(dt)

                    Dim ds As New DataSet()
                    da.Fill(ds)

                    Try
                        Dim SelectState As String = ds.Tables(0).Rows(0).Item("state").ToString
                        SelectOfficeState.ClearSelection()
                        SelectOfficeState.Items.FindByText(SelectState.ToString).Selected = True

                        'SelectStateOffice.SelectedItem.Text = SelectState.ToString

                        Dim DisplayContact As String = ds.Tables(0).Rows(0).Item("status").ToString

                        If DisplayContact = "0" Then
                            DisplayAddress.Checked = False

                        ElseIf DisplayContact = "1" Then
                            DisplayAddress.Checked = True
                        End If

                        OfficeEmailAddress.Text = ds.Tables(0).Rows(0).Item("emailAddress").ToString
                        OfficeAddress.Text = ds.Tables(0).Rows(0).Item("address").ToString
                        StateContactPersonName.Text = ds.Tables(0).Rows(0).Item("contactPersonName").ToString
                        StateContactPersonMobile.Text = ds.Tables(0).Rows(0).Item("contactPersonMobile").ToString


                    Catch ex As Exception
                        MessageBox.Show(Me, ex.Message)
                    End Try

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)
        End Try

    End Sub



    Protected Sub State_SelectedIndexChanged(sender As Object, e As EventArgs) Handles UploadedStates.SelectedIndexChanged


        'This populate state
        Try
            ConnectDatabase()

            Dim db As String = "SELECT * FROM lga WHERE state = '" & UploadedStates.SelectedItem.Text & "' ORDER BY lga"

            Using cn As MySqlCommand = New MySqlCommand(db, conn)
                Using da As New MySqlDataAdapter(cn)
                    'Fill data of logged in user into dataset

                    'Get the list of rows needed into Session, so as to enable us retreive it later
                    UploadedCities.Items.Clear()
                    UploadedLGA.Items.Clear()

                    Dim dt As New DataTable()
                    da.Fill(dt)
                    UploadedLGA.DataSource = dt
                    UploadedLGA.DataTextField = "lga"
                    UploadedLGA.DataValueField = "ID"
                    UploadedLGA.DataBind()

                End Using
            End Using

            'Trow errow is anything is wrong with the code

        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)

        Finally
            'After execution of mysql query, disconnect database
            DisconnectDatabase()
        End Try


    End Sub

    Protected Sub LGA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles UploadedLGA.SelectedIndexChanged

        Try
            ConnectDatabase()

            Dim db As String = "SELECT * FROM city WHERE lga = '" & UploadedLGA.SelectedItem.Text & "' ORDER BY city ASC"

            Using cn As MySqlCommand = New MySqlCommand(db, conn)
                Using da As New MySqlDataAdapter(cn)
                    'Fill data of logged in user into dataset

                    'Get the list of rows needed into Session, so as to enable us retreive it later

                    Dim dt As New DataTable()
                    da.Fill(dt)
                    UploadedCities.DataSource = dt
                    UploadedCities.DataTextField = "city"
                    UploadedCities.DataValueField = "ID"
                    UploadedCities.DataBind()

                End Using
            End Using

            'Trow errow is anything is wrong with the code

        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)

        Finally
            'After execution of mysql query, disconnect database
            DisconnectDatabase()
        End Try


    End Sub



    'This populate Fee Group to Modify
    Sub ModifyFeeGroup_SelectedIndexChanged(sender As Object, e As EventArgs)



        Try
            ConnectDatabase()

            Dim db As String = "SELECT * FROM feegroup WHERE feeGroup='" & ModifyFeeGroup.SelectedItem.Text & "'"

            Using cn As MySqlCommand = New MySqlCommand(db, conn)

                Using da As New MySqlDataAdapter(cn)
                    'Get the list of rows needed into dataset, so as to enable us retrieve it later

                    Dim ds As New DataSet()
                    da.Fill(ds)

                    Try

                        Dim feeIsServices As String = ds.Tables(0).Rows(0).Item("isService").ToString

                        If feeIsServices = "0" Then
                            FeeGroupIsService.Checked = False

                        ElseIf feeIsServices = "1" Then
                            FeeGroupIsService.Checked = True
                        End If

                        FeeGroup.Text = ds.Tables(0).Rows(0).Item("feeGroup").ToString

                    Catch ex As Exception
                        MessageBox.Show(Me, ex.Message)
                    End Try

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)
        End Try

    End Sub


    'This populate Fee Sub to Modify
    Sub ModifyFeeSub_SelectedIndexChanged(sender As Object, e As EventArgs)

        Try
            ConnectDatabase()

            Dim db As String = "SELECT * FROM feesubgroup WHERE groupSub='" & SelectFeeSub.SelectedItem.Text & "'"

            Using cn As MySqlCommand = New MySqlCommand(db, conn)

                Using da As New MySqlDataAdapter(cn)
                    'Get the list of rows needed into dataset, so as to enable us retrieve it later

                    Dim ds As New DataSet()
                    da.Fill(ds)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    Try

                        Dim FeeGroups As String = ds.Tables(0).Rows(0).Item("feeGroup").ToString
                        SelectFeeGroup.ClearSelection()
                        SelectFeeGroup.Items.FindByText(FeeGroups.ToString).Selected = True
                        FeeSub.Text = ds.Tables(0).Rows(0).Item("groupSub").ToString



                    Catch ex As Exception
                        MessageBox.Show(Me, ex.Message)
                    End Try

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)
        End Try

    End Sub


    'This populate Fee Table Data
    Sub SelectMeasureRange_SelectedIndexChanged(sender As Object, e As EventArgs)


        Try
            ConnectDatabase()

            Dim db As String = "SELECT * FROM feetable WHERE measureRange='" & SelectMeasureRange.SelectedItem.Text & "'"

            Using cn As MySqlCommand = New MySqlCommand(db, conn)

                Using da As New MySqlDataAdapter(cn)
                    'Get the list of rows needed into dataset, so as to enable us retrieve it later

                    Dim ds As New DataSet()
                    da.Fill(ds)
                    Dim dt As New DataTable()
                    da.Fill(dt)

                    Dim FeeGroups As String = ds.Tables(0).Rows(0).Item("feeGroup").ToString
                    SelectFeeGroupFee.ClearSelection()
                    SelectFeeGroupFee.Items.FindByText(FeeGroups.ToString).Selected = True

                    Dim FeeSubs = ds.Tables(0).Rows(0).Item("feeSubGroup").ToString
                    SelectFeeSubFee.ClearSelection()
                    SelectFeeSubFee.Items.FindByText(FeeSubs.ToString).Selected = True

                    MeasureRange.Text = ds.Tables(0).Rows(0).Item("measureRange").ToString
                    MainCharge.Text = ds.Tables(0).Rows(0).Item("amount").ToString


                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)
        End Try


    End Sub


    'This populate Sector data
    Sub ModifySector_SelectedIndexChanged(sender As Object, e As EventArgs)


        Try
            ConnectDatabase()

            Dim db As String = "SELECT * FROM sector WHERE sector='" & ModifySector.SelectedItem.Text & "'"

            Using cn As MySqlCommand = New MySqlCommand(db, conn)

                Using da As New MySqlDataAdapter(cn)
                    'Get the list of rows needed into dataset, so as to enable us retrieve it later

                    Dim ds As New DataSet()
                    da.Fill(ds)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    Try

                        Sector.Text = ds.Tables(0).Rows(0).Item("sector").ToString

                    Catch ex As Exception
                        MessageBox.Show(Me, ex.Message)
                    End Try

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)
        End Try


    End Sub


    'This populate Instrument Categories
    Sub ModifyInstrumentCategories_SelectedIndexChanged(sender As Object, e As EventArgs)


        Try
            ConnectDatabase()

            Dim db As String = "SELECT * FROM devicecategories WHERE deviceCategory='" & ModifyInstrumentCategory.SelectedItem.Text & "'"

            Using cn As MySqlCommand = New MySqlCommand(db, conn)

                Using da As New MySqlDataAdapter(cn)
                    'Get the list of rows needed into dataset, so as to enable us retrieve it later

                    Dim ds As New DataSet()
                    da.Fill(ds)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    Try

                        Dim Sectors = ds.Tables(0).Rows(0).Item("sector").ToString
                        SelectSector.ClearSelection()
                        SelectSector.Items.FindByText(Sectors.ToString).Selected = True

                        InstrumentCategory.Text = ds.Tables(0).Rows(0).Item("deviceCategory").ToString

                    Catch ex As Exception
                        MessageBox.Show(Me, ex.Message)
                    End Try

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)
        End Try


    End Sub



    'This populate Instrument Categories
    Sub SectorInstrumentCategories_SelectedIndexChanged(sender As Object, e As EventArgs)


        Try
            ConnectDatabase()

            Dim db As String = "SELECT * FROM devicecategories WHERE sector='" & SelectSectorAdd.SelectedItem.Text & "'"

            Using cn As MySqlCommand = New MySqlCommand(db, conn)

                Using da As New MySqlDataAdapter(cn)
                    'Get the list of rows needed into dataset, so as to enable us retrieve it later

                    Dim ds As New DataSet()
                    da.Fill(ds)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    Try

                        SelectInstrumentCategoryAdd.DataSource = dt
                        SelectInstrumentCategoryAdd.DataMember = "deviceCategory"
                        SelectInstrumentCategoryAdd.DataTextField = "deviceCategory"
                        SelectInstrumentCategoryAdd.DataValueField = "ID"
                        SelectInstrumentCategoryAdd.DataBind()

                        ' Response.Redirect("./#upload-instrument", False)

                    Catch ex As Exception

                        MessageBox.Show(Me, ex.Message)
                    End Try

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)
        End Try


    End Sub



    'This populate Instrument Sub Categories
    Sub ModifyInstrumentSubCategories_SelectedIndexChanged(sender As Object, e As EventArgs)


        Try
            ConnectDatabase()

            Dim db As String = "SELECT * FROM devicesub WHERE deviceType='" & ModifyInstrumentSubCategory.SelectedItem.Text & "'"

            Using cn As MySqlCommand = New MySqlCommand(db, conn)

                Using da As New MySqlDataAdapter(cn)
                    'Get the list of rows needed into dataset, so as to enable us retrieve it later

                    Dim ds As New DataSet()
                    da.Fill(ds)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    Try

                        'Dim Sectors = ds.Tables(0).Rows(0).Item("sector").ToString
                        'SelectSectorAdd.ClearSelection()
                        'SelectSectorAdd.Items.FindByText(Sectors.ToString).Selected = True

                        Dim InstrumentCat = ds.Tables(0).Rows(0).Item("deviceCategory").ToString
                        SelectInstrumentCategoryAdd.ClearSelection()
                        SelectInstrumentCategoryAdd.Items.FindByText(InstrumentCat.ToString).Selected = True

                        InstrumentSubCategory.Text = ds.Tables(0).Rows(0).Item("deviceType").ToString

                    Catch ex As Exception
                        MessageBox.Show(Me, ex.Message)
                    End Try

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)
        End Try


    End Sub



    'This populate Measurement
    Sub ModifyMeasureMeasurement_SelectedIndexChanged(sender As Object, e As EventArgs)


        Try
            ConnectDatabase()

            Dim db As String = "SELECT * FROM measurement WHERE measureName='" & ModifyMeasureMeasurement.SelectedItem.Text & "'"

            Using cn As MySqlCommand = New MySqlCommand(db, conn)

                Using da As New MySqlDataAdapter(cn)
                    'Get the list of rows needed into dataset, so as to enable us retrieve it later

                    Dim ds As New DataSet()
                    da.Fill(ds)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    Try

                        MeasureMeasurement.Text = ds.Tables(0).Rows(0).Item("measureName").ToString
                        MeasureMeasurementValue.Text = ds.Tables(0).Rows(0).Item("measureValue").ToString

                    Catch ex As Exception
                        MessageBox.Show(Me, ex.Message)
                    End Try

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)
        End Try


    End Sub


    'This populate Measurement
    Sub ModifyDeviceMeasurement_SelectedIndexChanged(sender As Object, e As EventArgs)


        Try
            ConnectDatabase()

            Dim db As String = "SELECT * FROM devicemeasurement WHERE deviceType='" & ModifyMeasurement.SelectedItem.Text & "'"

            Using cn As MySqlCommand = New MySqlCommand(db, conn)

                Using da As New MySqlDataAdapter(cn)
                    'Get the list of rows needed into dataset, so as to enable us retrieve it later

                    Dim ds As New DataSet()
                    da.Fill(ds)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    Try
                        Dim SelectedMeasure = ds.Tables(0).Rows(0).Item("measureName").ToString
                        SelectMeasureMeasurements.ClearSelection()
                        SelectMeasureMeasurements.Items.FindByText(SelectedMeasure).Selected = True

                        Dim SelectedDeviceType = ds.Tables(0).Rows(0).Item("deviceType").ToString
                        DeviceTypeMeasurement.ClearSelection()
                        DeviceTypeMeasurement.Items.FindByText(SelectedDeviceType).Selected = True

                        MeasurementValue.Text = ds.Tables(0).Rows(0).Item("measureValue").ToString

                    Catch ex As Exception
                        MessageBox.Show(Me, ex.Message)
                    End Try

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)
        End Try


    End Sub



    'This populate device or instrument category 

    Sub FeeSector_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            ConnectDatabase()

            Dim db As String = "SELECT * FROM devicecategories WHERE sector='" & FeeSector.SelectedItem.Text & "'"

            Using cn As MySqlCommand = New MySqlCommand(db, conn)
                Using da As New MySqlDataAdapter(cn)
                    'Fill data of logged in user into dataset

                    Dim dt As New DataTable()
                    da.Fill(dt)

                    FeeInstrumentCategory.DataSource = dt
                    FeeInstrumentCategory.DataTextField = "deviceCategory"
                    FeeInstrumentCategory.DataValueField = "ID"
                    FeeInstrumentCategory.DataBind()

                End Using
            End Using

            'Trow errow is anything is wrong with the code

        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)

        Finally
            'After execution of mysql query, disconnect database
            DisconnectDatabase()
        End Try



    End Sub



    'This populate device or instrument sub category 
    Sub FeeInstrumentCategory_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            ConnectDatabase()

            Dim db As String = "SELECT * FROM devicesub WHERE deviceCategory='" & FeeInstrumentCategory.SelectedItem.Text & "'"

            Using cn As MySqlCommand = New MySqlCommand(db, conn)
                Using da As New MySqlDataAdapter(cn)
                    'Fill data of logged in user into dataset

                    Dim dt As New DataTable()
                    da.Fill(dt)

                    FeeInstrumentSub.DataSource = dt
                    FeeInstrumentSub.DataTextField = "deviceType"
                    FeeInstrumentSub.DataValueField = "ID"
                    FeeInstrumentSub.DataBind()

                End Using
            End Using

            'Trow errow is anything is wrong with the code

        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)

        Finally
            'After execution of mysql query, disconnect database
            DisconnectDatabase()
        End Try

    End Sub

    'This populate measurement
    Sub FeeInstrumentSubCategory_SelectedIndexChanged(sender As Object, e As EventArgs)

        Try
            ConnectDatabase()

            Dim db As String = "SELECT * FROM devicemeasurement WHERE deviceType='" & FeeInstrumentSub.SelectedItem.Text & "'"

            Using cn As MySqlCommand = New MySqlCommand(db, conn)
                Using da As New MySqlDataAdapter(cn)
                    'Fill data of logged in user into dataset

                    Dim dt As New DataTable()
                    da.Fill(dt)

                    FeeMeasurement.DataSource = dt
                    FeeMeasurement.DataTextField = "measureName"
                    FeeMeasurement.DataValueField = "ID"
                    FeeMeasurement.DataBind()


                End Using
            End Using

            'Trow errow is anything is wrong with the code

        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)

        Finally
            'After execution of mysql query, disconnect database
            DisconnectDatabase()
        End Try



        'InstrumentFee_Click(sender, New System.EventArgs())



    End Sub


    'This populate Modify Fee Description
    Sub FeeDescription_SelectedIndexChanged(sender As Object, e As EventArgs)

        Try
            ConnectDatabase()

            Dim db As String = "SELECT * FROM feetable WHERE measureRange='" & FeeDescription.SelectedItem.Text & "'"

            Using cn As MySqlCommand = New MySqlCommand(db, conn)
                Using da As New MySqlDataAdapter(cn)
                    'Fill data of logged in user into dataset

                    Dim dt As New DataTable()
                    da.Fill(dt)

                    FeeAmount.Text = ds.Tables(0).Rows(0).Item("amount").ToString

                End Using
            End Using

            'Trow errow is anything is wrong with the code

        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)

        Finally
            'After execution of mysql query, disconnect database
            DisconnectDatabase()
        End Try

    End Sub




    'This populate Instrument Sub Categories
    Sub SelectInstrumentCategory_SelectedIndexChanged(sender As Object, e As EventArgs)

        Try
            ConnectDatabase()

            Dim db As String = "SELECT * FROM devicesub WHERE deviceCategory='" & SelectInstrumentCategory.SelectedItem.Text & "'"

            Using cn As MySqlCommand = New MySqlCommand(db, conn)

                Using da As New MySqlDataAdapter(cn)
                    'Get the list of rows needed into dataset, so as to enable us retrieve it later

                    Dim ds As New DataSet()
                    da.Fill(ds)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    Try

                        'Dim Sectors = ds.Tables(0).Rows(0).Item("sector").ToString
                        'SelectSectorAdd.ClearSelection()
                        'SelectSectorAdd.Items.FindByText(Sectors.ToString).Selected = True

                        SelectInstrumentSubCategory.DataSource = dt
                        SelectInstrumentSubCategory.DataTextField = "deviceType"
                        SelectInstrumentSubCategory.DataValueField = "ID"
                        SelectInstrumentSubCategory.DataBind()

                    Catch ex As Exception
                        MessageBox.Show(Me, ex.Message)
                    End Try

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)

        Finally
            DisconnectDatabase()
        End Try


    End Sub


    'This populate Instrument Sub Categories
    Protected Sub RecoverySearchButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RecoverySearchButton.Click
        If RecoverySearchName.Text = "" And RecoverySearchNumber.Text = "" Then
            MessageBox.Show(Me, "Search fields can not be left blank!")
        Else
            Try

                ConnectDatabase()

                Dim MyAdapter As New MySqlDataAdapter

                Dim SqlQuery = "SELECT * FROM company WHERE username='" & RecoverySearchName.Text & "' OR mobileNumber= '" & RecoverySearchNumber.Text & "' OR companyPhoneNumber= '" & RecoverySearchNumber.Text & "';"
                Dim Command As New MySqlCommand
                Command.Connection = conn
                Command.CommandText = SqlQuery
                MyAdapter.SelectCommand = Command
                Dim reader As MySqlDataReader
                reader = Command.ExecuteReader
                'Check if the credentials provided is in the database
                If reader.HasRows = 0 Then

                    MessageBox.Show(Me, "User not found!")
                    reader.Close()
                    'Log user activity
                    Dim Activity As String = Session("LoggedInAdminLoginUsername") & " attempt to change password for non-existing user!   Username Searched:  " & RecoverySearchName.Text & " Phone Number Searched:  " & RecoverySearchNumber.Text
                    Dim com As New MySqlCommand
                    com.Connection = conn
                    com.CommandText = "INSERT INTO userlog (activity,IPAddress,machineName,deviceType,browserName,logdate,logtime) VALUES ('" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "')"
                    com.ExecuteNonQuery()

                Else

                    'MessageBox.Show(Me, "User found in the database!")
                    reader.Close()
                    Dim db As String = "SELECT * FROM company WHERE username='" & RecoverySearchName.Text & "' OR mobileNumber= '" & RecoverySearchNumber.Text & "' OR companyPhoneNumber= '" & RecoverySearchNumber.Text & "';"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)
                            da.Fill(ds)
                            RecoverySelectUser.SelectedItem.Text = ds.Tables(0).Rows(0).Item("username").ToString
                            RecoveryCompanyName.Text = ds.Tables(0).Rows(0).Item("companyName").ToString
                            RecoveryMobile.Text = ds.Tables(0).Rows(0).Item("companyPhoneNumber").ToString
                            RecoverySurname.Text = ds.Tables(0).Rows(0).Item("filledBySurname").ToString
                            RecoveryOtherName.Text = ds.Tables(0).Rows(0).Item("filledByOtherNames").ToString
                            RecoveryEmail.Text = ds.Tables(0).Rows(0).Item("filledByEmail").ToString
                            RecoveryOldPassord.Text = "OldPassword"
                            RecoveryUserID.Text = ds.Tables(0).Rows(0).Item("ID").ToString


                        End Using
                    End Using

                    'Trow errow is anything wrong with the code

                End If

            Catch ex As Exception

                MessageBox.Show(Me, ex.Message)

            Finally
                'After execution of mysql query, disconnect database
                DisconnectDatabase()
            End Try

        End If

    End Sub


    Protected Sub RecoveryChangePassword_Click(sender As Object, e As EventArgs) Handles RecoveryChangePassword.Click

        Try

            Dim HashedPassword As String
            Dim EncodeMe As String = RecoveryConfirmPassword.Text
            HashedPassword = getSHA512Hash(EncodeMe)
            ConnectDatabase()

            If RecoveryPassword.Text = "" And Not RecoveryConfirmPassword.Text = "" Or Not ModifyPassword.Text = "" And ModifyConfirmPassword.Text = "" Then
                MessageBox.Show(Me, "Password do not match! Kindly reconfirm your passwordto change it, or Click cancel!")

            ElseIf RecoveryPassword.Text = "" And RecoveryConfirmPassword.Text = "" Then
                MessageBox.Show(Me, "None of the Password field can be left blank!")

            ElseIf ModifyPassword.Text = ModifyConfirmPassword.Text Then
                Dim strSQL As String
                strSQL = "UPDATE company SET password='" & HashedPassword & "' WHERE username='" & RecoverySelectUser.SelectedItem.Text & "' AND ID='" & RecoveryUserID.Text & "'"
                Dim cmd As New MySqlCommand(strSQL, conn)
                cmd.ExecuteNonQuery()

            End If

            'Log user activity
            Dim Activity As String = Session("LoggedInAdminLoginUsername") & " changed password for " & RecoverySearchName.Text
            Dim com As New MySqlCommand
            com.Connection = conn
            com.CommandText = "INSERT INTO userlog (activity,IPAddress,machineName,deviceType,browserName,logdate,logtime) VALUES ('" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "')"
            com.ExecuteNonQuery()
            MessageBox.Show(Me, "User Account Updated Successfully!")

            Response.AppendHeader("Refresh", "0;url=./#password-recovery")

        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)

        Finally
            DisconnectDatabase()

        End Try


    End Sub


    Protected Sub RecoveryDelete_Click(sender As Object, e As EventArgs) Handles RecoveryDelete.Click

        If RecoverySelectUser.SelectedItem.Text = "" Or RecoverySelectUser.SelectedItem.Text = "---Select User to modify its account ---" Then
            MessageBox.Show(Me, "No User Account Has been Selected")
        Else

            Try

                ConnectDatabase()

                'Dim cmd As New MySqlCommand

                'cmd.Connection = conn
                'cmd.CommandText = "DELETE FROM company WHERE ID='" & RecoveryUserID.Text & "' AND username='" & RecoverySelectUser.SelectedItem.Text & "'"
                'cmd.ExecuteNonQuery()

                Try
                    Dim Activity As String = Session("LoggedInAdminLoginUsername") & " attempt to delete" & RecoverySelectUser.SelectedItem.Text
                    Dim com As New MySqlCommand
                    com.Connection = conn
                    com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                    com.ExecuteNonQuery()
                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                End Try
                MessageBox.Show(Me, "User / Company Account was not programmed to be deleted!")
                Response.AppendHeader("Refresh", "0;url=./#password-recovery")
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()

            End Try

        End If

    End Sub


    Protected Sub SelectRecipient_SelectedIndexChanging(sender As Object, e As EventArgs)
        If Not RecipientName.SelectedItem.Text = "...Select All Registered Users..." Then
            RecipientEmailAddresses.Text = RecipientName.SelectedValue

        Else
            Try
                ConnectDatabase()

                Dim db As String = "SELECT companyEmail FROM company"

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)
                        'Get the list of rows needed into Session, so as to enable us retreive it later
                        Dim ds As New DataSet()
                        da.Fill(ds)

                        For Each Row As DataRow In ds.Tables(0).Rows
                            RecipientEmailAddresses.Text += ";" + (Row("companyEmail"))
                        Next
                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
            End Try
        End If


    End Sub


    Protected Sub SendEmail_Click(sender As Object, e As EventArgs) Handles SendEmail.Click

        Dim SenderEmailAddress = ""

        If Not SenderEmail.Text = "" And SenderEmail.Text.Contains("@") Then
            SenderEmailAddress = SenderEmail.Text
        Else
            SenderEmailAddress = AdminEmail()
        End If
        Try
            Dim Message = EmailMessageBody.Text
            'Dim Message = "Your Instrument Registered with Federal Ministry of Industry, Trade and Investment Weights and Measures Department Web Portal is due for renewal, an invoice is hereby been generated. <div style=''><p> Find below the details of transaction:<p> <strong> Reference Number: </strong>" + ReferenceNumber + "<p> <strong> Company Name: </strong>" + UserNameOfCompany + "<p> <strong> Sector: </strong>" + Sector + "<p> <strong> Instrument Category: </strong>" + Instrument + "  <p> <strong> Instrument: </strong>" + InstrumentType + "<p> <strong> Model Name: </strong>" + ModelName + "<p> <strong> Model Number: </strong>" + SerialNo + "  <p> <strong> Measurement Range: </strong>" + MeasurementRang + " <p> <strong> Actual Measurement: </strong>" + ActualMeasure + "<p> <strong> Amount Due: </strong>" + TotalAmount + "<p> <strong> Registration Date: </strong>" + InstrumentDate + "    <p> Kindly click the button below to login to your account.<p style='margin-top:50px;'> <strong>Thank you.</strong>"
            Dim Subject = EmailSubject.Text
            Dim MessageBody = "<html><head></head><body style='font-family:Tahoma; width:620px;font-size:13px;background:rgb(240,240, 240)'><div style='width:600px;height:70px;padding:10px;color:rgb(255, 255, 255);font-weight:bolder;text-align:center;font-size:20px;background:rgb(54,127,169);'><img src='http://www.wmdnigeria.com/images/icon.png' width='70px' height='70px' align='left' style='margin-top:-10px;padding:0px;' /><p>Federal Ministry of Industry Trade and Investment <br><span style='font-size:17px;'>Weights and Measures Department</span></div><div style='width:600px;font-size:13px;color:rgb(100,100,100);'><p> <div style='padding-left:10px; width:590px;'> <div style='font-weight:bolder;font-size:17px;'>" + Subject + "</div><p>" & Message & "</div> <a href='http://www.wmdnigeria.com/' style='text-decoration:none;width:auto;'><div style='margin-top:40px;padding: 5px 10px;width:100px;font-size: 14px;font-weight: bolder;line-height: 20px;text-align: center;cursor: pointer;border: 1px solid transparent;border-radius: 4px;background:rgb(54,127,169);color:rgb(255, 255, 255);'>Login Now</div> </div>           <p><div style='margin-top:100px;width:600px;height:auto;padding:10px;color:rgb(255, 255, 255);text-align:center;font-size:13px;background:rgb(54,127,169);'><strong>NOTICE: </strong>  The content of this e-mail is intended solely for the use of the individual or entity to whom it is addressed. If you have received this communication in error, beware that forwarding it, copying it or in any way disclosing its content to any other person or persons, is strictly prohibiting. If you have received this communication in error, please notify the author by replying this e-mail immediately.</div></body></html>"
            clsNotify.SendEmail(RecipientEmailAddresses.Text, Subject, MessageBody, SenderEmailAddress, True)
        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)
        End Try
    End Sub

    Protected Sub SaveAPIConfiguration_Click(sender As Object, e As EventArgs) Handles SaveAPIConfiguration.Click
        If BulkSMSAccountPassword.Text = "" Or BulkSMSAccountUsername.Text = "" Or BulkSMSAPILink.Text = "" Or BulkSMSSecurityCode.Text = "" Then
            MessageBox.Show(Me, "No field can be left blank!")

        Else
            If BulkSMSSecurityCode.Text = My.Settings.BulkSMSSecurityCode Then

                Try

                    ConnectDatabase()

                    Dim MyAdapter As New MySqlDataAdapter

                    Dim SqlQuery = "SELECT * FROM smsapi LIMIT 1;"
                    Dim Command As New MySqlCommand
                    Command.Connection = conn
                    Command.CommandText = SqlQuery
                    MyAdapter.SelectCommand = Command
                    Dim reader As MySqlDataReader
                    reader = Command.ExecuteReader
                    'Check if the credentials provided is in the database
                    If reader.HasRows = 0 Then

                        reader.Close()
                        'Log user activity
                        Dim Activity As String = Session("LoggedInAdminLoginUsername") & " attempt to change the SMS API Configuration"
                        Dim com As New MySqlCommand
                        com.Connection = conn
                        com.CommandText = "INSERT INTO userlog (activity,IPAddress,machineName,deviceType,browserName,logdate,logtime) VALUES ('" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "')"
                        com.ExecuteNonQuery()

                        Dim coms As New MySqlCommand
                        coms.Connection = conn
                        coms.CommandText = "INSERT INTO smsapi (APIUsername,APIPassword,APILink) VALUES ('" & BulkSMSAccountUsername.Text & "','" & BulkSMSAccountPassword.Text & "','" & BulkSMSAPILink.Text & "')"
                        coms.ExecuteNonQuery()

                        MessageBox.Show(Me, "SMS API Configuration Settings saved successfully!")

                    Else
                        reader.Close()

                        Dim strSQL As String
                        strSQL = "UPDATE smsapi SET APIUsername='" & BulkSMSAccountUsername.Text & "',APIPassword='" & BulkSMSAccountPassword.Text & "',APILink='" & BulkSMSAPILink.Text & "'"
                        Dim cmd As New MySqlCommand(strSQL, conn)
                        cmd.ExecuteNonQuery()

                        MessageBox.Show(Me, "SMS API Configuration Settings saved successfully!")

                        Dim Activity As String = Session("LoggedInAdminLoginUsername") & " attempt to change the SMS API Configuration"
                        Dim com As New MySqlCommand
                        com.Connection = conn
                        com.CommandText = "INSERT INTO userlog (activity,IPAddress,machineName,deviceType,browserName,logdate,logtime) VALUES ('" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "')"
                        com.ExecuteNonQuery()

                    End If

                Catch ex As Exception

                    MessageBox.Show(Me, ex.Message)
                Finally
                    'After execution of mysql query, disconnect database
                    DisconnectDatabase()
                    Response.AppendHeader("Refresh", "0;url=./#api-configuration")
                End Try

            Else
                MessageBox.Show(Me, "The Security Code you entered is not correct")
            End If

        End If

    End Sub



    Protected Sub SelectSMSRecipient_SelectedIndexChanging(sender As Object, e As EventArgs)
        If Not SMSRecipients.SelectedItem.Text = "...Select All Registered Users..." Then
            SMSRecipientNumbers.Text = SMSRecipients.SelectedValue

        Else
            Try
                ConnectDatabase()

                Dim db As String = "SELECT companyPhoneNumber FROM company"

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)
                        'Get the list of rows needed into Session, so as to enable us retreive it later
                        Dim ds As New DataSet()
                        da.Fill(ds)

                        For Each Row As DataRow In ds.Tables(0).Rows
                            SMSRecipientNumbers.Text += "," + (Row("companyPhoneNumber"))
                        Next
                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
            End Try
        End If


    End Sub

    Protected Sub SendSMS_Click(sender As Object, e As EventArgs) Handles SendSMS.Click
        tools.SendSMS(Me, GetSMSAPI(), GetSMSUsername, GetSMSPassword, SenderName.Text, SMSRecipientNumbers.Text, SMSMessageBody.Text)
    End Sub


    'More code here .........................
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub



End Class