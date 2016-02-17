/****** Sauvegarde de Village Green ******/
USE VILLAGEGREEN
go

----- Création d'une unité de sauvegarde
exec sp_addumpdevice 'disk','savVG','C:\tmp\Village_Green.bak'
-- exec sp_dropdevice 'savVG'

----- Sauvegarde de la base de données
backup database VILLAGEGREEN to savVG

----- Restauration de la base de données
restore database VILLAGEGREEN from savVG with replace

/***
Si un message d’erreur survient lors de la restauration, il est probable que votre
base de données soit en cours d’utilisation.

-----Pour libérer votre base et la passer en mode exclusif
alter database villagegreen set restricted_user with rollback immediate

-----Pour remettre votre base en mode multi utilisateur
alter database villagegreen set multi_user
***/

