/****** Création des Rôles ******/
use VILLAGE_GREEN
go

create role GEST --GESTION
grant SELECT, INSERT, DELETE, UPDATE on SCHEMA::dbo to GEST
go

create role COMPT -- COMPTABILITE
grant SELECT, INSERT, DELETE, UPDATE on FACT to COMPT
grant SELECT, INSERT, DELETE, UPDATE on REGL to COMPT
grant SELECT, INSERT, UPDATE on CLIENT to COMPT
go

create role LIVR -- LIVRAISON
grant SELECT, INSERT, DELETE, UPDATE on LIVR to LIVR
go

create role COMM -- COMMERCIAL
grant SELECT, INSERT, DELETE, UPDATE on CLIENT to COMM
grant SELECT, INSERT, DELETE, UPDATE on PROD to COMM
grant SELECT, INSERT, DELETE, UPDATE on NEGO to COMM
grant SELECT, INSERT, DELETE, UPDATE on LIGCOM to COMM
grant SELECT, INSERT, DELETE, UPDATE on COM to COMM
go

create role UTIL -- CLIENT
grant SELECT on PROD to UTIL
grant SELECT on LIVR to UTIL
grant SELECT on FACT to UTIL
grant SELECT, INSERT, DELETE, UPDATE on CLIENT to UTIL
grant SELECT, INSERT, DELETE, UPDATE on LIGCOM to UTIL
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
execute sp_addrolemember 'COMPT','VG_us01'
go

-- Création de l'utilisateur 2 / Service commercial
create login VG_log02 with password = 'pwd',
default_database=master,
check_expiration=off,
check_policy=off
go
create user VG_us02 for login VG_log02
go
execute sp_addrolemember 'COMM','VG_us02'
go

-- Création de l'utilisateur 3 / Clientèle
create login VG_log03 with password = 'pwd',
default_database=master,
check_expiration=off,
check_policy=off
go
create user VG_us03 for login VG_log03
go
execute sp_addrolemember 'UTIL','VG_us03'
go