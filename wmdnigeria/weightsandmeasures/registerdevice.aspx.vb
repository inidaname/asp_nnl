Imports System.Data

Partial Class registerdevice
    Inherits System.Web.UI.Page

    Dim dsFillCompany As New DataSet
 
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Try
            txtAccountID.Text = Session("ID")
 
            chkUseCompany.Text = "Tick Here If The Instrument In This Location Belong To ' " & Session("cname") & "'"

            If IsPostBack = False Then

                getDviceStaticdata()
                cboDeviceSub.Items.Insert(0, "Select Instrument Category")
                getCompanyStaticData()
                cboTypeOfDevice.Items.Add("Select Value")

                filldb("")

            End If


        Catch ex As Exception
            GenTool.GrabError(ex.Message, "regdevice")
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

        If dsDeviceType Is Nothing OrElse dsDeviceType.Tables.Count < 1 OrElse dsDeviceType.Tables(0).Rows.Count < 1 Then
            getDeviceType()
        End If

        Try
            cboFeegroup.Items.Clear()
            cboFeegroup.DataTextField = "HeaderName"
            cboFeegroup.DataValueField = "sysID"
            cboFeegroup.DataSource = GenTool.DataSetData("select ucase(HeaderName) as HeaderName,sysID from feegroup where recordStatus=0 AND IsService=0 ").Tables(0)
            cboFeegroup.DataBind()
        Catch ex As Exception
        End Try

        cboFeegroup.Items.Insert(0, "Select Type Of Fees")

        cboMainGroup.Items.Clear()
        cboMainGroup.DataTextField = "DeviceCategory"
        cboMainGroup.DataValueField = "sysID"
        cboMainGroup.DataSource = dsMainDevice.Tables(0)
        cboMainGroup.DataBind()
        cboMainGroup.Items.Insert(0, "Select Sector of the Economy")

    End Sub

    Private Sub getCompanyStaticData()
        If dsCity Is Nothing OrElse dsCity.Tables.Count < 1 OrElse dsCity.Tables(0).Rows.Count < 1 Then
            getCity()
        End If


        cboCity.DataValueField = "sysID"
        cboCity.DataTextField = "city"
        cboCity.DataSource = dsCity.Tables(0)
        cboCity.DataBind()
        cboCity.Items.Insert(0, "Select City")

        If dsState Is Nothing OrElse dsState.Tables.Count < 1 OrElse dsState.Tables(0).Rows.Count < 1 Then
            getState()
        End If
        cboState.DataTextField = "stateName"
        cboState.DataValueField = "sysID"
        cboState.DataSource = dsState.Tables(0)
        cboState.DataBind()
        cboState.Items.Insert(0, "Select State")

        If dsLGAState Is Nothing OrElse dsLGAState.Tables.Count < 1 OrElse dsLGAState.Tables(0).Rows.Count < 1 Then
            getLGA()
        End If

        Try
            cboLGA.DataTextField = "LGA"
            cboLGA.DataValueField = "sysID"
            cboLGA.DataSource = dsLGAState.Tables(cboState.Text)
            cboLGA.DataBind()
            cboLGA.Items.Insert(0, "Select LGA")
        Catch ex As Exception
        End Try

        If dsFillCompany Is Nothing OrElse dsFillCompany.Tables.Count < 1 OrElse dsFillCompany.Tables(0).Rows.Count < 1 Then
            dsFillCompany = GenTool.getFillCompany(Session("ID"))
        End If

    End Sub

    Protected Sub chkUseCompany_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkUseCompany.CheckedChanged

        If chkUseCompany.Checked = True Then
            Panel1.Visible = False
        Else
            Panel1.Visible = True
        End If

    End Sub

    Protected Sub cboState_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboState.SelectedIndexChanged
        Try
            cboLGA.Items.Clear()

            cboLGA.DataValueField = "sysID"
            cboLGA.DataTextField = "LGA"
            cboLGA.DataSource = dsLGAState.Tables(cboState.SelectedItem.Text)
            cboLGA.DataBind()
            cboLGA.Items.Insert(0, "Select LGA")
        Catch ex As Exception
            GenTool.GrabError(ex.Message, "cboState")
        End Try
    End Sub

    Dim GenTool As NNLN = xsmsCentralToolx.SetTool

    Private Sub filldb(ByVal w As String)
        Dim ds As DataSet = GenTool.DataSetData("select sysID as ID,(select DeviceType from maindevicesection where sysID=deviceregistration.TypeOfDevice) as 'Instrument Type',actualMeasure as Capacity,modelNumber as Model,serialNumber as Serial,manufactureNumber as Manu_Number,'0.00' as Fee,feeID as FID,BarCode,date_format(regDate,'%D-%M-%Y') as TransDate from deviceregistration where IsdbService=0 AND AccountID=" & Val(Session("ID")) & " " & w)
        Try
            Dim fPaid As String = GenTool.getSingleValue("select sum(deviceAmount) from deviceregistration where vStatus=1 AND AccountID=" & Val(Session("ID")) & " " & w)

            grd.DataSource = ds.Tables(0)
            grd.DataBind()
            lblTotal.Text = "Amount Due : " & Val(GenTool.getSummation(grd, 7) - Val(fPaid)).ToString("N#,#.00")

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        Try
            saveData()
            filldb("")
        Catch ex As Exception
        End Try
    End Sub

    Dim FN As String = ""
    Dim FV As String = ""
    Dim FUpdate As String = ""

    Private Sub saveData()
        Dim msgtext As String = ""

        FUpdate = ""
        FV = ""
        FN = ""
        lblMsg.Text = ""

        Try
            txtAccountID.Text = Session("ID")
            
            If String.IsNullOrEmpty(Session("DeviceID")) = True Then

                txtTransCode.Text = GenTool.GenerateRNDCode(True, True) & GenTool.GenerateUniqueCode
Reapeat:        txtBarCode.Text = Strings.Left(GenTool.GenerateUniqueCode & GenTool.GenerateRNDCode, 8)
                If GenTool.HasRows("SELECT barCode from deviceregistration where barCode=" & GenTool.addbackslash(txtBarCode.Text)) = True Then GoTo Reapeat

            End If


            If IsDate(txtDateIssued.Text) = False Then
                txtDateIssued.Text = "0000-00-00"
            End If

            If IsDate(txtVerDate.Text) = False Then
                txtVerDate.Text = "0000-00-00"
            End If

            If chkUseCompany.Checked = True Then
                msgtext = GenTool.checkControl(Panel2, FN, FV, FUpdate)
                If msgtext <> "" Then Return
            Else
                msgtext = GenTool.checkControl(Panel1, FN, FV, FUpdate)
                If msgtext <> "" Then Return

                msgtext = GenTool.checkControl(Panel2, FN, FV, FUpdate)
                If msgtext <> "" Then Return
            End If

            If RadioButton3.Checked = False AndAlso RadioButton2.Checked = False AndAlso RadioButton1.Checked = False AndAlso RadioButton4.Checked = False Then
                msgtext = "At least one certificate option must be selected"
                Return
            End If

            If RadioButton1.Checked = True Then
                If String.IsNullOrEmpty(txtCerticateNo.Text) = True Then
                    msgtext = "Please enter certificate number"
                    Return
                End If

                If String.IsNullOrEmpty(txtDateIssued.Text) = True Then
                    msgtext = "Please select date issued"
                    Return
                End If
            End If

            If RadioButton2.Checked = True Then
                If String.IsNullOrEmpty(txtVerificationCERT.Text) = True Then
                    msgtext = "Please enter certificate number"
                    Return
                End If

                If String.IsNullOrEmpty(txtVerDate.Text) = True Then
                    msgtext = "Please select date issued"
                    Return
                End If
            End If

            Dim sql = "Insert into deviceregistration(" & FN & ") Values (" & FV & ")"

            If String.IsNullOrEmpty(Session("DeviceID")) = True Then
                Dim sd As String = ""

                sd = "select sysID from deviceregistration where serialNumber=" & GenTool.addbackslash(txtserial.Text) & " AND AccountID=" & Val(Session("ID"))
                If GenTool.HasRows(sd) = True Then
                    msgtext = "Serila number already exist please choose another"
                    Return
                End If

                msgtext = "Instrument registered successfully"

            Else

                sql = "Update deviceregistration set " & FUpdate & " where sysID=" & Val(Session("DeviceID"))
                msgtext = "Instrument updated successfully"

            End If

            If GenTool.ExecuteDatabase(sql) = True Then
                If chkUseCompany.Checked = True Then

                    If GenTool.HasDatasetAnyRecord(dsFillCompany) = True Then
                        dsFillCompany = GenTool.getFillCompany(Session("ID"))
                    End If

                    Try

                        With dsFillCompany.Tables(0).Rows(0)
                            sql = "Update deviceregistration set companyName=" & GenTool.addbackslash(.Item(0)) & _
                                ",streetAddress=" & GenTool.addbackslash(.Item(1)) & _
                                ",cityID=" & Val(.Item(2)) & _
                                ",LGAID=" & Val(.Item(3)) & _
                                ",StateID=" & Val(.Item(4)) & _
                                ",POBOX=" & GenTool.addbackslash(.Item(5)) & _
                                ",companyEmail=" & GenTool.addbackslash(.Item(6)) & _
                                ",companywebsite=" & GenTool.addbackslash(.Item(7)) & " where AccountID=" & Val(Session("ID")) & " AND serialNumber=" & GenTool.addbackslash(txtserial.Text)
                        End With

                        GenTool.ExecuteDatabase(sql)

                    Catch ex As Exception
                        GenTool.GrabError(ex.Message, "saveData")
                    End Try
                End If

                getInPaymentSheet()

                GenTool.resetform(Panel1)
                GenTool.resetform(Panel2)

                If RadioButton3.Checked = True Then
                    msgtext = msgtext & " ,Please check your mail box for Pattern Approval application form"
                ElseIf RadioButton4.Checked = True Then
                    msgtext = msgtext & " ,Please check your mail box for Initial Verification Certificate application form"
                ElseIf RadioButton4.Checked = True OrElse RadioButton3.Checked = True Then
                    msgtext = msgtext & " ,Please check your mail box for Pattern Approval & Initial Verification Certificate application form"
                End If

            Else
                msgtext = "The system was unable to save this record,check your entry and try again,if it continues contact service center"
            End If

        Catch ex As Exception
            lblMsg.Text = ex.Message
        Finally
            lblMsg.Text = msgtext
            If msgtext <> "" Then
                MessageBox.Show(UpdatePanel1, msgtext)
            End If
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

    Private Sub getInPaymentSheet()
        Dim FtRUE As Boolean
        Dim orderID As String
        Dim sd As String = "select sysID from paymentsheet where companyID=" & Val(Session("ID")) & " AND TransCode=" & GenTool.addbackslash(txtTransCode.Text)

        If GenTool.HasRows(sd) = False Then
            orderID = Strings.Left(GenTool.GenerateUniqueCode & GenTool.GenerateRNDCode, 10)
            sd = "Insert into paymentsheet(companyID,amountDue,narration,paymentName,OrderId,TransCode) values(" & _
            Val(Session("ID")) & "," & Val(txtamount.Text.Replace("N", "").Replace(",", "")) & ",'Annual Licensing Fee'," & GenTool.addbackslash(Session("cname")) & "," & _
            GenTool.addbackslash(orderID) & "," & GenTool.addbackslash(txtTransCode.Text) & ")"

            FtRUE = True
        Else
            sd = "Update paymentsheet set amountDue=" & Val(txtamount.Text.Replace("N", "").Replace(",", "")) & " where companyID=" & Val(Session("ID")) & " AND TransCode=" & GenTool.addbackslash(txtTransCode.Text)
            orderID = GenTool.getSingleValue("select OrderId from paymentsheet where TransCode=" & GenTool.addbackslash(txtTransCode.Text))
            FtRUE = False
        End If

        GenTool.ExecuteDatabase(sd)

        dsFillCompany = GenTool.getFillCompany(Session("ID"))

        If GenTool.HasDatasetAnyRecord(dsFillCompany) = False Then
            With dsFillCompany.Tables(0).Rows(0)

                Dim db As String = GenTool.getSingleValue("select sum(amountDue)-sum(AmountPaid) from paymentsheet where companyID=" & Val(Session("ID")))

                Dim Narration As String = "INSTRUMENT REGISTRATION FEE"
                Dim Hearder As String = "INSTRUMENT REGISTRATION INVOICE"
                Dim Welcome As String = "INSTRUMENT REGISTRATION"
                Dim Footer As String = ""
                Footer = "<hr><strong>Outstanding Bill : " & Format(Val(db), "0,0.00") & "</strong>"
                Footer &= "<hr/>NOTE: This is a confidential information, please discard if it is received in error."

                If RadioButton3.Checked = True Then
                    Narration = "<p class='MsoNormal' style='margin-bottom: 0.0001pt; line-height: normal;'><b><span style='font-size: 12pt; font-family: 'times new roman','serif'; color: #3b3838;'>APPLICATION FOR PATTERN OF APPROVAL CERTIFICATE</span></b><b><span style='font-size: 12pt; font-family: 'times new roman','serif';'><br /></span></b><i><u><span style='font-size: 12pt; font-family: 'times new roman','serif'; color: #2e74b5;'><a href='http://www.nnlnigeria.com/documents/Pattern Approval Application.pdf' target='_self'>Click here to Download Pattern Of Approval Certificate  Application Form.pdf</a><br /></span></u></i><span style='font-size: 12pt; font-family: 'times new roman','serif';'>Please fill this document properly,  scan it after filling, and upload it from your Login page. </span></p><p class='MsoNormal' style='margin-bottom: 0.0001pt; text-align: justify; line-height: normal;'><span style='font-size: 12pt; font-family: 'times new roman','serif';'>You can login to our website to upload your Application Form.</span></p><a href='http://localhost/nnlnigeria/www.wmdnigeria.com' target='_self'><i><u><span style='font-size: 12pt; line-height: 107%; font-family: 'times new roman','serif'; color: #2e74b5;'>www.wmdnigeria.com</span></u></i></a>"
                    Footer = "<hr><strong>Outstading Bill : " & Format(Val(db), "0,0.00") & "</strong>"
                    Footer &= "<hr/>NOTE: This is a confidential information, please discard if it is received in error."
                    Welcome = "APPLICATION FOR PATTERN OF APPROVAL CERTIFICATE"
                    Hearder = "NOTICE OF APPLICATION FOR  PATTERN OF APPROVAL CERTIFICATE"
                End If

                If RadioButton4.Checked = True Then
                    Narration = "This mail is sent in acknowledgment of your application for Adjustment of your Instruments for accuracy. We shall communicate to you the scheduled date for the adjustment exercise. Thank you."
                    Footer = "<hr><strong>Outstanding Bill : " & Format(Val(db), "0,0.00") & "</strong>"
                    Footer &= "<hr/>NOTE: This is a confidential information, please discard if it is received in error."
                    Welcome = "Instrument Adjustment response alert"
                    Hearder = "Instrument Adjustment response alert".ToUpper
                End If

                If FtRUE = True Then
                    GenTool.SendFinancialMail(Hearder, orderID, .Item("companyName").ToString, txtamount.Text, Narration, "Transaction Alert-Federal Ministry Of Industry,Trade And Investment-" & orderID, .Item("companyEmail").ToString, "PENDING", Welcome, Footer)
                Else
                    GenTool.SendFinancialMail(Hearder, orderID, .Item("companyName").ToString, txtamount.Text, Narration, "Transaction Alert-Federal Ministry Of Industry,Trade And Investment-" & orderID, .Item("companyEmail").ToString, "PENDING", Welcome, Footer)
                End If

            End With
        End If

    End Sub

    Protected Sub grd_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grd.PageIndexChanging
        grd.PageIndex = e.NewPageIndex
        filldb("")
    End Sub

    Protected Sub grd_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grd.SelectedIndexChanged
        CheckBox1_CheckedChanged(Nothing, Nothing)

        Session("DeviceID") = grd.SelectedRow.Cells(1).Text

        Dim sql As String = "select sysID from deviceregistration where NoDelete=1 AND sysID=" & Val(Session("DeviceID"))
        If GenTool.HasRows(sql) = True Then
            MessageBox.Show(UpdatePanel1, "You have paid for this instrument and cannot be modified")
            Return
        End If


        fillBackForm(grd.SelectedRow.Cells(8).Text)
        'fillBackForm(grd.SelectedRow.Cells(8).Text)

        btnDelete.Visible = True
        btnPreview_ConfirmButtonExtender.ConfirmText = "Are you sure you want to UPDATE this record"

    End Sub

    Protected Sub cboFeegroup_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFeegroup.SelectedIndexChanged
        Try
            cboFeeSubGroup.Items.Clear()
            cboFeeSubGroup.DataValueField = "sysID"
            cboFeeSubGroup.DataTextField = "subheading"
            cboFeeSubGroup.DataSource = dsSubGroup.Tables(cboFeegroup.SelectedValue)
            cboFeeSubGroup.DataBind()
            cboFeeSubGroup.Items.Insert(0, "Select Sub Section")

            cboMrange.Items.Clear()
            cboMrange.Items.Insert(0, "Select Fee Name")
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
            cboMrange.Items.Insert(0, "Select Fee Name")

        Catch ex As Exception
            GenTool.GrabError(ex.Message, "cboFeeSubGroup")
        End Try
    End Sub

    Protected Sub cboMrange_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMrange.SelectedIndexChanged
        Dim f As String = "0.00"

        If cboMrange.SelectedIndex > 0 Then
            f = GenTool.getRowItemInds(dsFeeTable, "amount", "sysID", cboMrange.SelectedValue, cboFeeSubGroup.SelectedValue)
            lblAmount.Text = Val(f).ToString("Amt N#,#.00")
        Else
            lblAmount.Text = f
        End If

        txtamount.Text = f

    End Sub

    Private Sub fillBackForm(ByVal ID As String)
        Try

            Dim dsV As DataSet = GenTool.DataSetData("select * from deviceregistration where sysID=" & Val(Session("DeviceID")))
            GenTool.resetform(Panel2, dsV)
            GenTool.resetform(Panel1, dsV)

            Dim sectionID As String = GenTool.getRowItemInds(dsFeeTableAll, "feeGroupID", "sysID", ID)
            Dim sectionName As String = GenTool.getRowItemInds(dsScaleGroup, "HeaderName", "sysID", Val(sectionID))
            cboFeegroup.SelectedIndex = GenTool.getddlindexvalue(cboFeegroup, sectionName)
            cboFeegroup_SelectedIndexChanged(Nothing, Nothing)

            Dim subSectionID As String = GenTool.getRowItemInds(dsFeeTableAll, "feeSubGroupID", "sysID", ID)
            Dim subSectionName As String = GenTool.getRowItemInds(dsSubGroup, "subheading", "sysID", Val(subSectionID), cboFeegroup.SelectedValue)
            cboFeeSubGroup.SelectedIndex = GenTool.getddlindexvalue(cboFeeSubGroup, subSectionName)
            cboFeeSubGroup_SelectedIndexChanged(Nothing, Nothing)

            Dim feeName As String = GenTool.getRowItemInds(dsFeeTable, "measureRange", "sysID", Val(ID), cboFeeSubGroup.SelectedValue)
            cboMrange.SelectedIndex = GenTool.getddlindexvalue(cboMrange, feeName)
            cboMrange_SelectedIndexChanged(Nothing, Nothing)


            goFillCompany(dsV)

        Catch ex As Exception
            GenTool.GrabError(ex.Message, "fillBackForm")
        End Try
    End Sub

    Private Sub goFillCompany(ByVal ds As DataSet)

        Dim fx As String = GenTool.getValueSystem(ds, "StateID|")
        fx = GenTool.getRowItemInds(dsState, "stateName", "sysID", fx)
        cboState.SelectedIndex = GenTool.getddlindexvalue(cboState, fx)
        cboState_SelectedIndexChanged(Nothing, Nothing)


        fx = GenTool.getValueSystem(ds, "LGAID|")
        fx = GenTool.getRowItemInds(dsLGAState, "LGA", "sysID", fx, cboState.SelectedItem.Text)
        cboLGA.SelectedIndex = GenTool.getddlindexvalue(cboLGA, fx)

        fx = GenTool.getValueSystem(ds, "cityID|")
        fx = GenTool.getRowItemInds(dsCity, "city", "sysID", fx)
        cboCity.SelectedIndex = GenTool.getddlindexvalue(cboCity, fx)


        fx = GenTool.getValueSystem(ds, "DeviceGroupID|")
        fx = GenTool.getRowItemInds(dsMainDevice, "DeviceCategory", "sysID", fx)
        cboMainGroup.SelectedIndex = GenTool.getddlindexvalue(cboMainGroup, fx)
        cboMainGroup_SelectedIndexChanged(Nothing, Nothing)


        fx = GenTool.getValueSystem(ds, "SubDeviceID|")
        fx = GenTool.getRowItemInds(dsMainSubDevice, "DeviceName", "sysID", fx, cboMainGroup.SelectedValue)
        cboDeviceSub.SelectedIndex = GenTool.getddlindexvalue(cboDeviceSub, fx)

        cboDeviceSub_SelectedIndexChanged(Nothing, Nothing)
        fx = GenTool.getValueSystem(ds, "TypeOfDevice|")
        fx = GenTool.getRowItemInds(dsDeviceType, "DeviceType", "sysID", fx)
        cboTypeOfDevice.SelectedIndex = GenTool.getddlindexvalue(cboTypeOfDevice, fx)

    End Sub


    Protected Sub btncancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Try
            GenTool.resetform(Panel1)
            GenTool.resetform(Panel2)
            btnDelete.Visible = False
            Session("DeviceID") = ""
            lblTotal.Text = ""
            lblAmount.Text = ""
            btnPreview_ConfirmButtonExtender.ConfirmText = "Are you sure you want to SAVE this record"
        Catch ex As Exception
        End Try
      
    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim msgText As String = ""

        Try

            Dim sd As String = "select sysID from paymentsheet where AmountPaid>0 AND companyID=" & Val(Session("ID")) & " AND deviceSerial=" & GenTool.addbackslash(txtserial.Text)

            If GenTool.HasRows(sd) = True Then
                msgText = "This record cannot be deleted because you have commited payment on this Instrument"
                Return
            End If

            sd = "delete from paymentsheet where companyID=" & Val(Session("ID")) & " AND TransCode=" & GenTool.addbackslash(txtTransCode.Text)
            Dim al As New ArrayList
            al.Add(sd)

            Dim sd1 As String = "Delete from deviceregistration where AccountID=" & Val(Session("ID")) & " AND sysID=" & Val(Session("DeviceID"))
            al.Add(sd1)

            If GenTool.ExecuteBulkSQL(al) = True Then

                GenTool.FormHistory("Instrument With Serial Number : " & txtserial.Text & " was deleted ", Request.UserHostAddress, , Val(Session("ID")))

                filldb("")
                GenTool.resetform(Panel1)
                GenTool.resetform(Panel2)
                msgText = "Your Instrument was deleted successfully"
            Else
                msgText = "Your account cannot be updated at the moment,please try again later"
            End If

        Catch ex As Exception
            msgText = "Your account cannot be updated at the moment,please try again later"
        Finally
            lblMsg.Text = msgText
            If msgText <> "" Then
                MessageBox.Show(Me, msgText)
            End If
        End Try
    End Sub

    Protected Sub cboMainGroup_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMainGroup.SelectedIndexChanged
        Try
            cboDeviceSub.Items.Clear()

            If cboMainGroup.SelectedItem.Text.ToUpper = "Telecommunication".ToUpper Then
                Label27.Text = "Enter Network provider:"
                TextBox6.ValidationGroup = "DeviceModelName|Invalid Network Provider"
                TextBox6.ToolTip = "enter network provider"

            ElseIf cboMainGroup.SelectedItem.Text.ToUpper = "Banking".ToUpper Then

                Label27.Text = "Enter Terminal ID:"
                TextBox6.ValidationGroup = "DeviceModelName|Invalid Terminal ID"
                TextBox6.ToolTip = "enter terminal id"
                Label23.Text = "Measuring Instrument:"
                Label24.Visible = False
                TextBox5.Visible = False
                TextBox5.ValidationGroup = "actualMeasure"

            Else

                Label27.Text = "Instr. Model Name::"
                TextBox6.ValidationGroup = "DeviceModelName|Invalid Instrument model name"
                TextBox6.ToolTip = "enter Instrument model name"

                Label23.Text = "Official Measure:"
                Label24.Visible = True
                TextBox5.Visible = True
                TextBox5.ValidationGroup = "actualMeasure|Invalid Official Measure"

            End If


            cboDeviceSub.DataValueField = "sysID"
            cboDeviceSub.DataTextField = "DeviceName"
            cboDeviceSub.DataSource = dsMainSubDevice.Tables(cboMainGroup.SelectedValue)
            cboDeviceSub.DataBind()
            cboDeviceSub.Items.Insert(0, "Select Instrument Category")
        Catch ex As Exception
            GenTool.GrabError(ex.Message, "DeviceSub")
        End Try
    End Sub

 
    Protected Sub cboDeviceSub_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDeviceSub.SelectedIndexChanged
        Try
            Dim sql As String = "mainsubdeviceID=" & Val(cboDeviceSub.SelectedValue)
            Dim dsv As DataSet = GenTool.getFromDataset(dsDeviceType, sql)

            cboTypeOfDevice.Items.Clear()
            cboTypeOfDevice.DataValueField = "sysID"
            cboTypeOfDevice.DataTextField = "DeviceType"
            cboTypeOfDevice.DataSource = dsv.Tables(0)
            cboTypeOfDevice.DataBind()
            cboTypeOfDevice.Items.Insert(0, "Select Instrument Type")

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub BTNPAY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BTNPAY.Click
        Try
            Response.Redirect("invioces.aspx")
        Catch ex As Exception
        End Try
    End Sub

 
    Protected Sub RadioButton3_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged, RadioButton4.CheckedChanged
        txtCerticateNo.Text = ""
        txtDateIssued.Text = ""
        txtCerticateNo.Visible = False
        txtDateIssued.Visible = False
        childimgbtnCal0.Visible = False
        lblCerticateNo.Visible = False
        lblDateIssued.Visible = False

        txtVerificationCERT.Visible = False
        txtVerDate.Visible = False
        txtVerDate.Text = ""
        txtVerificationCERT.Text = ""
        ImageButton1.Visible = False
        Label28.Visible = False
        Label22.Visible = False

    End Sub

    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged

        txtVerificationCERT.Visible = False
        txtVerDate.Visible = False
        ImageButton1.Visible = False
        Label28.Visible = False
        Label22.Visible = False

        txtCerticateNo.Visible = True
        txtDateIssued.Visible = True
        childimgbtnCal0.Visible = True
        lblCerticateNo.Visible = True
        lblDateIssued.Visible = True
    End Sub

    Protected Sub RadioButton2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        txtCerticateNo.Visible = False
        txtDateIssued.Visible = False
        childimgbtnCal0.Visible = False
        lblCerticateNo.Visible = False
        lblDateIssued.Visible = False

        txtVerificationCERT.Visible = True
        txtVerDate.Visible = True
        ImageButton1.Visible = True
        Label28.Visible = True
        Label22.Visible = True
    End Sub

End Class
