Imports System.Data

Partial Class admincarrears
    Inherits System.Web.UI.Page
    Dim GenTool As NNLN = xsmsCentralToolx.SetTool

    Dim dsFillCompany As New DataSet

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Try
            If IsPostBack = False Then
                txtMessage.Content = GenTool.getSingleValue("select carrears from carrears")
            End If

        Catch ex As Exception
            GenTool.GrabError(ex.Message, "allocatedlot")
        End Try
    End Sub



    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        Dim msgText As String = ""

        Try
            Dim sql As String

            Dim sd As String = "select carrears from carrears"

            If GenTool.HasRows(sd) = True Then
                sql = "update carrears set carrears=" & GenTool.addbackslash(txtMessage.Content)
            Else
                sql = "Insert into carrears(carrears) value(" & GenTool.addbackslash(txtMessage.Content) & ")"
            End If

            If GenTool.ExecuteDatabase(sql) = True Then
                GenTool.FormHistory("Carrears  :   was created ", Request.UserHostAddress, , Val(Session("sysID")))
                msgText = "Record was created"
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


End Class
