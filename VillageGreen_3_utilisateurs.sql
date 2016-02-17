/****** Création des Rôles ******/
use VILLAGE_GREEN
go

/****** Création des Rôles ******/
use VILLAGE_GREEN
go

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
grant SELECT, INSERT, DELETE, UPDATE on NEGO to COMMERCIAL
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
