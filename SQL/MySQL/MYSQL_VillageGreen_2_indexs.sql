#LEPRETRE THOMAS - FORMATION DEVELOPPEUR LOGICIEL AFPA AMIENS

/*************************************************************
******************** FIL ROUGE *******************************
*************************************************************/
use VILLAGEGREEN
;
/****** Cr�ation des Indexs ******/
#Index sur les noms Clients
create index ix_client on CLIE(cli_nom)
;
#Index sur les noms Fournisseurs
create index ix_fournis on FOUR(fou_nom)
;
#Index sur les libell�s Produits
create index ix_produit on PROD(pro_lib)
;
#Index sur les villes Clients
create index ix_vilcli on CLIE(cli_vil)
;
#Index sur les villes Fournisseurs
create index ix_vilfou on FOUR(fou_vil)
;
#Index sur les villes Livraisons
create index ix_villiv on CLIE(liv_vil)
;
