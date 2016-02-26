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

        private void button1_Click(object sender, EventArgs e)
        {
            gestion_c f = new gestion_c();
            f.Owner = this;
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gestion_f f = new gestion_f();
            f.Owner = this;
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            gestion_p f = new gestion_p();
            f.Owner = this;
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mail f = new mail();
            f.Owner = this;
            f.Show();
        }
    }
}
