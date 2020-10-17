Imports System.Data

Partial Class amdsetupdeviceprice
    Inherits System.Web.UI.Page

    Dim GenTool As NNLN = xsmsCentralToolx.SetTool

    Protected Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init
        Try
            If IsPostBack = False Then
                lblInstrument.Text = Request("ins")
                lblParameters.Text = Request("par")
                lblInstType.Text = Request("instype")
                Session.Add("did", Request("did"))
                txtMainDeviceID.Text = Session("did")
                fetchData()
                Session("xyz") = ""
            End If

        Catch ex As Exception
            MessageBox.Show(Panel1, ex.Message)
        End Try
    End Sub

    Sub fetchData()
        Try
            Dim sql As String = "select sysID as ID,MinValue1,MaxValue1,Amount,amtAboveMaxValue,amt4First,IsMaxValue,MainDeviceID as InstID,Value4Occurance from maindeviceprice where MainDeviceID=" & Val(Session("did"))
            grd.DataSource = GenTool.DataSetData(sql).Tables(0)
            grd.DataBind()
        Catch ex As Exception
            GenTool.GrabError(ex.Message, "fetchData")
        End Try
    End Sub

    Protected Sub chkIsAbove_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkIsAbove.CheckedChanged
        If chkIsAbove.Checked = True Then
            TextBox2.Text = "0"
            TextBox1.Text = "0"
            TextBox1.Visible = False
            TextBox2.Visible = False
            Label25.Visible = False
            Label27.Visible = False
            txtAmount.Visible = False
            TextBox6.Visible = True
            Label37.Visible = True
            txtAmount.Text = "0"
            Label35.Visible = False
            TextBox3.Visible = True
            Label28.Visible = True
            Label29.Visible = True
            TextBox4.Visible = True

            Label38.Visible = True
            TextBox7.Visible = True
        Else
            TextBox1.Visible = True
            TextBox2.Visible = True
            Label25.Visible = True
            Label27.Visible = True

            TextBox3.Visible = False
            Label28.Visible = False
            Label29.Visible = False
            TextBox4.Visible = False

            TextBox3.Text = "0"
            TextBox4.Text = "0"
            txtAmount.Visible = True
            Label35.Visible = True
            TextBox6.Visible = False
            TextBox6.Text = "0"
            Label37.Visible = False
            TextBox7.Text = "0"
            Label38.Visible = False
            TextBox7.Visible = False
        End If
    End Sub

    Private Sub grdy_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grd.RowCreated
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

    Protected Sub grd_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles grd.SelectedIndexChanged
        Try
            Session("xyz") = grd.SelectedRow.Cells(1).Text

            Dim dsV As DataSet = GenTool.DataSetData("select * from maindeviceprice where sysID=" & Val(Session("xyz")))
            GenTool.resetform(Panel1, dsV)
            btnDelete.Visible = True
            btnPreview_ConfirmButtonExtender.ConfirmText = "Are you sure you want to UPDATE this record"
            chkIsAbove_CheckedChanged(Nothing, Nothing)

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btncancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Try
            GenTool.resetform(Panel1)
            btnDelete.Visible = False
            btnPreview_ConfirmButtonExtender.ConfirmText = "Are you sure you want to SAVE this record"
            chkIsAbove.Checked = False
            Session("xyz") = ""
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnPreview_Click(sender As Object, e As System.EventArgs) Handles btnPreview.Click
        Dim msgtext As String = ""

        Dim FUpdate As String = ""
        Dim FV As String = ""
        Dim FN As String = ""

        Try
            If chkIsAbove.Checked = True Then
                TextBox2.Text = "0"
                TextBox1.Text = "0"
            Else
                TextBox3.Text = "0"
                TextBox4.Text = "0"
                TextBox6.Text = "0"
                TextBox7.Text = "0"
            End If

            txtMainDeviceID.Text = Session("did")
            msgtext = GenTool.checkControl(Panel1, FN, FV, FUpdate)
            If msgtext <> "" Then Return

            Dim sql = "Insert into maindeviceprice(" & FN & ") Values (" & FV & ")"

            If String.IsNullOrEmpty(Session("xyz")) = True Then
                msgtext = "Instrument price range saved successfully"
            Else
                sql = "Update maindeviceprice set " & FUpdate & " where sysID=" & Val(Session("xyz"))
                msgtext = "Instrument price range updated successfully"
            End If

            'Response.Write(sql)

            If GenTool.ExecuteDatabase(sql) = True Then
                GenTool.FormHistory(lblInstType.Text & " Price was set", Request.UserHostAddress, Val(Session("sysID")))
                btncancel_Click(Nothing, Nothing)

                fetchData()
            Else
                msgtext = "The system was unable to save this record,check your entry and try again,if it continues contact service center"
            End If

        Catch ex As Exception
            msgtext = ex.Message
        Finally

            If msgtext <> "" Then
                MessageBox.Show(Panel1, msgtext)
            End If
        End Try
    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As System.EventArgs) Handles btnDelete.Click
        Dim msgText As String = ""

        Try
            Dim sd As String = "delete from maindeviceprice where sysID=" & Val(Session("xyz"))
            If GenTool.ExecuteDatabase(sd) = True Then
                GenTool.FormHistory("Price set for Instrument type : " & lblInstType.Text & " was deleted ", Request.UserHostAddress, , Val(Session("ID")))
                GenTool.resetform(Panel1)
                msgText = "Your Instrument was deleted successfully"
                fetchData()
            Else
                msgText = "Your account cannot be updated at the moment,please try again later"
            End If

        Catch ex As Exception
            msgText = "Your account cannot be delete at the moment,please try again later"
        Finally
            If msgText <> "" Then
                MessageBox.Show(Me, msgText)
            End If
        End Try
    End Sub

    Protected Sub btnAddMeasure_Click(sender As Object, e As System.EventArgs) Handles btnAddMeasure.Click
        Try
            Response.Redirect("amdsetupriceaddmeasure.aspx?ins=" & Request("par") & "&par=" & Request("par") & "&instype=" & Request("instype") & "&did=" & Session("did"))
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnDelete0_Click(sender As Object, e As System.EventArgs) Handles btnDelete0.Click
        Dim sd As String = "delete from maindeviceprice where MainDeviceID=" & Val(Session("did"))
        Dim dbStore As New ArrayList
        dbStore.Add(sd)
        sd = "delete from maindevicepriceadmeasure where MainDeviceID=" & Val(Session("did"))
        dbStore.Add(sd)
        If GenTool.ExecuteBulkSQL(dbStore) = True Then
            MessageBox.Show(Panel1, "Deleted Successfully")
            fetchData()
        Else
            MessageBox.Show(Panel1, "Failure")
        End If
    End Sub
End Class
