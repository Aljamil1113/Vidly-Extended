CREATE TABLE [dbo].[Rentals] (
    [RentalId]    INT             IDENTITY (1, 1) NOT NULL,
    [DateRented]  DATETIME        NOT NULL,
    [Customer_Id] INT             NOT NULL,
    [Price]       DECIMAL (18, 2) DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_dbo.Rentals] PRIMARY KEY CLUSTERED ([RentalId] ASC),
    CONSTRAINT [FK_dbo.Rentals_dbo.Customers_Customer_Id] FOREIGN KEY ([Customer_Id]) REFERENCES [dbo].[Customers] ([CustomerId]) ON DELETE CASCADE
);




GO
CREATE NONCLUSTERED INDEX [IX_Customer_Id]
    ON [dbo].[Rentals]([Customer_Id] ASC);


GO


