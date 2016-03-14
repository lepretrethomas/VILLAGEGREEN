using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class RubriqueDAO
    {
        SqlConnection connect;

        public RubriqueDAO(string chaine)
        {
            connect = new SqlConnection(chaine);
        }

        public void Insert(Rubrique r)
        {
            connect.Open();
            SqlCommand requete_insert = new SqlCommand("insert into RUB1 (ru1_nom)"
            + " values (@nom)", connect);
            requete_insert.Parameters.AddWithValue("@nom", r.Nom);
            requete_insert.ExecuteNonQuery();

            SqlCommand requete_id = new SqlCommand("select ru1_id from RUB1 where ru1_nom = @nom", connect);
            requete_id.Parameters.AddWithValue("@nom", r.Nom);
            SqlDataReader resultat = requete_id.ExecuteReader();
            resultat.Read();
            int id = (int)resultat["ru1_id"];
            r.Id = id;

            connect.Close();
        }

        public void Update(Rubrique r)
        {
            connect.Open();
            SqlCommand requete_update = new SqlCommand("update RUB1 set ru1_nom = @nom where ru1_id = @id", connect);
            requete_update.Parameters.AddWithValue("@nom", r.Nom);
            requete_update.ExecuteNonQuery();
            connect.Close();
        }

        public void Delete(Rubrique r)
        {
            connect.Open();
            SqlCommand requete_delete = new SqlCommand("delete from RUB1 where ru1_id = @id", connect);
            requete_delete.Parameters.AddWithValue("@id", r.Id);
            requete_delete.ExecuteNonQuery();
            connect.Close();
        }

        public Rubrique Find(int id)
        {
            connect.Open();
            Rubrique r = null;
            SqlCommand requete_find = new SqlCommand("select * from RUB1 where ru1_id = @id", connect);
            requete_find.Parameters.AddWithValue("@id", id);
            SqlDataReader lecture = requete_find.ExecuteReader();

            if (lecture.Read())
            {
                r = new Rubrique();
                r.Id = Convert.ToInt32(lecture["pro_id"]);
                r.Nom = Convert.ToString(lecture["fou_id"]);
            }

            lecture.Close();
            connect.Close();
            return r;
        }

        public List<Rubrique> List()
        {
            connect.Open();
            List<Rubrique> resultat = new List<Rubrique>();
            SqlCommand requete_list = new SqlCommand("select * from RUB1 order by ru1_nom", connect);
            SqlDataReader lecture = requete_list.ExecuteReader();

            while (lecture.Read())
            {
                Rubrique r = new Rubrique();
                r.Id = Convert.ToInt32(lecture["ru1_id"]);
                r.Nom = Convert.ToString(lecture["ru1_nom"]);
                resultat.Add(r);
            }

            lecture.Close();
            connect.Close();
            return resultat;
        }
    }
}
