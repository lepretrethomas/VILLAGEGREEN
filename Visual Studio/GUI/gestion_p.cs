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
    public partial class gestion_p : Form
    {
        int choix = 0;
        bool check_formulaire = false;
        bool check_libelle = false;
        bool check_description = false;
        bool check_prix = false;
        bool check_fournisseur = false;
        public gestion_p()
        {
            InitializeComponent();
            non_modifiable();
            button_modifier.Enabled = false;
            button_supprimer.Enabled = false;
            label_cours.Text = "En attente";
            charger_rubrique();
            charger_ssrubrique();
            charger();
            charger_ssrubrique2();
            comboBox_liste2.SelectedIndex = -1;
            comboBox_liste1.SelectedIndex = -1;
        }
        private void charger()
        {
            ProduitDAO pdao = new ProduitDAO(GUI.Properties.Settings.Default.Serveur);
            listBox.ValueMember = "Id";
            listBox.DisplayMember = "Libelle";
            listBox.DataSource = pdao.List();
        }
        private void charger_rubrique()
        {
            RubriqueDAO rdao = new RubriqueDAO(GUI.Properties.Settings.Default.Serveur);
            comboBox_liste1.ValueMember = "Id";
            comboBox_liste1.DisplayMember = "Nom";
            comboBox_liste1.DataSource = rdao.List();
            charger_ssrubrique();
        }
        private void charger_ssrubrique()
        {
            SsRubriqueDAO srdao = new SsRubriqueDAO(GUI.Properties.Settings.Default.Serveur);
            comboBox_liste2.ValueMember = "Id";
            comboBox_liste2.DisplayMember = "Nom";
            comboBox_liste2.DataSource = srdao.ParRubrique(Convert.ToInt32(comboBox_liste1.SelectedValue));
        }
        private void comboBox_liste1_SelectedIndexChanged(object sender, EventArgs e)
        {
            charger_ssrubrique();
        }
        private void charger_selection()
        {
            ProduitDAO pdao = new ProduitDAO(GUI.Properties.Settings.Default.Serveur);
            listBox.ValueMember = "Id";
            listBox.DisplayMember = "Libelle";
            listBox.DataSource = pdao.ParRubrique(Convert.ToInt32(comboBox_liste2.SelectedValue));
        }
        private void button_filtre_Click(object sender, EventArgs e)
        {
            charger_selection();
        }
        private void nettoyer()
        {
            textBox_libelle.Clear();
            textBox_description.Clear();
            textBox_fournisseur.Clear();
            textBox_prix.Clear();
            comboBox_ssrub.Hide();
            pictureBox_icone.Hide();
            label_id.Text = "";
            label_four_nom.Text = "";
            checkBox_affiche.Checked = false;
            textBox_libelle.BackColor = SystemColors.ControlLight;
            textBox_description.BackColor = SystemColors.ControlLight;
            textBox_prix.BackColor = SystemColors.ControlLight;
            textBox_fournisseur.BackColor = SystemColors.ControlLight;
        }
        private void remplir()
        {
            ProduitDAO pdao = new ProduitDAO(GUI.Properties.Settings.Default.Serveur);
            Produit p = pdao.FindbyId(Convert.ToInt32(listBox.SelectedValue));
            textBox_libelle.Text = p.Libelle;
            textBox_description.Text = p.Description;
            textBox_prix.Text = Convert.ToString(p.Prix);
            textBox_fournisseur.Text = Convert.ToString(p.Fournisseur);
            if (p.Affiche == 1)
            {
                checkBox_affiche.Checked = true;
            }
            else
            {
                checkBox_affiche.Checked = false;
            }
            comboBox_ssrub.SelectedValue = p.Rubrique;
            comboBox_ssrub.Show();
            pictureBox_icone.Show();
            label_id.Text = Convert.ToString(p.Id);
        }
        private void button_voir_Click(object sender, EventArgs e)
        {
            remplir();
            non_modifiable();
            button_modifier.Enabled = true;
            button_supprimer.Enabled = true;
            label_cours.Text = "Visualisation";
            button_confirmer.Enabled = false;
            button_annuler.Enabled = false;
            choix = 1;
        }
        private void button_ajouter_Click(object sender, EventArgs e)
        {
            nettoyer();
            modifiable();
            textBox_libelle.Focus();
            comboBox_ssrub.Show();
            button_modifier.Enabled = false;
            button_supprimer.Enabled = false;
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
            label_cours.Text = "En attente";
        }
        private void button_confirmer_Click(object sender, EventArgs e)
        {
            check();
            try
            {
                Produit p = new Produit();
                ProduitDAO pdao = new ProduitDAO(GUI.Properties.Settings.Default.Serveur);
                switch (choix)
                {
                    case (1):
                        p.Libelle = textBox_libelle.Text;
                        p.Description = textBox_description.Text;
                        p.Fournisseur = Convert.ToInt32(textBox_fournisseur.Text);
                        p.Prix = Convert.ToDecimal(textBox_prix.Text);
                        p.Rubrique = Convert.ToInt32(comboBox_ssrub.SelectedValue);
                        if (p.Affiche == 1)
                        {
                            checkBox_affiche.Checked = true;
                        }
                        else
                        {
                            checkBox_affiche.Checked = false;
                        }
                        break;
                    case (2):
                        if (check_formulaire == true)
                        {
                            p.Libelle = textBox_libelle.Text;
                            p.Description = textBox_description.Text;
                            p.Prix = Convert.ToDecimal(textBox_prix.Text);
                            p.Fournisseur = Convert.ToInt32(textBox_fournisseur.Text);
                            p.Rubrique = Convert.ToInt32(comboBox_ssrub.SelectedValue);
                            if (checkBox_affiche.Checked == true)
                            {
                                p.Affiche = 1;
                            }
                            else
                            {
                                p.Affiche = 0;
                            }
                            try
                            {
                                pdao.Insert(p);
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
                            MessageBox.Show("Vérifiez votre saisie dans les champs requis, puis recommencez.", "Echec", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case (3):
                        if (check_formulaire == true)
                        {
                            p.Libelle = textBox_libelle.Text;
                            p.Description = textBox_description.Text;
                            p.Prix = Convert.ToDecimal(textBox_prix.Text);
                            p.Fournisseur = Convert.ToInt32(textBox_fournisseur.Text);
                            p.Rubrique = Convert.ToInt32(comboBox_ssrub.SelectedValue);
                            if (checkBox_affiche.Checked == true)
                            {
                                p.Affiche = 1;
                            }
                            else
                            {
                                p.Affiche = 0;
                            }
                            p.Id = (int)listBox.SelectedValue;
                            try
                            {
                                pdao.Update(p);
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
                            MessageBox.Show("Vérifiez votre saisie dans les champs requis, puis recommencez.", "Echec", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case (4):
                        p.Id = (int)listBox.SelectedValue;
                        try
                        {
                            pdao.Delete(p);
                            MessageBox.Show("Suppression effectuée.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            nettoyer();
                            charger();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Un problème est survenu.\nNotification: Impossible de supprimer un produit associé à d'autres paramètres dans la base de données.", "Echec", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                }
                button_modifier.Enabled = false;
                button_supprimer.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("un problème est survenu", "Echec", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button_liste_Click(object sender, EventArgs e)
        {
            charger();
            comboBox_liste2.SelectedIndex = -1;
            comboBox_liste1.SelectedIndex = -1;
        }
        private void non_modifiable()
        {
            textBox_libelle.Enabled = false;
            textBox_description.Enabled = false;
            textBox_fournisseur.Enabled = false;
            textBox_prix.Enabled = false;
            comboBox_ssrub.Enabled = false;
            checkBox_affiche.Enabled = false;
            textBox_libelle.BackColor = SystemColors.ControlLight;
            textBox_prix.BackColor = SystemColors.ControlLight;
            textBox_description.BackColor = SystemColors.ControlLight;
            textBox_fournisseur.BackColor = SystemColors.ControlLight;
        }
        private void modifiable()
        {
            textBox_libelle.Enabled = true;
            textBox_description.Enabled = true;
            textBox_fournisseur.Enabled = true;
            textBox_prix.Enabled = true;
            comboBox_ssrub.Enabled = true;
            checkBox_affiche.Enabled = true;
            textBox_libelle.BackColor = SystemColors.Window;
            textBox_prix.BackColor = SystemColors.Window;
            textBox_description.BackColor = SystemColors.Window;
            textBox_fournisseur.BackColor = SystemColors.Window;
        }
        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            nettoyer();
            non_modifiable();
            button_modifier.Enabled = false;
            button_supprimer.Enabled = false;
            label_cours.Text = "En attente";
            label_four_nom.Text = "";
            button_confirmer.Enabled = false;
            button_annuler.Enabled = false;
        }
        private void textBox_libelle_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox_libelle.Text, @"^[\w -\/""']{1,50}$") == true)
            {
                textBox_libelle.BackColor = SystemColors.Window;
                check_libelle = true;
            }
            else
            {
                textBox_libelle.BackColor = Color.LightSalmon;
                check_libelle = false;
            }
        }
        private void textBox_description_TextChanged(object sender, EventArgs e)
        {
            if ((Regex.IsMatch(textBox_description.Text, @"^[^;]+$") == true) && (textBox_description.Text.Length <= 704))
            {
                textBox_description.BackColor = SystemColors.Window;
                check_description = true;
            }
            else
            {
                textBox_description.BackColor = Color.LightSalmon;
                check_description = false;
            }
        }
        private void textBox_fournisseur_TextChanged(object sender, EventArgs e)
        {
            try
            {
                FournisseurDAO fdao = new FournisseurDAO(GUI.Properties.Settings.Default.Serveur);
                Fournisseur f = fdao.FindbyId(Convert.ToInt32(textBox_fournisseur.Text));
                if (textBox_fournisseur.Text != "")
                {

                    label_four_nom.Text = f.Nom;
                }
                else
                {
                    label_four_nom.Text = "";
                }
            }
            catch
            { }
            if (Regex.IsMatch(textBox_fournisseur.Text, @"^[0-9]{1}$") == true)

            {
                textBox_fournisseur.BackColor = SystemColors.Window;
                check_fournisseur = true;
            }
            else
            {
                textBox_fournisseur.BackColor = Color.LightSalmon;
                check_fournisseur = false;
            }
        }
        private void charger_ssrubrique2()
        {
            SsRubriqueDAO srdao = new SsRubriqueDAO(GUI.Properties.Settings.Default.Serveur);
            comboBox_ssrub.ValueMember = "Id";
            comboBox_ssrub.DisplayMember = "Nom";
            comboBox_ssrub.DataSource = srdao.List();
        }

        private void textBox_prix_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox_prix.Text, @"^[0-9]+(\,[0-9][0-9]?)?$") == true)
            {
                textBox_prix.BackColor = SystemColors.Window;
                check_prix = true;
            }
            else
            {
                textBox_prix.BackColor = Color.LightSalmon;
                check_prix = false;
            }
        }
        private void check()
        {
            if ((check_libelle == true) && (check_description == true) && (check_fournisseur == true) && (check_prix == true))
            {
                check_formulaire = true;
            }
            else
            {
                check_formulaire = false;
            }
        }

        private void comboBox_ssrub_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selection = comboBox_ssrub.SelectedValue.ToString();
            switch (selection)
            {
                case ("1"):
                    pictureBox_icone.Image = Properties.Resources.villagegreen_icone1;
                    break;
                case ("2"):
                    pictureBox_icone.Image = Properties.Resources.villagegreen_icone2;
                    break;
                case ("3"):
                    pictureBox_icone.Image = Properties.Resources.villagegreen_icone3;
                    break;
                case ("4"):
                    pictureBox_icone.Image = Properties.Resources.villagegreen_icone4;
                    break;
                case ("5"):
                    pictureBox_icone.Image = Properties.Resources.villagegreen_icone5;
                    break;
                case ("6"):
                    pictureBox_icone.Image = Properties.Resources.villagegreen_icone6;
                    break;
                case ("7"):
                    pictureBox_icone.Image = Properties.Resources.villagegreen_icone7;
                    break;
                case ("8"):
                    pictureBox_icone.Image = Properties.Resources.villagegreen_icone8;
                    break;
                case ("9"):
                    pictureBox_icone.Image = Properties.Resources.villagegreen_icone9;
                    break;
                case ("10"):
                    pictureBox_icone.Image = Properties.Resources.villagegreen_icone10;
                    break;
                case ("11"):
                    pictureBox_icone.Image = Properties.Resources.villagegreen_icone11;
                    break;
                case ("12"):
                    pictureBox_icone.Image = Properties.Resources.villagegreen_icone12;
                    break;
                case ("13"):
                    pictureBox_icone.Image = Properties.Resources.villagegreen_icone13;
                    break;
                case ("14"):
                    pictureBox_icone.Image = Properties.Resources.villagegreen_icone14;
                    break;
                case ("15"):
                    pictureBox_icone.Image = Properties.Resources.villagegreen_icone15;
                    break;
                case ("16"):
                    pictureBox_icone.Image = Properties.Resources.villagegreen_icone16;
                    break;
                case ("17"):
                    pictureBox_icone.Image = Properties.Resources.villagegreen_icone17;
                    break;
                case ("18"):
                    pictureBox_icone.Image = Properties.Resources.villagegreen_icone18;
                    break;
                case ("19"):
                    pictureBox_icone.Image = Properties.Resources.villagegreen_icone19;
                    break;
                case ("20"):
                    pictureBox_icone.Image = Properties.Resources.villagegreen_icone20;
                    break;
                case ("21"):
                    pictureBox_icone.Image = Properties.Resources.villagegreen_icone21;
                    break;
                case ("22"):
                    pictureBox_icone.Image = Properties.Resources.villagegreen_icone22;
                    break;
                case ("23"):
                    pictureBox_icone.Image = Properties.Resources.villagegreen_icone23;
                    break;
                case ("24"):
                    pictureBox_icone.Image = Properties.Resources.villagegreen_icone24;
                    break;
                case ("25"):
                    pictureBox_icone.Image = Properties.Resources.villagegreen_icone25;
                    break;
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
        private void gestion_p_KeyDown(object sender, KeyEventArgs e)
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
    }
}
