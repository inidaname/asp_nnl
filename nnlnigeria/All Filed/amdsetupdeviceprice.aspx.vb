
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
            Dim sql As String = "select maindevicesection.sysID,DeviceType as InstrumentType,'" & cboCompany.SelectedItem.Text & "' as Sectors, '" & cboParameters.SelectedItem.Text & "' as Instruments,(Select count(sysID) from maindeviceprice where MainDeviceID=maindevicesection.sysID) as PriceHits,(Select count(sysID) from maindevicepriceadmeasure where MainDeviceID=maindevicesection.sysID) as MeasureHits from maindevicesection where mainsubdeviceID=" & Val(cboParameters.SelectedValue)
            grd.DataSource = GenTool.DataSetData(sql).Tables(0)
            grd.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub cboCompany_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboCompany.SelectedIndexChanged
        Try
            Dim cDropDown = New dropDownFiller
            cDropDown.SQL = "select sysID,DeviceName from mainsubdevice where GroupID=" & Val(cboCompany.SelectedValue) & " Order by DeviceName asc"
            cDropDown.ddlDown = cboParameters
            cDropDown.fieldname = "DeviceName"
            cDropDown.uniqueName = "sysID"
            GenTool.fillDropDownBox(cDropDown)
        Catch ex As Exception
        End Try
    End Sub
 
    Protected Sub grd_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles grd.SelectedIndexChanged
        Try
            Dim hreq As String = "?did=" & grd.SelectedRow.Cells(1).Text & "&ins=" & GenTool.Convert2PercentageFormat(cboCompany.SelectedItem.Text) & "&par=" & GenTool.Convert2PercentageFormat(cboParameters.SelectedItem.Text) & "&instype=" & grd.SelectedRow.Cells(2).Text
            Response.Redirect("amdsetuprice.aspx" & hreq)
        Catch ex As Exception
        End Try
    End Sub

 
End Class
