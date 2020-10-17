<%@ Page Title="" Language="VB" MasterPageFile="~/ISP.master" AutoEventWireup="false" CodeFile="ISPCenter.aspx.vb" Inherits="ISPCenter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td>
                &nbsp;</td>
            <td colspan="7">
                <center>
                 <div class="item_title">
                     &nbsp;&nbsp;&nbsp; ISP MANAGEMENT INTERFACE</div></center></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td colspan="7">
                <div id="item_left" 
                    style="border-width: thin; border-style: outset; width:100px; height:130px">
                 <%
                     Response.Write("<a href='ISPadmdevicemgt.aspx'><img src='images/sa/users-icon1.png' alt ='Manage Your Client' width='80px' height='80px'/><br /><br />Manage Your Client</a>")
                    
                     %>
                     
                </div>
                <div id="item_right" 
                    style="border-width: thin; border-style: outset; width:100px; height:130px">
                       <%
                           Response.Write("<a href='ISPUploadFile.aspx?pg=1'> <img src='images/sa/Text-Edit-icon.png' alt='Upload Files'  width='80px' height='80px'/><br /><br />Upload Files</a>")
                                                     
                         %>

                 </div>
                <div id="item_left" 
                    style="border-width: thin; border-style: outset; width:100px; height:130px">
                        <%
                           
                            Response.Write("<a href='ISPadmdevicemgt.aspx'><img src='images/sa/user-group-icon.png' alt ='Register New Instruments'  width='80px' height='80px'/><br />Register New Instruments</a>")
                                                    
                         %>
                 </div>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

