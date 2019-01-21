-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 21 Sty 2019, 10:08
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
  `Position` varchar(128) COLLATE utf16_polish_ci NOT NULL,
  `UserID` int(11) DEFAULT NULL,
  `QualifID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf16 COLLATE=utf16_polish_ci;

--
-- Zrzut danych tabeli `employees`
--

INSERT INTO `employees` (`ID`, `Name`, `Surname`, `BirthdayDate`, `PESEL`, `Address`, `HireDate`, `HireExpirationDate`, `Position`, `UserID`, `QualifID`) VALUES
(1, 'Konrad', 'Testowy', '2017-08-07', '1234231234', 'Jakis Tam', '2017-10-08', NULL, 'Jakas', NULL, NULL),
(2, 'Tyrion', 'Foldring', '2018-08-14', '123456789054', 'TTTTTTT', '2018-12-04', NULL, 'Najlepsza', NULL, NULL),
(3, 'Marcin', 'Tyman', '2018-07-15', '141414124', 'Jakis Tam 2', '2018-07-10', '2018-12-13', 'XXZ', NULL, NULL),
(6, 'qwert', 'TY', '1993-06-16', '123456789012', 'rggeger', '2018-12-04', '2018-12-12', 'COS2', NULL, NULL),
(7, 'TTYYST', 'QWER', '2018-12-11', '1234567', 'sggsg', '2018-11-27', '2018-12-13', 'R', NULL, NULL);

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
-- Struktura tabeli dla tabeli `tabeladwa`
--

CREATE TABLE `tabeladwa` (
  `ID` int(11) NOT NULL,
  `Data` datetime DEFAULT NULL,
  `Liczba` int(11) DEFAULT NULL,
  `Opis` varchar(2048) COLLATE utf16_polish_ci DEFAULT NULL,
  `KrotkiTekst` varchar(80) COLLATE utf16_polish_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf16 COLLATE=utf16_polish_ci;

--
-- Zrzut danych tabeli `tabeladwa`
--

INSERT INTO `tabeladwa` (`ID`, `Data`, `Liczba`, `Opis`, `KrotkiTekst`) VALUES
(1, '2019-01-17 20:30:04', 111, 'OPIS', 'TEST');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `user`
--

CREATE TABLE `user` (
  `ID` int(11) NOT NULL,
  `Login` varchar(32) COLLATE utf16_polish_ci NOT NULL,
  `Password` varchar(512) COLLATE utf16_polish_ci NOT NULL,
  `Name` varchar(32) COLLATE utf16_polish_ci NOT NULL,
  `Surname` varchar(32) COLLATE utf16_polish_ci NOT NULL,
  `Privileges` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf16 COLLATE=utf16_polish_ci;

--
-- Zrzut danych tabeli `user`
--

INSERT INTO `user` (`ID`, `Login`, `Password`, `Name`, `Surname`, `Privileges`) VALUES
(14, 'ACieniu', '$XEREC$V1$10000$RBjE2ySaJT6A1syCKM5GzOvghyT4boklSmaZqE0+Qu9HuxHW', 'Adrian', 'Cieniuch', 1),
(19, 'KSladko', '$XEREC$V1$10000$D7IR9qjsBmmQmO538AqQ0o9+LXGqlaIygNFRV1Q9u+Jdvtv0', 'Konrad', 'Sladkowski', 2);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `usertableinfo`
--

CREATE TABLE `usertableinfo` (
  `ID` int(11) NOT NULL,
  `TableName` varchar(150) COLLATE utf16_polish_ci NOT NULL,
  `ColumnsType` varchar(512) COLLATE utf16_polish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf16 COLLATE=utf16_polish_ci;

--
-- Zrzut danych tabeli `usertableinfo`
--

INSERT INTO `usertableinfo` (`ID`, `TableName`, `ColumnsType`) VALUES
(5, 'tabeladwa', 'Data#DATETIME|Liczba#INT|Opis#VARCHAR$2048|KrotkiTekst#VARCHAR$80'),
(8, 'tabeladwa', 'RR#VARCHAR$80|QE#VARCHAR$2048');

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `employees`
--
ALTER TABLE `employees`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `UserIndex` (`UserID`),
  ADD KEY `QualifID` (`QualifID`);

--
-- Indeksy dla tabeli `qualifications`
--
ALTER TABLE `qualifications`
  ADD PRIMARY KEY (`ID`);

--
-- Indeksy dla tabeli `tabeladwa`
--
ALTER TABLE `tabeladwa`
  ADD PRIMARY KEY (`ID`);

--
-- Indeksy dla tabeli `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`ID`) USING BTREE,
  ADD UNIQUE KEY `Login` (`Login`) USING BTREE;

--
-- Indeksy dla tabeli `usertableinfo`
--
ALTER TABLE `usertableinfo`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT dla tabeli `employees`
--
ALTER TABLE `employees`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT dla tabeli `qualifications`
--
ALTER TABLE `qualifications`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT dla tabeli `tabeladwa`
--
ALTER TABLE `tabeladwa`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT dla tabeli `user`
--
ALTER TABLE `user`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT dla tabeli `usertableinfo`
--
ALTER TABLE `usertableinfo`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
