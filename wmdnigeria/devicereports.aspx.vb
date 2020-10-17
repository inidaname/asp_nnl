Imports System.Data

Partial Class devicereports
    Inherits System.Web.UI.Page

    Dim GenTool As NNLN = xsmsCentralToolx.SetTool

    Property dsSet As DataSet
        Get
            Return CType(Session("dsset1"), DataSet)
        End Get
        Set(ByVal value As DataSet)
            Session("dsset1") = value
        End Set
    End Property

    Private Sub filldb(ByVal grd1 As GridView, ByVal ds As DataSet)
        Try
            grd1.DataSource = ds.Tables(0)
            grd1.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub grd_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grd.PageIndexChanging
        grd.PageIndex = e.NewPageIndex
        filldb(grd, dsSet)
    End Sub

    Protected Sub cboFeegroup_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFeegroup.SelectedIndexChanged
        Try
            cboFeeSubGroup.Items.Clear()
            cboFeeSubGroup.DataValueField = "sysID"
            cboFeeSubGroup.DataTextField = "subheading"
            cboFeeSubGroup.DataSource = dsSubGroup.Tables(cboFeegroup.SelectedValue)
            cboFeeSubGroup.DataBind()
            cboFeeSubGroup.Items.Insert(0, "None")

            cboMrange.Items.Clear()
            cboMrange.Items.Insert(0, "None")
        Catch ex As Exception
            GenTool.GrabError(ex.Message, "cboFeegroup")
        End Try
    End Sub

    Protected Sub cboFeeSubGroup_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFeeSubGroup.SelectedIndexChanged
        Try
            cboMrange.Items.Clear()
            cboMrange.DataValueField = "sysID"
            cboMrange.DataTextField = "measureRange"
            cboMrange.DataSource = dsFeeTable.Tables(cboFeeSubGroup.SelectedValue)
            cboMrange.DataBind()
            cboMrange.Items.Insert(0, "None")

        Catch ex As Exception
            GenTool.GrabError(ex.Message, "cboFeeSubGroup")
        End Try
    End Sub

    Protected Sub cboMainGroup_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMainGroup.SelectedIndexChanged
        Try
            cboDeviceSub.Items.Clear()

            cboDeviceSub.DataValueField = "sysID"
            cboDeviceSub.DataTextField = "DeviceName"
            cboDeviceSub.DataSource = dsMainSubDevice.Tables(cboMainGroup.SelectedValue)
            cboDeviceSub.DataBind()
            cboDeviceSub.Items.Insert(0, "None")
        Catch ex As Exception
            GenTool.GrabError(ex.Message, "DeviceSub")
        End Try
    End Sub

    Private Sub getDviceStaticdata()
        If dsScaleGroup Is Nothing OrElse dsScaleGroup.Tables.Count < 1 OrElse dsScaleGroup.Tables(0).Rows.Count < 1 Then
            getScaleGroup()
        End If

        If dsSubGroup Is Nothing OrElse dsSubGroup.Tables.Count < 1 OrElse dsSubGroup.Tables(0).Rows.Count < 1 Then
            getsubGroup()
        End If

        If dsFeeTable Is Nothing OrElse dsFeeTable.Tables.Count < 1 OrElse dsFeeTable.Tables(0).Rows.Count < 1 Then
            getFeeTable()
        End If

        If dsMainDevice Is Nothing OrElse dsMainDevice.Tables.Count < 1 OrElse dsMainDevice.Tables(0).Rows.Count < 1 Then
            getMainDevice()
        End If

        If dsMainSubDevice Is Nothing OrElse dsMainSubDevice.Tables.Count < 1 OrElse dsMainSubDevice.Tables(0).Rows.Count < 1 Then
            getMainSubDevice()
        End If

        cboFeegroup.Items.Clear()
        cboFeegroup.DataTextField = "HeaderName"
        cboFeegroup.DataValueField = "sysID"
        cboFeegroup.DataSource = dsScaleGroup.Tables(0)
        cboFeegroup.DataBind()
        cboFeegroup.Items.Insert(0, "None")

        cboMainGroup.Items.Clear()
        cboMainGroup.DataTextField = "DeviceCategory"
        cboMainGroup.DataValueField = "sysID"
        cboMainGroup.DataSource = dsMainDevice.Tables(0)
        cboMainGroup.DataBind()
        cboMainGroup.Items.Insert(0, "None")

    End Sub

    Protected Sub btncancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncancel.Click
        GenTool.resetform(Panel2)
    End Sub

    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        Try
           

            Dim w As String = ""

            GenTool.getWhereSQL(Panel2, w, False)

            If w <> "" Then
                w = " AND " & w
            End If

            Dim Sql As String = "select sysID as ID,if((select DeviceType from maindevicesection where maindevicesection.sysID=typeOfDevice limit 1) is null,'Unknown',(select DeviceType from maindevicesection where maindevicesection.sysID=typeOfDevice limit 1)) as 'Instrument Type',actualMeasure as Capacity,modelNumber as Model,serialNumber as Serial,manufactureNumber as Manu_Number,deviceAmount as Amount,BarCode from deviceregistration " & _
                      " Where AccountID=" & Val(Session("ID")) & " " & w

            Dim ds As DataSet = GenTool.DataSetData(Sql)
            lblccount.Text = ds.Tables(0).Rows.Count & " Instrument(s)"
            filldb(grd, ds)
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init
        Try
            If IsPostBack = False Then getDviceStaticdata()
        Catch ex As Exception
        End Try
    End Sub

End Class
