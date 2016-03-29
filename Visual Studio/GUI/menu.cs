using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void button_client_Click(object sender, EventArgs e)
        {
            gestion_c f = new gestion_c();
            f.Owner = this;
            f.Show();
        }

        private void button_fournisseur_Click(object sender, EventArgs e)
        {
            gestion_f f = new gestion_f();
            f.Owner = this;
            f.Show();
        }

        private void button_produit_Click(object sender, EventArgs e)
        {
            gestion_p f = new gestion_p();
            f.Owner = this;
            f.Show();
        }

        private void button_ca_Click(object sender, EventArgs e)
        {
            chiffreaffaire f = new chiffreaffaire();
            f.Owner = this;
            f.Show();
        }

        private void button_quitter_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Etes-vous sûrs de vouloir quitter?", "Fin", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button_deco_Click(object sender, EventArgs e)
        {
            start f = new start();
            this.Visible = false;
            f.ShowDialog();
            this.Close();
        }

        private void menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
