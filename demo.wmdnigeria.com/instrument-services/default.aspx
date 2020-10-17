<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="WMDPortal._default13" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Tools" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Weight & Measures : Instrument Services</title>
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
                        <li><asp:button ID="InvoiceIcon" UseSubmitBehavior ="false"  runat ="server" style="background:url(../images/invoice.png) no-repeat 5px 10px scroll; background-size :20px 20px; "  class="icon" Text ="Billing" /></li>
                        <li><asp:button ID="DepositIcon" UseSubmitBehavior ="false" runat ="server" style="background:url(../images/deposit.png) no-repeat 5px 10px scroll; background-size :20px 20px; " class="icon" Text ="e-Wallet" /></li>
                        <li><asp:button ID="UploadIcon" UseSubmitBehavior ="false" runat ="server" style="background:url(../images/upload.png) no-repeat 5px 10px scroll; background-size :20px 20px; " class="icon" Text ="Upload" /></li>
                        <li class="active"><asp:button ID="InstrumentServicesicon" UseSubmitBehavior ="false" runat ="server" style="background:url(../images/instruments.png) no-repeat 5px 10px scroll; background-size :20px 20px; " class="icon" Text ="Instrument Certification" /></li>
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
                   <span class ="left">Service Amount  : <asp:Label ID ="ServiceAmount" runat ="server"  Text="" ></asp:Label></span>
                 
            </div>

           <asp:ScriptManager ID="ScriptManager1" EnablePageMethods = "true" runat="server" />
           
            <div class ="deposit-form">
                
                <div class="form-group">
                        <label for="SelectInstrument" >Select Instrument:</label>
                        <asp:DropDownList ID="SelectInstrument" runat="server" AutoPostBack ="true" OnSelectedIndexChanged ="SelectInstrument_SelectedIndexChanged" CssClass="select">
                            <asp:ListItem Text="...Select Instrument..." Value="Other"></asp:ListItem>
                        </asp:DropDownList>

                </div>

                
                <div class="form-group">
                        <label for="SearchInstrument" >Search Instrument:</label>
                        <asp:TextBox ID="SearchInstrument" runat="server" Placeholder="Search by serial number" CssClass="input"></asp:TextBox>
                        <Tools:AutoCompleteExtender  ServiceMethod="SearchInstruments" MinimumPrefixLength="1" CompletionInterval="100" EnableCaching="false" CompletionSetCount="10"
                            TargetControlID="SearchInstrument" ID="AutoCompleteExtender1" runat="server" FirstRowSelected = "false">
                        </Tools:AutoCompleteExtender>

                </div>

                
                
                <div class="form-group"">
                        <label for="ServiceGroup" >Select Service Group:</label>
                        <asp:DropDownList ID="ServiceGroup" runat="server" AutoPostBack ="true" OnSelectedIndexChanged ="ServiceGroup_SelectedIndexChanged" CssClass="select">
                            <asp:ListItem Text="...Select Service Group..." Value="Other"></asp:ListItem>
                            <asp:ListItem Text="Approval of Pattern " Value="Approval of Pattern "></asp:ListItem>
                            <asp:ListItem Text="Adjusting Fees" Value="Adjusting Fees"></asp:ListItem>
                            <asp:ListItem Text="Instrument Services" Value="Instrument Services"></asp:ListItem>
                        </asp:DropDownList>

                </div><br />

                
                <asp:Panel ID="ServiceCategoryPanel" runat="server" class="form-group" style="float:left;">
                        <label for="ServiceCategory" >Service Category:</label>
                        <asp:DropDownList ID="ServiceCategory" AutoPostBack ="true" OnSelectedIndexChanged ="ServiceCategory_SelectedIndexChanged" runat="server" CssClass="select">
                            <asp:ListItem Text="...Select Service Category..." Value="Other"></asp:ListItem>
                        </asp:DropDownList>

                </asp:Panel>


                
                <asp:Panel ID="ServiceFeePanel" runat="server" class="form-group" style="float:left;">
                        <label for="SelectServiceFee" >Select Service Fee:</label>
                        <asp:DropDownList ID="SelectServiceFee" runat="server" AutoPostBack ="true" OnSelectedIndexChanged ="ServiceFee_SelectedIndexChanged" CssClass="select"> 
                            <asp:ListItem Text="...Select Service..." Value="Other"></asp:ListItem>
                        </asp:DropDownList>

                </asp:Panel>


                <div class="form-group" style="margin-left:5px;margin-top:5px;">
                    <label for="SelectServiceFee" style="color:transparent">.</label>
                    <asp:linkbutton ID="ContinueRegistration" runat="server" href="#ChargePanel" PostBackUrl="#ChargePanel" CssClass="pay-button">Continue Registration</asp:linkbutton>
                    <asp:Button ID="RegisterService" runat ="server" CssClass ="pay-button" Text ="Register for Service" UseSubmitBehavior ="true"  />

                </div> 

            </div>


            
    <asp:Panel runat="server" class="modal" ID="ChargePanel" aria-hidden="true">
        <div class="modal-dialog" style="width:650px; top: 3%;">
            <div class="modal-header">
                <h2>Instrument Service Charge</h2>
                <a href="#close" class="btn-close" aria-hidden="true">×</a>
            </div>
            <div class="modal-body" style="overflow-y:scroll" >
                <!-- Printable Invoice -->
                <asp:Panel runat ="server" ID="InvoiceDetails" class="invoice-payment" style="margin:0 auto;width:620px;">
                    <div class="column">
                        <div class="column-header">Description</div>
                        <div class="column-body" style="text-align:left;padding-left:10px;">Working Time</div>
                        <div class="column-body" style="text-align:left;height:20px;padding-left:10px;">Waiting Time</div>
                        <div class="column-body" style="text-align:left;padding-left:10px;">Overtime</div>
                        <div class="column-body" style="text-align:left;padding-left:10px;">Travelling Time</div>
                        <div class="column-body" style="text-align:left;height:20px;padding-left:10px;">1/2 Day</div>
                        <div class="column-body" style="text-align:left;height:20px;padding-left:10px;">3/4 Day</div>
                        <div class="column-body" style="text-align:left;height:20px;padding-left:10px;">1 Day</div>
                        <div class="column-body" style="text-align:left;height:20px;padding-left:10px;">Travel costs, tickets, etc</div>
                        <div class="column-body" style="text-align:left;height:40px;padding-left:10px;">Expenses, taxes, overweight, etc</div> 
                        <div class="column-body" style="text-align:left;height:20px;padding-left:10px;">Accommodation</div>
                    </div>
                    <div class="column" style="width:43%;">
                        <div class="column-header">Period</div> 
                        <div class="column-body">Week days up to 7hours per day (Between thehours of 08.00 and 15.00, inclusive)</div>
                        <div class="column-body" style="height:20px;">To be considered as working time</div>
                        <div class="column-body">Weekdays over 7 hours and betweeen 15.00 and 06.00, as well as Saturdays, Sundays and Public Holidays.</div>
                        <div class="column-body">Auto 1400cc mileage rate 170/10km(+18 percent when towing</div>
                        <div class="column-body" style="height:20px;">3.50 hours</div>
                        <div class="column-body" style="height:20px;">5.25 hours</div>
                        <div class="column-body" style="height:20px;">7 hours</div>
                        <div class="column-body" style="height:20px;"></div>
                        <div class="column-body" style="height:40px;"></div>
                        <div class="column-body" style="height:20px;"></div>
                    </div>

                    <div class="column" style="padding-right:20px;width:20%;float:right;">
                        <div class="column-header">Amount <span style="text-decoration:line-through">N</span></div> 
                        <div class="column-body" style="text-align:right;">4,750 per hour</div>
                        <div class="column-body" style="text-align:right;height:20px;">4,750 per hour</div>
                        <div class="column-body" style="text-align:right;">7,125.00 per hour</div>
                        <div class="column-body" style="text-align:right;">1,875.00 per hour</div>
                        <div class="column-body" style="text-align:right;height:20px;">15,500.00</div>
                        <div class="column-body" style="text-align:right;height:20px;">20,500.00</div>
                        <div class="column-body" style="text-align:right;height:20px;">30,000.00</div>
                        <div class="column-body" style="text-align:right;height:20px;">Actual Cost</div>
                        <div class="column-body" style="text-align:right;height:40px;">Actual Cost</div>
                        <div class="column-body" style="text-align:right;height:20px;">Actual Cost</div>
                    </div>
		
                </asp:Panel>
    <!-- /Printable Invoice -->
            </div>

     <div class="modal-footer">
        <a href="#close" class="mbtn-close">Close Info</a> 
        <asp:Button ID="ProceedRegistration" runat ="server" CssClass ="pay-button" Text ="Save & Exit" style="margin-top:-5px;" UseSubmitBehavior ="true"  />
  
    </div>
    </div>
    </asp:Panel> 


         
            <div class="title-bar" style="margin-right:50px;">
                   <span class ="left">List of Registered Instrument Services</span>
            </div>

          

            <asp:Panel ID="InvoiceViewPanel" runat ="server" style="margin-bottom:10px">
            <asp:Panel ID="ProcessingData" runat="server" class="loading"></asp:Panel>
            <asp:Panel ID="NoRecord" runat="server" class="no-record"><span>No record found!</span></asp:Panel>

                <asp:GridView ID="InstrumentServicesGridView" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="20" CssClass="grid" OnPageIndexChanging="InstrumentServicesGridView_PageIndexChanging" OnSelectedIndexChanged = "OnInstrumentSelectedIndexChanged"  AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" >        
                         <Columns>
                             <asp:BoundField DataField="transCode" HeaderText="ID" ItemStyle-Width ="70px" HeaderStyle-Width ="70px"/>
                             <asp:BoundField DataField="companyName" ItemStyle-wrap="true" ItemStyle-Width ="147px" HeaderStyle-Width ="147px" HeaderText="Company" />
                             <asp:BoundField DataField="deviceTypeAndNumber" ItemStyle-wrap="true" ItemStyle-Width ="180px" HeaderStyle-Width ="180px" HeaderText="Instrument" />
                             <asp:BoundField DataField="serviceGroup" ItemStyle-wrap="true" ItemStyle-Width ="117px" HeaderStyle-Width ="117px" HeaderText="Service Group" /> 
                             <asp:BoundField DataField="serviceCategory" ItemStyle-wrap="true" HeaderText="Fee Sub" />
                             <asp:TemplateField ItemStyle-wrap="true" ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass ="right-align" HeaderStyle-Width="105" ItemStyle-Width="105" HeaderText="Total Amount" > 
                            <ItemTemplate>
                                <asp:Label ID="Amount" runat ="server" Text='<%# DataBinder.Eval(Container.DataItem, "amount", "{0:#,#0.00}")%>' ></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                             <asp:BoundField DataField="registrationDate" ItemStyle-Width ="70px" HeaderStyle-Width ="70px" ItemStyle-wrap="true" HeaderText="Date" />       
                             <asp:ButtonField DataTextField="serviceGroup" Text="" CommandName="Select" ButtonType="Link" ItemStyle-ForeColor ="DarkGray" HeaderText ="Status" HeaderStyle-Width ="88" ItemStyle-Width="85" />
                         </Columns>
                    <PagerSettings Position="Bottom" Mode="NextPreviousFirstLast" FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Prev"/>
                </asp:GridView>
 
            </asp:Panel>
            </asp:Panel>


            <asp:Panel runat="server" class="modal" ID="InstrumentServicesFeedback" aria-hidden="true">
                <div class="modal-dialog" style="width:650px; top: 15%;">
                    <div class="modal-header">
                        <h2>Feed us Back on this Instrument</h2>
                        <a href="#close" class="btn-close" aria-hidden="true">×</a>
                    </div>
                    <div class="modal-body" >
                        <div class="instrument-services-feedback" >
                           <div class="form-group">
                               <label class="label">Company:</label>
                               <asp:TextBox runat="server" BorderStyle="none" Enabled="false" ID="CompanyName" CssClass="input"/>

                           </div>
                       
                           <div class="form-group">
                               <label class="label">Instrument:</label>
                               <asp:TextBox runat="server" BorderStyle="none" Enabled="false" ID="InstrumentName" CssClass="input"/>

                           </div>
                       
                           <div class="form-group">
                               <label class="label">Service Group:</label>
                               <asp:TextBox runat="server" BorderStyle="none" Enabled="false" ID="InstrumentServiceGroup" CssClass="input"/>

                           </div>
                       
                           <div class="form-group">
                               <label class="label">Engineer:</label>
                               <asp:TextBox runat="server" ID="TextBox3" CssClass="input"/>

                           </div>
                            
                       
                           <div class="form-group">
                               <label class="label">Job Hour:</label>
                               <asp:TextBox runat="server" ID="TextBox4" CssClass="input"/>

                           </div>
                       
                           <div class="form-group">
                               <label class="label">Amount Paid:</label>
                               <asp:TextBox runat="server" ID="TextBox6" CssClass="input"/>

                           </div>
                       
                           <div class="form-group" style="width:96%">
                               <label class="label">Experience:</label>
                               <asp:TextBox runat="server" ID="TextBox7" TextMode="MultiLine" CssClass="textarea" placeholder="Please tell us your experience with our engineer(s) who service your instrument to enable us serve you better!"/>

                           </div>
                       
                           <div class="form-group" style="width:96%;">
                               <label class="label">Upload Invoice:</label>
                               <asp:FileUpload runat="server" ID="TextBox9" style="width:80%;height:25px;margin-top:-3px;" CssClass="input"/>

                           </div>
                       
                        </div>
                    </div>

             <div class="modal-footer">
                <a href="#close" class="mbtn-close">Cancel</a> 
                <asp:Button ID="Button1" runat ="server" CssClass ="pay-button" Text ="Save & Exit" style="margin-top:-5px;" UseSubmitBehavior ="true"  />
  
            </div>
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
