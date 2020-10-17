Imports System.Data

Partial Class admauditrial
    Inherits System.Web.UI.Page

    Dim GenTool As NNLN = xsmsCentralToolx.SetTool

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then

            Dim ds As DataSet
            Try
                Dim sql As String = "select sysID,concat(Surname,' ',firstname, ' ',othernames) as Names from systemusers where recordstatus=0 "
                ds = GenTool.DataSetData(sql)
                cbosysUsers.DataValueField = "sysID"
                cbosysUsers.DataTextField = "Names"
                cbosysUsers.DataSource = ds.Tables(0)
                cbosysUsers.DataBind()

            Catch ex As Exception
            Finally
                cbosysUsers.Items.Insert(0, "None")
            End Try


            ds = getCompany()

            Try
                If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then

                    cboCompany.DataValueField = "sysID"
                    cboCompany.DataTextField = "companyName"
                    cboCompany.DataSource = ds.Tables(0)
                    cboCompany.DataBind()

                End If

            Catch ex As Exception
            Finally
                cboCompany.Items.Insert(0, "None")
            End Try
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            Dim sql As String = ""
            Dim w As String = ""
            Dim w1 As String = ""


            If cboCompany.SelectedIndex > 0 Then
                w = "," & GenTool.addbackslash(cboCompany.SelectedItem.Text) & " as CompanyName"
                w1 = " AND companyID=" & Val(cboCompany.SelectedValue)
            End If

            If cbosysUsers.SelectedIndex > 0 Then
                w &= "," & GenTool.addbackslash(cbosysUsers.SelectedItem.Text) & " as SystemUser"
                w1 &= " AND UserID=" & Val(cbosysUsers.SelectedValue)
            End If

            sql = "select Message,Date_Format(RegDate,'%D-%M-%Y') as Date,DATE_FORMAT(RegTime, '%h:%i:%S %p') as Time,ipAddress" & w & " from audit where RegDate>=" & _
                GenTool.addbackslash(txtDPTTo.Text) & " AND RegDate<=" & GenTool.addbackslash(txtDPTTo0.Text) & w1

            saveSQL = sql

            Dim ds As DataSet = GenTool.DataSetData(sql)
            filldb(ds)

        Catch ex As Exception
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

End Class
