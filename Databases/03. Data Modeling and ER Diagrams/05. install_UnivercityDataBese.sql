CREATE DATABASE  IF NOT EXISTS `univercity` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `univercity`;
-- MySQL dump 10.13  Distrib 5.6.12, for Win64 (x86_64)
--
-- Host: localhost    Database: univercity
-- ------------------------------------------------------
-- Server version	5.6.12

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
-- Table structure for table `courses`
--

DROP TABLE IF EXISTS `courses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `courses` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  `ProfessorID` int(11) NOT NULL,
  `DepartmentID` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `fk_Courses_Departments1_idx` (`DepartmentID`),
  CONSTRAINT `fk_Courses_Departments1` FOREIGN KEY (`DepartmentID`) REFERENCES `departments` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `courses`
--

LOCK TABLES `courses` WRITE;
/*!40000 ALTER TABLE `courses` DISABLE KEYS */;
INSERT INTO `courses` VALUES (1,'Molecular Matematics',1,1),(2,'Practical Biology',2,2),(3,'Regular Math',3,3),(4,'Mechanics',1,3),(5,'Antimats',1,1);
/*!40000 ALTER TABLE `courses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `departments`
--

DROP TABLE IF EXISTS `departments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `departments` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  `FacultyID` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `fk_Departments_Faculties1_idx` (`FacultyID`),
  CONSTRAINT `fk_Departments_Faculties1` FOREIGN KEY (`FacultyID`) REFERENCES `faculties` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `departments`
--

LOCK TABLES `departments` WRITE;
/*!40000 ALTER TABLE `departments` DISABLE KEYS */;
INSERT INTO `departments` VALUES (1,'SU',1),(2,'IUT',1),(3,'EZAM',1);
/*!40000 ALTER TABLE `departments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `faculties`
--

DROP TABLE IF EXISTS `faculties`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `faculties` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `faculties`
--

LOCK TABLES `faculties` WRITE;
/*!40000 ALTER TABLE `faculties` DISABLE KEYS */;
INSERT INTO `faculties` VALUES (1,'FA');
/*!40000 ALTER TABLE `faculties` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `professors`
--

DROP TABLE IF EXISTS `professors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `professors` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  `DepartmentID` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `fk_Professors_Departments1_idx` (`DepartmentID`),
  CONSTRAINT `fk_Professors_Departments1` FOREIGN KEY (`DepartmentID`) REFERENCES `departments` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `professors`
--

LOCK TABLES `professors` WRITE;
/*!40000 ALTER TABLE `professors` DISABLE KEYS */;
INSERT INTO `professors` VALUES (1,'Cherkezov ',1),(2,'Kolio Piandeto',1),(3,'Spiro ot Nadejda',1);
/*!40000 ALTER TABLE `professors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `students`
--

DROP TABLE IF EXISTS `students`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `students` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  `FacultyID` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `fk_Students_Faculties_idx` (`FacultyID`),
  CONSTRAINT `fk_Students_Faculties` FOREIGN KEY (`FacultyID`) REFERENCES `faculties` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `students`
--

LOCK TABLES `students` WRITE;
/*!40000 ALTER TABLE `students` DISABLE KEYS */;
INSERT INTO `students` VALUES (2,'Moncho Donkin',1),(3,'Dimo ot Kavarna',1),(4,'Dora ot Zornica',1);
/*!40000 ALTER TABLE `students` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `students_has_courses`
--

DROP TABLE IF EXISTS `students_has_courses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `students_has_courses` (
  `Students_ID` int(11) NOT NULL,
  `Courses_ID` int(11) NOT NULL,
  PRIMARY KEY (`Students_ID`,`Courses_ID`),
  KEY `fk_Students_has_Courses_Courses1_idx` (`Courses_ID`),
  KEY `fk_Students_has_Courses_Students1_idx` (`Students_ID`),
  CONSTRAINT `fk_Students_has_Courses_Students1` FOREIGN KEY (`Students_ID`) REFERENCES `students` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Students_has_Courses_Courses1` FOREIGN KEY (`Courses_ID`) REFERENCES `courses` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `students_has_courses`
--

LOCK TABLES `students_has_courses` WRITE;
/*!40000 ALTER TABLE `students_has_courses` DISABLE KEYS */;
INSERT INTO `students_has_courses` VALUES (2,1),(4,1),(2,2),(2,3),(3,3);
/*!40000 ALTER TABLE `students_has_courses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `titles`
--

DROP TABLE IF EXISTS `titles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `titles` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `titles`
--

LOCK TABLES `titles` WRITE;
/*!40000 ALTER TABLE `titles` DISABLE KEYS */;
INSERT INTO `titles` VALUES (1,'PhD'),(2,'Academician'),(3,'Senior Assistant');
/*!40000 ALTER TABLE `titles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `titles_has_professors`
--

DROP TABLE IF EXISTS `titles_has_professors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `titles_has_professors` (
  `Titles_ID` int(11) NOT NULL,
  `Professors_ID` int(11) NOT NULL,
  PRIMARY KEY (`Titles_ID`,`Professors_ID`),
  KEY `fk_Titles_has_Professors_Professors1_idx` (`Professors_ID`),
  KEY `fk_Titles_has_Professors_Titles1_idx` (`Titles_ID`),
  CONSTRAINT `fk_Titles_has_Professors_Titles1` FOREIGN KEY (`Titles_ID`) REFERENCES `titles` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Titles_has_Professors_Professors1` FOREIGN KEY (`Professors_ID`) REFERENCES `professors` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `titles_has_professors`
--

LOCK TABLES `titles_has_professors` WRITE;
/*!40000 ALTER TABLE `titles_has_professors` DISABLE KEYS */;
INSERT INTO `titles_has_professors` VALUES (1,1),(2,1),(1,2),(3,2),(1,3),(2,3),(3,3);
/*!40000 ALTER TABLE `titles_has_professors` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2013-07-14 18:12:09
