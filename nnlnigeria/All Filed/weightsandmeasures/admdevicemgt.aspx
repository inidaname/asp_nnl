<%@ Page Title="INSTRUMENT MANAGEMENT" Language="VB" MasterPageFile="~/adminpage.master" AutoEventWireup="false" CodeFile="admdevicemgt.aspx.vb" Inherits="admdevicemgt" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <cc1:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server">
    </cc1:toolkitscriptmanager>


<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:Panel ID="Panel1" runat="server">

  <table style="width: 100%;">
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td style="width: 426px">
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
                    &nbsp;
                </td>
                <td>
                    &nbsp;</td>
                <td align="right" style="width: 426px">
                    <asp:Label ID="Label1" runat="server" Font-Names="Calibri" Font-Size="Small" 
                        Text="Select Company Name:"></asp:Label>
                </td>
                <td align="left">
                    <asp:DropDownList ID="cboCompany" runat="server" AutoPostBack="True" 
                        Font-Names="Calibri" Font-Size="Small">
                    </asp:DropDownList>
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
                <td align="right" style="width: 426px">
                    &nbsp;</td>
                <td align="left">
                    <asp:Label ID="lblccount" runat="server" Font-Names="Calibri" Font-Size="Small"></asp:Label>
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
                    &nbsp;
                </td>
                <td align="center" colspan="5">
                    <asp:GridView ID="grd" runat="server" AllowPaging="True" BackColor="White" 
                        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="2" 
                        CellSpacing="2" EmptyDataText="NO RECORD FOUND" EnableModelValidation="True" 
                        Font-Names="Calibri" Font-Size="Small" GridLines="Vertical" Height="120px" 
                        PageSize="25" ShowFooter="True" Width="100%">
                        <AlternatingRowStyle BackColor="#DCDCDC" />
                        <Columns>
                            <asp:CommandField HeaderText="Action" SelectText="Select" 
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
                <td style="width: 426px">
                    <asp:TextBox ID="txtDeviceID" runat="server" Width="60px" Visible="False"></asp:TextBox>
                </td>
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
                    &nbsp;</td>
                <td colspan="5">
                    <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" 
                        Width="100%">
                        <cc1:TabPanel ID="TabRecommeded" runat="server" HeaderText="INVOICES">

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
                                    <td align="center" valign="top">
                                       <asp:GridView ID="grdinvioce" runat="server" AllowPaging="True" BackColor="White" 
                        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="2" 
                        CellSpacing="2" EmptyDataText="NO RECORD FOUND" EnableModelValidation="True" 
                        Font-Names="Calibri" Font-Size="Small" GridLines="Vertical" Height="120px" 
                        PageSize="15" ShowFooter="True" Width="100%">
                        <AlternatingRowStyle BackColor="Gainsboro" />
                        <Columns>
                            <asp:CommandField HeaderText="Action" 
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
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
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

                        <cc1:TabPanel ID="TabVerificationSheet" runat="server" HeaderText="VERIFICATION SHEET">
                            <HeaderTemplate>
                                &nbsp;&nbsp;&nbsp;&nbsp; VERIFICATION SHEET
                            </HeaderTemplate>
                         <ContentTemplate>

                         <asp:Panel ID="pnlVerificationSheet" runat="server" >

                             <table style="width: 100%;">
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td style="width: 277px">
                                        &nbsp;</td>
                                    <td style="width: 106px">
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
                                    <td style="width: 106px">
                                        <asp:Label ID="Label8" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                            Text="Standard Gauge:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtInpectionOfficer" runat="server" 
                                            ValidationGroup="StandardMeasure|Invalid standard guage" Width="204px"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="txtInpectionOfficer_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" TargetControlID="txtInpectionOfficer" 
                                            ValidChars="0123456789.">
                                        </cc1:FilteredTextBoxExtender>
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
                                     <td style="width: 106px">
                                         <asp:Label ID="Label9" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                             Text="Verified Guage:"></asp:Label>
                                     </td>
                                     <td>
                                         <asp:TextBox ID="TextBox4" runat="server" Width="204px" 
                                             ValidationGroup="VerifiedMeasure|Invalid verified guage"></asp:TextBox>
                                         <cc1:FilteredTextBoxExtender ID="TextBox4_FilteredTextBoxExtender" 
                                             runat="server" Enabled="True" TargetControlID="TextBox4" 
                                             ValidChars=".0123456789">
                                         </cc1:FilteredTextBoxExtender>
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
                                     <td style="width: 106px">
                                         <asp:Label ID="Label11" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                             Text="Guage Name:"></asp:Label>
                                     </td>
                                     <td>
                                         <asp:TextBox ID="TextBox6" runat="server" Width="204px" 
                                             ValidationGroup="MeasureType|Invalid Guage Name"></asp:TextBox>
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
                                     <td style="width: 106px">
                                         <asp:Label ID="Label31" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                             Text="Instrument Tag:"></asp:Label>
                                     </td>
                                     <td>
                                         <asp:DropDownList ID="DropDownList1" runat="server" 
                                             ValidationGroup="DeviceCurrentState|You have not selected instrument tags" 
                                             Width="204px">
                                             <asp:ListItem>SELECT INSTRUMENT</asp:ListItem>
                                             <asp:ListItem>NEW INSTRUMENT</asp:ListItem>
                                             <asp:ListItem>APPROVED INSTRUMENT</asp:ListItem>
                                             <asp:ListItem>UNAPPROVED INSTRUMENT</asp:ListItem>
                                             <asp:ListItem>OUT OF ORDER</asp:ListItem>
                                             <asp:ListItem>REJECTED INSTRUMENT</asp:ListItem>
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
                                     <td style="width: 106px" valign="top">
                                         <asp:Label ID="Label29" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                             Text="Comments:"></asp:Label>
                                     </td>
                                     <td>
                                         <asp:TextBox ID="TextBox7" runat="server" Height="100px" TextMode="MultiLine" 
                                             ValidationGroup="comments|Invalid comments" Width="204px"></asp:TextBox>
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
                                     <td align="right" style="width: 106px">
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
                                         <asp:TextBox ID="txtDeviceIDVS" runat="server" ValidationGroup="DeviceID|Invalid Instrument ID,Please select from the grid." 
                                             Width="60px" Visible="False"></asp:TextBox>
                                         <asp:TextBox ID="txtDeviceISVUSer" runat="server" ValidationGroup="userID|Please log out and log in again" 
                                             Width="60px" Visible="False"></asp:TextBox>
                                         <asp:TextBox ID="txtVSsysID" runat="server" Width="60px" Visible="False"></asp:TextBox>
                                         <asp:TextBox ID="txttranscode" runat="server" ValidationGroup="transcode" 
                                             Visible="False" Width="60px"></asp:TextBox>
                                     </td>
                                     <td align="right" style="width: 106px">
                                         <asp:Button ID="btnResetVS" runat="server" Text="Reset" />
                                         <cc1:ConfirmButtonExtender ID="btnResetVS_ConfirmButtonExtender" runat="server" 
                                             ConfirmOnFormSubmit="True" 
                                             ConfirmText="Are you sure you want to RESET this form" Enabled="True" 
                                             TargetControlID="btnResetVS">
                                         </cc1:ConfirmButtonExtender>
                                     </td>
                                     <td>
                                         <asp:Button ID="btnsheet" runat="server" Text="Save Record" />
                                         <cc1:ConfirmButtonExtender ID="btnsheet_ConfirmButtonExtender" runat="server" 
                                             ConfirmOnFormSubmit="True" 
                                             ConfirmText="Are you sure you want to SAVE this record" Enabled="True" 
                                             TargetControlID="btnsheet">
                                         </cc1:ConfirmButtonExtender>
                                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                         <asp:Button ID="btnVSHDelete" runat="server" Text="Delete" Visible="False" />
                                         <cc1:ConfirmButtonExtender ID="btnVSHDelete_ConfirmButtonExtender" 
                                             runat="server" ConfirmOnFormSubmit="True" 
                                             ConfirmText="Are you sure you want to DELETE this record" Enabled="True" 
                                             TargetControlID="btnVSHDelete">
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
                                     <td align="right" style="width: 106px">
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
                                     <td colspan="3">
                                         <asp:GridView ID="grdvsheet" runat="server" AllowPaging="True" 
                                             BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
                                             CellPadding="2" CellSpacing="2" EmptyDataText="NO RECORD FOUND" 
                                             EnableModelValidation="True" Font-Names="Calibri" Font-Size="Small" 
                                             GridLines="Vertical" Height="120px" PageSize="15" ShowFooter="True" 
                                             Width="100%">
                                             <AlternatingRowStyle BackColor="Gainsboro" />
                                             <Columns>
                                                 <asp:CommandField HeaderText="Action" ShowSelectButton="True" />
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
                                     <td style="width: 106px">
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
                                     <td style="width: 106px">
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
                                     <td style="width: 106px">
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

                         <cc1:TabPanel ID="TabLN" runat="server" HeaderText="LEGAL NOTICES">
                             <ContentTemplate>

                               <asp:Panel id="pnlLN" runat="server" >

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
                                    <td align="center">
                                        <asp:Label ID="Label30" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                            Text="Heading"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtDeviceID0" runat="server" 
                                            ValidationGroup="Heading|Invalid heading" Width="204px"></asp:TextBox>
                                    </td>
                                    <td align="center" colspan="2">
                                        &nbsp;</td>
                                    <td align="center">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td align="center" class="style2" style="width: 555px" valign="top">
                                        <asp:Label ID="Label16" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                            Text="Legal Notices"></asp:Label>
                                    </td>
                                    <td align="center" class="style2" style="width: 44px">
                                        <asp:TextBox ID="TextBox8" runat="server" Height="200px" 
                                            style="margin-left: 0px" TextMode="MultiLine" 
                                            ValidationGroup="Notices|Invalid Notices" Width="704px"></asp:TextBox>
                                    </td>
                                    <td align="left" style="width: 127px;">
                                        &nbsp;</td>
                                    <td align="left">
                                        &nbsp;</td>
                                    <td align="center">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="height: 19px">
                                        </td>
                                    <td align="right" style="height: 19px; width: 555px;">
                                        <asp:TextBox ID="txtDeviceILN" runat="server" ValidationGroup="DeviceID|Invalid Instrument ID,Please select from the grid." 
                                            Width="60px" Visible="False"></asp:TextBox>
                                        <asp:TextBox ID="txtLNsysID" runat="server" Width="60px" Visible="False"></asp:TextBox>
                                    </td>
                                    <td align="left" style="height: 19px; width: 44px;">
                                        <asp:Button ID="btnResetLN" runat="server" Text="Reset" 
                                            style="height: 26px; width: 50px" />
                                        <cc1:ConfirmButtonExtender ID="btnResetLN_ConfirmButtonExtender" runat="server" 
                                            ConfirmOnFormSubmit="True" 
                                            ConfirmText="Are you sure you want to RESET this form" Enabled="True" 
                                            TargetControlID="btnResetLN">
                                        </cc1:ConfirmButtonExtender>
                                        <asp:Button ID="btnLN" runat="server" Text="Save Record" />
                                        <cc1:ConfirmButtonExtender ID="btnLN_ConfirmButtonExtender" runat="server" 
                                            ConfirmOnFormSubmit="True" 
                                            ConfirmText="Are you sure you want to SAVE this record" Enabled="True" 
                                            TargetControlID="btnLN">
                                        </cc1:ConfirmButtonExtender>
                                        <asp:Button ID="btnLNDelete" runat="server" Text="Delete" />
                                        <cc1:ConfirmButtonExtender ID="btnLNDelete_ConfirmButtonExtender" runat="server" 
                                            ConfirmOnFormSubmit="True" 
                                            ConfirmText="Are you sure you want to DELETE this record" Enabled="True" 
                                            TargetControlID="btnLNDelete">
                                        </cc1:ConfirmButtonExtender>
                                    </td>
                                    <td align="left" style="width: 127px; height: 19px;">
                                        &nbsp;</td>
                                    <td align="left" style="height: 19px">
                                        &nbsp;</td>
                                    <td align="center" style="height: 19px">
                                        &nbsp;</td>
                                    <td style="height: 19px">
                                        </td>
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
                                             <asp:GridView ID="grdlegal" runat="server" AllowPaging="True" BackColor="White" 
                                                 BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="2" 
                                                 CellSpacing="2" EmptyDataText="NO RECORD FOUND" EnableModelValidation="True" 
                                                 Font-Names="Calibri" Font-Size="Small" GridLines="Vertical" Height="120px" 
                                                 PageSize="15" ShowFooter="True" Width="100%">
                                                 <AlternatingRowStyle BackColor="Gainsboro" />
                                                 <Columns>
                                                     <asp:CommandField HeaderText="Action" ShowSelectButton="True" />
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
                                         <td align="center" valign="top">
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
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td style="width: 426px">
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
                <td style="width: 426px">
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
                <td style="width: 426px">
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
</asp:UpdatePanel>


</asp:Content>

