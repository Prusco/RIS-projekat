-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: localhost    Database: informacionisistemak
-- ------------------------------------------------------
-- Server version	8.2.0

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `aerodrom`
--

DROP TABLE IF EXISTS `aerodrom`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aerodrom` (
  `idAerodrom` int NOT NULL AUTO_INCREMENT,
  `Ime` varchar(100) NOT NULL,
  `Grad` varchar(100) NOT NULL,
  `idDrzave` int DEFAULT NULL,
  PRIMARY KEY (`idAerodrom`),
  KEY `idDrzave_idx` (`idDrzave`),
  CONSTRAINT `idDrzave` FOREIGN KEY (`idDrzave`) REFERENCES `drzave` (`idDrzave`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aerodrom`
--

LOCK TABLES `aerodrom` WRITE;
/*!40000 ALTER TABLE `aerodrom` DISABLE KEYS */;
INSERT INTO `aerodrom` VALUES (1,'Nikola Tesla','Beograd',182),(2,'Frano Tudman','Zagreb',51),(3,'Unesite Ime Aerodroma','Unesite Grad Aerodroma',12);
/*!40000 ALTER TABLE `aerodrom` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `drzave`
--

DROP TABLE IF EXISTS `drzave`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `drzave` (
  `idDrzave` int NOT NULL AUTO_INCREMENT,
  `NazivDrzave` varchar(100) NOT NULL,
  `Skracenice` varchar(5) NOT NULL,
  PRIMARY KEY (`idDrzave`)
) ENGINE=InnoDB AUTO_INCREMENT=231 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `drzave`
--

LOCK TABLES `drzave` WRITE;
/*!40000 ALTER TABLE `drzave` DISABLE KEYS */;
INSERT INTO `drzave` VALUES (1,'Afghanistan','AF'),(2,'Albania','AL'),(3,'Algeria','DZ'),(4,'American Samoa','AS'),(5,'Andorra','AD'),(6,'Angola','AO'),(7,'Anguilla','AI'),(8,'Antarctica','AQ'),(9,'Antigua and Barbuda','AG'),(10,'Argentina','AR'),(11,'Armenia','AM'),(12,'Aruba','AW'),(13,'Australia','AU'),(14,'Austria','AT'),(15,'Azerbaijan','AZ'),(16,'Bahamas','BS'),(17,'Bahrain','BH'),(18,'Bangladesh','BD'),(19,'Barbados','BB'),(20,'Belarus','BY'),(21,'Belgium','BE'),(22,'Belize','BZ'),(23,'Benin','BJ'),(24,'Bermuda','BM'),(25,'Bhutan','BT'),(26,'Bosnia and Herzegovina','BA'),(27,'Botswana','BW'),(28,'Bouvet Island','BV'),(29,'Brazil','BR'),(30,'British Indian Ocean Territory','IO'),(31,'Brunei Darussalam','BN'),(32,'Bulgaria','BG'),(33,'Burkina Faso','BF'),(34,'Burundi','BI'),(35,'Cambodia','KH'),(36,'Cameroon','CM'),(37,'Canada','CA'),(38,'Cape Verde','CV'),(39,'Cayman Islands','KY'),(40,'Central African Republic','CF'),(41,'Chad','TD'),(42,'Chile','CL'),(43,'China','CN'),(44,'Christmas Island','CX'),(45,'Cocos (Keeling) Islands','CC'),(46,'Colombia','CO'),(47,'Comoros','KM'),(48,'Congo','CG'),(49,'Cook Islands','CK'),(50,'Costa Rica','CR'),(51,'Croatia','HR'),(52,'Cuba','CU'),(53,'Cyprus','CY'),(54,'Czech Republic','CZ'),(55,'Denmark','DK'),(56,'Djibouti','DJ'),(57,'Dominica','DM'),(58,'Dominican Republic','DO'),(59,'Ecuador','EC'),(60,'Egypt','EG'),(61,'El Salvador','SV'),(62,'Equatorial Guinea','GQ'),(63,'Eritrea','ER'),(64,'Estonia','EE'),(65,'Ethiopia','ET'),(66,'Falkland Islands (Malvinas)','FK'),(67,'Faroe Islands','FO'),(68,'Fiji','FJ'),(69,'Finland','FI'),(70,'France','FR'),(71,'French Guiana','GF'),(72,'French Polynesia','PF'),(73,'French Southern Territories','TF'),(74,'Gabon','GA'),(75,'Gambia','GM'),(76,'Georgia','GE'),(77,'Germany','DE'),(78,'Ghana','GH'),(79,'Gibraltar','GI'),(80,'Greece','GR'),(81,'Greenland','GL'),(82,'Grenada','GD'),(83,'Guadeloupe','GP'),(84,'Guam','GU'),(85,'Guatemala','GT'),(86,'Guernsey','GG'),(87,'Guinea','GN'),(88,'Guinea-Bissau','GW'),(89,'Guyana','GY'),(90,'Haiti','HT'),(91,'Heard Island and McDonald Islands','HM'),(92,'Holy See (Vatican City State)','VA'),(93,'Honduras','HN'),(94,'Hong Kong','HK'),(95,'Hungary','HU'),(96,'Iceland','IS'),(97,'India','IN'),(98,'Indonesia','ID'),(99,'Iran','IR'),(100,'Iraq','IQ'),(101,'Ireland','IE'),(102,'Isle of Man','IM'),(103,'Israel','IL'),(104,'Italy','IT'),(105,'Jamaica','JM'),(106,'Japan','JP'),(107,'Jersey','JE'),(108,'Jordan','JO'),(109,'Kazakhstan','KZ'),(110,'Kenya','KE'),(111,'Kiribati','KI'),(112,'Kuwait','KW'),(113,'Kyrgyzstan','KG'),(114,'Lao Peoples Democratic Republic','LA'),(115,'Latvia','LV'),(116,'Lebanon','LB'),(117,'Lesotho','LS'),(118,'Liberia','LR'),(119,'Libya','LY'),(120,'Liechtenstein','LI'),(121,'Lithuania','LT'),(122,'Luxembourg','LU'),(123,'Macao','MO'),(124,'Madagascar','MG'),(125,'Malawi','MW'),(126,'Malaysia','MY'),(127,'Maldives','MV'),(128,'Mali','ML'),(129,'Malta','MT'),(130,'Marshall Islands','MH'),(131,'Martinique','MQ'),(132,'Mauritania','MR'),(133,'Mauritius','MU'),(134,'Mayotte','YT'),(135,'Mexico','MX'),(136,'Monaco','MC'),(137,'Mongolia','MN'),(138,'Montenegro','ME'),(139,'Montserrat','MS'),(140,'Morocco','MA'),(141,'Mozambique','MZ'),(142,'Myanmar','MM'),(143,'Namibia','NA'),(144,'Nauru','NR'),(145,'Nepal','NP'),(146,'Netherlands','NL'),(147,'New Caledonia','NC'),(148,'New Zealand','NZ'),(149,'Nicaragua','NI'),(150,'Niger','NE'),(151,'Nigeria','NG'),(152,'Niue','NU'),(153,'Norfolk Island','NF'),(154,'Northern Mariana Islands','MP'),(155,'Norway','NO'),(156,'Oman','OM'),(157,'Pakistan','PK'),(158,'Palau','PW'),(159,'Panama','PA'),(160,'Papua New Guinea','PG'),(161,'Paraguay','PY'),(162,'Peru','PE'),(163,'Philippines','PH'),(164,'Pitcairn','PN'),(165,'Poland','PL'),(166,'Portugal','PT'),(167,'Puerto Rico','PR'),(168,'Qatar','QA'),(169,'Romania','RO'),(170,'Russian Federation','RU'),(171,'Rwanda','RW'),(172,'Saint Kitts and Nevis','KN'),(173,'Saint Lucia','LC'),(174,'Saint Martin (French part)','MF'),(175,'Saint Pierre and Miquelon','PM'),(176,'Saint Vincent and the Grenadines','VC'),(177,'Samoa','WS'),(178,'San Marino','SM'),(179,'Sao Tome and Principe','ST'),(180,'Saudi Arabia','SA'),(181,'Senegal','SN'),(182,'Serbia','RS'),(183,'Seychelles','SC'),(184,'Sierra Leone','SL'),(185,'Singapore','SG'),(186,'Sint Maarten (Dutch part)','SX'),(187,'Slovakia','SK'),(188,'Slovenia','SI'),(189,'Solomon Islands','SB'),(190,'Somalia','SO'),(191,'South Africa','ZA'),(192,'South Georgia and the South Sandwich Islands','GS'),(193,'South Sudan','SS'),(194,'Spain','ES'),(195,'Sri Lanka','LK'),(196,'State of Palestine','PS'),(197,'Sudan','SD'),(198,'SuriNazivDrzave','SR'),(199,'Svalbard and Jan Mayen','SJ'),(200,'Swaziland','SZ'),(201,'Sweden','SE'),(202,'Switzerland','CH'),(203,'Syrian Arab Republic','SY'),(204,'Tajikistan','TJ'),(205,'Thailand','TH'),(206,'Timor-Leste','TL'),(207,'Togo','TG'),(208,'Tokelau','TK'),(209,'Tonga','TO'),(210,'Trinidad and Tobago','TT'),(211,'Tunisia','TN'),(212,'Turkey','TR'),(213,'Turkmenistan','TM'),(214,'Turks and Caicos Islands','TC'),(215,'Tuvalu','TV'),(216,'Uganda','UG'),(217,'Ukraine','UA'),(218,'United Arab Emirates','AE'),(219,'United Kingdom','GB'),(220,'United States','US'),(221,'United States Minor Outlying Islands','UM'),(222,'Uruguay','UY'),(223,'Uzbekistan','UZ'),(224,'Vanuatu','VU'),(225,'Viet Nam','VN'),(226,'Wallis and Futuna','WF'),(227,'Western Sahara','EH'),(228,'Yemen','YE'),(229,'Zambia','ZM'),(230,'Zimbabwe','ZW');
/*!40000 ALTER TABLE `drzave` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `letovi`
--

DROP TABLE IF EXISTS `letovi`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `letovi` (
  `idLetovi` int NOT NULL,
  `AerodromIDPolaska` int NOT NULL,
  `AerodromIDDolaska` int NOT NULL,
  `Datum` datetime NOT NULL,
  `idPilota` int DEFAULT NULL,
  PRIMARY KEY (`idLetovi`),
  KEY `IDPilot_Let_idx` (`idPilota`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `letovi`
--

LOCK TABLES `letovi` WRITE;
/*!40000 ALTER TABLE `letovi` DISABLE KEYS */;
INSERT INTO `letovi` VALUES (3,1,2,'2024-01-27 00:00:00',3);
/*!40000 ALTER TABLE `letovi` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `letovi_stjuardese_veza`
--

DROP TABLE IF EXISTS `letovi_stjuardese_veza`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `letovi_stjuardese_veza` (
  `idLetovi` int NOT NULL,
  `idStjuardese` int NOT NULL,
  PRIMARY KEY (`idLetovi`,`idStjuardese`),
  KEY `idStjuardese` (`idStjuardese`),
  CONSTRAINT `letovi_stjuardese_veza_ibfk_1` FOREIGN KEY (`idLetovi`) REFERENCES `letovi` (`idLetovi`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `letovi_stjuardese_veza_ibfk_2` FOREIGN KEY (`idStjuardese`) REFERENCES `stjuardese` (`idstjuardese`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `letovi_stjuardese_veza`
--

LOCK TABLES `letovi_stjuardese_veza` WRITE;
/*!40000 ALTER TABLE `letovi_stjuardese_veza` DISABLE KEYS */;
/*!40000 ALTER TABLE `letovi_stjuardese_veza` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pilot`
--

DROP TABLE IF EXISTS `pilot`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pilot` (
  `idpilot` int NOT NULL AUTO_INCREMENT,
  `Ime` varchar(45) NOT NULL,
  `Prezime` varchar(45) NOT NULL,
  `godineIskustva` int NOT NULL,
  PRIMARY KEY (`idpilot`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pilot`
--

LOCK TABLES `pilot` WRITE;
/*!40000 ALTER TABLE `pilot` DISABLE KEYS */;
INSERT INTO `pilot` VALUES (1,'Imad','Hubljar',1),(3,'Amer','Delic',0),(4,'Djano','Kotejebe',0);
/*!40000 ALTER TABLE `pilot` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stjuardese`
--

DROP TABLE IF EXISTS `stjuardese`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `stjuardese` (
  `idstjuardese` int NOT NULL AUTO_INCREMENT,
  `Ime` varchar(45) NOT NULL,
  `Prezime` varchar(45) NOT NULL,
  `godineIskustva` varchar(45) NOT NULL,
  PRIMARY KEY (`idstjuardese`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stjuardese`
--

LOCK TABLES `stjuardese` WRITE;
/*!40000 ALTER TABLE `stjuardese` DISABLE KEYS */;
INSERT INTO `stjuardese` VALUES (1,'Adem','Spahic','2'),(2,'Hamza','Alickovic','0');
/*!40000 ALTER TABLE `stjuardese` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-01-27 18:24:33
