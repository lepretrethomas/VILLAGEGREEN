#LEPRETRE THOMAS - FORMATION DEVELOPPEUR LOGICIEL AFPA AMIENS

/*************************************************************
******************** FIL ROUGE *******************************
*************************************************************/

#Création de la base de donnees Village Green
CREATE DATABASE VILLAGEGREEN
;
USE VILLAGEGREEN
;
#Table: STATUT
CREATE TABLE STAT (
	sta_id     			INT auto_increment NOT NULL,
	sta_nom      		VARCHAR(50) NOT NULL,
	sta_coe				numeric (3,2) NOT NULL,
	PRIMARY KEY (sta_id)
)
;
#Table: CLIENTS
CREATE TABLE CLIE (
	cli_id     			INT auto_increment NOT NULL,
	sta_id 				INT NOT NULL,
	cli_nom      		VARCHAR(50) NOT NULL,
	cli_pre  			VARCHAR(25),
	cli_adr  			VARCHAR(100) NOT NULL,
	cli_cp       		VARCHAR(5) NOT NULL,
	cli_vil    			VARCHAR(100) NOT NULL,
	cli_tel      		VARCHAR(15) NOT NULL,
	fac_adr   			VARCHAR(100) NOT NULL,
	fac_cp        		VARCHAR(5) NOT NULL,
	fac_vil    			VARCHAR(100) NOT NULL,
	liv_adr 			VARCHAR(100) NOT NULL,
	liv_cp      		VARCHAR(5) NOT NULL,
	liv_vil   			VARCHAR(100) NOT NULL,
	PRIMARY KEY (cli_id)
)
;
#Table: FOURNISSEURS
CREATE TABLE FOUR (
	fou_id    			INT auto_increment NOT NULL,
	fou_nom     		VARCHAR(50) NOT NULL,
	fou_pre 			VARCHAR(25),
	fou_adr 			VARCHAR(100) NOT NULL,
	fou_cp      		VARCHAR(5) NOT NULL,
	fou_vil   			VARCHAR(100) NOT NULL,
	fou_tel     		VARCHAR(15) NOT NULL,
	PRIMARY KEY (fou_id)
)
;
#Table: PRODUITS
CREATE TABLE PROD (
	pro_id        		INT auto_increment NOT NULL,
	fou_id				INT NOT NULL,
	pro_lib  			VARCHAR(50) NOT NULL,
	pro_des   			VARCHAR(704),
	pro_pu				numeric (10,2) NOT NULL,
	pro_aff				bit NOT NULL,
	pro_pho      		VARCHAR(50),
	ru2_id        		INT,
	PRIMARY KEY (pro_id)
)
;
#Table: COMMANDES
CREATE TABLE COMM (
	com_id  			INT auto_increment NOT NULL,
	com_dat 			DATE NOT NULL,
	com_eta 			VARCHAR(25) NOT NULL,
	com_tot				numeric (10,2) NOT NULL,
	cli_id  			INT NOT NULL,
	PRIMARY KEY (com_id)
)
;
#Table: FACTURATIONS
CREATE TABLE FACT (
	fac_id       		INT auto_increment NOT NULL,
	com_id       		INT NOT NULL,
	fac_dat      		DATE NOT NULL,
	fac_red				numeric (10,2),
	fac_tot   			numeric (10,2) NOT NULL,
	PRIMARY KEY (fac_id)
)
;
#Table: REGLEMENTS
CREATE TABLE REGL (
	reg_id     			INT auto_increment NOT NULL,
	fac_id           	INT NOT NULL,
	reg_dat   			DATE NOT NULL,
	reg_tot 			numeric (10,2) NOT NULL,
	PRIMARY KEY (reg_id)
)
;
#Table: LIGNES DE COMMANDE
CREATE TABLE LIGN (
	lig_id				INT auto_increment NOT NULL,
	lig_qte   			INT NOT NULL,
	lig_pu    			numeric (10,2) NOT NULL,
	com_id   			INT NOT NULL,
	pro_id  			INT NOT NULL,
	PRIMARY KEY (lig_id)
)
;
#Table: LIVRAISONS
CREATE TABLE LIVR (
	liv_id     			INT auto_increment NOT NULL,
	com_id     			INT NOT NULL,
	liv_exp     		DATE NOT NULL,
	liv_rec     		DATE,
	PRIMARY KEY (liv_id)
)
;
#Table: COLIS
CREATE TABLE COLI (
	liv_id  			INT NOT NULL,
	liv_qte  			INT NOT NULL,
	pro_id 				INT NOT NULL,
	PRIMARY KEY (pro_id, liv_id)
)
;
#Table: CATEGORIES
CREATE TABLE RUB1 (
	ru1_id  			INT auto_increment NOT NULL,
	ru1_nom 			VARCHAR(25),
	PRIMARY KEY (ru1_id)
)
;
#Table: SOUS-CATEGORIES
CREATE TABLE RUB2 (
	ru2_id  			INT auto_increment NOT NULL,
	ru2_nom 			VARCHAR(25),
	ru1_id    			INT NOT NULL,
	PRIMARY KEY (ru2_id)
)
;
#Contrainte: Statut
ALTER TABLE CLIE
	ADD
		FOREIGN KEY (sta_id) REFERENCES STAT(sta_id)
;
#Contrainte: Produits
ALTER TABLE PROD
	ADD
		FOREIGN KEY (ru2_id) REFERENCES RUB2(ru2_id)
;
ALTER TABLE PROD
	ADD
		FOREIGN KEY (fou_id) REFERENCES FOUR(fou_id)
;
#Contrainte: SousCatégories
ALTER TABLE RUB2
	ADD
		FOREIGN KEY (ru1_id) REFERENCES RUB1(ru1_id)
;
#Contrainte: Lignes de commande
ALTER TABLE LIGN
	ADD
		FOREIGN KEY (pro_id) REFERENCES PROD(pro_id)
;
ALTER TABLE LIGN
	ADD
		FOREIGN KEY (com_id) REFERENCES COMM(com_id)
;
#Contrainte: Commandes
ALTER TABLE COMM
	ADD
		FOREIGN KEY (cli_id) REFERENCES CLIE(cli_id)
;	
#Contrainte: Facturations
ALTER TABLE FACT
	ADD
		FOREIGN KEY (com_id) REFERENCES COMM(com_id)
;
#Contrainte: Règlements
ALTER TABLE REGL
	ADD
		FOREIGN KEY (fac_id) REFERENCES FACT(fac_id)
;
#Contrainte: Livraisons
ALTER TABLE LIVR
	ADD
		FOREIGN KEY (com_id) REFERENCES COMM(com_id)
;
#Contrainte: Colis
ALTER TABLE COLI
	ADD
		FOREIGN KEY (pro_id) REFERENCES PROD(pro_id)
;
ALTER TABLE COLI
	ADD
		FOREIGN KEY (liv_id) REFERENCES LIVR(liv_id)
;

