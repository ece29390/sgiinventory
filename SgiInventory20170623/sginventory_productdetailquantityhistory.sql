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
-- Table structure for table `productdetailquantityhistory`
--

DROP TABLE IF EXISTS `productdetailquantityhistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `productdetailquantityhistory` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Barcode` varchar(50) DEFAULT NULL,
  `CreatedBy` varchar(20) NOT NULL,
  `CreatedDate` datetime NOT NULL,
  `Quantity` int(11) NOT NULL DEFAULT '0',
  `StockNumber` varchar(50) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `StockNumber_KEY_idx` (`StockNumber`),
  CONSTRAINT `StockNumber_KEY` FOREIGN KEY (`StockNumber`) REFERENCES `product` (`StockNumber`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productdetailquantityhistory`
--

LOCK TABLES `productdetailquantityhistory` WRITE;
/*!40000 ALTER TABLE `productdetailquantityhistory` DISABLE KEYS */;
INSERT INTO `productdetailquantityhistory` VALUES (3,'W0110155XS','admin','2013-08-10 16:22:17',125,'W-011'),(4,'W0110155XS','admin','2013-08-10 16:22:41',150,'W-011');
/*!40000 ALTER TABLE `productdetailquantityhistory` ENABLE KEYS */;
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
