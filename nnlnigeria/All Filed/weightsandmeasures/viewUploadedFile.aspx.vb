Imports System.Data

Partial Class viewUploadedFile
    Inherits System.Web.UI.Page

    Dim GenTool As NNLN = xsmsCentralToolx.SetTool
    Dim dsCC, dsISP As DataSet

    Private Sub filldata(ByVal w As String)
        Try
            Dim sql As String = "select sysID as ID,OFilename as 'Orginal Filename',GFilename as 'Given Filename',Description,date_format(UDate,'%D-%M-%Y') as Date,DATE_FORMAT(UTime, '%h:%i:%S %p') as Time,if(IsISP=0,'No','Yes') as IsISP,If(IsRead=0,'No','Yes') as IsRead from generaluploadfile where CompID<>-090902 " & w

            Dim ds As DataSet = GenTool.DataSetData(sql)
            grd.DataSource = ds.Tables(0)
            grd.DataBind()
        Catch ex As Exception
            GenTool.GrabError(ex.Message, "UploadFile-filldata")
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

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        If GenTool.HasDatasetAnyRecord(dsCC) = True Then
            dsCC = GenTool.DataSetData("select sysID ,companyName from companyregistration")

        End If

        If GenTool.HasDatasetAnyRecord(dsISP) = True Then
            dsISP = GenTool.DataSetData("select sysID,CompanyName from systemusers where ISClient=1")
        End If

        Try

            ddlCompany.Items.Clear()
            ddlCompany.DataTextField = "companyName"
            ddlCompany.DataValueField = "sysID"
            ddlCompany.DataSource = dsCC.Tables(0)
            ddlCompany.DataBind()
            ddlCompany.Items.Insert(0, "Select Company")

            ddlISP.Items.Clear()
            ddlISP.DataTextField = "CompanyName"
            ddlISP.DataValueField = "sysID"
            ddlISP.DataSource = dsISP.Tables(0)
            ddlISP.DataBind()
            ddlISP.Items.Insert(0, "Select ISP")

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            Dim w As String = ""
            Dim isp, comp As Long

            If ddlCompany.SelectedIndex > 0 Then
                comp = ddlCompany.SelectedValue
            End If

            If ddlISP.SelectedIndex > 0 Then
                isp = ddlISP.SelectedValue
            End If

            If chkComp.Checked = True AndAlso chkISP.Checked = True Then
                w = " AND (CompID=" & isp & " OR CompID=" & comp & ")"
            ElseIf chkISP.Checked = True Then
                w &= " AND CompID=" & isp & " AND IsISP=1"
            ElseIf chkComp.Checked = True Then
                w &= " AND CompID=" & comp
            End If

            If txtDPTTo.Text <> "" AndAlso txtDPTTo.Text <> "" Then
                w &= " AND UDate>=" & GenTool.addbackslash(txtDPTTo.Text) & " AND UDate<=" & GenTool.addbackslash(txtDPTTo.Text)
            End If

            If ddlReadStatus.SelectedIndex = 1 Then
                w &= " AND IsRead=1"
            ElseIf ddlReadStatus.SelectedIndex = 2 Then
                w &= " AND IsRead=0"
            End If

            If w = "" Then
                MessageBox.Show(Me, "You have not selected any query object")
                Return
            End If

            filldata(w)

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub grd_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grd.SelectedIndexChanged
        Try

            Dim folder As String = IIf(grd.SelectedRow.Cells(6).Text = "No", "generaldoc", "ispdoc")
            folder = pathdoclink & folder & "\" & grd.SelectedRow.Cells(2).Text

            If IO.File.Exists(folder) = False Then
                MessageBox.Show(Me, "The file is no longer existing,please try another")
                Return
            End If

            folder = "update generaluploadfile set IsRead=1 where sysID=" & Val(grd.SelectedRow.Cells(0).Text)
            GenTool.ExecuteDatabase(folder)

            folder = IIf(grd.SelectedRow.Cells(5).Text = "No", "generaldoc", "ispdoc")
            folder = docLink & folder & "\" & grd.SelectedRow.Cells(2).Text
            Response.Redirect(folder)

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click
        GenTool.resetform(Panel1)
    End Sub
End Class


