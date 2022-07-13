CREATE TABLE [dbo].[Tokens] (
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[userId] [int]  NOT NULL,
	[token] [varchar](1000) NOT NULL,
	PRIMARY KEY (Id)
)