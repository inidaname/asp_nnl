Imports System.Data

Partial Class manageISPState
    Inherits System.Web.UI.Page

    Dim GenTool As NNLN = xsmsCentralToolx.SetTool

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Try
            If IsPostBack = False Then

                If dsLotName Is Nothing OrElse dsLotName.Tables.Count < 1 OrElse dsLotName.Tables(0).Rows.Count < 1 Then
                    getLotName()
                End If

                Dim regType As String = Request("pg")
                Dim lName As String = Request("cid")

                'If Val(regType) = 1 Then
                '    Panel3.Visible = True
                '    filldb("")
                'Else
                '    Panel3.Visible = False
                'End If

                getCompanyNation()

                If lName <> "" Then
                    cboISP.SelectedIndex = GenTool.getddlindexvalue(cboISP, lName)
                    lblISP.Text = lName
                    cboISP_SelectedIndexChanged(Nothing, Nothing)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub getCompanyNation()
        Try
            cboISP.Items.Clear()
            cboISP.DataTextField = "CompanyName"
            cboISP.DataValueField = "sysID"
            cboISP.DataSource = GenTool.DataSetData("select sysID,CompanyName from systemusers where recordstatus=0 AND isISP=1").Tables(0)
            cboISP.DataBind()
        Catch ex As Exception
        Finally
            cboISP.Items.Insert(0, "Select ISP")
        End Try
    End Sub

    Dim FN As String = ""
    Dim FV As String = ""
    Dim FUpdate As String = ""

    Private Sub filldb(ByVal w As String)
        Dim ds As DataSet = GenTool.DataSetData("select tbllga.sysID as ID,LGA,(select Statename from tblstate where sysID=stateID limit 1) as Statename from tbllga,allocatedlga where tbllga.sysID=allocatedlga.LGAID " & w & "  order by Statename ")
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


    Protected Sub cboISP_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboISP.SelectedIndexChanged
        If cboISP.SelectedIndex > 0 Then
            lblISP.Text = cboISP.SelectedItem.Text
            filldb(" AND ISPID=" & cboISP.SelectedValue)
        End If
    End Sub

    Protected Sub btnAssign_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAssign.Click
        If cboISP.SelectedIndex > 0 Then
            Response.Redirect("manageISPLGA.aspx?cid=" & cboISP.SelectedValue & "&cidn=" & cboISP.SelectedItem.Text)
        Else
            MessageBox.Show(Me, "Please select ISP Name")
        End If

    End Sub
End Class
