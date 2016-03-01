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
