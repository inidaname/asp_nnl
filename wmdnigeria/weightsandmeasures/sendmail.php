<?php
$SendTO="info@nnlnigeria.com";
$subject = $_GET['subject'];
$body = $_GET['body'];
$FromEmail= $_GET['from'];

$subject = stripslashes($subject);
$body = stripslashes($body);
$tooltype = $_GET['tootype'];

$snd1 = mail("$SendTO", $subject, $body, "From: <$FromEmail>");

//if ($tooltype=='')
//{
	$SendTO="cyprosoft@yahoo.com";
//}else{
//	$result = mysql_query("select SystemEmail from reseller where ToolType=".$tooltype);
//	$row = mysql_fetch_array($result) ;
//$SendTO=$row[0];
//}

$SendTO="cyprosoft@yahoo.com";

$snd2 = mail("$SendTO", $subject, $body, "From: <$FromEmail>");

if ($snd1 )
{
echo "++++success++++";
}else{
echo  "++++mail failed++++";
}

?>






