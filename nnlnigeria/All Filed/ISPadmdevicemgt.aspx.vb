Imports System.Data

Partial Class ISPadmdevicemgt
    Inherits System.Web.UI.Page

    Dim GenTool As NNLN = xsmsCentralToolx.SetTool

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TabPanel1.Visible = False

        If IsPostBack = False Then
            Dim ds As DataSet = GenTool.DataSetData("select companyregistration.sysID,companyName from companyregistration,allocatedterminals where companyregistration.sysiD=allocatedterminals.CompID AND ISPID=" & Val(Session("sysid")))
            Session("ispCompID") = ""

            Try
                If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then

                    cboCompany.DataValueField = "sysID"
                    cboCompany.DataTextField = "companyName"
                    cboCompany.DataSource = ds.Tables(0)
                    cboCompany.DataBind()

                End If

            Catch ex As Exception
            Finally
                cboCompany.Items.Insert(0, "Select Company")
            End Try
        End If
    End Sub

    Protected Sub cboCompany_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCompany.SelectedIndexChanged
        Try

            Dim Sql As String = "select sysID as ID,typeOfDevice as 'Instrument Type',actualMeasure as Capacity,modelNumber as Model,serialNumber as Serial,manufactureNumber as Manu_Number,deviceAmount as Amount,BarCode,TransCode from deviceregistration " & _
                " Where AccountID=" & Val(cboCompany.SelectedValue.Split("|").ToArray(0))

            Dim ds As DataSet = GenTool.DataSetData(Sql)

            filldb(grd, ds)

            clearME()

            lblccount.Text = ds.Tables(0).Rows.Count & " Instrument(s)"
        Catch ex As Exception
        End Try
    End Sub


    Private Sub filldb(ByVal grd1 As GridView, ByVal ds As DataSet)
        Try
            grd1.DataSource = ds.Tables(0)
            grd1.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub grd_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grd.PageIndexChanging
        grd.PageIndex = e.NewPageIndex
    End Sub

    Protected Sub grd_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grd.SelectedIndexChanged
        Try
            Dim sql As String = "select PaymentName,AmountDue,AmountPaid,OrderId,Narration,Date_Format(RegDate,'%D-%M-%Y') as Date ,DATE_FORMAT(RegTime, '%h:%i:%S %p') as Time  from paymentsheet where companyID=" & _
                 Val(cboCompany.SelectedValue.Split("|").ToArray(0)) & " AND TransCode=" & GenTool.addbackslash(grd.SelectedRow.Cells(9).Text)

            txtDeviceID.Text = grd.SelectedRow.Cells(1).Text
            txtDeviceIDVS.Text = grd.SelectedRow.Cells(1).Text
            txtDeviceISVUSer.Text = Session("sysID")


            Dim ds As DataSet = GenTool.DataSetData(sql)
            filldb(grdinvioce, ds)

            populate()

        Catch ex As Exception
        End Try
    End Sub

    Private Sub populate()
        Dim Sql As String = "select sysID as ID,StandardMeasure,VerifiedMeasure,StandardMeasure-VerifiedMeasure as ErrorMeasure,MeasureType,Date_Format(RegDate,'%D-%M-%Y') as Date ,DATE_FORMAT(RegTime, '%h:%i:%S %p') as Time,comments,DeviceCurrentState as InstrumentTag from devicetestsheet where DeviceID=" & Val(txtDeviceID.Text)
        Dim ds As DataSet = GenTool.DataSetData(Sql)
        filldb(grdvsheet, ds)
    End Sub

    Sub clearME()
        Dim sql As String = "select PaymentName,AmountDue,AmountPaid,OrderId,Narration,Date_Format(RegDate,'%D-%M-%Y') as Date ,DATE_FORMAT(RegTime, '%h:%i:%S %p') as Time  from paymentsheet where companyID=-9"
        Dim ds As DataSet = GenTool.DataSetData(sql)
        filldb(grdinvioce, ds)

        sql = "select sysID as ID,StandardMeasure,VerifiedMeasure,StandardMeasure-VerifiedMeasure as ErrorMeasure,MeasureType,RegDate,RegTime,comments from devicetestsheet where DeviceID=" & Val(txtDeviceID.Text)
        ds = GenTool.DataSetData(sql)
        filldb(grdvsheet, ds)

    End Sub

    Dim FN As String = ""
    Dim FV As String = ""
    Dim FUpdate As String = ""

    Protected Sub btnsheet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsheet.Click
        Dim msg As String = ""

        Try
            msg = GenTool.checkControl(pnlVerificationSheet, FN, FV, FUpdate)
            Dim sql As String = ""

            If msg = "" Then

                If btnsheet.Text = "Save Record" Then
                    sql = "Insert into devicetestsheet(" & FN & ") Values (" & FV & " )"
                Else
                    sql = "Update devicetestsheet SET " & FUpdate & " where sysID=" & Val(grdvsheet.SelectedRow.Cells(1).Text)
                End If

                If GenTool.ExecuteDatabase(sql) = True Then
                    GenTool.FormHistory("Verification Test Sheet Modified", Request.UserHostAddress, Val(Session("sysid")), 0)
                    msg = "Record saved successfully"
                    populate()
                    btnResetVS_Click(Nothing, Nothing)
                Else
                    msg = "Record save failed,please again"
                End If

            End If

        Catch ex As Exception
            GenTool.GrabError(ex.Message, "btnsheet_Click")
            msg = "error occured,please contact the admin if it continues"
        Finally
            If msg <> "" Then
                MessageBox.Show(UpdatePanel1, msg)
            End If
        End Try
    End Sub

    Protected Sub grdvsheet_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdvsheet.PageIndexChanging
        grdvsheet.PageIndex = e.NewPageIndex
    End Sub

    Protected Sub grdvsheet_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdvsheet.SelectedIndexChanged
        Dim sql As String = ""
        sql = "select * from devicetestsheet where sysid=" & Val(grdvsheet.SelectedRow.Cells(1).Text)
        Dim ds As DataSet = GenTool.DataSetData(sql)

        GenTool.resetform(pnlVerificationSheet, ds)
        btnsheet.Text = "Update Record"
        btnVSHDelete.Visible = True

    End Sub

    Protected Sub btnResetVS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnResetVS.Click
        GenTool.resetform(pnlVerificationSheet)
        btnsheet.Text = "Save Record"
        btnVSHDelete.Visible = True
    End Sub

    Protected Sub grdinvioce_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdinvioce.PageIndexChanging
        grdinvioce.PageIndex = e.NewPageIndex
    End Sub

    Protected Sub btnVSHDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVSHDelete.Click
        Dim msgText As String = ""

        Try
            Dim sql As String = ""
            sql = "delete from devicetestsheet where sysid=" & Val(grdvsheet.SelectedRow.Cells(1).Text)
            If GenTool.ExecuteDatabase(sql) = True Then
                msgText = "Record saved successfully"
                btnVSHDelete.Visible = False
                GenTool.FormHistory("Verification Deleted", Request.UserHostAddress, Val(Session("sysid")), 0)
            Else
                msgText = "Record save failed"
            End If

        Catch ex As Exception
            GenTool.GrabError(ex.Message, "btnVSHDelete_Click")
        Finally
            If msgText <> "" Then MessageBox.Show(UpdatePanel1, msgText)
        End Try
    End Sub

    Protected Sub btnNewInstruments_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNewInstruments.Click
        If cboCompany.SelectedIndex > 0 Then
            Session("ispCompID") = cboCompany.SelectedValue.Split("|").ToArray(0)
            Response.Redirect("ISPregisterdevice.aspx?pg=1")
        Else
            MessageBox.Show(UpdatePanel1, "Please select a company")
        End If

    End Sub
End Class
