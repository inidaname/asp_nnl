<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="WMDPortal._default32" %>


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
    <link rel="stylesheet" href="../js/jQuery-ui.css" />
    <script src="../js/jQuery1.10.js"></script>
    <script src="../js/jQuery-ui.js"></script>

    <script type="text/javascript"  lang="javascript">

        $(function () {
            $("#BillofLadingDate").datepicker({ dateFormat: 'dd-mm-yy' });

        });

        $(function () {
            $("#AcceptanceDate").datepicker({ dateFormat: 'dd-mm-yy' });

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
                        <li><asp:button ID="InstrumentServicesicon" UseSubmitBehavior ="false" runat ="server" style="background:url(../images/instruments.png) no-repeat 5px 10px scroll; background-size :20px 20px; " class="icon" Text ="Instrument Certification" /></li>
                        <li><asp:button ID="RegisterInstrumentIcon" UseSubmitBehavior ="false" runat ="server" style="background:url(../images/register-instrument.png) no-repeat 5px 10px scroll; background-size :20px 20px; " class="icon" Text ="Register Instrument" /></li>
                        <li class="active"><asp:button ID="ExportReturnIcon" UseSubmitBehavior ="false" runat ="server" style="background:url(../images/import-export.png) no-repeat 5px 10px scroll; background-size :20px 20px; " class="icon" Text ="Export Return" /></li>
                        
                        <li><a style="background:url(../images/import-export.png) no-repeat 5px 10px scroll; background-size :20px 20px;color:rgb(200, 200, 200);" class="icon">Export Permit</a>
                            <ul>
                              <li><asp:button ID="ExportPermitIcon" UseSubmitBehavior ="false" runat ="server" style="background:url(../images/import-export.png) no-repeat 5px 10px scroll; background-size :20px 20px;color:rgb(0,0,0);" class="icon" Text ="Export Permit Application"></asp:button></li>
                              <li><asp:button ID="RequirementIcon" UseSubmitBehavior ="false" runat ="server" style="background:url(../images/import-export.png) no-repeat 5px 10px scroll; background-size :20px 20px;color:rgb(0,0,0);" class="icon" Text ="Export Permit Requirements"></asp:button></li>

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
                   <span class ="left">EXPORT DATA RETURN UPLOAD FORM</span>
                 
            </div>

            
            <asp:Panel ID="ExportDataReturnPreviewPanel" runat ="server" style="width:100%;">
                <asp:Label ID="PreviewReturnID" runat="server" Visible ="false"></asp:Label>

                <asp:GridView ID="CompanyInformationGridView" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="1" CssClass="grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" >        
                         <Columns>
                             <asp:BoundField DataField="ProductionVolumeNetMT" ItemStyle-wrap="true" HeaderStyle-Width ="130px" ItemStyle-Width="130px" HeaderText="Production Volumes (MT)" />       
                         </Columns>
                </asp:GridView>

                
                <asp:GridView ID="ExportSummaryGridView" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="1" CssClass="grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" >        
                         <Columns>
                            <asp:TemplateField HeaderStyle-CssClass="hide" ItemStyle-Width="0" ItemStyle-Height="0" ItemStyle-CssClass="hide" HeaderStyle-Height="0" HeaderStyle-Width="0">
                                <HeaderTemplate>
                                    <th style="width:98.2%; height:30px;margin-top:-0px;text-align:left;text-transform:uppercase;">CRUDE OIL LIFTING STATISTICS</th>
                                </HeaderTemplate>
                               
                             </asp:TemplateField> 
                             
                             <asp:BoundField DataField="stream" ItemStyle-wrap="true" HeaderText="Stream" HeaderStyle-Height="32px"/>      
                             <asp:BoundField DataField="exportPermitVolumeNetBBL" ItemStyle-wrap="true"  HeaderStyle-Width ="130px" ItemStyle-Width="130px" HeaderText="Permit Volumes (BBL)" />       
                             <asp:BoundField DataField="exportPermitVolumeNetMT" ItemStyle-wrap="true" HeaderStyle-Width ="130px" ItemStyle-Width="130px" HeaderText="Permit Volumes (MT)" />       
                             <asp:BoundField DataField="exportVolumeNetBBL" ItemStyle-wrap="true" HeaderStyle-Width ="137px" ItemStyle-Width="134px" HeaderText="Expport Volumes (BBL)" />       
                             <asp:BoundField DataField="exportVolumeNetMT" ItemStyle-wrap="true" HeaderStyle-Width ="125px" ItemStyle-Width="125px" HeaderText="Export Volumes (MT)" />       
                             <asp:BoundField DataField="ProductionVolumeNetBBL" ItemStyle-wrap="true" HeaderStyle-Width ="137px" ItemStyle-Width="135px" HeaderText="Production Volumes (BBL)" />       
                             <asp:BoundField DataField="ProductionVolumeNetMT" ItemStyle-wrap="true" HeaderStyle-Width ="135px" ItemStyle-Width="135px" HeaderText="Production Volumes (MT)" />       
                         </Columns>
                </asp:GridView>



                <asp:GridView ID="ProceedsGridView" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="1" CssClass="grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" >        
                         <Columns>
                             <asp:TemplateField HeaderStyle-CssClass="hide" ItemStyle-Width="0" ItemStyle-Height="0" ItemStyle-CssClass="hide" HeaderStyle-Height="0" HeaderStyle-Width="0">
                                <HeaderTemplate>
                                    <th style="width:98.2%; height:30px;margin-top:-0px;text-align:left;text-transform:uppercase;"><%# Eval("exporter")%> CRUDE OIL EXPORT AND PROCEEDS</th>
                                </HeaderTemplate>
                               
                             </asp:TemplateField> 
                             <asp:BoundField DataField="bLadingDate" ItemStyle-wrap="true" HeaderText="B / Lading" HeaderStyle-Height="32px" />      
                             <asp:BoundField DataField="proceedVessel" ItemStyle-wrap="true" HeaderStyle-Width ="80px" ItemStyle-Width="80px" HeaderText="Permit Vol. BBL" />       
                             <asp:BoundField DataField="BSW" ItemStyle-wrap="true" HeaderStyle-Width ="82px" ItemStyle-Width="80px" HeaderText="Permit Vol. MT" />       
                             <asp:BoundField DataField="API" ItemStyle-wrap="true" HeaderStyle-Width ="80px" ItemStyle-Width="80px" HeaderText="Expport Vol. BBL" />       
                             <asp:BoundField DataField="netBarrel" ItemStyle-wrap="true" HeaderStyle-Width ="82px" ItemStyle-Width="80px" HeaderText="Export Vol. MT" />       
                             <asp:BoundField DataField="netTons" ItemStyle-wrap="true" HeaderStyle-Width ="80px" ItemStyle-Width="80px" HeaderText="Production Vol. BBL" />       
                             <asp:BoundField DataField="proceedsDestination" ItemStyle-wrap="true" HeaderStyle-Width ="82px" ItemStyle-Width="80px" HeaderText="Production Vol. MT" />       
                             <asp:BoundField DataField="proceedNGN" ItemStyle-wrap="true" HeaderStyle-Width ="80px" ItemStyle-Width="80px" HeaderText="Production Vol. MT" />       
                             <asp:BoundField DataField="proceedsDestination" ItemStyle-wrap="true" HeaderStyle-Width ="81px" ItemStyle-Width="80px" HeaderText="Production Vol. MT" />       
                             <asp:BoundField DataField="proceedUSD" ItemStyle-wrap="true" HeaderStyle-Width ="95px" ItemStyle-Width="93px" HeaderText="Production Vol. MT" />       
                         </Columns>
                </asp:GridView>

            
                <asp:GridView ID="LiftingGridView" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="1" CssClass="grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" >        
                         <Columns>
                             <asp:TemplateField HeaderStyle-CssClass="hide" ItemStyle-Width="0" ItemStyle-Height="0" ItemStyle-CssClass="hide" HeaderStyle-Height="0" HeaderStyle-Width="0">
                                <HeaderTemplate>
                                    <th style="width:98.2%; height:30px;margin-top:-0px;text-align:left;text-transform:uppercase;"><%# Eval("exporter")%> PRODUCTION AND EXPORT SUMMARY</th>
                                </HeaderTemplate>
                               
                             </asp:TemplateField> 
                             <asp:BoundField DataField="equityOwner" ItemStyle-wrap="true" HeaderStyle-Height="32px" HeaderText="Equity Owner" />       
                             <asp:BoundField DataField="liftingVessel" ItemStyle-wrap="true" HeaderStyle-Width ="82px" ItemStyle-Width="80px" HeaderStyle-Height="32px"  HeaderText="Vessel" />       
                             <asp:BoundField DataField="acceptanceDate" ItemStyle-wrap="true" HeaderStyle-Width ="80px" ItemStyle-Width="80px" HeaderStyle-Height="32px"  HeaderText="Acceptance Date" />       
                             <asp:BoundField DataField="agent" ItemStyle-wrap="true" HeaderStyle-Width ="80px" ItemStyle-Width="80px" HeaderStyle-Height="32px"  HeaderText="Agent" />       
                             <asp:BoundField DataField="cargoInspector" ItemStyle-wrap="true" HeaderStyle-Width ="83px" ItemStyle-Width="80px" HeaderStyle-Height="32px"  HeaderText="Cargo Inspector" />       
                             <asp:BoundField DataField="quantityLiftedGrossBBLS" ItemStyle-wrap="true" HeaderStyle-Width ="80px" ItemStyle-Width="80px" HeaderStyle-Height="32px"  HeaderText="Quantity (GrossBBLS)" />       
                             <asp:BoundField DataField="quantityLiftedNetBBLS" ItemStyle-wrap="true" HeaderStyle-Width ="80px" ItemStyle-Width="80px" HeaderStyle-Height="32px"  HeaderText="Quantity (NetBBLS)" />       
                             <asp:BoundField DataField="quantityLiftedNetMT" ItemStyle-wrap="true" HeaderStyle-Width ="83px" ItemStyle-Width="80px" HeaderStyle-Height="32px"  HeaderText="Quantity (NetMT)" />       
                             <asp:BoundField DataField="quantityLiftedNetAPI" ItemStyle-wrap="true" HeaderStyle-Width ="80px" ItemStyle-Width="80px" HeaderStyle-Height="32px"  HeaderText="Quantity (NetAPI)" />       
                             <asp:BoundField DataField="liftingDestination" ItemStyle-wrap="true" HeaderStyle-Width ="95" ItemStyle-Width="93px" HeaderStyle-Height="32px"  HeaderText="Destination" />       
                             
                         </Columns>
                </asp:GridView>


            </asp:Panel>

            

            <asp:Panel ID="ExportSummary" runat ="server" CssClass ="export-return-form">
                   
                <h3>PRODUCTION AND EXPORT SUMMARY</h3>
                
                <div class="form-group" style="margin-right:10px;">
                        <label for="Exporter" >Name of Exporter:</label>
                        <asp:TextBox ID="Exporter" runat ="server" CssClass ="single-input"></asp:TextBox>
                 </div>
       
                 
                <div class="form-group" style="margin-right:10px;float:right;">
                        <label for="ExportPermitID" >Export Permit ID:</label>
                        <asp:TextBox ID="ExportPermitID" runat ="server" CssClass ="single-input"></asp:TextBox>
                </div>
                         
       
                  <div class="form-group" style="margin-right:10px;float:right;">
                        <label for="ExportQuarter" >Export Quarter   /   Month:</label>
                        <asp:DropDownList ID="ExportQuarter" runat="server" CssClass="select-double" AutoPostBack="true">
                            <asp:ListItem Selected="True" Text="...Quarter..." value="" ></asp:ListItem>
                            <asp:ListItem Text="1st Quarter" value="" ></asp:ListItem>
                            <asp:ListItem Text="2nd Quarter" value="" ></asp:ListItem>
                            <asp:ListItem Text="3rd Quarter" value="" ></asp:ListItem>
                            <asp:ListItem Text="4th Quarter" value="" ></asp:ListItem>
                        </asp:DropDownList>

                        <asp:DropDownList ID="ExportMonth" runat="server" CssClass="select-double">
                            <asp:ListItem Selected="True" Text="...Month..." value="" ></asp:ListItem>
                            
                        </asp:DropDownList>


                 </div>

                <div class="form-group" style="margin-right:10px;">
                        <label for="SummaryStream" >Stream:</label>
                        <asp:TextBox ID="ReferenceID" Enabled="false" Visible="false" runat ="server" CssClass ="single-input"></asp:TextBox>
                        <asp:TextBox ID="SummaryStream" runat ="server" CssClass ="single-input"></asp:TextBox>
                 </div>
               
                 <div class="form-group" style="margin-right:10px;float:right;">
                        <label for="ExportPermitVolumes" >Export Permit Volumes:</label>
                        <asp:TextBox ID="ExportPermitVolumesNetBBL" runat ="server" CssClass ="double-input" Placeholder="NET BBL"></asp:TextBox>
                        <asp:TextBox ID="ExportPermitVolumesNetMT" runat ="server" CssClass ="double-input" Placeholder="NET MT"></asp:TextBox>
                 </div>
                 
                 <div class="form-group" style="margin-right:10px;float:right;">
                        <label for="ProductionVolumes" >Production Volumes:</label>
                        <asp:TextBox ID="ProductionVolumesNetBBL" runat ="server" CssClass ="double-input" Placeholder="NET BBL"></asp:TextBox>
                        <asp:TextBox ID="ProductionVolumesNetMT" runat ="server" CssClass ="double-input" Placeholder="NET MT"></asp:TextBox>
                 </div>

                                    
                 <div class="form-group" style="margin-right:10px;">
                        <label for="ExportVolumes" >Export Volumes:</label>
                        <asp:TextBox ID="ExportVolumesNetBBL" runat ="server" CssClass ="double-input" Placeholder="NET BBL"></asp:TextBox>
                        <asp:TextBox ID="ExportVolumesNetMT" runat ="server" CssClass ="double-input" Placeholder="NET MT"></asp:TextBox>
                 </div>
               
            </asp:Panel> 

            
            
            <asp:Panel ID="ExportProceeds" runat ="server" CssClass ="export-return-form">
                   
                <h3>CRUDE OIL EXPORT AND PROCEEDS</h3>
                
                <div class="form-group" style="margin-right:10px;">
                        <label for="BillofLadingDate" >Bill of Lading Date:</label>
                        <asp:TextBox ID="BillofLadingDate" runat ="server" CssClass ="single-input"></asp:TextBox>
                 </div>
       
                 <div class="form-group" style="margin-right:10px;float:right;">
                        <label for="BSW" >BSW:</label>
                        <asp:TextBox ID="BSW" runat ="server" CssClass ="single-input"></asp:TextBox>
                 </div>
         
                
                <div class="form-group" style="margin-right:10px;float:right;">
                        <label for="Vessel" >Vessel:</label>
                        <asp:TextBox ID="ProceedVessel" runat ="server" CssClass ="single-input"></asp:TextBox>
                 </div>

       
                 <div class="form-group" style="margin-right:10px;">
                        <label for="API" >API:</label>
                        <asp:TextBox ID="API" runat ="server" CssClass ="single-input"></asp:TextBox>
                 </div>
         
                
                <div class="form-group" style="margin-right:10px;float:right;">
                        <label for="NetMetricTons" >Net Metric Tons:</label>
                        <asp:TextBox ID="NetMetricTons" runat ="server" CssClass ="single-input"></asp:TextBox>
                 </div>
       
                 <div class="form-group" style="margin-right:10px;float:right;">
                        <label for="NetBarrels" >Net Barrels:</label>
                        <asp:TextBox ID="NetBarrels" runat ="server" CssClass ="single-input"></asp:TextBox>
                 </div>
         
                
                <div class="form-group" style="margin-right:10px;">
                        <label for="Destination" >Destination:</label>
                        <asp:TextBox ID="Destination" runat ="server" CssClass ="single-input"></asp:TextBox>
                 </div>
       
                 <div class="form-group" style="margin-right:10px;float:right;">
                        <label for="ProceedPriceDollar" >Proceeds @ REALIZED PRICE <span style="text-decoration:line-through;">N</span>:</label>
                        <asp:TextBox ID="ProceedPriceDollar" runat ="server" CssClass ="single-input"></asp:TextBox>
                 </div>
         
              
                 <div class="form-group" style="margin-right:10px;float:right;">
                        <label for="ProceedPriceNaira" >Proceeds @ REALIZED PRICE $:</label>
                        <asp:TextBox ID="ProceedPriceNaira" runat ="server" CssClass ="single-input"></asp:TextBox>
                 </div>
         
            </asp:Panel> 


            
            <asp:Panel ID="LiftingStatistics" runat ="server" CssClass ="export-return-form">
                   
                <h3>CRUDE OIL LIFTING STATISTICS</h3>
                
                <div class="form-group" style="margin-right:10px;">
                        <label for="CrudeType" >Crude Type:</label>
                        <asp:TextBox ID="CrudeType" runat ="server" CssClass ="single-input"></asp:TextBox>
                 </div>
       
                 <div class="form-group" style="margin-right:10px;float:right;">
                        <label for="StatisticsVessle" >Vessle:</label>
                        <asp:TextBox ID="LiftingVessle" runat ="server" CssClass ="single-input"></asp:TextBox>
                 </div>
                         
                <div class="form-group" style="margin-right:10px;float:right;">
                        <label for="EquityOwner" >Equity Owner:</label>
                        <asp:TextBox ID="EquityOwner" runat ="server" CssClass ="single-input"></asp:TextBox>
                 </div>
       
                 <div class="form-group" style="margin-right:10px;">
                        <label for="AcceptanceDate" >Acceptance Date:</label>
                        <asp:TextBox ID="AcceptanceDate" runat ="server" CssClass ="single-input"></asp:TextBox>
                 </div>
                         
                <div class="form-group" style="margin-right:10px;float:right;">
                        <label for="CargoInspector" >Cargo Inspector:</label>
                        <asp:TextBox ID="CargoInspector" runat ="server" CssClass ="single-input"></asp:TextBox>
                 </div>
       
                 <div class="form-group" style="margin-right:10px;float:right;">
                        <label for="Agent" >Agent:</label>
                        <asp:TextBox ID="Agent" runat ="server" CssClass ="single-input"></asp:TextBox>
                 </div>
         
                <div class="form-group" style="margin-right:10px;">
                        <label for="QuantitiesLifted" >Quantities Lifted:</label>
                        <asp:TextBox ID="QuantitiesLiftedGrossBBLS" runat ="server" CssClass ="double-input" Placeholder="GROSS BBLS"></asp:TextBox>
                        <asp:TextBox ID="QuantitiesLiftedNetBBLS" runat ="server" CssClass ="double-input" Placeholder="NET BBLS"></asp:TextBox>
                 </div>
               
          
                <div class="form-group" style="margin-right:10px;float:right;">
                        <label for="StatisticsDestination" >Destination:</label>
                        <asp:TextBox ID="LiftingDestination" runat ="server" CssClass ="single-input"></asp:TextBox>
                 </div>
       
              
                 <div class="form-group" style="margin-right:10px;float:right;">
                        <label for="QuantitiesLifted" >Quantities Lifted:</label>
                        <asp:TextBox ID="QuantitiesLiftedNetMT" runat ="server" CssClass ="double-input" Placeholder="NET MT"></asp:TextBox>
                        <asp:TextBox ID="QuantitiesLiftedNetAPI" runat ="server" CssClass ="double-input" Placeholder="NET API"></asp:TextBox>
                 </div>
               
         
            </asp:Panel> 


            <asp:Panel ID="ExportReturnButtons" runat ="server" CssClass ="export-return-form" height="70">
              <div class="form-group" style="width:100%;display:inline-block ; padding-top:10px;margin-top:-5px; margin-left:-10px;height:50px;float:left;">
                    <asp:Button ID="RefreshPage" runat ="server" UseSubmitBehavior="false" CssClass ="pay-button" Text ="Refresh Form"  />
                    <asp:Button ID="PreviewReturn" runat ="server" CssClass ="pay-button" Text ="Save & Continue" UseSubmitBehavior ="true"  />
                    <asp:Button ID="CancelExportDataReturn" runat ="server" UseSubmitBehavior="false" CssClass ="pay-button" Text ="Return to Form"  />
                    <asp:Button ID="SaveExportDataReturn" runat ="server" CssClass ="pay-button" Text ="Submit Form" UseSubmitBehavior ="true"  />

                </div> 
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
