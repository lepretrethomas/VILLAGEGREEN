using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using System.Text.RegularExpressions;

namespace GUI
{
    public partial class chiffreaffaire : Form
    {
        public chiffreaffaire()
        {
            InitializeComponent();
            charger_liste_fournisseur();
            comboBox1.SelectedIndex = -1;
        }
        public void charger_liste_fournisseur()
        {
            FournisseurDAO fdao = new FournisseurDAO(GUI.Properties.Settings.Default.Serveur);
            comboBox1.DataSource = fdao.List();
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Nom";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                CADAO cdao = new CADAO(GUI.Properties.Settings.Default.Serveur);
                CA c = cdao.ParTypeClient("Particulier");
                label2.Text = c.ChiffreAffaire.ToString();
                comboBox1.SelectedIndex = -1;
            }
            catch (Exception)
            {
                MessageBox.Show("Un problème est survenu.", "Echec", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                CADAO cdao = new CADAO(GUI.Properties.Settings.Default.Serveur);
                CA c = cdao.ParTypeClient("Professionnel");
                label2.Text = c.ChiffreAffaire.ToString();
                comboBox1.SelectedIndex = -1;
            }
            catch (Exception)
            {
                MessageBox.Show("Un problème est survenu.", "Echec", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                CADAO cdao = new CADAO(GUI.Properties.Settings.Default.Serveur);
                CA c = cdao.AllClient();
                label2.Text = c.ChiffreAffaire.ToString();
                comboBox1.SelectedIndex = -1;
            }
            catch (Exception)
            {
                MessageBox.Show("Un problème est survenu.", "Echec", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                CADAO cdao = new CADAO(GUI.Properties.Settings.Default.Serveur);
                CA c = cdao.AllFournisseur();
                label2.Text = c.ChiffreAffaire.ToString();
                comboBox1.SelectedIndex = -1;
            }
            catch (Exception)
            {
                MessageBox.Show("Un problème est survenu.", "Echec", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                CADAO cdao = new CADAO(GUI.Properties.Settings.Default.Serveur);
                CA c = cdao.ParFournisseur(Convert.ToInt32(comboBox1.SelectedValue));
                label2.Text = c.ChiffreAffaire.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Un problème est survenu.", "Echec", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                button5.Enabled = false;
            }
            else
            {
                button5.Enabled = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
