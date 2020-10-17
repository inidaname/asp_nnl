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

Public Class _default2


    Inherits System.Web.UI.Page
     
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Session("Login")) Then
            ProfileIcon.Visible = False
            Account.Text = "ACCOUNT"
            Logout.Text = "LOGIN"
            ToolBar.Visible = False
            WMDInspectorTools.Visible = False
            HeaderPanel.Height = 110
            RegistrationPanel.Visible = True
        Else
            Logout.Text = "LOGOUT"
            ProfileIcon.Visible = True
            Account.Text = Session("UserLoginName")
            RegistrationPanel.Visible = False


        End If


        If Session("Login") = True And Session("UserLoginUserType") = "WMD Inspector" Then
            WMDInspectorTools.Visible = True
            ToolBar.Visible = False
        ElseIf Session("Login") = True And Session("UserLoginUserType") = "CPI Inspector" Then

        ElseIf Session("Login") = True And Session("UserLoginUserType") = "Calibrator" Then

        ElseIf Session("Login") = True And Session("UserLoginUserType") = "Authorized Verifier" Then

        ElseIf Not Session("Login") = True And Not Session("UserLoginUserType") = "CPI Inspector" And Not Session("UserLoginUserType") = "WMD Inspector" And Not Session("UserLoginUserType") = "Calibrator" And Not Session("UserLoginUserType") = "Authorized Verifier" Then
            WMDInspectorTools.Visible = False
            ToolBar.Visible = False
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