CREATE TABLE [dbo].[Requests]
(
	[Id]  INT IDENTITY (1, 1) NOT NULL, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [PhoneNumber] NVARCHAR(50) NOT NULL, 
    [ApartmentName] NVARCHAR(50) NOT NULL, 
    [UnitNumber] INT NOT NULL, 
    [Explanation] NVARCHAR(MAX)  NOT NULL, 
    [Permission] BIT  NOT NULL
	CONSTRAINT [PK_dbo.Requests] PRIMARY KEY CLUSTERED ([ID] ASC)
);

INSERT INTO dbo.Requests(FirstName, LastName, PhoneNumber, ApartmentName, UnitNumber, Explanation, Permission) VALUES
('Jia', 'Zhang', '666-678-6987', 'Whitesell', '9', 'No Light', 0),
('Yue', 'Zhang', '654-321-9876', 'Whitesell', '10', 'Cold', 1),
('Nan', 'Li', '666-999-3333', 'Whitesell', '10', 'bad window', 0),
('Jiahui', 'Zhang', '888-888-8888', 'Stephanies', '46', 'problem with bed', 1),
('Zun', 'Yan', '971-777-6115', 'Stephanies', '46', 'power failure', 1)
GO
