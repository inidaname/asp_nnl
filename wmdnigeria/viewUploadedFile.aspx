<%@ Page Title="" Language="VB" MasterPageFile="~/adminpage.master" AutoEventWireup="false" CodeFile="viewUploadedFile.aspx.vb" ValidateRequest ="false"  EnableEventValidation="false"  Inherits="viewUploadedFile" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!--start home-->
<div id="item1">
	   <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                            </cc1:ToolkitScriptManager>
 
    	<div>     
  
      <center>
      
    <div style="width : 75%" id="main-menu">
        <%--   </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnPreview" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="cboISP" EventName="SelectedIndexChanged" />
             </Triggers>
                </asp:UpdatePanel>--%>
        <div class="item_title"><asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></div>
                <div id="item2">
                    
              
               
                    <asp:Panel ID="Panel1" runat="server">
                        <table style="width:100%;" cellspacing="1" cellpadding="0">
                        
                            <tr>
                                <td class="style1" style="width: 10px">
                                    &nbsp;</td>
                                <td bgcolor="#99A6B4" colspan="8">
                                    <div class="item_title">&nbsp;&nbsp;&nbsp;VIEW UPLOADED FILES</div>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style1" style="width: 10px">
                                    &nbsp;</td>
                                <td align="left" style="width: 183px">
                                    &nbsp;</td>
                                <td align="center" style="width: 137px">
                                    &nbsp;</td>
                                <td align="left" style="width: 51px">
                                    &nbsp;</td>
                                <td style="width: 169px" align="left">
                                    <asp:CheckBox ID="chkComp" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" Text="Include Company" />
                                </td>
                                <td style="width: 72px">
                                    <asp:DropDownList ID="ddlCompany" runat="server" Width="204px" 
                                        Font-Names="Calibri" Font-Size="Small">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 72px">
                                    &nbsp;</td>
                                <td style="width: 85px">
                                    &nbsp;</td>
                                <td style="width: 139px">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style1" style="width: 10px">
                                    &nbsp;</td>
                                <td align="left" style="width: 183px">
                                    &nbsp;</td>
                                <td align="center" style="width: 137px">
                                    &nbsp;</td>
                                <td align="left" style="width: 51px">
                                    &nbsp;</td>
                                <td style="width: 169px" align="left">
                                    <asp:CheckBox ID="chkISP" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Include ISP:" />
                                </td>
                                <td style="width: 72px">
                                    <asp:DropDownList ID="ddlISP" runat="server" Width="204px" Font-Names="Calibri" 
                                        Font-Size="Small">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 72px">
                                    &nbsp;</td>
                                <td style="width: 85px">
                                    &nbsp;</td>
                                <td style="width: 139px">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style1" style="width: 10px">
                                    &nbsp;</td>
                                <td align="left" style="width: 183px">
                                    &nbsp;</td>
                                <td align="center" style="width: 137px">
                                    &nbsp;</td>
                                <td align="left" style="width: 51px">
                                    &nbsp;</td>
                                <td style="width: 169px" align="left">
                                    <asp:Label ID="Label1" runat="server" Text="Date From:" Font-Names="Calibri" 
                                        Font-Size="Small"></asp:Label>
                                </td>
                                <td style="width: 72px" align="left">
                                    <asp:TextBox ID="txtDPTFrom" runat="server" BorderStyle="Solid" BorderWidth="1px" 
                                        Font-Bold="False" Font-Names="Calibri" Font-Size="Small" Height="20px" 
                                        ValidationGroup="inspDate|Invalid inspection date" Width="80px"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" enabled="True" 
                                        format="yyyy-MM-dd" popupbuttonid="childimgbtnCal" 
                                        targetcontrolid="txtDPTFrom">
                                    </cc1:CalendarExtender>
                                    <asp:ImageButton ID="childimgbtnCal" runat="server" Height="16px" 
                                        ImageUrl="~/img/cal3.png" ValidationGroup="dd" Width="16px" />
                                </td>
                                <td style="width: 72px">
                                    &nbsp;</td>
                                <td style="width: 85px">
                                    &nbsp;</td>
                                <td style="width: 139px">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style1" style="width: 10px">
                                    &nbsp;</td>
                                <td align="left" style="width: 183px">
                                    &nbsp;</td>
                                <td align="center" style="width: 137px">
                                    &nbsp;</td>
                                <td align="left" style="width: 51px">
                                    &nbsp;</td>
                                <td style="width: 169px" align="left">
                                    <asp:Label ID="Label2" runat="server" Text="Date To:" Font-Names="Calibri" 
                                        Font-Size="Small"></asp:Label>
                                </td>
                                <td style="width: 72px" align="left">
                                    <asp:TextBox ID="txtDPTTo" runat="server" BorderStyle="Solid" 
                                        BorderWidth="1px" Font-Bold="False" Font-Names="Calibri" Font-Size="Small" 
                                        Height="20px" ValidationGroup="inspDate|Invalid inspection date" 
                                        Width="80px"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" 
                                        Format="yyyy-MM-dd" PopupButtonID="childimgbtnCal0" 
                                        TargetControlID="txtDPTTo">
                                    </cc1:CalendarExtender>
                                    <asp:ImageButton ID="childimgbtnCal0" runat="server" Height="16px" 
                                        ImageUrl="~/img/cal3.png" ValidationGroup="dd" Width="16px" />
                                </td>
                                <td style="width: 72px">
                                    &nbsp;</td>
                                <td style="width: 85px">
                                    &nbsp;</td>
                                <td style="width: 139px">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style1" style="width: 10px">
                                    &nbsp;</td>
                                <td align="left" style="width: 183px">
                                    &nbsp;</td>
                                <td align="center" style="width: 137px">
                                    &nbsp;</td>
                                <td align="left" style="width: 51px">
                                    &nbsp;</td>
                                <td style="width: 169px" align="left">
                                    <asp:Label ID="Label3" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Read Status:"></asp:Label>
                                </td>
                                <td align="left" style="width: 72px">
                                    <asp:DropDownList ID="ddlReadStatus" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" Width="204px">
                                        <asp:ListItem>All</asp:ListItem>
                                        <asp:ListItem>Read</asp:ListItem>
                                        <asp:ListItem>UnRead</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 72px">
                                    &nbsp;</td>
                                <td style="width: 85px">
                                    &nbsp;</td>
                                <td style="width: 139px">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style1" style="width: 10px">
                                </td>
                                <td align="left" style="width: 183px">
                                    &nbsp;</td>
                                <td align="center" style="width: 137px">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                                <td style="width: 51px">
                                    &nbsp;</td>
                                <td style="width: 169px">
                                    &nbsp;</td>
                                <td style="width: 72px">
                                    <asp:Button ID="btnSearch" runat="server" style="height: 26px" 
                                        Text="Search Records" Width="100px" />

                 &nbsp;&nbsp;
                                <asp:Button ID="btnReset" runat="server" Text="Reset" />
                             
                                <td style="width: 72px">
                              
                                </td>
                                <td style="width: 85px">
                                    &nbsp;
                                </td>
                                <td style="width: 139px">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style1" style="width: 10px">
                                    &nbsp;</td>
                                <td align="left" style="width: 183px">
                                    &nbsp;</td>
                                <td align="center" style="width: 137px">
                                    &nbsp;</td>
                                <td style="width: 51px">
                                    &nbsp;</td>
                                <td style="width: 169px">
                                    &nbsp;</td>
                                <td style="width: 72px">
                                    &nbsp;</td>
                                <td style="width: 72px">
                                    &nbsp;</td>
                                <td style="width: 85px">
                                    &nbsp;</td>
                                <td style="width: 139px">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style1" style="width: 10px">
                                    &nbsp;</td>
                                <td colspan="8">
                                    <asp:Panel ID="Panel3" runat="server" BackColor="Gainsboro">
                                        <table cellpadding="0" cellspacing="1" style="width:100%;">
                                            <tr>
                                                <td colspan="7" style="background-color: #99A6B4">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="7" style="background-color: #99A6B4">
                                                    <asp:GridView ID="grd" runat="server" AllowPaging="True" BackColor="White" 
                                                        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="2" 
                                                        CellSpacing="2" EmptyDataText="NO RECORDS FOUND" EnableModelValidation="True" 
                                                        Font-Names="Calibri" Font-Size="Small" GridLines="Vertical" PageSize="30" 
                                                        ShowFooter="True" Width="100%">
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
                                            </tr>
                                            <tr>
                                                <td colspan="7" style="background-color: #99A6B4">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style5">
                                                    &nbsp;</td>
                                                <td class="style23" title="background-color:#99A6B4">
                                                    &nbsp;</td>
                                                <td class="style22">
                                                    &nbsp;</td>
                                                <td class="style8">
                                                    &nbsp;</td>
                                                <td class="style31">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style1" style="width: 10px">
                                    &nbsp;</td>
                                <td style="width: 183px">
                                    &nbsp;</td>
                                <td style="width: 137px">
                                    &nbsp;</td>
                                <td style="width: 51px">
                                    &nbsp;</td>
                                <td style="width: 169px">
                                    &nbsp;</td>
                                <td style="width: 72px">
                                    &nbsp;</td>
                                <td style="width: 72px">
                                    &nbsp;</td>
                                <td style="width: 85px">
                                    &nbsp;</td>
                                <td style="width: 139px">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>   
                  
                </div>
<%--   </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnPreview" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="cboISP" EventName="SelectedIndexChanged" />
             </Triggers>
                </asp:UpdatePanel>--%>
    </div>
     </center>
</div>

        
</div>
    

<!--end home-->
</asp:Content>
