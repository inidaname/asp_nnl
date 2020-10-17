<%@ Page Title="" Language="VB" MasterPageFile="~/adminpage.master" AutoEventWireup="false" CodeFile="setupStaticData.aspx.vb" Inherits="setupStaticData" %>
<%@ Import Namespace="System.Data" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <cc1:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server">
    </cc1:toolkitscriptmanager>

    <table style="width:100%;">
        <tr>
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
                                        <td align="center">
                                            <asp:Label ID="Label20" runat="server" Text="Upload Changes"></asp:Label>
                                            <asp:DropDownList ID="dllSetupDate" runat="server">
                                                <asp:ListItem>All Static</asp:ListItem>
                                                <asp:ListItem>Fee Group</asp:ListItem>
                                                <asp:ListItem>Frontpage</asp:ListItem>
                                                <asp:ListItem>Instrument Setup</asp:ListItem>
                                                <asp:ListItem>Setup Addresses</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td align="center">
                                            <asp:ImageButton ID="imgBtnState" runat="server" 
                                                ImageUrl="~/images/sa/Button-Refresh-icon.png" />
                                            <cc1:confirmbuttonextender ID="imgBtnState_ConfirmButtonExtender" 
                                                runat="server" ConfirmOnFormSubmit="True" 
                                                
                                                ConfirmText="Are you sure you want to UPLOAD/UPDATE the entire changes made to STATIC TABLE?" Enabled="True" 
                                                TargetControlID="imgBtnState">
                                            </cc1:confirmbuttonextender>
                                            <br />
                                            Update/Upload All Changes Made To Static Data Table</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <table style="width: 100%;">
                    <tr>
                        <td class="style2" style="width: 395px">
                            &nbsp;</td>
                        <td style="width: 95px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style2" style="width: 395px">
                            &nbsp;</td>
                        <td style="width: 95px">
                            <asp:Label ID="Label21" runat="server" Text="Amt Per Barrel*:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtamtPerBarrel" runat="server"></asp:TextBox>
                             <cc1:FilteredTextBoxExtender ID="txtamtPerBarrel_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" TargetControlID="txtamtPerBarrel" 
                                ValidChars="1234567890.">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style2" style="width: 395px">
                            &nbsp;</td>
                        <td style="width: 95px">
                            <asp:Label ID="Label22" runat="server" Text="Exchange Rate*:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtExchangeRate" runat="server"></asp:TextBox>
                             <cc1:FilteredTextBoxExtender ID="txtExchangeRate_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" TargetControlID="txtExchangeRate" 
                                ValidChars="1234567890.">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style2" style="width: 395px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
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
        </tr>
    </table>
</asp:Content>

