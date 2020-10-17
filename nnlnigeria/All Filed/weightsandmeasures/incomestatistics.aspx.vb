Imports System.Data

Partial Class incomestatistics
    Inherits System.Web.UI.Page

    Dim GenTool As NNLN = xsmsCentralToolx.SetTool

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Dim sql As String = ""

            Dim ds As DataSet
            Try
                sql = "select sysID,stateName  from tblstate "
                ds = GenTool.DataSetData(sql)
                cboByState.DataValueField = "sysID"
                cboByState.DataTextField = "stateName"
                cboByState.DataSource = ds.Tables(0)
                cboByState.DataBind()

            Catch ex As Exception
            Finally
                cboByState.Items.Insert(0, "All States")
            End Try

            Sql = "select sysID,DeviceCategory from maindevice"
            ds = GenTool.DataSetData(Sql)

            Try
                If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then

                    cboBySector.DataValueField = "sysID"
                    cboBySector.DataTextField = "DeviceCategory"
                    cboBySector.DataSource = ds.Tables(0)
                    cboBySector.DataBind()

                End If

            Catch ex As Exception
            Finally
                cboBySector.Items.Insert(0, "All Sectors")
            End Try
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            Dim sql As String = ""

            If IsDate(txtDPTTo.Text) = False OrElse IsDate(txtDPTTo0.Text) = False Then
                MessageBox.Show(Me, "You have not selected date range")
                Return
            End If


            Dim ALProcess As New ArrayList

            Dim totalSUM As Double = 0
            Dim FValue As Single
            Dim Pert As String = ""

            If optBySector.Checked = True Then
                sql = "select sum(AmountPaid) from paymentsheet,deviceregistration,feegroup where deviceregistration.TransCode=paymentsheet.TransCode AND deviceregistration.feeIDGroup=feegroup.sysID"
                totalSUM = Val(GenTool.getSingleValue(sql))
            Else
                sql = "select sum(AmountPaid) from paymentsheet,deviceregistration where deviceregistration.TransCode=paymentsheet.TransCode AND deviceregistration.AccountID=companyID"
                totalSUM = Val(GenTool.getSingleValue(sql))
            End If

            sql = "Delete from  financialhistory where UserID=" & sysDBUser.sysid
            ALProcess.Add(sql)

            If optBySector.Checked = True Then

                If cboBySector.SelectedIndex > 0 Then
                    sql = "select sum(AmountPaid) from paymentsheet,deviceregistration,feegroup where deviceregistration.TransCode=paymentsheet.TransCode AND deviceregistration.feeIDGroup=feegroup.sysID AND feeIDGroup=" & Val(cboBySector.SelectedValue)
                    FValue = Val(GenTool.getSingleValue(sql))

                    If totalSUM <= 0 Then
                        Pert = "0%"
                    Else
                        Pert = (FValue / totalSUM * 100).ToString & "%"
                    End If

                    sql = "insert into  financialhistory (ProcessName, TotalFee, Percentage, UserID) Values (" & _
                    GenTool.addbackslash(cboBySector.SelectedItem.Text) & "," & FValue & "," & GenTool.addbackslash(Pert) & "," & sysDBUser.sysid & ")"

                    ALProcess.Add(sql)

                Else

                    For j As Integer = 1 To cboBySector.Items.Count - 1

                        sql = "select sum(AmountPaid) from paymentsheet,deviceregistration,feegroup where deviceregistration.TransCode=paymentsheet.TransCode AND deviceregistration.feeIDGroup=feegroup.sysID AND feeIDGroup=" & Val(cboBySector.Items(j).Value)
                        FValue = Val(GenTool.getSingleValue(sql))

                        If totalSUM <= 0 Then
                            Pert = "0%"
                        Else
                            Pert = (FValue / totalSUM * 100).ToString & "%"
                        End If

                        sql = "insert into  financialhistory (ProcessName, TotalFee, Percentage, UserID) Values (" & _
                        GenTool.addbackslash(cboBySector.Items(j).Text) & "," & FValue & "," & GenTool.addbackslash(Pert) & "," & sysDBUser.sysid & ")"

                        ALProcess.Add(sql)

                    Next

                End If

            End If

            If optByState.Checked = True Then

                If cboByState.SelectedIndex > 0 Then

                    sql = "select sum(AmountPaid) from paymentsheet,deviceregistration where deviceregistration.TransCode=paymentsheet.TransCode AND deviceregistration.AccountID=companyID AND deviceregistration.StateID=" & Val(cboByState.SelectedValue)
                    FValue = Val(GenTool.getSingleValue(sql))

                    If totalSUM <= 0 Then
                        Pert = "0%"
                    Else
                        Pert = (FValue / totalSUM * 100).ToString & "%"
                    End If

                    sql = "insert into  financialhistory (ProcessName, TotalFee, Percentage, UserID) Values (" & _
                    GenTool.addbackslash(cboBySector.SelectedItem.Text) & "," & FValue & "," & GenTool.addbackslash(Pert) & "," & sysDBUser.sysid & ")"

                    ALProcess.Add(sql)

                Else

                    For j As Integer = 1 To cboByState.Items.Count - 1

                        sql = "select sum(AmountPaid) from paymentsheet,deviceregistration where deviceregistration.TransCode=paymentsheet.TransCode AND deviceregistration.AccountID=companyID AND deviceregistration.StateID=" & Val(cboByState.Items(j).Value)
                        FValue = Val(GenTool.getSingleValue(sql))

                        If totalSUM <= 0 Then
                            Pert = "0%"
                        Else
                            Pert = (FValue / totalSUM * 100).ToString & "%"
                        End If

                        sql = "insert into  financialhistory (ProcessName, TotalFee, Percentage, UserID) Values (" & _
                        GenTool.addbackslash(cboByState.Items(j).Text) & "," & FValue & "," & GenTool.addbackslash(Pert) & "," & sysDBUser.sysid & ")"

                        ALProcess.Add(sql)

                    Next

                End If

            End If

            If totalSUM > 0 Then
                sql = "insert into  financialhistory (ProcessName, TotalFee, Percentage, UserID) Values ('Total Summary'," & totalSUM & ",'100%'," & sysDBUser.sysid & ")"
            Else
                sql = "insert into  financialhistory (ProcessName, TotalFee, Percentage, UserID) Values ('Total Summary'," & totalSUM & ",'0%'," & sysDBUser.sysid & ")"
            End If
            ALProcess.Add(sql)

            GenTool.ExecuteBulkSQL(ALProcess)

            sql = "select ProcessName,TotalFee,Percentage from financialhistory where UserID=" & sysDBUser.sysid
            Dim ds As DataSet = GenTool.DataSetData(sql)
            filldb(ds)

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)
        End Try
    End Sub

    Private Sub filldb(ByVal ds As DataSet)
        Try
            grd.DataSource = ds.Tables(0)
            grd.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub grd_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grd.PageIndexChanging
        grd.PageIndex = e.NewPageIndex
        Dim ds As DataSet = GenTool.DataSetData(saveSQL)
        filldb(ds)
    End Sub

    Property saveSQL As String
        Get
            Return Session("sql")
        End Get
        Set(ByVal value As String)
            Session("sql") = value
        End Set
    End Property

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
End Class
