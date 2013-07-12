CREATE DATABASE  IF NOT EXISTS `university` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `university`;
-- MySQL dump 10.13  Distrib 5.6.12, for Win64 (x86_64)
--
-- Host: localhost    Database: university
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
  `CourseId` int(11) NOT NULL AUTO_INCREMENT,
  `DepartmentId` int(11) DEFAULT NULL,
  `ProfessorId` int(11) DEFAULT NULL,
  `CourseName` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`CourseId`),
  KEY `FK_Courses_Departments_idx` (`DepartmentId`),
  KEY `FK_Courses_Professors_idx` (`ProfessorId`),
  CONSTRAINT `FK_Courses_Departments` FOREIGN KEY (`DepartmentId`) REFERENCES `departments` (`DepartmentId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_Courses_Professors` FOREIGN KEY (`ProfessorId`) REFERENCES `professors` (`ProfessorId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `courses`
--

LOCK TABLES `courses` WRITE;
/*!40000 ALTER TABLE `courses` DISABLE KEYS */;
/*!40000 ALTER TABLE `courses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `degrees`
--

DROP TABLE IF EXISTS `degrees`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `degrees` (
  `DegreeId` int(11) NOT NULL AUTO_INCREMENT,
  `DegreeName` varchar(45) NOT NULL,
  PRIMARY KEY (`DegreeId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `degrees`
--

LOCK TABLES `degrees` WRITE;
/*!40000 ALTER TABLE `degrees` DISABLE KEYS */;
/*!40000 ALTER TABLE `degrees` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `departments`
--

DROP TABLE IF EXISTS `departments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `departments` (
  `DepartmentId` int(11) NOT NULL AUTO_INCREMENT,
  `FacultyId` int(11) NOT NULL,
  `DepartmentName` varchar(45) NOT NULL,
  PRIMARY KEY (`DepartmentId`),
  KEY `FK_Departments_Faculties_idx` (`FacultyId`),
  CONSTRAINT `FK_Departments_Faculties` FOREIGN KEY (`FacultyId`) REFERENCES `faculties` (`FacultyId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `departments`
--

LOCK TABLES `departments` WRITE;
/*!40000 ALTER TABLE `departments` DISABLE KEYS */;
/*!40000 ALTER TABLE `departments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `faculties`
--

DROP TABLE IF EXISTS `faculties`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `faculties` (
  `FacultyId` int(11) NOT NULL AUTO_INCREMENT,
  `FacultyName` varchar(45) NOT NULL,
  PRIMARY KEY (`FacultyId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `faculties`
--

LOCK TABLES `faculties` WRITE;
/*!40000 ALTER TABLE `faculties` DISABLE KEYS */;
/*!40000 ALTER TABLE `faculties` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `professors`
--

DROP TABLE IF EXISTS `professors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `professors` (
  `ProfessorId` int(11) NOT NULL AUTO_INCREMENT,
  `DepartmentId` int(11) NOT NULL,
  `ProfessorName` varchar(45) NOT NULL,
  PRIMARY KEY (`ProfessorId`),
  KEY `FK_Professors_Departments_idx` (`DepartmentId`),
  CONSTRAINT `FK_Professors_Departments` FOREIGN KEY (`DepartmentId`) REFERENCES `departments` (`DepartmentId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `professors`
--

LOCK TABLES `professors` WRITE;
/*!40000 ALTER TABLE `professors` DISABLE KEYS */;
/*!40000 ALTER TABLE `professors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `professorsdegrees`
--

DROP TABLE IF EXISTS `professorsdegrees`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `professorsdegrees` (
  `ProfessorId` int(11) DEFAULT NULL,
  `DegreeId` int(11) DEFAULT NULL,
  KEY `FK_ProfessorsDegrees_Professors_idx` (`ProfessorId`),
  KEY `FK_ProfessorsDegrees_Degrees_idx` (`DegreeId`),
  CONSTRAINT `FK_ProfessorsDegrees_Professors` FOREIGN KEY (`ProfessorId`) REFERENCES `professors` (`ProfessorId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_ProfessorsDegrees_Degrees` FOREIGN KEY (`DegreeId`) REFERENCES `degrees` (`DegreeId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `professorsdegrees`
--

LOCK TABLES `professorsdegrees` WRITE;
/*!40000 ALTER TABLE `professorsdegrees` DISABLE KEYS */;
/*!40000 ALTER TABLE `professorsdegrees` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `students`
--

DROP TABLE IF EXISTS `students`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `students` (
  `StudentId` int(11) NOT NULL,
  `FacultyId` int(11) NOT NULL,
  `StudentName` varchar(45) NOT NULL,
  PRIMARY KEY (`StudentId`),
  KEY `FK_Students_Faculties_idx` (`FacultyId`),
  CONSTRAINT `FK_Students_Faculties` FOREIGN KEY (`FacultyId`) REFERENCES `faculties` (`FacultyId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `students`
--

LOCK TABLES `students` WRITE;
/*!40000 ALTER TABLE `students` DISABLE KEYS */;
/*!40000 ALTER TABLE `students` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `studentscourses`
--

DROP TABLE IF EXISTS `studentscourses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `studentscourses` (
  `StudentId` int(11) NOT NULL,
  `CourseId` int(11) NOT NULL,
  KEY `FK_StudentsCourses_Courses_idx` (`CourseId`),
  KEY `FK_StudentsCourses_Students_idx` (`StudentId`),
  CONSTRAINT `FK_StudentsCourses_Courses` FOREIGN KEY (`CourseId`) REFERENCES `courses` (`CourseId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_StudentsCourses_Students` FOREIGN KEY (`StudentId`) REFERENCES `students` (`StudentId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `studentscourses`
--

LOCK TABLES `studentscourses` WRITE;
/*!40000 ALTER TABLE `studentscourses` DISABLE KEYS */;
/*!40000 ALTER TABLE `studentscourses` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2013-07-12 20:38:38
