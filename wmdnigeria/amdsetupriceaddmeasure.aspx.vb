Imports System.Data

Partial Class amdsetupdeviceprice
    Inherits System.Web.UI.Page

    Dim GenTool As NNLN = xsmsCentralToolx.SetTool

    Protected Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init

    End Sub

    Sub fetchData()
        Try
            Dim sql As String = "select sysID as ID,MeasureName,MeasureValue,Status,IsDefault from maindevicepriceadmeasure where MainDeviceID=" & Val(Session("did"))
            grd.DataSource = GenTool.DataSetData(sql).Tables(0)
            grd.DataBind()
        Catch ex As Exception
            GenTool.GrabError(ex.Message, "fetchData")
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

    Protected Sub grd_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles grd.SelectedIndexChanged
        Try
            Session("xyz") = grd.SelectedRow.Cells(1).Text

            Dim dsV As DataSet = GenTool.DataSetData("select * from maindevicepriceadmeasure where sysID=" & Val(Session("xyz")))
            GenTool.resetform(Panel1, dsV)
            btnDelete.Visible = True
            btnPreview_ConfirmButtonExtender.ConfirmText = "Are you sure you want to UPDATE this record"
            'TextBox1.Text = grd.SelectedRow.Cells(2).Text
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btncancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Try
            GenTool.resetform(Panel1)
            btnDelete.Visible = False
            btnPreview_ConfirmButtonExtender.ConfirmText = "Are you sure you want to SAVE this record"
            Session("xyz") = ""
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnPreview_Click(sender As Object, e As System.EventArgs) Handles btnPreview.Click
        Dim msgtext As String = ""

        Dim FUpdate As String = ""
        Dim FV As String = ""
        Dim FN As String = ""

        Try


            txtMainDeviceID.Text = Session("did")
            msgtext = GenTool.checkControl(Panel1, FN, FV, FUpdate)
            If msgtext <> "" Then Return

            Dim sql = "Insert into maindevicepriceadmeasure(" & FN & ") Values (" & FV & ")"

            If String.IsNullOrEmpty(Session("xyz")) = True Then
                msgtext = "Instrument measure saved successfully"
            Else
                sql = "Update maindevicepriceadmeasure set " & FUpdate & " where sysID=" & Val(Session("xyz"))
                msgtext = "Instrument measure updated successfully"
            End If

            Dim dbStore As New ArrayList

            If chkDefault.Checked = True Then
                Dim sql1 As String = "update maindevicepriceadmeasure set IsDefault=0 where  MainDeviceID=" & Val(Session("did"))
                dbStore.Add(sql1)
                sql1 = "Update maindevicepriceadmeasure set IsDefault=1 where sysID=" & Val(Session("xyz"))
                dbStore.Add(sql1)
            End If

            dbStore.Add(sql)

            If GenTool.ExecuteBulkSQL(dbStore) = True Then


                GenTool.FormHistory(lblInstType.Text & " measure was set", Request.UserHostAddress, Val(Session("sysID")))
                btncancel_Click(Nothing, Nothing)
                fetchData()
            Else
                msgtext = "The system was unable to save this record,check your entry and try again,if it continues contact service center"
            End If

        Catch ex As Exception
            msgtext = ex.Message
        Finally

            If msgtext <> "" Then
                MessageBox.Show(Panel1, msgtext)
            End If
        End Try
    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As System.EventArgs) Handles btnDelete.Click
        Dim msgText As String = ""

        Try
            Dim sd As String = "delete from maindevicepriceadmeasure where sysID=" & Val(Session("xyz"))
            If GenTool.ExecuteDatabase(sd) = True Then
                GenTool.FormHistory("Measure set for Instrument type : " & lblInstType.Text & " was deleted ", Request.UserHostAddress, , Val(Session("ID")))
                GenTool.resetform(Panel1)
                msgText = "Your Instrument Measure was deleted successfully"
                fetchData()
            Else
                msgText = "Your account cannot be updated at the moment,please try again later"
            End If

        Catch ex As Exception
            msgText = "Your account cannot be delete at the moment,please try again later"
        Finally
            If msgText <> "" Then
                MessageBox.Show(Me, msgText)
            End If
        End Try
    End Sub

    Protected Sub cboCompany_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboCompany.SelectedIndexChanged
        Try
            TextBox2.Text = GenTool.getSingleValue("select MeasureValue from maindevicemeasurename where sysID=" & cboCompany.SelectedValue)
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            If IsPostBack = False Then
                lblInstrument.Text = Request("ins")
                lblParameters.Text = Request("par")
                lblInstType.Text = Request("instype")
                Session.Add("did", Request("did"))
                txtMainDeviceID.Text = Session("did")
                fetchData()


                Dim cDropDown = New dropDownFiller
                cDropDown.SQL = " select MeasureName,sysID from maindevicemeasurename "
                cDropDown.ddlDown = cboCompany
                cDropDown.fieldname = "MeasureName"
                cDropDown.uniqueName = "sysID"
                GenTool.fillDropDownBox(cDropDown)
                Session("xyz") = ""
            End If

        Catch ex As Exception
            MessageBox.Show(Panel1, ex.Message)
        End Try
    End Sub
End Class
