use VILLAGEGREEN
go

/****** Création des Indexs ******/
----- Index sur les noms Clients
create nonclustered index ix_client on CLIE(cli_nom)

----- Index sur les noms FOURnisseurs
create nonclustered index ix_fournis on FOUR(fou_nom)

----- Index sur les noms Produits
create nonclustered index ix_produit on PROD(pro_nom)

---- Index sur les villes Clients
create nonclustered index ix_vilcli on CLIE(cli_cp, cli_vil)

---- Index sur les villes FOURnisseurs
create nonclustered index ix_vilfou on FOUR(fou_cp, fou_vil)

---- Index sur les villes Livraisons
create nonclustered index ix_villiv on CLIE(liv_cp, liv_vil)
go
