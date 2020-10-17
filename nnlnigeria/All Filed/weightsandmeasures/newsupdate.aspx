<%@ Page Title="" Language="VB" MasterPageFile="~/companypage.master" AutoEventWireup="false" CodeFile="newsupdate.aspx.vb" Inherits="newsupdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<!--start home-->

<div id="item1">
	 
  <div class="item_title">&nbsp;&nbsp;&nbsp; News Update </div>

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
             <td >
               <div>
                     <%
                         Dim GenTool As NNLN = xsmsCentralToolx.SetTool
                       Response .Write (  GenTool.getRowItemInds(dsFrontPageSetup, "BodyMessage", "sysID", Request("pg")))
                         %>         
                </div></td>

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
     </table>
        
        </div></center>
   
 
</div>

        
</div>
    
<!--end home-->

</asp:Content>

