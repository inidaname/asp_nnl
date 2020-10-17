<%@ Page Title="Export Application Details" Language="VB" MasterPageFile="~/exportpage.master" AutoEventWireup="false" CodeFile="exportrejectedalert.aspx.vb" Inherits="exportappdetails" %>
<%@ Import Namespace="System.Data" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc2" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link rel="stylesheet" href="invoice/css/style.css" type="text/css" />
    <script language="javascript" type="text/javascript">
        function goBack() {
            window.history.go(-1); return false;
        }
    </script>

 
<div align="center">
	<div id="page2">
    	<div id="row17"><img src="invoice/images/logo2.jpg" /></div>
       	<div id="row18">FEDERAL MINISTRY OF INDUSTRY, TRADE AND INVESMENT
        COMMODITIES AND PRODUCTS INSPECTORATE DEPARTMENT
        </div>

        <div id="row19">EXPORT PERMIT APPLICATION STATUS</div>
        <% 
            Dim streetAddress As String = ""
            Dim City As String = ""
            
            Dim GenTool As NNLN = xsmsCentralToolx.SetTool
            Dim sd As String = "select streetAddress,(select city from tblcity where tblcity.sysID=cityID limit 1) as City from companyregistration where sysID=" & Val(Session("ID"))
            Dim dbStore As DataSet = GenTool.DataSetData(sd)
            
            If GenTool.HasDatasetRecords(dbStore) = True Then
                streetAddress = dbStore.Tables(0).Rows(0).Item(0).ToString
                City = dbStore.Tables(0).Rows(0).Item(1).ToString
                dbStore.Dispose()
            End If
            %>
        <div id="row20">
        	<div id="col36">&nbsp;</div
            ><div id="col37">COMPANY REG ID:</div><div id="col38"><% Response.Write(Request.QueryString("txtID"))%></div>
        	<div id="col37">COMPANY NAME:</div><div id="col38"><% Response.Write(Request.QueryString("txtcompanyname"))%></div>
        	<div id="col37">EXPORT PERMIT QUARTER:</div><div id="col38"><% Response.Write(Request.QueryString("txtexportPermitName"))%></div>
        	<div id="col37">EXPORT QUANTITY:</div><div id="col38"><% Response.Write(Request.QueryString("txtQuatity"))%></div>
        	<div id="col37">PORT OF EXPORT:</div><div id="col38"><% Response.Write(Request.QueryString("txtusername17"))%></div>
        	<div id="col37">STATUS:</div><div id="col38"><% Response.Write("<font style='color:#F00'>APPLICATION REJECTED</font>")%></div>
        	<div id="col37">DATE:</div><div id="col38"><% Response.Write(Request.QueryString("txtDPTTo"))%></div>        	 
        </div>
        <div id="row38">
            <p class="MsoNormal" style="margin-bottom:0in;margin-bottom:.0001pt;text-align:
justify;line-height:normal">
                <b><span style="font-size:14.0pt">COMMENT(S): The document attached are not 
                valid, hence your application has been rejected.<o:p></o:p></span></b></p>
            <p class="MsoNormal" style="margin-bottom:0in;margin-bottom:.0001pt;text-align:
justify;line-height:normal">
                <o:p></o:p>
            </p>
            <p class="MsoNormal" style="margin-bottom:0in;margin-bottom:.0001pt;text-align:
justify;line-height:normal">
                <b><span style="font-size:14.0pt"><o:p>&nbsp;</o:p></span><span style="font-size:14.0pt;line-height:115%;font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;;
mso-fareast-font-family:Calibri;mso-bidi-font-family:Arial;mso-ansi-language:
EN-US;mso-fareast-language:EN-US;mso-bidi-language:AR-SA">Thank you.</span></b></p>
            <p class="MsoNormal" style="margin-bottom:0in;margin-bottom:.0001pt;text-align:
justify;line-height:normal">
                &nbsp;</p>
            <p align="right" class="MsoNormal">
                <b><span style="font-size:14.0pt">Mr. Benard Usman<o:p></o:p></span></b></p>
            <p align="right" class="MsoNormal">
                <b><span style="font-size:14.0pt">CPI Inspector<o:p></o:p></span></b></p>
            <p class="MsoNormal" style="margin-bottom:0in;margin-bottom:.0001pt;text-align:
justify;line-height:normal">
                &nbsp;</p>
            <p class="MsoNormal" style="margin-bottom:0in;margin-bottom:.0001pt;text-align:
justify;line-height:normal">
                &nbsp;</p>
            <p class="MsoNormal" style="margin-bottom:0in;margin-bottom:.0001pt;text-align:justify;line-height:normal">&nbsp;</p>


        </div>
<center>
   <br />
 
        </center>
    
</div>
         <div id="Div1" align="right">   <br />
             Mr. Benard Usman
             <br />
             CPI Inspector<br />
    <br />   </div>
  
    </div>
   
 
</asp:Content>

