Imports System.Data

Partial Class admdevicemgt
    Inherits System.Web.UI.Page

    Dim GenTool As NNLN = xsmsCentralToolx.SetTool

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Dim sysDBUser As systemDBUsers = CType(Session("sysDBUser"), systemDBUsers)

            Try
                If sysDBUser.devicemdgtright = False Then
                    Response.Redirect("administrators.aspx?error=You are not permited to view this interface")
                Else
                    filldb("")
                End If
            Catch ex As Exception
            End Try
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

    Private Sub filldb(w As String)
        Try
            Dim ds As DataSet = GenTool.DataSetData("select sysID as ID,Username,CompanyName,if(CompanyExportAlert is not null,'YES',if(CompanyExportAlert<>'','YES','NO')) as 'Has Content' ,if(CompexportShow=0,'NO','YES') as 'Alert' from companyregistration " & w)
            grd.DataSource = ds.Tables(0)
            grd.DataBind()
            Session.Add("whereClause", w)

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub grd_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grd.PageIndexChanging
        grd.PageIndex = e.NewPageIndex
        filldb(Session("whereClause"))
    End Sub
 
    Protected Sub grd_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles grd.SelectedIndexChanged
        Try
            Session.Add("cisID", grd.SelectedRow.Cells(1).Text)
            Dim ds As DataSet = GenTool.DataSetData("select  CompanyExportAlert,CompexportShow from companyregistration where sysID=" & Val(grd.SelectedRow.Cells(1).Text))

            If GenTool.HasDatasetAnyRecord(ds) = False Then
                With ds.Tables(0).Rows(0)
                    Editor1.Content = .Item(0).ToString
                    chkShow.Checked = IIf(Val(.Item(1).ToString) = 0, False, True)
                End With

            End If

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As System.EventArgs) Handles btnSearch.Click
        Dim w As String = " where CompanyName like " & GenTool.addbackslash(txtsearchcomp.Text, , smsXMobile.smsXMobile.WillCardSettings.FullWicards)

        If cboAutoSearch.SelectedIndex = 1 Then
            w &= " AND CompanyExportAlert<>''"
        ElseIf cboAutoSearch.SelectedIndex = 2 Then
            w &= " AND (CompanyExportAlert is  null Or CompanyExportAlert='')"
        End If

        filldb(w)
    End Sub

    Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click
        Try
            Dim isShowMsg As String = "0"
            If chkShow.Checked = True Then
                isShowMsg = "1"
            End If

            Dim sd As String = "update companyregistration set CompanyExportAlert=" & GenTool.addbackslash(Editor1.Content) & ",CompexportShow=" & isShowMsg & "  WHERE	sysID=" & Val(Session("cisID"))
            If GenTool.ExecuteDatabase(sd) = True Then
                MessageBox.Show(Me, "Record update successfully")
                Editor1.Content = ""
                chkShow.Checked = False
                filldb(Session("whereClause"))
            Else
                MessageBox.Show(Me, "Record update failed")
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
