<%@ Page Title="NEW USERS" Language="VB" MasterPageFile="~/adminpage.master" AutoEventWireup="false" CodeFile="admnewuser.aspx.vb" ValidateRequest ="false"  EnableEventValidation ="false"  Inherits="admnewuser" %>
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
                                <td bgcolor="#99A6B4" colspan="5">
                                    <div class="item_title">&nbsp;&nbsp;&nbsp;ACCOUNT CREATION</div>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Username:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtuser" runat="server" ToolTip="enter username" 
                                        ValidationGroup="username|Invalid Username" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="lblsecurityquestion" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Security Question:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="cbosQuestion" runat="server" 
                                        ToolTip="select security question" 
                                        ValidationGroup="securityquestion|Please select security questions" 
                                        Width="204px">
                                    
                                        <asp:ListItem Selected="True">
                                        Select Question</asp:ListItem>
                                        <asp:ListItem>Petty Name</asp:ListItem>
                                        <asp:ListItem>Favorite Book</asp:ListItem>
                                        <asp:ListItem>Favorite Music</asp:ListItem>
                                        <asp:ListItem>Favorite Actor</asp:ListItem>
                                        <asp:ListItem>Mother's Maidein</asp:ListItem>
                                        <asp:ListItem>School Project</asp:ListItem>
                                        <asp:ListItem>Name You Call God</asp:ListItem>
                                        <asp:ListItem>First Uncle's Name</asp:ListItem>
                                        <asp:ListItem>Uncle's First Son</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Password:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtpwd" runat="server" TextMode="Password" 
                                        ToolTip="enter password" ValidationGroup="userpwd" CausesValidation="false" 
                                        Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label7" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Answer:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAsnwer" runat="server" 
                                        ToolTip="enter answer to your security question" 
                                        ValidationGroup="securityAnswer|Invalid Answer" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label24" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Retry Password:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtpwdR" runat="server" TextMode="Password" CausesValidation ="false"  
                                        ToolTip="retype password entered" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label25" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Company Name:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAsnwer0" runat="server" ToolTip="enter user company name" 
                                        ValidationGroup="CompanyName|Invalid CompanyName" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td colspan="5">
                                    <div class="item_title">
                                        &nbsp;&nbsp;&nbsp;USER RECORDS</div>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label8" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Surname:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtsurname" runat="server" ToolTip="enter surname" 
                                        ValidationGroup="Surname|Invalid Surname" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label11" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Address:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtusername12" runat="server" 
                                        ToolTip="enter contact address" 
                                        ValidationGroup="contacAddress|Invalid contact address" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Firstname:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtfirstname" runat="server" 
                                        ToolTip="enter firstname" 
                                        ValidationGroup="firstname|Invalid Firstname" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label17" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Mobile:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtusername9" runat="server" 
                                        ToolTip="enter mobile" 
                                        ValidationGroup="phone|Invalid Mobile" Width="204px"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtusername9_FilteredTextBoxExtender" 
                                        runat="server" Enabled="True" TargetControlID="txtusername9" 
                                        ValidChars="1234567890,+">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label10" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Othername:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtothername" runat="server" ToolTip="enter othername" 
                                        ValidationGroup="othernames|Invalid othernames" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label19" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Email:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtemail" runat="server" 
                                        ValidationGroup="email|Invalid email address" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td colspan="5">
                                    <div class="item_title">
                                        &nbsp;&nbsp;&nbsp;USER RIGHTS</div>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:CheckBox ID="CheckBox9" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" Text="Admin?" ValidationGroup="sysadminright" />
                                </td>
                                <td align="left">
                                    <asp:CheckBox ID="CheckBox10" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" Text="Export/Import Approval?" 
                                        ValidationGroup="approveExportImport" />
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:CheckBox ID="CheckBox11" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" Text="Report?" ValidationGroup="reportRight" />
                                </td>
                                <td align="left">
                                    <asp:CheckBox ID="CheckBox12" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" Text="Export/Import Data Import?" 
                                        ValidationGroup="dataimportright" />
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:CheckBox ID="CheckBox23" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" Text="Operator?" ValidationGroup="operatorright" />
                                </td>
                                <td align="left">
                                    <asp:CheckBox ID="CheckBox19" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" Text="Export/Import Endorse?" 
                                        ValidationGroup="endorseExportImport" />
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:CheckBox ID="CheckBox18" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" Text="Static Data?" ValidationGroup="staticdataright" />
                                </td>
                                <td align="left">
                                    <asp:CheckBox ID="CheckBox13" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" Text="Company Mgt?" ValidationGroup="companymgtright" />
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:CheckBox ID="CheckBox24" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" Text="Monitor?" ValidationGroup="systemMonitorright" />
                                </td>
                                <td align="left">
                                    
                                    <asp:CheckBox ID="CheckBox20" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" Text="Export/Import Recommend?" 
                                        ValidationGroup="recommendExportImport" />
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:CheckBox ID="CheckBox17" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" Text="Audit Right?" ValidationGroup="auditright" />
                                </td>
                                <td align="left">
                                    <asp:CheckBox ID="CheckBox14" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" Text="Instrument Mgt?" ValidationGroup="devicemdgtright" />
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:CheckBox ID="CheckBox22" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" Text="Monitor/Operator?" 
                                        ValidationGroup="monitorOperatorOnlyright" />
                                </td>
                                <td align="left">
                                    <asp:CheckBox ID="CheckBox21" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" Text="Export/Import Inspect?" 
                                        ValidationGroup="InspectExportImport" />
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:CheckBox ID="CheckBox16" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" Text="Dormant?" ValidationGroup="recordstatus" />
                                </td>
                                <td align="left">
                                    <asp:CheckBox ID="CheckBox15" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" Text="Bill Table?" ValidationGroup="BillTable" />
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:CheckBox ID="chkISP" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Manage ISP?" ValidationGroup="isISP" />
                                </td>
                                <td align="left">
                                    <asp:CheckBox ID="chkISP0" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" Text="Setup Frontpage?" ValidationGroup="SetMainPage" />
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:CheckBox ID="chkISP1" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" Text="Lots Management" ValidationGroup="ManageLot" />
                                </td>
                                <td align="left">
                                    <asp:CheckBox ID="chkISP2" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" Text="Download Manager" ValidationGroup="DownloadCenter" />
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:CheckBox ID="chkISP3" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" Text="Is ISP Client?" ValidationGroup="ISClient" />
                                </td>
                                <td align="left">
                                    <asp:CheckBox ID="chkISP4" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" Text="Can Upload Photo Gallery?" 
                                        ValidationGroup="uploadphotogallery" />
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:CheckBox ID="chkISP5" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" Text="Archive Right?" ValidationGroup="Quizright" />
                                </td>
                                <td align="left">
                                    <asp:CheckBox ID="chkISP6" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" Text="Quiz Right?" ValidationGroup="ArchiveRight" />
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:CheckBox ID="chkISP9" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" Text="Field Inspector" />
                                </td>
                                <td align="left">
                                    <asp:CheckBox ID="chkISP10" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" Text="Other  Documents" ValidationGroup="OtherDocRight" />
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:CheckBox ID="chkISP8" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" Text="Email Right?" ValidationGroup="emailRight" />
                                </td>
                                <td align="left">
                                    <asp:CheckBox ID="chkISP7" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" Text="Can Update Carrear?" ValidationGroup="CarrearRight" />
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:CheckBox ID="chkISP11" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" Text="Export Data Returns" 
                                        ValidationGroup="ExportDataReturns" />
                                </td>
                                <td align="left">
                                    <asp:CheckBox ID="chkISP12" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" Text="PIA Export Data Returns" 
                                        ValidationGroup="PIAExportDataReturns" />
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left">
                                    <asp:Button ID="btnISP" runat="server" style="height: 26px" Text="Manage ISP" 
                                        Visible="False" />
                                    <cc1:ConfirmButtonExtender ID="btnISP_ConfirmButtonExtender" runat="server" 
                                        ConfirmOnFormSubmit="True" 
                                        ConfirmText="You are about to manage lots allocation?" Enabled="True" 
                                        TargetControlID="btnISP">
                                    </cc1:ConfirmButtonExtender>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Button ID="btnPreview" runat="server" Text="Submit" style="height: 26px" />
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
                                                    <asp:Label ID="lblSearch" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                        Text="Search by:"></asp:Label>
                                                    <asp:DropDownList ID="cboSearch" runat="server" style="margin-top: 0px" 
                                                        Width="204px">
                                                        <asp:ListItem Selected="True">Select Value</asp:ListItem>
                                                        <asp:ListItem>Username</asp:ListItem>
                                                        <asp:ListItem>Surname</asp:ListItem>
                                                        <asp:ListItem>Firstname</asp:ListItem>
                                                        <asp:ListItem>Othernames</asp:ListItem>
                                                        <asp:ListItem>Phone</asp:ListItem>
                                                        <asp:ListItem>Email</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:TextBox ID="txtSearch" runat="server" CausesValidation="false" 
                                                        Width="204px"></asp:TextBox>
                                                    &nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" />
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
                                                        CellSpacing="2" EmptyDataText="NO REGISTERED INSTRUMENT" 
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

