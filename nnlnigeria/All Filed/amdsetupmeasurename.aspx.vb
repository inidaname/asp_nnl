Imports System.Data

Partial Class amdsetupdeviceprice
    Inherits System.Web.UI.Page

    Dim GenTool As NNLN = xsmsCentralToolx.SetTool

    Protected Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init
        If IsPostBack = False Then
            fetchData()
        End If
    End Sub

    Sub fetchData()
        Try
            Dim sql As String = "select sysID as ID,MeasureName,MeasureValue from maindevicemeasurename "
            grd.DataSource = GenTool.DataSetData(sql).Tables(0)
            grd.DataBind()
        Catch ex As Exception
            GenTool.GrabError(ex.Message, "fetchData")
        End Try
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

    Protected Sub grd_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles grd.SelectedIndexChanged
        Try
            Session("xyz") = grd.SelectedRow.Cells(1).Text

            Dim dsV As DataSet = GenTool.DataSetData("select * from maindevicemeasurename where sysID=" & Val(Session("xyz")))
            GenTool.resetform(Panel1, dsV)
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnPreview0_Click(sender As Object, e As System.EventArgs) Handles btnPreview0.Click
        Dim msgtext As String = ""

        Dim FUpdate As String = ""
        Dim FV As String = ""
        Dim FN As String = ""

        Try
           
            msgtext = GenTool.checkControl(Panel1, FN, FV, FUpdate)
            If msgtext <> "" Then Return

            Dim sql = "Insert into maindevicemeasurename(" & FN & ") Values (" & FV & ")"

            If String.IsNullOrEmpty(Session("xyz")) = True Then
                msgtext = "Measurement details saved successfully"
            Else
                sql = "Update maindevicemeasurename set " & FUpdate & " where sysID=" & Val(Session("xyz"))
                msgtext = "Measurement details updated successfully"
            End If

            'Response.Write(sql)

            If GenTool.ExecuteDatabase(sql) = True Then
                GenTool.FormHistory(TextBox3.Text & " measure was created ", Request.UserHostAddress, Val(Session("xyz")))
                GenTool.resetform(Panel1)
                fetchData()
                Session("xyz") = ""

            Else
                msgtext = "The system was unable to save this record,check your entry and try again,if it continues contact service center"
            End If

        Catch ex As Exception
            msgtext = ex.Message
        Finally

            If msgtext <> "" Then
                MessageBox.Show(Panel1, msgtext)
            End If
        End Try
    End Sub

    Protected Sub btnPreview_Click(sender As Object, e As System.EventArgs) Handles btnPreview.Click
        GenTool.resetform(Panel1)
        Session("xyz") = ""
    End Sub
End Class
