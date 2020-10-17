Imports System.Data

Partial Class adminquiz
    Inherits System.Web.UI.Page
    Dim GenTool As NNLN = xsmsCentralToolx.SetTool

    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        Dim msgtext As String = ""

        Try

            Dim FUpdate As String = ""
            Dim FV As String = ""
            Dim FN As String = ""

            lblMsg.Text = ""
            txtA_O.Text = cboAnswer.SelectedIndex

            msgtext = GenTool.checkControl(Panel1, FN, FV, FUpdate)

            If msgtext <> "" Then Return

            Dim sql = "Insert into  quitsetup(" & FN & ") Values (" & FV & ")"

            'Response.Write(sql)

            If String.IsNullOrEmpty(Session("m123xm")) = True Then
                msgtext = "Record created successfully"

            Else

                sql = "Update  quitsetup set " & FUpdate & " where sysID=" & Val(Session("m123xm"))
                msgtext = "Record updated successfully"

            End If

            If GenTool.ExecuteDatabase(sql) = True Then

                btnReset_Click(Nothing, Nothing)
                filldb("")
                btnDelete.Visible = False
            Else
                msgtext = "The system was unable to save this record,check your entry and try again,if it continues contact admin"
            End If

        Catch ex As Exception
            lblMsg.Text = ex.Message
        Finally
            lblMsg.Text = msgtext
            If msgtext <> "" Then MessageBox.Show(Me, msgtext)
        End Try
    End Sub

    Private Sub filldb(ByVal w As String)
        Dim ds As DataSet = GenTool.DataSetData("select sysID as ID,Question,A_A,A_B,A_C,A_D,A_O,Answer,Status from quitsetup where sysID<>-04984984  " & w)
        Try
            grd.DataSource = ds.Tables(0)
            grd.DataBind()

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

    Protected Sub btnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click
        GenTool.resetform(Panel1)
        btnPreview.Text = "Save"
        btnDelete.Visible = False
    End Sub

    Protected Sub grd_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grd.SelectedIndexChanged
        Session("m123xm") = grd.SelectedRow.Cells(1).Text
        btnPreview_ConfirmButtonExtender.ConfirmText = "Are you SURE you want to UPDATE this record?"
        GenTool.resetform(Panel1, GenTool.DataSetData("select * from  quitsetup where sysID=" & Val(Session("m123xm"))))
        btnPreview.Text = "Update"
        'CheckBox1.Checked = IIf(Val(grd.SelectedRow.Cells(9).Text) = 1, True, False)
        btnDelete.Visible = True
    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If IsPostBack = False Then
            filldb("")
        End If
    End Sub
End Class
