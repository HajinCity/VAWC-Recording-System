/*
 Navicat Premium Data Transfer

 Source Server         : 3CafePOS
 Source Server Type    : MySQL
 Source Server Version : 80035
 Source Host           : localhost:3306
 Source Schema         : vawcrsdb

 Target Server Type    : MySQL
 Target Server Version : 80035
 File Encoding         : 65001

 Date: 13/05/2024 09:15:42
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for caselist
-- ----------------------------
DROP TABLE IF EXISTS `caselist`;
CREATE TABLE `caselist`  (
  `caseNo` int NOT NULL,
  `comp_ID` int NULL DEFAULT NULL,
  `case_cLastName` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `case_cFirstName` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `case_cAge` int NULL DEFAULT NULL,
  `respo_ID` int NULL DEFAULT NULL,
  `case_ComplaintDate` date NULL DEFAULT NULL,
  `case_rLastName` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `case_rFirstName` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `case_rAlias` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `case_Violation` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `case_SubViolation` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `case_ReferredTo` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `case_Status` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `case_Description` varchar(1000) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `case_incidentDate` date NULL DEFAULT NULL,
  `case_plcofincident` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `case_purok` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `case_barangay` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `case_municipality` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `case_province` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `case_region` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `case_respoIdentifyingMarks` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  PRIMARY KEY (`caseNo`) USING BTREE,
  INDEX `cplnt_Age`(`case_cAge`) USING BTREE,
  INDEX `comp_FN`(`case_cFirstName`) USING BTREE,
  INDEX `comp_LN`(`case_cLastName`) USING BTREE,
  INDEX `respo_Alias`(`case_rAlias`) USING BTREE,
  INDEX `respo_FN`(`case_rFirstName`) USING BTREE,
  INDEX `respo_LN`(`case_rLastName`) USING BTREE,
  INDEX `comp_ID`(`comp_ID`) USING BTREE,
  INDEX `respo_ID`(`respo_ID`) USING BTREE,
  CONSTRAINT `caselist_ibfk_1` FOREIGN KEY (`comp_ID`) REFERENCES `complainant` (`comp_ID`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `caselist_ibfk_2` FOREIGN KEY (`respo_ID`) REFERENCES `respondent` (`respo_ID`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of caselist
-- ----------------------------
INSERT INTO `caselist` VALUES (220001, NULL, 'Tabacon', 'sdf', 12, NULL, '2024-04-12', 'asdf', 'sadf', 'asdf', 'R.A. 9262: Anti Violence Against Women and their Children Act', 'Psychological', 'PNP', 'Pending', 'asdfasdf', '2024-03-06', 'Religious Institutions', 'asdf', 'sdfasdf', 'asdfas', 'dfasd', 'asdf', 'asdfasdfasdf');
INSERT INTO `caselist` VALUES (220002, NULL, 'Tabacon', 'Carlos David', 12, NULL, '2024-04-14', 'sf', 'sd', 'sdf', 'R.A. 9262: Anti Violence Against Women and their Children Act', 'Sexual Abuse', 'PNP', 'Pending', 'asdfasdf', '2024-04-01', 'Religious Institutions', 'asdf', 'asdf', 'sdfa', 'sdfa', 'asdf', 'asdfasd');
INSERT INTO `caselist` VALUES (220003, NULL, 'asdf', 'sdf', NULL, NULL, '2024-05-06', NULL, NULL, NULL, '', '', '', '', NULL, '2024-05-06', '', NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `caselist` VALUES (220004, NULL, 'asdf', 'sdfasd', NULL, NULL, '2024-05-09', NULL, NULL, NULL, '', '', '', '', NULL, '2024-05-09', '', NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `caselist` VALUES (220005, NULL, 'asdf', 'dfa', NULL, NULL, '2024-05-09', NULL, NULL, NULL, '', '', '', '', NULL, '2024-05-09', '', NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `caselist` VALUES (220006, NULL, 'asdfasf', NULL, NULL, NULL, '2024-05-12', NULL, NULL, NULL, '', '', '', '', NULL, '2024-05-12', '', NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `caselist` VALUES (220007, NULL, 'dfasd', 'xvxffsd', NULL, NULL, '2024-05-12', NULL, NULL, NULL, '', '', '', '', NULL, '2024-05-12', '', NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `caselist` VALUES (220008, NULL, 'sdfa', 'asdef', 12, NULL, '2024-05-12', NULL, NULL, NULL, '', '', '', '', NULL, '2024-05-12', '', NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `caselist` VALUES (220009, NULL, 'asdfa', 'asdfasdfasdf', NULL, NULL, '2024-05-12', NULL, NULL, NULL, '', '', '', '', NULL, '2024-05-12', '', NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `caselist` VALUES (220010, NULL, 'asdfasd', 'sdfasdf', NULL, NULL, '2024-05-12', NULL, NULL, NULL, '', '', '', '', NULL, '2024-05-12', '', NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `caselist` VALUES (220011, NULL, 'asdf', 'fas', NULL, NULL, '2024-05-12', NULL, NULL, NULL, '', '', '', '', NULL, '2024-05-12', '', NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `caselist` VALUES (220012, NULL, 'sdfasdf', 'dfasd', NULL, NULL, '2024-05-12', NULL, NULL, NULL, '', '', '', '', NULL, '2024-05-12', '', NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `caselist` VALUES (220013, NULL, 'sdfas', 'dfasdf', NULL, NULL, '2024-05-12', NULL, NULL, NULL, '', '', '', '', NULL, '2024-05-12', '', NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `caselist` VALUES (220014, NULL, 'fdasd', NULL, NULL, NULL, '2024-05-12', NULL, NULL, NULL, '', '', '', '', NULL, '2024-05-12', '', NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `caselist` VALUES (220015, NULL, 'asdfas', 'dfasd', NULL, NULL, '2024-05-12', NULL, NULL, NULL, '', '', '', '', NULL, '2024-05-12', '', NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `caselist` VALUES (220016, NULL, 'asdfasd', 'fasdf', NULL, NULL, '2024-05-12', NULL, NULL, NULL, '', '', '', '', NULL, '2024-05-12', '', NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `caselist` VALUES (220017, NULL, 'asfdasdf', 'dfasdfasd', NULL, NULL, '2024-05-12', NULL, NULL, NULL, '', '', '', '', NULL, '2024-05-12', '', NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `caselist` VALUES (220018, NULL, 'asdfa', 'dfasdf', NULL, NULL, '2024-05-12', NULL, NULL, NULL, '', '', '', '', NULL, '2024-05-12', '', NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `caselist` VALUES (220019, NULL, 'dfas', 'dfasdfasdf', NULL, NULL, '2024-05-12', NULL, NULL, NULL, '', '', '', '', NULL, '2024-05-12', '', NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `caselist` VALUES (220020, NULL, 'sdfas', 'sdfasdf', NULL, NULL, '2024-05-12', NULL, NULL, NULL, '', '', '', '', NULL, '2024-05-12', '', NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `caselist` VALUES (220021, NULL, 'asdf', 'sadfa', NULL, NULL, '2024-05-12', NULL, NULL, NULL, '', '', '', '', NULL, '2024-05-12', '', NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `caselist` VALUES (220022, NULL, 'asdfsadf', NULL, NULL, NULL, '2024-05-12', NULL, NULL, NULL, '', '', '', '', NULL, '2024-05-12', '', NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `caselist` VALUES (220023, NULL, 'dfasdf', NULL, NULL, NULL, '2024-05-12', NULL, NULL, NULL, '', '', '', '', NULL, '2024-05-12', '', NULL, NULL, NULL, NULL, NULL, NULL);

-- ----------------------------
-- Table structure for complainant
-- ----------------------------
DROP TABLE IF EXISTS `complainant`;
CREATE TABLE `complainant`  (
  `comp_ID` int NOT NULL,
  `caseNo` int NULL DEFAULT NULL,
  `comp_LastName` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `comp_FirstName` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `comp_MiddleName` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `comp_Sex` varchar(6) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `comp_Age` int NULL DEFAULT NULL,
  `comp_CivilStatus` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `comp_EducationalAttainmaent` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `comp_Religion` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `comp_ContactNo` varchar(11) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `comp_Purok` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `comp_Barangay` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `comp_City` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `comp_Province` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `comp_Region` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `comp_Nationality` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `comp_Occupation` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `comp_PassportId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  PRIMARY KEY (`comp_ID`) USING BTREE,
  INDEX `comp_LastName`(`comp_LastName`) USING BTREE,
  INDEX `comp_FirstName`(`comp_FirstName`) USING BTREE,
  INDEX `comp_Age`(`comp_Age`) USING BTREE,
  INDEX `caseNo`(`caseNo`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of complainant
-- ----------------------------
INSERT INTO `complainant` VALUES (160001, 220001, 'Tabacon', 'sdf', 'asdf', 'Male', 12, 'Single', 'No. Formal Education', 'Islam', '9874561321', 'sd', NULL, 'asdf', 'asd', 'fas', 'sdf', 'sda', 'sdf');
INSERT INTO `complainant` VALUES (160002, 220002, 'asdf', 'sdf', 'asd', 'Male', 12, 'Live-in', 'Vocational', 'asdf', '6846513132', 'asd', 'sda', 'dsg', 'sdqsdf', 'df', 'gd', 's', 'f');
INSERT INTO `complainant` VALUES (160003, 220003, 'asdf', 'sdf', NULL, '', NULL, '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `complainant` VALUES (160004, 220004, 'asdf', 'sdfasd', 'sdfas', '', NULL, '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `complainant` VALUES (160005, 220005, 'asdf', 'dfa', 'sadfasdfas', '', NULL, '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `complainant` VALUES (160006, 220006, 'asdfasf', NULL, NULL, '', NULL, '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `complainant` VALUES (160007, 220007, 'dfasd', 'xvxffsd', 'fasdf', '', NULL, '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `complainant` VALUES (160008, 220008, 'sdfa', 'asdef', 'asdf', 'Female', 12, '', '', 'asdfa', '135', 'adsf', 'asdf', 'asdfasdf', NULL, NULL, NULL, NULL, NULL);
INSERT INTO `complainant` VALUES (160009, 220009, 'asdfa', 'asdfasdfasdf', 'asdfasdf', '', NULL, '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `complainant` VALUES (160010, 220010, 'asdfasd', 'sdfasdf', 'sdfasd', '', NULL, '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `complainant` VALUES (160011, 220011, 'asdf', 'fas', 'fasd', '', NULL, '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `complainant` VALUES (160012, 220012, 'sdfasdf', 'dfasd', 'dfasdf', 'Female', NULL, '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `complainant` VALUES (160013, 220013, 'sdfas', 'dfasdf', 'dfasdf', '', NULL, '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `complainant` VALUES (160014, 220014, 'fdasd', NULL, 'sdfasdf', '', NULL, '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `complainant` VALUES (160015, 220015, 'asdfas', 'dfasd', 'dfasdfasdfasd', '', NULL, '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `complainant` VALUES (160016, 220016, 'asdfasd', 'fasdf', 'asdfasdfasdf', '', NULL, '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `complainant` VALUES (160017, 220017, 'asfdasdf', 'dfasdfasd', 'sdfasdf', '', NULL, '', '', 'asdf', NULL, 'sdfasd', 'asdfas', 'dfas', 'dfasd', 'asdf', 'sdfasdf', 'dfasdf', 'adsasdf');
INSERT INTO `complainant` VALUES (160018, 220018, 'asdfa', 'dfasdf', 'dfasdf', '', NULL, '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `complainant` VALUES (160019, 220019, 'dfas', 'dfasdfasdf', 'asdfasdf', '', NULL, '', '', 'aasd', NULL, 'sfasdfsadf', NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `complainant` VALUES (160020, 220020, 'sdfas', 'sdfasdf', NULL, '', NULL, '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `complainant` VALUES (160021, 220021, 'asdf', 'sadfa', 'dfasd', '', NULL, '', '', 'asdf', NULL, 'asdf', 'f', 'df', 'df', NULL, NULL, NULL, NULL);
INSERT INTO `complainant` VALUES (160022, 220022, 'asdfsadf', NULL, NULL, '', NULL, '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `complainant` VALUES (160023, 220023, 'dfasdf', NULL, NULL, '', NULL, '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);

-- ----------------------------
-- Table structure for organization
-- ----------------------------
DROP TABLE IF EXISTS `organization`;
CREATE TABLE `organization`  (
  `organization_id` int NOT NULL AUTO_INCREMENT,
  `h_orgName` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `h_orgPurok` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `h_orgBaranggay` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `h_orgMunicipality` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `h_orgProvince` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `h_orgRegion` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `intake_lastName` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `intake_firstName` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `intake_middleName` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `intake_Position` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `casemanager_lastName` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `casemanager_firstName` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `casemanager_middleName` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  PRIMARY KEY (`organization_id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of organization
-- ----------------------------
INSERT INTO `organization` VALUES (1, 'Dumalinao, Zamboanga Del Sur', '', 'Camanga', 'Dumalinao', 'Zamboanga Del Sur', 'Region IX', 'Tabacon', 'Carlos David', 'A', 'Secretary', 'Duhilag', 'Daryl Michael', 'A.');

-- ----------------------------
-- Table structure for respondent
-- ----------------------------
DROP TABLE IF EXISTS `respondent`;
CREATE TABLE `respondent`  (
  `respo_ID` int NOT NULL,
  `caseNo` int NULL DEFAULT NULL,
  `respo_LastName` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `respo_FirstName` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `respo_MiddleName` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `respo_Alias` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `respo_Sex` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `respo_Age` int NULL DEFAULT NULL,
  `respo_CivilStatus` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `respo_EducationalAttainment` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `respo_Religion` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `respo_ContactNo` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `respo_Purok` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `respo_Barangay` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `respo_City` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `respo_Province` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `respo_Region` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `respo_RelationshipToVictim` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `respo_Nationality` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `respo_Occupation` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `respo_PassportID` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  PRIMARY KEY (`respo_ID`) USING BTREE,
  INDEX `respo_LastName`(`respo_LastName`) USING BTREE,
  INDEX `respo_FirstName`(`respo_FirstName`) USING BTREE,
  INDEX `respo_Alias`(`respo_Alias`) USING BTREE,
  INDEX `caseNo`(`caseNo`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of respondent
-- ----------------------------
INSERT INTO `respondent` VALUES (190001, 220001, 'asdf', 'sadf', 'df', 'asdf', 'Male', 21, 'Single', 'College Level/Graduate', 'Islam', '9785646543', 'asdf', 'asdf', 'asdf', 'asdf', 'asd', 'Stranger', 'asdf', 'df', 'asdf');
INSERT INTO `respondent` VALUES (190002, 220002, 'sf', 'sd', 'sdf', 'sdf', 'Female', 32, 'Live-in', 'College Level/Graduate', 'sadfads', '6546498797', 'asdf', 'asdf', 'asdf', 'xc', 'gd', 'Current Spouse/Partner', 'sdf', 'df', 'sd');
INSERT INTO `respondent` VALUES (190003, 220003, NULL, NULL, NULL, NULL, '', NULL, '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, NULL);
INSERT INTO `respondent` VALUES (190004, 220004, NULL, NULL, NULL, NULL, '', NULL, '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, NULL);
INSERT INTO `respondent` VALUES (190005, 220005, NULL, NULL, NULL, NULL, '', NULL, '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, NULL);
INSERT INTO `respondent` VALUES (190006, 220006, NULL, NULL, NULL, NULL, '', NULL, '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, NULL);
INSERT INTO `respondent` VALUES (190007, 220007, NULL, NULL, NULL, NULL, '', NULL, '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, NULL);
INSERT INTO `respondent` VALUES (190008, 220008, NULL, NULL, NULL, NULL, '', NULL, '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, NULL);
INSERT INTO `respondent` VALUES (190009, 220009, NULL, NULL, NULL, NULL, '', NULL, '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, NULL);
INSERT INTO `respondent` VALUES (190010, 220010, NULL, NULL, NULL, NULL, '', NULL, '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, NULL);
INSERT INTO `respondent` VALUES (190011, 220011, NULL, NULL, NULL, NULL, '', NULL, '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, NULL);
INSERT INTO `respondent` VALUES (190012, 220012, NULL, NULL, NULL, NULL, '', NULL, '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, NULL);
INSERT INTO `respondent` VALUES (190013, 220013, NULL, NULL, NULL, NULL, '', NULL, '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, NULL);
INSERT INTO `respondent` VALUES (190014, 220014, NULL, NULL, NULL, NULL, '', NULL, '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, NULL);
INSERT INTO `respondent` VALUES (190015, 220015, NULL, NULL, NULL, NULL, '', NULL, '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, NULL);
INSERT INTO `respondent` VALUES (190016, 220016, NULL, NULL, NULL, NULL, '', NULL, '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, NULL);
INSERT INTO `respondent` VALUES (190017, 220017, NULL, NULL, NULL, NULL, '', NULL, '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, NULL);
INSERT INTO `respondent` VALUES (190018, 220018, NULL, NULL, NULL, NULL, '', NULL, '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, NULL);
INSERT INTO `respondent` VALUES (190019, 220019, NULL, NULL, NULL, NULL, '', NULL, '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, NULL);
INSERT INTO `respondent` VALUES (190020, 220020, NULL, NULL, NULL, NULL, '', NULL, '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, NULL);
INSERT INTO `respondent` VALUES (190021, 220021, NULL, NULL, NULL, NULL, '', NULL, '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, NULL);
INSERT INTO `respondent` VALUES (190022, 220022, NULL, NULL, NULL, NULL, '', NULL, '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, NULL);
INSERT INTO `respondent` VALUES (190023, 220023, NULL, NULL, NULL, NULL, '', NULL, '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, NULL);

-- ----------------------------
-- Table structure for users
-- ----------------------------
DROP TABLE IF EXISTS `users`;
CREATE TABLE `users`  (
  `user_id` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `user` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `password` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `role` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `firstName` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `middleName` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `lastName` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `status` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  PRIMARY KEY (`user_id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of users
-- ----------------------------
INSERT INTO `users` VALUES ('01', 'tabacon', '123', 'Administrator', 'Carlos David', 'A', 'Tabacon', 'active');
INSERT INTO `users` VALUES ('02', 'amira', '456', 'Administrator', 'Amira', 'S', 'Mohammad', 'active');
INSERT INTO `users` VALUES ('03', 'daryl', '789', 'Administrator', 'Daryl Michael', 'A', 'Duhilag', 'active');
INSERT INTO `users` VALUES ('04', 'vawc1', '321', 'Administrator', 'Amira', 'A', 'Beef', 'active');
INSERT INTO `users` VALUES ('4100', 'dashout', '456', NULL, 'Helman', 'S', 'Dacuma', 'active');
INSERT INTO `users` VALUES ('4101', 'Axes', '456', 'Administrator', 'Hasmin', 'A', 'Arsenal', 'active');
INSERT INTO `users` VALUES ('4102', 'asd', '789', 'Administrator', 'Aleah', 'A', 'Tabacon', 'active');
INSERT INTO `users` VALUES ('4103', 'Aqua', '789', 'Administrator', 'Regien Mae', 'D', 'Colot', 'active');
INSERT INTO `users` VALUES ('4104', 'tadashi21', 'carlos', 'Administrator', 'Jerman', 'A.', 'Pabatang', 'inactive');

SET FOREIGN_KEY_CHECKS = 1;
