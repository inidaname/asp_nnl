Imports System.Data

Partial Class downloadcenter
    Inherits System.Web.UI.Page

    Dim GenTool As NNLN = xsmsCentralToolx.SetTool

    Dim FN As String = ""
    Dim FV As String = ""
    Dim FUpdate As String = ""

    Private Sub filldb(ByVal w As String)
        Dim ds As DataSet = GenTool.DataSetData("select sysID as ID,FileName,description,d_type as 'Document Type',if(RecordStatus=1,'Display','Hide') as DisplayStatus,Email from downloadcenter " & w)
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

            If Session("sdp1") = "" AndAlso fdb IsNot Nothing AndAlso fdb.FileName = "" Then
                msgtext = "You have not selected file"
                Return
            End If

            If fdb IsNot Nothing AndAlso fdb.FileName <> "" Then

                Dim f() As String = txtfilename.Text.Split(".")

                Try

                    txtfilename.Text = f(0).Trim & IO.Path.GetExtension(fdb.FileName)
                    Dim fname As String = ""

                    If cbolot.SelectedIndex = 1 Then
                        fname = pathdoclink & "downloadsmember/" & txtfilename.Text
                    ElseIf cbolot.SelectedIndex = 2 Then
                        fname = pathdoclink & "~/dowloadnonmembers/" & txtfilename.Text
                    End If

                    If fname = "" Then
                        msgtext = "You have not made appropriate selection"
                        Return
                    End If

                    fdb.SaveAs(fname)

                Catch ex As Exception
                    msgtext = "The system couldnt save this file,please check you file name, remove all special characters"
                    GenTool.GrabError(ex.Message, "btnPreview_Click-managelots")
                    Return
                End Try

            End If

            msgtext = GenTool.checkControl(Panel1, FN, FV, FUpdate)

            If msgtext <> "" Then Return

            Dim sql = "Insert into downloadcenter(" & FN & ") Values (" & FV & ")"

            If String.IsNullOrEmpty(Session("sdp1")) = True Then
                msgtext = "Record created successfully"
            Else
                sql = "Update downloadcenter set " & FUpdate & " where sysID=" & Val(Session("sdp1"))
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
        GenTool.resetform(Panel1)
        Session("sdp1") = ""
        btnPreview_ConfirmButtonExtender.ConfirmText = "Are you sure you want to SAVE this record?"
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
            Session("sdp1") = grd.SelectedRow.Cells(1).Text
            btnPreview_ConfirmButtonExtender.ConfirmText = "Are you sure you want to UPDATE this record?"
            Dim fsd As DataSet = GenTool.DataSetData("select * from downloadcenter where sysID=" & Val(Session("sdp1")))
            GenTool.resetform(Panel1, fsd)
        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)
        End Try
    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        filldb("")
    End Sub


End Class
