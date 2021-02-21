CREATE TABLE [dbo].[Customers] (
    [CustomerId]               INT            IDENTITY (1, 1) NOT NULL,
    [Name]                     NVARCHAR (255) NOT NULL,
    [IsSubscribedToNewsLetter] BIT            DEFAULT ((0)) NOT NULL,
    [MembershipTypeId]         TINYINT        NOT NULL,
    [BirthDate]                DATETIME       NULL,
    [IsDelinquent]             BIT            DEFAULT ((0)) NOT NULL,
    [RentLimit]                TINYINT        DEFAULT ((0)) NOT NULL,
    [DiscountRate]             INT            NOT NULL,
    CONSTRAINT [PK_dbo.Customers] PRIMARY KEY CLUSTERED ([CustomerId] ASC),
    CONSTRAINT [FK_dbo.Customers_dbo.MembershipTypes_MembershipTypeId] FOREIGN KEY ([MembershipTypeId]) REFERENCES [dbo].[MembershipTypes] ([MembershipTypeId]) ON DELETE CASCADE
);






GO
CREATE NONCLUSTERED INDEX [IX_MembershipTypeId]
    ON [dbo].[Customers]([MembershipTypeId] ASC);


GO
