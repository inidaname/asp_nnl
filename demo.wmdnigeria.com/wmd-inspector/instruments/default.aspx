<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="WMDPortal._default40" %>

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
                   <span class ="left">Instrument History<asp:Label ID="AlbumTitle" runat="server" ></asp:Label></span>

                   
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

                <div class="form-group" style="width:30%;display:inline-block ; padding-top:10px;margin-top:5px;float:right;">
                    <asp:Button ID="ShowHistory" runat ="server" CssClass ="pay-button" Text ="Display History" UseSubmitBehavior ="true"  />

                </div> 
                
                <asp:Label runat="server" ID="SearchMessage" style="width:80%;font-size:13px;margin:30px auto;font-weight:bolder;color:rgb(150,0,0);text-align:center;"></asp:Label>
                <asp:Label runat="server" ID="Company"></asp:Label>
                <asp:Label runat="server" ID="Amount"></asp:Label>
                
            </div>


             
            <div class="title-bar" style="margin-right:50px;">
                   <span class ="left">Inspection Worksheet History</span>
                   
                

            </div>


            <asp:Panel ID="InstrumentHistoryPanel" Visible="false" runat ="server" style="margin-bottom:10px">
                <asp:Label runat="server" ID="InstrumentDetail" ><h4 style="margin:20px 15px;">INSTRUMENT DETAIL</h4></asp:Label>
                <asp:GridView ID="InstrumentDetailGridView" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="15" OnPageIndexChanging="RegisteredInstrumentGridView_PageIndexChanging" CssClass="grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"  OnSelectedIndexChanged ="ViewDownloadWorksheet" >        
                    <Columns>
                        <asp:BoundField DataField="companyID" ItemStyle-wrap="true" ItemStyle-Width ="22px" HeaderStyle-Width ="22px" ItemStyle-CssClass ="left-align" HeaderText="ID" />
                        <asp:BoundField DataField="companyName" ItemStyle-wrap="true" ItemStyle-Width ="185px" HeaderStyle-Width ="185px" ItemStyle-CssClass ="left-align" HeaderText="Company" />
                        <asp:BoundField DataField="companyEmail" ItemStyle-wrap="true" ItemStyle-Width ="150px" HeaderStyle-Width ="150px" ItemStyle-CssClass ="left-align" HeaderText="Company Email" />
                        <asp:BoundField DataField="companyPhoneNumber" ItemStyle-wrap="true" ItemStyle-CssClass ="left-align" HeaderText="Mobile No." />
                        <asp:BoundField DataField="deviceModelName" ItemStyle-wrap="true" ItemStyle-Width ="100px" HeaderStyle-Width ="100px" ItemStyle-CssClass ="left-align" HeaderText="Instrument" />
                        <asp:BoundField DataField="serialNumber" ItemStyle-wrap="true" HeaderText="Serial No." ItemStyle-Width ="100px" HeaderStyle-Width ="100px" ItemStyle-CssClass ="left-align" />
                        <asp:BoundField DataField="transCode" ItemStyle-wrap="true" HeaderText="Reference" ItemStyle-Width ="120px" HeaderStyle-Width ="120px" />
                        <asp:BoundField DataField="deviceAmount" ItemStyle-wrap="true" HeaderText="Amount" ItemStyle-Width ="100px" HeaderStyle-Width ="100px" ItemStyle-CssClass ="right-align" />
                        
                    </Columns>
                    <PagerSettings Position="Bottom" Mode="NextPreviousFirstLast" FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Prev"/>
                </asp:GridView>
 
                <asp:Label runat="server" ID="Annual" ><h4 style="margin:20px 15px;">ANNUAL LISENCING</h4></asp:Label>
                <asp:GridView ID="AnnualLicensingGridView" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="15" OnPageIndexChanging="RegisteredInstrumentGridView_PageIndexChanging" CssClass="grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"  OnSelectedIndexChanged ="ViewDownloadWorksheet" >        
                    <Columns>
                       <asp:BoundField DataField="deviceReference" ItemStyle-wrap="true" ItemStyle-Width ="300px" HeaderStyle-Width ="300px" HeaderText="Reference Number" />
                        <asp:BoundField DataField="dateRenewed" ItemStyle-wrap="true" ItemStyle-Width ="300px" HeaderStyle-Width ="300px" HeaderText="Last Renewal Date" />
                        <asp:BoundField DataField="renewalYear" ItemStyle-wrap="true" HeaderText="Licensing Renewal Year" ItemStyle-Width ="182px" HeaderStyle-Width ="182px"/>
                        <asp:TemplateField ItemStyle-wrap="true" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="150" ItemStyle-Width="150" HeaderText="Payment Status" > 
                            <ItemTemplate>
                                <asp:Label ID="Status" runat ="server" Text='<%# String.Format("{0}", LicenseStatus )%>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                    </Columns>
                    <PagerSettings Position="Bottom" Mode="NextPreviousFirstLast" FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Prev"/>
                </asp:GridView>
 
 
                <asp:Label runat="server" ID="Pattern" ><h4 style="margin:20px 15px;">PATTERN OF APPROVAL</h4></asp:Label>
                <asp:GridView ID="ApprovalPatternGridView" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="15" OnPageIndexChanging="RegisteredInstrumentGridView_PageIndexChanging" CssClass="grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"  OnSelectedIndexChanged ="ViewDownloadWorksheet" >        
                    <Columns>
                       <asp:BoundField DataField="deviceTypeAndNumber" ItemStyle-wrap="true" ItemStyle-Width ="150px" HeaderStyle-Width ="150px" ItemStyle-CssClass ="left-align" HeaderText="Instrument Type" />
                        <asp:BoundField DataField="serviceGroup" ItemStyle-wrap="true" ItemStyle-Width ="150px" HeaderStyle-Width ="150px" ItemStyle-CssClass ="left-align" HeaderText="Service Group" />
                        <asp:BoundField DataField="serviceCategory" ItemStyle-wrap="true" HeaderText="Category" ItemStyle-Width ="100px" HeaderStyle-Width ="100px" ItemStyle-CssClass ="left-align" />
                        <asp:BoundField DataField="serviceFee" ItemStyle-wrap="true" HeaderText="Fee Group" />       
                        <asp:BoundField DataField="amount" ItemStyle-wrap="true" HeaderText="Amount" HeaderStyle-Width ="108px" ItemStyle-Width="108px" ItemStyle-CssClass ="right-align"/>
                        <asp:BoundField DataField="registrationDate" ItemStyle-wrap="true" HeaderText="Date" HeaderStyle-Width ="80px" ItemStyle-Width="82px"/>
                        <asp:BoundField DataField="description" ItemStyle-wrap="true" HeaderText="Description"/>
                        <asp:BoundField DataField="period" ItemStyle-wrap="true" HeaderText="Period" HeaderStyle-Width ="100px" ItemStyle-Width="100px"/>
                    </Columns>
                    <PagerSettings Position="Bottom" Mode="NextPreviousFirstLast" FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Prev"/>
                </asp:GridView>
 
 
                <asp:Label runat="server" ID="Verification" ><h4 style="margin:20px 15px;">INITIAL VERIFICATION</h4></asp:Label>
                <asp:GridView ID="VerificationGridView" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="15" OnPageIndexChanging="RegisteredInstrumentGridView_PageIndexChanging" CssClass="grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"  OnSelectedIndexChanged ="ViewDownloadWorksheet" >        
                    <Columns>
                        <asp:BoundField DataField="verifiedBy" ItemStyle-wrap="true" ItemStyle-Width ="282px" HeaderStyle-Width ="282px" ItemStyle-CssClass ="left-align" HeaderText="Verified By" />
                        <asp:BoundField DataField="verificationDate" ItemStyle-wrap="true" ItemStyle-Width ="150px" HeaderStyle-Width ="150px" HeaderText="Date Verified" />
                        <asp:BoundField DataField="verificationHour" ItemStyle-wrap="true" HeaderText="Hour" ItemStyle-Width ="100px" HeaderStyle-Width ="100px" />
                        <asp:BoundField DataField="verificationComment" ItemStyle-wrap="true" HeaderText="Verification Comment" ItemStyle-Width ="400px" HeaderStyle-Width ="400px" ItemStyle-CssClass ="left-align"/>  
                    </Columns>
                    <PagerSettings Position="Bottom" Mode="NextPreviousFirstLast" FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Prev"/>
                </asp:GridView>
 
 
                <asp:Label runat="server" ID="Services" ><h4 style="margin:20px 15px;">PERIODIC VERIFICATION</h4></asp:Label>
                <asp:GridView ID="ServicesGridView" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="15" OnPageIndexChanging="RegisteredInstrumentGridView_PageIndexChanging" CssClass="grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"  OnSelectedIndexChanged ="ViewDownloadWorksheet" >        
                    <Columns>
                       <asp:BoundField DataField="deviceTypeAndNumber" ItemStyle-wrap="true" ItemStyle-Width ="150px" HeaderStyle-Width ="150px" ItemStyle-CssClass ="left-align" HeaderText="Instrument Type" />
                        <asp:BoundField DataField="serviceGroup" ItemStyle-wrap="true" ItemStyle-Width ="150px" HeaderStyle-Width ="150px" ItemStyle-CssClass ="left-align" HeaderText="Service Group" />
                        <asp:BoundField DataField="serviceCategory" ItemStyle-wrap="true" HeaderText="Category" ItemStyle-Width ="100px" HeaderStyle-Width ="100px" ItemStyle-CssClass ="left-align" />
                        <asp:BoundField DataField="serviceFee" ItemStyle-wrap="true" HeaderText="Fee Group" />       
                        <asp:BoundField DataField="amount" ItemStyle-wrap="true" HeaderText="Amount" HeaderStyle-Width ="108px" ItemStyle-Width="108px" ItemStyle-CssClass ="right-align"/>
                        <asp:BoundField DataField="registrationDate" ItemStyle-wrap="true" HeaderText="Date" HeaderStyle-Width ="80px" ItemStyle-Width="82px"/>
                        <asp:BoundField DataField="description" ItemStyle-wrap="true" HeaderText="Description"/>
                        <asp:BoundField DataField="period" ItemStyle-wrap="true" HeaderText="Period" HeaderStyle-Width ="100px" ItemStyle-Width="100px"/>
                    </Columns>
                    <PagerSettings Position="Bottom" Mode="NextPreviousFirstLast" FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Prev"/>
                </asp:GridView>
 
 
                <asp:Label runat="server" ID="Adjustment" ><h4 style="margin:20px 15px;">ADJUSTMENT</h4></asp:Label>
                <asp:GridView ID="AdjustmentGridView" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="15" OnPageIndexChanging="RegisteredInstrumentGridView_PageIndexChanging" CssClass="grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"  OnSelectedIndexChanged ="ViewDownloadWorksheet" >        
                    <Columns>
                      <asp:BoundField DataField="deviceTypeAndNumber" ItemStyle-wrap="true" ItemStyle-Width ="150px" HeaderStyle-Width ="150px" ItemStyle-CssClass ="left-align" HeaderText="Instrument Type" />
                        <asp:BoundField DataField="serviceGroup" ItemStyle-wrap="true" ItemStyle-Width ="150px" HeaderStyle-Width ="150px" ItemStyle-CssClass ="left-align" HeaderText="Service Group" />
                        <asp:BoundField DataField="serviceCategory" ItemStyle-wrap="true" HeaderText="Category" ItemStyle-Width ="100px" HeaderStyle-Width ="100px" ItemStyle-CssClass ="left-align" />
                        <asp:BoundField DataField="serviceFee" ItemStyle-wrap="true" HeaderText="Fee Group" />       
                        <asp:BoundField DataField="amount" ItemStyle-wrap="true" HeaderText="Amount" HeaderStyle-Width ="108px" ItemStyle-Width="108px" ItemStyle-CssClass ="right-align"/>
                        <asp:BoundField DataField="registrationDate" ItemStyle-wrap="true" HeaderText="Date" HeaderStyle-Width ="80px" ItemStyle-Width="82px"/>
                        <asp:BoundField DataField="description" ItemStyle-wrap="true" HeaderText="Description"/>
                        <asp:BoundField DataField="period" ItemStyle-wrap="true" HeaderText="Period" HeaderStyle-Width ="100px" ItemStyle-Width="100px"/>
                    </Columns>
                    <PagerSettings Position="Bottom" Mode="NextPreviousFirstLast" FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Prev"/>
                </asp:GridView>
 
 
                <asp:Label runat="server" ID="Legal" ><h4 style="margin:20px 15px;">LEGAL NOTICES</h4></asp:Label>
                <asp:GridView ID="LegalNoticesGridView" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="15" OnPageIndexChanging="RegisteredInstrumentGridView_PageIndexChanging" CssClass="grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"  OnSelectedIndexChanged ="ViewDownloadWorksheet" >        
                    <Columns>
                        <asp:BoundField DataField="heading" ItemStyle-wrap="true" ItemStyle-Width ="150px" HeaderStyle-Width ="150px" ItemStyle-CssClass ="left-align" HeaderText="Notice Heading" />
                        <asp:BoundField DataField="notices" ItemStyle-wrap="true" HeaderText="Notice" ItemStyle-Width ="500px" HeaderStyle-Width ="500px" ItemStyle-CssClass ="left-align" />
                        <asp:BoundField DataField="userID" ItemStyle-wrap="true" HeaderText="Sent By" ItemStyle-Width ="180px" HeaderStyle-Width ="180px"/>       
                        <asp:BoundField DataField="registrationDate" ItemStyle-wrap="true" HeaderText="Date Sent" HeaderStyle-Width ="100px" ItemStyle-Width="100px"/>
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
