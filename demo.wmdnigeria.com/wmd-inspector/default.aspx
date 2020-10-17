<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="WMDPortal._default29" %>

<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System" %>
<%@ Import Namespace="System.Configuration" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Weight & Measures</title>
    <meta name="author" content="Application Developed by: John Ojebode"/>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../css/menu.css" rel="stylesheet" type="text/css" />
    <link href="../images/icon.png" rel="icon" type="images/jpg" />

    <link href="../css/gallery.prefixed.css" rel="stylesheet" type="text/css" />
	<link href="../css/gallery.theme.css" rel="stylesheet" type="text/css" />
	<meta name="viewport" content="width=device-width, initial-scale=1" />

</head>
<body>
     <form id="Form1" runat ="server">   
         <!-- This is header       -->
         <asp:Panel ID="HeaderPanel" CssClass ="headers"  runat="server"   >

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
                                    <li><asp:Button ID="Button1" UseSubmitBehavior ="false" runat ="server"  style="background:url(../images/account.png) no-repeat 2px 10px scroll; background-size :18px 20px;" class="icon" Text ="PROFILE" /></li>
                                    <li><asp:button ID="Logout" UseSubmitBehavior ="false" runat ="server"  style="background:url(../images/login.png) no-repeat 2px 10px scroll; background-size :18px 20px;" CssClass="icon"  Text ="LOGIN"></asp:button></li>
                                </ul>

                            </li>
 
                            <li><asp:Panel ID="RegistrationPanel" runat="server" style="background:url(../images/register.png);background-position:2px 9px;background-repeat:no-repeat;background-size:18px 20px;float:right">
                               <asp:Button  ID="Registration" UseSubmitBehavior ="false"  runat="server" CssClass ="button-label" Text="REGISTER" />
                            </asp:Panel></li>

                            <li style="background-image:url(../images/faq-icon.png);background-position:2px 10px;background-repeat:no-repeat; background-size:20px 20px;float:right;margin-right:10px;font-weight:normal;"><a href="../faqs/" class="button-label" style="width:40px;">FAQs</a></li>  
                            
                        </ul>

                  </nav>
              </div>

                        
                        
            
                
            <div class="half-down"> 

               

                <nav>
                    <ul>
                        <li class="active"><a href="./"><span>HOME </span></a></li>   
                        <li><a href="../about/"><span>ABOUT US</span></a></li>
                        <li><a href="../permit-tracking"><span>PERMIT TRACKING</span></a></li> 
                        <li><a href="../gallery/"><span>PHOTO GALLERY</span></a></li>
                        <li><a href="../article/"><span>NEWS</span></a></li>
                        <li><a href="../download/"><span>DOWNLOAD</span></a></li>
                        <li><a href="../career/"><span>CAREER</span></a></li>
                        <li><a href="#"><span>CONTACT US</span></a>
                            <ul style="right:10px;text-align:right;">
                              <li><a href="../contact/wmd/">Weights & Measures</a></li>
                              <li><a href="../contact/cpi/">CPI Department</a></li>
                              <li><a href="../contact/nigerco/">Nigerco Nigeria Ltd.</a></li>
                            </ul>
                        </li>
                                               
                    </ul>
                </nav>

            </div>

                
            <asp:Panel ID="ToolBar" runat ="server"  class="tools-bar">
                <nav>
                    <ul class="inner" style="margin-top:-2px;">
                        <li><asp:button ID="Inspection" UseSubmitBehavior ="false"  runat ="server" style="background:url(../images/inspection.png) no-repeat 5px 10px scroll rgb(12, 76, 112); background-size :20px 20px; " class="icon" Text ="Inspection" /></li>
                        <li><asp:button ID="VerificationBill" UseSubmitBehavior ="false" runat ="server" style="background:url(../images/verification.png) no-repeat 5px 10px scroll rgb(12, 76, 112); background-size :20px 20px; " class="icon" Text ="Verification Bill" /></li>
                        <li><asp:button ID="Enforcement" UseSubmitBehavior ="false" runat ="server" style="background:url(../images/enforcement.png) no-repeat 5px 10px scroll rgb(12, 76, 112); background-size :20px 20px; " class="icon" Text ="Enforcement" /></li>
                        <li><asp:button ID="Instruments" UseSubmitBehavior ="false" runat ="server" style="background:url(../images/instruments.png) no-repeat 5px 10px scroll rgb(12, 76, 112); background-size :20px 20px; " class="icon" Text ="Instruments" /> </li>

                    </ul>
                </nav>
            </asp:Panel>
            </div>
             
        </div>
         
   </asp:Panel>

    <div class="content">

         <asp:Panel ID="DepositPanel" runat ="server" CssClass ="content-container"  style="margin-top:-20px;padding:0px;">

            <div class="title-bar">
                   <span class ="left">Welcome to Weights & Measures Departments of Federal Ministry of Industry </span>

                   
                <span class="welcome" >You are currently logged in as:  
                    <asp:Label CssClass ="welcome" ID ="WelcomeMessage" runat ="server"  Text="" ></asp:Label>
                
                </span>

            </div>
            </asp:Panel>


        <div class="login-section">
            <asp:Panel ID="SlidePanel" class="slides" runat="server"> 
                
        
	                <div class="gallery autoplay items-8">
                    <div id="item-1" class="control-operator"></div>
                    <div id="item-2" class="control-operator"></div>
                    <div id="item-3" class="control-operator"></div>
                    <div id="item-4" class="control-operator"></div>
                    <div id="item-5" class="control-operator"></div>
                    <div id="item-6" class="control-operator"></div>
                    <div id="item-7" class="control-operator"></div>
                    <div id="item-8" class="control-operator"></div>

                    <figure class="item" style="background:url(../images/slide/slide1.png) transparent; background-size:cover;">
                      <h1>
 	                  </h1>
	  
                    </figure>

                    <figure class="item"style="background:url(../images/slide/slide2.png) transparent; background-size:cover;">
                      <h1>
 	                  </h1>
                    </figure>

                    <figure class="item" style="background:url(../images/slide/slide3.png) transparent; background-size:cover;">
                      <h1>
 	                  </h1>
                    </figure>

                    <figure class="item" style="background:url(images/slide/slide4.png) transparent; background-size:cover;">
                      <h1>
 	                  </h1>
                    </figure>


                    <figure class="item" style="background:url(../images/slide/slide5.png) transparent; background-size:cover;">
                      <h1>
 	                  </h1>
                    </figure>


                    <figure class="item" style="background:url(../images/slide/slide6.png) transparent; background-size:cover;">
                      <h1>
 	                  </h1>
                    </figure>


                    <figure class="item"style="background:url(../images/slide/slide7.png) transparent; background-size:cover;">
                      <h1>
 	                  </h1>
                    </figure>

                       

                    <figure class="item"style="background:url(../images/slide/slide8.png) transparent; background-size:cover;">
                      <h1>
 	                  </h1>
                        
                    </figure>
  
                    <div class="controls">
                      <a href="#item-1" class="control-button">•</a>
                      <a href="#item-2" class="control-button">•</a>
                      <a href="#item-3" class="control-button">•</a>
                      <a href="#item-4" class="control-button">•</a>
                      <a href="#item-5" class="control-button">•</a>
                      <a href="#item-6" class="control-button">•</a>
                      <a href="#item-7" class="control-button">•</a>
                      <a href="#item-8" class="control-button">•</a>
                    </div>
                  </div>
 
                 
            </asp:Panel>

            <asp:Panel ID="LoginPanel"  class="login" runat="server">
                <div>
                    <h3>Login</h3>

                        <p><label>Select User Type:</label></p>
                        <asp:DropDownList ID="UserType" runat="server" CssClass="select">
                            <asp:ListItem Selected="True" Disabled  Text="Select User Type" value="Select User Type" ></asp:ListItem>
                            <asp:ListItem Text="User" Value="User"></asp:ListItem>
                            <asp:ListItem Text="WMD Inspector" Value="WMD Inspector"></asp:ListItem>
                            <asp:ListItem Text="CPI Inspector" Value="CPI Inspector"></asp:ListItem>
                            <asp:ListItem Text="Calibrator" Value="Calibrator"></asp:ListItem>
                            <asp:ListItem Text="Authorized Verifier" Value="Authorized Verifier"></asp:ListItem>
                        </asp:DropDownList>

                        <p><label>Username:</label></p>
                        <asp:TextBox ID="Username" runat="server" placeholder="Username" cssclass="input" ></asp:TextBox>

                        <p><label>Password:</label></p>
                        <asp:TextBox ID="Password" runat="server" TextMode="Password" placeholder="********"  CssClass ="input-password"></asp:TextBox>

                        <div class="login-button">
                         <asp:Button ID="LoginButton" runat="server" class="button" Text="Login Now" />
                        </div>
                        
                        <asp:Button ID="PasswordReset" runat="server" class="button" BackColor="Transparent" BorderColor="Transparent"  CssClass="password-reset" Text="Password Reset" />
                        
                </div>
            </asp:Panel>


            <asp:Panel ID="PasswordResetPanel" Visible ="false"  class="login" runat="server">
                <div>
                    <h3 style="color:darkred;margin-bottom:50px;">Reset Password</h3>
                        <p><asp:Label runat="server"  style="font-weight:bolder;margin-left:15px;font-size :13px" ID="EmailLabel">E-mail Address:</asp:Label></p>
                        <asp:TextBox ID="AccountEmail" runat="server" placeholder="Enter registered email" cssclass="input" ></asp:TextBox>
                        
                        
                        <p><asp:label runat="server" style="font-weight:bolder;margin-left:15px;font-size :13px" Visible="false" ID="SecurityQuestion" Text ="Security Question:" ToolTip ="Security Question:"></asp:label></p>
                        <asp:TextBox ID="SecurityAnswer" Visible="false" style="background :rgb(255,255,255);padding-left:10px;" runat="server" placeholder="Enter answer to your question" cssclass="input" ></asp:TextBox>
                        

                         <p><asp:Label runat="server" style="font-weight:bolder;margin-left:15px;font-size :13px" Visible="false"  ID="NewPasswordLabel">New Password:</asp:Label></p>
                        <asp:TextBox ID="NewPassword" Visible="false"  runat="server" TextMode="Password" placeholder="***************"  CssClass ="input-password"></asp:TextBox>
                        
                         <p><asp:Label runat="server" style="font-weight:bolder;margin-left:15px;font-size :13px" Visible="false"  ID="ConfirmPasswordLabel">Confirm Password:</asp:Label></p>
                        <asp:TextBox ID="ConfirmPassword" Visible="false" runat="server" TextMode="Password" placeholder="***************"  CssClass ="input-password"></asp:TextBox>


                        <div class="login-button">
                         <asp:Button ID="ContinueReset" Visible="false" runat="server" class="button" Text="Continue" />
                         <asp:Button ID="SearchAcount" runat="server" class="button" Text="Search Account" />
                         <asp:Button Visible="false" ID="ResetMyPassword" runat="server" class="button" Text="Reset Password" />
                         <asp:Button ID="GoToLogin" runat="server" BackColor="Transparent" BorderColor="Transparent" ForeColor="DarkRed" Font-Bold="true" style="cursor:pointer " Text="Go to Login" />

                        </div>
                        
                        
                </div>
            </asp:Panel>




        </div>
        
     </div>
 

     <div class="news-section"> 
       <!--<asp:Button ID="RefreshNews" runat="server" Height="30" OnClick ="RefreshNews_Click" Width="100" Text="Refresh Article" /> -->

         <div class="inner-box">

             <div class="news-section-divider"> 
                 <div class="news-pix"><div class="news-image" style= '<% Response.Write("background:url(../images/article/" + ImageName1() + ") no-repeat rgb(255,255,255);background-size:cover;")%>'></div></div>
             
                 <div class="news-wrapper">
                     <asp:Panel runat ="server" ID="TitlePanel1" class="news-title" ><asp:Label runat ="server" ID="NewsTitle1" Text='<%# ArticleTitle1()%>'/></asp:Panel>
                     
                     <asp:Panel runat ="server" ID="PreviewPane1" class="news-content" ><asp:Label runat ="server" ID="NewsPreview1" Text='<%# ArticleText1()%>'/>
                    </asp:Panel >
                    <a id="A4" runat ="server" title ="Read Full News" href='<%# String.Format("../article/?ArticleID={0}", ArticleID1())%>'><div class="read-more">Read More</div></a>
                 </div>
             </div>

           <div class="news-section-divider"> 
               
                 <div class="news-pix"> <div class="news-image" style= '<% Response.Write("background:url(../images/article/" + ImageName2() + ") no-repeat rgb(255,255,255);background-size:cover;")%>'></div></div>
                  <div class="news-wrapper">
                     <asp:Panel runat ="server" ID="TitlePanel2" class="news-title" ><asp:Label runat ="server" ID="NewsTitle2" Text='<%# ArticleTitle2()%>'/></asp:Panel>
                     <asp:Panel runat ="server" ID="PreviewPanel2" class="news-content" ><asp:Label runat ="server" ID="NewsPreview2" class="news-content" Text='<%# ArticleText2()%>'/>
                    </asp:Panel>

                    <a id="A3" runat ="server" title ="Read Full News" href='<%# String.Format("../article/?ArticleID={0}", ArticleID2())%>'><div class="read-more">Read More</div></a>
                 </div>
             </div>

            <div class="news-section-divider"> 
                 <div class="news-pix"><div class="news-image" style= '<% Response.Write("background:url(../images/article/" + ImageName3() + ") no-repeat rgb(255,255,255);background-size:cover;")%>'></div></div>
             
                 <div class="news-wrapper">
                     <asp:Panel runat ="server" ID="TitlePanel3" class="news-title" ><asp:Label runat ="server" ID="NewsTitle3" Text='<%# ArticleTitle3()%>'/></asp:Panel>
                     <asp:Panel runat ="server" ID="PreviewPanel3" class="news-content" ><asp:Label runat ="server" ID="NewsPreview3" class="news-content" Text='<%# ArticleText3()%>'/>
                    </asp:Panel>
                    <a id="A2" runat ="server" title ="Read Full News" href='<%# String.Format("../article/?ArticleID={0}", ArticleID3())%>'><div class="read-more">Read More</div></a>
                 </div>
             </div>

            <div class="news-section-divider"> 

                
                 <div class="news-pix"><div class="news-image" style='<% Response.Write("background:url(../images/article/" + ImageName4() + ") no-repeat rgb(255,255,255);background-size:cover;")%>'></div></div>
             
                 <div class="news-wrapper">
                    <asp:Panel runat ="server" ID="TitlePanel4" class="news-title" ><asp:Label runat ="server" ID="NewsTitle4" Text='<%# ArticleTitle4()%>' /></asp:Panel>
                     <asp:Panel runat ="server" ID="PreviewPanel4" class="news-content" ><asp:label runat ="server" ID="NewsPreview4" class="news-content" Text='<%# ArticleText4()%>'/>
                    </asp:Panel>
                    <a id="A1" runat ="server" title ="Read Full News" href='<%# String.Format("../article/?ArticleID={0}", ArticleID4())%>'><div class="read-more">Read More</div></a>
                 </div>
             </div>


             
         </div>
        
    </div>
 
    <div class="vission-mission-section">
        <div class="vission-mission-inner-box">
            <div class="title">Vission & Mission Statement</div>
            
        
            <div class="vission-mission-divider">
                <h5>Mission Statement</h5>
                <p>Our mission is to be worlds leading provider of Innovative Legal Metrology Consultancy Services through establishment of Legal, Fair and Accurate Measurement System as a basis for competitive markets and consumer protection locally, nationally and internationally.</p>

            </div>

            <div class="vission-mission-divider">
                <h5>Vission Statement</h5>
                <p>To create a level playing field for Fair Trade, Consumer Protection and Sustainable Economic Growth.</p>

            </div>

       
        
        </div>
    </div>
    

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
                <div class="title">OTHER GOVT. AGENCIES</div>
                <div class="footer-link"><a href="http://www.son.gov.ng/" target ="_blank" >Standard Organisation of Nigeria</a></div>
                <div class="footer-link"><a href="http://www.cpc.gov.ng/" target ="_blank" >Consumer Protection Council</a></div>
                <div class="footer-link"><a href="http://www.finance.gov.ng/" target ="_blank" >Federal Ministry of Finance</a></div>
                <div class="footer-link"><a href="http://www.nipc.gov.ng/" target ="_blank" >Nigerian Invest. Promotion Comm.</a></div>
                <div class="footer-link"><a href="http://www.dpr.gov.ng/" target ="_blank" >Dept. of Petroleum Resources</a></div>

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
            <div class="copyright-text">Copyright &copy; 2013 - 2015. All rights reserved.</div>
            <div class="social">
                <a href ="http://www.facebook.com/NNLnigeria"><div class="social-img" style="background:url(../images/facebook.png) no-repeat; background-size:cover;" title="Like our Facebook Page"> </div></a>
                <a href ="http://www.facebook.com/NNLnigeria"><div class="social-img" style="background:url(../images/twitter.png) no-repeat; background-size:cover;" title="Join our Twitter Conversation"> </div></a>
                <a href ="../"><div class="social-img" style="height:20px; width: 20px; margin-top:2px; background:url(../images/youtube.png) no-repeat; background-size:20px 20px;"  title="Our Youtube Channel"> </div></a>
                <a href ="../"><div class="social-img" style="background:url(../images/linkedin.png) no-repeat; background-size:cover;"  title="Connect with us on Linkedin"> </div></a>
                <a href ="../contact/"><div class="social-img" style="background:url(../images/cont.png) no-repeat; background-size:cover;"  title="Contact Us"> </div></a>
            </div>

        </div>
    </div>

    </form>
</body>
</html>
