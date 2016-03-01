create view CA_Cat_Client
	as
select sta_nom as 'CATEGORIE', sum((com_qte*com_pu)*STAT.sta_coe) as 'CA'
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
select sum((com_qte*com_pu)*STAT.sta_coe) as 'CA'
	from LIGN
		join COMM
		on LIGN.com_id=COMM.com_id
			join CLIE
			on CLIE.cli_id=COMM.cli_id
				join STAT
				on CLIE.sta_id=STAT.sta_id

go

create view CA_Fournisseur
as
select FOUR.fou_id as 'FOURNISSEUR', sum(LIGN.com_qte*LIGN.com_pu) as 'CA'
	from FOUR
		join PROD
		on PROD.fou_id=FOUR.fou_id
			join LIGN
			on LIGN.pro_id=PROD.pro_id
				group by FOUR.fou_id

go

create view CA_All_Fournisseur
as
select sum(com_qte*com_pu) as 'CA'
	from LIGN

go