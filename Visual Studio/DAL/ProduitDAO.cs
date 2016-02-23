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
            SqlCommand requete_insert = new SqlCommand("insert into PROD (fou_id, pro_lbc, pro_lbl, pro_photo, ssrub_id)"
            + " values (@fournisseur, @libelle, @description, @photo, @rubrique)", connect);
            requete_insert.Parameters.AddWithValue("@fournisseur", p.Fournisseur);
            requete_insert.Parameters.AddWithValue("@libelle", p.Libelle);
            requete_insert.Parameters.AddWithValue("@description", p.Description);
            requete_insert.Parameters.AddWithValue("@photo", p.Photo);
            requete_insert.Parameters.AddWithValue("@rubrique", p.Rubrique);
            requete_insert.ExecuteNonQuery();

            SqlCommand requete_id = new SqlCommand("select pro_id from PROD where pro_lbc = @libelle", connect);
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
            SqlCommand requete_update = new SqlCommand("update PROD set fou_id = @fournisseur, pro_lbc = @libelle,"
            + " pro_pho = @photo, fou_adresse = @description, fou_ville=@rubrique, fou_tel = @telephone"
            + " where pro_id = @id", connect);
            requete_update.Parameters.AddWithValue("@fournisseur", p.Fournisseur);
            requete_update.Parameters.AddWithValue("@libelle", p.Libelle);
            requete_update.Parameters.AddWithValue("@description", p.Description);
            requete_update.Parameters.AddWithValue("@photo", p.Photo);
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

        public Produit Find(int id)
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
                p.Fournisseur = Convert.ToString(lecture["fou_id"]);
                p.Libelle = Convert.ToString(lecture["pro_lbc"]);
                p.Description = Convert.ToString(lecture["pro_lbl"]);
                p.Photo = Convert.ToString(lecture["pro_pho"]);
                p.Rubrique = Convert.ToString(lecture["ssrub_id"]);
            }

            lecture.Close();
            connect.Close();
            return p;
        }

        public List<Produit> List()
        {
            connect.Open();
            List<Produit> resultat = new List<Produit>();
            SqlCommand requete_list = new SqlCommand("select * from PROD", connect);
            SqlDataReader lecture = requete_list.ExecuteReader();

            while (lecture.Read())
            {
                Produit p = new Produit();
                p.Id = Convert.ToInt32(lecture["pro_id"]);
                p.Fournisseur = Convert.ToString(lecture["fou_id"]);
                p.Libelle = Convert.ToString(lecture["pro_lbc"]);
                p.Description = Convert.ToString(lecture["pro_lbl"]);
                p.Photo = Convert.ToString(lecture["pro_pho"]);
                p.Rubrique = Convert.ToString(lecture["ssrub_id"]);
                resultat.Add(p);
            }

            lecture.Close();
            connect.Close();
            return resultat;
        }
    }
}
