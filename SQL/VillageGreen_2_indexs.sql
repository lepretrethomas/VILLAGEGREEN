--LEPRETRE THOMAS - FORMATION DEVELOPPEUR LOGICIEL AFPA AMIENS

/*************************************************************
******************** FIL ROUGE *******************************
*************************************************************/

use VILLAGEGREEN
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
