<%@ Page Title="Setup Instrument Price" Language="VB" MasterPageFile="~/adminpage.master" AutoEventWireup="false"  EnableEventValidation="false" ValidateRequest ="false" CodeFile="amdsetupmeasurename.aspx.vb" Inherits="amdsetupdeviceprice" %>

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
                    <asp:Label ID="Label25" runat="server" Font-Names="Calibri" Font-Size="Small" 
                        Text="Measure Name:"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="TextBox3" runat="server" 
                        ValidationGroup="MeasureName|Invalid Measure name"></asp:TextBox>
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
                    <asp:Label ID="Label27" runat="server" Font-Names="Calibri" Font-Size="Small" 
                        Text="Measurement:"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="TextBox2" runat="server" 
                        ValidationGroup="MeasureValue|Invalid measurement"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="TextBox2_FilteredTextBoxExtender" 
                        runat="server" Enabled="True" TargetControlID="TextBox2" 
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
                <td align="right" style="width: 426px">
                    <asp:Button ID="btnPreview" runat="server" style="height: 26px" Text="Reset" />
                </td>
                <td align="left">
                    <asp:Button ID="btnPreview0" runat="server" style="height: 26px" 
                        Text="Submit" />
                    <cc1:ConfirmButtonExtender ID="btnPreview0_ConfirmButtonExtender" 
                        runat="server" ConfirmOnFormSubmit="True" 
                        ConfirmText="Are you sure you want SAVE this record?" Enabled="True" 
                        TargetControlID="btnPreview0">
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
