-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 18 Lis 2018, 13:06
-- Wersja serwera: 10.1.36-MariaDB
-- Wersja PHP: 7.1.23

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `service`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `employees`
--

CREATE TABLE `employees` (
  `ID` int(11) NOT NULL,
  `Name` varchar(32) COLLATE utf16_polish_ci NOT NULL,
  `Surname` varchar(32) COLLATE utf16_polish_ci NOT NULL,
  `BirthdayDate` date NOT NULL,
  `PESEL` char(12) COLLATE utf16_polish_ci NOT NULL,
  `Address` varchar(60) COLLATE utf16_polish_ci NOT NULL,
  `HireDate` date NOT NULL,
  `HireExpirationDate` date DEFAULT NULL,
  `Privileges` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf16 COLLATE=utf16_polish_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `qualifications`
--

CREATE TABLE `qualifications` (
  `ID` int(11) NOT NULL,
  `Qualification_Name` varchar(50) COLLATE utf16_polish_ci NOT NULL,
  `Qualification_Descr` varchar(300) COLLATE utf16_polish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf16 COLLATE=utf16_polish_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `user`
--

CREATE TABLE `user` (
  `ID` int(11) NOT NULL,
  `Login` varchar(32) COLLATE utf16_polish_ci NOT NULL,
  `EmployeeID` int(11) DEFAULT NULL,
  `Password` varchar(128) COLLATE utf16_polish_ci NOT NULL,
  `Name` varchar(32) COLLATE utf16_polish_ci NOT NULL,
  `Surname` varchar(32) COLLATE utf16_polish_ci NOT NULL,
  `Privileges` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf16 COLLATE=utf16_polish_ci;

--
-- Zrzut danych tabeli `user`
--

INSERT INTO `user` (`ID`, `Login`, `EmployeeID`, `Password`, `Name`, `Surname`, `Privileges`) VALUES
(1, 'Login_Test', NULL, 'PASSWORD', 'Konrad', 'Sladkowski', 1),
(3, 'KRyk', NULL, '$XEREC$V1$10000$h1qcvr8E04oZxdEApdNqdKDR4XJluCKLr/eIZYqmavDnuKps', 'Koko', 'Ryk', 2);

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `employees`
--
ALTER TABLE `employees`
  ADD PRIMARY KEY (`ID`);

--
-- Indeksy dla tabeli `qualifications`
--
ALTER TABLE `qualifications`
  ADD PRIMARY KEY (`ID`);

--
-- Indeksy dla tabeli `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`ID`) USING BTREE,
  ADD UNIQUE KEY `Login` (`Login`) USING BTREE,
  ADD UNIQUE KEY `EmployeeID` (`EmployeeID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT dla tabeli `employees`
--
ALTER TABLE `employees`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT dla tabeli `qualifications`
--
ALTER TABLE `qualifications`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT dla tabeli `user`
--
ALTER TABLE `user`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
