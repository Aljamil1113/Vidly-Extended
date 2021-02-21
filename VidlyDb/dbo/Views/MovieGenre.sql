CREATE VIEW [dbo].[MovieGenre]
	AS select [dbo].[Movies].[MovieId], [dbo].[Movies].[Name], [dbo].[Movies].[ReleaseDate], 
	[dbo].[Movies].[DateAdded], [dbo].[Movies].[NumberInStock], 
	[dbo].[Movies].[GenreId], [dbo].[Movies].[NumberAvailable], [dbo].[Movies].[Amount], 
	[dbo].[Genres].[Name] as GenreName from Movies inner join Genres
	on Movies.GenreId = Genres.GenreId Where [dbo].[Movies].[NumberAvailable] > 0
