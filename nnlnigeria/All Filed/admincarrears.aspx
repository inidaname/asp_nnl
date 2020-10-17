<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/adminpage.master" CodeFile="admincarrears.aspx.vb" Inherits="admincarrears" EnableEventValidation ="false" ValidateRequest ="false" %>

<%@ Import Namespace="System.Data" %>

 <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
 

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc2" %>
 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>

<div id="item1">
    	 
    	<div   class="item_title" align="center">&nbsp;&nbsp;&nbsp; Carrear Setup</div>
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
                                <td class="style39">
                                    &nbsp;</td>
                                <td class="style41">
                                    &nbsp;</td>
                                <td class="style22" align="center">
                                    <asp:Label ID="Label1" runat="server" Font-Names="Calibri" Font-Size="Large" 
                                        ForeColor="#003366" Text="Enter Application"></asp:Label>
                                </td>
                                <td class="style40" align="center">
                                    &nbsp;</td>
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
                                <td class="style41">
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
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style39" colspan="5">
                                    <cc2:Editor ID="txtMessage" runat="server" Height="500px" NoScript="True" 
                                        Width="100%" />
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style39">
                                    &nbsp;</td>
                                <td class="style41" colspan="3">
                                    &nbsp;</td>
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
                                <td class="style41" colspan="3" align ="center">
                                    <asp:Button ID="btnPreview" runat="server" style="height: 26px" Text="Submit" />
                                    <cc1:ConfirmButtonExtender ID="btnPreview_ConfirmButtonExtender" runat="server" 
                                        ConfirmOnFormSubmit="True" 
                                        ConfirmText="Are you sure you want SAVE this Record?" Enabled="True" 
                                        TargetControlID="btnPreview">
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
 