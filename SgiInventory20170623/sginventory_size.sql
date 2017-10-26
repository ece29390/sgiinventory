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
-- Table structure for table `size`
--

DROP TABLE IF EXISTS `size`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `size` (
  `Code` varchar(10) NOT NULL,
  `Name` varchar(25) NOT NULL,
  `CreatedBy` varchar(20) NOT NULL,
  `CreatedDate` datetime NOT NULL,
  `ModifiedBy` varchar(20) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Code`),
  UNIQUE KEY `Name_UNIQUE` (`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `size`
--

LOCK TABLES `size` WRITE;
/*!40000 ALTER TABLE `size` DISABLE KEYS */;
INSERT INTO `size` VALUES ('02','2','admin','2013-06-13 00:26:28','admin','2015-05-13 23:17:04'),('04','4','admin','2013-07-20 15:03:06','admin','2015-05-13 23:17:10'),('06','6','admin','2013-07-20 15:03:10','admin','2015-05-13 23:17:48'),('08','8','admin','2013-07-20 15:03:15','admin','2015-05-13 23:17:54'),('10','10','admin','2013-07-20 15:03:19',NULL,NULL),('12','12','admin','2013-07-20 15:03:26',NULL,NULL),('14','14','admin','2013-07-20 15:03:32',NULL,NULL),('16','16','admin','2013-07-20 15:03:39',NULL,NULL),('18','18','admin','2013-07-20 15:03:47',NULL,NULL),('20','20','admin','2013-07-20 15:03:53',NULL,NULL),('23','23','admin','2013-07-20 15:04:00',NULL,NULL),('24','24','admin','2013-07-20 15:04:06',NULL,NULL),('25','25','admin','2013-07-20 15:04:12',NULL,NULL),('S0','XXS','admin','2013-10-10 23:02:40',NULL,NULL),('S1','XS','admin','2013-10-10 23:02:53',NULL,NULL),('S2','S','admin','2013-06-12 20:52:53',NULL,NULL),('S3','M','admin','2013-06-12 19:49:54',NULL,NULL),('S4','L','admin','2013-06-12 20:50:58',NULL,NULL),('S5','XL','admin','2013-06-12 21:24:09','admin','2013-06-12 21:33:27'),('S6','XXL','admin','2013-07-20 15:04:29',NULL,NULL);
/*!40000 ALTER TABLE `size` ENABLE KEYS */;
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
