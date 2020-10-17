<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default4.aspx.vb" Inherits="Default4" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Sample Merchant Page</title>
</head>
<body>
    
    <form id="form1" runat="server">
    <div>
    <asp:HyperLink ID="HyperLink2"  Text="How To Make Payment?" runat="server"></asp:HyperLink>
    </div>
    <div>
     <p>
        <%--Amount:<input id="txtAmt" type="text" ></input></p>--%>
      
    </div>
    </form>
    
    <form method="post" id="upay_form" name="upay_form" action="https://skyecipg.skyebankng.com:5443/MerchantServices/MakePayment.aspx"  target="_top">'
    <input type="hidden" name="sessionId" value="000" />
    <table>
    <tr><td>MerchantID:</td><td><input name="mercId" value="08641" /></td></tr>
    <tr><td>Currency</td><td><%--<input type="hidden" name="currCode" value="560" />--%></td></tr>
    <tr><td>Amt:</td><td><input name="amt" value="700" /></td></tr>
    <tr><td>OrderID:</td><td><input name="orderId" value='<%= DateTime.Now.ToString("HHmmss") %>' /></td></tr>
    <tr><td>Product:</td><td><input name="prod" value="Donation" /></td></tr>
    <tr><td>Email:</td><td><input name="email" value="cokoro@appzonegroup.com" /></td></tr>
    <tr><td>MerchantProductName:</td><td><input name="mercProductAmts" value="004=300.00,005=400.00" /></td></tr>
    <tr><td></td><td><input type="submit" name="btnPay" value="Submit" /></td></tr>    
    </table>
    </form>;
    
     
            <%--upay_settings.setAmountField('txtAmt');
            upay_settings.setOrderId('<%= DateTime.Now.ToString("HHmmss") %>');
            upay_settings.setProduct("Donation");
            upay_settings.setEmail("cokoro@appzonegroup.com");--%>

     <br />
    <%--<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="https://skyecipg.skyebankng.com:5443/MerchantCustomerView/MerchantCustomerReport.aspx?email=cokoro@appzonegroup.com&mercID=08641">Click to view customer's transactions</asp:HyperLink>
    --%>
</body>
</html>
