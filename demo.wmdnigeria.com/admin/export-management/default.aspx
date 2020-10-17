<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="WMDPortal._default18" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Weight & Measures : Admin CPanel - Export History</title>

    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../css/menu.css" rel="stylesheet" type="text/css" />
    <link href="../../../images/icon.png" rel="icon" type="images/jpg" />
    <script type="text/javascript" src="../js/jQuery.js"></script>
    <script type="text/javascript" src="../js/tabScript.js"></script>

    <link rel="stylesheet" href="../js/jQuery-ui.css" />
    <script src="../js/jQuery1.10.js"></script>
    <script src="../js/jQuery-ui.js"></script>

</head>
 <body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="loading-progress">
                <div class="center"></div>
            </div>
        </ProgressTemplate>
        </asp:UpdateProgress>
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
                        <asp:Panel ID="CompanyManagementLink" runat="server" CssClass ="PanelDiv"><li style="background-image:url(../../../images/management.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a href="../company-management/"><span>Transaction Approval</span></a></li> </asp:Panel>
                        <asp:Panel ID="InstrumentManagementLink" runat="server" CssClass ="PanelDiv"><li style="background-image:url(../../../images/instrument.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a href="../instrument-management/"><span>Instrument History</span></a></li></asp:Panel>
                        <!-- <asp:Panel ID="StaticDataLink" runat="server" CssClass ="PanelDiv"><li style="background-image:url(../../../images/data.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a href="../career/"><span>Static Data</span></a></li></asp:Panel> -->
                        <asp:Panel ID="ExportPermitManagementLink" runat="server" CssClass ="PanelDiv"><li class="active" style="background-image:url(../../../images/data.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a href="./"><span>Export Permit History</span></a></li></asp:Panel>
                        <asp:Panel ID="ImportPermitManagementLink" runat="server" CssClass ="PanelDiv"><li style="background-image:url(../../../images/data.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a href="./"><span>Import Permit History</span></a></li></asp:Panel>
                        <asp:Panel ID="FileManagerLink" runat="server" CssClass ="PanelDiv"><li style="background-image:url(../../../images/file-manager.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a href="../file-manager/"><span>File Storage</span></a></li></asp:Panel>
                        <asp:Panel ID="ReportingLink" runat="server" CssClass ="PanelDiv"><li style="background-image:url(../../../images/reports.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a href="../reports/"><span>Report Pool</span></a></li></asp:Panel>
                        <asp:Panel ID="ExportDataLink" runat="server" CssClass ="PanelDiv"><li style="background-image:url(../../../images/export-data-return.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a href="../export-data/"><span>Export Return Data</span></a></li></asp:Panel>
                        <asp:Panel ID="HomePageTab" runat="server" CssClass ="PanelDiv"><li style="background-image:url(../../../images/table.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a href="../../../" target ="_blank"><span>Visit Homepage</span></a></li></asp:Panel>

                        <li style="background-image:url(../../../images/exit.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a >
                            <asp:Button ID="LogoutAdmin" runat="server" CssClass ="button-label" Text="Log Me Out" /></a></li>
                    </ul>
                </nav>


            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" EnableViewState ="true"  >
           <ContentTemplate>
            <div class="dashboard-container">
               
                        <div class ="dashboard-title">Export Permit History</div>
                           
                        <div class="dashboard-icon-container"> 
                            <div class="dashboard-icon-container-title">
                                <span style="float:left;margin-right:30px"><strong>Company Name: </strong></span>
                                 
                            <div class="form-group" style="width:20%;height:20px;float:left;margin:0px;margin-top:-5px;">
                                    <asp:DropDownList ID="SelectCompany" runat="server" AutoPostBack="true" OnSelectedIndexChanged="SelectCompany_SelectedIndexChanged"  CssClass="select">
                                        <asp:ListItem Selected="True" Text="...Select a Company" value="" ></asp:ListItem>
                                    </asp:DropDownList>

                            </div>
                                
                           <span style="float:left;margin-right:30px"><strong>Export Permit Quarter: </strong></span>
                                  
                            <div class="form-group" style="width:20%;height:20px;float:left;margin:0px;margin-top:-5px;">
                                    <asp:DropDownList ID="SelectQuarter" runat="server" CssClass="select">
                                        <asp:ListItem Selected="True" Text="...Select a Quarter..." value="" ></asp:ListItem>
                                        
                                    </asp:DropDownList>

                            </div>
                             <div class="form-group" style="width:20%;height:20px;float:left;margin:0px;margin-top:-5px;">
                                    <asp:Button ID="ShowPermitResult" runat="server" CssClass="button" OnClientClick="return true" Text="Show Permit Result"> </asp:Button>

                            </div>

                            </div>
                      
                             

                            <asp:Panel ID="ExportPermitViewPanel" runat ="server" style="margin-bottom:10px">

                                
                            <asp:Panel ID="ProcessingData" runat="server" class="loading"></asp:Panel>
                            <asp:Panel ID="NoRecord" runat="server" class="no-record"><span>No record found!</span></asp:Panel>

                            <asp:GridView ID="ExportPermitGridView" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="8" CssClass="grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" OnSelectedIndexChanged="OnExportSelectedIndexChanged">        
                                     <Columns>
                                         <asp:BoundField DataField="companyID" ItemStyle-wrap="true" HeaderStyle-Width ="5px" ItemStyle-Width ="5px" ItemStyle-Font-Size="2px" HeaderText="" ItemStyle-ForeColor="Transparent" />
                                         <asp:BoundField DataField="referenceCode" ItemStyle-wrap="true" HeaderStyle-Width ="106px" ItemStyle-Width ="105px"  HeaderText="Ref. No" />
                                         <asp:BoundField DataField="exportPermitName" ItemStyle-wrap="true" HeaderStyle-Width ="97px" ItemStyle-Width ="97px"  HeaderText="Quarter" />
                                         <asp:BoundField DataField="exporterName" ItemStyle-wrap="true" HeaderText="Exporter" HeaderStyle-Width ="120px" ItemStyle-Width ="120px"/>
                                         <asp:BoundField DataField="productName" ItemStyle-wrap="true" HeaderText="Product" HeaderStyle-Width ="70px" ItemStyle-Width ="70px"/> 
                                         <asp:BoundField DataField="exportPort" ItemStyle-wrap="true" HeaderText="Export Port" Visible ="false"/>
                                          <asp:TemplateField ItemStyle-wrap="true" ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass ="right-align" HeaderStyle-Width="77" ItemStyle-Width="79" HeaderText="Amount ($)" > 
                                            <ItemTemplate>
                                                <asp:Label ID="Quantity" runat ="server" Text='<%# DataBinder.Eval(Container.DataItem, "quantity", "{0:#,#}")%>' ></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:BoundField DataField="measure" ItemStyle-wrap="true"  HeaderStyle-Width ="52px" ItemStyle-Width ="50px" HeaderText="Measure" />
                                         <asp:TemplateField ItemStyle-wrap="true" ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass ="right-align" HeaderStyle-Width="77" ItemStyle-Width="77" HeaderText="Amount ($)" > 
                                            <ItemTemplate>
                                                <asp:Label ID="AmountPerBarrel" runat ="server" Text='<%# DataBinder.Eval(Container.DataItem, "amountPerBarrelUS", "{0:#,#0.00}")%>' ></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField ItemStyle-wrap="true" ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass ="right-align" HeaderStyle-Width="120" ItemStyle-Width="120" HeaderText="F.O.B Value ($)" > 
                                            <ItemTemplate>
                                                <asp:Label ID="FOBValue" runat ="server" Text='<%# DataBinder.Eval(Container.DataItem, "totalAmountUS", "{0:#,#0.00}")%>' ></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                          <asp:BoundField DataField="applicationDate" ItemStyle-wrap="true" HeaderStyle-Width ="70px" ItemStyle-Width ="70px"  HeaderText="App. Date" />        
                                         <asp:ButtonField Text="Select" ItemStyle-ForeColor ="DarkGray" HeaderText ="Action" CommandName="Select" HeaderStyle-Width ="50" ItemStyle-Width="50" />
                                     </Columns>
                            </asp:GridView>
 
                        </asp:Panel>
                    
                        <asp:Panel runat="server" ID="TabOverallContainer" class="container">

	                    <ul class="tabs">
                            <asp:Panel runat="server" ID="InspectionTab" CssClass="TabPanel">
		                        <li class="tab-link current" data-tab="tab-1">Inspection</li>
                            </asp:Panel>
                            <asp:Panel runat="server" ID="EndorsementTab" CssClass="TabPanel">
		                        <li class="tab-link" data-tab="tab-2">Endorsement</li>
                            </asp:Panel>
                            <asp:Panel runat="server" ID="RecommentionTab" CssClass="TabPanel">
		                        <li class="tab-link" data-tab="tab-3">Recommendation</li>
                            </asp:Panel>
                            <asp:Panel runat="server" ID="ApprovalTab" CssClass="TabPanel">
		                        <li class="tab-link" data-tab="tab-4">Approval</li>
                            </asp:Panel>
                            <asp:Panel runat="server" ID="EntryAuthorizationTab" CssClass="TabPanel">
		                        <li class="tab-link" data-tab="tab-5">Entry Authorization</li>
                            </asp:Panel>
                            <asp:Panel runat="server" ID="ProductLoadingTab" CssClass="TabPanel">
		                        <li class="tab-link" data-tab="tab-6">Loading</li>
                            </asp:Panel>
                            <asp:Panel runat="server" ID="ContainerExitTab" CssClass="TabPanel">
		                        <li class="tab-link" data-tab="tab-7">Exit</li>
                            </asp:Panel>

	                    </ul>

                        <asp:Panel runat="server" ID="InspectionContent" CssClass="TabPagesContent">
	                    <div id="tab-1" class="tab-content current">
                        <div class="export-management-container">

                        <div class="general-form" >
                                 
                        <div class="form-group" style="width:30%;margin-bottom:20px;">
                            <label for="ConformityCertificate" class ="label" >Inspection Officer:</label> 
                            <asp:TextBox ID="InspectionOfficer" runat="server" CssClass="input"></asp:TextBox>
                        </div>
  
                    
                        <div class="form-group" style="width:30%;margin-bottom:20px;"> 
                             <label for="InspectionStatus" class ="label" >Inspection Status:</label><br /> 
                             <span class="checkbox" style="font-weight:bolder;margin-top:6px; margin-right:35px;float:left;color:#000;width:115px;">Inspected</span>
                             <asp:CheckBox ID="InspectionStatus" GroupName="InspectionStatus" runat ="server" CssClass ="checkbox"></asp:CheckBox>
                        </div>
                  
                    
                         <div class="form-group" style="width:30%;margin-bottom:20px;">
                            <label for="InspectionDate" class ="label">Date:</label>
                            <asp:TextBox ID="InspectionDate" runat ="server" CssClass ="calendar-input"></asp:TextBox>
                            <asp:Button ID="InspectionDateButton" UseSubmitBehavior="false" onClientClick="return false;" runat="server" CssClass ="calendar-button"/>

                        </div>
                                             
                        <div class="form-group" style="width:30%;margin-bottom:20px;">
                            <label for="ProductDescription" class ="label" >Product Description:</label> 
                            <asp:TextBox ID="ProductDescription" runat="server" CssClass="input-flat"></asp:TextBox>
                        </div>

                             
                        <div class="form-group" style="width:30%;margin-bottom:20px;">
                            <label for="PeriodCoverFrom" class ="label" >Period Covered:-  From</label> 
                            <asp:TextBox ID="PeriodCoverFrom" runat="server" CssClass="input-flat"></asp:TextBox>
                        </div>

                        <div class="form-group" style="width:30%;margin-bottom:20px;">
                            <label for="PeriodCoverTo" class ="label" >To:</label> 
                            <asp:TextBox ID="PeriodCoverTo" runat="server" CssClass="input-flat"></asp:TextBox>
                        </div>

                             
                        <div class="form-group" style="width:60%;margin-bottom:20px;">
                            <label for="InspectionComment" class ="label" >Comment:</label> 
                            <asp:TextBox ID="InspectionComment" runat="server" TextMode="MultiLine" CssClass="textarea"></asp:TextBox>
                        </div>

                    
                        <div class="form-group" style="width:30%;display:inline-block ; margin-top:20px;">
                             <asp:Button ID="SaveInspection" runat ="server" CssClass ="pay-button-save" Text ="Save" />
                            <asp:Button ID="RejectInspection" runat ="server" CssClass ="pay-button-close" Text ="Reject"  />

                        </div> 

                        </div><!--General form -->
	                    </div>
	                    </div>
                        </asp:Panel>

                        <asp:Panel runat="server" ID="EndorsementContent" CssClass="TabPagesContent">
	                    <div id="tab-2" class="tab-content">
	                    <div class="export-management-container">
                    
                            <div class="general-form" >
                                 
                            <div class="form-group" style="width:30%;margin-bottom:20px;">
                                <label for="EndorsementPermitQuarter" class ="label" >Permit Quarter:</label> 
                                <asp:TextBox ID="EndorsementPermitQuarter" runat="server" CssClass="input-flat"></asp:TextBox>
                            </div>
  
                    
                            <div class="form-group" style="width:30%;margin-bottom:20px;"> 
                                 <label for="EndorsementStatus" class ="label" >Endorsement Status:</label><br /> 
                                 <span class="checkbox" style="font-weight:bolder;margin-top:6px; margin-right:35px;float:left;color:#000;width:115px;">Endorsed</span>
                                 <asp:CheckBox ID="EndorsementStatus" GroupName="EndorsementStatus" runat ="server" CssClass ="checkbox"></asp:CheckBox>
                            </div>
                  
                    
                             <div class="form-group" style="width:30%;margin-bottom:20px;">
                                <label for="EndorsementDate" class ="label">Date:</label>
                                <asp:TextBox ID="EndorsementDate" runat ="server" CssClass ="calendar-input"></asp:TextBox>
                                <asp:Button ID="EndorsementCalendarButton" runat="server" UseSubmitBehavior="false" onClientClick="return false;" CssClass ="calendar-button"/>

                            </div>
                                             
                            <div class="form-group" style="width:30%;float:right;margin-bottom:20px;margin-right:98px;">
                                <label for="EndorsedBy" class ="label" >Endorsed By:</label> 
                                <asp:TextBox ID="EndorsedBy" runat="server" CssClass="input"></asp:TextBox>
                            </div>

                            <div class="form-group" style="width:60%;float:left;margin-bottom:20px;">
                                <label for="EndorsementComment" class ="label" >Comment:</label> 
                                <asp:TextBox ID="EndorsementComment" runat="server" TextMode="MultiLine" CssClass="textarea"></asp:TextBox>
                            </div>

                    
                            <div class="form-group" style="width:50%;display:inline-block ; margin-top:20px;">
                                 <asp:Button ID="SaveEndorsement" runat ="server" CssClass ="pay-button-save" Text ="Save" />
                                <asp:Button ID="CancelEndorsement" runat ="server" CssClass ="pay-button-close" Text ="Cancel"  />

                            </div> 
                
	                        </div>
                        </div>
	                    </div>
	                    </asp:Panel>

                        <asp:Panel runat="server" ID="RecommendationContent" CssClass="TabPagesContent">
                        <div id="tab-3" class="tab-content">
                        <div class="export-management-container">

                            <div class="general-form" >
                                 
                            <div class="form-group" style="width:30%;margin-bottom:20px;">
                                <label for="RecommendationPermitQuarter" class ="label" >Permit Quarter:</label> 
                                <asp:TextBox ID="RecommendationPermitQuarter" runat="server" CssClass="input-flat"></asp:TextBox>
                            </div>
  
                    
                            <div class="form-group" style="width:30%;margin-bottom:20px;"> 
                                 <label for="RecommendationStatus" class ="label" >Recommendation Status:</label><br /> 
                                 <span class="RecommendationStatus" style="font-weight:bolder;margin-top:6px; margin-right:35px;float:left;color:#000;width:115px;">Recommended</span>
                                 <asp:CheckBox ID="RecommendationStatus" GroupName="RecommendationStatus" runat ="server" CssClass ="checkbox"></asp:CheckBox>
                            </div>
                  
                    
                             <div class="form-group" style="width:30%;margin-bottom:20px;">
                                <label for="EndorsementDate" class ="label">Date:</label>
                                <asp:TextBox ID="RecommendationDate" runat ="server" CssClass ="calendar-input"></asp:TextBox>
                                <asp:Button ID="RecommendationCalendarButton" runat="server" UseSubmitBehavior="false" onClientClick="return false;" CssClass ="calendar-button"/>

                            </div>
                                             
                            <div class="form-group" style="width:30%;float:right;margin-bottom:20px;margin-right:98px;">
                                <label for="RecommendationBy" class ="label" >Recommended By:</label> 
                                <asp:TextBox ID="RecommendationBy" runat="server" CssClass="input"></asp:TextBox>
                            </div>

                            <div class="form-group" style="width:60%;float:left;margin-bottom:20px;">
                                <label for="RecommendationComment" class ="label" >Comment:</label> 
                                <asp:TextBox ID="RecommendationComment" runat="server" TextMode="MultiLine" CssClass="textarea"></asp:TextBox>
                            </div>

                    
                            <div class="form-group" style="width:50%;display:inline-block ; margin-top:20px;">
                                 <asp:Button ID="SaveRecommendation" runat ="server" CssClass ="pay-button-save" Text ="Save" />
                                <asp:Button ID="CancelRecommendation" runat ="server" CssClass ="pay-button-close" Text ="Cancel"  />

                            </div> 
                
	                        </div>
	                    </div>
	                    </div>
	                    </asp:Panel><!-- container -->

                        <asp:Panel runat="server" ID="ApprovalContnet" CssClass="TabPagesContent">    
                        <div id="tab-4" class="tab-content">
                        <div class="export-management-container">

                    
                            <div class="general-form" >
                                 
                            <div class="form-group" style="width:30%;margin-bottom:20px;">
                                <label for="ApprovalPermitQuarter" class ="label" >Permit Quarter:</label> 
                                <asp:TextBox ID="ApprovalPermitQuarter" runat="server" CssClass="input-flat"></asp:TextBox>
                            </div>
  
                    
                            <div class="form-group" style="width:30%;margin-bottom:20px;"> 
                                 <label for="ApprovalStatus" class ="label" >Approval Status:</label><br /> 
                                 <span class="checkbox" style="font-weight:bolder;margin-top:6px; margin-right:35px;float:left;color:#000;width:115px;">Approved</span>
                                 <asp:CheckBox ID="ApprovalStatus" GroupName="ApprovalStatus" runat ="server" CssClass ="checkbox"></asp:CheckBox>
                            </div>
                  
                    
                             <div class="form-group" style="width:30%;margin-bottom:20px;">
                                <label for="EndorsementDate" class ="label">Date:</label>
                                <asp:TextBox ID="ApprovalDate" runat ="server" CssClass ="calendar-input"></asp:TextBox>
                                <asp:Button ID="ApprovalClandarButton" runat="server" UseSubmitBehavior="false" onClientClick="return false;" CssClass ="calendar-button"/>

                            </div>
                                             
                            <div class="form-group" style="width:30%;float:right;margin-bottom:20px;margin-right:98px;">
                                <label for="ApprovedBy" class ="label" >Approved By:</label> 
                                <asp:TextBox ID="ApprovedBy" runat="server" CssClass="input"></asp:TextBox>
                            </div>

                            <div class="form-group" style="width:60%;float:left;margin-bottom:20px;">
                                <label for="ApprovalComment" class ="label" >Comment:</label> 
                                <asp:TextBox ID="ApprovalComment" runat="server" TextMode="MultiLine" CssClass="textarea"></asp:TextBox>
                            </div>

                    
                            <div class="form-group" style="width:50%;display:inline-block ; margin-top:20px;">
                                 <asp:Button ID="SaveApproval" runat ="server" CssClass ="pay-button-save" Text ="Save" />
                                <asp:Button ID="RejectApproval" runat ="server" CssClass ="pay-button-close" Text ="Reject"  />

                            </div> 
                
	                        </div>
	                    </div>
	                    </div>
              
                    </asp:Panel><!-- container -->
            
                
                    <!-- This panels under are the ones added for FMTI, NCS, DPR and NAVY -->

                            <asp:Panel runat="server" ID="EntryAuthorization" CssClass="TabPagesContent">    
                        <div id="tab-5" class="tab-content">
                        <div class="export-management-container">

                    
                            <div class="general-form" >
                                 
                            <div class="form-group" style="width:30%;margin-bottom:20px;">
                                <label for="EntryPermitQuarter" class ="label" >Permit Quarter:</label> 
                                <asp:TextBox ID="EntryPermitQuarter" runat="server" CssClass="input-flat"></asp:TextBox>
                            </div>
  
                    
                            <div class="form-group" style="width:30%;margin-bottom:20px;"> 
                                 <label for="EntryStatus" class ="label" >Entry Status:</label><br /> 
                                 <span class="checkbox" style="font-weight:bolder;margin-top:6px; margin-right:35px;float:left;color:#000;width:115px;">Authorized</span>
                                 <asp:CheckBox ID="EntryStatus" GroupName="EntryStatus" runat ="server" CssClass ="checkbox"></asp:CheckBox>
                            </div>
                  
                    
                             <div class="form-group" style="width:30%;margin-bottom:20px;">
                                <label for="EndorsementDate" class ="label">Entry Date:</label>
                                <asp:TextBox ID="EntryDate" runat ="server" CssClass ="calendar-input"></asp:TextBox>
                                <asp:Button ID="AuthorizeEntryCal" runat="server" UseSubmitBehavior="false" onClientClick="return false;" CssClass ="calendar-button"/>

                            </div>
                                             
                            <div class="form-group" style="width:30%;float:right;margin-bottom:20px;margin-right:98px;">
                                <label for="AuthorizedBy" class ="label" >Entry Authorized By:</label> 
                                <asp:TextBox ID="AuthorizedBy" runat="server" CssClass="input"></asp:TextBox>
                            </div>

                            <div class="form-group" style="width:60%;float:left;margin-bottom:20px;">
                                <label for="AuthorizationComment" class ="label" >Comment:</label> 
                                <asp:TextBox ID="AuthorizationComment" runat="server" TextMode="MultiLine" CssClass="textarea"></asp:TextBox>
                            </div>

                    
                            <div class="form-group" style="width:50%;display:inline-block ; margin-top:20px;">
                                 <asp:Button ID="AuthorizeEntry" runat ="server" CssClass ="pay-button-save" Text ="Autorize Entry" />
                                <asp:Button ID="RejectAuthorization" runat ="server" CssClass ="pay-button-close" Text ="Reject Entry"  />

                            </div> 
                
	                        </div>
	                    </div>
	                    </div>
              
                    </asp:Panel><!-- container -->

                            <asp:Panel runat="server" ID="ProductLoading" CssClass="TabPagesContent">    
                        <div id="tab-6" class="tab-content">
                        <div class="export-management-container">

                    
                            <div class="general-form" >
                                 
                            <div class="form-group" style="width:30%;margin-bottom:20px;">
                                <label for="LoadingPermitQuarter" class ="label" >Permit Quarter:</label> 
                                <asp:TextBox ID="LoadingPermitQuarter" runat="server" CssClass="input-flat"></asp:TextBox>
                            </div>
  
                    
                            <div class="form-group" style="width:30%;margin-bottom:20px;"> 
                                 <label for="LoadingStatus" class ="label" >Loading Status:</label><br /> 
                                 <span class="checkbox" style="font-weight:bolder;margin-top:6px; margin-right:35px;float:left;color:#000;width:115px;">Loaded</span>
                                 <asp:CheckBox ID="LoadingStatus" GroupName="LoadingStatus" runat ="server" CssClass ="checkbox"></asp:CheckBox>
                            </div>
                  
                    
                             <div class="form-group" style="width:30%;margin-bottom:20px;">
                                <label for="LoadingDate" class ="label">Loading Date:</label>
                                <asp:TextBox ID="LoadingDate" runat ="server" CssClass ="calendar-input"></asp:TextBox>
                                <asp:Button ID="Button4" runat="server" UseSubmitBehavior="false" onClientClick="return false;" CssClass ="calendar-button"/>

                            </div>
                                             
                            <div class="form-group" style="width:30%;float:right;margin-bottom:20px;margin-right:98px;">
                                <label for="LoadedBy" class ="label" >Loading Approved By:</label> 
                                <asp:TextBox ID="LoadedBy" runat="server" CssClass="input"></asp:TextBox>
                            </div>

                            <div class="form-group" style="width:60%;float:left;margin-bottom:20px;">
                                <label for="LoaderComment" class ="label" >Comment:</label> 
                                <asp:TextBox ID="LoaderComment" runat="server" TextMode="MultiLine" CssClass="textarea"></asp:TextBox>
                            </div>

                    
                            <div class="form-group" style="width:50%;display:inline-block ; margin-top:20px;">
                                 <asp:Button ID="ApproveLoading" runat ="server" CssClass ="pay-button-save" Text ="Approve Loading" />
                                <asp:Button ID="DenyLoading" runat ="server" CssClass ="pay-button-close" Text ="Deny Loading"  />

                            </div> 
                
	                        </div>
	                    </div>
	                    </div>
              
                    </asp:Panel><!-- container -->
            

                        <asp:Panel runat="server" ID="ContainerExit" CssClass="TabPagesContent">    
                        <div id="tab-7" class="tab-content">
                        <div class="export-management-container">

                    
                            <div class="general-form" >
                                 
                            <div class="form-group" style="width:30%;margin-bottom:20px;">
                                <label for="ExitPermitQuarter" class ="label" >Permit Quarter:</label> 
                                <asp:TextBox ID="ExitPermitQuarter" runat="server" CssClass="input-flat"></asp:TextBox>
                            </div>
  
                    
                            <div class="form-group" style="width:30%;margin-bottom:20px;"> 
                                 <label for="ExitStatus" class ="label" >Exit Status:</label><br /> 
                                 <span class="checkbox" style="text-align:center;font-weight:bolder;margin-top:6px; margin-right:35px;float:left;color:#000;width:115px;">Exit</span>
                                 <asp:CheckBox ID="ExitStatus" GroupName="ExitStatus" runat ="server" CssClass ="checkbox"></asp:CheckBox>
                            </div>
                  
                    
                             <div class="form-group" style="width:30%;margin-bottom:20px;">
                                <label for="ExitDate" class ="label">Exit Date:</label>
                                <asp:TextBox ID="ExitDate" runat ="server" CssClass ="calendar-input"></asp:TextBox>
                                <asp:Button ID="Button7" runat="server" UseSubmitBehavior="false" onClientClick="return false;" CssClass ="calendar-button"/>

                            </div>
                                             
                            <div class="form-group" style="width:30%;float:right;margin-bottom:20px;margin-right:98px;">
                                <label for="ExitBy" class ="label" >Exit Approved By:</label> 
                                <asp:TextBox ID="ExitBy" runat="server" CssClass="input"></asp:TextBox>
                            </div>

                            <div class="form-group" style="width:60%;float:left;margin-bottom:20px;">
                                <label for="ExitComment" class ="label" >Comment:</label> 
                                <asp:TextBox ID="ExitComment" runat="server" TextMode="MultiLine" CssClass="textarea"></asp:TextBox>
                            </div>

                    
                            <div class="form-group" style="width:50%;display:inline-block ; margin-top:20px;">
                                 <asp:Button ID="ApproveExit" runat ="server" CssClass ="pay-button-save" Text ="Approve Exit" />
                                <asp:Button ID="DenyExit" runat ="server" CssClass ="pay-button-close" Text ="Deny Exit"  />

                            </div> 
                
	                        </div>
	                    </div>
	                    </div>
              
                    </asp:Panel><!-- container -->
            
                
                
            
                
                    
                        <div style="float:left;margin-top:30px;" class="dashboard-icon-container-title">
                            <span style="font-weight:bolder ">Application Status: 
                                <asp:Label runat="server" ID="ApplicationStatusText" style="color:#930505;font-weight:bolder">Incomplete Application!</asp:Label>

                            </span>
                     

                            <div class="form-group" style="float:right; margin-right:100px;"> 
                                    <asp:RadioButton ID="NonTerminalOperator" GroupName="TerminalOperator" runat ="server" CssClass ="checkbox"></asp:RadioButton>
                                    <span class="checkbox" style="text-align:center;font-weight:bolder;margin-top:-2px; width:94%;margin-right:35px;">Non Terminal Operator</span>
                            </div>

                            <div class="form-group"  style="float:right;">
                                <asp:RadioButton ID="TerminaOperator" GroupName ="TerminalOperator" runat ="server" CssClass ="checkbox"></asp:RadioButton>
                                <span class="checkbox" style="text-align:center;font-weight:bolder;margin-top:-2px; width:94%;margin-right:35px;">Terminal Operator</span>
                             </div>
                           
                        </div>
                      
                        <asp:Panel runat="server" ID="ApplicationStatus" CssClass="application-status-panel general-form">  
                                                    
                        <div class="form-group" style="width:100%">
                            <label for="CertificateOfIncorporation" class ="label" >Certificate of Incorporation of the applicant's company:</label> 
                            <asp:Button ID="CertificateOfIncorporation" runat="server" CssClass="mbtn" OnClick="CertificateOfIncorporation_Click" OnClientClick="NewWindow();" Text="View Uploaded File"></asp:Button>
                        </div>
                             
                        <div class="form-group" style="width:100%">
                            <label for="MemorandumOfAssociation" class ="label" >Company Article and Memorandum of Association</label> 
                            <asp:Button ID="MemorandumOfAssociation" runat="server" CssClass="mbtn" OnClick="MemorandumOfAssociation_Click" OnClientClick="NewWindow();" Text="View Uploaded File"></asp:Button>
                        </div>
                             
                        <div class="form-group" style="width:100%">
                            <label for="CurrentProduction" class ="label" >Current Production/Storage/Sales license issued by DPR</label> 
                            <asp:Button ID="CurrentProduction" runat="server" CssClass="mbtn" OnClick="CurrentProduction_Click" OnClientClick="NewWindow();" Text="View Uploaded File"></asp:Button>
                        </div>
                             
                        <div class="form-group" style="width:100%;margin-bottom:30px;">
                            <label for="ConformityCertificate" class ="label" >Current Weights and Measures Department certificate of conformity for the Fiscal Meters, Gauges, and all Custody Transfer Weighing & Measuring instruments at the terminal(s) to be used for the export	</label> 
                            <asp:Button ID="ConformityCertificate" runat="server" CssClass="mbtn" OnClick="ConformityCertificate_Click" OnClientClick="NewWindow();" Text="View Uploaded File"></asp:Button>
                        </div>
                             
                        <div class="form-group" style="width:100%">
                            <label for="BankReference" class ="label" >Original Bank reference with committed and explicit statements</label> 
                            <asp:Button ID="BankReference" runat="server" CssClass="mbtn" OnClick="BankReference_Click" OnClientClick="NewWindow();" Text="View Uploaded File"></asp:Button>
                        </div>
                     
                        <div class="form-group" style="width:100%">
                            <label for="ClearanceCertificate" class ="label" >3-Years Tax Clearance Certificate</label> 
                            <asp:Button ID="ClearanceCertificate" runat="server" CssClass="mbtn" OnClick="ClearanceCertificate_Click" OnClientClick="NewWindow();"  Text="View Uploaded File"></asp:Button>
                        </div>
                             
                        <div class="form-group" style="width:100%">
                            <label for="ExportPermitApplication" class ="label" >Attach Export Permit Application Document made to DPR	</label> 
                            <asp:Button ID="ExportPermitApplication" runat="server" CssClass="mbtn" OnClick="ExportPermitApplication_Click" OnClientClick="NewWindow();" Text="View Uploaded File"></asp:Button>
                        </div>
                              
                        <div class="form-group" style="width:100%">
                            <label for="EvidenceOfPayment" class ="label" ><span class="asterik"  >*</span> Evidence of Payment of Monitoring Fees</label> 
                            <asp:Button ID="EvidenceOfPayment" runat="server" CssClass="mbtn" OnClick="EvidenceOfPayment_Click" OnClientClick="NewWindow();" Text="View Uploaded File"></asp:Button>
                        </div>
                         </asp:Panel>
                        
                        </asp:Panel>





                    </div> 
               
                </div>
               </ContentTemplate>
                </asp:UpdatePanel>
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
