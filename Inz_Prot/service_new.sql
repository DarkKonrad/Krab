-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 03 Lut 2019, 15:45
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
(7, 'TTYYST', 'QWER', '2018-12-11', '1234567', 'sggsg', '2018-11-27', '2018-12-13', 'R', NULL, NULL);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `juxtapositions`
--

CREATE TABLE `juxtapositions` (
  `ID` int(11) NOT NULL,
  `JuxName` varchar(256) COLLATE utf16_polish_ci NOT NULL,
  `Components` varchar(3072) COLLATE utf16_polish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf16 COLLATE=utf16_polish_ci;

--
-- Zrzut danych tabeli `juxtapositions`
--

INSERT INTO `juxtapositions` (`ID`, `JuxName`, `Components`) VALUES
(1, 'ZEST', 'test2%Data2#DATETIME|tabeladwa%Data#DATETIME'),
(4, 'NOweJakies', 'test2%Data2#DATETIME|test%LiczbaZmienna#FLOAT|tabeladwa%Liczba#INT');

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
-- Struktura tabeli dla tabeli `t2`
--

CREATE TABLE `t2` (
  `ID` int(11) NOT NULL,
  `k1` float DEFAULT NULL,
  `k2` int(11) DEFAULT NULL,
  `K3` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf16 COLLATE=utf16_polish_ci;

--
-- Zrzut danych tabeli `t2`
--

INSERT INTO `t2` (`ID`, `k1`, `k2`, `K3`) VALUES
(1, 111, 0, 12),
(2, 1, 0, 121),
(3, 3, 0, 121),
(4, 0, 0, 1);

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
-- Struktura tabeli dla tabeli `test`
--

CREATE TABLE `test` (
  `ID` int(11) NOT NULL,
  `DATA` datetime DEFAULT NULL,
  `LiczbaZmienna` float DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf16 COLLATE=utf16_polish_ci;

--
-- Zrzut danych tabeli `test`
--

INSERT INTO `test` (`ID`, `DATA`, `LiczbaZmienna`) VALUES
(1, '2019-01-03 22:40:45', 12.123),
(2, '2019-01-21 22:40:56', 0.998),
(3, '2019-01-28 20:50:49', 42.7);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `test2`
--

CREATE TABLE `test2` (
  `ID` int(11) NOT NULL,
  `Data1` datetime DEFAULT NULL,
  `Data2` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf16 COLLATE=utf16_polish_ci;

--
-- Zrzut danych tabeli `test2`
--

INSERT INTO `test2` (`ID`, `Data1`, `Data2`) VALUES
(1, '2019-01-12 14:42:04', '2019-02-28 14:42:04'),
(2, '2019-01-11 14:42:13', '2019-02-17 15:19:54');

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
(19, 'KSladko', '$XEREC$V1$10000$D7IR9qjsBmmQmO538AqQ0o9+LXGqlaIygNFRV1Q9u+Jdvtv0', 'Konrad', 'Sladkowski', 2);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `usertableinfo`
--

CREATE TABLE `usertableinfo` (
  `ID` int(11) NOT NULL,
  `TableName` varchar(150) COLLATE utf16_polish_ci NOT NULL,
  `ColumnsType` varchar(8192) COLLATE utf16_polish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf16 COLLATE=utf16_polish_ci;

--
-- Zrzut danych tabeli `usertableinfo`
--

INSERT INTO `usertableinfo` (`ID`, `TableName`, `ColumnsType`) VALUES
(5, 'tabeladwa', 'Data#DATETIME|Liczba#INT|Opis#VARCHAR$2048|KrotkiTekst#VARCHAR$80'),
(17, 'test2', 'Data1#DATETIME|Data2#DATETIME'),
(19, 'test', 'DATA#DATETIME|LiczbaZmienna#FLOAT');

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `employees`
--
ALTER TABLE `employees`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `PESEL` (`PESEL`),
  ADD KEY `UserIndex` (`UserID`),
  ADD KEY `QualifID` (`QualifID`);

--
-- Indeksy dla tabeli `juxtapositions`
--
ALTER TABLE `juxtapositions`
  ADD PRIMARY KEY (`ID`);

--
-- Indeksy dla tabeli `qualifications`
--
ALTER TABLE `qualifications`
  ADD PRIMARY KEY (`ID`);

--
-- Indeksy dla tabeli `t2`
--
ALTER TABLE `t2`
  ADD PRIMARY KEY (`ID`);

--
-- Indeksy dla tabeli `tabeladwa`
--
ALTER TABLE `tabeladwa`
  ADD PRIMARY KEY (`ID`);

--
-- Indeksy dla tabeli `test`
--
ALTER TABLE `test`
  ADD PRIMARY KEY (`ID`);

--
-- Indeksy dla tabeli `test2`
--
ALTER TABLE `test2`
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
-- AUTO_INCREMENT dla tabeli `juxtapositions`
--
ALTER TABLE `juxtapositions`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT dla tabeli `qualifications`
--
ALTER TABLE `qualifications`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT dla tabeli `t2`
--
ALTER TABLE `t2`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT dla tabeli `tabeladwa`
--
ALTER TABLE `tabeladwa`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT dla tabeli `test`
--
ALTER TABLE `test`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT dla tabeli `test2`
--
ALTER TABLE `test2`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT dla tabeli `user`
--
ALTER TABLE `user`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT dla tabeli `usertableinfo`
--
ALTER TABLE `usertableinfo`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
