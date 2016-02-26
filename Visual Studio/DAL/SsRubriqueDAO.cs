using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class SsRubriqueDAO
    {
        SqlConnection connect;

        public SsRubriqueDAO(string chaine)
        {
            connect = new SqlConnection(chaine);
        }

        public void Insert(SsRubrique r)
        {
            connect.Open();
            SqlCommand requete_insert = new SqlCommand("insert into SCAT (ssrub_nom, rub_id)"
            + " values (@nom, @rubid)", connect);
            requete_insert.Parameters.AddWithValue("@nom", r.Nom);
            requete_insert.Parameters.AddWithValue("@rubid", r.RubId);
            requete_insert.ExecuteNonQuery();

            SqlCommand requete_id = new SqlCommand("select ssrub_id from SCAT where ssrub_nom = @nom", connect);
            requete_id.Parameters.AddWithValue("@nom", r.Nom);
            SqlDataReader resultat = requete_id.ExecuteReader();
            resultat.Read();
            int id = (int)resultat["ssrub_id"];
            r.Id = id;

            connect.Close();
        }

        public void Update(SsRubrique r)
        {
            connect.Open();
            SqlCommand requete_update = new SqlCommand(@"update SCAT set ssrub_nom = @nom, rub_id = @rubid
                                                        where ssrub_id = @id", connect);
            requete_update.Parameters.AddWithValue("@nom", r.Nom);
            requete_update.Parameters.AddWithValue("@rubid", r.RubId);
            requete_update.ExecuteNonQuery();
            connect.Close();
        }

        public void Delete(SsRubrique r)
        {
            connect.Open();
            SqlCommand requete_delete = new SqlCommand("delete from SCAT where ssrub_id = @id", connect);
            requete_delete.Parameters.AddWithValue("@id", r.Id);
            requete_delete.ExecuteNonQuery();
            connect.Close();
        }

        public SsRubrique Find(int id)
        {
            connect.Open();
            SsRubrique r = null;
            SqlCommand requete_find = new SqlCommand("select * from SCAT where ssrub_id = @id", connect);
            requete_find.Parameters.AddWithValue("@id", id);
            SqlDataReader lecture = requete_find.ExecuteReader();

            if (lecture.Read())
            {
                r = new SsRubrique();
                r.Id = Convert.ToInt32(lecture["ssrub_id"]);
                r.Nom = Convert.ToString(lecture["ssrub_nom"]);
                r.RubId = Convert.ToInt32(lecture["rub_id"]);
            }

            lecture.Close();
            connect.Close();
            return r;
        }

        public List<SsRubrique> List()
        {
            connect.Open();
            List<SsRubrique> resultat = new List<SsRubrique>();
            SqlCommand requete_list = new SqlCommand("select * from SCAT", connect);
            SqlDataReader lecture = requete_list.ExecuteReader();

            while (lecture.Read())
            {
                SsRubrique r = new SsRubrique();
                r.Id = Convert.ToInt32(lecture["ssrub_id"]);
                r.Nom = Convert.ToString(lecture["ssrub_nom"]);
                r.RubId = Convert.ToInt32(lecture["rub_id"]);
                resultat.Add(r);
            }

            lecture.Close();
            connect.Close();
            return resultat;
        }
        public List<SsRubrique> ParRubrique(int rub)
        {
            List<SsRubrique> resultat = new List<SsRubrique>();
            connect.Open();
            SqlCommand requete_statut = new SqlCommand(@"Select * from SCAT
                                                        where SCAT.rub_id = @rubid", connect);
            requete_statut.Parameters.AddWithValue("@rubid", rub);
            SqlDataReader lecture = requete_statut.ExecuteReader();
            while (lecture.Read())
            {
                SsRubrique sr = new SsRubrique();
                sr.Id = Convert.ToInt32(lecture["ssrub_id"]);
                sr.Nom = Convert.ToString(lecture["ssrub_nom"]);
                sr.RubId = Convert.ToInt32(lecture["rub_id"]);
                resultat.Add(sr);
            }
            lecture.Close();
            connect.Close();
            return resultat;
        }
    }
}
