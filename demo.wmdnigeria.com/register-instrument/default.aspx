<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="WMDPortal._default14" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Weight & Measures : Register Instrument</title>
    <meta name="author" content="Application Developed by: John Ojebode"/>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../css/menu.css" rel="stylesheet" type="text/css" />
    <link href="../images/icon.png" rel="icon" type="images/jpg" />
    <script src ="../js/jQuery.js" type ="text/javascript" ></script>
    <script src ="../js/tabScript.js" type ="text/javascript" ></script>
    
</head>
<body>
    <form id="RegistrationForm" runat ="server" enctype="multipart/form-data">
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
                        <li><asp:button ID="DepositIcon" UseSubmitBehavior ="false" runat ="server" style="background:url(../images/deposit.png) no-repeat 5px 10px scroll; background-size :20px 20px; " class="icon" Text ="e-Wallet" /></li>
                        <li><asp:button ID="UploadIcon" UseSubmitBehavior ="false" runat ="server" style="background:url(../images/upload.png) no-repeat 5px 10px scroll; background-size :20px 20px; " class="icon" Text ="Upload" /></li>
                        <li><asp:button ID="InstrumentServicesicon" UseSubmitBehavior ="false" runat ="server" style="background:url(../images/instruments.png) no-repeat 5px 10px scroll rgb(12, 76, 112); background-size :20px 20px; " class="icon" Text ="Instrument Certification" /></li>
                        <li class="active"><asp:button ID="RegisterInstrumentIcon" UseSubmitBehavior ="false" runat ="server" style="background:url(../images/register-instrument.png) no-repeat 5px 10px scroll; background-size :20px 20px; " class="icon" Text ="Register Instrument" /></li>
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
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    <div class="content">
        <asp:Panel ID="DepositPanel" runat ="server" CssClass ="content-container">

           
            <div class="title-bar">
                   <span class ="left">Instrument Registration Form</span>

                    
 	 	       <div class="form-group" style="float:left;height:20px">
                     <asp:CheckBox runat ="server" ID ="UseMyAddress" class="checkbox" value="Use Registered Date" AutoPostBack ="true" OnCheckedChanged ="UseMyAddress_CheckedChanged"/><span class="checkbox" style="color:#000">Use Another Address</span><br />

                </div>


 	 	       <div class="form-group" style="float:left;height:20px">
                    <asp:CheckBox runat ="server" ID ="BulkRegistratios" class="checkbox" value="Bulk" AutoPostBack ="true"/><span class="checkbox" style="color:#000">Bulk Instrument Registration</span><br />

                </div> 
                 
            </div>


            
            <div class ="general-form">

            <asp:panel ID="RegisteredAddress" runat ="server" class ="general-form">
            
                <h3>INSTRUMENT LOCATION</h3>

                 
                
                <div class="form-group" style="">
                        <label for="CompanyName" >Name of Company:</label>
                        <asp:TextBox ID="CompanyName" runat ="server" CssClass ="input"></asp:TextBox>
                 </div>

                 
                <div class="form-group" style="">
                        <label for="Email" >Email:</label>
                        <asp:TextBox ID="Email" runat ="server" CssClass ="input"></asp:TextBox>
                 </div>
 
                <div class="form-group" style="">
                        <label for="Addess" >Address:</label>
                        <asp:TextBox ID="Address" runat ="server" CssClass ="input" ></asp:TextBox>
                 </div>
 
                <div class="form-group" style="">
                        <label for="Website" >Website:</label>
                        <asp:TextBox ID="Website" runat ="server" CssClass ="input"></asp:TextBox>
                 </div>
 
                <div class="form-group" style="">
                        <label for="POBox" >P.O. Box:</label>
                        <asp:TextBox ID="POBox" runat ="server" CssClass ="input"></asp:TextBox>
                 </div>
 
                       
                <div class="form-group" style="">
                        <label for="State" >State:</label>
                        <asp:DropDownList ID="State" runat="server" AutoPostBack ="true" OnSelectedIndexChanged ="State_SelectedIndexChanged" CssClass="select">
                            <asp:ListItem Text="...Select State..." value="Export" ></asp:ListItem>

                        </asp:DropDownList>

                </div>
          

                <div class="form-group" style="">
                        <label for="LGA" >Local Government:</label>
                        <asp:DropDownList ID="LGA" runat="server" AutoPostBack ="true" OnSelectedIndexChanged ="LGA_SelectedIndexChanged" CssClass="select">
                            <asp:ListItem Text="...Select State..." value="Export" ></asp:ListItem>
                            
                        </asp:DropDownList>

                </div>
          

                <div class="form-group" style="">
                        <label for="City" >City:</label>
                        <asp:DropDownList ID="City" runat="server" AutoPostBack ="true" CssClass="select">
                            <asp:ListItem Text="...Select LGA..." value="Export" ></asp:ListItem>
                            
                        </asp:DropDownList>

                </div>

                </asp:panel> 
          

                <asp:panel ID="BulkRegistration" runat ="server" class ="general-form">
                    <h3>UPLOAD INSTRUMENT DETAILS</h3>
                  
                
                <div class="form-group" style="margin-top:10px; width:100%">
                    <label for="FileUpload" style="float:left;width:500px">Click this button to comfirm bulk regirstation!</label> 
                    <a class="mbtn" href="./#upload-bulk" style="float:left;">Bulk Registration</a>
                </div>

                
                </asp:panel> 

                
                    <!-- Modal for User logs -->
                    <div class="modal" id="upload-bulk" aria-hidden="true">
                      <div class="modal-dialog" style="width:550px; height:350px; left:55%; top: 25%;">
                        <div class="modal-header">
                          <h2>Bulk Instrument Registration</h2>
                          <a href="#close" class="btn-close" aria-hidden="true">×</a> <!--CHANGED TO "#close"-->
                        </div>
                        <div class="modal-body" >

                            <div class="form-container">
                                 <iframe src ="http://localhost/php/upload-instrument/?Session=ActiveFromAdmin" class="iframe" style="width:100%;height:470px;"></iframe>

                            </div>
                            
                             

                        </div>

                        <div class="modal-footer">
                          <a href="#close" class="mbtn-close">Cancel</a>  
                           <asp:Button ID="DownloadLogs" runat="server" text="Download Log Activities" class="mbtn"/>
                        </div>

                        </div>


                      </div>
                     <!-- /Modify User logs Activity -->
               
                    

                <asp:panel ID="SingleRegistration" runat ="server" class ="general-form">
              
                <h3>INSTRUMENT DETAILS</h3>
                <div style="font-size :12px;color:#f00;margin:0 70px; width:100%">IT IS AN OFFENSE PUNISHABLE BY LAW IF INSTRUMENTS USED FOR TRADE IN THE FEDERAL REPUBLIC OF NIGERIA ARE NOT REGISTERED.</div><br />

                

                <div class="form-group" style="">
                        <label for="Sector" >Sector:</label>
                        <asp:DropDownList ID="Sector" runat="server" AutoPostBack ="true" OnSelectedIndexChanged ="Sector_SelectedIndexChanged" CssClass="select">
                            <asp:ListItem Text="...Select Sector..." value="Export" ></asp:ListItem>
                            
                        </asp:DropDownList>

                </div>
          

                <div class="form-group" style="">
                        <label for="Instrument" >Instrument Category:</label>
                        <asp:DropDownList ID="Instrument" runat="server" AutoPostBack ="true" OnSelectedIndexChanged ="InstrumentCategory_SelectedIndexChanged" CssClass="select">
                            <asp:ListItem Text="...Select Category..." value="Export" ></asp:ListItem>
                            
                        </asp:DropDownList>
                        <asp:TextBox ID="InstrumentTxt" runat ="server" CssClass ="input"></asp:TextBox>

                </div>
          

                <div class="form-group" style="">
                        <label for="InstrumentType" >Instrument Type:</label>
                        <asp:DropDownList ID="InstrumentType" runat="server" AutoPostBack ="true" OnSelectedIndexChanged ="InstrumentType_SelectedIndexChanged" CssClass="select">
                            <asp:ListItem Text="...Select Instrument..." value="Export" ></asp:ListItem>
                            
                        </asp:DropDownList>

                        <asp:TextBox ID="InstrumentTypeTxt" runat ="server" CssClass ="input"></asp:TextBox>


                </div>
          
                <!-- This is to take off Unit of Measurement's field
                <div class="form-group" style="">
                        <label for="Measurement" >Unit of Measurement:</label>
                        <asp:DropDownList ID="Measurement" runat="server" AutoPostBack ="true" CssClass="select">
                            <asp:ListItem Text="...Select Instrument Type..." value="Export" ></asp:ListItem>
                            
                        </asp:DropDownList>

                </div>
                -->
                
                <asp:Panel ID="MeasurementRangePanel" runat="server" class="form-group" style="">
                        <label for="MeasurementRange" >Measurement Range:</label>
                        <asp:DropDownList ID="MeasurementRang" runat="server" AutoPostBack ="true" OnSelectedIndexChanged="MeasureRange_SelectedIndexChanged" CssClass="select">
                            <asp:ListItem Text="...Select Measurement Range..." value="Export" ></asp:ListItem>
                            
                        </asp:DropDownList>

                </asp:Panel>
           
                <asp:Panel ID="ActualMeasureRangePanel" runat="server" class="form-group" style="">
                        <label for="ActualMeasure" >Actual Measurement:</label>
                        <asp:TextBox ID="ActualMeasure" runat ="server" AutoPostBack ="true" OnTextChanged ="ValidateActualMeasure_SelectedIndexChanged" CssClass ="input"></asp:TextBox>
                 </asp:Panel>
 
 
                <div class="form-group" style="">
                        <label for="ModelNo" >Model No:</label>
                        <asp:TextBox ID="ModelNo" runat ="server" CssClass ="input"></asp:TextBox>
                 </div>
 
                <div class="form-group" style="margin-bottom:2px;margin-top:-10px">
                        <label for="SerialNo" >Serial / Tag No:</label>
                        <asp:TextBox ID="SerialNo" runat ="server" CssClass ="input"></asp:TextBox>
                 </div>
 
                <div class="form-group" style="margin-bottom:2px;margin-top:-10px">
                        <label for="Manufacturer" >Manufacturer:</label>
                        <asp:TextBox ID="Manufacturer" runat ="server"  CssClass ="input"></asp:TextBox>
                 </div>
 
                <div class="form-group" style="margin-bottom:2px;margin-top:-10px">
                        <label for="ModelName" >Model Name:</label>
                        <asp:TextBox ID="ModelName" runat ="server" CssClass ="input"></asp:TextBox>
                 </div>
 
                 <div class="form-group" style="margin-bottom:2px;margin-top:-10px">

                        <label for="Location" >Location:</label>
                        <asp:TextBox ID="Location" runat ="server" CssClass ="input"></asp:TextBox>
                 </div>

                

                    </asp:panel> 

                <div style="margin:0 auto; width:92%;">

                <h3> INSTRUMENT CERTIFICATE STATUS </h3>

 	 	       <div class="form-group" style="width:63%;margin-bottom:2px;margin-top:-10px">
                    <asp:RadioButton runat ="server" ID ="ApprovalCertificate" class="checkbox" AutoPostBack="true" OnCheckedChanged ="SelectCertificateToUpload_CheckedChanged" GroupName ="ApprovalCertificate" Text ="" value="Approval Certificate"/> <span class="checkbox" style="color:#000;">The Instrument has<span style="color:#f00;font-weight :bolder;">Pattern of Approval Certificate </span>  from the Weights and Measures Department</span><br />
                </div>


 	 	       <div class="form-group" style="width:30%;margin-bottom:2px;margin-top:-10px">
                     <asp:RadioButton runat ="server" ID ="ApplyForApproval" class="checkbox" AutoPostBack="true" OnCheckedChanged ="SelectCertificateToUpload_CheckedChanged"  GroupName ="ApprovalCertificate" value="Apply for Approval Certificate"/><span class="checkbox" style="color:#000">Apply For <span style="color:#f00;font-weight :bolder;">Pattern Of Approval Certificate</span> </span><br />

                </div>

 	 	       <div class="form-group" style="width:63%;margin-bottom:2px;margin-top:-10px">
                     <asp:RadioButton runat ="server" ID ="VerificationCertificate" class="checkbox" AutoPostBack="true" OnCheckedChanged ="SelectCertificateToUpload_CheckedChanged"  GroupName ="InitialCertificate" value="Initial Verification Certificate"/><span class="checkbox" style="color:#000">The instrument has <span style="color:#f00;font-weight :bolder;">Initial Verification Certificate </span>  and <span style="color:#f00;font-weight :bolder;">Periodic Verification Certificate</span> </span><br />
               </div> 
 	 	       <div class="form-group" style="width:30%;margin-bottom:2px;margin-top:-10px">
                    <asp:RadioButton runat ="server" ID ="ApplyForVerification" class="checkbox" AutoPostBack="true" OnCheckedChanged ="SelectCertificateToUpload_CheckedChanged"  GroupName ="InitialCertificate" value="Apply for Initial Certificate" /><span class="checkbox" style="color:#000">Apply For <span style="color:#f00;font-weight :bolder;">Initial Verification Certificate</span></span><br />

                </div> 

                <asp:Panel ID="ApplyForApprovalNowPanel" runat="server" Visible ="false" class="form-group" style="width:100%">
                <div class="form-group" style="width:100%;margin-bottom:2px;margin-top:50px">
                    <asp:CheckBox runat ="server" Checked ="true" ID ="ApplyForApprovalNow" class="checkbox" style="float:left;margin-top:0px;" /><span class="checkbox" style="color:#000;font-weight :bolder;margin-left:15px;margin-top:2px;float:left;">You will be redirected to  <span style="color:#f00;font-weight :bolder;"> Instrument Certification Page to apply for Pattern of Approval</span>,  <span style="color:#f00;font-weight :bolder;">UNCHEK</span>  the box to <span style="color:#f00;font-weight :bolder;">APPLY </span> later!</span><br />

                </div> 
                </asp:Panel> 

                <asp:Panel runat="server" ID="CertificateUploadPanel" style="width:100%;margin-top:50px;">
                 
                    <h3> UPLOAD CERTIFICATE(S)</h3>
                    
                <asp:Panel ID="ApprovalCertificateUploadPanel" runat="server" class="form-group" style="width:100%;">
                    <span><label for="PatternOfApprovalUpload" class ="label" style="float:left;width:200px;">Pattern of Approval Certificate </label> <asp:Label runat="server" ID="ApprovalPatternFileName" class ="label"  Text="" style="float:left;width:400px;"></asp:Label></span> 
                    <asp:FileUpload ID="PatternOfApprovalUpload" required runat="server" CssClass="input-flat"></asp:FileUpload>
                </asp:Panel>
                     
                <asp:Panel ID="InitialCertificateUploadPanel" runat="server"  class="form-group" style="width:100%">
                    <span><label for="PeriodicVerificationUpload" class ="label" style="float:left;width:200px;">Periodic Verification Certificate</label><asp:Label runat="server" ID="PeriodVerificationFileName" class ="label"  Text="" style="float:left;width:400px;"></asp:Label></span> 
                    <asp:FileUpload ID="PeriodicVerificationUpload" required runat="server" CssClass="input-flat"></asp:FileUpload>
                </asp:Panel>
                </asp:Panel><p><br>          

                <div class="form-group" style="float:left;width:65%;display:inline-block ; margin-top:17px;">
                     <asp:Button ID="CancelRegistration" runat ="server" CssClass ="mbtn-close" height="33" Text ="Cancel"  />
                     <asp:Button runat ="server" ID ="ContinueRegistration" CssClass ="pay-button-save"  Text ="Preview Application" style="margin-top:-5px;" OnClientClick="javascript:window.scrollTo(0,0);return confirm('This is a preview of your form, please make sure everything is in order before you click on Register!');"/>
                     <asp:Button runat ="server" ID ="RegisterInstrument" CssClass ="pay-button-save"  Text ="Register Instrument" Visible ="false" style="margin-top:-5px;" OnClientClick ="return confirm('Are you sure you want to Register this Instrument? Click okay to go ahead!')"/>
                     <asp:Button runat ="server" ID ="ModifyRegistration" CssClass ="pay-button"  Text ="Modify Form" style="margin-top:-5px;"  Visible ="false" />
                     <asp:Button runat ="server" ID ="SaveInstrument" CssClass ="pay-button-save"  Text ="Save Instrument" style="margin-top:-5px;" OnClientClick ="return confirm('Are you sure you want to Register this Instrument? Click okay to go ahead!')"/>

                </div> <br />
                
                </div>

            </div>


            <h3 style="height:20px;"></h3>
           
            <div class="title-bar" style="margin-right:50px;">
                   <span class ="left"> List of Registered Instrument(s) </span>
                   
                
                 <!--  
                <div class="form-group" style="width:200px;height:20px;float:left;">
                        <label for="FilterDeposit" >Filter:</label>
                        <asp:DropDownList ID="UploadFilter" runat="server" CssClass="select">
                            <asp:ListItem Selected="True" Text="All Documents" value="All" ></asp:ListItem>
                            <asp:ListItem Text="Export Data Returns" Value="Export"></asp:ListItem>
                            <asp:ListItem Text="PIA Export Data Returns" Value="PIA"></asp:ListItem>
                            <asp:ListItem Text="Other Documents" Value="Other"></asp:ListItem>

                        </asp:DropDownList>

                </div>
                                    
                <div class="form-group" style="margin-top:-5px; height:20px">
                     <asp:Button ID="FilterUploadButton" runat ="server"  CssClass ="button" Text ="Filter Files"  />

                </div> 
                -->
            </div>


            <asp:Panel ID="InvoiceViewPanel" runat ="server" style="margin-bottom:10px">
                <asp:GridView ID="RegisteredInstrumentGridView" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="15" OnPageIndexChanging="RegisteredInstrumentGridView_PageIndexChanging" CssClass="grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" >        
                         <Columns>
                           <asp:TemplateField HeaderStyle-CssClass ="check-head" ItemStyle-CssClass ="check"> 
                                <ItemTemplate>
                                  <asp:CheckBox ID="InstrumentSelector" runat="server" AutoPostBack ="true" onclick ="CheckOne(this)" OnCheckedChanged ="DisplaySelected_OnCheckedChanged"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:BoundField DataField="deviceModelName" ItemStyle-wrap="true" ItemStyle-Width ="200px" HeaderStyle-Width ="200px" ItemStyle-CssClass ="left-align" HeaderText="Instrument" />
                             <asp:BoundField DataField="modelNumber" ItemStyle-wrap="true" ItemStyle-Width ="122px" HeaderStyle-Width ="122px" ItemStyle-CssClass ="left-align"  HeaderText="Model No." /> 
                             <asp:BoundField DataField="serialNumber" ItemStyle-wrap="true" HeaderText="Serial No." ItemStyle-Width ="100px" HeaderStyle-Width ="100px" ItemStyle-CssClass ="left-align" />
                             <asp:TemplateField ItemStyle-wrap="true" ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass ="right-align" HeaderStyle-Width="150" ItemStyle-Width="150" HeaderText="Amount" > 
                            <ItemTemplate>
                                <asp:Label ID="AMount" runat ="server" Text='<%# DataBinder.Eval(Container.DataItem, "deviceAmount", "{0:#,#0.00}")%>' ></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                             <asp:BoundField DataField="transCode" ItemStyle-wrap="true" ItemStyle-Width ="110px" HeaderStyle-Width ="110px"  HeaderText="Reg. Code" />       
                             <asp:BoundField DataField="registrationDate" ItemStyle-wrap="true" HeaderText="Date" />       
                             <asp:BoundField DataField="registrationTime" ItemStyle-wrap="true" HeaderText="Time" />       
                         </Columns>
                    <PagerSettings Position="Bottom" Mode="NextPreviousFirstLast" FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Prev"/>
                </asp:GridView>

                 <p></p>
            <asp:Panel ID="FooterBar" runat ="server" CssClass="footer-bar">
                    <asp:Button ID="DeleteInstrument" runat ="server" tooltip="Click to delete selected instrument" OnClientClick ="return confirm('Are you sure you want to delete this instrument? Once deleted cannot be reversed!')" class ="pay-button" style="display:inline-block;float:left" text="Delete Selected"/> 
                    <asp:Button ID="ModifyInstrument" runat ="server" tooltip="Click to edit instrument detail" class ="pay-button" style="display:inline-block;float:left" text="Modify Instrument"/> 
                    <asp:Button ID="InstrumentProfile" runat ="server" Visible="false" tooltip="Click to view instrument detail" class ="pay-button" style="display:inline-block;float:left" text="Instrument Profile"/> 
                    <a href="../invoice/" id="PayAllLink" title="Click to Pay for All Invoices" class ="pay-button" style="display:inline-block;float:left" onclick ="return confirm('Are you sure you want to leave this page?')">Make Payment</a>
                 
            </asp:Panel> 

            </asp:Panel>
            
            </asp:Panel>

        
             
    </div>
     
</ContentTemplate>
     
</asp:UpdatePanel>

         


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
