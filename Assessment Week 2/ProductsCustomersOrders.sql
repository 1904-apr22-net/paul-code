CREATE TABLE Products (
	ProductId INT NOT NULL IDENTITY,
	Name NVARCHAR(200) NOT NULL,
	Price MONEY NOT NULL,
	CONSTRAINT PK_ProductId PRIMARY KEY (ProductId),
);
CREATE TABLE Customers (
	CustomerId INT NOT NULL IDENTITY,
	FirstName NVARCHAR(200) NOT NULL,
	LastName NVARCHAR(200) NOT NULL,
	CardNumer NVARCHAR(20) NULL,
	CONSTRAINT PK_CustomerId PRIMARY KEY (CustomerId),
);

CREATE TABLE Orders (
	OrderId INT NOT NULL IDENTITY,
	CustomerId INT NOT NULL,
	ProductId INT NOT NULL,
	CONSTRAINT PK_OrderId PRIMARY KEY (OrderId),
	CONSTRAINT FK_CustomerId FOREIGN KEY(CustomerId) REFERENCES Customers(CustomerId),
	CONSTRAINT FK_ProductId FOREIGN KEY(ProductId) REFERENCES Products(ProductId),
);


INSERT INTO Products(Name, Price) VALUES ('Bacon', 10);
INSERT INTO Products(Name, Price) VALUES ('Eggs', 3);
INSERT INTO Products(Name, Price) VALUES ('Cheese', 6);

INSERT INTO Customers(FirstName,LastName,CardNumer) 
VALUES('Paul','Grimes','4133 5678 9012 3456');
INSERT INTO Customers(FirstName,LastName,CardNumer) 
VALUES('Jack','Black','1234 0372 9488 8473');
INSERT INTO Customers(FirstName,LastName,CardNumer) 
VALUES('Potato','Head','3827 5678 4324 3234');

INSERT INTO Orders(CustomerId,ProductId) VALUES(1,3);
INSERT INTO Orders(CustomerId,ProductId) VALUES(2,1);
INSERT INTO Orders(CustomerId,ProductId) VALUES(3,2);

INSERT INTO Products(Name, Price) VALUES ('iPhone', 200);

INSERT INTO Customers(FirstName,LastName,CardNumer) 
VALUES('Tina','Smith','1732 3812 9483 3716');

INSERT INTO Orders(CustomerId,ProductId) VALUES(4,4);

SELECT FirstName,LastName, Name FROM Customers
INNER JOIN Orders ON Customers.CustomerId = Orders.OrderId
INNER JOIN Products ON Orders.ProductId = Products.ProductId
Where FirstName = 'Tina' AND LastName = 'Smith'

SELECT Sum(Price)as TotalSales FROM Products as p 
INNER JOIN Orders as o ON p.ProductId = o.ProductId
Where p.Name = 'Iphone'
Group by(o.ProductId)

UPDATE Products
SET Price = 250
WHERE Name = 'Iphone'