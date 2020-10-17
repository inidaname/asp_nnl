Imports System.Data

Partial Class manageISPLGA
    Inherits System.Web.UI.Page

    Dim GenTool As NNLN = xsmsCentralToolx.SetTool

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Try
            If IsPostBack = False Then
                filldb(" ")
                txtISP.Text = Val(Request("cid"))
                lblISP.Text = Request("cidn")
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub filldb(ByVal w As String)
        Dim ds As DataSet = GenTool.DataSetData("select sysID as ID,Statename from tblstate")
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


    Private Sub goGetThem(ByVal STID As String)
        Try
            chkGroup.Items.Clear()

            lblMsg.Text = "Setting LGA rights for " & lblISP.Text & " is in progress!"

            Dim ds As DataSet = GenTool.DataSetData("select sysID,LGA from tbllga where stateID=" & Val(STID))
            lblISP0.Text = ds.Tables(0).Rows.Count & " LGA"

            If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                Session("ds") = ds
                For j As Int32 = 0 To ds.Tables(0).Rows.Count - 1
                    With ds.Tables(0).Rows(j)
                        chkGroup.Items.Add(IIf(.IsNull(1) = True, "", .Item(1)))
                    End With
                Next
            End If

            Dim sd As String = "select tbllga.sysID,LGA from tbllga,allocatedlga where tbllga.sysID=LGAID AND ISPID=" & Val(txtISP.Text) & " AND stateID=" & Val(STID)
            ds = GenTool.DataSetData(sd)

            If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                Dim sValue, vValue As String
                For k As Int32 = 0 To ds.Tables(0).Rows.Count - 1
                    sValue = IIf(ds.Tables(0).Rows(k).IsNull(1) = True, "", ds.Tables(0).Rows(k).Item(1))

                    For j As Int32 = 0 To chkGroup.Items.Count - 1
                        vValue = chkGroup.Items(j).Value

                        If LCase(Trim(sValue)) = LCase(Trim(vValue)) Then
                            chkGroup.Items(j).Selected = True
                            Exit For
                        End If

                    Next
                Next
            End If

        Catch ex As Exception
        End Try

    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim fState As String = grd.SelectedRow.Cells(0).Text

            Dim ds As DataSet = CType(Session("ds"), DataSet)
            Dim SQL As String = "delete from allocatedlga where ISPID=" & Val(txtISP.Text) & " AND STID=" & Val(fState)
            GenTool.ExecuteDatabase(SQL)
            Dim linkId As Int32 = 0

            For j As Int32 = 0 To chkGroup.Items.Count - 1
                If chkGroup.Items(j).Selected = True Then
                    linkId = Val(ds.Tables(0).Rows(j).Item(0))
                    SQL = "Insert into allocatedlga (ISPID,LGAID,STID) Values (" & Val(txtISP.Text) & "," & linkId & "," & Val(fState) & ")"
                    GenTool.ExecuteDatabase(SQL)
                End If
            Next

            MessageBox.Show(Me, "Record saved successfully")

        Catch ex As Exception
            MessageBox.Show(Me, "Request was not successful")
        End Try


    End Sub

    Protected Sub btnSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click
        setAction(True)
    End Sub

    Private Sub setAction(ByVal iret As Boolean)
        For j As Int32 = 0 To chkGroup.Items.Count - 1
            chkGroup.Items(j).Selected = iret
        Next
    End Sub

    Protected Sub btnDeSellectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeSellectAll.Click
        setAction(False)
    End Sub

    Protected Sub grd_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grd.SelectedIndexChanged
        Try
            goGetThem(grd.SelectedRow.Cells(0).Text)
        Catch ex As Exception
        End Try
    End Sub
End Class
