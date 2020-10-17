<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="WMDPortal._default36" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Weight & Measures : Invoice - Printable</title>
    <meta name="author" content="Application Developed by: John Ojebode"/>
    <link href="../../css/invoice.css" rel="stylesheet" type="text/css" />
    <link href="../../css/menu.css" rel="stylesheet" type="text/css" />
    <link href="../../images/icon.png" rel="icon" type="images/jpg" />
    <script src ="../../js/jQuery.js" type ="text/javascript" ></script>
    <script src ="../../js/tabScript.js" type ="text/javascript" ></script>
    
    <link rel="stylesheet" href="../js/jQuery-ui.css" />
    <script src="../../js/jQuery1.10.js"></script>
    <script src="../../js/jQuery-ui.js"></script>
    <script type="text/javascript"  lang="javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <!-- Printable Invoice -->
                <asp:Panel runat ="server" ID="InvoiceDetails" class="invoice-payment" style="margin:10px auto;width:620px;box-shadow:rgba(0,0,0,4) 2px 2px 3px 3px;">
                    <div style='width:600px;height:70px;padding:10px;color:rgb(255, 255, 255);font-weight:bolder;text-align:center;font-size:20px;background-color:rgb(54,127,169);'>
	                    <img src='../../images/icon.png' width='70' height='70' style='margin-top:-10px;padding:0px;float:left' />
	                    <p style="margin-top:-1px" />Federal Ministry of Industry, Trade and Investment
                        <span style='font-size:17px;margin-top:-15px;'>Weights and Measures Department</span>
                    </div>
                    
                    <div style='width:620px;font-size:15px;background:rgb(255,255, 255);'>
                        <div style='padding-left:10px; width:590px;'>
			            <h4 style='padding:2px;font-size:23px;width:100%;text-align:center;margin-top:-10px;'>INVOICE</h4> 
			            <h4 style='padding:0px;font-size:17px;'>Invoice #<asp:Label runat="server" ID="InvoiceID"></asp:Label><span style='float:right;font-size:13px;'><asp:Label runat="server" ID="InvoiceDate"></asp:Label></span></h4>
			            
                        <div style='margin-bottom:0px;display:block;height:169px; width:100%;'>
				            <div style='width:45%;float:left;'>
					            <div style='font-weight:bolder;font-size:17px;padding:5px 0px;'>CLIENT DETAIL</div>
					            <p style='font-weight:bolder;font-size:15px;'><asp:Label runat="server" ID="InvoiceCompanyName"></asp:Label>( <asp:Label runat="server" ID="InvoiceUsername"></asp:Label>  ) </p>
					            <p style='font-weight:bolder;font-size:15px;'><asp:Label runat="server" ID="InvoiceCompanyAddress"></asp:Label></p>
				            </div>
					
				            <div style='width:45%;float:right;'>
					            <div style='font-weight:bolder;font-size:17px;padding:5px 0px;'>ACCOUNT DETAIL</div>
					            <p style='font-weight:bolder;font-size:13px;'>ACCOUNT NAME: <span style='font-weight:normal;'>FEDERAL MINISTRY OF INDUSTRY, TRADE AND INVESTMENT WEIGHTS AND MEASURES DEPARTMENT</span></p>
					            <p style='font-weight:bolder;font-size:13px;'>ACCOUNT NUMBER: <span style='font-weight:normal;'>1750013688</span></p>
					            <p style='font-weight:bolder;font-size:13px;'>BANK NAME: <span style='font-weight:normal;'>SKYE BANK</span></p>
					        </div>
			            </div>
			
			            <div style='font-weight:bolder;font-size:17px;padding:5px 0px;'>INVOICE ITEM(S)</div>
			                <div style='width:69%;display:inline-block;font-weight:bolder;padding:10px 0px;border-bottom:1px solid rgb(200,200,200);color:rgb(100,100,100);'>Summary</div>
			                <div style='width:30%;display:inline-block;text-align:right;font-weight:bolder;padding:10px 0px;border-bottom:1px solid rgb(200,200,200);color:rgb(100,100,100);'>Amount</div>
			                
                            <!--Repeater ...................................................
                                ............................................................ -->
                            <asp:Repeater ID="DisplayInvoice" runat="server">
                                <ItemTemplate>
                                    <div style='width:69%;display:inline-block;padding:5px 0px;font-size:12px;'><%# String.Format("{0}", Eval("narration"))%> </div>
			                        <div style='width:30%;display:inline-block;text-align:right;padding:5px 0px;font-size:12px;'><%# DataBinder.Eval(Container.DataItem, "amountDue", "{0:#,#0.00}")%></div>
			                    </ItemTemplate>
                            </asp:Repeater>
                                   <div style='width:100%;display:inline-block;padding:20px 0px 20px 29px;margin-left:-10px; padding-right:1px;text-align:right;font-weight:bolder;background:rgb(250,250,250);font-size:17px;'>
				                Total: <span style='float:right;margin-left:50px;margin-right:20px;'><span style="text-decoration :line-through">N</span><asp:Label runat ="server" ID="InvoiceTotalAmount" ></asp:Label></span>
			                </div>
		                </div>
		                <p/>
		                <div style='margin-top:0px;width:600px;height:auto;padding:2px 10px;height:1px;color:rgb(20,20,20);text-align:left;font-size:13px;background:rgb(255,255,255);'>
			            </div>
		
                </div>
                
                <div style="width:600px;height:auto;padding:5px 10px;color:rgb(255, 255, 255);text-align:left;font-size:13px;background:rgb(54,127,169);">
			        <strong>PLEASE NOTE: </strong>  ALL BANK DEPOSIT MUST BE MADE WITH THE USERNAME AS THE DEPOSITOR.<p>ALL PAYMENT(S) MADE ARE NON-REFUNDABLE.
			     </div>
           
                <div class="modal-footer">
                    <a href="../" class="mbtn-close">Close Invoice</a>  
                    <a href="#" onclick ="return printdiv('InvoiceDetails');" class="mbtn-printer" style="padding:8px 35px;color:rgb(255,255,255);margin-top:-3px;">Print Invoice</a>
                </div>
            </asp:Panel>
    <!-- /Printable Invoice -->

                
    </form>
</body>
</html>
