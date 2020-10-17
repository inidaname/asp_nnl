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
                        Font-Names="Calibri" Font-Size="Small">
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
                                        EnableModelValidation="True" Font-Names="Calibri" Font-Size="Small" 
                                        GridLines="Vertical" ShowFooter="True" Width="100%" 
                        PageSize="5" Height="166px">
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

                    <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" 
                        Width="100%">
                        <cc1:TabPanel ID="TabRecommeded" runat="server" HeaderText="EXPORT PERMIT RECOMMENDATION">

                           <ContentTemplate>

                           <asp:Panel id="pnlRecommend" runat="server" >

                          <table style="width: 100%;">
                                <tr>
                                    <td>
                                        &nbsp;
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
                                    <td align="center">
                                        <asp:Label ID="Label3" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                            Text="Active Permit Name:"></asp:Label>
                                        <asp:Label ID="lblAPN" runat="server" Font-Bold="True" Font-Names="Calibri" 
                                            Font-Size="Small"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="height: 19px">
                                        </td>
                                    <td align="center" style="height: 19px">
                                        <asp:Label ID="Label4" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                            Text="Status:"></asp:Label>
                                        <asp:Label ID="lblAPNS" runat="server" Font-Bold="True" Font-Names="Calibri" 
                                            Font-Size="Small"></asp:Label>
                                    </td>
                                    <td style="height: 19px">
                                        </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td align="center">
                                        <asp:CheckBox ID="chkrecommend" runat="server" Font-Bold="True" 
                                            Font-Names="Calibri" Font-Size="Small" Text="Recommend?" 
                                            ValidationGroup="recommendationStatus" />
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td align="center">
                                        <asp:Label ID="Label6" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                            Text="Recommended By:"></asp:Label>
                                        &nbsp;<asp:TextBox ID="txtRecommendedBy" runat="server" ReadOnly="True" 
                                            ValidationGroup="recommendationName" Width="204px"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td align="center" valign="top">
                                        <asp:Label ID="Label5" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                            Text="Comments:"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td align="center" valign="top">
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
                                    <td align="center">
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
                                    <td>
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

                        <cc1:TabPanel ID="TabInspected" runat="server" HeaderText="EXPORT PERMIT INSPECTION">
                         <ContentTemplate>

                         <asp:Panel ID="pnlInspected" runat="server" >

                             <table style="width: 100%;">
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td style="width: 277px">
                                        &nbsp;</td>
                                    <td style="width: 154px">
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
                                    <td style="width: 277px">
                                        &nbsp;</td>
                                    <td style="width: 154px">
                                        <asp:Label ID="Label8" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                            Text="Inspection Office Name:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtInpectionOfficer" runat="server" ReadOnly="True" 
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
                                    <td style="width: 277px">
                                        &nbsp;</td>
                                    <td style="width: 154px">
                                        &nbsp;</td>
                                    <td>
                                        <asp:CheckBox ID="chkInspected" runat="server" Font-Bold="True" 
                                            Font-Names="Calibri" Font-Size="Small" Text="Inspected?" 
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
                                     <td style="width: 277px">
                                         &nbsp;</td>
                                     <td style="width: 154px">
                                         <asp:Label ID="Label9" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                             Text="Inspector Designation:"></asp:Label>
                                     </td>
                                     <td>
                                         <asp:TextBox ID="TextBox4" runat="server" Width="204px" 
                                             ValidationGroup="inspDesgination|Invalid Designation"></asp:TextBox>
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
                                     <td style="width: 277px">
                                         &nbsp;</td>
                                     <td style="width: 154px">
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
                                     <td style="width: 277px">
                                         &nbsp;</td>
                                     <td style="width: 154px">
                                         <asp:Label ID="Label11" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                             Text="Product Name:"></asp:Label>
                                     </td>
                                     <td>
                                         <asp:TextBox ID="TextBox6" runat="server" Width="204px" 
                                             ValidationGroup="inspProductName|Invalid Product Name"></asp:TextBox>
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
                                     <td style="width: 277px">
                                         &nbsp;</td>
                                     <td style="width: 154px">
                                         <asp:Label ID="Label12" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                             Text="Product Grade:"></asp:Label>
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
                                     <td style="width: 277px">
                                         &nbsp;</td>
                                     <td style="width: 154px">
                                         <asp:Label ID="Label13" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                             Text="Destination Country:"></asp:Label>
                                     </td>
                                     <td>
                                         <asp:DropDownList ID="cboCountry" runat="server" 
                                             ValidationGroup="inspDestination|Please select destination country" 
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
                                     <td style="width: 277px">
                                         &nbsp;</td>
                                     <td style="width: 154px">
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
                                     <td style="width: 277px">
                                         &nbsp;</td>
                                     <td style="width: 154px">
                                         &nbsp;</td>
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
                                     <td style="width: 277px">
                                         &nbsp;</td>
                                     <td style="width: 154px">
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
                                     <td style="width: 277px">
                                         &nbsp;</td>
                                     <td style="width: 154px">
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
                                     <td style="width: 277px">
                                         &nbsp;</td>
                                     <td colspan="2" align ="left" >
                                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                         <asp:Button ID="btnInspected" runat="server" 
                                             Text="Save Permit Inspection" />
                                         <cc1:ConfirmButtonExtender ID="btnInspected_ConfirmButtonExtender" 
                                             runat="server" ConfirmOnFormSubmit="True" 
                                             ConfirmText="Are you sure you want to SAVE this Permit" Enabled="True" 
                                             TargetControlID="btnInspected">
                                         </cc1:ConfirmButtonExtender>
                                         &nbsp;
                                         <asp:Button ID="btnResetI" runat="server" Text="Reset" />
                                         <cc1:ConfirmButtonExtender ID="btnResetI_ConfirmButtonExtender" runat="server" 
                                             ConfirmOnFormSubmit="True" 
                                             ConfirmText="Are you sure you want to RESET this form" Enabled="True" 
                                             TargetControlID="btnResetI">
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
                                     <td style="width: 277px">
                                         &nbsp;</td>
                                     <td style="width: 154px">
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
                                     <td style="width: 277px">
                                         &nbsp;</td>
                                     <td style="width: 154px">
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
                                     <td style="width: 277px">
                                         &nbsp;</td>
                                     <td style="width: 154px">
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
                                     <td style="width: 277px">
                                         &nbsp;</td>
                                     <td style="width: 154px">
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

                        <cc1:TabPanel ID="TabEndorsed" runat="server" HeaderText="EXPORT PERMIT ENDORSEMENT">
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
                                    <td align="center" class="style2" style="width: 339px">
                                        &nbsp;</td>
                                    <td align="left" class="style2" style="width: 119px">
                                        <asp:Label ID="Label22" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                            Text="Active Permit Name:"></asp:Label>
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
                                    <td style="height: 19px">
                                        </td>
                                    <td align="center" style="height: 19px">
                                        &nbsp;</td>
                                    <td align="center" style="height: 19px; width: 339px;">
                                        &nbsp;</td>
                                    <td align="left" style="height: 19px; width: 119px;">
                                        <asp:Label ID="Label24" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                            Text="Endorsed Status:"></asp:Label>
                                    </td>
                                    <td align="left" style="height: 19px">
                                        <asp:Label ID="lblStatusE" runat="server" Font-Bold="True" Font-Names="Calibri" 
                                            Font-Size="Small"></asp:Label>
                                    </td>
                                    <td align="center" style="height: 19px">
                                        &nbsp;</td>
                                    <td style="height: 19px">
                                        </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td align="center">
                                        &nbsp;</td>
                                    <td align="center" class="style2" style="width: 339px">
                                        &nbsp;</td>
                                    <td align="center" class="style2" style="width: 119px">
                                        &nbsp;</td>
                                    <td align="left">
                                        <asp:CheckBox ID="chkEndorsed" runat="server" Font-Bold="True" 
                                            Font-Names="Calibri" Font-Size="Small" Text="Endorsed?" 
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
                                         <td align="center" class="style2" style="width: 339px">
                                             &nbsp;</td>
                                         <td align="left" class="style2" style="width: 119px">
                                             <asp:Label ID="Label27" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                 Text="Endorsed Date: "></asp:Label>
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
                                    <td align="center" style="width: 339px" valign="top">
                                        &nbsp;</td>
                                    <td align="left" class="style2" style="width: 119px" valign="top">
                                        <asp:Label ID="Label21" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                            Text="Endorsed By:"></asp:Label>
                                    </td>
                                    <td align="left" valign="top">
                                        <asp:TextBox ID="txtEndordedBy" runat="server" ReadOnly="True" 
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
                                         <td align="center" style="width: 339px" valign="top">
                                             &nbsp;</td>
                                         <td align="center" class="style2" style="width: 119px" valign="top">
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
                                         <td align="center" style="width: 339px" valign="top">
                                             &nbsp;</td>
                                         <td align="center" class="style2" style="width: 119px" valign="top">
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

                        <cc1:TabPanel ID="TabApproved" runat="server" HeaderText="EXPORT PERMIT APPROVAL">
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
                                    <td align="center" colspan="4">
                                        &nbsp;</td>
                                    <td align="center">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td align="center" class="style2">
                                        &nbsp;</td>
                                    <td align="center" class="style2" style="width: 44px">
                                        &nbsp;</td>
                                    <td align="left" style="width: 127px;">
                                        <asp:Label ID="Label16" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                            Text="Active Permit Name:"></asp:Label>
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
                                    <td style="height: 19px">
                                        </td>
                                    <td align="center" style="height: 19px; width: 312px;">
                                        &nbsp;</td>
                                    <td align="center" style="height: 19px; width: 44px;">
                                        &nbsp;</td>
                                    <td align="left" style="width: 127px; height: 19px;">
                                        <asp:Label ID="Label18" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                            Text="Status:"></asp:Label>
                                    </td>
                                    <td align="left" style="height: 19px">
                                        <asp:Label ID="lblStatusA" runat="server" Font-Bold="True" Font-Names="Calibri" 
                                            Font-Size="Small"></asp:Label>
                                    </td>
                                    <td align="center" style="height: 19px">
                                        &nbsp;</td>
                                    <td style="height: 19px">
                                        </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td align="center" class="style2">
                                        &nbsp;</td>
                                    <td align="center" class="style2" style="width: 44px">
                                        &nbsp;</td>
                                    <td align="center" style="width: 127px">
                                        &nbsp;</td>
                                    <td align="left">
                                        <asp:CheckBox ID="chkApproved" runat="server" Font-Bold="True" 
                                            Font-Names="Calibri" Font-Size="Small" Text="Approved" 
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
                                         <td align="center" class="style2">
                                                &nbsp;</td>
                                         <td align="center" class="style2" style="width: 44px">
                                             &nbsp;</td>
                                         <td align="left" style="width: 127px">
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
                                         <td align="center" class="style2">
                                             &nbsp;</td>
                                         <td align="center" class="style2" style="width: 44px">
                                             &nbsp;</td>
                                         <td align="left" style="width: 127px">
                                             <asp:Label ID="Label7" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                 Text="Approved By:"></asp:Label>
                                         </td>
                                         <td align="left">
                                             <asp:TextBox ID="txtApprovedBy" runat="server" ReadOnly="True" 
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
                                            Text="Save Permit Recommendation" />
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


