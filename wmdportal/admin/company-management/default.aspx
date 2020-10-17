<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="WMDPortal._default20" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Weight & Measures : Admin CPanel - Company Management</title>

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
                        <asp:Panel ID="CompanyManagementLink" runat="server" CssClass ="PanelDiv"><li class="active" style="background-image:url(../../../images/management.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a href="./"><span>Company Management</span></a></li> </asp:Panel>
                        <asp:Panel ID="InstrumentManagementLink" runat="server" CssClass ="PanelDiv"><li style="background-image:url(../../../images/instrument.png) ;background-repeat:no-repeat; background-position: 10px 10px; background-size:30px 30px; "><a href="../instrument-management/"><span>Instrument Management</span></a></li></asp:Panel>
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
               
                <div class ="dashboard-title">Company Management</div>


                <div class="dashboard-icon-container"> 
                            <div class="dashboard-icon-container-title">
                                <span style="float:left;margin-right:30px"><strong>Type: </strong></spaType: </strong></span>

                              <div class="form-group" style="width:20%;height:20px;float:left;margin:0px;margin-right:10px;margin-top:-5px;">
                                    <asp:DropDownList ID="SelectPayment" runat="server" AutoPostBack="true" OnSelectedIndexChanged ="SelectPaymentType_SelectedIndexChanged" CssClass="select">
                                        <asp:ListItem Text="Approve Deposit" value="Deposit" ></asp:ListItem>
                                     </asp:DropDownList>

                            </div>
                                     
                            <div class="form-group" style="width:15%;height:20px;float:left;margin:0px;margin-right:10px;margin-top:-5px;">
                                    <asp:DropDownList ID="AprrovedWaiting" runat="server" AutoPostBack="true" OnSelectedIndexChanged ="SelectPaymentType_SelectedIndexChanged" CssClass="select">
                                        <asp:ListItem Selected="True" Text="...Select Status..." value="None" ></asp:ListItem>
                                        <asp:ListItem Text="Awaiting Approval" value="Waiting" ></asp:ListItem>
                                        <asp:ListItem Text="Approved Payment" value="Approved" ></asp:ListItem>
                                    </asp:DropDownList>

                            </div>
                                   
                            <div class="form-group" style="width:20%;height:20px;float:left;margin:0px;margin-right:10px;margin-top:-5px;">                                    
                                    <asp:DropDownList ID="SelectCompany" runat="server" AutoPostBack="true" OnSelectedIndexChanged ="SelectCompany_SelectedIndexChanged" CssClass="select">
                                        <asp:ListItem Selected="True" Text="...Select a Company..." value="None" ></asp:ListItem>
                                    </asp:DropDownList>

                            </div>

                                                
                                                            
                        </div>
                          
                </div>
           <asp:ScriptManager ID="ScriptManager1" runat="server" />
           <asp:UpdatePanel ID="UpdatePanel1" runat="server" EnableViewState ="true"  >
           <ContentTemplate>

                 <asp:Panel ID="CompanyManagementViewPanel" runat ="server" style="margin-bottom:10px;float:left;">

                    
                        <asp:Panel ID="ProcessingData" runat="server" class="loading"></asp:Panel>
                        <asp:Panel ID="NoRecord" runat="server" class="no-record"><span>No record found!</span></asp:Panel>

                            <asp:GridView ID="DepositPaymentGridView" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="8" CssClass="grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" OnSelectedIndexChanged = "OnDepositSelectedIndexChanged">        
                                     <Columns>
                                         <asp:BoundField DataField="companyName" ItemStyle-CssClass ="left-align" ItemStyle-wrap="true" HeaderStyle-Width="111" ItemStyle-Width="110"  HeaderText="Company" />
                                         <asp:BoundField DataField="transactionID" ItemStyle-wrap="true" HeaderStyle-Width="125" ItemStyle-Width="125" HeaderText="Trans. ID" />
                                         <asp:TemplateField ItemStyle-wrap="true" ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass ="right-align" HeaderStyle-Width="105" ItemStyle-Width="105" HeaderText="Amount" > 
                                            <ItemTemplate>
                                                <asp:Label ID="AMount" runat ="server" Text='<%# DataBinder.Eval(Container.DataItem, "amountDeposit", "{0:#,#0.00}")%>' ></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:BoundField DataField="bankName" ItemStyle-CssClass ="left-align" ItemStyle-wrap="true" HeaderText="Bank Name" /> 
                                         <asp:BoundField DataField="paymentMode" ItemStyle-wrap="true" HeaderStyle-Width="60" ItemStyle-Width="60" HeaderText="Mode" />
                                         <asp:BoundField DataField="narration" ItemStyle-CssClass ="left-align" ItemStyle-wrap="true" HeaderStyle-Width="115" ItemStyle-Width="117" HeaderText="Narration" />      
                                         <asp:BoundField DataField="depositDate" ItemStyle-wrap="true" HeaderStyle-Width="65" ItemStyle-Width="65" HeaderText="Date" />        
                                         <asp:BoundField DataField="approvalStatus" ItemStyle-wrap="true" HeaderStyle-Width="60" ItemStyle-Width="60" HeaderText="Status" />        
                                         <asp:BoundField DataField="approvalNarration" ItemStyle-CssClass ="left-align" ItemStyle-wrap="true" HeaderStyle-Width="105" ItemStyle-Width="105" HeaderText="App. Narration" />
                                         <asp:ButtonField Text="Select" ItemStyle-ForeColor ="DarkGray" HeaderText ="Action" CommandName="Select" HeaderStyle-Width ="50" ItemStyle-Width="50" />
                                      </Columns>
                            </asp:GridView>
 
                        <div style="margin-top:50px;float:left;">

                         <asp:Panel runat="server" ID="ApproveORDisapproveTab" Visible="false"  style="margin-bottom:10px;float:left;height:300px;">
	                        <div class="export-management-container">
                    
                                <div class="general-form" >
                                 
                                <div class="form-group" style="width:30%;margin-bottom:20px;">
                                    <label for="CompanyName" class ="label" >Company Name:</label> 
                                    <asp:TextBox ID="CompanyName" runat="server" Enabled="false" CssClass="input-flat"></asp:TextBox>
                                </div>
                 
                                <div class="form-group" style="width:30%;margin-bottom:20px;">
                                    <label for="TransactionAmount" class ="label" >Transaction Amount:</label> 
                                    <asp:TextBox ID="TransactionAmount" runat="server" Enabled="false" CssClass="input-flat"></asp:TextBox>
                                </div>
                              
                                <div class="form-group" style="width:30%;margin-bottom:20px;">
                                    <label for="TransactionID" class ="label" >Transaction ID:</label> 
                                    <asp:TextBox ID="TransactionID" runat="server" Enabled="false" CssClass="input-flat"></asp:TextBox>
                                </div>
                                    
                                <div class="form-group" style="width:30%;float:left;margin-bottom:20px;">
                                    <label for="PaymentType" class ="label" >Payment Type:</label> 
                                    <asp:TextBox ID="PaymentType" runat="server" Enabled="false" CssClass="input-flat"></asp:TextBox>
                                </div>

                                <div class="form-group" style="width:30%;margin-bottom:20px;">
                                    <label for="OrderID" class ="label" >Order ID:</label> 
                                    <asp:TextBox ID="OrderID" runat="server" Enabled="false" CssClass="input-flat"></asp:TextBox>
                                </div>

                             
                                <div class="form-group" style="width:30%;float:left;margin-bottom:20px;">
                                    <label for="Narration" class ="label" >Narration:</label> 
                                    <asp:TextBox ID="Narration" runat="server" TextMode="MultiLine" CssClass="textarea"></asp:TextBox>
                                </div>
                                    <br />

                               <div class="form-group"  style="float:left;width:45%;margin-top:20px;margin-left:-20px;">

                                <div class="form-group"  style="float:left;width:20%;margin-top:-20px;margin-left:20px;padding-top:5px;">
                                    <asp:RadioButton ID="Approve" GroupName ="ApprovalState" Enabled="true" AutoPostBack ="true" OnCheckedChanged="ApprovalCheck_OnCheckedChanged"  runat ="server" CssClass ="checkbox"></asp:RadioButton>
                                    <span class="checkbox"  style="font-weight:bolder;float:left;margin-top:-20px; width:94%;margin-left:25px;">Approve</span>
                                </div>


                                <div class="form-group"  style="float:left;width:20%;margin-top:-20px;margin-left:20px;padding-top:5px;">
                                    <asp:RadioButton ID="Reject" GroupName ="ApprovalState" Enabled="true" AutoPostBack="true" OnCheckedChanged="ApprovalCheck_OnCheckedChanged" runat ="server" CssClass ="checkbox"></asp:RadioButton>
                                     <span class="checkbox"  style="font-weight:bolder;float:left;margin-top:-20px; width:94%;margin-left:25px;">Reject</span>

                                </div>

                                <div class="form-group"  style="float:left;width:30%;margin-top:-20px;margin-left:20px;padding-top:5px;">
                                    <asp:CheckBox ID="ApprovedOrNot" GroupName ="ApprovalState" Enabled="false" runat ="server" CssClass ="checkbox"></asp:CheckBox>
                                    <span class="checkbox"  style="font-weight:bolder;float:left;margin-top:-20px; width:94%;margin-left:25px;">Approval Status</span>

                                </div>

                            </div>

                                <div class="form-group" style="width:10%;display:inline-block;margin-left:5px;margin-top:-15px;">
                                    <asp:Button ID="SaveRecord" runat ="server" CssClass ="pay-button-save"  Text ="Save Record" />

                                </div> 
                
	                            </div>
                            </div>
	                    </asp:Panel>
                    
                    </div>

 
                        </asp:Panel>

            </ContentTemplate>
            </asp:UpdatePanel>      

            </div>
            </div>
            


        <div class="copyright">
        <div class="copy">
            <div class="copyright-text">Copyright &copy; 2013 - 2015. All rights reserved. Developed by: John<div class="social">
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
