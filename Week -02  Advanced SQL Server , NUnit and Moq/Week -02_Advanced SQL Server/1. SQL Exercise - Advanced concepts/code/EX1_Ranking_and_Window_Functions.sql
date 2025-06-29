CREATE DATABASE OnlineRetailStore;
Go
USE OnlineRetailStore;
GO
CREATE TABLE Products (
    ProductID INT PRIMARY KEY identity(1,1),
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10, 2)
);
INSERT INTO Products (ProductName, Category, Price) VALUES
('Laptop', 'Electronics', 75000.00),
('Smartphone', 'Electronics', 50000.00),
('Tablet', 'Electronics', 30000.00),
('LED TV', 'Electronics', 60000.00),

('T-shirt', 'Clothing', 500.00),
('Jacket', 'Clothing', 3000.00),
('Shoes', 'Clothing', 2500.00),
('Cap', 'Clothing', 300.00),

('Sofa', 'Furniture', 15000.00),
('Dining Table', 'Furniture', 20000.00),
('Bed', 'Furniture', 18000.00),
('Bookshelf', 'Furniture', 5000.00);

WITH RankedProducts AS (
    SELECT 
        ProductID,
        ProductName,
        Category,
        Price,
        ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS RowNum,
        RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS RankNum,
        DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS DenseRankNum
    FROM Products
)
SELECT 
    ProductID,
    ProductName,
    Category,
    Price,
    RowNum,
    RankNum,
    DenseRankNum
FROM RankedProducts
WHERE RowNum <= 3
ORDER BY Category, RowNum;


