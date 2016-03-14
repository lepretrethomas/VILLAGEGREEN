using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class ProduitDAO
    {
        SqlConnection connect;

        public ProduitDAO(string chaine)
        {
            connect = new SqlConnection(chaine);
        }

        public void Insert(Produit p)
        {
            connect.Open();
            //SqlCommand requete_insert = new SqlCommand("insert into PROD (fou_id, pro_lib, pro_des, pro_photo, ru2_id)"
            //+ " values (@fournisseur, @libelle, @description, @photo, @rubrique)", connect);
            SqlCommand requete_insert = new SqlCommand("insert into PROD (fou_id, pro_lib, pro_des, pro_pu, ru2_id)"
                                                    + " values (@fournisseur, @libelle, @description, @prix, @rubrique)", connect);
            requete_insert.Parameters.AddWithValue("@fournisseur", p.Fournisseur);
            requete_insert.Parameters.AddWithValue("@libelle", p.Libelle);
            requete_insert.Parameters.AddWithValue("@description", p.Description);
            requete_insert.Parameters.AddWithValue("@prix", p.Prix);
            //if (p.Photo != null)
            //{
            //    requete_insert.Parameters.AddWithValue("@photo", p.Photo);
            //}
            //else
            //{
            //    requete_insert.Parameters.AddWithValue("@photo", DBNull.Value);
            //}
            requete_insert.Parameters.AddWithValue("@rubrique", p.Rubrique);
            requete_insert.ExecuteNonQuery();

            SqlCommand requete_id = new SqlCommand("select pro_id from PROD where pro_lib = @libelle", connect);
            requete_id.Parameters.AddWithValue("@libelle", p.Libelle);
            SqlDataReader resultat = requete_id.ExecuteReader();
            resultat.Read();
            int id = (int)resultat["pro_id"];
            p.Id = id;

            connect.Close();
        }

        public void Update(Produit p)
        {
            connect.Open();
            //SqlCommand requete_update = new SqlCommand("update PROD set fou_id = @fournisseur, pro_lib = @libelle,"
            //+ " pro_pho = @photo, pro_des = @description, ru2_id=@rubrique"
            //+ " where pro_id = @id", connect);
            SqlCommand requete_update = new SqlCommand("update PROD set fou_id = @fournisseur, pro_lib = @libelle,"
            + " pro_des = @description, pro_pu = @prix, ru2_id=@rubrique"
            + " where pro_id = @id", connect);
            requete_update.Parameters.AddWithValue("@id", p.Id);
            requete_update.Parameters.AddWithValue("@fournisseur", p.Fournisseur);
            requete_update.Parameters.AddWithValue("@libelle", p.Libelle);
            requete_update.Parameters.AddWithValue("@description", p.Description);
            requete_update.Parameters.AddWithValue("@prix", p.Prix);
            //if (p.Photo != "")
            //{
            //    requete_update.Parameters.AddWithValue("@photo", p.Photo);
            //}
            //else
            //{
            //    requete_update.Parameters.AddWithValue("@photo", DBNull.Value);
            //}
            requete_update.Parameters.AddWithValue("@rubrique", p.Rubrique);
            requete_update.ExecuteNonQuery();
            connect.Close();
        }

        public void Delete(Produit p)
        {
            connect.Open();
            SqlCommand requete_delete = new SqlCommand("delete from PROD where pro_id = @id", connect);
            requete_delete.Parameters.AddWithValue("@id", p.Id);
            requete_delete.ExecuteNonQuery();
            connect.Close();
        }

        public Produit FindbyId(int id)
        {
            connect.Open();
            Produit p = null;
            SqlCommand requete_find = new SqlCommand("select * from PROD where pro_id = @id", connect);
            requete_find.Parameters.AddWithValue("@id", id);
            SqlDataReader lecture = requete_find.ExecuteReader();

            if (lecture.Read())
            {
                p = new Produit();
                p.Id = Convert.ToInt32(lecture["pro_id"]);
                p.Fournisseur = Convert.ToInt32(lecture["fou_id"]);
                p.Libelle = Convert.ToString(lecture["pro_lib"]);
                p.Description = Convert.ToString(lecture["pro_des"]);
                p.Prix = Convert.ToDecimal(lecture["pro_pu"]);
                p.Photo = Convert.ToString(lecture["pro_pho"]);
                p.Rubrique = Convert.ToInt32(lecture["ru2_id"]);
            }

            lecture.Close();
            connect.Close();
            return p;
        }
        public Produit FindbyName(string nom)
        {
            connect.Open();
            Produit p = null;
            SqlCommand requete_find = new SqlCommand("select * from PROD where pro_lib = @nom", connect);
            requete_find.Parameters.AddWithValue("@nom", nom);
            SqlDataReader lecture = requete_find.ExecuteReader();

            if (lecture.Read())
            {
                p = new Produit();
                p.Id = Convert.ToInt32(lecture["pro_id"]);
                p.Fournisseur = Convert.ToInt32(lecture["fou_id"]);
                p.Libelle = Convert.ToString(lecture["pro_lib"]);
                p.Description = Convert.ToString(lecture["pro_des"]);
                p.Prix = Convert.ToDecimal(lecture["pro_pu"]);
                p.Photo = Convert.ToString(lecture["pro_pho"]);
                p.Rubrique = Convert.ToInt32(lecture["ru2_id"]);
            }

            lecture.Close();
            connect.Close();
            return p;
        }

        public List<Produit> List()
        {
            connect.Open();
            List<Produit> resultat = new List<Produit>();
            SqlCommand requete_list = new SqlCommand("select * from PROD order by pro_lib", connect);
            SqlDataReader lecture = requete_list.ExecuteReader();

            while (lecture.Read())
            {
                Produit p = new Produit();
                p.Id = Convert.ToInt32(lecture["pro_id"]);
                p.Fournisseur = Convert.ToInt32(lecture["fou_id"]);
                p.Libelle = Convert.ToString(lecture["pro_lib"]);
                p.Description = Convert.ToString(lecture["pro_des"]);
                p.Prix = Convert.ToDecimal(lecture["pro_pu"]);
                p.Photo = Convert.ToString(lecture["pro_pho"]);
                p.Rubrique = Convert.ToInt32(lecture["ru2_id"]);
                resultat.Add(p);
            }

            lecture.Close();
            connect.Close();
            return resultat;
        }
        public List<Produit> ParRubrique(int rubrique)
        {
            List<Produit> resultat = new List<Produit>();
            connect.Open();
            SqlCommand requete_statut = new SqlCommand(@"Select * from PROD
                                                         where ru2_id = @rubrique order by pro_lib", connect);
            requete_statut.Parameters.AddWithValue("@rubrique", rubrique);
            SqlDataReader lecture = requete_statut.ExecuteReader();
            while (lecture.Read())
            {
                Produit p = new Produit();
                p.Id = Convert.ToInt32(lecture["pro_id"]);
                p.Fournisseur = Convert.ToInt32(lecture["fou_id"]);
                p.Libelle = Convert.ToString(lecture["pro_lib"]);
                p.Description = Convert.ToString(lecture["pro_des"]);
                p.Prix = Convert.ToDecimal(lecture["pro_pu"]);
                p.Photo = Convert.ToString(lecture["pro_pho"]);
                p.Rubrique = Convert.ToInt32(lecture["ru2_id"]);
                resultat.Add(p);
            }
            lecture.Close();
            connect.Close();
            return resultat;
        }
        public List<Produit> ParFournisseur(int fournisseur)
        {
            List<Produit> resultat = new List<Produit>();
            connect.Open();
            SqlCommand requete_statut = new SqlCommand(@"Select * from PROD
                                                         where fou_id = @fournisseur order by pro_lib", connect);
            requete_statut.Parameters.AddWithValue("@fournisseur", fournisseur);
            SqlDataReader lecture = requete_statut.ExecuteReader();
            while (lecture.Read())
            {
                Produit p = new Produit();
                p.Id = Convert.ToInt32(lecture["pro_id"]);
                p.Fournisseur = Convert.ToInt32(lecture["fou_id"]);
                p.Libelle = Convert.ToString(lecture["pro_lib"]);
                p.Description = Convert.ToString(lecture["pro_des"]);
                p.Prix = Convert.ToDecimal(lecture["pro_pu"]);
                p.Photo = Convert.ToString(lecture["pro_pho"]);
                p.Rubrique = Convert.ToInt32(lecture["ru2_id"]);
                resultat.Add(p);
            }
            lecture.Close();
            connect.Close();
            return resultat;
        }
    }
}
