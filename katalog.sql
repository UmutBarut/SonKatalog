/*
 Navicat Premium Data Transfer

 Source Server         : mysql
 Source Server Type    : MySQL
 Source Server Version : 80030
 Source Host           : localhost:3306
 Source Schema         : katalog

 Target Server Type    : MySQL
 Target Server Version : 80030
 File Encoding         : 65001

 Date: 01/06/2023 01:20:33
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for __efmigrationshistory
-- ----------------------------
DROP TABLE IF EXISTS `__efmigrationshistory`;
CREATE TABLE `__efmigrationshistory`  (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of __efmigrationshistory
-- ----------------------------
INSERT INTO `__efmigrationshistory` VALUES ('20221223183549_init', '6.0.11');
INSERT INTO `__efmigrationshistory` VALUES ('20221223184728_init2', '6.0.11');
INSERT INTO `__efmigrationshistory` VALUES ('20230524103532_sjfhfsdkgfsd', '6.0.11');
INSERT INTO `__efmigrationshistory` VALUES ('20230524122634_ImagePathForMarkaAndUrun', '6.0.11');
INSERT INTO `__efmigrationshistory` VALUES ('20230531200629_price', '6.0.11');
INSERT INTO `__efmigrationshistory` VALUES ('20230531221936_deleteprice', '6.0.11');

-- ----------------------------
-- Table structure for aspnetroleclaims
-- ----------------------------
DROP TABLE IF EXISTS `aspnetroleclaims`;
CREATE TABLE `aspnetroleclaims`  (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RoleId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ClaimType` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ClaimValue` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_AspNetRoleClaims_RoleId`(`RoleId` ASC) USING BTREE,
  CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of aspnetroleclaims
-- ----------------------------

-- ----------------------------
-- Table structure for aspnetroles
-- ----------------------------
DROP TABLE IF EXISTS `aspnetroles`;
CREATE TABLE `aspnetroles`  (
  `Id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Name` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `NormalizedName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `RoleNameIndex`(`NormalizedName` ASC) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of aspnetroles
-- ----------------------------
INSERT INTO `aspnetroles` VALUES ('1', 'Admin', 'ADMIN', 'AD1234');

-- ----------------------------
-- Table structure for aspnetuserclaims
-- ----------------------------
DROP TABLE IF EXISTS `aspnetuserclaims`;
CREATE TABLE `aspnetuserclaims`  (
  `Id` int NOT NULL AUTO_INCREMENT,
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ClaimType` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ClaimValue` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_AspNetUserClaims_UserId`(`UserId` ASC) USING BTREE,
  CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of aspnetuserclaims
-- ----------------------------

-- ----------------------------
-- Table structure for aspnetuserlogins
-- ----------------------------
DROP TABLE IF EXISTS `aspnetuserlogins`;
CREATE TABLE `aspnetuserlogins`  (
  `LoginProvider` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProviderKey` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProviderDisplayName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`LoginProvider`, `ProviderKey`) USING BTREE,
  INDEX `IX_AspNetUserLogins_UserId`(`UserId` ASC) USING BTREE,
  CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of aspnetuserlogins
-- ----------------------------

-- ----------------------------
-- Table structure for aspnetuserroles
-- ----------------------------
DROP TABLE IF EXISTS `aspnetuserroles`;
CREATE TABLE `aspnetuserroles`  (
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `RoleId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`UserId`, `RoleId`) USING BTREE,
  INDEX `IX_AspNetUserRoles_RoleId`(`RoleId` ASC) USING BTREE,
  CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT,
  CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of aspnetuserroles
-- ----------------------------
INSERT INTO `aspnetuserroles` VALUES ('08a8362e-378c-4051-9879-789f0764026b', '1');

-- ----------------------------
-- Table structure for aspnetusers
-- ----------------------------
DROP TABLE IF EXISTS `aspnetusers`;
CREATE TABLE `aspnetusers`  (
  `Id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Pasif` tinyint(1) NOT NULL,
  `IsAdmin` tinyint(1) NOT NULL,
  `ImagePath` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `AdSoyad` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `UserName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `NormalizedUserName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Email` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `NormalizedEmail` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `SecurityStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `PhoneNumber` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime(6) NULL DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `UserNameIndex`(`NormalizedUserName` ASC) USING BTREE,
  INDEX `EmailIndex`(`NormalizedEmail` ASC) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of aspnetusers
-- ----------------------------
INSERT INTO `aspnetusers` VALUES ('07595780-7f7d-4a25-931d-9d83aa918248', 0, 0, NULL, NULL, '123', '123', '123@mail.com', '123@MAIL.COM', 0, 'AQAAAAEAACcQAAAAEEXbbrcLJzobDUGjuGg6MJZMaZWN3zhsDM2yITj+6SNybU/4Y2ppPlyhjZt5MVMZSw==', 'UZJKYWPTWGVIG6M5ZQ77YJW6X6WI7YV6', '5387bc9b-ea86-44b0-8f71-2263b18f69fa', NULL, 0, 0, NULL, 1, 0);
INSERT INTO `aspnetusers` VALUES ('08a8362e-378c-4051-9879-789f0764026b', 0, 1, 'e6b3ab37-0c9f-47ed-87c7-01dae38b15a7.jpeg', 'Umut Barut', 'umutbarut', 'UMUTBARUT', 'umut@mail.com', 'UMUT@MAIL.COM', 1, 'AQAAAAEAACcQAAAAEC4/lMOYAL5Vqp5daHSWjYKrAd2ZfJhCuOdsLcKtRulGyjDpVHIVy6ANRPa4VLPeJQ==', 'COXJ3VOOY3YLRRGZ5BISXLQIGSS3O2UF', 'dd888740-dcac-499a-a1d0-508f5c6e2c2b', '0544 518 20 03', 0, 0, NULL, 1, 0);
INSERT INTO `aspnetusers` VALUES ('74c93b28-f6dd-4c1a-99c9-de8efc5db306', 0, 0, '6f9ee026-13e5-4dad-a502-b3186a232c5a.jpeg', 'Deneme1', 'deneme1', 'DENEME1', 'asd@deneme.com', 'ASD@DENEME.COM', 0, 'AQAAAAEAACcQAAAAEMO4m3nfB6gDMbmmem6+Qh7JGS2Rf7FH0u4UjvAWOuAzfGk26jOqK0F1aksmCZDZyg==', 'PJKQZ4KCEJ5Z547QQAKWK2HACZOWL2QM', 'c0fb8ccf-6b0d-4394-8223-e4e39fb62f81', '', 0, 0, NULL, 1, 0);
INSERT INTO `aspnetusers` VALUES ('81646736-b018-4bd4-92dc-f9f988abe8a9', 0, 0, NULL, NULL, 'asd', 'ASD', 'asd@mail.com', 'ASD@MAIL.COM', 0, 'AQAAAAEAACcQAAAAEDvk2fFPE2McsRYY5V3n3nnEgzVEzCg4d4HAcy4/6554d1Ox0JvTVMdaSjrvXeus8w==', '7GE7RJD4TPVERUNO7MX6XM2NA7XOPVIM', 'd1c14c0c-d0cd-423c-b873-9650280b3e9d', NULL, 0, 0, NULL, 1, 0);
INSERT INTO `aspnetusers` VALUES ('85293f66-443a-4600-b425-90c21151b426', 0, 0, '6fd1b569-49a8-4b67-bcf1-243fe38ba95e.jpg', NULL, 'keremkalayci', 'KEREMKALAYCI', 'kalayci@mail.com', 'KALAYCI@MAIL.COM', 0, 'AQAAAAEAACcQAAAAEFSn0MFWYXjmsZO9JDYtiG7K/FG5SpEJ7sCfkpixjs6Y+CEwPsAmBxLYXhWHAcshng==', 'QRXNW4DJKIW2E46TOY26UUQFFE3GEUPS', 'd8498228-02a6-4011-9677-795c82b57342', '0541 514 12 43', 0, 0, NULL, 1, 0);
INSERT INTO `aspnetusers` VALUES ('a6f8a39e-a34d-4843-b906-22a3aa00b2b2', 0, 0, NULL, 'dsa', 'dsa', 'DSA', 'dsa@mail.com', 'DSA@MAIL.COM', 0, 'AQAAAAEAACcQAAAAEG20gVRNBIPiKW9x5JKA07xkakPWoFP3lIgOESCJgmvCY+tfXJ3KRIDkdnOkDuQh5g==', 'ZC6PS5LYSPPELGCNVI2WSEK2Y2XRPXGB', '09adfafe-13e4-4750-9f14-1cf39dec21ea', NULL, 0, 0, NULL, 1, 0);
INSERT INTO `aspnetusers` VALUES ('b3c131b8-96f3-4d26-8bfb-d4570d11d03f', 0, 0, NULL, NULL, '321', '321', '321@mail.com', '321@MAIL.COM', 0, 'AQAAAAEAACcQAAAAEGvaJpRU/PCBsHwP6ggNNc0usM5oeOSMD0B9x5Zu+Xg2vhD96kgo0UrentxLGtCohQ==', 'MR23CXYKSBSP4E2FQQB4JJVCRTCLFGRC', 'aa9ff611-7fef-4081-a3e2-1db03e251246', NULL, 0, 0, NULL, 1, 0);

-- ----------------------------
-- Table structure for aspnetusertokens
-- ----------------------------
DROP TABLE IF EXISTS `aspnetusertokens`;
CREATE TABLE `aspnetusertokens`  (
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LoginProvider` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Value` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  PRIMARY KEY (`UserId`, `LoginProvider`, `Name`) USING BTREE,
  CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of aspnetusertokens
-- ----------------------------

-- ----------------------------
-- Table structure for firmalar
-- ----------------------------
DROP TABLE IF EXISTS `firmalar`;
CREATE TABLE `firmalar`  (
  `FirmaID` bigint NOT NULL AUTO_INCREMENT,
  `FirmaAdi` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Siralama` bigint NOT NULL,
  `Pasif` tinyint(1) NOT NULL,
  PRIMARY KEY (`FirmaID`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 6 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of firmalar
-- ----------------------------
INSERT INTO `firmalar` VALUES (1, 'AYD', 0, 0);
INSERT INTO `firmalar` VALUES (2, 'TEKNOROT', 0, 0);
INSERT INTO `firmalar` VALUES (3, 'ASMETAL', 0, 0);
INSERT INTO `firmalar` VALUES (4, 'asd', 1, 0);
INSERT INTO `firmalar` VALUES (5, 'asdfgh', 1, 0);

-- ----------------------------
-- Table structure for kullanilanparcalar
-- ----------------------------
DROP TABLE IF EXISTS `kullanilanparcalar`;
CREATE TABLE `kullanilanparcalar`  (
  `UrunID` bigint NOT NULL,
  `UrunNo` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `KullanildigiParcaID` bigint NOT NULL AUTO_INCREMENT,
  `KullanildigiParcaAdi` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `KullanildigiParcaUrunNo` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `EslestirilenUrunNo` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Siralama` bigint NOT NULL,
  `Pasif` tinyint(1) NOT NULL,
  PRIMARY KEY (`KullanildigiParcaID`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 3 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of kullanilanparcalar
-- ----------------------------
INSERT INTO `kullanilanparcalar` VALUES (3, '38BM1001', 1, 'Alt Rotilli Kol/Salıncak Sol', '23BM0352', '23BM0353', 0, 0);
INSERT INTO `kullanilanparcalar` VALUES (1, '17AU1202', 2, 'Rotbaşı Sağ', '17AU1203', '17AU1203', 1, 0);
INSERT INTO `kullanilanparcalar` VALUES (4, '17AU1203', 3, 'Rotbaşı Sol', '17UA1202', '17AU1202', 0, 0);

-- ----------------------------
-- Table structure for markalar
-- ----------------------------
DROP TABLE IF EXISTS `markalar`;
CREATE TABLE `markalar`  (
  `MarkaID` bigint NOT NULL AUTO_INCREMENT,
  `MarkaAdi` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Siralama` bigint NOT NULL,
  `Pasif` tinyint(1) NOT NULL,
  `ImagePath` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  PRIMARY KEY (`MarkaID`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 13 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of markalar
-- ----------------------------
INSERT INTO `markalar` VALUES (1, 'AUDI', 1, 0, NULL);
INSERT INTO `markalar` VALUES (2, 'BMW', 0, 0, NULL);
INSERT INTO `markalar` VALUES (3, 'MERCEDES', 0, 0, NULL);
INSERT INTO `markalar` VALUES (4, 'VOLVO', 0, 0, NULL);
INSERT INTO `markalar` VALUES (5, 'FIAT', 0, 0, NULL);
INSERT INTO `markalar` VALUES (6, 'dsa', 1, 0, NULL);
INSERT INTO `markalar` VALUES (7, 'asdfghj', 1, 0, NULL);
INSERT INTO `markalar` VALUES (8, 'deneme321123', 1, 0, NULL);
INSERT INTO `markalar` VALUES (9, '123', 1, 0, NULL);
INSERT INTO `markalar` VALUES (10, 'asdfghj', 1, 0, NULL);
INSERT INTO `markalar` VALUES (11, 'lkmjnhbgfd', 1, 0, NULL);
INSERT INTO `markalar` VALUES (12, '1234tyrhgdfs', 1, 0, 'ad6f2ca0-ff48-42ea-8d29-85c6a2839409.jpeg');

-- ----------------------------
-- Table structure for modeller
-- ----------------------------
DROP TABLE IF EXISTS `modeller`;
CREATE TABLE `modeller`  (
  `ModelID` bigint NOT NULL AUTO_INCREMENT,
  `ModelAdi` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `TipID` bigint NOT NULL,
  `MarkaID` bigint NOT NULL,
  `Siralama` bigint NOT NULL,
  `Pasif` tinyint(1) NOT NULL,
  PRIMARY KEY (`ModelID`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 12 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of modeller
-- ----------------------------
INSERT INTO `modeller` VALUES (1, 'A3 Sportback (8YA) [11/2019 ->]', 1, 1, 1, 0);
INSERT INTO `modeller` VALUES (2, 'RS6 (4G5,4GD-C7) [01/2013 - 09/2018]', 2, 1, 0, 0);
INSERT INTO `modeller` VALUES (3, '5 Serie Touring (G31) [03/2017 ->]', 3, 2, 0, 0);
INSERT INTO `modeller` VALUES (4, 'M5 (F10) [09/2011 - 10/2016]', 4, 2, 0, 0);
INSERT INTO `modeller` VALUES (5, 'asdasda', 1, 1, 1, 0);
INSERT INTO `modeller` VALUES (6, 'gegege', 1, 1, 1, 0);
INSERT INTO `modeller` VALUES (7, 'lnlnln', 3, 2, 1, 0);
INSERT INTO `modeller` VALUES (8, 'A-CLASS Sedan (V177) [09/2018 ->]', 6, 3, 0, 0);
INSERT INTO `modeller` VALUES (9, 'Fiorino Combi', 7, 5, 1, 0);
INSERT INTO `modeller` VALUES (10, 'V40 Hatchback (525) [03/2012 ->]', 8, 4, 1, 0);
INSERT INTO `modeller` VALUES (11, '1234567asdfg', 9, 6, 1, 0);

-- ----------------------------
-- Table structure for oemler
-- ----------------------------
DROP TABLE IF EXISTS `oemler`;
CREATE TABLE `oemler`  (
  `FirmaID` bigint NOT NULL AUTO_INCREMENT,
  `UrunID` bigint NOT NULL,
  `OEMno` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `MarkaID` bigint NOT NULL,
  `Siralama` bigint NOT NULL,
  `Pasif` tinyint(1) NOT NULL,
  PRIMARY KEY (`FirmaID`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 16 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of oemler
-- ----------------------------
INSERT INTO `oemler` VALUES (1, 1, '1K0423811J', 1, 1, 0);
INSERT INTO `oemler` VALUES (2, 2, '8K0 505 465 G', 1, 0, 0);
INSERT INTO `oemler` VALUES (8, 1, '1234567890', 2, 1, 0);
INSERT INTO `oemler` VALUES (9, 3, '768732453', 1, 1, 0);
INSERT INTO `oemler` VALUES (10, 3, '95670', 2, 1, 0);
INSERT INTO `oemler` VALUES (11, 4, '3454253', 4, 1, 0);
INSERT INTO `oemler` VALUES (12, 5, '15mk12', 3, 0, 0);
INSERT INTO `oemler` VALUES (13, 15, '123', 5, 1, 0);
INSERT INTO `oemler` VALUES (14, 16, '321', 4, 1, 0);
INSERT INTO `oemler` VALUES (15, 1, '12345432345432', 6, 1, 0);

-- ----------------------------
-- Table structure for referanslar
-- ----------------------------
DROP TABLE IF EXISTS `referanslar`;
CREATE TABLE `referanslar`  (
  `RefID` bigint NOT NULL AUTO_INCREMENT,
  `RefNo` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `FirmaID` bigint NOT NULL,
  `UrunID` bigint NOT NULL,
  `Siralama` bigint NOT NULL,
  `Pasif` tinyint(1) NOT NULL,
  PRIMARY KEY (`RefID`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 7 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of referanslar
-- ----------------------------
INSERT INTO `referanslar` VALUES (1, '91-02248', 1, 1, 1, 0);
INSERT INTO `referanslar` VALUES (2, 'A-597', 2, 2, 0, 0);
INSERT INTO `referanslar` VALUES (3, 'dasdas123', 1, 1, 1, 0);
INSERT INTO `referanslar` VALUES (4, '65GH-12', 3, 4, 1, 0);
INSERT INTO `referanslar` VALUES (5, '1234', 1, 5, 0, 0);
INSERT INTO `referanslar` VALUES (6, '1234567uytrsasdfgnm', 5, 17, 1, 0);

-- ----------------------------
-- Table structure for tipler
-- ----------------------------
DROP TABLE IF EXISTS `tipler`;
CREATE TABLE `tipler`  (
  `TipID` bigint NOT NULL AUTO_INCREMENT,
  `TipAdi` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `MarkaID` bigint NOT NULL,
  `Siralama` bigint NOT NULL,
  `Pasif` tinyint(1) NOT NULL,
  PRIMARY KEY (`TipID`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 11 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tipler
-- ----------------------------
INSERT INTO `tipler` VALUES (1, 'A3', 1, 1, 0);
INSERT INTO `tipler` VALUES (2, 'RS6', 1, 0, 0);
INSERT INTO `tipler` VALUES (3, '5 SERIE', 2, 0, 0);
INSERT INTO `tipler` VALUES (4, 'M5', 2, 0, 0);
INSERT INTO `tipler` VALUES (5, 'egege', 1, 0, 0);
INSERT INTO `tipler` VALUES (6, 'A-CLASS', 3, 0, 0);
INSERT INTO `tipler` VALUES (7, 'Fiorino', 5, 0, 0);
INSERT INTO `tipler` VALUES (8, 'V40', 4, 0, 0);
INSERT INTO `tipler` VALUES (9, 'asdfghgfdsa', 6, 0, 0);
INSERT INTO `tipler` VALUES (10, 'asdsdas', 3, 0, 0);

-- ----------------------------
-- Table structure for urun_araba
-- ----------------------------
DROP TABLE IF EXISTS `urun_araba`;
CREATE TABLE `urun_araba`  (
  `Urun_ArabaID` bigint NOT NULL AUTO_INCREMENT,
  `UrunID` bigint NOT NULL,
  `MarkaID` bigint NOT NULL,
  `TipID` bigint NOT NULL,
  `ModelID` bigint NOT NULL,
  PRIMARY KEY (`Urun_ArabaID`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of urun_araba
-- ----------------------------

-- ----------------------------
-- Table structure for urunler
-- ----------------------------
DROP TABLE IF EXISTS `urunler`;
CREATE TABLE `urunler`  (
  `UrunID` bigint NOT NULL AUTO_INCREMENT,
  `UrunAdi` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `UrunNo` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Olculer` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `EANno` bigint NOT NULL,
  `EslestirilenUrunNo` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `KullanildigiParcaID` bigint NULL DEFAULT NULL,
  `Siralama` bigint NOT NULL,
  `Pasif` tinyint(1) NOT NULL,
  `ImagePath` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  PRIMARY KEY (`UrunID`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 24 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of urunler
-- ----------------------------
INSERT INTO `urunler` VALUES (1, 'Rotbaşı Sol', '17AU1202', '0,45 kg', 0, '17AU1203', NULL, 0, 0, '82c97d5d-8b92-4b96-a4b5-7bf1f6ffc1a9.png');
INSERT INTO `urunler` VALUES (2, 'Arka Viraj Rotu', '26AU2500\r\n', 'L:60,5mm Plastic / 0,11 kg', 8680617016575, NULL, NULL, 0, 0, 'urun2.jpg');
INSERT INTO `urunler` VALUES (3, 'Salıncak Burcu', '38BM1001', 'di:Ø14.2 do:Ø43.3 L:55 / 0,3 kg', 8680617021289, '', NULL, 0, 0, 'urun3.jpg');
INSERT INTO `urunler` VALUES (4, 'Rotbaşı Sağ', '17AU1203', '0,45 kg', 8680617018647, '17AU1202', NULL, 1, 0, 'urun1.jpg');
INSERT INTO `urunler` VALUES (11, '123', '123', '123', 123, '123', NULL, 0, 0, '106c88f7-8e39-464b-996f-45ed9397789b.jpg');
INSERT INTO `urunler` VALUES (13, '12', '12', '12', 12, '12', NULL, 1, 0, 'd672be07-3fc4-408b-825a-952f3850e45b.png');
INSERT INTO `urunler` VALUES (14, '0', '0', '0', 0, '0', NULL, 1, 0, 'f638c239-9e57-4a9e-999f-203eac0c1306.png');
INSERT INTO `urunler` VALUES (15, 'x', 'y', 'x', 0, 'x', NULL, 0, 0, '410fd6cf-ae47-4c93-bea6-7bd9c1608aba.jpg');
INSERT INTO `urunler` VALUES (16, 'a', '15mk12', 'asd', 0, 'sadasdasd', NULL, 0, 0, '41f8e265-c378-4604-9c5a-55a6fa1d3810.jpg');
INSERT INTO `urunler` VALUES (17, 'Rotbaşı Sağ 23454567', '12345678', '123456789', 123456, '1234567888', NULL, 0, 0, '9f8035dd-2593-43a8-bc8c-5097997187fa.jpg');
INSERT INTO `urunler` VALUES (18, 'asdfgffsdgfhh', 'asdfdhgj', 'fasdfas342', 0, '23423faea', NULL, 1, 0, '2ed22a92-3a4b-4d61-a2a1-fe2262947a1c.jpg');
INSERT INTO `urunler` VALUES (19, 'sdffgggfds', 'dsfgfhggffsgd', 'gddsgd', 0, 'dsfgdg', NULL, 1, 0, 'b0d7bf94-56f4-4843-9f5d-0c818f7e3883.jpg');

-- ----------------------------
-- Table structure for uyumluluklar
-- ----------------------------
DROP TABLE IF EXISTS `uyumluluklar`;
CREATE TABLE `uyumluluklar`  (
  `UyumID` bigint NOT NULL AUTO_INCREMENT,
  `UrunID` bigint NOT NULL,
  `Uyum` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Siralama` bigint NOT NULL,
  `ModelID` bigint NOT NULL,
  PRIMARY KEY (`UyumID`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 26 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of uyumluluklar
-- ----------------------------
INSERT INTO `uyumluluklar` VALUES (1, 2, 'All Types', 1, 1);
INSERT INTO `uyumluluklar` VALUES (2, 1, 'All Types', 1, 1);
INSERT INTO `uyumluluklar` VALUES (3, 2, 'All Types', 1, 3);
INSERT INTO `uyumluluklar` VALUES (4, 4, 'Between (10/1967 - 06/1972)', 1, 5);
INSERT INTO `uyumluluklar` VALUES (5, 5, 'All Types', 1, 4);
INSERT INTO `uyumluluklar` VALUES (6, 13, 'All Types', 1, 1);
INSERT INTO `uyumluluklar` VALUES (7, 13, 'All Types', 1, 2);
INSERT INTO `uyumluluklar` VALUES (8, 13, 'All Types', 1, 3);
INSERT INTO `uyumluluklar` VALUES (9, 14, 'All Types', 1, 8);
INSERT INTO `uyumluluklar` VALUES (10, 15, 'All Types', 1, 8);
INSERT INTO `uyumluluklar` VALUES (11, 15, 'All Types', 1, 9);
INSERT INTO `uyumluluklar` VALUES (12, 16, 'All Types', 1, 6);
INSERT INTO `uyumluluklar` VALUES (13, 1, 'All Types', 1, 3);
INSERT INTO `uyumluluklar` VALUES (14, 17, 'All Types', 1, 3);
INSERT INTO `uyumluluklar` VALUES (15, 17, 'All Types', 1, 5);
INSERT INTO `uyumluluklar` VALUES (16, 17, '1235y6543234565', 1, 11);
INSERT INTO `uyumluluklar` VALUES (17, 18, 'All Types', 1, 11);
INSERT INTO `uyumluluklar` VALUES (18, 19, 'All Types', 1, 11);
INSERT INTO `uyumluluklar` VALUES (19, 20, 'All Types', 1, 1);
INSERT INTO `uyumluluklar` VALUES (20, 20, 'All Types', 1, 9);
INSERT INTO `uyumluluklar` VALUES (21, 21, 'All Types', 1, 1);
INSERT INTO `uyumluluklar` VALUES (22, 22, 'All Types', 1, 2);
INSERT INTO `uyumluluklar` VALUES (23, 23, 'All Types', 1, 1);
INSERT INTO `uyumluluklar` VALUES (24, 23, 'All Types', 1, 2);
INSERT INTO `uyumluluklar` VALUES (25, 23, 'All Types', 1, 4);

-- ----------------------------
-- View structure for detaytablo
-- ----------------------------
DROP VIEW IF EXISTS `detaytablo`;
CREATE ALGORITHM = UNDEFINED SQL SECURITY DEFINER VIEW `detaytablo` AS select `markalar`.`MarkaAdi` AS `MarkaAdi`,`tipler`.`TipAdi` AS `TipAdi`,`modeller`.`ModelAdi` AS `ModelAdi`,`uyumluluklar`.`Uyum` AS `Uyum`,`urunler`.`UrunID` AS `UrunID` from ((((`modeller` join `tipler` on((`modeller`.`TipID` = `tipler`.`TipID`))) join `markalar` on((`markalar`.`MarkaID` = `tipler`.`MarkaID`))) join `uyumluluklar` on((`modeller`.`ModelID` = `uyumluluklar`.`ModelID`))) join `urunler` on((`uyumluluklar`.`UrunID` = `urunler`.`UrunID`)));

-- ----------------------------
-- View structure for searchresult
-- ----------------------------
DROP VIEW IF EXISTS `searchresult`;
CREATE ALGORITHM = UNDEFINED SQL SECURITY DEFINER VIEW `searchresult` AS select distinct `urunler`.`UrunID` AS `UrunID`,`urunler`.`UrunNo` AS `UrunNo`,`urunler`.`UrunAdi` AS `UrunAdi`,`urunler`.`Olculer` AS `Olculer`,`oemler`.`OEMno` AS `OEMno`,`urunler`.`ImagePath` AS `ImagePath` from ((((((`urunler` left join `oemler` on((`urunler`.`UrunID` = `oemler`.`UrunID`))) left join `markalar` on((`markalar`.`MarkaID` = `oemler`.`MarkaID`))) left join `tipler` on((`tipler`.`MarkaID` = `markalar`.`MarkaID`))) left join `modeller` on((`modeller`.`TipID` = `tipler`.`TipID`))) left join `referanslar` on((`urunler`.`UrunID` = `referanslar`.`UrunID`))) left join `firmalar` on((`referanslar`.`FirmaID` = `firmalar`.`FirmaID`)));

SET FOREIGN_KEY_CHECKS = 1;
