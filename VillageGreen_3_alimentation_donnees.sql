/****** Alimentation de la base de données ******/
USE VILLAGE_GREEN
go
--
--
SET IDENTITY_INSERT Four ON
go
INSERT INTO Four (four_ref, four_nom, four_prenom, four_adresse, four_cp, four_ville, four_tel)
	VALUES	(13, 'WOODBRASS', NULL, '13 rue', '13001', 'MARSEILLE', '01 01 01 01 01'),
			(45, 'MUSICBOULEVARD', NULL, '31 rue', '31000', 'TOULOUSE', '02 02 02 02 02'),
			(68, 'Berry', 'Chuck', '35 rue', '35000', 'RENNES', '03 03 03 03 03'), 
			(34, 'Van Halen', 'Eddie', '34 rue', '34000', 'MONTPELLIER', '04 04 04 04 04'),
			(43, 'Harrison', 'George', '67 rue', '67000', 'STRASBOURG', '05 05 05 05 05')
go
SET IDENTITY_INSERT Four OFF
go
--
--
SET IDENTITY_INSERT Cat ON
go
INSERT INTO Cat (rub_id, rub_nom)
	VALUES	(1, 'Guitares'),
			(2,	'Claviers'),
			(4,	'Percussions'),
			(5,	'Violons'),
			(6,	'Vents'),
			(7,	'Micros'),
			(8,	'Casques')
go
SET IDENTITY_INSERT Cat OFF
go
--
--
SET IDENTITY_INSERT SsCat ON
go
INSERT INTO SsCat (ssrub_id, ssrub_nom, rub_id)
	VALUES	(100, 'Basses', 1),
			(102, 'Guitares classiques', 1),
			(103, 'Guitares électriques', 1),
			(105, 'Pianos', 2),
			(120, 'Batteries acoustiques', 4),
			(140, 'Clarinettes', 6),
			(143, 'Harmonicas',	6),
			(149, 'Etuis et Housses', 5),
			(201, 'Micros filaires', 7),
			(207, 'Casques sans fil', 8),
			(209, 'Casques DJ',	8)
go
SET IDENTITY_INSERT SsCat OFF
go
--
--
SET IDENTITY_INSERT Prod ON
go
INSERT INTO Prod (prod_ref, four_ref, prod_nom, prod_lib_court, prod_lib_long, prod_stock, prod_photo, ssrub_id)
	VALUES	('125234', '68', 'KINGMAN BASS V2 NATURAL + ETUI', '1aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa', '1bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb', 72, NULL, 100),
			('196704', '68', 'B4JRKIT-BLK BLACK BRILLANT', '2aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa', '2bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb', 89, NULL, 103),
			('191380', '34', 'TRAVEL BASS TB-4P', '3aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa', '3bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb', 56, NULL, 103),
			('213895', '13', 'FULLPACK F-140R-CB', '4aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa', '4bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb', 27, NULL, 105),
			('184790', '43', 'DS200 BK', '5aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa', '5bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb', 58, NULL, 120),
			('108752', '34', 'CL1 Sib', '6aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa', '6bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb',	135, NULL, 140),
			('30872', '43', 'HARMONICA DIATONIQUE', '7aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa', '7bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb', 201, NULL, 143),
			('127900', '45', '1SKB-244 ETUI POUR VIOLON', '8aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa', '8bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb', 145, NULL, 149),
			('20154', '13', 'SM58', '9aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa', '9bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb', 105, NULL, 201),
			('30277', '43', 'HD 205 II WEST', '10aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa', '10bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb', 68, NULL, 209)
go
SET IDENTITY_INSERT Prod OFF
go
--
--
SET IDENTITY_INSERT ServCom ON
go
INSERT INTO ServCom (commercial_id, commercial_nom, commercial_prenom)
	VALUES	(1, 'Reed', 'Lou'),
			(2, 'Verlaine', 'Tom'),
			(5, 'Beck',	'Jeff')
go
SET IDENTITY_INSERT ServCom OFF
go	
--
--
SET IDENTITY_INSERT Client ON
go
INSERT INTO Client (cli_ref, cli_nom,	cli_prenom,	cli_adresse, cli_cp, cli_ville, cli_tel, cli_categorie, cli_coef)
	VALUES	(1, 'Hendrix', 'Jimi', '33 rue de la Gironde', '33000', 'BORDEAUX', '06 06 06 06 06', 'Particulier', 1.30),
			(2, 'Clapton', 'Eric', '69 route du Rhone', '69001', 'LYON', '07 07 07 07 07', 'Particulier', 1.30),
			(3, 'Page', 'Jimmy', '80 rue de la Somme', '80000', 'AMIENS', '08 08 08 08 08', 'Particulier', 1.30),				
			(4, 'Richards', 'Keith', '59 route du Nord', '59000', 'LILLE', '09 09 09 09 09', 'Particulier', 1.30),
			(5, 'Beck', 'Jeff', '44 rue de la Loire', '44000', 'NANTES', '11 22 33 44 55', 'Particulier', 1.30),
			(6, 'SONY MUSIC', NULL, '131 av. de Wagram', '75017', 'PARIS', '01 44 40 60 60', 'Professionnel', 1.10),	
			(7, 'UNIVERSAL MUSIC', NULL, '22 rue des Fossés St-Jacques', '75235', 'PARIS', '01 44 41 91 91', 'Professionnel', 1.10)
go
SET IDENTITY_INSERT Client OFF
go
--
--
INSERT INTO nego (fac_reduction, commercial_id, cli_ref)
	VALUES	(10, 2, 4),
			(150, 5, 5) 
go
--
--
SET IDENTITY_INSERT Com ON
go
INSERT INTO Com (com_num, com_etat, com_date, cli_ref, fac_adresse, fac_cp, fac_ville, liv_adresse, liv_cp, liv_ville)
	VALUES	(456, 'Terminé', '12/12/2015', 3, '80 rue de la Somme', '80000', 'AMIENS', '80 rue de la Somme', '80000', 'AMIENS'),
			(123, 'En cours de livraison', '12/12/2015', 5, '44 rue de la Loire', '44000', 'NANTES', '44 rue de la Loire', '44000', 'NANTES'),
			(68, 'En attente de paiement','15/12/2015', 7, '22 rue des Fossés St-Jacques', '75235', 'PARIS', '22 rue des Fossés St-Jacques', '75235', 'PARIS')
go
SET IDENTITY_INSERT Com OFF
go
--
--
SET IDENTITY_INSERT Ligcom ON
go
INSERT INTO Ligcom (com_ligne, com_qte, com_pu, com_num, prod_ref)
	VALUES	(1, 1, 276, 456, '184790'),
			(2, 1, 1159, 456, '213895'),
			(6, 15, 76, 123, '127900'),
			(7, 30, 209, 68, '30277')
go
SET IDENTITY_INSERT Ligcom OFF
go
--
--
SET IDENTITY_INSERT Livr ON
go
INSERT INTO Livr (liv_num, liv_exp, liv_rec, com_num)
	VALUES	(8, '14/12/2015', '15/12/2015', 456),
			(12, '14/12/2015', '15/12/2015', 123),
			(13, '15/12/2015', NULL, 123)
go
SET IDENTITY_INSERT Livr OFF
go
--
--
INSERT INTO cont (liv_qte, prod_ref, liv_num)
	VALUES	(1, '184790', 8),
			(1, '213895', 8),
			(10,'127900', 12),
			(5, '127900', 13)
go
--
--
SET IDENTITY_INSERT Fact ON
go
INSERT INTO Fact (fac_num, fac_date, fac_montant, com_num)
	VALUES	(478, '12/12/2015', 1435, 456),
			(256, '12/12/2015', 1140, 123),
			(98,  '15/12/2015', 6270, 68)
go
SET IDENTITY_INSERT Fact OFF
go
--
--
SET IDENTITY_INSERT Regl ON
go
INSERT INTO Regl (reglement_num, reglement_date, reglement_montant, fac_num)
	VALUES	(125, '12/12/2015', 1435, 478),
			(128, '12/12/2015', 1140, 256)
go
SET IDENTITY_INSERT Regl OFF
go
