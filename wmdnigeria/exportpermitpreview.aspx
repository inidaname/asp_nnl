<%@ Page Language="VB" AutoEventWireup="false"  MasterPageFile="~/exportpage.master" CodeFile="exportpermitpreview.aspx.vb" Inherits="exportpermit" %>

<%@ Import Namespace="System.Data" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc2" %>
 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>

        <script language="javascript" type="text/javascript">
            function goBack() {
                window.history.back()
            }
    </script>

<!--start home-->
<div id="item1">
	 
  <div class="item_title">&nbsp;&nbsp;&nbsp; EXPORT PERMIT</div>
           <br /><br /><br />
                       
	                         <center >
        	                    <img src="images/coatofarm.jpg" />
        	                    <br />
                               <h1> <strong > FEDERAL MINISTRY OF INDUSTRY,TRADE AND INVESTMENT</strong></h1><br />
                                 <div align="center">
                                     <table border="0" cellpadding="0" cellspacing="0" class="style6" 
                                         style="mso-yfti-tbllook: 1184; mso-padding-alt: 0in 5.4pt 0in 5.4pt" 
                                         width="100%">
                                         <tr style="mso-yfti-irow:0;mso-yfti-firstrow:yes;height:1.0in">
                                             <td width="100%">
                                                 <p align="center" class="MsoNoSpacing" style="text-align:center">
                                                     <b style="mso-bidi-font-weight:normal">
                                                     <span style="font-size:26.0pt;mso-bidi-font-size:
  40.0pt;font-family:&quot;Cambria&quot;,&quot;serif&quot;"><o:p>&nbsp;</o:p></span><span style="font-size:24.0pt;font-family:
  &quot;Cambria&quot;,&quot;serif&quot;">APPLICATION FOR EXPORT CLEARANCE PERMIT<o:p></o:p></span></b></p>
                                                 <p align="center" class="MsoNoSpacing" style="text-align:center">
                                                     <b style="mso-bidi-font-weight:normal">
                                                     <span style="font-size:18.0pt;mso-bidi-font-size:
  40.0pt;font-family:&quot;Cambria&quot;,&quot;serif&quot;">(CRUDE OIL, GAS AND OTHER PETROLEUM PRODUCTS)</span><o:p></o:p></b></p>
                                                 <p align="center" class="MsoNormal">
                                                     <b style="mso-bidi-font-weight:normal"><span style="font-size:14.0pt">
                                                     COMMODITIES AND PRODUCTS INSPECTORATE DEPARTMENT (CPI)<u><span 
                                                         style="mso-bidi-font-weight:bold"><o:p></o:p></span></u></span></b></p>
                                                 <p align="center" class="MsoNoSpacing" style="text-align:center">
                                                     <o:p></o:p></p>
                                             </td>
                                         </tr>
                                  
                                     </table>
                                 </div>
        	
                            </center> 	
                            <hr />
 <div>
	  <center>
        <div style="width : 75%" id="main-menu">
      
         <asp:UpdatePanel ID="UpdatePanel1" runat ="server" >
            <ContentTemplate >
        <div class="item_title"><asp:Label ID="lblMsg" runat="server" Text ="PREVIEW YOUR DOCUMENT BEFORE SUBMITING" ForeColor="Red"></asp:Label></div>
                <div id="item2">
                      <asp:Panel ID="Panel1" runat="server">
                        <table style="width:100%;" cellspacing="1" cellpadding="0">
                        
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td bgcolor="#99A6B4" colspan="5">
                                    <div class="item_title">&nbsp;&nbsp;&nbsp;EXPORT APPLICATION FORM E001<asp:Label ID="lblAmtUsed" 
                                            runat="server" Text=""></asp:Label>
                                        </div>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style10" style="width: 149px">
                                    <asp:Label ID="Label34" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Permit Quarter*:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtexportPermitName" runat="server" 
                                        ToolTip="enter given name to this permit" 
                                        ValidationGroup="exportpermitName|Invalid Permit Quarter" 
                                        Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td class="style7" style="width: 127px">
                                    <asp:Label ID="Label4" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text=" Full Product Name:" Visible="False"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtuser0" runat="server" ToolTip="enter username" 
                                        ValidationGroup="productname" Visible="False" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style10" style="width: 149px">
                                    <asp:Label ID="Label1" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Product Description and Grade*:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtProducName" runat="server" ToolTip="enter product name(forecast)" 
                                        ValidationGroup="productnameforcast|Invalid Product Name(Forecast)" 
                                        Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td class="style7" style="width: 127px">
                                    <asp:Label ID="lblsecurityquestion" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" Text="Select Ult Consigee:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="cboUC" runat="server" ToolTip="enter username" 
                                        ValidationGroup="UCID" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style10" style="width: 149px">
                                    <asp:Label ID="Label25" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Export Quantity*:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtQuatity" runat="server" ToolTip="enter quantity" 
                                        ValidationGroup="quantity|Invalid export quantity" Width="204px" 
                                        AutoPostBack="True"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtQuatity_FilteredTextBoxExtender" 
                                        runat="server" Enabled="True" TargetControlID="txtQuatity" 
                                        ValidChars="1234567890,+">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td class="style7" style="width: 127px">
                                    <asp:Label ID="Label7" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Exporter Name*:"></asp:Label>
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
                                <td class="style10" style="width: 149px">
                                    <asp:Label ID="Label33" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Proposed Export date*:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDPTTo" runat="server" BorderStyle="Solid" BorderWidth="1px" 
                                        Font-Bold="False" Font-Names="Calibri" Font-Size="Small" Height="20px" 
                                        ToolTip="select proposed export date" 
                                        ValidationGroup="exportDate|Invalid proposed date" Width="80px"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd" 
                                        PopupButtonID="childimgbtnCal" TargetControlID="txtDPTTo" >
                                    </cc1:CalendarExtender>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td class="style7" style="width: 127px">
                                    <asp:Label ID="Label27" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Period Covered From*:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="cboPCF" runat="server" ToolTip="enter exporter name" 
                                        ValidationGroup="periodCoveredFrom|Please select period covered" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style10" style="width: 149px">
                                    <asp:Label ID="Label24" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Measure*:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="cboqtyMeasure" runat="server" 
                                        ValidationGroup="Measure|Please select measure" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td class="style7" style="width: 127px">
                                    <asp:Label ID="Label28" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Period Covered To*:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="cboPCT" runat="server" ToolTip="enter exporter name" 
                                        ValidationGroup="periodCoveredTo|Please select period covered" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style10" style="width: 149px">
                                    <asp:Label ID="Label8" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Quatity:" Visible="False"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtusername14" runat="server" ToolTip="enter quantity forecast" 
                                        ValidationGroup="quantityForcast" Width="204px" Visible="False"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtusername14_FilteredTextBoxExtender" 
                                        runat="server" Enabled="True" TargetControlID="txtusername14" 
                                        ValidChars="1234567890,+">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td class="style7" style="width: 127px">
                                    <asp:Label ID="Label10" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Destination:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="cboCountry" runat="server" ToolTip="enter quantity forecast" 
                                        ValidationGroup="destCountry|Please select destination country" Visible="False" 
                                        Width="204px"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="cboCountry_FilteredTextBoxExtender" 
                                        runat="server" Enabled="True" TargetControlID="cboCountry" 
                                        ValidChars="1234567890,+">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style10" style="width: 149px">
                                    <asp:Label ID="Label12" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Mode of Export*:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtusername16" runat="server" style="margin-bottom: 0px" 
                                        ToolTip="enter mode of export" 
                                        ValidationGroup="exportMode|Invalid mode of export" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td class="style7" style="width: 127px">
                                    <asp:Label ID="Label13" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Port Of Export*:"></asp:Label>
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
                                <td class="style10" style="width: 149px">
                                    <asp:Label ID="Label11" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Amount Per Barrel(USD):"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtamtPerBarrel" runat="server" BorderColor="#CCCCCC" 
                                        BorderStyle="Solid" ReadOnly="True" ValidationGroup="amtPerBarrelUS" 
                                        Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td class="style7" style="width: 127px">
                                    <asp:Label ID="Label9" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="F.O.B Value(USD)*:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAmtUS" runat="server" BorderColor="#CCCCCC" 
                                        BorderStyle="Solid" ReadOnly="True" ValidationGroup="TotalamtUS" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style10" style="width: 149px">
                                    <asp:Label ID="Label29" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Final Quantity(barrel):" Visible="False"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFinalQty" runat="server" BorderColor="#CCCCCC" 
                                        BorderStyle="Solid" ReadOnly="True" ValidationGroup="finalQuantity" 
                                        Visible="False" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td class="style7" style="width: 127px">
                                    <asp:Label ID="Label31" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Total Amount(NGN):" Visible="False"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAmtNGN" runat="server" BorderColor="#CCCCCC" 
                                        BorderStyle="Solid" ReadOnly="True" ValidationGroup="TotalAmtNig" 
                                        Visible="False" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style10" style="width: 149px">
                                    <asp:Label ID="Label32" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Exchange Rate:" Visible="False"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtExchangeRate" runat="server" BorderColor="#CCCCCC" 
                                        BorderStyle="Solid" 
                                        ValidationGroup="dollarNairaExchange" Width="204px" 
                                        ReadOnly="True" Visible="False"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td class="style7" style="width: 127px">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style10" style="width: 149px">
                                    &nbsp;</td>
                                <td colspan="4">
                                    <asp:CheckBox ID="CheckBox1" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" 
                                        Text="Do you have Certificate of Incorporation of the applicant's company?" 
                                        ValidationGroup="CertificateOfIncor" Checked="True" />
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style10" style="width: 149px">
                                    &nbsp;</td>
                                <td colspan="4">
                                    <asp:CheckBox ID="CheckBox2" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" 
                                        Text="Do you have Company Article and Memorandum of Association" 
                                        ValidationGroup="CompanyArticleMemo" Checked="True" />
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style10" style="width: 149px">
                                    &nbsp;</td>
                                <td colspan="4">
                                    <asp:CheckBox ID="CheckBox5" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" 
                                        Text="Do you have Current Production/Storage/Sales license issued by DPR?" 
                                        ValidationGroup="LicenseByDPR" Checked="True" />
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style10" style="width: 149px">
                                    &nbsp;</td>
                                <td colspan="4">
                                    <asp:CheckBox ID="CheckBox4" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" 
                                        Text="Do you have Current Weights and Measures Department certificate of conformity for the Fiscal Meters, Gauges, and all Custody Transfer Weighing &amp; Measuring instruments at the terminal(s) to be used for the export?" 
                                        ValidationGroup="WeightMeters" Checked="True" />
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style10" style="width: 149px">
                                    &nbsp;</td>
                                <td colspan="4">
                                    <asp:CheckBox ID="CheckBox6" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" 
                                        Text="Do you have Original Bank reference with committed and explicit statements?" 
                                        ValidationGroup="OriginalBank" Checked="True" />
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style10" style="width: 149px">
                                    &nbsp;</td>
                                <td colspan="4">
                                    <asp:CheckBox ID="CheckBox7" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" Text="Do you have 3-Years Tax Clearance Certificate?" 
                                        
                                        ValidationGroup="TaxClearance|You must have 3-Years Tax Clearance Certificate" 
                                        Checked="True" />
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style10" style="width: 149px">
                                    &nbsp;</td>
                                <td colspan="4">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style10" style="width: 149px">
                                    <asp:Label ID="Label36" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Is Cover Letter?"></asp:Label>
                                </td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtpassportname" runat="server" 
                                        ValidationGroup="CoverLetterName" Width="40px"></asp:TextBox>
                                    <td>
                                    
                                  
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style10" style="width: 149px">
                                    &nbsp;</td>
                                <td colspan="4">
                                      
                                    &nbsp;</td>
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
                                <td class="style10" style="width: 149px">
                                    <asp:Label ID="Label20" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Title:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="cbosTitle" runat="server" ToolTip="enter email address" 
                                        ValidationGroup="docFiledTitle|Please select title" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td class="style7" style="width: 127px">
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
                                <td class="style10" style="width: 149px">
                                    <asp:Label ID="Label35" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Email Address:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtemail" runat="server" ToolTip="enter email address" 
                                        ValidationGroup="emaildocsigned|Invalid email address" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td class="style7" style="width: 127px">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
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
                                <td class="style10" style="width: 149px">
                                    <asp:TextBox ID="txtID" runat="server" CausesValidation="false" 
                                        ValidationGroup="companyID" Visible="False" 
                                        Width="51px"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtTranscode" runat="server" CausesValidation="false" 
                                        ToolTip="retype password entered" ValidationGroup="transcode" Visible="False" 
                                        Width="51px"></asp:TextBox>
                                    <asp:Button ID="btnReset" runat="server" Height="25px" Text="BACK" 
                                        onclientclick="goBack()" />
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td class="style7" style="width: 127px">
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnPreview" runat="server" Height="25px" style="height: 26px" 
                                        Text="FINISH" />
                                    <cc1:ConfirmButtonExtender ID="btnPreview_ConfirmButtonExtender" runat="server" 
                                        ConfirmOnFormSubmit="True" 
                                        ConfirmText="Are you SURE you want to SAVE this export permit?" Enabled="True" 
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

        
</div>
    
</asp:Content>       