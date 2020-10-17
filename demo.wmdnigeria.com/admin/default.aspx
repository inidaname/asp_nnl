<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="WMDPortal._default3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" class="bg-black">
<head id="Head1" runat="server">
<title>Weight & Measure Admin | Log in</title>
<meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
<link href="css/style.css" rel="stylesheet" type="text/css" />
<link href="../../images/icon.png" rel="icon" type="images/jpg" />
    
</head>
    <body class="bg">
	
        <div class="login">

            <div class="logo-top"></div>

            <div class="headers">Weights & Measures Admin</div>
            
          
            <form  method="post" runat="server">
                <div class="body">
                    <div class="form-group">
                         
                        <div style="float:left;" class=""><asp:RadioButton ID="DashboardAdmin" GroupName="LoginType" runat="server" Checked="true"  /><span  class="checkbox-o" aria-checked="true" >Login to dashboard</span></div> 
                        <div style="float:left;display:none" class="clas"><asp:RadioButton ID="DatabaseSetup" GroupName="LoginType" runat="server" /><span  class="checkbox-o" />Setup database</span></div>
                    </div>

                    <div class="form-group">
                        <asp:TextBox ID="AdminUsername" runat="server" class="form-control" placeholder="User ID"></asp:TextBox>
                    </div>
                    
                    <div class="form-group">
                       <asp:TextBox ID="AdminPassword" runat="server" TextMode ="Password"  class="form-control" placeholder="Password" input-mask="*"></asp:TextBox>
                       
                    </div>



                    <div class="form-group">
                  
                         <asp:CheckBox ID="RememberMe" runat="server" /> <span  class="checkbox">Keep me logged in </span>
                    </div>
                </div>
                <div class="footers">
                    
                    <asp:Button ID="AdminSigninButton" class="btn" runat="server" Text="Sign me in" />
                    <p><a href="#">Request for password reset!</a></p>
                </div>
            </form>

            
        </div>

        <div style="margin:0 auto; padding:20px;color:rgb(255,255,255);font-size:10px;width:350px;text-align:center;"><strong>WMD Portal V 1.2</strong> <p/>Developed by <strong>John Ojebode</strong> for Nigerco Nigeria Ltd. Consultant to Weights & Measures Department of Federal Ministry of Industry, Trade and Investment</div>

    </body>
</html>
