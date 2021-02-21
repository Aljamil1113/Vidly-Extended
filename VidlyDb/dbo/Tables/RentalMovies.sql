CREATE TABLE [dbo].[RentalMovies] (
    [RentalId]     INT      NOT NULL,
    [MovieId]      INT      NOT NULL,
    [DateReturned] DATETIME NULL,
    CONSTRAINT [PK_dbo.RentalMovies] PRIMARY KEY CLUSTERED ([RentalId] ASC, [MovieId] ASC),
    CONSTRAINT [FK_dbo.RentalMovies_dbo.Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [dbo].[Movies] ([MovieId]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.RentalMovies_dbo.Rentals_RentalId] FOREIGN KEY ([RentalId]) REFERENCES [dbo].[Rentals] ([RentalId]) ON DELETE CASCADE
);




GO
CREATE NONCLUSTERED INDEX [IX_RentalId]
    ON [dbo].[RentalMovies]([RentalId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_MovieId]
    ON [dbo].[RentalMovies]([MovieId] ASC);

