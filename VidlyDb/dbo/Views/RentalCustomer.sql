CREATE VIEW [dbo].[RentalCustomer]
	AS SELECT [dbo].[Rentals].[RentalId], [dbo].[Rentals].[DateRented], [dbo].[Rentals].[Customer_Id], [dbo].[Rentals].[Price], 
	[dbo].[Customers].[CustomerId], [dbo].[Customers].[Name], [dbo].[Customers].[IsSubscribedToNewsLetter], 
	[dbo].[Customers].[MembershipTypeId], [dbo].[Customers].[BirthDate], [dbo].[Customers].[IsDelinquent], [dbo].[Customers].[RentLimit], 
	[dbo].[Customers].[DiscountRate] FROM [dbo].[Rentals] inner join [dbo].[Customers]
	ON [dbo].[Rentals].[Customer_Id] = [dbo].[Customers].[CustomerId]
