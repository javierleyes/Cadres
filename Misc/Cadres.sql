
DROP DATABASE CADRES

DELETE dbo.Varilla
DELETE dbo.Marco
DELETE dbo.Comprador
DELETE dbo.Pedido

SELECT * FROM dbo.Pedido 
SELECT * FROM dbo.Marco
SELECT * FROM dbo.Varilla 
SELECT * FROM dbo.Comprador 

-- SCRIPT INICIAL 

-- VARILLAS
INSERT INTO dbo.Varilla VALUES ('Chata 1,5 Cedro', 1.5, 140, 1, 1)
INSERT INTO dbo.Varilla VALUES ('Chata 2 Roble Oscuro', 2, 260, 1, 1)
INSERT INTO dbo.Varilla VALUES ('Chata 3 Kiri', 3, 140, 1, 1)
INSERT INTO dbo.Varilla VALUES ('Chata 4,5 Kiri', 4.5, 180, 1, 1)
INSERT INTO dbo.Varilla VALUES ('Chata 6 Kiri', 6, 180, 1, 1)
			
INSERT INTO dbo.Varilla VALUES ('Bombe 1,5 Kiri', 1.5, 140, 1, 1)
INSERT INTO dbo.Varilla VALUES ('Bombe 1,5 Roble Claro', 1.5, 140, 1, 1)
INSERT INTO dbo.Varilla VALUES ('Bombe 1,5 Roble Oscuro', 1.5, 140, 1, 1)
INSERT INTO dbo.Varilla VALUES ('Bombe 2 Roble Claro', 2, 140, 1, 1)
INSERT INTO dbo.Varilla VALUES ('Bombe 2 Roble Oscuro', 2, 140, 1, 1)
			
INSERT INTO dbo.Varilla VALUES ('Italiana 2 Kiri', 2, 140, 1, 1)
INSERT INTO dbo.Varilla VALUES ('Italiana 2 Roble claro', 2, 140, 1, 1)
INSERT INTO dbo.Varilla VALUES ('Italiana 2 Cedro', 2, 140, 1, 1)
INSERT INTO dbo.Varilla VALUES ('Italiana 3 Kiri', 3, 140, 1, 1)
INSERT INTO dbo.Varilla VALUES ('Italiana 3 cedro', 3, 200, 1, 1)
INSERT INTO dbo.Varilla VALUES ('Italiana 4,5 cedro', 4.5, 450, 1, 1)

-- PEDIDOS
INSERT INTO dbo.Pedido VALUES ('Este marco ya se realizo', '20190406', 450, 0, 1, NULL, NULL)

-- SEGUIMIENTO PEDIDO
SELECT TOP 1 * FROM dbo.Pedido ORDER BY Id DESC

SELECT * FROM dbo.Marco WHERE Pedido_Id IN (SELECT TOP 1 Id FROM dbo.Pedido ORDER BY Id DESC)

SELECT * FROM dbo.Comprador WHERE PedidoId = (SELECT TOP 1 Id FROM dbo.Pedido ORDER BY Id DESC)