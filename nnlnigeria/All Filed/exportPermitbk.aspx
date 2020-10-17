<%@ Page Language="VB" AutoEventWireup="false" CodeFile="exportPermitbk.aspx.vb" Inherits="exportPermitbk" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Import Namespace="System.Data" %>

 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
<div>
	  <center>
        <div style="width : 75%" id="main-menu">
      
         <asp:UpdatePanel ID="UpdatePanel1" runat ="server" >
            <ContentTemplate >
        <div class="item_title"><asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></div>
                <div id="item2">
                      <asp:Panel ID="Panel1" runat="server">
                        <table style="width:100%;" cellspacing="1" cellpadding="0">
                        
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td bgcolor="#99A6B4" colspan="5">
                                    <div class="item_title">&nbsp;&nbsp;&nbsp;EXPORT APPLICATION FORM E001(<asp:Label ID="lblAmtUsed" 
                                            runat="server" Text="Label"></asp:Label>
                                        )</div>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style10">
                                    <asp:Label ID="Label34" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Permit Quarter:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtexportPermitName" runat="server" 
                                        ToolTip="enter given name to this permit" 
                                        ValidationGroup="exportpermitName|Invalid Export Permit Given Name" 
                                        Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td class="style7">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style10">
                                    <asp:Label ID="Label1" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Product Name(Forecast):"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtProducName" runat="server" ToolTip="enter product name(forecast)" 
                                        ValidationGroup="productnameforcast|Invalid Product Name(Forecast)" 
                                        Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td class="style7">
                                    <asp:Label ID="lblsecurityquestion" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" Text="Select Ult Consigee:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="cboUC" runat="server" ToolTip="select Ultimate Consigee" 
                                        ValidationGroup="UCID|Please select Ultimate Consigee|1" Width="204px">
                                        <asp:ListItem Selected="True">Select Value</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style10">
                                    <asp:Label ID="Label25" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Quantity:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtusername14" runat="server" ToolTip="enter quantity forecast" 
                                        ValidationGroup="quantityForcast|Invalid quantity forecat" Width="204px"></asp:TextBox>
                                    <cc1:filteredtextboxextender ID="txtusername14_FilteredTextBoxExtender" 
                                        runat="server" Enabled="True" TargetControlID="txtusername14" 
                                        ValidChars="1234567890,+">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td class="style7">
                                    <asp:Label ID="Label7" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Exporter Name:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAsnwer" runat="server" 
                                        ToolTip="enter exporter name" 
                                        ValidationGroup="exporterName|Invalid exporter's Name" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style10">
                                    <asp:Label ID="Label4" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text=" Full Product Name:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtuser0" runat="server" ToolTip="enter username" 
                                        ValidationGroup="productname|Invalid productname" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td class="style7">
                                    <asp:Label ID="Label27" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Period Covered From:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="cboPCF" runat="server" ToolTip="select period covered" 
                                        ValidationGroup="periodCoveredFrom|Please select period covered" 
                                        Width="204px" AutoPostBack="True">
                                        <asp:ListItem Selected="True">Select Value</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style10">
                                    <asp:Label ID="Label24" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Select Measure:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="cboqtyMeasure" runat="server" AutoPostBack="True" 
                                        style="height: 22px" ToolTip="select measure" 
                                        ValidationGroup="Measure|Please select measure" 
                                        Width="204px">
                                        <asp:ListItem Selected="True">Select Measure</asp:ListItem>
                                        <asp:ListItem>Barrels</asp:ListItem>
                                        <asp:ListItem>Metric Tons</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td class="style7">
                                    <asp:Label ID="Label28" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Period Covered To:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="cboPCT" runat="server" ToolTip="select period covered" 
                                        ValidationGroup="periodCoveredTo|Please select period covered" 
                                        Width="204px">
                                        <asp:ListItem>Select Value</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style10">
                                    <asp:Label ID="Label8" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Quatity:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtQuatity" runat="server" ToolTip="enter quantity" 
                                        ValidationGroup="quantity|Invalid product quantity" Width="204px" 
                                        AutoPostBack="True"></asp:TextBox>
                                    <cc1:filteredtextboxextender ID="txtQuatity_FilteredTextBoxExtender" 
                                        runat="server" Enabled="True" TargetControlID="txtQuatity" 
                                        ValidChars="1234567890,+">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td class="style7">
                                    <asp:Label ID="Label10" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Destination:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="cboCountry" runat="server" 
                                        ValidationGroup="destCountry|Please select destination country" 
                                        Width="204px">
                                        <asp:ListItem Selected="True">Select Value</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style10">
                                    <asp:Label ID="Label12" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Mode of Export"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtusername16" runat="server" style="margin-bottom: 0px" 
                                        ToolTip="enter mode of export" 
                                        ValidationGroup="exportMode|Invalid mode of export" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td class="style7">
                                    <asp:Label ID="Label13" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Port Of Export:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtusername17" runat="server" 
                                        ToolTip="enter port of export" 
                                        ValidationGroup="exportPort|Invalid port of export" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style8" colspan="5">
                                    <hr />
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style10">
                                    <asp:Label ID="Label29" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Final Quantity(barrel):"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFinalQty" runat="server" BorderColor="#CCCCCC" 
                                        BorderStyle="Solid" 
                                        ValidationGroup="finalQuantity" Width="204px" 
                                        ReadOnly="True"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td class="style7">
                                    <asp:Label ID="Label33" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Proposed Export date:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDPTTo" runat="server" BorderStyle="Solid" BorderWidth="1px" 
                                        Font-Bold="False" Font-Names="Calibri" Font-Size="Small" Height="20px" 
                                        Width="80px" ToolTip="select proposed export date" 
                                        ValidationGroup="exportDate|Invalid proposed date"></asp:TextBox>
                                    <cc1:calendarextender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd" 
                                        PopupButtonID="childimgbtnCal" TargetControlID="txtDPTTo">
                                    </cc1:CalendarExtender>
                                    <asp:ImageButton ID="childimgbtnCal" runat="server" Height="16px" 
                                        ImageUrl="~/img/cal3.png" ValidationGroup="dd" Width="16px" />
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style10">
                                    <asp:Label ID="Label11" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Amount Per Barrel(US):"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtamtPerBarrel" runat="server" BorderColor="#CCCCCC" 
                                        BorderStyle="Solid" 
                                        ValidationGroup="amtPerBarrelUS" Width="204px" 
                                        ReadOnly="True"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td class="style7">
                                    <asp:Label ID="Label9" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Estimated Amt(US):"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAmtUS" runat="server" BorderColor="#CCCCCC" 
                                        BorderStyle="Solid" ReadOnly="True" ValidationGroup="TotalamtUS" 
                                        Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style10">
                                    <asp:Label ID="Label32" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Exchange Rate:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtExchangeRate" runat="server" BorderColor="#CCCCCC" 
                                        BorderStyle="Solid" 
                                        ValidationGroup="dollarNairaExchange" Width="204px" 
                                        ReadOnly="True"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td class="style7">
                                    <asp:Label ID="Label31" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Total Amount(NGN):"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAmtNGN" runat="server" BorderColor="#CCCCCC" 
                                        BorderStyle="Solid" ReadOnly="True" ValidationGroup="TotalAmtNig" 
                                        Width="204px"></asp:TextBox>
                               
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style10">
                                    &nbsp;</td>
                                <td colspan="4">
                                    <asp:CheckBox ID="CheckBox1" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" 
                                        Text="Do you have Certificate of Incorporation of the applicant's company?" 
                                        ValidationGroup="CertificateOfIncor|You must Have Certificate Of Incorporation" />
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style10">
                                    &nbsp;</td>
                                <td colspan="4">
                                    <asp:CheckBox ID="CheckBox2" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" 
                                        Text="Do you have Company Article and Memorandum of Association" 
                                        ValidationGroup="CompanyArticleMemo|You must have Company Article and Memorandum of Association?" />
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style10">
                                    &nbsp;</td>
                                <td colspan="4">
                                    <asp:CheckBox ID="CheckBox5" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" 
                                        Text="Do you have Current Production/Storage/Sales license issued by DPR?" 
                                        ValidationGroup="LicenseByDPR|You have License Issued by DPR" />
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style10">
                                    &nbsp;</td>
                                <td colspan="4">
                                    <asp:CheckBox ID="CheckBox4" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" 
                                        Text="Do you have Current Weights and Measures Department certificate of conformity for the Fiscal Meters, Gauges, and all Custody Transfer Weighing &amp; Measuring instruments at the terminal(s) to be used for the export?" 
                                        ValidationGroup="WeightMeters|You must have Approved Weights and Measures Department certificate for the registering devices " />
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style10">
                                    &nbsp;</td>
                                <td colspan="4">
                                    <asp:CheckBox ID="CheckBox6" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" 
                                        Text="Do you have Original Bank reference with committed and explicit statements?" 
                                        ValidationGroup="OriginalBank|You must have  Original Bank reference with committed and explicit statements" />
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style10">
                                    &nbsp;</td>
                                <td colspan="4">
                                    <asp:CheckBox ID="CheckBox7" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" Text="Do you have 3-Years Tax Clearance Certificate?" 
                                        ValidationGroup="TaxClearance|You must have 3-Years Tax Clearance Certificate" />
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td colspan="5">
                                    <div class="item_title">
                                        &nbsp;&nbsp;&nbsp;DOCUMENT SIGNED BY</div>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style10">
                                    <asp:Label ID="Label20" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Title:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="cbosTitle" runat="server" ToolTip="select title" 
                                        ValidationGroup="docFiledTitle|Please select title" Width="204px">
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
                                    &nbsp;</td>
                                <td class="style7">
                                    <asp:Label ID="Label21" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Fullname:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtfullname" runat="server" ToolTip="enter your fullname" 
                                        ValidationGroup="docfilledBy|Invalid fullname" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td colspan="5">
                                    <div class="item_title">
                                        &nbsp;&nbsp;&nbsp;ACKNOWLEDGEMENT</div>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td colspan="5">
                                    <center>
                                        <b style="mso-bidi-font-weight:normal">
                                        <span style="font-size: 10.0pt; line-height: 115%; font-family: &quot;Calibri&quot;,&quot;sans-serif&quot;; mso-fareast-font-family: Calibri; mso-bidi-font-family: &quot;Times New Roman&quot;; mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA; text-align: center; color: #FF0000;">
                                        We acknowledge that the making of any false statement or concealment of any 
                                        material fact in connection with this application may result in imprisonment or 
                                        fine, or both and denial, in whole or in part, of participation in Nigeria Oil 
                                        and Gas exports.<hr /></span></b>
                                    </center>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style10">
                                    <asp:TextBox ID="txtID" runat="server" CausesValidation="false" 
                                        ValidationGroup="companyID" Visible="False" 
                                        Width="51px"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtTranscode" runat="server" CausesValidation="false" 
                                        ToolTip="retype password entered" ValidationGroup="transcode" Visible="False" 
                                        Width="51px"></asp:TextBox>
                                    <asp:Button ID="btnReset" runat="server" Height="25px" Text="Reset" />
                                    <cc1:confirmbuttonextender ID="btnReset_ConfirmButtonExtender" runat="server" 
                                        ConfirmOnFormSubmit="True" 
                                        ConfirmText="Are you SURE you want to CLEAR this form" Enabled="True" 
                                        TargetControlID="btnReset">
                                    </cc1:ConfirmButtonExtender>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td class="style7">
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnPreview" runat="server" Height="25px" style="height: 26px" 
                                        Text="Submit" />
                                    <cc1:confirmbuttonextender ID="btnPreview_ConfirmButtonExtender" runat="server" 
                                        ConfirmOnFormSubmit="True" 
                                        ConfirmText="Are you SURE you want to SAVE this record?" Enabled="True" 
                                        TargetControlID="btnPreview">
                                    </cc1:ConfirmButtonExtender>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                       
                        </table>
                    </asp:Panel>   
                  
                </div>
   </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnPreview" EventName="Click" />
             </Triggers>
                </asp:UpdatePanel>
        </div></center>
   
 
</div>
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>
    </form>
</body>
</html>
