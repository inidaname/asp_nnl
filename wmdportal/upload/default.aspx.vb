Imports System.Web
Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Data.OleDb
Imports System.Web.Security
Imports System.Configuration
Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Data.SqlClient          ' FOR "SqlBulkCopy" CLASS.

Public Class _default12
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
        FilterUpload.Focus()

        If Not IsPostBack = True Then
            PIAExportDataReturn.Visible = False
            ExportDataReturn.Visible = True

        End If



        Try
            ConnectDatabase()

            Dim db As String = "SELECT * FROM fileupload WHERE CompanyID='" & Session("UserLoginID") & "' ORDER BY ID DESC"

            Using cn As MySqlCommand = New MySqlCommand(db, conn)
                Using da As New MySqlDataAdapter(cn)

                    'Get the list of rows needed into Session, so as to enable us retreive it later

                    Dim dt As New DataTable()
                    Dim ds As New DataSet()
                    da.Fill(dt)
                    da.Fill(ds, "fileupload")

                    UploadGridView.DataSource = Nothing
                    UploadGridView.DataBind()

                    UploadGridView.DataSource = ds
                    UploadGridView.DataMember = "fileupload"
                    UploadGridView.DataBind()
                    Cache.Remove("FileDownloads")
                    Cache("FileDownloads") = dt

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)
        End Try

    End Sub

    Protected Sub DownloadGridView_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        UploadGridView.PageIndex = e.NewPageIndex
        UploadGridView.DataSource = CType(Cache("FileDownloads"), DataTable)
        UploadGridView.DataBind()

    End Sub

    Protected Sub Registration_Click(sender As Object, e As EventArgs) Handles Registration.Click
        If (Session("Login")) Or (Session("Login")) = "True" Then
            Response.Redirect("../registration/")
            Logout_Click(sender, New EventArgs)

        Else
            Response.Redirect("../registration/")
        End If
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

    Dim UploadPath As String = HttpContext.Current.Request.PhysicalApplicationPath & "File Manager\UploadFiles\"
    Dim ExportMonth As String = ""


    Protected Sub UploadFile_Click(sender As Object, e As EventArgs) Handles UploadFile.Click

        If FileDescription.Text = "" Then
            MessageBox.Show(Me, "No field can be left Blank")

        Else

            If FileUpload.HasFile Then
                Dim fileExt As String
                fileExt = System.IO.Path.GetExtension(FileUpload.FileName)

                If (fileExt = ".pdf" Or fileExt = ".doc" Or fileExt = ".docx" Or fileExt = ".xls" Or fileExt = ".xlsx" Or fileExt = ".jpg" Or fileExt = ".png" Or fileExt = ".jpeg" Or fileExt = ".bmp" Or fileExt = ".txt" Or fileExt = ".ppt") Then
                    Try

                        Dim ContentType As String
                        ContentType = "File name: " & _
                          FileUpload.PostedFile.FileName & "<br>" & _
                          "File Size: " & _
                          FileUpload.PostedFile.ContentLength & " kb<br>" & _
                          "Content type: " & _
                          FileUpload.PostedFile.ContentType

                        Dim NewExtention = fileExt.Replace(".", "")

                        'Insert details into the database if file to upload meets our requirements
                        Try
                            FileUpload.SaveAs(UploadPath & FileUpload.FileName)

                            'If UploadDocumentType.SelectedValue = "Other" Then

                            'ExportMonth = ""
                            'Else
                            'ExportMonth = MonthOfExport.Text

                            'End If

                            ConnectDatabase()
                            Dim cmd As New MySqlCommand
                            cmd.Connection = conn
                            cmd.CommandText = "INSERT INTO fileupload (companyID,fileName,description,uploadDate,uploadTime,fileType) VALUES('" & Session("UserLoginID") & "','" & FileUpload.FileName & "','" & FileDescription.Text & "','" & TodaysDate() & "','" & CurrentTim() & "','" & NewExtention & "')"
                            cmd.ExecuteNonQuery()
                            'This code do the loggin magic
                            Dim Activity As String = Session("UserLoginUsername") & " upload a file!"
                            Dim comm As New MySqlCommand
                            comm.Connection = conn
                            comm.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("UserLoginID") & "','" & Activity & "','" & Session("UserLoginIPAddress") & "','" & ComputerName() & "','" & osVersion() & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("UserLoginUserType") & "')"
                            comm.ExecuteNonQuery()

                            MessageBox.Show(Me, "You file has been uploaded successfully! " & fileExt)
                            DisconnectDatabase()
                        Catch ex As Exception
                            MessageBox.Show(Me, ex.Message)
                        End Try

                    Catch ex As Exception
                        MessageBox.Show(Me, "ERROR: " & ex.Message.ToString())
                        'MsgBox("ERROR: " & ex.Message.ToString())
                    End Try

                Else
                    MessageBox.Show(Me, "ERROR: File type not allowed! Contact Administrator for correct File Type")

                    'This code do the loggin magic
                    Dim Activity As String = Session("UserLoginUsername") & " tried to upload an unacceptable file!"
                    Dim comm As New MySqlCommand
                    comm.Connection = conn
                    comm.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("UserLoginID") & "','" & Activity & "','" & Session("UserLoginIPAddress") & "','" & ComputerName() & "','" & osVersion() & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("UserLoginUserType") & "')"
                    comm.ExecuteNonQuery()
                End If
            Else
                MessageBox.Show(Me, "You have not select any file, please select file to upload.")
            End If
            Response.AppendHeader("Refresh", "0;url=./")
        End If
    End Sub

    Protected Sub OnUploadViewActionClicked(sender As Object, e As EventArgs)
        Dim File As String = UploadGridView.SelectedRow.Cells(0).Text
        Dim FileName = ""
        Try
            ConnectDatabase()

            Dim db As String = "SELECT fileName FROM fileupload WHERE CompanyID='" & Session("UserLoginID") & "' AND fileName='" & File & "'"

            Using cn As MySqlCommand = New MySqlCommand(db, conn)
                Using da As New MySqlDataAdapter(cn)

                    'Get the list of rows needed into Session, so as to enable us retreive it later

                    Dim dt As New DataTable()
                    Dim ds As New DataSet()
                    da.Fill(dt)
                    da.Fill(ds, "fileupload")
                    FileName = ds.Tables(0).Rows(0).Item("fileName").ToString
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)
        Finally
            DisconnectDatabase()
            Response.Redirect("../File Manager\UploadFiles\" & FileName)
        End Try

    End Sub

    Protected Sub FilterUploadButton_Click(sender As Object, e As EventArgs) Handles FilterUploadButton.Click
        If Not FilterUpload.Text = "" Then
            Try
                ConnectDatabase()

                Dim db As String = "SELECT * FROM fileupload WHERE CompanyID='" & Session("UserLoginID") & "' AND description LIKE '%" & FilterUpload.Text & "%' ORDER BY ID DESC"

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)
                        Dim ds As New DataSet()
                        da.Fill(ds, "fileupload")

                        UploadGridView.DataSource = Nothing
                        UploadGridView.DataBind()

                        UploadGridView.DataSource = ds
                        UploadGridView.DataMember = "fileupload"
                        UploadGridView.DataBind()
                        Cache.Remove("FileDownloads")
                        Cache("FileDownloads") = ds

                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            End Try
        End If
    End Sub

    Protected Sub CancelUpload_Click(sender As Object, e As EventArgs) Handles CancelUpload.Click
        Response.Redirect("./", True)
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

End Class