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
        int choix = 0;
        bool check_formulaire = false;
        bool check_categorie = false;
        bool check_nom = false;
        bool check_prenom = false;
        bool check_adresse = false;
        bool check_cp = false;
        bool check_ville = false;
        bool check_tel = false;
        bool check_fac_adresse = false;
        bool check_fac_cp = false;
        bool check_fac_ville = false;
        bool check_liv_adresse = false;
        bool check_liv_cp = false;
        bool check_liv_ville = false;
        public gestion_c()
        {
            InitializeComponent();
            Height = 510;
            Width = 1000;
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
            listBox.DisplayMember = "NomComplet";
        }
        private void button_pro_Click(object sender, EventArgs e)
        {
            ClientDAO cdao = new ClientDAO(GUI.Properties.Settings.Default.Serveur);
            listBox.DataSource = cdao.ParStatut(1);
            listBox.ValueMember = "Id";
            listBox.DisplayMember = "NomComplet";
        }
        private void button_par_Click(object sender, EventArgs e)
        {
            ClientDAO cdao = new ClientDAO(GUI.Properties.Settings.Default.Serveur);
            listBox.DataSource = cdao.ParStatut(2);
            listBox.ValueMember = "Id";
            listBox.DisplayMember = "NomComplet";
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
            button_modifier.Enabled = true;
            button_supprimer.Enabled = true;
            button_commande.Enabled = true;
            label_cours.Text = "Visualisation";
            button_confirmer.Enabled = false;
            button_annuler.Enabled = false;
            choix=1;
        }
        private void button_ajouter_Click(object sender, EventArgs e)
        {
            nettoyer();
            modifiable();
            textBox_nom.Focus();
            button_modifier.Enabled = false;
            button_supprimer.Enabled = false;
            button_commande.Enabled = false;
            label_cours.Text = "Ajout";
            button_confirmer.Enabled = true;
            button_annuler.Enabled = true;
                        choix=2;
        }
        private void button_modifier_Click(object sender, EventArgs e)
        {
            remplir();
            modifiable();
            label_cours.Text = "Modification";
            button_confirmer.Enabled = true;
            button_annuler.Enabled = true;
                        choix=3;
        }
        private void button_supprimer_Click(object sender, EventArgs e)
        {
            remplir();
            non_modifiable();
            label_cours.Text = "Suppression";
            button_confirmer.Enabled = true;
            button_annuler.Enabled = true;
                        choix=4;
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
            check();
            try
            {
                Client c = new Client();
                ClientDAO cdao = new ClientDAO(GUI.Properties.Settings.Default.Serveur);
                switch (choix)
                {
                case (1):
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
                break;
                case (2):
                        if (check_formulaire == true)
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
                    try
                    {
                        cdao.Insert(c);
                        MessageBox.Show("Ajout effectué.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                nettoyer();
                                charger();
                            }
                    catch (Exception)
                            {
                                MessageBox.Show("Un problème est survenu.", "Echec", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Vérifiez votre saisie dans les champs requis, puis recommencez.\nRéférez vous à l'aide en bas à droite de la fenêtre si nécessaire.", "Echec", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case (3):
                        if (check_formulaire == true)
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
                    c.Id = (int)listBox.SelectedValue;
                    try
                    {
                        cdao.Update(c);
                        MessageBox.Show("Modification effectuée.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                nettoyer();
                                charger();
                            }
                    catch (Exception)
                            {
                                MessageBox.Show("Un problème est survenu.", "Echec", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Vérifiez votre saisie dans les champs requis, puis recommencez.\nRéférez vous à l'aide en bas à droite de la fenêtre si nécessaire.", "Echec", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case (4):
                    c.Id = (int)listBox.SelectedValue;
                    try
                    {
                        cdao.Delete(c);
                        MessageBox.Show("Suppression effectuée.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            nettoyer();
                            charger();
                        }
                    catch (Exception)
                    {
                        MessageBox.Show("Un problème est survenu.\nNotification: Impossible de supprimer un client associé à d'autres paramètres dans la base de données.", "Echec", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                break;
                }
                button_modifier.Enabled = false;
                button_supprimer.Enabled = false;
                button_commande.Enabled = false;
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
            Height = 510;
        }
        private void textBox_categorie_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox_categorie.Text, @"^[12]{1}$") == true)
            {
                textBox_categorie.BackColor = SystemColors.Window;
                check_categorie = true;
            }
            else
            {
                textBox_categorie.BackColor = Color.LightSalmon;
                check_categorie = false;
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
            if (Regex.IsMatch(textBox_nom.Text, @"^[A-Za-z0-9 '-]{1,50}$") == true)
            {
                textBox_nom.BackColor = SystemColors.Window;
                check_nom = true;
            }
            else
            {
                textBox_nom.BackColor = Color.LightSalmon;
                check_nom = false;
            }
        }
        private void textBox_prenom_TextChanged(object sender, EventArgs e)
        {
            if ((Regex.IsMatch(textBox_prenom.Text, @"^[A-Za-z -]{1,25}$") == true) || (textBox_prenom.Text == ""))
            {
                textBox_prenom.BackColor = SystemColors.Window;
                check_prenom = true;
            }
            else
            {
                textBox_prenom.BackColor = Color.LightSalmon;
                check_prenom = false;
            }
        }
        private void textBox_adresse_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox_adresse.Text, @"^[A-Za-z0-9 ,'-]{1,100}$") == true)

            {
                textBox_adresse.BackColor = SystemColors.Window;
                check_adresse = true;
            }
            else
            {
                textBox_adresse.BackColor = Color.LightSalmon;
                check_adresse = false;
            }
        }
        private void textBox_cp_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox_cp.Text, @"^[0-9]{5}$") == true)
            {
                textBox_cp.BackColor = SystemColors.Window;
                check_cp = true;
            }
            else
            {
                textBox_cp.BackColor = Color.LightSalmon;
                check_cp = false;
            }
        }
        private void textBox_ville_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox_ville.Text, @"^[A-Za-z0-9 ,'-]{1,100}$") == true)
            {
                textBox_ville.BackColor = SystemColors.Window;
                check_ville = true;
            }
            else
            {
                textBox_ville.BackColor = Color.LightSalmon;
                check_ville = false;
            }
        }
        private void textBox_tel_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox_tel.Text, @"^[\d]{10}$") == true)
            {
                textBox_tel.BackColor = SystemColors.Window;
                check_tel = true;
            }
            else
            {
                textBox_tel.BackColor = Color.LightSalmon;
                check_tel = false;
            }
        }
        private void textBox_fac_adresse_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox_fac_adresse.Text, @"^[A-Za-z0-9 ,'-]{1,100}$") == true)
            {
                textBox_fac_adresse.BackColor = SystemColors.Window;
                check_fac_adresse = true;
            }
            else
            {
                textBox_fac_adresse.BackColor = Color.LightSalmon;
                check_fac_adresse = false;
            }
        }
        private void textBox_fac_cp_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox_fac_cp.Text, @"^[0-9]{5}$") == true)
            {
                textBox_fac_cp.BackColor = SystemColors.Window;
                check_fac_cp = true;
            }
            else
            {
                textBox_fac_cp.BackColor = Color.LightSalmon;
                check_fac_cp = false;
            }
        }
        private void textBox_fac_ville_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox_fac_ville.Text, @"^[A-Za-z0-9 ,'-]{1,100}$") == true)
            {
                textBox_fac_ville.BackColor = SystemColors.Window;
                check_fac_ville = true;
            }
            else
            {
                textBox_fac_ville.BackColor = Color.LightSalmon;
                check_fac_ville = false;
            }
        }
        private void textBox_liv_adresse_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox_liv_adresse.Text, @"^[A-Za-z0-9 ,'-]{1,100}$") == true)
            {
                textBox_liv_adresse.BackColor = SystemColors.Window;
                check_liv_adresse = true;
            }
            else
            {
                textBox_liv_adresse.BackColor = Color.LightSalmon;
                check_liv_adresse = false;
            }
        }

        private void textBox_liv_cp_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox_liv_cp.Text, @"^[0-9]{5}$") == true)
            {
                textBox_liv_cp.BackColor = SystemColors.Window;
                check_liv_cp = true;
            }
            else
            {
                textBox_liv_cp.BackColor = Color.LightSalmon;
                check_liv_cp = false;
            }
        }
        private void textBox_liv_ville_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox_liv_ville.Text, @"^[A-Za-z0-9 ,'-]{1,100}$") == true)
            {
                textBox_liv_ville.BackColor = SystemColors.Window;
                check_liv_ville = true;
            }
            else
            {
                textBox_liv_ville.BackColor = Color.LightSalmon;
                check_liv_ville = false;
            }
        }

        private void button_commande_Click(object sender, EventArgs e)
        {
            Height = 650;
            CommandeDAO cdao = new CommandeDAO(GUI.Properties.Settings.Default.Serveur);
            dataGridView1.DataSource = cdao.ParIdClient(Convert.ToInt32(listBox.SelectedValue));
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button_recherche_Click(object sender, EventArgs e)
        {
            ClientDAO cdao = new ClientDAO(GUI.Properties.Settings.Default.Serveur);
            listBox.DataSource = cdao.Recherche(textBox_recherche.Text.ToString());
            listBox.ValueMember = "Id";
            listBox.DisplayMember = "NomComplet";
        }

        private void textBox_recherche_TextChanged(object sender, EventArgs e)
        {
            if ((Regex.IsMatch(textBox_recherche.Text, @"^[a-zA-Z]+$") == true) || (textBox_recherche.Text == ""))
            {
                textBox_recherche.BackColor = SystemColors.Window;
                button_recherche.Enabled = true;
            }
            else
            {
                textBox_recherche.BackColor = Color.LightSalmon;
                button_recherche.Enabled = false;
            }
        }
        private void check()
        {
            if ((check_categorie == true) && (check_nom == true) && (check_prenom == true) && (check_adresse == true) && (check_cp == true) && (check_ville == true) && (check_tel == true) && (check_fac_adresse == true) && (check_fac_cp == true) && (check_fac_ville == true) && (check_liv_adresse == true) && (check_liv_cp == true) && (check_liv_ville == true))
            {
                check_formulaire = true;
            }
            else
            {
                check_formulaire = false;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Aide:\n\n\nCatégorie:\n1 = Particluier, 2 = Professionel\n\nNom:\nEntre 1 et 50 caractères alphanumériques, y compris les apostrophes * ' *, les espaces *  * et les tirets * - *.\n\nPrénom:\nEntre 0 et 25 caractères alphabétiques, y compris les espaces *  * et les tirets * - *.\n\nAdresse:\nEntre 1 et 100 caractères alphanumériques, y compris les apostrophes * ' *, les espaces *  *, les tirets * - * et les virgules * , *.\n\nCode Postal:\n5 caractères numériques, sans espace. (ex = 80130)\n\nVille:\nEntre 1 et 50 caractères alphanumériques, y compris les apostrophes * ' *, les espaces *  *, les tirets * - * et les virgules * , *.\n\nTéléphone:\n10 caractères numériques, sans espace. (ex = 0606060606)", "Informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void gestion_c_KeyDown(object sender, KeyEventArgs e)
        {
            this.listBox.Focus();
            this.listBox.Select();

            if (e.KeyCode == Keys.Up)
            {
                this.listBox.SelectedIndex--;

            }
            else if (e.KeyCode == Keys.Down)
            {
                this.listBox.SelectedIndex++;
            }
        }

        private void listBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.listBox.Focus();
            this.listBox.Select();

            if (e.KeyChar == (char)13)
            {
                button_voir.PerformClick();
            }
        }
    }
}