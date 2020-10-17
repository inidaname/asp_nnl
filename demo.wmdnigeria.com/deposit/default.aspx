<%@ Page Language="vb" Debug="true" AutoEventWireup="true" CodeBehind="default.aspx.vb" Inherits="WMDPortal._default11" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Weight & Measures : Deposit</title>
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
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="loading-progress">
                <div class="center"></div>
            </div>
        </ProgressTemplate>
        </asp:UpdateProgress>

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
                        <li class="active"><asp:button ID="DepositIcon" UseSubmitBehavior ="false" runat ="server" style="background:url(../images/deposit.png) no-repeat 5px 10px scroll; background-size :20px 20px; " class="icon" Text ="e-Wallet" /></li>
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
        <asp:Panel ID="DepositPanel" runat ="server" CssClass ="content-container">

           
            <div class="title-bar">
                <span class ="left">Deposit Page</span>
                <div class="form-group" style="float:left;margin-left:50px;margin-top:0px;">
                   <span class ="left">Wallet Ballance:</span>
                   <asp:Label CssClass ="welcome" ID ="WalletBalance" runat ="server"  Text="0.00" ></asp:Label>
                    
                 </div>   

            </div>


                    <div class ="deposit-form">
                        <asp:TextBox ID="OrderIDText"  Visible="false" runat="server" Height="0" CssClass ="input" style="padding:0;"></asp:TextBox>
                
                        <div class="form-group" style="float:left;position:relative">
                        
                                <label for="DepositPaymentType" >Payment Type:</label>
                                <asp:DropDownList ID="DepositPaymentType" runat="server" AutoPostBack ="true" OnSelectedIndexChanged ="PaymentType_IndexChanged" CssClass="select">
                                    <asp:ListItem Selected="True" Text="...Select Payment Type..." value="" ></asp:ListItem>
                                    <asp:ListItem Text="Cash Deposit" value="Cash" ></asp:ListItem>
                                    <asp:ListItem Text="Cheque Payment" Value="Cheque"></asp:ListItem>
                                    <asp:ListItem Text="Online Payment" Value="Online"></asp:ListItem>
                                </asp:DropDownList>

                        </div>
                              
                
                        <div class="form-group">
                                <label for="DepositAmount" >Amount to Deposit:</label>
                                <asp:TextBox ID="DepositAmount" runat ="server" TextMode ="Number"  CssClass ="input" ></asp:TextBox>

                        </div>
                        <div class="form-group">
                            <label><asp:label runat ="server" ID ="DepositChequeNumbe" Visible="true" Text=":"></asp:label></label>
                                <asp:TextBox ID="DepositChequeorReceiptNumber" runat ="server" CssClass ="input"></asp:TextBox>
                         </div>

                
                        <div class="form-group">
                        
                                <label><asp:label runat ="server" ID ="Label1" Text="Bank Name:"></asp:label></label>
                                <asp:DropDownList ID="BankName" runat="server" AutoPostBack ="true" OnSelectedIndexChanged ="PaymentType_IndexChanged" CssClass="select">
                                    <asp:ListItem Selected="True" Text="...Select Bank..." value="" ></asp:ListItem>
                                    <asp:ListItem Text="Access Bank" value="Access Bank" ></asp:ListItem>
                                    <asp:ListItem Text="Citibank" value="Citibank" ></asp:ListItem>
                                    <asp:ListItem Text="Diamond Bank" value="Diamond Bank" ></asp:ListItem>
                                    <asp:ListItem Text="Ecobank Nigeria" value="Ecobank Nigeria" ></asp:ListItem>
                                    <asp:ListItem Text="Enterprise Bank" value="Enterprise Bank" ></asp:ListItem>
                                    <asp:ListItem Text="Fidelity Bank" value="Fidelity Bank" ></asp:ListItem>
                                    <asp:ListItem Text="First Bank" value="First Bank" ></asp:ListItem>
                                    <asp:ListItem Text="First City Monument Bank" value="First City Monument Bank" ></asp:ListItem>
                                    <asp:ListItem Text="Guaranty Trust Bank" value="Guaranty Trust Bank" ></asp:ListItem>
                                    <asp:ListItem Text="Heritage Bank" value="Heritage Bank" ></asp:ListItem>
                                    <asp:ListItem Text="Keystone Bank" value="Keystone Bank" ></asp:ListItem>
                                    <asp:ListItem Text="Mainstreet Bank" value="Mainstreet Bank" ></asp:ListItem>
                                    <asp:ListItem Text="Skye Bank" value="Skye Bank" ></asp:ListItem>
                                    <asp:ListItem Text="Stanbic IBTC Bank" value="Stanbic IBTC Bank" ></asp:ListItem>
                                    <asp:ListItem Text="Standard Chartered Bank" value="Standard Chartered Bank" ></asp:ListItem>
                                    <asp:ListItem Text="Sterling Bank" Value="Sterling Bank"></asp:ListItem>
                                    <asp:ListItem Text="Union Bank " Value="Union Bank "></asp:ListItem>
                                    <asp:ListItem Text="United Bank for Africa" value="United Bank for Africa" ></asp:ListItem>
                                    <asp:ListItem Text="Wema Bank" Value="Wema Bank"></asp:ListItem>
                                    <asp:ListItem Text="Zenith Bank" Value="Zenith Bank"></asp:ListItem>
                                </asp:DropDownList>

                        </div>


                        <div class="form-group" style="float:right; margin-top:0px; margin-right:10px; width:63%">
                                <label for="DepositNarration" >Narration:</label>
                                <asp:TextBox ID="DepositNarration" runat ="server" CssClass ="textarea" TextMode ="MultiLine" ></asp:TextBox>
                         </div>


                
                        <div class="form-group" style="width:40%; margin-top:10px; margin-left:-10px;height:50px">
                             <asp:Button ID="CancelDeposit" runat ="server" CssClass ="pay-button" Text ="Cancel Deposit"  />
                             <asp:Button ID="SaveDeposit" runat ="server" CssClass ="pay-button" Text ="Save Deposit"/>

                        </div> 

                        <asp:Label ID="PaymentResponse" runat="server" style="display:inline-block;width:58%;padding:23px 0px;float:right; margin:0 auto;font-size:13px;font-weight:bolder;color:rgb(200,0,0)" text="" />

                    </div>

           <asp:UpdatePanel ID="UpdatePanel1" runat="server" EnableViewState ="true"  >
           <ContentTemplate>
            <div class="title-bar" style="margin-right:50px;">
                   <span class ="left">View deposit history </span>
                   
                
                   
                <div class="invoiceFilter form-group" style="width:200px;height:20px;float:left;">
                        <label for="FilterDeposit" >Filter:</label>
                        <asp:DropDownList ID="FilterDeposit" runat="server" AutoPostBack ="true" CssClass="select">
                            <asp:ListItem Selected="True" Text="All Payments" value="All" ></asp:ListItem>
                            <asp:ListItem Text="Cash Deposit" Value="Cash"></asp:ListItem>
                            <asp:ListItem Text="Cheque Deposit" Value="Cheque"></asp:ListItem>
                            <asp:ListItem Text="Online Deposit" Value="Online"></asp:ListItem>
                            <asp:ListItem Text="Approved Payment" Value="Approved"></asp:ListItem>
                            <asp:ListItem Text="Filter by Date" Value="Date"></asp:ListItem>
                            
                        </asp:DropDownList>

                </div>

                    
                <div class="invoiceFilter form-group" style="margin-top:-5px;float:left; height:20px;width:180px;">
                        <label for="DateFrom" >From:</label>
                        <asp:TextBox ID="DateFrom" runat ="server" CssClass ="input"  Width="120" ></asp:TextBox>
                        
                </div>
                <div class="invoiceFilter form-group" style="margin-top:-5px; float:left;height:20px;width:180px;">
                        <label for="DateTo" >To:</label>
                        <asp:TextBox ID="DateTo" runat ="server" CssClass ="input" Width="120"></asp:TextBox>
                </div>
                <div class="invoiceFilter form-group" style="margin-top:-5px; height:20px">
                    <asp:Button ID="FilterDepositButton" runat ="server"  CssClass ="buttons"  Text ="Filter Deposit"  />
                </div> 



            </div>


            <asp:Panel ID="InvoiceViewPanel" runat ="server" style="margin-bottom:10px">
                <asp:GridView ID="InvoiceGridView" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" CssClass="grid" OnPageIndexChanging="DepositGridView_PageIndexChanging" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" >        
                         <Columns>
                         <asp:BoundField DataField="orderID" ItemStyle-wrap="true" HeaderStyle-Width="100" ItemStyle-Width="100" HeaderText="Trans. ID" />
                         <asp:TemplateField ItemStyle-wrap="true" ItemStyle-CssClass ="right-align" HeaderStyle-Width="100" ItemStyle-Width="100" HeaderText="Amount" > 
                            <ItemTemplate>
                                <asp:Label ID="AMount" runat ="server" Text='<%# DataBinder.Eval(Container.DataItem, "amountDeposit", "{0:#,#0.00}")%>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:BoundField DataField="bankName" ItemStyle-wrap="true" ItemStyle-CssClass ="left-align" HeaderStyle-Width="200" ItemStyle-Width="200" HeaderText="Bank Name" /> 
                         <asp:BoundField DataField="paymentMode" ItemStyle-wrap="true" HeaderText="Mode" />
                         <asp:BoundField DataField="narration" ItemStyle-wrap="true" ItemStyle-CssClass ="left-align" HeaderStyle-Width="217" ItemStyle-Width="217" HeaderText="Narration" />      
                         <asp:BoundField DataField="depositDate" ItemStyle-wrap="true" HeaderText="Date" />        
                         <asp:BoundField DataField="approvalStatus" ItemStyle-wrap="true" HeaderText="Appr. Status" />        
                    </Columns>
                    <PagerSettings Position="Bottom" Mode="NextPreviousFirstLast" FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Prev"/>
                </asp:GridView>
 
            </asp:Panel>
            </ContentTemplate>
            </asp:UpdatePanel>

            <div class="invoiceFilter form-group" style="margin-top:15px;display:inline-block; height:50px">
                <asp:Button ID="OnlinePaymentHistory" runat ="server" CssClass ="pay-button" Text ="Detailed Online Payment History"/>
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
