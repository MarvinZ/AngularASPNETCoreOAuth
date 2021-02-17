DROP TABLE IF EXISTS Client;
CREATE TABLE Client
(Id int NOT NULL IDENTITY(1,1) PRIMARY KEY ,
Name nvarchar(250) NOT NULL,
DomainName nvarchar(250) NOT NULL,
Phone nvarchar(250) NOT NULL,
Email nvarchar(250) NOT NULL,
RegistrationDate datetime NOT NULL,
CreateDatetime datetime NOT NULL,
CreateUser nvarchar(100) NOT NULL,
LastModifiedUser nvarchar(100) NULL,
LastModificationDatetime datetime NULL,
DeactivateDatetime datetime NULL,
DeactivateUser nvarchar(100) NULL);

DROP TABLE IF EXISTS Student;
CREATE TABLE Student
(Id int NOT NULL IDENTITY(1,1) PRIMARY KEY ,
ClientId int NOT NULL,
Name nvarchar(250) NOT NULL,
LastName1 nvarchar(250) NOT NULL,
LastName2 nvarchar(250) NULL,
Birthday datetime NOT NULL,
Gender char null,
RegistrationDate datetime NOT NULL,
CreateDatetime datetime NOT NULL,
CreateUser nvarchar(100) NOT NULL,
LastModifiedUser nvarchar(100) NULL,
LastModificationDatetime datetime NULL,
DeactivateDatetime datetime NULL,
DeactivateUser nvarchar(100) NULL);


ALTER TABLE Student
ADD FOREIGN KEY (ClientId) REFERENCES Client(Id);


--DROP TABLE IF EXISTS ParentalType;
--CREATE TABLE ParentalType
--(Id int NOT NULL IDENTITY(1,1) PRIMARY KEY ,
--Name nvarchar(250) NOT NULL,

--CreateDatetime datetime NOT NULL,
--CreateUser nvarchar(100) NOT NULL,
--LastModifiedUser nvarchar(100) NULL,
--LastModificationDatetime datetime NULL,
--DeactivateDatetime datetime NULL,
--DeactivateUser nvarchar(100) NULL);




DROP TABLE IF EXISTS Parent;
CREATE TABLE Parent
(Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
 ClientId int NOT NULL,
 --ParentalTypeId int NOT NULL,
Name nvarchar(250) NOT NULL,
CountryId nvarchar(250) NOT NULL,
Address nvarchar(1000) NOT NULL,
LastName1 nvarchar(250) NOT NULL,
LastName2 nvarchar(250) NULL,
Birthday datetime NOT NULL,
Gender char null,
Email nvarchar(250) NOT NULL,
Phone nvarchar(250) NOT NULL,
RegistrationDate datetime NOT NULL,
CreateDatetime datetime NOT NULL,
CreateUser nvarchar(100) NOT NULL,
LastModifiedUser nvarchar(100) NULL,
LastModificationDatetime datetime NULL,
DeactivateDatetime datetime NULL,
DeactivateUser nvarchar(100) NULL);

ALTER TABLE Parent
ADD FOREIGN KEY (ClientId) REFERENCES Client(Id);

--ALTER TABLE Parent
--ADD FOREIGN KEY (ParentalTypeId) REFERENCES ParentalType(Id);


DROP TABLE IF EXISTS StudentParent;
CREATE TABLE StudentParent
(Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
StudentId int NOT NULL,
ParentId int NOT NULL,
CreateDatetime datetime NOT NULL,
CreateUser nvarchar(100) NOT NULL,
LastModifiedUser nvarchar(100) NULL,
LastModificationDatetime datetime NULL,
DeactivateDatetime datetime NULL,
DeactivateUser nvarchar(100) NULL);


ALTER TABLE StudentParent
ADD FOREIGN KEY (ParentId) REFERENCES Parent(Id);

ALTER TABLE StudentParent
ADD FOREIGN KEY (StudentId) REFERENCES Student(Id);


DROP TABLE IF EXISTS Teacher;
CREATE TABLE Teacher
(Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
 ClientId int NOT NULL,
Name nvarchar(250) NOT NULL,
CountryId nvarchar(250) NOT NULL,
LastName1 nvarchar(250) NOT NULL,
LastName2 nvarchar(250) NULL,
Birthday datetime NOT NULL,
Gender char null,
Email nvarchar(250) NOT NULL,
Phone nvarchar(250) NOT NULL,
Address nvarchar(1000) NOT NULL,
RegistrationDate datetime NOT NULL,
CreateDatetime datetime NOT NULL,
CreateUser nvarchar(100) NOT NULL,
LastModifiedUser nvarchar(100) NULL,
LastModificationDatetime datetime NULL,
DeactivateDatetime datetime NULL,
DeactivateUser nvarchar(100) NULL);

ALTER TABLE Teacher
ADD FOREIGN KEY (ClientId) REFERENCES Client(Id);

DROP TABLE IF EXISTS Level;
CREATE TABLE Level
(Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
Name nvarchar(250) NOT NULL,
CreateDatetime datetime NOT NULL,
CreateUser nvarchar(100) NOT NULL,
LastModifiedUser nvarchar(100) NULL,
LastModificationDatetime datetime NULL,
DeactivateDatetime datetime NULL,
DeactivateUser nvarchar(100) NULL
);


DROP TABLE IF EXISTS Cycle;
CREATE TABLE Cycle
(Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
Name nvarchar(250) NOT NULL,
CreateDatetime datetime NOT NULL,
CreateUser nvarchar(100) NOT NULL,
LastModifiedUser nvarchar(100) NULL,
LastModificationDatetime datetime NULL,
DeactivateDatetime datetime NULL,
DeactivateUser nvarchar(100) NULL
);

DROP TABLE IF EXISTS GroupStatus;
CREATE TABLE GroupStatus
(Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
Name nvarchar(250) NOT NULL,
CreateDatetime datetime NOT NULL,
CreateUser nvarchar(100) NOT NULL,
LastModifiedUser nvarchar(100) NULL,
LastModificationDatetime datetime NULL,
DeactivateDatetime datetime NULL,
DeactivateUser nvarchar(100) NULL
);

DROP TABLE IF EXISTS [Group];
CREATE TABLE [Group]

(Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
 ClientId int NOT NULL,
CycleId int NOT NULL,
LevelId int NOT NULL,
GroupStatusId int NOT NULL,
GroupShortname nvarchar(250) null,
MinDate datetime NOT NULL,
MaxDate datetime NOT NULL,
CreateDatetime datetime NOT NULL,
CreateUser nvarchar(100) NOT NULL,
LastModifiedUser nvarchar(100) NULL,
LastModificationDatetime datetime NULL,
DeactivateDatetime datetime NULL,
DeactivateUser nvarchar(100) NULL);

ALTER TABLE [Group]
ADD FOREIGN KEY (LevelId) REFERENCES Level(Id);

ALTER TABLE [Group]
ADD FOREIGN KEY (CycleId) REFERENCES Cycle(Id);

ALTER TABLE [Group]
ADD FOREIGN KEY (GroupStatusId) REFERENCES GroupStatus(Id);

ALTER TABLE [Group]
ADD FOREIGN KEY (ClientId) REFERENCES Client(Id);

DROP TABLE IF EXISTS GroupStudent;
CREATE TABLE GroupStudent
(Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
GroupId int NOT NULL,
StudentId int NOT NULL,
CreateDatetime datetime NOT NULL,
CreateUser nvarchar(100) NOT NULL,
LastModifiedUser nvarchar(100) NULL,
LastModificationDatetime datetime NULL,
DeactivateDatetime datetime NULL,
DeactivateUser nvarchar(100) NULL);

ALTER TABLE GroupStudent
ADD FOREIGN KEY (StudentId) REFERENCES Student(Id);

ALTER TABLE GroupStudent
ADD FOREIGN KEY (GroupId) REFERENCES [Group](Id);



DROP TABLE IF EXISTS GroupTeacher;
CREATE TABLE GroupTeacher
(Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
GroupId int NOT NULL,
TeacherId int NOT NULL,
CreateDatetime datetime NOT NULL,
CreateUser nvarchar(100) NOT NULL,
LastModifiedUser nvarchar(100) NULL,
LastModificationDatetime datetime NULL,
DeactivateDatetime datetime NULL,
DeactivateUser nvarchar(100) NULL);

ALTER TABLE GroupTeacher
ADD FOREIGN KEY (TeacherId) REFERENCES Teacher(Id);

ALTER TABLE GroupTeacher
ADD FOREIGN KEY (GroupId) REFERENCES [Group](Id);



DROP TABLE IF EXISTS Document;
CREATE TABLE Document
(Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
 ClientId int NOT NULL,
StudentId int null,
TeacherId int null,
GroupId int  null,  
Title nvarchar(200) NULL,
IsProfilePic bit NULL,
fileLocation nvarchar(400) NULL,
CreateDatetime datetime NOT NULL,
CreateUser nvarchar(100) NOT NULL,
LastModifiedUser nvarchar(100) NULL,
LastModificationDatetime datetime NULL,
DeactivateDatetime datetime NULL,
DeactivateUser nvarchar(100) NULL
);

ALTER TABLE Document
ADD FOREIGN KEY (StudentId) REFERENCES Student(Id);

ALTER TABLE Document
ADD FOREIGN KEY (TeacherId) REFERENCES Teacher(Id);

ALTER TABLE Document
ADD FOREIGN KEY (GroupId) REFERENCES [Group](Id);

ALTER TABLE Document
ADD FOREIGN KEY (ClientId) REFERENCES Client(Id)


/*********************ACTIVITY***************************/

DROP TABLE IF EXISTS ActivityType;
CREATE TABLE ActivityType
(Id int NOT NULL IDENTITY(1,1) PRIMARY KEY ,
Name nvarchar(250) NOT NULL,

CreateDatetime datetime NOT NULL,
CreateUser nvarchar(100) NOT NULL,
LastModifiedUser nvarchar(100) NULL,
LastModificationDatetime datetime NULL,
DeactivateDatetime datetime NULL,
DeactivateUser nvarchar(100) NULL);

DROP TABLE IF EXISTS Activity;
CREATE TABLE Activity
(Id int NOT NULL IDENTITY(1,1) PRIMARY KEY ,
 ClientId int NOT NULL,
StudentId int null,
GroupId int  null,
ActivityTypeId int NOT NULL,
ActivityDatetime datetime NOT NULL,
Notes nvarchar(1000) NOT NULL,
CreateDatetime datetime NOT NULL,
CreateUser nvarchar(100) NOT NULL,
LastModifiedUser nvarchar(100) NULL,
LastModificationDatetime datetime NULL,
DeactivateDatetime datetime NULL,
DeactivateUser nvarchar(100) NULL);

ALTER TABLE Activity
ADD FOREIGN KEY (StudentId) REFERENCES Student(Id);

ALTER TABLE Activity
ADD FOREIGN KEY (GroupId) REFERENCES [Group](Id);

ALTER TABLE Activity
ADD FOREIGN KEY (ClientId) REFERENCES Client(Id)

ALTER TABLE Activity
ADD FOREIGN KEY (ActivityTypeId) REFERENCES ActivityType(Id)
/*******************************************************************************************/


DROP TABLE IF EXISTS PaymentType;
CREATE TABLE PaymentType
(Id int NOT NULL IDENTITY(1,1) PRIMARY KEY ,
Name nvarchar(250) NOT NULL,

CreateDatetime datetime NOT NULL,
CreateUser nvarchar(100) NOT NULL,
LastModifiedUser nvarchar(100) NULL,
LastModificationDatetime datetime NULL,
DeactivateDatetime datetime NULL,
DeactivateUser nvarchar(100) NULL);




DROP TABLE IF EXISTS PaymentStatus;
CREATE TABLE PaymentStatus
(Id int NOT NULL IDENTITY(1,1) PRIMARY KEY ,
Name nvarchar(250) NOT NULL,

CreateDatetime datetime NOT NULL,
CreateUser nvarchar(100) NOT NULL,
LastModifiedUser nvarchar(100) NULL,
LastModificationDatetime datetime NULL,
DeactivateDatetime datetime NULL,
DeactivateUser nvarchar(100) NULL);

DROP TABLE IF EXISTS PaymentRequest;
CREATE TABLE PaymentRequest
(Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
 ClientId int NOT NULL,
StudentId int not null, 
PaymentStatusId int not null, 
PaymentTypeId int not null, 
Amount decimal (10,4) NOT NULL,
Details nvarchar(1000) NOT NULL,

DueDate datetime NOT NULL,
CreateDatetime datetime NOT NULL,
CreateUser nvarchar(100) NOT NULL,
LastModifiedUser nvarchar(100) NULL,
LastModificationDatetime datetime NULL,
DeactivateDatetime datetime NULL,
DeactivateUser nvarchar(100) NULL
);

ALTER TABLE PaymentRequest
ADD FOREIGN KEY (StudentId) REFERENCES Student(Id);

ALTER TABLE PaymentRequest
ADD FOREIGN KEY (ClientId) REFERENCES Client(Id);

ALTER TABLE PaymentRequest
ADD FOREIGN KEY (PaymentStatusId) REFERENCES PaymentStatus(Id);

ALTER TABLE PaymentRequest
ADD FOREIGN KEY (PaymentTypeId) REFERENCES PaymentType(Id);



DROP TABLE IF EXISTS Payment;
CREATE TABLE Payment
(Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
PaymentRequestId int NOT NULL,
ParentId int not null,
Amount decimal (10,4) NOT NULL,
CreateDatetime datetime NOT NULL,
CreateUser nvarchar(100) NOT NULL,
LastModifiedUser nvarchar(100) NULL,
LastModificationDatetime datetime NULL,
DeactivateDatetime datetime NULL,
DeactivateUser nvarchar(100) NULL
);

ALTER TABLE Payment
ADD FOREIGN KEY (ParentId) REFERENCES Parent(Id);

ALTER TABLE Payment
ADD FOREIGN KEY (PaymentRequestId) REFERENCES PaymentRequest(Id);


--Addresses


DROP TABLE IF EXISTS Country;
CREATE TABLE Country
(Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
Name nvarchar(250) NOT NULL,
CreateDatetime datetime NOT NULL,
CreateUser nvarchar(100) NOT NULL,
LastModifiedUser nvarchar(100) NULL,
LastModificationDatetime datetime NULL,
DeactivateDatetime datetime NULL,
DeactivateUser nvarchar(100) NULL
);


DROP TABLE IF EXISTS StateOrProvince;
CREATE TABLE StateOrProvince
(Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
CountryId INT not null,
Name nvarchar(250) NOT NULL,
CreateDatetime datetime NOT NULL,
CreateUser nvarchar(100) NOT NULL,
LastModifiedUser nvarchar(100) NULL,
LastModificationDatetime datetime NULL,
DeactivateDatetime datetime NULL,
DeactivateUser nvarchar(100) NULL
);


ALTER TABLE StateOrProvince
ADD FOREIGN KEY (CountryId) REFERENCES Country(Id);


DROP TABLE IF EXISTS Canton;
CREATE TABLE Canton
(Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
StateOrProvinceId INT not null,
Name nvarchar(250) NOT NULL,
CreateDatetime datetime NOT NULL,
CreateUser nvarchar(100) NOT NULL,
LastModifiedUser nvarchar(100) NULL,
LastModificationDatetime datetime NULL,
DeactivateDatetime datetime NULL,
DeactivateUser nvarchar(100) NULL
);


ALTER TABLE Canton
ADD FOREIGN KEY (StateOrProvinceId) REFERENCES StateOrProvince(Id);

DROP TABLE IF EXISTS Distrito;
CREATE TABLE Distrito
(Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
CantonId INT not null,
Name nvarchar(250) NOT NULL,
CreateDatetime datetime NOT NULL,
CreateUser nvarchar(100) NOT NULL,
LastModifiedUser nvarchar(100) NULL,
LastModificationDatetime datetime NULL,
DeactivateDatetime datetime NULL,
DeactivateUser nvarchar(100) NULL
);

ALTER TABLE Distrito
ADD FOREIGN KEY (CantonId) REFERENCES Canton(Id);


DROP TABLE IF EXISTS PhysicalAddress;
CREATE TABLE PhysicalAddress
(Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
CountryId INT not null,
StateOrProvinceId INT not null,
CantonId INT  null,
DistritoId INT  null,
Line1 nvarchar(500) NOT NULL,
Line2 nvarchar(500)  NULL,
ZipCode nvarchar(50)  NULL,
CreateDatetime datetime NOT NULL,
CreateUser nvarchar(100) NOT NULL,
LastModifiedUser nvarchar(100) NULL,
LastModificationDatetime datetime NULL,
DeactivateDatetime datetime NULL,
DeactivateUser nvarchar(100) NULL
);


ALTER TABLE PhysicalAddress
ADD FOREIGN KEY (StateOrProvinceId) REFERENCES StateOrProvince(Id);

ALTER TABLE PhysicalAddress
ADD FOREIGN KEY (CantonId) REFERENCES Canton(Id);

ALTER TABLE PhysicalAddress
ADD FOREIGN KEY (DistritoId) REFERENCES Distrito(Id);

ALTER TABLE PhysicalAddress
ADD FOREIGN KEY (CountryId) REFERENCES Country(Id);


--activty tables are missing here