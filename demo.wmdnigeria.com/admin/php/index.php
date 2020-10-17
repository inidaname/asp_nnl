<?php
error_reporting(0);
session_start(0); 
if(isset($_GET['Session']) && $_GET['Session']=="ActiveFromAdmin"){ 
//echo '<script>alert("This is right!")</script>'; 
}
else {
echo '<strong><p style="text-align:center">You made an attempt to view a restricted page</strong> <br> <br> Be careful, access to this page is restricted, contact administrator for more info! <br> <br> This activity has been logged!</p>';
echo '<script>alert("Be careful, access to this page is restricted, contact administrator for more info!  This activity has been logged!")</script>'; 
exit;
} 

include_once 'includes/db.php';
	
?>
<!DOCTYPE html >
<html>
<head>

<meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
<link href="css/style.css" rel="stylesheet" type="text/css" />

<title>SabiSabi Admin</title>


</head>

<body>

<div class="content"> 

<div class="container" style="font-size:7px;">
	
	
	<div class="wrapper">
	<div class="section-title" style="margin-top:10px;font-size:20px;font-weight:bolder;"> Upload Backlog Data to the Database </div>
	
	<p style="padding-top:30px;padding-bottom:0px;"><span style="font-size:17px;">This page is designed for the purpose of uploading backlog for static data like: States, Measurement, Instruments, Fee Categories, Fee Sub Category, Fee Section and Instrument Fee in <strong>csv</strong> format.<br> 
		</span>
		
		<p style="padding-top:30px;padding-bottom:30px;"><span style="font-size:14px;color:rgb(150,0,0);font-weight:bolder;">WARNING: Be careful what you do on this page, you could screw things up!<br>
		</span>
		
		<form name="batchProfileUpload" method="post" action=""  enctype="multipart/form-data" multiple='multiple' >
		<p><label style="font-size:14px; margin-top:10px; font-weight:bolder;">Select CSV File to Upload: </label></p>
		<input type="file" name="batchProfile" placeholder="Category ID" />
		
		<p><label style="font-size:14px; margin-top:10px; font-weight:bolder;">Select Table to Upload to: </label></p>
		<select name="uploadGroup"  class="select">
			<option value ="Sector">Upload Sector</option>
			<option value ="State">Upload States</option>
			<option value ="LGA">Upload Local Government</option>
			<option value ="Cities">Upload Cities</option>
			<option value="Measurement">Upload Measurement</option>
			<option value="Instrument Measurement">Upload Instrument Measurement</option>
			<option value="Instrument Category">Upload Instrument Category</option>
			<option value="Instrument Sub Category">Upload Instrument Sub Category</option>
			<option value="Fee Category">Upload Fee Categories</option>
			<option value="Fee Sub Category">Upload Fee Sub Category</option>
			<option value="Fee Section">Upload Fee Section</option>
			<option value="Instrument Fee">Upload Instrument Fee</option>
		</select>
		<p></p><br>
		<input type="submit" name="resetForm" class="button" style="margin-left:0px;" value="Cancel Upload" />
		<input type="submit" name="uploadBatch" class="button" style="margin-left:0px;" value="Upload & Extract File" /><br>
		
		</form >
	</div>

	<?php
	
	//Upload File

	if (isset($_POST['uploadBatch'])) {
	
    if (is_uploaded_file($_FILES['batchProfile']['tmp_name'])) {
    echo "<h1>" . "File ". $_FILES['batchProfile']['name'] ." uploaded successfully." . "</h1>";
	echo "<h2>Displaying contents:</h2>";

    //readfile($_FILES['batchProfile']['tmp_name']);
    }

	    //Import uploaded file to Database

	    $handle = fopen($_FILES['batchProfile']['tmp_name'], "r");

	    while (($data = fgetcsv($handle, 1000, ",")) !== FALSE) {
		
		if(isset($_POST['uploadGroup']) && $_POST['uploadGroup']=="Sector"){
			$import="INSERT INTO sector(sector) values('$data[0]')";
	      
	        mysql_query($import) or die(mysql_error());
		}
		elseif(isset($_POST['uploadGroup']) && $_POST['uploadGroup']=="State"){
			$import="INSERT INTO state(state) values('$data[0]')";
	      
	        mysql_query($import) or die(mysql_error());
			
		}
		elseif(isset($_POST['uploadGroup']) && $_POST['uploadGroup']=="LGA") {
		
		$import="INSERT INTO lga(state,lga) values('$data[0]','$data[1]')";
	      
	        mysql_query($import) or die(mysql_error());
			
	    }
		elseif(isset($_POST['uploadGroup']) && $_POST['uploadGroup']=="Cities") {
		
		$import="INSERT INTO city(city,lga) values('$data[0]','$data[1]')";
	      
	        mysql_query($import) or die(mysql_error());
			
	    }
		elseif(isset($_POST['uploadGroup']) && $_POST['uploadGroup']=="Measurement") {
		
		$import="INSERT INTO measurement(measureValue,measureName) values('$data[0]','$data[1]')";
	      
	        mysql_query($import) or die(mysql_error());
	    }
		elseif(isset($_POST['uploadGroup']) && $_POST['uploadGroup']=="Instrument Measurement") {
		
		$import="INSERT INTO devicemeasurement(measureName,measureValue,deviceType) values('$data[0]','$data[1]','$data[2]')";
	      
	        mysql_query($import) or die(mysql_error());
	       
		}
		elseif(isset($_POST['uploadGroup']) && $_POST['uploadGroup']=="Instrument Category") {
		
		$import="INSERT INTO devicecategories(deviceCategory,sector) values('$data[0]','$data[1]')";
	      
	        mysql_query($import) or die(mysql_error());
	       
		}
		elseif(isset($_POST['uploadGroup']) && $_POST['uploadGroup']=="Instrument Sub Category") {
		
		$import="INSERT INTO devicesub(deviceType,deviceCategory) values('$data[0]','$data[1]')";
	      
	        mysql_query($import) or die(mysql_error());
	       
		}
		elseif(isset($_POST['uploadGroup']) && $_POST['uploadGroup']=="Fee Category") {
		
		$import="INSERT INTO feegroup(feeGroup) values('$data[0]')";
	      
	        mysql_query($import) or die(mysql_error());
	       
		}
		elseif(isset($_POST['uploadGroup']) && $_POST['uploadGroup']=="Fee Sub Category") {
		
		$import="INSERT INTO feesubgroup(groupSub,feeGroup) values('$data[0]','$data[1]')";
	      
	        mysql_query($import) or die(mysql_error());
	       
		}
		elseif(isset($_POST['uploadGroup']) && $_POST['uploadGroup']=="Fee Section") {
		
		$import="INSERT INTO feetable(measureRange,amount,feeGroup,feeSubGroup) values('$data[0]','$data[1]','$data[2]','$data[3]')";
	      
	        mysql_query($import) or die(mysql_error());
	    	       
		}
		elseif(isset($_POST['uploadGroup']) && $_POST['uploadGroup']=="Instrument Fee") {
		
		$import="INSERT INTO deviceprice(deviceType,measureRange,instrumentAmount,AmountFirst,amountAboveMax,above,notExceeding,isMax,occurenceValue,partThereOf) values('$data[0]','$data[1]','$data[2]','$data[3]','$data[4]','$data[5]','$data[6]','$data[7]','$data[8]','$data[9]')";
	      
	        mysql_query($import) or die(mysql_error());
	       
		   
		
		//End of while
	    }
		}

	    fclose($handle);

	    print '<script>alert("'.$_POST['uploadGroup'].' Backlog file or data uploaded successful!")</script>';
		
	
	}
	
	?>

	
	
	
	
</div>
</div>
	
	
</body>
</html> 