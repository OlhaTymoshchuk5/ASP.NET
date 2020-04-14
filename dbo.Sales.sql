USE [eStore]
GO

/****** Object: Table [dbo].[Sales] Script Date: 08/08/2019 22:08:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Sales] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [ProdId]       INT           NOT NULL,
    [CusId]        INT           NOT NULL,
    [QtySold]      INT           NOT NULL,
    [SellingPrice] MONEY         NOT NULL,
    [OrderDate]    DATETIME2 (7) NOT NULL
);


GO
CREATE NONCLUSTERED INDEX [IX_Sales_CustomerId]
    ON [dbo].[Sales]([CusId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Sales_ProductId]
    ON [dbo].[Sales]([ProdId] ASC);


GO
ALTER TABLE [dbo].[Sales]
    ADD CONSTRAINT [PK_Sales] PRIMARY KEY CLUSTERED ([Id] ASC);


GO
ALTER TABLE [dbo].[Sales]
    ADD CONSTRAINT [FK_SALES_Customers_CustomersId] FOREIGN KEY ([CusId]) REFERENCES [dbo].[Customers] ([CustomerId]) ON DELETE CASCADE;


GO
ALTER TABLE [dbo].[Sales]
    ADD CONSTRAINT [FK_Sales_Products_ProductId] FOREIGN KEY ([ProdId]) REFERENCES [dbo].[Products] ([ProductID]) ON DELETE CASCADE;


