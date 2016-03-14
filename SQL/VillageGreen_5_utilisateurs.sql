--LEPRETRE THOMAS - FORMATION DEVELOPPEUR LOGICIEL AFPA AMIENS

/*************************************************************
******************** FIL ROUGE *******************************
*************************************************************/
use VILLAGEGREEN
go

/****** Création des Rôles ******/
create role ADMINISTRATEUR
grant SELECT, INSERT, DELETE, UPDATE on SCHEMA::dbo to ADMINISTRATEUR
go

create role COMPTABILITE -- COMPTABILITE
grant SELECT, INSERT, DELETE, UPDATE on FACT to COMPTABILITE
grant SELECT, INSERT, DELETE, UPDATE on REGL to COMPTABILITE
go

create role LIVRAISON -- LIVRAISON
grant SELECT, INSERT, DELETE, UPDATE on LIVR to LIVRAISON
grant SELECT, INSERT, DELETE, UPDATE on COLI to LIVRAISON	
go

create role COMMERCIAL -- COMMERCIAL
grant SELECT, INSERT, DELETE, UPDATE on CLIE to COMMERCIAL
grant SELECT, INSERT, DELETE, UPDATE on LIGN to COMMERCIAL
grant SELECT, INSERT, DELETE, UPDATE on COMM to COMMERCIAL
grant SELECT on PROD to COMMERCIAL
go

create role CLIENT -- CLIENT
grant SELECT on PROD to CLIENT
grant SELECT on LIVR to CLIENT
grant SELECT on FACT to CLIENT
grant SELECT on REGL to CLIENT
grant SELECT, INSERT, DELETE, UPDATE on CLIE to CLIENT
grant SELECT, INSERT, DELETE, UPDATE on LIGN to CLIENT
grant SELECT, INSERT, DELETE, UPDATE on COMM to CLIENT
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
execute sp_addrolemember 'COMPTABILITE','VG_us01'
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
execute sp_addrolemember 'CLIENT','VG_us03'
go
