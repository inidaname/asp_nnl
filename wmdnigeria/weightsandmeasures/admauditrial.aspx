<%@ Page Title="AUDIT TRAIL" Language="VB" MasterPageFile="~/adminpage.master" AutoEventWireup="false" CodeFile="admauditrial.aspx.vb" Inherits="admauditrial" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:Panel ID="Panel1" runat="server">

  <table style="width: 100%;">
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td class="style2" style="width: 347px">
                    &nbsp;</td>
                <td style="width: 120px">
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
                    &nbsp;
                </td>
                <td class="style2" style="width: 347px">
                    &nbsp;</td>
                <td style="width: 120px">
                    <asp:Label ID="Label1" runat="server" Text="Select Date From" 
                        Font-Names="Calibri" Font-Size="Small"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDPTTo" runat="server" BorderStyle="Solid" BorderWidth="1px" 
                        Font-Bold="False" Font-Names="Calibri" Font-Size="Small" Height="20px" 
                        ValidationGroup="inspDate|Invalid inspection date" Width="80px"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" 
                        Format="yyyy-MM-dd" PopupButtonID="childimgbtnCal" TargetControlID="txtDPTTo">
                    </cc1:CalendarExtender>
                    <asp:ImageButton ID="childimgbtnCal" runat="server" Height="16px" 
                        ImageUrl="~/img/cal3.png" ValidationGroup="dd" Width="16px" />
                </td>
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
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td class="style2" style="width: 347px">
                    &nbsp;</td>
                <td style="width: 120px">
                    <asp:Label ID="Label2" runat="server" Text="Date To:" Font-Names="Calibri" 
                        Font-Size="Small"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDPTTo0" runat="server" BorderStyle="Solid" 
                        BorderWidth="1px" Font-Bold="False" Font-Names="Calibri" Font-Size="Small" 
                        Height="20px" ValidationGroup="inspDate|Invalid inspection date" Width="80px"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" 
                        Format="yyyy-MM-dd" PopupButtonID="childimgbtnCal0" TargetControlID="txtDPTTo0">
                    </cc1:CalendarExtender>
                    <asp:ImageButton ID="childimgbtnCal0" runat="server" Height="16px" 
                        ImageUrl="~/img/cal3.png" ValidationGroup="dd" Width="16px" />
                </td>
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
                <td class="style2" style="width: 347px">
                    &nbsp;</td>
                <td style="width: 120px">
                    <asp:Label ID="Label3" runat="server" Font-Names="Calibri" Font-Size="Small" 
                        Text="Search By Company:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="cboCompany" runat="server" AutoPostBack="True" 
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
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td class="style2" style="width: 347px">
                    &nbsp;</td>
                <td style="width: 120px">
                    <asp:Label ID="Label4" runat="server" Font-Names="Calibri" Font-Size="Small" 
                        Text="Search By Users:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="cbosysUsers" runat="server" AutoPostBack="True" 
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
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td class="style2" style="width: 347px">
                    &nbsp;</td>
                <td style="width: 120px">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" />
                </td>
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
                <td class="style2" style="width: 347px">
                    &nbsp;</td>
                <td style="width: 120px">
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
                <td align="center" colspan="7">
                    <asp:GridView ID="grd" runat="server" AllowPaging="True" BackColor="White" 
                        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="2" 
                        CellSpacing="2" EmptyDataText="NO RECORD FOUND" EnableModelValidation="True" 
                        Font-Names="Calibri" Font-Size="Small" GridLines="Vertical" Height="90px" 
                        PageSize="40" ShowFooter="True" Width="100%">
                        <AlternatingRowStyle BackColor="#DCDCDC" />
                        <EmptyDataRowStyle Font-Names="Agency FB" Font-Size="Small" 
                            HorizontalAlign="Center" VerticalAlign="Top" />
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <HeaderStyle BackColor="#000084" Font-Bold="True" Font-Names="Calibri" 
                            Font-Size="Small" ForeColor="White" HorizontalAlign="Left" 
                            VerticalAlign="Top" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="center" />
                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" HorizontalAlign="left" 
                            VerticalAlign="Top" />
                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td class="style2" style="width: 347px">
                    &nbsp;</td>
                <td style="width: 120px">
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
        </asp:Panel>
      
    </ContentTemplate>
</asp:UpdatePanel>

</asp:Content>

