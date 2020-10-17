Imports System.Data

Partial Class allocatedlot
    Inherits System.Web.UI.Page

    Dim dsFillCompany As New DataSet

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Try
            If IsPostBack = False Then
                filldb("")
            End If

        Catch ex As Exception
            GenTool.GrabError(ex.Message, "allocatedlot")
        End Try
    End Sub

    Dim GenTool As NNLN = xsmsCentralToolx.SetTool

    Dim FN As String = ""
    Dim FV As String = ""
    Dim FUpdate As String = ""

    Private Sub filldb(ByVal w As String)
        Dim ds As DataSet = GenTool.DataSetData("select  sysID as ID,LotName,(select CompanyName from companyregistration where sysID=CompID) as CompanyName,(select streetAddress from companyregistration where sysID=CompID) as Address,(Select count(sysID) from allocatedterminals where LotID=allocatedlots.sysID) as Terminals from allocatedlots  " & " " & w)
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

    Protected Sub grd_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grd.SelectedIndexChanged
        txtLots.Text = grd.SelectedRow.Cells(2).Text
        btnDelete.Visible = True
        btnPreview_ConfirmButtonExtender.ConfirmText = "Are you sure you want to UPDATE this record"
    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim msgText As String = ""

        Try

            Dim sd As String = "select count(sysID) from allocatedterminals where LotID=" & Val(grd.SelectedRow.Cells(1).Text)
            sd = GenTool.getSingleValue(sd)

            If Val(sd) > 0 Then
                msgText = "This record cannot be deleted because you have " & Val(sd) & " record(s) attached to it"
                Return
            End If

            sd = "delete from allocatedlots where sysID=" & Val(grd.SelectedRow.Cells(1).Text)

            If GenTool.ExecuteDatabase(sd) = True Then

                GenTool.FormHistory("Lot name : " & txtLots.Text & " was deleted ", Request.UserHostAddress, , Val(Session("ID")))

                filldb("")

                msgText = "Your record deleted successfully"
                btncancel_Click(Nothing, Nothing)
            Else
                msgText = "Your record cannot be updated at the moment,please try again later"
            End If

        Catch ex As Exception
            msgText = "Your record cannot be updated at the moment,please try again later"
        Finally
            lblMsg.Text = msgText
            If msgText <> "" Then
                MessageBox.Show(Me, msgText)
            End If
        End Try
    End Sub

    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        Dim msgText As String = ""

        Try

            Dim sd As String = "select sysID from allocatedlots where LotName=" & GenTool.addbackslash(txtLots.Text)

            If GenTool.HasRows(sd) = True Then
                msgText = "Duplcate name,please choose another name"
                Return
            End If

            sd = "insert into allocatedlots(LotName) values (" & GenTool.addbackslash(txtLots.Text) & ") "

            If GenTool.ExecuteDatabase(sd) = True Then

                GenTool.FormHistory("Lots  : " & txtLots.Text & " was created ", Request.UserHostAddress, , Val(Session("ID")))

                filldb("")

                msgText = "Record was created"
                btncancel_Click(Nothing, Nothing)
            Else
                msgText = "Your record cannot be created at the moment,please try again later"
            End If

        Catch ex As Exception
            msgText = "Your record cannot be created at the moment,please try again later"
        Finally
            lblMsg.Text = msgText
            If msgText <> "" Then
                MessageBox.Show(Me, msgText)
            End If
        End Try
    End Sub

    Protected Sub btncancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Try
            btnDelete.Visible = False
            txtLots.Text = ""
            btnPreview_ConfirmButtonExtender.ConfirmText = "Are you sure you want to SAVE this record"
        Catch ex As Exception

        End Try
    End Sub
End Class
