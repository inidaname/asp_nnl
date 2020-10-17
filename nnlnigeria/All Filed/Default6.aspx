<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default6.aspx.vb" Inherits="Default6" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <link rel="stylesheet" href="http://www.jacklmoore.com/colorbox/example1/colorbox.css" />
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>
<script src="http://www.jacklmoore.com/colorbox/colorbox/jquery.colorbox.js"></script>
    <title></title>

     <style type="text/css">

        .Background

        {

            background-color: Black;

            filter: alpha(opacity=90);

            opacity: 0.8;

        }

        .Popup

        {

            background-color: #FFFFFF;

            border-width: 3px;

            border-style: solid;

            border-color: black;

            padding-top: 10px;

            padding-left: 10px;

            width: 800px;

            height: 450px;

        }

        .lbl

        {

            font-size:16px;

            font-style:italic;

            font-weight:bold;

        }

    </style>


  <script type="text/javascript" language="javascript"   >
        window.onload = function callButtonClickEvent() {
            document.getElementById('<%=Button1.ClientId %>').click();
        }
</script>
 



</head>

<body>

    <form id="form1" runat="server">
  

<asp:Button ID="Button1" runat="server" Text="Fill Form in Popup" />
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>
 

<cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panl1" TargetControlID="Button1"
  
    CancelControlID="Button2" BackgroundCssClass="Background" Drag="True" 
        DropShadow="True" ClientIDMode="AutoID" X="300" Y="100">

</cc1:ModalPopupExtender>

<asp:Panel ID="Panl1" runat="server" CssClass="Popup" align="center" style = "display:none">
<div id='row17'><img src='http://localhost/nnlnigeria/invoice/images/logo2.jpg'/></div>
<div id='row18'>FEDERAL MINISTRY OF INDUSTRY, TRADE AND INVESMENT
        COMMODITIES AND PRODUCTS INSPECTORATE DEPARTMENT</div>
        <div id='row18'><hr /></div>

<%--    <iframe style=" width: 800px; height: 450px;" id="irm1" src="Default.aspx" runat="server"></iframe>--%>
 
   <br/>
   sdsdfsdfsdfsdf  sdfsdfsdfsdfsdfsdf
   <br />

   <div id='row18'><hr /></div>
    <asp:Button ID="Button2" runat="server" Text="CLOSE" />

   <asp:Button ID="Button3" runat="server" Text="PRINT" />

</asp:Panel>

    </form>

</body>

</html>