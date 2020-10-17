Imports System.Data

Partial Class frontpagelastestnewssetup
    Inherits System.Web.UI.Page

    Dim GenTool As NNLN = xsmsCentralToolx.SetTool

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Try
            If IsPostBack = False Then
                If GenTool.HasDatasetAnyRecord(dsFrontPageSetup) = True Then
                    getFrontPageSetup()
                End If
                filldb("")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Dim FN As String = ""
    Dim FV As String = ""
    Dim FUpdate As String = ""

    Private Sub filldb(ByVal w As String)
        Dim ds As DataSet = GenTool.DataSetData("select sysID as ID,HeaderName,HeaderCode,recordStatus from frontpagesetup")
        Try
            grd.DataSource = ds.Tables(0)
            grd.DataBind()
        Catch ex As Exception
        End Try
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
            txtMessage.Content = GenTool.getSingleValue("select BodyMessage from frontpagesetup where sysID=" & Val(grd.SelectedRow.Cells(1).Text))
            Session("lnew") = Val(grd.SelectedRow.Cells(1).Text)
            btnSendMessage.Text = "Update Record"
            btnDelete.Visible = True
            txtHeadline.Text = grd.SelectedRow.Cells(2).Text
            cboGroupName.SelectedIndex = GenTool.getddlindexvalue(cboGroupName, grd.SelectedRow.Cells(3).Text)
            chkshow.Checked = IIf(Val(grd.SelectedRow.Cells(4).Text) = 1, True, False)

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnSendMessage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSendMessage.Click
        Dim msgText As String = ""

        If cboGroupName.SelectedIndex < 1 Then
            msgText = "You have not selected"
            Return
        End If

        If String.IsNullOrEmpty(txtMessage.Content) = True Then
            msgText = "You have not entered document"
            Return
        End If

        If String.IsNullOrEmpty(txtHeadline.Text) = True Then
            msgText = "You have not entered headline"
            Return
        End If

        Dim sql As String

        txtMessage.ActiveMode = AjaxControlToolkit.HTMLEditor.ActiveModeType.Html

        If String.IsNullOrEmpty(Session("lnew")) = True Then
            sql = "select sysID from frontpagesetup where HeaderCode=" & GenTool.addbackslash(cboGroupName.Text) & " AND HeaderName=" & GenTool.addbackslash(txtHeadline.Text)

            If GenTool.HasRows(sql) = True Then
                msgText = "The headline is already existing"
                Return
            End If

            sql = "Insert into frontpagesetup(HeaderName,BodyMessage,HeaderCode,recordStatus) Values(" & GenTool.addbackslash(txtHeadline.Text) & "," & _
                GenTool.addbackslash(txtMessage.Content) & "," & GenTool.addbackslash(cboGroupName.Text) & "," & IIf(chkshow.Checked = True, 1, 0) & ")"

        Else

            sql = "update frontpagesetup set HeaderName=" & GenTool.addbackslash(txtHeadline.Text) & ",BodyMessage=" & GenTool.addbackslash(txtMessage.Content.ToString) & _
            ",HeaderCode=" & GenTool.addbackslash(cboGroupName.Text) & ",recordStatus=" & IIf(chkshow.Checked = True, 1, 0) & " where sysID=" & Val(Session("lnew"))

        End If

        Try
            If GenTool.ExecuteDatabase(sql) = True Then
                msgText = "This record was saved successfully"
                reset()
                filldb("")
            Else
                msgText = "This record failed to save"
            End If

        Catch ex As Exception
            msgText = "System error, please try again"
            GenTool.GrabError(ex.Message, "btnSendMessage_Click-frontpagelastestnewssetup")
        Finally
            MessageBox.Show(Me, msgText)
        End Try
    End Sub

    Private Sub reset()
        'cboGroupName.SelectedIndex = 0
        txtHeadline.Text = ""
        txtMessage.Content = ""
        Session("lnew") = ""
        btnSendMessage.Text = "Save Record"
        btnDelete.Visible = False
    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim msgText As String = ""

        Try

            Dim Sql As String = "delete from frontpagesetup  where sysID=" & Val(Session("lnew"))

            If GenTool.ExecuteDatabase(Sql) = True Then
                msgText = "Record delete was  successfully"
                filldb("")
            Else
                msgText = "Record delete failed"
            End If
        Catch ex As Exception
            msgText = "System Error, please try again later"
        Finally
            MessageBox.Show(Me, msgText)
        End Try
    End Sub

    Protected Sub btnsetup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsetup.Click
        getFrontPageSetup()
        MessageBox.Show(Me, "System upload done")

    End Sub
End Class
