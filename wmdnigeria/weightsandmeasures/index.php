<?php
$page = $_GET['page'];
if (!$page) $page = "home";

$body="pages/".$page."/body.php";
?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>NNL NIGERIA</title>
<link rel="stylesheet" href="css/style.css" type="text/css" />
<!--menu-->

<!--slideshow-->
<!--tool tip-->

<!---->
</head>

<body>
<div align="center">
    <div id="content">
    	<div class="top">
        	<div id="top_holder">
            	<div id="top_left">
                	<form>
                    <div id="login">
                    	<input name='' class="theinput3" id="txtUserName" title="UserName"  type="text" />
                    </div>
                    <div id="login">
                    	<input name='' class="theinput3" type="password" id="txtPassword" title="Password" />
                    </div>
                    <div id="login2">
                    	<input name='' class="theinput4" type="submit" value="Login" />
                    </div>
                    <div id="login3">
                    	<a href="#">Forgot Password?</a> &nbsp; &nbsp; &nbsp; &nbsp;
                    	<a href="index.php?page=register">Registration</a>
                    </div>
                	</form>
                	<?php include("template/login/login.php"); ?>
                </div>
            	<div id="top_right">
                	<form>
                    <div id="search">
                    	<input name='' id="theinput" type="text" />
                    </div>
                	<div id="search_button">
                        <button type='submit' name='Submit' style='background:none; border:none; cursor:pointer' >	
                            <img src='images/view.png' />
                        </button>
                    </div>
                    </form>
                </div>
            </div>
        </div>
        <div id="header_holder">
            <div id="header">
                <?php include("template/header/header.php"); ?>
            </div>
        </div>
        
		<div id="main_page">
        
            <div id="submenubar">
                <div id="bread">You are Here > <a href="?page=<?php echo $_GET['page']; ?>"><?php echo $_GET['page']; ?></a></div>
                <div id="request"><a href="#">Registration</a></div>
            </div>
            <div id="page">
    
                    <?php 
                        include($body);
                    ?>
                <?php if($page != "register"){ ?>
   				<div id="cards"><img src="images/partners.png" /></div>
                <?php } ?>
            </div>
		</div>        
    </div>       
   <div id="footer">
		<div id="footer_content_left">Copyright &copy; 2012. All rights reserved.</div>
		<div id="footer_content_right">
        <a href="#" target="_blank"><strong>Powered by#</strong></a>
        
                    <div id="social">
                        <div id="social_content_f"><a href="#" alt="Follow us on Facebook" title="Follow us on Facebook">&nbsp;</a></div>
                        <div id="social_content_t"><a href="#" alt="Twitter" title="Twitter">&nbsp;</a></div>
                        <div id="social_content_y"><a href="#" alt="Youtube" title="Youtube">&nbsp;</a></div>
                        <div id="social_content_r"><a href="#" alt="RSS" title="RSS">&nbsp;</a></div>
                        <div id="social_content_g"><a href="#" alt="GROUP" title="GROUP">&nbsp;</a></div>
                    </div>
        </div>
   </div>
</div>
</body>
</html>                