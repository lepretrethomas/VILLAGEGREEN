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
            bool ajouter = false;
            bool modifier = false;
            bool supprimer = false;
            bool voir = false;
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
            label_id.Text = "";
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
            comboBox_ssrub.SelectedValue = p.Rubrique;
            comboBox_ssrub.Show();
            label_id.Text = Convert.ToString(p.Id);
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
            textBox_libelle.Focus();
            ajouter = true;
            comboBox_ssrub.Show();
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
                Produit p = new Produit();
                ProduitDAO pdao = new ProduitDAO(GUI.Properties.Settings.Default.Serveur);
                if (voir == true)
                {
                    p.Libelle = textBox_libelle.Text;
                    p.Description = textBox_description.Text;
                    p.Fournisseur = Convert.ToInt32(textBox_fournisseur.Text);
                    p.Prix = Convert.ToDecimal(textBox_prix.Text);
                    p.Rubrique = Convert.ToInt32(comboBox_ssrub.SelectedValue);
                }
                if (ajouter == true)
                {
                    modifier = false;
                    supprimer = false;
                    p.Libelle = textBox_libelle.Text;
                    p.Description = textBox_description.Text;
                    p.Prix = Convert.ToDecimal(textBox_prix.Text);
                    p.Fournisseur = Convert.ToInt32(textBox_fournisseur.Text);
                    p.Rubrique = Convert.ToInt32(comboBox_ssrub.SelectedValue);
                    try
                    {
                        pdao.Insert(p);
                        MessageBox.Show("Ajout effectué.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Un problème est survenu.\nVérifiez que vous avez saisi correctement tous les champs et recommencez.", "Echec", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (modifier == true)
                {
                    ajouter = false;
                    supprimer = false;
                    p.Libelle = textBox_libelle.Text;
                    p.Description = textBox_description.Text;
                    p.Prix = Convert.ToDecimal(textBox_prix.Text);
                    p.Fournisseur = Convert.ToInt32(textBox_fournisseur.Text);
                    p.Rubrique = Convert.ToInt32(comboBox_ssrub.SelectedValue);
                    p.Id = (int)listBox.SelectedValue;
                    try
                    {
                        pdao.Update(p);
                        MessageBox.Show("Modification effectuée.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Un problème est survenu.\nVérifiez que vous avez saisi correctement tous les champs et recommencez.", "Echec", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (supprimer == true)
                {
                    ajouter = false;
                    modifier = false;
                    p.Id = (int)listBox.SelectedValue;
                    try
                    {
                        pdao.Delete(p);
                        MessageBox.Show("Suppression effectuée.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Un problème est survenu.\nSi ce produit est associé à d'autres paramètres (commandes, catalogue, etc,...),\nil ne pourra pas être supprimé.", "Echec", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            catch (Exception erreur)
            {
                MessageBox.Show(erreur.Message, "Echec", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            }
            else
            {
                textBox_libelle.BackColor = Color.LightSalmon;
            }
        }
        private void textBox_description_TextChanged(object sender, EventArgs e)
        {
            if ((Regex.IsMatch(textBox_description.Text, @"^[^;]+$") == true) && (textBox_description.Text.Length <= 704))
            {
                textBox_description.BackColor = SystemColors.Window;
            }
            else
            {
                textBox_description.BackColor = Color.LightSalmon;
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
            }
            else
            {
                textBox_fournisseur.BackColor = Color.LightSalmon;
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
            }
            else
            {
                textBox_prix.BackColor = Color.LightSalmon;
            }
        }
    }
}