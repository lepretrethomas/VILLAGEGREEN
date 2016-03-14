--LEPRETRE THOMAS - FORMATION DEVELOPPEUR LOGICIEL AFPA AMIENS

/*************************************************************
******************** FIL ROUGE *******************************
*************************************************************/

/****** Acc�s aux donn�es VillageGreen ******/

/****** Formaliser des requ�tes � l'aide du langage SQL ******/
-- Certaines interrogations sont � pr�voir:

-- Chiffre d'affaire g�n�r� pour l'ensemble et par fournisseur
create view CA_All_Fournisseur
	as
select sum(lig_qte*lig_pu) as 'CA'
	from LIGN
go

create view CA_Fournisseur
	as
select FOUR.fou_id as 'FOURNISSEUR', sum(LIGN.lig_qte*LIGN.lig_pu) as 'CA'
	from FOUR
		join PROD
		on PROD.fou_id=FOUR.fou_id
			join LIGN
			on LIGN.pro_id=PROD.pro_id
				group by FOUR.fou_id
go

-- Liste des produits command�s (ref produit, qte command�)
create view Prod_Comm
	as
select pro_id as 'R�f�rence produit', sum(lig_qte) as 'Quantit� command�e' from LIGN
	group by pro_id
go

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
go
--exec comcli 'Page'
--exec comcli 'UNIVERSAL MUSIC'

-- R�partition du chiffre d'affaire par type de client
create view CA_Cat_Client
	as
select sta_nom as 'CATEGORIE', sum((lig_qte*lig_pu)*STAT.sta_coe) as 'CA'
	from LIGN
		join COMM
		on LIGN.com_id=COMM.com_id
			join CLIE
			on CLIE.cli_id=COMM.cli_id
				join STAT
				on CLIE.sta_id=STAT.sta_id
					group by sta_nom
go

create view CA_All_Client
	as
select sum((lig_qte*lig_pu)*STAT.sta_coe) as 'CA'
	from LIGN
		join COMM
		on LIGN.com_id=COMM.com_id
			join CLIE
			on CLIE.cli_id=COMM.cli_id
				join STAT
				on CLIE.sta_id=STAT.sta_id
go


-- Lister les commandes en cours de livraison.
create view Comm_Livr1
	as
select COMM.com_id, com_dat, com_eta, liv_id, cli_id, liv_exp, liv_rec from COMM, LIVR
	where (exists (select * where LIVR.com_id=COMM.com_id and LIVR.liv_exp is not null)
	and LIVR.liv_rec is null)
go

--ou

create view Comm_Livr2
	as
select * from COMM
	where COMM.com_eta='En cours de livraison'
go

/****** Programmer des proc�dures stock�es sur le SGBD ******/
-- Cr�ez une proc�dure stock�e qui s�lectionne les commandes non sold�es (en cours
-- de livraison)
create proc COMSOLD1
as
select * from COMM, LIVR
	where (exists (select * where LIVR.com_id=COMM.com_id and LIVR.liv_exp is not null)
	and LIVR.liv_rec is null)
go

create proc COMSOLD2
as
select * from COMM
	where COMM.com_eta='En cours de livraison'
go

--exec COMSOLDES1
--exec COMSOLDES2

-- Puis une autre qui renvoie le d�lai moyen entre la date de commande
-- et la date de facturation.
create proc DELAI_COMFAC
as
	select avg (datediff (day, COMM.com_dat, FACT.fac_dat)) as 'D�lai moyen entre la date de commande et la date de facturation'
		from COMM
			join FACT on FACT.com_id=COMM.com_id
			where FACT.fac_dat is not null
go

--exec DELAI_COMFAC

/****** G�rer les vues ******/
-- Cr�ez une vue correspondant � la jointure Produits - Fournisseurs :
create view Prod_Four
as
select PROD.pro_id, PROD.pro_lib, FOUR.fou_id, fou_nom
	from PROD
		join FOUR
		on FOUR.fou_id=PROD.fou_id
go