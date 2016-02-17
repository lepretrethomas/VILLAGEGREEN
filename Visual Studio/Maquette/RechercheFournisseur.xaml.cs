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
    /// Logique d'interaction pour RechercheFournisseur.xaml
    /// </summary>
    public partial class RechercheFournisseur : Window
    {
        public RechercheFournisseur()
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
        private void btn_annuler_Click(object sender, RoutedEventArgs e)
        {
            GestionFournisseur f = new GestionFournisseur();
            f.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            f.Owner = this;
            f.Show();
            this.Hide();
        }

        private void btn_suivant_Click(object sender, RoutedEventArgs e)
        {
            FicheFournisseur f = new FicheFournisseur();
            f.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            f.Owner = this;
            f.Show();
            this.Hide();
        }
    }
}
