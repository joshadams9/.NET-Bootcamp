


--creating new databaase

--CREATE Database AirRes;


---create tables

create table [User] (
	

	UserID int NOT NULL IDENTITY(1,1) Primary Key,
	FirstName VARCHAR (100) NOT NULL,
	LastName VARCHAR (100) NOT NULL,
	UserName VARCHAR (100) NOT NULL,
	Password VARCHAR (100) NOT NULL,
	

	);

	ALTER TABLE [User]
	ADD [Role]varchar (100) NOT NULL;

	create table [Aircraft] (
	

	AircraftID int NOT NULL,
	[Type] VARCHAR (100), 
	MaxDistance int, 
	
	);

	ALTER TABLE [Aircraft]
	WHERE AircraftID 

	Create TABLE [Flight](

	flightID int NOT NULL,
	AircraftID_FK int NOT NULL,
	FlightCode VARCHAR (10),
	Origin VARCHAR (100),
	Destination VARCHAR (100),
	FlightDate DATETIME,
	PRIMARY KEY (flightID),
	FOREIGN KEY (AircraftID_FK) REFERENCES Aircraft(AircraftID)

	);
	
	Create table [Passenger](
	PassengerID int identity(1,1)Not null Primary key,
	flightID_FK int not null,
	ConfirmationCode Varchar (10) not null,
	FirstName Varchar (100) Not null,
	LastName varchar (100) not null,
	Email varchar (100) not null,
	Phone varchar (100) not null,
	foreign key (flightId_FK) references Flight(flightID),
	);
	

	
	--SELECT * FROM [User];
	--Select * from Passenger
	
	--Where flightID_FK = '1';
	
	--Example of inner join
	Select * from [dbo].Flight f
		INNER JOIN [dbo].Passenger p ON p.flightID_FK = f.flightID;
		--more of inner join
		Select f.Origin, f.Destination, f.flightDate, p.FirstName, p.LastName, p.Email From [dbo].Flight f
		INNER JOIN [dbo].Passenger p ON p.flightID_FK = f.flightID;
		

		--left or riht join
		Select * From Aircraft a
		right join [dbo].flight f ON f.aircraftID_FK = a.AircraftID;


		Select * from flight f
		inner join passenger p ON p.flightID_FK = f.flightID
		inner join aircraft a on f.aircraftID_FK = a.aircraftID;

		select u.FirstName, u.LastName
		From [User] u 
		left join Passenger p ON p.FirstName = u.FirstName AND p.LastName = u.LastName;


		select * from [User]
		select * from Passenger;
		--creating a view
		CREATE VIEW VW_Passenger_User AS 
			select u.FirstName, u.LastName, u.Password, u.UserName, u.Role, p.Email
		From [User] u 
		inner join Passenger p ON p.FirstName = u.FirstName AND p.LastName = u.LastName;

		Select* from VW_Passenger_User;


