using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Client
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string NomComplet
        {
            get
            {
                return Nom + " " + Prenom;
            }
        }
        public string Adresse { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        public string Telephone { get; set; }
        public string Fac_Adresse { get; set; }
        public string Fac_CodePostal { get; set; }
        public string Fac_Ville { get; set; }
        public string Liv_Adresse { get; set; }
        public string Liv_CodePostal { get; set; }
        public string Liv_Ville { get; set; }
        public string Statut { get; set; }
    }
}

