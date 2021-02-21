CREATE TABLE [dbo].[Movies] (
    [MovieId]         INT             IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (MAX)  NOT NULL,
    [ReleaseDate]     DATETIME        NOT NULL,
    [DateAdded]       DATETIME        NOT NULL,
    [NumberInStock]   TINYINT         NOT NULL,
    [GenreId]         TINYINT         NOT NULL,
    [NumberAvailable] TINYINT         DEFAULT ((0)) NOT NULL,
    [Amount]          DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_dbo.Movies] PRIMARY KEY CLUSTERED ([MovieId] ASC),
    CONSTRAINT [FK_dbo.Movies_dbo.Genres_GenreId] FOREIGN KEY ([GenreId]) REFERENCES [dbo].[Genres] ([GenreId]) ON DELETE CASCADE
);




GO
CREATE NONCLUSTERED INDEX [IX_GenreId]
    ON [dbo].[Movies]([GenreId] ASC);

