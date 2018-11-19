CREATE TABLE [dbo].[Requestlists] (
    [ID]            INT            IDENTITY (1, 1) NOT NULL,
    [Request]		NVARCHAR (MAX) NOT NULL,
    [IPAddress]		NVARCHAR (MAX) NOT NULL,
	[ClientBrowser]	NVARCHAR (MAX) NOT NULL,
    [AccessTime]    DATETIME       NULL,

    CONSTRAINT [PK_dbo.Requestlists] PRIMARY KEY CLUSTERED ([ID] ASC)
	
);
