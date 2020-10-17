<%@ Page Title="Email Settings" Language="VB" MasterPageFile="~/adminpage.master" AutoEventWireup="false" CodeFile="emailmgt.aspx.vb" Inherits="emailmgt" %>

<%@ Import Namespace="System.Data" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<!--start home-->
<div id="item1">
	   <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                            </cc1:ToolkitScriptManager>
  <div class="item_title">&nbsp;&nbsp;&nbsp; USER ACCOUNT</div>
    	<div>     
  
      <center>
      
    <div style="width : 75%" id="main-menu">
         <asp:UpdatePanel ID="UpdatePanel1" runat ="server" >
            <ContentTemplate >
        <div class="item_title"><asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></div>
                <div id="item2">
                                 
               
                    <asp:Panel ID="Panel1" runat="server">
                        <table style="width:100%;" cellspacing="1" cellpadding="0">
                        
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td style="width: 225px" align="right">
                                    <asp:Label ID="Label1" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Email Address:"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:TextBox ID="txtuser" runat="server" 
                                        ValidationGroup="|Invalid email name" Width="134px"></asp:TextBox>
                                    <asp:DropDownList ID="cbosQuestion" runat="server" 
                                        ValidationGroup="accountdomainid|Please select dormain name|" 
                                        Width="250px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td style="width: 225px" align="right">
                                    <asp:Label ID="Label4" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Password:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtpwd" runat="server" TextMode="Password" 
                                        ValidationGroup="|Invalid password" CausesValidation="false" 
                                        Width="204px"></asp:TextBox>
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
                                <td style="width: 225px" align="right">
                                    <asp:Label ID="Label24" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" Text="Retry Password:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtpwdR" runat="server" CausesValidation="false" 
                                        TextMode="Password" ValidationGroup="|Invalid password" Width="204px"></asp:TextBox>
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
                                </td>
                                <td align="right" style="width: 225px">
                                    &nbsp;<asp:Label ID="Label8" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Surname:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtsurname" runat="server" ToolTip="enter surname" 
                                        ValidationGroup="accountpersonlastname|Invalid Surname" Width="204px"></asp:TextBox>
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
                                <td align="right" style="width: 225px">
                                    <asp:Label ID="Label9" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Firstname:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtfirstname" runat="server" ToolTip="enter firstname" 
                                        ValidationGroup="accountpersonfirstname|Invalid Firstname" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="left" style="width: 225px">
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:CheckBox ID="chkIsActive" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" Text="Is Active?" ValidationGroup="accountactive" 
                                        Checked="True" />
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="left" style="width: 225px">
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:TextBox ID="txtemailaddress" runat="server" 
                                        ValidationGroup="accountaddress" Width="16px" Visible="False"></asp:TextBox>
                                    <asp:TextBox ID="txtf1" runat="server" ValidationGroup="accountadminlevel" 
                                        Width="16px" Visible="False">0</asp:TextBox>
                                    <asp:TextBox ID="txtf2" runat="server" ValidationGroup="accountpwencryption" 
                                        Width="23px" Visible="False">2</asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left" style="width: 225px">
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Button ID="btnPreview" runat="server" style="height: 26px" Text="Submit" />
                                    <cc1:ConfirmButtonExtender ID="btnPreview_ConfirmButtonExtender" runat="server" 
                                        ConfirmOnFormSubmit="True" 
                                        ConfirmText="Are you SURE you want to SAVE this registration?" Enabled="True" 
                                        TargetControlID="btnPreview">
                                    </cc1:ConfirmButtonExtender>
                                    &nbsp;<asp:Button ID="btnReset" runat="server" Text="Reset" />
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
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="left" style="width: 225px">
                                    &nbsp;</td>
                                <td align="left">
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
                                <td colspan="4">
                                    <asp:GridView ID="grd" runat="server" BackColor="White" 
                                                        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="2" 
                                                        CellSpacing="2" EmptyDataText="NO RECORDS" 
                                                        EnableModelValidation="True" Font-Names="Calibri" Font-Size="Small" 
                                                        GridLines="Vertical" PageSize="20" ShowFooter="True" 
                                        Width="100%">
                                                        <AlternatingRowStyle BackColor="#DCDCDC" />
                                                       
                                                        <Columns>
                                                            <asp:CommandField SelectText="Edit" ShowSelectButton="True" />
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
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td style="width: 225px">
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
   </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnPreview" EventName="Click" />
             </Triggers>
                </asp:UpdatePanel>
    </div>
     </center>
</div>

        
</div>
    

<!--end home-->
</asp:Content>
