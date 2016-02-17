/****** Accès aux données Village_Green ******/

/****** Formaliser des requêtes à l'aide du langage SQL ******/
-- 1. Pour chacune des interrogations demandées (voir cahier des charges), créez un
-- script contenant la ou les requêtes nécessaires.
-- 2. Exportez les tables principales (entité) vers des tableaux d’un tableur de votre
-- choix ainsi que le contenu du résultat de vos requêtes.
-- Ces tableaux devront apparaitre dans votre dossier final.

-- Dans le catalogue de l'entreprise tous les produits sont organisés en
-- Rubrique/SousRubrique. Chaque produit doit être décrit par un libellé court et un libellé
-- long (description), une référence fournisseur, un prix d'achat et une photo.

-- Tous les prix sont notés hors taxes. Le prix de vente est calculé à partir du prix d'achat
-- auquel on applique un coefficient en fonction de la catégorie du client (Particulier ou
-- Professionnel). Les coefficients sont attribués aux clients au moment de leur création et
-- peuvent être ajustés par le service commercial.

-- Quand un client passe une commande, il peut être appliqué une réduction supplémentaire
-- sur le total, cette réduction est négociée par le service commercial.

-- Un module de gestion des commandes réservé au service commercial :
--- Créer une nouvelle commande
--- Ajouter des produits dans la commande
--- Connaître l’état de la commande (saisie, annulée, en préparation, expédiée,
--facturée, retard de paiement, soldée)
--- Consulter les clients en retard de paiement à une date donnée
--- Modifier ou annuler la commande avant qu’elle ne soit en préparation
--- Les commandes seront saisies par le biais d’une interface accessible par internet

-- Un module de gestion des produits va permettre :
-- D’ajouter des produits
create proc PROD_AJOUT --drop proc PROD_AJOUT
	@fournisseur int,
	@nom VARCHAR(30),
	@lib_court VARCHAR(50),
	@lib_long VARCHAR(200),
	@photo VARCHAR(25),
	@stock INT,
	@ssrub_id INT
as
INSERT INTO Prod (four_ref, prod_nom, prod_lib_court, prod_lib_long, prod_photo, prod_stock, ssrub_id)
	values (@fournisseur, @nom, @lib_court, @lib_long, @photo, @stock, @ssrub_id)

execute PROD_AJOUT '34', 'AAA', 'BBB', 'CCCC', NULL, 11, '100'
select * from prod

-- D’en supprimer
create proc PROD_SUPPR_NOM --drop proc PROD_SUPPR_NOM
	@produit VARCHAR(30)
as
DELETE from PROD where PROD.prod_nom=@produit


create proc PROD_SUPPR_REF --drop proc PROD_SUPPR_REF
	@ref INT
as
DELETE from PROD where PROD.prod_ref=@ref

execute PROD_SUPPR_NOM 'AAA'
execute PROD_SUPPR_REF '213897'
select * from prod

-- D’en modifier les caractéristiques (libellé, caractéristique, tarif)



-- Certaines interrogations sont à prévoir:
-- Chiffre d'affaire généré pour l'ensemble et par fournisseur
select sum(com_qte*com_pu) as 'Chiffre d''affaire'
	from LIGCOM

select FOUR.four_nom as 'Nom du fournisseur', sum(LIGCOM.com_qte*LIGCOM.com_pu) as 'Chiffre d''affaire'
	from FOUR
		join PROD
		on PROD.four_ref=FOUR.four_ref
			join LIGCOM
			on LIGCOM.prod_ref=PROD.prod_ref
				group by FOUR.four_nom

select * from prod
select * from ligcom

-- Liste des produits commandés (ref produit, qte commandé)
select distinct prod_ref, com_qte from LIGCOM

-- Liste des commandes pour un client (date, ref client, montant)
create proc COMCLI
	@client varchar(50)
as
select COM.com_num, COM.com_date, CLIENT.cli_ref, FACT.fac_montant
	from COM
		join CLIENT
		on CLIENT.cli_ref=COM.cli_ref
			join FACT
			on FACT.com_num=COM.com_num
				where CLIENT.cli_nom=@client

exec comcli 'Page'
exec comcli 'UNIVERSAL MUSIC'

-- Répartition du chiffre d'affaire par type de client
select cli_categorie as 'Catégorie', sum((com_qte*com_pu)*cli_coef) as 'Chiffre d''affaire'
	from CLIENT, LIGCOM
		group by cli_categorie

-- Lister les commandes en cours de livraison.
select * from COM, LIVR
	where (exists (select * where LIVR.com_num=COM.com_num and LIVR.liv_exp is not null)
	and LIVR.liv_rec is null)
	
ou

select * from COM
	where COM.com_etat='En cours de livraison'

/****** Programmer des procédures stockées sur le SGBD ******/
-- Créez une procédure stockée qui sélectionne les commandes non soldées (en cours
-- de livraison), puis une autre qui renvoie le délai moyen entre la date de commande
-- et la date de facturation.

/****** Gérer les vues ******/
-- Créez une vue correspondant à la jointure Produits - Fournisseurs :
create view PRODFOUR
as
select PROD.prod_ref, prod_nom, FOUR.four_ref, four_nom
	from PROD
		join FOUR
		on FOUR.four_ref=PROD.four_ref

select * from prodfour