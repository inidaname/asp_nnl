Imports System.Web
Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Data.OleDb
Imports System.Web.Security
Imports System.Configuration
Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography


Public Class _default14
    Inherits System.Web.UI.Page

    Dim OrderNumber = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Session("Login")) Or Not Session("Login") = "True" Then
            Logout.Text = "LOGIN"
            ToolBar.Visible = False
            ' Headers.Attributes("style") = "height:110px"
            HeaderPanel.Height = 110
            Response.Redirect("../")

            RegistrationPanel.Visible = True


        Else
            Logout.Text = "LOGOUT"
            ToolBar.Visible = True

            RegistrationPanel.Visible = False

 
        End If

        Registration.Text = "REGISTER"
       
        If Session("Login") = True And Session("UserLoginUserType") = "WMD Inspector" Then
            Response.Redirect("../wmd-inspector/")

        ElseIf Session("Login") = True And Session("UserLoginUserType") = "CPI Inspector" Then
            Response.Redirect("../cpi-inspector/")

        ElseIf Session("Login") = True And Session("UserLoginUserType") = "Calibrator" Then
            Response.Redirect("../calibrator/")

        ElseIf Session("Login") = True And Session("UserLoginUserType") = "Authorized Verifier" Then
            Response.Redirect("../authorized-verifier/")

        End If

        If Not IsPostBack = True Then
            OrderNumber = OrderID()

            CertificateUploadPanel.Visible = False
            ApplyForApproval.Checked = True
            ApplyForVerification.Checked = True

            InstrumentTypeTxt.Visible = False
            InstrumentTxt.Visible = False

            RegisteredAddress.Visible = False

            BulkRegistration.Visible = False
            SaveInstrument.Visible = False
            Session.Remove("SelectedInstrumentSerialNo")
            'This populate state
            Try
                ConnectDatabase()

                Dim db As String = "SELECT * FROM state ORDER BY state ASC"

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

            Catch ex As Exception

                MessageBox.Show(Me, ex.Message)

            Finally
                'After execution of mysql query, disconnect database
                DisconnectDatabase()
            End Try


            'This populate Sector
            Try
                ConnectDatabase()

                Dim db As String = "SELECT * FROM sector ORDER BY sector ASC"

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)
                        
                        Dim dt As New DataTable()
                        da.Fill(dt)
                        Sector.DataSource = dt
                        Sector.DataTextField = "sector"
                        Sector.DataValueField = "ID"
                        Sector.DataBind()
                        Sector.Items.Insert(0, "...Select Sector...")


                    End Using
                End Using
                 
            Catch ex As Exception

                MessageBox.Show(Me, ex.Message)

            Finally
                'After execution of mysql query, disconnect database
                DisconnectDatabase()
            End Try


            'Display registered instrument data in data gridview 
            Try
                ConnectDatabase()

                Dim db As String = "SELECT * FROM deviceregistration WHERE CompanyID='" & Session("UserLoginID") & "'"

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)
                         
                        Dim dt As New DataTable()
                        Dim ds As New DataSet()
                        da.Fill(dt)
                        da.Fill(ds, "deviceregistration")

                        RegisteredInstrumentGridView.DataSource = Nothing
                        RegisteredInstrumentGridView.DataBind()

                        RegisteredInstrumentGridView.DataSource = ds
                        RegisteredInstrumentGridView.DataMember = "deviceregistration"
                        RegisteredInstrumentGridView.DataBind()

                        Cache("InstrumentData") = dt

                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            End Try



            'Post back
        Else
           
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

    Protected Sub UseMyAddress_CheckedChanged(sender As Object, e As EventArgs)

        If UseMyAddress.Checked = True Then
            RegisteredAddress.Visible = True

        ElseIf UseMyAddress.Checked = False Then
            RegisteredAddress.Visible = False

        End If

    End Sub



    Protected Sub BulkCheckedChanged(sender As Object, e As EventArgs) Handles BulkRegistratios.CheckedChanged
        If BulkRegistratios.Checked = True Then
            'MessageBox.Show(Me, "Bulk registration has been checked")
            BulkRegistration.Visible = True
            SingleRegistration.Visible = False

        ElseIf BulkRegistratios.Checked = False Then
            'MessageBox.Show(Me, "Bulk registration is not checked")

            BulkRegistration.Visible = False
            SingleRegistration.Visible = True

        End If

    End Sub

    'Protected Sub BulkReg_Click(sender As Object, e As EventArgs) Handles BulkReg.Click
    'Response.Redirect("./#upload-file", False)

    'End Sub


    Protected Sub State_SelectedIndexChanged(sender As Object, e As EventArgs)

        'This populate state
        Try
            ConnectDatabase()

            Dim db As String = "SELECT * FROM lga WHERE state='" & State.SelectedItem.Text & "' ORDER BY lga ASC"

            Using cn As MySqlCommand = New MySqlCommand(db, conn)
                Using da As New MySqlDataAdapter(cn)
                   
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    LGA.DataSource = dt
                    LGA.DataTextField = "lga"
                    LGA.DataValueField = "ID"
                    LGA.DataBind()

                End Using
            End Using
             
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
                  
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    City.DataSource = dt
                    City.DataTextField = "city"
                    City.DataValueField = "ID"
                    City.DataBind()

                End Using
            End Using
             
        Catch ex As Exception

            MsgBox(ex.Message)

        Finally
            'After execution of mysql query, disconnect database
            DisconnectDatabase()
        End Try


    End Sub


    Protected Sub Sector_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Sector.SelectedIndexChanged

        ActualMeasure.Text = ""
        InstrumentType.Items.Clear()
        InstrumentType.Items.Insert(0, "...Select Instrument...")
        Measurement.Items.Clear()
        Measurement.Items.Insert(0, "...Select Instrument Type...")
        MeasurementRang.Items.Clear()
        MeasurementRang.Items.Insert(0, "...Select Instrument Type...")
        'This populate device or instrument category 
        If Not Sector.SelectedItem.Text = "...Select Sector..." Then
            Try
                ConnectDatabase()

                Dim db As String = "SELECT * FROM devicecategories WHERE  sector='" & Sector.SelectedItem.Text & "' ORDER BY deviceCategory ASC"

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)
                       
                        Dim dt As New DataTable()
                        da.Fill(dt)
                        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                            InstrumentType.Visible = False
                            InstrumentTypeTxt.Visible = True

                        Else
                            InstrumentTypeTxt.Visible = False
                            InstrumentType.Visible = True
                            Instrument.DataSource = dt
                            Instrument.DataTextField = "deviceCategory"
                            Instrument.DataValueField = "ID"
                            Instrument.DataBind()
                            Instrument.Items.Insert(0, "...Select Category...")
                        End If

                    End Using
                End Using
                 
            Catch ex As Exception

                MessageBox.Show(Me, ex.Message)

            Finally
                'After execution of mysql query, disconnect database
                DisconnectDatabase()
            End Try
        Else
            MessageBox.Show(Me, "You must select a valid option in Sector")

        End If
    End Sub

    Protected Sub InstrumentCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Instrument.SelectedIndexChanged
        ActualMeasure.Text = ""
        MeasurementRang.Items.Clear()
        MeasurementRang.Items.Insert(0, "...Select Instrument Type...")
        'This populate device or instrument sub category 
        If Not Instrument.SelectedItem.Text = "...Select Category..." Then
            If Sector.SelectedItem.Text = "Others" And Instrument.SelectedItem.Text = "Others" Then
                ActualMeasureRangePanel.Visible = True
                MeasurementRangePanel.Visible = True

                Try
                    ConnectDatabase()
                    Dim db As String = "SELECT * FROM deviceprice WHERE NOT (above =0 AND notExceeding =0) GROUP BY measureRange" ' ORDER BY measureRange ASC"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)
                             
                            Dim dt As New DataTable()
                            da.Fill(dt)

                            InstrumentType.Visible = False
                            InstrumentTypeTxt.Visible = True

                            MeasurementRang.DataSource = dt
                            MeasurementRang.DataTextField = "measureRange"
                            MeasurementRang.DataValueField = "ID"
                            MeasurementRang.DataBind()

                            'Dim liFirst As New ListItem("", "")
                            'MeasurementRang.Items.Insert(7, liFirst)

                            Measurement.Items.Insert(0, "None")
                            Measurement.ClearSelection()

                        End Using
                    End Using
                     
                Catch ex As Exception

                    MessageBox.Show(Me, ex.Message)

                Finally
                    'After execution of mysql query, disconnect database
                    DisconnectDatabase()
                End Try

            ElseIf Not Sector.SelectedItem.Text = "Others" And Instrument.SelectedItem.Text = "Others" Then
                ActualMeasureRangePanel.Visible = True
                MeasurementRangePanel.Visible = True

                Try
                    ConnectDatabase()
                    Dim db As String = "SELECT * FROM deviceprice WHERE NOT (above =0 AND notExceeding =0) GROUP BY measureRange" ' ORDER BY measureRange ASC"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)
                             
                            Dim dt As New DataTable()
                            da.Fill(dt)

                            InstrumentType.Visible = False
                            InstrumentTypeTxt.Visible = True

                            MeasurementRang.DataSource = dt
                            MeasurementRang.DataTextField = "measureRange"
                            MeasurementRang.DataValueField = "ID"
                            MeasurementRang.DataBind()

                            'Dim liFirst As New ListItem("", "")
                            'MeasurementRang.Items.Insert(7, liFirst)
                            Measurement.Items.Clear()
                            Measurement.Items.Insert(0, "None")

                        End Using
                    End Using
                     
                Catch ex As Exception

                    MessageBox.Show(Me, ex.Message)

                Finally
                    'After execution of mysql query, disconnect database
                    DisconnectDatabase()
                End Try


            Else


                Try
                    ConnectDatabase()

                    Dim db As String = "SELECT * FROM devicesub WHERE deviceCategory='" & Instrument.SelectedItem.Text & "' ORDER BY deviceType ASC"

                    Using cn As MySqlCommand = New MySqlCommand(db, conn)
                        Using da As New MySqlDataAdapter(cn)
                            
                            Dim dt As New DataTable()
                            da.Fill(dt)

                            If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                                InstrumentType.Visible = False
                                InstrumentTypeTxt.Visible = True

                                Try
                                    Dim dbm As String = "SELECT * FROM deviceprice WHERE NOT (above =0 AND notExceeding =0) GROUP BY measureRange" ' ORDER BY measureRange ASC"

                                    Using cnm As MySqlCommand = New MySqlCommand(dbm, conn)
                                        Using dam As New MySqlDataAdapter(cnm)
                                          
                                            Dim dtm As New DataTable()
                                            dam.Fill(dtm)

                                            InstrumentType.Visible = False
                                            InstrumentTypeTxt.Visible = True

                                            MeasurementRang.DataSource = dtm
                                            MeasurementRang.DataTextField = "measureRange"
                                            MeasurementRang.DataValueField = "ID"
                                            MeasurementRang.DataBind()

                                            'Dim liFirst As New ListItem("", "")
                                            'MeasurementRang.Items.Insert(7, liFirst)
                                            Measurement.Items.Clear()
                                            Measurement.Items.Insert(0, "None")

                                        End Using
                                    End Using
                                     
                                Catch ex As Exception

                                    MessageBox.Show(Me, ex.Message)

                                Finally
                                    'After execution of mysql query, disconnect database
                                End Try

                            Else
                                InstrumentTypeTxt.Text = ""
                                InstrumentTypeTxt.Visible = False
                                InstrumentType.Visible = True
                                InstrumentType.DataSource = dt
                                InstrumentType.DataTextField = "deviceType"
                                InstrumentType.DataValueField = "ID"
                                InstrumentType.DataBind()
                                InstrumentType.Items.Insert(0, "...Select Instrument Type...")
                            End If


                        End Using
                    End Using
                     
                Catch ex As Exception

                    MessageBox.Show(Me, ex.Message)

                Finally
                    'After execution of mysql query, disconnect database
                    DisconnectDatabase()
                End Try


            End If

        Else
            MessageBox.Show(Me, "You must select a valid option in Instrument")
        End If

    End Sub

    Public TotalAmount As Double
    Dim dbs As String

    Protected Sub InstrumentType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles InstrumentType.SelectedIndexChanged
        ActualMeasure.Text = ""
        If Not InstrumentType.SelectedItem.Text = "...Select Instrument Type..." Then
            'This populate device or instrument measurement 
            Try
                ConnectDatabase()
                If InstrumentType.SelectedItem.Text = "Others" Then
                    dbs = "SELECT * FROM deviceprice WHERE NOT (above =0 AND notExceeding =0) GROUP BY measureRange"
                Else
                    dbs = "SELECT * FROM deviceprice WHERE deviceType='" & InstrumentType.SelectedItem.Text & "'"
                End If
                Using cn As MySqlCommand = New MySqlCommand(dbs, conn)
                    Using da As New MySqlDataAdapter(cn)
                        
                        Dim dt As New DataTable()
                        da.Fill(dt)
                        Dim ds As New DataSet()
                        da.Fill(ds, "deviceprice")

                        MeasurementRang.DataSource = dt
                        MeasurementRang.DataTextField = "measureRange"
                        MeasurementRang.DataValueField = "ID"
                        MeasurementRang.DataBind()
                        Session.Remove("SelectedInstrumentTypeMeasures")
                        Session.Add(("SelectedInstrumentTypeMeasures"), ds.Tables(0).Rows(0).Item("measureRange").ToString)
                        Session.Remove("TotalAmount")
                        Session.Add("TotalAmount", ds.Tables(0).Rows(0).Item("instrumentAmount").ToString)

                        If Session("SelectedInstrumentTypeMeasures") = InstrumentType.SelectedItem.Text Then
                            ActualMeasureRangePanel.Visible = False
                            MeasurementRangePanel.Visible = False
                            MessageBox.Show(Me, Session("SelectedInstrumentTypeMeasures") & ",   " & Session("TotalAmount"))
                        Else
                            ActualMeasureRangePanel.Visible = True
                            MeasurementRangePanel.Visible = True
                        End If


                    End Using
                End Using
                 
            Catch ex As Exception
                 
            Finally
                'After execution of mysql query, disconnect database
                DisconnectDatabase()
            End Try

        Else
            MessageBox.Show(Me, "You must select a valid option in Instrument Type")
        End If

    End Sub

    Public ActualMeasurement
    Dim db As String
    Sub ValidateActualMeasure_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ActualMeasure.TextChanged
        If MeasurementRang.SelectedItem.Text.Contains("Select Instrument Type") Or MeasurementRang.SelectedItem.Text.Contains("Select Measurement") Then
            MessageBox.Show(Me, "You have not select measurement range, please select an option to continue")
            ActualMeasure.Text = ""
            MeasurementRang.BorderColor = Drawing.Color.Red
            ModelNo.Enabled = False
            ModelName.Enabled = False
            Manufacturer.Enabled = False
            Location.Enabled = False
            SerialNo.Enabled = False
            RegisterInstrument.Enabled = False

            RegisterInstrument.BackColor = Drawing.Color.LightGray
            ActualMeasure.BorderColor = Drawing.Color.Red
            MeasurementRang.BorderColor = Drawing.Color.Red
            ModelNo.BackColor = Drawing.Color.LightGray
            ModelName.BackColor = Drawing.Color.LightGray
            Manufacturer.BackColor = Drawing.Color.LightGray
            Location.BackColor = Drawing.Color.LightGray
            SerialNo.BackColor = Drawing.Color.LightGray

        End If


        If Not IsNumeric(ActualMeasure.Text) Then
            MessageBox.Show(Me, "Only numbers is allowed!")
            ActualMeasure.Text = ""
        End If

        If System.Text.RegularExpressions.Regex.IsMatch(ActualMeasure.Text, "[  ^ 0-9]") Then


            Try
                ConnectDatabase()

                If InstrumentType.SelectedItem.Text = "Others" Then
                    db = "SELECT * FROM deviceprice WHERE measureRange = '" & MeasurementRang.SelectedItem.Text & "'"

                ElseIf Instrument.SelectedItem.Text = "Others" Or InstrumentType.SelectedItem.Text = "Others" Then
                    db = "SELECT * FROM deviceprice WHERE measureRange = '" & MeasurementRang.SelectedItem.Text & "'"
                ElseIf InstrumentType.SelectedItem.Text = "Others" And Not Instrument.SelectedItem.Text = "Others" Then
                    db = "SELECT * FROM deviceprice WHERE measureRange = '" & MeasurementRang.SelectedItem.Text & "'"

                Else
                    db = "SELECT * FROM deviceprice WHERE deviceType='" & InstrumentType.SelectedItem.Text & "' AND measureRange = '" & MeasurementRang.SelectedItem.Text & "'"
                End If

                Using cn As MySqlCommand = New MySqlCommand(db, conn)
                    Using da As New MySqlDataAdapter(cn)
                        
                        Dim dt As New DataTable()
                        da.Fill(dt)
                        Dim ds As New DataSet()
                        da.Fill(ds)

                        Dim AmountFirst = ds.Tables(0).Rows(0).Item("amountFirst").ToString
                        Dim AmountAboveMax = ds.Tables(0).Rows(0).Item("amountAboveMax").ToString
                        Dim Above = ds.Tables(0).Rows(0).Item("above").ToString
                        Dim NotExceeding = ds.Tables(0).Rows(0).Item("notExceeding").ToString
                        Dim isMax = ds.Tables(0).Rows(0).Item("isMax").ToString
                        Dim InstrumentAmount = ds.Tables(0).Rows(0).Item("instrumentAmount").ToString
                        Dim OccurenceValue = ds.Tables(0).Rows(0).Item("occurenceValue").ToString
                        Dim PartThereOf = ds.Tables(0).Rows(0).Item("partThereOf").ToString


                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If Not isMax = Nothing And isMax = "0" And Above = "0" And NotExceeding = "0" Then
                            If ActualMeasure.Text = Nothing Then

                                TotalAmount = InstrumentAmount
                                Session.Add("TotalAmount", TotalAmount)

                                MessageBox.Show(Me, "This have no maximum value  " & isMax & ",      " & InstrumentAmount & ",   Total Amount =   " & TotalAmount)
                                ModelNo.Enabled = True
                                ModelName.Enabled = True
                                Manufacturer.Enabled = True
                                Location.Enabled = True
                                SerialNo.Enabled = True
                                RegisterInstrument.Enabled = True

                                RegisterInstrument.BackColor = Drawing.Color.Empty
                                ActualMeasure.BorderColor = Drawing.Color.Empty
                                MeasurementRang.BorderColor = Drawing.Color.Empty
                                ModelNo.BackColor = Drawing.Color.Empty
                                ModelName.BackColor = Drawing.Color.Empty
                                Manufacturer.BackColor = Drawing.Color.Empty
                                Location.BackColor = Drawing.Color.Empty
                                SerialNo.BackColor = Drawing.Color.Empty

                            ElseIf ActualMeasure.Text >= 1 Then

                                TotalAmount = InstrumentAmount '* ActualMeasure.Text
                                Session.Add("TotalAmount", TotalAmount)
                                MessageBox.Show(Me, "This have no maximum value  " & isMax & ",      " & InstrumentAmount & ",   Total Amount =   " & TotalAmount)
                                ModelNo.Enabled = True
                                ModelName.Enabled = True
                                Manufacturer.Enabled = True
                                Location.Enabled = True
                                SerialNo.Enabled = True
                                RegisterInstrument.Enabled = True

                                RegisterInstrument.BackColor = Drawing.Color.Empty
                                ActualMeasure.BorderColor = Drawing.Color.Empty
                                MeasurementRang.BorderColor = Drawing.Color.Empty
                                ModelNo.BackColor = Drawing.Color.Empty
                                ModelName.BackColor = Drawing.Color.Empty
                                Manufacturer.BackColor = Drawing.Color.Empty
                                Location.BackColor = Drawing.Color.Empty
                                SerialNo.BackColor = Drawing.Color.Empty

                            End If


                        ElseIf Not isMax = Nothing And isMax = "0" And Above = "0" Then


                            If ActualMeasure.Text = 0 Then
                                ActualMeasure.Text = ""
                                ActualMeasure.BorderColor = Drawing.Color.Red
                                MessageBox.Show(Me, "Error: Actual Measurement Cannot be Empty and Must be Greater than Zero (0) !")

                            ElseIf ActualMeasure.Text >= NotExceeding + 1 Or ActualMeasure.Text = "0" Then
                                ActualMeasure.Text = ""
                                ActualMeasure.BorderColor = Drawing.Color.Red
                                MessageBox.Show(Me, "Error: Actual Measurement cannot be Higher or Lower than the value of Measurement Range Selected !")

                            Else
                                TotalAmount = InstrumentAmount '* ActualMeasure.Text
                                Session.Add("TotalAmount", TotalAmount)
                                MessageBox.Show(Me, "This have no maximum value  " & isMax & ",      " & InstrumentAmount & ",   Total Amount =   " & TotalAmount)
                                ModelNo.Enabled = True
                                ModelName.Enabled = True
                                Manufacturer.Enabled = True
                                Location.Enabled = True
                                SerialNo.Enabled = True
                                RegisterInstrument.Enabled = True

                                RegisterInstrument.BackColor = Drawing.Color.Empty
                                ActualMeasure.BorderColor = Drawing.Color.Empty
                                MeasurementRang.BorderColor = Drawing.Color.Empty
                                ModelNo.BackColor = Drawing.Color.Empty
                                ModelName.BackColor = Drawing.Color.Empty
                                Manufacturer.BackColor = Drawing.Color.Empty
                                Location.BackColor = Drawing.Color.Empty
                                SerialNo.BackColor = Drawing.Color.Empty

                            End If

                        ElseIf Not isMax = Nothing And isMax = "0" And NotExceeding = "0" Then

                            If ActualMeasure.Text = 0 Then
                                ActualMeasure.Text = ""
                                ActualMeasure.BorderColor = Drawing.Color.Red
                                MessageBox.Show(Me, "Error: Actual Measurement Cannot be Empty and Must be Greater than Zero (0) !")

                            ElseIf ActualMeasure.Text <= Above - 1 Or ActualMeasure.Text = "0" Then
                                ActualMeasure.Text = ""
                                ActualMeasure.BorderColor = Drawing.Color.Red
                                MessageBox.Show(Me, "Error: Actual Measurement cannot be Higher or Lower than the value of Measurement Range Selected !")

                            Else
                                TotalAmount = InstrumentAmount '* ActualMeasure.Text
                                Session.Add("TotalAmount", TotalAmount)
                                MessageBox.Show(Me, "This have no maximum value  " & isMax & ",      " & InstrumentAmount & ",   Total Amount =   " & TotalAmount)
                                ModelNo.Enabled = True
                                ModelName.Enabled = True
                                Manufacturer.Enabled = True
                                Location.Enabled = True
                                SerialNo.Enabled = True
                                RegisterInstrument.Enabled = True

                                RegisterInstrument.BackColor = Drawing.Color.Empty
                                ActualMeasure.BorderColor = Drawing.Color.Empty
                                MeasurementRang.BorderColor = Drawing.Color.Empty
                                ModelNo.BackColor = Drawing.Color.Empty
                                ModelName.BackColor = Drawing.Color.Empty
                                Manufacturer.BackColor = Drawing.Color.Empty
                                Location.BackColor = Drawing.Color.Empty
                                SerialNo.BackColor = Drawing.Color.Empty


                            End If

                        ElseIf Not isMax = Nothing And isMax = "0" Then
                            If ActualMeasure.Text = 0 Then
                                ActualMeasure.Text = ""
                                ActualMeasure.BorderColor = Drawing.Color.Red
                                MessageBox.Show(Me, "Error: Actual Measurement Cannot be Empty and Must be Greater than Zero (0) !")

                            ElseIf ActualMeasure.Text <= Above - 1 Or ActualMeasure.Text = "0" Or ActualMeasure.Text >= NotExceeding + 1 Then
                                ActualMeasure.Text = ""
                                ActualMeasure.BorderColor = Drawing.Color.Red
                                MessageBox.Show(Me, "Error: Actual Measurement cannot be Higher or Lower than the value of Measurement Range Selected !")

                            Else
                                TotalAmount = InstrumentAmount '* ActualMeasure.Text
                                Session.Add("TotalAmount", TotalAmount)
                                MessageBox.Show(Me, "This have no maximum value  " & isMax & ",      " & InstrumentAmount & ",   Total Amount =   " & TotalAmount)
                                ModelNo.Enabled = True
                                ModelName.Enabled = True
                                Manufacturer.Enabled = True
                                Location.Enabled = True
                                SerialNo.Enabled = True
                                RegisterInstrument.Enabled = True

                                RegisterInstrument.BackColor = Drawing.Color.Empty
                                ActualMeasure.BorderColor = Drawing.Color.Empty
                                MeasurementRang.BorderColor = Drawing.Color.Empty
                                ModelNo.BackColor = Drawing.Color.Empty
                                ModelName.BackColor = Drawing.Color.Empty
                                Manufacturer.BackColor = Drawing.Color.Empty
                                Location.BackColor = Drawing.Color.Empty
                                SerialNo.BackColor = Drawing.Color.Empty


                            End If

                            'This is the calculation for the Part Thereof
                        ElseIf Not isMax = Nothing And isMax = "1" Then

                            If ActualMeasure.Text = "0" Then
                                ActualMeasure.Text = ""
                                ActualMeasure.BorderColor = Drawing.Color.Red
                                MessageBox.Show(Me, "Error: Actual Measurement Cannot be Empty and Must be Greater than Zero (0) !")

                            ElseIf ActualMeasure.Text <= OccurenceValue - 1 Then
                                ActualMeasure.Text = ""
                                ActualMeasure.BorderColor = Drawing.Color.Red
                                MessageBox.Show(Me, "Error: Actual Measurement cannot be Lower than the value of Measurement Range Selected !")

                            Else
                                ActualMeasure.BorderColor = Drawing.Color.Empty

                                Dim ToCalculate = ActualMeasure.Text - OccurenceValue

                                TotalAmount = ToCalculate * AmountAboveMax + AmountFirst
                                Session.Add("TotalAmount", TotalAmount)
                                MessageBox.Show(Me, "This have maximum value  " & isMax & ",      " & ToCalculate & ",   Total Amount =   " & TotalAmount)


                                ModelNo.Enabled = True
                                ModelName.Enabled = True
                                Manufacturer.Enabled = True
                                Location.Enabled = True
                                SerialNo.Enabled = True
                                RegisterInstrument.Enabled = True

                                RegisterInstrument.BackColor = Drawing.Color.Empty
                                ActualMeasure.BorderColor = Drawing.Color.Empty
                                MeasurementRang.BorderColor = Drawing.Color.Empty
                                ModelNo.BackColor = Drawing.Color.Empty
                                ModelName.BackColor = Drawing.Color.Empty
                                Manufacturer.BackColor = Drawing.Color.Empty
                                Location.BackColor = Drawing.Color.Empty
                                SerialNo.BackColor = Drawing.Color.Empty

                            End If

                        End If


                    End Using
                End Using
            Catch ex As Exception

                MessageBox.Show(Me, ex.Message)

            Finally
                'After execution of mysql query, disconnect database
                DisconnectDatabase()
            End Try







        Else
            MessageBox.Show(Me, "Only numbers is allowed!")
            ActualMeasure.Text = ""

        End If



    End Sub

    Sub ValidateActualMeasure_TextChanged(sender As Object, e As EventArgs) Handles ActualMeasure.TextChanged
        If ActualMeasure.Text = "" Or ActualMeasure.Text = "0" Then
            ActualMeasure.Text = ""
            MessageBox.Show(Me, "Actual Measurement cannot be empty, to continue, enter a value!")
            ModelNo.Enabled = False
            ModelName.Enabled = False
            Manufacturer.Enabled = False
            Location.Enabled = False
            SerialNo.Enabled = False
            RegisterInstrument.Enabled = False

            RegisterInstrument.BackColor = Drawing.Color.LightGray
            ActualMeasure.BorderColor = Drawing.Color.Red
            MeasurementRang.BorderColor = Drawing.Color.Red
            ModelNo.BackColor = Drawing.Color.LightGray
            ModelName.BackColor = Drawing.Color.LightGray
            Manufacturer.BackColor = Drawing.Color.LightGray
            Location.BackColor = Drawing.Color.LightGray
            SerialNo.BackColor = Drawing.Color.LightGray


        End If
    End Sub

    Protected Sub MeasureRange_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MeasurementRang.SelectedIndexChanged
        ActualMeasure.Text = ""
        
    End Sub

    Protected Sub SelectCertificateToUpload_CheckedChanged(sender As Object, e As EventArgs)

        If ApplyForApproval.Checked = True And ApplyForVerification.Checked = True Then
            ApprovalCertificateUploadPanel.Visible = False
            InitialCertificateUploadPanel.Visible = False
            CertificateUploadPanel.Visible = False

        ElseIf ApprovalCertificate.Checked = True And VerificationCertificate.Checked = True Then
            ApprovalCertificateUploadPanel.Visible = True
            InitialCertificateUploadPanel.Visible = True
            CertificateUploadPanel.Visible = True
            PatternOfApprovalUpload.Visible = True
            PeriodicVerificationUpload.Visible = True

        ElseIf ApprovalCertificate.Checked = True And VerificationCertificate.Checked = False Then
            CertificateUploadPanel.Visible = True
            ApprovalCertificateUploadPanel.Visible = True
            PatternOfApprovalUpload.Visible = True

        ElseIf VerificationCertificate.Checked = True And ApprovalCertificate.Checked = False Then
            CertificateUploadPanel.Visible = True
            InitialCertificateUploadPanel.Visible = True
            PeriodicVerificationUpload.Visible = True

        ElseIf ApprovalCertificate.Checked = True And VerificationCertificate.Checked = True Then
            CertificateUploadPanel.Visible = True
            ApprovalCertificateUploadPanel.Visible = True

        ElseIf VerificationCertificate.Checked = True And ApprovalCertificate.Checked = True Then
            CertificateUploadPanel.Visible = True
            InitialCertificateUploadPanel.Visible = True

        ElseIf ApprovalCertificate.Checked = True Then
            CertificateUploadPanel.Visible = True
            ApprovalCertificateUploadPanel.Visible = True

        ElseIf VerificationCertificate.Checked = True Then
            CertificateUploadPanel.Visible = True
            InitialCertificateUploadPanel.Visible = True


        End If


        If ApplyForApproval.Checked = True And ApplyForVerification.Checked = False Then
            ApprovalCertificateUploadPanel.Visible = False

        ElseIf ApplyForVerification.Checked = True And ApplyForApproval.Checked = False Then
            InitialCertificateUploadPanel.Visible = False

        ElseIf ApplyForApproval.Checked = True And ApplyForVerification.Checked = True Then
            CertificateUploadPanel.Visible = False

        ElseIf ApplyForVerification.Checked = True And ApplyForApproval.Checked = True Then
            CertificateUploadPanel.Visible = False


        ElseIf ApplyForApproval.Checked = True Then
            ApprovalCertificateUploadPanel.Visible = False

        ElseIf ApplyForVerification.Checked = True Then
            InitialCertificateUploadPanel.Visible = False




        End If
    End Sub




    Dim UploadPath As String = HttpContext.Current.Request.PhysicalApplicationPath & "File Manager\InstrumentFiles\"


    Dim UserNameOfCompany, UserEmail, UserAddress, UserWebsite, UserPOBox, UserState, UserLGA, UserCity As String

    Protected Sub ContinueRegistration_Click(sender As Object, e As EventArgs) Handles ContinueRegistration.Click
        If ApplyForApproval.Checked = True Then
            ApplyForApprovalNowPanel.Visible = True
        Else
            ApplyForApprovalNowPanel.Visible = False
        End If

        CompanyName.Enabled = False
        Email.Enabled = False
        Address.Enabled = False
        Website.Enabled = False
        POBox.Enabled = False
        State.Enabled = False
        LGA.Enabled = False
        City.Enabled = False
        Sector.Enabled = False
        Instrument.Enabled = False
        InstrumentType.Enabled = False
        MeasurementRang.Enabled = False
        ActualMeasure.Enabled = False
        ModelNo.Enabled = False
        SerialNo.Enabled = False
        Manufacturer.Enabled = False
        ModelName.Enabled = False
        Location.Enabled = False

        'RegisteredAddress.Visible = True
        CompanyName.BorderColor = Drawing.Color.Transparent
        Email.BorderColor = Drawing.Color.Transparent
        Address.BorderColor = Drawing.Color.Transparent
        Website.BorderColor = Drawing.Color.Transparent
        POBox.BorderColor = Drawing.Color.Transparent
        State.BorderColor = Drawing.Color.Transparent
        LGA.BorderColor = Drawing.Color.Transparent
        City.BorderColor = Drawing.Color.Transparent
        Sector.BorderColor = Drawing.Color.Transparent
        Instrument.BorderColor = Drawing.Color.Transparent
        InstrumentType.BorderColor = Drawing.Color.Transparent
        MeasurementRang.BorderColor = Drawing.Color.Transparent
        ActualMeasure.BorderColor = Drawing.Color.Transparent
        ModelNo.BorderColor = Drawing.Color.Transparent
        SerialNo.BorderColor = Drawing.Color.Transparent
        Manufacturer.BorderColor = Drawing.Color.Transparent
        ModelName.BorderColor = Drawing.Color.Transparent
        Location.BorderColor = Drawing.Color.Transparent

        ContinueRegistration.Visible = False
        ModifyRegistration.Visible = True
        RegisterInstrument.Visible = True
    End Sub


    Protected Sub ModifyForm_Click(sender As Object, e As EventArgs) Handles ModifyRegistration.Click
        MessageBox.Show(Me, "This is a preview of your form, please make sure everything is in order before you click on Register!")

        CompanyName.Enabled = True
        Email.Enabled = True
        Address.Enabled = True
        Website.Enabled = True
        POBox.Enabled = True
        State.Enabled = True
        LGA.Enabled = True
        City.Enabled = True
        Sector.Enabled = True
        Instrument.Enabled = True
        InstrumentType.Enabled = True
        MeasurementRang.Enabled = True
        ActualMeasure.Enabled = True
        ModelNo.Enabled = True
        SerialNo.Enabled = True
        Manufacturer.Enabled = True
        ModelName.Enabled = True
        Location.Enabled = True

        'RegisteredAddress.Visible = True
        CompanyName.BorderColor = Drawing.Color.Empty
        Email.BorderColor = Drawing.Color.Empty
        Address.BorderColor = Drawing.Color.Empty
        Website.BorderColor = Drawing.Color.Empty
        POBox.BorderColor = Drawing.Color.Empty
        State.BorderColor = Drawing.Color.Empty
        LGA.BorderColor = Drawing.Color.Empty
        City.BorderColor = Drawing.Color.Empty
        Sector.BorderColor = Drawing.Color.Empty
        Instrument.BorderColor = Drawing.Color.Empty
        InstrumentType.BorderColor = Drawing.Color.Empty
        MeasurementRang.BorderColor = Drawing.Color.Empty
        ActualMeasure.BorderColor = Drawing.Color.Empty
        ModelNo.BorderColor = Drawing.Color.Empty
        SerialNo.BorderColor = Drawing.Color.Empty
        Manufacturer.BorderColor = Drawing.Color.Empty
        ModelName.BorderColor = Drawing.Color.Empty
        Location.BorderColor = Drawing.Color.Empty

        ContinueRegistration.Visible = True
        ModifyRegistration.Visible = False
        RegisterInstrument.Visible = False
    End Sub
    Protected Sub RegisterInstrument_Click(sender As Object, e As EventArgs) Handles RegisterInstrument.Click
       
        If UseMyAddress.Checked = False Then
            UserNameOfCompany = Session("UserLoginCompanyName")
            UserEmail = Session("UserLoginCompanyEmail")
            UserAddress = Session("UserLoginCompanyAddress")
            UserWebsite = Session("UserLoginCompanyWebsite")
            UserPOBox = Session("UserLoginCompanyPOBox")
            UserState = Session("UserLoginCompanyState")
            UserLGA = Session("UserLoginCompanyLGA")
            UserCity = Session("UserLoginCompanyCity")
        Else
            UserNameOfCompany = CompanyName.Text
            UserEmail = Email.Text
            UserAddress = Address.Text
            UserWebsite = Website.Text
            UserPOBox = POBox.Text
            UserState = State.Text
            UserLGA = LGA.Text
            UserCity = City.Text
        End If

        If UseMyAddress.Checked = True Then
            If Email.Text = "" Or Address.Text = "" Or Website.Text = "" Or POBox.Text = "" Or State.Text = "" Or LGA.Text = "" Or City.Text = "" Then
                MessageBox.Show(Me, "Fields cannot be empty in Address Section! Check Use My Address box to use registered address!")

            End If

        ElseIf Session("SelectedInstrumentTypeMeasures") = "" And ActualMeasure.Text = "" Or ModelNo.Text = "" Or ModelName.Text = "" Or SerialNo.Text = "" Or Manufacturer.Text = "" Or Location.Text = "" Then

            MessageBox.Show(Me, "No Field should be left blank!")


        Else

            Dim ApprovalCertificat As String
            If ApprovalCertificate.Checked = True Then
                ApprovalCertificat = "1"
            Else
                ApprovalCertificat = "0"
            End If

            Dim ApplyApprovalCertificat As String
            If ApplyForApproval.Checked = True Then
                ApplyApprovalCertificat = "1"
            Else
                ApplyApprovalCertificat = "0"
            End If

            Dim VerificationCertificat As String
            If VerificationCertificate.Checked = True Then
                VerificationCertificat = "1"
            Else
                VerificationCertificat = "0"
            End If

            Dim ApplyForVerificationCertificat As String
            If ApplyForVerification.Checked = True Then
                ApplyForVerificationCertificat = "1"
            Else
                ApplyForVerificationCertificat = "0"
            End If


            Try

                ConnectDatabase()

                Dim MyAdapter As New MySqlDataAdapter

                Dim SqlQuery = "SELECT * FROM deviceregistration WHERE serialNumber='" & SerialNo.Text & "' AND companyID= '" & Session("UserLoginID") & "';"
                Dim Command As New MySqlCommand
                Command.Connection = conn
                Command.CommandText = SqlQuery
                MyAdapter.SelectCommand = Command

                Dim reader As MySqlDataReader
                reader = Command.ExecuteReader
                'Check if the credentials provided is in the database
                If reader.HasRows = 0 Then
                    reader.Close()

                    Session.Add("referenceCode", referenceCode)
                    Dim Narration As String = ModelName.Text & " Fee"
                    Dim NoDelete = 0

                    'Insert file name into the database if file is uploaded
                    If PatternOfApprovalUpload.HasFile = True And PeriodicVerificationUpload.HasFile = False Then

                        Dim com As New MySqlCommand
                        com.Connection = conn
                        com.CommandText = "INSERT INTO deviceregistration (companyID,companyName,companyAddress,city,lga,state,pobox,companyEmail,companyWebsite,modelNumber,serialNumber,manufactureNumber,registrationDate,registrationTime,registrationYear,deviceAmount,actualMeasure,sector,instrumentCategory,deviceType,deviceModelName,transCode,dApprovalPattern,dPeriodicCertificate,applyForCertificate,applyForVerificationCert,location,unitOfMeasureID,measurementRange,NoDelete,dApprovalPatternFile) VALUES ('" & Session("UserLoginID") & "','" & UserNameOfCompany & "','" & UserAddress & "','" & UserCity & "','" & UserLGA & "','" & UserState & "','" & UserPOBox & "','" & UserEmail & "','" & UserWebsite & "','" & ModelNo.Text & "','" & SerialNo.Text & "','" & Manufacturer.Text & "','" & TodaysDate() & "','" & CurrentTim() & "','" & CurrentYear() & "','" & Session("TotalAmount") & "','" & ActualMeasure.Text & "','" & Sector.SelectedItem.Text & "','" & Instrument.SelectedItem.Text & "','" & InstrumentType.SelectedItem.Text & "','" & ModelName.Text & "','" & Session("referenceCode") & "','" & ApprovalCertificat & "','" & VerificationCertificat & "','" & ApplyApprovalCertificat & "','" & ApplyForVerificationCertificat & "','" & Location.Text & "','" & Measurement.SelectedItem.Text & "','" & MeasurementRang.SelectedItem.Text & "','" & NoDelete & "','" & PatternOfApprovalUpload.FileName & "')"
                        com.ExecuteNonQuery()

                        'Upload certificates if any or all of the certificate is checked
                        Dim fileExt As String
                        fileExt = System.IO.Path.GetExtension(PatternOfApprovalUpload.FileName)

                        If (fileExt = ".pdf" Or fileExt = ".doc" Or fileExt = ".docx" Or fileExt = ".xlsx" Or fileExt = ".xls" Or fileExt = ".jpg" Or fileExt = ".png" Or fileExt = ".jpeg" Or fileExt = ".bmp") Then

                            PatternOfApprovalUpload.SaveAs(UploadPath & PatternOfApprovalUpload.FileName)
                        Else
                            MessageBox.Show(Me, "ERROR: File type not allowed! Contact Administrator for correct File Type")
                        End If

                    ElseIf PatternOfApprovalUpload.HasFile = False And PeriodicVerificationUpload.HasFile = True Then

                        Dim com As New MySqlCommand
                        com.Connection = conn
                        com.CommandText = "INSERT INTO deviceregistration (companyID,companyName,companyAddress,city,lga,state,pobox,companyEmail,companyWebsite,modelNumber,serialNumber,manufactureNumber,registrationDate,registrationTime,registrationYear,deviceAmount,actualMeasure,sector,instrumentCategory,deviceType,deviceModelName,transCode,dApprovalPattern,dPeriodicCertificate,applyForCertificate,applyForVerificationCert,location,unitOfMeasureID,measurementRange,NoDelete,dPeriodicCertificateFile) VALUES ('" & Session("UserLoginID") & "','" & UserNameOfCompany & "','" & UserAddress & "','" & UserCity & "','" & UserLGA & "','" & UserState & "','" & UserPOBox & "','" & UserEmail & "','" & UserWebsite & "','" & ModelNo.Text & "','" & SerialNo.Text & "','" & Manufacturer.Text & "','" & TodaysDate() & "','" & CurrentTim() & "','" & CurrentYear() & "','" & Session("TotalAmount") & "','" & ActualMeasure.Text & "','" & Sector.SelectedItem.Text & "','" & Instrument.SelectedItem.Text & "','" & InstrumentType.SelectedItem.Text & "','" & ModelName.Text & "','" & Session("referenceCode") & "','" & ApprovalCertificat & "','" & VerificationCertificat & "','" & ApplyApprovalCertificat & "','" & ApplyForVerificationCertificat & "','" & Location.Text & "','" & Measurement.SelectedItem.Text & "','" & MeasurementRang.SelectedItem.Text & "','" & NoDelete & "','" & PeriodicVerificationUpload.FileName & "')"
                        com.ExecuteNonQuery()

                        'Upload certificates if any or all of the certificate is checked
                        Dim fileExt As String
                        fileExt = System.IO.Path.GetExtension(PeriodicVerificationUpload.FileName)
                        If (fileExt = ".pdf" Or fileExt = ".doc" Or fileExt = ".docx" Or fileExt = ".xlsx" Or fileExt = ".xls" Or fileExt = ".jpg" Or fileExt = ".png" Or fileExt = ".jpeg" Or fileExt = ".bmp") Then
                            PeriodicVerificationUpload.SaveAs(UploadPath & PeriodicVerificationUpload.FileName)
                            'Update the instrument table with the information
                        Else
                            MessageBox.Show(Me, "ERROR: File type not allowed! Contact Administrator for correct File Type")
                        End If

                    ElseIf PatternOfApprovalUpload.HasFile = True And PeriodicVerificationUpload.HasFile = True Then

                        Dim com As New MySqlCommand
                        com.Connection = conn
                        com.CommandText = "INSERT INTO deviceregistration (companyID,companyName,companyAddress,city,lga,state,pobox,companyEmail,companyWebsite,modelNumber,serialNumber,manufactureNumber,registrationDate,registrationTime,registrationYear,deviceAmount,actualMeasure,sector,instrumentCategory,deviceType,deviceModelName,transCode,dApprovalPattern,dPeriodicCertificate,applyForCertificate,applyForVerificationCert,location,unitOfMeasureID,measurementRange,NoDelete,dApprovalPatternFile,dPeriodicCertificateFile) VALUES ('" & Session("UserLoginID") & "','" & UserNameOfCompany & "','" & UserAddress & "','" & UserCity & "','" & UserLGA & "','" & UserState & "','" & UserPOBox & "','" & UserEmail & "','" & UserWebsite & "','" & ModelNo.Text & "','" & SerialNo.Text & "','" & Manufacturer.Text & "','" & TodaysDate() & "','" & CurrentTim() & "','" & CurrentYear() & "','" & Session("TotalAmount") & "','" & ActualMeasure.Text & "','" & Sector.SelectedItem.Text & "','" & Instrument.SelectedItem.Text & "','" & InstrumentType.SelectedItem.Text & "','" & ModelName.Text & "','" & Session("referenceCode") & "','" & ApprovalCertificat & "','" & VerificationCertificat & "','" & ApplyApprovalCertificat & "','" & ApplyForVerificationCertificat & "','" & Location.Text & "','" & Measurement.SelectedItem.Text & "','" & MeasurementRang.SelectedItem.Text & "','" & NoDelete & "','" & PatternOfApprovalUpload.FileName & "','" & PeriodicVerificationUpload.FileName & "')"
                        com.ExecuteNonQuery()

                        'Upload certificates if any or all of the certificate is checked
                        Dim fileExt As String
                        fileExt = System.IO.Path.GetExtension(PatternOfApprovalUpload.FileName)

                        If (fileExt = ".pdf" Or fileExt = ".doc" Or fileExt = ".docx" Or fileExt = ".xlsx" Or fileExt = ".xls" Or fileExt = ".jpg" Or fileExt = ".png" Or fileExt = ".jpeg" Or fileExt = ".bmp") Then

                            PatternOfApprovalUpload.SaveAs(UploadPath & PatternOfApprovalUpload.FileName)
                        Else
                            MessageBox.Show(Me, "ERROR: File type not allowed! Contact Administrator for correct File Type")
                        End If


                        fileExt = System.IO.Path.GetExtension(PeriodicVerificationUpload.FileName)
                        If (fileExt = ".pdf" Or fileExt = ".doc" Or fileExt = ".docx" Or fileExt = ".xlsx" Or fileExt = ".xls" Or fileExt = ".jpg" Or fileExt = ".png" Or fileExt = ".jpeg" Or fileExt = ".bmp") Then
                            PeriodicVerificationUpload.SaveAs(UploadPath & PeriodicVerificationUpload.FileName)
                            'Update the instrument table with the information
                        Else
                            MessageBox.Show(Me, "ERROR: File type not allowed! Contact Administrator for correct File Type")
                        End If

                    ElseIf PatternOfApprovalUpload.HasFile = False And PeriodicVerificationUpload.HasFile = False Then

                        Dim com As New MySqlCommand
                        com.Connection = conn
                        com.CommandText = "INSERT INTO deviceregistration (companyID,companyName,companyAddress,city,lga,state,pobox,companyEmail,companyWebsite,modelNumber,serialNumber,manufactureNumber,registrationDate,registrationTime,registrationYear,deviceAmount,actualMeasure,sector,instrumentCategory,deviceType,deviceModelName,transCode,dApprovalPattern,dPeriodicCertificate,applyForCertificate,applyForVerificationCert,location,unitOfMeasureID,measurementRange,NoDelete) VALUES ('" & Session("UserLoginID") & "','" & UserNameOfCompany & "','" & UserAddress & "','" & UserCity & "','" & UserLGA & "','" & UserState & "','" & UserPOBox & "','" & UserEmail & "','" & UserWebsite & "','" & ModelNo.Text & "','" & SerialNo.Text & "','" & Manufacturer.Text & "','" & TodaysDate() & "','" & CurrentTim() & "','" & CurrentYear() & "','" & Session("TotalAmount") & "','" & ActualMeasure.Text & "','" & Sector.SelectedItem.Text & "','" & Instrument.SelectedItem.Text & "','" & InstrumentType.SelectedItem.Text & "','" & ModelName.Text & "','" & Session("referenceCode") & "','" & ApprovalCertificat & "','" & VerificationCertificat & "','" & ApplyApprovalCertificat & "','" & ApplyForVerificationCertificat & "','" & Location.Text & "','" & Measurement.SelectedItem.Text & "','" & MeasurementRang.SelectedItem.Text & "','" & NoDelete & "')"
                        com.ExecuteNonQuery()

                    End If

                    Dim PaymentFor = "Instrument Registration Invoice"
                    Dim comp As New MySqlCommand
                    comp.Connection = conn
                    comp.CommandText = "INSERT INTO payment (companyID,companyName,transCode,amountDue,invoiceDate,invoiceTime,narration,orderId,paymentFor) VALUE ('" & Session("UserLoginID") & "','" & UserNameOfCompany & "','" & Session("referenceCode") & "','" & Session("TotalAmount") & "','" & TodaysDate() & "','" & CurrentTim() & "', '" & Narration & "','" & OrderNumber & "','" & PaymentFor & "')"
                    comp.ExecuteNonQuery()
                    MessageBox.Show(Me, "Instrument registered successfully, to make payment, go to invoice!")

                    Dim InvoiceNumber = OrderNumber
                    Dim InvoiceCompanyName = UserNameOfCompany
                    Dim InvoiceUsername = Session("UserLoginName")
                    Dim CompanyAddress = Session("UserLoginCompanyAddress")
                    Dim Amount = Session("TotalAmount")
                    Dim Total = Session("TotalAmount")
                    Amount = FormatNumber(Amount, 2, TriState.False, , TriState.True)
                    Total = FormatNumber(Total, 2, TriState.False, , TriState.True)
                    Dim Purpose = PaymentFor + ":  " + ModelName.Text + "  (" + ModelNo.Text + ")"
                    Session.Remove("InstrumentName")
                    Session.Remove("InstrumentSerialNumber")
                    Session.Add("InstrumentName", ModelName.Text)
                    Session.Add("InstrumentSerialNumber", SerialNo.Text)
                    'Send SMS Message
                    tools.SendSMS(Me, GetSMSAPI(), GetSMSUsername(), GetSMSPassword(), BulkSMSDefaultSender(), SMSRecipientNumber(), LicensingFeeMessage())

                    'Send email to user after registration
                    Dim Subject = "Instrument Licensing Bill"
                    'Dim Message = "Your Online Registration with Federal Ministry of Industry, Trade and Investment was successful. <div style=''><p> Below are your registration details:<p> <strong> Username: </strong>" + Username.Text + "<p> <strong> Company Name: </strong>" + CompanyName.Text + " <p> Kindly click the button below to login to your account.<p style='margin-top:50px;'> <strong>Thank you.</strong>"
                    Dim Message = "<div style='width:620px;font-size:15px;background:rgb(255,255, 255);'><div style='padding-left:10px; width:590px;'><h4 style='padding:10px 0px;font-size:23px;width:100%;text-align:center;margin-top:-10px;'>" & Subject & "</span></h4> <h4 style='padding:10px 0px;font-size:17px;'><span style='float:right;font-size:13px;'>" + Date.Now + " </span></h4><div style='margin-bottom:10px;display:block;height:169px; width:100%;'><div style='width:45%;float:left;'><div style='font-weight:bolder;font-size:17px;padding:5px 0px;'>CLIENT DETAIL</div><p style='font-weight:bolder;font-size:15px;'>" + InvoiceCompanyName + " (" + InvoiceUsername + ")  </p><p style='font-weight:bolder;font-size:15px;'>" + CompanyAddress + "</p></div><div style='width:45%;float:right;'><div style='font-weight:bolder;font-size:17px;padding:5px 0px;'>ACCOUNT DETAIL</div><p style='font-weight:bolder;font-size:13px;'>ACCOUNT NAME: <span style='font-weight:normal;'>FEDERAL MINISTRY OF INDUSTRY, TRADE AND INVESTMENT WEIGHTS AND MEASURES DEPARTMENT</span></p><p style='font-weight:bolder;font-size:13px;'>ACCOUNT NUMBER: <span style='font-weight:normal;'>1750013688</span></p><p style='font-weight:bolder;font-size:13px;'>BANK NAME: <span style='font-weight:normal;'>SKYE BANK</span></p></div></div><div style='font-weight:bolder;font-size:17px;padding:5px 0px;'>INVOICE ITEM(S)</div><div style='width:69%;display:inline-block;font-weight:bolder;padding:10px 0px;border-bottom:1px solid rgb(200,200,200);color:rgb(100,100,100);'>Summary</div><div style='width:30%;display:inline-block;text-align:right;font-weight:bolder;padding:10px 0px;0px;border-bottom:1px solid rgb(200,200,200);color:rgb(100,100,100);'>Amount</div><div style='width:69%;display:inline-block;padding:10px 0px;'>" + Purpose + "</div><div style='width:30%;display:inline-block;text-align:right;padding:10px 0px;'>" + Amount + "</div><div style='width:100%;display:inline-block;padding:20px 0px;margin-left:-10px;padding-right:1px;text-align:right;font-weight:bolder;background:rgb(250,250,250);font-size:17px;'>Total: <span style='float:right;margin-left:50px;margin-right:0px;'>N" + Total + "</span></div></div><p><div style='margin-top:0px;width:600px;height:auto;padding:10px;color:rgb(20,20,20);text-align:left;font-size:13px;background:rgb(255,255,255);'><strong>PLEASE NOTE: </strong> <P>ALL BANK DEPOSIT MUST BE MADE WITH THE USERNAME NAME AS THE DEPOSITOR.<P>ALL PAYMENT(S) MADE ARE NON-REFUNDABLE.</div><p><a href='http://www.wmdnigeria.com/' style='text-decoration:none;width:auto;color:rgb(255,255,255);'><div style='margin-bottom:10px;padding: 5px 10px;width:100px;font-size: 14px;font-weight: bolder;line-height: 20px;text-align: center;cursor: pointer;border: 1px solid transparent;border-radius: 4px;background:rgb(54,127,169);color:rgb(255, 255, 255);'>Login Now</div> </div>"
                    Dim MessageBody = "<html><head></head><body style='font-family:Tahoma; width:620px;font-size:13px;background:rgb(240,240, 240)'><div style='width:600px;height:70px;padding:10px;color:rgb(255, 255, 255);font-weight:bolder;text-align:center;font-size:20px;background:rgb(54,127,169);'><img src='http://www.wmdnigeria.com/images/icon.png' width='70px' height='70px' align='left' style='margin-top:-10px;padding:0px;' /><p>Federal Ministry of Industry Trade and Investment <br><span style='font-size:17px;'>Weights and Measures Department</span></div><div style='width:600px;font-size:13px;color:rgb(100,100,100);'><p> <div style='padding-left:10px; width:590px;'> <div style='font-weight:bolder;font-size:17px;'></div><p>" & Message & "</div> </div> </div>           <p><div style='margin-top:100px;width:600px;height:auto;padding:10px;color:rgb(255, 255, 255);text-align:center;font-size:13px;background:rgb(54,127,169);'><strong>NOTICE: </strong>  The content of this e-mail is intended solely for the use of the individual or entity to whom it is addressed. If you have received this communication in error, beware that forwarding it, copying it or in any way disclosing its content to any other person or persons, is strictly prohibiting. If you have received this communication in error, please notify the author by replying this e-mail immediately.</div></body></html>"

                    clsNotify.SendEmail(UserEmail, Subject, MessageBody, AccountEmail(), True)

                    'This code do the loggin magic
                    Dim ComputerName = System.Net.Dns.GetHostEntry(Request.ServerVariables("remote_addr")).HostName
                    Dim UserIP = Request.ServerVariables("REMOTE_ADDR")

                    Dim Activity As String = UserNameOfCompany + " Registered an Instrument!"
                    Dim comm As New MySqlCommand
                    comm.Connection = conn
                    comm.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("UserLoginID") & "','" & Activity & "','" & Session("UserLoginIPAddress") & "','" & ComputerName & "','" & osVersion() & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("UserLoginUserType") & "')"
                    comm.ExecuteNonQuery()


                Else

                    MessageBox.Show(Me, "This Instrument is already registered, please register another instrument! ")

                End If
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message)
            Finally
                DisconnectDatabase()
                If ApplyForApprovalNow.Checked = True Then
                    Response.AppendHeader("Refresh", "0;url=../instrument-services/")
                Else
                    Response.AppendHeader("Refresh", "0;url=./")
                End If
            End Try

        End If


    End Sub

    
    Protected Sub DisplaySelected_OnCheckedChanged(sender As Object, e As EventArgs)

        For Each row As GridViewRow In RegisteredInstrumentGridView.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim chkRow As CheckBox = TryCast(row.Cells(0).FindControl("InstrumentSelector"), CheckBox)
                If chkRow.Checked Then
                    Dim InstrumentName = row.Cells(2).Text
                    Session.Add("InstrumentSelected", InstrumentName)
                    Dim InstrumentSerialNo = row.Cells(4).Text
                    Session.Add("SelectedInstrumentSerialNo", InstrumentSerialNo)
                    Dim Amount = row.Cells(5).Text
                    'MessageBox.Show(Me, InstrumentName & "      " & InstrumentSerialNo & "      " & Amount)

                Else

                End If
            End If
        Next


    End Sub

    
    'This is to Modify Instrument After editing!
    Protected Sub ModifyInstrument_Click(sender As Object, e As EventArgs) Handles ModifyInstrument.Click
        
        For Each row As GridViewRow In RegisteredInstrumentGridView.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim chkRow As CheckBox = TryCast(row.Cells(0).FindControl("InstrumentSelector"), CheckBox)
                If chkRow.Checked = True Then

                    'Check if the instrument has not paid for
                    Dim InstrumentSerialNo = row.Cells(4).Text
                    Session.Add("ModifyReferenceCode", row.Cells(6).Text)
                    Dim NoDelete = 0


                    Dim MyAdapter As New MySqlDataAdapter

                    Dim SqlQuery = "SELECT * FROM deviceregistration WHERE serialNumber='" & InstrumentSerialNo & "' AND NoDelete='" & NoDelete & "';"
                    Dim Command As New MySqlCommand
                    Command.Connection = conn
                    Command.CommandText = SqlQuery
                    MyAdapter.SelectCommand = Command

                    Dim reader As MySqlDataReader
                    reader = Command.ExecuteReader
                    'Check if the credentials provided is in the database
                    If reader.HasRows = 0 Then
                        reader.Close()

                        MessageBox.Show(Me, "The Instrument you selected can not be modify, kindly select another one to modify!")

                    Else
                        reader.Close()

                        RegisterInstrument.Visible = False
                        SaveInstrument.Visible = True

                        UseMyAddress.Checked = True
                        RegisteredAddress.Visible = True
                        SerialNo.Enabled = False
                        SerialNo.BackColor = Drawing.Color.DarkGray
                        InstrumentType.Enabled = False
                        InstrumentType.BackColor = Drawing.Color.DarkGray
                        UseMyAddress.Enabled = False
                        Registration.Visible = False


                        Try
                            ConnectDatabase()

                            Dim dbs As String = "SELECT * FROM state"
                            Using cns As MySqlCommand = New MySqlCommand(dbs, conn)
                                Using das As New MySqlDataAdapter(cns)
                                    Dim dts As New DataTable()
                                    das.Fill(dts)
                                    State.DataSource = dts
                                    State.DataTextField = "state"
                                    State.DataValueField = "ID"
                                    State.DataBind()

                                End Using
                            End Using

                            Dim dbl As String = "SELECT * FROM lga"
                            Using cnl As MySqlCommand = New MySqlCommand(dbl, conn)
                                Using dal As New MySqlDataAdapter(cnl)
                                    Dim dtl As New DataTable()
                                    dal.Fill(dtl)
                                    LGA.DataSource = dtl
                                    LGA.DataTextField = "lga"
                                    LGA.DataValueField = "ID"
                                    LGA.DataBind()

                                End Using
                            End Using

                            Dim dbc As String = "SELECT * FROM city"
                            Using cnc As MySqlCommand = New MySqlCommand(dbc, conn)
                                Using dac As New MySqlDataAdapter(cnc)
                                    Dim dtc As New DataTable()
                                    dac.Fill(dtc)
                                    City.DataSource = dtc
                                    City.DataTextField = "city"
                                    City.DataValueField = "ID"
                                    City.DataBind()

                                End Using
                            End Using


                            Dim dbd As String = "SELECT * FROM devicecategories"
                            Using cnd As MySqlCommand = New MySqlCommand(dbd, conn)
                                Using dad As New MySqlDataAdapter(cnd)
                                    Dim dtd As New DataTable()
                                    dad.Fill(dtd)
                                    Instrument.DataSource = dtd
                                    Instrument.DataTextField = "deviceCategory"
                                    Instrument.DataValueField = "ID"
                                    Instrument.DataBind()

                                End Using
                            End Using

                            Dim dbdt As String = "SELECT * FROM devicesub"
                            Using cndt As MySqlCommand = New MySqlCommand(dbdt, conn)
                                Using dadt As New MySqlDataAdapter(cndt)
                                    Dim dtdt As New DataTable()
                                    dadt.Fill(dtdt)
                                    InstrumentType.DataSource = dtdt
                                    InstrumentType.DataTextField = "deviceType"
                                    InstrumentType.DataValueField = "ID"
                                    InstrumentType.DataBind()

                                End Using
                            End Using

                            Dim dbm As String = "SELECT * FROM deviceprice"
                            Using cnm As MySqlCommand = New MySqlCommand(dbm, conn)
                                Using dam As New MySqlDataAdapter(cnm)
                                    Dim dtm As New DataTable()
                                    dam.Fill(dtm)
                                    MeasurementRang.DataSource = dtm
                                    MeasurementRang.DataTextField = "measureRange"
                                    MeasurementRang.DataValueField = "ID"
                                    MeasurementRang.DataBind()

                                End Using
                            End Using

                            Measurement.Items.Clear()
                            Measurement.Items.Insert(0, "None")


                            'Trow error is anything wrong with the code
                        Catch ex As Exception
                            MessageBox.Show(Me, ex.Message)
                        Finally
                            'After execution of mysql query, disconnect database
                            DisconnectDatabase()
                        End Try



                        Try
                            ConnectDatabase()

                            Dim db As String = "SELECT * FROM deviceregistration WHERE serialNumber='" & InstrumentSerialNo & "' AND NoDelete='" & NoDelete & "'"
                            Using cn As MySqlCommand = New MySqlCommand(db, conn)
                                Using da As New MySqlDataAdapter(cn)
                                    Dim ds As New DataSet()
                                    da.Fill(ds)

                                    CompanyName.Text = ds.Tables(0).Rows(0).Item("companyName").ToString
                                    Email.Text = ds.Tables(0).Rows(0).Item("companyEmail").ToString
                                    Address.Text = ds.Tables(0).Rows(0).Item("companyAddress").ToString
                                    Website.Text = ds.Tables(0).Rows(0).Item("companyWebsite").ToString
                                    POBox.Text = ds.Tables(0).Rows(0).Item("pobox").ToString

                                    Dim SelectedState = ds.Tables(0).Rows(0).Item("state").ToString
                                    State.Items.FindByValue(SelectedState).Selected = True

                                    Dim SelectedLGA = ds.Tables(0).Rows(0).Item("lga").ToString
                                    LGA.Items.FindByValue(SelectedLGA).Selected = True

                                    Dim SelectedCity = ds.Tables(0).Rows(0).Item("city").ToString
                                    City.Items.FindByValue(SelectedCity).Selected = True

                                    Dim SelectedSector = ds.Tables(0).Rows(0).Item("sector").ToString
                                    Sector.ClearSelection()
                                    Sector.Items.FindByText(SelectedSector).Selected = True

                                    Dim SelectedInstrument = ds.Tables(0).Rows(0).Item("instrumentCategory").ToString
                                    Instrument.Items.FindByText(SelectedInstrument).Selected = True

                                    Dim SelectedInstrumentType = ds.Tables(0).Rows(0).Item("deviceType").ToString
                                    InstrumentType.Items.FindByText(SelectedInstrumentType).Selected = True

                                    Dim SelectedMeasurement = ds.Tables(0).Rows(0).Item("unitOfMeasureID").ToString
                                    Measurement.Items.FindByText(SelectedMeasurement).Selected = True

                                    Dim SelectedMeasurementRange = ds.Tables(0).Rows(0).Item("measurementRange").ToString
                                    MeasurementRang.Items.FindByText(SelectedMeasurementRange).Selected = True


                                    ActualMeasure.Text = ds.Tables(0).Rows(0).Item("actualMeasure").ToString
                                    ModelNo.Text = ds.Tables(0).Rows(0).Item("modelNumber").ToString
                                    SerialNo.Text = ds.Tables(0).Rows(0).Item("serialNumber").ToString
                                    Manufacturer.Text = ds.Tables(0).Rows(0).Item("manufactureNumber").ToString
                                    ModelName.Text = ds.Tables(0).Rows(0).Item("deviceModelName").ToString
                                    Location.Text = ds.Tables(0).Rows(0).Item("location").ToString

                                    Session.Add("TotalAmount", ds.Tables(0).Rows(0).Item("deviceAmount").ToString)

                                    Dim ApprovalCertificateCheckedState = ds.Tables(0).Rows(0).Item("dApprovalPattern").ToString
                                    Dim ApplyApprovalCertificateCheckedState = ds.Tables(0).Rows(0).Item("applyForCertificate").ToString
                                    Dim PeriodicCertificateCheckedState = ds.Tables(0).Rows(0).Item("dPeriodicCertificate").ToString
                                    Dim ApplyPeriodicCertificateCheckedState = ds.Tables(0).Rows(0).Item("applyForVerificationCert").ToString

                                    If ApprovalCertificateCheckedState = "1" Then
                                        ApprovalCertificate.Checked = True
                                        ApprovalCertificateUploadPanel.Visible = True
                                        CertificateUploadPanel.Visible = True
                                        ApprovalPatternFileName.Text = ds.Tables(0).Rows(0).Item("dApprovalPatternFile").ToString
                                        PatternOfApprovalUpload.Visible = False

                                    ElseIf ApprovalCertificateCheckedState = "0" Then
                                        ApprovalCertificate.Checked = False
                                        ApprovalCertificateUploadPanel.Visible = False
                                    End If

                                    If ApplyApprovalCertificateCheckedState = "1" Then
                                        ApplyForApproval.Checked = True
                                    ElseIf ApplyApprovalCertificateCheckedState = "0" Then
                                        ApplyForApproval.Checked = False
                                    End If


                                    If PeriodicCertificateCheckedState = "1" Then
                                        VerificationCertificate.Checked = True
                                        InitialCertificateUploadPanel.Visible = True
                                        CertificateUploadPanel.Visible = True
                                        PeriodVerificationFileName.Text = ds.Tables(0).Rows(0).Item("dPeriodicCertificateFile").ToString
                                        PeriodicVerificationUpload.Visible = False
                                    ElseIf PeriodicCertificateCheckedState = "0" Then
                                        VerificationCertificate.Checked = False
                                        InitialCertificateUploadPanel.Visible = False
                                    End If

                                    If ApplyPeriodicCertificateCheckedState = "1" Then
                                        ApplyForVerification.Checked = True
                                        InitialCertificateUploadPanel.Visible = False

                                    ElseIf ApplyPeriodicCertificateCheckedState = "0" Then
                                        ApplyForVerification.Checked = False
                                    End If

                                    If ApplyPeriodicCertificateCheckedState = "1" Then
                                        ApplyForVerification.Checked = True
                                        InitialCertificateUploadPanel.Visible = False

                                    ElseIf ApplyPeriodicCertificateCheckedState = "0" Then
                                        ApplyForVerification.Checked = False
                                    End If

                                End Using
                            End Using


                        Catch ex As Exception

                            MessageBox.Show(Me, ex.Message)

                        Finally
                            'After execution of mysql query, disconnect database
                            DisconnectDatabase()
                        End Try

                    End If


                Else

                    MessageBox.Show(Me, "You have not select any instrument!")
                End If

            End If


        Next

    End Sub

    Dim ApprovalNewFileName, VerificationNewFileName As String
    'This is to save Instrument After editing!
    Protected Sub SaveInstrument_Click(sender As Object, e As EventArgs) Handles SaveInstrument.Click

        Try
            ConnectDatabase()
            If Email.Text = "" Or Address.Text = "" Or Website.Text = "" Or POBox.Text = "" Or State.Text = "" Or LGA.Text = "" Or City.Text = "" Or ActualMeasure.Text = "" Or ModelNo.Text = "" Or ModelName.Text = "" Or SerialNo.Text = "" Or Manufacturer.Text = "" Or Location.Text = "" Then
                MessageBox.Show(Me, "No Field should be left blank!")

            Else

                Dim ApprovalCertificat As String
                If ApprovalCertificate.Checked = True Then
                    ApprovalCertificat = "1"
                Else
                    ApprovalCertificat = "0"
                End If

                Dim ApplyApprovalCertificat As String
                If ApplyForApproval.Checked = True Then
                    ApplyApprovalCertificat = "1"
                Else
                    ApplyApprovalCertificat = "0"
                End If

                Dim VerificationCertificat As String
                If VerificationCertificate.Checked = True Then
                    VerificationCertificat = "1"
                Else
                    VerificationCertificat = "0"
                End If

                Dim ApplyForVerificationCertificat As String
                If ApplyForVerification.Checked = True Then
                    ApplyForVerificationCertificat = "1"
                Else
                    ApplyForVerificationCertificat = "0"
                End If


                'Update Instrument Table
                Dim cmd As New MySqlCommand
                cmd.Connection = conn
                cmd.CommandText = "UPDATE deviceregistration SET companyName='" & CompanyName.Text & "',companyAddress='" & Address.Text & "',city= '" & City.SelectedValue & "',lga= '" & LGA.SelectedValue & "',state= '" & State.SelectedValue & "',pobox='" & POBox.Text & "',companyEmail='" & Email.Text & "',companyWebsite= '" & Website.Text & "',modelNumber=  '" & ModelNo.Text & "',serialNumber=  '" & SerialNo.Text & "',manufactureNumber='" & Manufacturer.Text & "',deviceAmount='" & Session("TotalAmount") & "',actualMeasure= '" & ActualMeasure.Text & "',sector='" & Sector.SelectedItem.Text & "',instrumentCategory='" & Instrument.SelectedItem.Text & "',deviceType='" & InstrumentType.SelectedItem.Text & "',deviceModelName='" & ModelName.Text & "' ,dApprovalPattern='" & ApprovalCertificat & "'   ,dPeriodicCertificate='" & VerificationCertificat & "',applyForCertificate='" & ApplyApprovalCertificat & "',applyForVerificationCert='" & ApplyForVerificationCertificat & "',location='" & Location.Text & "' ,unitOfMeasureID='" & Measurement.SelectedItem.Text & "' ,measurementRange='" & MeasurementRang.SelectedItem.Text & "' WHERE serialNumber ='" & SerialNo.Text & "'"
                cmd.ExecuteNonQuery()

                Dim paymentStatus = "Unpaid"
                'Update payment table
                Dim cmdp As New MySqlCommand
                cmdp.Connection = conn
                cmdp.CommandText = "UPDATE payment SET amountDue='" & Session("TotalAmount") & "' WHERE transCode='" & Session("ModifyReferenceCode") & "' AND paymentStatus='" & paymentStatus & "'"
                cmdp.ExecuteNonQuery()


                'Upload certificates if any or all of the certificate is checked
                If ApprovalCertificate.Checked = True And PatternOfApprovalUpload.HasFile = True Then
                    PatternOfApprovalUpload.Visible = False
                    Dim fileExt As String
                    fileExt = System.IO.Path.GetExtension(PatternOfApprovalUpload.FileName)

                    If (fileExt = ".pdf" Or fileExt = ".doc" Or fileExt = ".docx" Or fileExt = ".xlsx" Or fileExt = ".xls" Or fileExt = ".jpg" Or fileExt = ".png" Or fileExt = ".jpeg" Or fileExt = ".bmp") Then
                        PatternOfApprovalUpload.SaveAs(UploadPath & PatternOfApprovalUpload.FileName)
                        ApprovalNewFileName = PatternOfApprovalUpload.FileName
                    Else
                        MessageBox.Show(Me, "ERROR: File type not allowed! Contact Administrator for correct File Type")
                    End If


                Else

                    'MessageBox.Show(Me, "You have not select any file to upload!")
                End If

                'Upload certificates if any or all of the certificate is checked
                If VerificationCertificate.Checked = True And PeriodicVerificationUpload.HasFile = True Then
                    PeriodicVerificationUpload.Visible = False

                    Dim fileExt As String
                    fileExt = System.IO.Path.GetExtension(PeriodicVerificationUpload.FileName)
                    If (fileExt = ".pdf" Or fileExt = ".doc" Or fileExt = ".docx" Or fileExt = ".xlsx" Or fileExt = ".xls" Or fileExt = ".jpg" Or fileExt = ".png" Or fileExt = ".jpeg" Or fileExt = ".bmp") Then
                        PeriodicVerificationUpload.SaveAs(UploadPath & PeriodicVerificationUpload.FileName)
                        VerificationNewFileName = PeriodicVerificationUpload.FileName
                    Else
                        MessageBox.Show(Me, "ERROR: File type not allowed! Contact Administrator for correct File Type")
                    End If

                Else
                    'MessageBox.Show(Me, "You have not select any file to upload!")

                End If


                If ApprovalNewFileName = "" Then

                ElseIf Not ApprovalNewFileName = "" Then
                    'Update the instrument table with the information
                    Dim cmdv As New MySqlCommand
                    cmdv.Connection = conn
                    cmdv.CommandText = "UPDATE deviceregistration SET dApprovalPatternFile='" & ApprovalNewFileName & "' WHERE serialNumber='" & SerialNo.Text & "'"
                    cmdv.ExecuteNonQuery()
                End If

                If VerificationNewFileName = "" Then

                ElseIf Not VerificationNewFileName = "" Then
                    'Update the instrument table with the information
                    Dim cmdv As New MySqlCommand
                    cmdv.Connection = conn
                    cmdv.CommandText = "UPDATE deviceregistration SET dPeriodicCertificateFile='" + VerificationNewFileName & "' WHERE serialNumber='" & SerialNo.Text & "'"
                    cmdv.ExecuteNonQuery()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)
        Finally
            DisconnectDatabase()
            Response.AppendHeader("Refresh", "0;url=./")
        End Try

    End Sub
     
    Protected Sub CancelRegistration_Click(sender As Object, e As EventArgs) Handles CancelRegistration.Click
        Response.Redirect("./")
    End Sub
    Protected Sub DeleteInstrument_Click(sender As Object, e As EventArgs) Handles DeleteInstrument.Click

        For Each row As GridViewRow In RegisteredInstrumentGridView.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim chkRow As CheckBox = TryCast(row.Cells(0).FindControl("InstrumentSelector"), CheckBox)
                If chkRow.Checked = True Then

                    'Check if the instrument has not been paid for
                    Dim InstrumentSerialNo = row.Cells(4).Text
                    Dim ReferenceCode = row.Cells(6).Text
                    Dim NoDelete = 0

                    ConnectDatabase()

                    Dim MyAdapter As New MySqlDataAdapter
                    Dim SqlQuery = "SELECT * FROM deviceregistration WHERE serialNumber='" & InstrumentSerialNo & "' AND companyID= '" & Session("UserLoginID") & "' AND NoDelete='" & NoDelete & "';"
                    Dim Command As New MySqlCommand
                    Command.Connection = conn
                    Command.CommandText = SqlQuery
                    MyAdapter.SelectCommand = Command

                    Dim reader As MySqlDataReader
                    reader = Command.ExecuteReader
                    'Check if the credentials provided is in the database
                    If reader.HasRows = 0 Then
                        reader.Close()
                        MessageBox.Show(Me, "The selected Instrument cannot be deleted, it been paid for!")
                    Else
                        reader.Close()
                        Try

                            Dim cmd As New MySqlCommand
                            cmd.Connection = conn
                            cmd.CommandText = "DELETE FROM deviceregistration WHERE companyID='" & Session("UserLoginID") & "' AND serialNumber='" & Session("SelectedInstrumentSerialNo") & "' AND NoDelete=0"
                            cmd.ExecuteNonQuery()

                            Dim PaymentStatus = "Unpaid"
                            Dim cmdp As New MySqlCommand
                            cmdp.Connection = conn
                            cmdp.CommandText = "DELETE FROM payment WHERE transCode='" & ReferenceCode & "' AND paymentStatus='" & PaymentStatus & "'"
                            cmdp.ExecuteNonQuery()


                            'This code do the loggin magic
                              
                            Dim Activity As String = Session("InstrumentSelected") & "has been deleted from instruments by " & Session("UserLoginUsername")
                            Dim com As New MySqlCommand
                            com.Connection = conn
                            com.CommandText = "INSERT INTO userlog (userID,activity,IPAddress,machineName,deviceType,browserName,logdate,logtime,usertype) VALUES ('" & Session("LoggedInAdminLoginID") & "','" & Activity & "','" & Session("AdminLoginIPAddress") & "','" & ComputerName & "','" & osVersion & "', '" & GetBrowserName() & "','" & TodaysDate() & "','" & CurrentTim() & "','" & Session("LoggedInAdminLoginAccountType") & "')"
                            com.ExecuteNonQuery()

                            MessageBox.Show(Me, "Selected Instrument has been deleted Successfully!")

                        Catch ex As Exception
                            MessageBox.Show(Me, ex.Message)
                        Finally
                            DisconnectDatabase()
                            Response.Redirect("./", False)
                        End Try

                    End If
                Else
                    MessageBox.Show(Me, "You have not select any instrument!")
                End If

            End If
        Next
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


    Protected Sub RegisteredInstrumentGridView_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        RegisteredInstrumentGridView.PageIndex = e.NewPageIndex
        RegisteredInstrumentGridView.DataSource = CType(Cache("InstrumentData"), DataTable)
        RegisteredInstrumentGridView.DataBind()
    End Sub
End Class