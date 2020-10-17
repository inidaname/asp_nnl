<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="WMDPortal._default16" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Weight & Measures : Requirements</title>
    <meta name="author" content="Application Developed by: John Ojebode"/>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../css/menu.css" rel="stylesheet" type="text/css" />
    <link href="../images/icon.png" rel="icon" type="images/jpg" />
    <script src ="../js/jQuery.js" type ="text/javascript" ></script>
    <script src ="../js/tabScript.js" type ="text/javascript" ></script>
    
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
                        <li><a href="../"><span>HOME </span></a></li>   
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
                    
                        <li class="active"><a style="background:url(../images/import-export.png) no-repeat 5px 10px scroll; background-size :20px 20px; " class="icon">Export Permit</a>
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
        <asp:Panel ID="DepositPanel" runat ="server" CssClass ="content-container">

           
            <div class="title-bar">
                   <span class ="left"> GUIDELINES FOR THE EXPORTATION OF OIL AND GAS AND OTHER PETROLEUM PRODUCTS FROM NIGERIA</span>

                    
            </div>


            
            <div class ="general-form">

           <h3 style="font-size:14px;">FEDERAL  MINISTRY OF INDUSTRY, TRADE AND INVESTMENT COMMODITIES AND PRODUCTS INSPECTORATE DEPARTMENT (CPI)</h3>
 
                <span style="font-size:14px;font-family:Tahoma;text-align:justify;color:#000;">
                <p><span style="font-weight:bolder;color:#000"> A. ELIGIBILITY</span></p>
                The following categories of companies may apply for PERMIT to Export Crude Oil, Liquefied Natural Gas, Liquefied Petroleum Gas, Condensate, Refined Products, Lubricants, Grease, etc.

                <ul style="list-style :lower-roman ">
	                <li>Nigerian National Petroleum Corporation (NNPC)</li>
	                <li>International Oil Companies (IOCs)</li>
	                <li>Pipelines and Products Marketing Company (PPMC) Ltd</li>
	                <li>Indigenous  Oil Producing Companies</li>
	                <li>Major Oil and Gas Marketing Companies</li>
	                <li>Independent Petroleum Marketing Companies (IPMAN or DAPPMA Companies) with current DPR license for receptacles/Storage facilities (i.e. jetties/depots)</li>
                 </ul>
 
                <p><span style="font-weight:bolder;color:#000"> B. CONDITIONS FOR EXPORTATION OF OIL AND GAS AND OTHER PETROLEUM PRODUCTS</span> </p> 
                <ul style="list-style :lower-roman ">
	                <li>Application for Export Clearance Permit made on company's letter headed paper.</li>
	                <li>Duly completed Application Form E001 attached with a copy of:</li>
		                <ul  style="list-style:lower-alpha ">
			                <li>Certificate of Incorporation of the applicant's company.</li>
			                <li>Company Article and Memorandum of Association</li>
			                <li>Current Production/Storage/Sales license issued by DPR.</li>
			                <li>Current Weights and Measures Department certificate of conformity for the Fiscal Meters, Gauges, and all Custody Transfer Weighing & Measuring instruments at the terminal(s) to be used for the export.</li>
			                <li>Original Bank reference with committed and explicit statements</li>
			                <li>3-Years Tax Clearance Certificate</li>
			                <li>Approved Application fee of …………. shall be charged per cargo/permit. All fees shall be in Bank Drafts and made payable to the Commodities Department <strong>(FMITI FEES Account)</strong>. Bank Drafts written “FGN” shall not be honoured. A CPI service charge of …………… per application shall be charged and made payable to <strong>Commodities and Products Inspectorate Department.</strong> </li>
		                </ul>
                </ul>


                <ul style="list-style :lower-roman ">
	                <li>Every export Permit shall have duration of 90 days from the date of issue.</li>
	                <li>Each exporter of Oil and Gas shall be required to complete <strong>Form DV001 </strong> on the previous EXPORTATION for which permit was granted, along with copies of all relevant invoices and shipping documents, before any subsequent application for an Export Permit can be approved. Such documents shall include:- </li>
		                <ul style="list-style :lower-alpha ">
			                <li>Relevant Invoices</li>
			                <li>Bill of Lading</li>
			                <li>Photocopy of Approved Form</li>
			                <li>Clean Certificate of Inspection (CCI) issued by Government appointed Pre-shipment Inspection Agent</li>
			                <li>Clearance or Export duty payment from Nigeria Customs & Excise</li>
			                <li>Detail cargo information, such as direct shipment, ship to ship, name of mother vessel, certificate of quality, last port of call etc.</li>
			                <li>For every new application for a Permit, a stamped copy of the last Permit granted to the company must be surrendered to the <strong> Commodities and Products Inspectorate Department.</strong></li>
		                </ul>
                </ul>
                <span style="font-weight :bolder;color:#000;">
                November 2011<br />
                FEDERAL MINISTRY OF INDUSTRY, TRADE AND INVESTMENT
                 </span>               
                </span>
            </div> 

            </asp:Panel>

        
             
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
