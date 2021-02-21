CREATE PROCEDURE [dbo].[spShowCustomers]
AS
	SELECT [CustomerId], [Name], [IsSubscribedToNewsLetter], [MembershipTypeId], [BirthDate], [IsDelinquent], [RentLimit], 
	[DiscountRate], [SignUpFree], [DurationInMonths], [MembershipTypeName] from [dbo].[CustomerMembershipType] 
RETURN 0
