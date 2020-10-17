Imports System.IO
Imports System.Net
Imports System.Web
Imports System.Data
Imports System.Text
Imports System.Web.UI
Imports System.Drawing
Imports System.Data.OleDb
Imports System.Web.Security
Imports System.Configuration
Imports MySql.Data.MySqlClient
Imports System.Drawing.Drawing2D
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Security.Cryptography

Public Class _default32
    Inherits System.Web.UI.Page

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

        If Not IsPostBack Then

            ReferenceID.Text = referenceCode()
            ExportSummary.Visible = True
            ExportProceeds.Visible = True
            LiftingStatistics.Visible = True
            ExportDataReturnPreviewPanel.Visible = False

            RefreshPage.Visible = True
            PreviewReturn.Visible = True
            SaveExportDataReturn.Visible = False
            CancelExportDataReturn.Visible = False

            Dim Options As ListItemCollection = New ListItemCollection()
            Options.Add(New ListItem("...Quarter...", "...Quarter..."))
            Options.Add(New ListItem("1st Quarter / " & Today.Year, "1st Quarter / " & Today.Year))
            Options.Add(New ListItem("2nd Quarter / " & Today.Year, "2nd Quarter / " & Today.Year))
            Options.Add(New ListItem("3rd Quarter / " & Today.Year, "3rd Quarter / " & Today.Year))
            Options.Add(New ListItem("4th Quarter / " & Today.Year, "4th Quarter / " & Today.Year))

            Me.ExportQuarter.DataSource = Options
            Me.ExportQuarter.DataBind()
            ExportQuarter.Items.FindByText("...Quarter...").Selected = True

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


    Protected Sub PermitQuarter_SelectedIndexChanged(Sender As Object, e As EventArgs) Handles ExportQuarter.SelectedIndexChanged

        Try
            If ExportQuarter.SelectedItem.Text.Contains("1st") Then
                Dim Options As ListItemCollection = New ListItemCollection()
                Options.Add(New ListItem("...Month...", "...Month..."))
                Options.Add(New ListItem("January"))
                Options.Add(New ListItem("February"))
                Options.Add(New ListItem("March"))
                Me.ExportMonth.DataSource = Options
                Me.ExportMonth.DataBind()
                ExportMonth.Items.FindByText("...Month...").Selected = True

            ElseIf ExportQuarter.SelectedItem.Text.Contains("2nd") Then
                Dim Options As ListItemCollection = New ListItemCollection()
                Options.Add(New ListItem("...Month...", "...Month..."))
                Options.Add(New ListItem("April"))
                Options.Add(New ListItem("May"))
                Options.Add(New ListItem("June"))
                Me.ExportMonth.DataSource = Options
                Me.ExportMonth.DataBind()
                ExportMonth.Items.FindByText("...Month...").Selected = True

            ElseIf ExportQuarter.SelectedItem.Text.Contains("3rd") Then
                Dim Options As ListItemCollection = New ListItemCollection()
                Options.Add(New ListItem("...Month...", "...Month..."))
                Options.Add(New ListItem("July"))
                Options.Add(New ListItem("August"))
                Options.Add(New ListItem("September"))
                Me.ExportMonth.DataSource = Options
                Me.ExportMonth.DataBind()
                ExportMonth.Items.FindByText("...Month...").Selected = True

            ElseIf ExportQuarter.SelectedItem.Text.Contains("4th") Then
                Dim Options As ListItemCollection = New ListItemCollection()
                Options.Add(New ListItem("...Month...", "...Month..."))
                Options.Add(New ListItem("October"))
                Options.Add(New ListItem("November"))
                Options.Add(New ListItem("December"))
                Me.ExportMonth.DataSource = Options
                Me.ExportMonth.DataBind()
                ExportMonth.Items.FindByText("...Month...").Selected = True

            Else
                MessageBox.Show(Me, "Select a valid Permit Quarters")
            End If

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)
        End Try


    End Sub

    Protected Sub RefreshPage_Click(Sender As Object, e As EventArgs) Handles RefreshPage.Click
        Response.Redirect("./", False)
    End Sub


    Protected Sub PreviewReturn_Click(Sender As Object, e As EventArgs) Handles PreviewReturn.Click
        ExportSummary.Visible = False
        ExportProceeds.Visible = False
        LiftingStatistics.Visible = False
        ExportDataReturnPreviewPanel.Visible = True

        RefreshPage.Visible = False
        PreviewReturn.Visible = False
        SaveExportDataReturn.Visible = True
        CancelExportDataReturn.Visible = True

        Try
            ConnectDatabase()

            Dim MyAdapter As New MySqlDataAdapter
            Dim SqlQuery = "SELECT * FROM exportreturn WHERE referenceID='" & ReferenceID.Text & "' AND companyID= '" & Session("UserLoginID") & "';"
            Dim Command As New MySqlCommand
            Command.Connection = conn
            Command.CommandText = SqlQuery
            MyAdapter.SelectCommand = Command
            Dim CheckReference As MySqlDataReader
            CheckReference = Command.ExecuteReader
            'Check if the credentials provided is in the database
            If CheckReference.HasRows = 0 Then
                CheckReference.Close()
                Dim DataReturnUploadStatus = "0"
                Dim com As New MySqlCommand
                com.Connection = conn
                com.CommandText = "INSERT INTO exportreturn (companyID,referenceID,exporter,exportPermitID,exportQuarter,exportMonth,stream,exportPermitVolumeNetBBL,exportPermitVolumeNetMT,exportVolumeNetBBL,exportVolumeNetMT,ProductionVolumeNetBBL,ProductionVolumeNetMT,bLadingDate,proceedVessel,BSW,API,netBarrel,netTons,proceedsDestination,proceedNGN,proceedUSD,crudeType,equityOwner,liftingVessel,acceptanceDate,agent,cargoInspector,quantityLiftedGrossBBLS,quantityLiftedNetBBLS,quantityLiftedNetMT,quantityLiftedNetAPI,liftingDestination,status,uploadDate,uploadTime) VALUES('" & Session("UserLoginID") & "','" & ReferenceID.Text & "','" & Exporter.Text & "','" & ExportPermitID.Text & "','" & ExportQuarter.SelectedItem.Text & "','" & ExportMonth.SelectedItem.Text & "','" & SummaryStream.Text & "','" & ExportPermitVolumesNetBBL.Text & "','" & ExportPermitVolumesNetMT.Text & "','" & ExportVolumesNetBBL.Text & "','" & ExportVolumesNetMT.Text & "','" & ProductionVolumesNetBBL.Text & "','" & ProductionVolumesNetMT.Text & "','" & BillofLadingDate.Text & "','" & ProceedVessel.Text & "','" & BSW.Text & "','" & API.Text & "','" & NetBarrels.Text & "','" & NetMetricTons.Text & "','" & Destination.Text & "','" & ProceedPriceNaira.Text & "','" & ProceedPriceDollar.Text & "','" & CrudeType.Text & "','" & EquityOwner.Text & "','" & LiftingVessle.Text & "','" & AcceptanceDate.Text & "','" & Agent.Text & "','" & CargoInspector.Text & "','" & QuantitiesLiftedGrossBBLS.Text & "','" & QuantitiesLiftedNetBBLS.Text & "','" & QuantitiesLiftedNetMT.Text & "','" & QuantitiesLiftedNetAPI.Text & "','" & LiftingDestination.Text & "','" & DataReturnUploadStatus & "','" & TodaysDate() & "','" & CurrentTim() & "')"
                com.ExecuteNonQuery()
                MessageBox.Show(Me, "There is no data yet!")

            Else
                CheckReference.Close()
                Dim strSQL As String
                strSQL = "UPDATE exportreturn SET exporter='" & Exporter.Text & "',exportPermitID='" & ExportPermitID.Text & "',exportQuarter='" & ExportQuarter.SelectedItem.Text & "',exportMonth='" & ExportMonth.SelectedItem.Text & "',stream='" & SummaryStream.Text & "',exportPermitVolumeNetBBL='" & ExportPermitVolumesNetBBL.Text & "',exportPermitVolumeNetMT='" & ExportPermitVolumesNetMT.Text & "',exportVolumeNetBBL='" & ExportVolumesNetBBL.Text & "',exportVolumeNetMT='" & ExportVolumesNetMT.Text & "',ProductionVolumeNetBBL='" & ProductionVolumesNetBBL.Text & "',ProductionVolumeNetMT='" & ProductionVolumesNetMT.Text & "',bLadingDate='" & BillofLadingDate.Text & "',proceedVessel='" & ProceedVessel.Text & "',BSW='" & BSW.Text & "',API='" & API.Text & "',netBarrel='" & NetBarrels.Text & "',netTons='" & NetMetricTons.Text & "',proceedsDestination='" & Destination.Text & "',proceedNGN='" & ProceedPriceNaira.Text & "',proceedUSD='" & ProceedPriceDollar.Text & "',crudeType='" & CrudeType.Text & "',equityOwner='" & EquityOwner.Text & "',liftingVessel='" & LiftingVessle.Text & "',acceptanceDate='" & AcceptanceDate.Text & "',agent='" & Agent.Text & "',cargoInspector='" & CargoInspector.Text & "',quantityLiftedGrossBBLS='" & QuantitiesLiftedGrossBBLS.Text & "',quantityLiftedNetBBLS='" & QuantitiesLiftedNetBBLS.Text & "',quantityLiftedNetMT='" & QuantitiesLiftedNetMT.Text & "',quantityLiftedNetAPI='" & QuantitiesLiftedNetAPI.Text & "',liftingDestination='" & LiftingDestination.Text & "' WHERE referenceID='" & ReferenceID.Text & "' AND companyID= '" & Session("UserLoginID") & "';"
                Dim cmd As New MySqlCommand(strSQL, conn)
                cmd.ExecuteNonQuery()

                MessageBox.Show(Me, "There is data!")

            End If

            PreviewReturnID.Text = ReferenceID.Text

            Dim db As String = "SELECT * FROM exportreturn WHERE referenceID='" & ReferenceID.Text & "' AND companyID= '" & Session("UserLoginID") & "';"
            Using cn As MySqlCommand = New MySqlCommand(db, conn)
                Using da As New MySqlDataAdapter(cn)
                    Dim ds As New DataSet()
                    da.Fill(ds)
                    ExportSummaryGridView.DataSource = Nothing
                    ExportSummaryGridView.DataBind()

                    ExportSummaryGridView.DataSource = ds
                    ExportSummaryGridView.DataBind()

                    ProceedsGridView.DataSource = Nothing
                    ProceedsGridView.DataBind()

                    ProceedsGridView.DataSource = ds
                    ProceedsGridView.DataBind()

                    LiftingGridView.DataSource = Nothing
                    LiftingGridView.DataBind()

                    LiftingGridView.DataSource = ds
                    LiftingGridView.DataBind()

                End Using
            End Using
        Catch ex As MySqlException
            MessageBox.Show(Me, ex.Message)

        Finally
            DisconnectDatabase()
        End Try
    End Sub



    Protected Sub CancelExportDataReturn_Click(Sender As Object, e As EventArgs) Handles CancelExportDataReturn.Click
        ExportSummary.Visible = True
        ExportProceeds.Visible = True
        LiftingStatistics.Visible = True
        ExportDataReturnPreviewPanel.Visible = False

        RefreshPage.Visible = True
        PreviewReturn.Visible = True
        SaveExportDataReturn.Visible = False
        CancelExportDataReturn.Visible = False

    End Sub


    Protected Sub SaveExportDataReturn_Click(Sender As Object, e As EventArgs) Handles SaveExportDataReturn.Click
        Try
            ConnectDatabase()
            Dim ExportDataReturnStatus = "1"
            Dim strSQL As String
            strSQL = "UPDATE exportreturn SET status='" & ExportDataReturnStatus & "' WHERE referenceID='" & ReferenceID.Text & "' AND companyID= '" & Session("UserLoginID") & "';"
            Dim cmd As New MySqlCommand(strSQL, conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show(Me, "You have successfuly upload Export Data Return for the month of " & ExportMonth.SelectedItem.Text & "  " & ExportQuarter.SelectedItem.Text)

        Catch ex As MySqlException
            MessageBox.Show(Me, ex.Message)

        Finally
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
        Response.Redirect("./")
    End Sub

    Protected Sub ExportPermitIcon_Click(sender As Object, e As EventArgs) Handles ExportPermitIcon.Click
        Response.Redirect("../export-permit/")
    End Sub

    Protected Sub ReportsIcon_Click(sender As Object, e As EventArgs) Handles ReportIcon.Click
        Response.Redirect("../reports/")
    End Sub

End Class