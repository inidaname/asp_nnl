/*
SQLyog - Free MySQL GUI v5.15
Host - 5.1.6-alpha-nt-max : Database - nnlnigeriaweb
*********************************************************************
Server version : 5.1.6-alpha-nt-max
*/

SET NAMES utf8;

SET SQL_MODE='';

create database if not exists `nnlnigeriaweb`;

USE `nnlnigeriaweb`;

SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO';

/*Table structure for table `companyregistration` */

DROP TABLE IF EXISTS `companyregistration`;

CREATE TABLE `companyregistration` (
  `sysID` int(11) NOT NULL auto_increment,
  `username` varchar(100) default ' ',
  `pwd` varchar(100) default ' ',
  `companyName` varchar(400) default ' ',
  `streetAddress` varchar(400) default ' ',
  `cityID` int(11) default '0',
  `LGAID` int(11) default '0',
  `StateID` int(11) default '0',
  `POBOX` varchar(200) default ' ',
  `companyEmail` varchar(200) default ' ',
  `companywebsite` varchar(200) default ' ',
  `representativeName` varchar(200) default ' ',
  `telephone` varchar(150) default ' ',
  `mobilephone` varchar(150) default ' ',
  `faxNumber` varchar(150) default ' ',
  `filledBy` varchar(150) default NULL,
  `filledByTitle` varchar(30) default ' ',
  `filledBytelephone` varchar(100) default ' ',
  `filledByemail` varchar(150) default ' ',
  `regDate` date default '0000-00-00',
  `regTime` time default '00:00:00',
  `regDateModify` date default '0000-00-00',
  `securityQuestions` varchar(100) default ' ',
  `securityAnswer` varchar(200) default ' ',
  `recordStatus` tinyint(4) default '0',
  `paid4Registration` tinyint(4) default '0',
  `companyregtype` varchar(300) default ' ',
  PRIMARY KEY  (`sysID`),
  UNIQUE KEY `username` (`username`),
  KEY `cityID` (`cityID`,`LGAID`,`StateID`),
  KEY `companyEmail` (`companyEmail`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `companyregistration` */

insert into `companyregistration` (`sysID`,`username`,`pwd`,`companyName`,`streetAddress`,`cityID`,`LGAID`,`StateID`,`POBOX`,`companyEmail`,`companywebsite`,`representativeName`,`telephone`,`mobilephone`,`faxNumber`,`filledBy`,`filledByTitle`,`filledBytelephone`,`filledByemail`,`regDate`,`regTime`,`regDateModify`,`securityQuestions`,`securityAnswer`,`recordStatus`,`paid4Registration`,`companyregtype`) values (1,'cyprosoft','good','Cyprosoft CodeSolution Nig. Ltd','Suit 12,13 Abuja',47,453,15,'Box 29','cyprosoft@yahoo.com','www.xmobileoffice.com','Udoka Okpalaku','08036025235','08062946900','090897847857684','Cyprian Okpalaku','Mr','08055958775','info@xmobileoffice.com','2013-03-13','17:07:51','2013-03-13','First MD','Cyprian Okpalaku',0,0,'measure');

/*Trigger structure for table `companyregistration` */

DELIMITER $$;

DROP TRIGGER `companyregistration_insert_trigger`$$

CREATE TRIGGER `companyregistration_insert_trigger` BEFORE INSERT ON `companyregistration` FOR EACH ROW BEGIN
SET  NEW.regDate=now();
SET  NEW.regTime=now();
END$$


DROP TRIGGER `companyregistration_update_trigger`$$

CREATE TRIGGER `companyregistration_update_trigger` BEFORE UPDATE ON `companyregistration` FOR EACH ROW BEGIN
SET NEW.regDateModify=NEW.regDate;
SET NEW.regDate=OLD.regDate;
END$$


DELIMITER ;$$

/*Table structure for table `deviceregistration` */

DROP TABLE IF EXISTS `deviceregistration`;

CREATE TABLE `deviceregistration` (
  `sysID` int(11) NOT NULL auto_increment,
  `companyName` varchar(400) NOT NULL default ' ',
  `streetAddress` varchar(400) default ' ',
  `cityID` varchar(50) default ' ',
  `LGAID` varchar(150) default '  ',
  `StateID` varchar(150) default ' ',
  `POBOX` varchar(200) default ' ',
  `companyEmail` varchar(200) default ' ',
  `companywebsite` varchar(200) default ' ',
  `typeOfDevice` varchar(150) default ' ',
  `modelNumber` varchar(150) NOT NULL default ' ',
  `serialNumber` varchar(150) NOT NULL default ' ',
  `manufactureNumber` varchar(150) NOT NULL default ' ',
  `regDate` date default '0000-00-00',
  `regTime` time default '00:00:00',
  `regDateModify` date default '0000-00-00',
  `barCode` varchar(20) default ' ',
  `deviceAmount` double(30,2) default '0.00',
  `vStatus` tinyint(4) default '0',
  `actualMeasure` varchar(200) default ' ',
  `AccountID` int(11) NOT NULL default '0',
  `feeID` int(11) default '0',
  `NoDelete` tinyint(4) default '0',
  PRIMARY KEY  (`sysID`),
  UNIQUE KEY `modelNumber` (`modelNumber`,`serialNumber`,`barCode`),
  KEY `FK_deviceregistration` (`AccountID`),
  CONSTRAINT `deviceregistration_ibfk_1` FOREIGN KEY (`AccountID`) REFERENCES `companyregistration` (`sysID`) ON DELETE NO ACTION ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `deviceregistration` */

insert into `deviceregistration` (`sysID`,`companyName`,`streetAddress`,`cityID`,`LGAID`,`StateID`,`POBOX`,`companyEmail`,`companywebsite`,`typeOfDevice`,`modelNumber`,`serialNumber`,`manufactureNumber`,`regDate`,`regTime`,`regDateModify`,`barCode`,`deviceAmount`,`vStatus`,`actualMeasure`,`AccountID`,`feeID`,`NoDelete`) values (1,'Cyprosoft CodeSolution Nig. Ltd','Suit 12,13 Abuja','47','71','18','Box 29','cyprosoft@yahoo.com','www.xmobileoffice.com','Water Meters','908900-0987889','890908-0988','0899','2013-03-13','17:15:33','2013-03-13','16580290',26000.00,0,'3 toones',1,63,0),(2,'Cyprosoft CodeSolution Nig. Ltd','Suit 12,13 Abuja','47','87','16','Box 29','cyprosoft@yahoo.com','www.xmobileoffice.com','Water Meters','99','99','90','2013-03-13','17:30:51','2013-03-13','35532505',1250.00,0,'78 liters',1,138,0),(3,'Cyprosoft CodeSolution Nig. Ltd','Suit 12,13 Abuja','47','453','15','Box 29','cyprosoft@yahoo.com','www.xmobileoffice.com','Liquid-Measuring Devices','8','888','8','2013-03-13','17:32:34','2013-03-13','84803127',1250.00,0,'7',1,135,0),(4,'Cyprosoft CodeSolution Nig. Ltd','Suit 12,13 Abuja','47','453','15','Box 29','cyprosoft@yahoo.com','www.xmobileoffice.com','Automatic Weighing Systems','889','8889','888','2013-03-13','17:33:55','2013-03-13','88997566',2000.00,0,'788',1,22,0),(5,'Cyprosoft CodeSolution Nig. Ltd','Suit 12,13 Abuja','47','453','15','Box 29','cyprosoft@yahoo.com','www.xmobileoffice.com','Weights','8899','867','7','2013-03-13','17:34:40','2013-03-13','19851923',50000.00,0,'8',1,108,0);

/*Trigger structure for table `deviceregistration` */

DELIMITER $$;

DROP TRIGGER `deviceregistration_insert_trigger`$$

CREATE TRIGGER `deviceregistration_insert_trigger` BEFORE INSERT ON `deviceregistration` FOR EACH ROW BEGIN
SET NEW.regDate=now();
SET NEW.regTime=now();
END$$


DROP TRIGGER `deviceregistration_update_trigger`$$

CREATE TRIGGER `deviceregistration_update_trigger` BEFORE UPDATE ON `deviceregistration` FOR EACH ROW BEGIN
SET NEW.regDateModify=NEW.regDate;
SET NEW.regDate=OLD.regDate;
END$$


DELIMITER ;$$

/*Table structure for table `emailsubs` */

DROP TABLE IF EXISTS `emailsubs`;

CREATE TABLE `emailsubs` (
  `sysID` int(11) NOT NULL auto_increment,
  `email` varchar(100) default ' ',
  `regDate` date default '0000-00-00',
  PRIMARY KEY  (`sysID`),
  UNIQUE KEY `email` (`email`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `emailsubs` */

insert into `emailsubs` (`sysID`,`email`,`regDate`) values (1,'cyprosoft@yahoo.com','2013-03-12');

/*Table structure for table `errortable` */

DROP TABLE IF EXISTS `errortable`;

CREATE TABLE `errortable` (
  `sysID` int(11) NOT NULL auto_increment,
  `ErrorMsg` longtext,
  `errordate` date default '0000-00-00',
  `errortime` time default '00:00:00',
  `hostinterface` varchar(300) default ' ',
  `UserID` int(9) default '0',
  PRIMARY KEY  (`sysID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `errortable` */

insert into `errortable` (`sysID`,`ErrorMsg`,`errordate`,`errortime`,`hostinterface`,`UserID`) values (1,'Thread was being aborted.','2013-03-13','17:31:44','regdevice',0),(2,'Thread was being aborted.','2013-03-13','17:31:55','regdevice',0),(3,'You have an error in your SQL syntax; check the manual that corresponds to your MySQL server version for the right syntax to use near \'date_format(regDate,\'%D-%M-%Y\') as TransDate from paymentsheet where companyID=1\' at line 1:::select sysID as ID,amountDue,AmountPaid,amountDue-AmountPaid as balance,OrderId,,date_format(regDate,\'%D-%M-%Y\') as TransDate from paymentsheet where companyID=1 ','2013-03-13','17:35:17','DataSetData (1 value)',0),(4,'You have an error in your SQL syntax; check the manual that corresponds to your MySQL server version for the right syntax to use near \'date_format(regDate,\'%D-%M-%Y\') as TransDate from paymentsheet where companyID=1\' at line 1:::select sysID as ID,amountDue,AmountPaid,amountDue-AmountPaid as balance,OrderId,,date_format(regDate,\'%D-%M-%Y\') as TransDate from paymentsheet where companyID=1 ','2013-03-13','17:35:18','DataSetData (1 value)',0),(5,'You have an error in your SQL syntax; check the manual that corresponds to your MySQL server version for the right syntax to use near \'date_format(regDate,\'%D-%M-%Y\') as TransDate from paymentsheet where companyID=1\' at line 1:::select sysID as ID,amountDue,AmountPaid,amountDue-AmountPaid as balance,OrderId,,date_format(regDate,\'%D-%M-%Y\') as TransDate from paymentsheet where companyID=1 ','2013-03-13','17:35:22','DataSetData (1 value)',0),(6,'Thread was being aborted.','2013-03-13','20:48:09','regdevice',0),(7,'Thread was being aborted.','2013-03-13','20:51:41','regdevice',0);

/*Table structure for table `feegroup` */

DROP TABLE IF EXISTS `feegroup`;

CREATE TABLE `feegroup` (
  `sysID` int(11) NOT NULL auto_increment,
  `HeaderName` varchar(900) default ' ',
  `recordStatus` tinyint(4) default '0',
  `userID` int(11) default '0',
  `userIdModify` int(11) default '0',
  `regDateModify` date default '0000-00-00',
  `regDate` date default '0000-00-00',
  PRIMARY KEY  (`sysID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `feegroup` */

insert into `feegroup` (`sysID`,`HeaderName`,`recordStatus`,`userID`,`userIdModify`,`regDateModify`,`regDate`) values (1,'MEASURES OF LENGTH',0,1,0,'0000-00-00','2013-03-13'),(2,'MEASURES OF CAPACITY',0,1,0,'0000-00-00','2013-03-13'),(3,'WEIGHTS',0,1,0,'0000-00-00','2013-03-13'),(4,' WEIGHING INSTRUMENT',0,1,0,'0000-00-00','2013-03-13'),(5,'Volumetric Measuring Instruments used for the measurement of  liquid Fuel, Lubricating, liquor and soft drinks',0,1,0,'0000-00-00','2013-03-13'),(6,'Approval of Pattern ',0,1,0,'0000-00-00','2013-03-13'),(7,'Other Measuring Instruments',0,1,0,'0000-00-00','2013-03-13'),(8,'Adjusting Fees',0,1,0,'0000-00-00','2013-03-13'),(9,'Weights, Measures, Weighing and Measuring  Instruments used for the Bulk measurement of Liquid fuel, lubricating oil, liquor and soft drinks',0,1,0,'0000-00-00','2013-03-13');

/*Trigger structure for table `feegroup` */

DELIMITER $$;

DROP TRIGGER `feegroup_insert_trigger`$$

CREATE TRIGGER `feegroup_insert_trigger` BEFORE INSERT ON `feegroup` FOR EACH ROW BEGIN
SET NEW.regDate=now();
END$$


DROP TRIGGER `feegroup_update_trigger`$$

CREATE TRIGGER `feegroup_update_trigger` BEFORE UPDATE ON `feegroup` FOR EACH ROW BEGIN
SET NEW.userIdModify=NEW.userID;
SET NEW.regDateModify=NEW.regDate;
SET NEW.userID=OLD.userID;
SET NEW.regDate=OLD.regDate;
END$$


DELIMITER ;$$

/*Table structure for table `feesubgroup` */

DROP TABLE IF EXISTS `feesubgroup`;

CREATE TABLE `feesubgroup` (
  `sysID` int(11) NOT NULL auto_increment,
  `subheading` varchar(900) default ' ',
  `recordStatus` tinyint(4) default '0',
  `userID` int(11) default '0',
  `userIdModify` int(11) default '0',
  `regDateModify` date default '0000-00-00',
  `regDate` date default '0000-00-00',
  `feegroupID` int(11) default '0',
  PRIMARY KEY  (`sysID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `feesubgroup` */

insert into `feesubgroup` (`sysID`,`subheading`,`recordStatus`,`userID`,`userIdModify`,`regDateModify`,`regDate`,`feegroupID`) values (1,'MEASURES OF LENGTH',0,1,0,'0000-00-00','2013-03-13',1),(2,'Folding  Scales/Measures of length used in weaving Industry',0,1,0,'0000-00-00','2013-03-13',1),(3,'Surveying Chain',0,1,0,'0000-00-00','2013-03-13',1),(4,'BEAM SCALE CLASS A & B',0,1,0,'0000-00-00','2013-03-13',1),(5,'BEAM SCALE CLASS C & D',0,1,0,'0000-00-00','2013-03-13',1),(6,'MEASURES OF CAPACITY',0,1,0,'0000-00-00','2013-03-13',2),(7,'Bulk Storage Facilities (Domestic Kero)',0,1,1,'2013-03-13','2013-03-13',2),(8,'Other Bulk Storage Facilities',0,1,1,'2013-03-13','2013-03-13',2),(9,'Bullion Weights',0,1,0,'0000-00-00','2013-03-13',3),(10,'Carat Metric and Rider Weight ',0,1,0,'0000-00-00','2013-03-13',3),(11,'Cylindrical Knob Type Weighst',0,1,0,'0000-00-00','2013-03-13',3),(12,'Sheet Metal Weights',0,1,0,'0000-00-00','2013-03-13',3),(13,'Parallelepiped Weights',0,1,0,'0000-00-00','2013-03-13',3),(14,'NON AUTOMATIC WEIGHING INSTRUMENT MECHANICAL (ANALOGUES) CLASS III & IV',0,1,0,'0000-00-00','2013-03-13',4),(15,'NON AUTOMATIC WEIGHING INSTRUMENT ELECTRONIC CLASS III & IV',0,1,0,'0000-00-00','2013-03-13',4),(16,'NON AUTOMATIC WEIGHING INSTRUMENTS BOTH MECHANICAL AND ELECTRONIC CLASS I AND II',0,1,1,'2013-03-13','2013-03-13',4),(17,'AUTOMATIC WEIGHING INSTRUMENTS',0,1,0,'0000-00-00','2013-03-13',4),(18,'Automatic weighing machine and totalising machine, each spout',0,1,0,'0000-00-00','2013-03-13',4),(19,'Balance of precision and analytical balance',0,1,0,'0000-00-00','2013-03-13',4),(20,'Piston type each instrument',0,1,0,'0000-00-00','2013-03-13',5),(21,'Container type including batteries of can or barrel fillers',0,1,1,'2013-03-13','2013-03-13',5),(22,'Dispenser other than E (I to II)',0,1,0,'0000-00-00','2013-03-13',5),(23,'FLOW METERS(Bulk Meter Type Each Instrument)',0,1,1,'2013-03-13','2013-03-13',5),(24,' ROAD TANKER FUEL MEASURING EQUIPMENT(Calibrated tanks and tank wagons without meter)',0,1,0,'0000-00-00','2013-03-13',5),(25,'Calibrated tanks and tank wagons with Measuring Systems: ',0,1,0,'0000-00-00','2013-03-13',5),(26,'Fuel Dispensers',0,1,1,'2013-03-13','2013-03-13',6),(27,'Weighing Instruments',0,1,1,'2013-03-13','2013-03-13',6),(28,'Measuring Instruments other thanfuel dispenser',0,1,0,'0000-00-00','2013-03-13',6),(29,'Weigh Bridges ',0,1,0,'0000-00-00','2013-03-13',6),(30,'Vending Machines',0,1,0,'0000-00-00','2013-03-13',6),(31,'ATM Machines',0,1,0,'0000-00-00','2013-03-13',6),(32,'Heavy Duty Notes Counting Machines ',0,1,0,'0000-00-00','2013-03-13',6),(33,'Other Notes Counting Machines',0,1,0,'0000-00-00','2013-03-13',6),(34,'Taxi Meters',0,1,0,'0000-00-00','2013-03-13',6),(35,'Water meters',0,1,0,'0000-00-00','2013-03-13',6),(36,'Electricity Meters',0,1,0,'0000-00-00','2013-03-13',6),(37,'Gas Meters',0,1,0,'0000-00-00','2013-03-13',6),(38,'Tank Gauging Systems',0,1,0,'0000-00-00','2013-03-13',6),(39,'Clocking Machine',0,1,0,'0000-00-00','2013-03-13',6),(40,'Gaming machine',0,1,0,'0000-00-00','2013-03-13',6),(41,'Telecommunication Reference Clocks',0,1,0,'0000-00-00','2013-03-13',6),(42,'Telecommunication Metering Systems',0,1,0,'0000-00-00','2013-03-13',6),(43,'Telecommunication Billing Systems',0,1,0,'0000-00-00','2013-03-13',6),(44,'Vehicles or measures used for the carriage for sale of sand, gravel, shingle, clinker of any description, granite and  other chipping and other materials commonly used in building ,civil engineering industries as hard -core or aggregate',0,1,1,'2013-03-13','2013-03-13',7),(45,'Vending Machines other than ATMs',0,1,0,'0000-00-00','2013-03-13',7),(46,'Taxi Meters',0,1,0,'0000-00-00','2013-03-13',7),(47,'ATM Machines',0,1,0,'0000-00-00','2013-03-13',7),(48,'Water meters',0,1,0,'0000-00-00','2013-03-13',7),(49,'Electricity Meters',0,1,0,'0000-00-00','2013-03-13',7),(50,'Tank Gauging Systems',0,1,0,'0000-00-00','2013-03-13',7),(51,'CNG/LNG/LPG Dispensers',0,1,0,'0000-00-00','2013-03-13',7),(52,'Standards and equipment under section 5 of the weights and Measures Act1974 ',0,1,0,'0000-00-00','2013-03-13',7),(53,'Clocking Machine',0,1,0,'0000-00-00','2013-03-13',7),(54,'Gaming machine',0,1,0,'0000-00-00','2013-03-13',7),(55,'Scanners',0,1,0,'0000-00-00','2013-03-13',7),(56,'Heavy Duty Notes Counting Machines',0,1,0,'0000-00-00','2013-03-13',7),(57,'Other Notes Counting Machines',0,1,0,'0000-00-00','2013-03-13',7),(58,'Moulds',0,1,0,'0000-00-00','2013-03-13',7),(59,'Weights',0,1,0,'0000-00-00','2013-03-13',8),(60,'Measures Capacity',0,1,1,'2013-03-13','2013-03-13',8),(61,'Weighing Instrument',0,1,1,'2013-03-13','2013-03-13',8),(62,'Measuring instrument used for the measurement of liquid fuel, lubricating oil, liquor and other liquid',0,1,0,'0000-00-00','2013-03-13',8),(63,'Prover Tanks',0,1,0,'0000-00-00','2013-03-13',9),(64,'Others',0,1,0,'0000-00-00','2013-03-13',9),(65,'Device Manufacturers Rated Capacity',0,1,0,'0000-00-00','2013-03-13',9),(66,'Indigenous Measures',0,1,0,'0000-00-00','2013-03-13',9);

/*Trigger structure for table `feesubgroup` */

DELIMITER $$;

DROP TRIGGER `feesubgroup_insert_trigger`$$

CREATE TRIGGER `feesubgroup_insert_trigger` BEFORE INSERT ON `feesubgroup` FOR EACH ROW BEGIN
SET NEW.regDate=now();
END$$


DROP TRIGGER `feesubgroup_update_trigger`$$

CREATE TRIGGER `feesubgroup_update_trigger` BEFORE UPDATE ON `feesubgroup` FOR EACH ROW BEGIN
SET NEW.userIdModify=NEW.userID;
SET NEW.regDateModify=NEW.regDate;
SET NEW.userID=OLD.userID;
SET NEW.regDate=OLD.regDate;
END$$


DELIMITER ;$$

/*Table structure for table `feetable` */

DROP TABLE IF EXISTS `feetable`;

CREATE TABLE `feetable` (
  `sysID` int(11) NOT NULL auto_increment,
  `measureRange` varchar(4000) default ' ',
  `amount` double(30,2) default '0.00',
  `regDate` date default '0000-00-00',
  `regTime` time default '00:00:00',
  `feeGroupID` int(11) default '0',
  `feeSubGroupID` int(11) default '0',
  `userID` int(11) default '0',
  `userIdModify` int(11) default '0',
  `regDateModify` date default '0000-00-00',
  `subheading` varchar(1000) default ' ',
  `groupname` varchar(1000) default ' ',
  PRIMARY KEY  (`sysID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `feetable` */

insert into `feetable` (`sysID`,`measureRange`,`amount`,`regDate`,`regTime`,`feeGroupID`,`feeSubGroupID`,`userID`,`userIdModify`,`regDateModify`,`subheading`,`groupname`) values (1,'Not exceeding 3 metre, each scale',250.00,'2013-03-13','04:17:02',1,1,1,0,'0000-00-00','MEASURES OF LENGTH','MEASURES OF LENGTH'),(2,'Above 3 metre, but not exceeding 25 metre, each scale',1250.00,'2013-03-13','04:17:02',1,1,1,0,'0000-00-00','MEASURES OF LENGTH','MEASURES OF LENGTH'),(3,'Above 25 meters',2500.00,'2013-03-13','04:17:02',1,1,1,0,'0000-00-00','MEASURES OF LENGTH','MEASURES OF LENGTH'),(4,'Length - 0.5 meter to 1 meter',2500.00,'2013-03-13','04:17:02',1,2,1,1,'2013-03-13','Folding  Scales/Measures of length used in weaving Industry','MEASURES OF LENGTH'),(5,'Above 1 meter',5000.00,'2013-03-13','04:17:02',1,2,1,1,'2013-03-13','Folding  Scales/Measures of length used in weaving Industry','MEASURES OF LENGTH'),(6,'Length 20  to 30 meter ',7500.00,'2013-03-13','04:17:03',1,3,1,1,'2013-03-13','Surveying Chain','MEASURES OF LENGTH'),(7,'Above 30 meter',10000.00,'2013-03-13','04:17:03',1,3,1,1,'2013-03-13','Surveying Chain','MEASURES OF LENGTH'),(8,'Fabric Plastic, Woven, and Steel Tapes Class I, II and III ',500.00,'2013-03-13','04:17:03',1,3,1,1,'2013-03-13','Surveying Chain','MEASURES OF LENGTH'),(9,'< 500g to 10 kg',10000.00,'2013-03-13','04:17:03',1,4,1,1,'2013-03-13','BEAM SCALE CLASS A & B','MEASURES OF LENGTH'),(10,'> 10kg to 200 kg',15000.00,'2013-03-13','04:17:03',1,4,1,1,'2013-03-13','BEAM SCALE CLASS A & B','MEASURES OF LENGTH'),(11,'< 500g to 10 kg',7500.00,'2013-03-13','04:17:03',1,5,1,1,'2013-03-13','BEAM SCALE CLASS C & D','MEASURES OF LENGTH'),(12,'> 10kg to 1000 kg',10000.00,'2013-03-13','04:17:03',1,5,1,1,'2013-03-13','BEAM SCALE CLASS C & D','MEASURES OF LENGTH'),(13,'Capacity measures without divisions not exceeding 1litre',500.00,'2013-03-13','04:17:03',2,6,1,1,'2013-03-13','MEASURES OF CAPACITY','MEASURES OF CAPACITY'),(14,'Not exceeding 5 litre, each measure',2500.00,'2013-03-13','04:17:03',2,6,1,1,'2013-03-13','MEASURES OF CAPACITY','MEASURES OF CAPACITY'),(15,'Above 5 litres for the first 5 litres',5000.00,'2013-03-13','04:17:03',2,6,1,1,'2013-03-13','MEASURES OF CAPACITY','MEASURES OF CAPACITY'),(16,'For  additional 5 litre or part thereof ',2500.00,'2013-03-13','04:17:03',2,6,1,1,'2013-03-13','MEASURES OF CAPACITY','MEASURES OF CAPACITY'),(17,'Cubic ballast measures (other than brim measures)',4500.00,'2013-03-13','04:17:03',2,6,1,1,'2013-03-13','MEASURES OF CAPACITY','MEASURES OF CAPACITY'),(18,'Liquid capacity measures for making up and checking average quantity packages',1200.00,'2013-03-13','04:17:03',2,6,1,1,'2013-03-13','MEASURES OF CAPACITY','MEASURES OF CAPACITY'),(19,'Templates (a) Per scale - first item',3500.00,'2013-03-13','04:17:03',2,6,1,1,'2013-03-13','MEASURES OF CAPACITY','MEASURES OF CAPACITY'),(20,'Templates (b) Second and subsequent items',1500.00,'2013-03-13','04:17:03',2,6,1,1,'2013-03-13','MEASURES OF CAPACITY','MEASURES OF CAPACITY'),(21,'Not exceeding 0.5 M³ each unit',1000.00,'2013-03-13','04:17:03',2,7,1,1,'2013-03-13','Bulk Storage Facilities (Domestic Kero):','MEASURES OF CAPACITY'),(22,'Above 0.5 M³ each unit for the first 0.5 M³ ',2000.00,'2013-03-13','04:17:03',2,7,1,1,'2013-03-13','Bulk Storage Facilities (Domestic Kero):','MEASURES OF CAPACITY'),(23,'For  additional 0.5 M³ or part thereof',1000.00,'2013-03-13','04:17:03',2,7,1,1,'2013-03-13','Bulk Storage Facilities (Domestic Kero):','MEASURES OF CAPACITY'),(24,'Not exceeding 0.5 M³ each unit',5000.00,'2013-03-13','04:17:04',2,8,1,1,'2013-03-13','Other Bulk Storage Facilities:','MEASURES OF CAPACITY'),(25,'Above 0.5 M³ each unit for the first 0.5 M³ ',10000.00,'2013-03-13','04:17:04',2,8,1,1,'2013-03-13','Other Bulk Storage Facilities:','MEASURES OF CAPACITY'),(26,'For  additional 0.5 M³ or part thereof',5000.00,'2013-03-13','04:17:04',2,8,1,1,'2013-03-13','Other Bulk Storage Facilities:','MEASURES OF CAPACITY'),(27,'Not exceeding 2kg each weight',250.00,'2013-03-13','04:17:04',3,9,1,1,'2013-03-13','Bullion Weights','WEIGHTS'),(28,'Above 2kg each weight',500.00,'2013-03-13','04:17:04',3,9,1,1,'2013-03-13','Bullion Weights','WEIGHTS'),(29,'1mg (0.005c) to 100g (500c) each weight',1000.00,'2013-03-13','04:17:04',3,10,1,1,'2013-03-13','Carat Metric and Rider Weight ','WEIGHTS'),(30,'1g to 500g',500.00,'2013-03-13','04:17:04',3,11,1,1,'2013-03-13','Cylindrical Knob Type Weighst','WEIGHTS'),(31,'500g to 1kg ',1000.00,'2013-03-13','04:17:04',3,11,1,1,'2013-03-13','Cylindrical Knob Type Weighst','WEIGHTS'),(32,'Above 1kg for the first 1Kg',2000.00,'2013-03-13','04:17:04',3,11,1,1,'2013-03-13','Cylindrical Knob Type Weighst','WEIGHTS'),(33,'For additional 1Kg or part thereafter',1000.00,'2013-03-13','04:17:04',3,11,1,1,'2013-03-13','Cylindrical Knob Type Weighst','WEIGHTS'),(34,'1mg to 500 mg',500.00,'2013-03-13','04:17:04',3,12,1,1,'2013-03-13','Sheet Metal Weights','WEIGHTS'),(35,'1g to 500g',750.00,'2013-03-13','04:17:04',3,13,1,1,'2013-03-13','Parallelepiped Weights','WEIGHTS'),(36,'500g to 1kg ',2500.00,'2013-03-13','04:17:04',3,13,1,1,'2013-03-13','Parallelepiped Weights','WEIGHTS'),(37,'Above 1kg for the first 1Kg',5000.00,'2013-03-13','04:17:04',3,13,1,1,'2013-03-13','Parallelepiped Weights','WEIGHTS'),(38,'For additional 1Kg or part thereafter',2500.00,'2013-03-13','04:17:04',3,13,1,1,'2013-03-13','Parallelepiped Weights','WEIGHTS'),(39,'Not exceeding 10kg',1250.00,'2013-03-13','04:17:04',4,14,1,1,'2013-03-13','NON AUTOMATIC WEIGHING INSTRUMENT MECHANICAL (ANALOGUES) CLASS III & IV',' WEIGHING INSTRUMENT'),(40,'Above 10kg but not exceeding 100kg',2500.00,'2013-03-13','04:17:04',4,14,1,1,'2013-03-13','NON AUTOMATIC WEIGHING INSTRUMENT MECHANICAL (ANALOGUES) CLASS III & IV',' WEIGHING INSTRUMENT'),(41,'Above 100kg but not exceeding 250kg',5000.00,'2013-03-13','04:17:05',4,14,1,1,'2013-03-13','NON AUTOMATIC WEIGHING INSTRUMENT MECHANICAL (ANALOGUES) CLASS III & IV',' WEIGHING INSTRUMENT'),(42,'Above 250kg but not exceeding 500kg',7500.00,'2013-03-13','04:17:05',4,14,1,1,'2013-03-13','NON AUTOMATIC WEIGHING INSTRUMENT MECHANICAL (ANALOGUES) CLASS III & IV',' WEIGHING INSTRUMENT'),(43,'Above 500kg but not exceeding 1 tonne',10000.00,'2013-03-13','04:17:05',4,14,1,1,'2013-03-13','NON AUTOMATIC WEIGHING INSTRUMENT MECHANICAL (ANALOGUES) CLASS III & IV',' WEIGHING INSTRUMENT'),(44,'Above 1 tonne for the first 1 tonne',24000.00,'2013-03-13','04:17:05',4,14,1,1,'2013-03-13','NON AUTOMATIC WEIGHING INSTRUMENT MECHANICAL (ANALOGUES) CLASS III & IV',' WEIGHING INSTRUMENT'),(45,'Every additional 1 tonne or part thereof',5500.00,'2013-03-13','04:17:05',4,14,1,1,'2013-03-13','NON AUTOMATIC WEIGHING INSTRUMENT MECHANICAL (ANALOGUES) CLASS III & IV',' WEIGHING INSTRUMENT'),(46,'Not exceeding 10kg',950.00,'2013-03-13','04:17:05',4,15,1,1,'2013-03-13','NON AUTOMATIC WEIGHING INSTRUMENT ELECTRONIC CLASS III & IV',' WEIGHING INSTRUMENT'),(47,'Above 10kg but not exceeding 100kg',2500.00,'2013-03-13','04:17:05',4,15,1,1,'2013-03-13','NON AUTOMATIC WEIGHING INSTRUMENT ELECTRONIC CLASS III & IV',' WEIGHING INSTRUMENT'),(48,'Above 100kg but not exceeding 250kg',5000.00,'2013-03-13','04:17:05',4,15,1,1,'2013-03-13','NON AUTOMATIC WEIGHING INSTRUMENT ELECTRONIC CLASS III & IV',' WEIGHING INSTRUMENT'),(49,'Above 250kg but not exceeding 500kg',7500.00,'2013-03-13','04:17:05',4,15,1,1,'2013-03-13','NON AUTOMATIC WEIGHING INSTRUMENT ELECTRONIC CLASS III & IV',' WEIGHING INSTRUMENT'),(50,'Above 500kg but not exceeding 1 tonne',10000.00,'2013-03-13','04:17:05',4,15,1,1,'2013-03-13','NON AUTOMATIC WEIGHING INSTRUMENT ELECTRONIC CLASS III & IV',' WEIGHING INSTRUMENT'),(51,'Above 1 tonne for the first 1 tonne',24000.00,'2013-03-13','04:17:05',4,15,1,1,'2013-03-13','NON AUTOMATIC WEIGHING INSTRUMENT ELECTRONIC CLASS III & IV',' WEIGHING INSTRUMENT'),(52,'Every additional 1 tonne or part thereof',5500.00,'2013-03-13','04:17:05',4,15,1,1,'2013-03-13','NON AUTOMATIC WEIGHING INSTRUMENT ELECTRONIC CLASS III & IV',' WEIGHING INSTRUMENT'),(53,'Above 10kg but not exceeding 100kg',2500.00,'2013-03-13','04:17:05',4,16,1,1,'2013-03-13','NON AUTOMATIC WEIGHING INSTRUMENTS BOTH MECHANICAL AND ELECTRONIC CLASS I AND II.',' WEIGHING INSTRUMENT'),(54,'Above 100kg but not exceeding 250kg',7000.00,'2013-03-13','04:17:05',4,16,1,1,'2013-03-13','NON AUTOMATIC WEIGHING INSTRUMENTS BOTH MECHANICAL AND ELECTRONIC CLASS I AND II.',' WEIGHING INSTRUMENT'),(55,'Above 250kg but not exceeding 500kg',8500.00,'2013-03-13','04:17:05',4,16,1,1,'2013-03-13','NON AUTOMATIC WEIGHING INSTRUMENTS BOTH MECHANICAL AND ELECTRONIC CLASS I AND II.',' WEIGHING INSTRUMENT'),(56,'Above 500kg but not exceeding 1 tonne',13000.00,'2013-03-13','04:17:06',4,16,1,1,'2013-03-13','NON AUTOMATIC WEIGHING INSTRUMENTS BOTH MECHANICAL AND ELECTRONIC CLASS I AND II.',' WEIGHING INSTRUMENT'),(57,'Above 1 tonne for the first 1 tonne',26000.00,'2013-03-13','04:17:06',4,16,1,1,'2013-03-13','NON AUTOMATIC WEIGHING INSTRUMENTS BOTH MECHANICAL AND ELECTRONIC CLASS I AND II.',' WEIGHING INSTRUMENT'),(58,'Every additional 1 tonne or part thereof',7500.00,'2013-03-13','04:17:06',4,16,1,1,'2013-03-13','NON AUTOMATIC WEIGHING INSTRUMENTS BOTH MECHANICAL AND ELECTRONIC CLASS I AND II.',' WEIGHING INSTRUMENT'),(59,'Above 10kg but not exceeding 100kg',2500.00,'2013-03-13','04:17:06',4,17,1,1,'2013-03-13','AUTOMATIC WEIGHING INSTRUMENTS',' WEIGHING INSTRUMENT'),(60,'Above 100kg but not exceeding 250kg',9000.00,'2013-03-13','04:17:06',4,17,1,1,'2013-03-13','AUTOMATIC WEIGHING INSTRUMENTS',' WEIGHING INSTRUMENT'),(61,'Above 250kg but not exceeding 500kg',10500.00,'2013-03-13','04:17:06',4,17,1,1,'2013-03-13','AUTOMATIC WEIGHING INSTRUMENTS',' WEIGHING INSTRUMENT'),(62,'Above 500kg but not exceeding 1 tonne',13000.00,'2013-03-13','04:17:06',4,17,1,1,'2013-03-13','AUTOMATIC WEIGHING INSTRUMENTS',' WEIGHING INSTRUMENT'),(63,'Above 1 tonne for the first 1 tonne',26000.00,'2013-03-13','04:17:06',4,17,1,1,'2013-03-13','AUTOMATIC WEIGHING INSTRUMENTS',' WEIGHING INSTRUMENT'),(64,'Every additional 1 tonne or part thereof',7500.00,'2013-03-13','04:17:06',4,17,1,1,'2013-03-13','AUTOMATIC WEIGHING INSTRUMENTS',' WEIGHING INSTRUMENT'),(65,'Not exceeding 10kg',5000.00,'2013-03-13','04:17:06',4,18,1,1,'2013-03-13','Automatic weighing machine and totalising machine, each spout',' WEIGHING INSTRUMENT'),(66,'Exceeding 10kg',10000.00,'2013-03-13','04:17:06',4,18,1,1,'2013-03-13','Automatic weighing machine and totalising machine, each spout',' WEIGHING INSTRUMENT'),(67,'Egg-grading machine, each unit',5000.00,'2013-03-13','04:17:06',4,18,1,1,'2013-03-13','Automatic weighing machine and totalising machine, each spout',' WEIGHING INSTRUMENT'),(68,'Each egg poise',1000.00,'2013-03-13','04:17:06',4,18,1,1,'2013-03-13','Automatic weighing machine and totalising machine, each spout',' WEIGHING INSTRUMENT'),(69,'Balance of precision and analytical balance',5000.00,'2013-03-13','04:17:07',4,19,1,1,'2013-03-13','Balance of precision and analytical balance',' WEIGHING INSTRUMENT'),(70,'Piston type each instrument',1250.00,'2013-03-13','04:17:07',5,20,1,1,'2013-03-13','Piston type each instrument','Volumetric Measuring Instruments used for the measurement of  liquid Fuel, Lubricating, liquor and soft drinks'),(71,'Each Container capacity not exceeding 20m litre',2550.00,'2013-03-13','04:17:07',5,21,1,1,'2013-03-13','Container type including batteries of can or barrel fillers:','Volumetric Measuring Instruments used for the measurement of  liquid Fuel, Lubricating, liquor and soft drinks'),(72,'Each Container capacity exceeding 20m litre',5500.00,'2013-03-13','04:17:07',5,21,1,1,'2013-03-13','Container type including batteries of can or barrel fillers:','Volumetric Measuring Instruments used for the measurement of  liquid Fuel, Lubricating, liquor and soft drinks'),(73,'Dispensing Pump each pump ',5000.00,'2013-03-13','04:17:07',5,22,1,1,'2013-03-13','Dispenser other than E (I to II)','Volumetric Measuring Instruments used for the measurement of  liquid Fuel, Lubricating, liquor and soft drinks'),(74,'Volumetric Fillers each Spout',3700.00,'2013-03-13','04:17:07',5,22,1,1,'2013-03-13','Dispenser other than E (I to II)','Volumetric Measuring Instruments used for the measurement of  liquid Fuel, Lubricating, liquor and soft drinks'),(75,'Totalizing Counter ',3500.00,'2013-03-13','04:17:07',5,22,1,1,'2013-03-13','Dispenser other than E (I to II)','Volumetric Measuring Instruments used for the measurement of  liquid Fuel, Lubricating, liquor and soft drinks'),(76,'Other instruments exceeding 100 L  for the first 100 L',7500.00,'2013-03-13','04:17:07',5,22,1,1,'2013-03-13','Dispenser other than E (I to II)','Volumetric Measuring Instruments used for the measurement of  liquid Fuel, Lubricating, liquor and soft drinks'),(77,'Every additional 100 L or part thereof',1000.00,'2013-03-13','04:17:07',5,22,1,1,'2013-03-13','Dispenser other than E (I to II)','Volumetric Measuring Instruments used for the measurement of  liquid Fuel, Lubricating, liquor and soft drinks'),(78,'Not exceeding 100 L but above 50 L',3500.00,'2013-03-13','04:17:07',5,22,1,1,'2013-03-13','Dispenser other than E (I to II)','Volumetric Measuring Instruments used for the measurement of  liquid Fuel, Lubricating, liquor and soft drinks'),(79,'Not exceeding 50L but above 20L',2000.00,'2013-03-13','04:17:07',5,22,1,1,'2013-03-13','Dispenser other than E (I to II)','Volumetric Measuring Instruments used for the measurement of  liquid Fuel, Lubricating, liquor and soft drinks'),(80,'Not exceeding 20L',1500.00,'2013-03-13','04:17:07',5,22,1,1,'2013-03-13','Dispenser other than E (I to II)','Volumetric Measuring Instruments used for the measurement of  liquid Fuel, Lubricating, liquor and soft drinks'),(81,'Flow Rate less than 100 litre/minute',10500.00,'2013-03-13','04:17:07',5,23,1,1,'2013-03-13','FLOW METERS(Bulk Meter Type Each Instrument : )','Volumetric Measuring Instruments used for the measurement of  liquid Fuel, Lubricating, liquor and soft drinks'),(82,'Flow Rate above 100 litre/minute up to 500Lt/minute',15950.00,'2013-03-13','04:17:07',5,23,1,1,'2013-03-13','FLOW METERS(Bulk Meter Type Each Instrument : )','Volumetric Measuring Instruments used for the measurement of  liquid Fuel, Lubricating, liquor and soft drinks'),(83,'Flow Rate above 500 litre/minute up to 1,500Lt/minute',17000.00,'2013-03-13','04:17:08',5,23,1,1,'2013-03-13','FLOW METERS(Bulk Meter Type Each Instrument : )','Volumetric Measuring Instruments used for the measurement of  liquid Fuel, Lubricating, liquor and soft drinks'),(84,'Flow Rate above 1,500 litre/minute up to 2,500Lt/minute',20000.00,'2013-03-13','04:17:08',5,23,1,1,'2013-03-13','FLOW METERS(Bulk Meter Type Each Instrument : )','Volumetric Measuring Instruments used for the measurement of  liquid Fuel, Lubricating, liquor and soft drinks'),(85,'Flow Rate above 2,500 litre/minute up to 5,000Lt/minute',25000.00,'2013-03-13','04:17:08',5,23,1,1,'2013-03-13','FLOW METERS(Bulk Meter Type Each Instrument : )','Volumetric Measuring Instruments used for the measurement of  liquid Fuel, Lubricating, liquor and soft drinks'),(86,'Flow Rate above 5,000 litre/minute',30000.00,'2013-03-13','04:17:08',5,23,1,1,'2013-03-13','FLOW METERS(Bulk Meter Type Each Instrument : )','Volumetric Measuring Instruments used for the measurement of  liquid Fuel, Lubricating, liquor and soft drinks'),(87,'Each unit or compartment of capacity not exceeding 1,500 litre',5000.00,'2013-03-13','04:17:08',5,24,1,1,'2013-03-13',' ROAD TANKER FUEL MEASURING EQUIPMENT(Calibrated tanks and tank wagons without meter)','Volumetric Measuring Instruments used for the measurement of  liquid Fuel, Lubricating, liquor and soft drinks'),(88,'Each calibrated unit or compartment above 1,500 litre for the first 1,500 litres',10000.00,'2013-03-13','04:17:08',5,24,1,1,'2013-03-13',' ROAD TANKER FUEL MEASURING EQUIPMENT(Calibrated tanks and tank wagons without meter)','Volumetric Measuring Instruments used for the measurement of  liquid Fuel, Lubricating, liquor and soft drinks'),(89,'For every additional 500litre',5000.00,'2013-03-13','04:17:08',5,24,1,1,'2013-03-13',' ROAD TANKER FUEL MEASURING EQUIPMENT(Calibrated tanks and tank wagons without meter)','Volumetric Measuring Instruments used for the measurement of  liquid Fuel, Lubricating, liquor and soft drinks'),(90,'Wet hose type with two testing liquids ',10000.00,'2013-03-13','04:17:08',5,25,1,1,'2013-03-13','Calibrated tanks and tank wagons with Measuring Systems: ','Volumetric Measuring Instruments used for the measurement of  liquid Fuel, Lubricating, liquor and soft drinks'),(91,'Dry hose type with two testing liquids',12000.00,'2013-03-13','04:17:08',5,25,1,1,'2013-03-13','Calibrated tanks and tank wagons with Measuring Systems: ','Volumetric Measuring Instruments used for the measurement of  liquid Fuel, Lubricating, liquor and soft drinks'),(92,'Dual wet/dry',17000.00,'2013-03-13','04:17:08',5,25,1,1,'2013-03-13','Calibrated tanks and tank wagons with Measuring Systems: ','Volumetric Measuring Instruments used for the measurement of  liquid Fuel, Lubricating, liquor and soft drinks'),(93,'Each Instrument ',250000.00,'2013-03-13','04:17:09',6,26,1,1,'2013-03-13','Fuel Dispensers;','Approval of Pattern '),(94,'Each Component',50000.00,'2013-03-13','04:17:09',6,26,1,1,'2013-03-13','Fuel Dispensers;','Approval of Pattern '),(95,'Each Instrument  not exceeding 250Kg ',50000.00,'2013-03-13','04:17:09',6,27,1,1,'2013-03-13','Weighing Instruments;','Approval of Pattern '),(96,'Each Instrument  above 250Kg',50000.00,'2013-03-13','04:17:09',6,27,1,1,'2013-03-13','Weighing Instruments;','Approval of Pattern '),(97,'Measuring Instruments other thanfuel dispenser',125000.00,'2013-03-13','04:17:09',6,28,1,1,'2013-03-13','Measuring Instruments other thanfuel dispenser','Approval of Pattern '),(98,'Weigh Bridges ',300000.00,'2013-03-13','04:17:09',6,29,1,1,'2013-03-13','Weigh Bridges ','Approval of Pattern '),(99,'Vending Machines',50000.00,'2013-03-13','04:17:09',6,30,1,1,'2013-03-13','Vending Machines','Approval of Pattern '),(100,'ATM Machines',750000.00,'2013-03-13','04:17:09',6,31,1,1,'2013-03-13','ATM Machines','Approval of Pattern '),(101,'Heavy Duty Notes Counting Machines ',350000.00,'2013-03-13','04:17:09',6,32,1,1,'2013-03-13','Heavy Duty Notes Counting Machines ','Approval of Pattern '),(102,'Other Notes Counting Machines',50000.00,'2013-03-13','04:17:09',6,33,1,1,'2013-03-13','Other Notes Counting Machines','Approval of Pattern '),(103,'Taxi Meters',25000.00,'2013-03-13','04:17:10',6,34,1,1,'2013-03-13','Taxi Meters','Approval of Pattern '),(104,'Water meters',150000.00,'2013-03-13','04:17:10',6,35,1,1,'2013-03-13','Water meters','Approval of Pattern '),(105,'Electricity Meters',150000.00,'2013-03-13','04:17:10',6,36,1,1,'2013-03-13','Electricity Meters','Approval of Pattern '),(106,'Gas Meters',250000.00,'2013-03-13','04:17:10',6,37,1,1,'2013-03-13','Gas Meters','Approval of Pattern '),(107,'Tank Gauging Systems',250000.00,'2013-03-13','04:17:10',6,38,1,1,'2013-03-13','Tank Gauging Systems','Approval of Pattern '),(108,'Clocking Machine',50000.00,'2013-03-13','04:17:10',6,39,1,1,'2013-03-13','Clocking Machine','Approval of Pattern '),(109,'Gaming machine',200000.00,'2013-03-13','04:17:10',6,40,1,1,'2013-03-13','Gaming machine','Approval of Pattern '),(110,'Telecommunication Reference Clocks',200000.00,'2013-03-13','04:17:10',6,41,1,1,'2013-03-13','Telecommunication Reference Clocks','Approval of Pattern '),(111,'Each Device capacity not exceeding 250,000 subscribers ',450000.00,'2013-03-13','04:17:10',6,42,1,1,'2013-03-13','Telecommunication Metering Systems','Approval of Pattern '),(112,'Each Device capacity above 250,000 subscribers',750000.00,'2013-03-13','04:17:11',6,42,1,1,'2013-03-13','Telecommunication Metering Systems','Approval of Pattern '),(113,'Each Device capacity not exceeding 250,000 subscribers ',550000.00,'2013-03-13','04:17:11',6,43,1,1,'2013-03-13','Telecommunication Billing Systems','Approval of Pattern '),(114,'Each Device capacity above 250,000 subscribers',950000.00,'2013-03-13','04:17:11',6,43,1,1,'2013-03-13','Telecommunication Billing Systems','Approval of Pattern '),(115,'',7500.00,'2013-03-13','04:17:11',7,44,1,1,'2013-03-13','Vehicles or measures used for the carriage for sale of sand, gravel, shingle, clinker of any description, granite and  other chipping and other materials commonly used in building ,civil engineering industries as hard -core or aggregate','Other Measuring Instruments'),(116,'Vending Machines other than ATMs',5500.00,'2013-03-13','04:17:11',7,45,1,1,'2013-03-13','Vending Machines other than ATMs','Other Measuring Instruments'),(117,'Taxi Meters',5000.00,'2013-03-13','04:17:11',7,34,1,1,'2013-03-13','Taxi Meters','Other Measuring Instruments'),(118,'ATM Machines',55000.00,'2013-03-13','04:17:11',7,31,1,1,'2013-03-13','ATM Machines','Other Measuring Instruments'),(119,'Water meters',5000.00,'2013-03-13','04:17:11',7,35,1,1,'2013-03-13','Water meters','Other Measuring Instruments'),(120,'Electricity Meters',5000.00,'2013-03-13','04:17:11',7,36,1,1,'2013-03-13','Electricity Meters','Other Measuring Instruments'),(121,'Tank Gauging Systems',25000.00,'2013-03-13','04:17:12',7,38,1,1,'2013-03-13','Tank Gauging Systems','Other Measuring Instruments'),(122,'CNG/LNG/LPG Dispensers',20000.00,'2013-03-13','04:17:12',7,51,1,1,'2013-03-13','CNG/LNG/LPG Dispensers','Other Measuring Instruments'),(123,'Standards and equipment under section 5 of the weights and Measures Act1974 ',5000.00,'2013-03-13','04:17:12',7,52,1,1,'2013-03-13','Standards and equipment under section 5 of the weights and Measures Act1974 ','Other Measuring Instruments'),(124,'Clocking Machine',5000.00,'2013-03-13','04:17:12',7,39,1,1,'2013-03-13','Clocking Machine','Other Measuring Instruments'),(125,'Gaming machine',10000.00,'2013-03-13','04:17:12',7,40,1,1,'2013-03-13','Gaming machine','Other Measuring Instruments'),(126,'Scanners',5000.00,'2013-03-13','04:17:12',7,55,1,1,'2013-03-13','Scanners','Other Measuring Instruments'),(127,'Heavy Duty Notes Counting Machines',25750.00,'2013-03-13','04:17:13',7,32,1,1,'2013-03-13','Heavy Duty Notes Counting Machines','Other Measuring Instruments'),(128,'Other Notes Counting Machines',5000.00,'2013-03-13','04:17:13',7,33,1,1,'2013-03-13','Other Notes Counting Machines','Other Measuring Instruments'),(129,'Moulds',5000.00,'2013-03-13','04:17:13',7,58,1,1,'2013-03-13','Moulds','Other Measuring Instruments'),(130,'Below 5kg, each weight',500.00,'2013-03-13','04:17:13',8,59,1,1,'2013-03-13','Weights','Adjusting Fees'),(131,'5kg and above each weight',1250.00,'2013-03-13','04:17:13',8,59,1,1,'2013-03-13','Weights','Adjusting Fees'),(132,'Not exceeding one litre each  measure',1250.00,'2013-03-13','04:17:13',8,60,1,1,'2013-03-13','Measures Capacity:','Adjusting Fees'),(133,'Above one litre, each measure',2500.00,'2013-03-13','04:17:13',8,60,1,1,'2013-03-13','Measures Capacity:','Adjusting Fees'),(134,'Balancing each instrument',1000.00,'2013-03-13','04:17:13',8,61,1,1,'2013-03-13','Weighing Instrument;','Adjusting Fees'),(135,'Adjusting of solid poise',1250.00,'2013-03-13','04:17:13',8,61,1,1,'2013-03-13','Weighing Instrument;','Adjusting Fees'),(136,'Adjusting of counter poise weighs, each weight',500.00,'2013-03-13','04:17:13',8,61,1,1,'2013-03-13','Weighing Instrument;','Adjusting Fees'),(137,'Fitting of stamping plug or seal',1250.00,'2013-03-13','04:17:14',8,61,1,1,'2013-03-13','Weighing Instrument;','Adjusting Fees'),(138,'Adjustment of measure delivered, each instrument',1250.00,'2013-03-13','04:17:14',8,62,1,1,'2013-03-13','Measuring instrument used for the measurement of liquid fuel, lubricating oil, liquor and other liquid','Adjusting Fees'),(139,'Not exceeding 100litres ',5000.00,'2013-03-13','04:17:14',9,63,1,1,'2013-03-13','Prover Tanks','Weights, Measures, Weighing and Measuring  Instruments used for the Bulk measurement of Liquid fuel, lubricating oil, liquor and soft drinks'),(140,'Above 100 litres but not exceeding 500 litres',10000.00,'2013-03-13','04:17:14',9,63,1,1,'2013-03-13','Prover Tanks','Weights, Measures, Weighing and Measuring  Instruments used for the Bulk measurement of Liquid fuel, lubricating oil, liquor and soft drinks'),(141,'Above 500 litres, first 500 litres',12500.00,'2013-03-13','04:17:14',9,63,1,1,'2013-03-13','Prover Tanks','Weights, Measures, Weighing and Measuring  Instruments used for the Bulk measurement of Liquid fuel, lubricating oil, liquor and soft drinks'),(142,'Every additional 100 litres or part there of',1250.00,'2013-03-13','04:17:14',9,63,1,1,'2013-03-13','Prover Tanks','Weights, Measures, Weighing and Measuring  Instruments used for the Bulk measurement of Liquid fuel, lubricating oil, liquor and soft drinks'),(143,'Pressure tester',10000.00,'2013-03-13','04:17:14',9,64,1,1,'2013-03-13','Others','Weights, Measures, Weighing and Measuring  Instruments used for the Bulk measurement of Liquid fuel, lubricating oil, liquor and soft drinks'),(144,'Master Meter',25000.00,'2013-03-13','04:17:14',9,64,1,1,'2013-03-13','Others','Weights, Measures, Weighing and Measuring  Instruments used for the Bulk measurement of Liquid fuel, lubricating oil, liquor and soft drinks'),(145,'Turbine Meter',25000.00,'2013-03-13','04:17:14',9,64,1,1,'2013-03-13','Others','Weights, Measures, Weighing and Measuring  Instruments used for the Bulk measurement of Liquid fuel, lubricating oil, liquor and soft drinks'),(146,'Prover loops',25000.00,'2013-03-13','04:17:14',9,64,1,1,'2013-03-13','Others','Weights, Measures, Weighing and Measuring  Instruments used for the Bulk measurement of Liquid fuel, lubricating oil, liquor and soft drinks'),(147,'Reference Thermometers',5000.00,'2013-03-13','04:17:14',9,64,1,1,'2013-03-13','Others','Weights, Measures, Weighing and Measuring  Instruments used for the Bulk measurement of Liquid fuel, lubricating oil, liquor and soft drinks'),(148,'Hydrometers',2500.00,'2013-03-13','04:17:14',9,64,1,1,'2013-03-13','Others','Weights, Measures, Weighing and Measuring  Instruments used for the Bulk measurement of Liquid fuel, lubricating oil, liquor and soft drinks'),(149,'Decade Boxes',5000.00,'2013-03-13','04:17:14',9,64,1,1,'2013-03-13','Others','Weights, Measures, Weighing and Measuring  Instruments used for the Bulk measurement of Liquid fuel, lubricating oil, liquor and soft drinks'),(150,'Dipping Tapes',5000.00,'2013-03-13','04:17:15',9,64,1,1,'2013-03-13','Others','Weights, Measures, Weighing and Measuring  Instruments used for the Bulk measurement of Liquid fuel, lubricating oil, liquor and soft drinks'),(151,'Pressure Gauges',2500.00,'2013-03-13','04:17:15',9,64,1,1,'2013-03-13','Others','Weights, Measures, Weighing and Measuring  Instruments used for the Bulk measurement of Liquid fuel, lubricating oil, liquor and soft drinks'),(152,'Water Draw Systems',25000.00,'2013-03-13','04:17:15',9,64,1,1,'2013-03-13','Others','Weights, Measures, Weighing and Measuring  Instruments used for the Bulk measurement of Liquid fuel, lubricating oil, liquor and soft drinks'),(153,'Not exceeding Five litters',200.00,'2013-03-13','04:17:15',9,65,1,1,'2013-03-13','Device Manufacturers Rated Capacity','Weights, Measures, Weighing and Measuring  Instruments used for the Bulk measurement of Liquid fuel, lubricating oil, liquor and soft drinks'),(154,'Exceeding  Five liters ',1500.00,'2013-03-13','04:17:15',9,66,1,1,'2013-03-13','Indigenous Measures','Weights, Measures, Weighing and Measuring  Instruments used for the Bulk measurement of Liquid fuel, lubricating oil, liquor and soft drinks');

/*Trigger structure for table `feetable` */

DELIMITER $$;

DROP TRIGGER `feetable_insert_trigger`$$

CREATE TRIGGER `feetable_insert_trigger` BEFORE INSERT ON `feetable` FOR EACH ROW BEGIN
SET NEW.regDate=now();
SET NEW.regTime=now();
END$$


DROP TRIGGER `feetable_update_trigger`$$

CREATE TRIGGER `feetable_update_trigger` BEFORE UPDATE ON `feetable` FOR EACH ROW BEGIN
SET NEW.userIdModify=NEW.userID;
SET NEW.regDateModify=NEW.regDate;
SET NEW.userID=OLD.userID;
SET NEW.regDate=OLD.regDate;
END$$


DELIMITER ;$$

/*Table structure for table `licenseandrenewalfees` */

DROP TABLE IF EXISTS `licenseandrenewalfees`;

CREATE TABLE `licenseandrenewalfees` (
  `sysID` int(11) NOT NULL auto_increment,
  `Description` varchar(5000) default ' ',
  `Fees` double(30,2) default '0.00',
  `recordStatus` tinyint(4) default '0',
  `userID` int(11) default '0',
  `userIdModify` int(11) default '0',
  `regDateModify` date default '0000-00-00',
  `regDate` date default '0000-00-00',
  PRIMARY KEY  (`sysID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `licenseandrenewalfees` */

/*Trigger structure for table `licenseandrenewalfees` */

DELIMITER $$;

DROP TRIGGER `licenseandrenewalfees_insert_trigger`$$

CREATE TRIGGER `licenseandrenewalfees_insert_trigger` BEFORE INSERT ON `licenseandrenewalfees` FOR EACH ROW BEGIN
SET NEW.regDate=now();
END$$


DROP TRIGGER `licenseandrenewalfees_update_trigger`$$

CREATE TRIGGER `licenseandrenewalfees_update_trigger` BEFORE UPDATE ON `licenseandrenewalfees` FOR EACH ROW BEGIN
SET NEW.userIdModify=NEW.userID;
SET NEW.regDateModify=NEW.regDate;
SET NEW.userID=OLD.userID;
SET NEW.regDate=OLD.regDate;
END$$


DELIMITER ;$$

/*Table structure for table `paymentsheet` */

DROP TABLE IF EXISTS `paymentsheet`;

CREATE TABLE `paymentsheet` (
  `sysID` int(11) NOT NULL auto_increment,
  `companyID` int(11) default '0',
  `amountDue` double(30,2) default '0.00',
  `AmountPaid` double(30,2) default '0.00',
  `regDate` date default '0000-00-00',
  `regTime` time default '00:00:00',
  `narration` varchar(300) default ' ',
  `paymentName` varchar(200) default ' ',
  `accStatus` tinyint(4) default '0',
  `cancelNarration` varchar(4000) default ' ',
  `OrderId` varchar(200) default ' ',
  `paidDate` date default '0000-00-00',
  `paidTime` time default '00:00:00',
  `deviceSerial` varchar(100) default ' ',
  `regModifyDate` date default '0000-00-00',
  `UserID` int(11) default '0',
  `userIdModify` int(11) default '0',
  PRIMARY KEY  (`sysID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `paymentsheet` */

insert into `paymentsheet` (`sysID`,`companyID`,`amountDue`,`AmountPaid`,`regDate`,`regTime`,`narration`,`paymentName`,`accStatus`,`cancelNarration`,`OrderId`,`paidDate`,`paidTime`,`deviceSerial`,`regModifyDate`,`UserID`,`userIdModify`) values (1,1,20000.00,0.00,'2013-03-13','17:07:51','Company Registration','',0,'','7713948713','0000-00-00','00:00:00',' ','2013-03-13',0,0),(2,1,50000.00,0.00,'2013-03-13','17:34:40','Device Registration','Cyprosoft CodeSolution Nig. Ltd',0,' ','6959303987','0000-00-00','00:00:00','867','0000-00-00',0,0),(3,1,1250.00,0.00,'2013-03-13','17:37:16','Device Registration','Cyprosoft CodeSolution Nig. Ltd',0,' ','1545009051','0000-00-00','00:00:00','99','0000-00-00',0,0),(4,1,26000.00,0.00,'2013-03-13','17:37:33','Device Registration','Cyprosoft CodeSolution Nig. Ltd',0,' ','2077185126','0000-00-00','00:00:00','890908-0988','0000-00-00',0,0),(5,1,1250.00,0.00,'2013-03-13','17:37:44','Device Registration','Cyprosoft CodeSolution Nig. Ltd',0,' ','6607595714','0000-00-00','00:00:00','888','0000-00-00',0,0);

/*Trigger structure for table `paymentsheet` */

DELIMITER $$;

DROP TRIGGER `paymentsheet_insert_trigger`$$

CREATE TRIGGER `paymentsheet_insert_trigger` BEFORE INSERT ON `paymentsheet` FOR EACH ROW BEGIN
SET NEW.regDate=now();
SET NEW.regTime=now();
END$$


DROP TRIGGER `paymentsheet_update_trigger`$$

CREATE TRIGGER `paymentsheet_update_trigger` BEFORE UPDATE ON `paymentsheet` FOR EACH ROW BEGIN
SET NEW.userIdModify=NEW.userID;
SET NEW.regModifyDate=NEW.regDate;
SET NEW.userID=OLD.userID;
SET NEW.regDate=OLD.regDate;
END$$


DELIMITER ;$$

/*Table structure for table `securitydeposit` */

DROP TABLE IF EXISTS `securitydeposit`;

CREATE TABLE `securitydeposit` (
  `sysID` int(11) NOT NULL auto_increment,
  `sDeposit` double(30,2) default '0.00',
  `description` varchar(5000) default ' ',
  `recordStatus` tinyint(4) default '0',
  `UserID` int(11) default '0',
  `userIdModify` int(11) default '0',
  `regDateModify` date default '0000-00-00',
  `regDate` date default '0000-00-00',
  `regTime` time default '00:00:00',
  PRIMARY KEY  (`sysID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `securitydeposit` */

/*Trigger structure for table `securitydeposit` */

DELIMITER $$;

DROP TRIGGER `securitydeposit_insert_trigger`$$

CREATE TRIGGER `securitydeposit_insert_trigger` BEFORE INSERT ON `securitydeposit` FOR EACH ROW BEGIN
SET NEW.regDate=now();
SET NEW.regTime=now();
END$$


DROP TRIGGER `securitydeposit_update_trigger`$$

CREATE TRIGGER `securitydeposit_update_trigger` BEFORE UPDATE ON `securitydeposit` FOR EACH ROW BEGIN
SET NEW.userIdModify=NEW.userID;
SET NEW.regDateModify=NEW.regDate;
SET NEW.userID=OLD.userID;
SET NEW.regDate=OLD.regDate;
END$$


DELIMITER ;$$

/*Table structure for table `systemusers` */

DROP TABLE IF EXISTS `systemusers`;

CREATE TABLE `systemusers` (
  `sysID` int(11) NOT NULL auto_increment,
  `username` varchar(200) default ' ',
  `userpwd` varchar(400) default ' ',
  `Surname` varchar(100) default ' ',
  `firstname` varchar(100) default ' ',
  `othernames` varchar(100) default ' ',
  `phone` varchar(100) default ' ',
  `email` varchar(100) default ' ',
  `sysadminright` tinyint(4) default '0',
  `operatorright` tinyint(4) default '0',
  `systemMonitorright` tinyint(4) default '0',
  `recordstatus` tinyint(4) default '0',
  `reportRight` tinyint(4) default '0',
  `staticdataright` tinyint(4) default '0',
  `companymgtright` tinyint(4) default '0',
  `monitorOperatorOnlyright` tinyint(4) default '0',
  `auditright` tinyint(4) default '0',
  `securityquestion` varchar(300) default ' ',
  `securityAnswer` varchar(300) default ' ',
  PRIMARY KEY  (`sysID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `systemusers` */

/*Table structure for table `tblcity` */

DROP TABLE IF EXISTS `tblcity`;

CREATE TABLE `tblcity` (
  `sysID` int(11) NOT NULL auto_increment,
  `city` varchar(200) default ' ',
  PRIMARY KEY  (`sysID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `tblcity` */

insert into `tblcity` (`sysID`,`city`) values (1,'Aba'),(2,'Abakaliki'),(3,'Abeokuta'),(4,'Abuja'),(5,'Akure'),(6,'Asaba'),(7,'Anambra'),(8,'Awka'),(9,'Bauchi'),(10,'Benin City'),(11,'Birnin Kebbi'),(12,'Calabar'),(13,'Dutse'),(14,'Eket'),(15,'Enugu'),(16,'Gombe'),(17,'Gusau'),(18,'Ibadan'),(19,'Ife'),(20,'Ikeja'),(21,'Ikot-Abasi'),(22,'Ikot Ekpene'),(23,'Ikoyi'),(24,'Ilorin'),(25,'Jalingo'),(26,'Jimeta'),(27,'Jos'),(28,'Kaduna'),(29,'Kano'),(30,'Katsina'),(31,'Karu'),(32,'Kumariya'),(33,'Lafia'),(34,'Lagos'),(35,'Lokoja'),(36,'Maiduguri'),(37,'Makurdi'),(38,'Minna'),(39,'Nsukka'),(40,'Ogbomoso'),(41,'Onitsha'),(42,'Oron'),(43,'Oshogbo'),(44,'Owerri'),(45,'Owo'),(46,'Oyo'),(47,'Port Harcourt'),(48,'Potiskum'),(49,'Sokoto'),(50,'Suleja'),(51,'Umuahia'),(52,'Uyo'),(53,'Warri'),(54,'Wukari'),(55,'Yenagoa'),(56,'Yola'),(57,'Zaria');

/*Table structure for table `tbllga` */

DROP TABLE IF EXISTS `tbllga`;

CREATE TABLE `tbllga` (
  `sysID` int(11) NOT NULL auto_increment,
  `LGA` varchar(200) default ' ',
  `stateID` int(11) default '0',
  PRIMARY KEY  (`sysID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `tbllga` */

insert into `tbllga` (`sysID`,`LGA`,`stateID`) values (1,'Abadam',8),(2,'Abaji',15),(3,'Abak',3),(4,'Abakaliki',11),(5,'Aba North',1),(6,'Aba South',1),(7,'Abeokuta North',28),(8,'Abeokuta South',28),(9,'Abi',9),(10,'Aboh Mbaise',17),(11,'Abua/Odual',33),(12,'Adavi',23),(13,'Ado Ekiti',13),(14,'Ado-Odo/Ota',28),(15,'Afijio',31),(16,'Afikpo North',11),(17,'Afikpo South',11),(18,'Agaie',27),(19,'Agatu',7),(20,'Agwara',27),(21,'Agege',25),(22,'Aguata',4),(23,'Ahiazu Mbaise',17),(24,'Ahoada East',33),(25,'Ahoada West',33),(26,'Ajaokuta',23),(27,'Ajeromi-Ifelodun',25),(28,'Ajingi',20),(29,'Akamkpa',9),(30,'Akinyele',31),(31,'Akko',16),(32,'Akoko-Edo',12),(33,'Akoko North-East',29),(34,'Akoko North-West',29),(35,'Akoko South-West',29),(36,'Akoko South-East',29),(37,'Akpabuyo',9),(38,'Akuku-Toru',33),(39,'Akure North',29),(40,'Akure South',29),(41,'Akwanga',26),(42,'Albasu',20),(43,'Aleiro',22),(44,'Alimosho',25),(45,'Alkaleri',5),(46,'Amuwo-Odofin',25),(47,'Anambra East',4),(48,'Anambra West',4),(49,'Anaocha',4),(50,'Andoni',33),(51,'Aninri',14),(52,'Aniocha North',10),(53,'Aniocha South',10),(54,'Anka',37),(55,'Ankpa',23),(56,'Apa',7),(57,'Apapa',25),(58,'Ado',7),(59,'Ardo Kola',35),(60,'Arewa Dandi',22),(61,'Argungu',22),(62,'Arochukwu',1),(63,'Asa',24),(64,'Asari-Toru',33),(65,'Askira/Uba',8),(66,'Atakunmosa East',30),(67,'Atakunmosa West',30),(68,'Atiba',31),(69,'Atisbo',31),(70,'Augie',22),(71,'Auyo',18),(72,'Awe',26),(73,'Awgu',14),(74,'Awka North',4),(75,'Awka South',4),(76,'Ayamelum',4),(77,'Aiyedaade',30),(78,'Aiyedire',30),(79,'Babura',18),(80,'Badagry',25),(81,'Bagudo',22),(82,'Bagwai',20),(83,'Bakassi',9),(84,'Bokkos',32),(85,'Bakori',21),(86,'Bakura',37),(87,'Balanga',16),(88,'Bali',35),(89,'Bama',8),(90,'Bade',36),(91,'Barkin Ladi',32),(92,'Baruten',24),(93,'Bassa',23),(94,'Bassa',32),(95,'Batagarawa',21),(96,'Batsari',21),(97,'Bauchi',5),(98,'Baure',21),(99,'Bayo',8),(100,'Bebeji',20),(101,'Bekwarra',9),(102,'Bende',1),(103,'Biase',9),(104,'Bichi',20),(105,'Bida',27),(106,'Billiri',16),(107,'Bindawa',21),(108,'Binji',34),(109,'Biriniwa',18),(110,'Birnin Gwari',19),(111,'Birnin Kebbi',22),(112,'Birnin Kudu',18),(113,'Birnin Magaji/Kiyaw',37),(114,'Biu',8),(115,'Bodinga',34),(116,'Bogoro',5),(117,'Boki',9),(118,'Boluwaduro',30),(119,'Bomadi',10),(120,'Bonny',33),(121,'Borgu',27),(122,'Boripe',30),(123,'Bursari',36),(124,'Bosso',27),(125,'Brass',6),(126,'Buji',18),(127,'Bukkuyum',37),(128,'Buruku',7),(129,'Bungudu',37),(130,'Bunkure',20),(131,'Bunza',22),(132,'Burutu',10),(133,'Bwari',15),(134,'Calabar Municipal',9),(135,'Calabar South',9),(136,'Chanchaga',27),(137,'Charanchi',21),(138,'Chibok',8),(139,'Chikun',19),(140,'Dala',20),(141,'Damaturu',36),(142,'Damban',5),(143,'Dambatta',20),(144,'Damboa',8),(145,'Dandi',22),(146,'Dandume',21),(147,'Dange Shuni',34),(148,'Danja',21),(149,'Dan Musa',21),(150,'Darazo',5),(151,'Dass',5),(152,'Daura',21),(153,'Dawakin Kudu',20),(154,'Dawakin Tofa',20),(155,'Degema',33),(156,'Dekina',23),(157,'Demsa',2),(158,'Dikwa',8),(159,'Doguwa',20),(160,'Doma',26),(161,'Donga',35),(162,'Dukku',16),(163,'Dunukofia',4),(164,'Dutse',18),(165,'Dutsi',21),(166,'Dutsin Ma',21),(167,'Eastern Obolo',3),(168,'Ebonyi',11),(169,'Edati',27),(170,'Ede North',30),(171,'Ede South',30),(172,'Edu',24),(173,'Ife Central',30),(174,'Ife East',30),(175,'Ife North',30),(176,'Ife South',30),(177,'Efon',13),(178,'Egbado North',28),(179,'Egbado South',28),(180,'Egbeda',31),(181,'Egbedore',30),(182,'Egor',12),(183,'Ehime Mbano',17),(184,'Ejigbo',30),(185,'Ekeremor',6),(186,'Eket',3),(187,'Ekiti, Kwara State',24),(188,'Ekiti East',13),(189,'Ekiti South-West',13),(190,'Ekiti West',13),(191,'Ekwusigo',4),(192,'Eleme',33),(193,'Emuoha',33),(194,'Emure',13),(195,'Enugu East',14),(196,'Enugu North',14),(197,'Enugu South',14),(198,'Epe',25),(199,'Esan Central',12),(200,'Esan North-East',12),(201,'Esan South-East',12),(202,'Esan West',12),(203,'Ese Odo',29),(204,'Esit Eket',3),(205,'Essien Udim',3),(206,'Etche',33),(207,'Ethiope East',10),(208,'Ethiope West',10),(209,'Etim Ekpo',3),(210,'Etinan',3),(211,'Eti Osa',25),(212,'Etsako Central',12),(213,'Etsako East',12),(214,'Etsako West',12),(215,'Etung',9),(216,'Ewekoro',28),(217,'Ezeagu',14),(218,'Ezinihitte',17),(219,'Ezza North',11),(220,'Ezza South',11),(221,'Fagge',20),(222,'Fakai',22),(223,'Faskari',21),(224,'Fika',36),(225,'Fufure',2),(226,'Funakaye',16),(227,'Fune',36),(228,'Funtua',21),(229,'Gabasawa',20),(230,'Gada',34),(231,'Gagarawa',18),(232,'Gamawa',5),(233,'Ganjuwa',5),(234,'Ganye',2),(235,'Garki',18),(236,'Garko',20),(237,'Garun Mallam',20),(238,'Gashaka',35),(239,'Gassol',35),(240,'Gaya',20),(241,'Gayuk',2),(242,'Gezawa',20),(243,'Gbako',27),(244,'Gboko',7),(245,'Gbonyin',13),(246,'Geidam',36),(247,'Giade',5),(248,'Giwa',19),(249,'Gokana',33),(250,'Gombe',16),(251,'Gombi',2),(252,'Goronyo',34),(253,'Grie',2),(254,'Gubio',8),(255,'Gudu',34),(256,'Gujba',36),(257,'Gulani',36),(258,'Guma',7),(259,'Gumel',18),(260,'Gummi',37),(261,'Gurara',27),(262,'Guri',18),(263,'Gusau',37),(264,'Guzamala',8),(265,'Gwadabawa',34),(266,'Gwagwalada',15),(267,'Gwale',20),(268,'Gwandu',22),(269,'Gwaram',18),(270,'Gwarzo',20),(271,'Gwer East',7),(272,'Gwer West',7),(273,'Gwiwa',18),(274,'Gwoza',8),(275,'Hadejia',18),(276,'Hawul',8),(277,'Hong',2),(278,'Ibadan North',31),(279,'Ibadan North-East',31),(280,'Ibadan North-West',31),(281,'Ibadan South-East',31),(282,'Ibadan South-West',31),(283,'Ibaji',23),(284,'Ibarapa Central',31),(285,'Ibarapa East',31),(286,'Ibarapa North',31),(287,'Ibeju-Lekki',25),(288,'Ibeno',3),(289,'Ibesikpo Asutan',3),(290,'Ibi',35),(291,'Ibiono-Ibom',3),(292,'Idah',23),(293,'Idanre',29),(294,'Ideato North',17),(295,'Ideato South',17),(296,'Idemili North',4),(297,'Idemili South',4),(298,'Ido',31),(299,'Ido Osi',13),(300,'Ifako-Ijaiye',25),(301,'Ifedayo',30),(302,'Ifedore',29),(303,'Ifelodun',24),(304,'Ifelodun',30),(305,'Ifo',28),(306,'Igabi',19),(307,'Igalamela Odolu',23),(308,'Igbo Etiti',14),(309,'Igbo Eze North',14),(310,'Igbo Eze South',14),(311,'Igueben',12),(312,'Ihiala',4),(313,'Ihitte/Uboma',17),(314,'Ilaje',29),(315,'Ijebu East',28),(316,'Ijebu North',28),(317,'Ijebu North East',28),(318,'Ijebu Ode',28),(319,'Ijero',13),(320,'Ijumu',23),(321,'Ika',3),(322,'Ika North East',10),(323,'Ikara',19),(324,'Ika South',10),(325,'Ikeduru',17),(326,'Ikeja',25),(327,'Ikenne',28),(328,'Ikere',13),(329,'Ikole',13),(330,'Ikom',9),(331,'Ikono',3),(332,'Ikorodu',25),(333,'Ikot Abasi',3),(334,'Ikot Ekpene',3),(335,'Ikpoba Okha',12),(336,'Ikwerre',33),(337,'Ikwo',11),(338,'Ikwuano',1),(339,'Ila',30),(340,'Ilejemeje',13),(341,'Ile Oluji/Okeigbo',29),(342,'Ilesa East',30),(343,'Ilesa West',30),(344,'Illela',34),(345,'Ilorin East',24),(346,'Ilorin South',24),(347,'Ilorin West',24),(348,'Imeko Afon',28),(349,'Ingawa',21),(350,'Ini',3),(351,'Ipokia',28),(352,'Irele',29),(353,'Irepo',31),(354,'Irepodun',30),(355,'Irepodun',24),(356,'Irepodun/Ifelodun',13),(357,'Irewole',30),(358,'Isa',34),(359,'Ise/Orun',13),(360,'Iseyin',31),(361,'Ishielu',11),(362,'Isiala Mbano',17),(363,'Isiala Ngwa North',1),(364,'Isiala Ngwa South',1),(365,'Isin',24),(366,'Isi Uzo',14),(367,'Isokan',30),(368,'Isoko North',10),(369,'Isoko South',10),(370,'Isu',17),(371,'Isuikwuato',1),(372,'Itas/Gadau',5),(373,'Itesiwaju',31),(374,'Itu',3),(375,'Ivo',11),(376,'Iwajowa',31),(377,'Iwo',30),(378,'Izzi',11),(379,'Jaba',19),(380,'Jada',2),(381,'Jahun',18),(382,'Jakusko',36),(383,'Jalingo',35),(384,'Jama\'are',5),(385,'Jega',22),(386,'Jema\'a',19),(387,'Jere',8),(388,'Jibia',21),(389,'Jos East',32),(390,'Jos North',32),(391,'Jos South',32),(392,'Kabba/Bunu',23),(393,'Kabo',20),(394,'Kachia',19),(395,'Kaduna North',19),(396,'Kaduna South',19),(397,'Kafin Hausa',18),(398,'Kafur',21),(399,'Kaga',8),(400,'Kagarko',19),(401,'Kaiama',24),(402,'Kaita',21),(403,'Kajola',31),(404,'Kajuru',19),(405,'Kala/Balge',8),(406,'Kalgo',22),(407,'Kaltungo',16),(408,'Kanam',32),(409,'Kankara',21),(410,'Kanke',32),(411,'Kankia',21),(412,'Kano Municipal',20),(413,'Karasuwa',36),(414,'Karaye',20),(415,'Karim Lamido',35),(416,'Karu',26),(417,'Katagum',5),(418,'Katcha',27),(419,'Katsina',21),(420,'Katsina-Ala',7),(421,'Kaura',19),(422,'Kaura Namoda',37),(423,'Kauru',19),(424,'Kazaure',18),(425,'Keana',26),(426,'Kebbe',34),(427,'Keffi',26),(428,'Khana',33),(429,'Kibiya',20),(430,'Kirfi',5),(431,'Kiri Kasama',18),(432,'Kiru',20),(433,'Kiyawa',18),(434,'Kogi',23),(435,'Koko/Besse',22),(436,'Kokona',26),(437,'Kolokuma/Opokuma',6),(438,'Konduga',8),(439,'Konshisha',7),(440,'Kontagora',27),(441,'Kosofe',25),(442,'Kaugama',18),(443,'Kubau',19),(444,'Kudan',19),(445,'Kuje',15),(446,'Kukawa',8),(447,'Kumbotso',20),(448,'Kumi',35),(449,'Kunchi',20),(450,'Kura',20),(451,'Kurfi',21),(452,'Kusada',21),(453,'Kwali',15),(454,'Kwande',7),(455,'Kwami',16),(456,'Kware',34),(457,'Kwaya Kusar',8),(458,'Lafia',26),(459,'Lagelu',31),(460,'Lagos Island',25),(461,'Lagos Mainland',25),(462,'Langtang South',32),(463,'Langtang North',32),(464,'Lapai',27),(465,'Larmurde',2),(466,'Lau',35),(467,'Lavun',27),(468,'Lere',19),(469,'Logo',7),(470,'Lokoja',23),(471,'Machina',36),(472,'Madagali',2),(473,'Madobi',20),(474,'Mafa',8),(475,'Magama',27),(476,'Magumeri',8),(477,'Mai\'Adua',21),(478,'Maiduguri',8),(479,'Maigatari',18),(480,'Maiha',2),(481,'Maiyama',22),(482,'Makarfi',19),(483,'Makoda',20),(484,'Malam Madori',18),(485,'Malumfashi',21),(486,'Mangu',32),(487,'Mani',21),(488,'Maradun',37),(489,'Mariga',27),(490,'Makurdi',7),(491,'Marte',8),(492,'Maru',37),(493,'Mashegu',27),(494,'Mashi',21),(495,'Matazu',21),(496,'Mayo Belwa',2),(497,'Mbaitoli',17),(498,'Mbo',3),(499,'Michika',2),(500,'Miga',18),(501,'Mikang',32),(502,'Minjibir',20),(503,'Misau',5),(504,'Moba',13),(505,'Mobbar',8),(506,'Mubi North',2),(507,'Mubi South',2),(508,'Mokwa',27),(509,'Monguno',8),(510,'Mopa Muro',23),(511,'Moro',24),(512,'Moya',27),(513,'Mkpat-Enin',3),(514,'Municipal Area Council',15),(515,'Musawa',21),(516,'Mushin',25),(517,'Nafada',16),(518,'Nangere',36),(519,'Nasarawa',20),(520,'Nasarawa',26),(521,'Nasarawa Egon',26),(522,'Ndokwa East',10),(523,'Ndokwa West',10),(524,'Nembe',6),(525,'Ngala',8),(526,'Nganzai',8),(527,'Ngaski',22),(528,'Ngor Okpala',17),(529,'Nguru',36),(530,'Ningi',5),(531,'Njaba',17),(532,'Njikoka',4),(533,'Nkanu East',14),(534,'Nkanu West',14),(535,'Nkwerre',17),(536,'Nnewi North',4),(537,'Nnewi South',4),(538,'Nsit-Atai',3),(539,'Nsit-Ibom',3),(540,'Nsit-Ubium',3),(541,'Nsukka',14),(542,'Numan',2),(543,'Nwangele',17),(544,'Obafemi Owode',28),(545,'Obanliku',9),(546,'Obi',26),(547,'Obi',7),(548,'Obi Ngwa',1),(549,'Obio/Akpor',33),(550,'Obokun',30),(551,'Obot Akara',3),(552,'Obowo',17),(553,'Obubra',9),(554,'Obudu',9),(555,'Odeda',28),(556,'Odigbo',29),(557,'Odogbolu',28),(558,'Odo Otin',30),(559,'Odukpani',9),(560,'Offa',24),(561,'Ofu',23),(562,'Ogba/Egbema/Ndoni',33),(563,'Ogbadibo',7),(564,'Ogbaru',4),(565,'Ogbia',6),(566,'Ogbomosho North',31),(567,'Ogbomosho South',31),(568,'Ogu/Bolo',33),(569,'Ogoja',9),(570,'Ogo Oluwa',31),(571,'Ogori/Magongo',23),(572,'Ogun Waterside',28),(573,'Oguta',17),(574,'Ohafia',1),(575,'Ohaji/Egbema',17),(576,'Ohaozara',11),(577,'Ohaukwu',11),(578,'Ohimini',7),(579,'Orhionmwon',12),(580,'Oji River',14),(581,'Ojo',25),(582,'Oju',7),(583,'Okehi',23),(584,'Okene',23),(585,'Oke Ero',24),(586,'Okigwe',17),(587,'Okitipupa',29),(588,'Okobo',3),(589,'Okpe',10),(590,'Okrika',33),(591,'Olamaboro',23),(592,'Ola Oluwa',30),(593,'Olorunda',30),(594,'Olorunsogo',31),(595,'Oluyole',31),(596,'Omala',23),(597,'Omuma',33),(598,'Ona Ara',31),(599,'Ondo East',29),(600,'Ondo West',29),(601,'Onicha',11),(602,'Onitsha North',4),(603,'Onitsha South',4),(604,'Onna',3),(605,'Okpokwu',7),(606,'Opobo/Nkoro',33),(607,'Oredo',12),(608,'Orelope',31),(609,'Oriade',30),(610,'Ori Ire',31),(611,'Orlu',17),(612,'Orolu',30),(613,'Oron',3),(614,'Orsu',17),(615,'Oru East',17),(616,'Oruk Anam',3),(617,'Orumba North',4),(618,'Orumba South',4),(619,'Oru West',17),(620,'Ose',29),(621,'Oshimili North',10),(622,'Oshimili South',10),(623,'Oshodi-Isolo',25),(624,'Osisioma',1),(625,'Osogbo',30),(626,'Oturkpo',7),(627,'Ovia North-East',12),(628,'Ovia South-West',12),(629,'Owan East',12),(630,'Owan West',12),(631,'Owerri Municipal',17),(632,'Owerri North',17),(633,'Owerri West',17),(634,'Owo',29),(635,'Oye',13),(636,'Oyi',4),(637,'Oyigbo',33),(638,'Oyo',31),(639,'Oyo East',31),(640,'Oyun',24),(641,'Paikoro',27),(642,'Pankshin',32),(643,'Patani',10),(644,'Pategi',24),(645,'Port Harcourt',33),(646,'Potiskum',36),(647,'Qua\'an Pan',32),(648,'Rabah',34),(649,'Rafi',27),(650,'Rano',20),(651,'Remo North',28),(652,'Rijau',27),(653,'Rimi',21),(654,'Rimin Gado',20),(655,'Ringim',18),(656,'Riyom',32),(657,'Rogo',20),(658,'Roni',18),(659,'Sabon Birni',34),(660,'Sabon Gari',19),(661,'Sabuwa',21),(662,'Safana',21),(663,'Sagbama',6),(664,'Sakaba',22),(665,'Saki East',31),(666,'Saki West',31),(667,'Sandamu',21),(668,'Sanga',19),(669,'Sapele',10),(670,'Sardauna',35),(671,'Shagamu',28),(672,'Shagari',34),(673,'Shanga',22),(674,'Shani',8),(675,'Shanono',20),(676,'Shelleng',2),(677,'Shendam',32),(678,'Shinkafi',37),(679,'Shira',5),(680,'Shiroro',27),(681,'Shongom',16),(682,'Shomolu',25),(683,'Silame',34),(684,'Soba',19),(685,'Sokoto North',34),(686,'Sokoto South',34),(687,'Song',2),(688,'Southern Ijaw',6),(689,'Suleja',27),(690,'Sule Tankarkar',18),(691,'Sumaila',20),(692,'Suru',22),(693,'Surulere, Oyo State',31),(694,'Surulere, Lagos State',25),(695,'Tafa',27),(696,'Tafawa Balewa',5),(697,'Tai',33),(698,'Takai',20),(699,'Takum',35),(700,'Talata Mafara',37),(701,'Tambuwal',34),(702,'Tangaza',34),(703,'Tarauni',20),(704,'Tarka',7),(705,'Tarmuwa',36),(706,'Taura',18),(707,'Toungo',2),(708,'Tofa',20),(709,'Toro',5),(710,'Toto',26),(711,'Chafe',37),(712,'Tsanyawa',20),(713,'Tudun Wada',20),(714,'Tureta',34),(715,'Udenu',14),(716,'Udi',14),(717,'Udu',10),(718,'Udung-Uko',3),(719,'Ughelli North',10),(720,'Ughelli South',10),(721,'Ugwunagbo',1),(722,'Uhunmwonde',12),(723,'Ukanafun',3),(724,'Ukum',7),(725,'Ukwa East',1),(726,'Ukwa West',1),(727,'Ukwuani',10),(728,'Umuahia North',1),(729,'Umuahia South',1),(730,'Umu Nneochi',1),(731,'Ungogo',20),(732,'Unuimo',17),(733,'Uruan',3),(734,'Urue-Offong/Oruko',3),(735,'Ushongo',7),(736,'Ussa',35),(737,'Uvwie',10),(738,'Uyo',3),(739,'Uzo Uwani',14),(740,'Vandeikya',7),(741,'Wamako',34),(742,'Wamba',26),(743,'Warawa',20),(744,'Warji',5),(745,'Warri North',10),(746,'Warri South',10),(747,'Warri South West',10),(748,'Wasagu/Danko',22),(749,'Wase',32),(750,'Wudil',20),(751,'Wukari',35),(752,'Wurno',34),(753,'Wushishi',27),(754,'Yabo',34),(755,'Yagba East',23),(756,'Yagba West',23),(757,'Yakuur',9),(758,'Yala',9),(759,'Yamaltu/Deba',16),(760,'Yankwashi',18),(761,'Yauri',22),(762,'Yenagoa',6),(763,'Yola North',2),(764,'Yola South',2),(765,'Yorro',35),(766,'Yunusari',36),(767,'Yusufari',36),(768,'Zaki',5),(769,'Zango',21),(770,'Zangon Kataf',19),(771,'Zaria',19),(772,'Zing',35),(773,'Zurmi',37),(774,'Zuru',22);

/*Table structure for table `tblstate` */

DROP TABLE IF EXISTS `tblstate`;

CREATE TABLE `tblstate` (
  `sysID` int(11) NOT NULL auto_increment,
  `stateName` varchar(200) default ' ',
  PRIMARY KEY  (`sysID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `tblstate` */

insert into `tblstate` (`sysID`,`stateName`) values (1,'Abia State'),(2,'Adamawa State'),(3,'Akwa Ibom State'),(4,'Anambra State'),(5,'Bauchi State'),(6,'Bayelsa State'),(7,'Benue State'),(8,'Borno State'),(9,'Cross River State'),(10,'Delta State'),(11,'Ebonyi State'),(12,'Edo State'),(13,'Ekiti State'),(14,'Enugu State'),(15,'FCT'),(16,'Gombe State'),(17,'Imo State'),(18,'Jigawa State'),(19,'Kaduna State'),(20,'Kano State'),(21,'Katsina State'),(22,'Kebbi State'),(23,'Kogi State'),(24,'Kwara State'),(25,'Lagos State'),(26,'Nasarawa State'),(27,'Niger State'),(28,'Ogun State'),(29,'Ondo State'),(30,'Osun State'),(31,'Oyo State'),(32,'Plateau State'),(33,'Rivers State'),(34,'Sokoto State'),(35,'Taraba State'),(36,'Yobe State'),(37,'Zamfara State');

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
