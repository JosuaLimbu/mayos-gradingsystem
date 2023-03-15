-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 23, 2022 at 08:01 AM
-- Server version: 10.4.25-MariaDB
-- PHP Version: 8.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `project_vispro`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin`
--

CREATE TABLE `admin` (
  `ID` int(11) NOT NULL,
  `name` varchar(50) NOT NULL,
  `ID_user` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `admin`
--

INSERT INTO `admin` (`ID`, `name`, `ID_user`) VALUES
(1, 'solo', 1),
(2, 'chew', 1);

-- --------------------------------------------------------

--
-- Table structure for table `classroom`
--

CREATE TABLE `classroom` (
  `day` varchar(30) NOT NULL,
  `hour` varchar(15) NOT NULL,
  `ID_lec` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `classroom`
--

INSERT INTO `classroom` (`day`, `hour`, `ID_lec`) VALUES
('senin,rabu', '14.30-16.00', 1),
('selasa,kamis', '14.11-15.11', 2),
('selasa-kamis', '11.11.-11.11', 3);

-- --------------------------------------------------------

--
-- Table structure for table `detail_grade`
--

CREATE TABLE `detail_grade` (
  `ID_stu` int(11) NOT NULL,
  `ID_lec` int(11) NOT NULL,
  `assg1` int(3) DEFAULT NULL,
  `assg2` int(3) DEFAULT NULL,
  `assg3` int(3) DEFAULT NULL,
  `quiz1` int(3) DEFAULT NULL,
  `quiz2` int(3) DEFAULT NULL,
  `quiz3` int(3) DEFAULT NULL,
  `project1` int(3) DEFAULT NULL,
  `project2` int(3) DEFAULT NULL,
  `Mid` int(3) DEFAULT NULL,
  `Final` int(3) DEFAULT NULL,
  `attendace` int(3) DEFAULT NULL,
  `total` int(3) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `detail_grade`
--

INSERT INTO `detail_grade` (`ID_stu`, `ID_lec`, `assg1`, `assg2`, `assg3`, `quiz1`, `quiz2`, `quiz3`, `project1`, `project2`, `Mid`, `Final`, `attendace`, `total`) VALUES
(31, 1, 100, 99, 99, 100, 100, 100, 99, 99, 100, 100, 100, 99),
(2, 1, 100, 98, 89, 100, 98, 99, 100, 99, 100, 100, 100, 99),
(2, 1, 100, 98, 89, 100, 98, 99, 100, 99, 100, 100, 100, 99),
(2, 1, 100, 98, 89, 100, 98, 99, 100, 99, 100, 100, 100, 99),
(3, 1, 88, 88, 88, 88, 88, 88, 88, 88, 88, 88, 88, 88),
(4, 1, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99),
(4, 1, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99),
(4, 1, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99),
(4, 1, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99),
(2, 2, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99),
(2, 1, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99),
(3, 1, 88, 88, 88, 88, 88, 88, 88, 88, 88, 88, 88, 88),
(6, 2, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99);

-- --------------------------------------------------------

--
-- Table structure for table `grade`
--

CREATE TABLE `grade` (
  `stu_ID` int(11) NOT NULL,
  `name` varchar(50) NOT NULL,
  `ID_lec` int(13) NOT NULL,
  `assignment_grade` double(5,2) NOT NULL,
  `quiz_grade` double(5,2) NOT NULL,
  `project` double(5,2) NOT NULL,
  `MidTerm` double(5,2) NOT NULL,
  `FinalTerm` double(5,2) NOT NULL,
  `attendance` double(5,2) NOT NULL,
  `total_grade` double(5,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `grade`
--

INSERT INTO `grade` (`stu_ID`, `name`, `ID_lec`, `assignment_grade`, `quiz_grade`, `project`, `MidTerm`, `FinalTerm`, `attendance`, `total_grade`) VALUES
(2, 'student2', 1, 8.00, 9.00, 20.00, 24.00, 24.00, 10.00, 97.00),
(2, 'student2', 1, 8.00, 9.00, 20.00, 24.00, 24.00, 10.00, 97.00),
(4, 'student4', 1, 9.00, 9.00, 19.00, 24.00, 24.00, 9.00, 99.00),
(2, 'student_2', 2, 9.00, 9.00, 19.00, 24.00, 24.00, 9.00, 99.00),
(2, 'student_2', 1, 9.00, 9.00, 19.00, 24.00, 24.00, 9.00, 99.00),
(3, 'student3', 1, 8.00, 8.00, 17.00, 22.00, 22.00, 8.00, 88.00),
(6, 'student6', 2, 9.00, 9.00, 19.00, 24.00, 24.00, 9.00, 99.00);

-- --------------------------------------------------------

--
-- Table structure for table `lec`
--

CREATE TABLE `lec` (
  `ID` int(11) NOT NULL,
  `lec_name` varchar(45) NOT NULL,
  `SKS` int(1) NOT NULL,
  `ID_lecturer` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `lec`
--

INSERT INTO `lec` (`ID`, `lec_name`, `SKS`, `ID_lecturer`) VALUES
(1, 'vispro', 3, 21),
(2, 'Agama1', 2, 3),
(3, 'ID', 3, 3),
(4, 'WD', 3, 3);

-- --------------------------------------------------------

--
-- Table structure for table `lecturer`
--

CREATE TABLE `lecturer` (
  `ID` int(11) NOT NULL,
  `name` varchar(50) NOT NULL,
  `ID_user` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `lecturer`
--

INSERT INTO `lecturer` (`ID`, `name`, `ID_user`) VALUES
(2, 'luke', 2),
(3, 'dosen2', 2),
(21, 'dosen1', 2);

-- --------------------------------------------------------

--
-- Table structure for table `student`
--

CREATE TABLE `student` (
  `ID` int(11) NOT NULL,
  `name` varchar(50) NOT NULL,
  `ID_user` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `student`
--

INSERT INTO `student` (`ID`, `name`, `ID_user`) VALUES
(1, 'lili', 3),
(2, 'student_2', 3),
(3, 'student3', 3),
(4, 'student4', 3),
(6, 'student6', 3),
(31, 'student1', 3);

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `ID` int(11) NOT NULL,
  `username` varchar(45) NOT NULL,
  `password` varchar(18) NOT NULL,
  `level` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`ID`, `username`, `password`, `level`) VALUES
(1, 'admin1', 'admin1', 1),
(2, 'dosen1', 'dosen1', 2),
(3, 'student1', 'student1', 3),
(4, 'student2', 'student2', 3),
(5, 'hann', '1234', 1),
(6, 'resma', '1234', 2),
(7, 'jojo', 'jojo', 3);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `ID_user` (`ID_user`);

--
-- Indexes for table `classroom`
--
ALTER TABLE `classroom`
  ADD KEY `ID_lec` (`ID_lec`);

--
-- Indexes for table `detail_grade`
--
ALTER TABLE `detail_grade`
  ADD KEY `ID_stu` (`ID_stu`),
  ADD KEY `ID_lec` (`ID_lec`);

--
-- Indexes for table `grade`
--
ALTER TABLE `grade`
  ADD KEY `stu_ID` (`stu_ID`),
  ADD KEY `ID_lec` (`ID_lec`);

--
-- Indexes for table `lec`
--
ALTER TABLE `lec`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `ID_lecturer` (`ID_lecturer`);

--
-- Indexes for table `lecturer`
--
ALTER TABLE `lecturer`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `ID_user` (`ID_user`);

--
-- Indexes for table `student`
--
ALTER TABLE `student`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `ID_user` (`ID_user`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `username` (`username`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `admin`
--
ALTER TABLE `admin`
  ADD CONSTRAINT `admin_ibfk_1` FOREIGN KEY (`ID_user`) REFERENCES `user` (`ID`);

--
-- Constraints for table `classroom`
--
ALTER TABLE `classroom`
  ADD CONSTRAINT `classroom_ibfk_1` FOREIGN KEY (`ID_lec`) REFERENCES `lec` (`ID`);

--
-- Constraints for table `detail_grade`
--
ALTER TABLE `detail_grade`
  ADD CONSTRAINT `detail_grade_ibfk_1` FOREIGN KEY (`ID_stu`) REFERENCES `student` (`ID`),
  ADD CONSTRAINT `detail_grade_ibfk_2` FOREIGN KEY (`ID_lec`) REFERENCES `lec` (`ID`);

--
-- Constraints for table `grade`
--
ALTER TABLE `grade`
  ADD CONSTRAINT `grade_ibfk_1` FOREIGN KEY (`stu_ID`) REFERENCES `student` (`ID`),
  ADD CONSTRAINT `grade_ibfk_2` FOREIGN KEY (`ID_lec`) REFERENCES `lec` (`ID`);

--
-- Constraints for table `lec`
--
ALTER TABLE `lec`
  ADD CONSTRAINT `lec_ibfk_1` FOREIGN KEY (`ID_lecturer`) REFERENCES `lecturer` (`ID`);

--
-- Constraints for table `lecturer`
--
ALTER TABLE `lecturer`
  ADD CONSTRAINT `lecturer_ibfk_1` FOREIGN KEY (`ID_user`) REFERENCES `user` (`ID`);

--
-- Constraints for table `student`
--
ALTER TABLE `student`
  ADD CONSTRAINT `student_ibfk_1` FOREIGN KEY (`ID_user`) REFERENCES `user` (`ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
