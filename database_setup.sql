-- Land Registration System Database Setup
-- Run this in phpMyAdmin: http://localhost/phpmyadmin/

CREATE DATABASE IF NOT EXISTS LandRegistrationDB
    CHARACTER SET utf8mb4
    COLLATE utf8mb4_unicode_ci;

USE LandRegistrationDB;

CREATE TABLE IF NOT EXISTS LandParcels (
    ParcelID       INT NOT NULL AUTO_INCREMENT,
    ParcelNumber   VARCHAR(30)  NOT NULL,
    OwnerName      VARCHAR(100) NOT NULL,
    Location       VARCHAR(150) NOT NULL,
    AreaSqMeters   DECIMAL(12,2) NOT NULL,
    LandUse        VARCHAR(100) NOT NULL,
    RegistrationDate DATE NOT NULL,
    PRIMARY KEY (ParcelID),
    UNIQUE (ParcelNumber)
) ENGINE=InnoDB
  DEFAULT CHARACTER SET utf8mb4
  COLLATE utf8mb4_unicode_ci;

-- Sample records
INSERT INTO LandParcels (ParcelNumber, OwnerName, Location, AreaSqMeters, LandUse, RegistrationDate)
VALUES
    ('LND-001', 'Alice Mukamana',   'Kigali, Gasabo',    500.00,  'Residential', '2024-01-15'),
    ('LND-002', 'Jean Niyonzima',   'Kigali, Kicukiro',  1200.50, 'Commercial',  '2024-03-22'),
    ('LND-003', 'Grace Uwimana',    'Musanze, Kinigi',   3400.00, 'Agricultural','2024-06-10');

SELECT * FROM LandParcels;
