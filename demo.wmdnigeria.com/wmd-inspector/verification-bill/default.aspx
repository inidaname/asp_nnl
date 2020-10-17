<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="WMDPortal._default41" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Tools" %>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Weight & Measures : Requirements</title>
    <meta name="author" content="Application Developed by: John Ojebode"/>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../../css/menu.css" rel="stylesheet" type="text/css" />
    <link href="../../images/icon.png" rel="icon" type="images/jpg" />
    <script src ="../../js/jQuery.js" type ="text/javascript" ></script>
    <script src ="../../js/tabScript.js" type ="text/javascript" ></script>
    
    <link rel="stylesheet" href="../../js/jQuery-ui.css" />
    <script src="../../js/jQuery1.10.js"></script>
    <script src="../../js/jQuery-ui.js"></script>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    
</head>
<body>
    <form id="RegistrationForm" runat ="server">
       <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
         

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
                           
                            <li style="background-image:url(../../images/account.png), url(../../images/arrow-down.png);background-position:2px 9px, 100% 53% ;background-repeat:no-repeat; background-size:18px 20px, 7px 5px" class="sub"><a >
                            <asp:Button ID="Account" runat="server"  UseSubmitBehavior ="false"  CssClass="button-label" style="margin-right:0px;" Text="ACCOUNT" /></a>
                                <ul>
                                    <li><asp:Button ID="ProfileIcon" UseSubmitBehavior ="false" runat ="server"  style="background:url(../../images/account.png) no-repeat 2px 10px scroll; background-size :18px 20px;" class="icon" Text ="PROFILE" /></li>
                                    <li><asp:button ID="Logout" UseSubmitBehavior ="false" runat ="server"  style="background:url(../../images/login.png) no-repeat 2px 10px scroll; background-size :18px 20px;" CssClass="icon"  Text ="LOGIN"></asp:button></li>
                                </ul>

                            </li>
 
                            <li><asp:Panel ID="RegistrationPanel" runat="server" style="background:url(../../images/register.png);background-position:2px 9px;background-repeat:no-repeat;background-size:18px 20px;float:right">
                               <asp:Button  ID="Registration" UseSubmitBehavior ="false"  runat="server" CssClass ="button-label" Text="REGISTER" />
                            </asp:Panel></li>

                            <li style="background-image:url(../../images/faq-icon.png);background-position:2px 10px;background-repeat:no-repeat; background-size:20px 20px;float:right;margin-right:10px;font-weight:normal;"><a href="faqs/" class="button-label" style="width:40px;">FAQs</a></li>  
                            
                        </ul>

                  </nav>
                
            </div>
            
                
            <div class="half-down"> 

               

                <nav>
                    <ul>
                        <li><a href="../../"><span>HOME </span></a></li>   
                        <li><a href="../../about/"><span>ABOUT US</span></a></li>
                        <li><a href="../../permit-tracking"><span>PERMIT TRACKING</span></a></li>
                        <li><a href="../"><span>PHOTO GALLERY</span></a></li>
                        <li><a href="../../article/"><span>NEWS</span></a></li>
                        <li><a href="../../download/"><span>DOWNLOAD</span></a></li>
                        <li><a href="#"><span>CONTACT US</span></a>
                            <ul style="right:10px;text-align:right;">
                              <li><a href="../../contact/wmd/">Weights & Measures Department</a></li>
                              <li><a href="../../contact/cpi/">Commodity & Prod. Inspectorate Dept.</a></li>
                              <li><a href="../../contact/finance/">Finance & Account Department</a></li>
                              <li><a href="../../contact/nigerco/">Nigerco Nigeria Ltd. (Consultant)</a></li>
                            </ul>
                        </li>
                    </ul>
                </nav>

            </div>

                  
            <asp:Panel ID="WMDInspectorTools" runat ="server"  class="tools-bar">
                <nav>
                    <ul class="inner" style="margin-top:-2px;">
                        <li><asp:button ID="Inspection" UseSubmitBehavior ="false"  runat ="server" style="background:url(../../images/inspection.png) no-repeat 5px 10px scroll; background-size :20px 20px; " class="icon" Text ="Inspection" /></li>
                        <li class="active"><asp:button ID="VerificationBill" UseSubmitBehavior ="false" runat ="server" style="background:url(../../images/verification.png) no-repeat 5px 10px scroll rgb(200,200,200); background-size :20px 20px; " class="icon" Text ="Verification Bill" /></li>
                        <li><asp:button ID="Enforcement" UseSubmitBehavior ="false" runat ="server" style="background:url(../../images/enforcement.png) no-repeat 5px 10px scroll; background-size :20px 20px; " class="icon" Text ="Enforcement" /></li>
                        <li><asp:button ID="Instruments" UseSubmitBehavior ="false" runat ="server" style="background:url(../../images/instruments.png) no-repeat 5px 10px scroll; background-size :20px 20px; " class="icon" Text ="Instruments" /> </li>

                    </ul>
                </nav>
            </asp:Panel>
            </div>


        </div>
    </asp:Panel>

    <div class="content">
        <asp:Panel ID="DepositPanel" runat ="server" CssClass ="content-container">

           
            <div class="title-bar">
                   <span class ="left">Generate Verification Bill<asp:Label ID="AlbumTitle" runat="server" ></asp:Label></span>

                   
            </div>


            
            <div class ="general-form" style="margin-bottom:50px;" >

                <div class="form-group" >
                        <label for="CompanyName" >Company Name:</label>
                        <asp:DropDownList ID="CompanyName" runat="server" CssClass="select" AutoPostBack ="true">
                        </asp:DropDownList>
                 </div>
                
                  <div class="form-group">
                    <label for="SearchInstrument" >Instrument Serial Number:</label>
                    <asp:TextBox ID="SearchInstrument" runat="server" Placeholder="Search by serial number" CssClass="input" onkeydown="CheckCompany()"></asp:TextBox>
                    <Tools:AutoCompleteExtender CompletionListCssClass="" ServiceMethod="SearchInstruments" MinimumPrefixLength="1" CompletionInterval="100" EnableCaching="false" CompletionSetCount="10"
                        TargetControlID="SearchInstrument" ID="AutoCompleteExtender1" runat="server" FirstRowSelected = "false">
                    </Tools:AutoCompleteExtender>
                </div>
                
                 <div class="form-group" style="width:30%;height:100px;position:relative;margin-bottom:-43px">
                    <label>Comment:</label>
                    <asp:TextBox ID="VerificationComment" Height="80" TextMode="MultiLine" runat ="server" CssClass ="textarea"></asp:TextBox>
                 </div>
                
                
                 <div class="form-group">
                    <label>Duration:</label>
                    <asp:TextBox ID="VerificationDuration" runat ="server" TextMode="Number" placeholder="Working Hour" CssClass ="input"></asp:TextBox>
                 </div>
                
                
                <div class="form-group">
                    <label>Submitted By:</label>
                    <asp:TextBox ID="SubmittedBy" runat ="server" CssClass ="input"></asp:TextBox>
                </div>
                
                
                <div class="form-group" style="width:40%;display:inline-block ;margin-top:10px;">
                    <asp:Button ID="CancelVerification" runat ="server" UseSubmitBehavior="false" CssClass ="pay-button" Text ="Cancel Upload"  />
                    <asp:Button ID="SaveVerification" runat ="server" CssClass ="pay-button" Text ="Save Verification" UseSubmitBehavior ="true"  />

                </div> 

                
            </div>
             
            <div class="title-bar" style="margin-right:50px;">
                   <span class ="left">Inspection Worksheet History</span>
            </div>


            <asp:Panel ID="InvoiceViewPanel" runat ="server" style="margin-bottom:10px">
                <asp:GridView ID="RegisteredInstrumentGridView" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="15" OnPageIndexChanging="RegisteredInstrumentGridView_PageIndexChanging" CssClass="grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" >        
                    <Columns>
                        <asp:BoundField DataField="companyID" ItemStyle-wrap="true" ItemStyle-Width ="22px" HeaderStyle-Width ="22px" ItemStyle-CssClass ="left-align" HeaderText="ID" />
                        <asp:BoundField DataField="serialNumber" ItemStyle-wrap="true" HeaderText="Serial No." ItemStyle-Width ="150px" HeaderStyle-Width ="150px" ItemStyle-CssClass ="left-align" />
                        <asp:BoundField DataField="verifiedBy" ItemStyle-wrap="true" ItemStyle-Width ="250px" HeaderStyle-Width ="250px"  HeaderText="Submitted By" />       
                        <asp:BoundField DataField="verificationDate" ItemStyle-wrap="true" HeaderText="Date" />       
                        <asp:BoundField DataField="verificationHour" ItemStyle-wrap="true" HeaderText="Hour" HeaderStyle-Width ="27px" ItemStyle-Width="27px"/>       
                        <asp:BoundField DataField="verificationComment" ItemStyle-wrap="true" HeaderText="Comment" HeaderStyle-Width ="345px" ItemStyle-Width="345px"/>       
                    </Columns>
                    <PagerSettings Position="Bottom" Mode="NextPreviousFirstLast" FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Prev"/>
                </asp:GridView>
 
            </asp:Panel> 
                

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
