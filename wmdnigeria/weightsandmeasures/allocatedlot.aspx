<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/adminpage.master" CodeFile="allocatedlot.aspx.vb" Inherits="allocatedlot" %>

<%@ Import Namespace="System.Data" %>

 <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>

<div id="item1">
    	 
    	<div class="item_title">&nbsp;&nbsp;&nbsp; INSTRUMENT REGISTRATION</div>
    	<div>
	                         <br /><br /><br />
                       
	                         <center>

                                 <div style="width : 75%"  id="main-menu" >

         <asp:UpdatePanel ID="UpdatePanel1" runat ="server" >
            <ContentTemplate >
              <div class="item_title">&nbsp;&nbsp;&nbsp; 
                                        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
              </div>

                <div id="item2">
                   <asp:Panel ID="MainRegForm" runat="server">
                      

                    <asp:Panel ID="Panel2" runat="server">
                       <table style="width:100%;" cellspacing="1" cellpadding="0">

                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td style="background-color:#99A6B4" colspan="5">
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                         
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style39">
                                    &nbsp;</td>
                                <td class="style41">
                                    &nbsp;</td>
                                <td class="style22">
                                    &nbsp;</td>
                                <td class="style40" align="center">
                                    <asp:Label ID="Label25" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Lots Name:"></asp:Label>
                                    <asp:TextBox ID="txtLots" runat="server" 
                                        ToolTip="enter actual Instrument measure" 
                                        ValidationGroup="actualMeasure|Invalid Actual Measure" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style39">
                                    &nbsp;</td>
                                <td align="center" class="style41">
                                    &nbsp;</td>
                                <td class="style22">
                                    &nbsp;</td>
                                <td align="center" class="style40">
                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" Visible="False" />
                                    <cc1:ConfirmButtonExtender ID="btnDelete_ConfirmButtonExtender" runat="server" 
                                        ConfirmOnFormSubmit="True" 
                                        ConfirmText="Are you sure you want to DELETE this Record" Enabled="True" 
                                        TargetControlID="btnDelete">
                                    </cc1:ConfirmButtonExtender>
                                    &nbsp;
                                    <asp:Button ID="btnPreview" runat="server" style="height: 26px" Text="Submit" />
                                    <cc1:ConfirmButtonExtender ID="btnPreview_ConfirmButtonExtender" runat="server" 
                                        ConfirmOnFormSubmit="True" 
                                        ConfirmText="Are you sure you want SAVE this Record?" Enabled="True" 
                                        TargetControlID="btnPreview">
                                    </cc1:ConfirmButtonExtender>
                                    &nbsp;
                                    <asp:Button ID="btncancel" runat="server" Text="Cancel/Reset" />
                                    <cc1:ConfirmButtonExtender ID="btncancel_ConfirmButtonExtender" runat="server" 
                                        ConfirmOnFormSubmit="True" 
                                        ConfirmText="Are you sure you want to CANCEL/RESET this form?" Enabled="True" 
                                        TargetControlID="btncancel">
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
                                <td class="style39">
                                    &nbsp;</td>
                                <td align="right" class="style41">
                                    &nbsp;</td>
                                <td class="style22">
                                    &nbsp;</td>
                                <td align="center" class="style40">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>

                  </asp:Panel>

                   <asp:Panel ID="Panel3" runat="server" BackColor ="Gainsboro" Visible ="true" >
                       <table style="width:100%;" cellspacing="1" cellpadding="0">

                                            
                            <tr>
                                <td class="style38">
                                    </td>
                                <td class="style33" align="center" colspan="5" rowspan="2">
                                    <asp:GridView ID="grd" runat="server" AllowPaging="True" BackColor="White" 
                                        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="2" 
                                        CellSpacing="2" EmptyDataText="NO RECORD FOUND" 
                                        EnableModelValidation="True" Font-Names="Calibri" Font-Size="Small" 
                                        GridLines="Vertical" ShowFooter="True" Width="100%" PageSize="20">
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
                                <td class="style38">
                                    </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style5">
                                    &nbsp;</td>
                                <td class="style23">
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

                </div>
   </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnPreview" EventName="Click" />
             </Triggers>
                </asp:UpdatePanel>


    </div>
     </center>
</div>

        
</div>
    
</asp:Content>
 