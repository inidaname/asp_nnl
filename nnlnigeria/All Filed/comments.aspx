<%@ Page Title="" Language="VB" MasterPageFile="~/companypage.master" AutoEventWireup="false" CodeFile="comments.aspx.vb" Inherits="comments" %>

<%@ Import Namespace="System.Data" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </cc1:ToolkitScriptManager>

    <table style="width:100%;">
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
               <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                    <center>
                <div style="border: thin solid #003399; width :80%; border-radius: 15px 0 15px 0;">

                 <table style="width:100%;">
                     <tr>
                         <td>
                             &nbsp;</td>
                         <td>
                             &nbsp;</td>
                         <td class="style2" style="width: 126px">
                             &nbsp;</td>
                         <td style="font-family: Calibri; font-size: medium">
                             &nbsp;</td>
                         <td>
                             &nbsp;</td>
                         <td>
                             &nbsp;</td>
                     </tr>
                     <tr>
                         <td>
                             &nbsp;</td>
                         <td>
                             &nbsp;</td>
                         <td class="style2" style="width: 126px">
                             &nbsp;</td>
                         <td style="font-family: Calibri; font-size: medium">
                             Please let us know your comments</td>
                         <td>
                             &nbsp;</td>
                         <td>
                             &nbsp;</td>
                     </tr>
                     <tr>
                         <td>
                             &nbsp;</td>
                         <td>
                             &nbsp;</td>
                         <td class="style2" style="width: 126px">
                             &nbsp;</td>
                         <td>
                             &nbsp;</td>
                         <td>
                             &nbsp;</td>
                         <td>
                             &nbsp;</td>
                     </tr>
                     <tr>
                         <td>
                             &nbsp;</td>
                         <td>
                             &nbsp;</td>
                         <td class="style2" style="width: 126px">
                             <asp:Label ID="Label1" runat="server" Font-Names="Calibri" Font-Size="Medium" 
                                 Text="Fullname:"></asp:Label>
                         </td>
                         <td>
                             <asp:TextBox ID="txtfullname" runat="server" Font-Names="Calibri" 
                                 Font-Size="Small" Width="230px"></asp:TextBox>
                         </td>
                         <td>
                             &nbsp;</td>
                         <td>
                             &nbsp;</td>
                     </tr>
                     <tr>
                         <td>
                             &nbsp;</td>
                         <td>
                             &nbsp;</td>
                         <td class="style2" style="width: 126px">
                             <asp:Label ID="Label2" runat="server" Font-Names="Calibri" Font-Size="Medium" 
                                 Text="Email Address:"></asp:Label>
                         </td>
                         <td>
                             <asp:TextBox ID="txtemail" runat="server" Width="230px" Font-Names="Calibri" 
                                 Font-Size="Small"></asp:TextBox>
                         </td>
                         <td>
                             &nbsp;</td>
                         <td>
                             &nbsp;</td>
                     </tr>
                     <tr>
                         <td>
                             &nbsp;</td>
                         <td>
                             &nbsp;</td>
                         <td class="style2" valign="top" style="width: 126px">
                             <asp:Label ID="Label4" runat="server" Font-Names="Calibri" Font-Size="Medium" 
                                 Text="Subject:"></asp:Label>
                         </td>
                         <td>
                             <asp:TextBox ID="txtsubject" runat="server" Font-Names="Calibri" 
                                 Font-Size="Small" Width="230px"></asp:TextBox>
                                 <asp:UpdateProgress ID="updProgress" runat="server" 
                                 AssociatedUpdatePanelID="UpdatePanel1">
                                 <ProgressTemplate>

                                 <div id="item_left"> 
                                     <img alt="progress"  src="images/sa/glossy-3d-blue-hourglass-icon.png" /> </div>
                                 <div id="item_right" style="font-family: calibri; font-size: small; color : red" > Sending mail please wait...</div>  
                                   
                                 </ProgressTemplate>
                             </asp:UpdateProgress>
                         </td>
            
                         <td>
                             &nbsp;</td>
                         <td>
                             &nbsp;</td>
                     </tr>
                     <tr>
                         <td>
                             &nbsp;</td>
                         <td>
                             &nbsp;</td>
                         <td align="left" valign="top" class="style2" style="width: 126px">
                             <asp:Label ID="Label3" runat="server" Font-Names="Calibri" Font-Size="Medium" 
                                 Text="Message:"></asp:Label>
                         </td>
                         <td>
                         <%--    <cc2:Editor ID="txtMessage" runat="server" 
                                 NoScript="True" />--%>
                             <asp:TextBox ID="txtMessage" Height="300px" Width="100%"  runat="server" 
                                 Font-Names="Calibri" Font-Size="Medium" TextMode="MultiLine"></asp:TextBox>
                         </td>
                         <td>
                             &nbsp;</td>
                         <td>
                             &nbsp;</td>
                     </tr>
                     <tr>
                         <td>
                             &nbsp;</td>
                         <td>
                             &nbsp;</td>
                         <td class="style2" style="width: 126px">
                             &nbsp;</td>
                         <td>
                             <asp:Button ID="btnSendMessage" runat="server" Text="Send Message" 
                                 style="height: 26px" />
                             <cc1:ConfirmButtonExtender ID="btnSendMessage_ConfirmButtonExtender" 
                                 runat="server" ConfirmOnFormSubmit="True" 
                                 ConfirmText="Are you sure you want to SEND this message?" Enabled="True" 
                                 TargetControlID="btnSendMessage">
                             </cc1:ConfirmButtonExtender>
                         </td>
                         <td>
                             &nbsp;</td>
                         <td>
                             &nbsp;</td>
                     </tr>
                     <tr>
                         <td>
                             &nbsp;</td>
                         <td>
                             &nbsp;</td>
                         <td class="style2" style="width: 126px">
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
                 </ContentTemplate>
                </asp:UpdatePanel></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
             
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
  
</asp:Content>


