USE model;
GO

CREATE DATABASE Refrigerator_store;
GO

USE Refrigerator_store;
GO

CREATE TABLE goods
(
	"Goods_ID" INT NOT NULL PRIMARY KEY IDENTITY,
	"Name" NVARCHAR(20) NOT NULL,
	"Quantity" SMALLINT NOT NULL DEFAULT 0 CHECK (Quantity >= 0)
);
GO

CREATE TABLE sellers
(
	"Seller_ID" TINYINT NOT NULL PRIMARY KEY IDENTITY,
	"LastName" NVARCHAR(20) NOT NULL,
	"FirstName" NVARCHAR(15) NOT NULL,
	"Patronymic" NVARCHAR(20) NOT NULL
);
GO

CREATE TABLE customers
(
	"Customer_ID" INT NOT NULL PRIMARY KEY IDENTITY,
	"LastName" NVARCHAR(20) NOT NULL,
	"FirstName" NVARCHAR(15) NOT NULL,
	"Patronymic" NVARCHAR(20) NOT NULL,
	"PurchasedGoods" INT NOT NULL DEFAULT 0
);
GO

CREATE TABLE sales_receipts
(
	"Receipt_ID" INT NOT NULL PRIMARY KEY IDENTITY,
	"DateOfsale" DATE NOT NULL DEFAULT GETDATE(),
	"FullNameCustomer" NVARCHAR(55) NOT NULL,
	"FullNameSeller" NVARCHAR(55) NOT NULL,
	"ProductName" NVARCHAR(20) NOT NULL
);
GO


-- INSERT

INSERT INTO goods
	VALUES
	('Whirlpool D9', 6),
	('LG L80', 5),
	('Samsung D900', 4),
	('Toshiba S8', 3),
	('LG P22', 2),
	('Xiaomi Fr1', 1);
GO

INSERT INTO sellers
	VALUES
	('Антонова', 'Ульяна', 'Степановна'),
	('Федотова', 'Влада', 'Сергеевна'),
	('Медведева', 'Лилия', 'Александровна'),
	('Фокина', 'Юлия', 'Андреевна');
GO

INSERT INTO customers
	("LastName", "FirstName", "Patronymic")
	VALUES
	('Буров', 'Аристарх', 'Петрович'),
	('Дроздов', 'Платон', 'Орландович'),
	('Логинов', 'Геннадий', 'Игоревич'),
	('Дмитриев', 'Евгений', 'Семенович'),
	('Орехов', 'Григорий', 'Филиппович'),
	('Виноградов', 'Николай', 'Романович')
GO

ALTER TABLE dbo.goods
ADD CHECK(Quantity >= 0);