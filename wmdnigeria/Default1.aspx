<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default1.aspx.vb" Inherits="_Default1" %>

<%@ Import Namespace="System.Data" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>WEIGHTS AND MEASURES NIGERIA</title>
<link rel="stylesheet" href="css/style.css" type="text/css" />
<!--login-->
	<link rel="stylesheet" href="template/login/css/style.css" type="text/css" />
    <script type="text/javascript" src="template/login/js/jquery.min.js"></script>
    <script src="template/login/js/WaterMark.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#txtUsername, #txtPassword").WaterMark({
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
$(document).ready(function($){
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
    
    If Request("error") <> "" andalso username="" Then
        MessageBox.Show(Me, Request("error"))
        GoTo 30
    End If
    
   
    
    Dim GenTool As smsXMobile.smsXMobile = xsmsCentralToolx.SetTool
    
    If String.IsNullOrEmpty(username) = False OrElse String.IsNullOrEmpty(pwd) = False Then
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
30:
    %>
    
<!---->
    <style type="text/css">
        .style1
        {
            text-align: right;
        }
        .style2
        {
            text-align: left;
        }
        .style3
        {
            font-size: medium;
            color: #111111;
        }
        .style5
        {
            width: 182px;
            height: 141px;
        }
        .style6
        {
            width: 182px;
            height: 129px;
        }
        .style7
        {
            font-family: Calibri;
            font-size: small;
        }
        .style8
        {
            color: #000000;
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
                    <%  
                	    Dim web1 As New System.Net.WebClient
                	    Dim sr1 As System.IO.StreamReader
                	    If String.IsNullOrEmpty(Session("ID")) = True Then
                	        sr1 = New System.IO.StreamReader(web1.OpenRead(Server.MapPath("~/body/loginform.aspx")))
                	    Else
                	        sr1 = New System.IO.StreamReader(web1.OpenRead(Server.MapPath("~/body/loginedform.aspx")))
                	    End If
                	    
                	    Response.Write(sr1.ReadToEnd)
                	    sr1.Dispose()
                	    web1.Dispose()
                	    
                	%>                         
                	 
                </div>
              
              
            	<div id="top_right1">
                	                  
                        <% 
                	      sr1 = New System.IO.StreamReader(web1.OpenRead(Server.MapPath("~/body/exportright.aspx")))
                	      Response.Write(sr1.ReadToEnd)
                	   %>
                       
               
                </div>
                  
            </div>
        </div>
          
        <div id="header_holder">
            <div id="header">
                <div id="header_left"><img src="images/logonew.png" /></div>
                <div id="header_right">
                    <div class="demo-container">
                        <div class="green">  
                            <ul id="mega-menu-9" class="mega-menu">
                                <li><a href="Default.aspx">Home</a></li>
                                <li><a href="aboutus.aspx">About Us</a></li>
                                <li><a href="contactus.aspx">Contact Us</a></li>
                              
                                <% 
                                    Dim regcomp As String = "New Company"
                                    Dim regDevice As String = "Instruments"
                                    Dim regedit As String = "cregistration.aspx?permit=2&status=measure"
                                    
                                    If String.IsNullOrEmpty(Session("ID")) = False Then
                                        regcomp = "Edit Profile"
                                        regDevice = "Instruments"
                                        regedit = "cregistration.aspx?pg=edit&status=measure"
                                    End If
                                    
                                    Response.Write("<li><a href='" & regedit & "'>" & regcomp & "</a></li>")
                                    Response.Write("<li><a href='registerdevice.aspx?status=measure'>" & regDevice & "</a></li>")
                                    
                                %>   
                                           
                                                               
                                <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                                    </cc1:ToolkitScriptManager>

                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        
		<div id="main_page">
        
          <%--  <div id="submenubar">
                <div id="bread">You are Here > <a href="#">&nbsp;</a></div>
                <div id="request"><a href="#">Registration</a></div>
            </div>--%>
            
            <div id="page">
    

<!--start home-->

<%
    'Dim pgName As String = Request("page")
    web1 = New System.Net.WebClient
    If String.IsNullOrEmpty(Request("page")) = True Then
        sr1 = New System.IO.StreamReader(web1.OpenRead(Server.MapPath("~/body/bannerslide.aspx")))
    Else
        sr1 = New System.IO.StreamReader(web1.OpenRead(Server.MapPath("~/body/cregistration.aspx")))
    End If
                	    
    Response.Write(sr1.ReadToEnd)
    sr1.Dispose()
    web1.Dispose()
    
    
 %>

<div id="main-menu">
	<div id="item2">
    	<div class="item_title">&nbsp;&nbsp;&nbsp; WELCOME</div>
    	<div class="item_content" style="font-family: calibri; font-size: small">
             <div id="content_left">&nbsp;</div>

             <div id="item_left" class="style1">
                 <div class="style2"><a href="content1.aspx"> 
                     <img src="images/B2611212-Olusegun-Aganga.jpg" width="150px" height="150px" align="left" /></a><strong><a href="content1.aspx"> <span class="style3">Weights and measures policies will save Nigeria N474 Billion -Aganga</span></a></strong><br />
                     <br />
                 “The Federal Government will save about N474billion ($3bn) through the implementation of new policies on weights and measures,” the Minister of Trade and Investment, Olusegun Aganga said this at the Second Annual Seminar for trade and investment correspondents and group business editors in Abuja recently....<hr />
                 </div>
            </div>

             <div id="item_right">
                    <p><a href="content3.aspx" class="style3"> <strong>Weights and Measures Department sealed filing stations in FCT.</strong></a></p>
                    <p><a href="content3.aspx"><img alt="Filling Station" class="style5" src="images/fillinstation.jpg" align="left" /></a></p>
                     The Weights and Measures Department of the Federal Ministry of Trade and 
                    Investment had sealed dispensing pumps of AYM Shafa filling station at Gudu 
                    district, M. Major Oil and Gas, Mbora and NNPC Mega station at Gwarinpa for 
                    under dispensing petroleum products to customers....
              </div>

              <div id="item_left" style="width:700px" >
                     <p class="style2"><a href="content2.aspx" class="style3"><strong>Weights, measures to be introduced across all sectors of the economy – FG</strong></a> </p>
                    <p class="style2"><a href="content2.aspx"><img alt="picture" class="style6" src="images/Olusegun-Aganga.jpg" 
                            align="left" /></a>The Federal Government is making a move to ensure that Nigerians get value for their money by introducing “Weights and Measures” across all the sectors of the economy.

                    The phrase weights and measures imply selling of goods by weight or measures such as volume and length and it is backed with a range of rules. These rules are designed to help customers understand how much they are buying and to ensure they receive the amount of goods they are entitled to.

                    Trade and Investment Minister, Olusegun Aganga, who disclosed this during questions/answers session at a public forum in Lagos, said that this move will also checkmate corruption in both public and private sector of the economy, stressing: “It will first be introduced in the oil and gas industry.”.....
                    </div>
   
            	 
        </div>
    </div>
	<div id="item3">
    	<div class="item_title">&nbsp;&nbsp;&nbsp; FEDERAL REPUBLIC OF NIGERIA</div>
    	<div class="item_content"><a href="http://www.mfa.gov.ng"> <center><img src="images/coatofarm2.jpg" width="200px"  /><center></a></div>
    </div>
	<div id="item3">
    	<div class="item_title">&nbsp;&nbsp;&nbsp; MORE DETAILS</div>
    	<div class="item_content"><p><a href="#"></a></p></div>
         <ul style="list-style-image:url(images/list2.png); padding:10px 0px 10px 30px">
            <li><a href="vissionmission.aspx"><strong>Vission & Mission Statement</strong></a>
            <li><a href="comments.aspx"><strong>Comments</strong></a>
            <li><a href="faq.aspx"><strong>FAQ</strong></a>
        </ul>
    </div>
	<div id="item3">
    	<div class="item_title">&nbsp;&nbsp;&nbsp; NEWSLETTER</div>
        
        <asp:UpdatePanel  ID ="upsusb" runat ="server">
        <ContentTemplate>
    	    <div class="item_content"><strong>Subscribe to our Monthly newsletter</strong><br /><br />Email: &nbsp;<asp:TextBox 
                    ID="txtemail" runat="server"></asp:TextBox><br /><br />
                <asp:Button ID="btnnewSubscription" runat="server" Text="Subscribe" /> </div>
         </ContentTemplate>
        </asp:UpdatePanel>

    </div>
</div>
<div id="main-menu">

    <div id="itemx">
    	<div class="item_title">&nbsp;&nbsp;&nbsp;  LATEST NEWS </div>
       
            <%
                Dim GenTool1 As NNLN = xsmsCentralToolx.SetTool
            If GenTool1.HasDatasetAnyRecord(dsFrontPageSetup) = True Then
                getFrontPageSetup()
            End If
              
            Try
                For j As Int16 = 0 To dsFrontPageSetup.Tables(0).Rows.Count - 1
                    With dsFrontPageSetup.Tables(0).Rows(j)
                        Dim sd As String
                        sd = "<div class='item_content' style='font-family: calibri; font-size: small'><a href='newsupdate.aspx?pg=" & .Item(0).ToString & "'><strong>" & .Item(1).ToString & "</strong></a></div>"
                        Response.Write(sd)
                        
                    End With
                Next
            Catch ex As Exception
            End Try
            
            %>

    	<%--<div class="item_content" style="font-family: calibri; font-size: small"><a href="newsupdate.aspx"><strong>Fake Oil Exporter Uncovered</strong></a></div>
        <div class="item_content" style="font-family: calibri; font-size: small"><a href="newsupdate1.aspx"><strong>FG to hire 1,000 inspectors to monitor Weights & Measures policy</strong></a></div>
        <div class="item_content" style="font-family: calibri; font-size: small"><a href="newsupdate2.aspx"><strong>Weights and Measure: Ministry Employs 200 Inspection Officers</strong></a></div>
        <div class="item_content" style="font-family: calibri; font-size: small"><a href="newsupdate3.aspx"><strong>Ministry of Trade and Investment Attracts N 4.29 trillion Investments in 6 months</strong></a></div>
--%>
    </div>


    <div id="itemx">
    	<div class="item_title" style="font-family: calibri; font-size: small">&nbsp;&nbsp;&nbsp; REGULATIONS</div>
    	<div class="item_content" style="font-family: calibri; font-size: small">      
            <div id="content">
                <ul style="list-style-image: url(images/list.png); padding: 10px 0px 0px 30px">
                <%
                    If GenTool1.HasDatasetAnyRecord(dsFrontPageSetup1) = True Then
                        getFrontPageSetup1()
                    End If
                    
                    If GenTool1.HasDatasetAnyRecord(dsFrontPageSetup1) = False Then
                        For k As Integer = 0 To dsFrontPageSetup1.Tables(0).Rows.Count - 1
                            With dsFrontPageSetup1.Tables(0).Rows(k)
                                Dim sd As String
                                sd = "<a href='" & docLink & .Item(0).ToString  & "' class='style8'> <strong>"&.Item (1).ToString  &"</strong></a></p>"
                                Response.Write(sd)
                            End With
                        Next
                        
                    End If
                    
                    
                    '<a href="http://localhost/nnlnigeria/documents/Official Gazette No. 25.pdf" class="style8"> <strong>Official Gazette No. 25</strong></a></p>
                    '<a href="http://localhost/nnlnigeria/documents/OFFICIAL PRE-SHIPMENT ACT.pdf" class="style8"> <strong>OFFICIAL PRE-SHIPMENT ACT</strong></a></p>
                    '<a href="http://localhost/nnlnigeria/documents/weightandmeasureact.pdf" class="style8"> <strong>Wieght And Measure Act</strong></a></p>
                 %>
                </ul>
                         
            </div></div>
    </div>
	<div id="itemx">
    	<div class="item_title">&nbsp;&nbsp;&nbsp;  INFORMATION CENTER </div>
    	<div class="item_content">
            <div id="content">
               <ul style="list-style-image: url(images/list2.png); padding: 10px 0px 0px 30px">
                    <p class="style7">
                       <a href="parastatals.aspx" class="style8"> <strong>PARASTATALS UNDER THE MINISTRY</strong></a></p>
                    <ul class="square3">
                        <li><a href="http://www.abujacomex.com" target="_blank">Abuja Securities &amp; 
                            Commodities Exchange</a></li>
                        <li><a href="http://www.boinigeria.com" target="_blank">Bank of Industry (BOI)</a></li>
                        <li><a href="http://www.cpc.gov.ng" target="_blank">Consumer protection Council</a></li>
                        <li><a href="http://www.cac.gov.ng" target="_blank">Corporate Affairs Commission 
                            (CAC)</a></li>
                        <li><a href="http://www.itf-nigeria.com/" target="_blank">Industrial Training Fund</a></li>
                        <li>etc</li>
          
                </ul>
            </div>
        </div>
    </div>
	<div id="itemx">
    	<div class="item_title">&nbsp;&nbsp;&nbsp;  LEGAL METROLOGY</div>
    	<div class="item_content" style="font-family: calibri; font-size: small"><strong>What is Legal Metrology?</strong><br />
Metrology is the science of measurement. Legal metrology provides regulations for the control of measurements and measuring instruments. Legal metrology also provides protection of public safety,...<a href="legalmeta.aspx">&nbsp;Read More</a> </div>
    </div>
	
	
</div>


<!--end home-->



   				<div id="cards"><img src="images/partners.png" /></div>
            </div>
 
		</div>        
    </div>       
   <div id="footer">
		<div id="footer_content_left">Copyright &copy; 2012. All rights reserved.</div>
		<div id="footer_content_right">
        <a href="#" target="_blank"><strong>Powered by#</strong></a>
        
                    <div id="social">
                        <div id="social_content_f"><a href="http://www.facebook.com/NNLnigeria" alt="Follow us on Facebook" title="Follow us on Facebook">&nbsp;</a></div>
                        <div id="social_content_t"><a href="http://www.twitter.com/NNLnigeria" alt="Twitter" title="Twitter">&nbsp;</a></div>
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