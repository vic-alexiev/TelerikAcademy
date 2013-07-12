SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

CREATE SCHEMA IF NOT EXISTS `University` ;
USE `University` ;

-- -----------------------------------------------------
-- Table `University`.`Faculties`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `University`.`Faculties` (
  `FacultyId` INT NOT NULL AUTO_INCREMENT ,
  `FacultyName` VARCHAR(45) NOT NULL ,
  PRIMARY KEY (`FacultyId`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `University`.`Students`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `University`.`Students` (
  `StudentId` INT NOT NULL ,
  `FacultyId` INT NOT NULL ,
  `StudentName` VARCHAR(45) NOT NULL ,
  PRIMARY KEY (`StudentId`) ,
  INDEX `FK_Students_Faculties_idx` (`FacultyId` ASC) ,
  CONSTRAINT `FK_Students_Faculties`
    FOREIGN KEY (`FacultyId` )
    REFERENCES `University`.`Faculties` (`FacultyId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `University`.`Departments`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `University`.`Departments` (
  `DepartmentId` INT NOT NULL AUTO_INCREMENT ,
  `FacultyId` INT NOT NULL ,
  `DepartmentName` VARCHAR(45) NOT NULL ,
  PRIMARY KEY (`DepartmentId`) ,
  INDEX `FK_Departments_Faculties_idx` (`FacultyId` ASC) ,
  CONSTRAINT `FK_Departments_Faculties`
    FOREIGN KEY (`FacultyId` )
    REFERENCES `University`.`Faculties` (`FacultyId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `University`.`Professors`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `University`.`Professors` (
  `ProfessorId` INT NOT NULL AUTO_INCREMENT ,
  `DepartmentId` INT NOT NULL ,
  `ProfessorName` VARCHAR(45) NOT NULL ,
  PRIMARY KEY (`ProfessorId`) ,
  INDEX `FK_Professors_Departments_idx` (`DepartmentId` ASC) ,
  CONSTRAINT `FK_Professors_Departments`
    FOREIGN KEY (`DepartmentId` )
    REFERENCES `University`.`Departments` (`DepartmentId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `University`.`Courses`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `University`.`Courses` (
  `CourseId` INT NOT NULL AUTO_INCREMENT ,
  `DepartmentId` INT NULL ,
  `ProfessorId` INT NULL ,
  `CourseName` VARCHAR(45) NULL ,
  PRIMARY KEY (`CourseId`) ,
  INDEX `FK_Courses_Departments_idx` (`DepartmentId` ASC) ,
  INDEX `FK_Courses_Professors_idx` (`ProfessorId` ASC) ,
  CONSTRAINT `FK_Courses_Departments`
    FOREIGN KEY (`DepartmentId` )
    REFERENCES `University`.`Departments` (`DepartmentId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_Courses_Professors`
    FOREIGN KEY (`ProfessorId` )
    REFERENCES `University`.`Professors` (`ProfessorId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `University`.`StudentsCourses`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `University`.`StudentsCourses` (
  `StudentId` INT NOT NULL ,
  `CourseId` INT NOT NULL ,
  INDEX `FK_StudentsCourses_Courses_idx` (`CourseId` ASC) ,
  INDEX `FK_StudentsCourses_Students_idx` (`StudentId` ASC) ,
  CONSTRAINT `FK_StudentsCourses_Courses`
    FOREIGN KEY (`CourseId` )
    REFERENCES `University`.`Courses` (`CourseId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_StudentsCourses_Students`
    FOREIGN KEY (`StudentId` )
    REFERENCES `University`.`Students` (`StudentId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `University`.`Degrees`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `University`.`Degrees` (
  `DegreeId` INT NOT NULL AUTO_INCREMENT ,
  `DegreeName` VARCHAR(45) NOT NULL ,
  PRIMARY KEY (`DegreeId`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `University`.`ProfessorsDegrees`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `University`.`ProfessorsDegrees` (
  `ProfessorId` INT NULL ,
  `DegreeId` INT NULL ,
  INDEX `FK_ProfessorsDegrees_Professors_idx` (`ProfessorId` ASC) ,
  INDEX `FK_ProfessorsDegrees_Degrees_idx` (`DegreeId` ASC) ,
  CONSTRAINT `FK_ProfessorsDegrees_Professors`
    FOREIGN KEY (`ProfessorId` )
    REFERENCES `University`.`Professors` (`ProfessorId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_ProfessorsDegrees_Degrees`
    FOREIGN KEY (`DegreeId` )
    REFERENCES `University`.`Degrees` (`DegreeId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

USE `University` ;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
