Imports System.Data

Partial Class invioces
    Inherits System.Web.UI.Page
    Dim GenTool As NNLN = xsmsCentralToolx.SetTool

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            filldb("")
        End If

    End Sub

    Private Sub filldb(ByVal w As String)

        Dim ds As DataSet = GenTool.DataSetData("select sysID as ID,amountDue as 'Amount Due',PaymentName as 'Payment Name' ,Narration,AmountPaid as 'Amount Paid',amountDue-AmountPaid as Balance,BookAmount,ApprovalStatus,OrderId as 'Order ID',date_format(regDate,'%D-%M-%Y') as 'Trans Date' from paymentsheet where companyID=" & Val(Session("ID")) & " " & w)

        Try

            grd.DataSource = ds.Tables(0)
            grd.DataBind()
            Dim sd As String = GenTool.getSummation(grd, 6)
            lblMsg.Text = Val(sd).ToString("Total OutStanding Bill : #,#.00")

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            Dim w As String = ""

            If cboQueryOptions.SelectedIndex = 1 Then
                w = " AND amountDue-AmountPaid=0"
            ElseIf cboQueryOptions.SelectedIndex = 2 Then
                w = " AND amountDue-AmountPaid>0"
            End If

            If chkIncludeDate.Checked = True Then
                w &= " And regDate>=" & GenTool.addbackslash(txtDPTFrom.Text) & "AND regDate<=" & GenTool.addbackslash(txtDPTTo.Text)
            End If

            filldb(w)

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub grd_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grd.SelectedIndexChanged

        Try
            Dim sTotal As Double = 0

            For k As Integer = 0 To grd.Rows.Count - 1

                Dim chk As CheckBox = CType(grd.Rows(k).FindControl("chkChild"), CheckBox)
                If chk.Checked = True AndAlso Val(grd.Rows(k).Cells(6).Text) > 0 AndAlso grd.Rows(k).Cells(8).Text <> "Awaiting Confirmation" Then
                    sTotal += Val(grd.Rows(k).Cells(6).Text)
                End If

            Next


            lblamtSelected.Text = Format(sTotal, "0,0.00")

        Catch ex As Exception
        End Try
    End Sub

    Private Sub grd_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grd.RowCreated
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                e.Row.Attributes("onmouseover") = "this.style.cursor='pointer';this.style.textDecoration='none';"
                e.Row.Attributes("onmouseout") = "this.style.textDecoration='none';"
                e.Row.ToolTip = "Click to select row"
                e.Row.Attributes("onclick") = Me.Page.ClientScript.GetPostBackClientHyperlink(Me.grd, "Select$" & e.Row.RowIndex)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnPayAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPayAll.Click
        Try

            Dim f1 As String = ""
            Dim f2 As String = ""
            Dim f3 As String = ""
            Dim f4 As Double = 0

            Dim HasSelected As Boolean

            For k As Integer = 0 To grd.Rows.Count - 1

                If Val(grd.Rows(k).Cells(6).Text) > 0 AndAlso grd.Rows(k).Cells(8).Text <> "Awaiting Confirmation" Then
                    HasSelected = True

                    If String.IsNullOrEmpty(f1) = True Then
                        f1 = grd.Rows(k).Cells(1).Text
                        f2 = grd.Rows(k).Cells(9).Text
                        f3 = grd.Rows(k).Cells(6).Text
                        f4 = Val(grd.Rows(k).Cells(6).Text).ToString
                    Else
                        f1 &= "||+=+" & grd.Rows(k).Cells(1).Text
                        f2 &= "||+=+" & grd.Rows(k).Cells(9).Text
                        f3 &= "||+=+" & Val(grd.Rows(k).Cells(6).Text).ToString
                        f4 += Val(grd.Rows(k).Cells(6).Text)
                    End If

                End If

            Next

            If HasSelected = False Then
                MessageBox.Show(Me, "There is not pending order. Your payment will be checked and updated")
                Return
            End If

            Session("mkid") = f1
            Session("sysnarration") = "Payment on the following Order ID -->" & f2
            Session("tkamt") = f3
            Session("tkamtsum") = f4

            Response.Redirect("payment.aspx")

        Catch ex As Exception
            GenTool.GrabError(ex.Message, "btnPayAll_Click")
            MessageBox.Show(Me, ex.Message)
        End Try
    End Sub

    Protected Sub btnPayAll0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPayAll0.Click
        Try

            Dim f1 As String = ""
            Dim f2 As String = ""
            Dim f3 As String = ""
            Dim f4 As Double = 0

            Dim HasSelected As Boolean

            For k As Integer = 0 To grd.Rows.Count - 1

                Dim chk As CheckBox = CType(grd.Rows(k).FindControl("chkChild"), CheckBox)
                If chk.Checked = True Then

                    If Val(grd.Rows(k).Cells(6).Text) > 0 AndAlso grd.Rows(k).Cells(8).Text <> "Awaiting Confirmation" Then
                        HasSelected = True
                        If String.IsNullOrEmpty(f1) = True Then
                            f1 = grd.Rows(k).Cells(1).Text
                            f2 = grd.Rows(k).Cells(9).Text
                            f3 = grd.Rows(k).Cells(6).Text
                            f4 = Val(grd.Rows(k).Cells(6).Text).ToString
                        Else
                            f1 &= "||+=+" & grd.Rows(k).Cells(1).Text
                            f2 &= "||+=+" & grd.Rows(k).Cells(9).Text
                            f3 &= "||+=+" & Val(grd.Rows(k).Cells(6).Text).ToString
                            f4 += Val(grd.Rows(k).Cells(6).Text)
                        End If

                    End If

                End If

            Next

            If HasSelected = False Then
                MessageBox.Show(Me, "You have not selected any pending order")
                Return
            End If

            Session("mkid") = f1
            Session("sysnarration") = "Payment on the following Order ID -->" & f2
            Session("tkamt") = f3
            Session("tkamtsum") = f4

            Response.Redirect("payment.aspx")

        Catch ex As Exception
            GenTool.GrabError(ex.Message, "btnPayAll0_Click")
            MessageBox.Show(Me, ex.Message)
        End Try
    End Sub
End Class
