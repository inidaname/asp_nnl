Imports System.Data

Partial Class admstaticdata
    Inherits System.Web.UI.Page

    Dim GenTool As NNLN = xsmsCentralToolx.SetTool

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Try
            If IsPostBack = False Then

                Dim regType As String = Request("pg")
                If Val(regType) < TabContainer1.Tabs.Count Then
                    TabContainer1.ActiveTabIndex = Val(regType)
                    TabContainer1.TabIndex = Val(regType)
                    TabContainer1_ActiveTabChanged(Nothing, Nothing)
                End If
            End If

        Catch ex As Exception
        End Try
    End Sub

    'Dim getStatic As New StaticTemplate

    Property getStatic As StaticTemplate
        Get
            Return CType(Session("dataValue"), StaticTemplate)
        End Get
        Set(ByVal value As StaticTemplate)
            Session("dataValue") = value
        End Set
    End Property

    Private Sub filldb(ByVal grd As GridView, ByVal SQL As String)
        If grd Is Nothing Then Return
        Dim ds As DataSet = GenTool.DataSetData(SQL)

        Try
            grd.DataSource = ds.Tables(0)
            grd.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub imgBtnState_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnState.Click
        Try

            If dllSetupDate.SelectedIndex = 0 Then
                AllStaticDate()
            ElseIf dllSetupDate.SelectedIndex = 1 Then
                FeeGroup()

            ElseIf dllSetupDate.SelectedIndex = 2 Then
                SetupFrontpage()

            ElseIf dllSetupDate.SelectedIndex = 3 Then
                GetDeviceSection()
            ElseIf dllSetupDate.SelectedIndex = 4 Then
                SetupAddress()
            End If
            MessageBox.Show(Me, "Process was successfull")

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub TabContainer1_ActiveTabChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabContainer1.ActiveTabChanged

        If TabContainer1.ActiveTabIndex = 0 Then

            filldb(grdstate, "select sysID as ID,StateName from tblstate")
            lblStateTotalRecords.Text = "Total record(s) : " & GenTool.getSingleValue("select count(sysID) from tblstate")

        ElseIf TabContainer1.ActiveTabIndex = 1 Then

            cboLGA.DataTextField = "stateName"
            cboLGA.DataValueField = "sysID"
            cboLGA.DataSource = GenTool.DataSetData("select StateName,sysID from tblstate").Tables(0)
            cboLGA.DataBind()
            cboLGA.Items.Insert(0, "Select State")

        ElseIf TabContainer1.ActiveTabIndex = 2 Then

            filldb(grdCity, "select sysID as ID,City from tblcity")
            lblCityTotalRecords.Text = "Total record(s) : " & GenTool.getSingleValue("select count(sysID) from tblcity")

        ElseIf TabContainer1.ActiveTabIndex = 3 Then

            filldb(grdcountry, "select sysID as ID,Country from tblcountry")
            lblCountryTotalRecords.Text = "Total record(s) : " & GenTool.getSingleValue("select count(sysID) from tblcountry")

        ElseIf TabContainer1.ActiveTabIndex = 4 Then

            filldb(grdFeeMainR, "select sysID as ID,HeaderName as 'Fee Group Name',IsService from feegroup")
            lblTotalFeeMain.Text = "Total record(s) : " & GenTool.getSingleValue("select count(sysID) from feegroup")

        ElseIf TabContainer1.ActiveTabIndex = 5 Then

            cboMainFee.DataTextField = "HeaderName"
            cboMainFee.DataValueField = "sysID"
            cboMainFee.DataSource = GenTool.DataSetData("select sysID,HeaderName from feegroup").Tables(0)
            cboMainFee.DataBind()
            cboMainFee.Items.Insert(0, "Select Fee Group")

        ElseIf TabContainer1.ActiveTabIndex = 6 Then

            cboFEEGROUP.DataTextField = "HeaderName"
            cboFEEGROUP.DataValueField = "sysID"
            cboFEEGROUP.DataSource = GenTool.DataSetData("select sysID,HeaderName from feegroup").Tables(0)
            cboFEEGROUP.DataBind()
            cboFEEGROUP.Items.Insert(0, "Select Fee Group")

        ElseIf TabContainer1.ActiveTabIndex = 7 Then

            filldb(grdMD, " select sysID as ID,DeviceCategory as 'Instrument Main Name' from maindevice ")
            lblTotalMDR.Text = "Total record(s) : " & GenTool.getSingleValue("select count(sysID) from maindevice")

        ElseIf TabContainer1.ActiveTabIndex = 8 Then

            cboDevice.DataTextField = "DeviceCategory"
            cboDevice.DataValueField = "sysID"
            cboDevice.DataSource = GenTool.DataSetData("select sysID,DeviceCategory from maindevice").Tables(0)
            cboDevice.DataBind()
            cboDevice.Items.Insert(0, "Select Instrument Group")

        End If

    End Sub

#Region "City"

    Protected Sub btnCityR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCityR.Click
        btnCityS_ConfirmButtonExtender.ConfirmText = "Are you SURE you want to SAVE this record?"
        btnCityD.Visible = False
        txtCityID.Text = ""
        txtCity.Text = ""
        btnCityS.Text = "SAVE"
    End Sub

    Protected Sub btnCityS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCityS.Click
        Dim msgText As String = ""
        Try
            If txtCity.Text = "" Then
                MessageBox.Show(UpdatePanel1, "Invalid City")
                Return
            End If

            Dim sql As String = ""

            If txtCityID.Text = "" Then
                msgText = "Record saved successfully"
                sql = "insert into tblcity(city) value (" & GenTool.addbackslash(txtCity.Text) & ")"
            Else
                sql = "Update tblcity SET city=" & GenTool.addbackslash(txtCity.Text) & " where sysID=" & Val(txtCityID.Text)
                msgText = "Record updated successfully"
            End If

            If GenTool.ExecuteDatabase(sql) = True Then

                If txtCityID.Text = "" Then
                    GenTool.FormHistory("City :  " & txtCity.Text & " was created", Request.UserHostAddress, Val(Session("sysID")))
                Else
                    GenTool.FormHistory("City :  " & txtCity.Text & " was updated", Request.UserHostAddress, Val(Session("sysID")))
                End If

                TabContainer1_ActiveTabChanged(Nothing, Nothing)
                btnCityR_Click(Nothing, Nothing)
            Else
                msgText = "Your account cannot be updated at the moment,please try again later"
            End If

        Catch ex As Exception
            msgText = "Your account cannot be updated at the moment,please try again later"
            GenTool.GrabError(ex.Message, "btnCityS_Click")
        Finally
            lblMsg.Text = msgText
            If msgText <> "" Then
                MessageBox.Show(Me, msgText)
            End If
        End Try
    End Sub

    Protected Sub btnCityD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCityD.Click
        Dim msgText As String = ""
        Try
            Dim sql As String

            Dim sql1 As String = "select count(sysID) from companyregistration where cityID=" & Val(txtCityID.Text)
            sql = "select count(sysID) from deviceregistration where cityID=" & Val(txtCityID.Text)

            Dim cc As String = GenTool.getSingleValue(sql)

            If Val(cc) > 0 Then
                msgText = cc & " record(s) is/are linked to this state in company registration"
                Return
            End If

            cc = Val(GenTool.getSingleValue(sql1))

            If Val(cc) > 0 Then
                msgText = cc & " record(s) is/are linked to this state in devuce registration"
                Return
            End If

            sql = "Delete from tblcity where sysID=" & Val(txtCityID.Text)

            If GenTool.ExecuteDatabase(sql) = True Then

                GenTool.FormHistory("City : " & txtCity.Text & " was deleted", Request.UserHostAddress, Val(Session("sysID")))

                TabContainer1_ActiveTabChanged(Nothing, Nothing)
                btnCityD.Visible = False
                txtCityID.Text = ""
                btnCityS.Text = "SAVE"
                btnCityS_ConfirmButtonExtender.ConfirmText = "Are you SURE you want to SAVE this record?"
                msgText = "Record deleted successfully"
            Else
                msgText = "Record deleted faled"
            End If

        Catch ex As Exception
            msgText = "Your account cannot be updated at the moment,please try again later"
            GenTool.GrabError(ex.Message, "btnCityD_Click")
        Finally
            lblMsg.Text = msgText
            If msgText <> "" Then
                MessageBox.Show(UpdatePanel1, msgText)
            End If
        End Try
    End Sub

    Protected Sub grdCity_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdCity.PageIndexChanging

        grdCity.PageIndex = e.NewPageIndex
        filldb(grdCity, "select sysID as ID,city from tblcity")
    End Sub

    Protected Sub grdCity_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdCity.SelectedIndexChanged
        Try

            txtCityID.Text = grdCity.SelectedRow.Cells(1).Text
            txtCity.Text = grdCity.SelectedRow.Cells(2).Text
            btnCityS_ConfirmButtonExtender.ConfirmText = "Are you SURE you want to UPDATE this record?"
            btnCityD.Visible = True
            btnCityS.Text = "UPDATE"

        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region "State"

    Protected Sub grdstate_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdstate.PageIndexChanging
        grdstate.PageIndex = e.NewPageIndex
        filldb(grdstate, "select sysID as ID,StateName from tblstate")
    End Sub

    Protected Sub grdstate_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdstate.SelectedIndexChanged
        Try
            txtStateID.Text = grdstate.SelectedRow.Cells(1).Text
            txtState.Text = grdstate.SelectedRow.Cells(2).Text
            btnStateS_ConfirmButtonExtender.ConfirmText = "Are you SURE you want to UPDATE this record?"
            btnStateD.Visible = True
            btnStateS.Text = "UPDATE"

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnStateR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnStateR.Click
        btnStateS_ConfirmButtonExtender.ConfirmText = "Are you SURE you want to SAVE this record?"
        btnStateD.Visible = False
        txtStateID.Text = ""
        txtState.Text = ""
        btnStateS.Text = "SAVE"

    End Sub

    Protected Sub btnStateS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnStateS.Click
        Dim msgText As String = ""
        Try
            If txtState.Text = "" Then
                MessageBox.Show(UpdatePanel1, "Invalid state")
                Return
            End If

            Dim sql As String = ""

            If txtStateID.Text = "" Then
                msgText = "Record saved successfully"
                sql = "insert into tblstate(stateName) value (" & GenTool.addbackslash(txtState.Text) & ")"
            Else
                sql = "Update tblstate SET stateName=" & GenTool.addbackslash(txtState.Text) & " where sysID=" & Val(txtStateID.Text)
                msgText = "Record updated successfully"
            End If

            If GenTool.ExecuteDatabase(sql) = True Then

                If txtStateID.Text = "" Then
                    GenTool.FormHistory("State :  " & txtState.Text & " was created", Request.UserHostAddress, Val(Session("sysID")))
                Else
                    GenTool.FormHistory("State :  " & txtState.Text & " was updated", Request.UserHostAddress, Val(Session("sysID")))
                End If

                TabContainer1_ActiveTabChanged(Nothing, Nothing)
                btnStateR_Click(Nothing, Nothing)
            Else
                msgText = "Your account cannot be updated at the moment,please try again later"
            End If

        Catch ex As Exception
            msgText = "Your account cannot be updated at the moment,please try again later"
            GenTool.GrabError(ex.Message, "btnStateS_Click")
        Finally
            lblMsg.Text = msgText
            If msgText <> "" Then
                MessageBox.Show(Me, msgText)
            End If
        End Try
    End Sub

    Protected Sub btnStateD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnStateD.Click
        Dim msgText As String = ""
        Try
            Dim sql As String

            Dim sql1 As String = "select count(sysID) from companyregistration where StateID=" & Val(txtStateID.Text)
            sql = "select count(sysID) from deviceregistration where StateID=" & Val(txtStateID.Text)

            Dim cc As String = GenTool.getSingleValue(sql)

            If Val(cc) > 0 Then
                msgText = cc & " record(s) is/are linked to this state in company registration"
                Return
            End If

            cc = Val(GenTool.getSingleValue(sql1))

            If Val(cc) > 0 Then
                msgText = cc & " record(s) is/are linked to this state in Instrument registration"
                Return
            End If

            sql = "Delete from tblstate where sysID=" & Val(txtStateID.Text)

            If GenTool.ExecuteDatabase(sql) = True Then

                GenTool.FormHistory("State :  " & txtState.Text & " was deleted", Request.UserHostAddress, Val(Session("sysID")))

                TabContainer1_ActiveTabChanged(Nothing, Nothing)
                btnStateD.Visible = False
                txtStateID.Text = ""
                btnStateD.Text = "SAVE"
                btnStateS_ConfirmButtonExtender.ConfirmText = "Are you SURE you want to SAVE this record?"
                msgText = "Record deleted successfully"
            Else
                msgText = "Record deleted faled"
            End If

        Catch ex As Exception
            msgText = "Your account cannot be updated at the moment,please try again later"
            GenTool.GrabError(ex.Message, "btnStateD_Click")
        Finally
            lblMsg.Text = msgText
            If msgText <> "" Then
                MessageBox.Show(UpdatePanel1, msgText)
            End If
        End Try
    End Sub

#End Region

#Region "Country"

    Protected Sub btnCountryD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCountryD.Click
        Dim msgText As String = ""
        Try
            Dim sql As String

            sql = "select sysID from exportuc where countryID=" & Val(txtCountryID.Text)

            Dim cc As String = GenTool.getSingleValue(sql)

            If Val(cc) > 0 Then
                msgText = cc & " record(s) is/are linked to this state in export permit registration"
                Return
            End If

            sql = "Delete from tblcountry where sysID=" & Val(txtCountryID.Text)

            If GenTool.ExecuteDatabase(sql) = True Then

                GenTool.FormHistory("Country :  " & txtCountry.Text & " was deleted", Request.UserHostAddress, Val(Session("sysID")))

                TabContainer1_ActiveTabChanged(Nothing, Nothing)
                btnCountryD.Visible = False
                txtCountryID.Text = ""
                btnCountryD.Text = "SAVE"
                btnCountryS_ConfirmButtonExtender.ConfirmText = "Are you SURE you want to SAVE this record?"
                msgText = "Record deleted successfully"

            Else
                msgText = "Record deleted faled"
            End If

        Catch ex As Exception
            msgText = "Your account cannot be updated at the moment,please try again later"
            GenTool.GrabError(ex.Message, "btnCountryD_Click")
        Finally
            lblMsg.Text = msgText
            If msgText <> "" Then
                MessageBox.Show(UpdatePanel1, msgText)
            End If
        End Try
    End Sub

    Protected Sub btnCountryS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCountryS.Click
        Dim msgText As String = ""
        Try
            If txtCountry.Text = "" Then
                MessageBox.Show(UpdatePanel1, "Invalid Country")
                Return
            End If

            Dim sql As String = ""

            If txtCountryID.Text = "" Then
                msgText = "Record saved successfully"
                sql = "insert into tblcountry(country) value (" & GenTool.addbackslash(txtCountry.Text) & ")"
            Else
                sql = "Update tblcountry SET country=" & GenTool.addbackslash(txtCountry.Text) & " where sysID=" & Val(txtCountryID.Text)
                msgText = "Record updated successfully"
            End If

            If GenTool.ExecuteDatabase(sql) = True Then

                If txtCountryID.Text = "" Then
                    GenTool.FormHistory("Country :  " & txtCountry.Text & " was created", Request.UserHostAddress, Val(Session("sysID")))
                Else
                    GenTool.FormHistory("Country :  " & txtCountry.Text & " was updated", Request.UserHostAddress, Val(Session("sysID")))
                End If

                TabContainer1_ActiveTabChanged(Nothing, Nothing)
                btnCountryR_Click(Nothing, Nothing)

            Else
                msgText = "Your account cannot be updated at the moment,please try again later"
            End If

        Catch ex As Exception
            msgText = "Your account cannot be updated at the moment,please try again later"
            GenTool.GrabError(ex.Message, "btnStateS_Click")
        Finally
            lblMsg.Text = msgText
            If msgText <> "" Then
                MessageBox.Show(Me, msgText)
            End If
        End Try
    End Sub

    Protected Sub btnCountryR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCountryR.Click
        btnCountryS_ConfirmButtonExtender.ConfirmText = "Are you SURE you want to SAVE this record?"
        btnCountryD.Visible = False
        txtCountryID.Text = ""
        txtCountry.Text = ""
        btnCountryS.Text = "SAVE"
    End Sub

    Protected Sub grdcountry_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdcountry.PageIndexChanging
        grdcountry.PageIndex = e.NewPageIndex
        filldb(grdcountry, "select sysID as ID,country from tblcountry")
    End Sub

    Protected Sub grdcountry_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdcountry.SelectedIndexChanged
        Try
            txtCountryID.Text = grdcountry.SelectedRow.Cells(1).Text
            txtCountry.Text = grdcountry.SelectedRow.Cells(2).Text
            btnCountryS_ConfirmButtonExtender.ConfirmText = "Are you SURE you want to UPDATE this record?"
            btnCountryD.Visible = True
            btnCountryS.Text = "UPDATE"

        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region "FEE MAIN GROUP"

    Protected Sub btnFeeMainR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFeeMainR.Click
        btnFeeMainS_ConfirmButtonExtender.ConfirmText = "Are you SURE you want to SAVE this record?"
        btnFeeMainD.Visible = False
        txtfeemainID.Text = ""
        txtFeeMain.Text = ""
        btnFeeMainS.Text = "SAVE"
    End Sub

    Protected Sub btnFeeMainS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFeeMainS.Click
        Dim msgText As String = ""
        Try
            If txtFeeMain.Text = "" Then
                MessageBox.Show(UpdatePanel1, "Invalid Entry")
                Return
            End If

            Dim sql As String = ""

            If txtfeemainID.Text = "" Then
                msgText = "Record saved successfully"
                sql = "insert into feegroup(HeaderName,IsService) value (" & GenTool.addbackslash(txtFeeMain.Text) & "," & IIf(chkFeeGroupService.Checked = True, 1, 0) & ")"
            Else
                sql = "Update feegroup SET HeaderName=" & GenTool.addbackslash(txtFeeMain.Text) & ",IsService=" & IIf(chkFeeGroupService.Checked = True, 1, 0) & " where sysID=" & Val(txtfeemainID.Text)
                msgText = "Record updated successfully"
            End If

            If GenTool.ExecuteDatabase(sql) = True Then

                If txtfeemainID.Text = "" Then
                    GenTool.FormHistory("FEE Group :  " & txtFeeMain.Text & " was created", Request.UserHostAddress, Val(Session("sysID")))
                Else
                    GenTool.FormHistory("FEE Group :  " & txtFeeMain.Text & " was updated", Request.UserHostAddress, Val(Session("sysID")))
                End If

                TabContainer1_ActiveTabChanged(Nothing, Nothing)
                btnFeeMainR_Click(Nothing, Nothing)

            Else
                msgText = "Your account cannot be updated at the moment,please try again later"
            End If

        Catch ex As Exception
            msgText = "Your account cannot be updated at the moment,please try again later"
            GenTool.GrabError(ex.Message, "btnStateS_Click")
        Finally
            lblMsg.Text = msgText
            If msgText <> "" Then
                MessageBox.Show(Me, msgText)
            End If
        End Try
    End Sub

    Protected Sub btnFeeMainD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFeeMainD.Click
        Dim msgText As String = ""
        Try
            Dim sql As String

            sql = "select sysID from deviceregistration where DeviceGroupID=" & Val(txtfeemainID.Text)

            Dim cc As String = GenTool.getSingleValue(sql)

            If Val(cc) > 0 Then
                msgText = cc & " record(s) is/are linked to this record"
                Return
            End If

            sql = "Delete from feegroup where sysID=" & Val(txtfeemainID.Text)

            If GenTool.ExecuteDatabase(sql) = True Then

                GenTool.FormHistory("FEE MAIN GROUP :  " & txtFeeMain.Text & " was deleted", Request.UserHostAddress, Val(Session("sysID")))

                TabContainer1_ActiveTabChanged(Nothing, Nothing)
                btnFeeMainD.Visible = False
                txtfeemainID.Text = ""
                btnFeeMainS.Text = "SAVE"
                btnFeeMainS_ConfirmButtonExtender.ConfirmText = "Are you SURE you want to SAVE this record?"
                msgText = "Record deleted successfully"

            Else
                msgText = "Record deleted faled"
            End If

        Catch ex As Exception
            msgText = "Your account cannot be updated at the moment,please try again later"
            GenTool.GrabError(ex.Message, "btnCountryD_Click")
        Finally
            lblMsg.Text = msgText
            If msgText <> "" Then
                MessageBox.Show(UpdatePanel1, msgText)
            End If
        End Try
    End Sub

    Protected Sub grdFeeMainR_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdFeeMainR.PageIndexChanging
        grdFeeMainR.PageIndex = e.NewPageIndex
        filldb(grdFeeMainR, "select sysID,HeaderName as 'Fee Group Name' from feegroup")
    End Sub


    Private Sub grdFeeMainR_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdFeeMainR.RowCreated
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                e.Row.Attributes("onmouseover") = "this.style.cursor='pointer';this.style.textDecoration='none';"
                e.Row.Attributes("onmouseout") = "this.style.textDecoration='none';"
                e.Row.ToolTip = "Click to select row"
                e.Row.Attributes("onclick") = Me.Page.ClientScript.GetPostBackClientHyperlink(Me.grdFeeMainR, "Select$" & e.Row.RowIndex)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub grdFeeMainR_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdFeeMainR.SelectedIndexChanged
        Try
            txtfeemainID.Text = grdFeeMainR.SelectedRow.Cells(1).Text
            txtFeeMain.Text = grdFeeMainR.SelectedRow.Cells(2).Text
            chkFeeGroupService.Checked = IIf(Val(grdFeeMainR.SelectedRow.Cells(3).Text) = 0, False, True)

            btnFeeMainS_ConfirmButtonExtender.ConfirmText = "Are you SURE you want to UPDATE this record?"
            btnFeeMainD.Visible = True
            btnFeeMainS.Text = "UPDATE"

        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region "Main Instrument Group"

    Protected Sub btnMDR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMDR.Click
        btnMDS_ConfirmButtonExtender.ConfirmText = "Are you SURE you want to SAVE this record?"
        btnMDD.Visible = False
        txtMDID.Text = ""
        txtMD.Text = ""
        btnMDS.Text = "SAVE"
    End Sub

    Protected Sub btnMDS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMDS.Click
        Dim msgText As String = ""
        Try
            If txtMD.Text = "" Then
                MessageBox.Show(UpdatePanel1, "Invalid Entry")
                Return
            End If

            Dim sql As String = ""

            If txtMDID.Text = "" Then
                msgText = "Record saved successfully"
                sql = "insert into maindevice(DeviceCategory) value (" & GenTool.addbackslash(txtMD.Text) & ")"
            Else
                sql = "Update maindevice SET DeviceCategory=" & GenTool.addbackslash(txtMD.Text) & " where sysID=" & Val(txtMDID.Text)
                msgText = "Record updated successfully"
            End If

            If GenTool.ExecuteDatabase(sql) = True Then

                If txtfeemainID.Text = "" Then
                    GenTool.FormHistory("Instrument Group :  " & txtMD.Text & " was created", Request.UserHostAddress, Val(Session("sysID")))
                Else
                    GenTool.FormHistory("Instrument Group :  " & txtMD.Text & " was updated", Request.UserHostAddress, Val(Session("sysID")))
                End If

                TabContainer1_ActiveTabChanged(Nothing, Nothing)
                btnMDR_Click(Nothing, Nothing)

            Else
                msgText = "Your account cannot be updated at the moment,please try again later"
            End If

        Catch ex As Exception
            msgText = "Your account cannot be updated at the moment,please try again later"
            GenTool.GrabError(ex.Message, "btnMDS_Click")
        Finally
            lblMsg.Text = msgText
            If msgText <> "" Then
                MessageBox.Show(Me, msgText)
            End If
        End Try
    End Sub

    Protected Sub btnMDD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMDD.Click
        Dim msgText As String = ""
        Try
            Dim sql As String

            sql = "select sysID from deviceregistration where DeviceGroupID=" & Val(txtMDID.Text)

            Dim cc As String = GenTool.getSingleValue(sql)

            If Val(cc) > 0 Then
                msgText = cc & " record(s) is/are linked to this record"
                Return
            End If

            sql = "Delete from maindevice where sysID=" & Val(txtMDID.Text)

            If GenTool.ExecuteDatabase(sql) = True Then

                GenTool.FormHistory("Instrument GROUP :  " & txtMD.Text & " was deleted", Request.UserHostAddress, Val(Session("sysID")))

                TabContainer1_ActiveTabChanged(Nothing, Nothing)

                btnMDD.Visible = False
                txtMDID.Text = ""
                btnMDS.Text = "SAVE"
                btnMDS_ConfirmButtonExtender.ConfirmText = "Are you SURE you want to SAVE this record?"
                msgText = "Record deleted successfully"

            Else
                msgText = "Record deleted faled"
            End If

        Catch ex As Exception
            msgText = "Your account cannot be updated at the moment,please try again later"
            GenTool.GrabError(ex.Message, "btnMDD_Click")
        Finally
            lblMsg.Text = msgText
            If msgText <> "" Then
                MessageBox.Show(UpdatePanel1, msgText)
            End If
        End Try
    End Sub

    Protected Sub grdMD_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdMD.PageIndexChanging
        grdMD.PageIndex = e.NewPageIndex
        filldb(grdMD, "select sysID as ID,DeviceCategory as 'Instrument Name' from maindevice")
    End Sub

    Protected Sub grdMD_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdMD.SelectedIndexChanged
        Try
            txtMDID.Text = grdMD.SelectedRow.Cells(1).Text
            txtMD.Text = grdMD.SelectedRow.Cells(2).Text
            btnMDS_ConfirmButtonExtender.ConfirmText = "Are you SURE you want to UPDATE this record?"
            btnMDD.Visible = True
            btnMDS.Text = "UPDATE"

        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region "LGA"

    Protected Sub cboLGA_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLGA.SelectedIndexChanged
        filldb(grdLGA, "select tbllga.sysID as ID,LGA,StateName from tbllga,tblstate where tblstate.sysID=tbllga.stateID AND tbllga.stateID=" & Val(cboLGA.SelectedValue))
        lblLGA.Text = "Total record(s) : " & GenTool.getSingleValue("select count(sysID) from tbllga where stateID=" & Val(cboLGA.SelectedValue))

        'txtLGAID.Text = ""
        'txtLGA.Text = ""

    End Sub

    Protected Sub btnLGAR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLGAR.Click
        btnLGAS_ConfirmButtonExtender.ConfirmText = "Are you SURE you want to SAVE this record?"
        btnLGAD.Visible = False
        txtLGAID.Text = ""
        txtLGA.Text = ""
        btnLGAS.Text = "SAVE"
    End Sub

    Protected Sub btnLGAS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLGAS.Click
        Dim msgText As String = ""
        Try
            If txtLGA.Text = "" Then
                MessageBox.Show(UpdatePanel1, "Invalid Entry")
                Return
            End If

            Dim sql As String = ""

            If txtLGAID.Text = "" Then
                msgText = "Record saved successfully"
                sql = "insert into tbllga(LGA,stateID) value (" & GenTool.addbackslash(txtLGA.Text) & "," & Val(cboLGA.SelectedValue) & ")"
            Else
                sql = "Update tbllga SET LGA=" & GenTool.addbackslash(txtLGA.Text) & ",stateID=" & Val(cboLGA.SelectedValue) & " where sysID=" & Val(txtLGAID.Text)
                msgText = "Record updated successfully"
            End If

            If GenTool.ExecuteDatabase(sql) = True Then

                If txtfeemainID.Text = "" Then
                    GenTool.FormHistory("LGA :  " & txtLGA.Text & " was created", Request.UserHostAddress, Val(Session("sysID")))
                Else
                    GenTool.FormHistory("LGA :  " & txtLGA.Text & " was updated", Request.UserHostAddress, Val(Session("sysID")))
                End If

                Dim cd As Int32 = cboLGA.SelectedIndex

                'TabContainer1_ActiveTabChanged(Nothing, Nothing)
                btnLGAR_Click(Nothing, Nothing)

                cboLGA.SelectedIndex = cd

                cboLGA_SelectedIndexChanged(Nothing, Nothing)

            Else
                msgText = "Your account cannot be updated at the moment,please try again later"
            End If

        Catch ex As Exception
            msgText = "Your account cannot be updated at the moment,please try again later"
            GenTool.GrabError(ex.Message, "btnLGAS_Click")
        Finally
            lblMsg.Text = msgText
            If msgText <> "" Then
                MessageBox.Show(Me, msgText)
            End If
        End Try
    End Sub

    Protected Sub btnLGAD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLGAD.Click
        Dim msgText As String = ""
        Try
            Dim sql As String

            Dim sql1 As String = "select count(sysID) from companyregistration where LGAID=" & Val(txtLGAID.Text)
            sql = "select count(sysID) from deviceregistration where LGAID=" & Val(txtLGAID.Text)

            Dim cc As String = GenTool.getSingleValue(sql)

            If Val(cc) > 0 Then
                msgText = cc & " record(s) is/are linked to this state in company registration"
                Return
            End If

            cc = Val(GenTool.getSingleValue(sql1))

            If Val(cc) > 0 Then
                msgText = cc & " record(s) is/are linked to this state in Instrument registration"
                Return
            End If

            sql = "Delete from tbllga where sysID=" & Val(txtLGAID.Text)

            If GenTool.ExecuteDatabase(sql) = True Then

                GenTool.FormHistory("LGA :  " & txtLGA.Text & " was deleted", Request.UserHostAddress, Val(Session("sysID")))

                btnLGAD.Visible = False
                txtLGAID.Text = ""
                btnLGAS.Text = "SAVE"
                btnLGAS_ConfirmButtonExtender.ConfirmText = "Are you SURE you want to SAVE this record?"
                msgText = "Record deleted successfully"

                Dim cd As Int32 = cboLGA.SelectedIndex

                'TabContainer1_ActiveTabChanged(Nothing, Nothing)
                btnLGAR_Click(Nothing, Nothing)

                cboLGA.SelectedIndex = cd

                cboLGA_SelectedIndexChanged(Nothing, Nothing)

            Else
                msgText = "Record deleted faled"
            End If

        Catch ex As Exception
            msgText = "Your account cannot be updated at the moment,please try again later"
            GenTool.GrabError(ex.Message, "btnMDD_Click")
        Finally
            lblMsg.Text = msgText
            If msgText <> "" Then
                MessageBox.Show(UpdatePanel1, msgText)
            End If
        End Try
    End Sub

    Protected Sub grdLGA_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdLGA.PageIndexChanging
        grdLGA.PageIndex = e.NewPageIndex
        filldb(grdLGA, "select tbllga.sysID as ID,LGA,StateName from tbllga,tblstate where tblstate.sysID=tbllga.stateID AND tbllga.stateID=" & Val(cboLGA.SelectedValue))
    End Sub

    Protected Sub grdLGA_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdLGA.SelectedIndexChanged
        Try
            txtLGAID.Text = grdLGA.SelectedRow.Cells(1).Text
            txtLGA.Text = grdLGA.SelectedRow.Cells(2).Text
            cboLGA.SelectedIndex = GenTool.getddlindexvalue(cboLGA, grdLGA.SelectedRow.Cells(3).Text)
            btnLGAS_ConfirmButtonExtender.ConfirmText = "Are you SURE you want to UPDATE this record?"
            btnLGAD.Visible = True
            btnLGAS.Text = "UPDATE"

        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region "Fee Sub Group"

    Protected Sub cboMainFee_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMainFee.SelectedIndexChanged

        filldb(grdFSS, "select feesubgroup.sysID as ID,subheading as 'Instrument Sub Group',HeaderName as 'Instrument Group' from feesubgroup,feegroup  where feesubgroup.feegroupID=feegroup.sysID AND feesubgroup.feegroupID=" & Val(cboMainFee.SelectedValue))
        lblfsstotal.Text = "Total record(s) : " & GenTool.getSingleValue("select count(sysID) from feesubgroup where feegroupID=" & Val(cboMainFee.SelectedValue))

    End Sub

    Protected Sub grdFSS_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdFSS.PageIndexChanging
        grdFSS.PageIndex = e.NewPageIndex

        filldb(grdFSS, "select mainsubdevice.sysID as ID,DeviceName as 'Instrument Sub Group',DeviceCategory as 'Main Group' from mainsubdevice,maindevice " & _
                       " where mainsubdevice.GroupID=maindevice.sysID AND mainsubdevice.GroupID=" & Val(cboMainFee.SelectedValue))
    End Sub

    Protected Sub grdFSS_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdFSS.SelectedIndexChanged
        Try
            txtFSSID.Text = grdFSS.SelectedRow.Cells(1).Text
            txtFSS.Text = grdFSS.SelectedRow.Cells(2).Text
            cboMainFee.SelectedIndex = GenTool.getddlindexvalue(cboMainFee, grdFSS.SelectedRow.Cells(3).Text)
            btnFSSS_ConfirmButtonExtender.ConfirmText = "Are you SURE you want to UPDATE this record?"
            btnFSD.Visible = True
            btnFSSS.Text = "UPDATE"

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnFSR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFSR.Click
        btnFSSS_ConfirmButtonExtender.ConfirmText = "Are you SURE you want to SAVE this record?"
        btnFSD.Visible = False
        txtFSSID.Text = ""
        txtFSS.Text = ""
        btnFSSS.Text = "SAVE"
    End Sub

    Protected Sub btnFSD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFSD.Click
        Dim msgText As String = ""
        Try
            Dim sql As String

            sql = "select count(sysID) from deviceregistration where feegroupID=" & Val(txtFSSID.Text)

            Dim cc As String = GenTool.getSingleValue(sql)

            If Val(cc) > 0 Then
                msgText = cc & " record(s) is/are linked to this record in Instrument registration"
                Return
            End If

            sql = "Delete from feesubgroup where sysID=" & Val(txtFSSID.Text)

            If GenTool.ExecuteDatabase(sql) = True Then

                GenTool.FormHistory("FEE SUB GROUP :  " & txtFSS.Text & " was deleted", Request.UserHostAddress, Val(Session("sysID")))


                btnFSD.Visible = False
                txtFSSID.Text = ""
                txtFSS.Text = ""
                btnFSSS.Text = "SAVE"
                btnFSSS_ConfirmButtonExtender.ConfirmText = "Are you SURE you want to SAVE this record?"
                msgText = "Record deleted successfully"

                Dim cd As Int32 = cboMainFee.SelectedIndex

                'TabContainer1_ActiveTabChanged(Nothing, Nothing)
                btnFSR_Click(Nothing, Nothing)

                cboMainFee.SelectedIndex = cd
                cboMainFee_SelectedIndexChanged(Nothing, Nothing)

            Else
                msgText = "Record deleted faled"
            End If

        Catch ex As Exception
            msgText = "Your account cannot be updated at the moment,please try again later"
            GenTool.GrabError(ex.Message, "btnFSD_Click")
        Finally
            lblMsg.Text = msgText
            If msgText <> "" Then
                MessageBox.Show(UpdatePanel1, msgText)
            End If
        End Try
    End Sub

    Protected Sub btnFSSS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFSSS.Click
        Dim msgText As String = ""
        Try
            If txtFSS.Text = "" Then
                MessageBox.Show(UpdatePanel1, "Invalid Entry")
                Return
            End If

            Dim sql As String = ""

            If txtFSSID.Text = "" Then
                msgText = "Record saved successfully"
                sql = "insert into feesubgroup(subheading,feegroupID) value (" & GenTool.addbackslash(txtFSS.Text) & "," & Val(cboMainFee.SelectedValue) & ")"
            Else
                sql = "Update feesubgroup SET subheading=" & GenTool.addbackslash(txtFSS.Text) & ",feegroupID=" & Val(cboMainFee.SelectedValue) & " where sysID=" & Val(txtFSSID.Text)
                msgText = "Record updated successfully"
            End If

            If GenTool.ExecuteDatabase(sql) = True Then

                If txtFSSID.Text = "" Then
                    GenTool.FormHistory("FEE SUB Group :  " & txtFSS.Text & " was created", Request.UserHostAddress, Val(Session("sysID")))
                Else
                    GenTool.FormHistory("FEE SUB Group :  " & txtFSS.Text & " was updated", Request.UserHostAddress, Val(Session("sysID")))
                End If

                Dim cd As Int32 = cboMainFee.SelectedIndex

                'TabContainer1_ActiveTabChanged(Nothing, Nothing)
                btnFSR_Click(Nothing, Nothing)

                cboMainFee.SelectedIndex = cd
                cboMainFee_SelectedIndexChanged(Nothing, Nothing)

            Else
                msgText = "Your account cannot be updated at the moment,please try again later"
            End If

        Catch ex As Exception
            msgText = "Your account cannot be updated at the moment,please try again later"
            GenTool.GrabError(ex.Message, "btnStateS_Click")
        Finally
            lblMsg.Text = msgText
            If msgText <> "" Then
                MessageBox.Show(Me, msgText)
            End If
        End Try
    End Sub

#End Region

#Region "Instrument Management"

    Protected Sub btnDeviceD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeviceD.Click
        Dim msgText As String = ""
        Try
            Dim sql As String

            sql = "select count(sysID) from deviceregistration where SubDeviceID=" & Val(txtDeviceID.Text)

            Dim cc As String = GenTool.getSingleValue(sql)

            If Val(cc) > 0 Then
                msgText = cc & " record(s) is/are linked to this record in Instrument registration"
                Return
            End If

            sql = "Delete from mainsubdevice where sysID=" & Val(txtDeviceID.Text)

            If GenTool.ExecuteDatabase(sql) = True Then


                GenTool.FormHistory("INSTRUMENT SUB GROUP :  " & txtDevice.Text & " was deleted", Request.UserHostAddress, Val(Session("sysID")))


                btnDeviceD.Visible = False
                txtDeviceID.Text = ""
                txtDevice.Text = ""
                btnDeviceS.Text = "SAVE"
                btnDeviceS_ConfirmButtonExtender.ConfirmText = "Are you SURE you want to SAVE this record?"
                msgText = "Record deleted successfully"

                Dim cd As Int32 = cboDevice.SelectedIndex

                'TabContainer1_ActiveTabChanged(Nothing, Nothing)
                btnDeviceR_Click(Nothing, Nothing)

                cboDevice.SelectedIndex = cd
                cboDevice_SelectedIndexChanged(Nothing, Nothing)

            Else
                msgText = "Record deleted faled"
            End If

        Catch ex As Exception
            msgText = "Your account cannot be updated at the moment,please try again later"
            GenTool.GrabError(ex.Message, "btnDeviceD_Click")
        Finally
            lblMsg.Text = msgText
            If msgText <> "" Then
                MessageBox.Show(UpdatePanel1, msgText)
            End If
        End Try
    End Sub

    Protected Sub btnDeviceS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeviceS.Click
        Dim msgText As String = ""
        Try
            If txtDevice.Text = "" Then
                MessageBox.Show(UpdatePanel1, "Invalid Entry")
                Return
            End If

            Dim sql As String = ""

            If txtDeviceID.Text = "" Then
                msgText = "Record saved successfully"
                sql = "insert into mainsubdevice(DeviceName,GroupID) value (" & GenTool.addbackslash(txtDevice.Text) & "," & Val(cboDevice.SelectedValue) & ")"
            Else
                sql = "Update mainsubdevice SET DeviceName=" & GenTool.addbackslash(txtDevice.Text) & " where sysID=" & Val(txtDeviceID.Text)
                msgText = "Record updated successfully"
            End If

            If GenTool.ExecuteDatabase(sql) = True Then

                If txtDeviceID.Text = "" Then
                    GenTool.FormHistory("INSTRUMENT CATEGORY :  " & txtDevice.Text & " was created", Request.UserHostAddress, Val(Session("sysID")))
                Else
                    GenTool.FormHistory("INSTRUMENT CATEGORY :  " & txtDevice.Text & " was updated", Request.UserHostAddress, Val(Session("sysID")))
                End If


                Dim cd As Int32 = cboDevice.SelectedIndex

                'TabContainer1_ActiveTabChanged(Nothing, Nothing)
                btnDeviceR_Click(Nothing, Nothing)

                cboDevice.SelectedIndex = cd
                cboDevice_SelectedIndexChanged(Nothing, Nothing)

            Else
                msgText = "Your account cannot be updated at the moment,please try again later"
            End If

        Catch ex As Exception
            msgText = "Your account cannot be updated at the moment,please try again later"
            GenTool.GrabError(ex.Message, "btnDeviceS_Click")
        Finally
            lblMsg.Text = msgText
            If msgText <> "" Then
                MessageBox.Show(Me, msgText)
            End If
        End Try
    End Sub

    Protected Sub btnDeviceR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeviceR.Click
        btnDeviceS_ConfirmButtonExtender.ConfirmText = "Are you SURE you want to SAVE this record?"
        btnDeviceD.Visible = False
        txtDeviceID.Text = ""
        txtDevice.Text = ""
        btnDeviceS.Text = "SAVE"
    End Sub

    Protected Sub grdDevice_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdDevice.PageIndexChanging
        grdDevice.PageIndex = e.NewPageIndex
        filldb(grdDevice, "select mainsubdevice.sysID as ID,DeviceName as 'Instrument Category',DeviceCategory as 'Group Name' from mainsubdevice,maindevice where mainsubdevice.GroupID=maindevice.sysID AND GroupID=" & Val(cboDevice.SelectedValue))
    End Sub

    Protected Sub grdDevice_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDevice.SelectedIndexChanged
        Try
            txtDeviceID.Text = grdDevice.SelectedRow.Cells(1).Text
            txtDevice.Text = grdDevice.SelectedRow.Cells(2).Text
            cboDevice.SelectedIndex = GenTool.getddlindexvalue(cboDevice, grdDevice.SelectedRow.Cells(3).Text)
            btnDeviceS_ConfirmButtonExtender.ConfirmText = "Are you SURE you want to UPDATE this record?"
            btnDeviceD.Visible = True
            btnDeviceS.Text = "UPDATE"

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub cboDevice_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDevice.SelectedIndexChanged
        filldb(grdDevice, "select mainsubdevice.sysID as ID,DeviceName as 'Instrument Category',DeviceCategory as 'Group Name' from mainsubdevice,maindevice where mainsubdevice.GroupID=maindevice.sysID AND GroupID=" & Val(cboDevice.SelectedValue))
        lblDeviceCat.Text = "Total record(s) : " & GenTool.getSingleValue("select count(sysID) from mainsubdevice where GroupID=" & Val(cboDevice.SelectedValue))
    End Sub
#End Region


#Region "FEETABLE"
    Protected Sub cboFEEGROUP_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFEEGROUP.SelectedIndexChanged
        cboFEESUBGROUP.DataTextField = "subheading"
        cboFEESUBGROUP.DataValueField = "sysID"
        cboFEESUBGROUP.DataSource = GenTool.DataSetData("select sysID,subheading from feesubgroup where feegroupID=" & Val(cboFEEGROUP.SelectedValue)).Tables(0)
        cboFEESUBGROUP.DataBind()
        cboFEESUBGROUP.Items.Insert(0, "Select Fee Sub Group")
    End Sub

    Protected Sub cboFEESUBGROUP_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFEESUBGROUP.SelectedIndexChanged
        Dim sd As String = "select feetable.sysID as ID,measureRange as 'Fee Name',amount,charges,renewal,securityDeposit as Sec_Deposit,calibrationFee as calibr_Fee from feetable,feesubgroup,feegroup " & _
            " where feetable.feeGroupID=feegroup.sysID AND feetable.feeSubGroupID=feesubgroup.sysID  AND feetable.feeGroupID=" & _
         Val(cboFEEGROUP.SelectedValue) & " AND feetable.feeSubGroupID=" & Val(cboFEESUBGROUP.SelectedValue)

        filldb(grdFee, sd)

        lblFeeTotalResult.Text = "Total record(s) : " & GenTool.getSingleValue("select count(sysID) from feetable where feetable.feeGroupID=" & _
         Val(cboFEEGROUP.SelectedValue) & " AND feetable.feeSubGroupID=" & Val(cboFEESUBGROUP.SelectedValue))

    End Sub

    Protected Sub btnFEED_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFEED.Click
        Dim msgText As String = ""
        Try
            Dim sql As String

            sql = "Delete from feetable where sysID=" & Val(txtFeeID.Text)

            If GenTool.ExecuteDatabase(sql) = True Then

                GenTool.FormHistory("FEE NAME :  " & txtFee.Text & " was deleted", Request.UserHostAddress, Val(Session("sysID")))

                cboFEESUBGROUP_SelectedIndexChanged(Nothing, Nothing)

                btnFEES.Visible = False
                txtFeeID.Text = ""
                btnFEES.Text = "SAVE"
                btnFEES_ConfirmButtonExtender.ConfirmText = "Are you SURE you want to SAVE this record?"
                msgText = "Record deleted successfully"

            Else
                msgText = "Record deleted faled"
            End If

        Catch ex As Exception
            msgText = "Your account cannot be updated at the moment,please try again later"
            GenTool.GrabError(ex.Message, "btnFEED_Click")
        Finally
            lblMsg.Text = msgText
            If msgText <> "" Then
                MessageBox.Show(UpdatePanel1, msgText)
            End If
        End Try
    End Sub

    Protected Sub btnFEES_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFEES.Click
        Dim msgText As String = ""
        Try
            If txtFee.Text = "" Then
                MessageBox.Show(UpdatePanel1, "Invalid Entry")
                Return
            End If

            Dim sql As String = ""

            If txtFeeID.Text = "" Then
                msgText = "Record saved successfully"
                sql = "INSERT INTO feetable (measureRange,amount,charges,renewal,securityDeposit,calibrationFee,feeSubGroupID,feeGroupID) Values (" & GenTool.addbackslash(txtFee.Text) & _
                    "," & Val(txtFeeAmount.Text) & "," & Val(txtfeecharges.Text) & "," & Val(txtFeeRenewal.Text) & "," & Val(txtFEESD.Text) & "," & Val(txtFEECalibrFee.Text) & _
                    "," & Val(cboFEESUBGROUP.SelectedValue) & "," & Val(cboFEEGROUP.SelectedValue) & ")"

            Else

                sql = "Update feetable SET measureRange=" & GenTool.addbackslash(txtFee.Text) & ",feeSubGroupID=" & Val(cboFEESUBGROUP.SelectedValue) & _
                    ",feeGroupID=" & Val(cboFEEGROUP.SelectedValue) & ",amount=" & Val(txtFeeAmount.Text) & ",charges=" & Val(txtfeecharges.Text) & _
                    ",renewal=" & Val(txtFeeRenewal.Text) & ",securityDeposit=" & Val(txtFEESD.Text) & ",calibrationFee=" & Val(txtFEECalibrFee.Text) & _
                    " where sysID=" & Val(txtFeeID.Text)

                msgText = "Record updated successfully"

            End If

            If GenTool.ExecuteDatabase(sql) = True Then

                If txtFeeID.Text = "" Then
                    GenTool.FormHistory("FEE NAME :  " & txtFee.Text & " was created", Request.UserHostAddress, Val(Session("sysID")))
                Else
                    GenTool.FormHistory("FEE NAME :  " & txtFee.Text & " was updated", Request.UserHostAddress, Val(Session("sysID")))
                End If

                btnFEER_Click(Nothing, Nothing)
                cboFEESUBGROUP_SelectedIndexChanged(Nothing, Nothing)

            Else
                msgText = "Your account cannot be updated at the moment,please try again later"
            End If

        Catch ex As Exception
            msgText = "Your account cannot be updated at the moment,please try again later"
            GenTool.GrabError(ex.Message, "btnFEES_Click")
        Finally
            lblMsg.Text = msgText
            If msgText <> "" Then
                MessageBox.Show(Me, msgText)
            End If
        End Try
    End Sub

    Protected Sub btnFEER_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFEER.Click

        btnFEES_ConfirmButtonExtender.ConfirmText = "Are you SURE you want to SAVE this record?"
        btnFEED.Visible = False
        txtFeeID.Text = ""
        txtFee.Text = ""
        btnFEES.Text = "SAVE"

        txtFeeAmount.Text = ""
        txtfeecharges.Text = ""
        txtFeeRenewal.Text = ""
        txtFEESD.Text = ""
        txtFEECalibrFee.Text = ""

    End Sub

    Protected Sub grdFee_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdFee.PageIndexChanging
        grdFee.PageIndex = e.NewPageIndex

        Dim sd As String = "select feetable.sysID as ID,measureRange as 'Fee Name',amount,charges,renewal,securityDeposit as Sec_Deposit,calibrationFee as calibr_Fee from feetable,feesubgroup,feegroup " & _
          " where feetable.feeGroupID=feegroup.sysID AND feetable.feeSubGroupID=feesubgroup.sysID  AND feetable.feeGroupID=" & _
       Val(cboFEEGROUP.SelectedValue) & " AND feetable.feeSubGroupID=" & Val(cboFEESUBGROUP.SelectedValue)

        filldb(grdFee, sd)

    End Sub

    Protected Sub grdFee_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdFee.SelectedIndexChanged
        Try
            txtFeeID.Text = grdFee.SelectedRow.Cells(1).Text
            txtFee.Text = grdFee.SelectedRow.Cells(2).Text

            txtFeeAmount.Text = grdFee.SelectedRow.Cells(3).Text
            txtfeecharges.Text = grdFee.SelectedRow.Cells(4).Text
            txtFeeRenewal.Text = grdFee.SelectedRow.Cells(5).Text
            txtFEESD.Text = grdFee.SelectedRow.Cells(6).Text
            txtFEECalibrFee.Text = grdFee.SelectedRow.Cells(7).Text

            btnFEES_ConfirmButtonExtender.ConfirmText = "Are you SURE you want to UPDATE this record?"
            btnFEED.Visible = True
            btnFEES.Text = "UPDATE"

            Dim sd As String = "select HeaderName,feesubgroup.subheading from feegroup,feesubgroup,feetable where feegroup.sysID=feetable.feeGroupID AND feesubgroup.sysID=feetable.feeSubGroupID AND feetable.sysID=" & Val(grdFee.SelectedRow.Cells(1).Text)
            Dim ds As DataSet = GenTool.DataSetData(sd)

            If ds IsNot Nothing AndAlso ds.Tables.Count > 0 And ds.Tables(0).Rows.Count > 0 Then
                With ds.Tables(0).Rows(0)
                    cboFEEGROUP.SelectedIndex = GenTool.getddlindexvalue(cboFEEGROUP, .Item(0))
                    cboFEEGROUP_SelectedIndexChanged(Nothing, Nothing)

                    cboFEESUBGROUP.SelectedIndex = GenTool.getddlindexvalue(cboFEESUBGROUP, .Item(1))
                End With
                ds.Dispose()
            End If

        Catch ex As Exception
        End Try
    End Sub

#End Region


End Class
