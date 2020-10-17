<%@ Page Title="" Language="VB" MasterPageFile="~/adminpage.master" AutoEventWireup="false" CodeFile="admindownloadfiles.aspx.vb" Inherits="downloadsmember" %>

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
            Documents Readily available from registered companies<br />
            click to view or download any document of your choice.</td>
        <td>
            &nbsp;
        </td>
    </tr>

    <tr>
        <td>
            &nbsp;</td>
        <td align="center" colspan="6" 
            style="font-family: 'Courier New', Courier, monospace; font-size: medium; font-weight: bold; font-style: normal; font-variant: normal">
           <hr /></td>
        <td>
            &nbsp;</td>
    </tr>

    <tr>
        <td>
            &nbsp;</td>
        <td align="center" colspan="6" 
            style="font-family: 'Courier New', Courier, monospace; font-size: medium; font-weight: bold; font-style: normal; font-variant: normal">
                                    <asp:Label ID="Label21" runat="server" 
                Font-Names="Calibri" Font-Size="Small" ToolTip="Document Type" 
                                        Text="Document Type:"></asp:Label>
                                    <asp:DropDownList ID="dllDocType" runat="server" AutoPostBack="True" 
                                        ValidationGroup="Document_Type">
                                        <asp:ListItem Selected="True">Export Data Returns</asp:ListItem>
                                        <asp:ListItem>PIA Export Data Returns</asp:ListItem>
                                        <asp:ListItem>Other Documents</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
        <td>
            &nbsp;</td>
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
           
            Dim ds As DataSet = GenTool.DataSetData("select concat(companyName,' | ' ,Description),GFilename,concat(UDate,' ',UTime) from generaluploadfile,companyregistration where generaluploadfile.CompID=companyregistration.sysID AND generaluploadfile.Document_Type=" & GenTool.addbackslash(dllDocType.Text))
            If GenTool.HasDatasetAnyRecord(ds) = False Then
            
                For j As Int32 = 0 To ds.Tables(0).Rows.Count - 1
                    With ds.Tables(0).Rows(j)
                        Response.Write(GenTool.getTR(.Item(0).ToString, .Item(1).ToString, "generaldoc", .Item(2).ToString))
                    End With
                Next
                        
            Else
                Response.Write(GenTool.getTR("No Document Found", "#", "generaldoc"))
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
