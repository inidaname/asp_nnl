Imports System.Data

Partial Class uploadfrontpage
    Inherits System.Web.UI.Page

    Dim GenTool As NNLN = xsmsCentralToolx.SetTool

    Dim FN As String = ""
    Dim FV As String = ""
    Dim FUpdate As String = ""

    Private Sub filldb(ByVal w As String)
        Dim ds As DataSet = GenTool.DataSetData("select sysID as ID,HeaderName,ImageName,Date_Format(RegDate,'%D-%M-%Y') as Date,DATE_FORMAT(RegTime, '%h:%i:%S %p') as Time,if(Status=1,'Display','Hide') as 'Display Status' from frontpagemain  where gDesign=0 " & w)
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

            If Session("sdp2") = "" AndAlso fdb IsNot Nothing AndAlso fdb.FileName = "" Then
                msgtext = "You have not selected file"
                Return
            End If

            If txtBDescription.Text.Length > 600 Then
                msgtext = "Brief Description cannot be greater than 600 characters"
                Return
            End If

            If fdb IsNot Nothing AndAlso fdb.FileName <> "" Then

                Dim f() As String = fdb.FileName.Split(".")

                Try

                    txtImageName.Text = f(0).Trim & IO.Path.GetExtension(fdb.FileName)

                    txtSysImageName.Text = GenTool.GenerateUniqueCode & GenTool.GenerateRNDCode(True, True) & IO.Path.GetExtension(fdb.FileName)

                    Dim fname As String = pathdoclink & "frontdoc/" & txtSysImageName.Text

                    If fname = "" Then
                        msgtext = "You have not made appropriate selection"
                        Return
                    End If

                    fdb.SaveAs(fname)

                Catch ex As Exception
                    msgtext = "The system couldnt save this file,please check you file name, remove all special characters"
                    GenTool.GrabError(ex.Message, "btnPreview_Click-uploadphotogallery")
                    Return
                End Try

            End If

            If String.IsNullOrEmpty(Session("sdp2")) = True Then
                txtTransCode.Text = GenTool.GenerateRNDCode(True, True) & GenTool.GenerateUniqueCode & GenTool.GenerateRNDCode(True, True) & GenTool.GenerateUniqueCode
            End If

            msgtext = GenTool.checkControl(Panel1, FN, FV, FUpdate)

            If msgtext <> "" Then Return

            Dim sql = "Insert into frontpagemain(" & FN & ") Values (" & FV & ")"

            If String.IsNullOrEmpty(Session("sdp2")) = True Then
                msgtext = "Record created successfully"
            Else
                sql = "Update frontpagemain set " & FUpdate & " where sysID=" & Val(Session("sdp2"))
                msgtext = "Record updated successfully"
            End If

            If GenTool.ExecuteDatabase(sql) = True Then
                sql = "update frontpagemain set FullMessage=" & GenTool.addbackslash(txtFullMessage.Content) & " where TransCode=" & GenTool.addbackslash(txtTransCode.Text)
                GenTool.ExecuteDatabase(sql)

                filldb("")

                btnReset_Click(Nothing, Nothing)
            Else
                msgtext = "The system was unable to save this record,check your entry and try again,if it continues contact admin"
            End If

        Catch ex As Exception
            GenTool.GrabError(ex.Message, "btnPreview_Click-uploadphotogallery")
            lblMsg.Text = ex.Message
        Finally
            lblMsg.Text = msgtext
            If msgtext <> "" Then MessageBox.Show(Me, msgtext)
        End Try
    End Sub

    Protected Sub btnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click
        GenTool.resetform(Panel1)
        Session("sdp2") = ""
        btnPreview_ConfirmButtonExtender.ConfirmText = "Are you sure you want to SAVE this record?"
        txtFullMessage.Content = ""
        CheckBox1.Checked = True
        btnMove.Visible = False
        cboGroupName.SelectedIndex = 0

        cboGroupName.Visible = False
        Label21.Visible = False
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
            Session("sdp2") = grd.SelectedRow.Cells(1).Text
            btnPreview_ConfirmButtonExtender.ConfirmText = "Are you sure you want to UPDATE this record?"
            Dim fsd As DataSet = GenTool.DataSetData("select * from frontpagemain where sysID=" & Val(Session("sdp2")))
            GenTool.resetform(Panel1, fsd)
            btnMove.Visible = True
            cboGroupName.Visible = True
            Label21.Visible = True

            Try
                txtFullMessage.Content = fsd.Tables(0).Rows(0).Item("FullMessage").ToString
            Catch ex As Exception
            End Try

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)
        End Try
    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        If IsPostBack = False Then
            filldb("")
            Session("sdp2") = ""
            cboGroupName.Items.Clear()
            cboGroupName.DataTextField = "groupname"
            cboGroupName.DataValueField = "sysID"
            cboGroupName.DataSource = GenTool.DataSetData("select sysID,groupname from photogallerygroup where Status=1 and GStatus=1").Tables(0)
            cboGroupName.DataBind()
            cboGroupName.Items.Insert(0, "Select Archive Group")
        End If

    End Sub
 
    Protected Sub btnMove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMove.Click
        Try
            If cboGroupName.SelectedIndex < 1 Then
                MessageBox.Show(Me, "You have not selected group where you archive the document")
                Return
            End If

            Dim sd As String = "Update frontpagemain Set gDesign=1,GroupID=" & Val(cboGroupName.SelectedValue) & " where sysID=" & Val(Session("sdp2"))

            If GenTool.ExecuteDatabase(sd) = True Then
                MessageBox.Show(Me, "Document Archived Successfully")
                filldb("")
                btnReset_Click(Nothing, Nothing)
            Else
                MessageBox.Show(Me, "Document Archiving failed")
            End If

        Catch ex As Exception
            GenTool.GrabError(ex.Message, Me.Title)
        End Try
    End Sub


End Class
