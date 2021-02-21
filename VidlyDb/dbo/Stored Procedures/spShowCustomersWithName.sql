CREATE PROCEDURE [dbo].[spShowCustomersWithName]
	@name nvarchar(50)
AS
	SELECT [CustomerId], [Name], [IsSubscribedToNewsLetter], [MembershipTypeId], [BirthDate], [IsDelinquent], [RentLimit], 
	[DiscountRate], [SignUpFree], [DurationInMonths], [MembershipTypeName] from [dbo].[CustomerMembershipType] 
	where [dbo].[CustomerMembershipType].[Name] LIKE '%' + @name + '%'
RETURN 0
