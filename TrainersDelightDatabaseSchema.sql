DROP DATABASE IF EXISTS TrainersDelight
CREATE DATABASE TrainersDelight
USE TrainersDelight

DROP TABLE IF EXISTS Trainers
CREATE TABLE Trainers
(
TrainerID INT PRIMARY KEY,
FirstName NVARCHAR(20),
LastName NVARCHAR(20),
MiddleName NVARCHAR(20),
Email NVARCHAR(30),
Phone VARCHAR(20),
DateOfBirth DATE
)

DROP TABLE IF EXISTS Clients
CREATE TABLE Clients
(
ClientID INT PRIMARY KEY,
TrainerID INT FOREIGN KEY REFERENCES Trainers(TrainerID),
FirstName NVARCHAR(20),
LastName NVARCHAR(20),
MiddleName NVARCHAR(20),
Height INT,
Email NVARCHAR(30),
Phone INT,
DateOfBirth DATE
)

DROP TABLE IF EXISTS TrainerNotes
CREATE TABLE TrainerNotes
(
TrainerID INT FOREIGN KEY REFERENCES Trainers(TrainerID),
ClientID INT FOREIGN KEY REFERENCES Clients(ClientID),
NotesOnClient NVARCHAR(150)
)

DROP TABLE IF EXISTS ClientBMI
CREATE TABLE ClientBMI
(
ClientID INT FOREIGN KEY REFERENCES Clients(ClientID),
BMI DECIMAL,
DateOfMessurment DATE
)

DROP TABLE IF EXISTS ClientGoals
CREATE TABLE ClientGoals
(
ClientID INT FOREIGN KEY REFERENCES Clients(ClientID),
Goals NVARCHAR(150),
DateOfMessurment DATE
)

DROP TABLE IF EXISTS ClientBFP
CREATE TABLE CLientBFP
(
ClientID INT FOREIGN KEY REFERENCES Clients(ClientID),
BFP DECIMAL,
DateOfMessurment DATE
)

DROP TABLE IF EXISTS ClientWeight
CREATE TABLE ClientWeight
(
ClientID INT FOREIGN KEY REFERENCES Clients(ClientID),
WeightInPounds DECIMAL,
DateOfMessurment DATE
)
