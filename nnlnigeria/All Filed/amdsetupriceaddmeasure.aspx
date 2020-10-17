<%@ Page Title="Device Price Setup" Language="VB" MasterPageFile="~/adminpage.master" AutoEventWireup="false" EnableEventValidation="false" ValidateRequest ="false" CodeFile="amdsetupriceaddmeasure.aspx.vb" Inherits="amdsetupdeviceprice" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <cc1:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server">
    </cc1:toolkitscriptmanager>
    <script language="javascript" type="text/javascript">
        function goBack() {
            window.history.back()
        }
    </script>

<% Dim ds As String = "<a href='amdsetupdeviceprice.aspx?ins=" & Request("ins") & "&par=" & Request("par") & "' onclick='goBack()'>---BACK---</a>"
                                    Response.Write(ds)
                                    %>
        <asp:Panel ID="Panel1" runat="server">

  <table style="width: 100%;">
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td style="width: 224px">
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
                <td style="width: 224px">
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
                <td align="right" colspan="3">
                    <table style="width:100%;">
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td class="style2" style="width: 161px">
                                <asp:Label ID="Label31" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                    Text="Sector:"></asp:Label>
                            </td>
                            <td style="width: 164px">
                                <asp:Label ID="lblInstrument" runat="server" Font-Names="Calibri" 
                                    Font-Size="Small" Text="Instrument:"></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td class="style2" style="width: 161px">
                                <asp:Label ID="Label33" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                    Text="Category:"></asp:Label>
                            </td>
                            <td style="width: 164px">
                                <asp:Label ID="lblParameters" runat="server" Font-Names="Calibri" 
                                    Font-Size="Small" Text="Instrument:"></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td class="style2" style="width: 161px">
                                <asp:Label ID="Label34" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                    Text="Instrument Type:"></asp:Label>
                            </td>
                            <td style="width: 164px">
                                <asp:Label ID="lblInstType" runat="server" Font-Names="Calibri" 
                                    Font-Size="Small" Text="Parameters:"></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="height: 18px">
                                </td>
                            <td class="style2" style="width: 161px; height: 18px;">
                                </td>
                            <td style="width: 164px; height: 18px;">
                                </td>
                            <td style="height: 18px">
                                </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td class="style2" style="width: 161px">
                                <asp:Label ID="Label36" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                    Text="Unit Of Measure:"></asp:Label>
                            </td>
                            <td style="width: 164px">
                                <asp:DropDownList ID="cboCompany" runat="server" AutoPostBack="True" 
                                    Font-Names="Calibri" Font-Size="Small" 
                                    ValidationGroup="MeasureName|Invalid Measure Name">
                                </asp:DropDownList>

                             

                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td class="style2" style="width: 161px">
                                <asp:Label ID="Label37" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                    Text="Value Of Measure From The Least:"></asp:Label>
                            </td>
                            <td style="width: 164px">
                                <asp:TextBox ID="TextBox2" runat="server" 
                                    ValidationGroup="MeasureValue|Invalid Measure Value"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="TextBox2_FilteredTextBoxExtender" 
                                    runat="server" Enabled="True" TargetControlID="TextBox2" 
                                    ValidChars=".0123456789">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td class="style2" style="width: 161px">
                                &nbsp;</td>
                            <td style="width: 164px">
                                <asp:CheckBox ID="chkDefault" runat="server" 
                                    Text="Tick if this measure is used to setup price range" 
                                    ValidationGroup="IsDefault" />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td class="style2" style="width: 161px">
                                &nbsp;</td>
                            <td style="width: 164px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td class="style2" style="width: 161px">
                                <asp:Button ID="btncancel" runat="server" Text="Reset" />
                                <cc1:ConfirmButtonExtender ID="btncancel_ConfirmButtonExtender" runat="server" 
                                    ConfirmOnFormSubmit="True" 
                                    ConfirmText="Are you sure you want to CANCEL/RESET this form?" Enabled="True" 
                                    TargetControlID="btncancel">
                                </cc1:ConfirmButtonExtender>
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" Visible="False" />
                                <cc1:ConfirmButtonExtender ID="btnDelete_ConfirmButtonExtender" runat="server" 
                                    ConfirmOnFormSubmit="True" 
                                    ConfirmText="Are you sure you want to DELETE this Instrument" Enabled="True" 
                                    TargetControlID="btnDelete">
                                </cc1:ConfirmButtonExtender>
                            </td>
                            <td style="width: 164px">
                                <asp:Button ID="btnPreview" runat="server" style="height: 26px" Text="Submit" />
                                <cc1:ConfirmButtonExtender ID="btnPreview_ConfirmButtonExtender" runat="server" 
                                    ConfirmOnFormSubmit="True" 
                                    ConfirmText="Are you sure you want SAVE this record?" Enabled="True" 
                                    TargetControlID="btnPreview">
                                </cc1:ConfirmButtonExtender>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td class="style2" style="width: 161px">
                                &nbsp;</td>
                            <td style="width: 164px">
                                <asp:TextBox ID="txtMainDeviceID" runat="server" ValidationGroup="MainDeviceID" 
                                    Visible="False"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td class="style2" style="width: 161px">
                                &nbsp;</td>
                            <td style="width: 164px">
                                <h3 align="left">
                                <% Dim ds As String = "<a href='amdsetupdeviceprice.aspx?ins=" & Request("ins") & "&par=" & Request("par") & "' onclick='goBack()'>---BACK---</a>"
                                    Response.Write(ds)
                                    %>
                                    
                                </h3>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </td>
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
                <td align="right" style="width: 224px">
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
                <td style="width: 224px">
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
                <td style="width: 224px">
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
                <td style="width: 224px">
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
      
<%--    </ContentTemplate>
</asp:UpdatePanel>--%>


</asp:Content>
