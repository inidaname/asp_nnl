<%@ Page Title="COMPANY MANAGEMENT" Language="VB" MasterPageFile="~/adminpage.master" AutoEventWireup="false" EnableEventValidation="false" ValidateRequest="false"  CodeFile="admcompanymgt.aspx.vb" Inherits="admcompanymgt" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>
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
                <td align="center" colspan="5">
                         <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                        Width="100%">
                        <cc1:TabPanel ID="TabRecommeded" runat="server" HeaderText="APPROVE PAYMENT">

                           <ContentTemplate>

                           <asp:Panel id="pnlRecommend" runat="server" >

                                <table style="width: 100%;">
                                <tr>
                                    <td>
                                        &nbsp;&nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td align="center" valign="top">
                                       <asp:GridView ID="grdappPay" runat="server" AllowPaging="True" BackColor="White" 
                        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="2" 
                        CellSpacing="2" EmptyDataText="NO RECORD FOUND" EnableModelValidation="True" 
                        Font-Names="Calibri" Font-Size="Small" GridLines="Vertical" Height="120px" 
                        PageSize="15" ShowFooter="True" Width="100%">
                        <AlternatingRowStyle BackColor="Gainsboro" />
                        <Columns>
                            <asp:CommandField HeaderText="Action" 
                                ShowSelectButton="True" SelectText="Edit" />
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
                                        &nbsp;&nbsp;</td>
                                    <td align="center">
                                        &nbsp;&nbsp;</td>
                                    <td>
                                        &nbsp;&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;&nbsp;</td>
                                    <td align="center">
                                        <table style="width:100%;">
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style2" style="width: 171px">
                                                    &nbsp;</td>
                                                <td align="right">
                                                    <asp:Label ID="Label31" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                        Text="Company Name:"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtCompanyName" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                        ValidationGroup="TransID|Invalid Transaction ID" Width="204px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style2" style="width: 171px">
                                                    &nbsp;</td>
                                                <td align="right">
                                                    <asp:Label ID="Label32" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                        Text="Trans Amount:"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtAmount" runat="server" Font-Names="Calibri" 
                                                        Font-Size="Small" ValidationGroup="TransID|Invalid Transaction ID" 
                                                        Width="204px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style2" style="width: 171px">
                                                    &nbsp;</td>
                                                <td align="right">
                                                    <asp:Label ID="Label33" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                        Text="Transaction ID:"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtTransID" runat="server" Font-Names="Calibri" 
                                                        Font-Size="Small" ValidationGroup="TransID|Invalid Transaction ID" 
                                                        Width="204px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style2" style="width: 171px">
                                                    &nbsp;</td>
                                                <td align="right">
                                                    <asp:Label ID="Label34" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                        Text="Payment Type:"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtPayType" runat="server" Font-Names="Calibri" 
                                                        Font-Size="Small" ValidationGroup="TransID|Invalid Transaction ID" 
                                                        Width="204px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style2" style="width: 171px">
                                                    &nbsp;</td>
                                                <td align="right">
                                                    <asp:Label ID="Label35" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                        Text="Order ID:"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtOrderIDPay" runat="server" Font-Names="Calibri" 
                                                        Font-Size="Small" Width="204px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style2" style="width: 171px">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td align="left">
                                                    <asp:RadioButton ID="optApprove" runat="server" Checked="True" 
                                                        Font-Names="Calibri" Font-Size="Medium" Text="Approve" />
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style2" style="width: 171px">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td align="left">
                                                    <asp:RadioButton ID="optCancel" runat="server" Font-Names="Calibri" 
                                                        Font-Size="Medium" Text="Cancel" />
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style2" style="width: 171px">
                                                    &nbsp;</td>
                                                <td align="right" valign="top">
                                                    <asp:Label ID="Label30" runat="server" Text="Narration:" Font-Names="Calibri" 
                                                        Font-Size="Small"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtAPpCC" runat="server" Font-Names="Calibri" 
                                                        Font-Size="Small" Height="132px" TextMode="MultiLine" Width="200px" 
                                                        ValidationGroup="TransID|Invalid Transaction ID"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style2" style="width: 171px">
                                                    &nbsp;</td>
                                                <td valign="top">
                                                    &nbsp;</td>
                                                <td align="left">
                                                    <asp:Button ID="btnSaveApproval" runat="server" Text=" Save Record" />
                                                      <cc1:ConfirmButtonExtender ID="btnSaveApproval_ConfirmButtonExtender" runat="server" 
                                                        ConfirmOnFormSubmit="True" 
                                                        ConfirmText="Are you sure you want to MODIFY this record" Enabled="True" 
                                                        TargetControlID="btnSaveApproval">
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
                                                <td class="style2" style="width: 171px">
                                                    &nbsp;</td>
                                                <td valign="top">
                                                    &nbsp;</td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtPayCID" runat="server" Font-Names="Calibri" 
                                                        Font-Size="Small" Visible="False" Width="30px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        &nbsp;&nbsp;</td>
                                </tr>
                                <tr>
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

                        <cc1:TabPanel ID="TabVerificationSheet" runat="server" HeaderText="APPROVE DEPOSIT">
                         <ContentTemplate>

                         <asp:Panel ID="pnlVerificationSheet" runat="server" >

                             <table style="width: 100%;">
                                <tr>
                                    <td>
                                        &nbsp;&nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td align="center" valign="top">
                                       <asp:GridView ID="grdDeposit" runat="server" AllowPaging="True" BackColor="White" 
                        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="2" 
                        CellSpacing="2" EmptyDataText="NO RECORD FOUND" EnableModelValidation="True" 
                        Font-Names="Calibri" Font-Size="Small" GridLines="Vertical" Height="120px" 
                        PageSize="15" ShowFooter="True" Width="100%">
                        <AlternatingRowStyle BackColor="Gainsboro" />
                        <Columns>
                            <asp:CommandField HeaderText="Action" 
                                ShowSelectButton="True" SelectText="Edit" />
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
                                        &nbsp;&nbsp;</td>
                                    <td align="center">
                                        &nbsp;&nbsp;</td>
                                    <td>
                                        &nbsp;&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;&nbsp;</td>
                                    <td align="center">
                                        <table style="width:100%;">
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style2" style="width: 171px">
                                                    &nbsp;</td>
                                                <td align="right">
                                                    <asp:Label ID="Label2" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                        Text="Company Name:"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtdcn" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                        ValidationGroup="TransID|Invalid Transaction ID" Width="204px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style2" style="width: 171px">
                                                    &nbsp;</td>
                                                <td align="right">
                                                    <asp:Label ID="Label3" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                        Text="Trans Amount:"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtdamt" runat="server" Font-Names="Calibri" 
                                                        Font-Size="Small" ValidationGroup="TransID|Invalid Transaction ID" 
                                                        Width="204px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style2" style="width: 171px">
                                                    &nbsp;</td>
                                                <td align="right">
                                                    <asp:Label ID="Label4" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                        Text="Transaction ID:"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtdtransID" runat="server" Font-Names="Calibri" 
                                                        Font-Size="Small" ValidationGroup="TransID|Invalid Transaction ID" 
                                                        Width="204px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style2" style="width: 171px">
                                                    &nbsp;</td>
                                                <td align="right">
                                                    <asp:Label ID="Label5" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                        Text="Payment Type:"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtdpaytype" runat="server" Font-Names="Calibri" 
                                                        Font-Size="Small" ValidationGroup="TransID|Invalid Transaction ID" 
                                                        Width="204px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style2" style="width: 171px">
                                                    &nbsp;</td>
                                                <td align="right">
                                                    <asp:Label ID="Label36" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                        Text="Order ID:"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtOrderIDDeposit" runat="server" Font-Names="Calibri" 
                                                        Font-Size="Small" Width="204px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style2" style="width: 171px">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td align="left">
                                                    <asp:RadioButton ID="optDApp" runat="server" Checked="True" 
                                                        Font-Names="Calibri" Font-Size="Medium" Text="Approve" />
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style2" style="width: 171px">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td align="left">
                                                    <asp:RadioButton ID="RadioButton2" runat="server" Font-Names="Calibri" 
                                                        Font-Size="Medium" Text="Cancel" />
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style2" style="width: 171px">
                                                    &nbsp;</td>
                                                <td align="right" valign="top">
                                                    <asp:Label ID="Label6" runat="server" Text="Narration:" Font-Names="Calibri" 
                                                        Font-Size="Small"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="TXTNarrationdepo" runat="server" Font-Names="Calibri" 
                                                        Font-Size="Small" Height="132px" TextMode="MultiLine" Width="200px" 
                                                        ValidationGroup="TransID|Invalid Transaction ID"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style2" style="width: 171px">
                                                    &nbsp;</td>
                                                <td valign="top">
                                                    &nbsp;</td>
                                                <td align="left">
                                                    <asp:Button ID="btnSaveDeposit" runat="server" Text=" Save Record" />
                                                      <cc1:ConfirmButtonExtender ID="btnSaveDeposit_ConfirmButtonExtender" runat="server" 
                                                        ConfirmOnFormSubmit="True" 
                                                        ConfirmText="Are you sure you want to MODIFY this record" Enabled="True" 
                                                        TargetControlID="btnSaveDeposit">
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
                                                <td class="style2" style="width: 171px">
                                                    &nbsp;</td>
                                                <td valign="top">
                                                    &nbsp;</td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtDepositCID" runat="server" Font-Names="Calibri" 
                                                        Font-Size="Small" Visible="False" Width="30px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        &nbsp;&nbsp;</td>
                                </tr>
                                <tr>
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

                    </cc1:TabContainer> </td>
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
                <td align="right" style="width: 426px">
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
                    &nbsp;
                </td>
                <td align="center" colspan="5">
                    <asp:GridView ID="grd" runat="server" AllowPaging="True" BackColor="White" 
                        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="2" 
                        CellSpacing="2" EmptyDataText="NO RECORD FOUND" EnableModelValidation="True" 
                        Font-Names="Calibri" Font-Size="Small" GridLines="Vertical" Height="110px" 
                        PageSize="2" ShowFooter="True" Width="100%">
                        <AlternatingRowStyle BackColor="#DCDCDC" />
                        <EmptyDataRowStyle Font-Names="Agency FB" Font-Size="Small" 
                            HorizontalAlign="Center" VerticalAlign="Top" />
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <HeaderStyle BackColor="#000084" Font-Bold="True" Font-Names="Calibri" 
                            Font-Size="Small" ForeColor="White" HorizontalAlign="left" 
                            VerticalAlign="Top" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="center" />
                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" HorizontalAlign="left" 
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
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td style="width: 426px">
                    &nbsp;</td>
                <td>
                    <asp:CheckBox ID="chkStatus" runat="server" Font-Bold="True" 
                        Font-Names="Calibri" Font-Size="Small" Text="Active?" />
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
                    <asp:Button ID="btnUpdate" runat="server" style="margin-left: 0px" 
                        Text="Update" Enabled="False" />
                    <cc1:ConfirmButtonExtender ID="btnUpdate_ConfirmButtonExtender" runat="server" 
                        ConfirmOnFormSubmit="True" 
                        ConfirmText="Are you sure you want to UPDATE this record" Enabled="True" 
                        TargetControlID="btnUpdate">
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
