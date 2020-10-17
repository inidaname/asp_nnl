<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="WMDPortal._default4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" class="bg-black">
<head id="Head1" runat="server">
<title>Weight & Measure Admin | Database Connection</title>
<meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
<link href="../css/style.css" rel="stylesheet" type="text/css" />
<link href="../../../images/logo.png" rel="icon" type="images/jpg" />
    
</head>
    <body class="bg">
	
        <div class="databasesetup">

            <div class="logo-top"></div>

            <div class="headerss">Connect to Database Server</div>
            
          
            <form id="Form1"  method="post" runat="server">
                <div class="body">
                    <div class="form-group">
                        <asp:TextBox ID="DatabaseServer" runat="server" class="form-control" placeholder="Database Server"></asp:TextBox>
                    </div>
                    
                    <div class="form-group">
                       <asp:TextBox ID="DatabasePort" runat="server" class="form-control" placeholder="Database Server Port"></asp:TextBox>
                    </div>
                    
                    <div class="form-group">
                       <asp:TextBox ID="DatabaseUsername" runat="server" class="form-control" placeholder="Database Username"></asp:TextBox>
                    </div>
                    
                    <div class="form-group">
                       <asp:TextBox ID="DatabasePassword" runat="server" class="form-control" TextMode="Password" placeholder="Database Password"></asp:TextBox>
                    </div>

                    <div class="form-group">
                       <asp:TextBox ID="DatabaseName" runat="server" class="form-control" placeholder="Database Name"></asp:TextBox>
                    </div>

                    <div class="form-group"  style="padding-top:10px;">
                            <asp:CheckBox ID="AgreetoConnect" runat="server"  class="checkbox"/> <span  class="checkbox">I Agree! Connect me to this server now!</span>
                    </div>


                  
                </div> 

          
                <div class="footerss">
                    
                    <asp:Button ID="ConnectDatabase" class="button" runat="server" Text="Connect to Database" />
                    <a href="../"><div class="button" style="padding:8px">Control Panel</div></a>

                </div>
           
            </form>
            
        </div>

 
    </body>
</html>
