﻿CREATE TABLE Products
(
    ProductID       INT            NOT NULL PRIMARY KEY IDENTITY,
	Name            NVARCHAR(100)  NOT NULL,
	Description     NVARCHAR(500)  NOT NULL,
	Category        NVARCHAR(50)   NOT NULL,
	Price           DECIMAL(16,2)  NOT NULL,
	ImageData       VARBINARY(MAX)     NULL,
	ImageMimeType   VARCHAR(50)        NULL  
);

CREATE TABLE Error
(
	ID              INT            NOT NULL PRIMARY KEY IDENTITY,
	Message         NVARCHAR(max)      NULL,
	StackTrace      NVARCHAR(max)      NULL,
	DateCreated     DATETIME       NOT NULL
);
