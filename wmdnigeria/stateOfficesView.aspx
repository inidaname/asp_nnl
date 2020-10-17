<%@ Page Title="" Language="VB" MasterPageFile="~/companypage.master" AutoEventWireup="false" CodeFile="stateOfficesView.aspx.vb" Inherits="stateOffices" %>

<%@ Import Namespace="System.Data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
<%  
    Dim GenTool As NNLN = xsmsCentralToolx.SetTool
    Dim ds As DataSet = GenTool.DataSetData("select StateName,StateAddress,Contacts,ContactPersonName,ContactPersonMobile,googlemapLink from statecontacts where sysID=" & Val(Request("id")))
    
    If GenTool.HasDatasetAnyRecord(ds) = False Then
        With ds.Tables(0).Rows(0)

    %>

    <div>
 <center>
        <div style="width : 75%" id="main-menu">
      
           <table style="width: 100%;">
         <tr>
             <td class="style1" style="width: 31px">
                 &nbsp;</td>
             <td>
                 &nbsp;<td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td class="style1" style="width: 31px">
                 &nbsp;</td>
             <td align ="center" >
                 <div class="item_title">
                     &nbsp;&nbsp;&nbsp; <% Response.Write(.Item("StateName").ToString)%></div>
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td class="style1" style="width: 31px">
                 &nbsp;</td>
             <td>
                 <p style="font-family: Calibri; font-size: small" align="center">
                   <% Response.Write(.Item("StateAddress").ToString)%></p>
                    <hr />
                 <p align="center" style="font-family: calibri; font-size: small">
                 <strong> Electronic Contact</strong><br />
                  <% Response.Write(.Item("Contacts").ToString)%></p>
                 <br /></td>
             <td>
                 &nbsp;</td>
         </tr>

            <tr>
             <td class="style1" style="width: 31px">
                 &nbsp;</td>
             <td align="center">
               
                 <strong style="font-family: Calibri">Contact Person</strong></td>
             <td>
                 &nbsp;
             </td>
         </tr>

                    <tr>
             <td class="style1" style="width: 31px">
                 &nbsp;</td>
             <td>
               
                 <hr />   
               
             </td>
             <td>
                 &nbsp;
             </td>
         </tr>

         <tr>
             <td class="style1" style="width: 31px">
                 &nbsp;</td>
             <td align ="center">
             <% Response.Write(.Item("ContactPersonName").ToString)%>
                 <br /> 
                  <% Response.Write(.Item("ContactPersonMobile").ToString)%>
                  <br />
             </td>
             <td>
                 &nbsp;
             </td>
         </tr>

         <tr>
             <td style="width: 31px"  >
                 </td>
             <td align="center">
             <%    If String.IsNullOrEmpty(.Item("googlemapLink").ToString.Trim) = False Then%>
                 <div class="item_title">
                     &nbsp;&nbsp;&nbsp; Office Road Map</div>
                     
                <% end if  %>     
                     </td>
             <td>
                 &nbsp;</td>
         </tr>

         <tr>
             <td style="width: 31px"  >
                 &nbsp;</td>
             <td align="center">
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
         </tr>

         <tr>
             <td class="style1" style="width: 31px">
                 &nbsp;</td>

             <td align="center">
               <% 
                   If String.IsNullOrEmpty(.Item("googlemapLink").ToString.Trim) = False Then
                       
                       Dim sd As String = "<iframe id='I1' frameborder='0' height='350' marginheight='0' marginwidth='0' name='I1' scrolling='no' src='" & .Item("googlemapLink").ToString & "&amp;output=embed' width='100%'></iframe>" & _
                            "<br/>" & _
                            "<small>" & _
                            " <a href='" & .Item("googlemapLink").ToString & "' style='color:#0000FF;text-align:left'>View Larger Map</a> " & _
                            " </small>"
                       Response.Write(sd)
                   End If
                   
                   %>
                 
                  </td>
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td class="style1" style="width: 31px">
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td class="style1" style="width: 31px">
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
         </tr>
     </table>
        
        </div></center>
     </div>

     <%              
     End With
 End If
     %>
</center>
</asp:Content>

