/****** Sauvegarde de Village Green ******/
USE VILLAGE_GREEN
go

----- Création d'une unité de sauvegarde
exec sp_addumpdevice 'disk','savVG','C:\tmp\Village_Green.bak'
-- exec sp_dropdevice 'savVG'

----- Sauvegarde de la base de données
backup database VILLAGE_GREEN to savVG

----- Restauration de la base de données
restore database VILLAGE_GREEN from savVG with replace

/***
Si un message d’erreur survient lors de la restauration, il est probable que votre
base de données soit en cours d’utilisation.

-----Pour libérer votre base et la passer en mode exclusif
alter database village_green set restricted_user with rollback immediate

-----Pour remettre votre base en mode multi utilisateur
alter database village_green set multi_user
***/

