-- --------------------------------------------------------------------------------
-- Options
-- --------------------------------------------------------------------------------
USE dbSQL1;     -- Get out of the master database
SET NOCOUNT ON; -- Report only errors

-- --------------------------------------------------------------------------------
-- Drop Tables
-- --------------------------------------------------------------------------------
IF OBJECT_ID( 'TGolferEventYearSponsors' )		IS NOT NULL DROP TABLE	TGolferEventYearSponsors
IF OBJECT_ID( 'TGolferEventYears' )				IS NOT NULL DROP TABLE	TGolferEventYears
IF OBJECT_ID( 'TEventYears' )					IS NOT NULL DROP TABLE	TEventYears
IF OBJECT_ID( 'TGolfers' )						IS NOT NULL DROP TABLE	TGolfers
IF OBJECT_ID( 'TGenders' )						IS NOT NULL DROP TABLE	TGenders
IF OBJECT_ID( 'TShirtSizes' )					IS NOT NULL DROP TABLE	TShirtSizes
IF OBJECT_ID( 'TPaymentTypes' )					IS NOT NULL DROP TABLE	TPaymentTypes
IF OBJECT_ID( 'TSponsors' )						IS NOT NULL DROP TABLE	TSponsors
IF OBJECT_ID( 'TSponsorTypes' )					IS NOT NULL DROP TABLE	TSponsorTypes



-- --------------------------------------------------------------------------------
-- Drop Procedures
-- --------------------------------------------------------------------------------
IF OBJECT_ID( 'uspAddGolferEventYear' )			IS NOT NULL DROP PROCEDURE	uspAddGolferEventYear
IF OBJECT_ID( 'uspAddGolferAndEvent' )			IS NOT NULL DROP PROCEDURE	uspAddGolferAndEvent
IF OBJECT_ID( 'uspAddEvent' )					IS NOT NULL DROP PROCEDURE	uspAddEvent
IF OBJECT_ID( 'uspAddGolfer' )					IS NOT NULL DROP PROCEDURE	uspAddGolfer

-- --------------------------------------------------------------------------------
-- Drop Views
-- --------------------------------------------------------------------------------
IF OBJECT_ID( 'vNotAvailableGolfers' )				IS NOT NULL DROP VIEW	vNotAvailableGolfers
IF OBJECT_ID( 'vAvailableGolfers' )					IS NOT NULL DROP VIEW	vAvailableGolfers

-- --------------------------------------------------------------------------------
-- Step #1: Create Tables
-- --------------------------------------------------------------------------------
CREATE TABLE TEventYears
(
	 intEventYearID		INTEGER			NOT NULL
	,intEventYear		INTEGER			NOT NULL
	,CONSTRAINT TEventYears_PK PRIMARY KEY ( intEventYearID	)
)

CREATE TABLE TGenders
(
	 intGenderID		INTEGER			NOT NULL
	,strGenderDesc			VARCHAR(50)		NOT NULL
	,CONSTRAINT TGenders_PK PRIMARY KEY ( intGenderID )
)

CREATE TABLE TShirtSizes
(
	 intShirtSizeID			INTEGER			NOT NULL
	,strShirtSizeDesc		VARCHAR(50)		NOT NULL
	,CONSTRAINT TShirtSizes_PK PRIMARY KEY ( intShirtSizeID )
)

CREATE TABLE TGolfers
(
	 intGolferID		INTEGER			NOT NULL
	,strFirstName		VARCHAR(50)		NOT NULL
	,strLastName		VARCHAR(50)		NOT NULL
	,strStreetAddress	VARCHAR(50)		NOT NULL
	,strCity			VARCHAR(50)		NOT NULL
	,strState			VARCHAR(50)		NOT NULL
	,strZip				VARCHAR(50)		NOT NULL
	,strPhoneNumber		VARCHAR(50)		NOT NULL
	,strEmail			VARCHAR(50)		NOT NULL
	,intShirtSizeID		INTEGER			NOT NULL
	,intGenderID		INTEGER			NOT NULL
	,CONSTRAINT TGolfers_PK PRIMARY KEY ( intGolferID )
)

CREATE TABLE TSponsors
(
	 intSponsorID		INTEGER			NOT NULL
	,strFirstName		VARCHAR(50)		NOT NULL
	,strLastName		VARCHAR(50)		NOT NULL
	,strStreetAddress	VARCHAR(50)		NOT NULL
	,strCity			VARCHAR(50)		NOT NULL
	,strState			VARCHAR(50)		NOT NULL
	,strZip				VARCHAR(50)		NOT NULL
	,strPhoneNumber		VARCHAR(50)		NOT NULL
	,strEmail			VARCHAR(50)		NOT NULL
	,CONSTRAINT TSponsors_PK PRIMARY KEY ( intSponsorID )
)

CREATE TABLE TPaymentTypes
(
	 intPaymentTypeID		INTEGER			NOT NULL
	,strPaymentTypeDesc		VARCHAR(50)		NOT NULL
	,CONSTRAINT TPaymentTypes_PK PRIMARY KEY ( intPaymentTypeID )
)

CREATE TABLE TGolferEventYears
(
	 intGolferEventYearID	INTEGER IDENTITY(1,1)		NOT NULL
	,intGolferID			INTEGER					NOT NULL
	,intEventYearID			INTEGER					NOT NULL
	,CONSTRAINT TGolferEventYears_UQ UNIQUE ( intGolferID, intEventYearID )
	,CONSTRAINT TGolferEventYears_PK PRIMARY KEY ( intGolferEventYearID )
)


CREATE TABLE TGolferEventYearSponsors
(
	 intGolferEventYearSponsorID	INTEGER				NOT NULL
	,intGolferID					INTEGER				NOT NULL
	,intEventYearID					INTEGER				NOT NULL
	,intSponsorID					INTEGER				NOT NULL
	,monPledgeAmount				MONEY				NOT NULL
	,intSponsorTypeID				INTEGER				NOT NULL
	,intPaymentTypeID				INTEGER				NOT NULL
	,blnPaid						BIT					NOT NULL
	,CONSTRAINT TGolferEventYearSponsors_UQ UNIQUE ( intGolferID, intEventYearID, intSponsorID )
	,CONSTRAINT TGolferEventYearSponsors_PK PRIMARY KEY ( intGolferEventYearSponsorID )
)

CREATE TABLE TSponsorTypes
(
	 intSponsorTypeID		INTEGER			NOT NULL
	,strSponsorTypeDesc		VARCHAR(50)		NOT NULL
	,CONSTRAINT TSponsorTypes_PK PRIMARY KEY ( intSponsorTypeID )
)


-- --------------------------------------------------------------------------------
-- Step #2: Identify and Create Foreign Keys
-- --------------------------------------------------------------------------------
--
-- #	Child							Parent						Column(s)
-- -	-----							------						---------
-- 1	TGolfers						TGenders					intGenderID
-- 2	TGolfers						TShirtSizes					intShirtSizeID
-- 3    TGolferEventYears				TGolfers					intGolferID
-- 4	TGolferEventYearSponsors		TGolferEventYears			intGolferID, intEventYearID
-- 5	TGolferEventYears				TEventYears					intEventYearID
-- 6    TGolferEventYearSponsors		TSponsors					intSponsorID
-- 7	TGolferEventYearSponsors		TSponsorTypes				intSponsorTypeID
-- 8	TGolferEventYearSponsors		TPaymentTypes				intPaymentTypeID

-- 1
ALTER TABLE TGolfers ADD CONSTRAINT TGolfers_TGenders_FK
FOREIGN KEY ( intGenderID ) REFERENCES TGenders ( intGenderID )

-- 2
ALTER TABLE TGolfers ADD CONSTRAINT TGolfers_TShirtSizes_FK
FOREIGN KEY ( intShirtSizeID ) REFERENCES TShirtSizes ( intShirtSizeID )

-- 3
ALTER TABLE TGolferEventYears ADD CONSTRAINT TGolferEventYears_TGolfers_FK
FOREIGN KEY ( intGolferID ) REFERENCES TGolfers ( intGolferID )

-- 4
ALTER TABLE TGolferEventYearSponsors ADD CONSTRAINT TGolferEventYearSponsors_TGolferEventYears_FK
FOREIGN KEY ( intGolferID, intEventYearID ) REFERENCES TGolferEventYears ( intGolferID, intEventYearID )

-- 5
ALTER TABLE TGolferEventYears ADD CONSTRAINT TGolferEventYears_TEventYears_FK
FOREIGN KEY ( intEventYearID ) REFERENCES TEventYears ( intEventYearID )

-- 6
ALTER TABLE TGolferEventYearSponsors ADD CONSTRAINT TGolferEventYearSponsors_TSponsors_FK
FOREIGN KEY ( intSponsorID ) REFERENCES TSponsors ( intSponsorID )

-- 7
ALTER TABLE TGolferEventYearSponsors ADD CONSTRAINT TGolferEventYearSponsors_TSponsorTypes_FK
FOREIGN KEY ( intSponsorTypeID ) REFERENCES TSponsorTypes ( intSponsorTypeID )

-- 8
ALTER TABLE TGolferEventYearSponsors ADD CONSTRAINT TGolferEventYearSponsors_TPaymentTypes_FK
FOREIGN KEY ( intPaymentTypeID ) REFERENCES TPaymentTypes ( intPaymentTypeID )

-- --------------------------------------------------------------------------------
-- Step #3: Add data to Gender
-- --------------------------------------------------------------------------------

INSERT INTO TGenders( intGenderID, strGenderDesc)
VALUES		 (1, 'Female')
			,(2, 'Male')

---- --------------------------------------------------------------------------------
---- Step #4: Add men's and women's shirt sizes
---- --------------------------------------------------------------------------------

INSERT INTO TShirtSizes( intShirtSizeID, strShirtSizeDesc)
VALUES		(1, 'Mens Small')
		,(2, 'Mens Medium')
		,(3, 'Mens Large')
		,(4, 'Mens XLarge')
		,(5, 'Womens Small')
		,(6, 'Womens Medium')
		,(7, 'Womens Large')
		,(8, 'Womens XLarge')

---- --------------------------------------------------------------------------------
---- Step #5: Add years
---- --------------------------------------------------------------------------------
INSERT INTO TEventYears ( intEventYearID, intEventYear )
	VALUES	 ( 1, 2015)
		,( 2, 2016)
		,(3, 2017)

---- --------------------------------------------------------------------------------
---- Step #6: Add sponsor types
---- --------------------------------------------------------------------------------
INSERT INTO TSponsorTypes ( intSponsorTypeID, strSponsorTypeDesc)
	VALUES (1, 'Parent')
		,(2, 'Alumni')
		,(3, 'Friend')
		,(4, 'Business')

---- --------------------------------------------------------------------------------
---- Step #7: Add payment types
---- --------------------------------------------------------------------------------
INSERT INTO TPaymentTypes ( intPaymentTypeID, strPaymentTypeDesc)
	VALUES (1, 'Check')
		,(2, 'Cash')
		,(3, 'Credit Card')
---- --------------------------------------------------------------------------------
---- Step #8: Add sponsors
---- --------------------------------------------------------------------------------

INSERT INTO TSponsors ( intSponsorID, strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, strPhoneNumber, strEmail )
VALUES	 ( 1, 'Jim', 'Smith', '1979 Wayne Trace Rd.', 'Willow', 'OH', '42368', '5135551212', 'jsmith@yahoo.com' )
		,( 2, 'Sally', 'Jones', '987 Mills Rd.', 'Cincinnati', 'OH', '45202', '5135551234', 'sjones@yahoo.com' )

---- --------------------------------------------------------------------------------
---- Step #9: Add golfers
---- --------------------------------------------------------------------------------

INSERT INTO TGolfers ( intGolferID, strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, strPhoneNumber, strEmail, intShirtSizeID, intGenderID )
VALUES	 ( 1, 'Bill', 'Goldstein', '156 Main St.', 'Mason', 'OH', '45040', '5135559999', 'bGoldstein@yahoo.com', 1, 2 )
		,( 2, 'Tara', 'Everett', '3976 Deer Run', 'West Chester', 'OH', '45069', '5135550101', 'teverett@yahoo.com', 6, 1 )

---- --------------------------------------------------------------------------------
---- Step # 10: Add Golfers and sponsors to link them
---- --------------------------------------------------------------------------------

--INSERT INTO TGolferEventYears ( intGolferEventYearID, intGolferID, intEventYearID)
--	VALUES (1, 1, 1)
--		,(2, 2, 1)
--		,(3, 1, 2)
--		,(4, 2, 2)

---- --------------------------------------------------------------------------------
---- Step # 10: Add Golfers and sponsors to link them
---- --------------------------------------------------------------------------------
--INSERT INTO TGolferEventYearSponsors ( intGolferEventYearSponsorID, intGolferID, intEventYearID, intSponsorID, monPledgeAmount, intSponsorTypeID, intPaymentTypeID, blnPaid )
--VALUES	 ( 1, 1, 1, 1, 25.00, 1, 1, 1 )
--		--,( 2, 1, 1, 2, 25.00, 1, 1, 1 )
		


	
-- --------------------------------------------------------------------------------
-- Step #11: Create a stored procedure to add an Event - uspAddEvent
-- --------------------------------------------------------------------------------
GO
CREATE PROCEDURE uspAddEvent
	@intEventYearID	AS	INTEGER OUTPUT
	,@intEventYear	AS	INTEGER

AS
SET XACT_ABORT ON

BEGIN TRANSACTION
	SELECT @intEventYearID = MAX(intEventYearID) + 1
	FROM TEventYears (TABLOCKX)
	
	SELECT @intEventYearID = COALESCE(@intEventYearID, 1)

	INSERT INTO TEventYears(intEventYearID, intEventYear)
	VALUES(@intEventYearID, @intEventYear)

COMMIT TRANSACTION
GO
-- TEST
SELECT * FROM TEventYears
DECLARE @intEventYearID AS INTEGER = 0
EXECUTE uspAddEvent @intEventYearID OUTPUT, 2018
PRINT 'Event ID =' + CONVERT(VARCHAR, @intEventYearID)
SELECT * FROM TEventYears


-- --------------------------------------------------------------------------------
-- Step #11: Create a stored procedure to add a Golfer - uspAddGolfer
-- --------------------------------------------------------------------------------
GO
CREATE PROCEDURE uspAddGolfer
	@intGolferID		AS	INTEGER OUTPUT
	,@strFirstName		AS	VARCHAR(50)
	,@strLastName		AS	VARCHAR(50)
	,@strStreetAddress	AS	VARCHAR(50)
	,@strCity			AS	VARCHAR(50)
	,@strState			AS	VARCHAR(50)
	,@strZip			AS	VARCHAR(50)
	,@strPhoneNumber	AS 	VARCHAR(50)
	,@strEmail			AS 	VARCHAR(50)
	,@intShirtSizeID	AS	INTEGER
	,@intGenderID		AS	INTEGER


AS
SET XACT_ABORT ON

BEGIN TRANSACTION
	SELECT @intGolferID = MAX(intGolferID) + 1
	FROM TGolfers (TABLOCKX)
		JOIN TShirtSizes
			ON TShirtSizes.intShirtSizeID = TGolfers.intShirtSizeID
		JOIN TGenders
			ON TGenders.intGenderID = TGolfers.intGenderID
	
	SELECT @intGolferID = COALESCE(@intGolferID, 1)

	INSERT INTO TGolfers(intGolferID, strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, strPhoneNumber, strEmail, intShirtSizeID, intGenderID)


	VALUES(@intGolferID, @strFirstName, @strLastName, @strStreetAddress, @strCity, @strState, @strZip, @strPhoneNumber, @strEmail, @intShirtSizeID, @intGenderID)

COMMIT TRANSACTION
GO
-- TEST
SELECT * FROM TGolfers
DECLARE @intGolferID AS INTEGER = 0
EXECUTE uspAddGolfer @intGolferID OUTPUT, 'Phoebe', 'Buffay', '123 Central Perk','New York','New York','10002','123-333-5555','PBuffay@Philange.com', 2, 1
PRINT 'Golfer ID =' + CONVERT(VARCHAR, @intGolferID)
SELECT * FROM TGolfers

-- --------------------------------------------------------------------------------
-- Step #1.4: uspAddGolferEventYear
-- --------------------------------------------------------------------------------
GO

CREATE PROCEDURE uspAddGolferEventYear
	 @intGolferEventYearID 		AS INTEGER OUTPUT
	,@intEventYearID 			AS INTEGER
	,@intGolferID	 			AS INTEGER
AS
SET NOCOUNT ON		-- Report only errors
SET XACT_ABORT ON	-- Terminate and rollback entire transaction on error

BEGIN TRANSACTION

	INSERT INTO TGolferEventYears WITH (TABLOCKX) ( intEventYearID, intGolferID)
	VALUES( @intEventYearID, @intGolferID )

	SELECT @intGolferEventYearID = MAX(intGolferEventYearID)
	FROM TGolferEventYears

COMMIT TRANSACTION
GO

-- Test it


DECLARE @intGolferEventYearID AS INTEGER = 0;
EXECUTE uspAddGolferEventYear @intGolferEventYearID OUTPUT, 2, 3
PRINT 'Event Golfer ID = ' + CONVERT( VARCHAR, @intGolferEventYearID )

SELECT * FROM TGolfers
SELECT * FROM TEventYears
SELECT * FROM TGolferEventYears


-- --------------------------------------------------------------------------------
-- Step #1.4: Create View Available Golfers
-- --------------------------------------------------------------------------------

GO
	
CREATE VIEW vAvailableGolfers
AS
SELECT
	intGolferID
	,strLastName	
FROM
	TGolfers
WHERE
	intGolferID NOT IN (SELECT intGolferID FROM TGolferEventYears)

GO

SELECT * FROM vAvailableGolfers

-- --------------------------------------------------------------------------------
-- Step #1.4: Create View NOT Available Golfers
-- --------------------------------------------------------------------------------
GO
	
CREATE VIEW vNotAvailableGolfers
AS
SELECT
	 TG.intGolferID
	,TG.strLastName
	,TE.intEventYearID	
FROM
	TGolfers AS TG
	,TEventYears AS TE
	,TGolferEventYears AS TGE
WHERE
	TG.intGolferID = TGE.intGolferID
AND TE.intEventYearID = TGE.intEventYearID

GO

SELECT * FROM vNotAvailableGolfers
