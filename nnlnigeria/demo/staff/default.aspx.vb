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




Public Class _default29
    Inherits System.Web.UI.Page

    Function getSHA512Hash(ByVal strToHash As String) As String
        Dim SHA512Obj As New SHA512CryptoServiceProvider
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)

        bytesToHash = SHA512Obj.ComputeHash(bytesToHash)

        Dim strResult As String = ""

        For Each b As Byte In bytesToHash
            strResult += b.ToString("x2")
        Next

        Return strResult
    End Function

    Dim msgtext As String = ""
    Dim ds As New DataSet
    Dim Article1ID, Article1Title, Article1Text, Article1Image, Article1Group As String
    Dim Article2ID, Article2Title, Article2Text, Article2Image, Article2Group As String
    Dim Article3ID, Article3Title, Article3Text, Article3Image, Article3Group As String
    Dim Article4ID, Article4Title, Article4Text, Article4Image, Article4Group As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Session("Login")) Then
            LoginPanel.Visible = True
            Logout.Text = "LOGIN"
            ToolBar.Visible = False
            ' Headers.Attributes("style") = "height:110px"
            HeaderPanel.Height = 110

            RegistrationPanel.Visible = True
            Response.Redirect("../")
        Else
            LoginPanel.Visible = False
            Logout.Text = "LOGOUT"
            SlidePanel.Width = 100%
            ToolBar.Visible = True
            SlidePanel.Attributes("style") = "Width:100%"

            RegistrationPanel.Visible = False

            If Session("Login") = True And Session("UserLoginCompanyUserType") = "User" Then
                MessageBox.Show(Me, "You logged as: " & Session("UserLoginCompanyUserType"))
                Response.Redirect("../")


            End If

            WelcomeMessage.Text = "  " & Session("UserLoginName")

        End If


        If Not IsPostBack = True Then
            GetNews()

            If Not Session("UserLoginIPAddress") = Nothing Then

                Session("UserLoginIPAddress") = Session("UserLoginIPAddress")
            Else
                Session.Add("UserLoginIPAddress", GetPublicIP())

            End If

            Try
                'This code do the loggin magic
                Try

                    ConnectDatabase()

                    Dim MyAdapter As New MySqlDataAdapter
                    Dim SqlQuery = "SELECT * FROM visitorslog WHERE logdate='" & TodaysDate() & "' AND IPAddress='" & Session("UserLoginIPAddress") & "' AND machineName='" & ComputerName() & "' AND deviceType='" & osVersion() & "' AND browserName='" & GetBrowserName() & "'"
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
                            com.CommandText = "INSERT INTO visitorslog (logdate,logtime,IPAddress,machineName,deviceType,browserName) VALUES ('" & TodaysDate() & "','" & CurrentTim() & "','" & Session("UserLoginIPAddress") & "','" & ComputerName() & "','" & osVersion() & "', '" & GetBrowserName() & "')"
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
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            End Try


        Else
            GetNews()

        End If


        DataBind()

    End Sub

    Public Function GetNews()


        Try
            ConnectDatabase()

            Dim ArticleStatus As Integer = 1
            'Select the First News
            Dim db As String = "SELECT * FROM article WHERE status='" & ArticleStatus & "' ORDER BY RAND() LIMIT 1"
            'Dim db As String = "SELECT TOP 1 * FROM article WHERE status='" & ArticleStatus & "' ORDER BY NEWID()"

            Using cn As MySqlCommand = New MySqlCommand(db, conn)
                Using da As New MySqlDataAdapter(cn)

                    Dim ds As New DataSet
                    da.Fill(ds)

                    Article1ID = ds.Tables(0).Rows(0).Item("ID").ToString
                    Article1Title = ds.Tables(0).Rows(0).Item("articleTitle").ToString
                    Article1Text = ds.Tables(0).Rows(0).Item("article").ToString
                    Article1Image = ds.Tables(0).Rows(0).Item("imageLink").ToString
                    Article1Group = ds.Tables(0).Rows(0).Item("articleGroup").ToString

                    'Select the Second News 
                    Dim db2 As String = "SELECT * FROM article WHERE NOT ID ='" & Article1ID & "' AND status='" & ArticleStatus & "' LIMIT 1"

                    Using cn2 As MySqlCommand = New MySqlCommand(db2, conn)
                        Using da2 As New MySqlDataAdapter(cn2)

                            Dim ds2 As New DataSet
                            da2.Fill(ds2)

                            Article2ID = ds2.Tables(0).Rows(0).Item("ID").ToString
                            Article2Title = ds2.Tables(0).Rows(0).Item("articleTitle").ToString
                            Article2Text = ds2.Tables(0).Rows(0).Item("article").ToString
                            Article2Image = ds2.Tables(0).Rows(0).Item("imageLink").ToString
                            Article2Group = ds2.Tables(0).Rows(0).Item("articleGroup").ToString

                            'Select the Third News
                            Dim db3 As String = "SELECT * FROM article WHERE NOT ID ='" & Article1ID & "' AND NOT ID ='" & Article2ID & "' AND status='" & ArticleStatus & "' LIMIT 1"

                            Using cn3 As MySqlCommand = New MySqlCommand(db3, conn)
                                Using da3 As New MySqlDataAdapter(cn3)

                                    Dim ds3 As New DataSet
                                    da3.Fill(ds3)

                                    Article3ID = ds3.Tables(0).Rows(0).Item("ID").ToString
                                    Article3Title = ds3.Tables(0).Rows(0).Item("articleTitle").ToString
                                    Article3Text = ds3.Tables(0).Rows(0).Item("article").ToString
                                    Article3Image = ds3.Tables(0).Rows(0).Item("imageLink").ToString
                                    Article3Group = ds3.Tables(0).Rows(0).Item("articleGroup").ToString

                                    'Select the Forth News
                                    Dim db4 As String = "SELECT * FROM article WHERE NOT ID ='" & Article1ID & "' AND NOT ID ='" & Article2ID & "' AND NOT ID ='" & Article3ID & "' AND status='" & ArticleStatus & "' LIMIT 1"

                                    Using cn4 As MySqlCommand = New MySqlCommand(db4, conn)
                                        Using da4 As New MySqlDataAdapter(cn4)

                                            Dim ds4 As New DataSet
                                            da4.Fill(ds4)

                                            Article4ID = ds4.Tables(0).Rows(0).Item("ID").ToString
                                            Article4Title = ds4.Tables(0).Rows(0).Item("articleTitle").ToString
                                            Article4Text = ds4.Tables(0).Rows(0).Item("article").ToString
                                            Article4Image = ds4.Tables(0).Rows(0).Item("imageLink").ToString
                                            Article4Group = ds4.Tables(0).Rows(0).Item("articleGroup").ToString

                                            NewsTitle1.DataBind()
                                            NewsTitle2.DataBind()
                                            NewsTitle3.DataBind()
                                            NewsTitle4.DataBind()

                                            NewsPreview1.DataBind()
                                            NewsPreview2.DataBind()
                                            NewsPreview3.DataBind()
                                            NewsPreview4.DataBind()

                                        End Using
                                    End Using


                                End Using
                            End Using

                        End Using
                    End Using

                End Using
            End Using

        Catch ex As MySqlException
            MessageBox.Show(Me, ex.Message)
        Finally
            DisconnectDatabase()
        End Try


    End Function





    Public Function ImageName1()
        ImageName1 = Article1Image
    End Function

    Public Function ImageName2()
        ImageName2 = Article2Image
    End Function

    Public Function ImageName3()
        ImageName3 = Article3Image
    End Function

    Public Function ImageName4()
        ImageName4 = Article4Image
    End Function


    Public Function ArticleTitle1()
        Try
            If Article4Title.Length >= 70 Then
                ArticleTitle1 = Left(Article1Title, 70) + "..."
            Else
                ArticleTitle1 = Article1Title
            End If
        Catch ex As Exception

        End Try

    End Function

    Public Function ArticleTitle2()
        Try
            If Article4Title.Length >= 70 Then
                ArticleTitle2 = Left(Article2Title, 70) + "..."
            Else
                ArticleTitle2 = Article2Title
            End If
        Catch ex As Exception

        End Try
    End Function

    Public Function ArticleTitle3()
        Try
            If Article4Title.Length >= 70 Then
                ArticleTitle3 = Left(Article3Title, 70) + "..."
            Else
                ArticleTitle3 = Article3Title
            End If
        Catch ex As Exception

        End Try
    End Function

    Public Function ArticleTitle4()
        Try
            If Article4Title.Length >= 70 Then
                ArticleTitle4 = Left(Article4Title, 70) + "..."
            Else
                ArticleTitle4 = Article4Title
            End If
        Catch ex As Exception

        End Try
    End Function


    Public Function ArticleText1()
        Try
            ArticleText1 = Article1Text.Substring(0, 270) & "..."
        Catch ex As Exception

        End Try
    End Function

    Public Function ArticleText2()
        Try
            ArticleText2 = Article2Text.Substring(0, 270) & "..."
        Catch ex As Exception

        End Try
    End Function

    Public Function ArticleText3()
        Try
            ArticleText3 = Article3Text.Substring(0, 270) & "..."
        Catch ex As Exception

        End Try
    End Function

    Public Function ArticleText4()
        Try
            ArticleText4 = Article4Text.Substring(0, 270) & "..."
        Catch ex As Exception

        End Try
    End Function


    Public Function ArticleID1()
        ArticleID1 = Article1ID
    End Function

    Public Function ArticleID2()
        ArticleID2 = Article2ID
    End Function

    Public Function ArticleID3()
        ArticleID3 = Article3ID
    End Function

    Public Function ArticleID4()
        ArticleID4 = Article4ID
    End Function







    Protected Sub Registration_Click(sender As Object, e As EventArgs) Handles Registration.Click
        If (Session("Login")) Or (Session("Login")) = "True" Then
            Logout_Click(sender, New EventArgs)
            Response.Redirect("../registration/", False)

        Else
            Response.Redirect("../registration/")
        End If
    End Sub


    Protected Sub RedirectPage(sender As Object, e As EventArgs)
        Response.Redirect("../", False)
    End Sub


    Protected Sub LoginButton_Click(sender As Object, e As EventArgs) Handles LoginButton.Click

        If Username.Text = "" Or Password.Text = "" Then

            'MessageBox.Show(Me, "Error Login in: No field is allowed to be empty")
            MessageBox.Show(Me, "Error Login in: No field is allowed to be empty")
        Else

            Try
                Dim HashedPassword As String
                Dim EncodeMe As String = Password.Text
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
                    MessageBox.Show(Me, "Error Login in: Invalid username or password")
                    reader.Close()

                    'This code do the loggin magic
                    Try
                        Dim Activity As String = "User tried to log in with this credential!" & " Username: " & Username.Text & "  " & Password.Text & "  "
                        Dim UserType = "Error Or Hacker"
                        Dim com As New MySqlCommand
                        com.Connection = conn
                        com.CommandText = "INSERT INTO userlog (activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Activity & "','" & GetPublicIP() & "','" & ComputerName() & "','" & osVersion() & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & UserType & "')"
                        com.ExecuteNonQuery()

                    Catch ex As Exception
                        MessageBox.Show(Me, "Database Connection Error: " & ex.Message)

                    End Try

                Else

                    Try
                        ConnectDatabase()
                        reader.Close()
                        Dim db As String = "SELECT * FROM company WHERE username='" & Username.Text & "';"

                        Using cn As MySqlCommand = New MySqlCommand(db, conn)
                            Using da As New MySqlDataAdapter(cn)
                                'Fill data of logged in user into dataset
                                da.Fill(ds)

                                'Get the list of rows needed into Session, so as to enable us retreive it later
                                For Each Row As DataRow In ds.Tables(0).Rows
                                    Session.Add("UserLoginName", (Row("username")))
                                    Session.Add("UserLoginPassword", (Row("password")))
                                    Session.Add("UserLoginUserType", (Row("userType")))
                                    Session.Add("UserLoginID", (Row("ID")))
                                    Session.Add("Login", "True")
                                    Session.Add("UserLoginCompanyName", (Row("companyName")))
                                    Session.Add("UserLoginCompanyAddress", (Row("companyAddress")))
                                    Session.Add("UserLoginCompanyCity", (Row("city")))
                                    Session.Add("UserLoginCompanyLGA", (Row("lga")))
                                    Session.Add("UserLoginCompanyState", (Row("state")))
                                    Session.Add("UserLoginCompanyPOBox", (Row("pobox")))
                                    Session.Add("UserLoginCompanyPhoneNumber", (Row("companyPhoneNumber")))
                                    Session.Add("UserLoginCompanyEmail", (Row("companyEmail")))
                                    Session.Add("UserLoginCompanyWebsite", (Row("companyWebsite")))
                                    Session.Add("UserLoginCompanyfaxNumber", (Row("faxNumber")))
                                    Session.Add("UserLoginCompanyRepName", (Row("representativeName")))
                                    Session.Add("UserLoginCompanyMobileNumber", (Row("mobileNumber")))
                                    Session.Add("UserLoginCompanyFilledByTitle", (Row("filledByTitle")))
                                    Session.Add("UserLoginCompanyfilledBySurname", (Row("filledBySurname")))
                                    Session.Add("UserLoginCompanyFilledByOtherNames", (Row("filledByOtherNames")))
                                    Session.Add("UserLoginCompanyFilledByMobile", (Row("filledByMobile")))
                                    Session.Add("UserLoginCompanyFilledByEmail", (Row("filledByEmail")))
                                    Session.Add("UserLoginCompanyRegistrationDate", (Row("registrationDate")))
                                    Session.Add("UserLoginCompanyRegistrationTime", (Row("registrationTime")))
                                    Session.Add("UserLoginCompanyRegistrationDateModify", (Row("registrationDateModify")))
                                    Session.Add("UserLoginCompanySecurityQuestions", (Row("securityQuestions")))
                                    Session.Add("UserLoginCompanySecurityAnswer", (Row("securityAnswer")))
                                    Session.Add("UserLoginCompanyRecordStatus", (Row("recordStatus")))
                                    Session.Add("UserLoginCompanyPaidRegistration", (Row("paidRegistration")))
                                    Session.Add("UserLoginCompanyCompanyRegistrationType", (Row("companyRegistrationType")))
                                    Session.Add("UserLoginCompanyTransCode", (Row("transCode")))
                                    Session.Add("UserLoginCompanyRCNumber", (Row("RCNumber")))
                                    Session.Add("UserLoginCompanyTotalDeposit", (Row("totalDeposit")))
                                    Session.Add("UserLoginCompanyTransactionID", (Row("transactionID")))
                                    Session.Add("UserLoginCompanyExportAlert", (Row("companyExportAlert")))
                                    Session.Add("UserLoginCompanyExportShow", (Row("companyExportShow")))
                                    Session.Add("UserLoginCompanyUserType", (Row("userType")))

                                    'This code do the loggin magic
                                    Try
                                        Dim Activity As String = "User logged in!"
                                        Dim com As New MySqlCommand
                                        com.Connection = conn
                                        com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("UserLoginID") & "','" & Activity & "','" & GetPublicIP() & "','" & ComputerName() & "','" & osVersion() & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("UserLoginUserType") & "')"
                                        com.ExecuteNonQuery()
                                        
                                    Catch ex As Exception
                                        MessageBox.Show(Me, "Database Connection Error: " & ex.Message)

                                    End Try
                                Next

                            End Using
                        End Using
                        Response.AppendHeader("Refresh", "0;url=../")
                        'Trow errow if anything is wrong with the code

                    Catch ex As Exception

                        MessageBox.Show(Me, "Error:" & ex.Message)

                    Finally
                        DisconnectDatabase()


                    End Try


                End If


            Catch ex As Exception
                MessageBox.Show(Me, "Database Connection Error: " & ex.Message)

            Finally
                DisconnectDatabase()
            End Try

        End If

        'RedirectPage(sender, New System.EventArgs)


    End Sub

    Protected Sub Logout_Click(sender As Object, e As EventArgs) Handles Logout.Click

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

    Protected Sub ProfileIcon_Click(sender As Object, e As EventArgs) Handles ProfileIcon.Click
        Response.Redirect("profile/")
    End Sub


    Protected Sub InvoiceIcon_Click(sender As Object, e As EventArgs) Handles InvoiceIcon.Click
        Response.Redirect("invoice/")
    End Sub


    Protected Sub DepositIcon_Click(sender As Object, e As EventArgs) Handles DepositIcon.Click
        Response.Redirect("deposit/")
    End Sub


    Protected Sub UploadIcon_Click(sender As Object, e As EventArgs) Handles UploadIcon.Click
        Response.Redirect("upload/")
    End Sub


    Protected Sub InstrumentServicesIcon_Click(sender As Object, e As EventArgs) Handles InstrumentServicesicon.Click
        Response.Redirect("instrument-services/")
    End Sub


    Protected Sub RegisterInstrumentIcon_Click(sender As Object, e As EventArgs) Handles RegisterInstrumentIcon.Click
        Response.Redirect("register-instrument/")
    End Sub

    Protected Sub RequirementIcon_Click(sender As Object, e As EventArgs) Handles RequirementIcon.Click
        Response.Redirect("requirements/")
    End Sub

    Protected Sub ExportReturnIcon_Click(sender As Object, e As EventArgs) Handles ExportReturnIcon.Click
        Response.Redirect("../export-data-return/")
    End Sub

    Protected Sub ExportPermitIcon_Click(sender As Object, e As EventArgs) Handles ExportPermitIcon.Click
        Response.Redirect("export-permit/")
    End Sub

    Protected Sub ReportsIcon_Click(sender As Object, e As EventArgs) Handles ReportIcon.Click
        Response.Redirect("reports/")
    End Sub




    Protected Sub RefreshNews_Click(sender As Object, e As EventArgs) Handles RefreshNews.Click
        GetNews()
    End Sub


    Protected Sub PasswordReset_Click(sender As Object, e As EventArgs) Handles PasswordReset.Click
        LoginPanel.Visible = False
        PasswordResetPanel.Visible = True
    End Sub

    Protected Sub GoToLogin_Click(sender As Object, e As EventArgs) Handles GoToLogin.Click
        LoginPanel.Visible = False
        PasswordResetPanel.Visible = True
        Response.AppendHeader("Refresh", "0;url=../")
    End Sub

    Dim SecurityAnswers As String
    Protected Sub SearchAccount_Click(sender As Object, e As EventArgs) Handles SearchAcount.Click
        If AccountEmail.Text = "" Then
            MessageBox.Show(Me, "Error Login Searching: You must enter your email address in the box!")
            LoginPanel.Visible = False
            PasswordResetPanel.Visible = True
        Else
            LoginPanel.Visible = False
            PasswordResetPanel.Visible = True
            Try

                ConnectDatabase()

                Dim MyAdapter As New MySqlDataAdapter

                Dim SqlQuery = "SELECT * FROM company WHERE companyEmail='" & AccountEmail.Text & "';"

                Dim Command As New MySqlCommand

                Command.Connection = conn

                Command.CommandText = SqlQuery

                MyAdapter.SelectCommand = Command

                Dim reader As MySqlDataReader
                reader = Command.ExecuteReader
                'Check if the credentials provided is in the database
                If reader.HasRows = 0 Then


                    'MessageBox.Show(Me, "Error Login in: Invalid username or password")
                    MessageBox.Show(Me, "Error: Account not found on our server, check your spelling or register a new account!")
                    reader.Close()

                    'This code do the loggin magic
                    
                    Try
                        Dim Activity As String = "User tried to reset password for an invalid account!" & " E-mail: " & AccountEmail.Text
                        Dim UserType = "Error Or Hacker"
                        Dim com As New MySqlCommand
                        com.Connection = conn
                        com.CommandText = "INSERT INTO userlog (activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Activity & "','" & GetPublicIP() & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & UserType & "')"
                        com.ExecuteNonQuery()

                    Catch ex As Exception
                        MessageBox.Show(Me, "Database Connection Error: " & ex.Message)

                    End Try

                Else

                    Try
                        ConnectDatabase()
                        reader.Close()
                        Dim db As String = "SELECT * FROM company WHERE companyEmail='" & AccountEmail.Text & "';"

                        Using cn As MySqlCommand = New MySqlCommand(db, conn)
                            Using da As New MySqlDataAdapter(cn)
                                'Fill data of logged in user into dataset
                                da.Fill(ds)

                                'Get the list of rows needed into Session, so as to enable us retreive it later
                                For Each Row As DataRow In ds.Tables(0).Rows

                                    LoginPanel.Visible = False
                                    PasswordResetPanel.Visible = True

                                    SecurityQuestion.Text = Row("securityQuestions") + "?"
                                    'SecurityAnswers = Row("securityAnswer")
                                    Session.Add("UserLoginCompanySecurityAnswer", (Row("securityAnswer")))
                                    Session.Add("UserTryingToResetPassword", (Row("ID")))

                                    AccountEmail.Visible = False
                                    EmailLabel.Visible = False
                                    SearchAcount.Visible = False

                                    SecurityQuestion.Visible = True
                                    SecurityAnswer.Visible = True
                                    ContinueReset.Visible = True


                                    'This code do the loggin magic
                                    
                                    Try
                                        Dim Activity As String = "User searched account to change the password!   " & AccountEmail.Text
                                        Dim com As New MySqlCommand
                                        com.Connection = conn
                                        com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("UserLoginID") & "','" & Activity & "','" & GetPublicIP() & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("UserLoginUserType") & "')"
                                        com.ExecuteNonQuery()
                                        'MessageBox.Show(Me, "Userlog has been saved successfully!")


                                    Catch ex As Exception
                                        MessageBox.Show(Me, "Database Connection Error: " & ex.Message)

                                    End Try
                                Next

                            End Using
                        End Using
                    Catch ex As Exception

                        MessageBox.Show(Me, "Error:" & ex.Message)

                    Finally
                        DisconnectDatabase()


                    End Try


                End If


            Catch ex As Exception
                MessageBox.Show(Me, "Database Connection Error: " & ex.Message)

            Finally
                DisconnectDatabase()
            End Try

        End If

    End Sub

    Protected Sub ContinueReset_Click(sender As Object, e As EventArgs) Handles ContinueReset.Click
        If SecurityAnswer.Text = Session("UserLoginCompanySecurityAnswer") Then
            LoginPanel.Visible = False
            PasswordResetPanel.Visible = True

            SecurityQuestion.Visible = False
            SecurityAnswer.Visible = False
            ContinueReset.Visible = False

            ResetMyPassword.Visible = True
            NewPasswordLabel.Visible = True
            NewPassword.Visible = True
            ConfirmPasswordLabel.Visible = True
            ConfirmPassword.Visible = True

            GoToLogin.Text = "Cancel Reset"

        Else
            LoginPanel.Visible = False
            PasswordResetPanel.Visible = True
            MessageBox.Show(Me, "You cannot reset this account: security answer provided does not match!")
        End If
    End Sub
    Protected Sub ResetMyPassword_Click(sender As Object, e As EventArgs) Handles ResetMyPassword.Click
        LoginPanel.Visible = False
        PasswordResetPanel.Visible = True

        If NewPassword.Text = "" Or ConfirmPassword.Text = "" Then
            MessageBox.Show(Me, "Password cannot be reset to blank")

        ElseIf Not NewPassword.Text = ConfirmPassword.Text Then

            MessageBox.Show(Me, "Password do not match")
        Else

            Try

                ConnectDatabase()
                Dim HashedPassword As String
                Dim EncodeMe As String = ConfirmPassword.Text
                HashedPassword = getSHA512Hash(EncodeMe)

                ConnectDatabase()


                Dim cmd As New MySqlCommand

                cmd.Connection = conn
                cmd.CommandText = "UPDATE company SET password='" & HashedPassword & "' WHERE ID='" & Session("UserTryingToResetPassword") & "'"

                cmd.ExecuteNonQuery()
                MessageBox.Show(Me, "Your password has been changed successfully!")
                Response.AppendHeader("Refresh", "0;url=./")
            Catch ex As Exception
                MessageBox.Show(Me, "Database Connection Error: " & ex.Message)

            Finally
                DisconnectDatabase()
            End Try

        End If

    End Sub



    Private Sub _default_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        'Check for device that has reach its renewal time
        Try
            ConnectDatabase()
            Dim db As String = "SELECT * FROM deviceregistration"
            Using cn As MySqlCommand = New MySqlCommand(db, conn)
                Using da As New MySqlDataAdapter(cn)
                    Dim ds As New DataSet()
                    da.Fill(ds, "deviceregistration")
                    'Loop through all the registered instrument to check if its due for annual renewal
                    For Each Row As DataRow In ds.Tables(0).Rows
                        Dim CompanyID = Row("ID")
                        Dim InstrumentDate = Row("registrationDate")
                        Dim TodaysDate = Date.Today.ToString("d-MM-yyyy")
                        Dim InstrumentSerialNo = Row("serialNumber")
                        Dim InstrumentReferenceNo = Row("transCode")

                        Dim UserNameOfCompany = Row("companyName")
                        Dim UserEmail = Row("companyEmail")
                        Dim ReferenceNumber = Row("transCode")
                        Dim Sector = Row("sector")
                        Dim Instrument = Row("instrumentCategory")
                        Dim InstrumentType = Row("deviceType")
                        Dim ModelName = Row("deviceModelName")
                        Dim SerialNo = Row("serialNumber")
                        Dim MeasurementRang = Row("measurementRange")
                        Dim ActualMeasure = Row("actualMeasure")
                        Dim TotalAmount = Row("deviceAmount")

                        TotalAmount = FormatNumber(TotalAmount, 2, TriState.False, , TriState.True)
                        'Check for difference between the Current Date and Instrument Registration Date
                        Dim DateDifference
                        DateDifference = Date.ParseExact(TodaysDate, "dd-MM-yyyy", Nothing) - Date.ParseExact(InstrumentDate, "dd-MM-yyyy", Nothing)
                        DateDifference = DateDifference.ToString.Replace(".00:00:00", "")

                        Dim OneYear As Integer = 365
                        Dim TwoYears As Integer = 365 * 2
                        Dim ThreeYears As Integer = 365 * 3
                        Dim FourYears As Integer = 365 * 4
                        Dim FiveYears As Integer = 365 * 5
                        Dim SixYears As Integer = 365 * 6
                        Dim SevenYears As Integer = 365 * 7
                        Dim EightYears As Integer = 365 * 8
                        Dim NineYears As Integer = 365 * 9
                        Dim TenYears As Integer = 365 * 10
                        Dim ElevenYears As Integer = 365 * 11
                        Dim TwelveYears As Integer = 365 * 12

                        Dim ReminderNotificationDays As Integer = 7
                        If DateDifference.ToString >= OneYear Then

                            Dim MyAdapter As New MySqlDataAdapter
                            Dim SqlQuery = "SELECT * FROM devicerenewal WHERE transCode='" & ReferenceNumber & "' AND serialNumber='" & SerialNo & "'"
                            Dim Command As New MySqlCommand
                            Command.Connection = conn
                            Command.CommandText = SqlQuery
                            MyAdapter.SelectCommand = Command

                            Dim reader As MySqlDataReader
                            reader = Command.ExecuteReader
                            'Check if the User has apply for export permit before
                            If reader.HasRows = 0 Then
                                reader.Close()

                                Dim com As New MySqlCommand
                                com.Connection = conn
                                com.CommandText = "INSERT INTO table () values ()"
                                com.ExecuteNonQuery()

                                Dim Message = "Your Instrument Registered with Federal Ministry of Industry, Trade and Investment Weights and Measures Department Web Portal is due for renewal, an invoice has been generated. <div style=''><p> Find below the details of transaction:<p> <strong> Reference Number: </strong>" + ReferenceNumber + "<p> <strong> Company Name: </strong>" + UserNameOfCompany + "<p> <strong> Sector: </strong>" + Sector + "<p> <strong> Instrument Category: </strong>" + Instrument + "  <p> <strong> Instrument: </strong>" + InstrumentType + "<p> <strong> Model Name: </strong>" + ModelName + "<p> <strong> Model Number: </strong>" + SerialNo + "  <p> <strong> Measurement Range: </strong>" + MeasurementRang + " <p> <strong> Actual Measurement: </strong>" + ActualMeasure + "<p> <strong> Amount Due: </strong>" + TotalAmount + "<p> <strong> Registration Date: </strong>" + InstrumentDate + "    <p> Kindly click the button below to login to your account.<p style='margin-top:50px;'> <strong>Thank you.</strong>"
                                'Dim Message = "Your Instrument Registered with Federal Ministry of Industry, Trade and Investment Weights and Measures Department Web Portal is due for renewal, an invoice is hereby been generated. <div style=''><p> Find below the details of transaction:<p> <strong> Reference Number: </strong>" + ReferenceNumber + "<p> <strong> Company Name: </strong>" + UserNameOfCompany + "<p> <strong> Sector: </strong>" + Sector + "<p> <strong> Instrument Category: </strong>" + Instrument + "  <p> <strong> Instrument: </strong>" + InstrumentType + "<p> <strong> Model Name: </strong>" + ModelName + "<p> <strong> Model Number: </strong>" + SerialNo + "  <p> <strong> Measurement Range: </strong>" + MeasurementRang + " <p> <strong> Actual Measurement: </strong>" + ActualMeasure + "<p> <strong> Amount Due: </strong>" + TotalAmount + "<p> <strong> Registration Date: </strong>" + InstrumentDate + "    <p> Kindly click the button below to login to your account.<p style='margin-top:50px;'> <strong>Thank you.</strong>"
                                Dim Subject = "Notification: Annual Licensing Renewal!"
                                Dim MessageBody = "<html><head></head><body style='font-family:Tahoma; width:620px;font-size:13px;background:rgb(240,240, 240)'><div style='width:600px;height:70px;padding:10px;color:rgb(255, 255, 255);font-weight:bolder;text-align:center;font-size:20px;background:rgb(54,127,169);'><img src='http://www.wmdnigeria.com/images/icon.png' width='70px' height='70px' align='left' style='margin-top:-10px;padding:0px;' /><p>Federal Ministry of Industry Trade and Investment <br><span style='font-size:17px;'>Weights and Measures Department</span></div><div style='width:600px;font-size:13px;color:rgb(100,100,100);'><p> <div style='padding-left:10px; width:590px;'> <div style='font-weight:bolder;font-size:17px;'>" + Subject + "</div><p>" & Message & "</div> <a href='http://www.wmdnigeria.com/' style='text-decoration:none;width:auto;'><div style='margin-top:40px;padding: 5px 10px;width:100px;font-size: 14px;font-weight: bolder;line-height: 20px;text-align: center;cursor: pointer;border: 1px solid transparent;border-radius: 4px;background:rgb(54,127,169);color:rgb(255, 255, 255);'>Login Now</div> </div>           <p><div style='margin-top:100px;width:600px;height:auto;padding:10px;color:rgb(255, 255, 255);text-align:center;font-size:13px;background:rgb(54,127,169);'><strong>NOTICE: </strong>  The content of this e-mail is intended solely for the use of the individual or entity to whom it is addressed. If you have received this communication in error, beware that forwarding it, copying it or in any way disclosing its content to any other person or persons, is strictly prohibiting. If you have received this communication in error, please notify the author by replying this e-mail immediately.</div></body></html>"

                                'clsNotify.SendEmail(UserEmail, Subject, MessageBody, FromEmail(), True)
                            Else
                                reader.Close()

                                'Dim strSQL As String
                                'strSQL = "UPDATE server SET serverIP='" & ServerIP & "',serverPort='" & ServerPort & "',serverAddress='" & ServerAddress & "',serverName='" & ServerName & "'"
                                'strSQL = ""
                                'Dim cmd As New MySqlCommand(strSQL, conn)
                                'cmd.ExecuteNonQuery()

                                Dim Message = "Your Instrument Registered with Federal Ministry of Industry, Trade and Investment Weights and Measures Department Web Portal is due for renewal, an invoice has been generated. <div style=''><p> Find below the details of transaction:<p> <strong> Reference Number: </strong>" + ReferenceNumber + "<p> <strong> Company Name: </strong>" + UserNameOfCompany + "<p> <strong> Sector: </strong>" + Sector + "<p> <strong> Instrument Category: </strong>" + Instrument + "  <p> <strong> Instrument: </strong>" + InstrumentType + "<p> <strong> Model Name: </strong>" + ModelName + "<p> <strong> Model Number: </strong>" + SerialNo + "  <p> <strong> Measurement Range: </strong>" + MeasurementRang + " <p> <strong> Actual Measurement: </strong>" + ActualMeasure + "<p> <strong> Amount Due: </strong>" + TotalAmount + "<p> <strong> Registration Date: </strong>" + InstrumentDate + "    <p> Kindly click the button below to login to your account.<p style='margin-top:50px;'> <strong>Thank you.</strong>"
                                'Dim Message = "Your Instrument Registered with Federal Ministry of Industry, Trade and Investment Weights and Measures Department Web Portal is due for renewal, an invoice is hereby been generated. <div style=''><p> Find below the details of transaction:<p> <strong> Reference Number: </strong>" + ReferenceNumber + "<p> <strong> Company Name: </strong>" + UserNameOfCompany + "<p> <strong> Sector: </strong>" + Sector + "<p> <strong> Instrument Category: </strong>" + Instrument + "  <p> <strong> Instrument: </strong>" + InstrumentType + "<p> <strong> Model Name: </strong>" + ModelName + "<p> <strong> Model Number: </strong>" + SerialNo + "  <p> <strong> Measurement Range: </strong>" + MeasurementRang + " <p> <strong> Actual Measurement: </strong>" + ActualMeasure + "<p> <strong> Amount Due: </strong>" + TotalAmount + "<p> <strong> Registration Date: </strong>" + InstrumentDate + "    <p> Kindly click the button below to login to your account.<p style='margin-top:50px;'> <strong>Thank you.</strong>"
                                Dim Subject = "Notification: Annual Licensing Renewal Reminder!"
                                Dim MessageBody = "<html><head></head><body style='font-family:Tahoma; width:620px;font-size:13px;background:rgb(240,240, 240)'><div style='width:600px;height:70px;padding:10px;color:rgb(255, 255, 255);font-weight:bolder;text-align:center;font-size:20px;background:rgb(54,127,169);'><img src='http://www.wmdnigeria.com/images/icon.png' width='70px' height='70px' align='left' style='margin-top:-10px;padding:0px;' /><p>Federal Ministry of Industry Trade and Investment <br><span style='font-size:17px;'>Weights and Measures Department</span></div><div style='width:600px;font-size:13px;color:rgb(100,100,100);'><p> <div style='padding-left:10px; width:590px;'> <div style='font-weight:bolder;font-size:17px;'>" + Subject + "</div><p>" & Message & "</div> <a href='http://www.wmdnigeria.com/' style='text-decoration:none;width:auto;'><div style='margin-top:40px;padding: 5px 10px;width:100px;font-size: 14px;font-weight: bolder;line-height: 20px;text-align: center;cursor: pointer;border: 1px solid transparent;border-radius: 4px;background:rgb(54,127,169);color:rgb(255, 255, 255);'>Login Now</div> </div>           <p><div style='margin-top:100px;width:600px;height:auto;padding:10px;color:rgb(255, 255, 255);text-align:center;font-size:13px;background:rgb(54,127,169);'><strong>NOTICE: </strong>  The content of this e-mail is intended solely for the use of the individual or entity to whom it is addressed. If you have received this communication in error, beware that forwarding it, copying it or in any way disclosing its content to any other person or persons, is strictly prohibiting. If you have received this communication in error, please notify the author by replying this e-mail immediately.</div></body></html>"

                                'clsNotify.SendEmail(UserEmail, Subject, MessageBody, FromEmail(), True)

                            End If
                        Else

                            MessageBox.Show(Me, DateDifference.ToString)

                        End If

                    Next

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)

        Finally
            DisconnectDatabase()
        End Try
    End Sub
End Class