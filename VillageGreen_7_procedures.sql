/****** Acc�s aux donn�es VillageGreen ******/

/****** Formaliser des requ�tes � l'aide du langage SQL ******/
-- 1. Pour chacune des interrogations demand�es (voir cahier des charges), cr�ez un
-- script contenant la ou les requ�tes n�cessaires.
-- 2. Exportez les tables principales (entit�) vers des tableaux d�un tableur de votre
-- choix ainsi que le contenu du r�sultat de vos requ�tes.
-- Ces tableaux devront apparaitre dans votre dossier final.

-- Dans le catalogue de l'entreprise tous les produits sont organis�s en
-- Rubrique/SousRubrique. Chaque produit doit �tre d�crit par un libell� court et un libell�
-- long (description), une r�f�rence fournisseur, un prix d'achat et une photo.

-- Tous les prix sont not�s hors taxes. Le prix de vente est calcul� � partir du prix d'achat
-- auquel on applique un coefficient en fonction de la cat�gorie du client (Particulier ou
-- Professionnel). Les coefficients sont attribu�s aux clients au moment de leur cr�ation et
-- peuvent �tre ajust�s par le service commercial.

-- Quand un client passe une commande, il peut �tre appliqu� une r�duction suppl�mentaire
-- sur le total, cette r�duction est n�goci�e par le service commercial.

-- Un module de gestion des commandes r�serv� au service commercial :
--- Cr�er une nouvelle commande
--- Ajouter des produits dans la commande
--- Conna�tre l��tat de la commande (saisie, annul�e, en pr�paration, exp�di�e,
--factur�e, retard de paiement, sold�e)
--- Consulter les clients en retard de paiement � une date donn�e
--- Modifier ou annuler la commande avant qu�elle ne soit en pr�paration
--- Les commandes seront saisies par le biais d�une interface accessible par internet

-- Un module de gestion des produits va permettre :
-- D�ajouter des produits
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

-- D�en supprimer
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

-- D�en modifier les caract�ristiques (libell�, caract�ristique, tarif)



-- Certaines interrogations sont � pr�voir:
-- Chiffre d'affaire g�n�r� pour l'ensemble et par fournisseur
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

-- Liste des produits command�s (ref produit, qte command�)
select pro_id as 'R�f�rence produit', sum(com_qte) as 'Quantit� command�e' from LIGN
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

-- R�partition du chiffre d'affaire par type de client
select sta_nom as 'Cat�gorie', sum((com_qte*com_pu)*STAT.sta_coe) as 'Chiffre d''affaire'
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

/****** Programmer des proc�dures stock�es sur le SGBD ******/
-- Cr�ez une proc�dure stock�e qui s�lectionne les commandes non sold�es (en cours
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


-- Puis une autre qui renvoie le d�lai moyen entre la date de commande
-- et la date de facturation.
create proc DELAI_COMFAC
as
	select avg (datediff (day, COMM.com_dat, FACT.fac_dat)) as 'D�lai moyen entre la date de commande et la date de facturation'
		from COMM
			join FACT on FACT.com_id=COMM.com_id
			where FACT.fac_dat is not null

exec DELAI_COMFAC

/****** G�rer les vues ******/
-- Cr�ez une vue correspondant � la jointure Produits - Fournisseurs :
create view PRODFOUR
as
select PROD.pro_id, PROD.pro_lbc, FOUR.fou_id, fou_nom
	from PROD
		join FOUR
		on FOUR.fou_id=PROD.fou_id

select * from prodfour