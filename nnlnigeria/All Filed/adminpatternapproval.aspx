<%@ Page Title="INSTRUMENT MANAGEMENT" Language="VB" MasterPageFile="~/adminpage.master" AutoEventWireup="false" CodeFile="adminpatternapproval.aspx.vb" Inherits="admdevicemgt" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <cc1:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server">
    </cc1:toolkitscriptmanager>


<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:Panel ID="Panel1" runat="server">

  <table style="width: 100%;">
            <tr>
                <td style="width: 61px">
                    &nbsp;</td>
                <td style="width: 304px">
                    &nbsp;</td>
                <td style="width: 209px" class="style2">
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
                <td style="width: 61px">
                    &nbsp;
                </td>
                <td style="width: 304px">
                    &nbsp;</td>
                <td align="right" style="width: 209px" class="style2">
                    <asp:RadioButton ID="optApprovalP" runat="server" Font-Names="Calibri" 
                        Font-Size="Small" Text="Approval Pertern" GroupName="22" 
                        AutoPostBack="True" />
                </td>
                <td align="left">
                    <asp:RadioButton ID="optInitial" runat="server" Font-Names="Calibri" 
                        Font-Size="Small" Text="Initial Verification Certificate" GroupName="22" 
                        AutoPostBack="True" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="optBoth" runat="server" Checked="True" 
                        Font-Names="Calibri" Font-Size="Small" Text="Both" GroupName="22" 
                        AutoPostBack="True" />
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
                <td style="width: 61px">
                    &nbsp;</td>
                <td style="width: 304px">
                    &nbsp;</td>
                <td align="right" style="width: 209px" class="style2">
                    &nbsp;</td>
                <td align="left">
                    <asp:Button ID="btnSearch" runat="server" Text="Search" />
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 61px">
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
                <td style="width: 61px">
                    &nbsp;</td>
                <td style="width: 304px">
                    &nbsp;</td>
                <td style="width: 209px" class="style2">
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
                <td style="width: 61px">
                    &nbsp;</td>
                <td style="width: 304px" align="right">
                    <asp:Label ID="lblCerticateNo" runat="server" Font-Names="Calibri" 
                        Font-Size="Small" Text="Approval Pattern Certificate No." Visible="False"></asp:Label>
                </td>
                <td style="width: 209px" class="style2">
                    <asp:TextBox ID="txtCerticateNo" runat="server" ValidationGroup="CertificateNo" 
                        Width="204px" Visible="False"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblDateIssued" runat="server" Font-Names="Calibri" 
                        Font-Size="Small" Text="Date Issued" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtDateIssued" runat="server" Font-Bold="False" 
                        Font-Names="Calibri" Font-Size="Small" Height="20px" 
                        ValidationGroup="certDateIssed" Width="80px"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" 
                        Format="yyyy-MM-dd" PopupButtonID="childimgbtnCal0" 
                        TargetControlID="txtDateIssued">
                    </cc1:CalendarExtender>
                    <asp:ImageButton ID="childimgbtnCal0" runat="server" Height="16px" 
                        ImageUrl="~/img/cal3.png" ValidationGroup="dd" Width="16px" 
                        Visible="False" />
                </td>
                <td>
                    <asp:TextBox ID="txtID" runat="server" Visible="False"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 61px">
                    &nbsp;</td>
                <td align="right" style="width: 304px">
                    <asp:Label ID="lblCerticateNo0" runat="server" Font-Names="Calibri" 
                        Font-Size="Small" Text="Initial Verification Certificate No." 
                        Visible="False"></asp:Label>
                </td>
                <td class="style2" style="width: 209px">
                    <asp:TextBox ID="txtCerticateNo0" runat="server" 
                        ValidationGroup="CertificateNoVerification" Width="204px" Visible="False"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblDateIssued0" runat="server" Font-Names="Calibri" 
                        Font-Size="Small" Text="Date Issued" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtDateIssued0" runat="server" Font-Bold="False" 
                        Font-Names="Calibri" Font-Size="Small" Height="20px" 
                        ValidationGroup="VerificationcertDateIssed" Width="80px" Visible="False"></asp:TextBox>
                    <cc1:CalendarExtender ID="txtDateIssued0_CalendarExtender" runat="server" 
                        Enabled="True" Format="yyyy-MM-dd" PopupButtonID="childimgbtnCal1" 
                        TargetControlID="txtDateIssued0">
                    </cc1:CalendarExtender>
                    <asp:ImageButton ID="childimgbtnCal1" runat="server" Height="16px" 
                        ImageUrl="~/img/cal3.png" ValidationGroup="dd" Width="16px" 
                        Visible="False" />
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 61px">
                    &nbsp;</td>
                <td style="width: 304px">
                    &nbsp;</td>
                <td style="width: 209px" class="style2">
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
                <td style="width: 61px">
                    &nbsp;</td>
                <td style="width: 304px">
                    &nbsp;</td>
                <td class="style2" style="width: 209px">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" />
                    <cc1:ConfirmButtonExtender ID="btnUpdate_ConfirmButtonExtender" runat="server" 
                        ConfirmOnFormSubmit="True" 
                        ConfirmText="Are you sure you want UPDATE this Record?" Enabled="True" 
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
        </table>
        </asp:Panel>
      
    </ContentTemplate>
</asp:UpdatePanel>


</asp:Content>

