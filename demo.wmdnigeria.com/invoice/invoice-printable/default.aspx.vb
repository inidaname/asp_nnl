Imports System.Web
Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Web.Security
Imports System.Configuration
Imports MySql.Data.MySqlClient

Public Class _default36
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("Login") = True And Session("UserLoginUserType") = "WMD Inspector" Then
            Response.Redirect("../wmd-inspector/")

        ElseIf Session("Login") = True And Session("UserLoginUserType") = "CPI Inspector" Then
            Response.Redirect("../cpi-inspector/")

        ElseIf Session("Login") = True And Session("UserLoginUserType") = "Calibrator" Then
            Response.Redirect("../calibrator/")

        ElseIf Session("Login") = True And Session("UserLoginUserType") = "Authorized Verifier" Then
            Response.Redirect("../authorized-verifier/")

        End If

        If IsNothing(Session("Login")) Or Not Session("Login") = "True" Then
            Response.Redirect("../../")
        Else

            If Not String.IsNullOrEmpty(Request.QueryString("/invoice/")) Then
                Dim OrderID As String = Request.QueryString("/invoice/")
                Try
                    ConnectDatabase()

                    Dim MyAdapter As New MySqlDataAdapter
                    Dim SqlQuery = "SELECT * FROM payment WHERE CompanyID='" & Session("UserLoginID") & "' AND orderID='" & OrderID & "'"
                    Dim Command As New MySqlCommand
                    Command.Connection = conn
                    Command.CommandText = SqlQuery
                    MyAdapter.SelectCommand = Command

                    Dim reader As MySqlDataReader
                    reader = Command.ExecuteReader
                    'Check if the credentials provided is in the database
                    If reader.HasRows Then
                        reader.Close()
                        Dim dbs As String = "SELECT * FROM payment WHERE CompanyID='" & Session("UserLoginID") & "' AND orderID='" & OrderID & "'"
                        Using cns As MySqlCommand = New MySqlCommand(dbs, conn)
                            Using das As New MySqlDataAdapter(cns)
                                Dim ds As New DataSet()
                                das.Fill(ds, "payment")
                                DisplayInvoice.DataSource = ds
                                DisplayInvoice.DataBind()
                            End Using
                        End Using


                        Dim db As String = "SELECT *, SUM(amountPaid) AS InvoiceTotalAmount FROM payment WHERE CompanyID='" & Session("UserLoginID") & "' AND orderID='" & OrderID & "'"
                        Using cn As MySqlCommand = New MySqlCommand(db, conn)
                            Using da As New MySqlDataAdapter(cn)
                                Dim ds As New DataSet()
                                da.Fill(ds, "payment")

                                Session.Add(("InvoiceID"), ds.Tables(0).Rows(0).Item("orderID").ToString)
                                Session.Add(("InvoiceDate"), ds.Tables(0).Rows(0).Item("invoiceDate").ToString & "   " & ds.Tables(0).Rows(0).Item("invoiceTime").ToString)
                                Session.Add(("InvoiceTotalAmount"), "   " & FormatNumber(ds.Tables(0).Rows(0).Item("InvoiceTotalAmount").ToString, 2, TriState.False, , TriState.True))

                                InvoiceID.Text = Session("InvoiceID").ToString
                                InvoiceDate.Text = Session("InvoiceDate").ToString
                                InvoiceCompanyName.Text = Session("UserLoginCompanyName").ToString & " "
                                InvoiceUsername.Text = Session("UserLoginName").ToString
                                InvoiceCompanyAddress.Text = Session("UserLoginCompanyAddress").ToString
                                InvoiceTotalAmount.Text = Session("InvoiceTotalAmount").ToString

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
                Response.Redirect("../", False)
            End If
        End If

    End Sub

End Class