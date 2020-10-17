<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/adminpage.master" EnableEventValidation="false"  CodeFile="admincregistration.aspx.vb" Inherits="_Default"  %>

<%@ Import Namespace="System.Data" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>

<div id="item1">
	 
    	<div class="item_title">&nbsp;&nbsp;&nbsp; REGISTRATION FORM WM002</div>
    	<div>
	                         <br /><br /><br />
                       
	                         <center >
        	                    <img src="images/coatofarm.jpg" />
        	                    <br />
                               <h1> <strong > FEDERAL MINISTRY OF INDUSTRY,TRADE AND INVESTMENT</strong></h1><br />
                                 <h3>  WEIGHTS AND MEASURES DEPARTMENT</h3> 
                                    <br />
                                   <h3> Old Secretariat Area I, Garki Abuja</h3>
                                   <br />
                                 <strong >   Weighing and Measuring Instrument Used for Trade or Official Purpose </strong>
        	
                            </center> 	
                            <hr />
     
  
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
                                    <div class="item_title">&nbsp;&nbsp;&nbsp;WMD STATE OFFICE LOGIN CREDENTIALS(All Fields Are Required)</div>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Username:"></asp:Label><font style="color:#F00">*</font>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtuser" runat="server" ToolTip="enter username" 
                                        ValidationGroup="username|Invalid Username" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="lblsecurityquestion" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Security Question:"></asp:Label><font style="color:#F00">*</font>
                                </td>
                                <td>
                                    <asp:DropDownList ID="cbosQuestion" runat="server" 
                                        ToolTip="select security question" 
                                        ValidationGroup="securityQuestions|Please select security questions" 
                                        Width="204px">
                                    
                                        <asp:ListItem Selected="True">Select Question</asp:ListItem>
                                        <asp:ListItem>Company&#39;S Birthday</asp:ListItem>
                                        <asp:ListItem>CEO&#39;S Middlename</asp:ListItem>
                                        <asp:ListItem>First MD</asp:ListItem>
                                        <asp:ListItem>First Office Address</asp:ListItem>
                                        <asp:ListItem>First Project</asp:ListItem>
                                        <asp:ListItem>REG Number</asp:ListItem>
                                    
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Password:"></asp:Label><font style="color:#F00">*</font>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtpwd" runat="server" TextMode="Password" 
                                        ToolTip="enter password" ValidationGroup="pwd" CausesValidation="false" 
                                        Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label7" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Answer:"></asp:Label><font style="color:#F00">*</font>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAsnwer" runat="server" 
                                        ToolTip="enter answer to your security question" 
                                        ValidationGroup="securityAnswer|Invalid Answer" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label24" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Confirm password:"></asp:Label><font style="color:#F00">*</font>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtpwdR" runat="server" TextMode="Password" CausesValidation ="false"  
                                        ToolTip="Confirm password" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtstatus" runat="server" CausesValidation="false" 
                                        ToolTip="retype password entered" ValidationGroup="companyregtype" 
                                        Visible="False" Width="51px"></asp:TextBox>
                                    <asp:TextBox ID="txtTranscode" runat="server" CausesValidation="false" 
                                        ToolTip="retype password entered" ValidationGroup="transcode" Visible="False" 
                                        Width="51px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td colspan="5">
                                    <div class="item_title">
                                        &nbsp;&nbsp;&nbsp;WMD STATE OFFICE'S DETAILS</div>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label8" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Name Of State:"></asp:Label><font style="color:#F00">*</font>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtcompany" runat="server" ToolTip="enter company name" 
                                        ValidationGroup="companyName|Invalid Company Name" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label15" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Telephone:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtusername7" runat="server" ToolTip="enter telephone number" 
                                        ValidationGroup="telephone" Width="204px"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtusername7_FilteredTextBoxExtender" 
                                        runat="server" Enabled="True" TargetControlID="txtusername7" 
                                        ValidChars="1234567890,+">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label25" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="State Code:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtcompany0" runat="server" 
                                        ToolTip="enter company registration number" 
                                        ValidationGroup="RCNumber" Width="204px"></asp:TextBox>
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
                                    <asp:Label ID="Label9" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Address:"></asp:Label><font style="color:#F00">*</font>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtusername12" runat="server" 
                                        ToolTip="enter company's address" 
                                        ValidationGroup="streetAddress|Invalid company address" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label19" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Email:"></asp:Label><font style="color:#F00">*</font>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtcompanyemail" runat="server" 
                                        ValidationGroup="companyEmail|Invalid company email address" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label10" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="P.O. Box:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtusername2" runat="server" ToolTip="enter company's P.O.Box" 
                                        ValidationGroup="POBOX" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label14" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Website:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtusername6" runat="server" ToolTip="enter company website" 
                                        ValidationGroup="companywebsite" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label11" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="State:"></asp:Label><font style="color:#F00">*</font>
                                </td>
                                <td>
                                
                                    <asp:DropDownList ID="cboState" runat="server" 
                                        AutoPostBack="True" ToolTip="select copany's state" 
                                        ValidationGroup="StateID|Invalid State|1" Width="204px">
                                    </asp:DropDownList>
                                  
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label18" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Fax Number:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtusername10" runat="server" 
                                        ToolTip="enter company fax number" 
                                        ValidationGroup="faxNumber" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label12" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="LGA:"></asp:Label><font style="color:#F00">*</font>
                                </td>
                                <td>
                                    <asp:DropDownList ID="cboLGA" runat="server" 
                                        ToolTip="enter company's LGA" ValidationGroup="LGAID|Invalid LGA|2" 
                                        Width="204px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label16" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Officer in Charge Of State:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtusername8" runat="server" 
                                        ToolTip="enter company representative fullname" 
                                        ValidationGroup="representativeName" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label13" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="City:"></asp:Label><font style="color:#F00">*</font>
                                </td>
                                <td>
                                    <asp:DropDownList ID="cboCity" runat="server" 
                                        ToolTip="enter company's city" ValidationGroup="cityID|Invalid City|3" 
                                        Width="204px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label17" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Mobile:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtusername9" runat="server" 
                                        ToolTip="enter company rep mobile" 
                                        ValidationGroup="mobilephone" Width="204px"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtusername9_FilteredTextBoxExtender" 
                                        runat="server" Enabled="True" TargetControlID="txtusername9" 
                                        ValidChars="1234567890,+">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
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
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td colspan="5">
                                    <div class="item_title">
                                        &nbsp;&nbsp;&nbsp;FORM FILLED BY</div>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label20" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Title:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="cbosTitle" runat="server" 
                                        ToolTip="select title" 
                                        ValidationGroup="filledByTitle" Width="204px">
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
                                <td>
                                    <asp:Label ID="Label22" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Mobile:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txttelephone" runat="server" ToolTip="enter telephone number" 
                                        ValidationGroup="filledBytelephone" 
                                        Width="204px"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txttelephone_FilteredTextBoxExtender" 
                                        runat="server" Enabled="True" TargetControlID="txttelephone" 
                                        ValidChars="1234567890,+">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label21" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Fullname:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtfullname" runat="server" ToolTip="enter your fullname" 
                                        ValidationGroup="filledBy" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label23" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Email Address:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtemailaddress" runat="server" 
                                        ToolTip="enter your email address" 
                                        ValidationGroup="filledByemail" Width="204px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td colspan="5">
                                    <asp:Panel ID="Panel4" runat="server">
                                        <center>
                                            <asp:UpdateProgress ID="updProgress" runat="server" 
                                                AssociatedUpdatePanelID="UpdatePanel1">
                                                <ProgressTemplate>
                                                    <div>
                                                        <img alt="progress"  src="images/sa/glossy-3d-blue-hourglass-icon.png" />
                                                    </div>
                                                    <div style="font-family: calibri; font-size: small; color : red">
                                                        System Processing your request please wait...</div>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </center>
                                    </asp:Panel>
                                </td>
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
                                
                                    <asp:Button ID="btnReset" runat="server" Text="Reset" />
                                    <cc1:ConfirmButtonExtender ID="btnReset_ConfirmButtonExtender" runat="server" 
                                        ConfirmOnFormSubmit="True" 
                                        ConfirmText="Are you SURE you want to CLEAR this form" Enabled="True" 
                                        TargetControlID="btnReset">
                                    </cc1:ConfirmButtonExtender>
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnPreview" runat="server" Text="Submit" style="height: 26px" />
                                    <cc1:ConfirmButtonExtender ID="btnPreview_ConfirmButtonExtender" runat="server" 
                                        ConfirmOnFormSubmit="True" 
                                        ConfirmText="Are you SURE you want to SAVE this registration?" Enabled="True" 
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
    </div>
     </center>
</div>

        
</div>
    

</asp:Content>           