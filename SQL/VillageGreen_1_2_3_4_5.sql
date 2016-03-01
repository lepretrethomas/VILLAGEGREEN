/*************************************************************
******************** FIL ROUGE *******************************
*************************************************************/

----- Suppression de la base Village Green existante
/*
USE VILLAGEGREEN
DROP USER VG_us01
go
DROP USER VG_us02
go
DROP USER VG_us03
go
USE master
go
DROP LOGIN VG_log01
go
DROP LOGIN VG_log02
go
DROP LOGIN VG_log03
go
DROP DATABASE VILLAGEGREEN
go
*/

----- Création de la base de donnees Village Green
CREATE DATABASE VILLAGEGREEN
go

USE VILLAGEGREEN
go

/****** Création des Tables ******/
----- Table: SERVICE COMMERCIAL
CREATE TABLE SERC (
	emp_id    	INT IDENTITY NOT NULL,
	emp_nom  	VARCHAR(50),
	emp_pre	VARCHAR(25),
	PRIMARY KEY (emp_id)
)

----- Table: STATUT
CREATE TABLE STAT (
	sta_id     			INT IDENTITY NOT NULL,
	sta_nom      		VARCHAR(50) NOT NULL,
	sta_coe				numeric (3,2) NOT NULL,
	PRIMARY KEY (sta_id)
)

----- Table: CLIENTS
CREATE TABLE CLIE (
	cli_id     			INT IDENTITY NOT NULL,
	sta_id 			INT NOT NULL,
	cli_nom      		VARCHAR(50) NOT NULL,
	cli_pre  		VARCHAR(25),
	cli_adr  		VARCHAR(100) NOT NULL,
	cli_cp       		int check (cli_cp like '[0-9][0-9][0-9][0-9][0-9]') NOT NULL,
	cli_vil    		VARCHAR(100) NOT NULL,
	cli_tel      		VARCHAR(15) NOT NULL,
	fac_adr   		VARCHAR(100) NOT NULL,
	fac_cp        		int check (fac_cp like '[0-9][0-9][0-9][0-9][0-9]') NOT NULL,
	fac_vil    		VARCHAR(100) NOT NULL,
	liv_adr 		VARCHAR(100) NOT NULL,
	liv_cp      		int check (liv_cp like '[0-9][0-9][0-9][0-9][0-9]') NOT NULL,
	liv_vil   		VARCHAR(100) NOT NULL,
	PRIMARY KEY (cli_id)
)

----- Table: FOURNISSEURS
CREATE TABLE FOUR (
	fou_id    			INT IDENTITY NOT NULL,
	fou_nom     		VARCHAR(50) NOT NULL,
	fou_pre 		VARCHAR(25),
	fou_adr 		VARCHAR(100) NOT NULL,
	fou_cp      		int check (fou_cp like '[0-9][0-9][0-9][0-9][0-9]') NOT NULL,
	fou_vil   		VARCHAR(100) NOT NULL,
	fou_tel     		VARCHAR(15) NOT NULL,
	PRIMARY KEY (fou_id)
)

----- Table: PRODUITS
CREATE TABLE PROD (
	pro_id        	INT IDENTITY NOT NULL,
	fou_id			INT NOT NULL,
	pro_lbc  	VARCHAR(50) NOT NULL,
	pro_lbl   	VARCHAR(1500),
	pro_pho      	VARCHAR(50),
	ssrub_id        INT,
	PRIMARY KEY (pro_id)
)

----- Table: COMMANDES
CREATE TABLE COMM (
	com_id  			INT IDENTITY NOT NULL,
	com_dat 			DATE DEFAULT GETDATE() NOT NULL,
	com_eta 			VARCHAR(25) NOT NULL,
	com_tot				numeric (10,2),
	cli_id  			INT NOT NULL,
	PRIMARY KEY (com_id)
)

----- Table: FACTURATIONS
CREATE TABLE FACT (
	fac_id       		INT IDENTITY NOT NULL,
	com_id       		INT NOT NULL,
	fac_dat      		DATE DEFAULT GETDATE() NOT NULL,
	fac_red			numeric (10,2),
	fac_tot   		numeric (10,2) NOT NULL,
	PRIMARY KEY (fac_id)
)

----- Table: REGLEMENTS
CREATE TABLE REGL (
	reg_id     	INT IDENTITY NOT NULL,
	fac_id           	INT NOT NULL,
	reg_dat   	DATE DEFAULT GETDATE() NOT NULL,
	reg_tot 	numeric (10,2) NOT NULL,
	PRIMARY KEY (reg_id)
)

----- Table: LIGNES DE COMMANDE
CREATE TABLE LIGN (
	com_lig 			INT IDENTITY NOT NULL,
	com_qte   			INT NOT NULL,
	com_pu    			numeric (10,2) NOT NULL,
	com_id   			INT,
	pro_id  			INT NOT NULL,
	PRIMARY KEY (com_lig)
)

----- Table: LIVRAISONS
CREATE TABLE LIVR (
	liv_id     		INT IDENTITY NOT NULL,
	com_id     		INT NOT NULL,
	liv_exp     		DATE NOT NULL,
	liv_rec     		DATE,
	PRIMARY KEY (liv_id)
)

----- Table: CATEGORIES
CREATE TABLE CATE (
	rub_id  			INT IDENTITY NOT NULL,
	rub_nom 			VARCHAR(25),
	PRIMARY KEY (rub_id)
)

----- Table: SOUS-CATEGORIES
CREATE TABLE SCAT (
	ssrub_id  			INT IDENTITY NOT NULL,
	ssrub_nom 			VARCHAR(25),
	rub_id    			INT NOT NULL,
	PRIMARY KEY (ssrub_id)
)

----- Table: COLIS
CREATE TABLE COLI (
	liv_id  			INT NOT NULL,
	liv_qte  			INT NOT NULL,
	pro_id 			INT NOT NULL,
	PRIMARY KEY (pro_id, liv_id)
)
go

/****** Création des Contraintes ******/
----- Contrainte: Statut
ALTER TABLE CLIE
	ADD
		FOREIGN KEY (sta_id) REFERENCES STAT(sta_id)

----- Contrainte: Produits
ALTER TABLE PROD
	ADD
		FOREIGN KEY (ssrub_id) REFERENCES SCAT(ssrub_id),
		FOREIGN KEY (fou_id) REFERENCES FOUR(fou_id)

----- Contrainte: SousCatégories
ALTER TABLE SCAT
	ADD
		FOREIGN KEY (rub_id) REFERENCES CATE(rub_id)

----- Contrainte: Lignes de commande
ALTER TABLE LIGN
	ADD
		FOREIGN KEY (pro_id) REFERENCES PROD(pro_id),
		FOREIGN KEY (com_id) REFERENCES COMM(com_id)

----- Contrainte: Commandes
ALTER TABLE COMM
	ADD
		FOREIGN KEY (cli_id) REFERENCES CLIE(cli_id)
	
----- Contrainte: Facturations
ALTER TABLE FACT
	ADD
		FOREIGN KEY (com_id) REFERENCES COMM(com_id),
		CONSTRAINT FACT_AK UNIQUE (com_id)

----- Contrainte: Règlements
ALTER TABLE REGL
	ADD
		FOREIGN KEY (fac_id) REFERENCES FACT(fac_id),
		CONSTRAINT REGL_AK UNIQUE (fac_id)

----- Contrainte: Livraisons
ALTER TABLE LIVR
	ADD
		FOREIGN KEY (com_id) REFERENCES COMM(com_id)

----- Contrainte: Colis
ALTER TABLE COLI
	ADD
		FOREIGN KEY (pro_id) REFERENCES PROD(pro_id),
		FOREIGN KEY (liv_id) REFERENCES LIVR(liv_id)
go

/****** Création des Indexs ******/
----- Index sur les noms Clients
create nonclustered index ix_client on CLIE(cli_nom)

----- Index sur les noms FOURnisseurs
create nonclustered index ix_fournis on FOUR(fou_nom)

----- Index sur les noms Produits
create nonclustered index ix_produit on PROD(pro_lbc)

---- Index sur les villes Clients
create nonclustered index ix_vilcli on CLIE(cli_cp, cli_vil)

---- Index sur les villes FOURnisseurs
create nonclustered index ix_vilfou on FOUR(fou_cp, fou_vil)

---- Index sur les villes Livraisons
create nonclustered index ix_villiv on CLIE(liv_cp, liv_vil)
go

/****** Création des Rôles ******/
create role GESTION --GESTION
grant SELECT, INSERT, DELETE, UPDATE on SCHEMA::dbo to GESTION
go

create role COMPTABLE -- COMPTABILITE
grant SELECT, INSERT, DELETE, UPDATE on FACT to COMPTABLE
grant SELECT, INSERT, DELETE, UPDATE on REGL to COMPTABLE
grant SELECT, INSERT, UPDATE on CLIE to COMPTABLE
go

create role LIVRAISON -- LIVRAISON
grant SELECT, INSERT, DELETE, UPDATE on LIVR to LIVRAISON
go

create role COMMERCIAL -- COMMERCIAL
grant SELECT, INSERT, DELETE, UPDATE on CLIE to COMMERCIAL
grant SELECT, INSERT, DELETE, UPDATE on PROD to COMMERCIAL
grant SELECT, INSERT, DELETE, UPDATE on LIGN to COMMERCIAL
grant SELECT, INSERT, DELETE, UPDATE on COMM to COMMERCIAL
go

create role UTILISATEUR -- CLIENT
grant SELECT on PROD to UTILISATEUR
grant SELECT on LIVR to UTILISATEUR
grant SELECT on FACT to UTILISATEUR
grant SELECT, INSERT, DELETE, UPDATE on CLIE to UTILISATEUR
grant SELECT, INSERT, DELETE, UPDATE on LIGN to UTILISATEUR
go

/****** Création des Utilisateurs ******/
-- Création de l'utilisateur 1 / Service comptabilité
create login VG_log01 with password = 'pwd',
default_database=master,
check_expiration=off,
check_policy=off
go
create user VG_us01 for login VG_log01
go
execute sp_addrolemember 'COMPTABLE','VG_us01'
go

-- Création de l'utilisateur 2 / Service commercial
create login VG_log02 with password = 'pwd',
default_database=master,
check_expiration=off,
check_policy=off
go
create user VG_us02 for login VG_log02
go
execute sp_addrolemember 'COMMERCIAL','VG_us02'
go

-- Création de l'utilisateur 3 / Clientèle
create login VG_log03 with password = 'pwd',
default_database=master,
check_expiration=off,
check_policy=off
go
create user VG_us03 for login VG_log03
go
execute sp_addrolemember 'UTILISATEUR','VG_us03'
go


/****** Alimentation de la base de données ******/
USE VILLAGEGREEN
go
--
--
SET IDENTITY_INSERT FOUR ON
go
INSERT INTO FOUR (fou_id, fou_nom, fou_pre, fou_adr, fou_cp, fou_vil, fou_tel)
	VALUES	(1, 'WOODBRASS', NULL, '13 rue du bois', '13001', 'MARSEILLE', '01 01 01 01 01'),
			(2, 'MUSICBOULEVARD', NULL, '31 boulevard de la musique', '31000', 'TOULOUSE', '02 02 02 02 02'),
			(3, 'Berry', 'Chuck', '35 rue de l''ouest', '35000', 'RENNES', '03 03 03 03 03'), 
			(4, 'Van Halen', 'Eddie', '34 rue de l''est', '34000', 'MONTPELLIER', '04 04 04 04 04'),
			(5, 'Harrison', 'George', '67 rue de l''alsace', '67000', 'STRASBOURG', '05 05 05 05 05')
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
			(3,	'Percussions'),
			(4,	'Vents'),
			(5,	'Violons'),
			(6,	'Micros'),
			(7,	'Casques')
go
SET IDENTITY_INSERT CATE OFF
go
--
--
SET IDENTITY_INSERT SCAT ON
go
INSERT INTO SCAT (ssrub_id, ssrub_nom, rub_id)
	VALUES	(1, 'Basses', 1),
			(2, 'Guitares classiques', 1),
			(3, 'Guitares électriques', 1),
			(4, 'Accordéons', 2),
			(5, 'Pianos', 2),
			(6, 'Claviers', 2),
			(7, 'Batteries acoustiques', 3),
			(8, 'Caisses claires', 3),
			(9, 'Clarinettes', 4),
			(10, 'Harmonicas', 4),
			(11, 'Saxophones', 4),
			(12, 'Archets', 5),
			(13, 'Etuis et Housses', 5),
			(14, 'Violoncelles', 5),
			(15, 'Micros Numériques', 6),
			(16, 'Micros filaires', 6),
			(17, 'Casques DJ', 7),
			(18, 'Casques sans fil', 7)
go
SET IDENTITY_INSERT SCAT OFF
go
--
--
SET IDENTITY_INSERT PROD ON
go
INSERT INTO PROD (pro_id, fou_id, pro_lbc, pro_lbl, pro_pho, ssrub_id)
	VALUES	('182835', '1', 'KALA U-BASS RUMBLER FRETLESS', 'Corps et Manche en Acajou
														Touche et Chevalet en Palissandre
														16 Frettes Nickel/Argent
														Diapason 21" (533,4mm)
														Mécaniques Hipshot noires
														Sillets GraphTech Black Tusq
														Finition naturelle – vernis satiné
														Filets noirs sur la table et le fond
														Cordes KALA Silver Rumbler
														Pré ampli actif Shadow avec les réglages Volume/Tone et accordeur intégré',
														NULL, 1),
			('166187', '1', 'EAGLESTONE LEONA NATURELLE', '- Table : Épicéa
															- Manche : Erable
															- Dos et éclisses : Acajou
															- Touche et Chevalet : Palissandre
															- Sillet manche et Chevalet : Os
															- Diapason : 864 mm
															- Préampli : Fishman ISY-301
															- Finition : Naturelle', 
															NULL, 1),
			('158197', '1', 'LAG OCCITANIA 66 3/4', '-Table : Epicéa Sitka
													-Dos & Eclisses : Acajou
													-Filets : Noir & Ivoire
													-Manche : Acajou / Finition vernis brillant
													-Finition corps et manche : Vernis brillant
													-Tige de réglage : Double sens
													-Touche : Palissandre d''Indonésie
													-Tête : Palissandre d''Indonésie
													-Mécaniques : Noir satiné
													-Chevalet : Palissandre d''Indonésie
													-Cordes : D''Addario
													-Frettes : 18 / Silver-Nickel
													-Diapason : 580mm
													-Sillet de tête : Graphite noir / 48mm
													-Sillet de Chevalet : Plat en graphite noir / 75mm', 
													NULL, 2),
			('156059', '1', 'EAGLESTONE SOLEA 3/4 NOIRE', '- Modèle : 3/4
														- Table d''harmonie : Cèdre
														- Dos et éclisses : Acajou
														- Manche : Nato
														- Sillet de tête : Plastique
														- Binding : Beige multi-plis
														- Touche : Sonokeling
														- Chevalet : Sonokeling
														- Mecaniques : Chromées
														- Cordes : D''Addario EJ45 Pro Arte
														- Finition : Noire' , 
														NULL, 2),
			('126190', '1', 'GRG140 BLACKN BLACK', '- accastillage chromé 
													- corps tilleul 
													- manche GRG en érable 
													- touche palissandre 24 cases 
													- Frettes médium 
													- Vibrato FAT 10 
													- Micros Single Coil STDS (manche et central) + Humbucker STH2 (chevalet)
													- plaque blanche', 
													NULL, 3),
			('216423', '1', 'X MONARKH SCX7 GLOSS BLACK', 'Corps acajou
															Vernis brillant
															Manche érable 1 pièce avec renfort en graphite
															Radius compensé 12" à 16"
															Frettes 22 jumbo
															Sillet1.875" (47.6 mm)
															Mécaniques Jackson bain d''huile à blocage
															Diapason 24.75 (628 mm)
															Chevalet jackson
															Micros Seymour Duncan Nazgu?l en Chevalet et Seymour Duncan Sentient en manche
															Sélecteur 3 positions
															Contrôles 2 volumes, master tonalité
															Accastillage noir
															Cordes 09-52', 
															NULL, 3),
			('213248', '1', 'NOVA III 96 NOIR', 'Qualité du jeu de plaque : Standard
													Touche boutons
													Nombre de boutons : 72
													Rangée de boutons : 5
													Nombres de notes : 44
													Gamme : Chromatique
													Note la plus basse : Mi bémol
													Note la plus haute : Si bémol
													Voix : 3
													Tonalité de couleur : 5
													Nombre de registres : 5
													Basses traditionnelles : 96
													Voix de basses traditionnelles : 4
													Registre des basses traditionnelles : 3
													Dimension (Hauteur x largeur) : 39,4 cm x 20,5 cm
													Poids : 7,6 kg.', 
													NULL, 4),
			('112381', '1', 'GALAAD G/C', 'Type Diatonique
											Touche/Notes 25 sur 2 rangs 1/2 - 12 Main Gauche
											Tonalités Sol, Do
											Basses 12
											Voix 2 Flûtes accordées Américain léger.
											Caisse Bois teinté Noyer - Filet de marquetterie
											Coins de Renfort Métalliques
											Grille Main Droite chromée
											Registres Droit/Gauche Coupure de tierce Main Gauche
											Dimensions 285 x 175 mm
											Poids 3.99 kg', 
											NULL, 4),
			('188088', '2', 'FULLPACK CELVIANO AP-260BK NOIR', '- Source Sonore Multi Dimensionnelle AiR
																- 88 touches dynamiques toucher ivoire et ébène
																- Clavier avec mécanique de marteaux naturels à 3 capteurs II
																- Fonction Concert Play
																- Effet Damper Resonance (Pédale Forte)
																- 18 sonorités améliorées', 
																NULL, 5),
			('210239', '2', 'CELVIANO GP-500 LAQUE NOIR', '- Layer
															- Split
															- Mode duo
															- Fonction de transposition
															- Décalage d’octave
															- 256 notes en polyphonie (max.)
															- Dynamique de frappe
															- Résonance pédale forte
															- Simulateur de couvercle (Lid-Simulation)
															- Brillance
															- Chorus (effet numérique)
															- Effets DSP
															- Concert Play
															- Fonction d''enregistrement audio
															- Métronome
															- Port USB mémoire flash (support de stockage)
															- Écran LCD avec rétro-éclairage
															- Raccordements casques (2x)
															- Raccordement Line-In (L/Mono,R)
															- Raccordement Line-Out (L/Mono, R)
															- Raccordement MIDI (In, Out)',	
															NULL, 5),
			('145479', '2', 'ROLAND A-49 BLACK', '- 49 touches de taille standard, sensibles à la vélocité
													- Léger et compact
													- Facile à utiliser
													- 2 commandes, 2 boutons et un contrôleur D-Beam
													- Alimentation via USB
													- Livré avec le logiciel "Cakewalk SONAR LE"
													- Finitions blanc nacré et noire', 
													NULL, 6),
			('158841', '2', 'SL 990 PRO FATAR', 'Clavier maître toucher lourd gradué 88 notes TP40GH
												4 courbes de vélocité
												Molettes pitch et modulation
												1x port sustain
												1x entrée breath controller
												1x MIDI Out
												Dimensions : 132,8 x 34,9 x 12,5 cm, poids 20 kg', 
												NULL, 6),
			('173197', '2', 'BIRD DS102 BK', '- Fûts en tilleul 6 plis
												- Cerclages et hardware noirs
												- Set d''accessoires complet
												Composition :
												1 Tom 12" x 9"
												1 Tom 13" x 10"
												1 Tom basse 16" x 16" 
												1 caisse claire 14" x 5.5"
												1 Grosse caisse 22" x 16"
												Accessoires : 
												1 Pied de cymbale droit
												1 Pédale de charleston
												1 Pédale de grosse caisse
												1 Stand de caisse claire
												1 paire de cymbales charleston
												1 Cymbale Crash
												1 Siège
												1 Paire de baguettes 5A', 
												NULL, 7),
			('127900', '2', 'TAMA Silverstar', 'Configuration: Sets Rock 
												Grosse caisse: 22" x 18" (sans embase)
												Tom 1: 12" x 9" 
												Tom basse 1: 14" x 12" 
												Tom basse 2: 16" x 14" 
												Caisse claire: 14" x 5,5" 
												Matériau fût: Bouleau 
												Cercles Sound Arc
												Hardware fût: Chrome 
												Couleur: Red Chameleon Sparkle
												Accessoires: Support de tom ', 
												NULL, 7),
			('124778', '2', 'BLADE - 14" x 5"', '- Fût acier 14" x 5"
												- Finition chrome
												- Accastillage chrome
												- 2 x 6 tirants
												- Baguettes 5A
												- Clé de réglage', 
												NULL, 8),
			('124780', '2', 'EDGE 14" x 6.5"', '- Fût cuivre martelé 14" x 6.5"
												- Cerclages moulés
												- 2 x 10 tirants
												- Peau de frappe Remo Ambassador UK
												- Clé de réglage', 
												NULL, 8),
			('143589', '2', 'ROAD CL100', '- Corps en résine
										- Mécanique argentée 
										- Graisse et chiffon d''entretien
										- Cordon
										- Housse de transport
										- Livrée en étui avec bec', 
										NULL, 9),
			('191321', '3', 'YCL650II', '- En Sib
										- Corps en grenadille pour une qualité optimale de son
										- Clés argentées
										- Finition Naturelle
										- Ressorts en acier bleui pour une action douce et précise
										- Pads Pisoni
										- Livrée en étui avec un bec, étui de type "Français"', 
										NULL, 9),
			('186715', '3', 'DIATONIQUE 2013/20 ROCKET 10 TROUS A LA', 'Type : diatonique
																		Réglage : Richter
																		Nombre de trous : 10
																		Lames : 20 Laiton
																		Capot : Acier inoxydable (inox)
																		Jeu de plaques : 0,9 mm / millimètre Laiton
																		Matériau plaque de musique : Laiton
																		Length : 10 cm', 
																		NULL, 10),
			('240899', '3', 'CHROMATIQUE 7582/64 SUPER 64 16 TROUS C DO', '- Sommier en plastique moulé par injection
																			- Plaques en laiton de 1,05 millimètre
																			- Plaques de rechange disponibles
																			- 64 anches Chromonica
																			- Quatre octaves complètes
																			- Capots polis en acier inoxydable
																			- Embouchure chromée avec trous ronds
																			- Disponible en Do majeur', 
																			NULL, 10),
			('164993', '3', 'VINTAGE HIGHWAY', '- FA# aigu
												- Garde sur la clé FA# côté
												- Support de pouce en métal
												- Tampons cuir, résonateurs métal
												- Finition Vintage
												- Livré en étui sac à dos, poche partitions, poche accessoires
												- Avec bec, Ligature et couvre-bec, stick de graisse
												- Cordon rembourré "confort"', 
												NULL, 11),
			('164992', '3', 'DARK HIGHWAY', '- FA# aigu
												- Garde sur la clé FA# côté
												- Support de pouce en métal
												- Tampons cuir, résonateurs métal
												- Finition noire
												- Livré en étui sac à dos, poche partitions, poche accessoires
												- Avec bec, Ligature et couvre-bec, stick de graisse
												- Cordon rembourré "confort"', 
												NULL, 11),
			('138074', '3', 'ASB 3/4', '- 3/4
										- Bois du Brésil
										- Hausse en ébène
										- Crin synthétique', 
										NULL, 12),
			('138075', '4', 'ASB 1/2', '- 1/2
										- Bois du Brésil
										- Hausse en ébène
										- Crin synthétique', 
										NULL, 12),
			('257312', '4', 'ETUI VIOLON CLASSIC MODELE CVK1 4/4', 'Ossature en polyfoam.
																	Housse vissée avec poche partitions noire incorporée.
																	Fonds et éclisses rembourrés.
																	Suspension de l''instrument.
																	2 bretelles sac à dos.
																	1 courroie épaule.
																	Extérieur TEX noir.
																	Intérieur velours gris clair.' , 
																	NULL, 13),
			('124893', '4', 'ETUI VIOLON CLASSIC MODELE CVF2 1/4', 'Ossature en polyfoam
																						Housse vissée avec poche partitions noire incorporée
																						Fond et éclisses rembourrés
																						Suspension de l''instrument
																						2 bretelles sac à dos
																						Poids env.1,2 kg
																						Exterieur Tex noir
																						Intérieur velours gris clair', 
																						NULL, 13),
			('124672', '4', 'ENSEMBLE VIOLONCELLE SET IDEALE 4/4', 'Laque transparente en résine naturelle brun rouge foncé
																	Finition vernis à l''alcool appliqué à la main
																	Entièrement massive
																	Fond flammé
																	Filets
																	Garniture en ébène
																	Chevalet Original Aubert
																	Cordier Wittner avec tendeurs
																	Cordes en acier, pique poirier ébène
																	Colophane
																	Archet crins naturels et hausse en ébène
																	Housse de violoncelle,rembourrage 10 mm,avec poche pour cordes et archet', 
																	NULL, 14),
			('814941', '4', 'SET VIOLONCELLE 3/4 VC5S34', '- Type : Stradivarius, 3/4
															- Table : Epicéa
															- Dos et éclisses : Erable
															- Manche : Erable
															- Touche en ébène
															- Chevalet : Yamaha Original
															- Cheville : Palissandre
															- Cordier : Wittner''Ultra''
															- Cordes : D''Addario Prelude
															- Livré avec archet (bois du Brésil), étui et colophane Piranito', 
															NULL, 14),
			('158777', '4', 'D-01 SINGLE MIC', 'Capteur à gradient de pression 
												Nouvelle capsule K07 à double membrane 
												15 directivités : omni… cardioïde… en huit 
												Filtre passe-haut : Flat/40 Hz/80 Hz/160 Hz 
												Convertisseur A/D 28 bits spécialement développé par Neumann 
												Dynamique >130 dB 
												Fréquences d’échantillonnage de 44,1 à 192 kHz 
												Toutes les fonctions et paramètres sont contrôlables à distance 
												Signal de sortie sur XLR-3 conforme à la norme AES 42
												(audio, statut du microphone, alim fantôme et données de contrôle).', 
												NULL, 15),
			('159151', '4', 'TLM 103 D', '- Conversion AES42 vers EBU
											Alimentation, télécommande et synchronisation des microphones
											sans convertisseur de fréquence d''échantillonnage (AES42, mode 2*)
											Synchronisation automatique par word clock ou AES11
											Toutes les fréquences d''échantillonnage, de 44,1 kHz à 192 kHz
											Contrôle complet et stockage des réglages par Mac ou PC', 
											NULL, 15),
			('163082', '4', 'DM66', 'Microphone dynamique
									Type unidirectionnel à directivité hyper-cardioïde 
									Réponse en fréquences : 50 Hz - 15 kHz 
									Sensibilité -53dB +/-3dB (0dB=1V/Pa à 1KHz) 
									Impédance de sortie 600 Ohms à 1 kHz 
									Très bonne résistance au Larsen 
									Isolation renforcée contre les bruits de manipulation. 
									Grille et corps en métal, sortie XLR mâle 3 broches 
									Finition de surface type gomme anti-glisse
									Livré avec pince nylon incassable
									Livré en pochette de transport avec fermeture éclair', 
									NULL, 16),
			('897316', '5', 'P3S', 'Grille résistante avec écran anti-vent intégré
													Interrupteur on/off intégré
													Corps en métal
													Livré avec sacoche de transport et pince micro
													Gamme de Fréquences : 40 Hz - 20 kHz
													Diagramme Polaire : Cardioïde
													Sensibilité : 2,5 mV/Pa
													Pression Maxi : 144 dB SPL', 
													NULL, 16),
			('150649', '5', 'MPC HP', 'Le son et la qualité de fabrication AKAI Professional
										Transducteurs précis de 50mm à aimants néodymium
										Construction en aluminium massif et acier
										Casque de type fermé avec coussinets en cuir
										Câble audio avec adaptateur Jack 3,5 mm / 6,35 mm
										Câble de communication avec micro inclus', 
										NULL, 17),
			('833472', '5', 'HD215 II', 'Type de casque : Fermé
										Type de transducteur : Dynamique
										Couplage auriculaire : Circum-aural
										Réponse en fréquence : 12 - 22 000 Hz
										Niveau de pression acoustique : 112 dB (SPL)
										Distorsion harmonique totale (DHT) : < 0,2 %
										Impédance nominale : 32 ohms
										Connecteur : Jack 3,5 mm stéréo, plaqué or
										Câble : 3 m / spiralé / détachable
										Poids sans câble : Environ 280 g', 
										NULL, 17),
			('196243', '5', 'SOUNDLINK CASQUE SUPRA-AURICULAIRE BLUETOOTH NOIR', 'Casques supra-auraux SoundLink®
																				Câble audio de 120 cm
																				Câble USB de 33,4 cm
																				Étui de transport', 
																				NULL, 18),
			('126745', '5', 'CASQUE BLUETOOTH - DT201K', 'Système Bluetooth
														Récepteur avec connexion USB
														Câbles et adaptateur jack fournis
														Fonctionne avec 2 piles LR6 AAA (fournies)
														Longue portée
														Etui de rangement', 
														NULL, 18)
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
			(3, 'Beck',	'Jeff')
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
INSERT INTO CLIE (cli_id, sta_id, cli_nom,	cli_pre, cli_adr, cli_cp, cli_vil, cli_tel, fac_adr, fac_cp, fac_vil, liv_adr, liv_cp, liv_vil)
	VALUES	(1, 1, 'Hendrix', 'Jimi', '33 rue de la Gironde', '33000', 'BORDEAUX', '06 06 06 06 06', '34 rue de la Gironde', '33001', 'BORDEAUX', '35 rue de la Gironde', '33002', 'BORDEAUX'),
			(2, 1, 'Clapton', 'Eric', '69 route du Rhone', '69000', 'LYON', '07 07 07 07 07', '70 route du Rhone', '69001', 'LYON', '71 route du Rhone', '69002', 'LYON'),
			(3, 1, 'Page', 'Jimmy', '80 rue de la Somme', '80000', 'AMIENS', '08 08 08 08 08', '81 rue de la Somme', '80001', 'AMIENS', '82 rue de la Somme', '80002', 'AMIENS'),				
			(4, 1, 'Richards', 'Keith', '59 route du Nord', '59000', 'LILLE', '09 09 09 09 09', '60 route du Nord', '59001', 'LILLE', '61 route du Nord', '59002', 'LILLE'),
			(5, 1, 'Beck', 'Jeff', '44 rue de la Loire', '44000', 'NANTES', '11 22 33 44 55', '45 rue de la Loire', '44001', 'NANTES', '46 rue de la Loire', '44002', 'NANTES'),
			(6, 2, 'SONY MUSIC', NULL, '131 av. de Wagram', '75000', 'PARIS', '01 44 40 60 60', '132 av. de Wagram', '75001', 'PARIS', '133 av. de Wagram', '75002', 'PARIS'),	
			(7, 2, 'UNIVERSAL MUSIC', NULL, '22 rue des Fossés St-Jacques', '75200', 'PARIS', '01 44 41 91 91', '23 rue des Fossés St-Jacques', '75201', 'PARIS', '24 rue des Fossés St-Jacques', '75202', 'PARIS')
go
SET IDENTITY_INSERT CLIE OFF
go
--
--
SET IDENTITY_INSERT COMM ON
go
INSERT INTO COMM (com_id, com_eta, com_dat, com_tot, cli_id)
	VALUES	(1, 'Terminé', '12/01/2016', 807.00, 1),
			(2, 'Terminé', '14/01/2016', 1380.00, 1),
			(3, 'Terminé','20/01/2016', 465.00, 1),
			(4, 'Terminé', '21/01/2016', 8044.00, 2),
			(5, 'Terminé', '22/01/2016', 199.00, 2),
			(6, 'Terminé','27/01/2016', 149.95, 2),
			(7, 'Terminé', '29/01/2016', 276.00, 2),
			(8, 'Terminé', '30/01/2016', 3368.00, 3),
			(9, 'Terminé','04/02/2016', 1121.4, 3),
			(10, 'Terminé', '04/02/2016', 1527.00, 4),
			(11, 'Terminé', '05/02/2016', 894.00, 5),
			(12, 'Terminé','09/02/2016', 7998.00, 6),
			(13, 'En cours de livraison','13/02/2016', 2637.00, 6),
			(14, 'En cours de livraison','15/02/2016', 494.00, 7),
			(15, 'En attente de paiement','20/02/2016', 1697.00, 7),
			(16, 'En attente de paiement','22/02/2016', 2800, 7)
go
SET IDENTITY_INSERT COMM OFF
go
--
--
SET IDENTITY_INSERT LIGN ON
go
INSERT INTO LIGN (com_id, com_lig, com_qte, com_pu, pro_id)
	VALUES	(1, 1, 3, 85.00, '182835'),
			(1, 2, 3, 184.00, '166187'),
			(2, 3, 20, 69.00, '833472'),
			(3, 4, 1, 465.00, '216423'),
			(4, 5, 10, 369.00, '158841'),
			(4, 6, 2, 879.00, '210239'),
			(4, 7, 4, 649.00, '164993'),
			(5, 8, 1, 199.00, '173197'),
			(6, 9, 5, 29.99, '163082'),
			(7, 10, 4, 69.00, '833472'),
			(8, 11, 2, 69.00, '257312'),
			(8, 12, 2, 1615.00, '124672'),
			(9, 13, 1, 12.90, '138074'),
			(9, 14, 1, 9.50, '138075'),
			(9, 15, 1, 1099.00, '814941'),
			(10, 16, 1, 789.00, '127900'),
			(10, 17, 2, 369.00, '158841'),
			(11, 18, 6, 149.00, '145479'),
			(12, 19, 2, 3999.00, '210239'),
			(13, 20, 3, 879.00, '188088'),
			(14, 21, 2, 247.00, '240899'),
			(15, 22, 3, 59.00, '124778'),
			(15, 23, 3, 175.00, '124780'),
			(15, 24, 5, 199.00, '143589'),
			(16, 25, 2, 1400.00, '112381')
go
SET IDENTITY_INSERT LIGN OFF
go
--
--
SET IDENTITY_INSERT LIVR ON
go
INSERT INTO LIVR (liv_id, liv_exp, liv_rec, com_id)
	VALUES	(1, '12/01/2016', '14/01/2016', 1),
			(2, '12/01/2016', '14/01/2016', 1),
			(3, '14/01/2016', '20/01/2016', 2),
			(4, '14/01/2016', '20/01/2016', 2),
			(5, '20/01/2016', '21/01/2016', 3),
			(6, '21/01/2016', '22/01/2016', 4),
			(7, '21/01/2016', '22/01/2016', 4),
			(8, '21/01/2016', '22/01/2016', 4),
			(9, '22/01/2016', '27/01/2016', 5),
			(10, '27/01/2016', '29/01/2016', 6),
			(11, '29/01/2016', '30/01/2016', 7),
			(12, '30/01/2016', '04/02/2016', 8),
			(13, '04/02/2016', '09/02/2016', 9),
			(14, '04/02/2016', '09/02/2016', 10),
			(15, '05/02/2016', '09/02/2016', 11),
			(16, '09/02/2016', '13/02/2016', 12),
			(17, '13/02/2016', null, 13),
			(18, '15/02/2016', null, 14)
go
SET IDENTITY_INSERT LIVR OFF
go
--
--
INSERT INTO COLI (liv_qte, pro_id, liv_id)
	VALUES	(3, '182835', 1),
			(3, '166187', 2),
			(15, '833472', 3),
			(5, '833472', 4),
			(1, '216423', 5),
			(10, '158841', 6),
			(2, '210239', 7),
			(4, '164993', 8),
			(1, '173197', 9),
			(5, '163082', 10),
			(4, '833472', 11),
			(2, '257312', 12),
			(2, '124672', 12),
			(1, '138074', 13),
			(1, '138075', 13),
			(1, '814941', 13),
			(1, '127900', 14),
			(2, '158841', 14),
			(6, '145479', 15),
			(2, '210239', 16),
			(3, '188088', 17),
			(2, '240899', 18)
go
--
--
SET IDENTITY_INSERT FACT ON
go
INSERT INTO FACT (fac_id, fac_dat, fac_red, fac_tot, com_id)
	VALUES	(1, '12/01/2016', null, 1049.10, 1),
			(2, '14/01/2016', null, 1794.00, 2),
			(3, '20/01/2016', null, 604.50, 3),
			(4, '21/01/2016', 200, 10257.20, 4),
			(5, '22/01/2016', null, 258.70, 5),
			(6, '27/01/2016', 30, 164.93, 6),
			(7, '29/01/2016', 75, 822.00, 7),
			(8, '30/01/2016', null, 4378.40, 8),
			(9, '04/02/2016', null, 1457.82, 9),
			(10, '04/02/2016', 150, 1835.10, 10),
			(11, '05/02/2016', 200, 962.20, 11),
			(12, '09/02/2016', 600, 8197.80, 12),
			(13, '13/02/2016', null, 2900.70, 13),
			(14, '15/02/2016', 30, 513.40, 14),
			(15, '20/02/2016', 60, 1806.70, 15),
			(16, '22/02/2016', null, 3080.00, 16)
go
SET IDENTITY_INSERT FACT OFF
go
--
--
SET IDENTITY_INSERT REGL ON
go
INSERT INTO REGL (reg_id, reg_dat, reg_tot, fac_id)
	VALUES	(1, '12/01/2016', 1049.10, 1),
			(2, '14/01/2016', 1794.00, 2),
			(3,'20/01/2016', 604.50, 3),
			(4, '21/01/2016', 10257.20, 4),
			(5, '22/01/2016', 258.70, 5),
			(6, '27/01/2016', 164.93, 6),
			(7,  '29/01/2016', 822.00, 7),
			(8, '30/01/2016', 4378.40, 8),
			(9, '04/02/2016', 1457.82, 9),
			(10, '04/02/2016', 1835.10, 10),
			(11, '05/02/2016', 962.20, 11),
			(12, '09/02/2016', 8197.80, 12),
			(13, '13/02/2016', 2900.70, 13),
			(14, '15/02/2016', 513.40, 14)
go
SET IDENTITY_INSERT REGL OFF
go

/*** Affichage des tables ***/
USE VILLAGEGREEN
select * from FOUR
select * from PROD
select * from SCAT
select * from CATE
select * from LIGN
select * from COMM
select * from LIVR
select * from COLI
select * from CLIE
select * from FACT
select * from REGL
select * from SERC
