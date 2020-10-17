<%@ Page Title="IMPORT EXPORT HISTORY DATA" Language="VB" AutoEventWireup="false"  MasterPageFile="~/adminpage.master"  CodeFile="admimportexceldata.aspx.vb" Inherits="admimportexceldata" %>

<%@ Import Namespace="System.Data" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>

<div id="item1">
	 
  <div class="item_title">&nbsp;&nbsp;&nbsp; IMPORT HISORY DATA >>> (<asp:Label 
          ID="lblaction" runat="server" Text="Label"></asp:Label>
      )</div>
    
</div>

   <div id="item_left"  style="width: 100%;"  >

 <asp:Panel ID="Panel1" runat="server">

    <table style="width: 100%;">
        <tr>
            <td> 
                   &nbsp;</td>
            <td>
                &nbsp;
            </td>
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
            <td align="center" colspan="5">
                <asp:Button ID="btnSample" runat="server" Text="Download Sample Excel Sheet" />
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;
            </td>
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
            <td align="center" colspan="5">
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
                &nbsp;
            </td>
            <td>
            
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td align="center" colspan="11">
                <asp:Panel ID="Panel2" runat="server">

                    <asp:Label ID="Label1" runat="server" Font-Names="Calibri" Font-Size="Small" 
                        Text="Select Excel File: "></asp:Label>
&nbsp;
                    <cc1:AsyncFileUpload ID="uploadTextFile" runat="server" 
                        FailedValidation="False" Height="20px" PersistFile="True" Width="200px" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnViewExcel" runat="server" Text="Extract" />

                </asp:Panel>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;
            </td>
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
            <td align="center">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="style2" style="width: 183px">
                &nbsp;</td>
            <td style="width: 105px">
                &nbsp;</td>
            <td align="left">
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
            <td align="center">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="style2" style="width: 183px">
                &nbsp;</td>
            <td style="width: 105px">
                <asp:Label ID="Label2" runat="server" Text="Balance NGN:"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtBalNGN" runat="server" BackColor="#FF6600" 
                    Font-Names="Calibri" Font-Size="Small" ReadOnly="True" Width="155px"></asp:TextBox>
            </td>
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
            <td align="center">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="style2" style="width: 183px">
                &nbsp;</td>
            <td style="width: 105px">
                <asp:Label ID="Label4" runat="server" Text="Balance US:"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtBalUS" runat="server" Font-Names="Calibri" 
                    Font-Size="Small" ReadOnly="True" Width="155px"></asp:TextBox>
            </td>
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
            <td align="center">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="style2" style="width: 183px">
                &nbsp;</td>
            <td style="width: 105px">
                <asp:Label ID="Label3" runat="server" Text="Total Amount NGN:"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtNGN" runat="server" BackColor="#FF6600" 
                    Font-Names="Calibri" Font-Size="Small" ReadOnly="True" Width="155px"></asp:TextBox>
            </td>
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
            <td align="center">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="style2" style="width: 183px">
                &nbsp;</td>
            <td style="width: 105px">
                <asp:Label ID="Label5" runat="server" Text="Total Amount US:"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtUS" runat="server" Font-Names="Calibri" Font-Size="Small" 
                    ReadOnly="True" Width="155px"></asp:TextBox>
            </td>
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
            <td align="center">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="style2" style="width: 183px">
                &nbsp;</td>
            <td style="width: 105px">
                &nbsp;</td>
            <td align="left">
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
            <td align="center">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="style2" style="width: 183px">
                &nbsp;</td>
            <td style="width: 105px">
                <asp:Label ID="Label6" runat="server" Text="Enter Given Name:"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtGivenName" runat="server" Width="204px"></asp:TextBox>
            </td>
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
            <td align="center">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="style2" colspan="3">
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
            <td align="center" colspan="11">
                <asp:GridView ID="grdExcel" runat="server" AllowPaging="True" BackColor="White" 
                    BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="2" 
                    CellSpacing="2" EmptyDataText="NO REGISTERED INSTRUMENT" 
                    EnableModelValidation="True" Font-Names="Calibri" Font-Size="Small" 
                    GridLines="Vertical" PageSize="20" ShowFooter="True" Width="100%">
                    <AlternatingRowStyle BackColor="#DCDCDC" />
                    <EmptyDataRowStyle Font-Names="Agency FB" Font-Size="Small" 
                        HorizontalAlign="Center" VerticalAlign="Top" />
                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <HeaderStyle BackColor="#000084" Font-Bold="True" Font-Names="Calibri" 
                        Font-Size="Small" ForeColor="White" HorizontalAlign="Center" 
                        VerticalAlign="Top" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" HorizontalAlign="Center" 
                        VerticalAlign="Top" />
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </td>
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
            <td align="center" colspan="5">
                <asp:Button ID="btnSave" runat="server" Text="Save Record" />
                <cc1:ConfirmButtonExtender ID="btnSave_ConfirmButtonExtender" runat="server" 
                    ConfirmOnFormSubmit="True" 
                    ConfirmText="Are you sure you want to SAVE this transaction" Enabled="True" 
                    TargetControlID="btnSave">
                </cc1:ConfirmButtonExtender>
            </td>
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

 </asp:Panel>

 </div>
   
</asp:Content>          

