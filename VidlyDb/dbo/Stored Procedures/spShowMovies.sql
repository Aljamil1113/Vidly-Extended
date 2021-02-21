CREATE PROCEDURE [dbo].[spShowMovies]
AS
	select [MovieId], [Name], [ReleaseDate], [DateAdded], [NumberInStock], [GenreId], 
	[NumberAvailable], [Amount], [GenreName] from [dbo].[MovieGenre]
RETURN 0
