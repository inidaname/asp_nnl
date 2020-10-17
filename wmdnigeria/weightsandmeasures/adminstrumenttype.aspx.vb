Imports System.Data

Partial Class adminstrumenttype
    Inherits System.Web.UI.Page
    Dim GenTool As NNLN = xsmsCentralToolx.SetTool

    Protected Sub btnFEED_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFEED.Click
        Dim msgText As String = ""
        Try
            Dim sql As String

            sql = "Delete from maindevicesection where sysID=" & Val(txtFeeID.Text)

            If GenTool.ExecuteDatabase(sql) = True Then

                GenTool.FormHistory("INSTRUMENT TYPE :  " & txtFee.Text & " was deleted", Request.UserHostAddress, Val(Session("sysID")))
                btnFEES.Visible = False
                txtFeeID.Text = ""
                btnFEES.Text = "SAVE"
                btnFEES_ConfirmButtonExtender.ConfirmText = "Are you SURE you want to SAVE this record?"
                msgText = "Record deleted successfully"

                btnFEER_Click(Nothing, Nothing)
                Dim sd As String = " AND mainsubdeviceID=" & Val(cboFEESUBGROUP.SelectedValue)
                filldb(sd)

            Else
                msgText = "Record deleted faled"
            End If

        Catch ex As Exception
            msgText = "Your account cannot be updated at the moment,please try again later"
            GenTool.GrabError(ex.Message, "btnFEED_Click")
        Finally
            lblMsg.Text = msgText
            If msgText <> "" Then
                MessageBox.Show(Me, msgText)
            End If
        End Try
    End Sub

    Protected Sub btnFEES_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFEES.Click
        Dim msgText As String = ""
        Try
            If txtFee.Text = "" Then
                MessageBox.Show(Me, "Invalid Entry")
                Return
            End If

            Dim sql As String = ""

            If txtFeeID.Text = "" Then
                msgText = "Record saved successfully"
                sql = "INSERT INTO maindevicesection (DeviceType,mainsubdeviceID) Values (" & GenTool.addbackslash(txtFee.Text) & _
                    "," & Val(cboFEESUBGROUP.SelectedValue) & ")"
            Else

                sql = "Update maindevicesection SET DeviceType=" & GenTool.addbackslash(txtFee.Text) & ",mainsubdeviceID=" & Val(cboFEESUBGROUP.SelectedValue) & _
                    " where sysID=" & Val(txtFeeID.Text)

                msgText = "Record updated successfully"

            End If

            If GenTool.ExecuteDatabase(sql) = True Then

                If txtFeeID.Text = "" Then
                    GenTool.FormHistory("INSTRUMENT TYPE :  " & txtFee.Text & " was created", Request.UserHostAddress, Val(Session("sysID")))
                Else
                    GenTool.FormHistory("INSTRUMENT TYPE :  " & txtFee.Text & " was updated", Request.UserHostAddress, Val(Session("sysID")))
                End If

                btnFEER_Click(Nothing, Nothing)
                cboFEESUBGROUP_SelectedIndexChanged(Nothing, Nothing)

            Else
                msgText = "Your account cannot be updated at the moment,please try again later"
            End If

        Catch ex As Exception
            msgText = "Your account cannot be updated at the moment,please try again later"
            GenTool.GrabError(ex.Message, "btnFEES_Click")
        Finally
            lblMsg.Text = msgText
            If msgText <> "" Then
                MessageBox.Show(Me, msgText)
            End If
        End Try
    End Sub

    Protected Sub btnFEER_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFEER.Click

        btnFEES_ConfirmButtonExtender.ConfirmText = "Are you SURE you want to SAVE this record?"
        btnFEED.Visible = False
        txtFeeID.Text = ""
        txtFee.Text = ""
        btnFEES.Text = "SAVE"
        btnFEES.Visible = True
    End Sub

    Protected Sub grdFee_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdFee.PageIndexChanging
        grdFee.PageIndex = e.NewPageIndex
        Dim sd As String = " AND maindevicesection.mainsubdeviceID=" & Val(cboFEESUBGROUP.SelectedValue)
        filldb(sd)

    End Sub

    Private Sub filldb(ByVal w As String)
        If grdFee Is Nothing Then Return
        Dim sql As String = "select sysID as ID,DeviceType as 'Instrument Type',mainsubdeviceID as CategoryID from maindevicesection where sysID<>-00 " & w

        Dim ds As DataSet = GenTool.DataSetData(SQL)

        Try
            grdFee.DataSource = ds.Tables(0)
            grdFee.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub grdFee_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdFee.SelectedIndexChanged
        Try
            txtFeeID.Text = grdFee.SelectedRow.Cells(1).Text
            txtFee.Text = grdFee.SelectedRow.Cells(2).Text


            btnFEES_ConfirmButtonExtender.ConfirmText = "Are you SURE you want to UPDATE this record?"
            btnFEED.Visible = True
            btnFEES.Text = "UPDATE"

            Dim sd As String = "select DeviceCategory,DeviceName from mainsubdevice,maindevice,maindevicesection where maindevice.sysID=mainsubdevice.GroupID AND mainsubdevice.sysID=maindevicesection.mainsubdeviceID AND maindevicesection.sysID=" & Val(grdFee.SelectedRow.Cells(1).Text)
            Dim ds As DataSet = GenTool.DataSetData(sd)

            If ds IsNot Nothing AndAlso ds.Tables.Count > 0 And ds.Tables(0).Rows.Count > 0 Then
                With ds.Tables(0).Rows(0)
                    cboFEEGROUP.SelectedIndex = GenTool.getddlindexvalue(cboFEEGROUP, .Item(0))
                    cboFEEGROUP_SelectedIndexChanged(Nothing, Nothing)

                    cboFEESUBGROUP.SelectedIndex = GenTool.getddlindexvalue(cboFEESUBGROUP, .Item(1))
                End With
                ds.Dispose()
            End If

        Catch ex As Exception
        End Try

    End Sub

    Protected Sub cboFEEGROUP_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFEEGROUP.SelectedIndexChanged
        cboFEESUBGROUP.DataTextField = "DeviceName"
        cboFEESUBGROUP.DataValueField = "sysID"
        cboFEESUBGROUP.DataSource = GenTool.DataSetData("select sysID,DeviceName from mainsubdevice where GroupID=" & Val(cboFEEGROUP.SelectedValue)).Tables(0)
        cboFEESUBGROUP.DataBind()
        cboFEESUBGROUP.Items.Insert(0, "Select Category")
    End Sub

    Protected Sub cboFEESUBGROUP_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFEESUBGROUP.SelectedIndexChanged
        Dim sd As String = " AND mainsubdeviceID=" & Val(cboFEESUBGROUP.SelectedValue)
        filldb(sd)
    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Try
            cboFEEGROUP.DataTextField = "DeviceCategory"
            cboFEEGROUP.DataValueField = "sysID"
            cboFEEGROUP.DataSource = GenTool.DataSetData("select sysID,DeviceCategory from maindevice").Tables(0)
            cboFEEGROUP.DataBind()
            cboFEEGROUP.Items.Insert(0, "Select Main Setcor")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdFEE_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdFee.RowCreated
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                e.Row.Attributes("onmouseover") = "this.style.cursor='pointer';this.style.textDecoration='none';"
                e.Row.Attributes("onmouseout") = "this.style.textDecoration='none';"
                e.Row.ToolTip = "Click to select row"
                e.Row.Attributes("onclick") = Me.Page.ClientScript.GetPostBackClientHyperlink(Me.grdFee, "Select$" & e.Row.RowIndex)
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
