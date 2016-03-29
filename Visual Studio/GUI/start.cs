using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GUI
{
    public partial class start : Form
    {
        SqlConnection connect = new SqlConnection(GUI.Properties.Settings.Default.Serveur);
        public start()
        {
            InitializeComponent();
            button_start.Hide();
            button_restart.Hide();
            connection();
        }
        public void connection()
        {
            try
            {
                connect.Open();
                label_resultatconnection.Text = connect.State.ToString();
                label_resultatconnection.ForeColor = Color.Green;
                textBox_messageconnection.Text = "La connection a pu être établie, vous pouvez lancer l'application.";
                button_start.Show();
                button_restart.Hide();
            }
            catch (Exception)
            {
                label_resultatconnection.Text = connect.State.ToString();
                label_resultatconnection.ForeColor = Color.Red;
                textBox_messageconnection.Text = "Un problème est survenu.\nVeuillez vérifier votre connection ou la disponibilité de la base de données VillageGreen, puis recommencez.";
                button_restart.Show();
            }
            connect.Close();
        }
        private void button_quitter_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Etes-vous sûrs de vouloir quitter?", "Fin", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            button_start.Hide();
            label_identifiant.Show();
            label_password.Show();
            textBox_identifiant.Show();
            textBox_identifiant.Focus();
            textBox_password.Show();
            button_connect.Show();
            button_cancel.Show();

        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            menu f = new menu();
            this.Visible = false;
            f.ShowDialog();
            this.Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            button_start.Show();
            label_identifiant.Hide();
            label_password.Hide();
            textBox_identifiant.Hide();
            textBox_password.Hide();
            button_connect.Hide();
            button_cancel.Hide();
        }

        private void start_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button_restart_Click(object sender, EventArgs e)
        {
            connection();
        }
    }
}
