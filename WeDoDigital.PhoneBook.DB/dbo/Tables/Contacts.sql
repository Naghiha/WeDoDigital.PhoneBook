CREATE TABLE [dbo].[Contacts] (
    [ID]          INT           IDENTITY (1, 1) NOT NULL,
    [FName]       NVARCHAR (50) NOT NULL,
    [LName]       NVARCHAR (50) NOT NULL,
    [PhoneNumber] CHAR (11)     NOT NULL,
    CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED ([ID] ASC)
);

