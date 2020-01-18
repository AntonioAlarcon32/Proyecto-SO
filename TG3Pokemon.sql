DROP DATABASE IF EXISTS TG3Pokemon;
CREATE DATABASE TG3Pokemon;

USE TG3Pokemon;

CREATE TABLE Players (
					  nombre VARCHAR(50) NOT NULL UNIQUE,
					  passwo VARCHAR(50) NOT NULL,
					  id INT,
					  nivel INT,
					  PartidasGanadas INT,
					  UNIQUE (nombre),
					  PRIMARY KEY (id)
					  )ENGINE=InnoDB;

CREATE TABLE Partidas (
					   id INT NOT NULL,
					   Fecha VARCHAR(11) NOT NULL,
					   Turnos INT NOT NULL,
					   Ganador1 VARCHAR(50) NOT NULL,
					   Ganador2 VARCHAR(50) NOT NULL,
					   PRIMARY KEY (id)
					   )ENGINE =InnoDB;

CREATE TABLE Relacion (
					   idJugador INT NOT NULL,
					   idPartida INT NOT NULL,
					   PokemonsRestantes INT NOT NULL,
					   FOREIGN KEY (idJugador) REFERENCES Players(id),
					   FOREIGN KEY (idPartida) REFERENCES Partidas(id)
					   )ENGINE = InnoDB;

INSERT INTO Players VALUES ('Alarcn32','proyectoso', 0001, 1, 1);
INSERT INTO Players VALUES ('SirXape','proyectoso',0002,1,2);
INSERT INTO Players VALUES ('StoodYapper','proyectoso',0003,1,2);
INSERT INTO Players VALUES ('Julia','proyectoso',0004,1,1);
INSERT INTO Players VALUES ('Poison','proyectoso',0005,1,1);


INSERT INTO Partidas VALUES (0001,'04.10.2019',16,'Alarcn32','-');
INSERT INTO Partidas VALUES (0002,'04.10.2019',23,'SirXape','StoodYapper');
INSERT INTO Partidas VALUES (0003,'05.10.2019',14,'Julia','SirXape');
INSERT INTO Partidas VALUES (0004,'06.10.2019',29,'Poison','StoodYapper');

INSERT INTO Relacion VALUES (0001,0001,3);
INSERT INTO Relacion VALUES (0002,0001,0);
INSERT INTO Relacion VALUES (0001,0002,0);
INSERT INTO Relacion VALUES (0002,0002,2);
INSERT INTO Relacion VALUES (0003,0002,1);
INSERT INTO Relacion VALUES (0004,0002,0);
INSERT INTO Relacion VALUES (0001,0003,0);
INSERT INTO Relacion VALUES (0002,0003,2);
INSERT INTO Relacion VALUES (0003,0003,0);
INSERT INTO Relacion VALUES (0004,0003,0);
INSERT INTO Relacion VALUES (0001,0004,0);
INSERT INTO Relacion VALUES (0002,0004,0);
INSERT INTO Relacion VALUES (0003,0004,0);
INSERT INTO Relacion VALUES (0005,0004,3);
