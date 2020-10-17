<%@ Page Title="Device Price Setup" Language="VB" MasterPageFile="~/adminpage.master" AutoEventWireup="false" EnableEventValidation="false" ValidateRequest ="false" CodeFile="amdsetuprice.aspx.vb" Inherits="amdsetupdeviceprice" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <cc1:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server">
    </cc1:toolkitscriptmanager>
    <script language="javascript" type="text/javascript">
        function goBack() {
            window.history.back()
        }
    </script>

<%--<% Dim ds As String = "<a href='amdsetupdeviceprice.aspx?ins=" & Request("ins") & "&par=" & Request("par") & "' onclick='goBack()'>---BACK---</a>"
                                    Response.Write(ds)
                                    %>--%>
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
                                <asp:Label ID="Label36" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                    Text="Measure name:"></asp:Label>
                            </td>
                            <td style="width: 164px">
                                <asp:Button ID="btnAddMeasure" runat="server" style="height: 26px" 
                                    Text="Add Measure" />

                             

                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td class="style2" style="width: 161px">
                                <asp:Label ID="Label25" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                    Text="Min Value:"></asp:Label>
                            </td>
                            <td style="width: 164px">
                                <asp:TextBox ID="TextBox1" runat="server" ValidationGroup="MinValue1"></asp:TextBox>

                                <cc1:FilteredTextBoxExtender ID="TextBox1_FilteredTextBoxExtender" 
                                    runat="server" Enabled="True" TargetControlID="TextBox1" 
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
                                <asp:Label ID="Label27" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                    Text="Max Value:" ToolTip="Measurement Parameters"></asp:Label>
                            </td>
                            <td style="width: 164px">
                                <asp:TextBox ID="TextBox2" runat="server" ValidationGroup="MaxValue1"></asp:TextBox>
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
                                <asp:Label ID="Label35" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                    Text="Amount" ToolTip="Measurement Parameters"></asp:Label>
                            </td>
                            <td style="width: 164px">
                                <asp:TextBox ID="txtAmount" runat="server" ValidationGroup="Amount"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="txtAmount_FilteredTextBoxExtender" 
                                    runat="server" Enabled="True" TargetControlID="txtAmount" 
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
                                <asp:CheckBox ID="chkIsAbove" runat="server" AutoPostBack="True" 
                                    Text="Is Last/Max Setup" ValidationGroup="IsMaxValue" />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="height: 34px">
                                </td>
                            <td class="style2" style="width: 161px; height: 34px;">
                                <asp:Label ID="Label28" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                    Text="Amt each for Additional Value:" ToolTip="Measurement Parameters" 
                                    Visible="False"></asp:Label>
                            </td>
                            <td style="width: 164px; height: 34px;">
                                <asp:TextBox ID="TextBox3" runat="server" Visible="False" 
                                    ValidationGroup="amtAboveMaxValue"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="TextBox3_FilteredTextBoxExtender" 
                                    runat="server" Enabled="True" TargetControlID="TextBox3" 
                                    ValidChars=".0123456789">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                            <td style="height: 34px">
                                </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td class="style2" style="width: 161px">
                                <asp:Label ID="Label29" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                    Text="Amt For First Occurance:" ToolTip="Measurement Parameters" 
                                    Visible="False"></asp:Label>
                            </td>
                            <td style="width: 164px">
                                <asp:TextBox ID="TextBox4" runat="server" Visible="False" 
                                    ValidationGroup="amt4First"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="TextBox4_FilteredTextBoxExtender" 
                                    runat="server" Enabled="True" TargetControlID="TextBox4" 
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
                                <asp:Label ID="Label37" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                    Text="Value to Calculate Occurances From:" ToolTip="Measurement Parameters" 
                                    Visible="False"></asp:Label>
                            </td>
                            <td style="width: 164px">
                                <asp:TextBox ID="TextBox6" runat="server" ValidationGroup="Value4Occurance" 
                                    Visible="False"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="TextBox6_FilteredTextBoxExtender" 
                                    runat="server" Enabled="True" TargetControlID="TextBox6" 
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
                                <asp:Label ID="Label38" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                    Text="Value For Part Thereof:" ToolTip="Measurement Parameters" Visible="False"></asp:Label>
                            </td>
                            <td style="width: 164px">
                                <asp:TextBox ID="TextBox7" runat="server" ValidationGroup="Value4PartthereOf" 
                                    Visible="False"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="TextBox7_FilteredTextBoxExtender" 
                                    runat="server" Enabled="True" TargetControlID="TextBox7" 
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
                                <asp:Button ID="btnDelete0" runat="server" Text="Delete All" />
                                <cc1:ConfirmButtonExtender ID="btnDelete0_ConfirmButtonExtender" runat="server" 
                                    ConfirmOnFormSubmit="True" 
                                    ConfirmText="Are you sure you want to DELETE this Instrument" Enabled="True" 
                                    TargetControlID="btnDelete0">
                                </cc1:ConfirmButtonExtender>
                            </td>
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
