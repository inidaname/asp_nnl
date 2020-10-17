<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="WMDPortal._default12" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Weight & Measures : Upload Documents</title>
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
                <h3 style="text-align:center; font-size:20px;margin-top:-10px;">Federal Ministry of Industry Trade and Investment<br /> 
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
                        <li><asp:button ID="InvoiceIcon" UseSubmitBehavior ="false"  runat ="server" style="background:url(../images/invoice.png) no-repeat 5px 10px scroll; background-size :20px 20px; "  class="icon" Text ="Billing" /></li>
                        <li><asp:button ID="DepositIcon" UseSubmitBehavior ="false" runat ="server" style="background:url(../images/deposit.png) no-repeat 5px 10px scroll; background-size :20px 20px; " class="icon" Text ="e-Wallet" /></li>
                        <li class="active"><asp:button ID="UploadIcon" UseSubmitBehavior ="false" runat ="server" style="background:url(../images/upload.png) no-repeat 5px 10px scroll; background-size :20px 20px; " class="icon" Text ="Upload" /></li>
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

            </div>


        </div>
    </asp:Panel>

    <div class="content">
        <asp:Panel ID="DepositPanel" runat ="server" CssClass ="content-container">
           
            <div class="title-bar">
                   <span class ="left">Upload Page : Upload Documents Archive</span>
                 
            </div>

              <div class ="deposit-form" style="height:200px;">
                <div class="form-group" style="float:left;width:100%;">
                     <asp:Label runat="server" ID="FileTypeAllowed" style="font-size:13px;height:20px;float:left; color:rgb(150,0,0)"></asp:Label>
                </div>
                <div class="form-group" style="margin-top:10px;float:left">
                    <label for="FileUpload" >File to Upload :</label> 
                    <asp:FileUpload ID="FileUpload" runat="server" CssClass="input-flat"></asp:FileUpload>
                </div>

                <div class="form-group" style="margin-right:10px;float:left">
                        <label for="FileDescription" >File Description:</label>
                        <asp:TextBox ID="FileDescription" runat ="server" CssClass ="input" TextMode ="MultiLine" ></asp:TextBox>
                 </div>
                        
                               
                <div class="form-group" style="display:inline-block ; padding-top:10px;margin-top:-5px; margin-left:-10px;height:50px;float:right;">
                    <br /> 
                    <asp:Button ID="CancelUpload" runat ="server" CssClass ="pay-button" Text ="Cancel"  />
                     <asp:Button ID="UploadFile" runat ="server" CssClass ="pay-button" Text ="Upload File" UseSubmitBehavior ="true"  />

                </div> 

            </div> 

            
            <!--
            <asp:Panel ID="ExportDataReturn" runat="server" class ="deposit-form" style="height:150px;">
                <div class="form-container">
                    <iframe src ="http://localhost/php/upload/?Session=ActiveFromUserExportFileUpload&CompanyID=1" class="iframe" style="width:100%;height:200px;"></iframe>

                </div>
            </asp:Panel>
                       
            
            <asp:Panel ID="PIAExportDataReturn" runat="server" class ="deposit-form" style="height:150px;">
                <div class="form-container">
                    <iframe src ="http://localhost/php/upload/?Session=ActiveFromUserPIAExportFileUpload&CompanyID=1" class="iframe" style="width:100%;height:200px;"></iframe>

                </div>
            </asp:Panel>
                       
            -->        


           <asp:ScriptManager ID="ScriptManager1" runat="server" />
           <asp:UpdatePanel ID="UpdatePanel1" runat="server" EnableViewState ="true"  >
           <ContentTemplate>
            <div class="title-bar" style="margin-right:50px;">
                   <span class ="left">Upload history: </span>
                         
                <div class="form-group" style="float:left; margin-top:-5px;margin-left:50px; height:20px">
                     <asp:TextBox runat ="server" ID="FilterUpload" Height="20" width="250" placeholder="Search by file name or description" style="text-transform:none;" onKeyPress="TextChanging()"  onfocus="SetCaretAtEnd(this)" CssClass ="input"></asp:TextBox>
                    <asp:Button ID="FilterUploadButton" runat ="server" Visible ="true" BackColor="Transparent" BorderColor ="Transparent" Text ="" />

                </div>
                

            </div>


            <asp:Panel ID="InvoiceViewPanel" runat ="server" style="margin-bottom:10px">
                <asp:GridView ID="UploadGridView" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" CssClass="grid" OnPageIndexChanging ="DownloadGridView_PageIndexChanging"  AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" OnSelectedIndexChanged ="OnUploadViewActionClicked" >        
                    <Columns>
                        <asp:BoundField DataField="fileName" ItemStyle-wrap="true" ItemStyle-CssClass ="left-align" ItemStyle-Width ="300px" HeaderStyle-Width ="300px" HeaderText="File" />
                        <asp:BoundField DataField="description" ItemStyle-wrap="true" ItemStyle-CssClass ="left-align" ItemStyle-Width ="395px" HeaderStyle-Width ="395px" HeaderText="File Description" /> 
                        <asp:BoundField DataField="uploadDate" ItemStyle-wrap="true" HeaderText="Date" />      
                        <asp:ButtonField Text="View / Download File" ItemStyle-ForeColor="GrayText" HeaderText ="File Action" CommandName="Select" HeaderStyle-Width ="150" ItemStyle-Width="150" /> 
                    </Columns>
                    <PagerSettings Position="Bottom" Mode="NextPreviousFirstLast" FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Prev"/>
                </asp:GridView>
 
            </asp:Panel>
            </ContentTemplate>
            </asp:UpdatePanel>
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
