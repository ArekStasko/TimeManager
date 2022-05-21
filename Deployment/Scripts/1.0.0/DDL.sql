create database TimeManager
go

use TimeManager
go

create table Category(
Id int NOT NULL identity(1,1), 
[Name] varchar(255) NOT NULL,
PRIMARY KEY (Id)
)

create table Activity(
Id int NOT NULL identity(1,1),
[Name] varchar(255) NOT NULL,
[Description] varchar(255) NOT NULL,
CategoryId int NOT NULL, 
PRIMARY KEY (Id)
)

