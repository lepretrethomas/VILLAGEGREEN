using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class CommandeDAO
    {
        SqlConnection connect;

        public CommandeDAO(string chaine)
        {
            connect = new SqlConnection(chaine);
        }
        public List<Commande> ParIdClient(int id)
        {
            List<Commande> resultat = new List<Commande>();
            connect.Open();
            Commande c = null;
            SqlCommand requete_find = new SqlCommand(@"select * from COMM
                                                    where cli_id = @id", connect);
            requete_find.Parameters.AddWithValue("@id", id);
            SqlDataReader lecture = requete_find.ExecuteReader();

            while (lecture.Read())
            {
                c = new Commande();
                c.Id = Convert.ToInt32(lecture["com_id"]);
                c.Date = Convert.ToDateTime(lecture["com_dat"]);
                c.Etat = Convert.ToString(lecture["com_eta"]);
                c.Total = Convert.ToDecimal(lecture["com_tot"]);
                c.Client = Convert.ToString(lecture["cli_id"]);
                resultat.Add(c);
            }

            lecture.Close();
            connect.Close();
            return resultat;
        }
    }
}
