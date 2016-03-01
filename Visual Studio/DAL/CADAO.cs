using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class CADAO
    {
        SqlConnection connect;

        public CADAO(string chaine)
        {
            connect = new SqlConnection(chaine);
        }
        public CA ParTypeClient(string nom)
        {
            connect.Open();
            CA c = null;
            SqlCommand requete_ca = new SqlCommand(@"select CA from CA_Cat_Client where CATEGORIE = @nom", connect);
            requete_ca.Parameters.AddWithValue("@nom", nom);
            SqlDataReader lecture = requete_ca.ExecuteReader();

            if (lecture.Read())
            {
                c = new CA();
                c.ChiffreAffaire = Convert.ToInt32(lecture["CA"]);
            }

            lecture.Close();
            connect.Close();
            return c;
        }
        public CA AllClient()
        {
            connect.Open();
            CA c = null;
            SqlCommand requete_ca = new SqlCommand(@"select * from CA_All_Client", connect);
            SqlDataReader lecture = requete_ca.ExecuteReader();

            if (lecture.Read())
            {
                c = new CA();
                c.ChiffreAffaire = Convert.ToInt32(lecture["CA"]);
            }

            lecture.Close();
            connect.Close();
            return c;
        }
        public CA ParFournisseur(int id)
        {
            connect.Open();
            CA c = null;
            SqlCommand requete_ca = new SqlCommand(@"select * from CA_Fournisseur where FOURNISSEUR = @id", connect);
            requete_ca.Parameters.AddWithValue("@id", id);
            SqlDataReader lecture = requete_ca.ExecuteReader();

            if (lecture.Read())
            {
                c = new CA();
                c.ChiffreAffaire = Convert.ToInt32(lecture["CA"]);
            }

            lecture.Close();
            connect.Close();
            return c;
        }
        public CA AllFournisseur()
        {
            connect.Open();
            CA c = null;
            SqlCommand requete_ca = new SqlCommand(@"select * from CA_All_Fournisseur", connect);
            SqlDataReader lecture = requete_ca.ExecuteReader();

            if (lecture.Read())
            {
                c = new CA();
                c.ChiffreAffaire = Convert.ToInt32(lecture["CA"]);
            }

            lecture.Close();
            connect.Close();
            return c;
        }

    }
}
