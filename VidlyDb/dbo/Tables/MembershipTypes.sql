CREATE TABLE [dbo].[MembershipTypes] (
    [MembershipTypeId] TINYINT        NOT NULL,
    [SignUpFree]       SMALLINT       NOT NULL,
    [DurationInMonths] TINYINT        NOT NULL,
    [DiscountRate]     TINYINT        NOT NULL,
    [Name]             NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.MembershipTypes] PRIMARY KEY CLUSTERED ([MembershipTypeId] ASC)
);



