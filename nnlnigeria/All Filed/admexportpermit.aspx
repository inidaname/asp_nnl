<%@ Page Title="EXPORT MANAGEMENT" Language="VB" MasterPageFile="~/adminpage.master" AutoEventWireup="false" CodeFile="admexportpermit.aspx.vb" Inherits="admexportpermit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:Panel ID="Panel1" runat="server">

  <table style="width: 100%;">
            <caption>
            </caption>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td style="width: 172px">
                    &nbsp;</td>
                <td style="width: 117px">
                    &nbsp;</td>
                <td style="width: 160px">
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
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td style="width: 172px">
                    &nbsp;</td>
                <td style="width: 117px">
                    &nbsp;</td>
                <td style="width: 160px">
                    <asp:Label ID="Label1" runat="server" Font-Names="Calibri" Font-Size="Small" 
                        Text="Select Company Name:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="cboCompany" runat="server" AutoPostBack="True" 
                        Font-Names="Calibri" Font-Size="Small" style="height: 21px">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;
                </td>
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
                <td style="width: 172px">
                    &nbsp;</td>
                <td style="width: 117px">
                    &nbsp;</td>
                <td style="width: 160px">
                    <asp:Label ID="Label2" runat="server" Font-Names="Calibri" Font-Size="Small" 
                        Text="Select Export Permit:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="cboExportPermit" runat="server" AutoPostBack="True" 
                        Font-Names="Calibri" Font-Size="Small">
                    </asp:DropDownList>
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
                <td style="width: 172px">
                    &nbsp;</td>
                <td style="width: 117px">
                    &nbsp;</td>
                <td style="width: 160px">
                    <asp:TextBox ID="txtExportID" runat="server" Width="50px" Visible="False"></asp:TextBox>
                    <asp:TextBox ID="txtExportName" runat="server" Width="50px" Visible="False"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnimportexporthistory" runat="server" Text="Import Export History" 
                        Visible="False" Width="140px" />
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td align="center" colspan="8">
                    <asp:GridView ID="grd" runat="server" AllowPaging="True" BackColor="White" 
                                        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="2" 
                                        CellSpacing="2" EmptyDataText="NO RECORD FOUND" 
                        Font-Names="Calibri" Font-Size="Small" 
                                        GridLines="Vertical" ShowFooter="True" Width="100%" 
                        PageSize="5" Height="166px">
                                        <AlternatingRowStyle BackColor="#DCDCDC" />
                                        <Columns>
                                            <asp:CommandField HeaderText="Select" SelectText="Select" 
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
                                    </asp:GridView></td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td align="center" colspan="8">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="10">

                  <div id="item_left" style="border-width:thick; border-style:double; width:65%;">

                    <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                        Width="100%">
                        <cc1:TabPanel ID="TabInspected" runat="server" HeaderText="INSPECTION">
                         <ContentTemplate>

                         <asp:Panel ID="pnlInspected" runat="server" >

                             <table style="width: 100%;">
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td style="width: 43px">
                                        &nbsp;</td>
                                    <td style="width: 181px">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td style="width: 43px">
                                        &nbsp;</td>
                                    <td style="width: 181px">
                                        <asp:Label ID="Label8" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                            Text="Inspection Officer:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtInpectionOfficer" runat="server" 
                                            ValidationGroup="InspOfficer" Width="204px"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td style="width: 43px">
                                        &nbsp;</td>
                                    <td style="width: 181px">
                                        &nbsp;</td>
                                    <td>
                                        <asp:CheckBox ID="chkInspected" runat="server" Font-Bold="True" 
                                            Font-Names="Calibri" Font-Size="Small" Text="Inspected" 
                                            ValidationGroup="inspStatus" />
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                 <tr>
                                     <td>
                                         &nbsp;</td>
                                     <td>
                                         &nbsp;</td>
                                     <td style="width: 43px">
                                         &nbsp;</td>
                                     <td style="width: 181px">
                                         <asp:Label ID="Label10" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                             Text="Inspection Date:"></asp:Label>
                                     </td>
                                     <td>
                                         <asp:TextBox ID="txtDPTTo" runat="server" BorderStyle="Solid" BorderWidth="1px" 
                                             Font-Bold="False" Font-Names="Calibri" Font-Size="Small" Height="20px" 
                                             ValidationGroup="inspDate|Invalid inspection date" Width="80px"></asp:TextBox>
                                         <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" 
                                             Format="yyyy-MM-dd" PopupButtonID="childimgbtnCal" TargetControlID="txtDPTTo">
                                         </cc1:CalendarExtender>
                                         <asp:ImageButton ID="childimgbtnCal" runat="server" Height="16px" 
                                             ImageUrl="~/img/cal3.png" ValidationGroup="dd" Width="16px" />
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
                                     <td style="width: 43px">
                                         &nbsp;</td>
                                     <td style="width: 181px">
                                         <asp:Label ID="Label12" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                             Text="Product Description"></asp:Label>
                                     </td>
                                     <td>
                                         <asp:TextBox ID="TextBox7" runat="server" Width="204px" 
                                             ValidationGroup="inspProductGrade|Invalid Product Grade"></asp:TextBox>
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
                                     <td style="width: 43px">
                                         &nbsp;</td>
                                     <td style="width: 181px">
                                         <asp:Label ID="Label14" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                             Text="Period Covered From:"></asp:Label>
                                     </td>
                                     <td>
                                         <asp:DropDownList ID="cboPCF" runat="server" AutoPostBack="True" 
                                             ToolTip="select period covered" 
                                             ValidationGroup="inspPeriodCovrdFrom|Please select period covered" 
                                             Width="204px">
                                             <asp:ListItem Selected="True">Select Value</asp:ListItem>
                                         </asp:DropDownList>
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
                                     <td style="width: 43px">
                                         &nbsp;</td>
                                     <td style="width: 181px">
                                         <asp:Label ID="Label30" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                             Text="Period Covered To:"></asp:Label>
                                     </td>
                                     <td>
                                         <asp:DropDownList ID="cboPCT" runat="server" ToolTip="select period covered" 
                                             ValidationGroup="inspPeriodCovrdTo|Please select period covered" 
                                             Width="204px">
                                             <asp:ListItem>Select Value</asp:ListItem>
                                         </asp:DropDownList>
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
                                     <td style="width: 43px">
                                         &nbsp;</td>
                                     <td style="width: 181px" valign="top">
                                         <asp:Label ID="Label15" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                             Text="Comments:"></asp:Label>
                                     </td>
                                     <td>
                                         <asp:TextBox ID="txtInspComments" runat="server" Height="100px" TextMode="MultiLine" 
                                             ValidationGroup="inspcomment|Invalid comments" Width="204px"></asp:TextBox>
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
                                     <td style="width: 43px">
                                         &nbsp;</td>
                                     <td style="width: 181px">
                                         <asp:Label ID="Label36" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                             Text="DPR REF. NO:"></asp:Label>
                                     </td>
                                     <td>
                                         <asp:TextBox ID="txtamtPerBarrel0" runat="server" BorderColor="#CCCCCC" 
                                             ValidationGroup="DPRREFNO|Invalid DPR REF. NO" Width="204px"></asp:TextBox>
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
                                     <td style="width: 43px">
                                         &nbsp;</td>
                                     <td colspan="2" align ="left" >
                                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                         <asp:Button ID="btnInspected" runat="server" 
                                             Text="Save Permit Inspection" Width="150px" />
                                         <cc1:ConfirmButtonExtender ID="btnInspected_ConfirmButtonExtender" 
                                             runat="server" ConfirmOnFormSubmit="True" 
                                             ConfirmText="Are you sure you want to SAVE this Permit" Enabled="True" 
                                             TargetControlID="btnInspected">
                                         </cc1:ConfirmButtonExtender>
                                         &nbsp;<asp:Button ID="btnResetI" runat="server" Text="Reset" />
                                         <cc1:ConfirmButtonExtender ID="btnResetI_ConfirmButtonExtender" runat="server" 
                                             ConfirmOnFormSubmit="True" 
                                             ConfirmText="Are you sure you want to RESET this form" Enabled="True" 
                                             TargetControlID="btnResetI">
                                         </cc1:ConfirmButtonExtender>
                                         &nbsp;<asp:Button ID="btnRejectInspection" runat="server" Font-Bold="False" 
                                             Font-Names="Calibri" ForeColor="Red" Text="Reject Permit Inspection" 
                                             Width="150px" />
                                         <cc1:ConfirmButtonExtender ID="btnRejectInspection_ConfirmButtonExtender" 
                                             runat="server" ConfirmOnFormSubmit="True" 
                                             ConfirmText="Are you sure you want to REJECT this Permit" Enabled="True" 
                                             TargetControlID="btnRejectInspection">
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
                                     <td>
                                         &nbsp;</td>
                                     <td style="width: 43px">
                                         &nbsp;</td>
                                     <td style="width: 181px">
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
                                     <td>
                                         &nbsp;</td>
                                     <td style="width: 43px">
                                         &nbsp;</td>
                                     <td style="width: 181px">
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
                                     <td>
                                         &nbsp;</td>
                                     <td style="width: 43px">
                                         &nbsp;</td>
                                     <td style="width: 181px">
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
                                     <td>
                                         &nbsp;</td>
                                     <td style="width: 43px">
                                         &nbsp;</td>
                                     <td style="width: 181px">
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
                        </ContentTemplate>

                        </cc1:TabPanel>

                        <cc1:TabPanel ID="TabEndorsed" runat="server" HeaderText="ENDORSEMENT">
                             <ContentTemplate>

                                 <asp:Panel id="pnlEndorsed" runat="server" >

                                 <table style="width: 100%;">
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td colspan="3">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td align="center">
                                        &nbsp;</td>
                                    <td align="center" class="style2" style="width: 83px">
                                        &nbsp;</td>
                                    <td align="left" class="style2" style="width: 153px">
                                        <asp:Label ID="Label22" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                            Text="Permit Quarter:"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblProductE" runat="server" Font-Bold="True" 
                                            Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                    </td>
                                    <td align="center">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td align="center">
                                        &nbsp;</td>
                                    <td align="center" class="style2" style="width: 83px">
                                        &nbsp;</td>
                                    <td align="center" class="style2" style="width: 153px">
                                        &nbsp;</td>
                                    <td align="left">
                                        <asp:CheckBox ID="chkEndorsed" runat="server" Font-Bold="True" 
                                            Font-Names="Calibri" Font-Size="Small" Text="Endorse" 
                                            ValidationGroup="endoresedStatus" />
                                    </td>
                                    <td align="center">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                     <tr>
                                         <td>
                                             &nbsp;</td>
                                         <td align="center">
                                                &nbsp;</td>
                                         <td align="center" class="style2" style="width: 83px">
                                             &nbsp;</td>
                                         <td align="left" class="style2" style="width: 153px">
                                             <asp:Label ID="Label27" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                 Text="Endorsement Date: "></asp:Label>
                                         </td>
                                         <td align="left">
                                             <asp:TextBox ID="txtInspDate" runat="server" BorderStyle="Solid" 
                                                 BorderWidth="1px" Font-Bold="False" Font-Names="Calibri" Font-Size="Small" 
                                                 Height="20px" ValidationGroup="endorsedDate|Invalid Endorsed date" Width="80px"></asp:TextBox>
                                             <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" 
                                                 Format="yyyy-MM-dd" PopupButtonID="childimgbtnCale" 
                                                 TargetControlID="txtInspDate">
                                             </cc1:CalendarExtender>
                                             <asp:ImageButton ID="childimgbtnCale" runat="server" Height="16px" 
                                                 ImageUrl="~/img/cal3.png" ValidationGroup="dd" Width="16px" />
                                         </td>
                                         <td align="center">
                                             &nbsp;</td>
                                         <td>
                                             &nbsp;</td>
                                     </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td align="center" valign="top">
                                        &nbsp;</td>
                                    <td align="center" style="width: 83px" valign="top">
                                        &nbsp;</td>
                                    <td align="left" class="style2" style="width: 153px" valign="top">
                                        <asp:Label ID="Label21" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                            Text="Endorsed By:"></asp:Label>
                                    </td>
                                    <td align="left" valign="top">
                                        <asp:TextBox ID="txtEndordedBy" runat="server" 
                                            ValidationGroup="endorsedBy" Width="204px"></asp:TextBox>
                                    </td>
                                    <td align="center" valign="top">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                     <tr>
                                         <td>
                                             &nbsp;</td>
                                         <td align="center" valign="top">
                                             &nbsp;</td>
                                         <td align="center" style="width: 83px" valign="top">
                                             &nbsp;</td>
                                         <td align="center" class="style2" style="width: 153px" valign="top">
                                             &nbsp;</td>
                                         <td align="center" valign="top">
                                             &nbsp;</td>
                                         <td align="center" valign="top">
                                             &nbsp;</td>
                                         <td>
                                             &nbsp;</td>
                                     </tr>
                                     <tr>
                                         <td>
                                             &nbsp;</td>
                                         <td align="center" valign="top">
                                             &nbsp;</td>
                                         <td align="center" style="width: 83px" valign="top">
                                             &nbsp;</td>
                                         <td align="right" class="style2" style="width: 153px" valign="top">
                                             <asp:Label ID="Label26" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                 Text="Comments:"></asp:Label>
                                         </td>
                                         <td align="center" valign="top">
                                             &nbsp;</td>
                                         <td align="center" valign="top">
                                             &nbsp;</td>
                                         <td>
                                             &nbsp;</td>
                                     </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td align="center" valign="top">
                                        &nbsp;</td>
                                    <td align="center" colspan="3" valign="top">
                                        <asp:TextBox ID="txtEndorsedComment" runat="server" Height="150px" 
                                            TextMode="MultiLine" ValidationGroup="endorsecomment|Invalid comments" 
                                            Width="350px"></asp:TextBox>
                                    </td>
                                    <td align="center" valign="top">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;</td>
                                    <td align="center" colspan="3">
                                        <asp:Button ID="btnEndorded" runat="server" Text="Save Permit Endorsement" />
                                        <cc1:ConfirmButtonExtender ID="_btnEndordedConfirmButtonExtender" 
                                            runat="server" ConfirmOnFormSubmit="True" 
                                            ConfirmText="Are you sure you want to SAVE this Permit" Enabled="True" 
                                            TargetControlID="btnEndorded">
                                        </cc1:ConfirmButtonExtender>
                                        &nbsp;
                                        <asp:Button ID="btnResetE" runat="server" Text="Reset" />
                                        <cc1:ConfirmButtonExtender ID="btnResetE_ConfirmButtonExtender" 
                                            runat="server" ConfirmOnFormSubmit="True" 
                                            ConfirmText="Are you sure you want to RESET this form" Enabled="True" 
                                            TargetControlID="btnResetE">
                                        </cc1:ConfirmButtonExtender>
                                    </td>
                                    <td align="center">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td colspan="3">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>

                            </asp:Panel>

                             </ContentTemplate>

                        </cc1:TabPanel>

                        <cc1:TabPanel ID="TabRecommeded" runat="server" HeaderText="RECOMMENDATION">

                           <ContentTemplate>

                           <asp:Panel id="pnlRecommend" runat="server" >

                          <table style="width: 100%;">
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td colspan="2">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td align="center" colspan="2">
                                        <asp:Label ID="Label3" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                            Text="Permit Quarter:"></asp:Label>
                                        <asp:Label ID="lblAPN" runat="server" Font-Bold="True" Font-Names="Calibri" 
                                            Font-Size="Small"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td align="center" colspan="2">
                                        <asp:CheckBox ID="chkrecommend" runat="server" Font-Bold="True" 
                                            Font-Names="Calibri" Font-Size="Small" Text="Recommend" 
                                            ValidationGroup="recommendationStatus" />
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td align="right" class="style2" style="width: 288px">
                                        <asp:Label ID="Label31" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                            Text="Recommendation Date:"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtRecommendDate" runat="server" BorderStyle="Solid" 
                                            BorderWidth="1px" Font-Bold="False" Font-Names="Calibri" Font-Size="Small" 
                                            Height="20px" ValidationGroup="recommendationDate|Invalid Recommendation date" Width="80px"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True" 
                                            Format="yyyy-MM-dd" PopupButtonID="childimgbtnCale0" 
                                            TargetControlID="txtRecommendDate">
                                        </cc1:CalendarExtender>
                                        <asp:ImageButton ID="childimgbtnCale0" runat="server" Height="16px" 
                                            ImageUrl="~/img/cal3.png" ValidationGroup="dd" Width="16px" />
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td align="right" class="style2" style="width: 288px">
                                        <asp:Label ID="Label6" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                            Text="Recommended By:"></asp:Label>
                                        &nbsp;</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtRecommendedBy" runat="server" 
                                            ValidationGroup="recommendationName" Width="204px"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td align="right" class="style2" style="width: 288px">
                                        &nbsp;</td>
                                    <td align="left">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td align="center" valign="top" colspan="2">
                                        <asp:Label ID="Label5" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                            Text="Comments:"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td align="center" valign="top" colspan="2">
                                        <asp:TextBox ID="txtRecommednComments" runat="server" Height="150px" TextMode="MultiLine" 
                                            ValidationGroup="recommendationComment|Invalid comments" Width="350px"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center" colspan="2">
                                        <asp:Button ID="btnRecommend" runat="server" 
                                            Text="Save Permit Recommendation" />
                                        <cc1:ConfirmButtonExtender ID="btnRecommend_ConfirmButtonExtender" 
                                            runat="server" ConfirmOnFormSubmit="True" 
                                            ConfirmText="Are you sure you want to SAVE this Permit" Enabled="True" 
                                            TargetControlID="btnRecommend">
                                        </cc1:ConfirmButtonExtender>
                                        &nbsp;
                                        <asp:Button ID="btnResetR" runat="server" Text="Reset" />
                                        <cc1:ConfirmButtonExtender ID="btnResetR_ConfirmButtonExtender" runat="server" 
                                            ConfirmOnFormSubmit="True" 
                                            ConfirmText="Are you sure you want to RESET this form" Enabled="True" 
                                            TargetControlID="btnResetR">
                                        </cc1:ConfirmButtonExtender>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>

                            </asp:Panel>

                        </ContentTemplate>
                          
                         </cc1:TabPanel>
                                              
                        <cc1:TabPanel ID="TabApproved" runat="server" HeaderText="APPROVAL">
                             <ContentTemplate>

                               <asp:Panel id="pnlApproved" runat="server" >

                                 <table style="width: 100%;">
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td colspan="4">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td align="center" class="style2" style="width: 23px">
                                        &nbsp;</td>
                                    <td align="center" class="style2" style="width: 44px;">
                                        &nbsp;</td>
                                    <td align="left" style="width: 185px">
                                        <asp:Label ID="Label16" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                            Text="Permit Quarter:"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblProductA" runat="server" Font-Bold="True" 
                                            Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                    </td>
                                    <td align="center">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td align="center" class="style2" style="width: 23px">
                                        &nbsp;</td>
                                    <td align="center" class="style2" style="width: 44px">
                                        &nbsp;</td>
                                    <td align="center" style="width: 185px">
                                        &nbsp;</td>
                                    <td align="left">
                                        <asp:CheckBox ID="chkApproved" runat="server" Font-Bold="True" 
                                            Font-Names="Calibri" Font-Size="Small" Text="Approve" 
                                            ValidationGroup="recommendationStatus" />
                                    </td>
                                    <td align="center">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                     <tr>
                                         <td>
                                             &nbsp;</td>
                                         <td align="center" class="style2" style="width: 23px">
                                                &nbsp;</td>
                                         <td align="center" class="style2" style="width: 44px">
                                             &nbsp;</td>
                                         <td align="left" style="width: 185px">
                                             <asp:Label ID="Label28" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                 Text="Approval Date:"></asp:Label>
                                         </td>
                                         <td align="left">
                                             <asp:TextBox ID="txtApprovalDate" runat="server" BorderStyle="Solid" 
                                                 BorderWidth="1px" Font-Bold="False" Font-Names="Calibri" Font-Size="Small" 
                                                 Height="20px" ValidationGroup="ApprovalDate|Invalid Approval date" Width="80px"></asp:TextBox>
                                             <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" 
                                                 Format="yyyy-MM-dd" PopupButtonID="childimgbtnCaleA" 
                                                 TargetControlID="txtApprovalDate">
                                             </cc1:CalendarExtender>
                                             <asp:ImageButton ID="childimgbtnCaleA" runat="server" Height="16px" 
                                                 ImageUrl="~/img/cal3.png" ValidationGroup="dd" Width="16px" />
                                         </td>
                                         <td align="center">
                                             &nbsp;</td>
                                         <td>
                                             &nbsp;</td>
                                     </tr>
                                     <tr>
                                         <td>
                                             &nbsp;</td>
                                         <td align="center" class="style2" style="width: 23px">
                                             &nbsp;</td>
                                         <td align="center" class="style2" style="width: 44px">
                                             &nbsp;</td>
                                         <td align="left" style="width: 185px">
                                             <asp:Label ID="Label7" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                 Text="Approved By:"></asp:Label>
                                         </td>
                                         <td align="left">
                                             <asp:TextBox ID="txtApprovedBy" runat="server" 
                                                 ValidationGroup="recommendationName" Width="204px"></asp:TextBox>
                                         </td>
                                         <td align="center">
                                             &nbsp;</td>
                                         <td>
                                             &nbsp;</td>
                                     </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td align="center" valign="top" colspan="4">
                                        &nbsp;</td>
                                    <td align="center" valign="top">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                     <tr>
                                         <td>
                                             &nbsp;</td>
                                         <td align="center" colspan="4" valign="top">
                                             <asp:Label ID="Label20" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                 Text="Comments:"></asp:Label>
                                         </td>
                                         <td align="center" valign="top">
                                             &nbsp;</td>
                                         <td>
                                             &nbsp;</td>
                                     </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td align="center" valign="top" colspan="4">
                                        <asp:TextBox ID="txtApprovedComments" runat="server" Height="150px" TextMode="MultiLine" 
                                            ValidationGroup="recommendationComment|Invalid comments" Width="350px"></asp:TextBox>
                                    </td>
                                    <td align="center" valign="top">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center" colspan="4">
                                        <asp:Button ID="btnApproved" runat="server" 
                                            Text="Save Permit Approval" />
                                        <cc1:ConfirmButtonExtender ID="btnApproved_ConfirmButtonExtender" 
                                            runat="server" ConfirmOnFormSubmit="True" 
                                            ConfirmText="Are you sure you want to SAVE this Permit" Enabled="True" 
                                            TargetControlID="btnApproved">
                                        </cc1:ConfirmButtonExtender>
                                        &nbsp;
                                        <asp:Button ID="btnResetA" runat="server" Text="Reset" />
                                        <cc1:ConfirmButtonExtender ID="btnResetA_ConfirmButtonExtender" runat="server" 
                                            ConfirmOnFormSubmit="True" 
                                            ConfirmText="Are you sure you want to RESET this form" Enabled="True" 
                                            TargetControlID="btnResetA">
                                        </cc1:ConfirmButtonExtender>
                                    </td>
                                    <td align="center">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td colspan="4">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>

                            </asp:Panel>
    
                           </ContentTemplate>

                        </cc1:TabPanel>

                    </cc1:TabContainer>

                  </div>

                  <div id="item_right" style="border-width: thick; border-style: double; width:30%;">
                      <asp:Panel ID="Panel2" runat="server">
                      
                         <table style="width: 100%;">                            
<tr>
                                <td align="left" class="style10">
                                    <asp:Label ID="Label29" runat="server" Text="Application Status:" 
                                        Font-Bold="True" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
                                    &nbsp;<font style="color:#F00"><asp:Label ID="lbl7" runat="server" 
                                        Text="Incomplete" CssClass="text-decoration: blink" Font-Bold="True" 
                                        Font-Names="Calibri" Font-Size="Medium"></asp:Label>
                                    </font></td>
                            </tr>
                            <tr>
                                <td align="left" class="style10" colspan="2">
                                    <hr /></td>
                       </tr>
                            <tr>
                                <td align="left" class="style10">
                                    <asp:RadioButton ID="RadioButton3" runat="server" Enabled="False" 
                                        Font-Names="Calibri" Font-Size="Small" GroupName="terminal" 
                                        Text="Terminal Operator" ValidationGroup="TerminalOperator" />
                                    &nbsp;<br />
                                    <asp:RadioButton ID="RadioButton4" runat="server" Enabled="False" 
                                        Font-Names="Calibri" Font-Size="Small" GroupName="terminal" 
                                        Text="Non Terminal Operate" ValidationGroup="NoneTerminalOperator" />
                                </td>
                                <td align="left" class="style10">
                                        &nbsp;</td>
                                 </td>
                          </tr>
                             <tr>
                                 <td align="left" class="style10">
                                     <font style="color:#F00">
                                     <asp:Label ID="lbl10" runat="server" Text="*"></asp:Label>
                                     </font>
                                    <%-- <font style="color:#F00">
                                     <asp:Label ID="lbl1" runat="server" Text="*"></asp:Label>
                                     </font>--%>
                                     <asp:Label ID="CheckBox1" runat="server" Enabled="False" 
                                         Font-Names="Calibri" Font-Size="Small" 
                                         Text="Certificate of Incorporation of the applicant's company" 
                                         ValidationGroup="CertificateOfIncor" />
                                     &nbsp;</td>
                                 <td align="left" class="style10">
                                     <asp:HyperLink ID="HView1" Runat="server" Font-Bold="True" Font-Italic="True" 
                                         Font-Names="Calibri" Font-Size="Medium">VIEW</asp:HyperLink>
                                 </td>
                             </tr>
                            <tr>
                                <td align="left" class="style10" style="height: 25px;">
                                    <font style="color:#F00">
                                    <asp:Label ID="lbl11" runat="server" Text="*"></asp:Label>
                                    </font>
                               <%-- <font style="color:#F00"><asp:Label ID="lbl2" runat="server" Text="*"></asp:Label></font>--%>
                                    <asp:Label ID="CheckBox2" runat="server" 
                                        Font-Names="Calibri" Font-Size="Small" 
                                        Text="Company Article and Memorandum of Association" 
                                        ValidationGroup="CompanyArticleMemo" Enabled="False" />
                                </td>
                                <td align="left" class="style10" style="height: 25px;">
                                    <asp:HyperLink ID="HView2" Runat="server" Font-Bold="True" Font-Italic="True" 
                                        Font-Names="Calibri" Font-Size="Medium">VIEW</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style10"><font style="color:#F00"><asp:Label ID="lbl3" 
                                        runat="server" Text="*"></asp:Label></font>
                                    <asp:Label ID="CheckBox3" runat="server" 
                                        Font-Names="Calibri" Font-Size="Small" 
                                        Text="Current Production/Storage/Sales license issued by DPR" 
                                        ValidationGroup="LicenseByDPR" Enabled="False" />
                                </td>
                                <td align="left" class="style10">
                                    <asp:HyperLink ID="HView3" Runat="server" Font-Bold="True" Font-Italic="True" 
                                        Font-Names="Calibri" Font-Size="Medium">VIEW</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style10"><font style="color:#F00"><asp:Label ID="lbl4" 
                                        runat="server" Text="*"></asp:Label></font>
                                    <asp:Label ID="CheckBox4" runat="server" 
                                        Font-Names="Calibri" Font-Size="Small" 
                                        Text="Current Weights and Measures Department certificate of conformity for the Fiscal Meters, Gauges, and all Custody Transfer Weighing &amp; Measuring instruments at the terminal(s) to be used for the export" 
                                        ValidationGroup="WeightMeters" Enabled="False" />
                                </td>
                                <td align="left" class="style10">
                                    <asp:HyperLink ID="HView4" Runat="server" Font-Bold="True" Font-Italic="True" 
                                        Font-Names="Calibri" Font-Size="Medium">VIEW</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style10"><font style="color:#F00">
                                    <asp:Label ID="lbl5" runat="server" Text="*"></asp:Label>
                                    </font>
                                    <asp:Label ID="CheckBox5" runat="server" 
                                        Font-Names="Calibri" Font-Size="Small" 
                                        Text="Original Bank reference with committed and explicit statements" 
                                        ValidationGroup="OriginalBank" Enabled="False" />
                                </td>
                                <td align="left" class="style10">
                                    <asp:HyperLink ID="HView5" Runat="server" Font-Bold="True" Font-Italic="True" 
                                        Font-Names="Calibri" Font-Size="Medium">VIEW</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style10"><font style="color:#F00">
                                    <asp:Label ID="lbl6" 
                                        runat="server" Text="*"></asp:Label></font>
                                    <asp:Label ID="CheckBox6" runat="server" 
                                        Font-Names="Calibri" Font-Size="Small" Text="3-Years Tax Clearance Certificate" 
                                        ValidationGroup="TaxClearance" Enabled="False" />
                                    
                                </td>
                                <td align="left" class="style10">
                                    <asp:HyperLink ID="HView6" Runat="server" Font-Bold="True" Font-Italic="True" 
                                        Font-Names="Calibri" Font-Size="Medium">VIEW</asp:HyperLink>
                                </td>
                                <td align="left"  >
                                    &nbsp;</td>
                            </tr>
                       <tr>
                           <td align="left" class="style10">
                               <font style="color:#F00">
                               <asp:Label ID="lbl8" runat="server" Text="*"></asp:Label>
                               </font>
                               <asp:Label ID="CheckBox7" runat="server" AutoPostBack="True" Enabled="False" 
                                   Font-Names="Calibri" Font-Size="Small" 
                                   Text="Attach Export Permit Application Document made to DPR" 
                                   ValidationGroup="DPRApplication" />
                           </td>
                           <td align="left" class="style10">
                               <asp:HyperLink ID="HView7" Runat="server" Font-Bold="True" Font-Italic="True" 
                                   Font-Names="Calibri" Font-Size="Medium">VIEW</asp:HyperLink>
                           </td>
                           <td align="left">
                               &nbsp;</td>
                       </tr>
                             <tr>
                                 <td align="left" class="style10">
                                     <font style="color:#F00">
                                     <asp:Label ID="lbl9" runat="server" Text="*"></asp:Label>
                                     </font>
                                     <asp:Label ID="CheckBox8" runat="server" AutoPostBack="True" Enabled="False" 
                                         Font-Names="Calibri" Font-Size="Small" 
                                         Text="Attach Evidence of Payment of Monitoring Fees" 
                                         ValidationGroup="EvidenceOfMonitoringFees" />
                                 </td>
                                 <td align="left" class="style10">
                                     <asp:HyperLink ID="HView8" Runat="server" Font-Bold="True" Font-Italic="True" 
                                         Font-Names="Calibri" Font-Size="Medium">VIEW</asp:HyperLink>
                                 </td>
                                 <td align="left">
                                     &nbsp;</td>
                             </tr>
                             <tr>
                                 <td align="left" class="style10">
                                     &nbsp;</td>
                                 <td align="left" class="style10">
                                     
                                 <td align="left">
                                     &nbsp;</td>
                             </tr>
                       <tr>
                           <td align="left" class="style10">
                               &nbsp;</td>
                           <td align="left" class="style10">
                               &nbsp;</td>
                           <td align="left">
                               &nbsp;</td>
                       </tr>
                       <tr>
                           <td align="left" class="style10">
                               <asp:TextBox ID="txtpassportname1" runat="server" 
                                   ValidationGroup="CoverLetterName1" Visible="False" Width="15px"></asp:TextBox>
                               <asp:TextBox ID="txtpassportname2" runat="server" 
                                   ValidationGroup="CoverLetterName2" Visible="False" Width="15px"></asp:TextBox>
                               <asp:TextBox ID="txtpassportname3" runat="server" 
                                   ValidationGroup="CoverLetterName3" Visible="False" Width="15px"></asp:TextBox>
                               <asp:TextBox ID="txtpassportname4" runat="server" 
                                   ValidationGroup="CoverLetterName4" Visible="False" Width="15px"></asp:TextBox>
                               <asp:TextBox ID="txtpassportname5" runat="server" 
                                   ValidationGroup="CoverLetterName5" Visible="False" Width="15px"></asp:TextBox>
                               <asp:TextBox ID="txtpassportname6" runat="server" 
                                   ValidationGroup="CoverLetterName6" Visible="False" Width="15px"></asp:TextBox>
                               <asp:TextBox ID="txtpassportname7" runat="server" 
                                   ValidationGroup="CoverLetterName7" Visible="False" Width="15px"></asp:TextBox>
                               <asp:TextBox ID="txtpassportname8" runat="server" 
                                   ValidationGroup="CoverLetterName8" Visible="False" Width="15px"></asp:TextBox>
                           </td>
                           <td align="left" class="style10">
                               &nbsp;</td>
                           <td align="left">
                               &nbsp;</td>
                       </tr>
                       <tr>
                           <td align="left" class="style10" colspan="2">
                               <hr /></td>
                           <td align="left">
                               &nbsp;</td>
                       </tr>
</table>

                      </asp:Panel>

                  </div>
                 
                     
                 
                 </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td colspan="8">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
        </asp:Panel>
      
    </ContentTemplate>
</asp:UpdatePanel>

</asp:Content>


