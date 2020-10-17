<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="WMDPortal._default9" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Weight & Measures : Profile</title>
    <meta name="author" content="Application Developed by: John Ojebode"/>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../css/menu.css" rel="stylesheet" type="text/css" />
    <link href="../images/icon.png" rel="icon" type="images/jpg" />

</head>
<body>
    <form id="RegistrationForm" runat ="server">
    <!-- This is header -->
    <asp:Panel ID="HeaderPanel" runat ="server"  CssClass ="headers">

        <div class="header">
            <div class="logo"></div>
            <div class="header-right">
            
                
            <div class="half-top"> 
                <h3 style="text-align:center; font-size:20px;margin-top:-10px;">Federal Ministry of Industry, Trade and Investment<br /> 
                    <span style="font-size:15px;">Weights and Measures Department</span></h3>
                 
                     <nav class="nav">
                        <ul>
                           
                            <li style="background-image:url(../images/account.png), url(../images/arrow-down.png);background-position:2px 9px, 100% 53% ;background-repeat:no-repeat; background-size:18px 20px, 7px 5px" class="sub"><a >
                            <asp:Button ID="Account" runat="server"  UseSubmitBehavior ="false"  CssClass="button-label" style="margin-right:0px;" Text="ACCOUNT" /></a>
                                <ul>
                                    <li><asp:Button ID="ProfileIco" UseSubmitBehavior ="false" runat ="server"  style="background:url(../images/account.png) no-repeat 2px 10px scroll; background-size :18px 20px;" class="icon" Text ="PROFILE" /></li>
                                    <li><asp:button ID="Logout" UseSubmitBehavior ="false" runat ="server"  style="background:url(../images/login.png) no-repeat 2px 10px scroll; background-size :18px 20px;" CssClass="icon"  Text ="LOGIN"></asp:button></li>
                                </ul>

                            </li>
 
                            <li><asp:Panel ID="RegistrationPanel" runat="server" style="background:url(../images/register.png);background-position:2px 9px;background-repeat:no-repeat;background-size:18px 20px;float:right">
                               <asp:Button  ID="Registration" UseSubmitBehavior ="false"  runat="server" CssClass ="button-label" Text="REGISTER" />
                            </asp:Panel></li>

                            <li style="background-image:url(../images/faq-icon.png);background-position:2px 10px;background-repeat:no-repeat; background-size:20px 20px;float:right;margin-right:10px;font-weight:normal;"><a href="faqs/" class="button-label" style="width:40px;">FAQs</a></li>  
                            
                        </ul>

                  </nav>
                
            </div>
            
                
            <div class="half-down"> 

               

                <nav>
                    <ul>
                        <li class="active"><a href="../"><span>HOME </span></a></li>   
                        <li><a href="../about/"><span>ABOUT US</span></a></li>
                        <li><a href="../permit-tracking"><span>PERMIT TRACKING</span></a></li>
                        <li><a href="../gallery/"><span>PHOTO GALLERY</span></a></li>
                        <li><a href="../article/"><span>NEWS</span></a></li>
                        <li><a href="../download/"><span>DOWNLOAD</span></a></li>
                        <li><a href="#"><span>CONTACT US</span></a>
                            <ul style="right:10px;text-align:right;">
                              <li><a href="../contact/wmd/">Weights & Measures Department</a></li>
                              <li><a href="../contact/cpi/">Commodity & Prod. Inspectorate Dept.</a></li>
                              <li><a href="../contact/finance/">Finance & Account Department</a></li>
                              <li><a href="../contact/nigerco/">Nigerco Nigeria Ltd. (Consultant)</a></li>
                            </ul>
                        </li>
                    </ul>
                </nav>

            </div>

               <asp:Panel ID="ToolBar" runat ="server"  class="tools-bar">
                <nav>
                    <ul class="inner" style="margin-top:-2px;">
                        <li class="active"><asp:button ID="ProfileIcon" UseSubmitBehavior ="false"  runat ="server" style="background:url(../images/profile.png) no-repeat 5px 10px scroll; background-size :20px 20px; " class="icon" Text ="Profile" /></li>
                        <li><asp:button ID="InvoiceIcon" UseSubmitBehavior ="false"  runat ="server" style="background:url(../images/invoice.png) no-repeat 5px 10px scroll; background-size :20px 20px; "  class="icon" Text ="Billing" /></li>
                        <li><asp:button ID="DepositIcon" UseSubmitBehavior ="false" runat ="server" style="background:url(../images/deposit.png) no-repeat 5px 10px scroll; background-size :20px 20px; " class="icon" Text ="e-Wallet" /></li>
                        <li><asp:button ID="UploadIcon" UseSubmitBehavior ="false" runat ="server" style="background:url(../images/upload.png) no-repeat 5px 10px scroll; background-size :20px 20px; " class="icon" Text ="Upload" /></li>
                        <li><asp:button ID="InstrumentServicesicon" UseSubmitBehavior ="false" runat ="server" style="background:url(../images/instruments.png) no-repeat 5px 10px scroll; background-size :20px 20px; " class="icon" Text ="Instrument Certification" /></li>
                        <li><asp:button ID="RegisterInstrumentIcon" UseSubmitBehavior ="false" runat ="server" style="background:url(../images/register-instrument.png) no-repeat 5px 10px scroll; background-size :20px 20px; " class="icon" Text ="Register Instrument" /></li>
                        <li><asp:button ID="ExportReturnIcon" UseSubmitBehavior ="false" runat ="server" style="background:url(../images/import-export.png) no-repeat 5px 10px scroll; background-size :20px 20px; " class="icon" Text ="Export Return" /></li>
                    
                        <li><a style="background:url(../images/import-export.png) no-repeat 5px 10px scroll; background-size :20px 20px; " class="icon">Export Permit</a>
                            <ul>
                              <li><asp:button ID="ExportPermitIcon" UseSubmitBehavior ="false" runat ="server" style="background:url(../images/import-export.png) no-repeat 5px 10px scroll; background-size :20px 20px; " class="icon" Text ="Export Permit Application"></asp:button></li>
                              <li><asp:button ID="RequirementIcon" UseSubmitBehavior ="false" runat ="server" style="background:url(../images/import-export.png) no-repeat 5px 10px scroll; background-size :20px 20px; " class="icon" Text ="Export Permit Requirements"></asp:button></li>

                            </ul>
                                  
		                </li>  
                    
                  
                        <li><asp:button ID="ReportIcon" UseSubmitBehavior ="false" runat ="server" style="background:url(../images/reporting.png) no-repeat 5px 10px scroll; background-size :20px 20px; " class="icon" Text ="Records" /> </li>

                    </ul>
                </nav>
            </asp:Panel>

                      
            <asp:Panel ID="WMDInspectorTools" runat ="server"  class="tools-bar">
                <nav>
                    <ul class="inner" style="margin-top:-2px;">
                        <li><asp:button ID="Inspection" UseSubmitBehavior ="false"  runat ="server" style="background:url(../../images/inspection.png) no-repeat 5px 10px scroll; background-size :20px 20px; " class="icon" Text ="Inspection" /></li>
                        <li><asp:button ID="VerificationBill" UseSubmitBehavior ="false" runat ="server" style="background:url(../../images/verification.png) no-repeat 5px 10px scroll; background-size :20px 20px; " class="icon" Text ="Verification Bill" /></li>
                        <li><asp:button ID="Enforcement" UseSubmitBehavior ="false" runat ="server" style="background:url(../../images/enforcement.png) no-repeat 5px 10px scroll; background-size :20px 20px; " class="icon" Text ="Enforcement" /></li>
                        <li class="active"><asp:button ID="Instruments" UseSubmitBehavior ="false" runat ="server" style="background:url(../../images/instruments.png) no-repeat 5px 10px scroll rgb(200,200,200); background-size :20px 20px; " class="icon" Text ="Instruments" /> </li>

                    </ul>
                </nav>
            </asp:Panel>

            </div>


        </div>
    </asp:Panel>

    <div class="content">

            <div class="title">User Profile<asp:Label  runat ="server" ID="ProfileName" Text="" /></div>
            
            <div class="registration-section">
            <div class="registration-form">

               
                
                    
                    <div class="registration-form-container">

                        <h3>COMPANY LOGIN CREDENTIAL (All fields are required)</h3>
                    <div class="form-group" style="float:left;">
                        <label for="Username" >Username:</label> 
                        <asp:TextBox ID="Username" Enabled ="false"  runat="server" CssClass="input-flat"></asp:TextBox>
                    </div>

                    <div class="form-group" style="float:left;">
                        <label for="SecurityQuestion" >Security Question:</label>
                        <asp:DropDownList ID="SecurityQuestion" runat="server" CssClass="select-flat">
                            <asp:ListItem Selected="True" Text="---Select Question---" value="" ></asp:ListItem>
                            <asp:ListItem Text="Company's Birthday" Value="Company Birthday"></asp:ListItem>
                            <asp:ListItem Text="CEO's Middlename" Value="CEO Middlename"></asp:ListItem>
                            <asp:ListItem Text="First MD" Value="First MD"></asp:ListItem>
                            <asp:ListItem Text="First Office Address" Value="First Office Address"></asp:ListItem>
                            <asp:ListItem Text="First Project" Value="First Project"></asp:ListItem>
                            <asp:ListItem Text="REG Number" value="REG Number"  ></asp:ListItem>

 
                        </asp:DropDownList>

                     </div>

                         
                    <div class="form-group">
                        <label for="SecurityAnswer" >Answer:</label> 
                        <asp:TextBox ID="SecurityAnswer" runat="server" CssClass="input-flat"></asp:TextBox>
                    </div>
 
                         

                    </div>

                <div class="registration-form-container">

                        <h3>CHANGE PASSWORD</h3>
                    
                    <div class="form-group">
                        <label for="Passsword" >Old Password: </label> 
                        <asp:TextBox ID="OldPassword" runat="server" TextMode ="Password"  CssClass="input-flat-password"></asp:TextBox>
                    </div>

                   <div class="form-group">
                        <label for="Passsword" >New Password: </label> 
                        <asp:TextBox ID="NewPassword" runat="server" TextMode ="Password"  CssClass="input-flat-password"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="ConfirmPassword" >Confirm Password:</label> 
                        <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"  CssClass="input-flat-password"></asp:TextBox>
                    </div>

                </div>
                    
                    <div class="registration-form-container">

                        <h3>COMPANY'S DETAILS</h3>
                    <div class="form-group">
                        <label for="CompanyName" >Name of Company:</label> 
                        <asp:TextBox ID="CompanyName" runat="server" CssClass="input-flat"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="PhoneNumber" >Phone Number: </label> 
                        <asp:TextBox ID="PhoneNumber" runat="server" CssClass="input-flat"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="EmailAddress" >Email Address:</label> 
                        <asp:TextBox ID="EmailAddress" runat="server" CssClass="input-flat"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="Website" >Website:</label> 
                        <asp:TextBox ID="Website" runat="server" CssClass="input-flat"></asp:TextBox>
                    </div>

                                            
                    <div class="form-group">
                        <label for="FaxNumber" >Fax Number:</label> 
                        <asp:TextBox ID="FaxNumber" runat="server" CssClass="input-flat"></asp:TextBox>
                    </div>

                              
                    <div class="form-group">
                        <label for="Representative" >Representative:</label> 
                        <asp:TextBox ID="Representative" runat="server" CssClass="input-flat"></asp:TextBox>
                    </div> 

                              
                    <div class="form-group">
                        <label for="Mobile" >Mobile:</label> 
                        <asp:TextBox ID="Mobile" runat="server" CssClass="input-flat"></asp:TextBox>
                    </div> 

                              
                    <div class="form-group">
                        <label for="RC Number" >RC Number:</label> 
                        <asp:TextBox ID="RCNumber" runat="server" CssClass="input-flat"></asp:TextBox>
                    </div> 

                              
                    <div class="form-group" style="float:right ;height:50px">
                        <label for="RegisteredAddress" >Registered Address:</label> 
                        <asp:TextBox ID="RegisteredAddress" TextMode ="MultiLine"  runat="server" CssClass="textarea"></asp:TextBox>
                    </div> 
                         
                              
                    <div class="form-group" style="float:left;">
                        <label for="POBox" >P.O. Box:</label> 
                        <asp:TextBox ID="POBox" runat="server" CssClass="input-flat"></asp:TextBox>
                    </div> 

                              
                    <div class="form-group" style="float:left;" >
                        <label for="State" >State:</label> 
                        <asp:DropDownList ID="State" runat="server" CssClass="select-flat" AutoPostBack ="true"  OnSelectedIndexChanged="State_SelectedIndexChanged"></asp:DropDownList>

                    </div>  

                    <div class="form-group" style="float:right;">
                        <label for="LGA" >LGA:</label> 
                        <asp:DropDownList ID="LGA" runat="server" CssClass="select-flat" AutoPostBack="true" OnSelectedIndexChanged ="LGA_SelectedIndexChanged"></asp:DropDownList>
                    </div> 
                    
                    <datalist id="CityiesData" >
                       

                    </datalist>

                    <div class="form-group">
                        <label for="City" >City:</label> 
                        <asp:DropDownList ID="City" runat="server" CssClass="select-flat"></asp:DropDownList>                    </div> 
         
                    </div>


                    <div class="registration-form-container">

                        <h3>FORM FILLED BY</h3>
                    <div class="form-group" style="float:left;">
                        <label for="Title" >Title:</label>
                        <asp:DropDownList ID="FillerTitle" runat="server" CssClass="select-flat">
                             
                            <asp:ListItem value="---Select Title---" selected="true"></asp:ListItem>
                            <asp:ListItem Text="Mr" value="Mr"></asp:ListItem>
                            <asp:ListItem Text="Mrs" value="Mrs"></asp:ListItem>
                            <asp:ListItem Text="Ms" value="Ms"></asp:ListItem>
                            <asp:ListItem Text="Miss" value="Miss"></asp:ListItem>
                            <asp:ListItem Text="Dr" value="Dr"></asp:ListItem>
                            <asp:ListItem Text="Barister" value="Barister"></asp:ListItem>
                            <asp:ListItem Text="Alhaji" value="Alhaji"></asp:ListItem>
                            <asp:ListItem Text="Hajia" value="Hajia"></asp:ListItem>
                            <asp:ListItem Text="Malam" value="Malam"></asp:ListItem>
                            <asp:ListItem Text="Evang" value="Evang"></asp:ListItem>
                            <asp:ListItem Text="Prohpet" value="Prohpet"></asp:ListItem>
                            <asp:ListItem Text="Bishop" value="Bishop"></asp:ListItem>
                            <asp:ListItem Text="Pastor" value="Pastor"></asp:ListItem>
                            
                        </asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <label for="Surname" >Surname: </label> 
                        <asp:TextBox ID="Surname" runat="server" CssClass="input-flat"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="OtherNames" >Other Names:</label> 
                        <asp:TextBox ID="OtherNames" runat="server" CssClass="input-flat"></asp:TextBox>
                    </div>
                        <p></p>
                    <div class="form-group">
                        <label for="FillerMobile" >Phone Number:</label> 
                        <asp:TextBox ID="FillerMobile" runat="server" CssClass="input-flat"></asp:TextBox>
                    </div>

                         
                    <div class="form-group">
                        <label for="FillerEmail" >Email Address:</label> 
                        <asp:TextBox ID="FillerEmail" runat="server" CssClass="input-flat"></asp:TextBox>
                    </div>

                     
                         
                    <div class="form-group" style="float:right;">
                        <!-- <asp:CheckBox ID="Certify" runat="server" CssClass="checkbox" Text="I hereby certify that the information above is true and accurate." Font-Size="XX-Small"/><!--<span class="checkbox"></span> -->  
                        <label for="FillerEmail" ></label> <br />
                        <asp:Button ID="Register" runat="server" Text="Update Info" onClientClick=" return confirm('Are you sure you want to submit application?')"  class="pay-button-save" />
                        <asp:Button ID="ClearForm" runat="server" Text="Reset"  onClientClick=" return confirm('Are you sure you want reset form?')"  class="mbtn-close" style="padding-top:5px;padding-bottom:8px;"/>
                    </div>

                     

                    </div>




                     <div class="registration-form-container" style="border-bottom:0px; width:50%; margin:0 auto;">
                        
                        
                    </div>
                

            </div>
                 
        
            
        </div>
        </div>
       
         



    <div class="partner-section" >
        <div class="partner-section-inner-box" >
          
        </div>

    </div>
    <!--
    <div class="other-section">
        <div class="inner-box">
            <div class="title">Other Section</div>
        </div>
    </div>

    -->
    <footer>        
        <div class="footer">
            
           <div class="footer-divider"> 
                <div class="title">NAVIGATE QUICKLY</div>
                <div class="footer-link"><a href="../about/">Know Who we Are</a></div>
                <div class="footer-link"><a href="../gallery/">View Photo Gallery</a></div>
                <div class="footer-link"><a href="../article/">Read News / Articles</a></div>
                <div class="footer-link"><a href="../download/">Download Files</a></div>
                <div class="footer-link"><a href="../faqs/">Frequently Ask Questions</a></div>
                

            </div>
            <div class="footer-divider"> 
                <div class="title">REGULATIONS </div>
                <div class="footer-link"><a href="../File Manager/DownloadCenter/Official_Gazette_No.24.pdf" target ="_blank">Official Gazette No. 24</a></div>
                <div class="footer-link"><a href="../File Manager/DownloadCenter/Official_Gazette_No.25.pdf" target ="_blank">Official Gazette No. 25</a></div>
                <div class="footer-link"><a href="../File Manager/DownloadCenter/Official_Pre-Shipment_Act.pdf" target ="_blank">Official Pre-Shipment Act</a></div>
                <div class="footer-link"><a href="../File Manager/DownloadCenter/Weight_and_Measure_Act.pdf" target ="_blank">Weights and Measures Act</a></div>
                <div class="footer-link"><a href="../File Manager/DownloadCenter/WMD_Calibration_Guideline.pdf" target ="_blank">Guideline for Calibrators</a></div>

            </div>
            <div class="footer-divider"> 
                <div class="title">OTHER GOVT. AGENCIES</div>
                <div class="footer-link"><a href="http://www.son.gov.ng/" target ="_blank" >Standard Organisation of Nigeria</a></div>
                <div class="footer-link"><a href="http://www.cpc.gov.ng/" target ="_blank" >Consumer Protection Council</a></div>
                <div class="footer-link"><a href="http://www.finance.gov.ng/" target ="_blank" >Federal Ministry of Finance</a></div>
                <div class="footer-link"><a href="http://www.nipc.gov.ng/" target ="_blank" >Nigerian Invest. Promotion Comm.</a></div>
                <div class="footer-link"><a href="http://www.dpr.gov.ng/" target ="_blank" >Dept. of Petroleum Resources</a></div>

            </div>

            <div class="footer-divider"> 
                <div class="title">LEGAL METROLOGY</div>
                <p style="color:#49bbf5">What is Legal Metrology?</p>
                <p>Metrology is the science of measurement.
Legal Metrology provides regulations for the control of the measurements and mearuring instruments. Legal metrology also provides protection of public safety.</p>

            </div>

       </div>

    </footer>

    <div class="copyright">
        <div class="copy">
            <div class="copyright-text">Copyright &copy; 2013 - <%# String.Format("{0}", Today.Year )%>. All rights reserved. Powered by <a href="http://www.nnlnigeria.com">Nigerco Nigeria Ltd.</a></div>
            <div class="social">
                <div class="social-img" style="background:url(../images/facebook.png) no-repeat; background-size:cover;" title="Like our Facebook Page"> </div>
                <div class="social-img" style="background:url(../images/twitter.png) no-repeat; background-size:cover;" title="Join our Twitter Conversation"> </div>
                <div class="social-img" style="height:20px; width: 20px; margin-top:2px; background:url(../images/youtube.png) no-repeat; background-size:20px 20px;"  title="Our Youtube Channel"> </div>
                <div class="social-img" style="background:url(../images/linkedin.png) no-repeat; background-size:cover;"  title="Connect with us on Linkedin"> </div>
                <div class="social-img" style="background:url(../images/cont.png) no-repeat; background-size:cover;"  title="Contact Us"> </div>
            </div>

        </div>
    </div>

</form>

</body>
</html>
