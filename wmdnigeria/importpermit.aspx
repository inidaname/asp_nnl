<%@ Page Language="VB" AutoEventWireup="false"  MasterPageFile="~/exportpage.master"  CodeFile="importpermit.aspx.vb" Inherits="exportpermit" %>

<%@ Import Namespace="System.Data" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<!--start home-->
<div id="item1">
	 
  <div class="item_title">&nbsp;&nbsp;&nbsp; EXPORT PERMIT</div>

 <div>
	  <center>
        <div style="width : 75%" id="main-menu">
      
           <table style="width: 100%;" bgcolor="Silver">
         <tr>
             <td class="style1">
                 &nbsp;</td>
             <td align="right" class="style7" style="width: 297px">
                 &nbsp;</td>
             <td>
                 &nbsp;<td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td class="style1">
                 &nbsp;</td>
             <td align="right" class="style7" style="width: 297px">
                <asp:Label ID="Label2" runat="server" Text="Username" Font-Names="Agency FB"></asp:Label></td>
             <td>
                 <div id="login">
                     <input id="txtUserName" class="theinput3" name="txtUserName1" title="UserName" 
                         type="text" />
                 </div>
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td class="style1">
                 &nbsp;</td>
             <td align="right" class="style7" style="width: 297px">
                 <asp:Label ID="Label1" runat="server" Text="Password" Font-Names="Agency FB"></asp:Label>
             </td>
             <td>
                 
                 <div id="login">
                     <input id="txtPassword" class="theinput3" name="txtPassword1" title="Password" 
                         type="password" />
                 </div>
                 
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td class="style1">
                 &nbsp;</td>
             <td class="style7" style="width: 297px">
                 &nbsp;</td>
             <td>
                 <div id="login2">
                     <input class="theinput4" name="Login1" type="submit" value="Login" />
                 </div>
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td class="style1">
                 &nbsp;</td>
             <td class="style7" style="width: 297px">
                 &nbsp;
             </td>
             <td>
              
             <a href="cregistration.aspx?status=import">    <asp:Label ID="Label3" runat="server" Font-Names="Agency FB" 
                     Text="New Account" Font-Bold="False" Font-Italic="False" 
                     Font-Size="Medium"></asp:Label></a>
&nbsp; |&nbsp;
               <a href="fpassword.aspx?pg=ei"><asp:Label ID="Label4" runat="server" Font-Names="Agency FB" 
                     Text="Forgot Password" Font-Size="Medium"></asp:Label></a>
              
             <td>
                 &nbsp;
             </td>
         </tr>
         <tr>
             <td class="style1">
                 &nbsp;</td>
             <td class="style7" style="width: 297px">
                 &nbsp;
             </td>
             <td style="font-family: calibri, Arial, Helvetica, sans-serif">
              </td>
             <td>
                 &nbsp;
             </td>
         </tr>
         <tr>
             <td class="style3">
                 </td>
             <td class="style7" style="width: 297px">
                 &nbsp;
             </td>
             <td class="style5">
                 &nbsp;
             </td>
             <td class="style5">
                 &nbsp;
             </td>
         </tr>
         <tr>
             <td class="style1">
                 &nbsp;</td>
             <td class="style7" style="width: 297px">
                 &nbsp;</td>
             <td>
           
             </td>
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td class="style1">
                 &nbsp;</td>
             <td class="style7" style="width: 297px">
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
         </tr>
     </table>
        
        </div></center>
   
 
</div>

        
</div>
    
</asp:Content>                