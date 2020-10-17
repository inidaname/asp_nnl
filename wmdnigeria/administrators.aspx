<%@ Page Title="" Language="VB" MasterPageFile="~/adminpage.master" AutoEventWireup="false" CodeFile="administrators.aspx.vb" Inherits="administrators1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<!--start home-->
<div id="item1">
	 
  <div class="item_title">&nbsp;&nbsp;&nbsp; ADMINISTRATORS</div>

 <div>
	  <center>
        <div style="width : 75%" id="main-menu">

              <table style="width: 100%;">
         <tr>
             <td class="style1">
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;<td>
                 &nbsp;</td>
         </tr>

         <tr>
             <td class="style1">
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td><center>
                 <div class="item_title">
                     &nbsp;&nbsp;&nbsp; USER/COMPANY 
                     MANAGEMENT</div></center>
             <td>
                 &nbsp;</td>
         </tr>

         <tr>
             <td class="style1">
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;<td>
                 &nbsp;</td>
         </tr>

         <tr>
             <td class="style1">
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td align="center">
                <%  
                    Dim sysDBUser As systemDBUsers = CType(Session("sysDBUser"), systemDBUsers)
                
                    %> 
                 <div id="item_left" style="border-width: thin; border-style: outset; width:100px; height:130px">
                 <%
                     If sysDBUser.sysadminright = True Then
                         Response.Write("<a href='admnewuser.aspx'><img src='images/sa/users-icon1.png' alt ='New User' width='80px' height='80px'/><br /><br />New Application Users</a>")
                     Else
                         Response.Write("<img src='img/nopicture.jpg' alt ='' width='100px' height='130px'/><br /><br />")
                     End If
                     %>
                     
                </div>

                 <div id="item_right"  style="border-width: thin; border-style: outset; width:100px; height:130px">
                       <%
                           If sysDBUser.sysadminright = True Then
                               Response.Write("<a href='admnewuser.aspx?pg=1'> <img src='images/sa/Text-Edit-icon.png' alt='Existing User'  width='80px' height='80px'/><br /><br />Modify Existing Users</a>")
                           Else
                               Response.Write("<img src='img/nopicture.jpg' alt ='' width='100px' height='130px'/><br /><br />")
                           End If
                           
                         %>

                 </div>
                       
                 <div id="item_left" style="border-width: thin; border-style: outset; width:100px; height:130px">
                        <%
                            If sysDBUser.ManageLot = True Then
                                Response.Write("<a href='managelots.aspx'><img src='images/sa/user-group-icon.png' alt ='New User'  width='80px' height='80px'/><br />Lots Allocation</a>")
                            Else
                                Response.Write("<img src='img/nopicture.jpg' alt ='' width='100px' height='130px'/><br /><br />")
                            End If
                           
                         %>
                 </div>

                 <div id="item_right"  style="border-width: thin; border-style: outset; width:100px; height:130px">
                         <%
                            If sysDBUser.ManageLot = True Then
                                 Response.Write("<a href='managelots.aspx?pg=1'><img src='images/sa/user-group-icon12.png' alt ='New User'  width='80px' height='80px'/><br />Manage Lots Allocation</a>")
                            Else
                                Response.Write("<img src='img/nopicture.jpg' alt ='' width='100px' height='130px'/><br /><br />")
                            End If
                           
                         %>
                    
                 </div>
                     
                  <div id="item_left" style="border-width: thin; border-style: outset; width:100px; height:130px"> 

                          <%
                              If sysDBUser.companymgtright = True Then
                                  Response.Write("<a href='admcompanymgt.aspx'> <img src='images/sa/log-icon.png' alt ='Company management'  width='80px' height='80px' /><br />Company Management</a>")
                              Else
                                  Response.Write("<img src='img/nopicture.jpg' alt ='' width='100px' height='130px'/><br /><br />")
                              End If
                           
                         %>
 
                  </div>

                  <div id="item_right" style="border-width: thin; border-style: outset; width:100px; height:130px"> 
                     <%
                         If sysDBUser.devicemdgtright = True Then
                             Response.Write("<a href='admdevicemgt.aspx'><img src='images/sa/signal-Vista-icon.png' alt='Instrument management'  width='80px' height='80px' /><br /><br /> Instrument Management</a>")
                         Else
                             Response.Write("<img src='img/nopicture.jpg' alt ='' width='100px' height='130px'/><br /><br />")
                         End If
                           
                         %>

                        
                  </div>

              </td> 

              <td>
                 &nbsp;</td>
         </tr>

         <tr>
             <td class="style1">
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td align="center" style="font-family: calibri; font-size: small">
                 <hr /><td>
                 &nbsp;</td>
         </tr>

         <tr>
             <td class="style1">
                 &nbsp;</td>
             <td>
                 &nbsp;
             </td>
             <td><center>
                 <div class="item_title">
                     &nbsp;&nbsp;&nbsp; SETUP</div></center>
             </td>
             <td>
                 &nbsp;
             </td>
         </tr>

          <tr>
             <td class="style1">
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td align="center">
                 
                    <div id="item_left" style="border-width: thin; border-style: outset; width:100px; height:130px"> 
                       <%
                           If sysDBUser.staticdataright = True Then
                               Response.Write("<a href='admstaticdata.aspx?pg=2'><img src='images/sa/2-Hot-Home-icon.png' alt ='static data' width='80px' height='80px'  /><br /><br /> Modify City Table</a>")
                           Else
                               Response.Write("<img src='img/nopicture.jpg' alt ='' width='100px' height='130px'/><br /><br />")
                           End If
                           
                         %>
                                                  
                    </div>
                     
                    <div id="item_right" style="border-width: thin; border-style: outset; width:100px; height:130px"> 
                      <%
                           If sysDBUser.staticdataright = True Then
                               Response.Write("<a href='admstaticdata.aspx?pg=0'><img src='images/sa/Actions-document-save-all-icon.png'  alt='static data' width='80px' height='80px' /><br /><br /> Modify State Table</a>")
                           Else
                               Response.Write("<img src='img/nopicture.jpg' alt ='' width='100px' height='130px'/><br /><br />")
                           End If
                           
                         %>

                        
                    </div>
                      
                      <div id="item_left" style="border-width: thin; border-style: outset; width:100px; height:130px"> 
                         <%
                           If sysDBUser.staticdataright = True Then
                               Response.Write("<a href='admstaticdata.aspx?pg=1'> <img src='images/sa/Actions-document-edit-icon.png' alt ='static data' width='80px' height='80px'  /><br /><br /> Modify LGA Table</a>")
                           Else
                               Response.Write("<img src='img/nopicture.jpg' alt ='' width='100px' height='130px'/><br /><br />")
                           End If
                           
                         %>

                        
                      </div>
                    
                    <div id="item_right" style="border-width: thin; border-style: outset; width:100px; height:130px"> 
                         <%
                           If sysDBUser.staticdataright = True Then
                               Response.Write("<a href='admstaticdata.aspx?pg=4'> <img src='images/sa/Architecture-info-icon.png' alt='static data' width='80px' height='80px' /><br /><br />Modify Fee Section Table</a>")
                           Else
                               Response.Write("<img src='img/nopicture.jpg' alt ='' width='100px' height='130px'/><br /><br />")
                           End If
                           
                         %>

                        
                     </div>

                 <div id="item_left" style="border-width: thin; border-style: outset; width:100px; height:130px"> 
                    <%
                           If sysDBUser.staticdataright = True Then
                            Response.Write("<a href='admstaticdata.aspx?pg=5'> <img src='images/sa/Notepad-Bloc-notes-icon.png' alt ='static data'  width='80px' height='80px' /><br /><br /> Modify Fee Sub Section Table</a>")
                           Else
                               Response.Write("<img src='img/nopicture.jpg' alt ='' width='100px' height='130px'/><br /><br />")
                           End If
                           
                         %>

                    
                 </div>

                 <div id="item_right" style="border-width: thin; border-style: outset; width:100px; height:130px"> 

                        <%
                           If sysDBUser.staticdataright = True Then
                                Response.Write("<a href='admstaticdata.aspx?pg=6'> <img src='images/sa/box-config-icon.png' alt='static data' width='80px' height='80px' /><br /> <br /> Modify Fee Table</a>")
                           Else
                               Response.Write("<img src='img/nopicture.jpg' alt ='' width='100px' height='130px'/><br /><br />")
                           End If
                           
                         %>
                                              
                 </div>

             <td>
                 &nbsp;</td>
         </tr>
     
            <tr>
             <td class="style1">
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td align="center" style="font-family: calibri; font-size: small">
                <hr /></td><td>
                 &nbsp;</td>
         </tr>

            <tr>
             <td class="style1">
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td align="center">
                 <div id="item_left" style="border-width: thin; border-style: outset; width:100px; height:130px"> 
                  
                         <%
                           If sysDBUser.staticdataright = True Then
                               Response.Write("<a href='admstaticdata.aspx?pg=3'> <img src='images/sa/url-history-icon1.png'  alt ='static data'  width='80px' height='80px' /><br /> <br /> Modify Country Table</a>")
                           Else
                               Response.Write("<img src='img/nopicture.jpg' alt ='' width='100px' height='130px'/><br /><br />")
                           End If
                           
                         %>
                </div>

                <div id="item_right" style="border-width: thin; border-style: outset; width:100px; height:130px"> 
                   
                   <%
                           If sysDBUser.staticdataright = True Then
                               Response.Write("<a href='admstaticdata.aspx?pg=7'><img src='images/sa/Process-Info-icon.png' alt='Instrument Main Group' width='80px' height='80px' /><br /> <br />  Modify Instrument Main Group</a>")
                           Else
                               Response.Write("<img src='img/nopicture.jpg' alt ='' width='100px' height='130px'/><br /><br />")
                           End If
                           
                         %>

                     
                 </div>

                 <div id="item_left" style="border-width: thin; border-style: outset; width:100px; height:130px"> 
                   
                   <%
                           If sysDBUser.staticdataright = True Then
                               Response.Write("<a href='adminstrumenttype.aspx'> <img src='images/sa/info-icon1.png'  alt ='static data' width='80px' height='80px'  /><br /> <br /> Modify Instrument Category</a>")
                           Else
                               Response.Write("<img src='img/nopicture.jpg' alt ='' width='100px' height='130px'/><br /><br />")
                           End If
                           
                         %>

                </div>

                 <div id="item_right" style="border-width: thin; border-style: outset; width:100px; height:130px"> 
                    <%
                           If sysDBUser.staticdataright = True Then
                               Response.Write("<a href='allocatedlot.aspx?pg=8'> <img src='images/sa/personal-information-icon.png'  alt ='static data'  width='80px' height='80px' /><br /> <br /> Modify LOT Table</a>")
                           Else
                               Response.Write("<img src='img/nopicture.jpg' alt ='' width='100px' height='130px'/><br /><br />")
                           End If
                           
                         %>

                    
                 </div>
                    
                 <div id="item_left" style="border-width: thin; border-style: outset; width:100px; height:130px"> 
                     <%
                         If sysDBUser.approveexportimport = True OrElse sysDBUser.endorseexportimport = True OrElse sysDBUser.recommendexportimport = True OrElse sysDBUser.inspectexportimport = True Then
                             Response.Write(" <a href='admexportpermit.aspx'> <img src='images/sa/ok-icon1.png' alt ='Permit Management' width='80px' height='80px'  /><br /> <br /> Exporters Permit Management</a>")
                         Else
                             Response.Write("<img src='img/nopicture.jpg' alt ='' width='100px' height='130px'/><br /><br />")
                         End If
                           
                         %>

                   
                  </div>
                     
                  <div id="item_right" style="border-width: thin; border-style: outset; width:100px; height:130px"> 
                   
                   <%
                           If sysDBUser.staticdataright = True Then
                               Response.Write(" <a href='admimportpermit.aspx'>  <img src='images/sa/ok-icon.png' alt='Permit Management' width='80px' height='80px' /><br /> <br /> Importers Permit Management</a>")
                           Else
                               Response.Write("<img src='img/nopicture.jpg' alt ='' width='100px' height='130px'/><br /><br />")
                           End If
                           
                         %>


                    
                  </div>


                 <br />
             </td>    
             <td>
                 &nbsp;</td>
         </tr>

           <tr>
             <td class="style1">
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td align="center" style="font-family: calibri; font-size: small">
                 <hr /><td>
                 &nbsp;</td>
         </tr>

                    <tr>
             <td class="style1">
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td align="center">
                 <div id="item_left" style="border-width: thin; border-style: outset; width:100px; height:130px"> 
                  
                         <%
                           If sysDBUser.staticdataright = True Then
                                 Response.Write("<a href='downloadcenter.aspx?pg=3'> <img src='images/sa/Library-Folder-white-icon.png'  alt ='static data'  width='80px' height='80px' /><br /> <br />Manage Download Center</a>")
                           Else
                               Response.Write("<img src='img/nopicture.jpg' alt ='' width='100px' height='130px'/><br /><br />")
                           End If
                           
                         %>
                </div>

                <div id="item_right" style="border-width: thin; border-style: outset; width:100px; height:130px"> 
                   
                   <%
                           If sysDBUser.staticdataright = True Then
                           Response.Write("<a href='frontpagelastestnewssetup.aspx?pg=7'><img src='images/sa/Search-Images-icon.png' alt='Instrument Main Group' width='80px' height='80px' /><br /> <br />Configure Latest News</a>")
                           Else
                               Response.Write("<img src='img/nopicture.jpg' alt ='' width='100px' height='130px'/><br /><br />")
                           End If
                           
                         %>

                     
                 </div>

                    <div id="item_left" style="border-width: thin; border-style: outset; width:100px; height:130px"> 
                   
                   <%
                       If sysDBUser.DownloadCenter = True Then
                           Response.Write("<a href='viewUploadedFile.aspx?pg=8'> <img src='images/sa/dw1.jpg'  alt ='View Uploaded Files' width='80px' height='80px'  /><br /> <br />View Uploaded Files</a>")
                       Else
                           Response.Write("<img src='img/nopicture.jpg' alt ='' width='100px' height='130px'/><br /><br />")
                       End If
                           
                         %>

                </div>
                 
                      <div id="item_right" style="border-width: thin; border-style: outset; width:100px; height:130px"> 
                   
                   <%
                       If sysDBUser.uploadphotogallery = True Then
                           Response.Write("<a href='uploadphotogallery.aspx'> <img src='images/sa/upload3.jpg'  alt ='Upload Picture Gallery' width='80px' height='80px'  /><br /> <br />Upload Picture Gallery</a>")
                       Else
                           Response.Write("<img src='img/nopicture.jpg' alt ='' width='100px' height='130px'/><br /><br />")
                       End If
                           
                         %>

                </div>
                
                <div id="item_left" style="border-width: thin; border-style: outset; width:100px; height:130px"> 
                   
                   <%
                       If sysDBUser.uploadphotogallery = True Then
                           Response.Write("<a href='uploadfrontpage.aspx'> <img src='images/sa/upload1.jpg'  alt ='Setup Frontpage' width='80px' height='80px'  /><br /> <br />Setup Frontpage</a>")
                       Else
                           Response.Write("<img src='img/nopicture.jpg' alt ='' width='100px' height='130px'/><br /><br />")
                       End If
                           
                         %>

                </div>

                <div id="item_right" style="border-width: thin; border-style: outset; width:100px; height:130px"> 
                   
                    <%
                       If sysDBUser.staticdataright = True Then
                           Response.Write("<a href='setupStaticData.aspx'> <img src='images/sa/Button-Refresh-icon.png'  alt ='Refresh Static Data' width='80px' height='80px'  /><br /> <br />Refresh Static Data</a>")
                       Else
                           Response.Write("<img src='img/nopicture.jpg' alt ='' width='100px' height='130px'/><br /><br />")
                       End If
                           
                   %>

                </div>

                  <div id="item_left" style="border-width: thin; border-style: outset; width:100px; height:130px"> 
                   
                   <%
                       If sysDBUser.uploadphotogallery = True Then
                           Response.Write("<a href='setupstateoffices.aspx'> <img src='images/sa/catalog-icon.png'  alt ='Setup State Offices' width='80px' height='80px'  /><br /> <br />Setup State Offices</a>")
                       Else
                           Response.Write("<img src='img/nopicture.jpg' alt ='' width='100px' height='130px'/><br /><br />")
                       End If
                           
                         %>

                </div>

                <div id="item_right" style="border-width: thin; border-style: outset; width:100px; height:130px"> 
                   
                    <%
                        If sysDBUser.ArchiveRight = True Then
                            Response.Write("<a href='setuparchives.aspx'> <img src='images/sa/order-history-icon.png'  alt ='Create Archives' width='80px' height='80px'  /><br /> <br />Create Archives</a>")
                        Else
                            Response.Write("<img src='img/nopicture.jpg' alt ='' width='100px' height='130px'/><br /><br />")
                        End If
                           
                   %>

                </div>

                   <div id="item_left" style="border-width: thin; border-style: outset; width:100px; height:130px"> 
                   
                    <%
                        If sysDBUser.Quizright = True Then
                            Response.Write("<a href='adminquiz.aspx'> <img src='images/sa/Apps-date-icon.png'  alt ='Create Quiz' width='80px' height='80px'  /><br /> <br />Create Quiz</a>")
                        Else
                            Response.Write("<img src='img/nopicture.jpg' alt ='' width='100px' height='130px'/><br /><br />")
                        End If
                           
                   %>

                </div>

                <div id="item_right" style="border-width: thin; border-style: outset; width:100px; height:130px"> 
                   
                    <%
                        If sysDBUser.CarrearRight = True Then
                            Response.Write("<a href='admincarrears.aspx'> <img src='images/sa/task-notes-icon.png'  alt ='Create Carrear' width='80px' height='80px'  /><br /> <br />Create Carrear</a>")
                        Else
                            Response.Write("<img src='img/nopicture.jpg' alt ='' width='100px' height='130px'/><br /><br />")
                        End If
                           
                   %>

                </div>

                <div id="item_left" style="border-width: thin; border-style: outset; width:100px; height:130px"> 
                   
                    <%
                        If sysDBUser.emailRight = True Then
                            Response.Write("<a href='emailmgt.aspx'> <img src='images/sa/Status-mail-unread-icon.png'  alt ='Create Email' width='80px' height='80px'  /><br /> <br />Create Email Addresses</a>")
                        Else
                            Response.Write("<img src='img/nopicture.jpg' alt ='' width='100px' height='130px'/><br /><br />")
                        End If
                           
                   %>

                </div>



             <div id="item_right" style="border-width: thin; border-style: outset; width:100px; height:130px"> 
                   
                    <%
                        If sysDBUser.reportright = True Then
                            Response.Write("<a href='incomestatistics.aspx'> <img src='images/sa/Search-Search-Computer-icon.png'  alt ='Income Statistics' width='80px' height='80px'  /><br /> <br />Income Statistics</a>")
                        Else
                            Response.Write("<img src='img/nopicture.jpg' alt ='' width='100px' height='130px'/><br /><br />")
                        End If
                           
                   %>

                </div>

                 <br />
                 
                   <div id="item_left" style="border-width: thin; border-style: outset; width:100px; height:130px"> 
                   
                    <%
                        If sysDBUser.sysadminright = True Then
                            Response.Write("<a href='amdsetupdeviceprice.aspx'> <img src='images/sa/computer-ok-icon.png'  alt ='Setup Instrument Prices' width='80px' height='80px'  /><br /> <br />Setup Instrument Prices</a>")
                        Else
                            Response.Write("<img src='img/nopicture.jpg' alt ='' width='100px' height='130px'/><br /><br />")
                        End If
                           
                   %>

                </div>

                <div id="item_right" style="border-width: thin; border-style: outset; width:100px; height:130px"> 
                   
                    <%
                        If sysDBUser.sysadminright = True Then
                            Response.Write("<a href='amdsetupdevicmoveeprice.aspx'> <img src='images/sa/settings-icon.png'  alt ='Manage Instrument Prices' width='80px' height='80px'  /><br /> <br />Manage Instrument Prices</a>")
                        Else
                            Response.Write("<img src='img/nopicture.jpg' alt ='' width='100px' height='130px'/><br /><br />")
                        End If
                           
                   %>

                </div>

                <div id="item_left" style="border-width: thin; border-style: outset; width:100px; height:130px"> 
                   
                    <%
                        If sysDBUser.sysadminright = True Then
                            Response.Write("<a href='amdsetupmeasurename.aspx'> <img src='images/sa/Medical-invoice-information-icon.png'  alt ='Manage Measurement' width='80px' height='80px'  /><br /> <br />Manage Measurement</a>")
                        Else
                            Response.Write("<img src='img/nopicture.jpg' alt ='' width='100px' height='130px'/><br /><br />")
                        End If
                           
                   %>

                </div>

                <div id="item_right" style="border-width: thin; border-style: outset; width:100px; height:130px"> 
                   
                    <%
                        If sysDBUser.admregistration = True Then
                            Response.Write("<a href='admincregistration.aspx'> <img src='images/extra/index1.jpg'  alt ='Company Registration' width='80px' height='80px'  /><br /> <br />Company Registration</a>")
                        Else
                            Response.Write("<img src='img/nopicture.jpg' alt ='' width='100px' height='130px'/><br /><br />")
                        End If
                           
                   %>

                </div>

                <div id="item_left" style="border-width: thin; border-style: outset; width:100px; height:130px"> 
                   
                    <%
                        If sysDBUser.ExportAlertright = True Then
                            Response.Write("<a href='admexportmsgalert.aspx'> <img src='images/sa/Actions-document-save-icon.png'  alt ='Add Export Permit Message' width='80px' height='80px'  /><br /> <br />Add Export Permit Message</a>")
                        Else
                            Response.Write("<img src='img/nopicture.jpg' alt ='' width='100px' height='130px'/><br /><br />")
                        End If
                           
                   %>

                </div>
             </td>    
             <td>
               </td>
         </tr>

                    <tr>
             <td class="style1">
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td align="center">
                 <hr />
                        </td>    
             <td>
                 &nbsp;</td>
         </tr>

         <tr>
             <td class="style1">
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td><center>
                 <div class="item_title">
                     &nbsp;&nbsp;&nbsp; REPORTING</div></center>
             </td>
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td class="style1">
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
         </tr>
                <tr>
             <td class="style1">
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td align="center">

                 <div id="item_left"  style="border-width: thin; border-style: outset; width:100px; height:130px"> 
                      
                      <%
                          If sysDBUser.reportright = True Then
                              Response.Write(" <a href='admcompanyreports.aspx'> <img src='images/sa/Company-icon.png' alt ='Company report' width='80px' height='80px'  /><br /> <br /> Company Reports</a>")
                          Else
                              Response.Write("<img src='img/nopicture.jpg' alt ='' width='100px' height='130px'/><br /><br />")
                          End If
                           
                         %>

                    
                 </div>
                 
                 <div id="item_right"  style="border-width: thin; border-style: outset; width:100px; height:130px"> 
                    <%
                        If sysDBUser.reportright = True Then
                            Response.Write("<a href='admdevicereports.aspx'> <img src='images/sa/MI-Scare-Report-icon.png' alt='Instrument Report' width='80px' height='80px' /><br /> <br /> Instrument Reports</a>")
                        Else
                            Response.Write("<img src='img/nopicture.jpg' alt ='' width='100px' height='130px'/><br /><br />")
                        End If
                           
                         %>

                     
                 </div>  

                 <div id="item_left"  style="border-width: thin; border-style: outset; width:100px; height:130px">  
                      <%
                          If sysDBUser.reportright = True Then
                              Response.Write("<a href='admimportpermit.aspx'><img src='images/sa/computer-ok-icon.png' alt ='Import Permit' width='80px' height='80px'  /><br /> <br /> Import Permit</a>  ")
                          Else
                              Response.Write("<img src='img/nopicture.jpg' alt ='' width='100px' height='130px'/><br /><br />")
                          End If
                           
                         %>

                    
                 </div>
                 
                 <div id="item_right"  style="border-width: thin; border-style: outset; width:100px; height:130px"> 
                      <%
                          If sysDBUser.reportright = True Then
                              Response.Write(" <a href='admexportpermit.aspx'> <img src='images/sa/Apps-preferences-system-login-icon.png'  alt='Export permit' width='80px' height='80px' /><br /> <br /> Export Permit</a> Reports")
                          Else
                              Response.Write("<img src='img/nopicture.jpg' alt ='' width='100px' height='130px'/><br /><br />")
                          End If
                           
                         %>

                   
                 </div>  
                  
                 <div id="item_left"  style="border-width: thin; border-style: outset; width:100px; height:130px">
                    <%
                           If sysDBUser.auditright = True Then
                               Response.Write("<a href='admauditrial.aspx'>  <img src='images/sa/URL-history-icon.png' alt ='New User' width='80px' height='80px' /> <br /><br /> Audit Report</a>")
                           Else
                               Response.Write("<img src='img/nopicture.jpg' alt ='' width='100px' height='130px'/><br /><br />")
                           End If
                           
                         %>

                    
                    </div>

                    <div id="item_right"  style="border-width: thin; border-style: outset; width:100px; height:130px">
                    <%
                           If sysDBUser.companymgtright = True Then
                            Response.Write("<a href='adminpatternapproval.aspx'>  <img src='images/sa/Actions-document-preview-archive-icon.png' alt ='Company Request' width='80px' height='80px' /> <br /><br />Company Request</a>")
                           Else
                               Response.Write("<img src='img/nopicture.jpg' alt ='' width='100px' height='130px'/><br /><br />")
                           End If
                           
                     %>

                     </div>

                    <div id="item_left"  style="border-width: thin; border-style: outset; width:100px; height:130px">
                    <%
                        If sysDBUser.reportright = True Then
                            Response.Write("<a href='noticeofcontravention.aspx'>  <img src='images/sa/Edit-Document-icon.png' alt ='Notice Of Contravention' width='80px' height='80px' /> <br /><br />Notice Of Contravention</a>")
                        Else
                            Response.Write("<img src='img/nopicture.jpg' alt ='' width='100px' height='130px'/><br /><br />")
                        End If
                           
                     %>
                    
                    </div>

                        <div id="item_right"  style="border-width: thin; border-style: outset; width:100px; height:130px">
                    <%
                        If sysDBUser.otherdocright = True OrElse sysDBUser.piaexportdatareturns=True  OrElse sysDBUser.exportdatareturns=True  Then
                            Response.Write("<a href='admindownloadfiles.aspx'>  <img src='images/sa/Edit-Document-icon.png' alt ='Clients Uploaded File' width='80px' height='80px' /> <br /><br />Clients Uploaded File</a>")
                        Else
                            Response.Write("<img src='img/nopicture.jpg' alt ='' width='100px' height='130px'/><br /><br />")
                        End If
                           
                     %>
                    
                    </div>

                    <div id="item_left"  style="border-width: thin; border-style: outset; width:100px; height:130px">
                    <%
                        If sysDBUser.accountsreport Then
                            Response.Write("<a href='admininviocesreports.aspx'>  <img src='images/extra/Accounts.jpg' alt ='Invioce History' width='80px' height='80px' /> <br /><br />Invioce History</a>")
                        Else
                            Response.Write("<img src='img/nopicture.jpg' alt ='' width='100px' height='130px'/><br /><br />")
                        End If
                           
                     %>
                    
                    </div>

                 </div>

               <br />
                      
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td class="style1">
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td>
                 <hr /></td>
             <td>
                 &nbsp;</td>
         </tr>
     </table>
        
    </div></center>

</div>
       
</div>
    

<!--end home-->
</asp:Content>

