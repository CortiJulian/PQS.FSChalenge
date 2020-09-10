CREATE DATABASE [PQS Challenge]

GO

CREATE TABLE [PQS Challenge].dbo.ORDERS (
OrderId INT PRIMARY KEY IDENTITY(1,1),
OrderStatus INT NOT NULL,
OrderDescription NVARCHAR(255) NOT NULL,
CreatedOn DATETIME NOT NULL,
AuthDate DATETIME
)

GO

CREATE TABLE [PQS Challenge].dbo.ORDER_ITEMS (
OrderItemId INT PRIMARY KEY NONCLUSTERED IDENTITY(1,1),
OrderId INT NOT NULL,
ItemDescription NVARCHAR(255) NOT NULL,
Quantity INT NOT NULL,
UnitPrice NUMERIC(32,2) NOT NULL

CONSTRAINT FK_ORDER_ITEMS_ORDERS FOREIGN KEY (OrderId)
REFERENCES	[PQS Challenge].dbo.ORDERS (OrderId)
)

GO

CREATE CLUSTERED INDEX IX_ORDER_ITEMS_OrderId
ON [PQS Challenge].dbo.ORDER_ITEMS (OrderId);  

ALTER TABLE [PQS Challenge TEST].dbo.ORDERS 
ADD CONSTRAINT DF_ORDER_CreatedOn  
DEFAULT GETDATE() FOR CreatedOn;

CREATE NONCLUSTERED INDEX IX_ORDER_Status   
ON [PQS Challenge].dbo.ORDERS (OrderStatus);
	
GO

USE [PQS Challenge]

GO

CREATE VIEW vORDERS_INFO AS
SELECT O.OrderId, O.OrderDescription, O.OrderStatus, O.CreatedOn, O.AuthDate, SUM(OI.UnitPrice * OI.Quantity) AS Total, SUM(OI.Quantity) AS QItems
FROM [PQS Challenge].dbo.ORDERS AS O 
LEFT JOIN [PQS Challenge].dbo.ORDER_ITEMS AS OI
ON OI.OrderId = O.OrderId
GROUP BY O.OrderId, O.OrderDescription, O.OrderStatus, O.CreatedOn, O.AuthDate
