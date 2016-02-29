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
using System.Data.SqlClient;

namespace GUI
{
    public partial class gestion_c : Form
    {
        bool ajouter = false;
        bool modifier = false;
        bool supprimer = false;
        bool voir = false;
        public gestion_c()
        {
            InitializeComponent();
            Height = 475;
            Width = 900;
            charger();
            non_modifiable();
            button_modifier.Enabled = false;
            button_supprimer.Enabled = false;
            button_commande.Enabled = false;
            label_cours.Text = "En attente";
        }
        private void charger()
        {
            ClientDAO cdao = new ClientDAO(GUI.Properties.Settings.Default.Serveur);
            listBox.DataSource = cdao.List();
            listBox.ValueMember = "Id";
            listBox.DisplayMember = "Nom";
        }
        private void button_pro_Click(object sender, EventArgs e)
        {
            ClientDAO cdao = new ClientDAO(GUI.Properties.Settings.Default.Serveur);
            listBox.DataSource = cdao.ParStatut(1);
            listBox.ValueMember = "Id";
            listBox.DisplayMember = "Nom";
        }
        private void button_par_Click(object sender, EventArgs e)
        {
            ClientDAO cdao = new ClientDAO(GUI.Properties.Settings.Default.Serveur);
            listBox.DataSource = cdao.ParStatut(2);
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
            textBox_fac_adresse.Clear();
            textBox_fac_cp.Clear();
            textBox_fac_ville.Clear();
            textBox_liv_adresse.Clear();
            textBox_liv_cp.Clear();
            textBox_liv_ville.Clear();
            textBox_categorie.Clear();
            label_statut.Text = "";
            label_id.Text = "";
            textBox_categorie.BackColor = SystemColors.ControlLight;
            textBox_nom.BackColor = SystemColors.ControlLight;
            textBox_prenom.BackColor = SystemColors.ControlLight;
            textBox_adresse.BackColor = SystemColors.ControlLight;
            textBox_cp.BackColor = SystemColors.ControlLight;
            textBox_ville.BackColor = SystemColors.ControlLight;
            textBox_tel.BackColor = SystemColors.ControlLight;
            textBox_fac_adresse.BackColor = SystemColors.ControlLight;
            textBox_fac_cp.BackColor = SystemColors.ControlLight;
            textBox_fac_ville.BackColor = SystemColors.ControlLight;
            textBox_liv_adresse.BackColor = SystemColors.ControlLight;
            textBox_liv_cp.BackColor = SystemColors.ControlLight;
            textBox_liv_ville.BackColor = SystemColors.ControlLight;
        }
        private void remplir()
        {
            ClientDAO cdao = new ClientDAO(GUI.Properties.Settings.Default.Serveur);
            Client c = cdao.FindbyId(Convert.ToInt32(listBox.SelectedValue));
            textBox_nom.Text = c.Nom;
            textBox_prenom.Text = c.Prenom;
            textBox_adresse.Text = c.Adresse;
            textBox_cp.Text = c.CodePostal;
            textBox_ville.Text = c.Ville;
            textBox_tel.Text = c.Telephone;
            textBox_fac_adresse.Text = c.Fac_Adresse;
            textBox_fac_cp.Text = c.Fac_CodePostal;
            textBox_fac_ville.Text = c.Fac_Ville;
            textBox_liv_adresse.Text = c.Liv_Adresse;
            textBox_liv_cp.Text = c.Liv_CodePostal;
            textBox_liv_ville.Text = c.Liv_Ville;
            textBox_categorie.Text = c.Statut;
            label_id.Text = Convert.ToString(c.Id);
        }
        private void button_voir_Click(object sender, EventArgs e)
        {
            remplir();
            non_modifiable();
            voir = true;
            button_modifier.Enabled = true;
            button_supprimer.Enabled = true;
            button_commande.Enabled = true;
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
            button_commande.Enabled = false;
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
            button_commande.Enabled = false;
            label_cours.Text = "En attente";
        }
        private void button_confirmer_Click(object sender, EventArgs e)
        {

            try
            {
                Client c = new Client();
                ClientDAO cdao = new ClientDAO(GUI.Properties.Settings.Default.Serveur);
                if (voir == true)
                {
                    c.Nom = textBox_nom.Text;
                    c.Prenom = textBox_prenom.Text;
                    c.Adresse = textBox_adresse.Text;
                    c.CodePostal = textBox_cp.Text;
                    c.Ville = textBox_ville.Text;
                    c.Telephone = textBox_tel.Text;
                    c.Fac_Adresse = textBox_fac_adresse.Text;
                    c.Fac_CodePostal = textBox_fac_cp.Text;
                    c.Fac_Ville = textBox_fac_ville.Text;
                    c.Liv_Adresse = textBox_liv_adresse.Text;
                    c.Liv_CodePostal = textBox_liv_cp.Text;
                    c.Liv_Ville = textBox_liv_ville.Text;
                    c.Statut = textBox_categorie.Text;
                }
                if (ajouter == true)
                {
                    modifier = false;
                    supprimer = false;
                    c.Nom = textBox_nom.Text;
                    c.Prenom = textBox_prenom.Text;
                    c.Adresse = textBox_adresse.Text;
                    c.CodePostal = textBox_cp.Text;
                    c.Ville = textBox_ville.Text;
                    c.Telephone = textBox_tel.Text;
                    c.Fac_Adresse = textBox_fac_adresse.Text;
                    c.Fac_CodePostal = textBox_fac_cp.Text;
                    c.Fac_Ville = textBox_fac_ville.Text;
                    c.Liv_Adresse = textBox_liv_adresse.Text;
                    c.Liv_CodePostal = textBox_liv_cp.Text;
                    c.Liv_Ville = textBox_liv_ville.Text;
                    c.Statut = textBox_categorie.Text;
                    try
                    {
                        cdao.Insert(c);
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
                    c.Nom = textBox_nom.Text;
                    c.Prenom = textBox_prenom.Text;
                    c.Adresse = textBox_adresse.Text;
                    c.CodePostal = textBox_cp.Text;
                    c.Ville = textBox_ville.Text;
                    c.Telephone = textBox_tel.Text;
                    c.Fac_Adresse = textBox_fac_adresse.Text;
                    c.Fac_CodePostal = textBox_fac_cp.Text;
                    c.Fac_Ville = textBox_fac_ville.Text;
                    c.Liv_Adresse = textBox_liv_adresse.Text;
                    c.Liv_CodePostal = textBox_liv_cp.Text;
                    c.Liv_Ville = textBox_liv_ville.Text;
                    c.Statut = textBox_categorie.Text;
                    c.Id = (int)listBox.SelectedValue;
                    try
                    {
                        cdao.Update(c);
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
                    c.Id = (int)listBox.SelectedValue;
                    try
                    {
                        cdao.Delete(c);
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
                button_commande.Enabled = false;
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
            no_copy();
            textBox_nom.Enabled = false;
            textBox_prenom.Enabled = false;
            textBox_adresse.Enabled = false;
            textBox_cp.Enabled = false;
            textBox_ville.Enabled = false;
            textBox_tel.Enabled = false;
            textBox_fac_adresse.Enabled = false;
            textBox_fac_cp.Enabled = false;
            textBox_fac_ville.Enabled = false;
            textBox_liv_adresse.Enabled = false;
            textBox_liv_cp.Enabled = false;
            textBox_liv_ville.Enabled = false;
            textBox_categorie.Enabled = false;
            textBox_categorie.BackColor = SystemColors.ControlLight;
            textBox_nom.BackColor = SystemColors.ControlLight;
            textBox_prenom.BackColor = SystemColors.ControlLight;
            textBox_adresse.BackColor = SystemColors.ControlLight;
            textBox_cp.BackColor = SystemColors.ControlLight;
            textBox_ville.BackColor = SystemColors.ControlLight;
            textBox_tel.BackColor = SystemColors.ControlLight;
            textBox_fac_adresse.BackColor = SystemColors.ControlLight;
            textBox_fac_cp.BackColor = SystemColors.ControlLight;
            textBox_fac_ville.BackColor = SystemColors.ControlLight;
            textBox_liv_adresse.BackColor = SystemColors.ControlLight;
            textBox_liv_cp.BackColor = SystemColors.ControlLight;
            textBox_liv_ville.BackColor = SystemColors.ControlLight;
        }
        private void modifiable()
        {
            ok_copy();
            textBox_nom.Enabled = true;
            textBox_prenom.Enabled = true;
            textBox_adresse.Enabled = true;
            textBox_cp.Enabled = true;
            textBox_ville.Enabled = true;
            textBox_tel.Enabled = true;
            textBox_fac_adresse.Enabled = true;
            textBox_fac_cp.Enabled = true;
            textBox_fac_ville.Enabled = true;
            textBox_liv_adresse.Enabled = true;
            textBox_liv_cp.Enabled = true;
            textBox_liv_ville.Enabled = true;
            textBox_categorie.Enabled = true;
            textBox_categorie.BackColor = SystemColors.Window;
            textBox_nom.BackColor = SystemColors.Window;
            textBox_prenom.BackColor = SystemColors.Window;
            textBox_adresse.BackColor = SystemColors.Window;
            textBox_cp.BackColor = SystemColors.Window;
            textBox_ville.BackColor = SystemColors.Window;
            textBox_tel.BackColor = SystemColors.Window;
            textBox_fac_adresse.BackColor = SystemColors.Window;
            textBox_fac_cp.BackColor = SystemColors.Window;
            textBox_fac_ville.BackColor = SystemColors.Window;
            textBox_liv_adresse.BackColor = SystemColors.Window;
            textBox_liv_cp.BackColor = SystemColors.Window;
            textBox_liv_ville.BackColor = SystemColors.Window;
        }
        private void button_copier1_Click(object sender, EventArgs e)
        {
            textBox_fac_adresse.Text = textBox_adresse.Text;
            textBox_fac_cp.Text = textBox_cp.Text;
            textBox_fac_ville.Text = textBox_ville.Text;
        }
        private void button_copier2_Click(object sender, EventArgs e)
        {
            textBox_liv_adresse.Text = textBox_adresse.Text;
            textBox_liv_cp.Text = textBox_cp.Text;
            textBox_liv_ville.Text = textBox_ville.Text;
        }
        private void ok_copy()
        {
            button_copier1.Show();
            button_copier2.Show();
            labelcopie1.Show();
            labelcopie2.Show();
        }
        private void no_copy()
        {
            button_copier1.Hide();
            button_copier2.Hide();
            labelcopie1.Hide();
            labelcopie2.Hide();
        }
        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            nettoyer();
            non_modifiable();
            button_modifier.Enabled = false;
            button_supprimer.Enabled = false;
            button_commande.Enabled = false;
            label_cours.Text = "En attente";
            button_confirmer.Enabled = false;
            button_annuler.Enabled = false;
            Height = 475;
        }
        private void textBox_categorie_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox_categorie.Text, @"^[12]{1}$") == true)
            {
                textBox_categorie.BackColor = SystemColors.Window;
                button_confirmer.Enabled = true;
            }
            else
            {
                textBox_categorie.BackColor = Color.LightSalmon;
                button_confirmer.Enabled = false;
            }
            if (textBox_categorie.Text == "1")
            {
                label_statut.Text = "Particulier";
            }
            else if (textBox_categorie.Text == "2")
            {
                label_statut.Text = "Professionnel";
            }
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
            if (Regex.IsMatch(textBox_tel.Text, @"^[\d ]{10,15}$") == true)
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
        private void textBox_fac_adresse_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox_fac_adresse.Text, @"^[\w àäéèêëîïôöûùü'-.,]{1,100}$") == true)
            {
                textBox_fac_adresse.BackColor = SystemColors.Window;
                button_confirmer.Enabled = true;
            }
            else
            {
                textBox_fac_adresse.BackColor = Color.LightSalmon;
                button_confirmer.Enabled = false;
            }
        }
        private void textBox_fac_cp_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox_fac_cp.Text, @"^\d{5}$") == true)
            {
                textBox_fac_cp.BackColor = SystemColors.Window;
                button_confirmer.Enabled = true;
            }
            else
            {
                textBox_fac_cp.BackColor = Color.LightSalmon;
                button_confirmer.Enabled = false;
            }
        }
        private void textBox_fac_ville_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox_fac_ville.Text, @"^[\w àäéèêëîïôöûùü'-.,]{1,100}$") == true)
            {
                textBox_fac_ville.BackColor = SystemColors.Window;
                button_confirmer.Enabled = true;
            }
            else
            {
                textBox_fac_ville.BackColor = Color.LightSalmon;
                button_confirmer.Enabled = false;
            }
        }
        private void textBox_liv_adresse_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox_liv_adresse.Text, @"^[\w àäéèêëîïôöûùü'-.,]{1,100}$") == true)
            {
                textBox_liv_adresse.BackColor = SystemColors.Window;
                button_confirmer.Enabled = true;
            }
            else
            {
                textBox_liv_adresse.BackColor = Color.LightSalmon;
                button_confirmer.Enabled = false;
            }
        }

        private void textBox_liv_cp_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox_liv_cp.Text, @"^\d{5}$") == true)
            {
                textBox_liv_cp.BackColor = SystemColors.Window;
                button_confirmer.Enabled = true;
            }
            else
            {
                textBox_liv_cp.BackColor = Color.LightSalmon;
                button_confirmer.Enabled = false;
            }
        }
        private void textBox_liv_ville_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox_liv_ville.Text, @"^[\w àäéèêëîïôöûùü'-.,]{1,100}$") == true)
            {
                textBox_liv_ville.BackColor = SystemColors.Window;
                button_confirmer.Enabled = true;
            }
            else
            {
                textBox_liv_ville.BackColor = Color.LightSalmon;
                button_confirmer.Enabled = false;
            }
        }

        private void button_commande_Click(object sender, EventArgs e)
        {
            Height = 615;
            CommandeDAO cdao = new CommandeDAO(GUI.Properties.Settings.Default.Serveur);
            dataGridView1.DataSource = cdao.ParIdClient(Convert.ToInt32(listBox.SelectedValue));
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}