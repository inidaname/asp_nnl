<%@ Page Title="" Language="VB" MasterPageFile="~/companynoheader.master" AutoEventWireup="false" CodeFile="downloadsmember.aspx.vb" Inherits="downloadsmember" %>

<%@ Import Namespace="System.Data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>

    <table style="width: 100%;">

    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>

    <tr>
        <td>
            &nbsp;</td>
        <td align="center" colspan="6" 
            style="font-family: 'Courier New', Courier, monospace; font-size: medium; font-weight: bold; font-style: normal; font-variant: normal">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
        <td align="center" colspan="6" 
            style="font-family: 'Courier New', Courier, monospace; font-size: medium; font-weight: bold; font-style: normal; font-variant: normal">
            Documents Readily available for registered companies<br />
            click to view or download any document of your choice.</td>
        <td>
            &nbsp;
        </td>
    </tr>

    <tr>
        <td>
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
        <td colspan="5">
           <hr /></td>
        <td>
            &nbsp;
        </td>
    </tr>

    <%
        Dim GenTool As NNLN = xsmsCentralToolx.SetTool
        Try
           
            Dim ds As DataSet = GenTool.DataSetData("select description,FileName from downloadcenter where d_type='REGISTERED MEMBERS'  AND RecordStatus=1")
            If GenTool.HasDatasetAnyRecord(ds) = False Then
            
                For j As Int32 = 0 To ds.Tables(0).Rows.Count - 1
                    With ds.Tables(0).Rows(j)
                        Response.Write(GenTool.getTR(.Item(0).ToString, .Item(1).ToString, "downloadsmember"))
                    End With
                Next
                        
            Else
                Response.Write(GenTool.getTR("No Document Found", "#", "downloadsmember"))
            End If
        
        Catch ex As Exception
            GenTool.GrabError(ex.Message, "download for members")
        End Try
        
        %>


        <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>


        <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>

    </center>

</asp:Content>
