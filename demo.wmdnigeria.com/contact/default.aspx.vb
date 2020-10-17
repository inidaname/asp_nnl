Imports System
Imports System.Text
Imports System.Net.Mail
Imports System.Net
Imports System.Web
Imports System.Xml
Imports System.Data
Imports System.Web.Security
Imports System.Globalization
Imports System.Configuration
Imports MySql.Data.MySqlClient
Imports System.Collections.Generic
Imports System.Security.Cryptography
Imports System.Web.Script.Serialization


Public Class _default5
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
        ElseIf Session("Login") = True And Not Session("UserLoginUserType") = "CPI Inspector" And Not Session("UserLoginUserType") = "WMD Inspector" And Not Session("UserLoginUserType") = "Calibrator" And Not Session("UserLoginUserType") = "Authorized Verifier" Then
            WMDInspectorTools.Visible = False
            ToolBar.Visible = True
        End If

        'Display registered instrument data in data gridview 
        Try
            ConnectDatabase()

            Dim Status As Integer = 1

            Dim db As String = "SELECT * FROM statecontacts WHERE status='" & Status & "'"

            Using cn As MySqlCommand = New MySqlCommand(db, conn)
                Using da As New MySqlDataAdapter(cn)

                    'Get the list of rows needed into Session, so as to enable us retreive it later

                    Dim dt As New DataTable()
                    Dim ds As New DataSet()
                    da.Fill(dt)
                    da.Fill(ds, "statecontacts")

                    StateOfficesGrid.DataSource = ds
                    StateOfficesGrid.DataMember = "statecontacts"
                    StateOfficesGrid.DataBind()

                    Cache("StateOffices") = dt

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)
        End Try



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
        MessageBox.Show(Me, "Logout button is clicked!!!")

        If IsNothing(Session("Login")) Then

            Response.Redirect("../")
            MessageBox.Show(Me, "You are already on the login page, please login")
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

    Protected Sub SendMessage_Click(sender As Object, e As EventArgs) Handles SendMessage.Click

        'This is for contact us form
        Dim MessageBody = "<html><head></head><body style='font-family:Tahoma; width:620px;font-size:13px;background:rgb(240,240, 240)'><div style='width:600px;height:70px;padding:10px;color:rgb(255, 255, 255);font-weight:bolder;text-align:center;font-size:20px;background:rgb(54,127,169);'><img src='http://www.wmdnigeria.com/images/icon.png' width='70px' height='70px' align='left' style='margin-top:-10px;padding:0px;' /><p>Federal Ministry of Industry Trade and Investment <br><span style='font-size:17px;'>Weights and Measures Department</span></div><div style='width:600px;font-size:13px;color:rgb(100,100,100);'><p> <div style='padding-left:10px; width:590px;'> <div style='font-weight:bolder;font-size:17px;'>Contact Us Form :: " + Subject.Text + "</div><p>" & Message.Text & "</div> <a href='http://www.wmdnigeria.com/' style='text-decoration:none;width:auto;'><div style='margin-left:10px;margin-top:40px;padding: 5px 10px;width:100px;font-size: 14px;font-weight: bolder;line-height: 20px;text-align: center;cursor: pointer;border: 1px solid transparent;border-radius: 4px;background:rgb(54,127,169);color:rgb(255, 255, 255);'>Visit Website</div> </div>           <p><div style='margin-top:100px;width:600px;height:auto;padding:10px;color:rgb(255, 255, 255);text-align:center;font-size:13px;background:rgb(54,127,169);'><strong>NOTICE: </strong>  The content of this e-mail is intended solely for the use of the individual or entity to whom it is addressed. If you have received this communication in error, beware that forwarding it, copying it or in any way disclosing its content to any other person or persons, is strictly prohibiting. If you have received this communication in error, please notify the author by replying this e-mail immediately.</div></body></html>"

        Try
            clsNotify.SendEmail(EmailAddress.Text, Subject.Text, MessageBody, ContactEmail(), True)
            MessageBox.Show(Me, "Your message has been received successfully")

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)
        End Try

    End Sub

    Protected Sub ClearForm_Click(sender As Object, e As EventArgs) Handles ClearForm.Click
        Name.Text = ""
        EmailAddress.Text = ""
        PhoneNumber.Text = ""
        Subject.Text = ""
        Message.Text = ""
    End Sub

    Protected Sub StateOfficesGrid_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        StateOfficesGrid.PageIndex = e.NewPageIndex
        StateOfficesGrid.DataSource = CType(Cache("StateOffices"), DataTable)
        StateOfficesGrid.DataBind()
    End Sub

    Protected Sub ProfileIcon_Click(sender As Object, e As EventArgs) Handles ProfileIcon.Click
        Response.Redirect("../../profile/")
    End Sub

    Protected Sub InvoiceIcon_Click(sender As Object, e As EventArgs) Handles InvoiceIcon.Click
        Response.Redirect("../../invoice/")
    End Sub

    Protected Sub DepositIcon_Click(sender As Object, e As EventArgs) Handles DepositIcon.Click
        Response.Redirect("../../deposit/")
    End Sub

    Protected Sub UploadIcon_Click(sender As Object, e As EventArgs) Handles UploadIcon.Click
        Response.Redirect("../../upload/")
    End Sub

    Protected Sub InstrumentServicesIcon_Click(sender As Object, e As EventArgs) Handles InstrumentServicesicon.Click
        Response.Redirect("../../instrument-services/")
    End Sub

    Protected Sub RegisterInstrumentIcon_Click(sender As Object, e As EventArgs) Handles RegisterInstrumentIcon.Click
        Response.Redirect("../../register-instrument/")
    End Sub

    Protected Sub RequirementIcon_Click(sender As Object, e As EventArgs) Handles RequirementIcon.Click
        Response.Redirect("../../requirements/")
    End Sub

    Protected Sub ImportPermitIcon_Click(sender As Object, e As EventArgs) Handles ImportPermitIcon.Click
        'Response.Redirect("../../import-permit/")
    End Sub

    Protected Sub ExportPermitIcon_Click(sender As Object, e As EventArgs) Handles ExportPermitIcon.Click
        Response.Redirect("../../export-permit/")
    End Sub

    Protected Sub ReportsIcon_Click(sender As Object, e As EventArgs) Handles ReportIcon.Click
        Response.Redirect("../../reports/")
    End Sub


End Class