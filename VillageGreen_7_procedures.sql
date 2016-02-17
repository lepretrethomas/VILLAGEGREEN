/****** Accès aux données VillageGreen ******/

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
	@lib_court VARCHAR(50),
	@lib_long VARCHAR(200),
	@photo VARCHAR(25),
	@ssrub_id INT
as
INSERT INTO PROD (fou_id, pro_lbc, pro_lbl, pro_pho, ssrub_id)
	values (@fournisseur, @lib_court, @lib_long, @photo, @ssrub_id)

execute PROD_AJOUT '1', 'AAA', 'BBB', NULL, '1'
select * from PROD

-- D’en supprimer
create proc PROD_SUPPR_NOM --drop proc PROD_SUPPR_NOM
	@produit VARCHAR(30)
as
DELETE from PROD where PROD.pro_lbc=@produit


create proc PROD_SUPPR_REF --drop proc PROD_SUPPR_REF
	@ref INT
as
DELETE from PROD where PROD.pro_id=@ref

execute PROD_SUPPR_NOM 'AAA'
execute PROD_SUPPR_REF '897319'
select * from PROD

-- D’en modifier les caractéristiques (libellé, caractéristique, tarif)



-- Certaines interrogations sont à prévoir:
-- Chiffre d'affaire généré pour l'ensemble et par fournisseur
select sum(com_qte*com_pu) as 'Chiffre d''affaire'
	from LIGN

select FOUR.fou_nom as 'Nom du fournisseur', sum(LIGN.com_qte*LIGN.com_pu) as 'Chiffre d''affaire'
	from FOUR
		join PROD
		on PROD.fou_id=FOUR.fou_id
			join LIGN
			on LIGN.pro_id=PROD.pro_id
				group by FOUR.fou_nom

select * from prod
select * from lign

-- Liste des produits commandés (ref produit, qte commandé)
select pro_id as 'Référence produit', sum(com_qte) as 'Quantité commandée' from LIGN
	group by pro_id

-- Liste des commandes pour un client (date, ref client, montant)
create proc COMCLI
	@client varchar(50)
as
select COMM.com_id, COMM.com_dat, CLIE.cli_id, FACT.fac_tot
	from COMM
		join CLIE
		on CLIE.cli_id=COMM.cli_id
			join FACT
			on FACT.com_id=COMM.com_id
				where CLIE.cli_nom=@client

exec comcli 'Page'
exec comcli 'UNIVERSAL MUSIC'

-- Répartition du chiffre d'affaire par type de client
select sta_nom as 'Catégorie', sum((com_qte*com_pu)*STAT.sta_coe) as 'Chiffre d''affaire'
	from LIGN
		join COMM
		on LIGN.com_id=COMM.com_id
			join CLIE
			on CLIE.cli_id=COMM.cli_id
				join STAT
				on CLIE.sta_id=STAT.sta_id
					group by sta_nom


-- Lister les commandes en cours de livraison.
select * from COMM, LIVR
	where (exists (select * where LIVR.com_id=COMM.com_id and LIVR.liv_exp is not null)
	and LIVR.liv_rec is null)
	
ou

select * from COMM
	where COMM.com_eta='En cours de livraison'

/****** Programmer des procédures stockées sur le SGBD ******/
-- Créez une procédure stockée qui sélectionne les commandes non soldées (en cours
-- de livraison)
create proc COMSOLDES1
as
select * from COMM, LIVR
	where (exists (select * where LIVR.com_id=COMM.com_id and LIVR.liv_exp is not null)
	and LIVR.liv_rec is null)

create proc COMSOLDES2
as
select * from COMM
	where COMM.com_eta='En cours de livraison'

exec COMSOLDES1
exec COMSOLDES2


-- Puis une autre qui renvoie le délai moyen entre la date de commande
-- et la date de facturation.
create proc DELAI_COMFAC
as
	select avg (datediff (day, COMM.com_dat, FACT.fac_dat)) as 'Délai moyen entre la date de commande et la date de facturation'
		from COMM
			join FACT on FACT.com_id=COMM.com_id
			where FACT.fac_dat is not null

exec DELAI_COMFAC

/****** Gérer les vues ******/
-- Créez une vue correspondant à la jointure Produits - Fournisseurs :
create view PRODFOUR
as
select PROD.pro_id, PROD.pro_lbc, FOUR.fou_id, fou_nom
	from PROD
		join FOUR
		on FOUR.fou_id=PROD.fou_id

select * from prodfour