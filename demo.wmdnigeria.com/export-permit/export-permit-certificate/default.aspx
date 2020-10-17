<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="WMDPortal._default37" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Weight & Measures : Export Permit Certificate - Printable</title>
    <meta name="author" content="Application Developed by: John Ojebode"/>
    <link href="../../css/export.css" rel="stylesheet" type="text/css" />
    <link href="../../images/icon.png" rel="icon" type="images/jpg" />
    <script src ="../../js/jQuery.js" type ="text/javascript" ></script>
    <script src ="../../js/tabScript.js" type ="text/javascript" ></script>
    
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel runat ="server" ID="ExportApplicationDetails" class="export-application-details" style="margin:10px auto;width:500px;position:relative;border: 5px solid rgb(54,127,169);">
        <div style="margin:0 auto;margin-top:5px;width:80px;height:80px;"><img src="../../images/coatofarm.png" /></div>

        <span style="position:absolute;right:15px;top:30px;font-size:12px;">Ref. No: <asp:Label runat="server" ID="ExportReference" Text="12345688"/></span>

        <asp:Panel runat ="server" ID="ExportPermitHeading" class="export-application-details-title" >
        FEDERAL REPUBLIC OF NIGERIA  <br />FEDERAL MINISTRY OF INDUSTRY, TRADE & INVESTMENT<br />DEPARTMENT OF COMMODITIES AND PRODUCTS INSPECTORATES <br />
            <span style="font-size:14px;font-weight:normal">Old Secretariat Complex, Area 1, Garki Abuja, Nigeria</span>

        </asp:Panel>

        <asp:Panel ID="ExportTitle" runat ="server" class="export-application-details-body-title">EXPORT PERMIT APPLICATION DETAILS</asp:Panel>

        <asp:Panel runat ="server" ID="Body" class="export-application-details-body" >
            <asp:TextBox runat ="server" ID="text1" Enabled="false" CssClass="label"  Text="Name of Applicant:"></asp:TextBox>
           <asp:TextBox runat ="server" ID="AppName" Enabled="false" CssClass="label-info"></asp:TextBox><p/>
   
           <asp:TextBox runat ="server" ID="text2" Enabled="false" CssClass="label"  Text="Applicant's Address:"></asp:TextBox>
           <asp:TextBox runat ="server" ID="AppAddress" Enabled="false" CssClass="label-info"></asp:TextBox><br />
   
           <asp:TextBox runat ="server" ID="text3" Enabled="false" CssClass="label"  Text="Apllicant City:"></asp:TextBox>
           <asp:TextBox runat ="server" ID="AppCity" Enabled="false" CssClass="label-info"></asp:TextBox><br />
   
           <asp:TextBox runat ="server" ID="text4" Enabled="false" CssClass="label"  Text="Permit Quarter:"></asp:TextBox>
           <asp:TextBox runat ="server" ID="AppPermitQuarter" Enabled="false" CssClass="label-info" ></asp:TextBox><br />
   
           <asp:TextBox runat ="server" ID="text5" Enabled="false" CssClass="label"  Text="Product Description:"></asp:TextBox>
           <asp:TextBox runat ="server" ID="AppProductName" Enabled="false" CssClass="label-info"></asp:TextBox><br />
   
           <asp:TextBox runat ="server" ID="text6" Enabled="false" CssClass="label"  Text="Export Quantity:"></asp:TextBox>
           <asp:TextBox runat ="server" ID="AppExportQuantity" Enabled="false" CssClass="label-info"></asp:TextBox><br />
   
           <asp:TextBox runat ="server" ID="text7" Enabled="false" CssClass="label"  Text="F.O.B. Value (USD):"></asp:TextBox>
           <asp:TextBox runat ="server" ID="AppFOBValue" Enabled="false" CssClass="label-info"></asp:TextBox><br />
   
           <asp:TextBox runat ="server" ID="text8" Enabled="false" CssClass="label"  Text="Period of Export:"></asp:TextBox>
           <asp:TextBox runat ="server" ID="AppPeriodOfExport" Enabled="false" CssClass="label-info"></asp:TextBox><br />

           <asp:TextBox runat ="server" ID="text9" Enabled="false" CssClass="label"  Text="Proposed Export Date:"></asp:TextBox>
           <asp:TextBox runat ="server" ID="AppProposedDateOfExpor" Enabled="false" CssClass="label-info"></asp:TextBox><br />

           <asp:TextBox runat ="server" ID="text10" Enabled="false" CssClass="label"  Text="Period Covered:"></asp:TextBox>
           <asp:TextBox runat ="server" ID="AppPeriodCovere" Enabled="false" CssClass="label-info"></asp:TextBox><br />

           <asp:TextBox runat ="server" ID="text11" CssClass="label" Enabled="false"  Text="Name of Exporter:"></asp:TextBox>
           <asp:TextBox runat ="server" ID="AppNameOfExporte" Enabled="false" CssClass="label-info"></asp:TextBox>

            <asp:Panel runat ="server" ID="Panel1" class="export-application-authorization" >
                
                <asp:Label runat ="server" ID="ApprovalDate" Enabled="false" style="width:100px;height:15px;padding-top:15px;margin-top:5px;float:left;margin-left:30px;color:rgb(0,0,0);text-transform:uppercase;font-weight:bolder;text-align:center;">23/11/2015</asp:Label>                
                <asp:Label runat ="server" ID="ApprovedBy" Enabled="false" style="width:250px;height:15px;padding-top:15px;margin-top:5px;float:left;margin-left:10px;color:rgb(0,0,0);text-transform:uppercase;font-weight:bolder;text-align:center;">John Ojebode Segun</asp:Label>
                <asp:Repeater ID="ApprovalSignature" runat="server">
                    <ItemTemplate>
                        <asp:Label  runat ="server" ID="ApprovalSignature" Enabled="false" style='width:80px;height:15px;padding-top:15px;margin-top:5px;float:right;margin-right:20px;color:transparent ;text-transform:uppercase;font-weight:bolder;text-decoration-line:line-through;background:url(../../images/nnl.png) no-repeat 0% 0%;background-size:100px 30px;'>Signature</asp:Label>
			        </ItemTemplate>
                </asp:Repeater><br />


                <asp:Label runat ="server" ID="Label1" Enabled="false" style="width:100px;float:left;margin-left:30px;color:rgb(0,0,0);text-transform:capitalize ;font-weight:bolder;text-decoration-line:overline;text-align:center;">Date Approved:</asp:Label>
                <asp:Label runat ="server" ID="Label2" Enabled="false" style="width:250px;float:left;margin-left:10px;color:rgb(0,0,0);text-transform:capitalize ;font-weight:bolder;text-decoration-line:overline;text-align:center;">Application Approved By:</asp:Label>
                <asp:Label runat ="server" ID="Signature" Enabled="false" style="width:80px;float:right;margin-right:15px;color:rgb(0,0,0);text-transform:capitalize ;font-weight:bolder;text-decoration-line:overline ;text-align:center;">Signature:</asp:Label>
           </asp:Panel>
          <asp:Panel runat ="server" ID="Declaration" class="export-application-details-declaration" >
            We acknowledge that the making of any false statement or concealment of any material fact connection with this application may result in imprisonment or fine, or both and denial, in whole or in part of participation in Nigeria Oil & Gas Exports.
          </asp:Panel>
          
        </asp:Panel>    
        
    </asp:Panel>
    <div class="modal-footer">                             
        <a href="../" class="mbtn-close">Close Certificate</a>  
        <a class="mbtn-printer" onclick ="return printdiv('ExportApplicationDetails');" >Print Permit Application</a> 
    </div>
    
    
    </form>
</body>
</html>
