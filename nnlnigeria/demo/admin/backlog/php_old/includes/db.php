<?php

define('DB_SERVER', 'localhost');
define('DB_USERNAME', 'root');
define('DB_PASSWORD', '');
define('DB_DATABASE', 'wmddb');
$connection = mysql_connect(DB_SERVER, DB_USERNAME, DB_PASSWORD) or die(mysql_error());
//&mysql_select_db($dbDatabase, $connection)or die("Couldn't select the database."); 
mysql_select_db(DB_DATABASE) or die(mysql_error());
?>
