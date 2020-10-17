<%@ Page Language="VB" AutoEventWireup="false" CodeFile="changepassword.aspx.vb" Inherits="exportpermit"    %>

<%@ Import Namespace="System.Data" %>

 <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
 

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>CHANGE PASSWORD</title>
<link rel="stylesheet" href="css/style.css" type="text/css" />
<!--login-->
	<link rel="stylesheet" href="template/login/css/style.css" type="text/css" />
    <script type="text/javascript" src="template/login/js/jquery.min.js"></script>
    <script src="template/login/js/WaterMark.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#txtUserName, #txtPassword").WaterMark({
                WaterMarkTextColor: '#fff'
            });
        });
    </script>
 

<!--slideshow-->
    <link rel="stylesheet" href="template/slideshow/themes/default/default.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="template/slideshow/css/nivo-slider.css" type="text/css" media="screen" />
<!--menu-->
<link href="template/menu/css/dcmegamenu.css" rel="stylesheet" type="text/css" />
<!--<script type="text/javascript" src="template/menu/js/jquery.min.js"></script>-- Enable if not working. conflict with tooltip-->
<script type='text/javascript' src='template/menu/js/jquery.hoverIntent.minified.js'></script>
<script type='text/javascript' src='template/menu/js/jquery.dcmegamenu.1.3.3.js'></script>
<script type="text/javascript">
    $(document).ready(function ($) {
        $('#mega-menu-9').dcMegaMenu({
            rowItems: '3',
            speed: 'fast',
            effect: 'fade'
        });
    });


</script>

<link href="template/menu/css/skins/green.css" rel="stylesheet" type="text/css" />

<%
  
    Dim username As String = Request("txtUserName1")
    Dim pwd As String = Request("txtPassword1")
    Dim pgName As String = Request("page")
    
    Dim GenTool As smsXMobile.smsXMobile = xsmsCentralToolx.SetTool
    
    If String.IsNullOrEmpty(username) = False AndAlso String.IsNullOrEmpty(pwd) = False Then
        Dim sql As String = "select sysID,companyName,username,companyEmail,recordStatus from  companyregistration where username=" & GenTool.addbackslash(username) & _
        "  AND pwd=" & GenTool.addbackslash(pwd)
        Dim ds As DataSet = GenTool.DataSetData(sql)
        
        If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
            With ds.Tables(0).Rows(0)
                If Val(.Item(4)) = 0 Then
                    Session("ID") = .Item(0)
                    Session("cname") = .Item(1)
                    Session("username") = .Item(2)
                    Session("email") = .Item(3)
                    Session("status") = .Item(4)
                Else
                    Session.Clear()
                    CyMessageBox.Show("Your account is DORMANT,please contact admin")
                End If
                
            End With
            
            ds.Dispose()
            
        Else
            Session.Clear()
            CyMessageBox.Show("Invalid Username or Password")
        End If
      
    End If
 
    %>
    
<!---->
    <style type="text/css">
        #Button2
        {
            height: 26px;
        }
        .style1
        {
            width: 13px;
        }
        .style6
        {
            width: 285px;
        }
        .style7
        {
            width: 270px;
        }
        .style8
        {
            width: 13px;
            height: 20px;
        }
        .style9
        {
            width: 285px;
            height: 20px;
        }
        .style10
        {
            height: 20px;
        }
    </style>
    </head>

<body>
    
 <form id="form1" runat="server">
   
<div align="center">
    <div id="content">
    	<div class="top">
        	<div id="top_holder">
            	<div id="top_left">
                    <%-- <%  
                	    Dim web1 As New System.Net.WebClient
                	    Dim sr1 As System.IO.StreamReader
                	    If String.IsNullOrEmpty(Session("email")) = True Then
                	        sr1 = New System.IO.StreamReader(web1.OpenRead(Server.MapPath("~/body/loginformexport.aspx")))
                	    Else
                	        sr1 = New System.IO.StreamReader(web1.OpenRead(Server.MapPath("~/body/loginedform.aspx")))
                	    End If
                	    
                	    'Response.Write(sr1.ReadToEnd)
                	    sr1.Dispose()
                	    web1.Dispose()

                	%>   --%>                      
                	                	 
                </div>
              
              
            	<%--<div id="top_right">
                	 
                    <div id="search">
                    	<input name='' id="theinput" type="text" />
                    </div>
                	<div id="search_button">
                        <button type='submit' name='Submit' style='background:none; border:none; cursor:pointer' >	
                            <img src='images/view.png' />
                        </button>
                    </div>
                  
                </div>--%>
 
            </div>
        </div>
        <div id="header_holder">
            <div id="header">
                <div id="header_left"><img src="images/logo.png" /></div>
                <div id="header_right">
                    <div class="demo-container">
                        <div class="green">  
                            <ul id="mega-menu-9" class="mega-menu"  style ="background-color:#F7F7F7">

                            <%
                                If Val(Request("pg")) = 1 Then
                                    Response.Write("<li><a href='Admin.aspx'>Home</a></li>")
                                Else
                                    Response.Write("<li><a href='Default.aspx'>Home</a></li>")
                                End If
                                
                                %>
   
                                <li><a href="aboutus.aspx">About Us</a></li>
                                <li><a href="contactus.aspx">Contact US</a></li>

                            </ul>
                        </div>
                    </div>
                </div>
                            <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                            </cc1:ToolkitScriptManager>
            </div>
        </div>
        
		<div id="main_page">
        
          <%--  <div id="submenubar">
                <div id="bread">You are Here > <a href="#">&nbsp;</a></div>
                <div id="request"><a href="#">Registration</a></div>
            </div>--%>
            
            <div id="page">
    

<!--start home-->
<div id="item1">
	 
  <div class="item_title">&nbsp;&nbsp;&nbsp; FORGOT PASSWORD</div>

 <div>
	  <center>
        <div style="width : 75%" id="main-menu">
        <asp:UpdatePanel ID="UpdatePanel1"  runat ="server"  >
        <ContentTemplate>

           <table style="width: 100%;" bgcolor="Silver">
         <tr>
             <td class="style8">
                 </td>
             <td align="right" class="style9">
                 </td>
             <td class="style10">
                 <asp:Label ID="lblMsg" runat="server" Font-Names="Calibri" Font-Size="11pt" 
                     ForeColor="Red"></asp:Label>
                 <td class="style10">
                 </td>
         </tr>
         <tr>
             <td class="style1">
                 &nbsp;</td>
             <td align="right" class="style6">
                <asp:Label ID="Label2" runat="server" Text="Old Password" Font-Names="Agency FB"></asp:Label></td>
             <td>
                                    <asp:TextBox ID="txtoldpass" runat="server" ToolTip="enter username" 
                                        ValidationGroup="username|Invalid Username" 
                     Width="204px" TextMode="Password"></asp:TextBox>
                                <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td class="style1">
                 &nbsp;</td>
             <td align="right" class="style6">
                 &nbsp;</td>
             <td>
                 
                                    &nbsp;<td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td class="style1">
                 &nbsp;</td>
             <td align="right" class="style6">
                 <asp:Label ID="Label1" runat="server" Text="New Password:" 
                     Font-Names="Agency FB"></asp:Label>
             </td>
             <td>
                 
                                    <asp:TextBox ID="txtPasswrod" runat="server" TextMode="Password" 
                                        ToolTip="enter username" ValidationGroup="username|Invalid Username" 
                                        Width="204px"></asp:TextBox>
                                                 
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td class="style1">
                 &nbsp;</td>
             <td align="right" class="style6">
                 &nbsp;</td>
             <td>
                 
                                    &nbsp;<td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td class="style1">
                 &nbsp;</td>
             <td align="right" class="style6">
                 <asp:Label ID="Label3" runat="server" Text="Retype Password:" 
                     Font-Names="Agency FB"></asp:Label>
             </td>
             <td>
                 
                                    <asp:TextBox ID="txtretryPassword" runat="server" ToolTip="enter username" 
                                        ValidationGroup="username|Invalid Username" 
                     Width="204px" TextMode="Password"></asp:TextBox>
                                                 
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td class="style1">
                 &nbsp;</td>
             <td class="style6">
                 &nbsp;</td>
             <td>
                 <asp:UpdateProgress ID="updProgress" runat="server" 
                     AssociatedUpdatePanelID="UpdatePanel1">
                     <ProgressTemplate>
                         <table style="width: 70%;">
                             <tr>
                                 <td>
                                     &nbsp;
                                     <div>
                                         <img alt="progress" 
                                             src="images/sa/glossy-3d-blue-hourglass-icon.png" />
                                     </div>
                                 </td>
                                 <td class="style7">
                                     <div style="font-family: calibri; font-size: small; color : red">
                                         processing your request,please wait...</div>
                                     &nbsp;
                                 </td>
                             </tr>
                             <tr>
                                 <td>
                                     &nbsp;</td>
                                 <td class="style7">
                                     &nbsp;
                                 </td>
                             </tr>
                         </table>
                        
                     </ProgressTemplate>
                 </asp:UpdateProgress>
                 <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td class="style1">
                 &nbsp;</td>
             <td class="style6">
                 &nbsp;</td>
             <td>
                 <asp:Button ID="btnSend" runat="server" Text="Submit" style="height: 26px" />
                 <cc1:ConfirmButtonExtender ID="btnSend_ConfirmButtonExtender" runat="server" 
                     ConfirmOnFormSubmit="True" 
                     ConfirmText="Are you sure you want to Upload this record?" Enabled="True" 
                     TargetControlID="btnSend">
                 </cc1:ConfirmButtonExtender>
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td class="style1">
                 &nbsp;</td>
             <td class="style6">
                 &nbsp;
             </td>
             <td>
              
                 &nbsp;<td>
                 &nbsp;
             </td>
         </tr>
         <tr>
             <td class="style1">
                 &nbsp;</td>
             <td class="style6">
                 &nbsp;
             </td>
             <td style="font-family: calibri, Arial, Helvetica, sans-serif">
              </td>
             <td>
                 &nbsp;
             </td>
         </tr>
         <tr>
             <td class="style1">
                 &nbsp;</td>
             <td class="style6">
                 &nbsp;
             </td>
             <td>
                 &nbsp;
             </td>
             <td>
                 &nbsp;
             </td>
         </tr>
         <tr>
             <td class="style1">
                 &nbsp;</td>
             <td class="style6">
                 &nbsp;</td>
             <td>
           
             </td>
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td class="style1">
                 &nbsp;</td>
             <td class="style6">
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
         </tr>
     </table>

</ContentTemplate>
</asp:UpdatePanel>
        </div></center>
   
 
</div>

        
</div>
    

<!--end home-->



   				<div id="cards"><img src="images/partners.png" /></div>
            </div>
 
		</div>        
    </div>       
      <div id="footer">
		<div id="footer_content_left">Copyright &copy; 2012. All rights reserved.arget="_blank"><strong>Powered by#</strong></a>
        
                    <div id="social">
                        <div id="social_content_f"><a href="#" alt="Follow us on Facebook" title="Follow us on Facebook">&nbsp;</a></div>
                        <div id="social_content_t"><a href="#" alt="Twitter" title="Twitter">&nbsp;</a></div>
                        <div id="social_content_y"><a href="#" alt="Youtube" title="Youtube">&nbsp;</a></div>
                        <div id="social_content_r"><a href="#" alt="RSS" title="RSS">&nbsp;</a></div>
                        <div id="social_content_g"><a href="#" alt="GROUP" title="GROUP">&nbsp;</a></div>
                    </div>
        </div>
   </div>
</div>
    </form>
</body>
</html>               