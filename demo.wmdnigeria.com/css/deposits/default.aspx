<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="WMDPortal._default11" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Weight & Measures : Deposit</title>

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
                        <li class="active"><a href="../"><span>HOME </span></a></li>   
                        <li><a href="./"><span>ABOUT US</span></a></li>
                        <li><a href="../download/"><span>DOWNLOAD</span></a></li>
                        <li><a href="../career/"><span>CAREER</span></a></li>
                        <li><a href="../contact/"><span>CONTACT US</span></a></li>
                    </ul>
                </nav>

            </div>

                <asp:Panel ID="ToolBar" runat ="server"  class="tools-bar">
                <div class="inner">
                     <asp:button ID="ProfileIcon" UseSubmitBehavior ="false" runat ="server" style="background:url(../images/profile.png) no-repeat 0px 10px scroll; background-size :20px 20px; " class="icon" Text ="Profile" />
                    <asp:button ID="InvoiceIcon" UseSubmitBehavior ="false"  runat ="server" style="background:url(../images/invoice.png) no-repeat 0px 10px scroll; background-size :20px 20px; "  class="icon" Text ="Inovices" />
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
        <asp:Panel ID="DepositPanel" runat ="server" CssClass ="content-container">

           
            <div class="title-bar">
                <span class ="left">Deposit Page</span>
                <div class="form-group" style="float:left;margin-left:50px;margin-top:0px;">
                   <span class ="left">My Wallet:</span>
                   <asp:Label CssClass ="welcome" ID ="WalletBalance" runat ="server"  Text="0.00" ></asp:Label>
                    
                 </div>  
                <span class="welcome" >Welcome 
                    <asp:Label CssClass ="welcome" ID ="WelcomeMessage" runat ="server"  Text=" John" ></asp:Label>
                
                </span>

            </div>


            <div class ="deposit-form">
                
                <div class="form-group" style="float:left;">
                        <label for="DepositPaymentType" >Payment Type:</label>
                        <asp:DropDownList ID="DepositPaymentType" runat="server" AutoPostBack ="true"  OnSelectedIndexChanged ="PaymentType_IndexChanged" CssClass="select">
                            <asp:ListItem Selected="True" Text="...Select Payment Type..." value="" ></asp:ListItem>
                            <asp:ListItem Text="Cash Deposit" value="Cash" ></asp:ListItem>
                            <asp:ListItem Text="Cheque Payment" Value="Cheque"></asp:ListItem>
                            <asp:ListItem Text="Online Payment" Value="Online"></asp:ListItem>
                        </asp:DropDownList>

                </div>

                
                
                <div class="form-group">
                        <label for="DepositAmount" >Amount to Depost:</label>
                        <asp:TextBox ID="DepositAmount" runat ="server" TextMode ="Number"  CssClass ="input" ></asp:TextBox>

                </div>
                <div class="form-group" >
                    <label><asp:label runat ="server" ID ="DepositChequeNumbe" Text="Cheque Number:"></asp:label></label>
                        <asp:TextBox ID="DepositChequeorReceiptNumber" runat ="server" CssClass ="input"></asp:TextBox>
                 </div>


                
                
                <div class="form-group" >
                        <label><asp:label runat ="server" ID ="DepositBankNam" Text="Bank Name:"></asp:label></label>
                        <asp:TextBox ID="DepositBankName" runat ="server" CssClass ="input"></asp:TextBox>

                </div>
                <div class="form-group" style="float:right; margin-top:-10px; margin-right:10px; width:63%">
                        <label for="DepositNarration" >Narration:</label>
                        <asp:TextBox ID="DepositNarration" runat ="server" CssClass ="textarea" TextMode ="MultiLine" ></asp:TextBox>
                 </div>


                
                <div class="form-group" style="width:400px; margin-top:10px; margin-left:-10px;height:50px">
                     <asp:Button ID="CancelDeposit" runat ="server" CssClass ="pay-button" Text ="Cancel Deposit"  />
                     <asp:Button ID="SaveDeposit" runat ="server" CssClass ="pay-button" Text ="Save Deposit" UseSubmitBehavior ="true"  />

                </div> 

            </div>



           <asp:ScriptManager ID="ScriptManager1" runat="server" />
           <asp:UpdatePanel ID="UpdatePanel1" runat="server" EnableViewState ="true"  >
           <ContentTemplate>
            <div class="title-bar" style="margin-right:50px;">
                   <span class ="left">View deposit history </span>
                   
                
                   
                <div class="invoiceFilter form-group" style="width:200px;height:20px;float:left;">
                        <label for="FilterDeposit" >Filter:</label>
                        <asp:DropDownList ID="FilterDeposit" runat="server" CssClass="select">
                            <asp:ListItem Selected="True" Text="All Payments" value="All" ></asp:ListItem>
                            <asp:ListItem Text="Cash Deposit" Value="Cash"></asp:ListItem>
                            <asp:ListItem Text="Cheque Payment" Value="Cheque"></asp:ListItem>
                            <asp:ListItem Text="Online Payment" Value="Online"></asp:ListItem>
                            <asp:ListItem Text="Approved Payment" Value="Approved"></asp:ListItem>
                            <asp:ListItem Text="Filter by Date" Value="Date"></asp:ListItem>
                            
                        </asp:DropDownList>

                </div>

                    
                <div class="invoiceFilter form-group" style="margin-top:-5px;float:left; height:20px">
                        <label for="FilterInvoiceByDateFrom" >From:</label>
                        <asp:Calendar ID="CalendarFrom" runat="server" Visible="False" CssClass ="calendar" TitleStyle-CssClass="calendarTitle"    OnSelectionChanged ="CalendarFrom_SelectionChanged"  Font-Size="8pt"></asp:Calendar>
                        <asp:TextBox ID="FilterInvoiceByDateFrom" runat ="server" CssClass ="input" AutoPostBack ="true" ></asp:TextBox>
                        <asp:Button ID="FromDate" runat="server" CssClass ="calendar-button"  onclick="FromDate_Click"/>

                </div>
                <div class="invoiceFilter form-group" style="margin-top:-5px; float:left;height:20px">
                        <label for="FilterInvoiceByDateTo" >To:</label>
                        <asp:Calendar ID="CalendarTo" runat="server" Visible="False"  CssClass ="calendar" OnSelectionChanged ="CalendarTO_SelectionChanged" TitleStyle-CssClass="calendarTitle" Font-Size="8pt"></asp:Calendar>
                        <asp:TextBox ID="FilterInvoiceByDateTo" runat ="server" CssClass ="input"></asp:TextBox>
                        <asp:Button ID="ToDate" runat="server"  CssClass ="calendar-button"  onclick="ToDate_Click"/>
                </div>
                <div class="invoiceFilter form-group" style="margin-top:-5px; height:20px">
                     <asp:Button ID="FilterDepositButton" runat ="server"  CssClass ="button" Text ="Filter Deposit"  />

                </div> 

            </div>


            <asp:Panel ID="InvoiceViewPanel" runat ="server" style="margin-bottom:10px">
                <asp:GridView ID="InvoiceGridView" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="8" CssClass="grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" >        
                         <Columns>
                        <asp:TemplateField HeaderStyle-CssClass ="check-head" ItemStyle-CssClass ="check"> 
                            <ItemTemplate>
                              <!--  <asp:CheckBox ID="DepositSelector" runat="server"/> -->
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:BoundField DataField="transactionID" ItemStyle-wrap="true" HeaderText="Trans. ID" />
                         <asp:BoundField DataField="amountDeposit" ItemStyle-wrap="true" HeaderText="Amount" />
                         <asp:BoundField DataField="bankName" ItemStyle-wrap="true" HeaderText="Bank Name" /> 
                         <asp:BoundField DataField="paymentMode" ItemStyle-wrap="true" HeaderText="Mode" />
                         <asp:BoundField DataField="narration" ItemStyle-wrap="true" HeaderText="Narration" />      
                         <asp:BoundField DataField="depositDate" ItemStyle-wrap="true" HeaderText="Date" />        
                         <asp:BoundField DataField="depositTime" ItemStyle-wrap="true" HeaderText="Time" />        
                         <asp:BoundField DataField="approvalStatus" ItemStyle-wrap="true" HeaderText="Appr. Status" />        
                         <asp:BoundField DataField="approvalNarration" ItemStyle-wrap="true" HeaderText="Narration" />        
                         </Columns>
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
                <div class="title">Other Links</div>
                <div class="footer-link"><a>Posts & Comments</a></div>
                <div class="footer-link"><a>Photo Gallery</a></div>
                <div class="footer-link"><a>News Archive</a></div>
                <div class="footer-link"><a>Quiz (Questions & Answers)</a></div>
                <div class="footer-link"><a>Frequently Ask Questions</a></div>
                

            </div>
            <div class="footer-divider"> 
                <div class="title">REGULATIONS </div>
                <div class="footer-link"><a>Official Gazette No. 24</a></div>
                <div class="footer-link"><a>Official Gazette No. 25</a></div>
                <div class="footer-link"><a>Official Pre-Shipment Act</a></div>
                <div class="footer-link"><a>Weights and Measures Act</a></div>
                <div class="footer-link"><a>Guideline for Calibrators</a></div>

            </div>
            <div class="footer-divider"> 
                <div class="title">INFORMATION CENTER</div>
                <div class="footer-link"><a>Abuja Securities & Commodities</a></div>
                <div class="footer-link"><a>Bank of Industry (BOI)</a></div>
                <div class="footer-link"><a>Consumer Protection Council</a></div>
                <div class="footer-link"><a>Corporate Affairs Commission</a></div>
                <div class="footer-link"><a>Industrial Training Fund</a></div>

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
