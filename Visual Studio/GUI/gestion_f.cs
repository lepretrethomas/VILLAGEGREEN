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
        int choix = 0;
        bool check_formulaire = false;
        bool check_nom = false;
        bool check_prenom = false;
        bool check_adresse = false;
        bool check_cp = false;
        bool check_ville = false;
        bool check_tel = false;
        public gestion_f()
        {
            InitializeComponent();
            Height = 510;
            Width = 1000;
            charger();
            non_modifiable();
            button_modifier.Enabled = false;
            button_supprimer.Enabled = false;
            button_produit.Enabled = false;
            label_cours.Text = "En attente";
        }
        private void charger()
        {
            FournisseurDAO fdao = new FournisseurDAO(GUI.Properties.Settings.Default.Serveur);
            listBox.DataSource = fdao.List();
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
            button_modifier.Enabled = true;
            button_supprimer.Enabled = true;
            button_produit.Enabled = true;
            label_cours.Text = "Visualisation";
            button_confirmer.Enabled = false;
            button_annuler.Enabled = false;
            choix = 1;
        }
        private void button_ajouter_Click(object sender, EventArgs e)
        {
            nettoyer();
            modifiable();
            textBox_nom.Focus();
            button_modifier.Enabled = false;
            button_supprimer.Enabled = false;
            button_produit.Enabled = false;
            label_cours.Text = "Ajout";
            button_confirmer.Enabled = true;
            button_annuler.Enabled = true;
            choix = 2;
        }
        private void button_modifier_Click(object sender, EventArgs e)
        {
            remplir();
            modifiable();
            label_cours.Text = "Modification";
            button_confirmer.Enabled = true;
            button_annuler.Enabled = true;
            choix = 3;
        }
        private void button_supprimer_Click(object sender, EventArgs e)
        {
            remplir();
            non_modifiable();
            label_cours.Text = "Suppression";
            button_confirmer.Enabled = true;
            button_annuler.Enabled = true;
            choix = 4;
        }
        private void button_annuler_Click(object sender, EventArgs e)
        {
            non_modifiable();
            nettoyer();
            button_modifier.Enabled = false;
            button_supprimer.Enabled = false;
            button_produit.Enabled = false;
            label_cours.Text = "En attente";
        }
        private void button_confirmer_Click(object sender, EventArgs e)
        {
            check();
            try
            {
                Fournisseur f = new Fournisseur();
                FournisseurDAO fdao = new FournisseurDAO(GUI.Properties.Settings.Default.Serveur);
                switch (choix)
                {
                    case (1):
                        f.Nom = textBox_nom.Text;
                        f.Prenom = textBox_prenom.Text;
                        f.Adresse = textBox_adresse.Text;
                        f.CodePostal = textBox_cp.Text;
                        f.Ville = textBox_ville.Text;
                        f.Telephone = textBox_tel.Text;
                        break;
                    case (2):

                        if (check_formulaire == true)
                        {
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
                        f.Id = (int)listBox.SelectedValue;
                        try
                        {
                            fdao.Delete(f);
                            MessageBox.Show("Suppression effectuée.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            nettoyer();
                        charger();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Un problème est survenu.\nNotification: Impossible de supprimer un fournisseur associé à d'autres paramètres dans la base de données.", "Echec", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        break;
                }
                button_modifier.Enabled = false;
                button_supprimer.Enabled = false;
                button_produit.Enabled = false;
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
            button_produit.Enabled = false;
            label_cours.Text = "En attente";
            button_confirmer.Enabled = false;
            button_annuler.Enabled = false;
            Height = 510;
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
            if (Regex.IsMatch(textBox_adresse.Text, @"^[A-Za-z0-9 -,']{1,100}$") == true)
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
            if (Regex.IsMatch(textBox_cp.Text, @"^[\d]{5}$") == true)
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
        private void button_recherche_Click(object sender, EventArgs e)
        {
            FournisseurDAO cdao = new FournisseurDAO(GUI.Properties.Settings.Default.Serveur);
            listBox.DataSource = cdao.Recherche(textBox_recherche.Text.ToString());
            listBox.ValueMember = "Id";
            listBox.DisplayMember = "NomComplet";
        }

        private void button_produit_Click(object sender, EventArgs e)
        {
            Height = 650;
            ProduitDAO pdao = new ProduitDAO(GUI.Properties.Settings.Default.Serveur);
            dataGridView1.DataSource = pdao.ParFournisseur(Convert.ToInt32(listBox.SelectedValue));
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns[7].HeaderText = "Rubrique";
            dataGridView1.Columns[0].Width = 30;
            dataGridView1.Columns[2].Width = 60;
            dataGridView1.Columns[4].Width = 30;
            dataGridView1.Columns[7].Width = 65;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void textBox_recherche_TextChanged(object sender, EventArgs e)
        {
            if ((Regex.IsMatch(textBox_recherche.Text, @"^[a-zA-Z0-9]+$") == true) || (textBox_recherche.Text == ""))
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
            if ((check_nom == true) && (check_prenom == true) && (check_adresse == true) && (check_cp == true) && (check_ville == true) && (check_tel == true))
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
            MessageBox.Show("Aide:\n\nNom:\nEntre 1 et 50 caractères alphanumériques, y compris les apostrophes * ' *, les espaces *  * et les tirets * - *.\n\nPrénom:\nEntre 0 et 25 caractères alphabétiques, y compris les espaces *  * et les tirets * - *.\n\nAdresse:\nEntre 1 et 100 caractères alphanumériques, y compris les apostrophes * ' *, les espaces *  *, les tirets * - * et les virgules * , *.\n\nCode Postal:\n5 caractères numériques, sans espace. (ex = 80130)\n\nVille:\nEntre 1 et 50 caractères alphanumériques, y compris les apostrophes * ' *, les espaces *  *, les tirets * - * et les virgules * , *.\n\nTéléphone:\n10 caractères numériques, sans espace. (ex = 0606060606)", "Informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void gestion_f_KeyDown(object sender, KeyEventArgs e)
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
