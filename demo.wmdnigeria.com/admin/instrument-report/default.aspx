<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="WMDPortal._default42" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Weight & Measures : Admin CPanel - Export Management</title>

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
    <header>
        <div class="header">
            <div class="logo">WMD Nigeria CPanel</div>
            <asp:Label ID="loggedUser" runat="server" style="background-image:url(../../../images/arrow-down.png) ;background-repeat:no-repeat; background-position:right; background-size:15px 10px;" class="admin-loggedin" text="" />
        </div>
    </header>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="overall-container">
            <div class="sidebar">
                <nav>
                    <ul>
                        <asp:Panel ID="DashboardLink" runat="server" CssClass ="PanelDiv"><li  style="background-image:url(../../../images/dashboard.png) ;background-repeat:no-repeat; background-position: 10px 13px;  background-size:25px 25px; "><a href="../dashboard/"><span>Dashboard </span></a></li>  </asp:Panel>
                        <asp:Panel ID="CompanyManagementLink" runat="server" CssClass ="PanelDiv"><li style="background-image:url(../../../images/management.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a href="../company-management/"><span>Company Management</span></a></li> </asp:Panel>
                        <asp:Panel ID="InstrumentManagementLink" runat="server" CssClass ="PanelDiv"><li style="background-image:url(../../../images/instrument.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a href="../instrument-management/"><span>Instrument Management</span></a></li></asp:Panel>
                        <!-- <asp:Panel ID="StaticDataLink" runat="server" CssClass ="PanelDiv"><li style="background-image:url(../../../images/data.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a href="../career/"><span>Static Data</span></a></li></asp:Panel> -->
                        <asp:Panel ID="ExportPermitManagementLink" runat="server" CssClass ="PanelDiv"><li style="background-image:url(../../../images/data.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a href="../export-management/"><span>Export Permit Management</span></a></li></asp:Panel>
                        <asp:Panel ID="ImportPermitManagementLink" runat="server" CssClass ="PanelDiv"><li style="background-image:url(../../../images/data.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a href="./"><span>Import Permit Management</span></a></li></asp:Panel>
                        <asp:Panel ID="FileManagerLink" runat="server" CssClass ="PanelDiv"><li style="background-image:url(../../../images/file-manager.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a href="../file-manager/"><span>Document/File Management</span></a></li></asp:Panel>
                        <asp:Panel ID="ReportingLink" runat="server" CssClass ="PanelDiv"><li style="background-image:url(../../../images/reports.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a href="../reports/"><span>Report / Data Management</span></a></li></asp:Panel>
                        <asp:Panel ID="ExportDataLink" runat="server" CssClass ="PanelDiv"><li class ="active" style="background-image:url(../../../images/export-data-return.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a href="../export-data/"><span>Export Data Return</span></a></li></asp:Panel>
                        <asp:Panel ID="HomePageTab" runat="server" CssClass ="PanelDiv"><li style="background-image:url(../../../images/table.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a href="../../../" target ="_blank"><span>Visit Homepage</span></a></li></asp:Panel>

                        <li style="background-image:url(../../../images/exit.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a >
                            <asp:Button ID="LogoutAdmin" runat="server" CssClass ="button-label" Text="Log Me Out" /></a></li>
                    </ul>
                </nav>


            </div>

       
     
            <div class="dashboard-container">
               
                <div class ="dashboard-title">Export Data Return Reports</div>
                           
                <div class="dashboard-icon-container"> 
                
                <div class="dashboard-icon-container-title">
                    <span style="float:left;margin-right:5px;margin-left:0px;"><strong>Report Type: </strong></span>
                                 
                            <div class="form-group" style="width:20%;height:35px;float:left;margin:0px;margin-top:-5px;">
                                    <asp:DropDownList ID="SelectReport" runat="server" AutoPostBack="true" CssClass="select">
                                        <asp:ListItem Selected="True" Text="...Select Report Type..." value="" ></asp:ListItem>
                                    </asp:DropDownList>

                            </div>
                      
                           <span style="float:left;margin-right:5px;margin-left:0px;"><strong><asp:Label runat="server" ID ="ReportParameterLabel" text="Parameter:"></asp:Label> </strong></span>
                                  
                            <div class="form-group" style="width:20%;height:35px;float:left;margin:0px;margin-top:-5px;">
                                    <asp:DropDownList ID="SelectReportParameter" runat="server" AutoPostBack="true"  CssClass="select">
                                        <asp:ListItem Selected="True" Text="...Select Report Data..." value="" ></asp:ListItem>
                                    </asp:DropDownList>

                            </div>

                    

                            <div class="form-group" style="width:8%;height:35px;float:left;margin:0px;margin-top:-5px;margin-left:5px;">
                                    <asp:TextBox ID="FilterDateFrom" runat="server" CssClass="input" placeholder="Start Date"> </asp:TextBox>
                                                         
                            </div>

                            <div class="form-group" style="width:8%;height:35px;float:left;margin:0px;margin-top:-5px;margin-left:5px;">
                                    <asp:TextBox ID="FilterDateTo" runat="server" CssClass="input" placeholder="End Date"> </asp:TextBox>

                            </div>

                
                             <div class="form-group" style="width:8%;height:35px;float:right;margin:0px;margin-top:-5px;">
                                    <asp:Button ID="ShowReport" runat="server" Height="30" Width="10" OnClientClick="return true" Text=""> </asp:Button>
                                    <asp:Button ID="GetDate" runat="server" Height="30" Text="Filter"> </asp:Button>
                            </div>

                            </div>
                      
                            
                <asp:Panel ID="ProcessingData" runat="server" class="loading"></asp:Panel>
                <asp:Panel ID="NoRecord" runat="server" class="no-record"><span>No record found!</span></asp:Panel>
                    
                <div style="margin:0 auto; width:99%;">
                    <rsweb:ReportViewer ID="NationwideReport" runat="server" Width="100%" height="500" ShowPrintButton="true" ></rsweb:ReportViewer>
                    <rsweb:ReportViewer ID="StateReport" runat="server" Width="100%" height="500" ShowPrintButton="true" ></rsweb:ReportViewer>
                    <rsweb:ReportViewer ID="YearlyReport" runat="server" Width="100%" height="500" ShowPrintButton="true" ></rsweb:ReportViewer>
                </div>
 
                
              


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