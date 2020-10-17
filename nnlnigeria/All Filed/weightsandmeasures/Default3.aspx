<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default3.aspx.vb" Inherits="Default3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Sample Merchant Page</title>
</head>
<body>
<form id="form1”>
<div>
<p>
Amount:<input id="txtAmt" type="text" value ="4500" ></input>
</p>
</div>
</form>
<%--<script type="text/javascript"
src="https://skyecipg.skyebankng.com:5443/MerchantServices/UPaybutton.ashx?mercId=00037
&CurrencyCode=566">
</script>
<script type="text/javascript">
    upay_settings.setAmountField('45000');
    upay_settings.setOrderId('31-Aug-2019');
    upay_settings.setProduct('Donation');
    upay_settings.setEmail('cyprosoft@yahoo.com');
</script>--%>
</body>