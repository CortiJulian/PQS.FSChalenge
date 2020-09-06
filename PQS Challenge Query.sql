CREATE DATABASE [PQS Challenge]

CREATE TABLE ORDERS (
OrderId INT PRIMARY KEY IDENTITY(1,1),
OrderStatus INT NOT NULL,
OrderDescription NVARCHAR(255) NOT NULL,
CreatedOn DATETIME NOT NULL,
AuthDate DATETIME
)

CREATE TABLE ORDER_ITEMS (
OrderItemId INT PRIMARY KEY NONCLUSTERED IDENTITY(1,1),
OrderId INT NOT NULL,
ItemDescription NVARCHAR(255) NOT NULL,
Quantity INT NOT NULL,
UnitPrice NUMERIC(32,2) NOT NULL

CONSTRAINT FK_ORDER_ITEMS_ORDERS FOREIGN KEY (OrderId)
REFERENCES	ORDERS (OrderId)
)

CREATE CLUSTERED INDEX IX_ORDER_ITEMS_OrderId
ON ORDER_ITEMS (OrderId);  

ALTER TABLE ORDERS 
ADD CONSTRAINT DF_ORDER_CreatedOn  
DEFAULT GETDATE() FOR CreatedOn;

CREATE NONCLUSTERED INDEX IX_ORDER_Status   
    ON ORDERS (OrderStatus);  

CREATE VIEW vORDERS_INFO AS
SELECT O.OrderId, O.OrderDescription, O.OrderStatus, O.CreatedOn, O.AuthDate, SUM(OI.UnitPrice * OI.Quantity) AS Total, SUM(OI.Quantity) AS QItems
FROM ORDERS AS O 
LEFT JOIN ORDER_ITEMS AS OI
ON OI.OrderId = O.OrderId
GROUP BY O.OrderId, O.OrderDescription, O.OrderStatus, O.CreatedOn, O.AuthDate
