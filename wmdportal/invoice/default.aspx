<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="WMDPortal._default10" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Weight & Measures : Invoice</title>
    <meta name="author" content="Application Developed by: John Ojebode"/>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../css/menu.css" rel="stylesheet" type="text/css" />
    <link href="../images/icon.png" rel="icon" type="images/jpg" />
    <script src ="../js/jQuery.js" type ="text/javascript" ></script>
    <script src ="../js/tabScript.js" type ="text/javascript" ></script>
    
    <link rel="stylesheet" href="../js/jQuery-ui.css" />
    <script src="../js/jQuery1.10.js"></script>
    <script src="../js/jQuery-ui.js"></script>
    <script type="text/javascript"  lang="javascript">
        $(function () {
            $("#DateFrom").datepicker({ dateFormat: 'dd-mm-yy' });
        });

        $(function () {
            $("#DateTo").datepicker({ dateFormat: 'dd-mm-yy' });
        });

     </script>

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
                        <li class="active"><asp:button ID="InvoiceIcon" UseSubmitBehavior ="false"  runat ="server" style="background:url(../images/invoice.png) no-repeat 5px 10px scroll; background-size :20px 20px; "  class="icon" Text ="Billing" /></li>
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
            </div>


        </div>
    </asp:Panel>

    <div class="content">
        <asp:Panel ID="InvoicePanel" runat ="server" CssClass ="content-container">

           
            <div class="title-bar">
                   <span class ="left">Outstanding: </span>
                   <asp:Label CssClass ="outstanding" ID ="OutstandingBill" runat ="server"  Text="0.00" ></asp:Label>

                   <span class ="left" style="color:#042378">Wallet: </span>
                   <asp:Label CssClass ="outstanding" ID ="WalletBalance" runat ="server"  Text="0.00" ></asp:Label>

                   
                <div class="invoiceFilter form-group" style="float:left; height:20px;">
                        <label for="FilterInvoice" >Filter:</label>
                        <asp:DropDownList ID="FilterInvoice" runat="server" CssClass="select" AutoPostBack="true" OnSelectedIndexChanged ="FilterInvoice_SelectedIndexChanged">
                            <asp:ListItem Text="...Select Payment" disabled="disabled" value="Select" ></asp:ListItem>
                            <asp:ListItem Text="Outstanding Bills" Value="Outstanding" Selected="True" ></asp:ListItem>                            
                            <asp:ListItem Text="Bills Paid" Value="Paid"></asp:ListItem>

                        </asp:DropDownList>

                </div>

                <div class="invoiceFilter form-group" style="float:left;  height:20px;">
                        <label for="FilterInvoice" >Transaction Type:</label>
                        <asp:DropDownList ID="TransactionType" runat="server" CssClass="select"  AutoPostBack="true" OnSelectedIndexChanged ="TransactionType_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Text="...Select Transaction Type" disabled="disabled" value="Select" ></asp:ListItem>
                            <asp:ListItem Text="Company Registration Fee" Value="Registration Invoice"></asp:ListItem>
                            <asp:ListItem Text="Instrument Fee" Value="Instrument Registration Invoice"></asp:ListItem>
                            <asp:ListItem Text="Anual Licensing Renewal Fee" Value="Annual Licensing Renewal Invoice"></asp:ListItem>
                            <asp:ListItem Text="Export Permit Fee" Value="Date"></asp:ListItem>
                            
                        </asp:DropDownList>

                </div>
                 
                <div class="invoiceFilter form-group" style="float:left; margin-top:-5px; height:20px">
                     <asp:TextBox runat ="server" ID="FilterBills" Height="20" width="150" placeholder="Search transaction" onKeyPress="TextChangingBill()"  onfocus="SetCaretAtEnd(this)" CssClass ="input"></asp:TextBox>
                    <asp:Button ID="FilterBill" runat ="server" Visible ="true" BackColor="Transparent" BorderColor ="Transparent" Text ="" />

                </div>
               
            </div>

            <asp:Panel ID="InvoiceViewPanel" runat ="server" >
                <p /><h2 style="margin:0 auto;width:100%;text-align:center;"><asp:label ID="DocumentTitle" runat ="server" Text="OUTSTANDING BILLS"></asp:label></h2>
                <asp:Panel ID="ProcessingData" runat="server" class="loading"></asp:Panel>
                <asp:Panel ID="NoRecord" runat="server" class="no-record"><span>No record found!</span></asp:Panel>

                <asp:GridView ID="PaymentGridView" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="15" CssClass="grid" OnPageIndexChanging="PaymentGridView_PageIndexChanging" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" DataKeyNames = "transCode">        
                    <Columns>
                         <asp:TemplateField HeaderStyle-CssClass ="check-head" ItemStyle-CssClass ="check"> 
                            <ItemTemplate>
                                <asp:CheckBox ID="PaymentSelector" runat="server" OnCheckedChanged="PaymentSelection_CheckedChanged" AutoPostBack ="true" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="invoiceDate" ItemStyle-wrap="true" HeaderStyle-Width ="65" ItemStyle-Width="65" HeaderText="Date" /> 
                        <asp:TemplateField ItemStyle-wrap="true" ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass ="right-align" HeaderStyle-Width="150" ItemStyle-Width="150" HeaderText="Total Amount" > 
                            <ItemTemplate>
                                <asp:Label ID="AmountDue" runat ="server" Text='<%# DataBinder.Eval(Container.DataItem, "amountDue", "{0:#,#0.00}")%>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField><asp:BoundField DataField="narration" ItemStyle-wrap="true" ItemStyle-CssClass ="left-align" HeaderStyle-Width ="406" ItemStyle-Width="406" HeaderText="Purpose" />
                        <asp:BoundField DataField="paymentStatus" ItemStyle-wrap="true" HeaderStyle-Width ="135" ItemStyle-Width="135" HeaderText="Payment Status"  />
                        <asp:BoundField DataField="transCode" ItemStyle-wrap="true" HeaderStyle-Width ="135" ItemStyle-Width="135" HeaderText="Transact. ID" />
                                                          
                    </Columns>
                    <PagerSettings Position="Bottom" Mode="NextPreviousFirstLast" FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Prev"/>
                </asp:GridView>

                
                <asp:GridView ID="InvoiceGridView" runat="server" OnSelectedIndexChanged = "OnInvoiceSelectedIndexChanged" AutoGenerateColumns="false" AllowPaging="true" PageSize="15" CssClass="grid" OnPageIndexChanging="InvoiceGridView_PageIndexChanging" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" >        
                    <Columns>
                        <asp:BoundField DataField="orderId" ItemStyle-wrap="true" HeaderText="Invoice Number" HeaderStyle-Width ="121" ItemStyle-Width="120" /> 
                        <asp:TemplateField ItemStyle-wrap="true" ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass ="right-align" HeaderStyle-Width="150" ItemStyle-Width="150" HeaderText="Total Amount" > 
                            <ItemTemplate>
                                <asp:Label ID="AMount" runat ="server" Text='<%# DataBinder.Eval(Container.DataItem, "TotalAmountPaid", "{0:#,#0.00}")%>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="narration" ItemStyle-wrap="true" HeaderStyle-Width ="400" ItemStyle-Width="400" ItemStyle-CssClass ="left-align" HeaderText="Purpose of Transaction" />
                        <asp:BoundField DataField="invoiceDate" ItemStyle-wrap="true" HeaderStyle-Width ="120" ItemStyle-Width="120" HeaderText="Invoice Date" /> 
                        <asp:ButtonField Text="View Invoice" ItemStyle-ForeColor ="DarkGray" HeaderText ="Action" CommandName="Select" HeaderStyle-Width ="125" ItemStyle-Width="125" />         
                        


                    </Columns>
                    <PagerSettings Position="Bottom" Mode="NextPreviousFirstLast" FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Prev"/>
                </asp:GridView>



            <p></p>
            <asp:Panel ID="FooterBar" runat ="server" CssClass="footer-bar" Height="50px">
                    <div style="margin-left:10px;">
                    <asp:Button ID="PaySelected" runat="server" CssClass ="mbtn" Text="Pay Selected" />
                    <asp:Button ID="RechargeAccount" runat="server" CssClass ="mbtn" Text="Fund my Wallet" />

                    </div>
                    
            </asp:Panel> 

            </asp:Panel>

        </asp:Panel>
            
    </div>

    <asp:Panel runat="server" class="modal" ID="ViewInvoice" aria-hidden="true">
        <div class="modal-dialog" style="width:650px; top: 0%;">
           <!-- <div class="modal-header">
                <h2>File Download center</h2>
                <a href="#close" class="btn-close" aria-hidden="true">×</a>
            </div>-->
            <div class="modal-body" style="height:620px;overflow-y:scroll" >
                <!-- Printable Invoice -->
                <asp:Panel runat ="server" ID="InvoiceDetails" class="invoice-payment" style="margin:0 auto;width:620px;">
                    <div style='width:600px;height:70px;padding:10px;color:rgb(255, 255, 255);font-weight:bolder;text-align:center;font-size:20px;background:rgb(54,127,169);'>
	                    <img src='../images/icon.png' width='70' height='70' style='margin-top:-10px;padding:0px;float:left' />
	                    <p style="margin-top:-1px" />Federal Ministry of Industry Trade and Investment
                        <span style='font-size:17px;margin-top:-15px;'>Weights and Measures Department</span>
                    </div>
                    
                    <div style='width:620px;font-size:15px;background:rgb(255,255, 255);'>
                        <div style='padding-left:10px; width:590px;'>
			            <h4 style='padding:2px;font-size:23px;width:100%;text-align:center;margin-top:-10px;'>INVOICE</h4> 
			            <h4 style='padding:0px;font-size:17px;'>Invoice #<asp:Label runat="server" ID="InvoiceID"></asp:Label><span style='float:right;font-size:13px;'><asp:Label runat="server" ID="InvoiceDate"></asp:Label></span></h4>
			            
                        <div style='margin-bottom:0px;display:block;height:169px; width:100%;'>
				            <div style='width:45%;float:left;'>
					            <div style='font-weight:bolder;font-size:17px;padding:5px 0px;'>CLIENT DETAIL</div>
					            <p style='font-weight:bolder;font-size:15px;'><asp:Label runat="server" ID="InvoiceCompanyName"></asp:Label>( <asp:Label runat="server" ID="InvoiceUsername"></asp:Label>  ) </p>
					            <p style='font-weight:bolder;font-size:15px;'><asp:Label runat="server" ID="InvoiceCompanyAddress"></asp:Label></p>
				            </div>
					
				            <div style='width:45%;float:right;'>
					            <div style='font-weight:bolder;font-size:17px;padding:5px 0px;'>ACCOUNT DETAIL</div>
					            <p style='font-weight:bolder;font-size:13px;'>ACCOUNT NAME: <span style='font-weight:normal;'>FEDERAL MINISTRY OF INDUSTRY, TRADE AND INVESTMENT WEIGHTS AND MEASURES DEPARTMENT</span></p>
					            <p style='font-weight:bolder;font-size:13px;'>ACCOUNT NUMBER: <span style='font-weight:normal;'>1750013688</span></p>
					            <p style='font-weight:bolder;font-size:13px;'>BANK NAME: <span style='font-weight:normal;'>SKYE BANK</span></p>
					        </div>
			            </div>
			
			            <div style='font-weight:bolder;font-size:17px;padding:5px 0px;'>INVOICE ITEM(S)</div>
			                <div style='width:69%;display:inline-block;font-weight:bolder;padding:10px 0px;border-bottom:1px solid rgb(200,200,200);color:rgb(100,100,100);'>Summary</div>
			                <div style='width:30%;display:inline-block;text-align:right;font-weight:bolder;padding:10px 0px;border-bottom:1px solid rgb(200,200,200);color:rgb(100,100,100);'>Amount</div>
			                
                            <!--Repeater ...................................................
                                ............................................................ -->
                            <asp:Repeater ID="DisplayInvoice" runat="server">
                                <ItemTemplate>
                                    <div style='width:69%;display:inline-block;padding:10px 0px;'><%# String.Format("{0}", Eval("narration"))%> </div>
			                        <div style='width:30%;display:inline-block;text-align:right;padding:10px 0px;'><%# DataBinder.Eval(Container.DataItem, "amountDue", "{0:#,#0.00}")%></div>
			                    </ItemTemplate>
                            </asp:Repeater>
                                   <div style='width:100%;display:inline-block;padding:20px 0px 20px 29px;margin-left:-10px; padding-right:1px;text-align:right;font-weight:bolder;background:rgb(250,250,250);font-size:17px;'>
				                Total: <span style='float:right;margin-left:50px;margin-right:20px;'><span style="text-decoration :line-through">N</span><asp:Label runat ="server" ID="InvoiceTotalAmount" ></asp:Label></span>
			                </div>
		                </div>
		                <p/>
		                <div style='margin-top:0px;width:600px;height:auto;padding:2px 10px;height:1px;color:rgb(20,20,20);text-align:left;font-size:13px;background:rgb(255,255,255);'>
			            </div>
		
                </div>
                
                <div style="width:600px;height:auto;padding:5px 10px;color:rgb(255, 255, 255);text-align:left;font-size:13px;background:rgb(54,127,169);">
			        <strong>PLEASE NOTICE: </strong>  ALL BANK DEPOSIT MUST BE MADE WITH THE USERNAME AS THE DEPOSITOR.<p>ALL PAYMENT(S) MADE ARE NON-REFUNDABLE.
			     </div>
           
            </asp:Panel>
    <!-- /Printable Invoice -->

            </div>

     <div class="modal-footer">
        <a href="#close" class="mbtn-close">Close Invoice</a>  
        <a href="#" onclick ="return printdiv('InvoiceDetails');" class="mbtn-printer" style="padding:8px 35px;color:rgb(255,255,255);margin-top:-3px;">Print Invoice</a>
    </div>
    </div>
    </asp:Panel> 


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
