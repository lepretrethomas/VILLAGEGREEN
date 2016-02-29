using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class FournisseurDAO
    {
        SqlConnection connect;

        public FournisseurDAO(string chaine)
        {
            connect = new SqlConnection(chaine);
        }

        public void Insert(Fournisseur f)
        {
            connect.Open();
            SqlCommand requete_insert = new SqlCommand("insert into FOUR (fou_nom, fou_pre, fou_adr, fou_cp, fou_vil, fou_tel)"
            + " values (@nom, @prenom, @adresse, @codepostal, @ville, @telephone)", connect);
            requete_insert.Parameters.AddWithValue("@nom", f.Nom);
            if (f.Prenom != "")
            {
                requete_insert.Parameters.AddWithValue("@prenom", f.Prenom);
            }
            else
            {
                requete_insert.Parameters.AddWithValue("@prenom", DBNull.Value);
            }
            requete_insert.Parameters.AddWithValue("@adresse", f.Adresse);
            requete_insert.Parameters.AddWithValue("@codepostal", f.CodePostal);
            requete_insert.Parameters.AddWithValue("@ville", f.Ville);
            requete_insert.Parameters.AddWithValue("@telephone", f.Telephone);
            requete_insert.ExecuteNonQuery();

            SqlCommand requete_id = new SqlCommand("select fou_id from FOUR where fou_nom = @nom", connect);
            requete_id.Parameters.AddWithValue("@nom", f.Nom);
            SqlDataReader resultat = requete_id.ExecuteReader();
            resultat.Read();
            int id = (int)resultat["fou_id"];
            f.Id = id;

            connect.Close();
        }

        public void Update(Fournisseur f)
        {
            connect.Open();
            SqlCommand requete_update = new SqlCommand("update FOUR set fou_nom = @nom, fou_pre = @prenom,"
            + " fou_cp = @codepostal, fou_adr = @adresse, fou_vil=@ville, fou_tel = @telephone"
            + " where fou_id = @id", connect);
            requete_update.Parameters.AddWithValue("@id", f.Id);
            requete_update.Parameters.AddWithValue("@nom", f.Nom);
            if (f.Prenom != "")
            {
                requete_update.Parameters.AddWithValue("@prenom", f.Prenom);
            }
            else
            {
                requete_update.Parameters.AddWithValue("@prenom", DBNull.Value);
            }
            requete_update.Parameters.AddWithValue("@adresse", f.Adresse);
            requete_update.Parameters.AddWithValue("@codepostal", f.CodePostal);
            requete_update.Parameters.AddWithValue("@ville", f.Ville);
            requete_update.Parameters.AddWithValue("@telephone", f.Telephone);
            requete_update.ExecuteNonQuery();
            connect.Close();
        }

        public void Delete(Fournisseur f)
        {
            connect.Open();
            SqlCommand requete_delete = new SqlCommand("delete from FOUR where fou_id = @id", connect);
            requete_delete.Parameters.AddWithValue("@id", f.Id);
            requete_delete.ExecuteNonQuery();
            connect.Close();
        }

        public Fournisseur FindbyId(int id)
        {
            connect.Open();
            Fournisseur f = null;
            SqlCommand requete_find = new SqlCommand("select * from FOUR where fou_id = @id", connect);
            requete_find.Parameters.AddWithValue("@id", id);
            SqlDataReader lecture = requete_find.ExecuteReader();

            if (lecture.Read())
            {
                f = new Fournisseur();
                f.Id = Convert.ToInt32(lecture["fou_id"]);
                f.Nom = Convert.ToString(lecture["fou_nom"]);
                f.Prenom = Convert.ToString(lecture["fou_pre"]);
                f.Adresse = Convert.ToString(lecture["fou_adr"]);
                f.CodePostal = Convert.ToString(lecture["fou_cp"]);
                f.Ville = Convert.ToString(lecture["fou_vil"]);
                f.Telephone = Convert.ToString(lecture["fou_tel"]);
            }

            lecture.Close();
            connect.Close();
            return f;
        }
        public Fournisseur FindbyName(string nom)
        {
            connect.Open();
            Fournisseur f = null;
            SqlCommand requete_find = new SqlCommand("select * from FOUR where fou_nom = @nom", connect);
            requete_find.Parameters.AddWithValue("@nom", nom);
            SqlDataReader lecture = requete_find.ExecuteReader();

            if (lecture.Read())
            {
                f = new Fournisseur();
                f.Id = Convert.ToInt32(lecture["fou_id"]);
                f.Nom = Convert.ToString(lecture["fou_nom"]);
                f.Prenom = Convert.ToString(lecture["fou_pre"]);
                f.Adresse = Convert.ToString(lecture["fou_adr"]);
                f.CodePostal = Convert.ToString(lecture["fou_cp"]);
                f.Ville = Convert.ToString(lecture["fou_vil"]);
                f.Telephone = Convert.ToString(lecture["fou_tel"]);
            }

            lecture.Close();
            connect.Close();
            return f;
        }

        public List<Fournisseur> List()
        {
            connect.Open();
            List<Fournisseur> resultat = new List<Fournisseur>();
            SqlCommand requete_list = new SqlCommand("select * from FOUR", connect);
            SqlDataReader lecture = requete_list.ExecuteReader();

            while (lecture.Read())
            {
                Fournisseur f = new Fournisseur();
                f.Id = Convert.ToInt32(lecture["fou_id"]);
                f.Nom = Convert.ToString(lecture["fou_nom"]);
                f.Prenom = Convert.ToString(lecture["fou_pre"]);
                f.Adresse = Convert.ToString(lecture["fou_adr"]);
                f.CodePostal = Convert.ToString(lecture["fou_cp"]);
                f.Ville = Convert.ToString(lecture["fou_vil"]);
                f.Telephone = Convert.ToString(lecture["fou_tel"]);
                resultat.Add(f);
            }

            lecture.Close();
            connect.Close();
            return resultat;
        }
        public List<Fournisseur> Recherche(string recherche)
        {
            List<Fournisseur> resultat = new List<Fournisseur>();

            connect.Open();

            SqlCommand requete_statut = new SqlCommand(@"Select * from FOUR where fou_nom like '%" + recherche + "%'", connect);

            SqlDataReader lecture = requete_statut.ExecuteReader();

            while (lecture.Read())
            {
                Fournisseur f = new Fournisseur();
                f.Id = Convert.ToInt32(lecture["fou_id"]);
                f.Nom = Convert.ToString(lecture["fou_nom"]);
                f.Prenom = Convert.ToString(lecture["fou_pre"]);
                f.Adresse = Convert.ToString(lecture["fou_adr"]);
                f.CodePostal = Convert.ToString(lecture["fou_cp"]);
                f.Ville = Convert.ToString(lecture["fou_vil"]);
                f.Telephone = Convert.ToString(lecture["fou_tel"]);
                resultat.Add(f);
            }
            lecture.Close();
            connect.Close();
            return resultat;
        }
    }
}
