
DELETE VAR.Varilla
DELETE GES.Marco
DELETE GES.Comprador
DELETE GES.Pedido

SELECT * FROM GES.Pedido 
SELECT * FROM GES.Marco
SELECT * FROM VAR.Varilla 
SELECT * FROM GES.Comprador 

--SCRIPT INICIAL CON VARILLAS
IF NOT EXISTS(SELECT * FROM VAR.Varilla WHERE Nombre = 'Chata 1,5 Cedro')
BEGIN
	INSERT INTO VAR.Varilla VALUES ('Chata 1,5 Cedro', 1.5, 140, 1, 1)
	INSERT INTO VAR.Varilla VALUES ('Chata 3 Kiri', 3, 140, 1, 1)
	INSERT INTO VAR.Varilla VALUES ('Chata 4,5 Kiri', 4.5, 180, 1, 1)
	INSERT INTO VAR.Varilla VALUES ('Chata 6 Kiri', 6, 180, 1, 1)
	
	INSERT INTO VAR.Varilla VALUES ('Bombe 1,5 Kiri', 1.5, 140, 1, 1)
	INSERT INTO VAR.Varilla VALUES ('Bombe 1,5 Roble Claro', 1.5, 140, 1, 1)
	INSERT INTO VAR.Varilla VALUES ('Bombe 1,5 Roble Oscuro', 1.5, 140, 1, 1)
	INSERT INTO VAR.Varilla VALUES ('Bombe 2 Roble Claro', 2, 140, 1, 1)
	INSERT INTO VAR.Varilla VALUES ('Bombe 2 Roble Oscuro', 2, 140, 1, 1)
	
	INSERT INTO VAR.Varilla VALUES ('Italiana 2 Kiri', 2, 140, 1, 1)
	INSERT INTO VAR.Varilla VALUES ('Italiana 2 Roble claro', 2, 140, 1, 1)
	INSERT INTO VAR.Varilla VALUES ('Italiana 2 Cedro', 2, 140, 1, 1)
	INSERT INTO VAR.Varilla VALUES ('Italiana 3 Kiri', 3, 140, 1, 1)
END
