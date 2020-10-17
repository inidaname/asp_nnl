<%@ Page Title="" Language="VB" MasterPageFile="~/adminpage.master" AutoEventWireup="false" CodeFile="adminstrumenttype.aspx.vb" Inherits="adminstrumenttype" %>

<%@ Import Namespace="System.Data" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>
        <asp:Panel ID="Panel1" runat="server">
                 
                  <center>
                        <table style="width: 100%;">
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
                                        <td class="style4" align="center" colspan="2">
                                         <center style="width: 927px" >   <div class="item_title"><asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></div></center></td>
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
                                            &nbsp;
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
                                        <td class="style4" style="width: 398px">
                                            &nbsp;</td>
                                        <td align="left">
                                            <asp:TextBox ID="txtFeeID" runat="server" Width="50px" Visible="False"></asp:TextBox>
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
                                        <td class="style4" align="right" style="width: 398px">
                                            <asp:Label ID="Label12" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                Text="Main Sector:"></asp:Label>

                                        </td>
                                        <td align="left">
                                            
                                            <asp:DropDownList ID="cboFEEGROUP" runat="server" Width="204px" 
                                                AutoPostBack="True" >
                                            </asp:DropDownList>
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
                                        <td class="style4" align="right" style="width: 398px">
                                            <asp:Label ID="Label15" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                Text="Category"></asp:Label>

                                        </td>
                                        <td align="left">
                                            
                                            <asp:DropDownList ID="cboFEESUBGROUP" runat="server" Width="204px" 
                                                AutoPostBack="True" >
                                            </asp:DropDownList>
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
                                        <td align="right" class="style4" style="width: 398px">
                                             <asp:Label ID="Label13" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                Text="Instrument Type:"></asp:Label>  </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtFee" runat="server" Width="304px"></asp:TextBox> 
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
                                        <td align="right" class="style4" style="width: 398px">
                                            <asp:Button ID="btnFEER" runat="server" Text="RESET" />
                                              <cc1:ConfirmButtonExtender ID="btnFEER_ConfirmButtonExtender" runat="server" 
                                                ConfirmOnFormSubmit="True" 
                                                ConfirmText="Are you SURE you want to CLEAR this form" Enabled="True" 
                                                TargetControlID="btnFEER">
                                            </cc1:ConfirmButtonExtender>
                                        </td>
                                        <td align="left">
                                            &nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="btnFEES" runat="server" style="height: 26px" Text="SAVE" />
                                              <cc1:ConfirmButtonExtender ID="btnFEES_ConfirmButtonExtender" runat="server" 
                                                ConfirmOnFormSubmit="True" 
                                                ConfirmText="Are you SURE you want to SAVE this record" Enabled="True" 
                                                TargetControlID="btnFEES">
                                            </cc1:ConfirmButtonExtender>

                                            &nbsp;&nbsp;
                                            <asp:Button ID="btnFEED" runat="server" style="height: 26px" Text="DELETE" 
                                                Visible="False" />
                                               <cc1:ConfirmButtonExtender ID="btnFEED_ConfirmButtonExtender" runat="server" 
                                                ConfirmOnFormSubmit="True" 
                                                ConfirmText="Are you SURE you want to DELETE this record" Enabled="True" 
                                                TargetControlID="btnFEED">
                                            </cc1:ConfirmButtonExtender>
                                        
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
                                        <td align="right" class="style4" style="width: 398px">
                                            &nbsp;</td>
                                        <td>
                                            <asp:Label ID="lblFeeTotalResult" runat="server" Font-Bold="True" 
                                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
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
                                            &nbsp;
                                        </td>
                                        <td align="center" colspan="11">
                                            <asp:GridView ID="grdFee" runat="server" AllowPaging="True" BackColor="White" 
                                                BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="2" 
                                                CellSpacing="2" EmptyDataText="NO RECORD FOUND" 
                                                EnableModelValidation="True" Font-Names="Calibri" Font-Size="Small" 
                                                GridLines="Vertical" PageSize="25" ShowFooter="True" Width="100%">
                                                <AlternatingRowStyle BackColor="Gainsboro" />
                                                <Columns>
                                                    <asp:CommandField HeaderText="Action" SelectText="Edit" 
                                                        ShowSelectButton="True"  />
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
                                        <td class="style4" style="width: 398px">
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
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                  </center>            

            </asp:Panel>
</asp:Content>

