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

Public Class _default40
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

        End If

    End Sub


    Protected Sub ViewDownloadWorksheet(sender As Object, e As EventArgs)

        Dim File As String = InstrumentDetailGridView.SelectedRow.Cells(5).Text
        Dim SerialNumber = InstrumentDetailGridView.SelectedRow.Cells(2).Text
        Dim CompanyID = InstrumentDetailGridView.SelectedRow.Cells(0).Text
        Dim FileName = ""
        MessageBox.Show(Me, SerialNumber + " " + CompanyID)

        Try
            ConnectDatabase()

            Dim db As String = "SELECT inspectionSheet FROM deviceregistration WHERE companyID='" & CompanyID & "' AND serialNumber='" & SerialNumber & "' AND inspectionSheet='" & File & "'"

            Using cn As MySqlCommand = New MySqlCommand(db, conn)
                Using da As New MySqlDataAdapter(cn)

                    'Get the list of rows needed into Session, so as to enable us retreive it later

                    Dim dt As New DataTable()
                    Dim ds As New DataSet()
                    da.Fill(dt)
                    da.Fill(ds, "inspectionSheet")
                    FileName = ds.Tables(0).Rows(0).Item("inspectionSheet").ToString
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)
        Finally
            DisconnectDatabase()
            Response.Redirect("../../File Manager\UploadFiles\" & FileName)
        End Try

    End Sub



    Protected Sub RegisteredInstrumentGridView_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        InstrumentDetailGridView.PageIndex = e.NewPageIndex
        InstrumentDetailGridView.DataSource = CType(Cache("deviceregistration"), DataTable)
        InstrumentDetailGridView.DataBind()
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
     
    Public StringCompanyName, StringAmount, ReferenceNumber, LicenseStatus As String

    Protected Sub DispalyHistory_Click(sender As Object, e As EventArgs) Handles ShowHistory.Click

        Try
            ConnectDatabase()

            'Dim db As String = "SELECT D.companyID,D.companyName,D.companyEmail,D.deviceType,D.deviceModelName,D.serialNumber,D.deviceAmount,C.companyPhoneNumber FROM company C, deviceregistration D WHERE inspectionSubmitedBy='" & Session("UserLoginID") & "' AND C.ID = D.companyID ORDER BY D.ID DESC "
            Dim db As String = "SELECT * FROM company C, deviceregistration D WHERE D.companyID='" & CompanyName.SelectedValue & "' AND D.serialNumber='" & SearchInstrument.Text & "' AND C.ID = D.companyID ORDER BY D.ID DESC "


            Using cn As MySqlCommand = New MySqlCommand(db, conn)
                Using da As New MySqlDataAdapter(cn)

                    Dim dt As New DataTable()
                    Dim ds As New DataSet()
                    da.Fill(dt)
                    da.Fill(ds, "deviceregistration")

                    If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                        InstrumentHistoryPanel.Visible = False
                        SearchMessage.Text = "Oooops!!! Sorry, the instrument you searched could not be found."
                    Else
                        InstrumentHistoryPanel.Visible = True

                        ReferenceNumber = ds.Tables(0).Rows(0).Item("transCode")
                        StringAmount = ds.Tables(0).Rows(0).Item("deviceAmount")
                        StringCompanyName = ds.Tables(0).Rows(0).Item("companyName")

                        'MessageBox.Show(Me, ReferenceNumber + " " + CompanyName.SelectedValue)
                        InstrumentDetailGridView.DataSource = ds
                        InstrumentDetailGridView.DataMember = "deviceregistration"
                        InstrumentDetailGridView.DataBind()
                        Cache.Remove("deviceregistration")
                        Cache("deviceregistration") = dt



                        'Verification

                        Dim verificationquery As String = "SELECT * FROM deviceregistration WHERE companyID='" & CompanyName.SelectedValue & "' AND serialNumber='" & SearchInstrument.Text & "'   "
                        Using vcn As MySqlCommand = New MySqlCommand(verificationquery, conn)
                            Using vda As New MySqlDataAdapter(vcn)

                                Dim vdt As New DataTable()
                                Dim vds As New DataSet()
                                vda.Fill(vdt)
                                vda.Fill(vds, "deviceregistration")
                                If (vdt Is Nothing) Or (vdt.Rows.Count = 0) Then
                                    Verification.Visible = False
                                Else
                                    Verification.Visible = True
                                End If
                                VerificationGridView.DataSource = vds
                                VerificationGridView.DataMember = "deviceregistration"
                                VerificationGridView.DataBind()
                                Cache.Remove("deviceregistration")
                                Cache("deviceregistration") = vdt
                            End Using
                        End Using




                        'Adjustment

                        Dim adjustmentquery As String = "SELECT * FROM deviceservices WHERE transCode='" & ReferenceNumber & "' AND companyID='" & CompanyName.SelectedValue & "' AND serviceGroup='Adjusting Fees' ORDER BY ID DESC"
                        Using adcn As MySqlCommand = New MySqlCommand(adjustmentquery, conn)
                            Using adda As New MySqlDataAdapter(adcn)

                                Dim addt As New DataTable()
                                Dim adds As New DataSet()
                                adda.Fill(addt)
                                adda.Fill(adds, "deviceservices")
                                If (addt Is Nothing) Or (addt.Rows.Count = 0) Then
                                    Adjustment.Visible = False
                                Else
                                    Adjustment.Visible = True
                                End If
                                AdjustmentGridView.DataSource = adds
                                AdjustmentGridView.DataMember = "deviceservices"
                                AdjustmentGridView.DataBind()
                                Cache.Remove("deviceservices")
                                Cache("deviceservices") = addt
                            End Using
                        End Using





                        'Services

                        Dim servicesquery As String = "SELECT * FROM deviceservices WHERE transCode='" & ReferenceNumber & "' AND companyID='" & CompanyName.SelectedValue & "' AND serviceGroup='Instrument Services' ORDER BY ID DESC"
                        Using scn As MySqlCommand = New MySqlCommand(servicesquery, conn)
                            Using sda As New MySqlDataAdapter(scn)

                                Dim sdt As New DataTable()
                                Dim sds As New DataSet()
                                sda.Fill(sdt)
                                sda.Fill(sds, "deviceservices")
                                If (sdt Is Nothing) Or (sdt.Rows.Count = 0) Then
                                    Services.Visible = False
                                Else
                                    Services.Visible = True
                                End If
                                ServicesGridView.DataSource = sds
                                ServicesGridView.DataMember = "deviceservices"
                                ServicesGridView.DataBind()
                                Cache.Remove("deviceservices")
                                Cache("deviceservices") = sdt
                            End Using
                        End Using


                        'Pattern of Approval

                        Dim approvalquery As String = "SELECT * FROM deviceservices WHERE transCode='" & ReferenceNumber & "' AND companyID='" & CompanyName.SelectedValue & "' AND serviceGroup='Approval of Pattern ' ORDER BY ID DESC"
                        Using acn As MySqlCommand = New MySqlCommand(approvalquery, conn)
                            Using ada As New MySqlDataAdapter(acn)

                                Dim adt As New DataTable()
                                Dim ads As New DataSet()
                                ada.Fill(adt)
                                ada.Fill(ads, "deviceservices")
                                If (adt Is Nothing) Or (adt.Rows.Count = 0) Then
                                    Pattern.Visible = False
                                Else
                                    Pattern.Visible = True
                                End If
                                ApprovalPatternGridView.DataSource = ads
                                ApprovalPatternGridView.DataMember = "deviceservices"
                                ApprovalPatternGridView.DataBind()
                                Cache.Remove("deviceservices")
                                Cache("deviceservices") = adt
                            End Using
                        End Using




                        'Annual Licensing Fee
                        Dim licensingquery As String = "SELECT * FROM devicerenewal WHERE deviceReference='" & ReferenceNumber & "' AND companyID='" & CompanyName.SelectedValue & "' ORDER BY ID DESC"
                        Using lcn As MySqlCommand = New MySqlCommand(licensingquery, conn)
                            Using lda As New MySqlDataAdapter(lcn)

                                Dim ldt As New DataTable()
                                Dim lds As New DataSet()
                                lda.Fill(ldt)
                                lda.Fill(lds, "devicerenewal")

                                LicenseStatus = lds.Tables(0).Rows(0).Item("renewalStatus")
                                If LicenseStatus = "0" Then
                                    LicenseStatus = "Unpaid"
                                Else
                                    LicenseStatus = "Paid"
                                End If
                                AnnualLicensingGridView.DataSource = lds
                                AnnualLicensingGridView.DataMember = "devicerenewal"
                                AnnualLicensingGridView.DataBind()
                                Cache.Remove("devicerenewal")
                                Cache("devicerenewal") = ldt
                            End Using
                        End Using



                        'Legal Notices

                        Dim noticequery As String = "SELECT * FROM devicelegalnotices WHERE deviceID='" & SearchInstrument.Text & "'"
                        Using ncn As MySqlCommand = New MySqlCommand(noticequery, conn)
                            Using nda As New MySqlDataAdapter(ncn)

                                Dim ndt As New DataTable()
                                Dim nds As New DataSet()
                                nda.Fill(ndt)
                                nda.Fill(nds, "devicelegalnotices")
                                If (ndt Is Nothing) Or (ndt.Rows.Count = 0) Then
                                    Legal.Visible = False
                                Else
                                    Legal.Visible = True
                                End If
                                LegalNoticesGridView.DataSource = nds
                                LegalNoticesGridView.DataMember = "devicelegalnotices"
                                LegalNoticesGridView.DataBind()
                                Cache.Remove("devicelegalnotices")
                                Cache("devicelegalnotices") = ndt
                            End Using
                        End Using






                    End If

                   

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)
        End Try

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




    Protected Sub Inspection_Click(sender As Object, e As EventArgs) Handles Inspection.Click
        Response.Redirect("../inspection-worksheet/")
    End Sub

    Protected Sub VerificationBill_Click(sender As Object, e As EventArgs) Handles VerificationBill.Click
        Response.Redirect("../verification-bill/")
    End Sub



    Protected Sub Enforcement_Click(sender As Object, e As EventArgs) Handles Enforcement.Click
        Response.Redirect("../enforcement-worksheet/")
    End Sub


    Protected Sub Instrument_Click(sender As Object, e As EventArgs) Handles Instruments.Click
        Response.Redirect("./")
    End Sub

End Class