Imports System.Data

Partial Class registerdevice
    Inherits System.Web.UI.Page

    Dim dsFillCompany As New DataSet
 
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Try
            txtAccountID.Text = Session("ID")
 
            If IsPostBack = False Then
                getDviceStaticdata()
                getCompanyStaticData()
                filldb("")
            End If

        Catch ex As Exception
            GenTool.GrabError(ex.Message, "regdevice")
        End Try
    End Sub

    Private Sub getDviceStaticdata()

        If GenTool.HasDatasetAnyRecord(dsScaleGroupService) = True Then
            getScaleGroupService()
        End If

        If GenTool.HasDatasetAnyRecord(dsSubGroupService) = True Then
            getGroupService()
        End If

        If GenTool.HasDatasetAnyRecord(dsFeeTable) = True Then
            getFeeTable()
        End If

        Try
            cboFeegroup.Items.Clear()
            cboFeegroup.DataTextField = "HeaderName"
            cboFeegroup.DataValueField = "sysID"
            cboFeegroup.DataSource = dsScaleGroupService.Tables(0)
            cboFeegroup.DataBind()
        Catch ex As Exception
        End Try
        cboFeegroup.Items.Insert(0, "Select Service Group")

        Try
            cboInstrument.Items.Clear()
            cboInstrument.DataTextField = "serialNumber"
            cboInstrument.DataValueField = "sysID"
            cboInstrument.DataSource = GenTool.DataSetData("select concat(devicetype,' : SN ',serialNumber) as serialNumber,deviceregistration.sysID from deviceregistration,maindevicesection where deviceregistration.TypeOfDevice=maindevicesection.sysID AND AccountID=" & Val(Session("ID"))).Tables(0)
            cboInstrument.DataBind()
        Catch ex As Exception
        End Try
        cboInstrument.Items.Insert(0, "Select Instrument")

    End Sub

    Private Sub getCompanyStaticData()

        If dsFillCompany Is Nothing OrElse dsFillCompany.Tables.Count < 1 OrElse dsFillCompany.Tables(0).Rows.Count < 1 Then
            dsFillCompany = GenTool.getFillCompany(Session("ID"))
        End If

    End Sub


    Dim GenTool As NNLN = xsmsCentralToolx.SetTool

    Private Sub filldb(ByVal w As String)
        Dim ds As DataSet = GenTool.DataSetData("select sysID as ID,(select HeaderName from feegroup,feesubgroup,feetable where feesubgroup.feegroupID=feegroup.sysID AND feesubgroup.sysID=feetable.feeGroupID AND feetable.sysID=deviceregistration.feeID) as 'Service Name',(select feesubgroup.subheading from feesubgroup,feetable where feesubgroup.sysID=feetable.feeGroupID AND feetable.sysID=deviceregistration.feeID) as 'Service Category',date_format(regDate,'%D-%M-%Y') as TransDate,DATE_FORMAT(RegTime, '%h:%i:%S %p') as TransTime,(select measureRange from feetable where sysID=feeID) as Capacity,deviceAmount as Fee,feeID as FID from deviceregistration where IsdbService=1 AND AccountID=" & Val(Session("ID")) & " " & w)
        Try
            Dim fPaid As String = GenTool.getSingleValue("select sum(deviceAmount) from deviceregistration where IsdbService=1 AND vStatus=1 AND AccountID=" & Val(Session("ID")) & " " & w)

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
        txtIsDbService.Text = "1"

        Try
            txtAccountID.Text = Session("ID")

            If String.IsNullOrEmpty(Session("DeviceIDs")) = True Then
                txtTransCode.Text = GenTool.GenerateRNDCode(True, True) & GenTool.GenerateUniqueCode
                txtbarCode.Text = GenTool.GenerateUniqueCode & GenTool.GenerateRNDCode()
                txtserialNumber.Text = GenTool.GenerateRNDCode() & GenTool.GenerateUniqueCode
            End If
            txtamount.Text = Val(txtamount.Text)
            msgtext = GenTool.checkControl(Panel2, FN, FV, FUpdate)
            If msgtext <> "" Then Return

            Dim sql = "Insert into deviceregistration(" & FN & ") Values (" & FV & ")"

            If String.IsNullOrEmpty(Session("DeviceIDs")) = True Then
                msgtext = "Instrument service registered successfully"
            Else

                sql = "Update deviceregistration set " & FUpdate & " where sysID=" & Val(Session("DeviceIDs"))
                msgtext = "Instrument service updated successfully"

            End If

            If GenTool.ExecuteDatabase(sql) = True Then

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
                            ",companywebsite=" & GenTool.addbackslash(.Item(7)) & " where AccountID=" & Val(Session("ID"))
                    End With

                    GenTool.ExecuteDatabase(sql)

                Catch ex As Exception
                    GenTool.GrabError(ex.Message, "saveData")
                End Try

                getInPaymentSheet()
                GenTool.resetform(Panel2)
                filldb("")
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
            Val(Session("ID")) & "," & Val(txtamount.Text.Replace("N", "").Replace(",", "")) & ",'Instrument Registration'," & GenTool.addbackslash(Session("cname")) & "," & _
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
             
            Dim Hearder As String
            Dim Welcome As String
            Dim Footer As String
            Dim Narration As String

            With dsFillCompany.Tables(0).Rows(0)

                Dim db As String = GenTool.getSingleValue("select sum(amountDue)-sum(AmountPaid) from paymentsheet where companyID=" & Val(Session("ID")))

                Narration = "This mail is sent in acknowledgment of your application for SERVICE request on your Instruments. We shall communicate to you the scheduled date for the exercise. Thank you."
                Footer = "<hr><strong>Outstanding Bill : " & Format(Val(db), "0,0.00") & "</strong>"
                Footer &= "<hr/>NOTE: This is a confidential information, please discard if it is received in error."
                Welcome = "Instrument Service response alert"
                Hearder = "Instrument service response alert".ToUpper

                GenTool.SendFinancialMail(Hearder, orderID, .Item("companyName").ToString, txtamount.Text, Narration, "Transaction Alert-Federal Ministry Of Industry,Trade And Investment-" & orderID, .Item("companyEmail").ToString, "PENDING", Welcome, Footer)

            End With
        End If

    End Sub

    Protected Sub grd_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grd.PageIndexChanging
        grd.PageIndex = e.NewPageIndex
        filldb("")
    End Sub

    Protected Sub grd_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grd.SelectedIndexChanged

        Session("DeviceIDs") = grd.SelectedRow.Cells(1).Text

        Dim sql As String = "select sysID from deviceregistration where NoDelete=1 AND sysID=" & Val(Session("DeviceIDs"))
        If GenTool.HasRows(sql) = True Then
            MessageBox.Show(UpdatePanel1, "You have paid for this service and cannot be modified")
            Return
        End If

        fillBackForm(grd.SelectedRow.Cells(8).Text)

        btnDelete.Visible = True
        btnPreview_ConfirmButtonExtender.ConfirmText = "Are you sure you want to UPDATE this record"

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

            Dim dsV As DataSet = GenTool.DataSetData("select * from deviceregistration where sysID=" & Val(Session("DeviceIDs")))
            GenTool.resetform(Panel2, dsV)

            Dim sectionID As String = GenTool.getRowItemInds(dsFeeTableAll, "feeGroupID", "sysID", ID)
            Dim sectionName As String = GenTool.getRowItemInds(dsScaleGroupService, "HeaderName", "sysID", Val(sectionID))
            cboFeegroup.SelectedIndex = GenTool.getddlindexvalue(cboFeegroup, sectionName)
            cboFeegroup_SelectedIndexChanged(Nothing, Nothing)

            Dim subSectionID As String = GenTool.getRowItemInds(dsFeeTableAll, "feeSubGroupID", "sysID", ID)
            Dim subSectionName As String = GenTool.getRowItemInds(dsSubGroupService, "subheading", "sysID", Val(subSectionID), cboFeegroup.SelectedValue)
            cboFeeSubGroup.SelectedIndex = GenTool.getddlindexvalue(cboFeeSubGroup, subSectionName)
            cboFeeSubGroup_SelectedIndexChanged(Nothing, Nothing)

            Dim feeName As String = GenTool.getRowItemInds(dsFeeTable, "measureRange", "sysID", Val(ID), cboFeeSubGroup.SelectedValue)
            cboMrange.SelectedIndex = GenTool.getddlindexvalue(cboMrange, feeName)
            cboMrange_SelectedIndexChanged(Nothing, Nothing)

            subSectionName = GenTool.getRowItemInds(dsV, "DID", "sysID", Val(Session("DeviceIDs")))
            subSectionName = "select concat(devicetype,' : SN ',serialNumber) as serialNumber,deviceregistration.sysID from deviceregistration,maindevicesection where deviceregistration.TypeOfDevice=maindevicesection.sysID AND deviceregistration.sysID=" & Val(subSectionName)
            subSectionName = GenTool.getSingleValue(subSectionName)

            cboInstrument.SelectedIndex = GenTool.getddlindexvalue(cboInstrument, subSectionName)

        Catch ex As Exception
            GenTool.GrabError(ex.Message, "fillBackForm")
        End Try
    End Sub

    Protected Sub btncancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Try
            GenTool.resetform(Panel2)
            btnDelete.Visible = False
            Session("DeviceIDs") = ""
            lblTotal.Text = ""
            lblAmount.Text = ""
            btnPreview_ConfirmButtonExtender.ConfirmText = "Are you sure you want to SAVE this record"
        Catch ex As Exception
        End Try
      
    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim msgText As String = ""

        Try

            Dim sd As String = "select sysID from paymentsheet where AmountPaid>0 AND companyID=" & Val(Session("ID"))

            If GenTool.HasRows(sd) = True Then
                msgText = "This record cannot be deleted because you have commited payment on this Instrument"
                Return
            End If

            sd = "delete from paymentsheet where companyID=" & Val(Session("ID")) & " AND TransCode=" & GenTool.addbackslash(txtTransCode.Text)
            Dim al As New ArrayList
            al.Add(sd)

            Dim sd1 As String = "Delete from deviceregistration where AccountID=" & Val(Session("ID")) & " AND sysID=" & Val(Session("DeviceIDs"))
            al.Add(sd1)

            If GenTool.ExecuteBulkSQL(al) = True Then

                GenTool.FormHistory("Instrument  was deleted ", Request.UserHostAddress, , Val(Session("ID")))

                filldb("")

                GenTool.resetform(Panel2)
                msgText = "Your service was deleted successfully"
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

    Protected Sub BTNPAY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BTNPAY.Click
        Try
            Response.Redirect("invioces.aspx")
        Catch ex As Exception
        End Try
    End Sub


    Protected Sub cboFeegroup_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFeegroup.SelectedIndexChanged
        Try
            cboFeeSubGroup.Items.Clear()
            cboFeeSubGroup.DataValueField = "sysID"
            cboFeeSubGroup.DataTextField = "subheading"
            cboFeeSubGroup.DataSource = GenTool.DataSetData("select subheading,sysID from feesubgroup where feegroupID=" & cboFeegroup.SelectedValue).Tables(0)
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
            cboMrange.DataSource = GenTool.DataSetData("select measureRange,sysID from feetable where feeSubGroupID=" & cboFeeSubGroup.SelectedValue).Tables(0)
            cboMrange.DataBind()
            cboMrange.Items.Insert(0, "Select Fee Name")

        Catch ex As Exception
            GenTool.GrabError(ex.Message, "cboFeeSubGroup")
        End Try
    End Sub
End Class
