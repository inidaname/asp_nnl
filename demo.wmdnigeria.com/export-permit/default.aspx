<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="WMDPortal._default15" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Weight & Measures : Export Permit</title>
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
            <div class="logo-coat"></div>
            <div class="header-right">
                            
            <div class="half-top"> 
                <h3 style="text-align:center; font-size:20px;margin-top:-10px;">Federal Ministry of Industry, Trade and Investment<br /> 
                    <span style="font-size:15px;">Commodities and Products Inspectorate Department (CPI)</span></h3>
                 
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
                        <li><asp:button ID="InstrumentServicesicon" UseSubmitBehavior ="false" runat ="server" style="background:url(../images/instruments.png) no-repeat 5px 10px scroll; background-size :20px 20px; " class="icon" Text ="Instrument Certification" /></li>
                        <li><asp:button ID="RegisterInstrumentIcon" UseSubmitBehavior ="false" runat ="server" style="background:url(../images/register-instrument.png) no-repeat 5px 10px scroll; background-size :20px 20px; " class="icon" Text ="Register Instrument" /></li>
                        <li><asp:button ID="ExportReturnIcon" UseSubmitBehavior ="false" runat ="server" style="background:url(../images/import-export.png) no-repeat 5px 10px scroll; background-size :20px 20px; " class="icon" Text ="Export Return" /></li>
                    
                        <li class="active"><a style="background:url(../images/import-export.png) no-repeat 5px 10px scroll; background-size :20px 20px; " class="icon">Export Permit</a>
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
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div class="content">
 
        
        <asp:Panel ID="ExportPermitPanel" runat ="server" CssClass ="content-container">

          
            <div class="title-bar">
               <span class ="left" style="float:left;margin-right:40px;">Export Permit Application Form</span>

                
 	 	       <div class="form-group" style="float:left;height:20px;margin-top:0px;">
                     <asp:RadioButton runat ="server" ID ="MainExportPermitApplication" Enabled ="true" class="checkbox" GroupName="ApplicationMode" ToolTip ="Main Export Permit Application for a Quarter in Year" value="Singel"/><span class="checkbox" style="color:#7c0909;margin-top:1px; font-weight:bolder;float:right;">Main Export Permit Applicaiton</span><br />
               </div> 
 	 	       <div class="form-group" style="float:left;height:20px;margin-top:0px;">
                    <asp:RadioButton runat ="server" ID ="SupplimentExportPermitApplication" Enabled ="true" class="checkbox" GroupName="ApplicationMode" ToolTip ="This will be selected automatically if you have already applied for Selected Permit Quarter this Year" value="Bulk"/><span class="checkbox" style="color:#7c0909;font-weight:bolder;margin-top:1px;float:right;">Suppliment Export Permit Application</span><br />

                </div> 
                                   
                <span class="welcome" >Welcome 
                    <asp:Label CssClass ="welcome" ID ="WelcomeMessage" runat ="server"  Text=" John" ></asp:Label>
                
                </span>
                
                <br /><p></p>

                 
            </div>

            <asp:Panel ID="ExportApplication" runat ="server">
                <div style="float:left;width:100%;font-size:17px;margin:0px auto;padding:0px;text-align:center;font-weight :bolder; ">
                    APPLICATION FOR EXPORT CLEARANCE PERMIT <br /><span style="font-size:14px;margin-bottom :50px;"> (CRUDE OIL, GAS AND OTHER PETROLEUM PRODUCTS)</span></>
                </div>
              
          
            <div class ="general-form" style="margin-top:50px;">
               
                 <h3 style="width:100%; float:left;">EXPORT PERMIT DETAILS</h3>

                
                <div class="form-group" >
                        <label for="PermitQuarter" >Permit Quarter:<span class="asterik"  >*</span> </label>
                     <asp:DropDownList ID="PermitQuarters" runat ="server" AutoPostBack ="true" OnSelectedIndexChanged ="PermitQuarter_SelectedIndexChanged" CssClass ="select">
                            <asp:ListItem text="...Select Permit Quarter..." value="" ></asp:ListItem>
                            
                     </asp:DropDownList>
                 </div>
                             
                
                <div class="form-group" >
                        <label for="ProductDescription" >Product Description:<span class="asterik"  >*</span> </label>
                        <asp:TextBox ID="ProductDescription" runat ="server" CssClass ="input"></asp:TextBox>
                 </div>
                             
                
                <div class="form-group">
                        <label for="Measure" >Select Measure:<span class="asterik"  >*</span> </label>
                        <asp:DropDownList ID="Measure" runat ="server" CssClass ="select">
                            <asp:ListItem text="...Select Measurement..." value="" ></asp:ListItem>
                            <asp:ListItem text="Barrels" value="Barrels" ></asp:ListItem>
                            <asp:ListItem text="Metric Tons" value="Metric Tons" ></asp:ListItem>
                        </asp:DropDownList>

                 </div>
                             
                <div class="form-group" >
                        <label for="ExportQuantity" >Export Quantity:<span class="asterik"  >*</span> </label>
                        <asp:TextBox ID="ExportQuantity" runat ="server" AutoPostBack ="true" OnTextChanged ="ExportQuantity_TextChanged" CssClass ="input"></asp:TextBox>
                 </div>
                             
                
                <div class="form-group">
                        <label for="AmountPerBarrel" >Amount Per Barrel(USD):<span class="asterik"  >*</span> </label>
                        <asp:TextBox ID="AmountPerBarrel" runat ="server" AutoPostBack ="true" OnTextChanged ="AmountPerBarrel_TextChanged"  CssClass ="input"></asp:TextBox>
                 </div>
                     
                <div class="form-group">
                        <label for="ExporterName" >Exporter Name:<span class="asterik"  >*</span> </label>
                        <asp:TextBox ID="ExporterName" runat ="server" CssClass ="input"></asp:TextBox>
                 </div>
                           
                   
                <div class="form-group">
                        <label for="Measure" >Period Covered From:<span class="asterik"  >*</span> </label>
                        <asp:DropDownList ID="PeriodCoveredFrom" runat ="server" CssClass ="select">
                            <asp:ListItem text="...Select Measurement..." value="" ></asp:ListItem>
                            <asp:ListItem text="January" value="1" ></asp:ListItem>
                            <asp:ListItem text="February" value="2" ></asp:ListItem>
                            <asp:ListItem text="March" value="3" ></asp:ListItem>
                            <asp:ListItem text="April" value="4" ></asp:ListItem>
                            <asp:ListItem text="May" value="5" ></asp:ListItem>
                            <asp:ListItem text="June" value="6" ></asp:ListItem>
                            <asp:ListItem text="July" value="7" ></asp:ListItem>
                            <asp:ListItem text="August" value="8" ></asp:ListItem>
                            <asp:ListItem text="September" value="9" ></asp:ListItem>
                            <asp:ListItem text="October" value="10" ></asp:ListItem>
                            <asp:ListItem text="Novermber" value="11" ></asp:ListItem>
                            <asp:ListItem text="December" value="12" ></asp:ListItem>
                        </asp:DropDownList>

                 </div>
                             
                
                <div class="form-group">
                        <label for="Measure" >Period Covered From:<span class="asterik"  >*</span> </label>
                        <asp:DropDownList ID="PeriodCoveredTo" runat ="server" CssClass ="select">
                            <asp:ListItem text="...Select Measurement..." value="" ></asp:ListItem>
                            <asp:ListItem text="January" value="1" ></asp:ListItem>
                            <asp:ListItem text="February" value="2" ></asp:ListItem>
                            <asp:ListItem text="March" value="3" ></asp:ListItem>
                            <asp:ListItem text="April" value="4" ></asp:ListItem>
                            <asp:ListItem text="May" value="5" ></asp:ListItem>
                            <asp:ListItem text="June" value="6" ></asp:ListItem>
                            <asp:ListItem text="July" value="7" ></asp:ListItem>
                            <asp:ListItem text="August" value="8" ></asp:ListItem>
                            <asp:ListItem text="September" value="9" ></asp:ListItem>
                            <asp:ListItem text="October" value="10" ></asp:ListItem>
                            <asp:ListItem text="Novermber" value="11" ></asp:ListItem>
                            <asp:ListItem text="December" value="12" ></asp:ListItem>
                        </asp:DropDownList>

                 </div>
                             
                
                <div class="form-group">
                        <label for="ExportPort" >Port Of Export:<span class="asterik"  >*</span> </label>
                        <asp:TextBox ID="ExportPort" runat ="server" CssClass ="input"></asp:TextBox>
                 </div>
                             
                <div class="form-group" style="float:left" >
                        <label for="FOBValue" >F.O.B Value(USD):<span class="asterik"  >*</span> </label>
                        <asp:TextBox ID="FOBValue" runat ="server" Enabled ="false" CssClass ="input"></asp:TextBox>
                 </div>
                             
                <div class="form-group" style="float:left">
                       <label for="TerminalOperator" >Terminal Operator:</label>
                        <asp:RadioButton ID="TerminaOperator" GroupName ="TerminalOperator" runat ="server" CssClass ="checkbox"></asp:RadioButton>
                        <span class="checkbox" style="text-align:center;margin-top:-2px; width:94%;margin-right:35px;">Terminal Operator</span>
                 </div>
                            
                <div class="form-group" style="float:right">
                        <label for="NonTerminalOperator">Non Terminal Operator:</label>
                        <asp:RadioButton ID="NonTerminalOperator" GroupName="TerminalOperator" runat ="server" CssClass ="checkbox"></asp:RadioButton>
                        <span class="checkbox" style="text-align:center;margin-top:-2px; width:94%;margin-right:35px;">Non Terminal Operator</span>
                 </div>
                    
                <h3 style="width:100%; float:left;">EXPORT PERMIT DOCUMENTS UPLOAD</h3>
                             
                <div class="form-group" style="width:100%">
                    <label for="CertificateOfIncorporation" class ="label" >Certificate of Incorporation of the applicant's company:</label> 
                    <asp:FileUpload ID="CertificateOfIncorporation" runat="server" CssClass="input-flat"></asp:FileUpload>
                </div>
                             
                <div class="form-group" style="width:100%">
                    <label for="MemorandumOfAssociation" class ="label" >Company Article and Memorandum of Association</label> 
                    <asp:FileUpload ID="MemorandumOfAssociation" runat="server" CssClass="input-flat"></asp:FileUpload>
                </div>
                             
                <div class="form-group" style="width:100%">
                    <label for="CurrentProduction" class ="label" >Current Production/Storage/Sales license issued by DPR</label> 
                    <asp:FileUpload ID="CurrentProduction" runat="server" CssClass="input-flat"></asp:FileUpload>
                </div>
                             
                <div class="form-group" style="width:100%;margin-bottom:30px;">
                    <label for="ConformityCertificate" class ="label" >Current Weights and Measures Department certificate of conformity for the Fiscal Meters, Gauges, and all Custody Transfer Weighing & Measuring instruments at the terminal(s) to be used for the export	</label> 
                    <asp:FileUpload ID="ConformityCertificate" runat="server" CssClass="input-flat"></asp:FileUpload>
                </div>
                             
                <div class="form-group" style="width:100%">
                    <label for="BankReference" class ="label" >Original Bank reference with committed and explicit statements</label> 
                    <asp:FileUpload ID="BankReference" runat="server" CssClass="input-flat"></asp:FileUpload>
                </div>
                     
                <div class="form-group" style="width:100%">
                    <label for="ClearanceCertificate" class ="label" >3-Years Tax Clearance Certificate</label> 
                    <asp:FileUpload ID="ClearanceCertificate" runat="server" CssClass="input-flat"></asp:FileUpload>
                </div>
                             
                <div class="form-group" style="width:100%">
                    <label for="ExportPermitApplication" class ="label" >Attach Export Permit Application Document made to DPR	</label> 
                    <asp:FileUpload ID="ExportPermitApplication" runat="server" CssClass="input-flat"></asp:FileUpload>
                </div>
                              
                <div class="form-group" style="width:100%">
                    <label for="EvidenceOfPayment" class ="label" ><span class="asterik"  >*</span> Evidence of Payment of Monitoring Fees</label> 
                    <asp:FileUpload ID="EvidenceOfPayment" runat="server" ViewStateMode ="Enabled" EnableViewState ="true"  required="" CssClass="input-flat"></asp:FileUpload>
                </div>
                         
                <br />

                <h3 style="width:100%; float:left;">APPLICATION FILLED BY</h3>

                <div class="form-group">
                        <label for="FillerTitle" >Title:</label>
                        <asp:DropDownList ID="FillerTitle" required="" runat="server" CssClass="select">
                             
                            <asp:ListItem value="---Select Title---" selected="true"></asp:ListItem>
                            <asp:ListItem Text="Mr" value="Mr"></asp:ListItem>
                            <asp:ListItem Text="Mrs" value="Mrs"></asp:ListItem>
                            <asp:ListItem Text="Ms" value="Ms"></asp:ListItem>
                            <asp:ListItem Text="Miss" value="Miss"></asp:ListItem>
                            
                        </asp:DropDownList>
                    </div> 
                 
                <div class="form-group" >
                        <label for="FillerFullName" >Full Name:</label>
                        <asp:TextBox ID="FillerFullName" runat ="server"  required="" CssClass ="input" ></asp:TextBox>
                 </div>
                             
                
                <div class="form-group">
                        <label for="FillerEmailAddress" >Email Address:</label>
                        <asp:TextBox ID="FillerEmailAddress" runat ="server" required="" CssClass  ="input" TextMode ="Email" ></asp:TextBox>
                 </div>
                             

                    <h3>DECLARATION</h3>
                <div class="form-group" style="width:100%;">
                        <asp:CheckBox ID="Agree" runat ="server" CssClass ="checkbox"></asp:CheckBox>
                        <span class="checkbox" style="text-align:left;margin-top:-4px; width:94%;float:right;margin-right:35px;"> We declare that the making of any false statement or concealment of any material fact in connection with this application may result in imprisonment or fine, or both and denial, in whole or in part, of participation in Nigeria Oil and Gas Exports.</span>
                 </div>
                         
                
                <div class="form-group" style="width:50%;display:inline-block ; margin-top:30px; margin-left:-10px;height:50px">
                    <asp:Button ID="Cancel" runat ="server" CssClass ="mbtn-close" Text ="Cancel"  />
                    <asp:Button ID="CompleteProcess" runat="server" text="Submit Application" class="pay-button-save"/>
                    
                </div> 

                
            </div>
            </asp:Panel>
            
           
           
         <div class="title-bar">
                <span class ="left">List of Export Permit Application</span>
              
                <asp:TextBox runat ="server" ID="SearchExportPermit" Height="20" width="200" CssClass ="input"  placeholder="Enter Application Reference No" onKeyPress ="TextChangingExport()" onfocus="SetCaretAtEnd(this)" ></asp:TextBox>
                <asp:Button ID="SearchPermit" UseSubmitBehavior ="false" runat ="server" BackColor="Transparent" ForeColor="Transparent" BorderColor ="Transparent"  Width="20" Text ="" />
                <asp:Button ID="FreshApplication" UseSubmitBehavior ="false" runat ="server" CssClass ="buttons" Text ="Application Form" />
           
          
         </div>
 
            <asp:Panel ID="ExportViewPanel" runat ="server" style="margin-bottom:10px">
            <asp:Panel ID="ProcessingData" runat="server" class="loading"></asp:Panel>
            <asp:Panel ID="NoRecord" runat="server" class="no-record"><span>No record found!</span></asp:Panel>

                <asp:GridView ID="ExportPermitGridView" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" CssClass="grid" OnPageIndexChanging ="ExportPermitGridView_PageIndexChanging" OnSelectedIndexChanged = "OnInvoiceSelectedIndexChanged" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" >        
                    <Columns>
                        <asp:BoundField DataField="referenceCode" ItemStyle-wrap="true" HeaderStyle-Width ="105px" ItemStyle-Width ="105px"  HeaderText="Reference Code" />
                        <asp:BoundField DataField="exportPermitName" ItemStyle-wrap="true" HeaderText="Quarter" />
                        <asp:BoundField DataField="exporterName" ItemStyle-wrap="true" HeaderText="Exporter" HeaderStyle-Width ="164px" ItemStyle-Width ="164px"/>
                        <asp:BoundField DataField="productName" ItemStyle-wrap="true" HeaderText="Product" /> 
                        <asp:TemplateField ItemStyle-wrap="true" ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass ="right-align" HeaderStyle-Width ="63px" ItemStyle-Width ="65px" HeaderText="Quantity" > 
                            <ItemTemplate>
                                <asp:Label ID="quantity" runat ="server" Text='<%# DataBinder.Eval(Container.DataItem, "quantity", "{0:#,#0}")%>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-wrap="true" ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass ="right-align" HeaderStyle-Width="100" ItemStyle-Width="100" HeaderText="Amt. Per Bll ($)" > 
                            <ItemTemplate>
                                <asp:Label ID="amountPerBarrel" runat ="server" Text='<%# DataBinder.Eval(Container.DataItem, "amountPerBarrelUS", "{0:#,#0.00}")%>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-wrap="true" ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass ="right-align" HeaderStyle-Width="100" ItemStyle-Width="100" HeaderText="F.O.B Value ($)" > 
                            <ItemTemplate>
                                <asp:Label ID="TotalAMount" runat ="server" Text='<%# DataBinder.Eval(Container.DataItem, "totalAmountUS", "{0:#,#0.00}")%>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="applicationDate" ItemStyle-wrap="true" HeaderStyle-Width ="70px" ItemStyle-Width ="70px"  HeaderText="App. Date" />        
                        <asp:ButtonField DataTextField="approvalStatus" ControlStyle-BorderColor="Transparent" ItemStyle-BackColor="Transparent" HeaderText ="Status" ButtonType="Link" CommandName="Select" HeaderStyle-Width ="70" ItemStyle-Width="70" />


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
