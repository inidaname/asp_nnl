Imports System.Data

Partial Class managelots
    Inherits System.Web.UI.Page

    Dim GenTool As NNLN = xsmsCentralToolx.SetTool

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Try
            If IsPostBack = False Then

                If dsLotName Is Nothing OrElse dsLotName.Tables.Count < 1 OrElse dsLotName.Tables(0).Rows.Count < 1 Then
                    getLotName()
                End If

                btnReset_Click(Nothing, Nothing)

                Dim regType As String = Request("pg")
                Dim lName As String = Request("cid")

                If Val(regType) = 1 Then
                    Panel3.Visible = True
                    filldb("")
                Else
                    Panel3.Visible = False
                End If

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
            cbolot.Items.Clear()
            cbolot.DataTextField = "LotName"
            cbolot.DataValueField = "sysID"
            cbolot.DataSource = dsLotName.Tables(0)
            cbolot.DataBind()
        Catch ex As Exception
        Finally
            cbolot.Items.Insert(0, "Select Lots Name")
        End Try

        Try
            cbocomp.Items.Clear()
            cbocomp.DataTextField = "CompanyName"
            cbocomp.DataValueField = "sysID"
            cbocomp.DataSource = GenTool.DataSetData("select sysID,CompanyName from companyregistration where recordstatus=0").Tables(0)
            cbocomp.DataBind()
        Catch ex As Exception
        Finally
            cbocomp.Items.Insert(0, "Select Company")
        End Try

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
        Dim ds As DataSet = GenTool.DataSetData("Select allocatedterminals.sysID as ID,TerminalName,TerminalOwner,RCNumber,Location,LotName from allocatedterminals,allocatedlots where allocatedlots.sysID=allocatedterminals.LotID " & w)
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


            If fdb IsNot Nothing AndAlso fdb.FileName <> "" Then

                Try
                    Dim fname As String = GenTool.GenerateRNDCode(True, True) & IO.Path.GetExtension(fdb.FileName)
                    fname = pathdoclink & "facilitydb/" & fname
                    fdb.SaveAs(fname)
                    txtfdbName.Text = Strings.Replace(fname, "\", "\\")
                Catch ex As Exception
                    GenTool.GrabError(ex.Message, "btnPreview_Click-managelots")
                End Try
            Else
                txtfdbName.Text = Strings.Replace(txtfdbName.Text, "\", "\\")
            End If


            msgtext = GenTool.checkControl(Panel1, FN, FV, FUpdate)
            If msgtext <> "" Then Return

            Dim sql = "Insert into allocatedterminals(" & FN & ") Values (" & FV & ")"

            If String.IsNullOrEmpty(Session("sdp")) = True Then
                msgtext = "Record created successfully"

            Else

                sql = "Update allocatedterminals set " & FUpdate & " where sysID=" & Val(Session("sdp"))
                msgtext = "Record updated successfully"

            End If

            If GenTool.ExecuteDatabase(sql) = True Then

                btnReset_Click(Nothing, Nothing)

                If Panel3.Visible = True Then filldb("")
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
        GenTool.resetform(Panel1)
        txtfilepath.Visible = False
        lblfilepath.Visible = False
        lblISP.Text = ""
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

            Session("sdp") = grd.SelectedRow.Cells(1).Text
            btnPreview_ConfirmButtonExtender.ConfirmText = "Are you SURE you want to UPDATE this record?"

            txtfilepath.ValidationGroup = "fabilityDBFilename"
            Dim fsd As DataSet = GenTool.DataSetData("select * from allocatedterminals where sysID=" & Val(Session("sdp")))

            GenTool.resetform(Panel1, fsd)

            If IO.File.Exists(txtfilepath.Text) = True Then
                txtfilepath.Text = IO.Path.GetFileName(txtfilepath.Text)
            End If

            txtfilepath.ValidationGroup = ""

            Dim sectionID As String = GenTool.getRowItemInds(fsd, "LotID", "sysID", Val(Session("sdp")))
            Dim sectionName As String = GenTool.getRowItemInds(dsLotName, "LotName", "sysID", Val(sectionID))
            cbolot.SelectedIndex = GenTool.getddlindexvalue(cbolot, sectionName)

            sectionID = GenTool.getRowItemInds(fsd, "ISPID", "sysID", Val(Session("sdp")))
            sectionName = GenTool.getRowItemInds(GenTool.DataSetData("select CompanyName,sysID from systemusers"), "CompanyName", "sysID", Val(sectionID))
            cboISP.SelectedIndex = GenTool.getddlindexvalue(cboISP, sectionName)


            sectionID = GenTool.getRowItemInds(fsd, "CompID", "sysID", Val(Session("sdp")))
            sectionName = GenTool.getRowItemInds(GenTool.DataSetData("select CompanyName,sysID from companyregistration where sysID=" & sectionID), "CompanyName", "sysID", Val(sectionID))
            cbocomp.SelectedIndex = GenTool.getddlindexvalue(cbocomp, sectionName)

            cboISP_SelectedIndexChanged(Nothing, Nothing)

            txtfilepath.Visible = True
            lblfilepath.Visible = True

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)
        Finally
            txtfilepath.ValidationGroup = ""
        End Try
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            Dim w As String = ""

            If cboSearch.SelectedIndex > 0 Then
                w = " AND " & cboSearch.Text & " like " & GenTool.addbackslash(txtSearch.Text, , True)
                filldb(w)
            Else
                filldb("")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub cboISP_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboISP.SelectedIndexChanged
        If cboISP.SelectedIndex > 0 Then
            lblISP.Text = cboISP.SelectedItem.Text
        End If
    End Sub
 
    Protected Sub btnAssignLGA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAssignLGA.Click
        Try
            Response.Redirect("manageISPState.aspx?cid=" & lblISP.Text)
        Catch ex As Exception

        End Try
    End Sub
End Class
