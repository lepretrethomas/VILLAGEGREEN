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
    /// Logique d'interaction pour ChiffreAffaire.xaml
    /// </summary>
    public partial class ChiffreAffaire : Window
    {
        public ChiffreAffaire()
        {
            InitializeComponent();
        }

        private void btn_menu_Click(object sender, RoutedEventArgs e)
        {
            MenuGestion f = new MenuGestion();
            f.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            f.Owner = this;
            f.Show();
        }

        private void btn_quitter_Click(object sender, RoutedEventArgs e)
        {
            ConfirmeQuitter f = new ConfirmeQuitter();
            f.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            f.Owner = this;
            f.Show();
        }
    }
}
