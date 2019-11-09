CREATE SCHEMA Inf

CREATE TABLE INF.Region (
  Code varchar(50) NOT NULL,
  Name varchar(50) NULL,
  IssertDate datetime NULL,
  InsertUserName varchar(50) NULL,
  UpdateDate datetime NULL,
  UpdateUserName varchar(50) NULL,
  CONSTRAINT PK_Region_RegionCode PRIMARY KEY CLUSTERED (Code)
)
ON [PRIMARY]
GO

CREATE TABLE INF.PhoneNumber (
  PhoneNumber varchar(50) NOT NULL,
  AreaCode varchar(50) NOT NULL,
  RegionCode varchar(50) NOT NULL,
  Name varchar(50) NULL,
  Surname varchar(50) NULL,
  InsertUserName varchar(50) NULL,
  InsertDate datetime NULL,
  UpdateDate datetime NULL,
  UpdateUserName varchar(50) NULL,
  CONSTRAINT PK_PhoneNumber PRIMARY KEY NONCLUSTERED (PhoneNumber, RegionCode, AreaCode)
)
ON [PRIMARY]
GO

CREATE UNIQUE CLUSTERED INDEX UK_PhoneNumber
  ON INF.PhoneNumber (AreaCode, RegionCode, PhoneNumber)
  ON [PRIMARY]
GO

ALTER TABLE INF.PhoneNumber
  ADD CONSTRAINT FK_PhoneNumber_RegionCode FOREIGN KEY (RegionCode) REFERENCES INF.Region (Code)
GO