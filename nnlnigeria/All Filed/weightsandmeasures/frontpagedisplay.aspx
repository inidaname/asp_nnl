<%@ Page Title="" Language="VB" MasterPageFile="~/companypage.master" AutoEventWireup="false" CodeFile="frontpagedisplay.aspx.vb" Inherits="frontpagedisplay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <%
      Dim sysID As String = Request("msgid")
      Dim GenTool As NNLN = xsmsCentralToolx.SetTool
      Dim dsV As System.Data.DataSet = GenTool.DataSetData("select sysID,HeaderName,BriefMsg,FullMessage,sysImageName from frontpagemain where Status=1 AND sysid=" & Val(sysID) & " order by sysID asc")
  If GenTool.HasDatasetAnyRecord(dsV) = True Then Return 
      With dsV.Tables(0).Rows(0)
          
          %>

    <table style="width: 100%;">
        <tr>
            <td 
                
                style="font-family: Calibri; font-size: large; font-weight: bold; font-style: normal">
                &nbsp;</td>
            <td colspan="6" style="font-family: Calibri; font-size: x-large; font-weight: bold; font-style: normal">
             
                <% Response.Write(.Item("HeaderName"))%>
              </td>
        </tr>
        <tr>
            <td style="text-align: justify">
                &nbsp;</td>
            <td colspan="6" style="text-align: justify; font-family: Calibri; font-size: medium;">
           
                <img align="left" alt="Picture" height="168" 
                    src='<% Response.Write(docLink & "frontdoc/" & .Item("sysImageName"))%>' 
                    style="font-size: small; font-family: Calibri" v:shapes="Picture_x0020_4" 
                    width="224" /><p style="text-align: justify"> <% Response.Write(.Item("FullMessage"))%></p> </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
             
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>

        
   <% End With%>
</asp:Content>

