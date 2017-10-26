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
-- Table structure for table `productpriceshistory`
--

DROP TABLE IF EXISTS `productpriceshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `productpriceshistory` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `StockNumber` varchar(50) NOT NULL,
  `Cost` decimal(10,2) NOT NULL,
  `RegularPrice` decimal(10,2) NOT NULL,
  `MarkdownPrice` decimal(10,2) NOT NULL,
  `CreatedDate` datetime NOT NULL,
  `CreatedBy` varchar(20) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_Product_ProductPrices_idx` (`StockNumber`),
  CONSTRAINT `FK_Product_ProductPrices` FOREIGN KEY (`StockNumber`) REFERENCES `product` (`StockNumber`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productpriceshistory`
--

LOCK TABLES `productpriceshistory` WRITE;
/*!40000 ALTER TABLE `productpriceshistory` DISABLE KEYS */;
INSERT INTO `productpriceshistory` VALUES (5,'W-011',160.00,210.00,170.00,'2013-07-29 22:43:36','admin'),(6,'W-011',170.00,220.00,180.00,'2013-08-10 16:00:30','admin'),(7,'W-011',180.00,230.00,190.00,'2014-01-12 15:00:59','admin'),(8,'W-011',200.00,250.00,210.00,'2014-01-12 16:52:23','admin'),(9,'1368',500.00,650.00,600.00,'2014-07-08 07:22:44','admin'),(13,'1367',400.00,450.00,430.00,'2014-07-03 09:08:05','admin'),(14,'1368',510.00,660.00,610.00,'2014-07-08 08:42:15','admin'),(15,'1368',511.00,661.00,611.00,'2014-07-08 09:49:52','admin'),(16,'1600',150.00,170.00,160.00,'2014-07-08 09:46:32','admin'),(17,'1367',401.00,451.00,431.00,'2014-07-02 08:02:46','admin'),(18,'W-014',350.00,400.00,375.00,'2014-08-19 08:00:06','admin'),(19,'W-014',560.00,580.00,600.00,'2014-08-19 08:03:28','admin'),(20,'W-015',0.00,0.00,0.00,'2014-08-19 08:13:01','admin'),(21,'W-011',205.00,250.00,210.00,'2013-06-29 00:00:00','sang'),(22,'w-015',250.00,300.00,200.00,'2014-08-19 08:13:01','admin'),(23,'W-015',0.00,0.00,0.00,'2014-08-19 08:30:03','admin'),(24,'W-015',345.00,300.00,275.00,'2014-08-19 08:32:15','admin'),(25,'W-014',0.00,0.00,0.00,'2014-08-19 08:12:02','admin'),(26,'W-020',330.00,350.00,340.00,'2014-10-08 08:50:29','admin'),(27,'W-021',0.00,0.00,0.00,'2014-10-11 23:02:35','admin'),(28,'W-055',230.00,255.00,245.00,'2015-04-17 22:45:13','admin');
/*!40000 ALTER TABLE `productpriceshistory` ENABLE KEYS */;
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
