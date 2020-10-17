<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="WMDPortal._default22" %>

<%@ Import Namespace="MySql.Data.MySqlClient" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.MySqlClient" %>
<%@ Import Namespace="System" %>
<%@ Import Namespace="System.Configuration" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Weight & Measures : Admin CPanel - File Storage</title>

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
                        <asp:Panel ID="CompanyManagementLink" runat="server" CssClass ="PanelDiv"><li style="background-image:url(../../../images/management.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a href="../company-management/"><span>Transaction Approval</span></a></li> </asp:Panel>
                        <asp:Panel ID="InstrumentManagementLink" runat="server" CssClass ="PanelDiv"><li style="background-image:url(../../../images/instrument.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a href="./"><span>Instrument History</span></a></li></asp:Panel>
                        <!-- <asp:Panel ID="StaticDataLink" runat="server" CssClass ="PanelDiv"><li style="background-image:url(../../../images/data.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a href="../career/"><span>Static Data</span></a></li></asp:Panel> -->
                        <asp:Panel ID="ExportPermitManagementLink" runat="server" CssClass ="PanelDiv"><li style="background-image:url(../../../images/data.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a href="../export-management/"><span>Export Permit History</span></a></li></asp:Panel>
                        <asp:Panel ID="ImportPermitManagementLink" runat="server" CssClass ="PanelDiv"><li style="background-image:url(../../../images/data.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a href="./"><span>Import Permit History</span></a></li></asp:Panel>
                        <asp:Panel ID="FileManagerLink" runat="server" CssClass ="PanelDiv"><li class="active" style="background-image:url(../../../images/file-manager.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a href="../file-manager/"><span>File Storage</span></a></li></asp:Panel>
                        <asp:Panel ID="ReportingLink" runat="server" CssClass ="PanelDiv"><li style="background-image:url(../../../images/reports.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a href="../reports/"><span>Report Pool</span></a></li></asp:Panel>
                        <asp:Panel ID="ExportDataLink" runat="server" CssClass ="PanelDiv"><li style="background-image:url(../../../images/export-data-return.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a href="../export-data/"><span>Export Return Data</span></a></li></asp:Panel>
                        <asp:Panel ID="HomePageTab" runat="server" CssClass ="PanelDiv"><li style="background-image:url(../../../images/table.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a href="../../../" target ="_blank"><span>Visit Homepage</span></a></li></asp:Panel>

                        <li style="background-image:url(../../../images/exit.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a >
                            <asp:Button ID="LogoutAdmin" runat="server" CssClass ="button-label" Text="Log Me Out" /></a></li>
                    </ul>
                </nav>


            </div>
            <div class="dashboard-container">
               
                <div class ="dashboard-title">File Manager</div>


                <div class="dashboard-icon-container"> 
                            <div class="dashboard-icon-container-title">
                                <span style="float:left;margin-right:5px"><strong>Company Name: </strong></span>
                                 
                            <div class="form-group" style="width:20%;height:20px;float:left;margin:0px;margin-top:-5px;">
                                    <asp:DropDownList ID="SelectCompany" runat="server" AutoPostBack="true" OnSelectedIndexChanged ="SelectCompany_SelectedIndexChanged" CssClass="select">
                                    </asp:DropDownList>

                            </div>
                                
                           <span style="float:left;margin-right:5px"><strong>File Group: </strong></span>
                                  
                            <div class="form-group" style="width:15%;height:20px;float:left;margin:0px;margin-top:-5px;">
                                    <asp:DropDownList ID="SelectFileGroup" runat="server" AutoPostBack ="true" OnSelectedIndexChanged ="SelectFileGroup_SelectedIndexChanged" CssClass="select">
                                        <asp:ListItem Selected="True" Text="Display All Group" value="All Group" ></asp:ListItem>
                                        <asp:ListItem Text="Export Data Return" value="Export" ></asp:ListItem>
                                        <asp:ListItem Text="PIA Export Data Return" value="PIA" ></asp:ListItem>
                                        <asp:ListItem Text="Other Documents" value="Other" ></asp:ListItem>
                                    </asp:DropDownList>

                            </div>

                            <span style="float:left;margin-right:5px"><strong>File Type: </strong></span>
                                      
                            <div class="form-group" style="width:15%;height:20px;float:left;margin:0px;margin-top:-5px;">
                                    <asp:DropDownList ID="SelectFileType" runat="server" AutoPostBack ="true" OnSelectedIndexChanged ="SelectFileType_SelectedIndexChanged" CssClass="select">
                                        <asp:ListItem Selected="True" Text="All File Types" value="All Type" ></asp:ListItem>
                                        <asp:ListItem Text="Word Document (.docx)" value="doc" ></asp:ListItem>
                                        <asp:ListItem Text="Excel Document (.xlx)" value="xls" ></asp:ListItem>
                                        <asp:ListItem Text="PowerPoint Document (.ppt)" value="ppt" ></asp:ListItem>
                                        <asp:ListItem Text="PDF Document (.pdf)" value="pdf" ></asp:ListItem>
                                        <asp:ListItem Text="Text Document (.txt)" value="txt" ></asp:ListItem>
                                        <asp:ListItem Text="Image (.jpg, .jpeg, .png etc.)" value="png" ></asp:ListItem>
                                    </asp:DropDownList>

                            </div>


                            </div>

                                <asp:Panel ID="ProcessingData" runat="server" class="loading"></asp:Panel>
                                <asp:Panel ID="NoRecord" runat="server" class="no-record"><span>No file(s) found!</span></asp:Panel>


                          <div style="width:100%;float:left;padding:0;margin:0;">
                          <asp:Panel ID="Panel1" runat ="server" style="margin-bottom:10px">
                           
                              <asp:GridView ID="DownloadGridView"  OnPageIndexChanging="DownloadGridView_PageIndexChanging" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="35" CssClass="download" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" >        
                                     <Columns>
                                    <asp:TemplateField > 
                                        <ItemTemplate>
                                          <!--  <asp:CheckBox ID="DepositSelector" runat="server"/>
                                            <asp:HyperLink ID="HlFile" runat="server" NavigateUrl ="../File Manager/" Text='<%# Eval("fileName") %>'> </asp:HyperLink> -->
                                            
                                            <a id="A1" href='<%# String.Format("../../File Manager/UploadFiles/{0}", Eval("fileName"))%>' runat="server" class="download-wrapper-cover" title ='<%# Eval("description") %>' >Download</a>
                                            <asp:Image ID="DownloadDocPreviews" ImageUrl ="../../../File Manager/p.png" runat="server" class='<%# String.Format("download-doc-preview-{0}", Eval("fileType"))%>'></asp:Image>
                                            <asp:Label runat ="server" ID="DownloadDocName" text='<%# Eval("fileName") %>' CssClass ="download-doc-name "></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                            
                                     </Columns>
                                  <PagerSettings Position="Bottom" Mode="NextPreviousFirstLast" FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Prev"/>
                            </asp:GridView>
                        </asp:Panel>
                    
                        </div><!--General form -->

                     
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
