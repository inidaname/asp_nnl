Imports System.Data

Partial Class admdevicemgt
    Inherits System.Web.UI.Page

    Dim GenTool As NNLN = xsmsCentralToolx.SetTool

    Private Sub filldb(ByVal sql As String)
        Try


            Dim ds As DataSet = GenTool.DataSetData(sql)
            grd.DataSource = ds.Tables(0)
            grd.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub grd_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grd.PageIndexChanging
        grd.PageIndex = e.NewPageIndex
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim w As String = ""
        w = "select sysID as SN,companyName,streetAddress,modelNumber,serialNumber,DATE_FORMAT(RegDate, '%Y-%m-%d') as Date,CertificateNo,DATE_FORMAT(certDateIssed, '%Y-%m-%d') as DateIssued,if(ApplyForVerificationCert=0,'No','Yes') as 'Initial Verification',if(ApplyForCertificate=0,'No','Yes') as 'Pattern Approval' from deviceregistration "

        If optBoth.Checked = True Then
            w &= " where ApplyForCertificate=0 Or ApplyForVerificationCert=0 "

        ElseIf optApprovalP.Checked = True Then
            w &= " where ApplyForCertificate=0"
        Else
            w &= " where  ApplyForVerificationCert=0 "
        End If
        filldb(w)
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

    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim msgText As String = ""

        Try
            Dim sql As String = ""

            If optApprovalP.Checked = True Then
                If txtCerticateNo.Text.Trim = "" Then
                    msgText = "Invalid certificate number"
                    Return
                Else
                    sql = " CertificateNo=" & GenTool.addbackslash(txtCerticateNo.Text)
                End If

                If IsDate(txtDateIssued.Text) = False Then
                    msgText = "Invalid date issued"
                    Return
                Else
                    If String.IsNullOrEmpty(sql) = False Then
                        sql &= ",certDateIssed=" & GenTool.addbackslash(txtDateIssued.Text)
                    End If

                End If

            End If

            If optInitial.Checked = True Then
                If txtCerticateNo0.Text.Trim = "" Then
                    msgText = "Invalid certificate number"
                    Return
                Else
                    sql = " CertificateNoVerification=" & GenTool.addbackslash(txtCerticateNo0.Text)
                End If

                If IsDate(txtDateIssued0.Text) = False Then
                    msgText = "Invalid date issued"
                    Return
                Else
                    If String.IsNullOrEmpty(sql) = False Then
                        sql &= ",VerificationcertDateIssed=" & GenTool.addbackslash(txtDateIssued0.Text)
                    End If

                End If

            End If

            If optInitial.Checked = False AndAlso optApprovalP.Checked = False Then
                msgText = "To make update, you must choose either choose Approval Pertern Or Initial Verification"
                Return
            End If

            If txtID.Text = "" Then
                msgText = "Please select record you want to update from the grid"
                Return
            End If

            sql = "update deviceregistration set " & sql & " where sysID=" & Val(txtID.Text)
            If GenTool.ExecuteDatabase(sql) = True Then
                msgText = "Record saved successfully"
                btnSearch_Click(Nothing, Nothing)
                txtCerticateNo.Text = ""
                txtDateIssued.Text = ""
                txtID.Text = ""
            Else
                msgText = "Record saved failed,please try again"
            End If

        Catch ex As Exception
            GenTool.GrabError(ex.Message, "btnUpdate_Click")
            msgText = "System error"
        Finally
            If msgText <> "" Then
                MessageBox.Show(Me, msgText)
            End If
        End Try

    End Sub

    Protected Sub grd_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grd.SelectedIndexChanged
        Try
            txtID.Text = grd.SelectedRow.Cells(1).Text.ToString
        Catch ex As Exception
        End Try

    End Sub



    Private Sub makeVisible(ByVal Iret1 As Boolean, ByVal iret2 As Boolean)
        If Iret1 = True Then

            lblCerticateNo.Visible = Iret1
            txtCerticateNo.Visible = Iret1
            lblDateIssued.Visible = Iret1
            txtDateIssued.Visible = Iret1
            childimgbtnCal0.Visible = Iret1
            txtDateIssued.Visible = Iret1

            lblCerticateNo0.Visible = iret2
            txtCerticateNo0.Visible = iret2
            lblDateIssued0.Visible = iret2
            txtDateIssued0.Visible = iret2
            childimgbtnCal1.Visible = iret2

            btnUpdate.Visible = True

        ElseIf iret2 = True Then

            lblCerticateNo0.Visible = iret2
            txtCerticateNo0.Visible = iret2
            lblDateIssued0.Visible = iret2
            txtDateIssued0.Visible = iret2
            childimgbtnCal1.Visible = iret2

            lblCerticateNo.Visible = Iret1
            txtCerticateNo.Visible = Iret1
            lblDateIssued.Visible = Iret1
            txtDateIssued.Visible = Iret1
            childimgbtnCal0.Visible = Iret1

            btnUpdate.Visible = True
        Else
            lblCerticateNo.Visible = False
            txtCerticateNo.Visible = False
            lblDateIssued.Visible = False
            txtDateIssued.Visible = False
            childimgbtnCal0.Visible = False

            lblCerticateNo0.Visible = False
            txtCerticateNo0.Visible = False
            lblDateIssued0.Visible = False
            txtDateIssued0.Visible = False
            childimgbtnCal1.Visible = False

            btnUpdate.Visible = False

        End If

    End Sub

    Protected Sub optInitial_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles optInitial.CheckedChanged
        If optInitial.Checked = True Then makeVisible(False, optInitial.Checked)
    End Sub

    Protected Sub optBoth_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles optBoth.CheckedChanged
        If optBoth.Checked = True Then makeVisible(False, False)
    End Sub

    Protected Sub optApprovalP_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles optApprovalP.CheckedChanged
        If optApprovalP.Checked = True Then makeVisible(optApprovalP.Checked, False)
    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If IsPostBack = False Then
            makeVisible(False, False)
        End If
    End Sub
End Class
