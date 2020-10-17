Imports System.Web
Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Data.OleDb
Imports System.Web.Security
Imports System.Configuration
Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography

Public Class _default22
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
        End If



        If Not IsPostBack Then
            Try
                NoRecord.Visible = False
                ProcessingData.Visible = False

                ConnectDatabase()

                Dim db As String = "SELECT * FROM fileupload"

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)

                        'Get the list of rows needed into Session, so as to enable us retreive it later

                        Dim dt As New DataTable()
                        Dim ds As New DataSet()
                        da.Fill(dt)
                        da.Fill(ds, "fileupload")

                        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                            NoRecord.Visible = True
                        Else
                            NoRecord.Visible = False
                        End If

                        Dim FilesName = ds.Tables(0).Rows(0).Item("fileName").ToString
                        Dim FileDiscription = ds.Tables(0).Rows(0).Item("description").ToString
                        Dim CompanyID = ds.Tables(0).Rows(0).Item("companyID").ToString
                        Dim DocumentType = ds.Tables(0).Rows(0).Item("documentType").ToString

                        DownloadGridView.DataSource = ds
                        DownloadGridView.DataBind()
                        Cache("FileDownloads") = dt



                    End Using
                End Using
           
                Dim dbu As String = "SELECT * FROM company"

                Using cnu As MySqlCommand = New MySqlCommand(dbu, conn)
                    Using dau As New MySqlDataAdapter(cnu)
                        'Fill data of logged in user into dataset

                        'Get the list of rows needed into Session, so as to enable us retreive it later
                        Dim dt As New DataTable
                        dau.Fill(dt)

                        SelectCompany.DataSource = dt
                        SelectCompany.DataTextField = "companyName"
                        SelectCompany.DataValueField = "ID"
                        SelectCompany.DataBind()
                        SelectCompany.Items.Insert(0, "All Documents")

                    End Using
                End Using
            Catch ex As Exception
             Finally
                DisconnectDatabase()
            End Try

        End If


    End Sub


    Protected Sub DownloadGridView_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        DownloadGridView.PageIndex = e.NewPageIndex
        DownloadGridView.DataSource = CType(Cache("FileDownloads"), DataTable)
        DownloadGridView.DataBind()

    End Sub


    Protected Sub SelectCompany_SelectedIndexChanged(sender As Object, e As EventArgs)

        SelectFileGroup.ClearSelection()
        SelectFileGroup.Items.FindByText("Display All Group").Selected = True
        SelectFileType.ClearSelection()
        SelectFileType.Items.FindByText("All File Types").Selected = True

        DownloadGridView.DataSource = Nothing
        DownloadGridView.DataBind()

        If SelectCompany.SelectedItem.Text = "All Documents" Then
            Try
                ConnectDatabase()

                Dim db As String = "SELECT * FROM fileupload"

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)

                        'Get the list of rows needed into Session, so as to enable us retreive it later

                        Dim dt As New DataTable()
                        Dim ds As New DataSet()
                        da.Fill(dt)
                        da.Fill(ds, "fileupload")

                        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                            NoRecord.Visible = True
                        Else
                            NoRecord.Visible = False
                        End If

                        Dim FilesName = ds.Tables(0).Rows(0).Item("fileName").ToString
                        Dim FileDiscription = ds.Tables(0).Rows(0).Item("description").ToString
                        Dim CompanyID = ds.Tables(0).Rows(0).Item("companyID").ToString
                        Dim DocumentType = ds.Tables(0).Rows(0).Item("documentType").ToString

                        DownloadGridView.DataSource = Nothing
                        DownloadGridView.DataBind()

                        DownloadGridView.DataSource = ds
                        DownloadGridView.DataBind()
                        Cache("FileDownloads") = dt



                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
            End Try

        Else

            Try
                ConnectDatabase()

                Dim db As String = "SELECT * FROM fileupload WHERE CompanyID='" & SelectCompany.SelectedValue & "'"

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)

                        'Get the list of rows needed into Session, so as to enable us retreive it later

                        Dim dt As New DataTable()
                        Dim ds As New DataSet()
                        da.Fill(dt)
                        da.Fill(ds, "fileupload")

                        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                            NoRecord.Visible = True
                        Else
                            NoRecord.Visible = False
                        End If

                        Dim FilesName = ds.Tables(0).Rows(0).Item("fileName").ToString
                        Dim FileDiscription = ds.Tables(0).Rows(0).Item("description").ToString
                        Dim CompanyID = ds.Tables(0).Rows(0).Item("companyID").ToString
                        Dim DocumentType = ds.Tables(0).Rows(0).Item("documentType").ToString

                        DownloadGridView.DataSource = Nothing
                        DownloadGridView.DataBind()

                        DownloadGridView.DataSource = ds
                        DownloadGridView.DataBind()
                        Cache("FileDownloads") = dt



                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
            End Try

        End If


    End Sub



    Protected Sub SelectFileGroup_SelectedIndexChanged(sender As Object, e As EventArgs)

        DownloadGridView.DataSource = Nothing
        DownloadGridView.DataBind()

        SelectFileType.ClearSelection()
        SelectFileType.Items.FindByText("All File Types").Selected = True

        If SelectFileGroup.SelectedValue = "All Group" Then

            If SelectCompany.SelectedValue = "All Documents" Then
                Try
                    ConnectDatabase()

                    Dim db As String = "SELECT * FROM fileupload"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)

                            'Get the list of rows needed into Session, so as to enable us retreive it later

                            Dim dt As New DataTable()
                            Dim ds As New DataSet()
                            da.Fill(dt)
                            da.Fill(ds, "fileupload")

                            If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                NoRecord.Visible = True
                            Else
                                NoRecord.Visible = False
                            End If

                            Dim FilesName = ds.Tables(0).Rows(0).Item("fileName").ToString
                            Dim FileDiscription = ds.Tables(0).Rows(0).Item("description").ToString
                            Dim CompanyID = ds.Tables(0).Rows(0).Item("companyID").ToString
                            Dim DocumentType = ds.Tables(0).Rows(0).Item("documentType").ToString

                            DownloadGridView.DataSource = Nothing
                            DownloadGridView.DataBind()

                            DownloadGridView.DataSource = ds
                            DownloadGridView.DataBind()
                            Cache("FileDownloads") = dt



                        End Using
                    End Using
                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                Finally
                    DisconnectDatabase()
                End Try

            Else
                Try
                    ConnectDatabase()

                    Dim db As String = "SELECT * FROM fileupload WHERE CompanyID='" & SelectCompany.SelectedValue & "'"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)

                            'Get the list of rows needed into Session, so as to enable us retreive it later

                            Dim dt As New DataTable()
                            Dim ds As New DataSet()
                            da.Fill(dt)
                            da.Fill(ds, "fileupload")

                            If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                NoRecord.Visible = True
                            Else
                                NoRecord.Visible = False
                            End If

                            Dim FilesName = ds.Tables(0).Rows(0).Item("fileName").ToString
                            Dim FileDiscription = ds.Tables(0).Rows(0).Item("description").ToString
                            Dim CompanyID = ds.Tables(0).Rows(0).Item("companyID").ToString
                            Dim DocumentType = ds.Tables(0).Rows(0).Item("documentType").ToString

                            DownloadGridView.DataSource = Nothing
                            DownloadGridView.DataBind()

                            DownloadGridView.DataSource = ds
                            DownloadGridView.DataBind()
                            Cache("FileDownloads") = dt



                        End Using
                    End Using
                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                Finally
                    DisconnectDatabase()
                End Try


            End If


        ElseIf SelectFileGroup.SelectedItem.Value = "Export" Then


            If SelectCompany.SelectedValue = "All Documents" Then
                Try
                    ConnectDatabase()

                    Dim db As String = "SELECT * FROM fileupload WHERE documentType='" & SelectFileGroup.SelectedValue & "'"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)

                            'Get the list of rows needed into Session, so as to enable us retreive it later

                            Dim dt As New DataTable()
                            Dim ds As New DataSet()
                            da.Fill(dt)
                            da.Fill(ds, "fileupload")

                            If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                NoRecord.Visible = True
                            Else
                                NoRecord.Visible = False
                            End If

                            Dim FilesName = ds.Tables(0).Rows(0).Item("fileName").ToString
                            Dim FileDiscription = ds.Tables(0).Rows(0).Item("description").ToString
                            Dim CompanyID = ds.Tables(0).Rows(0).Item("companyID").ToString
                            Dim DocumentType = ds.Tables(0).Rows(0).Item("documentType").ToString

                            DownloadGridView.DataSource = Nothing
                            DownloadGridView.DataBind()

                            DownloadGridView.DataSource = ds
                            DownloadGridView.DataBind()
                            Cache("FileDownloads") = dt



                        End Using
                    End Using
                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                Finally
                    DisconnectDatabase()
                End Try

            Else
                Try
                    ConnectDatabase()

                    Dim db As String = "SELECT * FROM fileupload WHERE CompanyID='" & SelectCompany.SelectedValue & "' AND documentType='" & SelectFileGroup.SelectedValue & "'"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)

                            'Get the list of rows needed into Session, so as to enable us retreive it later

                            Dim dt As New DataTable()
                            Dim ds As New DataSet()
                            da.Fill(dt)
                            da.Fill(ds, "fileupload")

                            If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                NoRecord.Visible = True
                            Else
                                NoRecord.Visible = False
                            End If

                            Dim FilesName = ds.Tables(0).Rows(0).Item("fileName").ToString
                            Dim FileDiscription = ds.Tables(0).Rows(0).Item("description").ToString
                            Dim CompanyID = ds.Tables(0).Rows(0).Item("companyID").ToString
                            Dim DocumentType = ds.Tables(0).Rows(0).Item("documentType").ToString

                            DownloadGridView.DataSource = Nothing
                            DownloadGridView.DataBind()

                            DownloadGridView.DataSource = ds
                            DownloadGridView.DataBind()
                            Cache("FileDownloads") = dt



                        End Using
                    End Using
                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                Finally
                    DisconnectDatabase()
                End Try

            End If



        ElseIf SelectFileGroup.SelectedItem.Value = "PIA" Then

            If SelectCompany.SelectedValue = "All Documents" Then
                Try
                    ConnectDatabase()

                    Dim db As String = "SELECT * FROM fileupload WHERE documentType='" & SelectFileGroup.SelectedValue & "'"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)

                            'Get the list of rows needed into Session, so as to enable us retreive it later

                            Dim dt As New DataTable()
                            Dim ds As New DataSet()
                            da.Fill(dt)
                            da.Fill(ds, "fileupload")

                            If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                NoRecord.Visible = True
                            Else
                                NoRecord.Visible = False
                            End If

                            Dim FilesName = ds.Tables(0).Rows(0).Item("fileName").ToString
                            Dim FileDiscription = ds.Tables(0).Rows(0).Item("description").ToString
                            Dim CompanyID = ds.Tables(0).Rows(0).Item("companyID").ToString
                            Dim DocumentType = ds.Tables(0).Rows(0).Item("documentType").ToString

                            DownloadGridView.DataSource = Nothing
                            DownloadGridView.DataBind()

                            DownloadGridView.DataSource = ds
                            DownloadGridView.DataBind()
                            Cache("FileDownloads") = dt



                        End Using
                    End Using
                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                Finally
                    DisconnectDatabase()
                End Try

            Else
                Try
                    ConnectDatabase()

                    Dim db As String = "SELECT * FROM fileupload WHERE CompanyID='" & SelectCompany.SelectedValue & "' AND documentType='" & SelectFileGroup.SelectedValue & "'"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)

                            'Get the list of rows needed into Session, so as to enable us retreive it later

                            Dim dt As New DataTable()
                            Dim ds As New DataSet()
                            da.Fill(dt)
                            da.Fill(ds, "fileupload")

                            If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                NoRecord.Visible = True
                            Else
                                NoRecord.Visible = False
                            End If

                            Dim FilesName = ds.Tables(0).Rows(0).Item("fileName").ToString
                            Dim FileDiscription = ds.Tables(0).Rows(0).Item("description").ToString
                            Dim CompanyID = ds.Tables(0).Rows(0).Item("companyID").ToString
                            Dim DocumentType = ds.Tables(0).Rows(0).Item("documentType").ToString

                            DownloadGridView.DataSource = Nothing
                            DownloadGridView.DataBind()

                            DownloadGridView.DataSource = ds
                            DownloadGridView.DataBind()
                            Cache("FileDownloads") = dt



                        End Using
                    End Using
                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                Finally
                    DisconnectDatabase()
                End Try

            End If




        ElseIf SelectFileGroup.SelectedItem.Value = "Other" Then

            If SelectCompany.SelectedValue = "All Documents" Then
                Try
                    ConnectDatabase()

                    Dim db As String = "SELECT * FROM fileupload WHERE documentType='" & SelectFileGroup.SelectedValue & "'"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)

                            'Get the list of rows needed into Session, so as to enable us retreive it later

                            Dim dt As New DataTable()
                            Dim ds As New DataSet()
                            da.Fill(dt)
                            da.Fill(ds, "fileupload")

                            If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                NoRecord.Visible = True
                            Else
                                NoRecord.Visible = False
                            End If

                            Dim FilesName = ds.Tables(0).Rows(0).Item("fileName").ToString
                            Dim FileDiscription = ds.Tables(0).Rows(0).Item("description").ToString
                            Dim CompanyID = ds.Tables(0).Rows(0).Item("companyID").ToString
                            Dim DocumentType = ds.Tables(0).Rows(0).Item("documentType").ToString

                            DownloadGridView.DataSource = Nothing
                            DownloadGridView.DataBind()

                            DownloadGridView.DataSource = ds
                            DownloadGridView.DataBind()
                            Cache("FileDownloads") = dt



                        End Using
                    End Using
                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                Finally
                    DisconnectDatabase()
                End Try

            Else
                Try
                    ConnectDatabase()

                    Dim db As String = "SELECT * FROM fileupload WHERE CompanyID='" & SelectCompany.SelectedValue & "' AND documentType='" & SelectFileGroup.SelectedValue & "'"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)

                            'Get the list of rows needed into Session, so as to enable us retreive it later

                            Dim dt As New DataTable()
                            Dim ds As New DataSet()
                            da.Fill(dt)
                            da.Fill(ds, "fileupload")

                            If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                NoRecord.Visible = True
                            Else
                                NoRecord.Visible = False
                            End If

                            Dim FilesName = ds.Tables(0).Rows(0).Item("fileName").ToString
                            Dim FileDiscription = ds.Tables(0).Rows(0).Item("description").ToString
                            Dim CompanyID = ds.Tables(0).Rows(0).Item("companyID").ToString
                            Dim DocumentType = ds.Tables(0).Rows(0).Item("documentType").ToString

                            DownloadGridView.DataSource = Nothing
                            DownloadGridView.DataBind()

                            DownloadGridView.DataSource = ds
                            DownloadGridView.DataBind()
                            Cache("FileDownloads") = dt



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



    Protected Sub SelectFileType_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim DocType1 = "doc"
        Dim DocType2 = "docx"

        Dim ExcelType1 = "xls"
        Dim ExcelType2 = "xlsx"

        Dim PDFType = "pdf"

        Dim PowerPointType = "ppt"

        Dim PictureType1 = "jpg"
        Dim PictureType2 = "png"
        Dim PictureType3 = "jpeg"
        Dim PictureType4 = "bmp"

        Dim TextType = "txt"


        If SelectFileType.SelectedValue = "All Type" Then

            If SelectCompany.SelectedValue = "All Documents" And SelectFileGroup.SelectedValue = "All Group" Then
                DownloadGridView.DataSource = Nothing
                DownloadGridView.DataBind()
                Try
                    ConnectDatabase()

                    Dim db As String = "SELECT * FROM fileupload"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)

                            'Get the list of rows needed into Session, so as to enable us retreive it later

                            Dim dt As New DataTable()
                            Dim ds As New DataSet()
                            da.Fill(dt)
                            da.Fill(ds, "fileupload")

                            If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                NoRecord.Visible = True
                            Else
                                NoRecord.Visible = False
                            End If

                            Dim FilesName = ds.Tables(0).Rows(0).Item("fileName").ToString
                            Dim FileDiscription = ds.Tables(0).Rows(0).Item("description").ToString
                            Dim CompanyID = ds.Tables(0).Rows(0).Item("companyID").ToString
                            Dim DocumentType = ds.Tables(0).Rows(0).Item("documentType").ToString

                            DownloadGridView.DataSource = Nothing
                            DownloadGridView.DataBind()

                            DownloadGridView.DataSource = ds
                            DownloadGridView.DataBind()
                            Cache("FileDownloads") = dt



                        End Using
                    End Using
                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                Finally
                    DisconnectDatabase()
                End Try

            ElseIf SelectCompany.SelectedValue = "All Documents" And Not SelectFileGroup.SelectedValue = "All Group" Then
                DownloadGridView.DataSource = Nothing
                DownloadGridView.DataBind()
                Try
                    ConnectDatabase()

                    Dim db As String = "SELECT * FROM fileupload WHERE CompanyID='" & SelectCompany.SelectedValue & "'"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)

                            'Get the list of rows needed into Session, so as to enable us retreive it later

                            Dim dt As New DataTable()
                            Dim ds As New DataSet()
                            da.Fill(dt)
                            da.Fill(ds, "fileupload")

                            If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                NoRecord.Visible = True
                            Else
                                NoRecord.Visible = False
                            End If

                            Dim FilesName = ds.Tables(0).Rows(0).Item("fileName").ToString
                            Dim FileDiscription = ds.Tables(0).Rows(0).Item("description").ToString
                            Dim CompanyID = ds.Tables(0).Rows(0).Item("companyID").ToString
                            Dim DocumentType = ds.Tables(0).Rows(0).Item("documentType").ToString

                            DownloadGridView.DataSource = Nothing
                            DownloadGridView.DataBind()

                            DownloadGridView.DataSource = ds
                            DownloadGridView.DataBind()
                            Cache("FileDownloads") = dt



                        End Using
                    End Using
                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                Finally
                    DisconnectDatabase()
                End Try

            ElseIf Not SelectCompany.SelectedValue = "All Documents" And SelectFileGroup.SelectedValue = "All Group" Then
                DownloadGridView.DataSource = Nothing
                DownloadGridView.DataBind()

                Try
                    ConnectDatabase()

                    Dim db As String = "SELECT * FROM fileupload WHERE companyID='" & SelectCompany.SelectedValue & "'"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)

                            'Get the list of rows needed into Session, so as to enable us retreive it later

                            Dim dt As New DataTable()
                            Dim ds As New DataSet()
                            da.Fill(dt)
                            da.Fill(ds, "fileupload")

                            If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                NoRecord.Visible = True
                            Else
                                NoRecord.Visible = False
                            End If

                            Dim FilesName = ds.Tables(0).Rows(0).Item("fileName").ToString
                            Dim FileDiscription = ds.Tables(0).Rows(0).Item("description").ToString
                            Dim CompanyID = ds.Tables(0).Rows(0).Item("companyID").ToString
                            Dim DocumentType = ds.Tables(0).Rows(0).Item("documentType").ToString

                            DownloadGridView.DataSource = ds
                            DownloadGridView.DataBind()
                            Cache("FileDownloads") = dt



                        End Using
                    End Using
                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                Finally
                    DisconnectDatabase()
                End Try


            ElseIf Not SelectCompany.SelectedValue = "All Documents" And Not SelectFileGroup.SelectedValue = "All Group" Then
                DownloadGridView.DataSource = Nothing
                DownloadGridView.DataBind()

                Try
                    ConnectDatabase()

                    Dim db As String = "SELECT * FROM fileupload WHERE companyID='" & SelectCompany.SelectedValue & "' AND documentType='" & SelectFileGroup.SelectedValue & "'"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)

                            'Get the list of rows needed into Session, so as to enable us retreive it later

                            Dim dt As New DataTable()
                            Dim ds As New DataSet()
                            da.Fill(dt)
                            da.Fill(ds, "fileupload")

                            If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                NoRecord.Visible = True
                            Else
                                NoRecord.Visible = False
                            End If

                            Dim FilesName = ds.Tables(0).Rows(0).Item("fileName").ToString
                            Dim FileDiscription = ds.Tables(0).Rows(0).Item("description").ToString
                            Dim CompanyID = ds.Tables(0).Rows(0).Item("companyID").ToString
                            Dim DocumentType = ds.Tables(0).Rows(0).Item("documentType").ToString

                            DownloadGridView.DataSource = ds
                            DownloadGridView.DataBind()
                            Cache("FileDownloads") = dt



                        End Using
                    End Using
                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                Finally
                    DisconnectDatabase()
                End Try

            Else
                MessageBox.Show(Me, "You need to Select an a Company or File Group!")
                DownloadGridView.DataSource = Nothing
                DownloadGridView.DataBind()
            End If

            
            'This is for Microsoft Word Document
        ElseIf SelectFileType.SelectedValue = "doc" Then
            If SelectCompany.SelectedValue = "All Documents" And SelectFileGroup.SelectedValue = "All Group" Then

                DownloadGridView.DataSource = Nothing
                DownloadGridView.DataBind()
                Try
                    ConnectDatabase()

                   

                    Dim db As String = "SELECT * FROM fileupload WHERE fileType LIKE '%" & DocType1 & "%' OR fileType LIKE '%" & DocType2 & "%'"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)

                            'Get the list of rows needed into Session, so as to enable us retreive it later

                            Dim dt As New DataTable()
                            Dim ds As New DataSet()
                            da.Fill(dt)
                            da.Fill(ds, "fileupload")

                            If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                NoRecord.Visible = True
                            Else
                                NoRecord.Visible = False
                            End If

                            Dim FilesName = ds.Tables(0).Rows(0).Item("fileName").ToString
                            Dim FileDiscription = ds.Tables(0).Rows(0).Item("description").ToString
                            Dim CompanyID = ds.Tables(0).Rows(0).Item("companyID").ToString
                            Dim DocumentType = ds.Tables(0).Rows(0).Item("documentType").ToString

                            DownloadGridView.DataSource = ds
                            DownloadGridView.DataBind()
                            Cache("FileDownloads") = dt



                        End Using
                    End Using
                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                Finally
                    DisconnectDatabase()
                End Try

            ElseIf SelectCompany.SelectedValue = "All Documents" And Not SelectFileGroup.SelectedValue = "All Group" Then
                DownloadGridView.DataSource = Nothing
                DownloadGridView.DataBind()

                Try
                    ConnectDatabase()

                
                    Dim db As String = "SELECT * FROM fileupload WHERE CompanyID='" & SelectCompany.SelectedValue & "' AND fileType LIKE '%" & DocType1 & "%' OR fileType LIKE '%" & DocType2 & "%'"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)

                            'Get the list of rows needed into Session, so as to enable us retreive it later

                            Dim dt As New DataTable()
                            Dim ds As New DataSet()
                            da.Fill(dt)
                            da.Fill(ds, "fileupload")

                            If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                NoRecord.Visible = True
                            Else
                                NoRecord.Visible = False
                            End If

                            Dim FilesName = ds.Tables(0).Rows(0).Item("fileName").ToString
                            Dim FileDiscription = ds.Tables(0).Rows(0).Item("description").ToString
                            Dim CompanyID = ds.Tables(0).Rows(0).Item("companyID").ToString
                            Dim DocumentType = ds.Tables(0).Rows(0).Item("documentType").ToString

                            DownloadGridView.DataSource = ds
                            DownloadGridView.DataBind()
                            Cache("FileDownloads") = dt



                        End Using
                    End Using
                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                Finally
                    DisconnectDatabase()
                End Try

            ElseIf Not SelectCompany.SelectedValue = "All Documents" And SelectFileGroup.SelectedValue = "All Group" Then

                DownloadGridView.DataSource = Nothing
                DownloadGridView.DataBind()
                Try
                    ConnectDatabase()

                    Dim db As String = "SELECT * FROM fileupload WHERE companyID='" & SelectCompany.SelectedValue & "' AND fileType LIKE '%" & DocType1 & "%' OR fileType LIKE '%" & DocType2 & "%'"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)

                            'Get the list of rows needed into Session, so as to enable us retreive it later

                            Dim dt As New DataTable()
                            Dim ds As New DataSet()
                            da.Fill(dt)
                            da.Fill(ds, "fileupload")

                            If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                NoRecord.Visible = True
                            Else
                                NoRecord.Visible = False
                            End If

                            Dim FilesName = ds.Tables(0).Rows(0).Item("fileName").ToString
                            Dim FileDiscription = ds.Tables(0).Rows(0).Item("description").ToString
                            Dim CompanyID = ds.Tables(0).Rows(0).Item("companyID").ToString
                            Dim DocumentType = ds.Tables(0).Rows(0).Item("documentType").ToString

                            DownloadGridView.DataSource = ds
                            DownloadGridView.DataBind()
                            Cache("FileDownloads") = dt



                        End Using
                    End Using
                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                Finally
                    DisconnectDatabase()
                End Try


            ElseIf Not SelectCompany.SelectedValue = "All Documents" And Not SelectFileGroup.SelectedValue = "All Group" Then

                DownloadGridView.DataSource = Nothing
                DownloadGridView.DataBind()
                Try
                    ConnectDatabase()
                  
                    Dim db As String = "SELECT * FROM fileupload WHERE companyID='" & SelectCompany.SelectedValue & "' AND documentType='" & SelectFileGroup.SelectedValue & "' AND fileType LIKE '%" & DocType1 & "%' OR fileType LIKE '%" & DocType2 & "%'"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)

                            'Get the list of rows needed into Session, so as to enable us retreive it later

                            Dim dt As New DataTable()
                            Dim ds As New DataSet()
                            da.Fill(dt)
                            da.Fill(ds, "fileupload")

                            If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                NoRecord.Visible = True
                            Else
                                NoRecord.Visible = False
                            End If

                            Dim FilesName = ds.Tables(0).Rows(0).Item("fileName").ToString
                            Dim FileDiscription = ds.Tables(0).Rows(0).Item("description").ToString
                            Dim CompanyID = ds.Tables(0).Rows(0).Item("companyID").ToString
                            Dim DocumentType = ds.Tables(0).Rows(0).Item("documentType").ToString

                            DownloadGridView.DataSource = ds
                            DownloadGridView.DataBind()
                            Cache("FileDownloads") = dt



                        End Using
                    End Using
                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                Finally
                    DisconnectDatabase()
                End Try
            End If















            'This is for PDF Document
        ElseIf SelectFileType.SelectedValue = "pdf" Then
            If SelectCompany.SelectedValue = "All Documents" And SelectFileGroup.SelectedValue = "All Group" Then

                DownloadGridView.DataSource = Nothing
                DownloadGridView.DataBind()
                Try
                    ConnectDatabase()



                    Dim db As String = "SELECT * FROM fileupload WHERE fileType LIKE '%" & PDFType & "%'"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)

                            'Get the list of rows needed into Session, so as to enable us retreive it later

                            Dim dt As New DataTable()
                            Dim ds As New DataSet()
                            da.Fill(dt)
                            da.Fill(ds, "fileupload")

                            If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                NoRecord.Visible = True
                            Else
                                NoRecord.Visible = False
                            End If

                            Dim FilesName = ds.Tables(0).Rows(0).Item("fileName").ToString
                            Dim FileDiscription = ds.Tables(0).Rows(0).Item("description").ToString
                            Dim CompanyID = ds.Tables(0).Rows(0).Item("companyID").ToString
                            Dim DocumentType = ds.Tables(0).Rows(0).Item("documentType").ToString

                            DownloadGridView.DataSource = ds
                            DownloadGridView.DataBind()
                            Cache("FileDownloads") = dt



                        End Using
                    End Using
                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                Finally
                    DisconnectDatabase()
                End Try

            ElseIf SelectCompany.SelectedValue = "All Documents" And Not SelectFileGroup.SelectedValue = "All Group" Then
                DownloadGridView.DataSource = Nothing
                DownloadGridView.DataBind()

                Try
                    ConnectDatabase()


                    Dim db As String = "SELECT * FROM fileupload WHERE CompanyID='" & SelectCompany.SelectedValue & "' AND fileType LIKE '%" & PDFType & "%'"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)

                            'Get the list of rows needed into Session, so as to enable us retreive it later

                            Dim dt As New DataTable()
                            Dim ds As New DataSet()
                            da.Fill(dt)
                            da.Fill(ds, "fileupload")

                            If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                NoRecord.Visible = True
                            Else
                                NoRecord.Visible = False
                            End If

                            Dim FilesName = ds.Tables(0).Rows(0).Item("fileName").ToString
                            Dim FileDiscription = ds.Tables(0).Rows(0).Item("description").ToString
                            Dim CompanyID = ds.Tables(0).Rows(0).Item("companyID").ToString
                            Dim DocumentType = ds.Tables(0).Rows(0).Item("documentType").ToString

                            DownloadGridView.DataSource = ds
                            DownloadGridView.DataBind()
                            Cache("FileDownloads") = dt



                        End Using
                    End Using
                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                Finally
                    DisconnectDatabase()
                End Try

            ElseIf Not SelectCompany.SelectedValue = "All Documents" And SelectFileGroup.SelectedValue = "All Group" Then

                DownloadGridView.DataSource = Nothing
                DownloadGridView.DataBind()
                Try
                    ConnectDatabase()

                    Dim db As String = "SELECT * FROM fileupload WHERE companyID='" & SelectCompany.SelectedValue & "' AND fileType LIKE '%" & PDFType & "%'"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)

                            'Get the list of rows needed into Session, so as to enable us retreive it later

                            Dim dt As New DataTable()
                            Dim ds As New DataSet()
                            da.Fill(dt)
                            da.Fill(ds, "fileupload")

                            If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                NoRecord.Visible = True
                            Else
                                NoRecord.Visible = False
                            End If

                            Dim FilesName = ds.Tables(0).Rows(0).Item("fileName").ToString
                            Dim FileDiscription = ds.Tables(0).Rows(0).Item("description").ToString
                            Dim CompanyID = ds.Tables(0).Rows(0).Item("companyID").ToString
                            Dim DocumentType = ds.Tables(0).Rows(0).Item("documentType").ToString

                            DownloadGridView.DataSource = ds
                            DownloadGridView.DataBind()
                            Cache("FileDownloads") = dt



                        End Using
                    End Using
                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                Finally
                    DisconnectDatabase()
                End Try


            ElseIf Not SelectCompany.SelectedValue = "All Documents" And Not SelectFileGroup.SelectedValue = "All Group" Then

                DownloadGridView.DataSource = Nothing
                DownloadGridView.DataBind()
                Try
                    ConnectDatabase()

                    Dim db As String = "SELECT * FROM fileupload WHERE companyID='" & SelectCompany.SelectedValue & "' AND documentType='" & SelectFileGroup.SelectedValue & "' AND fileType LIKE '%" & PDFType & "%'"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)

                            'Get the list of rows needed into Session, so as to enable us retreive it later

                            Dim dt As New DataTable()
                            Dim ds As New DataSet()
                            da.Fill(dt)
                            da.Fill(ds, "fileupload")

                            If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                NoRecord.Visible = True
                            Else
                                NoRecord.Visible = False
                            End If

                            Dim FilesName = ds.Tables(0).Rows(0).Item("fileName").ToString
                            Dim FileDiscription = ds.Tables(0).Rows(0).Item("description").ToString
                            Dim CompanyID = ds.Tables(0).Rows(0).Item("companyID").ToString
                            Dim DocumentType = ds.Tables(0).Rows(0).Item("documentType").ToString

                            DownloadGridView.DataSource = ds
                            DownloadGridView.DataBind()
                            Cache("FileDownloads") = dt



                        End Using
                    End Using
                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                Finally
                    DisconnectDatabase()
                End Try
            End If









            'This is for Microsoft Excel Document
        ElseIf SelectFileType.SelectedValue = "xls" Then
            If SelectCompany.SelectedValue = "All Documents" And SelectFileGroup.SelectedValue = "All Group" Then

                DownloadGridView.DataSource = Nothing
                DownloadGridView.DataBind()
                Try
                    ConnectDatabase()



                    Dim db As String = "SELECT * FROM fileupload WHERE fileType LIKE '%" & ExcelType1 & "%' OR fileType LIKE '%" & ExcelType2 & "%'"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)

                            'Get the list of rows needed into Session, so as to enable us retreive it later

                            Dim dt As New DataTable()
                            Dim ds As New DataSet()
                            da.Fill(dt)
                            da.Fill(ds, "fileupload")

                            If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                NoRecord.Visible = True
                            Else
                                NoRecord.Visible = False
                            End If

                            Dim FilesName = ds.Tables(0).Rows(0).Item("fileName").ToString
                            Dim FileDiscription = ds.Tables(0).Rows(0).Item("description").ToString
                            Dim CompanyID = ds.Tables(0).Rows(0).Item("companyID").ToString
                            Dim DocumentType = ds.Tables(0).Rows(0).Item("documentType").ToString

                            DownloadGridView.DataSource = ds
                            DownloadGridView.DataBind()
                            Cache("FileDownloads") = dt



                        End Using
                    End Using
                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                Finally
                    DisconnectDatabase()
                End Try

            ElseIf SelectCompany.SelectedValue = "All Documents" And Not SelectFileGroup.SelectedValue = "All Group" Then
                DownloadGridView.DataSource = Nothing
                DownloadGridView.DataBind()

                Try
                    ConnectDatabase()


                    Dim db As String = "SELECT * FROM fileupload WHERE CompanyID='" & SelectCompany.SelectedValue & "' AND fileType LIKE '%" & ExcelType1 & "%' OR fileType LIKE '%" & ExcelType2 & "%'"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)

                            'Get the list of rows needed into Session, so as to enable us retreive it later

                            Dim dt As New DataTable()
                            Dim ds As New DataSet()
                            da.Fill(dt)
                            da.Fill(ds, "fileupload")

                            If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                NoRecord.Visible = True
                            Else
                                NoRecord.Visible = False
                            End If

                            Dim FilesName = ds.Tables(0).Rows(0).Item("fileName").ToString
                            Dim FileDiscription = ds.Tables(0).Rows(0).Item("description").ToString
                            Dim CompanyID = ds.Tables(0).Rows(0).Item("companyID").ToString
                            Dim DocumentType = ds.Tables(0).Rows(0).Item("documentType").ToString

                            DownloadGridView.DataSource = ds
                            DownloadGridView.DataBind()
                            Cache("FileDownloads") = dt



                        End Using
                    End Using
                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                Finally
                    DisconnectDatabase()
                End Try

            ElseIf Not SelectCompany.SelectedValue = "All Documents" And SelectFileGroup.SelectedValue = "All Group" Then

                DownloadGridView.DataSource = Nothing
                DownloadGridView.DataBind()
                Try
                    ConnectDatabase()

                    Dim db As String = "SELECT * FROM fileupload WHERE companyID='" & SelectCompany.SelectedValue & "' AND fileType LIKE '%" & ExcelType1 & "%' OR fileType LIKE '%" & ExcelType2 & "%'"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)

                            'Get the list of rows needed into Session, so as to enable us retreive it later

                            Dim dt As New DataTable()
                            Dim ds As New DataSet()
                            da.Fill(dt)
                            da.Fill(ds, "fileupload")

                            If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                NoRecord.Visible = True
                            Else
                                NoRecord.Visible = False
                            End If

                            Dim FilesName = ds.Tables(0).Rows(0).Item("fileName").ToString
                            Dim FileDiscription = ds.Tables(0).Rows(0).Item("description").ToString
                            Dim CompanyID = ds.Tables(0).Rows(0).Item("companyID").ToString
                            Dim DocumentType = ds.Tables(0).Rows(0).Item("documentType").ToString

                            DownloadGridView.DataSource = ds
                            DownloadGridView.DataBind()
                            Cache("FileDownloads") = dt



                        End Using
                    End Using
                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                Finally
                    DisconnectDatabase()
                End Try


            ElseIf Not SelectCompany.SelectedValue = "All Documents" And Not SelectFileGroup.SelectedValue = "All Group" Then

                DownloadGridView.DataSource = Nothing
                DownloadGridView.DataBind()
                Try
                    ConnectDatabase()

                    Dim db As String = "SELECT * FROM fileupload WHERE companyID='" & SelectCompany.SelectedValue & "' AND documentType='" & SelectFileGroup.SelectedValue & "' AND fileType LIKE '%" & ExcelType1 & "%' OR fileType LIKE '%" & ExcelType2 & "%'"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)

                            'Get the list of rows needed into Session, so as to enable us retreive it later

                            Dim dt As New DataTable()
                            Dim ds As New DataSet()
                            da.Fill(dt)
                            da.Fill(ds, "fileupload")

                            If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                NoRecord.Visible = True
                            Else
                                NoRecord.Visible = False
                            End If

                            Dim FilesName = ds.Tables(0).Rows(0).Item("fileName").ToString
                            Dim FileDiscription = ds.Tables(0).Rows(0).Item("description").ToString
                            Dim CompanyID = ds.Tables(0).Rows(0).Item("companyID").ToString
                            Dim DocumentType = ds.Tables(0).Rows(0).Item("documentType").ToString

                            DownloadGridView.DataSource = ds
                            DownloadGridView.DataBind()
                            Cache("FileDownloads") = dt



                        End Using
                    End Using
                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                Finally
                    DisconnectDatabase()
                End Try
            End If











            'This is for Power Point Document
        ElseIf SelectFileType.SelectedValue = "ppt" Then
            If SelectCompany.SelectedValue = "All Documents" And SelectFileGroup.SelectedValue = "All Group" Then

                DownloadGridView.DataSource = Nothing
                DownloadGridView.DataBind()
                Try
                    ConnectDatabase()



                    Dim db As String = "SELECT * FROM fileupload WHERE fileType LIKE '%" & PowerPointType & "%'"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)

                            'Get the list of rows needed into Session, so as to enable us retreive it later

                            Dim dt As New DataTable()
                            Dim ds As New DataSet()
                            da.Fill(dt)
                            da.Fill(ds, "fileupload")

                            If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                NoRecord.Visible = True
                            Else
                                NoRecord.Visible = False
                            End If

                            Dim FilesName = ds.Tables(0).Rows(0).Item("fileName").ToString
                            Dim FileDiscription = ds.Tables(0).Rows(0).Item("description").ToString
                            Dim CompanyID = ds.Tables(0).Rows(0).Item("companyID").ToString
                            Dim DocumentType = ds.Tables(0).Rows(0).Item("documentType").ToString

                            DownloadGridView.DataSource = ds
                            DownloadGridView.DataBind()
                            Cache("FileDownloads") = dt



                        End Using
                    End Using
                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                Finally
                    DisconnectDatabase()
                End Try

            ElseIf SelectCompany.SelectedValue = "All Documents" And Not SelectFileGroup.SelectedValue = "All Group" Then
                DownloadGridView.DataSource = Nothing
                DownloadGridView.DataBind()

                Try
                    ConnectDatabase()


                    Dim db As String = "SELECT * FROM fileupload WHERE CompanyID='" & SelectCompany.SelectedValue & "' AND fileType LIKE '%" & PowerPointType & "%'"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)

                            'Get the list of rows needed into Session, so as to enable us retreive it later

                            Dim dt As New DataTable()
                            Dim ds As New DataSet()
                            da.Fill(dt)
                            da.Fill(ds, "fileupload")

                            If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                NoRecord.Visible = True
                            Else
                                NoRecord.Visible = False
                            End If

                            Dim FilesName = ds.Tables(0).Rows(0).Item("fileName").ToString
                            Dim FileDiscription = ds.Tables(0).Rows(0).Item("description").ToString
                            Dim CompanyID = ds.Tables(0).Rows(0).Item("companyID").ToString
                            Dim DocumentType = ds.Tables(0).Rows(0).Item("documentType").ToString

                            DownloadGridView.DataSource = ds
                            DownloadGridView.DataBind()
                            Cache("FileDownloads") = dt



                        End Using
                    End Using
                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                Finally
                    DisconnectDatabase()
                End Try

            ElseIf Not SelectCompany.SelectedValue = "All Documents" And SelectFileGroup.SelectedValue = "All Group" Then

                DownloadGridView.DataSource = Nothing
                DownloadGridView.DataBind()
                Try
                    ConnectDatabase()

                    Dim db As String = "SELECT * FROM fileupload WHERE companyID='" & SelectCompany.SelectedValue & "' AND fileType LIKE '%" & PowerPointType & "%'"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)

                            'Get the list of rows needed into Session, so as to enable us retreive it later

                            Dim dt As New DataTable()
                            Dim ds As New DataSet()
                            da.Fill(dt)
                            da.Fill(ds, "fileupload")

                            If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                NoRecord.Visible = True
                            Else
                                NoRecord.Visible = False
                            End If

                            Dim FilesName = ds.Tables(0).Rows(0).Item("fileName").ToString
                            Dim FileDiscription = ds.Tables(0).Rows(0).Item("description").ToString
                            Dim CompanyID = ds.Tables(0).Rows(0).Item("companyID").ToString
                            Dim DocumentType = ds.Tables(0).Rows(0).Item("documentType").ToString

                            DownloadGridView.DataSource = ds
                            DownloadGridView.DataBind()
                            Cache("FileDownloads") = dt



                        End Using
                    End Using
                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                Finally
                    DisconnectDatabase()
                End Try


            ElseIf Not SelectCompany.SelectedValue = "All Documents" And Not SelectFileGroup.SelectedValue = "All Group" Then

                DownloadGridView.DataSource = Nothing
                DownloadGridView.DataBind()
                Try
                    ConnectDatabase()

                    Dim db As String = "SELECT * FROM fileupload WHERE companyID='" & SelectCompany.SelectedValue & "' AND documentType='" & SelectFileGroup.SelectedValue & "' AND fileType LIKE '%" & PowerPointType & "%'"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)

                            'Get the list of rows needed into Session, so as to enable us retreive it later

                            Dim dt As New DataTable()
                            Dim ds As New DataSet()
                            da.Fill(dt)
                            da.Fill(ds, "fileupload")

                            If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                NoRecord.Visible = True
                            Else
                                NoRecord.Visible = False
                            End If

                            Dim FilesName = ds.Tables(0).Rows(0).Item("fileName").ToString
                            Dim FileDiscription = ds.Tables(0).Rows(0).Item("description").ToString
                            Dim CompanyID = ds.Tables(0).Rows(0).Item("companyID").ToString
                            Dim DocumentType = ds.Tables(0).Rows(0).Item("documentType").ToString

                            DownloadGridView.DataSource = ds
                            DownloadGridView.DataBind()
                            Cache("FileDownloads") = dt



                        End Using
                    End Using
                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                Finally
                    DisconnectDatabase()
                End Try
            End If









            'This is for Picture Document
        ElseIf SelectFileType.SelectedValue = "png" Then
            If SelectCompany.SelectedValue = "All Documents" And SelectFileGroup.SelectedValue = "All Group" Then

                DownloadGridView.DataSource = Nothing
                DownloadGridView.DataBind()
                Try
                    ConnectDatabase()



                    Dim db As String = "SELECT * FROM fileupload WHERE fileType LIKE '%" & PictureType1 & "%' OR fileType LIKE '%" & PictureType2 & "%' OR fileType LIKE '%" & PictureType3 & "%' OR fileType LIKE '%" & PictureType4 & "%'"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)

                            'Get the list of rows needed into Session, so as to enable us retreive it later

                            Dim dt As New DataTable()
                            Dim ds As New DataSet()
                            da.Fill(dt)
                            da.Fill(ds, "fileupload")

                            If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                NoRecord.Visible = True
                            Else
                                NoRecord.Visible = False
                            End If

                            Dim FilesName = ds.Tables(0).Rows(0).Item("fileName").ToString
                            Dim FileDiscription = ds.Tables(0).Rows(0).Item("description").ToString
                            Dim CompanyID = ds.Tables(0).Rows(0).Item("companyID").ToString
                            Dim DocumentType = ds.Tables(0).Rows(0).Item("documentType").ToString

                            DownloadGridView.DataSource = ds
                            DownloadGridView.DataBind()
                            Cache("FileDownloads") = dt



                        End Using
                    End Using
                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                Finally
                    DisconnectDatabase()
                End Try

            ElseIf SelectCompany.SelectedValue = "All Documents" And Not SelectFileGroup.SelectedValue = "All Group" Then
                DownloadGridView.DataSource = Nothing
                DownloadGridView.DataBind()

                Try
                    ConnectDatabase()


                    Dim db As String = "SELECT * FROM fileupload WHERE CompanyID='" & SelectCompany.SelectedValue & "' AND fileType LIKE '%" & PictureType1 & "%' OR fileType LIKE '%" & PictureType2 & "%' OR fileType LIKE '%" & PictureType3 & "%' OR fileType LIKE '%" & PictureType4 & "%'"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)

                            'Get the list of rows needed into Session, so as to enable us retreive it later

                            Dim dt As New DataTable()
                            Dim ds As New DataSet()
                            da.Fill(dt)
                            da.Fill(ds, "fileupload")

                            If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                NoRecord.Visible = True
                            Else
                                NoRecord.Visible = False
                            End If

                            Dim FilesName = ds.Tables(0).Rows(0).Item("fileName").ToString
                            Dim FileDiscription = ds.Tables(0).Rows(0).Item("description").ToString
                            Dim CompanyID = ds.Tables(0).Rows(0).Item("companyID").ToString
                            Dim DocumentType = ds.Tables(0).Rows(0).Item("documentType").ToString

                            DownloadGridView.DataSource = ds
                            DownloadGridView.DataBind()
                            Cache("FileDownloads") = dt



                        End Using
                    End Using
                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                Finally
                    DisconnectDatabase()
                End Try

            ElseIf Not SelectCompany.SelectedValue = "All Documents" And SelectFileGroup.SelectedValue = "All Group" Then

                DownloadGridView.DataSource = Nothing
                DownloadGridView.DataBind()
                Try
                    ConnectDatabase()

                    Dim db As String = "SELECT * FROM fileupload WHERE companyID='" & SelectCompany.SelectedValue & "' AND fileType LIKE '%" & PictureType1 & "%' OR fileType LIKE '%" & PictureType2 & "%' OR fileType LIKE '%" & PictureType3 & "%' OR fileType LIKE '%" & PictureType4 & "%'"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)

                            'Get the list of rows needed into Session, so as to enable us retreive it later

                            Dim dt As New DataTable()
                            Dim ds As New DataSet()
                            da.Fill(dt)
                            da.Fill(ds, "fileupload")

                            If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                NoRecord.Visible = True
                            Else
                                NoRecord.Visible = False
                            End If

                            Dim FilesName = ds.Tables(0).Rows(0).Item("fileName").ToString
                            Dim FileDiscription = ds.Tables(0).Rows(0).Item("description").ToString
                            Dim CompanyID = ds.Tables(0).Rows(0).Item("companyID").ToString
                            Dim DocumentType = ds.Tables(0).Rows(0).Item("documentType").ToString

                            DownloadGridView.DataSource = ds
                            DownloadGridView.DataBind()
                            Cache("FileDownloads") = dt



                        End Using
                    End Using
                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                Finally
                    DisconnectDatabase()
                End Try


            ElseIf Not SelectCompany.SelectedValue = "All Documents" And Not SelectFileGroup.SelectedValue = "All Group" Then

                DownloadGridView.DataSource = Nothing
                DownloadGridView.DataBind()
                Try
                    ConnectDatabase()

                    Dim db As String = "SELECT * FROM fileupload WHERE companyID='" & SelectCompany.SelectedValue & "' AND documentType='" & SelectFileGroup.SelectedValue & "' AND fileType LIKE '%" & PictureType1 & "%' OR fileType LIKE '%" & PictureType2 & "%' OR fileType LIKE '%" & PictureType3 & "%' OR fileType LIKE '%" & PictureType4 & "%'"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)

                            'Get the list of rows needed into Session, so as to enable us retreive it later

                            Dim dt As New DataTable()
                            Dim ds As New DataSet()
                            da.Fill(dt)
                            da.Fill(ds, "fileupload")

                            If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                NoRecord.Visible = True
                            Else
                                NoRecord.Visible = False
                            End If

                            Dim FilesName = ds.Tables(0).Rows(0).Item("fileName").ToString
                            Dim FileDiscription = ds.Tables(0).Rows(0).Item("description").ToString
                            Dim CompanyID = ds.Tables(0).Rows(0).Item("companyID").ToString
                            Dim DocumentType = ds.Tables(0).Rows(0).Item("documentType").ToString

                            DownloadGridView.DataSource = ds
                            DownloadGridView.DataBind()
                            Cache("FileDownloads") = dt



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
            coms.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("UserLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
            coms.ExecuteNonQuery()

            Response.AppendHeader("Refresh", "0;url=./")
        Catch ex As Exception
        End Try
    End Sub


End Class