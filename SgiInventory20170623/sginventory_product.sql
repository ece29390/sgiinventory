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
-- Table structure for table `product`
--

DROP TABLE IF EXISTS `product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `product` (
  `StockNumber` varchar(50) NOT NULL,
  `Description` varchar(100) DEFAULT NULL,
  `CategoryId` int(11) NOT NULL,
  `CreatedBy` varchar(20) NOT NULL,
  `CreatedDate` datetime NOT NULL,
  `ModifiedBy` varchar(20) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  `Cost` decimal(10,2) NOT NULL DEFAULT '0.00',
  `RegularPrice` decimal(10,2) NOT NULL DEFAULT '0.00',
  `MarkdownPrice` decimal(10,2) NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`StockNumber`),
  KEY `Category_FK_idx` (`CategoryId`),
  CONSTRAINT `Category_FK` FOREIGN KEY (`CategoryId`) REFERENCES `category` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product`
--

LOCK TABLES `product` WRITE;
/*!40000 ALTER TABLE `product` DISABLE KEYS */;
INSERT INTO `product` VALUES ('1367','desc',3,'admin','2014-08-13 07:41:24','admin','2016-06-26 21:38:12',450.00,445.00,440.00),('1368','edit only',3,'admin','2014-07-02 08:04:38','admin','2014-07-08 09:55:17',512.00,662.00,612.00),('1369','',2,'admin','2014-07-02 08:06:42','admin','2014-07-02 08:51:41',400.00,500.00,475.00),('1370','',3,'admin','2014-07-02 08:09:11','admin','2014-07-03 09:09:26',300.00,330.00,310.00),('1371','Description',2,'admin','2014-07-03 09:09:14',NULL,NULL,450.00,500.00,475.00),('1471','Gsdada',2,'admin','2014-07-03 09:10:48','admin','2014-07-03 09:19:15',750.00,800.00,775.00),('1500','Sample',2,'admin','2014-07-06 23:10:18',NULL,NULL,700.00,800.00,780.00),('1501','',2,'admin','2014-07-06 23:21:19',NULL,NULL,450.00,480.00,470.00),('1502','',2,'admin','2014-07-06 23:29:52',NULL,NULL,100.00,150.00,125.00),('1503','Sample',3,'admin','2014-07-06 23:30:32','admin','2016-06-22 20:53:11',300.00,350.00,325.00),('1600','',2,'admin','2014-07-08 09:46:32','admin','2014-07-08 09:52:54',151.00,171.00,161.00),('B-482','Lorem Ipsum is simply dummy text of the printing',2,'admin','2013-11-24 22:59:32','admin','2014-07-02 06:47:59',380.00,399.75,385.00),('B-483','Tops regedit',3,'admin','2014-01-12 15:02:03','admin','2014-07-03 07:25:56',150.00,175.00,160.00),('B-502','',2,'admin','2013-11-25 01:03:41','admin','2014-07-03 07:25:10',400.00,429.75,410.00),('W-011','This is a sample edit 3',2,'sang','2013-06-29 00:00:00','admin','2014-08-19 08:20:30',200.00,200.00,200.00),('W-012','This is a sample edit 2',4,'admin','2013-11-16 00:43:15','admin','2014-07-03 07:24:50',115.00,125.00,120.00),('W-013','Description',2,'admin','2014-08-19 08:07:40',NULL,NULL,250.00,300.00,275.00),('W-014','Descriptin',2,'admin','2014-08-19 08:12:02','admin','2014-10-08 08:49:38',250.00,300.00,260.00),('W-015','description tops',2,'admin','2014-08-19 08:32:15','admin','2014-08-19 08:33:43',450.00,400.00,375.00),('W-020','Navy blue',2,'admin','2014-10-11 22:32:44','admin','2014-10-12 22:33:01',0.00,0.00,0.00),('W-021','',2,'admin','2014-10-11 23:02:35','admin','2016-06-26 21:42:03',25.00,75.00,65.00),('W-023','',2,'admin','2014-10-11 23:45:40','admin','2014-10-20 23:14:08',0.00,0.00,0.00),('W-024','sample',2,'admin','2014-10-19 23:39:47',NULL,NULL,100.00,150.00,175.00),('W-055','',2,'admin','2015-04-17 23:03:56','admin','2015-04-17 23:06:28',300.00,400.00,350.00);
/*!40000 ALTER TABLE `product` ENABLE KEYS */;
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
