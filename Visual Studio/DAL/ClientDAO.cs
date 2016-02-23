using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class ClientDAO
    {
        SqlConnection connect;

        public ClientDAO(string chaine)
        {
            connect = new SqlConnection(chaine);
        }

        public void Insert(Client c)
        {
            connect.Open();
            SqlCommand requete_insert = new SqlCommand("insert into CLIE (cli_nom, cli_pre, cli_adr, cli_cp, cli_vil, cli_tel,"
            + " fac_adr, fac_cp, fac_vil, liv_adr, liv_cp, liv_vil, sta_id)"
            + " values (@nom, @prenom, @adresse, @codepostal, @ville, @telephone,"
            + " @adresse_f, @codepostal_f, @ville_f, @adresse_l, @codepostal_l, @ville_l, @statut)", connect);
            requete_insert.Parameters.AddWithValue("@nom", c.Nom);
            requete_insert.Parameters.AddWithValue("@prenom", c.Prenom);
            requete_insert.Parameters.AddWithValue("@adresse", c.Adresse);
            requete_insert.Parameters.AddWithValue("@codepostal", c.CodePostal);
            requete_insert.Parameters.AddWithValue("@ville", c.Ville);
            requete_insert.Parameters.AddWithValue("@telephone", c.Telephone);
            requete_insert.Parameters.AddWithValue("@adresse_f", c.Fac_Adresse);
            requete_insert.Parameters.AddWithValue("@codepostal_f", c.Fac_CodePostal);
            requete_insert.Parameters.AddWithValue("@ville_f", c.Fac_Ville);
            requete_insert.Parameters.AddWithValue("@adresse_l", c.Liv_Adresse);
            requete_insert.Parameters.AddWithValue("@codepostal_l", c.Liv_CodePostal);
            requete_insert.Parameters.AddWithValue("@ville_l", c.Liv_Ville);
            requete_insert.Parameters.AddWithValue("@statut", c.Statut);
            requete_insert.ExecuteNonQuery();

            SqlCommand requete_id = new SqlCommand("select cli_id from CLIE where cli_nom = @nom", connect);
            requete_id.Parameters.AddWithValue("@nom", c.Nom);
            SqlDataReader resultat = requete_id.ExecuteReader();
            resultat.Read();
            int id = (int)resultat["cli_id"];
            c.Id = id;

            connect.Close();
        }

        public void Update(Client c)
        {
            connect.Open();
            SqlCommand requete_update = new SqlCommand("update CLIE set cli_nom = @nom, cli_pre = @prenom,"
            + " cli_cp = @codepostal, cli_adr = @adresse, cli_vil =@ville, cli_tel = @telephone,"
            + " fac_adr = @adresse_f, fac_cp = @codepostal_f, fac_vil = @ville_f,"
            + " liv_adr = @adresse_l, liv_cp = @codepostal_l, liv_vil = @ville_l, sta_id = @statut"
            + " where cli_id = @id", connect);
            requete_update.Parameters.AddWithValue("@id", c.Id);
            requete_update.Parameters.AddWithValue("@nom", c.Nom);
            requete_update.Parameters.AddWithValue("@prenom", c.Prenom);
            requete_update.Parameters.AddWithValue("@adresse", c.Adresse);
            requete_update.Parameters.AddWithValue("@codepostal", c.CodePostal);
            requete_update.Parameters.AddWithValue("@ville", c.Ville);
            requete_update.Parameters.AddWithValue("@telephone", c.Telephone);
            requete_update.Parameters.AddWithValue("@adresse_f", c.Fac_Adresse);
            requete_update.Parameters.AddWithValue("@codepostal_f", c.Fac_CodePostal);
            requete_update.Parameters.AddWithValue("@ville_f", c.Fac_Ville);
            requete_update.Parameters.AddWithValue("@adresse_l", c.Liv_Adresse);
            requete_update.Parameters.AddWithValue("@codepostal_l", c.Liv_CodePostal);
            requete_update.Parameters.AddWithValue("@ville_l", c.Liv_Ville);
            requete_update.Parameters.AddWithValue("@statut", c.Statut);
            requete_update.ExecuteNonQuery();
            connect.Close();
        }

        public void Delete(Client c)
        {
            connect.Open();
            SqlCommand requete_delete = new SqlCommand("delete from CLIE where cli_id = @id", connect);
            requete_delete.Parameters.AddWithValue("@id", c.Id);
            requete_delete.ExecuteNonQuery();
            connect.Close();
        }

        public Client Find(int id)
        {
            connect.Open();
            Client c = null;
            SqlCommand requete_find = new SqlCommand("select * from CLIE where cli_id = @id", connect);
            requete_find.Parameters.AddWithValue("@id", id);
            SqlDataReader lecture = requete_find.ExecuteReader();

            if (lecture.Read())
            {
                c = new Client();
                c.Id = Convert.ToInt32(lecture["cli_id"]);
                c.Nom = Convert.ToString(lecture["cli_nom"]);
                c.Prenom = Convert.ToString(lecture["cli_pre"]);
                c.Adresse = Convert.ToString(lecture["cli_adr"]);
                c.CodePostal = Convert.ToString(lecture["cli_cp"]);
                c.Ville = Convert.ToString(lecture["cli_vil"]);
                c.Telephone = Convert.ToString(lecture["cli_tel"]);
                c.Fac_Adresse = Convert.ToString(lecture["fac_adr"]);
                c.Fac_CodePostal = Convert.ToString(lecture["fac_cp"]);
                c.Fac_Ville = Convert.ToString(lecture["fac_vil"]);
                c.Liv_Adresse = Convert.ToString(lecture["liv_adr"]);
                c.Liv_CodePostal = Convert.ToString(lecture["liv_cp"]);
                c.Liv_Ville = Convert.ToString(lecture["liv_vil"]);
                c.Statut = Convert.ToString(lecture["sta_id"]);
            }

            lecture.Close();
            connect.Close();
            return c;
        }

        public List<Client> List()
        {
            connect.Open();
            List<Client> resultat = new List<Client>();
            SqlCommand requete_list = new SqlCommand("select * from CLIE", connect);
            SqlDataReader lecture = requete_list.ExecuteReader();

            while (lecture.Read())
            {
                Client c = new Client();
                c.Id = Convert.ToInt32(lecture["cli_id"]);
                c.Nom = Convert.ToString(lecture["cli_nom"]);
                c.Prenom = Convert.ToString(lecture["cli_pre"]);
                c.Adresse = Convert.ToString(lecture["cli_adr"]);
                c.CodePostal = Convert.ToString(lecture["cli_cp"]);
                c.Ville = Convert.ToString(lecture["cli_vil"]);
                c.Telephone = Convert.ToString(lecture["cli_tel"]);
                c.Fac_Adresse = Convert.ToString(lecture["fac_adr"]);
                c.Fac_CodePostal = Convert.ToString(lecture["fac_cp"]);
                c.Fac_Ville = Convert.ToString(lecture["fac_vil"]);
                c.Liv_Adresse = Convert.ToString(lecture["liv_adr"]);
                c.Liv_CodePostal = Convert.ToString(lecture["liv_cp"]);
                c.Liv_Ville = Convert.ToString(lecture["liv_vil"]);
                c.Statut = Convert.ToString(lecture["sta_id"]);
                resultat.Add(c);
            }

            lecture.Close();
            connect.Close();
            return resultat;
        }
    }
}
