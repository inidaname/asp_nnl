<%@ Page Title="EXPORT PERMIT MSG SETUP" Language="VB" MasterPageFile="~/adminpage.master" AutoEventWireup="false" CodeFile="admexportmsgalert.aspx.vb" Inherits="admdevicemgt" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <cc1:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server">
    </cc1:toolkitscriptmanager>


<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:Panel ID="Panel1" runat="server">

  <table style="width: 100%;">
            <tr>
                <td valign="top">
                <div> <asp:Label ID="Label1" runat="server" Text="Enter Company Name:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtsearchcomp" runat="server" Width="80px"></asp:TextBox></div>
                   
                   
                    <div>
                    <asp:Label ID="Label2" runat="server" Text="By Company Content:"></asp:Label>
                    <asp:DropDownList ID="cboAutoSearch" runat="server" Width="100px">
                        <asp:ListItem>All Value</asp:ListItem>
                        <asp:ListItem>With Content</asp:ListItem>
                        <asp:ListItem>Without Content</asp:ListItem>
                    </asp:DropDownList> <asp:Button ID="btnSearch" runat="server" Text="Search" /></div>
                 
            <center>
&nbsp;<asp:UpdateProgress ID="updProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                        <ProgressTemplate>
                            <div>
                                <img alt="progress"  height="50px"  width="50px" src="images/sa/glossy-3d-blue-hourglass-icon.png" />
                            </div>
                            <div style="font-family: calibri; font-size: small; color : red">
                                System Processing your request please wait...</div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    </center>       
                    <asp:GridView ID="grd" runat="server" AllowPaging="True" BackColor="White" 
                        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="2" 
                        CellSpacing="2" EmptyDataText="NO RECORD FOUND" Font-Names="Calibri" 
                        Font-Size="Small" GridLines="Vertical" Height="120px" PageSize="25" 
                        ShowFooter="True" Width="100%">
                        <AlternatingRowStyle BackColor="#DCDCDC" />
                        <Columns>
                            <asp:CommandField HeaderText="Action" SelectText="Edit" 
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
                <td align="center" colspan="5" valign="top">
                    <cc2:Editor ID="Editor1" runat="server" Height="870px" />
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
                <td style="width: 426px" align="center">
                    <asp:CheckBox ID="chkShow" runat="server" Font-Bold="True" Font-Names="Calibri" 
                        Font-Size="Medium" Text="Show?" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" Text="UPDATE" />
                    <cc1:ConfirmButtonExtender ID="Button1_ConfirmButtonExtender" runat="server" 
                        ConfirmOnFormSubmit="True" 
                        ConfirmText="Are you sure you want UPDATE this alert message?" Enabled="True" 
                        TargetControlID="Button1">
                    </cc1:ConfirmButtonExtender>
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
                <td colspan="5" align="center">
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
                <td style="width: 426px" align="right">
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
      <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
             </Triggers>
</asp:UpdatePanel>


</asp:Content>

