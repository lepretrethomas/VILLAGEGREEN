using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Commande
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Etat { get; set; }
        public string Total { get; set; }
        public string Client { get; set; }
    }
}
