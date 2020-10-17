Imports System.Web
Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Data.OleDb
Imports System.Web.Security
Imports System.Configuration
Imports MySql.Data.MySqlClient

Public Class _default37
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsNothing(Session("Login")) Or Not Session("Login") = "True" Then
            Response.Redirect("../../")
        Else

            If Not String.IsNullOrEmpty(Request.QueryString("/printable-certificate/")) Then
                Dim ExportPermitReference As String = Request.QueryString("/printable-certificate/")

                Try
                    ConnectDatabase()

                    Dim MyAdapter As New MySqlDataAdapter
                    Dim SqlQuery = "SELECT * FROM exportpermit WHERE CompanyID='" & Session("UserLoginID") & "' AND referenceCode ='" & ExportPermitReference & "'"
                    Dim Command As New MySqlCommand
                    Command.Connection = conn
                    Command.CommandText = SqlQuery
                    MyAdapter.SelectCommand = Command

                    Dim reader As MySqlDataReader
                    reader = Command.ExecuteReader
                    'Check if the credentials provided is in the database
                    If reader.HasRows Then
                        reader.Close()
                        Dim db As String = "SELECT * FROM exportpermit WHERE CompanyID='" & Session("UserLoginID") & "' AND referenceCode ='" & ExportPermitReference & "'"

                        Using cn As MySqlCommand = New MySqlCommand(db, conn)
                            Using da As New MySqlDataAdapter(cn)

                                Dim City As String

                                Dim dbc As String = "SELECT * FROM city WHERE city='" & Session("UserLoginCompanyCity") & "'"
                                Using cnc As MySqlCommand = New MySqlCommand(dbc, conn)
                                    Using dac As New MySqlDataAdapter(cnc)

                                        'Get the list of rows needed into Session, so as to enable us retreive it later

                                        Dim dsc As New DataSet()
                                        dac.Fill(dsc, "city")
                                        City = dsc.Tables(0).Rows(0).Item("city").ToString
                                    End Using
                                End Using
                                Dim dt As New DataTable()
                                Dim ds As New DataSet()
                                da.Fill(dt)
                                da.Fill(ds, "exportpermit")


                                ExportReference.Text = ds.Tables(0).Rows(0).Item("referenceCode").ToString
                                AppName.Text = Session("UserLoginName")
                                AppAddress.Text = Session("UserLoginCompanyAddress")
                                AppCity.Text = City
                                AppPermitQuarter.Text = ds.Tables(0).Rows(0).Item("exportPermitName").ToString
                                AppProductName.Text = ds.Tables(0).Rows(0).Item("productName").ToString
                                AppExportQuantity.Text = ds.Tables(0).Rows(0).Item("quantity").ToString
                                Dim TotalAmount As String = ds.Tables(0).Rows(0).Item("totalAmountUS").ToString
                                TotalAmount = FormatNumber(TotalAmount, 2, TriState.False, , TriState.True)

                                AppFOBValue.Text = TotalAmount
                                AppPeriodOfExport.Text = ""
                                AppProposedDateOfExpor.Text = ds.Tables(0).Rows(0).Item("applicationDate").ToString
                                AppPeriodCovere.Text = ds.Tables(0).Rows(0).Item("periodCoveredFrom").ToString & " - " & ds.Tables(0).Rows(0).Item("periodCoveredTo").ToString
                                AppNameOfExporte.Text = ds.Tables(0).Rows(0).Item("exporterName").ToString

                                ApprovalSignature.DataSource = dt
                                ApprovalSignature.DataBind()
                            End Using
                        End Using
                    Else
                        reader.Close()
                        Response.Redirect("../", False)
                    End If

                Catch ex As Exception
                    'MessageBox.Show(Me, ex.Message)
                Finally
                    DisconnectDatabase()
                End Try
            Else
                Response.Redirect("../../", False)
            End If

        End If
    End Sub

End Class