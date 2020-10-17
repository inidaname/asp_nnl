Imports System.Data

Partial Class admcompanyreports
    Inherits System.Web.UI.Page

    Dim GenTool As NNLN = xsmsCentralToolx.SetTool

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

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            getCompanyStaticData()
        End If
    End Sub

    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        Dim w, w1 As String
        w1 = ""
        w = ",(select stateName from tblstate where sysID=companyregistration.StateID) as State,(select LGA from tbllga where sysID=companyregistration.LGAID) as LGA,(select city from tblcity where sysID=companyregistration.cityID) as CIty"

        GenTool.getWhereSQL(Panel1, w1, chkWilCard.Checked)

        If w1 <> "" Then
            w1 = " where " & w1
        End If

        saveSQL = "select CompanyName,StreetAddress,CompanyEmail as Email,Telephone" & w & ",FilledBy,representativeName as RepName,Date_Format(RegDate,'%D-%M-%Y')  as Date from companyregistration " & _
           w1

        Dim ds As DataSet = GenTool.DataSetData(saveSQL)
        filldb(ds)
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

    Protected Sub btnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click
        GenTool.resetform(Panel1)
    End Sub

    Protected Sub grd_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grd.SelectedIndexChanged

    End Sub
End Class
