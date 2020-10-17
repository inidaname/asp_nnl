<%@ Page Title="EXPORT DATA HISTORY" Language="VB" AutoEventWireup="false" MasterPageFile="~/companynoheader.master" CodeFile="apphistory.aspx.vb" Inherits="exportpermit" %>

<%@ Import Namespace="System.Data" %>

 <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<!--start home-->

<div id="item1">
	 
  <div class="item_title">&nbsp;&nbsp;&nbsp; EXPORT PERMIT HISTORY FILE</div>
</div>
 <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div id="item_left" style="100%: ;"100%"  >
      
      <table style="width: 298%;">
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;</td>
                <td style="width: 435px">
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
                 <td align="right" style="width: 435px">
                     <asp:Label ID="Label2" runat="server" Font-Names="Calibri" Font-Size="Small" 
                         Text="Select Import History Name:"></asp:Label>
                 </td>
                 <td>
                     <asp:DropDownList ID="cboExportPermit" runat="server" AutoPostBack="True" 
                         Font-Names="Calibri" Font-Size="Small">
                     </asp:DropDownList>
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
             <tr>
                 <td>
                     &nbsp;</td>
                 <td>
                     &nbsp;</td>
                 <td>
                     &nbsp;</td>
                 <td style="width: 435px">
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
                    &nbsp;
                </td>
                <td colspan="8">
                    &nbsp;
                    <asp:GridView ID="grd" runat="server" AllowPaging="True" BackColor="White" 
                        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="2" 
                        CellSpacing="2" EmptyDataText="NO RECORD FOUND" EnableModelValidation="True" 
                        Font-Names="Calibri" Font-Size="Small" GridLines="Vertical" Height="166px" 
                        PageSize="20" ShowFooter="True" Width="100%">
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
                <td>
                    &nbsp;</td>
                <td style="width: 435px">
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
                    &nbsp;
                </td>
            </tr>
        </table>
      
      </div>

    </ContentTemplate>
</asp:UpdatePanel>

     
    

</asp:Content>         