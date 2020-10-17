Imports System.Data

Partial Class uploadphotogallery
    Inherits System.Web.UI.Page

    Dim GenTool As NNLN = xsmsCentralToolx.SetTool

    Dim FN As String = ""
    Dim FV As String = ""
    Dim FUpdate As String = ""

    Private Sub filldb(ByVal w As String)
        Dim ds As DataSet = GenTool.DataSetData("SELECT sysID as ID,Groupname,Status FROM photogallerygroup  where  GStatus=" & Val(txtGroupdID.Text) & w)
        Try
            grd.DataSource = ds.Tables(0)
            grd.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        Dim msgtext As String = ""
        Try

            FUpdate = ""
            FV = ""
            FN = ""
            lblMsg.Text = ""

            msgtext = GenTool.checkControl(Panel1, FN, FV, FUpdate)

            If msgtext <> "" Then Return

            Dim sql = "Insert into photogallerygroup(" & FN & ") Values (" & FV & ")"

            If String.IsNullOrEmpty(Session("sdp2")) = True Then
                msgtext = "Record created successfully"
            Else
                sql = "Update photogallerygroup set " & FUpdate & " where sysID=" & Val(Session("sdp2"))
                msgtext = "Record updated successfully"
            End If

            If GenTool.ExecuteDatabase(sql) = True Then
                btnReset_Click(Nothing, Nothing)
                filldb("")
            Else
                msgtext = "The system was unable to save this record,check your entry and try again,if it continues contact admin"
            End If

        Catch ex As Exception
            GenTool.GrabError(ex.Message, "btnPreview_Click-managelots")
            lblMsg.Text = ex.Message
        Finally
            lblMsg.Text = msgtext
            If msgtext <> "" Then MessageBox.Show(Me, msgtext)
        End Try
    End Sub

    Protected Sub btnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Dim sd As String = txtGroupdID.Text
        GenTool.resetform(Panel1)
        Session("sdp2") = ""
        btnPreview_ConfirmButtonExtender.ConfirmText = "Are you sure you want to SAVE this record?"
        btnPreview.Text = "Submit"
        chkShow.Checked = True

        txtGroupdID.Text = sd
    End Sub

    Protected Sub grd_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grd.PageIndexChanging
        grd.PageIndex = e.NewPageIndex
        filldb("")
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

    Protected Sub grd_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grd.SelectedIndexChanged
        Try
            Session("sdp2") = grd.SelectedRow.Cells(1).Text
            txtphotoGroupName.Text = grd.SelectedRow.Cells(2).Text
            chkShow.Checked = IIf(Val(grd.SelectedRow.Cells(3).Text) = 0, False, True)
            btnPreview.Text = "Update"

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)
        End Try
    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If IsPostBack = False Then
            txtGroupdID.Text = Val(Request("idg"))
            filldb("")
        End If
    End Sub

End Class
