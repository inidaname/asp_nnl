Imports System.Web
Imports System.Data
Imports System.Text
Imports System.Web.Security
Imports System.Configuration
Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography

Public Class _default9
    Inherits System.Web.UI.Page

Dim ds As New DataSet

    Public OldPass As String
   
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

    'This populate state
        If Not IsPostBack Then
            Try
                ConnectDatabase()



                Dim dbu As String = "SELECT * FROM company WHERE username='" & Session("UserLoginName") & "' "

                Using cnu As MySqlCommand = New MySqlCommand(dbu, conn)
                    Using dau As New MySqlDataAdapter(cnu)
                        'Fill data of logged in user into dataset

                        'Get the list of rows needed into Session, so as to enable us retreive it later
                        Dim dtm As New DataTable
                        dau.Fill(dtm)
                        Dim dsm As New DataSet
                        dau.Fill(dsm)
                        Username.Text = dsm.Tables(0).Rows(0).Item("username").ToString
                        OldPass = dsm.Tables(0).Rows(0).Item("password").ToString
                        Dim CompanySecurityQuestion As String = dsm.Tables(0).Rows(0).Item("securityQuestions").ToString
                        'Populate Security Question and select user security question
                        'SecurityQuestion.SelectedItem.Text = CompanySecurityQuestion.ToString
                        SecurityQuestion.ClearSelection()
                        SecurityQuestion.Items.FindByValue(CompanySecurityQuestion).Selected = True
                        'Security Answe
                        'SecurityAnswer.Text = dsm.Tables(0).Rows(0).Item("securityAnswer").ToString
                        CompanyName.Text = dsm.Tables(0).Rows(0).Item("companyName").ToString
                        PhoneNumber.Text = dsm.Tables(0).Rows(0).Item("companyPhoneNumber").ToString
                        EmailAddress.Text = dsm.Tables(0).Rows(0).Item("companyEmail").ToString
                        Website.Text = dsm.Tables(0).Rows(0).Item("companyWebsite").ToString
                        FaxNumber.Text = dsm.Tables(0).Rows(0).Item("faxNumber").ToString
                        Representative.Text = dsm.Tables(0).Rows(0).Item("representativeName").ToString
                        Mobile.Text = dsm.Tables(0).Rows(0).Item("mobileNumber").ToString
                        RCNumber.Text = dsm.Tables(0).Rows(0).Item("RCNumber").ToString
                        RegisteredAddress.Text = dsm.Tables(0).Rows(0).Item("companyAddress").ToString
                        POBox.Text = dsm.Tables(0).Rows(0).Item("pobox").ToString


                        Dim CompanyState As String = dsm.Tables(0).Rows(0).Item("state").ToString
                        Dim CompanyLGA As String = dsm.Tables(0).Rows(0).Item("lga").ToString
                        Dim CompanyCity As String = dsm.Tables(0).Rows(0).Item("city").ToString

                        'Populate state and select Company state
                        Dim db As String = "SELECT * FROM state"

                        Using cn As MySqlCommand = New MySqlCommand(db, conn)
                            Using da As New MySqlDataAdapter(cn)
                                'Fill data of logged in user into dataset
                                Dim dt As New DataTable()
                                da.Fill(dt)
                                State.DataSource = dt
                                State.DataTextField = "state"
                                State.DataValueField = "ID"
                                State.DataBind()
                                State.Items.FindByText(CompanyState).Selected = True

                            End Using
                        End Using


                        'Populate Local Government and select the company local government
                        Dim dtl As New DataTable()

                        Dim dbl As String = "SELECT * FROM lga WHERE state = '" & State.SelectedItem.Text & "' ORDER BY lga"

                        Using cnl As MySqlCommand = New MySqlCommand(dbl, conn)
                            Using dal As New MySqlDataAdapter(cnl)
                                'Fill data of logged in user into dataset

                                dal.Fill(dtl)
                                LGA.DataSource = dtl
                                LGA.DataTextField = "lga"
                                LGA.DataValueField = "ID"
                                LGA.DataBind()
                                LGA.Items.FindByText(CompanyLGA).Selected = True


                            End Using
                        End Using

                        'Populate city and select the company city
                        Dim dtc As New DataTable()

                        Dim dbc As String = "SELECT * FROM city WHERE lga = '" & LGA.SelectedItem.Text & "' ORDER BY city"

                        Using cnc As MySqlCommand = New MySqlCommand(dbc, conn)
                            Using dac As New MySqlDataAdapter(cnc)
                                'Fill data of logged in user into dataset

                                dac.Fill(dtc)
                                City.DataSource = dtc
                                City.DataTextField = "city"
                                City.DataValueField = "ID"
                                City.DataBind()
                                City.Items.FindByText(CompanyCity).Selected = True


                            End Using
                        End Using

                        Dim FillerTite As String = dsm.Tables(0).Rows(0).Item("filledByTitle").ToString
                        'Populate Security Question and select user security question
                        'FillerTitle.SelectedItem.Text = FillerTite.ToString
                        FillerTitle.ClearSelection()
                        FillerTitle.Items.FindByText(FillerTite).Selected = True
                        Surname.Text = dsm.Tables(0).Rows(0).Item("filledBySurname").ToString
                        OtherNames.Text = dsm.Tables(0).Rows(0).Item("filledByOtherNames").ToString
                        FillerMobile.Text = dsm.Tables(0).Rows(0).Item("filledByMobile").ToString
                        FillerEmail.Text = dsm.Tables(0).Rows(0).Item("filledByEmail").ToString

                    End Using
                End Using

                'Trow errow is anything wrong with the code

            Catch ex As Exception

                MessageBox.Show(Me, ex.Message)

            Finally
                'After execution of mysql query, disconnect database
                DisconnectDatabase()
            End Try

        End If

End Sub

    Protected Sub Registration_Click(sender As Object, e As EventArgs) Handles Registration.Click
        Response.Redirect("../registration/")
        Logout_Click(sender, New EventArgs)

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

    Protected Sub Register_Click(sender As Object, e As EventArgs) Handles Register.Click

        If Not OldPassword.Text = Nothing Then
            Try

                Dim HashedPassword As String
                Dim EncodeMe As String = OldPassword.Text
                HashedPassword = getSHA512Hash(EncodeMe)

                ConnectDatabase()

                Dim MyAdapter As New MySqlDataAdapter

                Dim SqlQuery = "SELECT * FROM company WHERE username='" & Username.Text & "' AND password= '" & HashedPassword & "';"

                Dim Command As New MySqlCommand

                Command.Connection = conn

                Command.CommandText = SqlQuery

                MyAdapter.SelectCommand = Command

                Dim reader As MySqlDataReader
                reader = Command.ExecuteReader
                'Check if the credentials provided is in the database
                If reader.HasRows = 0 Then

                    'MessageBox.Show(Me, "Error Login in: Invalid username or password")
                    MessageBox.Show(Me, "Error: The Current Password you entered or Security Answer is incorrect!")
                    reader.Close()

                Else
                    reader.Close()
                    If NewPassword.Text = "" Or ConfirmPassword.Text = "" Or SecurityAnswer.Text = "" Then
                        MessageBox.Show(Me, "The New Password, Confirm Password and Security Answer Box cannot be left blank if you want to change your password!")

                    Else
                        If NewPassword.Text = ConfirmPassword.Text Then

                            If Username.Text = "" Or CompanyName.Text = "" Or PhoneNumber.Text = "" Or EmailAddress.Text = "" Or Representative.Text = "" Or Mobile.Text = "" Or RCNumber.Text = "" Or RegisteredAddress.Text = "" Or POBox.Text = "" Or FillerTitle.Text = "" Or Surname.Text = "" Or OtherNames.Text = "" Or FillerMobile.Text = "" Or FillerEmail.Text = "" Then
                                'If Username.Text = "" Or Password.Text = "" Or ConfirmPassword.Text = "" Or SecurityAnswer.Text = "" Or CompanyName.Text = "" Or PhoneNumber.Text = "" Or EmailAddress.Text = "" Or Representative.Text = "" Or Mobile.Text = "" Or RCNumber.Text = "" Or RegisteredAddress.Text = "" Or POBox.Text = "" Or State.Text = "" Or City.Text = "" Or LGA.Text = "" Or FillerTitle.Text = "" Or Surname.Text = "" Or OtherNames.Text = "" Or FillerMobile.Text = "" Or FillerEmail.Text = "" Then

                                MessageBox.Show(Me, "Error Submitting Application: All fields are required!")

                            Else

                                Try

                                    Dim HashedPasswordNew As String
                                    Dim EncodeMeNew As String = ConfirmPassword.Text
                                    HashedPasswordNew = getSHA512Hash(EncodeMeNew)
                                    ConnectDatabase()

                                    Dim cmd As New MySqlCommand

                                    cmd.Connection = conn
                                    cmd.CommandText = "UPDATE company SET password='" & HashedPasswordNew & "',securityQuestions='" & Me.SecurityQuestion.Text & "',securityAnswer='" & Me.SecurityAnswer.Text & "',companyName='" & Me.CompanyName.Text & "',companyPhoneNumber='" & Me.PhoneNumber.Text & "',companyEmail='" & Me.EmailAddress.Text & "',companyWebsite='" & Me.Website.Text & "',faxNumber='" & Me.FaxNumber.Text & "',representativeName='" & Me.Representative.Text & "',mobileNumber='" & Me.Mobile.Text & "',RCNumber='" & Me.RCNumber.Text & "',companyAddress='" & Me.RegisteredAddress.Text & "',pobox='" & Me.POBox.Text & "',state='" & Me.State.Text & "',city='" & Me.City.Text & "',lga='" & Me.LGA.Text & "',filledByTitle='" & Me.FillerTitle.Text & "',filledBySurname='" & Me.Surname.Text & "',filledByOtherNames='" & Me.OtherNames.Text & "',filledByMobile='" & Me.FillerMobile.Text & "',filledByEmail='" & Me.FillerEmail.Text & "' WHERE ID='" & Session("UserLoginID") & "'"

                                    cmd.ExecuteNonQuery()

                                    'This code do the loggin magic
                                    Dim Activity As String = "Update its Profile fetails!"
                                    Dim comm As New MySqlCommand
                                    comm.Connection = conn
                                    comm.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("UserLoginID") & "','" & Activity & "','" & Session("UserLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("UserLoginUserType") & "')"
                                    comm.ExecuteNonQuery()

                                    MessageBox.Show(Me, "Your account has been updated successfully and your password has been changed successfully, you can now re-login!")
                                Catch ex As Exception

                                    'MessageBox.Show(Me, ex.Message)
                                    MessageBox.Show(Me, ex.Message)
                                Finally
                                    DisconnectDatabase()

                                End Try
                            End If

                        Else
                            MessageBox.Show(Me, "New Password and Confirm Password Do not Match!")
                        End If
                    End If

                End If


            Catch ex As Exception
                MessageBox.Show(Me, "Database Connection Error: " & ex.Message)

            Finally
                DisconnectDatabase()
            End Try

        Else
            MessageBox.Show(Me, "Old Password Box is Empty!")
        End If


    End Sub

    Protected Sub State_SelectedIndexChanged(sender As Object, e As EventArgs) Handles State.SelectedIndexChanged


        'This populate state
        Try
            ConnectDatabase()



            Dim dbu As String = "SELECT lga FROM company WHERE username='" & Session("UserLoginName") & "'"

            Using cnu As MySqlCommand = New MySqlCommand(dbu, conn)
                Using dau As New MySqlDataAdapter(cnu)
                    'Fill data of logged in user into dataset

                    'Get the list of rows needed into Session, so as to enable us retreive it later

                    dau.Fill(ds)
                    Dim CompanyLGA As String = ds.Tables(0).Rows(0).Item("lga").ToString

                    'Get the list of rows needed into Session, so as to enable us retreive it later

                    Dim dt As New DataTable()

                    Dim db As String = "SELECT * FROM lga WHERE state = '" & State.SelectedItem.Text & "' ORDER BY lga"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)
                            'Fill data of logged in user into dataset

                            da.Fill(dt)
                            LGA.DataSource = dt
                            LGA.DataTextField = "lga"
                            LGA.DataValueField = "ID"
                            LGA.DataBind()
                            LGA.SelectedIndex = CompanyLGA


                        End Using
                    End Using

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

    Protected Sub LGA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LGA.SelectedIndexChanged
        MessageBox.Show(Me, "This is to populate city")

        Try
            ConnectDatabase()

            Dim db As String = "SELECT * FROM city WHERE lga = '" & LGA.SelectedItem.Text & "' ORDER BY city ASC"

            Using cn As MySqlCommand = New MySqlCommand(db, conn)
                Using da As New MySqlDataAdapter(cn)
                    'Fill data of logged in user into dataset

                    'Get the list of rows needed into Session, so as to enable us retreive it later

                    Dim dt As New DataTable()
                    da.Fill(dt)
                    City.DataSource = dt
                    City.DataTextField = "city"
                    City.DataValueField = "ID"
                    City.DataBind()

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