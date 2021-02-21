CREATE VIEW [dbo].[CustomerMembershipType]
	AS SELECT [dbo].[Customers].[CustomerId], [dbo].[Customers].[Name], [dbo].[Customers].[IsSubscribedToNewsLetter], 
	[dbo].[Customers].[MembershipTypeId], [dbo].[Customers].[BirthDate], [dbo].[Customers].[IsDelinquent], [dbo].[Customers].[RentLimit], 
	[dbo].[Customers].[DiscountRate], [dbo].[MembershipTypes].[SignUpFree], 
	[dbo].[MembershipTypes].[DurationInMonths], [dbo].[MembershipTypes].[Name] as MembershipTypeName 
	FROM [dbo].[Customers] inner join [dbo].[MembershipTypes] 
	on [dbo].[Customers].[MembershipTypeId] = [dbo].[MembershipTypes].[MembershipTypeId]
