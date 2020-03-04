-- phpMyAdmin SQL Dump
-- version 5.0.1
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 04 Mar 2020, 18:14:33
-- Sunucu sürümü: 10.4.11-MariaDB
-- PHP Sürümü: 7.2.27

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `sorucozum`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `cografya`
--

CREATE TABLE `cografya` (
  `id` int(244) NOT NULL,
  `soru_icerik` varchar(244) NOT NULL,
  `dogru_cevap` varchar(244) NOT NULL,
  `cevap1` varchar(244) NOT NULL,
  `cevap2` varchar(244) NOT NULL,
  `cevap3` varchar(244) NOT NULL,
  `cevap4` varchar(244) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `fizik`
--

CREATE TABLE `fizik` (
  `id` int(244) NOT NULL,
  `soru_icerik` varchar(244) NOT NULL,
  `dogru_cevap` varchar(244) NOT NULL,
  `cevap1` varchar(244) NOT NULL,
  `cevap2` varchar(244) NOT NULL,
  `cevap3` varchar(244) NOT NULL,
  `cevap4` varchar(244) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kimya`
--

CREATE TABLE `kimya` (
  `id` int(244) NOT NULL,
  `soru_icerik` varchar(244) NOT NULL,
  `dogru_cevap` varchar(244) NOT NULL,
  `cevap1` varchar(244) NOT NULL,
  `cevap2` varchar(244) NOT NULL,
  `cevap3` varchar(244) NOT NULL,
  `cevap4` varchar(244) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `matematik`
--

CREATE TABLE `matematik` (
  `id` int(244) NOT NULL,
  `soru_icerik` varchar(244) NOT NULL,
  `dogru_cevap` varchar(244) NOT NULL,
  `cevap1` varchar(244) NOT NULL,
  `cevap2` varchar(244) NOT NULL,
  `cevap3` varchar(244) NOT NULL,
  `cevap4` varchar(244) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `turkce`
--

CREATE TABLE `turkce` (
  `id` int(244) NOT NULL,
  `soru_icerik` varchar(244) NOT NULL,
  `dogru_cevap` varchar(244) NOT NULL,
  `cevap1` varchar(244) NOT NULL,
  `cevap2` varchar(244) NOT NULL,
  `cevap3` varchar(244) NOT NULL,
  `cevap4` varchar(244) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Tablo döküm verisi `turkce`
--

INSERT INTO `turkce` (`id`, `soru_icerik`, `dogru_cevap`, `cevap1`, `cevap2`, `cevap3`, `cevap4`) VALUES
(1, '1.Aşağıdaki cümlelerin hangisinde abartı yoktur?', 'a', 'a', 'b', 'c', 'd'),
(2, 'soru2', 'b', 'a', 'b', 'c', 'd'),
(3, 'soru3', 'd', 'a', 'b', 'c', 'd'),
(4, 'soru4', 'd', 'a', 'b', 'c', 'd');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `uyeler`
--

CREATE TABLE `uyeler` (
  `id` int(255) NOT NULL,
  `kullaniciadi` varchar(244) NOT NULL,
  `sifre` varchar(244) NOT NULL,
  `mailadresi` varchar(255) NOT NULL,
  `kayit_tarihi` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Tablo döküm verisi `uyeler`
--

INSERT INTO `uyeler` (`id`, `kullaniciadi`, `sifre`, `mailadresi`, `kayit_tarihi`) VALUES
(1, 'asd', 'asd', 'asd', '2020-02-24 00:00:00'),
(2, 'asdasd', 'asdsd', 'asdasd', '2020-02-24 00:00:00'),
(3, 'oguz', 'oguz', 'oguz@oguz.com', '2020-02-24 00:00:00');

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `matematik`
--
ALTER TABLE `matematik`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `turkce`
--
ALTER TABLE `turkce`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `uyeler`
--
ALTER TABLE `uyeler`
  ADD PRIMARY KEY (`id`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `matematik`
--
ALTER TABLE `matematik`
  MODIFY `id` int(244) NOT NULL AUTO_INCREMENT;

--
-- Tablo için AUTO_INCREMENT değeri `turkce`
--
ALTER TABLE `turkce`
  MODIFY `id` int(244) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Tablo için AUTO_INCREMENT değeri `uyeler`
--
ALTER TABLE `uyeler`
  MODIFY `id` int(255) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
