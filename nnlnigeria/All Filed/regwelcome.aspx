<%@ Page Title="Welcome!" Language="VB" MasterPageFile="~/companynoheader.master" AutoEventWireup="false" CodeFile="regwelcome.aspx.vb" Inherits="regwelcome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>

<div style=" width:65%; height :500px; background-position: center center;margin: 0px 0px 0px 0px;background-image: url('images/welcome.png'); background-repeat: no-repeat;padding: 0px 0px 0px 0px" >

    <center>
        <img src="images/coatofarm.jpg" />
        <br />
        <br />
        <p align="center" class="MsoNormal" style="margin-bottom:0in;margin-bottom:.0001pt;
text-align:center">
            <span lang="EN-GB" 
                
                style="font-family:&quot;Georgia&quot;,&quot;serif&quot;; font-size: large; font-weight: bold;">
            FEDERAL MINISTRY OF INDUSTRY, TRADE AND INVESTMENT<o:p></o:p></span></p>
        <p align="center" class="MsoNormal" style="margin-bottom:0in;margin-bottom:.0001pt;
text-align:center; line-height: 200%;">
            <o:p></o:p></p>
        <p align="center" class="MsoNormal" style="margin-bottom:0in;margin-bottom:.0001pt;
text-align:center; line-height: 200%;">
            <span lang="EN-GB" 
                style="font-family:&quot;Georgia&quot;,&quot;serif&quot;; font-size: medium;">
            WEIGHTS AND MEASURES DEPARTMENT<o:p></o:p></span></p>
        <p align="center" class="MsoNormal" style="margin-bottom:0in;margin-bottom:.0001pt;
text-align:center; line-height: 200%;">
            <span lang="EN-GB" 
                style="font-family:&quot;Georgia&quot;,&quot;serif&quot;; font-size: medium;">Old 
            Secretariat Area 1, Garki Abuja.<o:p></o:p></span></p>
        <p align="center" class="MsoNormal" style="margin-bottom:0in;margin-bottom:.0001pt;
text-align:center">
            <table style="width:100%;">
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <p class="MsoNormal">
                            <span lang="en-US" style="font-family:Georgia;mso-default-font-family:Georgia;mso-ascii-font-family:
Georgia;mso-latin-font-family:Georgia;mso-greek-font-family:Georgia;mso-cyrillic-font-family:
Georgia;mso-latinext-font-family:Georgia;font-style:italic;language:en-US;
mso-ansi-language:en-US; font-size: medium; text-align: left;">&nbsp;&nbsp;&nbsp;&nbsp;</span></p>
                        <p class="MsoNormal">
                            <span lang="en-US" style="font-family:Georgia;mso-default-font-family:Georgia;mso-ascii-font-family:
Georgia;mso-latin-font-family:Georgia;mso-greek-font-family:Georgia;mso-cyrillic-font-family:
Georgia;mso-latinext-font-family:Georgia;font-style:italic;language:en-US;
mso-ansi-language:en-US; font-size: medium; text-align: left;">&nbsp;&nbsp;&nbsp;&nbsp; Welcome <% Response.Write( Session("cname"))%><o:p></o:p>
                            </span>
                        </p>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <p class="MsoNormal">
                            <span lang="en-US" style="font-family:Georgia;mso-default-font-family:Georgia;mso-ascii-font-family:
Georgia;mso-latin-font-family:Georgia;mso-greek-font-family:Georgia;mso-cyrillic-font-family:
Georgia;mso-latinext-font-family:Georgia;font-style:italic;language:en-US;
mso-ansi-language:en-US; font-size: medium;">&nbsp;&nbsp;&nbsp; Thank you for registering your company.<o:p></o:p></span></p>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <p class="MsoNormal">
                            <span lang="en-US" style="font-family:Georgia;mso-default-font-family:Georgia;
mso-ascii-font-family:Georgia;mso-latin-font-family:Georgia;mso-greek-font-family:
Georgia;mso-cyrillic-font-family:Georgia;mso-latinext-font-family:Georgia;
font-style:italic;language:en-US;mso-ansi-language:en-US; font-size: medium;">&nbsp; We employ you to 
                            register and pay for all your weights, measures, weighing&nbsp;&nbsp; and 
                            measuring equipments or instruments used for Trade and official purposes.<o:p></o:p></span></p>
                    </td>
                </tr>
                <tr>
                    <td>
                        </td>
                </tr>
                </table>
            <o:p></o:p></p>
    </center>

 
    <p class="MsoNormal">
        <span lang="en-US" style="language:en-US">&nbsp;<o:p></o:p></span></p>

</div>

</center>
</asp:Content>

