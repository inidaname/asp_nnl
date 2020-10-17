<%@ Page Title="MANAGE LOTS" Language="VB" MasterPageFile="~/adminpage.master" AutoEventWireup="True" CodeFile="managelots.aspx.vb" Inherits="managelots" EnableEventValidation="false"  ValidateRequest ="false"  %>
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
                                    <div class="item_title">&nbsp;&nbsp;&nbsp;MANAGE LOT ALLOCATION(<asp:Label ID="lblISP" 
                                            runat="server"></asp:Label>
                                        )</div>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label8" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Terminal:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtsurname" runat="server" 
                                        ValidationGroup="TerminalName|Invalid TerminalName" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label11" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Owner:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtusername12" runat="server" 
                                        ValidationGroup="TerminalOwner|Invalid Owner's Name" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="RC Number:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtfirstname" runat="server" 
                                        ValidationGroup="RCNumber|Invalid Registration Number" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label17" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Location:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtusername9" runat="server" 
                                        ValidationGroup="Location|Invalid Location" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label10" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Select Lot Name:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="cbolot" runat="server" 
                                        Font-Names="Calibri" Font-Size="Small" 
                                        ValidationGroup="LotID|Invalid Lots Selection|1" Width="210px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label19" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Select Company:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="cbocomp" runat="server" 
                                        Font-Names="Calibri" Font-Size="Small" 
                                        ValidationGroup="CompID|Invalid Company Selection|1" Width="210px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label21" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Active ISP:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="cboISP" runat="server" AutoPostBack="True" 
                                        Font-Names="Calibri" Font-Size="Small" 
                                        ValidationGroup="ISPID|Invalid ISP Selection|1" Width="210px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label20" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Facility Database:"></asp:Label>
                                </td>
                                <td>
                                    <asp:FileUpload ID="fdb" runat="server" Width="204px" />
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="lblfilepath" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" Text="Filename:" Visible="False"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtfilepath" runat="server" ReadOnly="True" Width="204px" 
                                        Wrap="False"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left">
                                    <asp:Button ID="btnAssignLGA" runat="server" style="height: 26px" 
                                        Text="Assign LGA" />
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                </td>
                                <td>
                                    &nbsp;<asp:Button ID="btnPreview" runat="server" style="height: 26px" 
                                        Text="Submit" />
                                    <cc1:ConfirmButtonExtender ID="btnPreview_ConfirmButtonExtender" runat="server" 
                                        ConfirmOnFormSubmit="True" 
                                        ConfirmText="Are you SURE you want to SAVE this registration?" Enabled="True" 
                                        TargetControlID="btnPreview">
                                    </cc1:ConfirmButtonExtender>
                                    <asp:Button ID="btnReset" runat="server" Text="Reset" />
                                    <cc1:ConfirmButtonExtender ID="btnReset_ConfirmButtonExtender" runat="server" 
                                        ConfirmOnFormSubmit="True" 
                                        ConfirmText="Are you SURE you want to CLEAR this form" Enabled="True" 
                                        TargetControlID="btnReset">
                                    </cc1:ConfirmButtonExtender>
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
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtfdbName" runat="server" 
                                        ValidationGroup="fabilityDBFilename" Visible="False" Width="50px"></asp:TextBox>
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
                                                    <asp:Label ID="lblSearch" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                        Text="Search by:"></asp:Label>
                                                    <asp:DropDownList ID="cboSearch" runat="server" style="margin-top: 0px" 
                                                        Width="204px">
                                                        <asp:ListItem Selected="True">Select Value</asp:ListItem>
                                                        <asp:ListItem>TerminalName</asp:ListItem>
                                                        <asp:ListItem>TerminalOwner</asp:ListItem>
                                                        <asp:ListItem>RCNumber</asp:ListItem>
                                                        <asp:ListItem>Location</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:TextBox ID="txtSearch" runat="server" CausesValidation="false" 
                                                        Width="204px"></asp:TextBox>
                                                    &nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" 
                                                        style="height: 26px" />
                                                </td>
                                            </tr>
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

