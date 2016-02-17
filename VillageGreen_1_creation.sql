/*************************************************************
******************** FIL ROUGE *******************************
*************************************************************/

----- Suppression de la base Village Green existante
/*
USE VILLAGE_GREEN
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
DROP DATABASE VILLAGE_GREEN
go
*/

----- Création de la base de donnees Village Green
CREATE DATABASE VILLAGE_GREEN
go

USE VILLAGE_GREEN
go

/****** Création des Tables ******/
----- Table: SERVICE COMMERCIAL
CREATE TABLE SERVCOM (
	commercial_id    	INT IDENTITY NOT NULL,
	commercial_nom  	VARCHAR(50),
	commercial_prenom	VARCHAR(25),
	PRIMARY KEY (commercial_id)
)

----- Table: CLIENTS
CREATE TABLE CLIENT (
	cli_ref      		INT IDENTITY NOT NULL,
	cli_nom      		VARCHAR(50) NOT NULL,
	cli_prenom   		VARCHAR(25),
	cli_adresse  		VARCHAR(100) NOT NULL,
	cli_cp       		int check (cli_cp like '[0-9][0-9][0-9][0-9][0-9]') NOT NULL,
	cli_ville    		VARCHAR(100) NOT NULL,
	cli_tel      		VARCHAR(15) NOT NULL,
	cli_categorie 		VARCHAR(15),
	cli_coef     		INT,
	PRIMARY KEY (cli_ref)
)

----- Table: FOURNISSEURS
CREATE TABLE FOUR (
	four_ref     		INT IDENTITY NOT NULL,
	four_nom     		VARCHAR(50) NOT NULL,
	four_prenom  		VARCHAR(25),
	four_adresse 		VARCHAR(100) NOT NULL,
	four_cp      		int check (four_cp like '[0-9][0-9][0-9][0-9][0-9]') NOT NULL,
	four_ville   		VARCHAR(100) NOT NULL,
	four_tel     		VARCHAR(15) NOT NULL,
	PRIMARY KEY (four_ref)
)

----- Table: PRODUITS
CREATE TABLE PROD (
	prod_ref        	INT IDENTITY NOT NULL,
	four_ref			INT NOT NULL,
	prod_nom        	VARCHAR(30) NOT NULL,
	prod_lib_court  	VARCHAR(50),
	prod_lib_long   	VARCHAR(200),
	prod_photo      	VARCHAR(25),
	prod_stock      	INT NOT NULL,
	ssrub_id        	INT,
	PRIMARY KEY (prod_ref)
)

----- Table: COMMANDES
CREATE TABLE COM (
	com_num  			INT IDENTITY NOT NULL,
	com_date 			DATE DEFAULT GETDATE() NOT NULL,
	com_etat 			VARCHAR(25) NOT NULL,
	cli_ref  			INT NOT NULL,
	fac_adresse   		VARCHAR(100) NOT NULL,
	fac_cp        		int check (fac_cp like '[0-9][0-9][0-9][0-9][0-9]') NOT NULL,
	fac_ville     		VARCHAR(100) NOT NULL,
	liv_adresse 		VARCHAR(100) NOT NULL,
	liv_cp      		int check (liv_cp like '[0-9][0-9][0-9][0-9][0-9]') NOT NULL,
	liv_ville   		VARCHAR(100) NOT NULL,
	PRIMARY KEY (com_num)
)

----- Table: FACTURATIONS
CREATE TABLE FACT (
	fac_num       		INT IDENTITY NOT NULL,
	com_num       		INT NOT NULL,
	fac_date      		DATE DEFAULT GETDATE() NOT NULL,
	fac_montant   		numeric (8,2) NOT NULL,
	PRIMARY KEY (fac_num)
)

----- Table: REGLEMENTS
CREATE TABLE REGL (
	reglement_num     	INT IDENTITY NOT NULL,
	fac_num           	INT NOT NULL,
	reglement_date    	DATE DEFAULT GETDATE() NOT NULL,
	reglement_montant 	numeric (8,2) NOT NULL,
	PRIMARY KEY (reglement_num)
)

----- Table: LIGNES DE COMMANDE
CREATE TABLE LIGCOM (
	com_ligne 			INT IDENTITY NOT NULL,
	com_qte   			INT NOT NULL,
	com_pu    			MONEY NOT NULL,
	com_num   			INT,
	prod_ref  			INT NOT NULL,
	PRIMARY KEY (com_ligne)
)

----- Table: LIVRAISONS
CREATE TABLE LIVR (
	liv_num     		INT IDENTITY NOT NULL,
	com_num     		INT NOT NULL,
	liv_exp     		DATE NOT NULL,
	liv_rec     		DATE,
	PRIMARY KEY (liv_num)
)

----- Table: CATEGORIES
CREATE TABLE CAT (
	rub_id  			INT IDENTITY NOT NULL,
	rub_nom 			VARCHAR(25),
	PRIMARY KEY (rub_id)
)

----- Table: SOUS-CATEGORIES
CREATE TABLE SSCAT (
	ssrub_id  			INT IDENTITY NOT NULL,
	ssrub_nom 			VARCHAR(25),
	rub_id    			INT NOT NULL,
	PRIMARY KEY (ssrub_id)
)

----- Table: NEGOCIER
CREATE TABLE NEGO (
	cli_ref       		INT  NOT NULL,
	commercial_id 		INT  NOT NULL,
	fac_reduction 		numeric (8,2) NOT NULL,
	PRIMARY KEY (commercial_id, cli_ref)
)

----- Table: CONTENIR
CREATE TABLE CONT (
	liv_num  			INT NOT NULL,
	liv_qte  			INT NOT NULL,
	prod_ref 			INT NOT NULL,
	PRIMARY KEY (prod_ref, liv_num)
)
go

/****** Création des Contraintes ******/
----- Contrainte: Produits
ALTER TABLE PROD
	ADD
		FOREIGN KEY (ssrub_id) REFERENCES SSCAT(ssrub_id),
		FOREIGN KEY (four_ref) REFERENCES FOUR(four_ref)

----- Contrainte: SousCatégories
ALTER TABLE SSCAT
	ADD
		FOREIGN KEY (rub_id) REFERENCES CAT(rub_id)

----- Contrainte: Lignes de commande
ALTER TABLE LIGCOM
	ADD
		FOREIGN KEY (prod_ref) REFERENCES PROD(prod_ref),
		FOREIGN KEY (com_num) REFERENCES COM(com_num)

----- Contrainte: Commandes
ALTER TABLE COM
	ADD
		FOREIGN KEY (cli_ref) REFERENCES CLIENT(cli_ref)
	
----- Contrainte: Facturations
ALTER TABLE FACT
	ADD
		FOREIGN KEY (com_num) REFERENCES COM(com_num),
		CONSTRAINT FACT_AK UNIQUE (com_num)

----- Contrainte: Règlements
ALTER TABLE REGL
	ADD
		FOREIGN KEY (fac_num) REFERENCES FACT(fac_num),
		CONSTRAINT REG_AK UNIQUE (fac_num)

----- Contrainte: Livraisons
ALTER TABLE LIVR
	ADD
		FOREIGN KEY (com_num) REFERENCES COM(com_num)

----- Contrainte: NEGOCIER
ALTER TABLE NEGO
	ADD
		FOREIGN KEY (commercial_id) REFERENCES SERVCOM(commercial_id),
		FOREIGN KEY (cli_ref) REFERENCES CLIENT(cli_ref)

----- Contrainte: contenir
ALTER TABLE CONT
	ADD
		FOREIGN KEY (prod_ref) REFERENCES PROD(prod_ref),
		FOREIGN KEY (liv_num) REFERENCES LIVR(liv_num)
go

/****** Création des Indexs ******/
----- Index sur les noms Clients
create nonclustered index ix_client on CLIENT(cli_nom)

----- Index sur les noms Fournisseurs
create nonclustered index ix_fournis on FOUR(four_nom)

----- Index sur les noms Produits
create nonclustered index ix_produit on PROD(prod_nom)

---- Index sur les villes Clients
create nonclustered index ix_vilcli on CLIENT(cli_cp, cli_ville)

---- Index sur les villes Fournisseurs
create nonclustered index ix_vilfou on FOUR(four_cp, four_ville)

---- Index sur les villes Livraisons
create nonclustered index ix_villiv on COM(liv_cp, liv_ville)
go
