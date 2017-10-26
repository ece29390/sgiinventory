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
-- Table structure for table `deliverytooutlet`
--

DROP TABLE IF EXISTS `deliverytooutlet`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `deliverytooutlet` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `DeliveryDate` datetime NOT NULL,
  `PackingListNumber` varchar(20) NOT NULL,
  `Outlet` int(11) NOT NULL,
  `IsActive` int(11) NOT NULL DEFAULT '1',
  `CreatedBy` varchar(20) NOT NULL,
  `CreatedDate` datetime NOT NULL,
  `ModifiedBy` varchar(20) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Store_Code_FK_idx` (`Outlet`),
  CONSTRAINT `DeliveryToOutlet_Outlet_FK` FOREIGN KEY (`Outlet`) REFERENCES `outlet` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `deliverytooutlet`
--

LOCK TABLES `deliverytooutlet` WRITE;
/*!40000 ALTER TABLE `deliverytooutlet` DISABLE KEYS */;
INSERT INTO `deliverytooutlet` VALUES (1,'2015-02-25 21:25:17','11111',7,1,'admin','2015-02-22 23:33:58','admin','2015-02-25 21:25:46'),(2,'2015-04-18 00:17:45','45645657',6,1,'admin','2015-04-18 00:20:32',NULL,NULL),(3,'2015-11-05 18:16:52','354353',7,1,'admin','2015-11-05 18:17:18',NULL,NULL),(4,'2015-11-05 21:16:11','45646',6,1,'admin','2015-11-05 21:16:24',NULL,NULL),(5,'2017-06-21 13:05:54','43242',6,1,'admin','2017-06-21 13:46:42',NULL,NULL);
/*!40000 ALTER TABLE `deliverytooutlet` ENABLE KEYS */;
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
