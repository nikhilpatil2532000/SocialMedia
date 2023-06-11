GO
	--created user table
	CREATE TABLE [dbo].[Users](
		UserId INT IDENTITY(1,1) PRIMARY KEY,
		FirstName NVARCHAR(MAX) NOT NULL,
		LastName NVARCHAR(MAX) NOT NULL,
		Email NVARCHAR(MAX) NOT NULL,
		Password NVARCHAR(MAX) NOT NULL,
		PhoneNumber NVARCHAR(MAX) NOT NULL,
		CreatedDate DATETIME NOT NULL,
		UpdatedDate DATETIME NOT NULL,
		Gender INT NOT NULL,
	);
GO
	--created Relationship table
	CREATE TABLE [dbo].[Relationships] (
		RelationshipNo INT IDENTITY(1,1) PRIMARY KEY,
		UserID INT FOREIGN KEY REFERENCES dbo.Users(UserId) NOT NULL,
		FriendID INT FOREIGN KEY REFERENCES dbo.Users(UserId) NOT NULL,
		ClosedFriend BIT NOT NULL DEFAULT 0,
		RelationIsActive BIT NOT NULL DEFAULT 1,
		CreatedDate DATETIME NOT NULL ,
		UpdatedDate DATETIME NOT NULL
	);
GO
	--drop tables
	DROP TABLE [dbo].[Relationships]
	DROP TABLE [dbo].[Users]
GO