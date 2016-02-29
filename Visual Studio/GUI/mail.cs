using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace GUI
{
    public partial class mail : Form
    {
        public mail()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox1.Text, @"^[a-z0-9._-]{2,}@[a-z0-9]{2,}\.[a-z]{2,}$") == true)
            {
                label2.Text = "Correct";
            }
            else
            {
                label2.Text = "Incorrect";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                label4.Text = "Le champ texte est vide...";
            }
            else
            {
                label4.Text = Verification(textBox1.Text);
            }
        }
        public static string Verification(string email)
        {
            string resultat = "";
            try
            {
                int a = email.IndexOf("@");
                if (a == -1)
                {
                    resultat = "Le caractère '@' est manquant.";
                }
                else
                {
                    //email = partieA + '@' + partieB
                    //partieB = elementA + '.' + elementB
                    string partieA = email.Substring(0, a);
                    string partieB = email.Substring(a + 1);
                    if (partieA.Length < 2)
                    {
                        resultat = "Deux caractères minimums avant '@'.";
                    }
                    else if (partieB.Length < 2)
                    {
                        resultat = "Deux caractères minimums après '@'.";
                    }
                    else
                    {
                        int p = partieB.IndexOf(".");
                        if (p == -1)
                        {
                            resultat = "Le caractère '.' est manquant.";
                        }
                        else
                        {
                            string elementA = partieB.Substring(0, p);
                            string elementB = partieB.Substring(p + 1);
                            if (elementA.Length < 2)
                            {
                                resultat = "Deux caractères minimums avant '.'.";
                            }
                            else if (elementB.Length < 2)
                            {
                                resultat = "Deux caractères minimums après '.'.";
                            }
                            else
                            {
                                resultat = "";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Echec");
            }
            return resultat;
        }
    }
}
