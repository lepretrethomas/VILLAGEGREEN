--LEPRETRE THOMAS - FORMATION DEVELOPPEUR LOGICIEL AFPA AMIENS

/*************************************************************
******************** FIL ROUGE *******************************
*************************************************************/

----- Création de la base de donnees Village Green
CREATE DATABASE VILLAGEGREEN
go

USE VILLAGEGREEN
go

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
	sta_id 				INT NOT NULL,
	cli_nom      		VARCHAR(50) NOT NULL,
	cli_pre  			VARCHAR(25),
	cli_adr  			VARCHAR(100) NOT NULL,
	cli_cp       		int check (cli_cp like '[0-9][0-9][0-9][0-9][0-9]') NOT NULL,
	cli_vil    			VARCHAR(100) NOT NULL,
	cli_tel      		VARCHAR(15) NOT NULL,
	fac_adr   			VARCHAR(100) NOT NULL,
	fac_cp        		int check (fac_cp like '[0-9][0-9][0-9][0-9][0-9]') NOT NULL,
	fac_vil    			VARCHAR(100) NOT NULL,
	liv_adr 			VARCHAR(100) NOT NULL,
	liv_cp      		int check (liv_cp like '[0-9][0-9][0-9][0-9][0-9]') NOT NULL,
	liv_vil   			VARCHAR(100) NOT NULL,
	PRIMARY KEY (cli_id)
)

----- Table: FOURNISSEURS
CREATE TABLE FOUR (
	fou_id    			INT IDENTITY NOT NULL,
	fou_nom     		VARCHAR(50) NOT NULL,
	fou_pre 			VARCHAR(25),
	fou_adr 			VARCHAR(100) NOT NULL,
	fou_cp      		int check (fou_cp like '[0-9][0-9][0-9][0-9][0-9]') NOT NULL,
	fou_vil   			VARCHAR(100) NOT NULL,
	fou_tel     		VARCHAR(15) NOT NULL,
	PRIMARY KEY (fou_id)
)

----- Table: PRODUITS
CREATE TABLE PROD (
	pro_id        		INT IDENTITY NOT NULL,
	fou_id				INT NOT NULL,
	pro_lib  			VARCHAR(50) NOT NULL,
	pro_des   			VARCHAR(704),
	pro_pu				numeric (10,2) NOT NULL,
	pro_aff				bit NOT NULL,
	pro_pho      		VARCHAR(50),
	ru2_id        		INT,
	PRIMARY KEY (pro_id)
)

----- Table: COMMANDES
CREATE TABLE COMM (
	com_id  			INT IDENTITY NOT NULL,
	com_dat 			DATE DEFAULT GETDATE() NOT NULL,
	com_eta 			VARCHAR(25) NOT NULL,
	com_tot				numeric (10,2) NOT NULL,
	cli_id  			INT NOT NULL,
	PRIMARY KEY (com_id)
)

----- Table: FACTURATIONS
CREATE TABLE FACT (
	fac_id       		INT IDENTITY NOT NULL,
	com_id       		INT NOT NULL,
	fac_dat      		DATE DEFAULT GETDATE() NOT NULL,
	fac_red				numeric (10,2),
	fac_tot   			numeric (10,2) NOT NULL,
	PRIMARY KEY (fac_id)
)

----- Table: REGLEMENTS
CREATE TABLE REGL (
	reg_id     			INT IDENTITY NOT NULL,
	fac_id           	INT NOT NULL,
	reg_dat   			DATE DEFAULT GETDATE() NOT NULL,
	reg_tot 			numeric (10,2) NOT NULL,
	PRIMARY KEY (reg_id)
)

----- Table: LIGNES DE COMMANDE
CREATE TABLE LIGN (
	lig_id 			INT IDENTITY NOT NULL,
	lig_qte   			INT NOT NULL,
	lig_pu    			numeric (10,2) NOT NULL,
	com_id   			INT NOT NULL,
	pro_id  			INT NOT NULL,
	PRIMARY KEY (lig_id)
)

----- Table: LIVRAISONS
CREATE TABLE LIVR (
	liv_id     			INT IDENTITY NOT NULL,
	com_id     			INT NOT NULL,
	liv_exp     		DATE NOT NULL,
	liv_rec     		DATE,
	PRIMARY KEY (liv_id)
)

----- Table: COLIS
CREATE TABLE COLI (
	liv_id  			INT NOT NULL,
	liv_qte  			INT NOT NULL,
	pro_id 				INT NOT NULL,
	PRIMARY KEY (pro_id, liv_id)
)

----- Table: CATEGORIES
CREATE TABLE RUB1 (
	ru1_id  			INT IDENTITY NOT NULL,
	ru1_nom 			VARCHAR(25),
	PRIMARY KEY (ru1_id)
)

----- Table: SOUS-CATEGORIES
CREATE TABLE RUB2 (
	ru2_id  			INT IDENTITY NOT NULL,
	ru2_nom 			VARCHAR(25),
	ru1_id    			INT NOT NULL,
	PRIMARY KEY (ru2_id)
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
		FOREIGN KEY (ru2_id) REFERENCES RUB2(ru2_id),
		FOREIGN KEY (fou_id) REFERENCES FOUR(fou_id)

----- Contrainte: SousCatégories
ALTER TABLE RUB2
	ADD
		FOREIGN KEY (ru1_id) REFERENCES RUB1(ru1_id)

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
		FOREIGN KEY (com_id) REFERENCES COMM(com_id)

----- Contrainte: Règlements
ALTER TABLE REGL
	ADD
		FOREIGN KEY (fac_id) REFERENCES FACT(fac_id)

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

----- Index sur les noms Fournisseurs
create nonclustered index ix_fournis on FOUR(fou_nom)

----- Index sur les libellés Produits
create nonclustered index ix_produit on PROD(pro_lib)

---- Index sur les villes Clients
create nonclustered index ix_vilcli on CLIE(cli_vil)

---- Index sur les villes Fournisseurs
create nonclustered index ix_vilfou on FOUR(fou_vil)

---- Index sur les villes Livraisons
create nonclustered index ix_villiv on CLIE(liv_vil)

go

/****** Alimentation de la base de données ******/
--
--
SET IDENTITY_INSERT FOUR ON
go
INSERT INTO FOUR (fou_id, fou_nom, fou_pre, fou_adr, fou_cp, fou_vil, fou_tel)
	VALUES	(1, 'WOODBRASS', NULL, '13 rue du bois', '13001', 'MARSEILLE', '0101010101'),
			(2, 'MUSICBOULEVARD', NULL, '31 boulevard de la musique', '31000', 'TOULOUSE', '0202020202'),
			(3, 'Berry', 'Chuck', '35 rue de l''ouest', '35000', 'RENNES', '0303030303'), 
			(4, 'Van Halen', 'Eddie', '34 rue de l''est', '34000', 'MONTPELLIER', '0404040404'),
			(5, 'Harrison', 'George', '67 rue de l''alsace', '67000', 'STRASBOURG', '0505050505'),
			(6, 'Beck', 'Jeff', '59 rue du nord', '59000', 'LILLE', '0606060606')

go
SET IDENTITY_INSERT FOUR OFF
go
--
--
SET IDENTITY_INSERT RUB1 ON
go
INSERT INTO RUB1 (ru1_id, ru1_nom)
	VALUES	(1, 'Guitares'),
			(2,	'Claviers'),
			(3,	'Percussions'),
			(4,	'Vents'),
			(5,	'Cordes')
go
SET IDENTITY_INSERT RUB1 OFF
go
--
--
SET IDENTITY_INSERT RUB2 ON
go
INSERT INTO RUB2 (ru2_id, ru2_nom, ru1_id)
	VALUES	(1, 'Basses', 1),
			(2, 'Guitares classiques', 1),
			(3, 'Guitares électriques', 1),
			(4, 'Banjos', 1),
			(5, 'Pianos', 2),
			(6, 'Claviers', 2),
			(7, 'Batteries acoustiques', 3),
			(8, 'Timbales', 3),
			(9, 'Tambourins', 3),
			(10, 'Bongos', 3),
			(11, 'Congas', 3),
			(12, 'Tambours', 3),
			(13, 'Maracas', 3),
			(14, 'Triangles', 3),
			(15, 'Xylophones', 3),
			(16, 'Accordéons', 4),
			(17, 'Flûtes', 4),
			(18, 'Flûtes de pan', 4),
			(19, 'Trombones', 4),
			(20, 'Trompes', 4),
			(21, 'Saxophones', 4),
			(22, 'Trompettes', 5),
			(23, 'Violoncelles', 5),
			(24, 'Violons', 5),
			(25, 'Harpes', 5)
go
SET IDENTITY_INSERT RUB2 OFF
go
--
--
SET IDENTITY_INSERT PROD ON
go
INSERT INTO PROD (pro_id, fou_id, pro_lib, pro_des, pro_pu, pro_aff, pro_pho, ru2_id)
	VALUES	('182835', '1', 'KALA U-BASS',
'-Corps et Manche en Acajou
-Touche et Chevalet en Palissandre
-16 Frettes Nickel/ArgentDiapason 21" (533,4mm)
-Mécaniques Hipshot noires
-Sillets GraphTech Black Tusq
-Finition naturelle – vernis satiné
-Filets noirs sur la table et le fond
-Cordes KALA Silver Rumbler
-Pré ampli actif Shadow avec les réglages Volume/Tone et accordeur intégré', 408.29, 1, NULL, 1),
			('166187', '1', 'EAGLESTONE LEONA',
'-Table : Épicéa
-Manche : Erable
-Dos et éclisses : Acajou
-Touche et Chevalet : Palissandre
-Sillet manche et Chevalet : Os
-Diapason : 864 mm
-Préampli : Fishman ISY-301
-Finition : Naturelle', 199.00, 1, NULL, 1),
			('158197', '1', 'LAG OCCITANIA 66',
'-Table : Epicéa Sitka
-Dos & Eclisses : Acajou
-Filets : Noir & Ivoire
-Corps et Manche : Acajou / Finition vernis brillant
-Tige de réglage : Double sens
-Touche - Tête - Chevalet: Palissandre d''Indonésie
-Mécaniques : Noir satiné
-Cordes : D''Addario
-Frettes : 18 / Silver-Nickel', 159.00, 1, NULL, 2),
			('156059', '1', 'EAGLESTONE SOLEA',
'-Modèle : 3/4
-Table d''harmonie : Cèdre
-Dos et éclisses : Acajou
-Manche : Nato
-Sillet de tête : Plastique
-Binding : Beige multi-plis
-Touche et Chevalet : Sonokeling
-Mecaniques : Chromées
-Cordes : D''Addario EJ45 Pro Arte
-Finition : Noire' , 85.00, 1, NULL, 2),
			('126190', '1', 'GRG140',
'-Accastillage chromé 
-Corps tilleul 
-Manche GRG en érable 
-Touche palissandre 24 cases 
-Frettes médium 
-Vibrato FAT 10 
-Micros Single Coil STDS (manche et central) + Humbucker STH2 (chevalet)
-Plaque blanche', 184.00, 1, NULL, 3),
			('216423', '1', 'X MONARKH SCX7',
'-Corps acajou
-Manche érable 1 pièce avec renfort en graphite
-Radius compensé 12" à 16"
-Frettes 22 jumbo
-Sillet 1.875" (47.6 mm)
-Mécaniques Jackson bain d''huile à blocage
-Diapason 24.75 (628 mm)
-Chevalet jackson
-Micros Seymour Duncan Nazgu?l en Chevalet et Seymour Duncan Sentient en manche
-Sélecteur 3 positions', 465.00, 1, NULL, 3),
			('213248', '1', 'NOVA III 96',
'-Qualité du jeu de plaque : Standard
-Nombre de boutons : 72 sur 5 rangées
-Nombres de notes : 44 (la plus basse : Mi bémol, la plus haute : Si bémol)
-Gamme : Chromatique
-Tonalité de couleur : 5
-Nombre de registres : 5
-Basses traditionnelles : 96
-Voix de basses traditionnelles : 4
-Registre des basses traditionnelles : 3
-Dimension (Hauteur x largeur) : 39,4 cm x 20,5 cm
-Poids : 7,6 kg.', 2039.00, 1, NULL, 16),
			('112381', '1', 'GALAAD G/C',
'-Type Diatonique
-Touche/Notes 25 sur 2 rangs 1/2 - 12 Main Gauche
-Tonalités Sol, Do
-Basses 12
-Voix 2 Flûtes accordées Américain léger.
-Caisse Bois teinté Noyer - Filet de marquetterie
-Coins de Renfort Métalliques
-Grille Main Droite chromée
-Registres Droit/Gauche Coupure de tierce Main Gauche
-Dimensions 285 x 175 mm - Poids 3.99 kg', 1400.00, 1, NULL, 16),
			('188088', '2', 'FULLPACK CELVIANO AP-260BK',
'-Source Sonore Multi Dimensionnelle AiR
-88 touches dynamiques toucher ivoire et ébène
-Clavier avec mécanique de marteaux naturels à 3 capteurs II
-Fonction Concert Play
-Effet Damper Resonance (Pédale Forte)
-18 sonorités améliorées', 879.00, 1, NULL, 5),
			('210239', '2', 'CELVIANO GP-500',
'-Layer - Split - Mode duo
-Fonction de transposition
-Décalage d’octave
-256 notes en polyphonie (max.)
-Résonance pédale forte
-Simulateur de couvercle (Lid-Simulation)
-Chorus (effet numérique)
-Fonction d''enregistrement audio
-Port USB mémoire flash (support de stockage)
-Écran LCD avec rétro-éclairage',	3999.00, 1, NULL, 5),
			('145479', '2', 'ROLAND A-49',
'-49 touches de taille standard, sensibles à la vélocité
-Léger et compact
-Facile à utiliser
-2 commandes, 2 boutons et un contrôleur D-Beam
-Alimentation via USB
-Livré avec le logiciel "Cakewalk SONAR LE"
-Finitions blanc nacré et noire', 149.00, 1, NULL, 6),
			('158841', '2', 'SL 990 PRO FATAR',
'-Clavier maître toucher lourd gradué 88 notes TP40GH
-4 courbes de vélocité
-Molettes pitch et modulation
-1x port sustain
-1x entrée breath controller
-1x MIDI Out
-Dimensions : 132,8 x 34,9 x 12,5 cm, poids 20 kg', 369.00, 1, NULL, 6),
			('173197', '2', 'BIRD DS102 BK',
'-Fûts en tilleul 6 plis
-Cerclages et hardware noirs
-Set d''accessoires complet
-Composition : -1 Tom 12" x 9" -1 Tom 13" x 10" -1 Tom basse 16" x 16" -1 caisse claire 14" x 5.5" -1 Grosse caisse 22" x 16"
-Accessoires : -1 Pied de cymbale droit -1 Pédale de charleston -1 Pédale de grosse caisse -1 Stand de caisse claire -1 paire de cymbales charleston -1 Cymbale Crash -1 Siège -1 Paire de baguettes 5A', 199.00, 1, NULL, 7),
			('127900', '2', 'TAMA Silverstar',
'-Configuration: Sets Rock 
-Grosse caisse: 22" x 18" (sans embase)
-Tom 1: 12" x 9" -Tom basse 1: 14" x 12" -Tom basse 2: 16" x 14" 
-Caisse claire: 14" x 5,5" 
-Matériau fût: Bouleau 
-Cercles Sound Arc
-Hardware fût: Chrome 
-Couleur: Red Chameleon Sparkle
-Accessoires: Support de tom ', 789.00, 1, NULL, 7),
			('124778', '2', 'BLADE - 14" x 5"',
'-Fût acier 14" x 5"
-Finition chrome
-Accastillage chrome
-2 x 6 tirants
-Baguettes 5A
-Clé de réglage', 59.00, 1, NULL, 8),
			('124780', '2', 'EDGE 14" x 6.5"',
'-Fût cuivre martelé 14" x 6.5"
-Cerclages moulés
-2 x 10 tirants
-Peau de frappe Remo Ambassador UK
-Clé de réglage', 175.00, 1, NULL, 12),
			('143589', '2', 'MC890NT Conga Set',
'-Set de congas 10"+11"
-En bois
-Finition: Vernis
-Couleur: Naturel/ambre
-2 supports simples incl.
-Housses Millenium optionnelles non-fournies
', 199.00, 1, NULL, 11),
			('186715', '3', 'BALSERO BK',
'-Fûts 6.5" & 7.5" en bouleau sélectionné
-Cerclages traditionnels
-Clé de réglage
-Finition laquée noire
', 44.60, 1, NULL, 10),
			('164993', '3', 'VINTAGE HIGHWAY',
'-FA# aigu
-Garde sur la clé FA# côté
-Support de pouce en métal
-Tampons cuir, résonateurs métal
-Finition Vintage
-Livré en étui sac à dos, poche partitions, poche accessoires
-Avec bec, Ligature et couvre-bec, stick de graisse
-Cordon rembourré "confort"', 649.00, 1, NULL, 21),
			('164992', '3', 'DARK HIGHWAY',
'-FA# aigu
-Garde sur la clé FA# côté
-Support de pouce en métal
-Tampons cuir, résonateurs métal
-Finition noire
-Livré en étui sac à dos, poche partitions, poche accessoires
-Avec bec, Ligature et couvre-bec, stick de graisse
-Cordon rembourré "confort"', 699.00, 1, NULL, 21),
('138075', '4', 'DG30',
'-En bois
-Lames en métal
-Diatonique
-De Do3 à Do4
-1 couleur par note pour bien repérer la gamme
-Livré avec 1 mailloche', 9.50, 1, NULL, 15),
			('124672', '4', 'SET VIOLONCELLE IDEALE',
'-Laque transparente en résine naturelle brun rouge foncé
-Finition vernis à l''alcool appliqué à la main
-Fond flammé
-Garniture en ébène
-Chevalet Original Aubert
-Cordier Wittner avec tendeurs
-Cordes en acier, pique poirier ébène
-Archet crins naturels et hausse en ébène
-Housse de violoncelle,rembourrage 10 mm,avec poche pour cordes et archet', 1615.00, 1, NULL, 23),
			('814941', '4', 'SET VIOLONCELLE VC5S34',
'-Type : Stradivarius, 3/4
-Table : Epicéa
-Manche, Dos et éclisses : Erable
-Touche en ébène
-Chevalet : Yamaha Original
-Cheville : Palissandre
-Cordier : Wittner''Ultra''
-Cordes : D''Addario Prelude
-Livré avec archet (bois du Brésil), étui et colophane Piranito', 1099.00, 1, NULL, 23),
			('159151', '4', 'YSL610',
'-Coulisse extérieur cuivre jaune
-Coulisse interne en maillechort
-Pavillon cuivre jaune
-Qualité sonoreRiche, chaude et ample
-Grande souplesse et confort de jeu
-Homogénéité et équilibre
-Finition : verni', 1679.00, 1, NULL, 19),
			('150649', '5', 'RIMINI 4/4',
'-Table : Épicéa
-Fond, éclisses, manche et tête : Érable
-Touche : Ébène
-Chevilles : Ébène
-Cordier : Ébène
-Verni à la main
-Livré en étui avec archet et colophane', 149.00, 1, NULL, 24),
			('196243', '5', 'SILVER DREAM',
'- Sib
- Finition argentée
- Pistons vernis
- Perce : 11,60 mm
- Pavillon 120 mm
- Piston Monel
- Livrée en étui solide et compact avec une embouchure', 249.00, 1, NULL, 22),
			('240899', '3', 'TROMPE DE CHASSE EN RE',
'-Ré Laiton 4/10ème résistant, enroulement 3 tours 1/2 (diamètre 35cm). 
-Branche d''embouchure étirée conique et fixe. 
-Pavillon noirci 27cm. 
-En étui', 247.00, 1, NULL, 20),
			('138074', '3','FLUTE A BEC SOPRANO 303AI',
'-Doigté baroque, double trou, trois parties
-Finition ivoire
-Livrée avec housse et ecouvillon', 12.90, 1, NULL, 12),
			('158777', '4','Salvi Titan Lever Harp',
'-Cordes en boyau/soie
-Hauteur : 150 cm
-Largeur: 78 cm
-Poids: 12,5 kg
-Tessiture: Do première octave à La sixième octave
-Livrée avec housse de thomann protection et clé d''accordage
-Couleur: acajou', 4789.00, 1, NULL, 25),
			('163082', '4','Thomann Leather Maracas',
'-Peau naturelle
-Manches en bois
-Longueur: 300 mm
-Diamètre: 90 mm', 29.90, 1, NULL, 13),
			('126745', '5', 'LP M257',
'-Diamètre: 14" et 15"
-Série Matador
-Fûts en acier
-Hauteur: 16,5 mm
-Finition: Chrome
-Pied, cloche, clé d''accordage et paire de baguettes incl.', 221.50, 1, NULL, 8),
			('257312', '4', 'Studio 49 TI 3',
'-Fabriqué à la main
-En acier
-Epaisseur: 10 - 14mm
-Diamètre: 20cm
-Batte TS 04 incl.', 69.00, 1, NULL, 14),
			('833472', '5','Solist Panpipes Alto',
'-Tonalité: Sol majeur
-Tessiture: Sol1 - Do3
-18 tuyaux en érable
-Forme incurvée
-Fabriquée à la main', 69.00, 1, NULL, 18),
			('191321', '3', 'Eagle II 5-string',
'Manche en érable/acajou
Touche ébène
Anneau de tonalité Deering 22 trous
Corps 3 pièces en érable thomann catégorie violon
Cordier True Tone Deering
Cercle de tension Deering en laiton
24 crochets ronds
Chevalet en érable/ébène' , 1279.00, 1, NULL, 4),
			('897316', '5','Buffalo Drum 14"x3,5"',
'-Dimensions: 14" x 3,5"
-Traverses en cordes croisées
-Cadre en acousticon
-Maillet incl.', 44.00, 1, NULL, 12),
			('124893', '4','TSKJ-6BK',
'-Tambourin accordable
-Tige de percussion de 9,5 mm (3/8")
-Se joue à la main ou avec une baguette
-Complète à merveille toute batterie ou tout ensemble de percussions
-Peut s’emporter partout grâce à sa petite taille
-Peau synthétique', 37.80, 1, NULL, 9)
go
SET IDENTITY_INSERT PROD OFF
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
	VALUES	(1, 1, 'Hendrix', 'Jimi', '33 rue de la Gironde', '33000', 'BORDEAUX', '0606060606', '34 rue de la Gironde', '33001', 'BORDEAUX', '35 rue de la Gironde', '33002', 'BORDEAUX'),
			(2, 1, 'Clapton', 'Eric', '69 route du Rhone', '69000', 'LYON', '0707070707', '70 route du Rhone', '69001', 'LYON', '71 route du Rhone', '69002', 'LYON'),
			(3, 1, 'Page', 'Jimmy', '80 rue de la Somme', '80000', 'AMIENS', '0808080808', '81 rue de la Somme', '80001', 'AMIENS', '82 rue de la Somme', '80002', 'AMIENS'),				
			(4, 1, 'Richards', 'Keith', '59 route du Nord', '59000', 'LILLE', '0909090909', '60 route du Nord', '59001', 'LILLE', '61 route du Nord', '59002', 'LILLE'),
			(5, 1, 'Beck', 'Jeff', '44 rue de la Loire', '44000', 'NANTES', '1122334455', '45 rue de la Loire', '44001', 'NANTES', '46 rue de la Loire', '44002', 'NANTES'),
			(6, 2, 'SONY MUSIC', NULL, '131 av. de Wagram', '75000', 'PARIS', '0144406060', '132 av. de Wagram', '75001', 'PARIS', '133 av. de Wagram', '75002', 'PARIS'),	
			(7, 2, 'UNIVERSAL MUSIC', NULL, '22 rue des Fossés St-Jacques', '75200', 'PARIS', '0144419191', '23 rue des Fossés St-Jacques', '75201', 'PARIS', '24 rue des Fossés St-Jacques', '75202', 'PARIS'),
			(8, 1, 'Reed', 'Lou', '45 rue de l''Auvergne', '63000', 'CLERMONT-FERRAND', '1010101010', '45 rue de l''Auvergne', '63000', 'CLERMONT-FERRAND', '45 rue de l''Auvergne', '63000', 'CLERMONT-FERRAND')

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
INSERT INTO LIGN (com_id, lig_id, lig_qte, lig_pu, pro_id)
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

/****** Accès aux données VillageGreen ******/

/****** Formaliser des requêtes à l'aide du langage SQL ******/
-- Certaines interrogations sont à prévoir:

-- Chiffre d'affaire généré pour l'ensemble et par fournisseur
create view CA_All_Fournisseur
	as
select sum(lig_qte*lig_pu) as 'CA'
	from LIGN
go

create view CA_Fournisseur
	as
select FOUR.fou_id as 'FOURNISSEUR', sum(LIGN.lig_qte*LIGN.lig_pu) as 'CA'
	from FOUR
		join PROD
		on PROD.fou_id=FOUR.fou_id
			join LIGN
			on LIGN.pro_id=PROD.pro_id
				group by FOUR.fou_id
go

-- Liste des produits commandés (ref produit, qte commandé)
create view Prod_Comm
	as
select pro_id as 'Référence produit', sum(lig_qte) as 'Quantité commandée' from LIGN
	group by pro_id
go

-- Liste des commandes pour un client (date, ref client, montant)
create proc COMCLI
	@client varchar(50)
	as
select COMM.com_id, COMM.com_dat, CLIE.cli_id, FACT.fac_tot
	from COMM
		join CLIE
		on CLIE.cli_id=COMM.cli_id
			join FACT
			on FACT.com_id=COMM.com_id
				where CLIE.cli_nom=@client
go
--exec comcli 'Page'
--exec comcli 'UNIVERSAL MUSIC'

-- Répartition du chiffre d'affaire par type de client
create view CA_Cat_Client
	as
select sta_nom as 'CATEGORIE', sum((lig_qte*lig_pu)*STAT.sta_coe) as 'CA'
	from LIGN
		join COMM
		on LIGN.com_id=COMM.com_id
			join CLIE
			on CLIE.cli_id=COMM.cli_id
				join STAT
				on CLIE.sta_id=STAT.sta_id
					group by sta_nom
go

create view CA_All_Client
	as
select sum((lig_qte*lig_pu)*STAT.sta_coe) as 'CA'
	from LIGN
		join COMM
		on LIGN.com_id=COMM.com_id
			join CLIE
			on CLIE.cli_id=COMM.cli_id
				join STAT
				on CLIE.sta_id=STAT.sta_id
go


-- Lister les commandes en cours de livraison.
create view Comm_Livr1
	as
select COMM.com_id, com_dat, com_eta, liv_id, cli_id, liv_exp, liv_rec from COMM, LIVR
	where (exists (select * where LIVR.com_id=COMM.com_id and LIVR.liv_exp is not null)
	and LIVR.liv_rec is null)
go

--ou

create view Comm_Livr2
	as
select * from COMM
	where COMM.com_eta='En cours de livraison'
go

/****** Programmer des procédures stockées sur le SGBD ******/
-- Créez une procédure stockée qui sélectionne les commandes non soldées (en cours
-- de livraison)
create proc COMSOLD1
as
select * from COMM, LIVR
	where (exists (select * where LIVR.com_id=COMM.com_id and LIVR.liv_exp is not null)
	and LIVR.liv_rec is null)
go

create proc COMSOLD2
as
select * from COMM
	where COMM.com_eta='En cours de livraison'
go

--exec COMSOLDES1
--exec COMSOLDES2

-- Puis une autre qui renvoie le délai moyen entre la date de commande
-- et la date de facturation.
create proc DELAI_COMFAC
as
	select avg (datediff (day, COMM.com_dat, FACT.fac_dat)) as 'Délai moyen entre la date de commande et la date de facturation'
		from COMM
			join FACT on FACT.com_id=COMM.com_id
			where FACT.fac_dat is not null
go

--exec DELAI_COMFAC

/****** Gérer les vues ******/
-- Créez une vue correspondant à la jointure Produits - Fournisseurs :
create view Prod_Four
as
select PROD.pro_id, PROD.pro_lib, FOUR.fou_id, fou_nom
	from PROD
		join FOUR
		on FOUR.fou_id=PROD.fou_id
go
