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

Public Class _default35
    Inherits System.Web.UI.Page

    Dim ArticleTitle As String
    Dim Status = "1"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
 
        If IsNothing(Session("Login")) Then
            ProfileIcon.Visible = False
            Account.Text = "ACCOUNT"
            Logout.Text = "LOGIN"
            ToolBar.Visible = False
            HeaderPanel.Height = 110
            RegistrationPanel.Visible = True
        Else
            Logout.Text = "LOGOUT"
            ProfileIcon.Visible = True
            Account.Text = Session("UserLoginName")
            ToolBar.Visible = True

            RegistrationPanel.Visible = False

        End If

        If Not IsPostBack Then
            Try
                'Select the First News

                Dim db As String = "SELECT ID,articleGroup FROM article WHERE status='" & Status & "' GROUP  BY articleGroup"
                'Dim db As String = "SELECT TOP 1 * FROM article WHERE status='" & ArticleStatus & "' ORDER BY NEWID()"

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)

                        Dim dt As New DataTable
                        da.Fill(dt)
                        GetAllNewsGroup.DataSource = dt
                        GetAllNewsGroup.DataBind()
                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)

            End Try


            If Not String.IsNullOrEmpty(Request.QueryString("article-id")) Then
                ' Access the value LinkReportType
                Dim ArticleID = Request.QueryString("article-id")
                Try
                    ConnectDatabase()

                    'Select the First News
                    Dim db As String = "SELECT * FROM article WHERE ID='" & ArticleID & "' AND status='" & Status & "'"
                    'Dim db As String = "SELECT TOP 1 * FROM article WHERE status='" & ArticleStatus & "' ORDER BY NEWID()"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)

                            Dim ds As New DataSet
                            da.Fill(ds)

                            GetNewsInDetail.DataSource = ds
                            GetNewsInDetail.DataBind()

                        End Using
                    End Using

                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message)
                    'Response.Redirect("./")
                End Try

            Else


                Try
                    ConnectDatabase()

                     'Select the First News
                    Dim db As String = "SELECT * FROM article WHERE status='" & Status & "' ORDER BY RAND() LIMIT 1"
                    'Dim db As String = "SELECT TOP 1 * FROM article WHERE status='" & ArticleStatus & "' ORDER BY NEWID()"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)

                            Dim dt As New DataTable
                            da.Fill(dt)
                            Dim ds As New DataSet
                            da.Fill(ds)
                            GetNewsInDetail.DataSource = ds
                            GetNewsInDetail.DataBind()

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
                Dim Activity As String = "User logged out!"
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