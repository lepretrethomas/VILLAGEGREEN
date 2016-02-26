using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Produit
    {
        public int Id { get; set; }
        public int Fournisseur { get; set; }
        public string Libelle { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public int Rubrique { get; set; }
    }
}
