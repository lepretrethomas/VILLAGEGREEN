using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Maquette
{
    /// <summary>
    /// Logique d'interaction pour MenuGestion.xaml
    /// </summary>
    public partial class MenuGestion : Window
    {
        public MenuGestion()
        {
            InitializeComponent();
        }
        private void btn_quitter_Click(object sender, RoutedEventArgs e)
        {
            ConfirmeQuitter f = new ConfirmeQuitter();
            f.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            f.Owner = this;
            f.Show();
        }
        private void btn_clie_Click(object sender, RoutedEventArgs e)
        {
            GestionClient f = new GestionClient();
            f.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            f.Owner = this;
            f.Show();
            this.Hide();
        }

        private void btn_prod_Click(object sender, RoutedEventArgs e)
        {
            GestionProduit f = new GestionProduit();
            f.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            f.Owner = this;
            f.Show();
            this.Hide();
        }

        private void btn_comm_Click(object sender, RoutedEventArgs e)
        {
            GestionCommande f = new GestionCommande();
            f.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            f.Owner = this;
            f.Show();
            this.Hide();
        }

        private void btn_four_Click(object sender, RoutedEventArgs e)
        {
            GestionFournisseur f = new GestionFournisseur();
            f.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            f.Owner = this;
            f.Show();
            this.Hide();

        }

        private void btn_deconnexion_Click(object sender, RoutedEventArgs e)
        {
            Connexion f = new Connexion();
            f.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            f.Owner = this;
            f.Show();
            this.Hide();
        }

        private void btn_facture_Click(object sender, RoutedEventArgs e)
        {
            RechercheFacture f = new RechercheFacture();
            f.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            f.Owner = this;
            f.Show();
            this.Hide();
        }

        private void btn_livraison_Click(object sender, RoutedEventArgs e)
        {
            RechercheLivraison f = new RechercheLivraison();
            f.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            f.Owner = this;
            f.Show();
            this.Hide();
        }

        private void btn_catalogue_Click(object sender, RoutedEventArgs e)
        {
            Catalogue f = new Catalogue();
            f.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            f.Owner = this;
            f.Show();
            this.Hide();
        }

        private void btn_ca_Click(object sender, RoutedEventArgs e)
        {
            ChiffreAffaire f = new ChiffreAffaire();
            f.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            f.Owner = this;
            f.Show();
            this.Hide();
        }
    }
}
