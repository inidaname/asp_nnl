<%@ Page Title="LGA ASSIGNMENT" Language="VB" MasterPageFile="~/adminpage.master" AutoEventWireup="True" CodeFile="manageISPLGA.aspx.vb" Inherits="manageISPLGA" EnableEventValidation="false"  ValidateRequest ="false"  %>
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
        <%--  <asp:ConfirmButtonExtender ID="btnSave_ConfirmButtonExtender" runat="server" 
                                                        ConfirmOnFormSubmit="True" 
                                                        ConfirmText="Are you sure you want to UPDATE this record" Enabled="True" 
                                                        TargetControlID="btnSave">
                                                    </asp:ConfirmButtonExtender></td>--%>
        <div class="item_title"><asp:Label ID="lblMsg" runat="server" ForeColor="#990000"></asp:Label></div>
                <div id="item2">
                    
              
               
                    <asp:Panel ID="Panel1" runat="server">
                        <table style="width:100%;" cellspacing="1" cellpadding="0">
                        
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td bgcolor="#99A6B4" colspan="5">
                                    <div class="item_title">&nbsp;&nbsp;&nbsp;LGA ASSIGNMENT(<asp:Label ID="lblISP" 
                                            runat="server"></asp:Label>
                                        )</div>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="center" valign ="top"  style="width: 245px">
                                   <div id="item_left" style="border: medium groove #008080">
                                   <asp:GridView ID="grd" runat="server" AllowPaging="True" BackColor="White" 
                                                        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="2" 
                                                        CellSpacing="2" EmptyDataText="NO RECORDS FOUND" 
                                                        EnableModelValidation="True" Font-Names="Calibri" Font-Size="Small" 
                                                        GridLines="Vertical" PageSize="30" ShowFooter="True" 
                                           Width="100%">
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
                                   </div>
                                   
                                 </td>
                                <td>
                                    &nbsp;</td>
                                <td align ="center" valign ="top"  >
                                   <div id="item_right">
                                       <asp:Panel ID="Panel2" runat="server" BorderStyle="Double">

                                           <table style="width:89%;">
                                               <tr>
                                                   <td>
                                                       &nbsp;</td>
                                                   <td>
                                                       &nbsp;</td>
                                                   <td align="left" colspan="2">
                                                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                       <asp:Label ID="lblISP0" runat="server" Font-Bold="True" Font-Names="Calibri" 
                                                           Font-Size="Small"></asp:Label>
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
                                                   <td align="center" colspan="2">
                                                       <asp:CheckBoxList ID="chkGroup" runat="server" Font-Names="Calibri" 
                                                           Font-Size="Small">
                                                       </asp:CheckBoxList>
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
                                                   <td>
                                                       <hr /></td>
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
                                                       <asp:Button ID="btnSelectAll" runat="server" BackColor="#F4F4F4" 
                                                           BorderStyle="Solid" BorderWidth="0px" Font-Names="Calibri" Font-Size="Small" 
                                                           ForeColor="#990033" Text="Select All" Width="98px" />
                                                       &nbsp; |&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="btnDeSellectAll" runat="server" BackColor="#F3F3F3" 
                                                           BorderStyle="Solid" BorderWidth="0px" Font-Names="Calibri" Font-Size="Small" 
                                                           ForeColor="#990033" Text="De-select All" />
                                                       &nbsp;&nbsp;</td>
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
                                                       <asp:TextBox ID="txtISP" runat="server" Visible="False" Width="50px"></asp:TextBox>
                                                       <hr />
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
                                                   <td align="center">
                                                         <asp:Button ID="btnSave" runat="server" Text="Update Right" 
                                                        Font-Names="Calibri" />
                                                       <cc1:ConfirmButtonExtender ID="btnSave_ConfirmButtonExtender" runat="server" 
                                                        ConfirmOnFormSubmit="True" 
                                                        ConfirmText="Are you SURE you want to SAVE this record?" Enabled="True" 
                                                        TargetControlID="btnSave">
                                                    </cc1:ConfirmButtonExtender></td>
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
                                <td style="width: 245px" align="left">
                                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" 
                                        Font-Names="Calibri" Font-Size="Medium" NavigateUrl="~/manageISPState.aspx">Back</asp:HyperLink>
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
                                <td colspan="5">
                                    <asp:Panel ID="Panel3" runat="server" BackColor="Gainsboro">
                                        <table cellpadding="0" cellspacing="1" style="width:100%;">
                                            <tr>
                                                <td colspan="7" style="background-color: #99A6B4">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="7" style="background-color: #99A6B4">
                                                    
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

