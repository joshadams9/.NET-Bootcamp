USE [AirRes]
GO

SELECT *
FROM [Aircraft]
WHERE Role = 'CUSTOMER';

           [UserID]
           ,[FirstName]
          ,[LastName]
           ,[UserName]
           ,[Password]
           ,[Role]

		   FROM [dbo].[User];

	UPDATE [User] SET LastName = 'Smith' 
	WHERE UserID = 2;


INSERT INTO [dbo].[User]
           ([UserID]
           ,[FirstName]
           ,[LastName]
           ,[UserName]
           ,[Password]
           ,[Role])
     VALUES
           (4
           ,'Ben'
           ,'Hall'
           ,'benhall'
           ,'password'
           ,'ADMINISTRATOR')
GO

DELETE FROM [User] WHERE LastName = 'Hall';

select * from [User]
SELECT AircraftID, Type, MaxDistance From [dbo].Aircraft;

select * from [User]
where Role ='Customer';

Select AircraftID, Type, MaxDistance From Aircraft
--Where MaxDistance > 1000;
