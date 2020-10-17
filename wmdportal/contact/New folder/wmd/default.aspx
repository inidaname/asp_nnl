<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="WMDPortal._default5" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Weight & Measures : Contact Us</title>

    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../css/menu.css" rel="stylesheet" type="text/css" />
    <link href="../images/icon.png" rel="icon" type="images/jpg" />
    <script src ="../js/jQuery.js" type ="text/javascript" ></script>
    <script src ="../js/tabScript.js" type ="text/javascript" ></script>

    <script type="text/javascript">
        function StateOffices() {
            var e = document.getElementById('StateOfficesPanel');
            if (e.style.display == 'block')
                e.style.display = 'none';
            else
                e.style.display = 'block';

            $('html, body').animate({
                scrollTop: $("#StateOfficesPanel").offset().top
            }, 2000);
        }
   </script>
            
</head>
<body>
     <form id="Form1" runat ="server" >
    <!-- This is header -->
    <asp:Panel ID="HeaderPanel" runat ="server"  CssClass ="headers">

        <div class="header">
            <div class="logo"></div>
            <div class="header-right">
            
                
            <div class="half-top"> 
                <h3 style="text-align:center; font-size:20px;margin-top:-10px;">Federal Ministry of Industry Trade and Investment<br /> 
                    <span style="font-size:15px;">Weights and Measures Department</span></h3>
                 
                     <ul>
                            <li style="background:url(../images/login.png) no-repeat 2px 12px; background-size:18px 22px"><a >
                            <asp:Button ID="Logout" runat="server" CssClass ="button-label" Text="LOGIN" /></a></li>
 
                            <asp:Panel ID="RegistrationPanel" runat="server" CssClass="li" style="background:url(../images/register.png) no-repeat 2px 12px; background-size:20px 22px;float:right">
                               <asp:Button  ID="Registration" runat="server" CssClass ="button-label" Text="REGISTER" />
                            </asp:Panel>

                            <li><a href="faqs/"><span>FAQs</span></a></li>  
                            
                        </ul>
                
            </div>
            
                
            <div class="half-down"> 

               

                <nav>
                    <ul>
                        <li><a href="../"><span>HOME </span></a></li>   
                        <li><a href="../about/"><span>ABOUT US</span></a></li>
                        <li><a href="../gallery/"><span>PHOTO GALLERY</span></a></li>
                        <li><a href="../article/"><span>NEWS</span></a></li>
                        <li><a href="../download/"><span>DOWNLOAD</span></a></li>
                        <li><a href="../career/"><span>CAREER</span></a></li>
                        <li  class="active"><a href="./"><span>CONTACT US</span></a>
                            <ul style="right:10px;text-align:right;">
                              <li><a href="../contact/wmd/">Weights & Measures</a></li>
                              <li><a href="../contact/cpi/">CPI Department</a></li>
                              <li><a href="../contact/nigerco/">Nigerco Nigeria Ltd.</a></li>
                            </ul>
                        </li>
                    </ul>
                </nav>

            </div>

              <asp:Panel ID="ToolBar" runat ="server"  class="tools-bar">
                <div class="inner">
                     <asp:button ID="ProfileIcon" UseSubmitBehavior ="false" runat ="server" style="background:url(../images/profile.png) no-repeat 0px 10px scroll; background-size :20px 20px; " class="icon" Text ="Profile" />
                    <asp:button ID="InvoiceIcon" UseSubmitBehavior ="false"  runat ="server" style="background:url(../images/invoice.png) no-repeat 0px 10px scroll; background-size :20px 20px; "  class="icon" Text ="Invoices" />
                    <asp:button ID="DepositIcon" UseSubmitBehavior ="false" runat ="server" style="background:url(../images/deposit.png) no-repeat 0px 10px scroll; background-size :20px 20px; " class="icon" Text ="My Wallet" />
                    <asp:button ID="UploadIcon" UseSubmitBehavior ="false" runat ="server" style="background:url(../images/upload.png) no-repeat 0px 10px scroll; background-size :20px 20px; " class="icon" Text ="Upload" />
                    <asp:button ID="InstrumentServicesicon" UseSubmitBehavior ="false" runat ="server" style="background:url(../images/instruments.png) no-repeat 0px 10px scroll; background-size :20px 20px; " class="icon" Text ="Instrument" />
                    <asp:button ID="RegisterInstrumentIcon" UseSubmitBehavior ="false" runat ="server" style="background:url(../images/register-instrument.png) no-repeat 0px 10px scroll; background-size :20px 20px; " class="icon" Text ="Register Instrument" />
                    <asp:button ID="RequirementIcon" UseSubmitBehavior ="false" runat ="server" style="background:url(../images/requirement.png) no-repeat 0px 10px scroll; background-size :20px 20px; " class="icon" Text ="Requirement" />
                    <asp:button ID="ImportPermitIcon" UseSubmitBehavior ="false" runat ="server" style="background:url(../images/import-export.png) no-repeat 0px 10px scroll; background-size :20px 20px; " class="icon" Text ="Import Permit" />
                    <asp:button ID="ExportPermitIcon" UseSubmitBehavior ="false" runat ="server" style="background:url(../images/import-export.png) no-repeat 0px 10px scroll; background-size :20px 20px; " class="icon" Text ="Export Permit" />
                    <asp:button ID="ReportIcon" UseSubmitBehavior ="false" runat ="server" style="background:url(../images/reporting.png) no-repeat 0px 10px scroll; background-size :20px 20px; " class="icon" Text ="Reports" />

                </div>

            </asp:Panel>  

            </div>


        </div>
    </asp:Panel>

    <div class="content">

            <div class="title">Contact Us</div>
            
            <div class="contact-section">
            <div class="contact-form">
                <h3>Contact Form</h3>

                     <div class="form-group">
                        <label for="Name" >Name:</label><br />
                        <asp:TextBox ID="Name" runat="server" CssClass="input"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="Email" >Email Address: </label><br />
                        <asp:TextBox ID="EmailAddress" runat="server" CssClass="input"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="Name" >Phone Number:</label><br />
                        <asp:TextBox ID="PhoneNumber" runat="server" CssClass="input"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="Name" >Subject:</label><br />
                        <asp:TextBox ID="Subject" runat="server" CssClass="input"></asp:TextBox>
                    </div>

                    <div class="form-group" style="margin-bottom:20px;">
                        <label for="Name" >Message:</label><br />
                        <asp:TextBox ID="Message" TextMode="MultiLine"  runat="server" CssClass="textarea"></asp:TextBox>


                    </div>
                    
                    <div class="form-group">
                        <asp:Button ID="SendMessage" runat="server" Text="Send Message" class="button" />
                        <asp:Button ID="ClearForm" runat="server" Text="Reset Form" class="button"/>

                    </div>

 

            </div>

            <div class="contact-details">
                <h3>Contact Information</h3> 
                <p>Head Office Address</p> 


                <span>NIGERCO NIGERIA LIMITED<br />
                    Plot 3379, Cadastral Zone, A04, Mungo Park Close, Asokoro, Abuja.

                </span>
                <p>Email Address:</p>
                <span>metrology@nnlnigeria.com
                info@nnlnigeria.com</span>
                <p>Phone Number:</p>
                +234 (0) 709 881 8412



                <p>Abuja Annex Office</p>
	 
  	  	

                <span>Block G, Room 141 & 142
                Old Secretariat Area I, Garki Abuja
                P. O. Box 1882 Abuja, Nigeria.
                </span>

                <p>Email Address:</p>
                info@nnlnigeria.com
                metrology@nigerco.com

                <p>Phone Number:</p>
                092915722, 07033865116, 07069544888, 08037216405

                <div runat="server" id="StateOffices" style="margin:20px 0px;" class="pay-button" onclick="StateOffices()" >View State Offices</div>
            </div>
        
            
        </div>
        <asp:Panel ID="StateOfficesPanel" runat="server" class="state-offices-section">
           <div class="title" style="width:100%;"><div style="width:300px;margin:0 auto; text-align:center"> Our Other State Offices</div></div>
            
            <asp:GridView ID="StateOfficesGrid" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="15" OnPageIndexChanging="StateOfficesGrid_PageIndexChanging" CssClass="grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" >        
                <Columns>
                    <asp:BoundField DataField="state" ItemStyle-wrap="true" ItemStyle-Width ="100px" HeaderStyle-Width ="100px" HeaderText="STATE" />
                    <asp:BoundField DataField="address" ItemStyle-wrap="true" ItemStyle-Width ="350PX" HeaderStyle-Width ="352PX" HeaderText="CONTACT ADDRESS" />
                    <asp:BoundField DataField="emailAddress" ItemStyle-wrap="true" ItemStyle-Width ="220px" HeaderStyle-Width ="220px" HeaderText="EMAIL ADDRESS" /> 
                    <asp:BoundField DataField="contactPersonName" ItemStyle-wrap="true" ItemStyle-Width ="160px" HeaderStyle-Width ="162px" HeaderText="CONTACT PERSON" />
                    <asp:BoundField DataField="contactPersonMobile" ItemStyle-wrap="true"  ItemStyle-Width ="80px" HeaderStyle-Width ="80px" HeaderText="MOBILE" />      
                </Columns>
                <PagerSettings Position="Bottom" Mode="NextPreviousFirstLast" FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Prev"/>
             </asp:GridView>

        </asp:Panel>

        <div class="map-section">
            <iframe src="http://www.yourmapmaker.com/preview.php?a=Old Secretariat Area I, Garki Abuja, Nigeria.,Nigeria&w=1010&h=400&n=NIGERCO NIGERIA LIMITED&z=14&t=Map" height="400" width="1010" style="border:0px;"></iframe> 
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
                <div class="title">INFORMATION CENTER</div>
                <div class="footer-link"><a href="http://www.abujacomex.com/" target ="_blank" >Abuja Securities & Commodities</a></div>
                <div class="footer-link"><a href="http://www.boinigeria.com/" target ="_blank" >Bank of Industry (BOI)</a></div>
                <div class="footer-link"><a href="http://www.cpc.gov.ng/" target ="_blank" >Consumer Protection Council</a></div>
                <div class="footer-link"><a href="http://www.cac.gov.ng/" target ="_blank" >Corporate Affairs Commission</a></div>
                <div class="footer-link"><a href="http://www.itf-nigeria.com/" target ="_blank" >Industrial Training Fund</a></div>

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
            <div class="copyright-text">Copyright &copy; 2013 - 2015. All rights reserved.</div>
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
