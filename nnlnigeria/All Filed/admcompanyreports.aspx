<%@ Page Title="COMPANY REPORT" Language="VB" MasterPageFile="~/adminpage.master" AutoEventWireup="false" CodeFile="admcompanyreports.aspx.vb" Inherits="admcompanyreports" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        
        <asp:Panel ID="Panel1" runat="server">
                        <table style="width:100%;" cellspacing="1" cellpadding="0">
                        
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td colspan="8">
                                    <div class="item_title">
                                        &nbsp;&nbsp;&nbsp;SEARCH COMPANY&#39;S DETAILS</div>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label8" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Name:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtcompany" runat="server" ToolTip="enter company name" 
                                        ValidationGroup="companyName|Invalid Company Name" Width="150px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label11" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="State:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="cboState" runat="server" AutoPostBack="True" 
                                        ToolTip="select copany's state" ValidationGroup="StateID|Invalid State|1" 
                                        Width="150px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label15" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Telephone:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtusername7" runat="server" style="margin-bottom: 0px" 
                                        ToolTip="enter telephone number" 
                                        ValidationGroup="telephone|Invalid company Telephone" Width="150px"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtusername7_FilteredTextBoxExtender" 
                                        runat="server" Enabled="True" TargetControlID="txtusername7" 
                                        ValidChars="1234567890,+">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                                <td>
                                    <asp:Label ID="Label18" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Fax Number:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtusername10" runat="server" 
                                        ToolTip="enter company fax number" ValidationGroup="faxNumber" Width="150px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Address:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtusername12" runat="server" 
                                        ToolTip="enter company's address" 
                                        ValidationGroup="streetAddress|Invalid company address" Width="150px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label12" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="LGA:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="cboLGA" runat="server" 
                                        ToolTip="enter company's LGA" ValidationGroup="LGAID|Invalid LGA|2" 
                                        Width="150px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label19" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Email:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtcompanyemail" runat="server" 
                                        ValidationGroup="companyEmail|Invalid company email address" Width="150px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label16" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Representative:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtusername8" runat="server" 
                                        ToolTip="enter company representative fullname" 
                                        ValidationGroup="representativeName|Company Reprentative" Width="150px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label10" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="P.O. Box:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtusername2" runat="server" ToolTip="enter company's P.O.Box" 
                                        ValidationGroup="POBOX|invalid P.O. Box" Width="150px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label13" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="City:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="cboCity" runat="server" ToolTip="enter company's city" 
                                        ValidationGroup="cityID|Invalid City|3" Width="150px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label14" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Website:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtusername6" runat="server" ToolTip="enter company website" 
                                        ValidationGroup="companywebsite|Invalid company website" Width="150px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label17" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Mobile:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtusername9" runat="server" 
                                        ToolTip="enter company rep mobile" 
                                        ValidationGroup="mobilephone|Invalid Representative Mobile" Width="150px"></asp:TextBox>
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
                                <td colspan="8">
                                    <div class="item_title">
                                        &nbsp;&nbsp;&nbsp;SEARCH BY FORM FILLED BY</div>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label20" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Title:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="cbosTitle" runat="server" 
                                        ToolTip="select title" 
                                        ValidationGroup="filledByTitle|Please select title" Width="150px">
                                        <asp:ListItem Selected="True">Select Title</asp:ListItem>
                                        <asp:ListItem>Mr</asp:ListItem>
                                        <asp:ListItem>Mrs</asp:ListItem>
                                        <asp:ListItem>Ms</asp:ListItem>
                                        <asp:ListItem>Miss</asp:ListItem>
                                        <asp:ListItem>Dr</asp:ListItem>
                                        <asp:ListItem>Barister</asp:ListItem>
                                        <asp:ListItem>Alhaji</asp:ListItem>
                                        <asp:ListItem>Hajia</asp:ListItem>
                                        <asp:ListItem>Malam</asp:ListItem>
                                        <asp:ListItem>Evang</asp:ListItem>
                                        <asp:ListItem>Prohpet</asp:ListItem>
                                        <asp:ListItem>Bishop</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label22" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Telephone:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txttelephone" runat="server" ToolTip="enter telephone number" 
                                        ValidationGroup="filledBytelephone|Enter your telephone number" Width="150px"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txttelephone_FilteredTextBoxExtender" 
                                        runat="server" Enabled="True" TargetControlID="txttelephone" 
                                        ValidChars="1234567890,+">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkWilCard" runat="server" Font-Bold="True" 
                                        Font-Names="Calibri" Font-Size="Small" Text="Use Search Wilcard" />
                                </td>
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
                                    <asp:Label ID="Label21" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Fullname:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtfullname" runat="server" ToolTip="enter your fullname" 
                                        ValidationGroup="filledBy|Invalid fullname" Width="150px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label23" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Email Address:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtemailaddress" runat="server" 
                                        ToolTip="enter your email address" 
                                        ValidationGroup="filledByemail|Invalid email address" Width="150px"></asp:TextBox>
                                </td>
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
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Button ID="btnPreview" runat="server" style="height: 26px" Text="Search" />
                                </td>
                                <td>
                                
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
                                <td align="center" colspan="8">
                                    <asp:GridView ID="grd" runat="server" AllowPaging="True" BackColor="White" 
                                        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="2" 
                                        CellSpacing="2" EmptyDataText="NO RECORD FOUND" EnableModelValidation="True" 
                                        Font-Names="Calibri" Font-Size="Small" GridLines="Vertical" Height="110px" 
                                        PageSize="40" ShowFooter="True" Width="100%">
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
