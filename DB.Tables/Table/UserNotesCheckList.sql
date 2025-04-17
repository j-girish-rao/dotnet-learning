CREATE TABLE [dbo].[UserNotesCheckList]
(
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[ParentUserNotesId] UNIQUEIDENTIFIER NOT NULL,
	[Name] NVARCHAR(256) NULL,
	[IsCompleted] BIT NOT NULL,
	[CreatedDate] DATETIME NOT NULL,
	[ModifiedDate] DATETIME NOT NULL,
	CONSTRAINT PK_UserNotesCheckList PRIMARY KEY (Id),
	CONSTRAINT FK_UserNotesCheckList_UserNotes FOREIGN KEY (ParentUserNotesId) REFERENCES UserNotes(Id)
)
