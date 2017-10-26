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
-- Table structure for table `washing`
--

DROP TABLE IF EXISTS `washing`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `washing` (
  `Code` varchar(10) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `CreatedDate` datetime NOT NULL,
  `CreatedBy` varchar(20) NOT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`Code`),
  UNIQUE KEY `Name_UNIQUE` (`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `washing`
--

LOCK TABLES `washing` WRITE;
/*!40000 ALTER TABLE `washing` DISABLE KEYS */;
INSERT INTO `washing` VALUES ('0','Biowashing','2013-06-13 00:17:39','admin',NULL,NULL),('1','M1','2013-07-20 15:00:41','admin',NULL,NULL),('2','M2','2013-07-20 15:00:49','admin',NULL,NULL),('3','M3','2013-07-20 15:00:56','admin',NULL,NULL),('4','Expose Dark','2013-06-13 00:17:58','admin','2013-06-13 00:22:34','admin'),('5','ASH GRAY','2013-07-20 15:01:07','admin',NULL,NULL),('6','ORDINARY WASH/RAW WASH','2013-07-20 15:01:25','admin',NULL,NULL),('7','STONE WASH','2013-06-13 00:18:42','admin',NULL,NULL),('8','BLUE BLACK W/EURO','2013-07-20 15:01:46','admin',NULL,NULL),('9','EUROBLAST','2013-07-20 15:01:53','admin',NULL,NULL),('A','URBAN BLUE','2013-07-20 15:02:03','admin',NULL,NULL),('AAA','Ordinary Wash/Raw Wash/Rinse Wash','2014-09-17 00:28:48','admin',NULL,NULL),('B','ENZYME','2013-07-20 15:02:10','admin',NULL,NULL),('C','INK WASH','2013-07-20 15:02:17','admin',NULL,NULL);
/*!40000 ALTER TABLE `washing` ENABLE KEYS */;
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
