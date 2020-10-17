<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Defaultx.aspx.vb" Inherits="_Default"  EnableEventValidation ="false" ValidateRequest ="false"    %>

<%@ Import Namespace="System.Data" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat ="server">
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

<!---->
<!--news gallery-->
<link rel="stylesheet" href="template/gallery/style.css" type="text/css" media="screen" />
<script src="template/gallery/jquery-latest.pack.js" type="text/javascript"></script>
<script type="text/javascript" src="template/login/js/jquery.min.js"></script>
<script src="template/gallery/jcarousellite_1.0.1c4.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
        $(".newsticker-jcarousellite2").jCarouselLite({
            vertical: true,
            hoverPause: true,
            visible: 1,
            auto: 2000,
            speed: 5000
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
    
    Dim GenTool As NNLN = xsmsCentralToolx.SetTool
    If GenTool.HasDatasetAnyRecord(dsfrontpagemain) = True Then
        getFrontPagemain()
    End If
    
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
        .style7
        {
            font-family: Calibri;
            font-size: small;
            text-align: left;
        }
        .style8
        {
            color: #000000;
        }
        .style11
        {
            text-align: justify;
        }
        .style12
        {
            width: 100%;
            float: left;
            padding: 7px 0 0 0;
            margin: 0px;
            display: inline-block;
            font-size: 12px;
            text-align: justify;
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
                            If String.IsNullOrEmpty(Session("ID")) = false Then
                                sr1 = New System.IO.StreamReader(web1.OpenRead(Server.MapPath("~/body/exportright.aspx")))
                                Response.Write(sr1.ReadToEnd)
                            End If
                            
                	   %>
                                      
                </div>
               
            </div>
        </div>
          
        <div id="header_holder">
            <div id="header">
                <div id="header_left"><img  alt="logo" src="images/logonew.png" /></div>
                <div id="header_right">
                    <div class="demo-container">
                        <div class="green">  
                            <ul id="mega-menu-9" class="mega-menu" style ="background-color:#F7F7F7">
                                <li><a href="Default.aspx">Home</a></li>
                                <li><a href="aboutus.aspx">About Us</a></li>
                                <li><a href="contactus.aspx">Contact Us</a></li>
                              
                                <% 
                                    Dim regcomp As String = "Instruments Registration"
                                    Dim regDevice As String = "Careers"
                                    Dim regedit As String = "cregistration.aspx?permit=2&status=measure"
                                    Dim degDV As String = "Careers.aspx"
                                    
                                    If String.IsNullOrEmpty(Session("ID")) = False Then
                                        regcomp = "Instrument Services"
                                        regDevice = "Instruments Registration"
                                        regedit = "registerdeviceservices.aspx?status=measure"
                                        degDV = "registerdevice.aspx?status=measure"
                                    End If
                                    
                                    Response.Write("<li><a href='" & regedit & "'>" & regcomp & "</a></li>")
                                    Response.Write("<li><a href='" & degDV & "'>" & regDevice & "</a></li>")
                                %>   
                                                                                                  
                                <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"  >
                               
                                    </cc1:ToolkitScriptManager>
                                 

                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        


		<div id="main_page">
      

          <%  If String.IsNullOrEmpty(Session("ID")) = False Then
                            Dim GenTool23 As NNLN = xsmsCentralToolx.SetTool
                  Response.Write(GenTool23.getUserLoggedIn(Session("username")))
                        End If
                        
                     %>  
        
           

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

 </div>

<div id="main-menu">

	<div id="item2" runat ="server">
    	<div class="item_title" runat ="server">&nbsp;&nbsp;&nbsp; WELCOME</div>
      
   <div id="newsticker-demo2">    
    <div class="newsticker-jcarousellite2">
		<ul>
		<%
		    Dim GenTool As NNLN = xsmsCentralToolx.SetTool
		    dsfrontpagemain = GenTool.DataSetData("select sysID,HeaderName,BriefMsg,FullMessage,sysImageName from frontpagemain where Status=1 order by sysID asc")
		    If GenTool.HasDatasetAnyRecord(dsfrontpagemain) = False Then
		        
		        Dim counted As Integer = dsfrontpagemain.Tables(0).Rows.Count - 1
		        
		        Do While counted < dsfrontpagemain.Tables(0).Rows.Count
		            With dsfrontpagemain.Tables(0)
		                
		          
		                Dim s1 As String = ""
		                Dim n1 As String = ""
		                Dim sd1 As String = ""
		                Dim d1 As String = ""
		            
		                Dim s2 As String = ""
		                Dim n2 As String = ""
		                Dim sd2 As String = ""
		                Dim d2 As String = ""
		            		              
		                
		                s1 = .Rows(counted).Item("HeaderName").ToString
		                n1 = .Rows(counted).Item("sysImageName").ToString
		                sd1 = .Rows(counted).Item("sysID").ToString
		                d1 = .Rows(counted).Item("BriefMsg").ToString
		                
		                counted += 1
		                
		                If counted < dsfrontpagemain.Tables(0).Rows.Count Then
		                    
		                    s2 = .Rows(counted).Item("HeaderName").ToString
		                    n2 = .Rows(counted).Item("sysImageName").ToString
		                    sd2 = .Rows(counted).Item("sysID").ToString
		                    d2 = .Rows(counted).Item("BriefMsg").ToString
		                    
		                End If
		            
		                Dim fVb As String = "<a href='frontpagedisplay.aspx?msgid=" & sd1 & "'><img src='frontdoc/" & n1.Trim & "' width='80px' height='80px' align='left' style='border:1px solid #DBDBDB'/> </a>"
		                Dim vsm As String = "<a href='frontpagedisplay.aspx?msgid=" & sd1 & "'><span class='style3'><left>" & s1.Trim & "</left></span></a>"
		      
		         		            
		                Dim fVb1 As String = "<a href='frontpagedisplay.aspx?msgid=" & sd2 & "'><img src='frontdoc/" & n2.Trim & "' width='80px' height='80px' align='left' style='border:1px solid #DBDBDB'/> </a>"
		                Dim vsm1 As String = "<a href='frontpagedisplay.aspx?msgid=" & sd2 & "'><span class='style3'><left>" & s2.Trim & "</left></span></a>"
		                
		     
		    %>

            <li>
            	<div id="gallery-wrap">
                    <div class="thumbnail2">
                        <%--<a href="#"><img src="template/gallery/images/1_t.jpg"></a>--%>
                        <% Response.Write(fVb)%>

                    </div>
                    <div class="info2">
                        <a href="#"><strong><% Response.Write(s1.Trim)%></strong></a><br/> <% Response.Write(d1)%>
                    </div>


                    <div class="info2">
                      <%--  <a href="#"><strong>Sports Federation Elections</strong></a><br/> Selling power wewrwerwerith metre helps ...--%>
                       <a href="#"><strong><% Response.Write(s2.Trim)%></strong></a><br/> <% Response.Write(d2)%>
                    </div>
				</div>
			 </li>

             <% End With%>
             <% Loop%>
             <% End If%>

        </ul>

    </div>
   </div>

    
<!--end gallery news-->
 
    </div>

    <div id="item3x">
    	<div class="item_title">&nbsp;&nbsp;&nbsp; VISION & MISSION STATEMENT</div>
    	<div class="item_content"> 
            <table style="width:100%;">
                <tr>
                    <td>
                        &nbsp;</td>
                    <td align="center" 
            style="font-family: Calibri; font-size: 15px; font-weight: bold; color: #008080;">
            &nbsp;Vision Statement 
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td style="font-family: calibri; font-size: small">
                        <p class="style11">
                            To create a level playing field for Fair Trade, Consumer Protection and 
                            Sustainable Economic Growth.</p>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td align="center" 
            style="font-family: Calibri; font-size: 15px; font-weight: bold; color: #008080;">
            Mission Statement</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td style="font-family: calibri; font-size: small">
                        <p class="style11">
            Our mission is to be worlds leading provider of 
                            Innovative Legal Metrology Consultancy Services through establishment of Legal, 
                            Fair and Accurate 
            Measurement System as a basis for competitive markets and consumer protection 
            locally, nationally and internationally.</p>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </div>
    </div>

	<div id="item3">
    	<div class="item_title">&nbsp;&nbsp;&nbsp; FEDERAL REPUBLIC OF NIGERIA</div>
    	<div class="item_content"><a href="http://www.mfa.gov.ng"> <center><img src="images/coatofarm2.jpg" width="100px" height ="100px"  /><center></a></div>
    </div>
	<div id="item3">
    	<div class="item_title">&nbsp;&nbsp;&nbsp; MORE DETAILS</div>
    	<div class="item_content"><p><a href="#"></a></p></div>
         <ul style="list-style-image:url(images/list2.png); padding:10px 0px 10px 30px">
            <li class="style2"><a href="comments.aspx" class="style2"><strong>Comments</strong></a>
            <li>
                <p class="style2">
                    <a href="photogallerygroup.aspx"><strong>Photo Gallery</strong></a>
                </p>
             <li class="style2"><a href="archives.aspx" class="style2"><strong>Archive</strong></a>
        </ul>
    </div>
 
     
</div>

<div id="main-menu">

    <div id="itemx">
    	<div class="item_title">&nbsp;&nbsp;&nbsp;  LATEST NEWS </div>
        <br />
        <br />
          <ul style="list-style-image:url(images/list2.png); padding:10px 0px 10px 30px">
             
        
            <%
            Dim GenTool1 As smsXMobile.smsXMobile = xsmsCentralToolx.SetTool
            If GenTool1.HasDatasetAnyRecord(dsFrontPageSetup) = True Then
                getFrontPageSetup()
            End If
               
            Try
                For j As Int16 = 0 To dsFrontPageSetup.Tables(0).Rows.Count - 1
                    With dsFrontPageSetup.Tables(0).Rows(j)
                            Dim sd As String
                            sd = "<li  class='style2'><a href='newsupdate.aspx?pg=" & .Item(0).ToString & "'  class='style2'><strong>" & .Item(1).ToString & "</strong></a>"
                            'sd = "<div class='item_content' style='font-family: calibri; font-size: small'><a href='newsupdate.aspx?pg=" & .Item(0).ToString & "'><strong>" & .Item(1).ToString & "</strong></a></div>"
                        Response.Write(sd)
                        
                    End With
                Next
            Catch ex As Exception
            End Try
            
            %>

    	 </ul>
    </div>


    <div id="itemx">
    	<div class="item_title" style="font-family: calibri; font-size: small">&nbsp;&nbsp;&nbsp; REGULATIONS</div>
    	 <br />
         <br />
             
                <ul style="list-style-image: url(images/list2.png); padding: 10px 0px 0px 30px">
                <%
                    If GenTool1.HasDatasetAnyRecord(dsFrontPageSetup1) = True Then
                        getFrontPageSetup1()
                    End If
                    
                    If GenTool1.HasDatasetAnyRecord(dsFrontPageSetup1) = False Then
                        For k As Integer = 0 To dsFrontPageSetup1.Tables(0).Rows.Count - 1
                            With dsFrontPageSetup1.Tables(0).Rows(k)
                                Dim sd As String
                                sd = "<li  class='style2'><a href='" & .Item(0).ToString & "' class='style2'><strong>" & .Item(1).ToString & "</strong></a>"
                                'sd = "<a href='" & docLink & .Item(0).ToString  & "' class='style8'> <strong>"&.Item (1).ToString  &"</strong></a></p>"
                                Response.Write(sd)
                            End With
                        Next
                        
                    End If
                    
                    
                    '<a href="http://localhost/nnlnigeria/documents/Official Gazette No. 25.pdf" class="style8"> <strong>Official Gazette No. 25</strong></a></p>
                    '<a href="http://localhost/nnlnigeria/documents/OFFICIAL PRE-SHIPMENT ACT.pdf" class="style8"> <strong>OFFICIAL PRE-SHIPMENT ACT</strong></a></p>
                    '<a href="http://localhost/nnlnigeria/documents/weightandmeasureact.pdf" class="style8"> <strong>Wieght And Measure Act</strong></a></p>
                 %>
                </ul>
       
    </div>
	<div id="itemx">
    	<div class="item_title">&nbsp;&nbsp;&nbsp;  INFORMATION CENTER </div>
        <br />
        <br />
            <ul style="list-style-image: url(images/list2.png); padding: 10px 0px 0px 30px">
                <p class="style7">
                    <a href="parastatals.aspx" class="style8"> <strong>PARASTATALS UNDER THE MINISTRY</strong></a></p>
                    <li class="style2"><a href="http://www.abujacomex.com" target="_blank">Abuja Securities &amp; Commodities Exchange</a></li>
                    <li class="style2"><a href="http://www.boinigeria.com" target="_blank">Bank of Industry (BOI)</a></li>
                    <li class="style2"><a href="http://www.cpc.gov.ng" target="_blank">Consumer protection Council</a></li>
                    <li class="style2"><a href="http://www.cac.gov.ng" target="_blank">Corporate Affairs Commission (CAC)</a></li>
                    <li class="style2"><a href="http://www.itf-nigeria.com/" target="_blank">Industrial Training Fund</a></li>
                    <li class="style2">etc</li>
             </ul>
 
    </div>
	<div id="itemx">
    	<div class="item_title">&nbsp;&nbsp;&nbsp;  LEGAL METROLOGY</div>
    	<div class="style12" style="font-family: calibri; font-size: small"><strong>What is Legal Metrology?</strong><br />
Metrology is the science of measurement. Legal metrology provides regulations for the control of measurements and measuring instruments. Legal metrology also provides protection of public safety,...<a href="legalmeta.aspx">&nbsp;Read More</a> </div>
    </div>
	
	
</div>


<!--end home-->



   				<div id="cards1"><img src="images/partners.png" /></div>

            </div>
 
		</div>        
    </div>    
    <center>
   <div id="footer">
		<div id="footer_content_left">Copyright &copy; 2013. All rights reserved.</div>
		<div id="footer_content_right">
        <a href="#" target="_blank"><strong></strong></a>
        
                    <div id="social">
                        <div id="social_content_f"><a href="http://www.facebook.com/NNLnigeria" alt="Follow us on Facebook" title="Follow us on Facebook">&nbsp;</a></div>
                        <div id="social_content_t"><a href="http://www.twitter.com/NNLnigeria" alt="Twitter" title="Twitter">&nbsp;</a></div>
                        <div id="social_content_y"><a href="#" alt="Youtube" title="Youtube">&nbsp;</a></div>
                    </div>
        </div>
   </div>
   </center>   
</div>
    </form>
</body>
</html>          