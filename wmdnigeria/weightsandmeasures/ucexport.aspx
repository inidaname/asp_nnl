<%@ Page Title="" Language="VB" MasterPageFile="~/exportpage.master" AutoEventWireup="false" CodeFile="ucexport.aspx.vb" Inherits="ucexport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!--start home-->

<div id="item1">
	 
  <div class="item_title">&nbsp;&nbsp;&nbsp; ULTIMATE CONSIGNEE</div>
           <br /><br /><br />
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>
                       
	                         <center >
        	                    <img src="images/coatofarm.jpg" />
        	                    <br />
                               <h1> <strong > MINISTRY OF INDUSTRY, TRADE AND INVESTMENT</strong></h1><br />
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
  40.0pt;font-family:&quot;Cambria&quot;,&quot;serif&quot;">(CRUDE OIL, GAS AND OTHER PETROLEUM PRODUCTS)</span><span 
                                                         style="font-size:26.0pt;mso-bidi-font-size:40.0pt;font-family:&quot;Cambria&quot;,&quot;serif&quot;"><o:p></o:p></span></b></p>
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
        <div class="item_title"><asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></div>
                <div id="item2">
                      <asp:Panel ID="Panel1" runat="server">
                        <table style="width:100%;" cellspacing="1" cellpadding="0">
                        
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td bgcolor="#99A6B4" colspan="5">
                                    <div class="item_title">&nbsp;&nbsp;&nbsp;ULTIMATE CONSIGNEE FORM DV001</div>
                                </td>
                                <td>
                                 
                                </td>
                            </tr>
    <tr>
                                <td>
                                    &nbsp;</td>
                                <td bgcolor="#99A6B4" colspan="5">
                                <center >
                                      <asp:Label ID="Label2" runat="server" Text="Select Record To Modify:" 
                                          Font-Names="Calibri" Font-Size="Small" ForeColor="#220066"></asp:Label>
                                      <asp:DropDownList
                                        ID="cboUCEdit" runat="server" AutoPostBack="True">
                                    </asp:DropDownList></center>
                                </td>
                                <td>
                                 
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td bgcolor="#99A6B4" colspan="5">
                                    <asp:Panel ID="Panel2" runat="server">
                                        <table cellpadding="0" cellspacing="1" style="width:100%;">
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td colspan="5" style="background-color:#99A6B4">
                                                    <div class="item_title">
                                                        &nbsp;&nbsp;&nbsp;1. COMPANY DETAILS</div>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style27">
                                                    <asp:Label ID="Label29" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                        Text="Name:"></asp:Label>
                                                </td>
                                                <td class="style48">
                                                    <asp:TextBox ID="txtcompany" runat="server" ToolTip="enter  name" 
                                                        ValidationGroup="UCName|Invalid Name" Width="204px"></asp:TextBox>
                                                </td>
                                                <td class="style15">
                                                    &nbsp;</td>
                                                <td class="style14">
                                                    <asp:Label ID="Label19" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                        Text="Email:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtemailaddress" runat="server" ToolTip="enter email address" 
                                                        ValidationGroup="email|Invalid email address" Width="204px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style27">
                                                    <asp:Label ID="Label9" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                        Text="Address 1:"></asp:Label>
                                                </td>
                                                <td class="style48">
                                                    <asp:TextBox ID="txtusername12" runat="server" ToolTip="enter  address1" 
                                                        ValidationGroup="Address1|Invalid address1" Width="204px"></asp:TextBox>
                                                </td>
                                                <td class="style15">
                                                    &nbsp;</td>
                                                <td class="style14">
                                                    <asp:Label ID="Label14" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                        Text="Fax:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtusername6" runat="server" ToolTip="enter fax Number" 
                                                        ValidationGroup="faxNumber|Invalid fax number" Width="204px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style27">
                                                    <asp:Label ID="Label34" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                        Text="Address 2:"></asp:Label>
                                                </td>
                                                <td class="style48">
                                                    <asp:TextBox ID="txtusername19" runat="server" ToolTip="enter address2" 
                                                        ValidationGroup="Address2" Width="204px"></asp:TextBox>
                                                </td>
                                                <td class="style15">
                                                    &nbsp;</td>
                                                <td class="style14">
                                                    <asp:Label ID="Label33" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                        Text="Telephone:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtusername18" runat="server" ToolTip="enter telephone" 
                                                        ValidationGroup="telephone|Invalid telephone" Width="204px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style27">
                                                    <asp:Label ID="Label30" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                        Text="Postal Address:"></asp:Label>
                                                </td>
                                                <td class="style48">
                                                    <asp:TextBox ID="txtusername2" runat="server" style="height: 22px" 
                                                        ToolTip="enter postal address" ValidationGroup="Postal|invalid Postal address" 
                                                        Width="204px"></asp:TextBox>
                                                </td>
                                                <td class="style15">
                                                    &nbsp;</td>
                                                <td class="style14">
                                                    <asp:Label ID="Label32" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                        Text="City:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtusername20" runat="server" ToolTip="enter city" 
                                                        ValidationGroup="City|Invalid city" Width="204px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style27">
                                                    <asp:Label ID="Label11" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                        Text="Country:"></asp:Label>
                                                </td>
                                                <td class="style48">
                                                    <asp:DropDownList ID="cboCountry" runat="server" ToolTip="select country" 
                                                        ValidationGroup="countryID|Please select country|1" Width="204px">
                                                        <asp:ListItem Selected="True">Select Value</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="style15">
                                                    &nbsp;</td>
                                                <td class="style14">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style16" colspan="5">
                                                    <div class="item_title">
                                                        &nbsp;&nbsp;&nbsp;2.	DISPOSITION OR USE OF ITEMS BY ULTIMATE CONSIGNEE NAMED IN BLOCK 1 We certify that the items</div>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style16" colspan="5">
                                                    <p class="MsoNormal">
                                                        <span style="font-size:10.0pt">A. </span>
                                                        <span style="font-size:20.0pt;
mso-bidi-font-family:Arial">&nbsp;</span><span style="font-size:8.0pt">Will be processed or incorporated by us into the following 
                                                        product (s)&nbsp; <asp:TextBox ID="TextBox1" runat="server" ValidationGroup="fpName"></asp:TextBox>
                                                        to be produced in the country named in Block 1 for distribution in&nbsp;
                                                        <asp:TextBox ID="TextBox2" runat="server" ValidationGroup="fpdistributionIn"></asp:TextBox>
                                                        
                                                        <p>
                                                        </p>
                                                        </span>
                                                        <p>
                                                        </p>
                                                        <p class="MsoNormal">
                                                            <span style="font-size:10.0pt">B. </span>
                                                            <span style="font-size:20.0pt;
mso-bidi-font-family:Arial">&nbsp;</span><span style="font-size:8.0pt">Will be resold by us in the form in which received in the country named in 
                                                            Block 1 for use or consumption therein. The specific end-use by my customer will
                                                            <span style="mso-spacerun:yes">&nbsp;</span>be
                                                            <asp:TextBox ID="TextBox3" runat="server" ValidationGroup="resoledForm"></asp:TextBox>
                                                        
                                                            <p>
                                                            </p>
                                                            </span>
                                                            <p>
                                                            </p>
                                                            <p class="MsoNormal">
                                                                <span style="font-size:10.0pt">C. </span>
                                                                <span style="font-size:20.0pt;
mso-bidi-font-family:Arial">&nbsp;</span><span style="font-size:8.0pt">Will be re-exported by us in the form in which received to&nbsp;
                                                                <asp:TextBox ID="TextBox4" runat="server" ValidationGroup="reExportedForm"></asp:TextBox>
                                                        
                                                                <p>
                                                                </p>
                                                                </span>
                                                                <p>
                                                                </p>
                                                                <p class="MsoNormal">
                                                                    <span style="font-size:10.0pt">D. </span>
                                                                    <span style="font-size:20.0pt;
mso-bidi-font-family:Arial">&nbsp;</span><span style="font-size:8.0pt">Other (describe 
                                                                    fully)
                                                                    <asp:TextBox ID="TextBox5" runat="server" ValidationGroup="others"></asp:TextBox>
                                                        
                                                                    <p>
                                                                   <hr />
                                                                    </span>
                                                                    <span style="font-size:3.0pt;mso-bidi-font-size:7.0pt">
                                                                    <p>
                                                                        &nbsp;</p>
                                                                    </span>
                                                                    <p>
                                                                        <span style="font-size:9.0pt;line-height:115%;font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;;
mso-fareast-font-family:Calibri;mso-bidi-font-family:&quot;Times New Roman&quot;;
mso-ansi-language:EN-US;mso-fareast-language:EN-US;mso-bidi-language:AR-SA">NOTE: If BOX (C) is checked, acceptance of this form by the Ministry as 
                                                                    a supporting document for license applications shall not be construed as an 
                                                                    authorization to re-export the items to which the form applies unless specific 
                                                                    approval has been obtained from the Ministry for such export.`</span><hr /></td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style22" colspan="5">
                                                   <div class="item_title">
                                                        &nbsp;&nbsp;&nbsp;3.	NATURE OF BUSINESS OF ULTIMATE CONSIGNEE NAMED IN BLOCK 1</div></td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style22" colspan="5">
                                                    <p class="style23" style="mso-add-space: auto; mso-list: l0 level1 lfo1">
                                                        <![if !supportLists]><span style="font-size:8.0pt;mso-bidi-font-family:Calibri">
                                                        <span style="mso-list:
Ignore">A.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><![endif]><span style="font-size:8.0pt">The 
                                                        nature of our usual business 
                                                        is-<span style="font-size:8.0pt">
                                                                    <asp:TextBox ID="TextBox6" runat="server" 
                                                            ValidationGroup="bizNature|Invalid nature of business" Width="300px"></asp:TextBox>
                                                        
                                                                    </span>
                                                                    <p>
                                                        </p>
                                                        </span>
                                                      <br />
                                                        <span style="font-size:8.0pt"></span>
                                                        <p>
                                                        </p>
                                                        <p class="style25" style="mso-add-space: auto; mso-list: l0 level1 lfo1">
                                                            <![if !supportLists]><span style="font-size:9.0pt;mso-bidi-font-family:Calibri">
                                                            <span style="mso-list:
Ignore">B.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><![endif]><span style="font-size:8.0pt">Our 
                                                            business relationship with the Nigerian <span style="mso-spacerun:yes">&nbsp;</span>exporter 
                                                            is<span style="font-size:8.0pt">
                                                            <asp:TextBox ID="TextBox7" runat="server" 
                                                                ValidationGroup="bizRelationship|Invalid Business Relationship" Width="204px"></asp:TextBox>
                                                            </span></span><span style="font-size:9.0pt">
                                                            <p>
                                                            </p>
                                                            </span>
                                                            <p>
                                                            </p>
                                                            <span style="font-size:8.0pt;line-height:115%;font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;;
mso-fareast-font-family:Calibri;mso-bidi-font-family:&quot;Times New Roman&quot;;
mso-ansi-language:EN-US;mso-fareast-language:EN-US;mso-bidi-language:AR-SA"><span style="mso-spacerun:yes">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>and we have 
                                                            had this business relationship for<span style="font-size:8.0pt">
                                                            <asp:TextBox ID="TextBox8" runat="server" 
                                                                ValidationGroup="BizYear|Invalid Business Year" Width="80px"></asp:TextBox>
                                                            </span>year(s).</span><p>
                                                         
                                                    </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style22" colspan="5">
                                                    <div class="item_title">
                                                        &nbsp;&nbsp;&nbsp;4.	ADDITIONAL INFORMATION</div>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style27">
                                                    <asp:Label ID="Label35" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                        Text="Information:"></asp:Label>
                                                </td>
                                                <td class="style48" colspan="4">
                                                    <span style="font-size:8.0pt">
                                                    <asp:TextBox ID="TextBox9" runat="server" 
                                                        ValidationGroup="additionalInfor|Invalid additional information" 
                                                        Width="100%"></asp:TextBox>
                                                    </span></td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style27" colspan="5">
                                                    <div class="item_title">
                                                        &nbsp;&nbsp;&nbsp;5. ASSISTANCE IN PREPARING STATEMENT</div>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style27" colspan="5">
                                                    <i style="mso-bidi-font-style:normal">
                                                    <span style="font-size:9.0pt;mso-bidi-font-size:8.0pt;line-height:115%;font-family:
&quot;Calibri&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:Calibri;mso-bidi-font-family:
&quot;Times New Roman&quot;;mso-ansi-language:EN-US;mso-fareast-language:EN-US;
mso-bidi-language:AR-SA">STATEMENT OF ULTIMATE CONSIGNEE AND PURCHASER </span>
                                                    <span style="font-size:9.0pt;mso-bidi-font-size:7.0pt;line-height:115%;font-family:
&quot;Calibri&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:Calibri;mso-bidi-font-family:
&quot;Times New Roman&quot;;mso-ansi-language:EN-US;mso-fareast-language:EN-US;
mso-bidi-language:AR-SA">We certify that all of the facts contained in this statement are true and correct to the best of our 
                                                    knowledge and we do not know of any additional facts which are inconsistent with 
                                                    the above statement. We shall promptly send a supplemental statement to the 
                                                    NIGERIAN Exporter, disclosing any change of facts or intentions set forth in 
                                                    this statement which occurs after the statement has been prepared and forwarded, 
                                                    except as specifically authorized by the NIGERIAN Export Government or by prior 
                                                    written approval of the Ministry, we will not re-export, resell, or otherwise 
                                                    dispose of any items approved on a license supported by this statement (1) to 
                                                    any country not approved for export as brought to our attention by means of a 
                                                    bill of lading, commercial invoice, or any other means, or(2) to any person if 
                                                    we know that it will result directly or indirectly, in disposition of the items 
                                                    contrary to the representations made in this statement or contrary to Export 
                                                    Administration Regulations.</span></i></td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style27" colspan="5">
                                                    <div class="item_title">
                                                        &nbsp;&nbsp;&nbsp;6.	 SIGNATURE OF OFFICIAL OF ULTIMATE CONSIGNEE</div>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style27">
                                                    <asp:Label ID="Label36" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                        Text="Title:"></asp:Label>
                                                </td>
                                                <td class="style48">
                                                    <asp:DropDownList ID="cbosTitle0" runat="server" ToolTip="select title" 
                                                        ValidationGroup="Officialtitle|Please select title" Width="204px">
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
                                                <td class="style15">
                                                    &nbsp;</td>
                                                <td class="style14">
                                                    <asp:Label ID="Label37" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                        Text="Official Name:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtfullname0" runat="server" ToolTip="enter your fullname" 
                                                        ValidationGroup="OfficialName|Invalid fullname" Width="204px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style27">
                                                    <asp:Label ID="Label38" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                        Text="Date:"></asp:Label>
                                                </td>
                                                <td class="style48">
                                                    <asp:TextBox ID="txtDPTTo" runat="server" BorderStyle="Solid" BorderWidth="1px" 
                                                        Font-Bold="False" Font-Names="Calibri" Font-Size="Small" Height="20px" 
                                                        ToolTip="select  date" 
                                                        ValidationGroup="officialDate|Invalid date" Width="80px"></asp:TextBox>
                                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd"  PopupPosition="TopLeft"
                                                        PopupButtonID="childimgbtnCal" TargetControlID="txtDPTTo">
                                                    </cc1:CalendarExtender>
                                                    <asp:ImageButton ID="childimgbtnCal" runat="server" Height="16px" 
                                                        ImageUrl="~/img/cal3.png"  Width="16px" />
                                                </td>
                                                <td class="style15">
                                                    &nbsp;</td>
                                                <td class="style14">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style27" colspan="5">
                                                    <div class="item_title">
                                                        &nbsp;&nbsp;&nbsp;7.	 NAME OF PURCHASER</div>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style27">
                                                    <asp:Label ID="Label39" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                        Text="Title:"></asp:Label>
                                                </td>
                                                <td class="style48">
                                                    <asp:DropDownList ID="cbosTitle1" runat="server" ToolTip="select title" 
                                                        ValidationGroup="Purchasertitle|Please select title" Width="204px">
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
                                                <td class="style15">
                                                    &nbsp;</td>
                                                <td class="style14">
                                                    <asp:Label ID="Label40" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                        Text="Purchaser Name:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtfullname1" runat="server" ToolTip="enter your fullname" 
                                                        ValidationGroup="purchaserName|Invalid fullname" Width="204px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style27">
                                                    <asp:Label ID="Label41" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                        Text="Date:"></asp:Label>
                                                </td>
                                                <td class="style48">
                                                    <asp:TextBox ID="txtDPTP" runat="server" BorderStyle="Solid" 
                                                        BorderWidth="1px" Font-Bold="False" Font-Names="Calibri" Font-Size="Small" 
                                                        Height="20px" ToolTip="select  date" 
                                                        ValidationGroup="purchaserDate|Invalid date" Width="80px"></asp:TextBox>
                                                    <cc1:CalendarExtender ID="CalendarExtender3" runat="server" 
                                                        Format="yyyy-MM-dd"   PopupPosition="TopLeft"
                                                        PopupButtonID="childimgbtnCalP" TargetControlID="txtDPTP">
                                                    </cc1:CalendarExtender>
                                                    <asp:ImageButton ID="childimgbtnCalP" runat="server" Height="16px" 
                                                        ImageUrl="~/img/cal3.png"  Width="16px" />
                                                </td>
                                                <td class="style15">
                                                    &nbsp;</td>
                                                <td class="style14">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="7">
                                                    <div class="item_title">
                                                        &nbsp;&nbsp;&nbsp;8.	NAME OF EXPORTER  </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style27">
                                                    <asp:Label ID="Label20" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                        Text="Title:"></asp:Label>
                                                </td>
                                                <td class="style48">
                                                    <asp:DropDownList ID="cbosTitle" runat="server" ToolTip="select title" 
                                                        ValidationGroup="exporterTitle|Please select title" Width="204px">
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
                                                <td class="style15">
                                                    &nbsp;</td>
                                                <td class="style14">
                                                    <asp:Label ID="Label21" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                        Text="Exporter Name:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtfullname" runat="server" ToolTip="enter your fullname" 
                                                        ValidationGroup="exporterName|Invalid fullname" Width="204px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style27">
                                                    &nbsp;</td>
                                                <td class="style48">
                                                    &nbsp;</td>
                                                <td class="style15">
                                                    &nbsp;</td>
                                                <td class="style14">
                                                    &nbsp;</td>
                                                <td>
                                                    <asp:TextBox ID="txtTranscode" runat="server" CausesValidation="false" 
                                                        ValidationGroup="transcode" Visible="False" Width="51px"></asp:TextBox>
                                                    <asp:TextBox ID="txtID" runat="server" CausesValidation="false" 
                                                        ValidationGroup="companyID" Visible="False" Width="51px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style20">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td class="style19">
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
                                       We acknowledge that the making of any false statements or concealment of any material fact in connection with this statement may result in imprisonment or fine, or both and denial, in whole or in part, of participation in NIGERIAN exports and re-exports.<hr /></span></b>
                                    </center>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style20">
                                    &nbsp;</td>
                                <td align="right">
                                    <asp:Button ID="btnReset" runat="server" Height="25px" Text="Reset" />
                                    <cc1:ConfirmButtonExtender ID="btnReset_ConfirmButtonExtender" runat="server" 
                                        ConfirmOnFormSubmit="True" 
                                        ConfirmText="Are you SURE you want to CLEAR this form" Enabled="True" 
                                        TargetControlID="btnReset">
                                    </cc1:ConfirmButtonExtender>
                                </td>
                                <td>
                                    <asp:Button ID="btnPreview" runat="server" Height="25px" style="height: 26px" 
                                        Text="Submit" />
                                    <cc1:ConfirmButtonExtender ID="btnPreview_ConfirmButtonExtender" runat="server" 
                                        ConfirmOnFormSubmit="True" 
                                        ConfirmText="Are you SURE you want to SAVE this record?" Enabled="True" 
                                        TargetControlID="btnPreview">
                                    </cc1:ConfirmButtonExtender>
                                </td>
                                <td class="style19">
                                    &nbsp;</td>
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
    
<!--end home-->
</asp:Content>

