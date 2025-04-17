use master
IF EXISTS (SELECT*FROM sys.databases WHERE name = 'EventCaseDB')
DROP DATABASE EventCaseDB
CREATE DATABASE EventCaseDB

USE EventCaseDB




CREATE TABLE Venues (
    VenueID INT PRIMARY KEY IDENTITY,
    VenueName NVARCHAR(100),
    Location NVARCHAR(200),
    Capacity INT,
    Description NVARCHAR(500),
    ImageURL NVARCHAR(500)  
);

CREATE TABLE Event (
    EventID INT PRIMARY KEY IDENTITY,
    EventName NVARCHAR(100),
    EventDate DATETIME,
    VenueID INT,
    EventType NVARCHAR(50),
    Description NVARCHAR(500),
    TicketPrice DECIMAL(10, 2),
    FOREIGN KEY (VenueID) REFERENCES Venues(VenueID)
);

CREATE TABLE Bookings (
    BookingID INT PRIMARY KEY IDENTITY,
    CustomerID INT,
    EventID INT,
    BookingDate DATETIME,
    SeatsBooked INT,
    BookingStatus NVARCHAR(50),
    FOREIGN KEY (EventID) REFERENCES Event(EventID)
);






	SELECT*
	FROM Venues

	SELECT*
	FROM Event
		
	SELECT*
	FROM Bookings

