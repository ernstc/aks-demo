CREATE TABLE [dbo].[Region] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [IdCountry]  INT           NOT NULL,
    [Name]       NVARCHAR (50) NULL,
    [Population] INT           CONSTRAINT [DF_Region_Population] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Region] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Region_Country] FOREIGN KEY ([IdCountry]) REFERENCES [dbo].[Country] ([Id])
);

