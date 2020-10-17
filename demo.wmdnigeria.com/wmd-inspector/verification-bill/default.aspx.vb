Imports System.Web
Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Data.OleDb
Imports System.Web.Security
Imports System.Configuration
Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Data.SqlClient

Public Class _default41
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Session("Login")) Or Not Session("Login") = "True" Then
            ProfileIcon.Visible = False
            Account.Text = "ACCOUNT"
            Logout.Text = "LOGIN"
            WMDInspectorTools.Visible = False
            HeaderPanel.Height = 110
            Response.Redirect("../")

            RegistrationPanel.Visible = True
        Else
            ProfileIcon.Visible = True
            Account.Text = Session("UserLoginName")
            Logout.Text = "LOGOUT"
            WMDInspectorTools.Visible = True

            RegistrationPanel.Visible = False

        End If

        Registration.Text = "REGISTER"

        If Session("Login") = True And Session("UserLoginUserType") = "WMD Inspector" Then

        ElseIf Session("Login") = True And Session("UserLoginUserType") = "CPI Inspector" Then
            Response.Redirect("../cpi-inspector/")

        ElseIf Session("Login") = True And Session("UserLoginUserType") = "Calibrator" Then
            Response.Redirect("../calibrator/")

        ElseIf Session("Login") = True And Session("UserLoginUserType") = "Authorized Verifier" Then
            Response.Redirect("../authorized-verifier/")

        Else
            Response.Redirect("../")
        End If

        If Not IsPostBack = True Then
            Session.Remove("Company")

            Try
                ConnectDatabase()

                'Dim db As String = "SELECT deviceType, concat(deviceType,' : SN ',serialNumber) As Instrument FROM deviceregistration WHERE CompanyID='" & Session("UserLoginID") & "'"
                Dim db As String = "SELECT C.ID,C.companyName,D.ID,D.companyID FROM company C, deviceRegistration D WHERE C.ID = D.companyID GROUP BY C.ID"
                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)

                        'Get the list of rows needed into Session, so as to enable us retreive it later
                        Dim dt As New DataTable()
                        da.Fill(dt)

                        CompanyName.DataSource = dt
                        CompanyName.DataTextField = "companyName"
                        CompanyName.DataValueField = "ID"
                        CompanyName.DataBind()
                        CompanyName.Items.Insert(0, "...Select Company...")

                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
            End Try



            Try
                ConnectDatabase()

                Dim db As String = "SELECT * FROM deviceregistration,deviceverification WHERE verificationSubmitedBy='" & Session("UserLoginID") & "'"
                'Dim db As String = "SELECT * FROM deviceregistration,deviceverification WHERE IN.verificationSubmitedBy='" & Session("UserLoginID") & "' AND DV.verificationSubmitedBy='" & Session("UserLoginID") & "' ORDER BY DV.ID DESC"
                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)

                        'Get the list of rows needed into Session, so as to enable us retreive it later

                        Dim dt As New DataTable()
                        Dim ds As New DataSet()
                        da.Fill(dt)
                        da.Fill(ds)

                        RegisteredInstrumentGridView.DataSource = ds
                        RegisteredInstrumentGridView.DataBind()
                        Cache.Remove("deviceverification")
                        Cache("deviceverification") = dt

                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            End Try

        End If


    End Sub


    Protected Sub RegisteredInstrumentGridView_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        RegisteredInstrumentGridView.PageIndex = e.NewPageIndex
        RegisteredInstrumentGridView.DataSource = CType(Cache("deviceregistration"), DataTable)
        RegisteredInstrumentGridView.DataBind()
    End Sub


    <System.Web.Script.Services.ScriptMethod(), System.Web.Services.WebMethod()>
    Public Shared Function SearchInstruments(ByVal prefixText As String, ByVal count As Integer) As List(Of String)
        ConnectDatabase()

        Dim Command As New MySqlCommand
        Command.CommandText = "SELECT serialNumber FROM deviceregistration WHERE  companyID='" & HttpContext.Current.Session("Company") & "' AND serialNumber LIKE @SearchText"
        Command.Parameters.AddWithValue("@SearchText", "%" + prefixText + "%")
        Command.Connection = conn
        Dim Instruments As List(Of String) = New List(Of String)
        Dim reader As MySqlDataReader = Command.ExecuteReader
        While reader.Read
            Instruments.Add(reader("serialNumber").ToString)
        End While
        DisconnectDatabase()
        Return Instruments


    End Function

    Protected Sub CompanyName_SelectedIndexedChanged(sender As Object, e As EventArgs) Handles CompanyName.SelectedIndexChanged
        Session.Add("Company", CompanyName.SelectedValue)
    End Sub



    Protected Sub SaveVerification_Click(sender As Object, e As EventArgs) Handles SaveVerification.Click

        If CompanyName.Text = "...Select Company..." Or SubmittedBy.Text = "" Or VerificationDuration.Text = "" Or Instruments.Text = "" Then
            MessageBox.Show(Me, "No field can be left blank, remember to select a Company")

        Else

            'Insert details into the database if file to upload meets our requirements

            Try
                ConnectDatabase()

                Dim db As String = "SELECT * FROM deviceregistration WHERE NOT verifiedBy='' AND NOT verificationDate='' AND NOT verificationComment='' AND NOT verificationSubmitedBy='' AND  companyID='" & CompanyName.SelectedValue & "' AND serialNumber='" & SearchInstrument.Text & "'"

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)

                        'Get the list of rows needed into Session, so as to enable us retreive it later

                        Dim dt As New DataTable()
                        Dim ds As New DataSet()
                        da.Fill(dt)
                        da.Fill(ds, "deviceregistration")

                        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                            Try
                                ConnectDatabase()

                                Dim cmd As New MySqlCommand
                                cmd.Connection = conn
                                cmd.CommandText = "UPDATE deviceregistration SET verifiedBy='" & SubmittedBy.Text & "',verificationDate='" & TodaysDate() & "',verificationComment='" & VerificationComment.Text & "',verificationSubmitedBy='" & Session("UserLoginID") & "' WHERE companyID='" & CompanyName.SelectedValue & "' AND serialNumber='" & SearchInstrument.Text & "'"
                                cmd.ExecuteNonQuery()
                                'This code do the loggin magic
                                Dim Activity As String = Session("UserLoginUsername") & " upload enforcement worksheet!"
                                Dim comm As New MySqlCommand
                                comm.Connection = conn
                                comm.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("UserLoginID") & "','" & Activity & "','" & Session("UserLoginIPAddress") & "','" & ComputerName() & "','" & osVersion() & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("UserLoginUserType") & "')"
                                comm.ExecuteNonQuery()

                                MessageBox.Show(Me, "You worksheet has been uploaded successfully! ")
                                DisconnectDatabase()
                            Catch ex As Exception
                                MessageBox.Show(Me, ex.Message)
                            End Try


                            MessageBox.Show(Me, "You have not select any file, please select file to upload.")
                            Response.AppendHeader("Refresh", "0;url=./")

                        Else

                            Try
                                ConnectDatabase()

                                Dim cmd As New MySqlCommand
                                cmd.Connection = conn
                                cmd.CommandText = "INSERT INTO deviceverification (companyID,serialNumber,verifiedBy,verificationDate,verificationComment,verificationSubmitedBy) VALUES ('" & CompanyName.SelectedValue & "','" & SearchInstrument.Text & "','" & SubmittedBy.Text & "','" & TodaysDate() & "','" & VerificationComment.Text & "','" & Session("UserLoginID") & "')"
                                cmd.ExecuteNonQuery()
                                'This code do the loggin magic
                                Dim Activity As String = Session("UserLoginUsername") & " upload enforcement worksheet!"
                                Dim comm As New MySqlCommand
                                comm.Connection = conn
                                comm.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("UserLoginID") & "','" & Activity & "','" & Session("UserLoginIPAddress") & "','" & ComputerName() & "','" & osVersion() & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("UserLoginUserType") & "')"
                                comm.ExecuteNonQuery()

                                MessageBox.Show(Me, "You worksheet has been uploaded successfully! ")
                                DisconnectDatabase()
                            Catch ex As Exception
                                MessageBox.Show(Me, ex.Message)
                            End Try


                            MessageBox.Show(Me, "You have not select any file, please select file to upload.")
                            Response.AppendHeader("Refresh", "0;url=./")
                        End If

                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            End Try


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
                com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("UserLoginID") & "','" & Activity & "','" & Session("UserLoginIPAddress") & "','" & osVersion() & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("UserLoginUserType") & "')"
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



    Protected Sub Inspection_Click(sender As Object, e As EventArgs) Handles Inspection.Click
        Response.Redirect("../inspection-worksheet/")
    End Sub

    Protected Sub VerificationBill_Click(sender As Object, e As EventArgs) Handles VerificationBill.Click
        Response.Redirect("./")
    End Sub



    Protected Sub Enforcement_Click(sender As Object, e As EventArgs) Handles Enforcement.Click
        Response.Redirect("../enforcement-worksheet/")
    End Sub


    Protected Sub Instrument_Click(sender As Object, e As EventArgs) Handles Instruments.Click
        Response.Redirect("../instruments/")
    End Sub

End Class