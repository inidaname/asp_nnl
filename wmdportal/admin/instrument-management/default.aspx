<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="WMDPortal._default19" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Weight & Measures : Admin CPanel - Instrument Management</title>

    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../css/menu.css" rel="stylesheet" type="text/css" />
    <link href="../../../images/icon.png" rel="icon" type="images/jpg" />
    <script type="text/javascript" src="../js/jQuery.js"></script>
    <script type="text/javascript" src="../js/tabScript.js"></script>

    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css" />
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>


</head>
 <body>
    <form id="form1" runat="server">
    <header>
        <div class="header">
            <div class="logo">WMD Nigeria CPanel</div>
            <asp:Label ID="loggedUser" runat="server" style="background-image:url(../../../images/arrow-down.png) ;background-repeat:no-repeat; background-position:right; background-size:15px 10px;" class="admin-loggedin" text="" />
        </div>
    </header>

        <div class="overall-container">
            <div class="sidebar">
                <nav>
                    <ul>
                        <asp:Panel ID="DashboardLink" runat="server" CssClass ="PanelDiv"><li  style="background-image:url(../../../images/dashboard.png) ;background-repeat:no-repeat; background-position: 10px 13px;  background-size:25px 25px; "><a href="../dashboard/"><span>Dashboard </span></a></li>  </asp:Panel>
                        <asp:Panel ID="CompanyManagementLink" runat="server" CssClass ="PanelDiv"><li style="background-image:url(../../../images/management.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a href="../company-management/"><span>Company Management</span></a></li> </asp:Panel>
                        <asp:Panel ID="InstrumentManagementLink" runat="server" CssClass ="PanelDiv"><li class="active" style="background-image:url(../../../images/instrument.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a href="./"><span>Instrument Management</span></a></li></asp:Panel>
                        <!-- <asp:Panel ID="StaticDataLink" runat="server" CssClass ="PanelDiv"><li style="background-image:url(../../../images/data.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a href="../career/"><span>Static Data</span></a></li></asp:Panel> -->
                        <asp:Panel ID="ExportPermitManagementLink" runat="server" CssClass ="PanelDiv"><li style="background-image:url(../../../images/data.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a href="../export-management/"><span>Export Permit Management</span></a></li></asp:Panel>
                        <asp:Panel ID="ImportPermitManagementLink" runat="server" CssClass ="PanelDiv"><li style="background-image:url(../../../images/data.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a href="./"><span>Import Permit Management</span></a></li></asp:Panel>
                        <asp:Panel ID="FileManagerLink" runat="server" CssClass ="PanelDiv"><li style="background-image:url(../../../images/file-manager.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a href="../file-manager/"><span>Document/File Management</span></a></li></asp:Panel>
                        <asp:Panel ID="ReportingLink" runat="server" CssClass ="PanelDiv"><li style="background-image:url(../../../images/reports.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a href="../reports/"><span>Report / Data Management</span></a></li></asp:Panel>
                        <asp:Panel ID="ExportDataLink" runat="server" CssClass ="PanelDiv"><li style="background-image:url(../../../images/export-data-return.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a href="../export-data/"><span>Export Data Return</span></a></li></asp:Panel>
                        <asp:Panel ID="HomePageTab" runat="server" CssClass ="PanelDiv"><li style="background-image:url(../../../images/table.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a href="../../../" target ="_blank"><span>Visit Homepage</span></a></li></asp:Panel>

                        <li style="background-image:url(../../../images/exit.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a >
                            <asp:Button ID="LogoutAdmin" runat="server" CssClass ="button-label" Text="Log Me Out" /></a></li>
                    </ul>
                </nav>


            </div>
            <div class="dashboard-container">
               
                <div class ="dashboard-title">Instrument Management</div>


                <div class="dashboard-icon-container"> 
                            <div class="dashboard-icon-container-title">
                                <span style="float:left;margin-right:30px"><strong>Company Name: </strong></span>
                                 
                            <div class="form-group" style="width:20%;height:20px;float:left;margin:0px;margin-top:-5px;">
                                    <asp:DropDownList ID="SelectCompany" runat="server" AutoPostBack="true" CssClass="select">
                                        <asp:ListItem Selected="True" Text="...Select a Company" value="" ></asp:ListItem>
                                    </asp:DropDownList>

                            </div>
                                
                           <span style="float:left;margin-right:30px"><strong>Registered Instrument: </strong></span>
                                  
                            <div class="form-group" style="width:20%;height:20px;float:left;margin:0px;margin-top:-5px;">
                                    <asp:DropDownList ID="SelectInstrument" runat="server" CssClass="select" OnSelectedIndexChanged="SelectCompany_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Text="...Select an Instrument..." value="" ></asp:ListItem>
                                        
                                    </asp:DropDownList>

                            </div>
                             <div class="form-group" style="width:20%;height:20px;float:left;margin:0px;margin-top:-5px;">
                                    <asp:Button ID="ShowPermitResult" runat="server" CssClass="button" Text="Show Instrument Result"> </asp:Button>

                            </div>

                            </div>

                                <asp:Panel ID="ProcessingData" runat="server" class="loading"></asp:Panel>
                                <asp:Panel ID="NoRecord" runat="server" class="no-record"><span>No record found!</span></asp:Panel>


                          <div style="width:100%;float:left;padding:0;margin:0;">
                          <asp:Panel ID="Panel1" runat ="server" style="margin-bottom:10px">
                              
                               
                                <asp:GridView ID="RegisteredInstrumentGridView" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="8" CssClass="grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"  OnSelectedIndexChanged="OnInstrumentSelectedIndexChanged" >        
                                 <Columns>
                                     <asp:BoundField DataField="deviceType" ItemStyle-wrap="true" ItemStyle-Width ="110px" HeaderStyle-Width ="110px" HeaderText="Instument" />
                                     <asp:BoundField DataField="InstrumentAndModel" ItemStyle-wrap="true" ItemStyle-Width ="135px" HeaderStyle-Width ="135px" HeaderText="Model Name" />
                                     <asp:BoundField DataField="manufactureNumber" ItemStyle-wrap="true" ItemStyle-Width ="92px" HeaderStyle-Width ="92px" HeaderText="Manufacturer" /> 
                                     <asp:BoundField DataField="serialNumber" ItemStyle-wrap="true" HeaderText="Serial No." />
                                     <asp:TemplateField ItemStyle-wrap="true" ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass ="right-align" HeaderStyle-Width="120" ItemStyle-Width="120" HeaderText="Amount" > 
                                        <ItemTemplate>
                                            <asp:Label ID="AMount" runat ="server" Text='<%# DataBinder.Eval(Container.DataItem, "deviceAmount", "{0:#,#0.00}")%>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:BoundField DataField="transCode" ItemStyle-wrap="true" ItemStyle-Width ="110px" HeaderStyle-Width ="110px"  HeaderText="Reg. Code" />       
                                     <asp:BoundField DataField="registrationDate" ItemStyle-wrap="true" HeaderText="Reg. Date" />       
                                     <asp:BoundField DataField="registrationTime" ItemStyle-wrap="true" HeaderText="Reg. Time" />
                                     <asp:ButtonField Text="Select" ItemStyle-ForeColor ="DarkGray" HeaderText ="Action" CommandName="Select" HeaderStyle-Width ="50" ItemStyle-Width="50" />       
                                 </Columns>
                            </asp:GridView>

                        </asp:Panel>
                    
                        </div><!--General form -->


                        <asp:Panel runat="server" ID="TabOverallContainer" class="container">
                          



	                    <ul class="tabs">
                            <asp:Panel runat="server" ID="Invoice" CssClass="TabPanel">
		                        <li class="tab-link current" data-tab="tab-1">Invoice</li>
                            </asp:Panel>
                            <asp:Panel runat="server" ID="VerificationSheet" CssClass="TabPanel">
		                        <li class="tab-link" id="tab2" data-tab="tab-2">Verification Sheet</li>
                            </asp:Panel>
                            <asp:Panel runat="server" ID="LegalNotices" CssClass="TabPanel">
		                        <li class="tab-link" data-tab="tab-3">Legal Notices</li>
                            </asp:Panel>
                            

	                    </ul>

                        <asp:Panel runat="server" ID="InspectionContent" CssClass="TabPagesContent">
	                    <div id="tab-1" class="tab-content current">
                        <div class="export-management-container">

                        <div style="width:100%;float:left;padding:0;margin:0;">
                            
                            <asp:GridView ID="InstrumentInvoiceGridView" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="8" CssClass="grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" >        
                                 <Columns>
                                     <asp:BoundField DataField="companyName" ItemStyle-CssClass="left-align" ItemStyle-wrap="true" ItemStyle-Width ="180px" HeaderStyle-Width ="180px" HeaderText="Company" />
                                     <asp:BoundField DataField="transCode" ItemStyle-wrap="true" ItemStyle-Width ="130px" HeaderStyle-Width ="130px" HeaderText="Instrument ID" />
                                     <asp:BoundField DataField="narration" ItemStyle-CssClass="left-align" ItemStyle-wrap="true" ItemStyle-Width ="245px" HeaderStyle-Width ="245px" HeaderText="Description" />
                                     <asp:TemplateField ItemStyle-wrap="true" ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass ="right-align" HeaderStyle-Width="100" ItemStyle-Width="100" HeaderText="Amount" > 
                                        <ItemTemplate>
                                            <asp:Label ID="AMount" runat ="server" Text='<%# DataBinder.Eval(Container.DataItem, "amountDue", "{0:#,#0.00}")%>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:BoundField DataField="invoiceDate" ItemStyle-wrap="true" ItemStyle-Width ="65px" HeaderStyle-Width ="65px" HeaderText="Date" />       
                                     <asp:BoundField DataField="invoiceTime" ItemStyle-wrap="true" ItemStyle-Width ="65px" HeaderStyle-Width ="65px" HeaderText="Time" />  
                                     <asp:BoundField DataField="paymentMode" ItemStyle-wrap="true" HeaderText="Mode" />
                                 </Columns>
                            </asp:GridView>                    
                        </div><!--General form -->
	                    </div>
	                    </div>
                        </asp:Panel>

                        <asp:Panel runat="server" ID="EndorsementContent" CssClass="TabPagesContent">
	                    <div id="tab-2" class="tab-content">
	                    <div class="export-management-container">
                    
                            <div class="general-form" >
                                 
                            <div class="form-group" style="width:30%;margin-bottom:20px;">
                                <label for="StandardGuage" class ="label" >Standard Guage:</label> 
                                <asp:TextBox ID="StandardGuage" runat="server" CssClass="input"></asp:TextBox>
                            </div>
  
                             <div class="form-group" style="width:30%;margin-bottom:20px;">
                                <label for="VerifiedGuage" class ="label">Verified Guage:</label>
                                <asp:TextBox ID="VerifiedGuage" runat ="server" CssClass ="input"></asp:TextBox>

                            </div>
                                 
                             <div class="form-group" style="width:30%;margin-bottom:20px;">
                                <label for="GuageName" class ="label">Guage Name:</label>
                                <asp:TextBox ID="GuageName" runat ="server" CssClass ="input"></asp:TextBox>

                            </div>
                                             
                                  
                             <div class="form-group" style="width:30%;margin-bottom:20px;">
                                <label for="Instrument" class ="label" >Instrument Serial No:</label>
                                <asp:TextBox ID="Instrument" runat ="server" Enabled ="false"  CssClass="input-flat" ></asp:TextBox>

                            </div>
                                           
                             <div class="form-group" style="width:30%;margin-bottom:20px;">
                                <label for="VerificationDate" class ="label">Verification Date:</label>
                                <asp:TextBox ID="VerificationDate" runat ="server" CssClass ="input"></asp:TextBox>

                            </div>
                            
                            <div class="form-group" style="width:30%;float:left;margin-bottom:20px;margin-right:98px;">
                                <label for="InstrumentTag" class ="label" >Instrument Status:</label> 
                                <asp:DropDownList ID="InstrumentTag" runat="server" CssClass="select">

                                </asp:DropDownList>
                            </div>

                            <div class="form-group" style="width:92%;height:150px;float:left;margin-bottom:20px;">
                                <label for="Comment" class ="label" >Comment:</label> 
                                <asp:TextBox ID="Comment" runat="server" TextMode="MultiLine" Height="150" CssClass="textarea"></asp:TextBox>
                            </div>

                    
                            <div class="form-group" style="width:50%;display:inline-block ; margin-top:20px;">
                                 <asp:Button ID="SaveInstrument" runat ="server" CssClass ="pay-button-save" Text ="Save Instrument" />
                                <asp:Button ID="CanselInstrument" runat ="server" CssClass ="pay-button-close" Text ="Cancel Verification"  />

                            </div> 
                
	                        </div>
                        </div>
	                    </div>
	                    </asp:Panel>

                        <asp:Panel runat="server" ID="RecommendationContent" CssClass="TabPagesContent">
                        <div id="tab-3" class="tab-content">
                        <div class="export-management-container">

                            <div class="general-form" >
                                 
                            <div class="form-group" style="width:42%;margin-bottom:20px;">
                                <label for="NoticesHeading" class ="label" >Notice Heading:</label> 
                                <asp:TextBox ID="NoticeHeading" runat="server" CssClass="input"></asp:TextBox>
                            </div>
  
                            <br />


                            <div class="form-group" style="width:60%;height:180px;float:left;margin-bottom:20px;">
                                <label for="NoticeBody" class ="label" >Legal Notice:</label> 
                                <asp:TextBox ID="NoticeBody" runat="server" TextMode="MultiLine" CssClass="textarea-big"></asp:TextBox>
                            </div>

                    
                            <div class="form-group" style="width:50%;display:inline-block ; margin-top:20px;">
                                 <asp:Button ID="SendLegalNotice" runat ="server" CssClass ="pay-button-save" Text ="Send Legal Notice" />
                                <asp:Button ID="CancelNotice" runat ="server" CssClass ="pay-button-close" Text ="Cancel Notice"  />

                            </div> 
                
	                        </div>
	                    </div>
	                    </div>
	                    </asp:Panel><!-- container -->

            
                </asp:Panel>
                
                          
                </div>
            </div>
            </div>
            


        <div class="copyright">
        <div class="copy">
            <div class="copyright-text">Copyright &copy; 2013 - 2015. All rights reserved. Developed by: John</div>
            <div class="social">
                <div class="social-img" style="background:url(../../../images/facebook.png) no-repeat; background-size:cover;" title="Like our Facebook Page"> </div>
                <div class="social-img" style="background:url(../../../images/twitter.png) no-repeat; background-size:cover;" title="Join our Twitter Conversation"> </div>
                <div class="social-img" style="height:20px; width: 20px; margin-top:2px; background:url(../../../images/youtube.png) no-repeat; background-size:20px 20px;"  title="Our Youtube Channel"> </div>
                <div class="social-img" style="background:url(../../../images/linkedin.png) no-repeat; background-size:cover;"  title="Connect with us on Linkedin"> </div>
                <div class="social-img" style="background:url(../../../images/cont.png) no-repeat; background-size:cover;"  title="Contact Us"> </div>
            </div>

        </div>
    </div>

     
    </form>
</body>
</html>
