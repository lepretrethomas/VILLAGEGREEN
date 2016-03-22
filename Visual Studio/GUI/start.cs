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
    public partial class start : Form
    {
        public start()
        {
            InitializeComponent();
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
            f.Owner = this;
            f.Show();
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
    }
}
