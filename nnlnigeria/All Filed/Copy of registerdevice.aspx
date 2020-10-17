<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/companynoheader.master" CodeFile="Copy of registerdevice.aspx.vb" Inherits="registerdevice" %>

<%@ Import Namespace="System.Data" %>

 <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>

<div id="item1">
    	 
    	<div class="item_title">&nbsp;&nbsp;&nbsp; Registration Application Form (W002)</div>
    	<div>
	                         <br /><br /><br />
                       
	                         <center >
        	                    <img src="images/coatofarm.jpg" alt ="" />
        	                    <br />
                               <h1> <strong > FEDERAL MINISTRY OF INDUSTRY,TRADE AND INVESTMENT</strong></h1><br />
                                 <h3>  WEIGHTS AND MEASURES DEPARTMENT</h3> 
                                   <h3> Old Secretariat Area I, Garki Abuja</h3>
                                   <br />
                               <h1> <strong >   REGISTRATION FORM</strong></h1>
                            </center> 	
                            <hr />
      <center>

    <div style="width : 75%"  id="main-menu" >

         <asp:UpdatePanel ID="UpdatePanel1" runat ="server" >
            <ContentTemplate >
            <div class="item_title"> 
                    <asp:Button ID="btnBulkregistration" runat="server" Text="BULK INSTRUMENT REGISTRATION" 
                        BorderColor="#669999" ForeColor="#F66100" />               
              </div>

              <div class="item_title">&nbsp;&nbsp;&nbsp; 
                                        <asp:CheckBox ID="chkUseCompany" runat="server" 
                                            Text="Tick Here If The Instrument In This Location Belong To "
                                       AutoPostBack="True" />
              </div>

        <div class="item_title"><asp:Label ID="lblMsg" runat="server" ForeColor="#FF3300"></asp:Label></div>

                <div  id="item2">
                   <asp:Panel ID="MainRegForm" runat="server">
                    <asp:Panel ID="Panel1" runat="server">
                        <table style="width:100%;" cellspacing="1" cellpadding="0">
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td style="background-color:#99A6B4" colspan="5">
                                    <div class="item_title">&nbsp;&nbsp;&nbsp;INSTRUMENT LOCATION&nbsp; (<asp:Label ID="lblMsg0" 
                                            runat="server" ForeColor="#FF3300">All Fields Are Required</asp:Label>
                                        )</div>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style49" style="width: 108px">
                                    <asp:Label ID="Label8" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Name Of Company:"></asp:Label>
                                </td>
                                <td class="style48">
                                    <asp:TextBox ID="txtcompany" runat="server" ToolTip="enter company name" 
                                        ValidationGroup="companyName|Invalid Company Name" Width="204px"></asp:TextBox>
                                </td>
                                <td class="style54">
                                    &nbsp;</td>
                                <td class="style49">
                                    <asp:Label ID="Label19" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Email:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtcompanyemail" runat="server" 
                                        ValidationGroup="companyEmail|Invalid company email address" Width="204px" 
                                        ToolTip="enter email address"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style49" style="width: 108px">
                                    <asp:Label ID="Label9" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Address:"></asp:Label>
                                </td>
                                <td class="style48">
                                    <asp:TextBox ID="txtusername12" runat="server" 
                                        ToolTip="enter company's address" 
                                        ValidationGroup="streetAddress|Invalid company address" Width="204px"></asp:TextBox>
                                </td>
                                <td class="style54">
                                    &nbsp;</td>
                                <td class="style49">
                                    <asp:Label ID="Label14" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Website:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtusername6" runat="server" 
                                        ValidationGroup="companywebsite|Invalid company website" 
                                        ToolTip="enter company website" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style49" style="width: 108px">
                                    <asp:Label ID="Label10" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="P.O. Box:"></asp:Label>
                                </td>
                                <td class="style48">
                                    <asp:TextBox ID="txtusername2" runat="server" ToolTip="enter company's P.O.Box" 
                                        ValidationGroup="POBOX|invalid P.O. Box" style="height: 22px" 
                                        Width="204px"></asp:TextBox>
                                </td>
                                <td class="style54">
                                    &nbsp;</td>
                                <td class="style49">
                                    <asp:Label ID="Label11" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="State:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="cboState" runat="server" AutoPostBack="True" 
                                        Font-Names="Calibri" Font-Size="Small" ToolTip="select company's state" 
                                        ValidationGroup="StateID|Invalid State|1" Width="204px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style49" style="width: 108px">
                                    <asp:Label ID="Label13" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="City:"></asp:Label>
                                </td>
                                <td class="style48">
                                
                                    <asp:DropDownList ID="cboCity" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" ToolTip="enter company's city" 
                                        ValidationGroup="cityID|Invalid City|1" Width="204px">
                                    </asp:DropDownList>
                                  
                                </td>
                                <td class="style54">
                                    &nbsp;</td>
                                <td class="style49">
                                    <asp:Label ID="Label12" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="LGA:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="cboLGA" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" ToolTip="enter company's LGA" 
                                        ValidationGroup="LGAID|Invalid LGA|1" Width="204px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style49" style="width: 108px">
                                    &nbsp;</td>
                                <td class="style48">
                                    &nbsp;</td>
                                <td class="style54">
                                    &nbsp;</td>
                                <td class="style49">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>   

                    <asp:Panel ID="Panel2" runat="server">
                       <table style="width:100%;" cellspacing="1" cellpadding="0">

                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td style="background-color:#99A6B4" colspan="5">
                                    <div class="item_title">&nbsp;&nbsp;&nbsp;INSTRUMENT DETAILS&nbsp; </div>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style39" colspan="5">
                                    &nbsp;</td>
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
                                        IT IS AN OFFENSE PUNISHABLE BY LAW IF INSTRUMENTS USED FOR TRADE IN THE FEDERAL 
                                        REPUBLIC OF NIGERIA ARE NOT REGISTERED.</center>
                                    </span></b>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style39" style="width: 113px">
                                    &nbsp;</td>
                                <td class="style41">
                                    &nbsp;</td>
                                <td class="style22">
                                    &nbsp;</td>
                                <td class="style40" style="width: 173px">
                                    &nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtamount" runat="server" ValidationGroup="deviceAmount|" 
                                        Visible="False" Width="64px"></asp:TextBox>
                                    <asp:TextBox ID="txtAccountID" runat="server" ValidationGroup="AccountID|" 
                                        Visible="False" Width="64px"></asp:TextBox>
                                    <asp:TextBox ID="txtBarCode" runat="server" ValidationGroup="barCode|" 
                                        Visible="False" Width="64px"></asp:TextBox>
                                    <asp:TextBox ID="txtTransCode" runat="server" Height="16px" 
                                        ValidationGroup="TransCode|" Visible="False" Width="17px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style39" style="width: 113px">
                                    <asp:Label ID="Label25" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Instrument:"></asp:Label>
                                </td>
                                <td class="style41">
                                    <asp:DropDownList ID="cboMainGroup" runat="server" AutoPostBack="True" 
                                        Font-Names="Calibri" Font-Size="Small" 
                                        ValidationGroup="DeviceGroupID|Invalid Instrument Category|1" Width="204px">
                                    </asp:DropDownList>
                                </td>
                                <td class="style22">
                                    &nbsp;</td>
                                <td class="style40" style="width: 173px">
                                    <asp:Label ID="Label1" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Model No:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtModel" runat="server" style="margin-bottom: 0px" 
                                        ToolTip="enter Instrument model" 
                                        ValidationGroup="modelNumber|Invalid Instrument model" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style39" style="width: 113px">
                                    <asp:Label ID="Label26" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Parameters:" ToolTip="Measurement Parameters"></asp:Label>
                                </td>
                                <td class="style41">
                                    <asp:DropDownList ID="cboDeviceSub" runat="server" AutoPostBack="True" 
                                        Font-Names="Calibri" Font-Size="Small" 
                                        ValidationGroup="SubDeviceID|Invalid Instrument group|1" Width="204px">
                                    </asp:DropDownList>
                                </td>
                                <td class="style22">
                                    &nbsp;</td>
                                <td class="style40" style="width: 173px">
                                    <asp:Label ID="Label2" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Serial/Tag number."></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtserial" runat="server" 
                                        ToolTip="enter Instrument serial number" 
                                        ValidationGroup="serialNumber|Invalid Serial Number" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style39" style="width: 113px">
                                    <asp:Label ID="Label4" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Instrument Type:"></asp:Label>
                                </td>
                                <td class="style41">
                                
                                    <asp:DropDownList ID="cboTypeOfDevice" runat="server" AutoPostBack="True" 
                                        Font-Names="Calibri" Font-Size="Small" ToolTip="enter Instrument type" 
                                        ValidationGroup="typeOfDevice|Invalid Instrument Type|1" Width="204px">
                                    </asp:DropDownList>
                                  
                                </td>
                                <td class="style22">
                                    &nbsp;</td>
                                <td class="style40" style="width: 173px">
                                    <asp:Label ID="Label3" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Manufacturer's Name:"></asp:Label>
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
                                <td class="style39" style="width: 113px">
                                    <asp:Label ID="Label29" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Process Fluid:" Visible="False"></asp:Label>
                                </td>
                                <td class="style41">
                                    <asp:DropDownList ID="cboProcessFluid" runat="server" AutoPostBack="True" 
                                        Font-Names="Calibri" Font-Size="Small" ValidationGroup="ProcessFluid" 
                                        Visible="False" Width="204px">
                                        <asp:ListItem>None</asp:ListItem>
                                        <asp:ListItem>Oil</asp:ListItem>
                                        <asp:ListItem>Gas</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="style22">
                                    &nbsp;</td>
                                <td class="style40" style="width: 173px">
                                    <asp:Label ID="Label27" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Instr. Model Name:" ToolTip="Instrument Model Name:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox6" runat="server" ToolTip="enter Instrument model name" 
                                        ValidationGroup="DeviceModelName|Invalid Instrument model name" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style39" style="width: 113px">
                                    <asp:Label ID="Label30" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Location:"></asp:Label>
                                </td>
                                <td class="style41" colspan="4">
                                    <asp:TextBox ID="TextBox7" runat="server" ValidationGroup="Location" 
                                        Width="100%"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style39" colspan="5">
                                    <div class="item_title">
                                        &nbsp;&nbsp;&nbsp;INSTRUMENT ANNUAL LICENSING FEE (<asp:Label ID="lblAmount" 
                                            runat="server" Visible="False"></asp:Label>
                                        )&nbsp;&nbsp;
                                    </div>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style39" style="width: 113px">
                                    <asp:Label ID="Label7" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Fee Category:"></asp:Label>
                                </td>
                                <td class="style41">
                                    <asp:DropDownList ID="cboFeegroup" runat="server" AutoPostBack="True" 
                                        Font-Names="Calibri" Font-Size="Small" ValidationGroup="feeIDGroup|Invalid Scale Group|1" 
                                        Width="204px">
                                    </asp:DropDownList>
                                </td>
                                <td class="style22">
                                    &nbsp;</td>
                                <td class="style40" style="width: 173px">
                                    <asp:Label ID="Label23" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Instru. Capacity:" ToolTip="Instrument Capacity"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="cboMrange" runat="server" AutoPostBack="True" 
                                        Font-Names="Calibri" Font-Size="Small" ToolTip="enter company's city" 
                                        ValidationGroup="feeID|Invalid Official Measure|1" Width="204px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style39" style="width: 113px">
                                    <asp:Label ID="Label21" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Sub Section:"></asp:Label>
                                </td>
                                <td align="left" class="style41">
                                    <asp:DropDownList ID="cboFeeSubGroup" runat="server" AutoPostBack="True" 
                                        Font-Names="Calibri" Font-Size="Small" 
                                        ValidationGroup="feeIDSubGroup|Invalid Scale Sub-Group|1" Width="204px">
                                    </asp:DropDownList>
                                </td>
                                <td class="style22">
                                    &nbsp;</td>
                                <td align="left" class="style40" style="width: 173px">
                                    <asp:Label ID="Label24" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Actual Measure:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox5" runat="server" 
                                        ToolTip="enter actual Instrument measure" 
                                        ValidationGroup="actualMeasure|Invalid Actual Measure" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style39" colspan="5">
                                   <div class="item_title">
                                        &nbsp;&nbsp;&nbsp;INSTRUMENT CERTIFICATE STATUS&nbsp;&nbsp;
                                    </div></td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                             <tr>
                                 <td>
                                     &nbsp;</td>
                                 <td class="style39" style="width: 113px">
                                     &nbsp;</td>
                                 <td align="left" class="style41" colspan="4">
                                     <asp:RadioButton ID="RadioButton1" runat="server" AutoPostBack="True" 
                                         Font-Names="Calibri" Font-Size="Small" GroupName="certificate" 
                                         Text="Tick if the Instrument has " ValidationGroup="dApprovalPattern" />
                                     <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Names="Calibri" 
                                         Font-Size="Small" ForeColor="#FF3300" Text=" Pattern Approval Certificate "></asp:Label>
                                     <asp:Label ID="Label6" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                         Text="from the Weights and Measures Department"></asp:Label>
                                 </td>
                                 <td>
                                     &nbsp;</td>
                            </tr>
                             <%  If RadioButton1.Checked = True Then%>

                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style39" style="width: 113px">
                                    <asp:Label ID="lblCerticateNo" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Certificate No." Visible="False"></asp:Label>
                                </td>
                                <td align="left" class="style41">
                                    <asp:TextBox ID="txtCerticateNo" runat="server" 
                                        ValidationGroup="CertificateNo" Width="204px" Visible="False"></asp:TextBox>
                                </td>
                                <td class="style22">
                                    &nbsp;</td>
                                <td align="left" class="style40" style="width: 173px">
                                    <asp:Label ID="lblDateIssued" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Date Issued" Visible="False"></asp:Label>
                                </td>
                                <td>

                                    <asp:TextBox ID="txtDateIssued" runat="server" 
                                        ValidationGroup="certDateIssed" Width="80px" Font-Bold="False" 
                                        Font-Names="Calibri" Font-Size="Small" Height="20px" Visible="False"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" 
                                        Format="yyyy-MM-dd" PopupButtonID="childimgbtnCal0" 
                                        TargetControlID="txtDateIssued">
                                    </cc1:CalendarExtender>
                                    <asp:ImageButton ID="childimgbtnCal0" runat="server" Height="16px" 
                                        ImageUrl="~/img/cal3.png" ValidationGroup="dd" Width="16px" 
                                        Visible="False" />
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>

                            <% end if  %>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style39" style="width: 113px">
                                    &nbsp;</td>
                                <td align="left" class="style41" colspan="4">
                                    <asp:RadioButton ID="RadioButton2" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" GroupName="Certificate" 
                                        Text="Tick if the instrument has " 
                                        ValidationGroup="dPeriodicCertificate" AutoPostBack="True" /><asp:Label ID="Label15" runat="server"
                                            Text=" Initial Verification Certificate " Font-Names="Calibri" 
                                        Font-Size="Small" Font-Bold="True" ForeColor="#FF3300"></asp:Label>   <asp:Label ID="Label16" runat="server" Text=" and "  Font-Names="Calibri" 
                                        Font-Size="Small"></asp:Label><asp:Label ID="Label17" runat="server"
                                            Text=" Periodic Verification Certificate " Font-Names="Calibri" 
                                        Font-Size="Small" Font-Bold="True" ForeColor="#FF3300"></asp:Label>
                                </td>  
                                <td>
                                    &nbsp;</td>
                            </tr>

                     <%  If RadioButton2.Checked = True Then%>

                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style39" style="width: 113px">
                                    <asp:Label ID="Label22" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Certificate No." Visible="False"></asp:Label>
                                </td>
                                <td align="left" class="style41">
                                    <asp:TextBox ID="txtVerificationCERT" runat="server" 
                                        ValidationGroup="CertificateNoVerification" Width="204px" Visible="False"></asp:TextBox>
                                </td>
                                <td class="style22">
                                    &nbsp;</td>
                                <td align="left" class="style40" style="width: 173px">
                                    <asp:Label ID="Label28" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Date Issued" Visible="False"></asp:Label>
                                </td>
                                <td>

                                    <asp:TextBox ID="txtVerDate" runat="server" 
                                        ValidationGroup="VerificationcertDateIssed" Width="80px" Font-Bold="False" 
                                        Font-Names="Calibri" Font-Size="Small" Height="20px" Visible="False"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" 
                                        Format="yyyy-MM-dd" PopupButtonID="ImageButton1" 
                                        TargetControlID="txtVerDate">
                                    </cc1:CalendarExtender>
                                    <asp:ImageButton ID="ImageButton1" runat="server" Height="16px" 
                                        ImageUrl="~/img/cal3.png" ValidationGroup="dd" Width="16px" 
                                        Visible="False" />
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>

                            <% end if  %>
                        

                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style39" style="width: 113px">
                                    &nbsp;</td>
                                <td align="left" class="style41" colspan="4">
                                    <asp:RadioButton ID="RadioButton3" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" GroupName="certificate" Text="Tick To Apply For Pattern Of " 
                                        ValidationGroup="ApplyForCertificate" AutoPostBack="True" /><asp:Label ID="Label18" runat="server"
                                            Text=" Approval Certificate " Font-Names="Calibri" 
                                        Font-Size="Small" Font-Bold="True" ForeColor="#FF3300"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style39" style="width: 113px">
                                    &nbsp;</td>
                                <td align="left" class="style41" colspan="4">
                                    <asp:RadioButton ID="RadioButton4" runat="server" Font-Names="Calibri" 
                                        Font-Size="Small" GroupName="certificate" 
                                        Text="Tick To Apply For " 
                                        ValidationGroup="ApplyForVerificationCert" AutoPostBack="True" /><asp:Label ID="Label20" runat="server"
                                            Text=" Initial Verification Certificate " Font-Names="Calibri" 
                                        Font-Size="Small" Font-Bold="True" ForeColor="#FF3300"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style39" style="width: 113px">
                                    &nbsp;</td>
                                <td align="center" class="style41">
                                    &nbsp;</td>
                                <td class="style22">
                                    &nbsp;</td>
                                <td align="left" class="style40" style="width: 173px">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style39" style="width: 113px">
                                    &nbsp;</td>
                                <td align="center" class="style41">
                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" Visible="False" />
                                    <cc1:ConfirmButtonExtender ID="btnDelete_ConfirmButtonExtender" runat="server" 
                                        ConfirmOnFormSubmit="True" 
                                        ConfirmText="Are you sure you want to DELETE this Instrument" Enabled="True" 
                                        TargetControlID="btnDelete">
                                    </cc1:ConfirmButtonExtender>
                                </td>
                                <td class="style22">
                                    &nbsp;</td>
                                <td align="left" class="style40" style="width: 173px">
                                    <asp:Button ID="btnPreview" runat="server" style="height: 26px" Text="Submit" />
                                    <cc1:ConfirmButtonExtender ID="btnPreview_ConfirmButtonExtender" runat="server" 
                                        ConfirmOnFormSubmit="True" 
                                        ConfirmText="Are you sure you want SAVE this record?" Enabled="True" 
                                        TargetControlID="btnPreview">
                                    </cc1:ConfirmButtonExtender>
                                </td>
                                <td>
                                    <asp:Button ID="btncancel" runat="server" Text="Cancel/Reset" />
                                    <cc1:ConfirmButtonExtender ID="btncancel_ConfirmButtonExtender" runat="server" 
                                        ConfirmOnFormSubmit="True" 
                                        ConfirmText="Are you sure you want to CANCEL/RESET this form?" Enabled="True" 
                                        TargetControlID="btncancel">
                                    </cc1:ConfirmButtonExtender>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style39" style="width: 113px">
                                    &nbsp;</td>
                                <td align="right" class="style41">
                                    &nbsp;</td>
                                <td class="style22">
                                    &nbsp;</td>
                                <td align="center" class="style40" style="width: 173px">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>

                  </asp:Panel>
                    <asp:Panel ID="Panel4" runat="server">
                   
            
                  
                  <center >
                   <asp:UpdateProgress ID="updProgress" runat="server" 
                                 AssociatedUpdatePanelID="UpdatePanel1">
                                 <ProgressTemplate>

                                 <div  > 
                                     <img alt="progress"  height="50px"  width="50px" src="images/sa/glossy-3d-blue-hourglass-icon.png" /> </div>
                                 <div   style="font-family: calibri; font-size: small; color : red" >System 
                                     Processing your request please wait...</div>  
                                   
                                 </ProgressTemplate>
                             </asp:UpdateProgress>
                    </center>
                  
             </asp:Panel>

                   <asp:Panel ID="Panel3" runat="server" BackColor ="Gainsboro" >
                       <table style="width:100%;" cellspacing="1" cellpadding="0">

                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td style="background-color:#99A6B4" colspan="5" >
                                    <div class="item_title">&nbsp;&nbsp;&nbsp;REGISTERED INSTRUMENTS (<asp:Label 
                                            ID="lblTotal" runat="server" Visible="False"></asp:Label>
                                        )&nbsp;&nbsp; </div>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td style="background-color:#99A6B4" colspan="5">
                                    <asp:Button ID="BTNPAY" runat="server" Text="MAKE PAYMENT" />
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style38">
                                    </td>
                                <td class="style33" align="center" colspan="5" rowspan="2">
                                    <asp:GridView ID="grd" runat="server" AllowPaging="True" BackColor="White" 
                                        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="2" 
                                        CellSpacing="2" EmptyDataText="NO REGISTERED INSTRUMENT" 
                                        EnableModelValidation="True" Font-Names="Calibri" Font-Size="Small" 
                                        GridLines="Vertical" ShowFooter="True" Width="100%" PageSize="20">
                                        <AlternatingRowStyle BackColor="#DCDCDC" />
                                        <Columns>
                                            <asp:CommandField HeaderText="Select" SelectText="Edit" 
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
                                <td class="style38">
                                    </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style5">
                                    &nbsp;</td>
                                <td class="style23">
                                    &nbsp;</td>
                                <td class="style22">
                                    &nbsp;</td>
                                <td class="style8">
                                    &nbsp;</td>
                                <td class="style31">
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


    </div>

     </center>
</div>

        
</div>
    
</asp:Content>
 