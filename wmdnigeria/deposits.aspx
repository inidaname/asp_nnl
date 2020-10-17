<%@ Page Title="DEPOSIT" Language="VB" MasterPageFile="~/companynoheader.master" AutoEventWireup="false" CodeFile="deposits.aspx.vb" Inherits="deposits" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>
    <asp:Panel ID="Panel1" runat="server">

    <table style="width:100%;">
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td style="width: 296px">
                &nbsp;</td>
            <td style="width: 139px">
                &nbsp;</td>
            <td>
                <asp:TextBox ID="txtID" runat="server" ValidationGroup="companyID" Width="30px" 
                    Visible="False"></asp:TextBox>
                <asp:TextBox ID="txtTranscode" runat="server" Font-Names="Calibri" 
                    Font-Size="Small" ValidationGroup="TransCode" Width="204px" 
                    Visible="False"></asp:TextBox>
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
            <td style="width: 296px">
                &nbsp;</td>
            <td style="width: 139px">
                <asp:Label ID="Label1" runat="server" Text="Amount To Deposit:" 
                    Font-Names="Calibri" Font-Size="Small"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAmt" runat="server" Width="204px" Font-Names="Calibri" 
                    Font-Size="Small" ValidationGroup="sDeposit|Invalid deposit amount"></asp:TextBox>
                   <cc1:FilteredTextBoxExtender ID="txtusername7_FilteredTextBoxExtender" 
                                        runat="server" Enabled="True" TargetControlID="txtAmt" 
                                        ValidChars="1234567890,+">
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
            <td style="width: 296px">
                &nbsp;</td>
            <td style="width: 139px">
                <asp:Label ID="Label2" runat="server" Text="Payment Type:" Font-Names="Calibri" 
                    Font-Size="Small"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="cboPayType" runat="server" Width="204px" 
                    Font-Names="Calibri" Font-Size="Small" 
                    ValidationGroup="PayType|Invalid Pay type" AutoPostBack="True" >
                    <asp:ListItem>Select Payment Type</asp:ListItem>
                    <asp:ListItem>Cash</asp:ListItem>
                    <asp:ListItem>Cheque Payment</asp:ListItem>
                    <asp:ListItem>Online Payment</asp:ListItem>
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
            <td style="width: 296px">
                &nbsp;</td>
            <td style="width: 139px">
                <asp:Label ID="lblRec" runat="server" Text="Transaction ID:" 
                    Font-Names="Calibri" Font-Size="Small"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCode" runat="server" Width="204px" 
                    Font-Names="Calibri" Font-Size="Small" 
                    ValidationGroup="TransID|Invalid Transaction ID"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 18px">
            </td>
            <td style="height: 18px">
            </td>
            <td style="width: 296px; height: 18px;">
            </td>
            <td style="width: 139px; height: 18px;" valign="top">
                <asp:Label ID="lblRec0" runat="server" Font-Names="Calibri" Font-Size="Small" 
                    Text="Bank Name:" Visible="False"></asp:Label>
            </td>
            <td style="height: 18px">
                <asp:TextBox ID="txtbankname" runat="server" Font-Names="Calibri" 
                    Font-Size="Small" ValidationGroup="BankName" Visible="False" Width="204px"></asp:TextBox>
            </td>
            <td style="height: 18px">
            </td>
            <td style="height: 18px">
            </td>
            <td style="height: 18px">
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td style="width: 296px">
                &nbsp;</td>
            <td style="width: 139px" valign="top">
                <asp:Label ID="Label3" runat="server" Font-Names="Calibri" Font-Size="Small" 
                    Text="Narration:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNarration" runat="server" Font-Names="Calibri" 
                    Font-Size="Small" Height="80px" TextMode="MultiLine" 
                    ValidationGroup="narration|Invalid Narration" Width="204px"></asp:TextBox>
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
            <td style="width: 296px">
                &nbsp;</td>
            <td style="width: 139px" align="right">
                &nbsp;</td>
            <td>
                <asp:TextBox ID="txtOrderID" runat="server" ValidationGroup="OrderID" 
                    Visible="False" Width="30px"></asp:TextBox>
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
            <td style="width: 296px">
                &nbsp;</td>
            <td align="right" style="width: 139px">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnPayment" runat="server" Text="Save Deposit" />
                <cc1:ConfirmButtonExtender ID="btnPayment_ConfirmButtonExtender" runat="server" 
                    ConfirmOnFormSubmit="True" 
                    ConfirmText="Are you SURE you want to SAVE this record?" Enabled="True" 
                    TargetControlID="btnPayment">
                </cc1:ConfirmButtonExtender>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnReset" runat="server" Text="Reset" />
                <cc1:ConfirmButtonExtender ID="btnReset_ConfirmButtonExtender" runat="server" 
                    ConfirmOnFormSubmit="True" 
                    ConfirmText="Are you SURE you want to RESET this record?" Enabled="True" 
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
            <td>
                &nbsp;</td>
            <td style="width: 296px">
                &nbsp;</td>
            <td style="width: 139px">
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
            <td colspan="6">
                <asp:GridView ID="grd" runat="server" AllowPaging="True" BackColor="White" 
                    BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="2" 
                    CellSpacing="2" EmptyDataText="NO INVOICE" EnableModelValidation="True" 
                    Font-Names="Calibri" Font-Size="Small" GridLines="Vertical" PageSize="20" 
                    ShowFooter="True" Width="100%">
                    <AlternatingRowStyle BackColor="#DCDCDC" />
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
            <td>
                &nbsp;</td>
            <td style="width: 296px">
                &nbsp;</td>
            <td style="width: 139px">
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
            <td style="width: 296px">
                &nbsp;</td>
            <td style="width: 139px">
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

</asp:Content>

