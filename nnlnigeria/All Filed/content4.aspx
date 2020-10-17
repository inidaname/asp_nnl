<%@ Page Title="" Language="VB" MasterPageFile="~/companypage.master" AutoEventWireup="false" CodeFile="content4.aspx.vb" Inherits="content1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <%Dim sysID As String = Request("msgid")%>
  <%Dim GenTool As NNLN = xsmsCentralToolx.SetTool%>
  <%Dim dsV As System.Data.DataSet = GenTool.getFromDataset(dsfrontpagemain, "sysID=" & Val(sysID))%>
  <%If GenTool.HasDatasetAnyRecord(dsV) = True Then Return%>
  <%With dsV.Tables(0).Rows(0)%>

    <table border="0" cellpadding="0" class="MsoNormalTable" 
        style="width:80.82%;mso-cellspacing:1.5pt;mso-yfti-tbllook:1184" width="80%">
        <tr style="mso-yfti-irow:0;mso-yfti-firstrow:yes;mso-yfti-lastrow:yes">
            <td width="96%">
                <p class="MsoNormal" style="margin-bottom:0in;margin-bottom:.0001pt;line-height:
  normal">
                    <o:p>
                    <b>
                    <span lang="EN-GB" style="font-size:
  14.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;;
  mso-fareast-language:EN-GB"> <% Response.Write(.Item("HeaderName"))%></span></b><span 
                        lang="EN-GB" style="font-size:12.0pt;font-family:
  &quot;Times New Roman&quot;,&quot;serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;;
  mso-fareast-language:EN-GB"><o:p></o:p></span></o:p></p>
            </td>
            <td width="0%">
                <p align="right" class="MsoNormal" style="margin-bottom:0in;margin-bottom:.0001pt;
  text-align:right;line-height:normal">
                    <span lang="EN-GB" style="font-size:12.0pt;
  font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;;
  mso-fareast-language:EN-GB">
                    <o:p>
                    &nbsp;</o:p></span></p>
            </td>
            <td width="0%">
            </td>
            <td width="0%">
            </td>
        </tr>
    </table>

    <p class="MsoNormal" style="margin-bottom:0in;margin-bottom:.0001pt;line-height:
normal">
        <span lang="EN-GB" style="font-size:12.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;
mso-fareast-font-family:&quot;Times New Roman&quot;;display:none;mso-hide:all;mso-fareast-language:
EN-GB">
        <o:p>
        &nbsp;</o:p></span></p>
    <table border="0" cellpadding="0" class="MsoNormalTable" style="mso-cellspacing:1.5pt;
 mso-yfti-tbllook:1184">
        <tr style="mso-yfti-irow:0;mso-yfti-firstrow:yes;mso-yfti-lastrow:yes">
            <td valign="top">
                &nbsp;</td>
            <td valign="top">
                <p class="MsoNormal" style="margin-bottom:12.0pt;line-height:normal">
                   <![if !vml]>
                    <img align="left" 
                        alt="Picture" height="168" 
                        src="frontdoc/<% Response.Write(.Item("sysImageName"))%>" 
                        style="font-size: small; font-family: Calibri" v:shapes="Picture_x0020_4" 
                        width="224" /><![endif]></p>
                <p style="font-size: small">
                    <span style="font-family: Calibri"><% Response.Write(.Item("FullMessage"))%>
</span></p>
            </td>
            <td valign="top">
                &nbsp;</td>
        </tr>
    </table>

    
   <% End With%>
</asp:Content>

