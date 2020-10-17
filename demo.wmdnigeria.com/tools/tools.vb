Imports System.IO
Imports System.Net
Imports System.Xml
Imports System.Web
Imports System.Data
Imports System.Text
Imports System.Net.Mail
Imports System.Web.Security
Imports System.Globalization
Imports System.Configuration
Imports MySql.Data.MySqlClient
Imports System.Collections.Generic
Imports System.Security.Cryptography
Imports System.Web.Script.Serialization




Module tools


    Public Function getSHA512Hash(ByVal strToHash As String) As String
        Dim SHA512Obj As New SHA512CryptoServiceProvider
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)

        bytesToHash = SHA512Obj.ComputeHash(bytesToHash)

        Dim strResult As String = ""

        For Each b As Byte In bytesToHash
            strResult += b.ToString("x2")
        Next
        Return strResult
    End Function


    Public Function GetPublicIP() As String
        Try
            Dim ExternalIP As String
            ExternalIP = (New WebClient()).DownloadString("http://checkip.dyndns.org/")
            ExternalIP = (New Regex("\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}")) _
                         .Matches(ExternalIP)(0).ToString()
            Return ExternalIP
        Catch
            Return Nothing
        End Try
    End Function

    Public Function GenerateRandomStringNumber(ByRef len As Integer, ByRef upper As Boolean) As String
        Dim rand As New Random()
        Dim allowableChars() As Char = "012345678ASi986574231".ToCharArray()
        Dim final As String = String.Empty
        For i As Integer = 0 To len - 1
            final += allowableChars(rand.Next(allowableChars.Length - 1))
        Next
        Return IIf(upper, final.ToUpper(), final)
    End Function


    Public Function GenerateRandomStringNumbers(ByRef len As Integer, ByRef upper As Boolean) As String
        Dim rand As New Random()
        Dim allowableChars() As Char = "1234567890".ToCharArray()
        Dim final As String = String.Empty
        For i As Integer = 0 To len - 1
            final += allowableChars(rand.Next(allowableChars.Length - 1))
        Next
        Return IIf(upper, final.ToUpper(), final)
    End Function


    Public Function GenerateRandomStringOrderID(ByRef len As Integer, ByRef upper As Boolean) As String
        Dim rand As New Random()
        Dim allowableChars() As Char = "26513784687138904".ToCharArray()
        Dim final As String = String.Empty
        For i As Integer = 0 To len - 1
            final += allowableChars(rand.Next(allowableChars.Length - 1))
        Next
        Return IIf(upper, final.ToUpper(), final)
    End Function


    'Function to get today's date
    Public Function TodaysDate()
        Dim TodayDate As Date = DateTime.Now
        Dim DateFormat As String = "dd-MM-yyyy"
        TodaysDate = TodayDate.ToString(DateFormat.ToString)
        Return TodaysDate
    End Function
    'Function to get current time

    'Function to get Current Year
    Public Function CurrentYear()
        CurrentYear = Today.Year
        Return CurrentYear()
    End Function
    'Function to get current time
    Public Function CurrentTim()

        Dim CurrentTime As DateTime = DateTime.Now
        Dim TimeFormat As String = "hh:mm tt"
        CurrentTim = CurrentTime.ToString(TimeFormat)
        Return CurrentTim
    End Function

    Public Function referenceCode()
        referenceCode = GenerateRandomStringNumbers(2, False) & GenerateRandomStringNumber(12, False)
        Return referenceCode
    End Function

    Public Function OrderID()
        OrderID = GenerateRandomStringOrderID(11, False)
        Return OrderID
    End Function


    Public Function GenerateRandomStringsSmall(ByRef len As Integer, ByRef upper As Boolean) As String
        Dim rand As New Random()
        Dim allowableChars() As Char = "abcdefghijklmnopqrstuvwxyz".ToCharArray()
        Dim final As String = String.Empty
        For i As Integer = 0 To len - 1
            final += allowableChars(rand.Next(allowableChars.Length - 1))
        Next

        Return IIf(upper, final.ToUpper(), final)

    End Function

    Public Function GenerateRandomStringsCapital(ByRef len As Integer, ByRef upper As Boolean) As String
        Dim rand As New Random()
        Dim allowableChars() As Char = "AYJSLKAJDWKHRGOUENBDZXCPQMI".ToCharArray()
        Dim final As String = String.Empty
        For i As Integer = 0 To len - 1
            final += allowableChars(rand.Next(allowableChars.Length - 1))
        Next

        Return IIf(upper, final.ToUpper(), final)

    End Function

    Public Function GenerateID()
        GenerateID = GenerateRandomStringNumbers(2, False) & GenerateRandomStringNumber(15, False)
    End Function

    Public Function GeneratePasswordResetCode()
        GeneratePasswordResetCode = GenerateRandomStringOrderID(6, False)
        Return GeneratePasswordResetCode
    End Function



    'This get client's browser type
    Public Function GetBrowserName() As String
        ''Dim userAgent As String = Request.UserAgent
        Dim userAgent As String = HttpContext.Current.Request.UserAgent
        'Dim userAgent As String = HttpContext.Current.Request.ServerVariables("HTTP_USER_AGENT")
        If userAgent.Contains("MSIE 5.0") Then
            Return "Internet Explorer 5.0"
        ElseIf userAgent.Contains("MSIE 6.0") Then
            Return "Internet Explorer 6.0"
        ElseIf userAgent.Contains("MSIE 7.0") Then
            Return "Internet Explorer 7.0"
        ElseIf userAgent.Contains("MSIE 8.0") Then
            Return "Internet Explorer 8.0"
        ElseIf userAgent.Contains("Firefox") Then
            Return userAgent.Substring(userAgent.IndexOf("Firefox")).Replace("/", " ")
        ElseIf userAgent.Contains("Opera") Then
            Return userAgent.Substring(userAgent.IndexOf("Opera"))
        ElseIf userAgent.Contains("Chrome") Then
            Dim agentPart As String = userAgent.Substring(userAgent.IndexOf("Chrome"))
            Return agentPart.Substring(0, agentPart.IndexOf("Safari") - 1).Replace("/", " ")
        ElseIf userAgent.Contains("Safari") Then
            Dim agentPart As String = userAgent.Substring(userAgent.IndexOf("Version"))
            Dim version As String = agentPart.Substring(0, agentPart.IndexOf("Safari") - 1).Replace("Version/", "")
            Return "Safari " & version
        ElseIf userAgent.Contains("Konqueror") Then
            Dim agentPart As String = userAgent.Substring(userAgent.IndexOf("Konqueror"))
            Return agentPart.Substring(0, agentPart.IndexOf(";")).Replace("/", " ")
        ElseIf userAgent.ToLower.Contains("bot") Or userAgent.ToLower.Contains("search") Then
            Return "Search Bot"
        End If
        Return "Unknown Browser or Bot"


    End Function

    Public Function ComputerName() As String
        ComputerName = System.Net.Dns.GetHostEntry(HttpContext.Current.Request.ServerVariables("REMOTE_ADDR")).HostName
        Return ComputerName
    End Function


    Public Function UserIP() As String
        UserIP = HttpContext.Current.Request.ServerVariables("REMOTE_ADDR") 'Request.ServerVariables("REMOTE_ADDR")
        Return UserIP
    End Function

    Public Function osVersion() As String
        osVersion = System.Environment.OSVersion.ToString()

        If osVersion.Contains("Windows") Then
            osVersion = "Windows Operating System"
        End If
        If osVersion.Contains("MAC") Then
            osVersion = "MAC Operating System"
        End If
        If osVersion.Contains("X11") Then
            osVersion = "UNIX Operating System"
        End If
        If osVersion.Contains("Linux") Then
            osVersion = "LINUX Operating System"
        End If

    End Function



    Public Function GetSMSAPI()
        ConnectDatabase()
        Dim db As String = "SELECT * FROM smsapi LIMIT 1"

        Using cn As MySqlCommand = New MySqlCommand(db, conn)
            Using da As New MySqlDataAdapter(cn)
                'Get the list of rows needed into Session, so as to enable us retreive it later
                Dim ds As New DataSet()
                da.Fill(ds)
                For Each Row As DataRow In ds.Tables(0).Rows
                    GetSMSAPI = (Row("APILink"))
                    Return GetSMSAPI
                Next
            End Using
        End Using
        DisconnectDatabase()
    End Function

    Public Function GetSMSUsername()
        ConnectDatabase()
        Dim db As String = "SELECT * FROM smsapi LIMIT 1"

        Using cn As MySqlCommand = New MySqlCommand(db, conn)
            Using da As New MySqlDataAdapter(cn)
                'Get the list of rows needed into Session, so as to enable us retreive it later
                Dim ds As New DataSet()
                da.Fill(ds)
                For Each Row As DataRow In ds.Tables(0).Rows
                    GetSMSUsername = (Row("APIUsername"))
                    Return GetSMSUsername
                Next
            End Using
        End Using
        DisconnectDatabase()
    End Function


    Public Function GetSMSPassword()
        ConnectDatabase()
        Dim db As String = "SELECT * FROM smsapi LIMIT 1"

        Using cn As MySqlCommand = New MySqlCommand(db, conn)
            Using da As New MySqlDataAdapter(cn)
                'Get the list of rows needed into Session, so as to enable us retreive it later
                Dim ds As New DataSet()
                da.Fill(ds)
                For Each Row As DataRow In ds.Tables(0).Rows
                    GetSMSPassword = (Row("APIPassword"))
                    Return GetSMSPassword

                Next
            End Using
        End Using
        DisconnectDatabase()
    End Function


    Public Sub SendSMS(ByVal pg As Page, ByVal APILink As String, ByVal username As String, ByVal password As String, ByVal sender As String, ByVal recipient As String, ByVal message As String)
        Dim SmsStatusMsg As String = String.Empty
        Try
            'Sending SMS To User
            Dim client As WebClient = New WebClient()
            Dim URL As String = APILink + "username=" + username + "&password=" + password + "&sender=" + sender + "&recipient=" + recipient + "&message=" + message

            SmsStatusMsg = client.DownloadString(URL)
            If SmsStatusMsg.Contains("<br>") Then
                SmsStatusMsg = SmsStatusMsg.Replace("<br>", ", ")
            End If

        Catch e1 As WebException
            SmsStatusMsg = e1.Message
        Catch e2 As Exception
            SmsStatusMsg = e2.Message
        Finally
            MessageBox.Show(pg, SmsStatusMsg)
        End Try

    End Sub


    Public Sub DoOnlinePayment(ByVal pg As Page, ByVal amount As String, ByVal orderId As String, ByVal Narration As String, ByVal email As String)
        Try

            'pg.Response.Clear()

            Dim sb = New StringBuilder()
            sb.Append("<html>")
            sb.AppendFormat("<body onload='document.forms[""form""].submit()'>")
            sb.AppendFormat("<form name='form' target='_top' action='{0}' method='post'>", "https://skyecipg.skyebankng.com/MerchantServices/MakePayment.aspx")

            sb.AppendFormat("<input type='hidden' name='mercId' value='{0}'>", "04225") '04225 '08641

            'sb.AppendFormat("<input type='hidden' name='currCode' value='{0}'>", "560")

            sb.AppendFormat("<input type='hidden' name='amt' value='{0}'>", amount)
            sb.AppendFormat("<input type='hidden' name='orderId' value='{0}'>", orderId)

            sb.AppendFormat("<input type='hidden' name='prod' value='{0}'>", Narration)

            sb.AppendFormat("<input type='hidden' name='email' value='{0}'>", email)

            sb.Append("</form>")
            sb.Append("</body>")
            sb.Append("</html>")

            pg.Response.Write(sb.ToString())

            pg.Response.End()

        Catch ex As Exception

        End Try
    End Sub


    Public Sub GetPaymentStatus(ByVal pg As Page, ByVal OrderID As String, ByVal Amount As String)
        Dim SmsStatusMsg As String = String.Empty
        Try

            'Get Client Online Payment Status
            Dim client As WebClient = New WebClient()
            Dim URL As String = "https://skyecipg.skyebankng.com/MerchantServices/TransactionStatusCheck.ashx?" + "MERCHANT_ID=04225&ORDER_ID=" + OrderID + "&CURR_CODE=566&AMOUNT=" + Amount + ""

            SmsStatusMsg = client.DownloadString(URL)
            If SmsStatusMsg.Contains("<br>") Then
                SmsStatusMsg = SmsStatusMsg.Replace("<br>", ", ")
            End If

        Catch e1 As WebException
            SmsStatusMsg = e1.Message
        Catch e2 As Exception
            SmsStatusMsg = e2.Message
        Finally
            'MessageBox.Show(pg, SmsStatusMsg)
            HttpContext.Current.Response.Write(SmsStatusMsg)
        End Try


    End Sub


    Public Function DeveloperNumber()
        DeveloperNumber = "07066998070,07038108429"
        Return DeveloperNumber
    End Function

    Public Function DeveloperEmail()
        DeveloperEmail = "johnrise2010@yahoo.com"
        Return DeveloperEmail
    End Function

    Public Function BulkSMSDefaultSender()
        BulkSMSDefaultSender = "WMD Portal"
        Return BulkSMSDefaultSender
    End Function

    Public Function SMSRecipientNumber()
        SMSRecipientNumber = HttpContext.Current.Session("UserLoginCompanyPhoneNumber") & "," & HttpContext.Current.Session("UserLoginCompanyFilledByMobile")
        Return SMSRecipientNumber
    End Function

    Public Function CompanyRegistrationMessage()
        CompanyRegistrationMessage = " Hi, " & HttpContext.Current.Session("CompanyName") & " has been registered successfully, kindly log on to http://www.wmdnigeria.com and login with your Username and Password. Thank you."
        Return CompanyRegistrationMessage
    End Function

    Public Function PasswordResetMessage()
        PasswordResetMessage = "Thank you for using WMD Portal, your password reset code is:  " & HttpContext.Current.Session("PasswordResetDigit") & "  for further assistance, please send an e-mail to " & SupportEmail() & " or call " & DeveloperNumber()
        Return PasswordResetMessage
    End Function

    Public Function PasswordChangedMessage()
        PasswordChangedMessage = "You have successfully changed your password for further assistance, please send an e-mail to " & SupportEmail() & " or call " & DeveloperNumber()
        Return PasswordChangedMessage
    End Function

    Public Function WalletMessage()
        WalletMessage = "Hi, your e-Wallet Account has successfully been funded with " & HttpContext.Current.Session("AmountPaid") & " , kindly log on to http://www.wmdnigeria.com to see your e-Wallet balance. Thank you."
        Return WalletMessage
    End Function

    Public Function CashWalletMessage()
        CashWalletMessage = "Hi, your e-Wallet cash payment was successful, your Wallet Account will be credited with: " & HttpContext.Current.Session("AmountPaid") & " once your payment has been confirmed and approved. Kindly log on to http://www.wmdnigeria.com to see your e-Wallet balance. Thank you."
        Return CashWalletMessage
    End Function

    Public Function BillingMessage()
        BillingMessage = "Hi, your payment for " & HttpContext.Current.Session("PaymentPurpose") & " has been successful, kindly log on to http://www.wmdnigeria.com to view payment history. Thank you."
        Return BillingMessage
    End Function

    Public Function LicensingFeeMessage()
        LicensingFeeMessage = "Hi, please be informed that " & HttpContext.Current.Session("InstrumentName") & " with serial no: " & HttpContext.Current.Session("InstrumentSerialNumber") & " has been registered successfully, kindly log on to http://www.wmdnigeria.com to to view your bill. Thank you."
        Return LicensingFeeMessage
    End Function


    Public Function InstrumentServiceMessage()
        InstrumentServiceMessage = "Hi, please be informed that " & HttpContext.Current.Session("InstrumentName") & " with " & HttpContext.Current.Session("InstrumentSerialNumber") & " has been registered for service, kindly log on to http://www.wmdnigeria.com to to view your bill. Thank you."
        Return InstrumentServiceMessage
    End Function

    Public Function OneMonthAnnualLicensingRenewalReminderMessage()
        OneMonthAnnualLicensingRenewalReminderMessage = "Hi, please be informed that Annual Licensing Renewal Fee for " & HttpContext.Current.Session("InstrumentName") & " with serial no: " & HttpContext.Current.Session("InstrumentSerialNumber") & " will be due for payment in one (1) month time, kindly log on to http://wwww.wmdnigeria.com to view your bill. Thank you."
        Return OneMonthAnnualLicensingRenewalReminderMessage()
    End Function

    Public Function OneWeekAnnualLicensingRenewalReminderMessage()
        OneWeekAnnualLicensingRenewalReminderMessage = "Hi, please be informed that Annual Licensing Renewal Fee for " & HttpContext.Current.Session("InstrumentName") & " with serial no: " & HttpContext.Current.Session("InstrumentSerialNumber") & " will be due for payment in one (1) week time, kindly log on to http://wwww.wmdnigeria.com to view your bill. Thank you."
        Return OneWeekAnnualLicensingRenewalReminderMessage
    End Function


    Public Function AnnualLicensingRenewalReminderMessage()
        AnnualLicensingRenewalReminderMessage = "Hi, please be informed that Annual Licensing Renewal Fee for " & HttpContext.Current.Session("InstrumentName") & " with serial no: " & HttpContext.Current.Session("InstrumentSerialNumber") & " is due for payment, kindly log on to http://wwww.wmdnigeria.com to view your bill. Thank you."
        Return AnnualLicensingRenewalReminderMessage
    End Function



    Public Function ServerToEmail()
        ServerToEmail = "johnrise2010@yahoo.com"
        Return ServerToEmail
    End Function

    Public Function NoReplyEmail()
        NoReplyEmail = "noreply@wmdnigeria.com"
        Return NoReplyEmail
    End Function

    Public Function SupportEmail()
        SupportEmail = "support@wmdnigeria.com"
        Return SupportEmail
    End Function

    Public Function AccountEmail()
        AccountEmail = "account@wmdnigeria.com"
        Return AccountEmail
    End Function

    Public Function AdminEmail()
        AdminEmail = "admin@wmdnigeria.com"
        Return AdminEmail
    End Function

    Public Function WMDPortalEmail()
        WMDPortalEmail = "wmdportal@wmdnigeria.com"
        Return WMDPortalEmail
    End Function

    Public Function ContactEmail()
        ContactEmail = "contact@wmdnigeria.com"
        Return ContactEmail
    End Function

    Public Function CPIEmail()
        CPIEmail = "contact@wmdnigeria.com"
        Return CPIEmail
    End Function

    Public Function FinanceEmail()
        FinanceEmail = "contact@wmdnigeria.com"
        Return FinanceEmail
    End Function

    Public Function NNLEmail()
        NNLEmail = "contact@nnlnigeria.com"
        Return NNLEmail
    End Function
    
    Public Class clsNotify 'Create a class that can be called from anywhere within your application

        Shared Sub SendEmail(ByVal strTo As String, ByVal strSubject As String, ByVal strBody As String, ByVal strFrom As String, Optional ByVal blnHTML As Boolean = True) 'Create Subroutine that can have parameters passed to it
            Try
                Dim mailmsg As New System.Net.Mail.MailMessage 'Declare Mail message variable
                Dim mailfrom As New System.Net.Mail.MailAddress(strFrom) 'Declare Mail Message Address, references strFrom passed from Sub

                Dim mailcred As New System.Net.Mail.SmtpClient 'Declare SMTP Client to pass credentials through
                Dim strRecipients() As String = strTo.Trim.Replace(" ", "").ToString.Split(";") 'Replace spaces and blanks with Semi Colon to deliniate recipiants addresses
                Dim smtpuser As New System.Net.NetworkCredential("noreply@wmdnigeria.com", "WMDn0r3ply") 'define SMTP user credentials

                mailmsg.To.Add(strRecipients(0)) 'Add Recipiants to MailMsg Variable
                mailmsg.IsBodyHtml = blnHTML 'Add HTML or just text for Email Body
                mailmsg.From = mailfrom 'Add Email from line, Can be anything really
                mailmsg.Subject = strSubject 'Add Subjec to mail Line
                mailmsg.Body = strBody 'Add Body as plain text incase users mail app doesn't support HTML mail
                mailmsg.Priority = MailPriority.High 'Set Priority if Desired

                Dim smtp As System.Net.Mail.SmtpClient = New System.Net.Mail.SmtpClient 'Declare SMTP Mail Client
                smtp.Host = "mail.wmdnigeria.com"
                smtp.Credentials = smtpuser
                smtp.Port = 25
                smtp.EnableSsl = False
                smtp.Timeout = 1000000
                smtp.ServicePoint.MaxIdleTime = 0
                smtp.Send(mailmsg)
            Catch ex As Exception
            End Try

        End Sub

        Shared Sub SendEmail(UserEmail As Object, Subject As String, MessageBody As Object, textBox As TextBox, p5 As Boolean)
            Throw New NotImplementedException
        End Sub

    End Class

    Public Class SendMail 'Create a class that can be called from anywhere within your application

        Shared Sub SendEmails(ByVal strTo As String, ByVal strSubject As String, ByVal strBody As String, ByVal strFrom As String, Optional ByVal blnHTML As Boolean = True) 'Create Subroutine that can have parameters passed to it
            Try
                Dim mailmsg As New System.Net.Mail.MailMessage 'Declare Mail message variable
                Dim mailfrom As New System.Net.Mail.MailAddress(strFrom) 'Declare Mail Message Address, references strFrom passed from Sub

                Dim mailcred As New System.Net.Mail.SmtpClient 'Declare SMTP Client to pass credentials through
                Dim strRecipients() As String = strTo.Trim.Replace(" ", "").ToString.Split(";") 'Replace spaces and blanks with Semi Colon to deliniate recipiants addresses
                Dim smtpuser As New System.Net.NetworkCredential("johnricho2010@gmail.com", "john2010") 'define SMTP user credentials

                mailmsg.To.Add(strRecipients(0)) 'Add Recipiants to MailMsg Variable
                mailmsg.IsBodyHtml = blnHTML 'Add HTML or just text for Email Body
                mailmsg.From = mailfrom 'Add Email from line, Can be anything really
                mailmsg.Subject = strSubject 'Add Subjec to mail Line
                mailmsg.Body = strBody 'Add Body as plain text incase users mail app doesn't support HTML mail
                mailmsg.Priority = MailPriority.High 'Set Priority if Desired

                Dim smtp As System.Net.Mail.SmtpClient = New System.Net.Mail.SmtpClient 'Declare SMTP Mail Client
                smtp.Host = "smtp.gmail.com"
                smtp.Credentials = smtpuser
                smtp.Port = 587
                smtp.EnableSsl = True
                smtp.Timeout = 1000000
                smtp.ServicePoint.MaxIdleTime = 0
                smtp.Send(mailmsg)
            Catch ex As Exception

            End Try
        End Sub


    End Class


    Public Class IPNetworking
        Public Shared Function GetIP4Address() As String
            Dim IP4Address As String = String.Empty

            For Each IPA As IPAddress In Dns.GetHostAddresses(HttpContext.Current.Request.UserHostAddress)
                If IPA.AddressFamily.ToString() = "InterNetwork" Then
                    IP4Address = IPA.ToString()
                    Exit For
                End If
            Next

            If IP4Address <> String.Empty Then
                Return IP4Address
            End If

            For Each IPA As IPAddress In Dns.GetHostAddresses(Dns.GetHostName())
                If IPA.AddressFamily.ToString() = "InterNetwork" Then
                    IP4Address = IPA.ToString()
                    Exit For
                End If
            Next

            Return IP4Address
        End Function
    End Class



    Public Class ServerIPAddress
        Public Shared Function GetIP4Address() As String
            Dim IP4Address As String = String.Empty

            For Each IPA As IPAddress In Dns.GetHostAddresses(HttpContext.Current.Request.ServerVariables("SERVER_NAME"))
                If IPA.AddressFamily.ToString() = "InterNetwork" Then
                    IP4Address = IPA.ToString()
                    Exit For
                End If
            Next
            If IP4Address <> String.Empty Then
                Return IP4Address
            End If

            For Each IPA As IPAddress In Dns.GetHostAddresses(Dns.GetHostName())
                If IPA.AddressFamily.ToString() = "InterNetwork" Then
                    IP4Address = IPA.ToString()
                    Exit For
                End If
            Next

            Return IP4Address
        End Function
    End Class




End Module
