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
    /// Logique d'interaction pour CreationCommande4.xaml
    /// </summary>
    public partial class CreationCommande4 : Window
    {
        public CreationCommande4()
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
            GestionCommande f = new GestionCommande();
            f.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            f.Owner = this;
            f.Show();
            this.Hide();
        }
        private void btn_precedent_Click(object sender, RoutedEventArgs e)
        {
            CreationCommande3 f = new CreationCommande3();
            f.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            f.Owner = this;
            f.Show();
            this.Hide();
        }

        private void btn_terminer_Click(object sender, RoutedEventArgs e)
        {
            ConfirmeCommande f = new ConfirmeCommande();
            f.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            f.Owner = this;
            f.Show();
        }
    }
}
