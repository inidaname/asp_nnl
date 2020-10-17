<%@ Page Title="" Language="VB" MasterPageFile="~/companypage.master" AutoEventWireup="false" CodeFile="quiz.aspx.vb" EnableEventValidation ="false" ValidateRequest ="false"  Inherits="quiz" %>
<%@ Import Namespace="System.Data" %>

 <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></cc1:ToolkitScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<center>
    <table style="width:100%;">
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td colspan="5" align="center">
                <p class="MsoNormal">
                    <span style="mso-spacerun:yes">
                    </span><b style="mso-bidi-font-weight:normal"><span style="font-size:14.0pt">
                    NIGERCO NIGERIA LIMITED</span></b></p>QUIZ QUESTIONS
               
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
            <td>
                &nbsp;</td>
            <td style="width: 379px" align="right">
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
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td align="right" style="width: 379px">
                &nbsp;</td>
            <td>
                <asp:Label ID="lblResult" runat="server" Font-Names="Calibri" 
                    Font-Size="Medium"></asp:Label>
            </td>
            <td>
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
            <td>
                &nbsp;</td>
            <td style="width: 379px">
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
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td style="width: 379px">
                &nbsp;</td>
            <td>
                <asp:Label ID="lblQuestion" runat="server" BackColor="#DEDEDE" Font-Bold="True" 
                    Font-Italic="False" Font-Names="Calibri" Font-Overline="False" 
                    Font-Size="Large" Font-Underline="True"></asp:Label>
            </td>
            <td>
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
            <td>
                &nbsp;</td>
            <td align="center" colspan="2">
                <asp:Label ID="lblResult0" runat="server" Font-Bold="True" Font-Names="Calibri" 
                    Font-Size="Small">Choose an answer from among the list of options,the one you consider to be the answer to the question above</asp:Label>
            </td>
            <td>
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
            <td>
                &nbsp;</td>
            <td colspan="2">
               <hr /></td>
            <td>
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
            <td>
                &nbsp;</td>
            <td style="width: 379px">
                &nbsp;</td>
            <td>
                <asp:RadioButton ID="opt1" runat="server" GroupName="q" Font-Names="Calibri" 
                    Font-Size="Medium" />
            </td>
            <td>
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
            <td>
                &nbsp;</td>
            <td style="width: 379px">
                &nbsp;</td>
            <td>
                <asp:RadioButton ID="opt2" runat="server" GroupName="q" Font-Names="Calibri" 
                    Font-Size="Medium" />
            </td>
            <td>
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
            <td>
                &nbsp;</td>
            <td style="width: 379px">
                &nbsp;</td>
            <td>
                <asp:RadioButton ID="opt3" runat="server" GroupName="q" Font-Names="Calibri" Font-Size="Medium" />
            </td>
            <td>
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
            <td>
                &nbsp;</td>
            <td style="width: 379px">
                &nbsp;</td>
            <td>
                <asp:RadioButton ID="opt4" runat="server" GroupName="q" Font-Names="Calibri" 
                    Font-Size="Medium" />
            </td>
            <td>
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
            <td>
                &nbsp;</td>
            <td colspan="2">
               <hr /></td>
            <td>
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
            <td>
                &nbsp;</td>
            <td style="width: 379px">
                &nbsp;</td>
            <td>
                <asp:Button ID="txtNext" runat="server" Text="NEXT" />
                     <cc1:confirmbuttonextender ID="txtNext_ConfirmButtonExtender" runat="server" 
                        ConfirmOnFormSubmit="True" 
                        ConfirmText="Are you sure you want PICK this Option?" Enabled="True" 
                        TargetControlID="txtNext">
                    </cc1:confirmbuttonextender>
            </td>
            <td>
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
            <td>
                &nbsp;</td>
            <td style="width: 379px">
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
</center>

</ContentTemplate>
   </asp:UpdatePanel>

</asp:Content>

