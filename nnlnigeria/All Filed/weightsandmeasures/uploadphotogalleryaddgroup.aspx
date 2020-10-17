<%@ Page Title="Upload Photo Gallery" Language="VB" MasterPageFile="~/adminpage.master" AutoEventWireup="True" CodeFile="uploadphotogalleryaddgroup.aspx.vb" EnableEventValidation ="false" Inherits="uploadphotogallery"   %>
<%@ Import Namespace="System.Data" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!--start home-->
<div id="item1">
	   <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                            </cc1:ToolkitScriptManager>
 
    	<div>     
  
      <center>
      
    <div style="width : 75%" id="main-menu">
        <%--   <cc1:AsyncFileUpload ID="fdb" runat="server" Width="204px"  />--%>
        <div class="item_title"><asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></div>
                <div id="item2">
                    
              
               
                    <asp:Panel ID="Panel1" runat="server">
                        <table style="width:100%;" cellspacing="1" cellpadding="0">
                        
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td bgcolor="#99A6B4" colspan="5" align ="center">
                                    <div class="item_title">&nbsp;&nbsp;&nbsp;ADD CATEGORY</div>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td align="right" style="width: 242px">
                                 <%--   <cc1:AsyncFileUpload ID="fdb" runat="server" Width="204px"  />--%>
                                    <asp:Label ID="Label20" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Enter Phot Group:"></asp:Label>
                                </td>
                                <td align="left">
                                    
                                    <asp:TextBox ID="txtphotoGroupName" runat="server" ValidationGroup="groupname" 
                                        Width="204px"></asp:TextBox>
                                    <asp:CheckBox ID="chkShow" runat="server" Checked="True" Font-Bold="True" 
                                        Font-Names="Calibri" Font-Overline="False" Font-Size="Small" Text="Show?" 
                                        ValidationGroup="Status" />
                                </td>
                                <td align="left" colspan="2">
                                    <asp:TextBox ID="txtGroupdID" runat="server" ValidationGroup="GStatus" 
                                        Visible="False" Width="28px">0</asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left">
                                    &nbsp;</td>
                                <td align="left" style="width: 242px">
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Button ID="btnPreview" runat="server" style="height: 26px" Text="Submit" />
                                    <cc1:ConfirmButtonExtender ID="btnPreview_ConfirmButtonExtender" runat="server" 
                                        ConfirmOnFormSubmit="True" 
                                        ConfirmText="Are you sure you want to SAVE this record?" Enabled="True" 
                                        TargetControlID="btnPreview">
                                    </cc1:ConfirmButtonExtender>
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnReset" runat="server" Text="Reset" />
                                    <cc1:ConfirmButtonExtender ID="btnReset_ConfirmButtonExtender" runat="server" 
                                        ConfirmOnFormSubmit="True" 
                                        ConfirmText="Are you sure you want to CLEAR this form" Enabled="True" 
                                        TargetControlID="btnReset">
                                    </cc1:ConfirmButtonExtender>
                                </td>
                                <td align="left" style="width: 240px">
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
                                <td>
                                    &nbsp;</td>
                                <td style="width: 242px">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td style="width: 240px">
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
                                                        CellSpacing="2" EmptyDataText="NO RECORDS FOUND" 
                                                        EnableModelValidation="True" Font-Names="Calibri" Font-Size="Small" 
                                                        GridLines="Vertical" PageSize="20" ShowFooter="True" Width="100%">
                                                        <AlternatingRowStyle BackColor="#DCDCDC" />
                                                        <Columns>
                                                            <asp:CommandField HeaderText="Select" SelectText="Edit" 
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
                                <td>
                                    &nbsp;</td>
                                <td style="width: 242px">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td style="width: 240px">
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

