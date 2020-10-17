<%@ Page Title="" Language="VB" MasterPageFile="~/companynoheader.master" AutoEventWireup="false" CodeFile="payment.aspx.vb" Inherits="payment" %>
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
            <td align="center" colspan="3">
                <p ID="yui_3_7_2_1_1373035972769_6141" dir="ltr" 
                    style="font-family: Calibri; font-size: medium; text-decoration: underline">
                    <b>ACCOUNT DETAILS FOR CASH PAYMENT TO ANY SKYE BANK NATION WIDE:</b></p>
                <p dir="ltr" style="font-family: Calibri; font-size: medium; ">
                    &nbsp;</p>
                <p dir="ltr" style="font-size: small">
                    <span style="font-family: Calibri"><i>ACCOUNT NAME:</i></span></p>
                <p ID="yui_3_7_2_1_1373035972769_6142" dir="ltr">
                    <span style="font-size: small">FEDERAL MINISTRY OF INDUSTRY, TRADE AND 
                    INVESTMENT</span><br style="font-size: small" /> <span style="font-size: small">
                    WEIGHTS AND MEASURES DEPARTMENT</span></p>
                <p dir="ltr" style="font-size: small">
                    &nbsp;</p>
                <p dir="ltr">
                    <span style="font-size: small"><i>BANK NAME:</i>&nbsp; <b>SKYE BANK</b></span><br style="font-size: small" />
                    <span style="font-size: small"><i>ACCOUNT NO</i>: </span><b>1750013688</b></span></p>
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
            <td align="center" colspan="3">
            <hr />
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
            <td style="width: 258px">
                &nbsp;</td>
            <td style="width: 139px">
                <asp:Label ID="Label4" runat="server" Font-Names="Calibri" Font-Size="Small" 
                    Text="Wallet:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtWallet" runat="server" Font-Names="Calibri" 
                    Font-Size="Small" ReadOnly="True" Width="204px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtWallet_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" TargetControlID="txtWallet" 
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
            <td style="width: 258px">
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
            <td style="width: 258px">
                &nbsp;</td>
            <td style="width: 139px">
                <asp:Label ID="Label1" runat="server" Text="Amount:" 
                    Font-Names="Calibri" Font-Size="Small"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAmt" runat="server" Width="204px" Font-Names="Calibri" 
                    Font-Size="Small" ValidationGroup="AmountPaid|Invalid Amount" 
                    ReadOnly="True"></asp:TextBox>
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
            <td style="width: 258px">
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
                     <asp:ListItem>Card Payment</asp:ListItem>
                    <asp:ListItem>Cash</asp:ListItem>
                    <asp:ListItem>Bank Draft</asp:ListItem>
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
            <td style="width: 258px">
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
            <td style="width: 258px; height: 18px;">
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
            <td style="width: 258px">
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
            <td style="width: 258px">
                &nbsp;</td>
            <td style="width: 139px" align="right">
                &nbsp;</td>
            <td>
                <asp:CheckBox ID="chkOk" runat="server" ValidationGroup="isDeposit" 
                    Visible="False" />
                <asp:TextBox ID="txtOrderID" runat="server" Font-Names="Calibri" 
                    Font-Size="Small" ValidationGroup="OrderID" Visible="False" Width="50px"></asp:TextBox>
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
            <td style="width: 258px">
                &nbsp;</td>
            <td align="right" style="width: 139px">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnPayment" runat="server" Text="Save Payment" />
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
            <td style="width: 258px">
                &nbsp;</td>
            <td style="width: 139px">
                &nbsp;</td>
            <td>
                <asp:TextBox ID="txtPID" runat="server" Font-Names="Calibri" Font-Size="Small" 
                    ValidationGroup="pID" Visible="False" Width="30px"></asp:TextBox>
                <asp:TextBox ID="txtTranscode" runat="server" Font-Names="Calibri" 
                    Font-Size="Small" ValidationGroup="TransCode" Visible="False" Width="30px"></asp:TextBox>
                <asp:TextBox ID="txtID" runat="server" ValidationGroup="companyID" 
                    Visible="False" Width="30px"></asp:TextBox>
                <asp:TextBox ID="txtonlineOrderID" runat="server" Font-Names="Calibri" 
                    Font-Size="Small" ValidationGroup="onlineOrderID" Visible="False" Width="50px"></asp:TextBox>
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
            <td style="width: 258px">
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
            <td style="width: 258px">
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

