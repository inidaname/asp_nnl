<%@ Page Language="VB" AutoEventWireup="false"  MasterPageFile="~/exportpage.master" CodeFile="Copy (2) of exportpermit.aspx.vb" Inherits="exportpermit" %>

<%@ Import Namespace="System.Data" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc2" %>
 
 
 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>

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
      
        <div class="item_title"><asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></div>
<%--        <asp:Panel ID="Panel2" runat="server">
        <asp:UpdatePanel ID="UPanels" runat ="server"    >
        <ContentTemplate>--%>

                <div id="item2">

                      <asp:Panel ID="Panel1" runat="server">
                        <table style="width:100%;" cellspacing="1" cellpadding="0">
                        
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td bgcolor="#99A6B4" colspan="7">
                                    <div class="item_title">&nbsp;&nbsp;&nbsp;EXPORT APPLICATION FORM E001  <asp:Label ID="lblAmtUsed" 
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
                                    &nbsp;</td>
                                <td align="right" colspan="2">
                                    <asp:RadioButton ID="RadioButton1" runat="server" Text="Main Application" 
                                        Checked="True" GroupName="mn" />
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td class="style7" colspan="3">
                                    <asp:RadioButton ID="RadioButton2" runat="server" 
                                        Text="Supplimentary Application" GroupName="mn" />
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style10" style="width: 149px">
                                    <asp:Label ID="Label34" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Permit Quarter:"></asp:Label><font style="color:#F00">*</font>
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="txtexportPermitName" runat="server" 
                                        ToolTip="enter given name to this permit" 
                                        ValidationGroup="exportpermitName|Invalid Permit Quarter" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td class="style7" style="width: 127px" colspan="2">
                                    <asp:Label ID="Label7" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Exporter Name:"></asp:Label><font style="color:#F00">*</font>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAsnwer" runat="server" ToolTip="enter exporter name" 
                                        ValidationGroup="exporterName|Invalid exporter's Name" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style10" style="width: 149px">
                                    <asp:Label ID="Label1" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Product Description:"></asp:Label>
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="txtProducName" runat="server" 
                                        ToolTip="enter product name(forecast)" 
                                        ValidationGroup="productnameforcast|Invalid Product Name(Forecast)" 
                                        Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td class="style7" style="width: 127px" colspan="2">
                                    <asp:Label ID="Label27" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Period Covered From:"></asp:Label><font style="color:#F00">*</font>
                                </td>
                                <td>
                                    <asp:DropDownList ID="cboPCF" runat="server" AutoPostBack="True" 
                                        ToolTip="Select Period Covered" 
                                        ValidationGroup="periodCoveredFrom|Please select period covered" Width="204px">
                                        <asp:ListItem Selected="True">Select Value</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style10" style="width: 149px">
                                    <asp:Label ID="Label24" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Select Measure:"></asp:Label><font style="color:#F00">*</font>
                                </td>
                                <td colspan="2">
                                    <asp:DropDownList ID="cboqtyMeasure" runat="server" 
                                        style="height: 22px" ToolTip="select measure" 
                                        ValidationGroup="Measure|Please select measure" Width="204px">
                                        <asp:ListItem Selected="True">Select Measure</asp:ListItem>
                                        <asp:ListItem>Barrels</asp:ListItem>
                                        <asp:ListItem>Metric Tons</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td class="style7" style="width: 127px" colspan="2">
                                    <asp:Label ID="Label28" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Period Covered To:"></asp:Label><font style="color:#F00">*</font>
                                </td>
                                <td>
                                    <asp:DropDownList ID="cboPCT" runat="server" ToolTip="select period covered" 
                                        ValidationGroup="periodCoveredTo|Please select period covered" Width="204px">
                                        <asp:ListItem>Select Value</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style10" style="width: 149px">
                                    <asp:Label ID="Label25" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Export Quantity:"></asp:Label><font style="color:#F00">*</font>
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="txtQuatity" runat="server" 
                                        ToolTip="enter quantity" ValidationGroup="quantity|Invalid export quantity" 
                                        Width="204px"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtQuatity_FilteredTextBoxExtender" 
                                        runat="server" Enabled="True" TargetControlID="txtQuatity" 
                                        ValidChars="1234567890,+">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td class="style7" style="width: 127px" colspan="2">
                                    <asp:Label ID="Label13" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Port Of Export:"></asp:Label><font style="color:#F00">*</font>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtusername17" runat="server" ToolTip="enter port of export" 
                                        ValidationGroup="exportPort|Invalid port of export" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style10" style="width: 149px">
                                    &nbsp;</td>
                                <td colspan="2">
                                    <asp:TextBox ID="txtFinalQty" runat="server" BorderColor="#CCCCCC" 
                                        BorderStyle="Solid" ReadOnly="True" ValidationGroup="finalQuantity" 
                                        Visible="False" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td class="style7" style="width: 127px" colspan="2">
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
                                    <asp:Label ID="Label11" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Amount Per Barrel(USD):"></asp:Label><font style="color:#F00">*</font>
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="txtamtPerBarrel" runat="server" BorderColor="#CCCCCC" 
                                        ValidationGroup="amtPerBarrelUS|Invalid amount/barrel" Width="204px"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtamtPerBarrel_FilteredTextBoxExtender" 
                                        runat="server" Enabled="True" TargetControlID="txtamtPerBarrel" 
                                        ValidChars=".0123456789-">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td class="style7" style="width: 127px" colspan="2">
                                    <asp:Label ID="Label9" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="F.O.B Value(USD):"></asp:Label><font style="color:#F00">*</font>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAmtUS" runat="server" BorderColor="#CCCCCC" 
                                        BorderStyle="Solid" ValidationGroup="TotalamtUS|Invalid Amount" Width="204px"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtAmtUS_FilteredTextBoxExtender" 
                                        runat="server" Enabled="True" TargetControlID="txtAmtUS" 
                                        ValidChars=".0123456789-">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style8" colspan="7" align="center">
                                    <asp:CheckBox ID="chkMultiple" runat="server" AutoPostBack="True" 
                                        Text="Multiple Application?" CausesValidation="True" />
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" colspan="9">
                              
                                     <asp:Panel ID="pnlDataView" runat="server" Width="100%" Visible="false">

                                         <asp:Button ID="btnPreview0" runat="server" Font-Names="Calibri" 
                                             Font-Size="Small" Height="25px" Text="ADD APPLICATION" />
                                         <cc1:ConfirmButtonExtender ID="btnPreview0_ConfirmButtonExtender" 
                                             runat="server" ConfirmOnFormSubmit="True" 
                                             ConfirmText="Are you SURE you want to SUBMIT this application?" Enabled="True" 
                                             TargetControlID="btnPreview0">
                                         </cc1:ConfirmButtonExtender>
                                         <br />

                                    <br />
                                         <asp:GridView ID="grd" runat="server" Font-Names="Calibri" Font-Size="X-Small" 
                                            Width="100%" BorderStyle="Double" EmptyDataText="NO APPLICATION FOUND">
                                            <Columns>
                                                <asp:CommandField ButtonType="Image" HeaderText="#" 
                                                    SelectImageUrl="~/images/icn_alert_error.png" SelectText="" 
                                                    ShowSelectButton="True" />
                                            </Columns>
                                             <EmptyDataRowStyle Font-Names="Calibri" Font-Size="Small" 
                                                 HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:GridView>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr >
                                <td align="center" colspan="9" >
                               
                             <%--       <asp:Panel ID="Panel4" runat="server">
                                        <center>
                                            <asp:UpdateProgress ID="updProgress" runat="server" 
                                                AssociatedUpdatePanelID="UPanels">
                                                <ProgressTemplate>
                                                    <div>
                                                        <img alt="progress"  height="50px"  width="50px" src="images/sa/glossy-3d-blue-hourglass-icon.png" />
                                                    </div>
                                                    <div style="font-family: calibri; font-size: small; color : red">
                                                        System Processing your request please wait...</div>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </center>
                                    </asp:Panel>--%>
                               
                                </td>
                            </tr>
                            <tr>
                                <td align="right" colspan="3">
                                    <span style="font-size:11.0pt;line-height:115%;
font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;;mso-ascii-theme-font:minor-latin;mso-fareast-font-family:
Calibri;mso-fareast-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;
mso-bidi-font-family:&quot;Times New Roman&quot;;mso-bidi-theme-font:minor-bidi;
mso-ansi-language:EN-US;mso-fareast-language:EN-US;mso-bidi-language:AR-SA">Category of Applicant&nbsp; </span>
                                </td>
                                <td align="right" colspan="3">
                                    <asp:RadioButton ID="RadioButton3" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" Text="Terminal Operator?" 
                                        ValidationGroup="TerminalOperator" Checked="True" GroupName="terminal" 
                                        AutoPostBack="True" />
                                </td>
                                <td align="center" colspan="3">
                                    <asp:RadioButton ID="RadioButton4" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" Text="Non Terminal Operate" 
                                        ValidationGroup="NoneTerminalOperator" GroupName="terminal" 
                                        AutoPostBack="True" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" colspan="3">
                                    &nbsp;</td>
                                <td align="right" colspan="3">
                                    &nbsp;</td>
                                <td align="center" colspan="3">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="9" align="center" bgcolor="Black">
                                    <font style="color:#F00; font:Calibri;Font-Size:Small; font-weight:bold" >Tick and Upload documents accompanying your application.</font></td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="left" class="style10" colspan="6">
                                    <font style="color:#F00">
                                    <asp:Label ID="Label2" runat="server" Text="*"></asp:Label>
                                    &nbsp;Required</font></td>
                                <td align="left">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="left" class="style10" colspan="6">
                                    <font style="color:#F00"><asp:Label ID="lbl1" runat="server" Text="*"></asp:Label></font>
                                    <asp:CheckBox ID="CheckBox1" runat="server" 
                                        Font-Names="Calibri" Font-Size="Small" 
                                        Text="Certificate of Incorporation of the applicant's company" 
                                        ValidationGroup="CertificateOfIncor" AutoPostBack="True" />
                                </td>
                                <td align="left">
                                    <cc1:AsyncFileUpload ID="fileLetterPicture1" runat="server" Width="200px" 
                                        Visible="true" ClientIDMode="AutoID" />
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="height: 25px">
                                </td>
                                <td align="left" class="style10" colspan="6" style="height: 25px;">
                                  <font style="color:#F00"><asp:Label ID="lbl2" runat="server" Text="*"></asp:Label></font>  
                                    <asp:CheckBox ID="CheckBox2" runat="server" 
                                        Font-Names="Calibri" Font-Size="Small" 
                                        Text="Company Article and Memorandum of Association" 
                                        ValidationGroup="CompanyArticleMemo" AutoPostBack="True" />
                                </td>
                                <td align="left" style="height: 25px">
                                    <cc1:AsyncFileUpload ID="fileLetterPicture2" runat="server" Width="200px" 
                                        Visible="true" OnUploadComplete="fileLetterPicture2_UploadComplete" />
                                </td>
                                <td style="height: 25px">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="left" class="style10" colspan="6"><font style="color:#F00"><asp:Label ID="lbl3" runat="server" Text="*"></asp:Label></font>
                                    <asp:CheckBox ID="CheckBox3" runat="server" 
                                        Font-Names="Calibri" Font-Size="Small" 
                                        Text="Current Production/Storage/Sales license issued by DPR" 
                                        ValidationGroup="LicenseByDPR" AutoPostBack="True" />
                                </td>
                                <td align="left">
                                    <cc1:AsyncFileUpload ID="fileLetterPicture3" runat="server" Width="200px" 
                                        Visible="true" OnUploadComplete="fileLetterPicture3_UploadComplete"/>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="left" class="style10" colspan="6"><font style="color:#F00"><asp:Label ID="lbl4" runat="server" Text="*"></asp:Label></font>
                                    <asp:CheckBox ID="CheckBox4" runat="server" 
                                        Font-Names="Calibri" Font-Size="Small" 
                                        Text="Current Weights and Measures Department certificate of conformity for the Fiscal Meters, Gauges, and all Custody Transfer Weighing &amp; Measuring instruments at the terminal(s) to be used for the export" 
                                        ValidationGroup="WeightMeters" AutoPostBack="True" />
                                </td>
                                <td align="left">
                                    <cc1:AsyncFileUpload ID="fileLetterPicture4" runat="server" Width="200px" 
                                        Visible="true" OnUploadComplete="fileLetterPicture4_UploadComplete"/>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="left" class="style10" colspan="6"><font style="color:#F00"><asp:Label ID="lbl5" runat="server" Text="*"></asp:Label></font>
                                    <asp:CheckBox ID="CheckBox5" runat="server" 
                                        Font-Names="Calibri" Font-Size="Small" 
                                        Text="Original Bank reference with committed and explicit statements" 
                                        ValidationGroup="OriginalBank" AutoPostBack="True" />
                                </td>
                                <td align="left">
                                    <cc1:AsyncFileUpload ID="fileLetterPicture5" runat="server" Width="200px" 
                                        Visible="true" OnUploadComplete="fileLetterPicture5_UploadComplete"/>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="left" class="style10" colspan="6"><font style="color:#F00"><asp:Label ID="lbl6" runat="server" Text="*"></asp:Label></font>
                                    <asp:CheckBox ID="CheckBox6" runat="server" 
                                        Font-Names="Calibri" Font-Size="Small" 
                                        Text="3-Years Tax Clearance Certificate" 
                                        ValidationGroup="TaxClearance" AutoPostBack="True" />
                                </td>
                                <td align="left">
                                    <cc1:AsyncFileUpload ID="fileLetterPicture6" runat="server" Width="200px" 
                                        Visible="true" OnUploadComplete="fileLetterPicture6_UploadComplete"/>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="left" class="style10" colspan="6">
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td colspan="7">
                                    <div class="item_title">
                                        &nbsp;&nbsp;&nbsp;APPLICATION FILLED BY</div>
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
                                <td colspan="2">
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
                                <td class="style7" style="width: 127px" colspan="2">
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
                                <td colspan="2">
                                    <asp:TextBox ID="txtemail" runat="server" ToolTip="enter email address" 
                                        ValidationGroup="emaildocsigned|Invalid email address" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td class="style7" style="width: 127px" colspan="2">
                                    <asp:TextBox ID="txtpassportname1" runat="server" 
                                        ValidationGroup="CoverLetterName1" Visible="False" Width="15px"></asp:TextBox>
                                    <asp:TextBox ID="txtpassportname2" runat="server" 
                                        ValidationGroup="CoverLetterName2" Visible="False" Width="15px"></asp:TextBox>
                                    <asp:TextBox ID="txtpassportname3" runat="server" 
                                        ValidationGroup="CoverLetterName3" Visible="False" Width="15px"></asp:TextBox>
                                    <asp:TextBox ID="txtpassportname4" runat="server" 
                                        ValidationGroup="CoverLetterName4" Visible="False" Width="15px"></asp:TextBox>
                                    <asp:TextBox ID="txtpassportname5" runat="server" 
                                        ValidationGroup="CoverLetterName5" Visible="False" Width="15px"></asp:TextBox>
                                    <asp:TextBox ID="txtpassportname6" runat="server" 
                                        ValidationGroup="CoverLetterName6" Visible="False" Width="15px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td colspan="7">
                                    <div class="item_title">
                                        &nbsp;&nbsp;&nbsp;ACKNOWLEDGEMENT</div>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td colspan="7">
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
                                    <asp:TextBox ID="txtcompanyname" runat="server" CausesValidation="false" 
                                        ToolTip="retype password entered" Visible="False" 
                                        Width="51px"></asp:TextBox>
                                    <asp:TextBox ID="txtTranscode" runat="server" CausesValidation="false" 
                                        ToolTip="retype password entered" ValidationGroup="transcode" Visible="False" 
                                        Width="51px"></asp:TextBox>
                                </td>
                                <td align="right" colspan="2" class="style7">
                                    <asp:Button ID="btnReset" runat="server" Height="25px" Text="Reset" />
                                    <cc1:ConfirmButtonExtender ID="btnReset_ConfirmButtonExtender" runat="server" 
                                        ConfirmOnFormSubmit="True" 
                                        ConfirmText="Are you SURE you want to CLEAR this form" Enabled="True" 
                                        TargetControlID="btnReset">
                                    </cc1:ConfirmButtonExtender>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td class="style7" style="width: 127px" colspan="2">
                                    &nbsp;<asp:Button ID="btnPreview" runat="server" Height="25px" 
                                        Text="CONTINUE" />
                                    <cc1:ConfirmButtonExtender ID="btnPreview_ConfirmButtonExtender" runat="server" 
                                        ConfirmOnFormSubmit="True" 
                                        ConfirmText="Are you SURE you want to CONTINUE this record?" Enabled="True" 
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

  <%--          </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnPreview0" />
            </Triggers>
         </asp:UpdatePanel>
    </asp:Panel>--%>
        </div>

      
    
   </center>
   
 
</div>

        
</div>
  
 
</asp:Content>       