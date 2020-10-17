<%@ Page Title="" Language="VB" MasterPageFile="~/companynoheader.master" AutoEventWireup="false" CodeFile="devicereports.aspx.vb" Inherits="devicereports" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <cc1:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server">
    </cc1:toolkitscriptmanager>
    <script language="javascript" type ="text/javascript">
        function CallPrint(strid) {
            var prtContent = document.getElementById(strid);
            var WinPrint = window.open('', '', 'letf=0,top=0,width=1,height=1,toolbar=0,scrollbars=0,status=0');
            WinPrint.document.write(prtContent.innerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
            prtContent.innerHTML = strOldOne;
        }
</script>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">


    <ContentTemplate>


        <asp:Panel ID="Panel1" runat="server">

             <table style="width: 100%;">
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td colspan="2">
             
                    

                    <asp:Panel ID="Panel2" runat="server">
                        <table cellpadding="0" cellspacing="1" style="width:100%;">
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td colspan="5" style="background-color:#99A6B4">
                                    <div class="item_title">
                                        &nbsp;&nbsp;&nbsp;SEARCH INSTRUMENT RECORDS&nbsp;&nbsp;&nbsp;</div>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style39" colspan="5">
                                    <b style="mso-bidi-font-weight:normal">
                                    <span style="font-size: 10.0pt; line-height: 115%; font-family: &quot;Calibri&quot;,&quot;sans-serif&quot;; mso-fareast-font-family: Calibri; mso-bidi-font-family: &quot;Times New Roman&quot;; mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA; text-align: center; color: #FF0000;">
                                    <center>
                                    </center>
                                    </span></b>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style39">
                                    &nbsp;</td>
                                <td class="style41">
                                    &nbsp;</td>
                                <td class="style22">
                                    &nbsp;</td>
                                <td class="style40">
                                    <asp:Label ID="Label28" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Bar code:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtBarCode" runat="server" ValidationGroup="barCode|" 
                                        Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style39">
                                    <asp:Label ID="Label25" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Main Category:"></asp:Label>
                                </td>
                                <td class="style41">
                                    <asp:DropDownList ID="cboMainGroup" runat="server" AutoPostBack="True" 
                                        Font-Names="Calibri" Font-Size="Small" 
                                        ValidationGroup="DeviceGroupID|Invalid Instrument Category|1" Width="204px">
                                    </asp:DropDownList>
                                </td>
                                <td class="style22">
                                    &nbsp;</td>
                                <td class="style40">
                                    <asp:Label ID="Label24" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Actual Measure:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox5" runat="server" ToolTip="enter actual Instrument measure" 
                                        ValidationGroup="actualMeasure|Invalid Actual Measure" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style39">
                                    <asp:Label ID="Label26" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Instrument Group:"></asp:Label>
                                </td>
                                <td class="style41">
                                    <asp:DropDownList ID="cboDeviceSub" runat="server" AutoPostBack="True" 
                                        Font-Names="Calibri" Font-Size="Small" 
                                        ValidationGroup="SubDeviceID|Invalid Instrument group|1" Width="204px">
                                    </asp:DropDownList>
                                </td>
                                <td class="style22">
                                    &nbsp;</td>
                                <td class="style40">
                                    <asp:Label ID="Label27" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Model:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtModel" runat="server" ToolTip="enter Instrument model" 
                                        ValidationGroup="modelNumber|Invalid Instrument model" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style39">
                                    <asp:Label ID="Label7" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Main Section(Drill Down):"></asp:Label>
                                </td>
                                <td class="style41">
                                    <asp:DropDownList ID="cboFeegroup" runat="server" AutoPostBack="True" 
                                        Font-Names="Calibri" Font-Size="Small" ValidationGroup="|Invalid Scale Group" 
                                        Width="204px">
                                    </asp:DropDownList>
                                </td>
                                <td class="style22">
                                    &nbsp;</td>
                                <td class="style40">
                                    <asp:Label ID="Label2" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Serial Number:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtserial" runat="server" ToolTip="enter Instrument serial number" 
                                        ValidationGroup="serialNumber|Invalid Serial Number" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style39">
                                    <asp:Label ID="Label21" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Sub Section(Drill Down):"></asp:Label>
                                </td>
                                <td class="style41">
                                    <asp:DropDownList ID="cboFeeSubGroup" runat="server" AutoPostBack="True" 
                                        Font-Names="Calibri" Font-Size="Small" 
                                        ValidationGroup="|Invalid Scale Sub-Group" Width="204px">
                                    </asp:DropDownList>
                                </td>
                                <td class="style22">
                                    &nbsp;</td>
                                <td class="style40">
                                    <asp:Label ID="Label4" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Type Of Instrument:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="cboTypeOfDevice" runat="server" AutoPostBack="True" 
                                        Font-Names="Calibri" Font-Size="Small" ToolTip="enter Instrument type" 
                                        ValidationGroup="typeOfDevice|Invalid Instrument Type" Width="204px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style39">
                                    <asp:Label ID="Label23" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Official Measure:"></asp:Label>
                                </td>
                                <td align="left" class="style41">
                                    <asp:DropDownList ID="cboMrange" runat="server" AutoPostBack="True" 
                                        Font-Names="Calibri" Font-Size="Small" ToolTip="enter company's city" 
                                        ValidationGroup="feeID|Invalid Official Measure|1" Width="204px">
                                    </asp:DropDownList>
                                </td>
                                <td class="style22">
                                    &nbsp;</td>
                                <td align="left" class="style40">
                                    <asp:Label ID="Label3" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Manufacturer No:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox3" runat="server" ToolTip="enter manufacturer number" 
                                        ValidationGroup="manufactureNumber|Invalid Manufacturer Number" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style39">
                                    &nbsp;</td>
                                <td align="right" class="style41">
                                    &nbsp;</td>
                                <td class="style22">
                                    &nbsp;</td>
                                <td align="left" class="style40">
                                    <asp:Label ID="lblccount" runat="server" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style39">
                                    &nbsp;</td>
                                <td align="right" class="style41">
                                    <asp:Button ID="btncancel" runat="server" Text="Reset" />
                                    <cc1:ConfirmButtonExtender ID="btncancel_ConfirmButtonExtender" runat="server" 
                                        ConfirmOnFormSubmit="True" 
                                        ConfirmText="Are you sure you want to RESET this form?" Enabled="True" 
                                        TargetControlID="btncancel">
                                    </cc1:ConfirmButtonExtender>
                                </td>
                                <td class="style22">
                                    &nbsp;</td>
                                <td align="left" class="style40">
                                    <asp:Button ID="btnPreview" runat="server" style="height: 26px" Text="Search" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtamount" runat="server" ValidationGroup="deviceAmount|" 
                                        Visible="False" Width="64px"></asp:TextBox>
                                    <asp:TextBox ID="txtAccountID" runat="server" ValidationGroup="AccountID|" 
                                        Visible="False" Width="64px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
             
                    

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
                <td style="width: 456px">
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
                <td align="center" colspan="6">
                <div id="divPrint">
                    <asp:GridView ID="grd" runat="server" AllowPaging="True" BackColor="White" 
                        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="2" 
                        CellSpacing="2" EmptyDataText="NO RECORD FOUND" EnableModelValidation="True" 
                        Font-Names="Calibri" Font-Size="Small" GridLines="Vertical" Height="120px" 
                        PageSize="25" ShowFooter="True" Width="100%">
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
                    </asp:GridView></div>
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
                <td>
                    &nbsp;</td>
                <td style="width: 456px" align="right">
                    <asp:Button ID="btnPrint" runat="server" style="height: 26px" Text="PRINT" OnClientClick="javascript:CallPrint('divPrint');" />
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
        </table>

        </asp:Panel>
      
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

