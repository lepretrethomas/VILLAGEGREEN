﻿using System;
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
    /// Logique d'interaction pour CreationCommande3.xaml
    /// </summary>
    public partial class CreationCommande3 : Window
    {
        public CreationCommande3()
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
            CreationCommande2 f = new CreationCommande2();
            f.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            f.Owner = this;
            f.Show();
            this.Hide();
        }

        private void btn_suivant_Click(object sender, RoutedEventArgs e)
        {
            CreationCommande4 f = new CreationCommande4();
            f.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            f.Owner = this;
            f.Show();
            this.Hide();
        }
    }
}

