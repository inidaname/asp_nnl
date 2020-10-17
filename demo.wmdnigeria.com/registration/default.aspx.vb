Imports System.Web
Imports System.Data
Imports System.Text
Imports System.Web.Security
Imports System.Configuration
Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography



Public Class _default6
    Inherits System.Web.UI.Page

    Dim ds As New DataSet


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsNothing(Session("Login")) Then
            Logout.Text = "LOGIN"
            HeaderPanel.Height = 110
            RegistrationPanel.Visible = True
            ToolBar.Visible = False
            WMDInspectorTools.Visible = False
        Else
            Logout.Text = "LOGOUT"
            RegistrationPanel.Visible = False

        End If

        If Session("Login") = True And Session("UserLoginUserType") = "WMD Inspector" Then
            Response.Redirect("../wmd-inspector/")


        ElseIf Session("Login") = True And Session("UserLoginUserType") = "CPI Inspector" Then
            Response.Redirect("../cpi-inspector/")

        ElseIf Session("Login") = True And Session("UserLoginUserType") = "Calibrator" Then
            Response.Redirect("../calibrator/")

        ElseIf Session("Login") = True And Session("UserLoginUserType") = "Authorized Verifier" Then
            Response.Redirect("../authorized-verifier/")

        End If


        If Not IsPostBack Then
            Try
                ConnectDatabase()
                Dim db As String = "SELECT * FROM state"
                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)
                       
                        Dim dt As New DataTable()
                        da.Fill(dt)
                        State.DataSource = dt
                        State.DataTextField = "state"
                        State.DataValueField = "ID"
                        State.DataBind()

                    End Using
                End Using
                'Trow errow is anything is wrong with the code
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                'After execution of mysql query, disconnect database
                DisconnectDatabase()
            End Try


        Else


        End If

        Session.Add("UserLoginIPAddress", GetPublicIP())


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

    Protected Sub State_SelectedIndexChanged(sender As Object, e As EventArgs) Handles State.SelectedIndexChanged

        'This populate state
        Try
            ConnectDatabase()
            Dim db As String = "SELECT * FROM lga WHERE state = '" & State.SelectedItem.Text & "' ORDER BY lga"

            Using cn As MySqlCommand = New MySqlCommand(db, conn)
                Using da As New MySqlDataAdapter(cn)
                    'Fill data of logged in user into dataset
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    LGA.DataSource = dt
                    LGA.DataTextField = "lga"
                    LGA.DataValueField = "ID"
                    LGA.DataBind()

                End Using
            End Using

            'Trow errow is anything wrong with the code

        Catch ex As Exception

            MessageBox.Show(Me, ex.Message)

        Finally
            'After execution of mysql query, disconnect database
            DisconnectDatabase()
        End Try

    End Sub

    Protected Sub LGA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LGA.SelectedIndexChanged
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



    Protected Sub Register_Click(sender As Object, e As EventArgs) Handles Register.Click
        
        If Username.Text = "" Or Password.Text = "" Or ConfirmPassword.Text = "" Or SecurityAnswer.Text = "" Or CompanyName.Text = "" Or PhoneNumber.Text = "" Or EmailAddress.Text = "" Or Representative.Text = "" Or Mobile.Text = "" Or RCNumber.Text = "" Or RegisteredAddress.Text = "" Or FillerTitle.Text = "" Or Surname.Text = "" Or OtherNames.Text = "" Or FillerMobile.Text = "" Or FillerEmail.Text = "" Then
            'If Username.Text = "" Or Password.Text = "" Or ConfirmPassword.Text = "" Or SecurityAnswer.Text = "" Or CompanyName.Text = "" Or PhoneNumber.Text = "" Or EmailAddress.Text = "" Or Representative.Text = "" Or Mobile.Text = "" Or RCNumber.Text = "" Or RegisteredAddress.Text = "" Or POBox.Text = "" Or State.Text = "" Or City.Text = "" Or LGA.Text = "" Or FillerTitle.Text = "" Or Surname.Text = "" Or OtherNames.Text = "" Or FillerMobile.Text = "" Or FillerEmail.Text = "" Then
            MessageBox.Show(Me, "Error Submitting Application: All fields are required!")
            'This code do the loggin magic

            Try
                ConnectDatabase()

                Dim MyAdapter As New MySqlDataAdapter
                Dim SqlQuery = "SELECT * FROM visitorslog WHERE logdate='" & TodaysDate() & "' AND IPAddress='" & GetPublicIP() & "' AND machineName='" & ComputerName() & "' AND deviceType='" & osVersion() & "' AND browserName='" & GetBrowserName() & "'"
                Dim Command As New MySqlCommand
                Command.Connection = conn
                Command.CommandText = SqlQuery
                MyAdapter.SelectCommand = Command

                Dim reader As MySqlDataReader
                reader = Command.ExecuteReader
                'Check if the User has apply for export permit before
                If reader.HasRows = 0 Then
                    reader.Close()

                    Try
                        Dim com As New MySqlCommand
                        com.Connection = conn
                        com.CommandText = "INSERT INTO visitorslog (logdate,logtime,IPAddress,machineName,deviceType,browserName) VALUES ('" & TodaysDate() & "','" & CurrentTim() & "','" & GetPublicIP() & "','" & ComputerName() & "','" & osVersion() & "', '" & GetBrowserName() & "')"
                        com.ExecuteNonQuery()

                    Catch ex As Exception
                        MessageBox.Show(Me, ex.Message)
                    Finally

                    End Try
                Else
                    reader.Close()

                End If


            Catch ex As Exception
                MessageBox.Show(Me, "Database Connection Error: " & ex.Message)

            Finally
                DisconnectDatabase()
            End Try

        ElseIf Username.Text.Length >= 11 Then
            Username.BorderColor = Drawing.Color.DarkRed
            Username.Text = ""
            MessageBox.Show(Me, "Your username has passed maximum character allowed!")

        ElseIf Password.Text = ConfirmPassword.Text And Password.Text.Length <= 7 Then
            Password.BorderColor = Drawing.Color.DarkRed
            Password.Text = ""
            MessageBox.Show(Me, "Password must be atleast 8 Characters! Alphanumeric password is strongly advised!")

        ElseIf Password.Text = ConfirmPassword.Text And Password.Text.Length >= 8 Then
            Password.BorderColor = Drawing.Color.Empty
            ConfirmPassword.BorderColor = Drawing.Color.Empty

            Try

                Dim HashedPassword As String
                Dim EncodeMe As String = ConfirmPassword.Text
                HashedPassword = getSHA512Hash(EncodeMe)
                ConnectDatabase()
                Dim AdapterCheck As New MySqlDataAdapter
                Dim SqlQueryCheck = "SELECT * FROM company WHERE username='" & Username.Text & "' OR companyName='" & CompanyName.Text & "' OR companyEmail='" & EmailAddress.Text & "'"
                Dim CommandCheck As New MySqlCommand
                CommandCheck.Connection = conn
                CommandCheck.CommandText = SqlQueryCheck
                AdapterCheck.SelectCommand = CommandCheck
                Dim readerCheck As MySqlDataReader
                readerCheck = CommandCheck.ExecuteReader
                'Check if the credentials provided is in the database

                If readerCheck.HasRows = 0 Then
                    readerCheck.Close()
                    Dim cmd As New MySqlCommand
                    cmd.Connection = conn
                    cmd.CommandText = "INSERT INTO company (username,password,securityQuestions,securityAnswer,companyName,companyPhoneNumber,companyEmail,companyWebsite,faxNumber,representativeName,mobileNumber,RCNumber,companyAddress,pobox,state,city,lga,filledByTitle,filledBySurname,filledByOtherNames,filledByMobile,filledByEmail,registrationDate,registrationTime,userType)  VALUES ('" & Me.Username.Text & "','" & HashedPassword & "','" & Me.SecurityQuestion.SelectedValue & "','" & Me.SecurityAnswer.Text & "','" & Me.CompanyName.Text & "','" & Me.PhoneNumber.Text & "','" & Me.EmailAddress.Text & "','" & Me.Website.Text & "','" & Me.FaxNumber.Text & "','" & Me.Representative.Text & "','" & Me.Mobile.Text & "','" & Me.RCNumber.Text & "','" & Me.RegisteredAddress.Text & "','" & Me.POBox.Text & "','" & Me.State.SelectedItem.Text & "','" & Me.City.SelectedItem.Text & "','" & Me.LGA.SelectedItem.Text & "','" & Me.FillerTitle.SelectedItem.Text & "','" & Me.Surname.Text & "','" & Me.OtherNames.Text & "','" & Me.FillerMobile.Text & "','" & Me.FillerEmail.Text & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Me.UserType.SelectedValue & "')"
                    cmd.ExecuteNonQuery()

                    Dim MyAdapter As New MySqlDataAdapter
                    Dim SqlQuery = "SELECT * FROM company WHERE username='" & Username.Text & "'"
                    Dim Command As New MySqlCommand
                    Command.Connection = conn
                    Command.CommandText = SqlQuery
                    MyAdapter.SelectCommand = Command
                    Dim reader As MySqlDataReader
                    reader = Command.ExecuteReader
                    'Check if the credentials provided is in the database
                    If reader.HasRows = 0 Then
                        reader.Close()
                        'MessageBox.Show(Me, " Registration not successful, please check and try again!")
                    Else
                        reader.Close()
                        CompanyName.BorderColor = Drawing.Color.Empty
                        Username.BorderColor = Drawing.Color.Empty
                        Dim db As String = "SELECT * FROM company WHERE username='" & Username.Text & "'"

                        Using cn As MySqlCommand = New MySqlCommand(db, conn)

                            Using da As New MySqlDataAdapter(cn)
                                'Get the list of rows needed into dataset, so as to enable us retrieve it later
                                Dim ds As New DataSet()
                                da.Fill(ds)
                                Dim PaymentFor = "Company Registration Invoice"
                                Dim CompID As String = ds.Tables(0).Rows(0).Item("ID").ToString
                                Dim Narration As String = "Company registration Fee"
                                Dim RegistrationFee As String = "20000.00"
                                Dim ApprovalStatus As String = "Waiting"
                                Dim com As New MySqlCommand

                                com.Connection = conn
                                com.CommandText = "INSERT INTO payment (companyID,companyName,transCode,amountDue,invoiceDate,invoiceTime,narration,paymentFor) VALUE ('" & CompID & "','" & CompanyName.Text & "','" & GenerateID() & "','" & RegistrationFee & "','" & TodaysDate() & "','" & CurrentTim() & "', '" & Narration & "','" & PaymentFor & "')"
                                com.ExecuteNonQuery()
                                MessageBox.Show(Me, "Registration successful, you can now login to the Portal with your Username and Password!")
                                Dim InvoiceCompanyName = CompanyName.Text
                                Dim InvoiceUsername = Username.Text
                                Dim CompanyAddress = RegisteredAddress.Text
                                Dim Amount = RegistrationFee
                                Dim Total = RegistrationFee
                                Amount = FormatNumber(Amount, 2, TriState.False, , TriState.True)
                                Total = FormatNumber(Total, 2, TriState.False, , TriState.True)
                                Dim Purpose = PaymentFor
                                Session.Add("CompanyName", CompanyName.Text)
                                'Send SMS Message
                                tools.SendSMS(Me, GetSMSAPI(), GetSMSUsername(), GetSMSPassword(), BulkSMSDefaultSender(), SMSRecipientNumber(), CompanyRegistrationMessage())
                                'Send email to user after registration
                                'Dim Message = "Your Online Registration with Federal Ministry of Industry, Trade and Investment was successful. <div style=''><p> Below are your registration details:<p> <strong> Username: </strong>" + Username.Text + "<p> <strong> Company Name: </strong>" + CompanyName.Text + " <p> Kindly click the button below to login to your account.<p style='margin-top:50px;'> <strong>Thank you.</strong>"
                                Dim Subject = "Company Registration Bill"
                                Dim Message = "<div style='width:620px;font-size:15px;background:rgb(255,255, 255);'><div style='padding-left:10px; width:590px;'><h4 style='padding:10px 0px;font-size:23px;width:100%;text-align:center;margin-top:-10px;'>" & Subject & "</span></h4> <h4 style='padding:10px 0px;font-size:17px;'><span style='float:right;font-size:13px;'>" + Date.Now + " </span></h4><div style='margin-bottom:10px;display:block;height:169px; width:100%;'><div style='width:45%;float:left;'><div style='font-weight:bolder;font-size:17px;padding:5px 0px;'>CLIENT DETAIL</div><p style='font-weight:bolder;font-size:15px;'>" + InvoiceCompanyName + " (" + InvoiceUsername + ")  </p><p style='font-weight:bolder;font-size:15px;'>" + CompanyAddress + "</p></div><div style='width:45%;float:right;'><div style='font-weight:bolder;font-size:17px;padding:5px 0px;'>ACCOUNT DETAIL</div><p style='font-weight:bolder;font-size:13px;'>ACCOUNT NAME: <span style='font-weight:normal;'>FEDERAL MINISTRY OF INDUSTRY, TRADE AND INVESTMENT WEIGHTS AND MEASURES DEPARTMENT</span></p><p style='font-weight:bolder;font-size:13px;'>ACCOUNT NUMBER: <span style='font-weight:normal;'>1750013688</span></p><p style='font-weight:bolder;font-size:13px;'>BANK NAME: <span style='font-weight:normal;'>SKYE BANK</span></p></div></div><div style='font-weight:bolder;font-size:17px;padding:5px 0px;'>INVOICE ITEM(S)</div><div style='width:69%;display:inline-block;font-weight:bolder;padding:10px 0px;border-bottom:1px solid rgb(200,200,200);color:rgb(100,100,100);'>Summary</div><div style='width:30%;display:inline-block;text-align:right;font-weight:bolder;padding:10px 0px;0px;border-bottom:1px solid rgb(200,200,200);color:rgb(100,100,100);'>Amount</div><div style='width:69%;display:inline-block;padding:10px 0px;'>" + Purpose + "</div><div style='width:30%;display:inline-block;text-align:right;padding:10px 0px;'>" + Amount + "</div><div style='width:100%;display:inline-block;padding:20px 0px;margin-left:-10px;padding-right:1px;text-align:right;font-weight:bolder;background:rgb(250,250,250);font-size:17px;'>Total: <span style='float:right;margin-left:50px;margin-right:0px;'>N" + Total + "</span></div></div><p><div style='margin-top:0px;width:600px;height:auto;padding:10px;color:rgb(20,20,20);text-align:left;font-size:13px;background:rgb(255,255,255);'><strong>PLEASE NOTE: </strong> <P>ALL BANK DEPOSIT MUST BE MADE WITH THE USERNAME NAME AS THE DEPOSITOR.<P>ALL PAYMENT(S) MADE ARE NON-REFUNDABLE.</div><p><a href='http://www.wmdnigeria.com/' style='text-decoration:none;width:auto;color:rgb(255,255,255);'><div style='margin-bottom:10px;padding: 5px 10px;width:100px;font-size: 14px;font-weight: bolder;line-height: 20px;text-align: center;cursor: pointer;border: 1px solid transparent;border-radius: 4px;background:rgb(54,127,169);color:rgb(255, 255, 255);'>Login Now</div> </div>"
                                Dim MessageBody = "<html><head></head><body style='font-family:Tahoma; width:620px;font-size:13px;background:rgb(240,240, 240)'><div style='width:600px;height:70px;padding:10px;color:rgb(255, 255, 255);font-weight:bolder;text-align:center;font-size:20px;background:rgb(54,127,169);'><img src='http://www.wmdnigeria.com/images/icon.png' width='70px' height='70px' align='left' style='margin-top:-10px;padding:0px;' /><p>Federal Ministry of Industry Trade and Investment <br><span style='font-size:17px;'>Weights and Measures Department</span></div><div style='width:600px;font-size:13px;color:rgb(100,100,100);'><p> <div style='padding-left:10px; width:590px;'> <div style='font-weight:bolder;font-size:17px;'>" + Subject + "</div><p>" & Message & "</div></div> </div>           <p><div style='margin-top:100px;width:600px;height:auto;padding:10px;color:rgb(255, 255, 255);text-align:center;font-size:13px;background:rgb(54,127,169);'><strong>NOTICE: </strong>  The content of this e-mail is intended solely for the use of the individual or entity to whom it is addressed. If you have received this communication in error, beware that forwarding it, copying it or in any way disclosing its content to any other person or persons, is strictly prohibiting. If you have received this communication in error, please notify the author by replying this e-mail immediately.</div></body></html>"
                                clsNotify.SendEmail(EmailAddress.Text, Subject, MessageBody, AccountEmail(), True)
                                'MessageBox.Show(Me, "Your message has been received successfully")
                                Response.AppendHeader("Refresh", "0;url=./")
                            End Using
                        End Using
                    End If


                Else
                    readerCheck.Close()
                    CompanyName.BorderColor = Drawing.Color.DarkRed
                    Username.BorderColor = Drawing.Color.DarkRed

                    MessageBox.Show(Me, "Your Account cannot be created, the Email or Username or Company Name already existing!")

                End If

                'This code do the loggin magic
                Dim Activity As String = Username.Text & " registered as a new user succesffuly!"
                Dim comm As New MySqlCommand
                comm.Connection = conn
                comm.CommandText = "INSERT INTO userlog (activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Activity & "','" & Session("UserLoginIPAddress") & "','" & ComputerName() & "','" & osVersion() & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("UserLoginUserType") & "')"
                comm.ExecuteNonQuery()

            Catch ex As Exception

                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()

            End Try

        Else
            Password.BorderColor = Drawing.Color.DarkRed
            ConfirmPassword.BorderColor = Drawing.Color.DarkRed
            MessageBox.Show(Me, "Password do not match!")
        End If

    End Sub


End Class