Imports System.Data

Partial Class exportpermit
    Inherits System.Web.UI.Page

    Dim GenTool As NNLN = xsmsCentralToolx.SetTool

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Try
                Dim sd As String = "select concat(CompanyID,'|',sysID) as ID,ImportName from exportdatareturn where CompanyID=" & Val(Session("ID")) & " group by ImportName"

                Dim ds As DataSet = GenTool.DataSetData(sd)

                cboExportPermit.Items.Clear()

                cboExportPermit.DataValueField = "ID"
                cboExportPermit.DataTextField = "ImportName"
                cboExportPermit.DataSource = ds.Tables(0)
                cboExportPermit.DataBind()

            Catch ex As Exception
                GenTool.GrabError(ex.Message, "Page_Load")
            Finally
                cboExportPermit.Items.Insert(0, "Select Import Name")
            End Try
        End If

    End Sub

    Protected Sub cboExportPermit_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboExportPermit.SelectedIndexChanged
        Try
            Dim sql As String = "select CompanyName,Productname,TotalAmtUS,AmtUsedUS,TotalAmtNig,AmtUsedNGN,CargoName,Date_Format(exportdatareturn.regDate,'%D-%M-%Y') as Date ,Destination,ProceedNGN,ProceedUS,PricePerBarrel as 'Amt/Barrel' from exportdatareturn,companyregistration,exportpermit where exportdatareturn.CompanyID=companyregistration.sysID AND exportdatareturn.exportPermitID=exportpermit.sysID AND exportpermit.CompanyID=companyregistration.sysID " & _
                " AND exportdatareturn.CompanyID=" & cboExportPermit.SelectedValue.Split("|").ToArray(1)

            Try
                Dim ds As DataSet = GenTool.DataSetData(sql)
                grd.DataSource = ds.Tables(0)
                grd.DataBind()
            Catch ex As Exception
            End Try

        Catch ex As Exception
            GenTool.GrabError(ex.Message, "cboExportPermit_SelectedIndexChanged")
        End Try
    End Sub

    Protected Sub grd_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grd.PageIndexChanging
        grd.PageIndex = e.NewPageIndex
    End Sub

 
End Class
