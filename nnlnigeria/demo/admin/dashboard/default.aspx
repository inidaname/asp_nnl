<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="WMDPortal._default8" EnableViewState ="true"  ViewStateMode ="Enabled" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Weight & Measures : Admin CPanel</title>

   <link href="../css/style.css" rel="stylesheet" type="text/css" />
   <link href="../css/menu.css" rel="stylesheet" type="text/css" />
    <link href="../../../images/icon.png" rel="icon" type="images/jpg" />
    <script type="text/javascript" src="../js/jQuery.js"></script>
    <script type="text/javascript" src="../js/tabScript.js"></script>
   
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
                        <asp:Panel ID="DashboardLink" runat="server" CssClass ="PanelDiv"><li class="active"  style="background-image:url(../../../images/dashboard.png) ;background-repeat:no-repeat; background-position: 10px 13px;  background-size:25px 25px; "><a href="./"><span>Dashboard </span></a></li>  </asp:Panel>
                        <asp:Panel ID="CompanyManagementLink" runat="server" CssClass ="PanelDiv"><li style="background-image:url(../../../images/management.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a href="../company-management/"><span>Company Management</span></a></li> </asp:Panel>
                        <asp:Panel ID="InstrumentManagementLink" runat="server" CssClass ="PanelDiv"><li style="background-image:url(../../../images/instrument.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a href="../instrument-management/"><span>Instrument Management</span></a></li></asp:Panel>
                        <!-- <asp:Panel ID="StaticDataLink" runat="server" CssClass ="PanelDiv"><li style="background-image:url(../../../images/data.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a href="../career/"><span>Static Data</span></a></li></asp:Panel> -->
                        <asp:Panel ID="ExportPermitManagementLink" runat="server" CssClass ="PanelDiv"><li style="background-image:url(../../../images/data.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a href="../export-management/"><span>Export Permit Management</span></a></li></asp:Panel>
                        <asp:Panel ID="ImportPermitManagementLink" runat="server" CssClass ="PanelDiv"><li style="background-image:url(../../../images/data.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a href="./"><span>Import Permit Management</span></a></li></asp:Panel>
                        <asp:Panel ID="FileManagerLink" runat="server" CssClass ="PanelDiv"><li style="background-image:url(../../../images/file-manager.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a href="../file-manager/"><span>Document/File Management</span></a></li></asp:Panel>
                        <asp:Panel ID="ReportingLink" runat="server" CssClass ="PanelDiv"><li style="background-image:url(../../../images/reports.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a href="../reports/"><span>Report / Data Management</span></a></li></asp:Panel>
                        <asp:Panel ID="ExportDataLink" runat="server" CssClass ="PanelDiv"><li style="background-image:url(../../../images/export-data-return.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a href="../export-data/"><span>Export Data Return</span></a></li></asp:Panel>
                        <asp:Panel ID="HomePageTab" runat="server" CssClass ="PanelDiv"><li style="background-image:url(../../../images/table.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a href="../../../" target ="_blank" ><span>Visit Homepage</span></a></li></asp:Panel>

                        <li style="background-image:url(../../../images/exit.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a >
                            <asp:Button UseSubmitBehavior="false"  ID="LogoutAdmin" runat="server" CssClass ="button-label" Text="Log Me Out" /></a></li>
                    </ul>
                </nav>


            </div>
            <div class="dashboard-container">
                
                <div class ="dashboard-title">Control Panel (Dashboard)</div>
               
                <asp:Panel ID="UserPanel" runat="server">
                <div class="dashboard-icon-container"> <div class="dashboard-icon-container-title"><span><strong>Users: </strong>Manage admin and staff users - Create new user, modify user, Grant roles to user, </span></div>

                     <asp:Panel ID="CreateUser" runat="server"><a href="#create-user"><div class ="icon-wrapper">
                        <div class ="icon-image"  style="background:url(../../../images/profile.png) no-repeat; background-size:cover;"></div>
                         <div class ="icon-title">Create User</div>
                         <div class ="icon-brief">Create new admin user with user role</div>

                    </div></a></asp:Panel>

                    <asp:Panel ID="ModifyUser" runat="server"><a  href="#modify-user"><div class ="icon-wrapper">
                        <div class ="icon-image"  style="background:url(../../../images/modify-user.png) no-repeat; background-size:cover;"></div>
                         <div class ="icon-title">Modify User</div>
                         <div class ="icon-brief">Modify existing admin user with user role</div>

                    </div></a></asp:Panel>


                    <asp:Panel ID="UserLogs" runat="server"><a href="#user-logs"><div class ="icon-wrapper">
                        <div class ="icon-image"  style="background:url(../../../images/logs.png) no-repeat; background-size:cover;"></div>
                         <div class ="icon-title">User Logs</div>
                         <div class ="icon-brief">View or download user access to the software</div>

                    </div></a></asp:Panel>


                    <asp:Panel ID="BackLogs" runat="server"><a href="#back-logs"><div class ="icon-wrapper">
                        <div class ="icon-image"  style="background:url(../../../images/backlog.png) no-repeat; background-size:cover;"></div>
                         <div class ="icon-title">Back Logs</div>
                         <div class ="icon-brief">Upload data on the currently running website to new one</div>

                    </div></a></asp:Panel>

                </div>
                </asp:Panel>
                
                                
                <div class="dashboard-icon-container"> <div class="dashboard-icon-container-title"><span><strong>System Setup / Configuration: </strong>Manage admin and staff users - Create new user, modify user, Grant roles to user, </span></div> 
                     

                    <asp:Panel ID="LotTable" runat="server"><a href="#lot-table"><div class ="icon-wrapper">
                        <div class ="icon-image"  style="background:url(../../../images/table.png) no-repeat; background-size:cover;"></div>
                         <div class ="icon-title">Lot Table</div>
                         <div class ="icon-brief">Create new admin user with user role</div>

                    </div></a></asp:Panel>

                    
                    <asp:Panel ID="LotsAllocation" runat="server"><a href="#lots-allocation"><div class ="icon-wrapper">
                        <div class ="icon-image"  style="background:url(../../../images/allocation.png) no-repeat; background-size:cover;"></div>
                         <div class ="icon-title">Lots Allocation</div>
                         <div class ="icon-brief">Add and edit lot allocation for company</div>

                    </div></a></asp:Panel>


                    <asp:Panel ID="DownloadCenter" runat="server"><a href="#download-center"><div class ="icon-wrapper">
                        <div class ="icon-image"  style="background:url(../../../images/download.png) no-repeat; background-size:cover;"></div>
                         <div class ="icon-title">Download Center</div>
                         <div class ="icon-brief">Create new admin user with user role</div>

                    </div></a></asp:Panel>

                    
                    <asp:Panel ID="UploadNews" runat="server"><a href="#upload-news"><div class ="icon-wrapper">
                        <div class ="icon-image"  style="background:url(../../../images/news.png) no-repeat; background-size:cover;"></div>
                         <div class ="icon-title">Upload News</div>
                         <div class ="icon-brief">Create new admin user with user role</div>

                    </div></a></asp:Panel>

                                        
                    <asp:Panel ID="UploadPicture" runat="server"><a href="#upload-picture"><div class ="icon-wrapper">
                        <div class ="icon-image"  style="background:url(../../../images/picture-upload.png) no-repeat; background-size:cover;"></div>
                         <div class ="icon-title">Upload Picture</div>
                         <div class ="icon-brief">Create new admin user with user role</div>

                    </div></a></asp:Panel>
                      
                    <asp:Panel ID="setupOffice" runat="server"><a href="#setup-office"><div class ="icon-wrapper">
                        <div class ="icon-image"  style="background:url(../../../images/office.png) no-repeat; background-size:cover;"></div>
                         <div class ="icon-title">Setup Office</div>
                         <div class ="icon-brief">Create new admin user with user role</div>

                    </div></a></asp:Panel>

                                        
                    <asp:Panel ID="UploadQuiz" runat="server"><a href="#upload-quiz"><div class ="icon-wrapper">
                        <div class ="icon-image"  style="background:url(../../../images/quiz.png) no-repeat; background-size:cover;"></div>
                         <div class ="icon-title">Upload Quiz</div>
                         <div class ="icon-brief">Create new admin user with user role</div>

                    </div></a></asp:Panel>


                    <asp:Panel ID="UploadCareer" runat="server"><a href="#upload-career"><div class ="icon-wrapper">
                        <div class ="icon-image"  style="background:url(../../../images/career.png) no-repeat; background-size:cover;"></div>
                         <div class ="icon-title">Upload Career</div>
                         <div class ="icon-brief">Create new admin user with user role</div>

                    </div></a></asp:Panel>

                    
                    
                </div>


                
                <asp:Panel ID="StaticData" runat="server">
                <div class="dashboard-icon-container"> <div class="dashboard-icon-container-title"><span><strong>Static Data </strong>Manage static data - Upload state, LGA and cities, create and modify fee section and Instrument category </span></div>

                     <asp:Panel ID="UploadStates" runat="server"><a href="#upload-states"><div class ="icon-wrapper">
                        <div class ="icon-image"  style="background:url(../../../images/profile.png) no-repeat; background-size:cover;"></div>
                         <div class ="icon-title">Upload States</div>
                         <div class ="icon-brief">Create new admin user with user role</div>

                    </div></a></asp:Panel>

                    
                    <asp:Panel ID="Measurement" runat="server"><a href="#measurement"><div class ="icon-wrapper">
                        <div class ="icon-image"  style="background:url(../../../images/measurement.png) no-repeat; background-size:cover;"></div>
                         <div class ="icon-title">Measurement</div>
                         <div class ="icon-brief">Create new admin user with user role</div>

                    </div></a></asp:Panel>


                    <asp:Panel ID="UploadInstrument" runat="server"><a href="#upload-instrument"><div class ="icon-wrapper">
                        <div class ="icon-image"  style="background:url(../../../images/logs.png) no-repeat; background-size:cover;"></div>
                         <div class ="icon-title">Upload Instruments</div>
                         <div class ="icon-brief">View or download user access to the software</div>

                    </div></a></asp:Panel>

                    
                    <asp:Panel ID="FeeGroupSub" runat="server"><a href="#fee-group-sub"><div class ="icon-wrapper">
                        <div class ="icon-image"  style="background:url(../../../images/modify-user.png) no-repeat; background-size:cover;"></div>
                         <div class ="icon-title">Fee Group & Sub</div>
                         <div class ="icon-brief">Modify existing admin user with user role</div>

                    </div></a></asp:Panel>


                    <asp:Panel ID="FeeSection" runat="server"><a href="#fee-section"><div class ="icon-wrapper">
                        <div class ="icon-image"  style="background:url(../../../images/modify-user.png) no-repeat; background-size:cover;"></div>
                         <div class ="icon-title">Fee Section</div>
                         <div class ="icon-brief">Modify existing admin user with user role</div>

                    </div></a></asp:Panel>
                  
                    <asp:Panel ID="InstrumentFee" runat="server"><a href="#instrument-fee"><div class ="icon-wrapper">
                        <div class ="icon-image"  style="background:url(../../../images/fee.png) no-repeat; background-size:cover;"></div>
                         <div class ="icon-title">Instrument Fee</div>
                         <div class ="icon-brief">Create new admin user with user role</div>

                    </div></a></asp:Panel>
                     
                </div>
                </asp:Panel>


                

                 <!-- The File Manager section links starts here -->
                <asp:Panel ID="FileManagerPanel" runat="server">
                <div class="dashboard-icon-container"> <div class="dashboard-icon-container-title"><span><strong>File Manager: </strong>View and Download files uploaded by user and admins for analysis..</span></div> 
                    
                    
                    <asp:Panel ID="Panel2" runat="server"><a href="../file-manager/"><div class ="icon-wrapper">
                        <div class ="icon-image"  style="background:url(../../../images/export-data.png) no-repeat; background-size:cover;"></div>
                         <div class ="icon-title">Export Data</div>
                         <div class ="icon-brief">View  Export Data Return documents</div>

                    </div></a></asp:Panel>

                    <asp:Panel ID="Panel3" runat="server"><a href="../file-manager/"><div class ="icon-wrapper">
                        <div class ="icon-image"  style="background:url(../../../images/pia-documents.png) no-repeat; background-size:cover;"></div>
                         <div class ="icon-title">PIA Export Data</div>
                         <div class ="icon-brief">View PIA Export Data Return documents</div>

                    </div></a></asp:Panel>

                    <asp:Panel ID="Panel4" runat="server"><a href="../file-manager/"><div class ="icon-wrapper">
                        <div class ="icon-image"  style="background:url(../../../images/other-documents.png) no-repeat; background-size:cover;"></div>
                         <div class ="icon-title">Other Documents</div>
                         <div class ="icon-brief">View all documents uploaded to ungrouped folder by users</div>

                    </div></a></asp:Panel>

                    <asp:Panel ID="Panel5" runat="server"><a href="../file-manager/"><div class ="icon-wrapper">
                        <div class ="icon-image"  style="background:url(../../../images/admin-files.png) no-repeat; background-size:cover;"></div>
                         <div class ="icon-title">Admin Documents</div>
                         <div class ="icon-brief">View and download all the files uploaded by Admin</div>

                    </div></a></asp:Panel>
                     
                </div>
                </asp:Panel>

               

                <!-- The reporting section links starts here -->
                <asp:Panel ID="ReportingPanel" runat="server">
                <div class="dashboard-icon-container"> <div class="dashboard-icon-container-title"><span><strong>Reports: </strong>Generate report for all Activity - Generate company, instrument, import & export permit, audit and file reports!</span></div> 
                    
                    <asp:LinkButton runat="server" ID="CompanyReportLink" PostBackUrl="../reports/">
                    <asp:Panel ID="CompanyReport" runat="server"><a href="../reports/?LinkReportType=CompanyReport"><div class ="icon-wrapper">
                        <div class ="icon-image"  style="background:url(../../../images/company.png) no-repeat; background-size:cover;"></div>
                         <div class ="icon-title">Company Report</div>
                         <div class ="icon-brief">Generate and view registered company report</div>

                    </div></a></asp:Panel></asp:LinkButton>

                    <asp:Panel ID="InstrumentReport" runat="server"><a href="../reports/?LinkReportType=InstrumentReport"><div class ="icon-wrapper">
                        <div class ="icon-image"  style="background:url(../../../images/instrument-report.png) no-repeat; background-size:cover;"></div>
                         <div class ="icon-title">Instrument Report</div>
                         <div class ="icon-brief">Generate and view registered instrument report</div>

                    </div></a></asp:Panel>

                    <asp:Panel ID="ImportPermitReport" runat="server"><a href="../reports/?LinkReportType=ImportPermitReport"><div class ="icon-wrapper">
                        <div class ="icon-image"  style="background:url(../../../images/import-report.png) no-repeat; background-size:cover;"></div>
                         <div class ="icon-title">Import Permit</div>
                         <div class ="icon-brief">Generate and view import permit reports</div>

                    </div></a></asp:Panel>

                    <asp:Panel ID="ExportPermitReport" runat="server"><a href="../reports/?LinkReportType=ExportPermitReport"><div class ="icon-wrapper">
                        <div class ="icon-image"  style="background:url(../../../images/import-export.png) no-repeat; background-size:cover;"></div>
                         <div class ="icon-title">Export Permit</div>
                         <div class ="icon-brief">Generate and view export permit reports</div>

                    </div></a></asp:Panel>
                     
                    <asp:Panel ID="CompanyRequestReport" runat="server"><a href="../reports/?LinkReportType=CompanyRequest"><div class ="icon-wrapper">
                        <div class ="icon-image"  style="background:url(../../../images/request.png) no-repeat; background-size:cover;"></div>
                         <div class ="icon-title">Company Request</div>
                         <div class ="icon-brief">View and generate company requests report</div>

                    </div></a></asp:Panel>

                    <asp:Panel ID="NoticeOfContravention" runat="server"><a href="../reports/?LinkReportType=ContraventionNotice"><div class ="icon-wrapper">
                        <div class ="icon-image"  style="background:url(../../../images/contravention.png) no-repeat; background-size:cover;"></div>
                         <div class ="icon-title">Contravention Notc</div>
                         <div class ="icon-brief">View and generate notice of contravention report</div>

                    </div></a></asp:Panel>

 
                    <asp:Panel ID="InvoiceReport" runat="server"><a href="../reports/?LinkReportType=InvoiceReport"><div class ="icon-wrapper">
                        <div class ="icon-image"  style="background:url(../../../images/financial-report.png) no-repeat; background-size:cover;"></div>
                         <div class ="icon-title">Invoice Report</div>
                         <div class ="icon-brief">View and generate invoice reports</div>

                    </div></a></asp:Panel>

                </div>
                </asp:Panel>

                

                

                <!-- The Settings section links starts here -->
                <asp:Panel ID="SettingsPanel" runat="server">
                <div class="dashboard-icon-container"> <div class="dashboard-icon-container-title"><span><strong>Settings: </strong>Manage communication, notification, security settings for the system and manage user accounts</span></div> 
                    
                    <asp:Panel ID="PasswordRecovery" runat="server"><a href="#password-recovery"><div class ="icon-wrapper">
                        <div class ="icon-image"  style="background:url(../../../images/reset.png) no-repeat; background-size:cover;"></div>
                         <div class ="icon-title">Password Recovery</div>
                         <div class ="icon-brief">Reset forgotten password for User / Company</div>

                    </div></a></asp:Panel>

                    <asp:Panel ID="ComposeMail" runat="server"><a href="#compose-email"><div class ="icon-wrapper">
                        <div class ="icon-image"  style="background:url(../../../images/email_compose.png) no-repeat; background-size:cover;"></div>
                         <div class ="icon-title">Compose Mail</div>
                         <div class ="icon-brief">Compose an mail to send to User(s) or Admin User</div>

                    </div></a></asp:Panel>
                  
                    <asp:Panel ID="APIConfiguration" runat="server"><a href="#api-configuration"><div class ="icon-wrapper">
                        <div class ="icon-image"  style="background:url(../../../images/sms-icon.png) no-repeat; background-size:cover;"></div>
                         <div class ="icon-title">API Configuration</div>
                         <div class ="icon-brief">Set Bulk Short Messaging Services API Configuration</div>

                    </div></a></asp:Panel>

                    <asp:Panel ID="SendMessage" runat="server"><a href="#send-messages"><div class ="icon-wrapper">
                        <div class ="icon-image"  style="background:url(../../../images/sms.png) no-repeat; background-size:cover;"></div>
                         <div class ="icon-title">Send Messages</div>
                         <div class ="icon-brief">Send SMS Message(s) to Users or Admin Users</div>

                    </div></a></asp:Panel>

 
                </div>
                </asp:Panel>

                








                
               
            </div>

 
                    <!-- Modal for Admin Account creation -->
                    <div class="modal" id="create-user" aria-hidden="true">
                        <asp:ScriptManager ID="ScriptManager1" runat="server" />
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" EnableViewState ="true"  >
                        <ContentTemplate>
                      <div class="modal-dialog">
                        <div class="modal-header">
                          <h2>Create New Admin User?</h2>
                          <a href="#close" class="btn-close" aria-hidden="true">×</a> <!--CHANGED TO "#close"-->
                        </div>
                        <div class="modal-body">
                          
                        <div class="form-container">
                            
                            <h3 style="height:10px;width:100%;float:left;margin-bottom:5px;margin-top:2px;">LOGIN CREDENTIAL INFORMATION</h3>

                            
                            
                            <div class="form-group">
                                <label for="AccountType" >Account Type:</label>
                                <asp:DropDownList ID="AccountType" runat="server" AutoPostBack="true" OnSelectedIndexChanged ="AccountType_SelectedIndexChanged" CssClass="select">
                                    <asp:ListItem Selected="True" Text="---Select Account Type---" value=""  ></asp:ListItem>
                                    <asp:ListItem Text="Admin Account" Value="Admin"></asp:ListItem>
                                    <asp:ListItem Text="Staff Account" value="Staff"  ></asp:ListItem>
                                    <asp:ListItem Text="Other Organization Account" value="Other"  ></asp:ListItem>

 
                                </asp:DropDownList>

                             </div>

                            <div class="form-group">
                                <label for="Username" >Username:</label> 
                                <asp:TextBox ID="Username" runat="server" CssClass="input"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label for="Passsword" >Password: </label> 
                                <asp:TextBox ID="Password" runat="server" TextMode ="Password"  CssClass="input"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label for="ConfirmPassword" >Confirm Password:</label> 
                                <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"  CssClass="input"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label for="SecurityQuestion" >Security Question:</label>
                                <asp:DropDownList ID="SecurityQuestion" runat="server" CssClass="select">
                                    <asp:ListItem Selected="True" Text="---Select Question---" value="" ></asp:ListItem>
                                    <asp:ListItem Text="Pet's Name" Value="Pet"></asp:ListItem>
                                    <asp:ListItem Text="Model of first car used" Value="First car"></asp:ListItem>
                                    <asp:ListItem Text="Your favorite food" Value="Favorite food"></asp:ListItem>
                                    <asp:ListItem Text="Name of the street where you grow up" Value="Street where grow up"></asp:ListItem>

 
                                </asp:DropDownList>

                             </div>

                         
                            <div class="form-group">
                                <label for="SecurityAnswer" >Answer:</label> 
                                <asp:TextBox ID="SecurityAnswer" runat="server" CssClass="input"></asp:TextBox>
                            </div>
 

                        </div>



                        <div class="form-container">
                            
                            <h3 style="height:10px;width:100%;float:left;margin-bottom:5px;margin-top:2px;">USER INFORMATION</h3>

                            
                            <div class="form-group">
                                <label for="CompanyName" >Organization Name:</label> 
                                <asp:TextBox ID="CompanyName" runat="server" CssClass="input"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label for="Surname" >Surname:</label> 
                                <asp:TextBox ID="Surname" runat="server" CssClass="input"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label for="OtherNames" >Other Names: </label> 
                                <asp:TextBox ID="OtherNames" runat="server" CssClass="input"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label for="Address" >Address:</label> 
                                <asp:TextBox ID="Address" runat="server" CssClass="input"></asp:TextBox>
                            </div>

                                                    
                            <div class="form-group">
                                <label for="Mobile" >Mobile:</label> 
                                <asp:TextBox ID="Mobile" runat="server" CssClass="input"></asp:TextBox>
                            </div>
 
                            <div class="form-group">
                                <label for="EmailAddress" >Email Address:</label> 
                                <asp:TextBox ID="EmailAddress" runat="server" CssClass="input"></asp:TextBox>
                            </div>

                             
                        </div>



                        <div class="form-container">
                            
                            <h3 style="height:10px;width:100%;float:left;margin-bottom:5px;margin-top:2px;">USER ROLES</h3>

                            
                            <div class="check-group">
                                <asp:CheckBox ID="CompanyManagementRight" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Company Mgt</span>

                            </div>
                             
                            
                            <div class="check-group">
                                <asp:CheckBox ID="InstrumentManagementRight" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Instrument Mgt</span>

                            </div>
                             
                            
                            <div class="check-group">
                                <asp:CheckBox ID="StaticDataRights" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Static Data</span>

                            </div>

                             
                            <div class="check-group">
                                <asp:CheckBox ID="LotsManagementRight" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Lots Mgt</span>

                            </div>
                             
                            
                           
                            <div class="check-group">
                                <asp:CheckBox ID="InvoiceReportRight" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Invoice</span>

                            </div>

                             
                            <div class="check-group">
                                <asp:CheckBox ID="ReportsRight" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Reports</span>

                            </div>

                             
                             <div class="check-group">
                                <asp:CheckBox ID="ExportPermitManagement" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Exp. Permit Mgt</span>

                            </div>

                             <div class="check-group">
                                <asp:CheckBox ID="ImportPermitManagement" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Imp. Permit Mgt</span>

                            </div>
                            
                            <div class="check-group">
                                <asp:CheckBox ID="ExportImportExitRight" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Exp./ Imp. Exit</span>

                            </div>
                             
                            
                            <div class="check-group">
                                <asp:CheckBox ID="ExportImportLoadingRight" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Exp./ Imp. Loading</span>

                            </div>
                             
                            <div class="check-group">
                                <asp:CheckBox ID="ExportImportEntryRight" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Exp./ Imp. Entry</span>

                            </div>
                             
                            <div class="check-group">
                                <asp:CheckBox ID="ExportImportApprovalRight" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Exp./ Imp. Approval</span>

                            </div>
                             
                            <div class="check-group">
                                <asp:CheckBox ID="ExportImportEndorseRight" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Exp. / Imp. Endorse</span>

                            </div>

                            <div class="check-group">
                                <asp:CheckBox ID="ExportImportRecomendRight" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Exp. / Imp. Recommend</span>

                            </div>
                             
                            <div class="check-group">
                                <asp:CheckBox ID="ExportImportInspectionRight" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Exp. / Imp. Inspect</span>

                            </div>
                             
                            <div class="check-group">
                                <asp:CheckBox ID="DownloadManagerRight" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Download Manager</span>

                            </div>
                             
                            <div class="check-group">
                                <asp:CheckBox ID="UploadNewsRight" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Upload News</span>

                            </div>
                              
                            
                            <div class="check-group">
                                <asp:CheckBox ID="OtherDocumentsRight" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Other Documents</span>

                            </div>

                            <div class="check-group">
                                <asp:CheckBox ID="UploadPictureRight" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Upload Picture</span>

                            </div>

                            <div class="check-group">
                                <asp:CheckBox ID="SetupOfficeRight" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Setup Office</span>

                            </div>

                            <div class="check-group">
                                <asp:CheckBox ID="ArchiveAccessRight" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Archive Access</span>

                            </div>

                            <div class="check-group">
                                <asp:CheckBox ID="UploadQuizRight" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Upload Quiz</span>

                            </div>
                            
                            <div class="check-group">
                                <asp:CheckBox ID="UploadCareerRight" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Upload Career</span>

                            </div>
                              
                            
                            <div class="check-group">
                                <asp:CheckBox ID="InstrumentFeeRight" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Upload Instr. Fee</span>

                            </div>
                              
                            
                            <div class="check-group">
                                <asp:CheckBox ID="MeasurementRight" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Measurement</span>

                            </div>
                              
                            <div class="check-group">
                                <asp:CheckBox ID="Settings" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Settings</span>

                            </div>
                              
                            <div class="check-group">
                                <asp:CheckBox ID="ExportDataReturn" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Data Return</span>

                            </div>
                              
                        </div>

                        </div>

                        <div class="modal-footer">
                          <a href="#close" class="mbtn-close">Cancel</a>  <!--CHANGED TO "#close"-->
                          <asp:Button ID="RegisterNewAdmin" runat="server" text="Add Admin User" class="mbtn"/>
                        </div>

                        </div>

                            </ContentTemplate>
                            </asp:UpdatePanel>
                      </div>
                     <!-- /Create User Modal -->

                    
                    
                    <!-- Modal for Modify User -->
                    <div class="modal" id="modify-user" aria-hidden="true">
                      <div class="modal-dialog" style="width:700px; top: 5%;">
                        <div class="modal-header">
                          <h2>Modify Staff Account?</h2>
                          <a href="#close" class="btn-close" aria-hidden="true">×</a> <!--CHANGED TO "#close"-->
                        </div>
                        <div class="modal-body">
                          
                        <div class="form-container">
                            
 
                            <div class="form-group" style="width:96%">
                                

                             </div>
                            
                             
                        </div>

                            <div class="form-container">
                            
                            <h3>LOGIN CREDENTIAL INFORMATION</h3>

                            <div class="form-group">
                                <label for="SelectUser"  >Select User:</label>
                                <asp:DropDownList ID="SelectUser" runat="server" AutoPostBack ="true" OnSelectedIndexChanged ="AdminSelectUserIndex_Changed"  CssClass="select-flat">
                                    <asp:ListItem Selected="True" Text="---Select User to modify its account ---" value="" ></asp:ListItem>
                                     

 
                                </asp:DropDownList>
                            </div>

                            <div class="form-group">
                                <label for="Passsword" >New / Old Password: </label> 
                                <asp:TextBox ID="ModifyPassword" runat="server" TextMode ="Password"  CssClass="input-flat"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label for="ConfirmPassword" >Confirm Password:</label> 
                                <asp:TextBox ID="ModifyConfirmPassword" runat="server" TextMode="Password"  CssClass="input-flat"></asp:TextBox>
                            </div>

                            <div class="form-group" style="float:right; margin-right:17px;">
                                <label for="CompanyName" >Company Name:</label> 
                                <asp:TextBox ID="ModifyCompanyName" runat="server" CssClass="input-flat"></asp:TextBox>
                            </div>

                         
                            <div class="form-group" style="float:right">
                                <label for="ModifySecurityAnswer" >Answer:</label> 
                                <asp:TextBox ID="ModifySecurityAnswer" runat="server" CssClass="input-flat"></asp:TextBox>
                            </div>
 

                            <div class="form-group" style="float:right">
                                <label for="SecurityQuestion" >Security Question:</label>
                                <asp:DropDownList ID="ModifySecurityQuestion" runat="server" CssClass="select-flat">
                                    <asp:ListItem Selected="True" Text="---Select Question---" value="" ></asp:ListItem>
                                    <asp:ListItem Text="Company's Birthday" Value="Company Birthday"></asp:ListItem>
                                    <asp:ListItem Text="CEO's Middlename" Value="CEO Middlename"></asp:ListItem>
                                    <asp:ListItem Text="First MD" Value="First MD"></asp:ListItem>
                                    <asp:ListItem Text="First Office Address" Value="First Office Address"></asp:ListItem>
                                    <asp:ListItem Text="First Project" Value="First Project"></asp:ListItem>
                                    <asp:ListItem Text="REG Number" value="REG Number"  ></asp:ListItem>

 
                                </asp:DropDownList>

                             </div>

                        </div>



                        <div class="form-container">
                            
                            <h3>USER INFORMATION</h3>

                            <div class="form-group">
                                <label for="Surname" >Surname:</label> 
                                <asp:TextBox ID="ModifySurname" runat="server" CssClass="input-flat"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label for="OtherNames" >Other Names: </label> 
                                <asp:TextBox ID="ModifyOtherNames" runat="server" CssClass="input-flat"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label for="Address" >Address:</label> 
                                <asp:TextBox ID="ModifyAddress" runat="server" CssClass="input-flat"></asp:TextBox>
                            </div>

                                                    
                            <div class="form-group">
                                <label for="Mobile" >Mobile:</label> 
                                <asp:TextBox ID="ModifyMobile" runat="server" CssClass="input-flat"></asp:TextBox>
                            </div>
 
                            <div class="form-group">
                                <label for="EmailAddress" >Email Address:</label> 
                                <asp:TextBox ID="ModifyEmailAddress" runat="server" CssClass="input-flat"></asp:TextBox>
                            </div>

                            
                            <div class="form-group">
                                <label for="ModifyAccountType" >Account Type:</label>
                                <asp:DropDownList ID="ModifyAccountType" runat="server" CssClass="select-flat">
                                    <asp:ListItem Selected="True" Text="---Select Account Type---" value="" ></asp:ListItem>
                                    <asp:ListItem Text="Admin" Value="Admin Account"></asp:ListItem>
                                    <asp:ListItem Text="Staff" value="Staff Account"  ></asp:ListItem>

 
                                </asp:DropDownList>

                             </div>


                        </div>



                        <div class="form-container">
                            
                            <h3 style="height:10px;width:100%;float:left;margin-bottom:5px;margin-top:2px;">USER ROLES</h3>
                            
                            
                            <div class="check-group">
                                <asp:CheckBox ID="ModifyCompanyManagementRight" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Company Mgt</span>

                            </div>
                             
                            
                            <div class="check-group">
                                <asp:CheckBox ID="ModifyInstrumentManagementRight" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Instrument Mgt</span>

                            </div>
                             
                            
                            <div class="check-group">
                                <asp:CheckBox ID="ModifyStaticDataRight" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Static Data</span>

                            </div>

                             
                            <div class="check-group">
                                <asp:CheckBox ID="ModifyLotsManagementRight" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Lots Mgt</span>

                            </div>
                             
                            
                           
                            <div class="check-group">
                                <asp:CheckBox ID="ModifyInvoiceReportRight" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Invoice</span>

                            </div>

                             
                            <div class="check-group">
                                <asp:CheckBox ID="ModifyReportsRight" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Reports</span>

                            </div>

                             
                             <div class="check-group">
                                <asp:CheckBox ID="ModifyExportPermitManagement" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Exp. Permit Mgt</span>

                            </div>

                             <div class="check-group">
                                <asp:CheckBox ID="ModifyImportPermitManagement" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Imp. Permit Mgt</span>

                            </div>

                            
                            <div class="check-group">
                                <asp:CheckBox ID="ModifyExportImportExitRight" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Exp./ Imp. Exit</span>

                            </div>
                             
                            
                            <div class="check-group">
                                <asp:CheckBox ID="ModifyExportImportLoadingRight" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Exp./ Imp. Loading</span>

                            </div>
                             
                            
                            <div class="check-group">
                                <asp:CheckBox ID="ModifyExportImportEntryRight" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Exp./ Imp. Entry</span>

                            </div>
                             

                            <div class="check-group">
                                <asp:CheckBox ID="ModifyExportImportApprovalRight" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Exp./ Imp. Approval</span>

                            </div>
                             
                            <div class="check-group">
                                <asp:CheckBox ID="ModifyExportImportEndorseRight" runat="server"  ForeColor ="Transparent"/><span class ="checkboxs" >Exp. / Imp. Endorse</span>

                            </div>

                            <div class="check-group">
                                <asp:CheckBox ID="ModifyExportImportRecomendRight" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Exp. / Imp. Recommend</span>

                            </div>
                             
                            <div class="check-group">
                                <asp:CheckBox ID="ModifyExportImportInspectionRight" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Exp. / Imp. Inspect</span>

                            </div>
                             
                            <div class="check-group">
                                <asp:CheckBox ID="ModifyDownloadManagerRight" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Download Manager</span>

                            </div>
                             
                            <div class="check-group">
                                <asp:CheckBox ID="ModifyUploadNewsRight" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Upload News</span>

                            </div>
                              
                            
                            <div class="check-group">
                                <asp:CheckBox ID="ModifyOtherDocumentsRight" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Other Documents</span>

                            </div>

                            <div class="check-group">
                                <asp:CheckBox ID="ModifyUploadPictureRight" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Upload Picture</span>

                            </div>

                            <div class="check-group">
                                <asp:CheckBox ID="ModifySetupOfficeRight" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Setup Office</span>

                            </div>

                            <div class="check-group">
                                <asp:CheckBox ID="ModifyArchiveAccessRight" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Archive Access</span>

                            </div>

                            <div class="check-group">
                                <asp:CheckBox ID="ModifyUploadQuizRight" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Upload Quiz</span>

                            </div>
                            
                            <div class="check-group">
                                <asp:CheckBox ID="ModifyUploadCareerRight" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Upload Career</span>

                            </div>
                              
                            
                            <div class="check-group">
                                <asp:CheckBox ID="ModifyInstrumentFeeRight" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Upload Instr. Fee</span>

                            </div>
                              
                            
                            <div class="check-group">
                                <asp:CheckBox ID="ModifyMeasurementRight" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Measurement</span>

                            </div>
                            
                            <div class="check-group">
                                <asp:CheckBox ID="ModifySettings" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Settings</span>

                            </div>
                              
                            <div class="check-group">
                                <asp:CheckBox ID="ModifyExportDataReturn" runat="server" ForeColor ="Transparent"/><span class ="checkboxs" >Data Return</span>

                            </div>
                              
                             

                        </div>

                        </div>

                        <div class="modal-footer">
                          <a href="#close" class="mbtn-close">Cancel</a>   
                          <asp:Button ID="DeleteUser" runat="server" text="Delete User" OnClientClick ="return confirm('You are about to delete a user from the database, click okay to continue?')" class="mbtn-close"/>
                          <asp:Button ID="SaveUserInfo" runat="server" text="Save Details" OnClientClick ="return confirm('Are you sure you want to save this changes?')" class="mbtn"/>
                        </div>

                        </div>


                      </div>
                     <!-- /Modify User Modal -->
                                
                    <!-- Modal for User logs -->
                    <div class="modal" id="user-logs" aria-hidden="true">
                      <div class="modal-dialog" style="width:1050px; height:610px;padding:0px; top: 5%;left:38%;">
                        <div class="modal-header" style="margin-bottom:10px;height:40px;float:left;padding-top:5px;padding-bottom:5px;width:96%">
                          <h2 style="width:20%;float:left; height:20px">View User Log Activities</h2>
                          
                            
                            <div class="form-group" style="float:left;margin-left:30px;height:20px; margin-top:7px;display:inline;width:25%;">
                                <asp:DropDownList ID="SelectLogs" runat="server" CssClass="select">
                                    <asp:ListItem Selected="True" Text="User Logs" value="User" ></asp:ListItem>
                                    <asp:ListItem Text="Visitor Logs" value="Visitor"></asp:ListItem>
                                    
                                </asp:DropDownList>

                            </div>
                            <div class="form-group" style="float:left;margin-left:-45px;margin-top:7px;height:20px;width:20%;">
                                 <asp:Button ID="ViewLog" runat ="server"  CssClass ="button" Text ="View Logs"  />

                            </div> 

                          <a href="#close" style="margin-top:10px;margin-left:30px" class="btn-close" aria-hidden="true">×</a> <!--CHANGED TO "#close"-->
                        </div>

                        <div class="modal-body" style="padding:0px;margin:0px;">
                            <br />

                            <div class="form-container" style="float:left;margin-left:20px;">

                                
                                <asp:GridView ID="UserLogsGrid" runat="server" AutoGenerateColumns="false"  PageSize="8" AllowPaging="true" OnPageIndexChanging="UserLogsGrid_PageIndexChanging" CssClass="grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" >        
                                         <Columns>
                                             <asp:BoundField DataField="userID" ItemStyle-wrap="true" HeaderStyle-Width ="30" ItemStyle-Width="30" HeaderText="ID" />
                                             <asp:BoundField DataField="activity" ItemStyle-wrap="true" HeaderStyle-Width ="352" ItemStyle-Width="350" HeaderText="Activity" />
                                             <asp:BoundField DataField="IPAddress" ItemStyle-wrap="true" HeaderStyle-Width ="91" ItemStyle-Width="90"  HeaderText="IP Address" /> 
                                             <asp:BoundField DataField="machineName" ItemStyle-wrap="true" HeaderStyle-Width ="137" ItemStyle-Width="135" HeaderText="Machine Used" />
                                             <asp:BoundField DataField="userType" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width ="70" ItemStyle-Width="70" ItemStyle-wrap="true" HeaderText="User Type" />      
                                             <asp:BoundField DataField="logdate" ItemStyle-wrap="true" HeaderText="Date" />        
                                             <asp:BoundField DataField="logtime" ItemStyle-wrap="true" HeaderText="Time" />        
                                               
                                         </Columns>
                                        <PagerSettings Position="Bottom" Mode="NextPreviousFirstLast" FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Prev"/>
                                </asp:GridView>

                                 
                                <asp:GridView ID="VisitorLogsGrid" runat="server" AutoGenerateColumns="false"  PageSize="8" AllowPaging="true" OnPageIndexChanging="VisitorsLogGrid_PageIndexChanging" CssClass="grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" >        
                                         <Columns>
                                             <asp:BoundField DataField="IPAddress" ItemStyle-wrap="true" HeaderStyle-Width ="120" ItemStyle-Width="120" HeaderText="IP Address" /> 
                                             <asp:BoundField DataField="machineName" ItemStyle-wrap="true" HeaderStyle-Width ="170" ItemStyle-Width="170" HeaderText="Machine Used" />
                                             <asp:BoundField DataField="deviceType" ItemStyle-wrap="true" HeaderStyle-Width ="250" ItemStyle-Width="248" HeaderText="Devite Type" />
                                             <asp:BoundField DataField="browserName" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width ="150" ItemStyle-Width="150" ItemStyle-wrap="true" HeaderText="Browser Name" />      
                                             <asp:BoundField DataField="logdate" ItemStyle-wrap="true" HeaderText="Date" />        
                                             <asp:BoundField DataField="logtime" ItemStyle-wrap="true" HeaderText="Time" />        
                                               
                                         </Columns>
                                        <PagerSettings Position="Bottom" Mode="NextPreviousFirstLast" FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Prev"/>
                                </asp:GridView>
 
 

                            </div>
                            
                             

                        </div>

                        <div class="modal-footer">
                          <a href="#close" class="mbtn-close">Cancel</a>  
                           <asp:Button ID="DownloadLogs" runat="server" text="Download Log Activities" class="mbtn"/>
                        </div>

                        </div>


                      </div>
                     <!-- /Modify User logs Activity -->
               
                    
            
                    <!-- Modal for Back logs -->
                    <div class="modal" id="back-logs" aria-hidden="true">
                      <div class="modal-dialog" style="width:700px; top: 5%;">
                        <div class="modal-header">
                          <h2>Upload Back Logs Data</h2>
                          <a href="#close" class="btn-close" aria-hidden="true">×</a> <!--CHANGED TO "#close"-->
                        </div>
                        <div class="modal-body" >

                            <div class="form-container">
                                 <iframe src ="http://localhost/php/?Session=ActiveFromAdmin" class="iframe" style="width:100%;height:470px;"></iframe>

                            </div>
                            
                             

                        </div>

                        </div>


                      </div>
                     <!-- /Modify Back logs Activity -->
               
                    
                    <!-- Modal for Lots Allocation -->
                    <div class="modal" id="lots-allocation" aria-hidden="true">
                      <div class="modal-dialog" style="width:700px; top: 5%;">
                        <div class="modal-header">
                          <h2>Lots Allocation Management</h2>
                          <a href="#close" class="btn-close" aria-hidden="true">×</a> <!--CHANGED TO "#close"-->
                        </div>
                        <div class="modal-body" >

                            <div class="form-container">

                                <h3>SELECT TERMINAL TO EDIT LOT ALLOCATION </h3>

                                <div class="form-group" style="width:96%">
                                    <label for="TerminalName" >Terminal Name:</label>
                                    <asp:DropDownList ID="TerminalName" OnSelectedIndexChanged="TerminalName_SelectedIndexChanged" autopostback="true"  runat="server" CssClass="select">
                                        <asp:ListItem Selected="True" Text="---Select Terminal Name to Manage Allocation---" value="" ></asp:ListItem>
                                    
                                    </asp:DropDownList>

                                 </div>

                            </div>


                         
                            <div class="form-container">
                            
                            <h3>MANAGE LOTS ALLOCATION</h3>

                            <div class="form-group">
                                <label for="LotTerminal" >Terminal:</label> 
                                <asp:TextBox ID="Terminal" runat="server" CssClass="input"></asp:TextBox>
                            </div>

                            <div class="form-group" style="float:left">
                                <label for="LotTerminalLocation" >Location:</label> 
                                <asp:TextBox ID="LotTerminalLocation" runat="server" CssClass="input"></asp:TextBox>
                            </div>
 
                                     
                                        
                            <div class="form-group">
                                <label for="LotTerminalCompany" >Terminal Owner: </label> 
                                <asp:TextBox ID="LotTerminalOwner" runat="server" CssClass="input"></asp:TextBox>
                            </div>

                                    

                            <div class="form-group">
                                <label for="LotTerminalRCNumber" >RC Number: </label> 
                                <asp:TextBox ID="LotTerminalRCNumber" runat="server" CssClass="input"></asp:TextBox>
                            </div>

                                
                            <div class="form-group">
                                <label for="SelectLotName" >Select Lot:</label>
                                <asp:DropDownList ID="SelectLotName" runat="server" CssClass="select">
                                    <asp:ListItem Selected="True" Text="---Select Lot---" value="" ></asp:ListItem>
                                    
 
                                </asp:DropDownList>

                             </div>

                    
                            <div class="form-group" style="width:96%">
                                <label for="LotTerminalActiveISP" >Active ISP:</label>
                                <asp:DropDownList ID="LotTerminalActiveISP" runat="server" CssClass="select">
                                    <asp:ListItem Selected="True" Text="---Select Active ISP---" value="" ></asp:ListItem>
                                    
                                </asp:DropDownList>

                             </div>

                            <div class="form-group" style="width:46%">
                                <label for="LotTerminalFacilityDatabase" >Facility Database:</label> 
                               <asp:FileUpload ID="LotTerminalFacilityDatabase" runat="server" />
                            </div>
                              
                                <!--
                            <div class="form-group" style="width:46%">
                                 <asp:Button ID="LotTerminalAssignLGA" runat="server" text="Assign Local Government" class="mbtn"/>
                            </div>
                            -->

                        </div>

                        </div>

                        <div class="modal-footer">
                          <a href="#close" class="mbtn-close">Cancel</a>  
                           <asp:Button ID="RegisterAllocation" runat="server" text="Add New Lot" OnClientClick ="return confirm('Are you sure you want to register this new lot?')" class="mbtn"/>
                           <asp:Button ID="SaveLotAllocation" runat="server" text="Save Lot Details" OnClientClick ="return confirm('Are you sure you want to save this change lot?')" class="mbtn"/>
                        </div>


                        </div>
                        </div>
                     <!-- /Lot Allocation -->

                        
                    
                    
                    
                    <!-- Modal Lots Table -->
                    <div class="modal" id="lot-table" aria-hidden="true">
                      <div class="modal-dialog" style="width:700px; top: 5%;">
                        <div class="modal-header">
                          <h2>Lot Configuration Table</h2>
                          <a href="#close" class="btn-close" aria-hidden="true">×</a> <!--CHANGED TO "#close"-->
                        </div>
                        <div class="modal-body" >

                             <div class="form-container">

                                <h3>CREATE NEW LOT</h3>

                                <div class="form-group" style="width:106%">
                                    <label for="NewLotName" >Lot Name:</label>
                                         <asp:TextBox ID="NewLotName" runat="server" CssClass="input"></asp:TextBox>
                                    
 
                                 </div>
                                 </div>

                            <div class="form-container">

                                <h3>SELECT LOT TO EDIT </h3>

                                 
                                <div class="form-group" style="width:99%">
                                    <label for="LotToEdit" >Select Lot:</label>
                                    <asp:DropDownList ID="SelectLotToEdit" runat="server" AutoPostBack="true"  OnSelectedIndexChanged ="SelectLotToEdit_Changed"   CssClass="select">
                                        <asp:ListItem Selected="True" Text="---Select Lot to view or modify ---" value="" ></asp:ListItem>
                                    
                                    </asp:DropDownList>

                                 </div>

                            </div>


                         
                            <div class="form-container">
                            
                            <h3>EDIT LOT</h3>
                                
                                <div class="form-group" style="width:99%">
                                    <label for="EditLotName" >Edit Lot Name:</label>
                                         <asp:TextBox ID="EditLotName" runat="server" CssClass="input"></asp:TextBox>
                                    
                                 </div>
                           </div>

                        </div>

                        <div class="modal-footer">
                          <a href="#close" class="mbtn-close">Cancel</a>  
                           <asp:Button ID="CreateNewLot" runat="server" text="Add New Lot" OnClientClick ="return confirm('Are you sure you want to save this changes?')" class="mbtn"/>
                           <asp:Button ID="SaveEditedLot"  runat="server" text="Save Lot Details" OnClientClick ="return confirm('Are you sure you want to save this changes?')" class="mbtn"/>
                        </div>

                        </div>


                      </div>
                     <!-- /Modify Lot Table-->

                    
                    
                    <!-- Modal for download center -->
                    <div class="modal" id="download-center" aria-hidden="true">
                      <div class="modal-dialog" style="width:700px; top: 5%;">
                        <div class="modal-header">
                          <h2>File Download center</h2>
                          <a href="#close" class="btn-close" aria-hidden="true">×</a> <!--CHANGED TO "#close"-->
                        </div>
                        <div class="modal-body" >

                            <div class="form-container">
                                 
                                     <h3>SELECT FILE TO MANAGE</h3>
                                    
                                 
                                    <div class="form-group" style="width:99%">
                                        <label for="SelectFileDownload" >Select File:</label>
                                        <asp:DropDownList ID="SelectFileDownload" runat="server" AutoPostBack="true"  OnSelectedIndexChanged ="DownloadCenter_SelectedIndexChanged"   CssClass="select">
                                        <asp:ListItem Selected="True" Text="---Select downloadable file to modify ---" value="" ></asp:ListItem>
                                    
                                    </asp:DropDownList>
                                    </div>
                            </div>

                            <div class="form-container">
                                 
                                     <h3>FILE INFORMATION</h3>

                                    <div class="form-group">
                                        <label for="MemberType" >User Type:</label>
                                        <asp:DropDownList ID="FileMemberType" runat="server" CssClass="select">
                                        <asp:ListItem Selected="True" Text="---User type ---" value="" ></asp:ListItem>
                                        <asp:ListItem Text="Registered Member" value="Registered User" ></asp:ListItem>
                                        <asp:ListItem Text="Non Registered Member" value="Non Registered User" ></asp:ListItem>


                                    
                                    </asp:DropDownList>

                                    </div>

                                    <div class="form-group">
                                        <label for="FileDownloadName" >File Name:</label> 
                                        <asp:TextBox ID="FileDownloadName" runat="server" CssClass="input"></asp:TextBox>
                                    </div>
 
                                    <div class="form-group" style="float:right;">
                                           <label for="FileDownloadUpload" >Upload File:</label><br /> 
                                            <asp:checkbox ID="DisplayDownloadFile" runat="server" CssClass="checkbox"></asp:checkbox><span class="checkbox" >Display or Hide File</span>
                                    </div>
 
                                                
                                    <div class="form-group" style="width:100%">
                                           <label for="FileDownloadDescription" >File Description:</label> 
                                            <asp:TextBox ID="FileDownloadDescription" TextMode ="MultiLine"  runat="server" CssClass="textarea"></asp:TextBox>
                                    </div>
                                    
                                    <div class="form-group" style="margin-top:50px; width:100%">
                                           <label for="FileDownloadUpload" >Upload File:</label> 
                                            <asp:FileUpload ID="FileDownloadUpload" runat="server" CssClass="input-flat"></asp:FileUpload>
                                    </div>
 
                                                   
                            </div>
                            
                             

                        </div>

                        <div class="modal-footer">
                          <a href="#close" class="mbtn-close">Close Download</a>  
                          <asp:Button ID="SaveDownloadFile" runat="server" text="Save File" class="mbtn"/>
                          <asp:Button ID="UploadDownloadFile" runat="server" text="Upload File" class="mbtn"/>

                        </div>

                        </div>


                      </div>
                     <!-- /Download center modal ends here -->


                    
                    
                    <!-- Modal for news for home page -->
                    <div class="modal" id="upload-news" aria-hidden="true">
                      <div class="modal-dialog" style="width:880px; top: 2%;left:43%;">
                        <div class="modal-header">
                          <h2>Upload News</h2>
                          <a href="#close" class="btn-close" aria-hidden="true">×</a> <!--CHANGED TO "#close"-->
                        </div>
                        <div class="modal-body" >

                            <div class="form-container">
                                 
                                     <h3>SELECT ARTICLE HEADLINE TO MODIFY</h3>
                                    
                                 
                                    <div class="form-group" style="width:99%">
                                        <label for="SelectArticleHeader" >Select Article Header:</label>
                                        <asp:DropDownList ID="SelectNewHeader" runat="server" AutoPostBack="true"  OnSelectedIndexChanged ="ArticleHeader_SelectedIndexChanged"   CssClass="select">
                                        <asp:ListItem Selected="True" Text="---Select Article Header ---" value="" ></asp:ListItem>
                                    
                                    </asp:DropDownList>
                                    </div>
                            </div>

                            <div class="form-container">
                                 
                                     <h3>ARTICLE DETAILS</h3>

                                     
                                     <div class="form-group">
                                           <label for="ArticleHeader" >News Header:</label> 
                                            <asp:TextBox ID="ArticleHeader" AutoPostBack="false" runat="server" CssClass="input"></asp:TextBox>
                                    </div>
                                    
                                    <div class="form-group">
                                        <label for="NewsHeader" >Article Group:</label> 
                                        <asp:DropDownList ID="ArticleGroup" runat="server" CssClass="select">
                                        <asp:ListItem Selected="True" Text="---Select Article Group ---" value="" ></asp:ListItem>
                                        <asp:ListItem  Text="Weights and Measures" value="Weights and Measures" ></asp:ListItem>
                                        <asp:ListItem  Text="General News" value="General News" ></asp:ListItem>
                                        <asp:ListItem  Text="Oil and Gas" value="Oil and Gas" ></asp:ListItem>
                                        <asp:ListItem  Text="Nigerco News" value="Nigerco News" ></asp:ListItem>
                                        <asp:ListItem  Text="Others Sectors" value="Others" ></asp:ListItem>
                                        
                                        </asp:DropDownList>                                
                                    </div>
                                    
                              
                                 <div class="form-group" style="float:right;">
                                           <label for="ArticleStatus" >Display Article:</label><br /> 
                                            <asp:checkbox ID="ArticleStatus" runat="server" CssClass="checkbox"></asp:checkbox><span class="checkbox" >Display on Homepage</span>
                                    </div>
                                <script type="text/javascript">
                                   
                                    function process(e) {
                                        var code = (e.keyCode ? e.keyCode : e.which);
                                        if (code == 13) { //Enter keycode
                                            //alert("Sending your Message : " + document.getElementById('txt').value);
                                            //document.getElementById('txt').value = document.getElementById('ArticleBody').value + "Environment.New";
                                            document.getElementById('ArticleBody').value = document.getElementById('ArticleBody').value + " <p>";
                                        }

                                    }
                                   </script>
                                    <asp:HtmlEditorExtender ID="HtmlEditorExtender1" runat="server" DisplaySourceTab="true" EnableSanitization="false" TargetControlID="ArticleBody">

                                    </asp:HtmlEditorExtender>

                                    <div class="form-group" style="width:100%; height:220px;">
                                        <label for="ArticleBody" >Article Body:</label> 
                                        <asp:TextBox ID="ArticleBody" runat="server"  onkeypress="process(event, this)" TextMode ="MultiLine" CssClass="textarea-news" style="height:200px;"></asp:TextBox>
                                    </div>
                                    
                                  
                                    <div class="form-group" style="width:106%;height:20px;">
                                            <asp:TextBox ID="ArticlePictureLink" runat="server" CssClass="input-flat"></asp:TextBox>
                                    </div>
                                    
                                    <div class="form-group" style="margin-top:0px; width:100%">
                                           <label for="UploadArticlePicture" >Upload Picture:</label> 
                                            <asp:FileUpload ID="UploadArticlePicture" runat="server" CssClass="input-flat"></asp:FileUpload>
                                    </div>
 
                                                   
                            </div>
                            
                             

                        </div>

                        <div class="modal-footer">
                          <a href="#close" class="mbtn-close">Close Setup</a>  
                          <asp:Button ID="DeleteHomepageArticle" runat="server" text="Delete Article" class="mbtn-close"/>
                          <asp:Button ID="SaveHomepageArticle" runat="server" text="Save Article" class="mbtn"/>
                          <asp:Button ID="UploadHomepageArticle" runat="server" text="Upload Article" class="mbtn"/>

                        </div>

                        </div>


                      </div>
                     <!-- /news for home page ends here -->


            
                    
                    <!-- Modal for Uploading Picture Gallery -->
                    <div class="modal" id="upload-picture" aria-hidden="true">
                      <div class="modal-dialog" style="width:700px; top: 5%;">
                        <div class="modal-header">
                          <h2>Gallery Picture Upload</h2>
                          <a href="#close" class="btn-close" aria-hidden="true">×</a> <!--CHANGED TO "#close"-->
                        </div>
                        <div class="modal-body" >

                            <div class="form-container">
                                 
                                     <h3>SELECT PICTURE TO DELETE OR MODIFY</h3>
                                    
                                 
                                    <div class="form-group" style="width:99%">
                                        <label for="SelectPictureGallery" >Select Photo Caption:</label>
                                        <asp:DropDownList ID="SelectPictureGallery" runat="server" AutoPostBack="true"  OnSelectedIndexChanged ="PictureGallery_SelectedIndexChanged"   CssClass="select">
                                        <asp:ListItem Selected="True" Text="---Select Picture Gallery ---" value="" ></asp:ListItem>
                                    
                                    </asp:DropDownList>
                                    </div>
                            </div>

                            <div class="form-container" style="float:left;margin-left:20px;">
                                 
                                     <h3>CREATE GALLERY GROUP</h3>

                                    <div class="form-group" style="width:60%">
                                        <label for="GalleryGroup" >Create Gallery Group:</label> 
                                        <asp:TextBox ID="GalleryGroup" runat="server" CssClass="input"></asp:TextBox>                               
                                    </div>
                                    
                              
                                 <div class="form-group" style="float:right;">
                                           <label for="CreateGalleryGroup"></label><br /> 
                                           <asp:Button ID="CreateGalleryGroup" runat="server" text="Create Picture Group" style="margin-top:-5px;" class="mbtn"/>
                                    </div>
 
                             </div>

                            <div class="form-container">
                                 
                                     <h3>UPLOAD PICTURE GALLERY</h3>

                                    <div class="form-group" style="width:60%">
                                        <label for="PictureGalleryGroup" >Picture Gallery Group:</label> 
                                        <asp:DropDownList ID="PictureGalleryGroup" runat="server" CssClass="select">
                                        <asp:ListItem Selected="True" Text="---Select Picture Group ---" value="" ></asp:ListItem>
                                    </asp:DropDownList>                                
                                    </div>
                                    
                              
                                 <div class="form-group" style="float:right;">
                                           <label for="DisplayPictureGallery" >Add Picture to Gallery:</label><br /> 
                                            <asp:checkbox ID="DisplayPictureGallery" runat="server" CssClass="checkbox"></asp:checkbox><span class="checkbox" >Display Picture in Gallery</span>
                                    </div>
 
                                  
                                    <div class="form-group" style="width:100%;">
                                           <label for="PictureGalleryCaption" >Photo Caption:</label> 
                                            <asp:TextBox ID="PictureGalleryCaption" runat="server" CssClass="input"></asp:TextBox>
                                    </div>
                                    
                                  
                                    <div class="form-group" style="width:106%;">
                                           <label for="PictureGalleryLink" >Picture Link:</label> 
                                            <asp:TextBox ID="PictureGalleryLink" runat="server" CssClass="input-flat"></asp:TextBox>
                                    </div>
                                    
                                    <div class="form-group" style="margin-top:0px; width:100%">
                                           <label for="UploadPictureGallery" >Select Picture to Upload:</label> 
                                            <asp:FileUpload ID="UploadPictureGallery" runat="server" CssClass="input-flat"></asp:FileUpload>
                                    </div>
 
                                                   
                            </div>
                            
                        </div>

                        <div class="modal-footer">
                          <a href="#close" class="mbtn-close">Close Setup</a>  
                          <asp:Button ID="DeleteGallery" runat="server" text="Delete Picture" class="mbtn-close"/>
                          <asp:Button ID="SaveGallery" runat="server" text="Save Change" class="mbtn"/>
                          <asp:Button ID="GalleryUpload" runat="server" text="Upload Picture" class="mbtn"/>

                        </div>

                        </div>


                      </div>
                     <!-- /news for home page ends here -->

                        
                    
                    <!-- Modal for state office setup -->
                    <div class="modal" id="setup-office" aria-hidden="true">
                      <div class="modal-dialog" style="width:700px; top: 5%;">
                        <div class="modal-header">
                          <h2>Setup State Office</h2>
                          <a href="#close" class="btn-close" aria-hidden="true">×</a> <!--CHANGED TO "#close"-->
                        </div>
                        <div class="modal-body" >

                            <div class="form-container" style="float:left; margin-left:15px;">
                                 
                                     <h3>SELECT OFFICE</h3>
                                    
                                 
                                    <div class="form-group" style="width:99%">
                                        <label for="SelectStateOffice" >Select Office:</label>
                                        <asp:DropDownList ID="SelectStateOffice" runat="server" AutoPostBack="true"  OnSelectedIndexChanged ="StateContact_SelectedIndexChanged"   CssClass="select">
                                        <asp:ListItem Text="---Select Picture Gallery ---" value="" ></asp:ListItem>
                                    
                                    </asp:DropDownList>
                                    </div>
                            </div>

                            <div class="form-container">
                                 
                                     <h3>CONTACT DETAILS</h3>

                                    <div class="form-group" style="width:60%">
                                        <label for="SelectOfficeState" >Select State:</label> 
                                        <asp:DropDownList ID="SelectOfficeState" runat="server" CssClass="select">
                                        
                                        
                                        </asp:DropDownList>                                
                                    </div>
                                    
                              
                                     <div class="form-group" style="float:right;">
                                           <label for="DisplayAddress" >Display Address:</label><br /> 
                                            <asp:checkbox ID="DisplayAddress" runat="server" CssClass="checkbox"></asp:checkbox><span class="checkbox" >Display Address in Contact</span>
                                    </div>

                                    <div class="form-group" style="width:106%;">
                                           <label for="OfficeEmailAddress" >Email Address:</label> 
                                            <asp:TextBox ID="OfficeEmailAddress" runat="server" TextMode ="Email"  CssClass="input"></asp:TextBox>
                                    </div>
                                    

                                    <div class="form-group" style="width:100%; height:90px;">
                                           <label for="OfficeAddress" >Office Address:</label> 
                                            <asp:TextBox ID="OfficeAddress" runat="server" TextMode ="MultiLine"  CssClass="textarea"></asp:TextBox>
                                    </div>
                                                                    
                            </div>

                             <div class="form-container" style="float:left; margin-left:15px;">
                                 
                                     <h3>STATE ADDRESS CONTACT PERSON</h3>
                                    <div class="form-group" style="width:48%;">
                                           <label for="StateContactPersonName" >Contact Person Name:</label> 
                                            <asp:TextBox ID="StateContactPersonName" runat="server" CssClass="input"></asp:TextBox>
                                    </div>
                                    
                                  
                                    <div class="form-group" style="width:46.5%;">
                                           <label for="StateContactPersonMobile" >Contact Person Mobile:</label> 
                                            <asp:TextBox ID="StateContactPersonMobile" runat="server" CssClass="input"></asp:TextBox>
                                    </div>
                                    
                                                   
                            </div>
                            
                        </div>

                        <div class="modal-footer">
                          <a href="#close" class="mbtn-close">Close Setup</a>  
                          <asp:Button ID="DeleteStateAddress" runat="server" text="Delete Address" class="mbtn-close"/>
                          <asp:Button ID="SaveStateAddress" runat="server" text="Save Change" class="mbtn"/>
                          <asp:Button ID="AddStateAddress" runat="server" text="Add Address" class="mbtn"/>

                        </div>

                        </div>


                      </div>
                     <!-- /news for home page ends here -->


                        
                    
                    <!-- Modal for Quiz Upload -->
                    <div class="modal" id="upload-quiz" aria-hidden="true">
                      <div class="modal-dialog" style="width:700px; top: 5%;">
                        <div class="modal-header">
                          <h2>Upload Quiz to Database</h2>
                          <a href="#close" class="btn-close" aria-hidden="true">×</a> <!--CHANGED TO "#close"-->
                        </div>
                        <div class="modal-body" >

                            <div class="form-container">
                                 
                                     <h3>SELECT QUESTION</h3>
                                    
                                 
                                    <div class="form-group" style="width:99%">
                                        <label for="SelectQuestion" >Select Question:</label>
                                        <asp:DropDownList ID="SelectQuestion" runat="server" AutoPostBack="true" CssClass="select">
                                        <asp:ListItem Text="---Select Question ---" value="" ></asp:ListItem>
                                    
                                    </asp:DropDownList>
                                    </div>
                            </div>

                            <div class="form-container">
                                 
                                     <h3>QUIZ DETAILS</h3>
                                                                
                                
                            </div>


                        </div>

                        <div class="modal-footer">
                          <a href="#close" class="mbtn-close">Close Setup</a>  
                          <asp:Button ID="Button2" runat="server" text="Delete Address" class="mbtn-close"/>
                          <asp:Button ID="Button3" runat="server" text="Save Change" class="mbtn"/>
                          <asp:Button ID="Button5" runat="server" text="Add Address" class="mbtn"/>

                        </div>

                        </div>


                      </div>
                     <!-- Upload Quiz ends here -->

                       
                    
                    <!-- Modal for Career Opportunity Openings -->
                    <div class="modal" id="upload-career" aria-hidden="true">
                      <div class="modal-dialog" style="width:700px; top: 5%;">
                        <div class="modal-header">
                          <h2>Upload Career Opportunity Openings</h2>
                          <a href="#close" class="btn-close" aria-hidden="true">×</a> <!--CHANGED TO "#close"-->
                        </div>
                        <div class="modal-body" >

                            <div class="form-container">
                                 
                                     <h3>SELECT POSITION TO MODITY</h3>
                                    
                                 
                                    <div class="form-group" style="width:99%">
                                        <label for="SelectPosition" >Select Position:</label>
                                        <asp:DropDownList ID="SelectPosition" runat="server" AutoPostBack="true" CssClass="select">
                                        <asp:ListItem Text="---Select Position ---" value="" ></asp:ListItem>
                                    
                                    </asp:DropDownList>
                                    </div>
                            </div>

                            <div class="form-container">
                                 
                                     <h3>POSITION DETAILS</h3>
                                 
                                         
                            </div>


                        </div>

                        <div class="modal-footer">
                          <a href="#close" class="mbtn-close">Close Setup</a>  
                          <asp:Button ID="DeleteCareer" runat="server" text="Delete Career" class="mbtn-close"/>
                          <asp:Button ID="SaveCareer" runat="server" text="Save Career" class="mbtn"/>
                          <asp:Button ID="AddCareer" runat="server" text="Add Career" class="mbtn"/>

                        </div>

                        </div>


                      </div>
                     <!-- Upload Career Opportunity ends here -->


            
                    <!-- Modal for Instrument Fee -->
                    <div class="modal" id="instrument-fee" aria-hidden="true">
                      <div class="modal-dialog" style="width:700px; top: 5%;">
                        <div class="modal-header">
                          <h2>Upload Instrument Fee</h2>
                          <a href="#close" class="btn-close" aria-hidden="true">×</a> <!--CHANGED TO "#close"-->
                        </div>
                        <div class="modal-body" >

                            <div class="form-container">
                                 
                                     <h3>INSTRUMENT FEE</h3>
                                    
                                 <div class="form-group" style="width:100%">
                                        <label for="ModifyInstrumentFee" >Modify Instrument Fee:</label>
                                        <asp:DropDownList ID="ModifyInstrumentFee" runat="server" AutoPostBack="true" OnSelectedIndexChanged ="ModifyInstrumentCategories_SelectedIndexChanged" CssClass="select">
                                            <asp:ListItem Text="---Select Instrument Fee ---" value="" ></asp:ListItem>
                                    
                                        </asp:DropDownList>
                                        
                                  </div>

                                    <div class="form-group" style="width:47.6%">
                                           <label for="FeeSector" >Select Sector:</label>
                                           <asp:DropDownList ID="FeeSector" runat="server" AutoPostBack ="true" OnSelectedIndexChanged ="FeeSector_SelectedIndexChanged" PostBackUrl="#you" CssClass="select">
                                                <asp:ListItem Text="---Select Sector---" value="" ></asp:ListItem>
                                    
                                            </asp:DropDownList>

                                    </div>

                                    <div class="form-group" style="width:46%;float:right;margin-right :-17px">
                                           <label for="FeeInstrumentCategory" >Select Instument Category:</label>
                                           <asp:DropDownList ID="FeeInstrumentCategory" runat="server" AutoPostBack ="true" OnSelectedIndexChanged ="FeeInstrumentCategory_SelectedIndexChanged" CssClass="select">
                                                <asp:ListItem Text="---Select Instrument Category---" value="" ></asp:ListItem>
                                    
                                            </asp:DropDownList>

                                    </div>
                                
                                    <div class="form-group" style="width:47.6%">
                                           <label for="FeeInstrumentSub" >Select Instrument Sub Cate.:</label>
                                           <asp:DropDownList ID="FeeInstrumentSub" runat="server" AutoPostBack ="true" OnSelectedIndexChanged ="FeeInstrumentSubCategory_SelectedIndexChanged" CssClass="select">
                                                <asp:ListItem Text="---Select Sector---" value="" ></asp:ListItem>
                                    
                                            </asp:DropDownList>

                                    </div>
                                
                                    <div class="form-group" style="width:46%;float:right;margin-right :-17px">
                                           <label for="FeeMeasurement" >Select Measurement:</label>
                                           <asp:DropDownList ID="FeeMeasurement" runat="server" CssClass="select">
                                                <asp:ListItem Text="---Select Measurement---" value="" ></asp:ListItem>
                                    
                                            </asp:DropDownList>

                                    </div>

                                </div>
                                
                             <div class="form-container" style="margin-top:30px">
                                 
                                     <h3>SETUP INSTRUMENT FEE</h3>
                                    
                                    
                                    <div class="form-group" style="width:47.6%;">
                                           <label for="FeeDescription" >Fee Description:</label> 
                                           <asp:DropDownList ID="FeeDescription" runat="server" CssClass="select">
                                                <asp:ListItem Text="---Select Fee Description to add---" value="" ></asp:ListItem>
                                    
                                            </asp:DropDownList>

                                    </div>
   
                                
                                    
                                    <div class="form-group" style="width:47%; float:right; margin-right :-25px;">
                                        <label for="FeeMaxValue" >Maximum Value:</label> 
                                        <asp:TextBox ID="FeeMaxValue" runat="server" CssClass="input"></asp:TextBox>
                                    </div>    
                                                                  
                                    <p style="height:10px;margin:0px;padding:0"></p>
                                 
                                    <div class="form-group" style="width:50%;margin-top:-15px;">
                                        <label for="FeeAmount" >Amount:</label> 
                                        <asp:TextBox ID="FeeAmount" Enabled ="false"  runat="server" CssClass="input"></asp:TextBox>
                                    </div>
                                    
                                    <div class="form-group" style="margin-left:15px;">
                                        <label for="FeeIsMaxSetup" >Is Last/Max Setup:</label><br /> 
                                        <asp:checkbox ID="FeeIsMaxSetup" runat="server" CssClass="checkbox"></asp:checkbox><span class="checkbox" >Check if its Last/Max Setup</span>
                                    </div>

                             
                            </div>
                        </div>

                        <div class="modal-footer">
                          <a href="#close" class="mbtn-close">Close</a>  
                          <asp:Button ID="DeleteInstrumentFee" runat="server" text="Delete Inst. Fee" class="mbtn-close"/>
                          <asp:Button ID="SaveInstrumentFee" runat="server" text="Save Inst. Fee" class="mbtn"/>
                          <asp:Button ID="AddInstrumentFee" runat="server" text="Add Inst. Fee" class="mbtn"/>

                        </div>

                        </div>


                      </div>
                     <!-- Upload Instrument Fee ends here -->


            
                    <!-- Modal for Measurement -->
                    <div class="modal" id="measurement" aria-hidden="true">
                      <div class="modal-dialog" style="width:700px; top: 5%;">
                        <div class="modal-header">
                          <h2>Upload Measurement</h2>
                          <a href="#close" class="btn-close" aria-hidden="true">×</a> <!--CHANGED TO "#close"-->
                        </div>
                        <div class="modal-body" >

                            <div class="form-container">
                                 
                                     <h3>MEASUREMENT</h3>
                                     <div class="form-group" style="width:100%">
                                        <label for="ModifyMeasurement" >Modify Measurement:</label>
                                        <asp:DropDownList ID="ModifyMeasureMeasurement" runat="server" AutoPostBack="true" OnSelectedIndexChanged ="ModifyMeasureMeasurement_SelectedIndexChanged" CssClass="select">
                                            <asp:ListItem Text="---Select Measurement ---" value="" ></asp:ListItem>
                                    
                                    </asp:DropDownList>
                                        
                                     </div>
                  
                                    <div class="form-group" style="width:45%">
                                        <label for="MeasureMeasurement" >Measurment:</label> 
                                        <asp:TextBox ID="MeasureMeasurement" runat="server" CssClass="input"></asp:TextBox>
                                    </div>    
                                
                                    
                                    <div class="form-group" style="float:right; margin-right :-17px;width:45%">
                                        <label for="MeasureMeasurementValue" >Value:</label> 
                                        <asp:TextBox ID="MeasureMeasurementValue" runat="server" CssClass="input"></asp:TextBox>
                                    </div> 

                                 <div class="modal-footer" style="margin-top:20px;">
                                <asp:Button ID="DeleteMeasurement" runat="server" text="Delete Measurement" class="mbtn-close"/>
                                <asp:Button ID="AddMeasurement" runat="server" text="Add Measurement" class="mbtn"/>

                            </div>

                      
                            </div>

                           


                            <div class="form-container" style="float:left; margin-left:15px;margin-top:20px" >
                                 
                                     <h3 style="margin-bottom:-5px;">DEVICE MEASUREMENT SECTION</h3>
                                        
                                    <div class="form-group" style="width:100%">
                                        <label for="ModifyMeasurement" >Modify Device Measurement:</label>
                                        <asp:DropDownList ID="ModifyMeasurement" runat="server" AutoPostBack="true" OnSelectedIndexChanged ="ModifyDeviceMeasurement_SelectedIndexChanged" CssClass="select">
                                            <asp:ListItem Text="---Select Measurement ---" value="" ></asp:ListItem>
                                    
                                    </asp:DropDownList>
                                        
                                     </div>

                                    
                                    <div class="form-group">
                                        <label for="DeviceTypeMeasurement" >Device Type:</label>
                                        <asp:DropDownList ID="DeviceTypeMeasurement" runat="server" CssClass="select">
                                            <asp:ListItem Text="---Select Device Type ---" value="" ></asp:ListItem>
                                    
                                    </asp:DropDownList>
                                        
                                     </div>

                                     
                                    <div class="form-group">
                                        <label for="SelectMeasureMeasurements" >Select Measurement:</label>
                                        <asp:DropDownList ID="SelectMeasureMeasurements" runat="server" CssClass="select">
                                            <asp:ListItem Text="---Select Measurement ---" value="" ></asp:ListItem>
                                    
                                    </asp:DropDownList>
                                        
                                     </div>

                                                                    
                                    <div class="form-group" style="float:right; margin-right :-17px;">
                                        <label for="Measurement" >Value:</label> 
                                        <asp:TextBox ID="MeasurementValue" runat="server" CssClass="input"></asp:TextBox>
                                    </div>    
                                                         
                                </div>

                            
                        </div>

                            <div class="modal-footer" style="margin-top:20px;">
                                <asp:Button ID="DeleteDeviceMeasurement" runat="server" text="Delete Device Measurement" class="mbtn-close"/>
                                <asp:Button ID="AddDeviceMeasurement" runat="server" text="Add Device Measurement" class="mbtn"/>

                            </div>

                        </div>


                      </div>
                     <!-- Measurement Modal ends here -->










                    
                    <!-- Modal for Upload State -->
                    <div class="modal" id="upload-states" aria-hidden="true">
                      <div class="modal-dialog" style="width:700px; top: 5%;">
                        <div class="modal-header">
                          <h2>Upload States, LGA and Cities</h2>
                          <a href="#close" class="btn-close" aria-hidden="true">×</a> <!--CHANGED TO "#close"-->
                        </div>
                        <div class="modal-body" >

                           
                            <div class="form-container" style="float:left; margin-left:15px;">
                                 
                                     <h3>UPLOAD STATES</h3>
                                           
                                <div class="form-group" style="margin-top:10px;margin-bottom:20px;">
                                        <label for="UploadedStates" >Select States:</label>
                                        <asp:DropDownList ID="UploadedStates" runat="server" AutoPostBack="true" OnSelectedIndexChanged="State_SelectedIndexChanged" CssClass="select">
                                        <asp:ListItem Text="---Select Select State ---" value="" ></asp:ListItem>
                                    
                                        </asp:DropDownList>
                               </div>
                                                               
                                 <div class="form-group" style="margin-top:0px; width:60%;float:right;">
                                           <label for="StateFile" >Select State File:</label> 
                                            <asp:FileUpload ID="UploadStateFile" runat="server" CssClass="input-flat"></asp:FileUpload>
                                    </div>

                                
                        <div class="modal-footer">
                          <asp:Button ID="DeleteStates" runat="server" text="Delete States" class="mbtn-close"/>
                          <asp:Button ID="UploadStatesFileDB" runat="server" text="Upload States" class="mbtn"/>

                        </div>
 
                            </div>

                           <div class="form-container" style="float:left; margin-left:15px;">
                                 
                                     <h3>UPLOAD LOCAL GOVERNMENTS</h3>
                                     <div class="form-group" style="margin-top:10px;margin-bottom:20px;">
                                        <label for="UploadedLGA" >Select LGA:</label>
                                        <asp:DropDownList ID="UploadedLGA" runat="server" AutoPostBack="true" OnSelectedIndexChanged ="LGA_SelectedIndexChanged"   CssClass="select">
                                        <asp:ListItem Text="---Select Local Government ---" value="" ></asp:ListItem>
                                    
                                        </asp:DropDownList>
                                    </div>      
                                                               
                                    <div class="form-group" style="margin-top:0px; width:60%;float:right;">
                                           <label for="LGAFile" >Select LGA File:</label> 
                                            <asp:FileUpload ID="UploadLGAFile" runat="server"  CssClass="input-flat"></asp:FileUpload>
                                    </div>

                               
                        <div class="modal-footer">
                          <asp:Button ID="DeleteLGA" runat="server" text="Delete LGA" class="mbtn-close"/>
                          <asp:Button ID="UploadLGAFileDB" runat="server" text="Upload LGA" class="mbtn"/>

                        </div>
 
                            </div>


                            <div class="form-container">
                                 
                                     <h3>UPLOAD CITIES</h3>

                                        <div class="form-group" style="margin-top:10px;margin-bottom:20px;">
                                            <label for="UploadedCities" >Select Cities:</label>
                                            <asp:DropDownList ID="UploadedCities" runat="server" CssClass="select">
                                            <asp:ListItem Text="---Select City ---" value="" ></asp:ListItem>
                                    
                                            </asp:DropDownList>
                                         </div>
                                                               
                                    <div class="form-group" style="margin-top:0px; width:60%;float:right;">
                                           <label for="CitiesFile" >Select Cities File:</label> 
                                            <asp:FileUpload ID="UploadCitiesFile" runat="server" CssClass="input-flat"></asp:FileUpload>
                                    </div>
                        
                          <div class="modal-footer">
                          <asp:Button ID="DeleteCities" runat="server" text="Delete Cities" class="mbtn-close"/>
                          <asp:Button ID="UploadCitiesFileDB" runat="server" text="Upload Cities" class="mbtn"/>

                        </div>

                            </div>

                       
                        </div>

                        

                        </div>


                      </div>
                     <!-- Upload state ends here -->
                                             
                    
                    <!-- Modal for Fee Group and Sub -->
                    <div class="modal" id="fee-group-sub" aria-hidden="true">
                      <div class="modal-dialog" style="width:700px; top: 5%;">
                        <div class="modal-header">
                          <h2>Upload Fee Group and Sub Group</h2>
                          <a href="#close" class="btn-close" aria-hidden="true">×</a> <!--CHANGED TO "#close"-->
                        </div>
                        <div class="modal-body" >
                            <div class="form-container" style="float:left; margin-left:15px;">
                                 
                                     <h3 style="margin-bottom:-5px;">FEE GROUP SECTION</h3>
                                        
                                    <div class="form-group" style="width:99%">
                                        <label for="ModifyFeeGroup" >Select Fee Group to Modify:</label>
                                        <asp:DropDownList ID="ModifyFeeGroup" runat="server" AutoPostBack="true" OnSelectedIndexChanged ="ModifyFeeGroup_SelectedIndexChanged" CssClass="select">
                                        <asp:ListItem Text="---Select Fee Group ---" value="" ></asp:ListItem>
                                    
                                    </asp:DropDownList>
                                        
                                     </div>

                                    <div class="form-group" style="width:58%;">
                                        <label for="FeeGroup" >Fee Group:</label> 
                                        <asp:TextBox ID="FeeGroup" runat="server" CssClass="input"></asp:TextBox>
                                    </div>
                                    
                                    <div class="form-group" style="float:right;">
                                        <label for="FeeGroupIsService" >This Fee Is Service Fee:</label><br /> 
                                        <asp:checkbox ID="FeeGroupIsService" runat="server" CssClass="checkbox"></asp:checkbox><span class="checkbox" >Check if it's service fee</span>
                                    </div>

                        <div class="modal-footer" style="margin-top:30px;">
                           <asp:Button ID="DeleteFeeGroup" runat="server" text="Delete Fee Group" class="mbtn-close"/>
                          <asp:Button ID="SaveFeeGroup" runat="server" text="Save Fee Group" class="mbtn"/>
                          <asp:Button ID="AddFeeGroup" runat="server" text="Add Fee Group" class="mbtn"/>


                        </div>
                                  
                            </div>

                            <div class="form-container" style="float:left; margin-left:15px;">
                                <h3 style="margin-bottom:-5px;">FEE SUB SECTOIN</h3>
                                 
                                   <div class="form-group" style="width:99%">
                                       <label for="SelectFeeSub" >Select Fee Sub:</label>
                                       <asp:DropDownList ID="SelectFeeSub" runat="server" AutoPostBack="true" OnSelectedIndexChanged ="ModifyFeeSub_SelectedIndexChanged" CssClass="select">
                                       <asp:ListItem Text="---Select Fee Sub Group ---" value="" ></asp:ListItem>
                                    
                                        </asp:DropDownList>

                                    </div>
                                      
                                <div class="form-group" style="width:46%;">
                                       <label for="SelectFeeGroup" >Select Fee Group:</label>
                                       <asp:DropDownList ID="SelectFeeGroup" runat="server" CssClass="select">
                                       <asp:ListItem Text="---Select Fee Group ---" value="" ></asp:ListItem>
                                    
                                        </asp:DropDownList>

                                    </div>
   
                                 <div class="form-group" style="width:46.5%; float:right; margin-right:-15px">
                                       <label for="FeeSub" >Fee Sub:</label> 
                                        <asp:TextBox ID="FeeSub" runat="server" CssClass="input"></asp:TextBox>
                                   </div>

                            </div>

                            
                        </div>

                        <div class="modal-footer"  style="margin-top:30px;">
                          <a href="#close" class="mbtn-close">Close</a>  
                          <asp:Button ID="DeleteFeeSub" runat="server" text="Delete Fee Sub" class="mbtn-close"/>
                          <asp:Button ID="SaveFeeSub" runat="server" text="Save Fee Sub" class="mbtn"/>
                          <asp:Button ID="AddFeeSub" runat="server" text="Add Fee Sub" class="mbtn"/>

                        </div>

                        </div>


                      </div>
                     <!-- Upload Fee Group and Sub ends here -->

                      
                    
                    <!-- Modal for Fee Section -->
                    <div class="modal" id="fee-section" aria-hidden="true">
                      <div class="modal-dialog" style="width:700px; top: 5%;">
                        <div class="modal-header">
                          <h2>Upload Data to Fee Table</h2>
                          <a href="#close" class="btn-close" aria-hidden="true">×</a> <!--CHANGED TO "#close"-->
                        </div>
                        <div class="modal-body" >
                            
                            
                            <div class="form-container" style="float:left; margin-left:15px;">
                                <h3 style="margin-bottom:-5px;">FEE SECTOIN</h3>
                                 
                                <div class="form-group" style="width:98%">
                                       <label for="SelectMeasureRange" >Select Fee Name:</label>
                                       <asp:DropDownList ID="SelectMeasureRange" runat="server" CssClass="select">
                                       <asp:ListItem Text="---Select Fee Name ---" value="" ></asp:ListItem>
                                    
                                        </asp:DropDownList>

                                 </div>
   
                                   <div class="form-group" style="width:47.6%">
                                       <label for="SelectFeeGroupFee" >Select Fee Group:</label>
                                       <asp:DropDownList ID="SelectFeeGroupFee" runat="server" CssClass="select">
                                       <asp:ListItem Text="---Select Fee Group ---" value="" ></asp:ListItem>
                                    
                                        </asp:DropDownList>

                                    </div>
                                      
                                   <div class="form-group" style="width:47%">
                                       <label for="SelectFeeSubFee" >Select Fee Sub:</label>
                                       <asp:DropDownList ID="SelectFeeSubFee" runat="server" CssClass="select">
                                       <asp:ListItem Text="---Select Fee Sub Group ---" value="" ></asp:ListItem>
                                    
                                        </asp:DropDownList>

                                    </div>
                                      

                                
                                   <div class="form-group" style="width:47.6%">
                                       <label for="SelectInstrumentCategory" >Select Instrument Category:</label>
                                       <asp:DropDownList ID="SelectInstrumentCategory" AutoPostBack ="true" OnSelectedIndexChanged ="SelectInstrumentCategory_SelectedIndexChanged" runat="server" CssClass="select">
                                       <asp:ListItem Text="---Select Instrument Category ---" value="" ></asp:ListItem>
                                    
                                        </asp:DropDownList>

                                    </div>
                                      
                                   <div class="form-group" style="width:47%">
                                       <label for="SelectInstrumentSubCategory" >Select Instrument Sub Category:</label>
                                       <asp:DropDownList ID="SelectInstrumentSubCategory" runat="server" CssClass="select">
                                       <asp:ListItem Text="---Select Instrument Sub Category ---" value="" ></asp:ListItem>
                                    
                                        </asp:DropDownList>

                                    </div>

                                 <div class="form-group" style="width:47.6%; margin-bottom:50px;">
                                       <label for="MeasureRange" >Measure Range / Fee Description:</label> 
                                        <asp:TextBox ID="MeasureRange" runat="server" TextMode ="MultiLine"  CssClass="textarea"></asp:TextBox>
                                 </div>


                                 <div class="form-group" style="width:47%; float:right">
                                       <label for="MainCharge" >Main Charge:</label> 
                                        <asp:TextBox ID="MainCharge" runat="server" text="0.00" CssClass="input"></asp:TextBox>
                                 </div>
                                 <div class="form-group" style="width:47%">
                                       <label for="OtherCharges" >Other Charges:</label> 
                                        <asp:TextBox ID="OtherCharges" runat="server" text="0.00"  CssClass="input"></asp:TextBox>
                                 </div>

                                <div class="form-group" style="width:47.6%">
                                       <label for="RenewalFee" >Renewal Fee:</label> 
                                        <asp:TextBox ID="RenewalFee" runat="server" text="0.00"  CssClass="input"></asp:TextBox>
                                 </div>

                                 <div class="form-group" style="width:47%">
                                       <label for="SecurityDeposit" >Security Deposit:</label> 
                                        <asp:TextBox ID="SecurityDeposit" runat="server" text="0.00"  CssClass="input"></asp:TextBox>
                                 </div>
                                
                                 <div class="form-group" style="width:47.6%">
                                       <label for="CalibrationFee" >Calibration Fee:</label> 
                                        <asp:TextBox ID="CalibrationFee" runat="server" text="0.00"  CssClass="input"></asp:TextBox>
                                 </div>

                            </div>


                        </div>

                        <div class="modal-footer">
                          <a href="#close" class="mbtn-close">Close</a>  
                          <asp:Button ID="DeleteFee" runat="server" text="Save Fee Sub" class="mbtn"/>
                          <asp:Button ID="SaveFee" runat="server" text="Save Fee" class="mbtn"/>
                          <asp:Button ID="AddFee" runat="server" text="Add Fee" class="mbtn"/>

                        </div>

                        </div>


                      </div>
                     <!-- Upload Fee Section ends here -->

                                             
                    
                    <!-- Modal for Instrument Upload -->
                    <div class="modal" id="upload-instrument" aria-hidden="true">
                      <div class="modal-dialog" style="width:700px; top: 2%;">
                        <div class="modal-header">
                          <h2>Upload Instrument</h2>
                          <a href="#close" class="btn-close" aria-hidden="true">×</a> <!--CHANGED TO "#close"-->
                        </div>
                        <div class="modal-body" >

                            <div class="form-container" style="float:left; margin-left:15px;">
                                 
                                     <h3 style="margin-bottom:-5px;">SECTOR SECTION</h3>
                                        
                                    <div class="form-group" style="width:47.6%">
                                        <label for="ModifySector" >Select Sector to Modify:</label>
                                        <asp:DropDownList ID="ModifySector" runat="server" AutoPostBack="true" OnSelectedIndexChanged ="ModifySector_SelectedIndexChanged" CssClass="select">
                                        <asp:ListItem Text="---Select Sector---" value="" ></asp:ListItem>
                                    
                                    </asp:DropDownList>
                                        
                                     </div>

                                    <div class="form-group" style="width:46%;float:right ">
                                        <label for="Sector" >Sector:</label> 
                                        <asp:TextBox ID="Sector" runat="server" CssClass="input"></asp:TextBox>
                                    </div>
                                    
                                <div class="modal-footer" style="margin-top:20px;">
                                   <asp:Button ID="DeleteSector" runat="server" text="Delete Sector" class="mbtn-close"/>
                                  <asp:Button ID="AddSector" runat="server" text="Add Sector" class="mbtn"/>


                                </div>
                                  
                            </div>

                            <div class="form-container" style="float:left; margin-left:15px;">
                                 
                                     <h3 style="margin-bottom:-5px;">INSTRUMENT CATEGORY SECTION</h3>
                                        
                                    <div class="form-group" style="width:100%">
                                        <label for="ModifyInstrumentCategory" >Instrument Category:</label>
                                        <asp:DropDownList ID="ModifyInstrumentCategory" runat="server" AutoPostBack="true" OnSelectedIndexChanged ="ModifyInstrumentCategories_SelectedIndexChanged" CssClass="select">
                                            <asp:ListItem Text="---Select Instrument Category ---" value="" ></asp:ListItem>
                                    
                                    </asp:DropDownList>
                                        
                                     </div>

                                    <div class="form-group" style="width:47.6%">
                                           <label for="SelectSector" >Select Sector:</label>
                                           <asp:DropDownList ID="SelectSector" runat="server" CssClass="select">
                                                <asp:ListItem Text="---Select Sector---" value="" ></asp:ListItem>
                                    
                                            </asp:DropDownList>

                                        </div>

                                    <div class="form-group" style="float:right;width:46%">
                                        <label for="InstrumentCategory" >Instrument Category:</label> 
                                        <asp:TextBox ID="InstrumentCategory" runat="server" CssClass="input"></asp:TextBox>
                                    </div>
                                    
                                <div class="modal-footer" style="margin-top:20px;">
                                   <asp:Button ID="DeleteInstrumentCategory" runat="server" text="Delete Instrument" class="mbtn-close"/>
                                  <asp:Button ID="SaveInstrumentCategory" runat="server" text="Save Instrument" class="mbtn"/>
                                  <asp:Button ID="AddInstrumentCategory" runat="server" text="Add Instrument" class="mbtn"/>


                                </div>
                                  
                            </div>

                            <div class="form-container">
                                <h3 style="margin-bottom:-5px;">INSTRUMENT SUB CATEGORY SECTOIN</h3>
                                 
                                   <div class="form-group" style="width:99%">
                                       <label for="ModifyInstrumentSubCategory" >Instrument Sub Cat.:</label>
                                       <asp:DropDownList ID="ModifyInstrumentSubCategory" runat="server" AutoPostBack="false" CssClass="select">
                                       <asp:ListItem Text="---Select Instrument Sub Category ---" value="" ></asp:ListItem>
                                    
                                        </asp:DropDownList>

                                    </div>
                                      
                                    <div class="form-group">
                                           <label for="SelectSectorAdd" >Select Sector:</label>
                                           <asp:DropDownList ID="SelectSectorAdd" runat="server" AutoPostBack="true" OnSelectedIndexChanged ="SectorInstrumentCategories_SelectedIndexChanged" CssClass="select">
                                                <asp:ListItem Text="---Select Sector---" value="" ></asp:ListItem>
                                    
                                            </asp:DropDownList>

                                        </div>

                                        <div class="form-group">
                                           <label for="SelectInstrumentCategoryAdd" >Instrument Category:</label>
                                           <asp:DropDownList ID="SelectInstrumentCategoryAdd" runat="server" CssClass="select">
                                           <asp:ListItem Text="---Select Fee Group ---" value="" ></asp:ListItem>
                                    
                                            </asp:DropDownList>

                                        </div>
                                                               
                                


   
                                 <div class="form-group" style="float:right ">
                                       <label for="InstrumentSubCategory" >Instrument Sub Cat.:</label> 
                                        <asp:TextBox ID="InstrumentSubCategory" runat="server" CssClass="input"></asp:TextBox>
                                   </div>

                            </div>

                            
                        </div>

                        <div class="modal-footer"  style="margin-top:30px;">
                          <a href="#close" class="mbtn-close">Close</a>  
                          <asp:Button ID="DeleteInstrumentSubCategory" runat="server" text="Delete Inst. Sub" class="mbtn-close"/>
                          <asp:Button ID="SaveInstrumentSubCategory" runat="server" text="Save Inst. Sub" class="mbtn"/>
                          <asp:Button ID="AddInstrumentSubCategory" runat="server" text="Add Inst. Sub" class="mbtn"/>

                        </div>

                        </div>


                      </div>
                     <!-- Upload Fee Group and Sub ends here -->


                       
                    <!-- Modal for Password Recovery -->
                    <div class="modal" id="password-recovery" aria-hidden="true">
                      <div class="modal-dialog" style="width:700px; top: 5%;">
                        <div class="modal-header">
                          <h2>Modify User / Company Account?</h2>
                          <a href="#close" class="btn-close" aria-hidden="true">×</a> <!--CHANGED TO "#close"-->
                        </div>
                        <div class="modal-body">
                      
                         <div class="form-container">
                            
                            <h3>SEARCH USER</h3>

                                
                            <div class="form-group">
                                <label for="RecoverySearchName" >Name or E-mail:</label> 
                                <asp:TextBox ID="RecoverySearchName" runat="server" CssClass="input-flat" placeholder="Enter Username"></asp:TextBox>
                            </div>
       
                            <div class="form-group">
                                <label for="RecoverySearchNumber" >Phone Number:</label> 
                                <asp:TextBox ID="RecoverySearchNumber" runat="server" CssClass="input-flat" placeholder="Enter User Phone Number"></asp:TextBox>
                            </div>
 
                               <div class="form-group">
                                <asp:Button ID="RecoverySearchButton" runat="server" text="Lookup Database" style="margin-top:10px;" class="mbtn-close"/>
                            </div>
                        
                        </div>


                        <div class="form-container">
                            
                            <h3>USER INFORMATION</h3>
                            
                            <div class="form-group">
                                <label for="RecoverySelectUser"  >Select User:</label>
                                <asp:DropDownList ID="RecoverySelectUser" runat="server" AutoPostBack ="true" OnSelectedIndexChanged ="AdminSelectUserIndex_Changed"  CssClass="select-flat">
                                    <asp:ListItem Selected="True" Text="---Select User to modify its account ---" value="" ></asp:ListItem>
                                     

 
                                </asp:DropDownList>
                            </div>
                            
                            <div class="form-group">
                                <label for="RecoverySurname" >Surname:</label> 
                                <asp:TextBox ID="RecoverySurname" runat="server" CssClass="input-flat"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label for="RecoveryOtherName" >Other Names: </label> 
                                <asp:TextBox ID="RecoveryOtherName" runat="server" CssClass="input-flat"></asp:TextBox>
                            </div>

                            
                            <div class="form-group" style="float:right;margin-right:17px;">
                                <label for="RecoveryEmail" >Email Address:</label> 
                                <asp:TextBox ID="RecoveryEmail" runat="server" CssClass="input-flat"></asp:TextBox>
                            </div>

                                                    
                            <div class="form-group" style="float:right;" >
                                <label for="Mobile" >Mobile:</label> 
                                <asp:TextBox ID="RecoveryMobile" runat="server" CssClass="input-flat"></asp:TextBox>
                            </div>
 
                            <div class="form-group" style="float:right;">
                                <label for="RecoveryCompanyName" >Company Name:</label> 
                                <asp:TextBox ID="RecoveryCompanyName" runat="server" CssClass="input-flat"></asp:TextBox>
                            </div>

                                <asp:TextBox ID="RecoveryUserID" Height="20" Enabled="false" ForeColor ="Transparent" BackColor ="Transparent" BorderColor ="Transparent" runat="server" width="10"></asp:TextBox>

                        </div>





                         <div class="form-container" style="padding-top:20px;">
                            
                            <p /><h3>CHANGE USER PASSWORD</h3>
                             
                          
                            <div class="form-group">
                                <label for="RecoveryOldPasssword" >Old Password: </label> 
                                <asp:TextBox ID="RecoveryOldPassord" runat="server" TextMode ="Password"  CssClass="input-flat"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label for="RecoveryPasssword" >New Password: </label> 
                                <asp:TextBox ID="RecoveryPassword" runat="server" TextMode ="Password"  CssClass="input-flat"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label for="RecoveryConfirmPassword" >Confirm Password:</label> 
                                <asp:TextBox ID="RecoveryConfirmPassword" runat="server" TextMode="Password"  CssClass="input-flat"></asp:TextBox>
                            </div>

                        </div>
 
                             

                        </div>

                        <div class="modal-footer">
                          <a href="#close" class="mbtn-close">Cancel</a>   
                          <asp:Button ID="RecoveryDelete" runat="server" text="Delete User" OnClientClick ="return confirm('You are about to delete a user from the database, click okay to continue?')" class="mbtn-close"/>
                          <asp:Button ID="RecoveryChangePassword" runat="server" text="Change User Password" OnClientClick ="return confirm('Are you sure you want to the user password?')" class="mbtn"/>
                        </div>

                        </div>


                      </div>
                     <!-- /Password Recovery Modal -->
                            

                    <!-- Modal for Compose Email -->
                    <div class="modal" id="compose-email" aria-hidden="true">
                      <div class="modal-dialog" style="width:700px; top: 5%;">
                        <div class="modal-header">
                          <h2>Send Email to User?</h2>
                          <a href="#close" class="btn-close" aria-hidden="true">×</a> <!--CHANGED TO "#close"-->
                        </div>
                       <div class="modal-body" >
                          
                           

                            <div class="form-container"style="height:120px">
                                 
                                     <h3>RECIPIENT(S)</h3>
                                    
                                 
                                    <div class="form-group" style="width:45%;">
                                        <label for="RecipientName" >Recipient Name:</label>
                                        <asp:DropDownList ID="RecipientName" runat="server" AutoPostBack="true"  OnSelectedIndexChanged ="SelectRecipient_SelectedIndexChanging"   CssClass="select">
                                        <asp:ListItem Selected="True" Text="Select All Registered Users" value="" ></asp:ListItem>
                                    
                                    </asp:DropDownList>
                                    </div>

 
                                    <div class="form-group" style="width:45%;float:right;">
                                        <label for="SenderEmail" >Sender Email:</label> 
                                        <asp:TextBox ID="SenderEmail" runat="server" placeholder="Example: john@domain.com"  CssClass="input"></asp:TextBox>
                                    </div>
                                    
                                     
                                    <div class="form-group" style="width:100%; height:120px;">
                                        <label for="RecipientEmailAddresses" >Recipient Email(s):</label> 
                                        <asp:TextBox ID="RecipientEmailAddresses" runat="server"  TextMode ="MultiLine" CssClass="textarea-news"  height="90"></asp:TextBox>
                                    </div>
                                    
                            </div>

                            <div class="form-container">
                                 
                                     <h3>MESSAGE TO SEND</h3>

                                  
                                    <div class="form-group" style="width:106%;">
                                        <label for="EmailSubject" >Message Subject:</label> 
                                        <asp:TextBox ID="EmailSubject" runat="server" CssClass="input"></asp:TextBox>
                                    </div>
                                          
                                    <div class="form-group" style="width:100%; height:160px;">
                                        <label for="EmailMessageBody" >Message Body:</label> 
                                        <asp:TextBox ID="EmailMessageBody" runat="server"  TextMode ="MultiLine"  style="height:130px;" CssClass="textarea-news"></asp:TextBox>
                                    </div>
                                    
                            </div>
                            
                             

                        </div>

                        <div class="modal-footer">
                          <a href="#close" class="mbtn-close">Cancel</a>   
                          <asp:Button ID="SendEmail" runat="server" text="Send Mail" OnClientClick ="return confirm('Confirm message sending!')" class="mbtn"/>
                        </div>

                        </div>


                      </div>
                     <!-- /Compose Email Modal -->
                        

                    
                    <!-- Modal for SMS API Configuration -->
                    <div class="modal" id="api-configuration" aria-hidden="true">
                      <div class="modal-dialog" style="width:700px; top: 5%;">
                        <div class="modal-header">
                          <h2>Set or Modify SMS API Configuration?</h2>
                          <a href="#close" class="btn-close" aria-hidden="true">×</a> <!--CHANGED TO "#close"-->
                        </div>
                       <div class="modal-body" >
                          
                            <div class="form-container"style="height:120px">
                                 
                                     <h3>API ACCOUNT DETAILS</h3>
                                     
                                    <div class="form-group" style="width:106%;">
                                        <label for="BulkSMSAccountUsername" >Bulk SMS Account Username:</label> 
                                        <asp:TextBox ID="BulkSMSAccountUsername" runat="server" placeholder="The Username you Registered with on the SMS Platform"  CssClass="input"></asp:TextBox>
                                    </div>
                                 
                                    <div class="form-group" style="width:106%;">
                                        <label for="EmailSubject" >Bulk SMS Account Password:</label> 
                                        <asp:TextBox ID="BulkSMSAccountPassword" runat="server" TextMode ="Password" Placeholder="***************" CssClass="input"></asp:TextBox>
                                    </div>
                                          
                                    <div class="form-group" style="width:106%;height:80px;">
                                        <label for="BulkSMSSecurityCode" >Bulk SMS Account Password:</label> 
                                        <asp:TextBox ID="BulkSMSSecurityCode" runat="server" TextMode ="Password" Placeholder="Enter Security Code to Modify this Setting" CssClass="input"></asp:TextBox>
                                    </div>
                                          
                            </div>

                            <div class="form-container">
                                 
                                     <h3>API CONFIGURATION LINK</h3>
                                  
                                    <div class="form-group" style="width:100%; height:160px;">
                                        <label for="APILink" >Bulk SMS API Link:</label> 
                                        <asp:TextBox ID="BulkSMSAPILink" runat="server"  TextMode ="MultiLine" Placeholder="http://wwww.smsapiwebisteaddres.com/api/?" style="height:130px;" CssClass="textarea-news"></asp:TextBox>
                                    </div>
                            </div>

                        </div>

                        <div class="modal-footer">
                          <a href="#close" class="mbtn-close">Cancel</a>   
                          <asp:Button ID="SaveAPIConfiguration" runat="server" text="Save Configuration" OnClientClick ="return confirm('Are you sure you want to save this SMS API configuration settings? This will overwrite the existing setting!!')" class="mbtn"/>
                        </div>

                        </div>


                      </div>
                     <!-- /SMS API Configuration Modal -->
                        


                    <!-- Modal for Send Messages -->
                    <div class="modal" id="send-messages" aria-hidden="true">
                      <div class="modal-dialog" style="width:700px; top: 5%;">
                        <div class="modal-header">
                          <h2>Send SMS Message(s)?</h2>
                          <a href="#close" class="btn-close" aria-hidden="true">×</a> <!--CHANGED TO "#close"-->
                        </div>
                       <div class="modal-body" >
                          
                           

                            <div class="form-container"style="height:120px">
                                 
                                     <h3>RECIPIENT(S)</h3>
                                    
                                 
                                    <div class="form-group" style="width:98%;">
                                        <label for="SMSRecipients" >Recipient Name:</label>
                                        <asp:DropDownList ID="SMSRecipients" runat="server" AutoPostBack="true"  OnSelectedIndexChanged ="SelectSMSRecipient_SelectedIndexChanging"   CssClass="select">
                                        <asp:ListItem Selected="True" Text="Select All Registered Users" value="" ></asp:ListItem>
                                    
                                    </asp:DropDownList>
                                    </div>

 
                                    <div class="form-group" style="width:100%; height:120px;">
                                        <label for="SMSRecipientNumbers" >Recipient Number(s):</label> 
                                        <asp:TextBox ID="SMSRecipientNumbers" runat="server"  TextMode ="MultiLine" CssClass="textarea-news" Placeholder="Example: 08033333333,08033333332 (Comma (,) separation only allowed" height="90"></asp:TextBox>
                                    </div>
                                    
                            </div>

                            <div class="form-container">
                                 
                                     <h3>MESSAGE TO SEND</h3>

                                  
                                    <div class="form-group" style="width:106%;">
                                        <label for="SenderName" >Sender Name:</label> 
                                        <asp:TextBox ID="SenderName" runat="server" Placeholder="WMP Portal  (10 Character Maximum)" CssClass="input"></asp:TextBox>
                                    </div>
                                          
                                    <div class="form-group" style="width:100%; height:160px;">
                                        <label for="SMSMessageBody" >Message Body:</label> 
                                        <asp:TextBox ID="SMSMessageBody" runat="server"  TextMode ="MultiLine"  style="height:130px;" CssClass="textarea-news"></asp:TextBox>
                                    </div>
                                    
                            </div>
                            
                             

                        </div>

                        <div class="modal-footer">
                          <a href="#close" class="mbtn-close">Cancel</a>   
                          <asp:Button ID="SendSMS" runat="server" text="Send Message" OnClientClick ="return confirm('Confirm message sending!')" class="mbtn"/>
                        </div>

                        </div>


                      </div>
                     <!-- /Send Messages Modal -->
                            

       
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
