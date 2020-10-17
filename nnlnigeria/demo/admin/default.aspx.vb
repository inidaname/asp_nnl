Imports System.IO
Imports System.Web
Imports System.Data
Imports System.Text
Imports System.Web.Security
Imports System.Configuration
Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Net



Public Class _default3
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

    'This code do the loggin magic
    Dim ComputerName, UserIP, osVersion As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session.Add("AdminLoginIPAddress", GetPublicIP())
    End Sub


    Private ds As New DataSet()
    Dim da As New MySqlDataAdapter()

    Dim DatabaseConnectionLogs As String = HttpContext.Current.Request.PhysicalApplicationPath & "databasefile\DBConnectionLogs.txt"

    Protected Sub AdminSigninButton_Click(sender As Object, e As EventArgs) Handles AdminSigninButton.Click

        'Execute below code if Admin dashboard login radio box is checked
        If DashboardAdmin.Checked = True Then

            Try

                Dim HashedPassword As String
                Dim EncodeMe As String = AdminPassword.Text
                HashedPassword = getSHA512Hash(EncodeMe)

                ConnectDatabase()
                Dim MyAdapter As New MySqlDataAdapter
                Dim SqlQuery = "SELECT * FROM admin WHERE username='" & AdminUsername.Text & "' AND password= '" & HashedPassword & "';"
                Dim Command As New MySqlCommand
                Command.Connection = conn
                Command.CommandText = SqlQuery
                MyAdapter.SelectCommand = Command
                Dim reader As MySqlDataReader
                reader = Command.ExecuteReader
                'Check if the credentials provided is in the database
                If reader.HasRows = 0 Then
                    MessageBox.Show(Me, "Error Login in: Invalid email or password")
                    reader.Close()
                    'Log user activity
                    Try
                        Dim Activity As String = "Login fail, either an Hacker is trying to hack this application or User is making mistake in Username or Password!"
                        Dim com As New MySqlCommand
                        com.Connection = conn
                        com.CommandText = "INSERT INTO userlog (activity,IPAddress,machineName,deviceType,browserName,logdate,logtime) VALUES ('" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "')"
                        com.ExecuteNonQuery()
                    Catch ex As Exception
                        MessageBox.Show(Me, ex.Message)
                    End Try

                ElseIf AdminUsername.Text = "" Or AdminPassword.Text = "" Then
                    MessageBox.Show(Me, "Error Login in: No field is allowed to be empty")
                    reader.Close()
                    'Log user activity
                    Try
                        Dim Activity As String = "Login fail, either an Hacker is trying to hack this application or User is making mistake in Username or Password! (" & AdminUsername.Text & ")"
                        Dim com As New MySqlCommand
                        com.Connection = conn
                        com.CommandText = "INSERT INTO userlog (activity,IPAddress,machineName,deviceType,browserName,logdate,logtime) VALUES ('" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "')"
                        com.ExecuteNonQuery()
                    Catch ex As Exception
                        MessageBox.Show(Me, ex.Message)
                    End Try

                Else
                    reader.Close()
                    Try

                        Dim db As String = "SELECT * FROM admin WHERE username='" & AdminUsername.Text & "';"

                        Using cn As MySqlCommand = New MySqlCommand(db, conn)
                            Using da As New MySqlDataAdapter(cn)
                                'Fill data of logged in user into dataset
                                da.Fill(ds)

                                'Get the list of rows needed into Session, so as to enable us retreive it later
                                For Each Row As DataRow In ds.Tables(0).Rows
                                    Session.Add("LoggedInAdminLoginID", (Row("ID")))
                                    Session.Add("LoggedInAdminLoginUsername", (Row("username")))
                                    Session.Add("LoggedInAdminLoginCompanyName", (Row("companyName")))
                                    Session.Add("LoggedInAdminLoginSurName", (Row("surname")))
                                    Session.Add("LoggedInAdminLoginOtherNames", (Row("otherNames")))
                                    Session.Add("LoggedInAdminLoginPhone", (Row("phone")))
                                    Session.Add("LoggedInAdminLoginEmail", (Row("email")))
                                    Session.Add("LoggedInAdminLoginContactAddress", (Row("contactAddress")))
                                    Session.Add("LoggedInAdminLoginSecurityQuestion", (Row("securityQuestion")))
                                    Session.Add("LoggedInAdminLoginSecurityAnswer", (Row("securityAnswer")))
                                    Session.Add("LoggedInAdminLoginAccountType", (Row("accountType")))
                                    Session.Add("LoggedInAdminLoginCompanyMgtRight", (Row("companyMgtRight")))
                                    Session.Add("LoggedInAdminLoginInstrumentMgtRight", (Row("instrumentMgtRight")))
                                    Session.Add("LoggedInAdminLoginStaticDataRight", (Row("staticDataRight")))
                                    Session.Add("LoggedInAdminLoginManageLot", (Row("manageLot")))
                                    Session.Add("LoggedInAdminLoginInvoiceReport", (Row("invoiceReport")))
                                    Session.Add("LoggedInAdminLoginReportRight", (Row("reportRight")))
                                    Session.Add("LoggedInAdminLoginExportPermitManagement", (Row("exportPermitMgt")))
                                    Session.Add("LoggedInAdminLoginImportPermitManagement", (Row("importPermitMgt")))
                                    Session.Add("LoggedInAdminLoginDownloadCenter", (Row("downloadCenter")))
                                    Session.Add("LoggedInAdminLoginUploadNews", (Row("uploadNews")))
                                    Session.Add("LoggedInAdminLoginOtherDocRight", (Row("otherDocRight")))
                                    Session.Add("LoggedInAdminLoginUploadGallery", (Row("uploadGallery")))
                                    Session.Add("LoggedInAdminLoginSetupOffice", (Row("setupOffice")))
                                    Session.Add("LoggedInAdminLoginExitExportImport", (Row("exitExportImport")))
                                    Session.Add("LoggedInAdminLoginLoadingExportImport", (Row("loadingExportImport")))
                                    Session.Add("LoggedInAdminLoginEntryExportImport", (Row("entryExportImport")))
                                    Session.Add("LoggedInAdminLoginApproveExportImport", (Row("approveExportImport")))
                                    Session.Add("LoggedInAdminLoginInspectExportImport", (Row("inspectExportImport")))
                                    Session.Add("LoggedInAdminLoginEndorseExportImport", (Row("endorseExportImport")))
                                    Session.Add("LoggedInAdminLoginRecommendExportImport", (Row("recommendExportImport")))
                                    Session.Add("LoggedInAdminLoginArchiveRight", (Row("archiveRight")))
                                    Session.Add("LoggedInAdminLoginQuizRight", (Row("quizRight")))
                                    Session.Add("LoggedInAdminLoginCareerRight", (Row("careerRight")))
                                    Session.Add("LoggedInAdminLoginInstrumentFee", (Row("instrumentFee")))
                                    Session.Add("LoggedInAdminLoginMeasurement", (Row("measurement")))
                                    Session.Add("LoggedInAdminLoginSettings", (Row("settings")))
                                    Session.Add("LoggedInAdminLoginExportDataReturn", (Row("exportDataReturn")))

                                    'Log user out activity
                                    Try
                                        Dim Activity As String = Session("LoggedInAdminLoginUsername") & "  (Admin) User logged in!"
                                        Dim com As New MySqlCommand
                                        com.Connection = conn
                                        com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                                        com.ExecuteNonQuery()
                                    Catch ex As Exception
                                        MessageBox.Show(Me, ex.Message)
                                    End Try
                                Next
                            End Using
                        End Using
                        'Trow errow is anything is wrong with the code
                    Catch ex As Exception
                        MessageBox.Show(Me, "Error:" & ex.Message)
                    End Try
                    Response.Redirect("dashboard/")
                End If
            Catch ex As Exception
                MessageBox.Show(Me, "Error:" & ex.Message)
            Finally
                DisconnectDatabase()
            End Try


        ElseIf DatabaseSetup.Checked = True Then

            If AdminUsername.Text = My.Settings.BackUsername And AdminPassword.Text = My.Settings.BackPassword Then
                Session.Add("LoggedInAdminLoginUsername", "Admin")
                Session.Add("LoggedInAdminLoginPassword", "DatabaseSetup")
                'If everything goes well, redirect to setup page
                Response.Redirect("setup/")

            ElseIf AdminUsername.Text = My.Settings.AdminUsername And AdminPassword.Text = My.Settings.AdminPassword Then
                Session.Add("LoggedInAdminLoginUsername", "Admin")
                Session.Add("LoggedInAdminLoginPassword", "DatabaseSetup")
                'If everything goes well, redirect to setup page
                Response.Redirect("setup/")
            ElseIf AdminUsername.Text = "" Or AdminPassword.Text = "" Then
                MessageBox.Show(Me, "No Fields should be left blank!")
                If Not File.Exists(DatabaseConnectionLogs) Then
                    ' Create a file to write to.  
                    Using objWriter As StreamWriter = File.CreateText(DatabaseConnectionLogs)
                        objWriter.WriteLine("Login fail, an Hacker perform SQL Injection Or Error from Admin End" & "   " & Session("AdminLoginIPAddress") & "   " & ComputerName & "   " & osVersion & "   " & TodaysDate() & "   " & CurrentTim())
                        objWriter.WriteLine("")
                        objWriter.Close()
                    End Using

                Else
                    ' Create a file to write to.  
                    Using objWriter As StreamWriter = File.AppendText(DatabaseConnectionLogs)
                        objWriter.WriteLine("Login fail, an Hacker perform SQL Injection Or Error from Admin End" & "   " & Session("AdminLoginIPAddress") & "   " & ComputerName & "   " & osVersion & "   " & TodaysDate() & "   " & CurrentTim())
                        objWriter.WriteLine("")
                        objWriter.Close()
                    End Using

                End If

            Else
                MessageBox.Show(Me, "Database setup login credentials is not correct!")

                If Not File.Exists(DatabaseConnectionLogs) Then

                    ' Create a file to write to.  
                    Using objWriter As StreamWriter = File.CreateText(DatabaseConnectionLogs)
                        objWriter.WriteLine("Login fail, an Hacker or Error from Admin End! Username Tried: " & AdminUsername.Text & " Password Tried: " & AdminPassword.Text & "   " & Session("AdminLoginIPAddress") & "   " & ComputerName & "   " & osVersion & "   " & TodaysDate() & "   " & CurrentTim())
                        objWriter.WriteLine("")
                        objWriter.Close()
                    End Using

                Else
                    ' Create a file to write to.  
                    Using objWriter As StreamWriter = File.AppendText(DatabaseConnectionLogs)
                        objWriter.WriteLine("Login fail, an Hacker or Error from Admin End! Username Tried: " & AdminUsername.Text & " Password Tried: " & AdminPassword.Text & "   " & Session("AdminLoginIPAddress") & "   " & ComputerName & "   " & osVersion & "   " & TodaysDate() & "   " & CurrentTim())
                        objWriter.WriteLine("")
                        objWriter.Close()
                    End Using

                End If


            End If

        End If


    End Sub


    Private Sub _default_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete

        Try
            Dim ServerName As String
            Dim ServerIP As String
            ServerName = Request.ServerVariables("SERVER_NAME")
            'ServerIP = System.Net.Dns.GetHostAddresses(ServerName).GetValue(0).ToString()
            ServerIP = ServerIPAddress.GetIP4Address()
            Dim ServerAddress = Request.ServerVariables("LOCAL_ADDR")
            Dim ServerPort = Request.ServerVariables("SERVER_PORT")
            'MessageBox.Show(Me, "Host Name: " & ServerName & " IP Address: " & ServerIP)
            ConnectDatabase()
            Dim MyAdapter As New MySqlDataAdapter
            Dim SqlQuery = "SELECT * FROM server"
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
                com.CommandText = "INSERT INTO server (serverIP,serverPort,serverAddress,serverName) VALUES ('" & ServerIP & "','" & ServerPort & "','" & ServerAddress & "','" & ServerName & "')"
                com.ExecuteNonQuery()
                'MessageBox.Show(Me, "Server configuration not registered, registering server configuration into database: " & ServerName & "   " & ServerIP & "   " & ServerAddress & "   " & ServerPort)
            Else
                reader.Close()
                Dim ServerAdapter As New MySqlDataAdapter
                Dim ServerQuery = "SELECT * FROM server WHERE serverIP='" & ServerIP & "' AND serverPort='" & ServerPort & "' AND serverAddress='" & ServerAddress & "' AND serverName='" & ServerName & "'"
                Dim ServerCommand As New MySqlCommand
                ServerCommand.Connection = conn
                ServerCommand.CommandText = ServerQuery
                ServerAdapter.SelectCommand = ServerCommand
                Dim serverReader As MySqlDataReader
                serverReader = ServerCommand.ExecuteReader
                'Check if the User has apply for export permit before
                If serverReader.HasRows = 0 Then
                    serverReader.Close()

                    Dim strSQL As String
                    strSQL = "UPDATE server SET serverIP='" & ServerIP & "',serverPort='" & ServerPort & "',serverAddress='" & ServerAddress & "',serverName='" & ServerName & "'"
                    Dim cmd As New MySqlCommand(strSQL, conn)
                    cmd.ExecuteNonQuery()
                    'MessageBox.Show(Me, "Server configuration has been changed: " & ServerName & "   " & ServerIP & "   " & ServerAddress & "   " & ServerPort)
                    Dim Message = "Server configuration has been changed.<p> Find below the new server details:<p> <strong> Server Name: </strong>" + ServerName + "<p> <strong> Server IP Address: </strong>" + ServerIP + "<p> <strong> Server Domain Address: </strong>" + ServerAddress + "<p> <strong> Server Port: </strong>" + ServerPort + "    <p> <strong>Thank you.</strong>"
                    Dim Subject = "Notification: Server has been moved!"
                    Dim MessageBody = "<html><head></head><body style='font-family:Tahoma; width:620px;font-size:13px;background:rgb(240,240, 240)'><div style='width:600px;height:70px;padding:10px;color:rgb(255, 255, 255);font-weight:bolder;text-align:center;font-size:20px;background:rgb(54,127,169);'><img src='http://www.wmdnigeria.com/images/icon.png' width='70px' height='70px' align='left' style='margin-top:-10px;padding:0px;' /><p>Federal Ministry of Industry Trade and Investment <br><span style='font-size:17px;'>Weights and Measures Department</span></div><div style='width:600px;font-size:13px;color:rgb(100,100,100);'><p> <div style='padding-left:10px; width:590px;'> <div style='font-weight:bolder;font-size:17px;'>" + Subject + "</div><p>" & Message & "</div> <a href='http://www.wmdnigeria.com/' style='text-decoration:none;width:auto;'><div style='margin-top:40px;padding: 5px 10px;width:100px;font-size: 14px;font-weight: bolder;line-height: 20px;text-align: center;cursor: pointer;border: 1px solid transparent;border-radius: 4px;background:rgb(54,127,169);color:rgb(255, 255, 255);'>Login Now</div> </div>           <p><div style='margin-top:100px;width:600px;height:auto;padding:10px;color:rgb(255, 255, 255);text-align:center;font-size:13px;background:rgb(54,127,169);'><strong>NOTICE: </strong>  The content of this e-mail is intended solely for the use of the individual or entity to whom it is addressed. If you have received this communication in error, beware that forwarding it, copying it or in any way disclosing its content to any other person or persons, is strictly prohibiting. If you have received this communication in error, please notify the author by replying this e-mail immediately.</div></body></html>"
                    clsNotify.SendEmail(ServerToEmail, Subject, MessageBody, AccountEmail(), True)
                Else
                    serverReader.Close()
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)
        Finally
            DisconnectDatabase()
        End Try

    End Sub

End Class