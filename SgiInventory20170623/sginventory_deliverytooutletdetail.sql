CREATE DATABASE  IF NOT EXISTS `sginventory` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `sginventory`;
-- MySQL dump 10.13  Distrib 5.7.9, for Win64 (x86_64)
--
-- Host: localhost    Database: sginventory
-- ------------------------------------------------------
-- Server version	5.7.11-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `deliverytooutletdetail`
--

DROP TABLE IF EXISTS `deliverytooutletdetail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `deliverytooutletdetail` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `IsActive` int(11) NOT NULL DEFAULT '1',
  `DeliveryToOutlet` int(11) DEFAULT NULL,
  `ProductDetail` varchar(50) NOT NULL,
  `SuggestedRetailPrice` decimal(18,2) NOT NULL DEFAULT '0.00',
  `Quantity` int(11) NOT NULL,
  `Remarks` varchar(500) DEFAULT NULL,
  `AdjustmentDate` datetime DEFAULT NULL,
  `Status` int(11) NOT NULL,
  `AdjustmentRemarks` varchar(50) DEFAULT NULL,
  `AdjustmentMode` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `DeliveryToOutlet_ID_FK_idx` (`DeliveryToOutlet`),
  KEY `ProductDetail_Code_FK_idx` (`ProductDetail`),
  CONSTRAINT `DeliveryToOutlet_ID_FK` FOREIGN KEY (`DeliveryToOutlet`) REFERENCES `deliverytooutlet` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `ProductDetail_Code_FK` FOREIGN KEY (`ProductDetail`) REFERENCES `productdetails` (`Code`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `deliverytooutletdetail`
--

LOCK TABLES `deliverytooutletdetail` WRITE;
/*!40000 ALTER TABLE `deliverytooutletdetail` DISABLE KEYS */;
INSERT INTO `deliverytooutletdetail` VALUES (1,1,1,'1367002202',445.00,5,NULL,NULL,1,NULL,NULL),(2,1,1,'1367002210',445.00,2,NULL,NULL,1,NULL,NULL),(3,1,1,'1367002214',445.00,2,NULL,NULL,1,NULL,NULL),(4,1,1,'1367002220',445.00,2,NULL,NULL,1,NULL,NULL),(12,0,1,'W015014C23',400.00,5,'',NULL,1,NULL,NULL),(13,1,NULL,'13670022S2',445.00,5,NULL,'2015-04-03 23:13:14',1,'Added to outlet',3),(14,1,NULL,'13670022S2',445.00,-3,NULL,'2015-04-03 22:28:52',1,'Deduct from outlet(goods)',4),(15,1,NULL,'13670022S5',445.00,5,NULL,'2015-04-03 23:29:42',2,'Add to outlet (Stain)',3),(16,1,NULL,'13670022S5',445.00,-5,NULL,'2015-04-03 23:29:42',2,'Deduct from outlet(Holes)',4),(17,1,2,'W0550012S6',400.00,5,NULL,NULL,1,NULL,NULL),(18,1,3,'1367002210',445.00,1,NULL,NULL,1,NULL,NULL),(19,1,4,'1367002202',445.00,1,NULL,NULL,1,NULL,NULL),(20,1,5,'W011000808',0.00,1,NULL,NULL,1,NULL,NULL),(21,1,5,'W011000808',0.00,1,NULL,NULL,1,NULL,NULL),(22,1,5,'W023004504',0.00,1,NULL,NULL,1,NULL,NULL);
/*!40000 ALTER TABLE `deliverytooutletdetail` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-06-23 15:01:07
