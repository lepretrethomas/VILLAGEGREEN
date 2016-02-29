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
    public partial class gestion_f : Form
    {
        bool ajouter = false;
        bool modifier = false;
        bool supprimer = false;
        bool voir = false;
        public gestion_f()
        {
            InitializeComponent();
            charger();
            non_modifiable();
            button_modifier.Enabled = false;
            button_supprimer.Enabled = false;
            label_cours.Text = "En attente";
        }
        private void charger()
        {
            FournisseurDAO fdao = new FournisseurDAO(GUI.Properties.Settings.Default.Serveur);
            listBox.DataSource = fdao.List();
            listBox.ValueMember = "Id";
            listBox.DisplayMember = "Nom";
        }
        private void nettoyer()
        {
            textBox_nom.Clear();
            textBox_prenom.Clear();
            textBox_adresse.Clear();
            textBox_cp.Clear();
            textBox_ville.Clear();
            textBox_tel.Clear();
            label_id.Text = "";
            textBox_nom.BackColor = SystemColors.ControlLight;
            textBox_prenom.BackColor = SystemColors.ControlLight;
            textBox_adresse.BackColor = SystemColors.ControlLight;
            textBox_cp.BackColor = SystemColors.ControlLight;
            textBox_ville.BackColor = SystemColors.ControlLight;
            textBox_tel.BackColor = SystemColors.ControlLight;
        }
        private void remplir()
        {
            FournisseurDAO fdao = new FournisseurDAO(GUI.Properties.Settings.Default.Serveur);
            Fournisseur f = fdao.FindbyId(Convert.ToInt32(listBox.SelectedValue));
            textBox_nom.Text = f.Nom;
            textBox_prenom.Text = f.Prenom;
            textBox_adresse.Text = f.Adresse;
            textBox_cp.Text = f.CodePostal;
            textBox_ville.Text = f.Ville;
            textBox_tel.Text = f.Telephone;
            label_id.Text = Convert.ToString(f.Id);
        }
        private void button_voir_Click(object sender, EventArgs e)
        {
            remplir();
            non_modifiable();
            voir = true;
            button_modifier.Enabled = true;
            button_supprimer.Enabled = true;
            label_cours.Text = "Visualisation";
            button_confirmer.Enabled = false;
            button_annuler.Enabled = false;
        }
        private void button_ajouter_Click(object sender, EventArgs e)
        {
            nettoyer();
            modifiable();
            textBox_nom.Focus();
            ajouter = true;
            button_modifier.Enabled = false;
            button_supprimer.Enabled = false;
            label_cours.Text = "Ajout";
            button_confirmer.Enabled = true;
            button_annuler.Enabled = true;
        }
        private void button_modifier_Click(object sender, EventArgs e)
        {
            remplir();
            modifiable();
            modifier = true;
            label_cours.Text = "Modification";
            button_confirmer.Enabled = true;
            button_annuler.Enabled = true;
        }
        private void button_supprimer_Click(object sender, EventArgs e)
        {
            remplir();
            non_modifiable();
            supprimer = true;
            label_cours.Text = "Suppression";
            button_confirmer.Enabled = true;
            button_annuler.Enabled = true;
        }
        private void button_annuler_Click(object sender, EventArgs e)
        {
            non_modifiable();
            nettoyer();
            button_modifier.Enabled = false;
            button_supprimer.Enabled = false;
            label_cours.Text = "En attente";
        }
        private void button_confirmer_Click(object sender, EventArgs e)
        {

            try
            {
                Fournisseur f = new Fournisseur();
                FournisseurDAO fdao = new FournisseurDAO(GUI.Properties.Settings.Default.Serveur);
                if (voir == true)
                {
                    f.Nom = textBox_nom.Text;
                    f.Prenom = textBox_prenom.Text;
                    f.Adresse = textBox_adresse.Text;
                    f.CodePostal = textBox_cp.Text;
                    f.Ville = textBox_ville.Text;
                    f.Telephone = textBox_tel.Text;
                }
                if (ajouter == true)
                {
                    modifier = false;
                    supprimer = false;
                    f.Nom = textBox_nom.Text;
                    f.Prenom = textBox_prenom.Text;
                    f.Adresse = textBox_adresse.Text;
                    f.CodePostal = textBox_cp.Text;
                    f.Ville = textBox_ville.Text;
                    f.Telephone = textBox_tel.Text;
                    try
                    {
                        fdao.Insert(f);
                        MessageBox.Show("Ajout effectué.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Un problème est survenu.", "Echec", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (modifier == true)
                {
                    ajouter = false;
                    supprimer = false;
                    f.Nom = textBox_nom.Text;
                    f.Prenom = textBox_prenom.Text;
                    f.Adresse = textBox_adresse.Text;
                    f.CodePostal = textBox_cp.Text;
                    f.Ville = textBox_ville.Text;
                    f.Telephone = textBox_tel.Text;
                    f.Id = (int)listBox.SelectedValue;
                    try
                    {
                        fdao.Update(f);
                        MessageBox.Show("Modification effectuée.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Un problème est survenu.", "Echec", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (supprimer == true)
                {
                    ajouter = false;
                    modifier = false;
                    f.Id = (int)listBox.SelectedValue;
                    try
                    {
                        fdao.Delete(f);
                        MessageBox.Show("Suppression effectuée.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Un problème est survenu.", "Echec", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                nettoyer();
                charger();
                button_modifier.Enabled = false;
                button_supprimer.Enabled = false;
                ajouter = false;
                modifier = false;
                supprimer = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Un problème est survenu.", "Echec", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button_liste_Click(object sender, EventArgs e)
        {
            charger();
        }
        private void non_modifiable()
        {
            textBox_nom.Enabled = false;
            textBox_prenom.Enabled = false;
            textBox_adresse.Enabled = false;
            textBox_cp.Enabled = false;
            textBox_ville.Enabled = false;
            textBox_tel.Enabled = false;
            textBox_nom.BackColor = SystemColors.ControlLight;
            textBox_prenom.BackColor = SystemColors.ControlLight;
            textBox_adresse.BackColor = SystemColors.ControlLight;
            textBox_cp.BackColor = SystemColors.ControlLight;
            textBox_ville.BackColor = SystemColors.ControlLight;
            textBox_tel.BackColor = SystemColors.ControlLight;
        }
        private void modifiable()
        {
            textBox_nom.Enabled = true;
            textBox_prenom.Enabled = true;
            textBox_adresse.Enabled = true;
            textBox_cp.Enabled = true;
            textBox_ville.Enabled = true;
            textBox_tel.Enabled = true;
            textBox_nom.BackColor = SystemColors.Window;
            textBox_prenom.BackColor = SystemColors.Window;
            textBox_adresse.BackColor = SystemColors.Window;
            textBox_cp.BackColor = SystemColors.Window;
            textBox_ville.BackColor = SystemColors.Window;
            textBox_tel.BackColor = SystemColors.Window;
        }
        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            nettoyer();
            non_modifiable();
            button_modifier.Enabled = false;
            button_supprimer.Enabled = false;
            label_cours.Text = "En attente";
            button_confirmer.Enabled = false;
            button_annuler.Enabled = false;
        }
        private void textBox_nom_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox_nom.Text, @"^[A-Za-z àäéèêëîïôöûùü'-]{1,50}$") == true)
            {
                textBox_nom.BackColor = SystemColors.Window;
                button_confirmer.Enabled = true;
            }
            else
            {
                textBox_nom.BackColor = Color.LightSalmon;
                button_confirmer.Enabled = false;
            }
        }
        private void textBox_prenom_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox_prenom.Text, @"^[A-Za-z àäéèêëîïôöûùü'-]{0,25}$") == true)
            {
                textBox_prenom.BackColor = SystemColors.Window;
                button_confirmer.Enabled = true;
            }
            else
            {
                textBox_prenom.BackColor = Color.LightSalmon;
                button_confirmer.Enabled = false;
            }
        }
        private void textBox_adresse_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox_adresse.Text, @"^[\w àäéèêëîïôöûùü'-.,]{1,100}$") == true)

            {
                textBox_adresse.BackColor = SystemColors.Window;
                button_confirmer.Enabled = true;
            }
            else
            {
                textBox_adresse.BackColor = Color.LightSalmon;
                button_confirmer.Enabled = false;
            }
        }
        private void textBox_cp_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox_cp.Text, @"^[\d]{5}$") == true)
            {
                textBox_cp.BackColor = SystemColors.Window;
                button_confirmer.Enabled = true;
            }
            else
            {
                textBox_cp.BackColor = Color.LightSalmon;
                button_confirmer.Enabled = false;
            }
        }
        private void textBox_ville_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox_ville.Text, @"^[\w àäéèêëîïôöûùü'-.,]{1,100}$") == true)
            {
                textBox_ville.BackColor = SystemColors.Window;
                button_confirmer.Enabled = true;
            }
            else
            {
                textBox_ville.BackColor = Color.LightSalmon;
                button_confirmer.Enabled = false;
            }
        }
        private void textBox_tel_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox_tel.Text, @"^[\d ]{10,16}$") == true)
            {
                textBox_tel.BackColor = SystemColors.Window;
                button_confirmer.Enabled = true;
            }
            else
            {
                textBox_tel.BackColor = Color.LightSalmon;
                button_confirmer.Enabled = false;
            }
        }
    }
}
