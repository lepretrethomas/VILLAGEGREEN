/****** Alimentation de la base de données ******/
USE VILLAGE_GREEN
go
--
--
SET IDENTITY_INSERT FOUR ON
go
INSERT INTO FOUR (fou_id, fou_nom, fou_pre, fou_adr, fou_cp, fou_vil, fou_tel)
	VALUES	(13, 'WOODBRASS', NULL, '13 rue', '13001', 'MARSEILLE', '01 01 01 01 01'),
			(45, 'MUSICBOULEVARD', NULL, '31 rue', '31000', 'TOULOUSE', '02 02 02 02 02'),
			(68, 'Berry', 'Chuck', '35 rue', '35000', 'RENNES', '03 03 03 03 03'), 
			(34, 'Van Halen', 'Eddie', '34 rue', '34000', 'MONTPELLIER', '04 04 04 04 04'),
			(43, 'Harrison', 'George', '67 rue', '67000', 'STRASBOURG', '05 05 05 05 05')
go
SET IDENTITY_INSERT FOUR OFF
go
--
--
SET IDENTITY_INSERT CATE ON
go
INSERT INTO CATE (rub_id, rub_nom)
	VALUES	(1, 'Guitares'),
			(2,	'Claviers'),
			(4,	'Percussions'),
			(5,	'Violons'),
			(6,	'Vents'),
			(7,	'Micros'),
			(8,	'Casques')
go
SET IDENTITY_INSERT CATE OFF
go
--
--
SET IDENTITY_INSERT SCAT ON
go
INSERT INTO SCAT (ssrub_id, ssrub_nom, rub_id)
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
SET IDENTITY_INSERT SCAT OFF
go
--
--
SET IDENTITY_INSERT PROD ON
go
INSERT INTO PROD (pro_id, fou_id, pro_nom, pro_lbc, pro_lbl, pro_sto, pro_pho, ssrub_id)
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
SET IDENTITY_INSERT PROD OFF
go
--
--
SET IDENTITY_INSERT SERC ON
go
INSERT INTO SERC (emp_id, emp_nom, emp_pre)
	VALUES	(1, 'Reed', 'Lou'),
			(2, 'Verlaine', 'Tom'),
			(5, 'Beck',	'Jeff')
go
SET IDENTITY_INSERT SERC OFF
go
--
--
SET IDENTITY_INSERT STAT ON
go
INSERT INTO STAT (sta_id, sta_nom, sta_coe)
	VALUES	(1, 'Particulier', 1.30),
			(2, 'Professionnel', 1.10)

go
SET IDENTITY_INSERT STAT OFF
go
--
--
SET IDENTITY_INSERT CLIE ON
go
INSERT INTO CLIE (cli_id, cli_nom,	cli_pre,	cli_adr, cli_cp, cli_vil, cli_tel, sta_id)
	VALUES	(1, 'Hendrix', 'Jimi', '33 rue de la Gironde', '33000', 'BORDEAUX', '06 06 06 06 06', 1),
			(2, 'Clapton', 'Eric', '69 route du Rhone', '69001', 'LYON', '07 07 07 07 07', 1),
			(3, 'Page', 'Jimmy', '80 rue de la Somme', '80000', 'AMIENS', '08 08 08 08 08', 1),				
			(4, 'Richards', 'Keith', '59 route du Nord', '59000', 'LILLE', '09 09 09 09 09', 1),
			(5, 'Beck', 'Jeff', '44 rue de la Loire', '44000', 'NANTES', '11 22 33 44 55', 1),
			(6, 'SONY MUSIC', NULL, '131 av. de Wagram', '75017', 'PARIS', '01 44 40 60 60', 2),	
			(7, 'UNIVERSAL MUSIC', NULL, '22 rue des Fossés St-Jacques', '75235', 'PARIS', '01 44 41 91 91', 2)
go
SET IDENTITY_INSERT CLIE OFF
go
--
--
INSERT INTO NEGO (fac_red, emp_id, cli_id)
	VALUES	(10, 2, 4),
			(150, 5, 5) 
go
--
--
SET IDENTITY_INSERT COMM ON
go
INSERT INTO COMM (com_id, com_eta, com_dat, cli_id, fac_adr, fac_cp, fac_vil, liv_adr, liv_cp, liv_vil)
	VALUES	(456, 'Terminé', '12/12/2015', 3, '80 rue de la Somme', '80000', 'AMIENS', '80 rue de la Somme', '80000', 'AMIENS'),
			(123, 'En cours de livraison', '12/12/2015', 5, '44 rue de la Loire', '44000', 'NANTES', '44 rue de la Loire', '44000', 'NANTES'),
			(68, 'En attente de paiement','15/12/2015', 7, '22 rue des Fossés St-Jacques', '75235', 'PARIS', '22 rue des Fossés St-Jacques', '75235', 'PARIS')
go
SET IDENTITY_INSERT COMM OFF
go
--
--
SET IDENTITY_INSERT LIGN ON
go
INSERT INTO LIGN (com_lig, com_qte, com_pu, com_id, pro_id)
	VALUES	(1, 1, 276, 456, '184790'),
			(2, 1, 1159, 456, '213895'),
			(6, 15, 76, 123, '127900'),
			(7, 30, 209, 68, '30277')
go
SET IDENTITY_INSERT LIGN OFF
go
--
--
SET IDENTITY_INSERT LIVR ON
go
INSERT INTO LIVR (liv_id, liv_exp, liv_rec, com_id)
	VALUES	(8, '14/12/2015', '15/12/2015', 456),
			(12, '14/12/2015', '15/12/2015', 123),
			(13, '15/12/2015', NULL, 123)
go
SET IDENTITY_INSERT LIVR OFF
go
--
--
INSERT INTO CONT (liv_qte, pro_id, liv_id)
	VALUES	(1, '184790', 8),
			(1, '213895', 8),
			(10,'127900', 12),
			(5, '127900', 13)
go
--
--
SET IDENTITY_INSERT FACT ON
go
INSERT INTO FACT (fac_id, fac_dat, fac_tot, com_id)
	VALUES	(478, '12/12/2015', 1435, 456),
			(256, '12/12/2015', 1140, 123),
			(98,  '15/12/2015', 6270, 68)
go
SET IDENTITY_INSERT FACT OFF
go
--
--
SET IDENTITY_INSERT REGL ON
go
INSERT INTO REGL (reg_id, reg_dat, reg_tot, fac_id)
	VALUES	(125, '12/12/2015', 1435, 478),
			(128, '12/12/2015', 1140, 256)
go
SET IDENTITY_INSERT REGL OFF
go
