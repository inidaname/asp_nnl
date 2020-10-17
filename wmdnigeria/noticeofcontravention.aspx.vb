Imports System.Data

Partial Class admdevicemgt
    Inherits System.Web.UI.Page

    Dim GenTool As NNLN = xsmsCentralToolx.SetTool

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Dim sysDBUser As systemDBUsers = CType(Session("sysDBUser"), systemDBUsers)
            If sysDBUser.devicemdgtright = False Then
                Response.Redirect("administrators.aspx?error=You are not permited to view this interface")
            End If
        Catch ex As Exception
        End Try
 
        If IsPostBack = False Then
            Dim ds As DataSet = getCompany()
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

    Protected Sub cboCompany_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCompany.SelectedIndexChanged
        Try

            Dim Sql As String = "select sysID as ID,typeOfDevice as 'Instrument Type',actualMeasure as Capacity,modelNumber as Model,serialNumber as Serial,manufactureNumber as Manu_Number,deviceAmount as Amount,BarCode,TransCode from deviceregistration " & _
                " Where AccountID=" & Val(cboCompany.SelectedValue.Split("|").ToArray(0))

            Dim ds As DataSet = GenTool.DataSetData(Sql)

            filldb(grd, ds)

            clearME(" AND AccountID=" & Val(cboCompany.SelectedValue.Split("|").ToArray(0)))

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
            txtDeviceID.Text = grd.SelectedRow.Cells(1).Text
        
            clearME(" AND AccountID=" & Val(cboCompany.SelectedValue.Split("|").ToArray(0)) & " AND DeviceID=" & Val(txtDeviceID.Text))

        Catch ex As Exception
        End Try
    End Sub

    Sub clearME(ByVal w As String)
        Dim sql As String = "select Sections,DescriptionOfOffenses as Offenses,Date_Format(InvitationDate,'%D-%M-%Y') as IVDate,DATE_FORMAT(InvitationTime,'%h:%i:%S %p')as IVTime,NameCompanyRep as CompanyRep,DesignationCompReg as Designation,WPNoticeNumber,ActionRecommeddedBy as RecommendedBY,ActionApprovedName as ApprovedBy from contraventionnotice where DeviceID<>-9455 " & w
        Dim ds As DataSet = GenTool.DataSetData(sql)
        filldb(grdinvioce, ds)
    End Sub

    Dim FN As String = ""
    Dim FV As String = ""
    Dim FUpdate As String = ""
     
    Protected Sub grdinvioce_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdinvioce.PageIndexChanging
        grdinvioce.PageIndex = e.NewPageIndex
    End Sub

End Class
