<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="WMDPortal._default6"   %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Weight & Measures : Registration Form</title>
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
                                    <li><asp:Button ID="ProfileIcon" UseSubmitBehavior ="false" runat ="server"  style="background:url(../images/account.png) no-repeat 2px 10px scroll; background-size :18px 20px;" class="icon" Text ="PROFILE" /></li>
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
                        <li><asp:button ID="InvoiceIcon" UseSubmitBehavior ="false"  runat ="server" style="background:url(../images/invoice.png) no-repeat 5px 10px scroll rgb(12, 76, 112); background-size :20px 20px; "  class="icon" Text ="Billing" /></li>
                        <li><asp:button ID="DepositIcon" UseSubmitBehavior ="false" runat ="server" style="background:url(../images/deposit.png) no-repeat 5px 10px scroll rgb(12, 76, 112); background-size :20px 20px; " class="icon" Text ="e-Wallet" /></li>
                        <li><asp:button ID="UploadIcon" UseSubmitBehavior ="false" runat ="server" style="background:url(../images/upload.png) no-repeat 5px 10px scroll rgb(12, 76, 112); background-size :20px 20px; " class="icon" Text ="Upload" /></li>
                        <li><asp:button ID="InstrumentServicesicon" UseSubmitBehavior ="false" runat ="server" style="background:url(../images/instruments.png) no-repeat 5px 10px scroll rgb(12, 76, 112); background-size :20px 20px; " class="icon" Text ="Instrument Certification" /></li>
                        <li><asp:button ID="RegisterInstrumentIcon" UseSubmitBehavior ="false" runat ="server" style="background:url(../images/register-instrument.png) no-repeat 5px 10px scroll rgb(12, 76, 112); background-size :20px 20px; " class="icon" Text ="Register Instrument" /></li>
                        <li><asp:button ID="ExportReturnIcon" UseSubmitBehavior ="false" runat ="server" style="background:url(../images/import-export.png) no-repeat 5px 10px scroll rgb(12, 76, 112); background-size :20px 20px; " class="icon" Text ="Export Return" /></li>
                    
                        <li><a style="background:url(../images/import-export.png) no-repeat 5px 10px scroll; background-size :20px 20px; " class="icon">Export Permit</a>
                            <ul>
                              <li><asp:button ID="ExportPermitIcon" UseSubmitBehavior ="false" runat ="server" style="background:url(../images/import-export.png) no-repeat 5px 10px scroll; background-size :20px 20px; " class="icon" Text ="Export Permit Application"></asp:button></li>
                              <li><asp:button ID="RequirementIcon" UseSubmitBehavior ="false" runat ="server" style="background:url(../images/import-export.png) no-repeat 5px 10px scroll; background-size :20px 20px; " class="icon" Text ="Export Permit Requirements"></asp:button></li>

                            </ul>
                                  
		                </li>  
                    
                  
                        <li><asp:button ID="ReportIcon" UseSubmitBehavior ="false" runat ="server" style="background:url(../images/reporting.png) no-repeat 5px 10px scroll rgb(12, 76, 112); background-size :20px 20px; " class="icon" Text ="Records" /> </li>

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

            <div class="title">Company Registration</div>
            
            <div class="registration-section">
            <div class="registration-form">

                     
                    
                    <div class="registration-form-container">

                        <h3>COMPANY'S DETAILS</h3>
                    
                    <div class="form-group" style="float:left;">
                        <label for="UserType" >Select User Type:</label><span class="asterik-small">*</span>
                        <asp:DropDownList ID="UserType" runat="server" CssClass="select">
                            <asp:ListItem Selected="True" Text="---User Type ---" value="" ></asp:ListItem>
                            <asp:ListItem Text="User" Value="User"></asp:ListItem>
                            <asp:ListItem Text="WMD Inspector" Value="WMD Inspector"></asp:ListItem>
                            <asp:ListItem Text="CPI Inspector" Value="CPI Inspector"></asp:ListItem>
                            <asp:ListItem Text="Calibrator" Value="Calibrator"></asp:ListItem>
                            <asp:ListItem Text="Authorized Verifier" Value="Authorized Verifier"></asp:ListItem>

                        </asp:DropDownList>

                    </div>  
                         

                    <div class="form-group">
                        <label for="CompanyName" >Name of Company:</label><span class="asterik-small">*</span>
                        <asp:TextBox ID="CompanyName" runat="server" CssClass="input"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="PhoneNumber" >Phone Number: </label><span class="asterik-small">*</span>
                        <asp:TextBox ID="PhoneNumber" runat="server" CssClass="input"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="EmailAddress" >Email Address:</label><span class="asterik-small">*</span>
                        <asp:TextBox ID="EmailAddress" runat="server" CssClass="input"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="Website" >Website:</label>
                        <asp:TextBox ID="Website" runat="server" CssClass="input"></asp:TextBox>
                    </div>

                                            
                    <div class="form-group">
                        <label for="FaxNumber" >Fax Number:</label>
                        <asp:TextBox ID="FaxNumber" runat="server" CssClass="input"></asp:TextBox>
                    </div>

                              
                    <div class="form-group">
                        <label for="Representative" >Representative:</label><span class="asterik-small">*</span>
                        <asp:TextBox ID="Representative" runat="server" CssClass="input"></asp:TextBox>
                    </div> 

                              
                    <div class="form-group">
                        <label for="Mobile" >Mobile:</label><span class="asterik-small">*</span>
                        <asp:TextBox ID="Mobile" runat="server" CssClass="input"></asp:TextBox>
                    </div> 

                              
                    <div class="form-group">
                        <label for="RC Number" >RC Number:</label><span class="asterik-small">*</span>
                        <asp:TextBox ID="RCNumber" runat="server" CssClass="input"></asp:TextBox>
                    </div> 

                              
                    <div class="form-group" style=" margin-top:-5px;margin-right:0px;">
                        <label for="RegisteredAddress" >Registered Address:</label><span class="asterik-small">*</span>
                        <asp:TextBox ID="RegisteredAddress" TextMode ="MultiLine"  runat="server" CssClass="textarea"></asp:TextBox>
                    </div> 
                         
                              
                    <div class="form-group" style=" ">
                        <label for="POBox" >P.O. Box:</label>
                        <asp:TextBox ID="POBox" runat="server" CssClass="input"></asp:TextBox>
                    </div> 

                              
                    <div class="form-group" style=" ">
                        <label for="State" >State:</label><span class="asterik-small">*</span>
                        <asp:DropDownList ID="State" runat="server" CssClass="select" AutoPostBack ="true"  OnSelectedIndexChanged="State_SelectedIndexChanged"></asp:DropDownList>

                    </div>  
                         
                    <div class="form-group" style=" ">
                        <label for="LGA" >LGA:</label><span class="asterik-small">*</span>
                        <asp:DropDownList ID="LGA" runat="server" CssClass="select" AutoPostBack="true" OnSelectedIndexChanged ="LGA_SelectedIndexChanged"></asp:DropDownList>
                    </div> 
 
                   <div class="form-group" style="">
                        <label for="City" >City:</label><span class="asterik-small">*</span>
                        <asp:DropDownList ID="City" runat="server" CssClass="select"></asp:DropDownList>                    

                    </div> 
         
                    </div>

                            
                    <div class="registration-form-container">

                        <h3>COMPANY LOGIN CREDENTIAL (All fields are required)</h3>
                    <div class="form-group">
                        <label for="Username" >Username:</label><span class="asterik-small">*</span><span class="asterik-small" style="float:none;font-size:10px;">(Maximum Character lenght = 10)</span>
                        <asp:TextBox ID="Username" runat="server" MaxLength="10" CssClass="input"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="Passsword" >Password: </label><span class="asterik-small">*</span><span class="asterik-small" style="float:none;font-size:10px;">(Minimum Character lenght = 8)</span>
                        <asp:TextBox ID="Password" runat="server" TextMode ="Password"  CssClass="input" ToolTip="Alphanumeric (A - Z, a - z, 0 - 9) and Special Characters (. , ! @ # $ % ^ * ( ) { } [ ] | : ? / | \) is strongly advised for maximum protection!"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="ConfirmPassword" >Confirm Password:</label><span class="asterik-small">*</span>
                        <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"  CssClass="input"></asp:TextBox>
                    </div>

                    <div class="form-group" style="float :left;">
                        <label for="SecurityQuestion" >Security Question:</label><span class="asterik-small">*</span>
                        <asp:DropDownList ID="SecurityQuestion" runat="server" CssClass="select">
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
                        <label for="SecurityAnswer" >Answer:</label><span class="asterik-small">*</span>
                        <asp:TextBox ID="SecurityAnswer" runat="server" CssClass="input"></asp:TextBox>
                    </div>
 
                         

                    </div>


                    <div class="registration-form-container">

                        <h3>FORM FILLED BY</h3>
                    <div class="form-group" style="float:left;">
                        <label for="Title" >Title:</label><span class="asterik-small">*</span>
                        <asp:DropDownList ID="FillerTitle" runat="server" CssClass="select">
                             
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
                        <label for="OtherNames" >Surname:</label><span class="asterik-small">*</span>
                        <asp:TextBox ID="Surname" runat="server" CssClass="input"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="OtherNames" >Other Names:</label><span class="asterik-small">*</span>
                        <asp:TextBox ID="OtherNames" runat="server" CssClass="input"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="FillerMobile" >Phone Number:</label><span class="asterik-small">*</span>
                        <asp:TextBox ID="FillerMobile" runat="server" CssClass="input"></asp:TextBox>
                    </div>

                         
                    <div class="form-group">
                        <label for="FillerEmail" >Email Address:</label><span class="asterik-small">*</span>
                        <asp:TextBox ID="FillerEmail" runat="server" CssClass="input"></asp:TextBox>
                    </div>

                     
                         
                    <div class="form-group" style="float:right;"> 
                        <!-- <asp:CheckBox ID="Certify" runat="server" CssClass="checkbox" Text="I hereby certify that the information above is true and accurate." Font-Size="XX-Small"/><!--<span class="checkbox"></span> -->  
                        <label for="FillerEmail" ></label> <p>
                        <asp:Button ID="Register" runat="server" Text="Register Company" onClientClick=" return confirm('Are you sure you want to submit this application?')"  class="mbtn" />
                        <asp:Button ID="ClearForm" runat="server" Text="Reset"  onClientClick=" return confirm('Are you sure you want reset this form? All your input will be lost!')"  class="mbtn"/>

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
