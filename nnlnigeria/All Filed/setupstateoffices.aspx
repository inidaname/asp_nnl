<%@ Page Title="State Offices" Language="VB" MasterPageFile="~/adminpage.master" AutoEventWireup="false" CodeFile="setupstateoffices.aspx.vb"  EnableEventValidation="false" ValidateRequest ="false" Inherits="setupstateoffices" %>


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
                                <td>
                                    &nbsp;</td>
                                <td bgcolor="#99A6B4" colspan="5">
                                    <div class="item_title">&nbsp;&nbsp;&nbsp;Setup State Address</div>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label20" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="State Name:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtfilename0" runat="server" MaxLength="30" 
                                        ValidationGroup="StateName|Invalid State Name" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="lblfilepath1" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" Text="Contact Person:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtfilename4" runat="server" MaxLength="30" 
                                        ValidationGroup="ContactPersonName|" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="lblfilepath" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" Text="Address:"></asp:Label>
                                </td>
                                <td align="left">
                                 <%--   <cc1:AsyncFileUpload ID="fdb" runat="server" Width="204px"  />--%>
                                    <asp:TextBox ID="txtfilename1" runat="server" Height="56px" MaxLength="30" 
                                        TextMode="MultiLine" ValidationGroup="StateAddress|Invalid State Address" 
                                        Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label11" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Contact Person's Mobile"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtfilename" runat="server" MaxLength="30" 
                                        ValidationGroup="ContactPersonMobile|" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="lblfilepath0" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" Text="Electronic Address:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtfilename3" runat="server" Height="52px" MaxLength="30" 
                                        TextMode="MultiLine" ValidationGroup="Contacts|Invalid Contact" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label21" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Google Map Link:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtfilename2" runat="server" Height="54px" MaxLength="30" 
                                        TextMode="MultiLine" ValidationGroup="googlemapLink|" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left">
                                    &nbsp;</td>
                                <td align="center">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                                <td>
                                    <asp:Button ID="btnPreview" runat="server" style="height: 26px" Text="Save" />
                                    <cc1:ConfirmButtonExtender ID="btnPreview_ConfirmButtonExtender" runat="server" 
                                        ConfirmOnFormSubmit="True" 
                                        ConfirmText="Are you sure you want to UPLOAD this File?" Enabled="True" 
                                        TargetControlID="btnPreview">
                                    </cc1:ConfirmButtonExtender>
                                </td>
                                <td>
                                    <asp:Button ID="btnReset" runat="server" Text="Reset" />
                                    <cc1:ConfirmButtonExtender ID="btnReset_ConfirmButtonExtender" runat="server" 
                                        ConfirmOnFormSubmit="True" 
                                        ConfirmText="Are you sure you want to CLEAR this form" Enabled="True" 
                                        TargetControlID="btnReset">
                                    </cc1:ConfirmButtonExtender>
                                    &nbsp;&nbsp;&nbsp;
                                </td>
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
                                                        Font-Names="Calibri" Font-Size="Small" GridLines="Vertical" PageSize="20" 
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


