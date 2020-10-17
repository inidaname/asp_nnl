
Partial Class amdsetupdeviceprice
    Inherits System.Web.UI.Page

    Dim GenTool As NNLN = xsmsCentralToolx.SetTool

    Protected Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init
        If IsPostBack = False Then
            Dim cDropDown = New dropDownFiller
            cDropDown.SQL = "select sysID,DeviceCategory from maindevice "
            cDropDown.ddlDown = cboCompany
            cDropDown.fieldname = "DeviceCategory"
            cDropDown.uniqueName = "sysID"
            GenTool.fillDropDownBox(cDropDown)

            cDropDown.SQL = "select sysID,DeviceCategory from maindevice "
            cDropDown.ddlDown = cboCompany1
            cDropDown.fieldname = "DeviceCategory"
            cDropDown.uniqueName = "sysID"
            GenTool.fillDropDownBox(cDropDown)

            Dim ins As String = Request("ins")
            Dim par As String = Request("par")

            If String.IsNullOrEmpty(ins) = False Then
                cboCompany.SelectedIndex = GenTool.getddlindexvalue1(cboCompany, ins)
                cboCompany_SelectedIndexChanged(Nothing, Nothing)
            End If

            If String.IsNullOrEmpty(par) = False Then
                cboParameters.SelectedIndex = GenTool.getddlindexvalue1(cboParameters, par)
                cboParameters_SelectedIndexChanged(Nothing, Nothing)
            End If

        End If
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

    Protected Sub cboParameters_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboParameters.SelectedIndexChanged
        Try
            Dim sql As String = "select maindevicesection.sysID as ID,DeviceType as InstrumentType,'" & cboCompany.SelectedItem.Text & "' as Sectors, '" & cboParameters.SelectedItem.Text & "' as Instruments,(Select count(sysID) from maindeviceprice where MainDeviceID=maindevicesection.sysID) as PriceHits,(Select count(sysID) from maindevicepriceadmeasure where MainDeviceID=maindevicesection.sysID) as MeasureHits from maindevicesection where mainsubdeviceID=" & Val(cboParameters.SelectedValue)
            grd.DataSource = GenTool.DataSetData(sql).Tables(0)
            grd.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub cboCompany_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboCompany.SelectedIndexChanged
        Try
            Dim cDropDown = New dropDownFiller
            cDropDown.SQL = "select sysID,DeviceName from mainsubdevice where GroupID=" & Val(cboCompany.SelectedValue)
            cDropDown.ddlDown = cboParameters
            cDropDown.fieldname = "DeviceName"
            cDropDown.uniqueName = "sysID"
            GenTool.fillDropDownBox(cDropDown)
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub cboCompany1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboCompany1.SelectedIndexChanged
       Try
            Dim sql As String = "select maindevicesection.sysID as ID,DeviceType as InstrumentType,mainsubdevice.DeviceName as Instrument from maindevicesection,mainsubdevice where mainsubdeviceID=mainsubdevice.sysID AND GroupID=" & Val(cboCompany1.SelectedValue)
            grd1.DataSource = GenTool.DataSetData(sql).Tables(0)
            grd1.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub grd_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles grd.SelectedIndexChanged
        Try
            If Val(grd.SelectedRow.Cells(5).Text) = 0 Then
                MessageBox.Show(Panel1, "You have not setup price for this intrument")
                Return
            End If

            lblActInstr.Text = grd.SelectedRow.Cells(2).Text
            txtID.Text = grd.SelectedRow.Cells(1).Text
            Label28.Visible = True
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnPreview0_Click(sender As Object, e As System.EventArgs) Handles btnPreview0.Click
        Try

    
        If Val(txtID.Text) = 0 Then
            MessageBox.Show(Panel1, "You have not selected Instrument type you want to replicate its record")
            Return
        End If

        Dim dbStore As New ArrayList
        Dim sql As String = ""

        For k As Integer = 0 To grd1.Rows.Count - 1

            Dim chk As CheckBox = CType(grd1.Rows(k).FindControl("chkChild"), CheckBox)

            If chk.Checked = True Then
                sql = "select MainDeviceID from maindeviceprice where MainDeviceID=" & Val(grd1.Rows(k).Cells(1).Text)
                If GenTool.HasRows(sql) = False Then
                    sql = "insert into maindeviceprice(MinValue1,MaxValue1,Amount,amt4First,amtAboveMaxValue,MainDeviceID,IsMaxValue,Value4Occurance ) select MinValue1,MaxValue1,Amount,amt4First,amtAboveMaxValue," & Val(grd1.Rows(k).Cells(1).Text) & ",IsMaxValue,Value4Occurance from maindeviceprice where MainDeviceID=" & Val(txtID.Text)
                    dbStore.Add(sql)
                End If

                sql = "select MainDeviceID from maindevicepriceadmeasure where MainDeviceID=" & Val(grd1.Rows(k).Cells(1).Text)
                If GenTool.HasRows(sql) = False Then
                    sql = "insert into maindevicepriceadmeasure(MainDeviceID,MeasureName,Status,MeasureValue,IsDefault) select " & Val(grd1.Rows(k).Cells(1).Text) & ",MeasureName,Status,MeasureValue,IsDefault from maindevicepriceadmeasure where MainDeviceID=" & Val(txtID.Text)
                    dbStore.Add(sql)
                End If

            End If
        Next

        If dbStore.Count < 1 Then
            MessageBox.Show(Panel1, "You have not selected any instrument type")
            Return
        End If

            If GenTool.ExecuteBulkSQL(dbStore) = True Then
                MessageBox.Show(Panel1, "Record saved successfully")
                btnPreview_Click(Nothing, Nothing)

            Else
                MessageBox.Show(Panel1, "Record save failed")
            End If


        Catch ex As Exception
            GenTool.GrabError("btnPreview0_Click-" & Me.Title.ToString, ex.Message)
        End Try

    End Sub

    Protected Sub btnPreview_Click(sender As Object, e As System.EventArgs) Handles btnPreview.Click
        lblActInstr.Text = ""
        txtID.Text = ""
        Label28.Visible = False
        cboCompany1.SelectedIndex = 0
        cboCompany1_SelectedIndexChanged(Nothing, Nothing)
    End Sub
End Class
