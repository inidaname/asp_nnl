<%@ Page Title="Export Application Details" Language="VB" MasterPageFile="~/exportpage.master" AutoEventWireup="false" CodeFile="exportappdetails.aspx.vb" Inherits="exportappdetails" %>
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

 
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>

<div align="center">
	<div id="page2">
    	<div id="row17"><img src="invoice/images/logo2.jpg" /></div>
       	<div id="row18"><strong>FEDERAL REPUBLIC OF NIGERIA<br />
FEDERAL MINISTRY OF INDUSTRY, TRADE & INVESTMENT<br /></strong>
DEPARTMENT OF COMMODITIES AND PRODUCTS INSPECTORATES<br />
Old Secretariat Complex, Area 1, Garki Abuja, Nigeria<br />
        </div>
        <div id="row19">EXPORT PERMIT APPLICATION DETAILS</div>
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
        	<div id="col36">&nbsp;</div>
            <%--<div id="col37">DPR REF. NO:</div><div id="col38"><% Response.Write(Request.QueryString("txtamtPerBarrel0"))%></div>--%>
        	<div id="col37">Name of Applicant:</div><div id="col38"><% Response.Write(Request.QueryString("txtcompanyname"))%></div>
        	<div id="col37">Address in Nigeria:</div><div id="col38"><% Response.Write(streetAddress)%></div>
        	<div id="col37">City:</div><div id="col38"><% Response.Write(City)%></div>
        	<div id="col37">Permit Quarter:</div><div id="col38"><% Response.Write(Request.QueryString("txtexportPermitName"))%></div>
        	<div id="col37">Product Description:</div><div id="col38"><% Response.Write(Request.QueryString("txtProducName"))%></div>
        	<div id="col37">Export Quantity (bbl):</div><div id="col38"><% Response.Write(Request.QueryString("txtQuatity"))%></div>
        	<div id="col37">F.O.B Value (USD):</div><div id="col38"><% Response.Write(Request.QueryString("txtAmtUS"))%></div>
        	<div id="col37">Port of Export:</div><div id="col38"><% Response.Write(Request.QueryString("txtusername17"))%></div>
        	<div id="col37">Period Covered:</div><div id="col38"><% Response.Write(Request.QueryString("cboPCF") & "-" & Request.QueryString("cboPCT"))%></div>
        	<div id="col37">Proposed date of Export:</div><div id="col38"><% Response.Write(Request.QueryString("txtDPTTo"))%></div>
        	<div id="col37">Name of Exporter:</div><div id="col38"><% Response.Write(Request.QueryString("txtAsnwer"))%></div>
        </div>
        <div id="row21">We acknoledge that the making of any false statement or concealment of any
material fact connection with this pplication may result in imprisonment or
fine, or both and denial, in whole or in part, of participation in Nigeria Oil & Gas Exports.</div>
<center>
   <br />
 
<asp:Button ID="btnReset" runat="server" Height="25px" Text="BACK" 
                                        onclientclick="JavaScript:window.history.back(1);return false;" />
                                             <asp:Button ID="btnPreview" runat="server" Height="25px" style="height: 26px" 
                                        Text="FINISH" />
                                    <cc1:ConfirmButtonExtender ID="btnPreview_ConfirmButtonExtender" runat="server" 
                                        ConfirmOnFormSubmit="True" 
                                        ConfirmText="Are you SURE you want to SAVE this export permit?" Enabled="True" 
                                        TargetControlID="btnPreview">
                                    </cc1:ConfirmButtonExtender>
    <br />
    <br />
    <br />
        </center>
    
</div>
         <div id="Div1">   <br />
    <br />
    <br /> </div>
    </div>
    
 
</asp:Content>

