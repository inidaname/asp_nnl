<%@ Page Title="FRONT PAGE SETUP" Language="VB" MasterPageFile="~/adminpage.master" AutoEventWireup="True" CodeFile="frontpagelastestnewssetup.aspx.vb" Inherits="frontpagelastestnewssetup" EnableEventValidation="false"  ValidateRequest ="false"  %>
<%@ Import Namespace="System.Data" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc2" %>

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
                                <td>
                                    &nbsp;</td>
                                <td bgcolor="#99A6B4" colspan="5">
                                    <div class="item_title">&nbsp;&nbsp;&nbsp;MANAGE FRONT PAGE</div>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="right" style="width: 245px">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="Label21" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Setup Name:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="cboGroupName" runat="server" 
                                        Font-Names="Calibri" Font-Size="Small" 
                                        ValidationGroup="ISPID|Invalid ISP Selection|1" Width="210px">
                                        <asp:ListItem>SELECT VALUE</asp:ListItem>
                                        <asp:ListItem>LATEST NEWS</asp:ListItem>
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
                                <td style="height: 16px">
                                    </td>
                                <td style="width: 245px; height: 16px;" align="right">
                                    <asp:Label ID="Label22" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Headline:"></asp:Label>
                                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                                <td align="left" style="height: 16px">
                                    <asp:TextBox ID="txtHeadline" runat="server" Width="204px" 
                                        style="margin-left: 0px"></asp:TextBox>
                                    <asp:CheckBox ID="chkshow" runat="server" Checked="True" Font-Bold="True" 
                                        Font-Names="Calibri" Font-Overline="False" Font-Size="Small" Text="Show?" 
                                        ValidationGroup="RecordStatus" />
                                </td>
                                <td style="height: 16px">
                                    </td>
                                <td style="height: 16px">
                                    </td>
                                <td style="height: 16px">
                                    </td>
                                <td style="height: 16px">
                                    </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="right" style="width: 245px">
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label23" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Full Message Body"></asp:Label>
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
                                <td align="center" colspan="5">
                              
                                    <cc2:Editor ID="txtMessage" runat="server" Height="300px" NoScript="True" 
                                        Width="100%" />
                              
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="right" style="width: 245px">
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
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="right" style="width: 245px">
                                    <asp:Button ID="btnsetup" runat="server" Text="Upload Changes" Visible="true" 
                                        Width="120px" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnReset" runat="server" Text="Reset" Visible="true" 
                                        Width="80px" />
                                    <cc1:ConfirmButtonExtender ID="btnReset_ConfirmButtonExtender" runat="server" 
                                        ConfirmOnFormSubmit="True" 
                                        ConfirmText="Are you sure you want to reset this form" Enabled="True" 
                                        TargetControlID="btnReset">
                                    </cc1:ConfirmButtonExtender>
                                </td>
                                <td align="center">
                                    <asp:Button ID="btnSendMessage" runat="server" Text="Save Record" />
                                    <cc1:ConfirmButtonExtender ID="btnSendMessage_ConfirmButtonExtender" 
                                        runat="server" ConfirmOnFormSubmit="True" 
                                        ConfirmText="Are you sure you want to Save this record?" Enabled="True" 
                                        TargetControlID="btnSendMessage">
                                    </cc1:ConfirmButtonExtender>
                                </td>
                                <td>
                                    <asp:Button ID="btnDelete" runat="server" Text="Delete Record" Visible="false" 
                                        Width="100px" />
                                    <cc1:ConfirmButtonExtender ID="btnDelete_ConfirmButtonExtender" runat="server" 
                                        ConfirmOnFormSubmit="True" 
                                        ConfirmText="Are you sure you want to DELETE this record" Enabled="True" 
                                        TargetControlID="btnDelete">
                                    </cc1:ConfirmButtonExtender>
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
                                <td align="right" style="width: 245px">
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
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td colspan="5">
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
                                                        Font-Names="Calibri" Font-Size="Small" GridLines="Vertical" PageSize="15" 
                                                        ShowFooter="True" Width="100%">
                                                        <AlternatingRowStyle BackColor="#DCDCDC" />
                                                        <Columns>
                                                            <asp:CommandField HeaderText="Action" SelectText="Edit" 
                                                                ShowSelectButton="True" />
                                                        </Columns>
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
                                <td>
                                    &nbsp;</td>
                                <td style="width: 245px">
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

