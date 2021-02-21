CREATE PROCEDURE [dbo].[spShowMoviesWithName]
	@name nvarchar(50)
AS
	SELECT [MovieId], [Name], [ReleaseDate], [DateAdded], [NumberInStock], [GenreId], 
	[NumberAvailable], [Amount], [GenreName] from [dbo].[MovieGenre] 
	WHERE [dbo].[MovieGenre].[Name] LIKE '%' + @name + '%'

RETURN 0
