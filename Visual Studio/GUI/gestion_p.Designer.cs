namespace GUI
{
    partial class gestion_p
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(gestion_p));
            this.label_cours = new System.Windows.Forms.Label();
            this.label_operation = new System.Windows.Forms.Label();
            this.label_obligatoire = new System.Windows.Forms.Label();
            this.button_confirmer = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.button_voir = new System.Windows.Forms.Button();
            this.button_liste = new System.Windows.Forms.Button();
            this.groupBox_detail = new System.Windows.Forms.GroupBox();
            this.label_euros = new System.Windows.Forms.Label();
            this.textBox_prix = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label_prix = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.comboBox_ssrub = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label_four_nom = new System.Windows.Forms.Label();
            this.textBox_fournisseur = new System.Windows.Forms.TextBox();
            this.label_four_id = new System.Windows.Forms.Label();
            this.label_id = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_identifiant = new System.Windows.Forms.Label();
            this.label_ssrubrique = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_photo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_description = new System.Windows.Forms.TextBox();
            this.textBox_libelle = new System.Windows.Forms.TextBox();
            this.label_description = new System.Windows.Forms.Label();
            this.label_libelle = new System.Windows.Forms.Label();
            this.button_supprimer = new System.Windows.Forms.Button();
            this.button_modifier = new System.Windows.Forms.Button();
            this.button_annuler = new System.Windows.Forms.Button();
            this.button_ajouter = new System.Windows.Forms.Button();
            this.comboBox_liste1 = new System.Windows.Forms.ComboBox();
            this.comboBox_liste2 = new System.Windows.Forms.ComboBox();
            this.button_filtre = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label_menu = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox_detail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label_cours
            // 
            this.label_cours.AutoSize = true;
            this.label_cours.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_cours.Location = new System.Drawing.Point(393, 425);
            this.label_cours.Name = "label_cours";
            this.label_cours.Size = new System.Drawing.Size(0, 13);
            this.label_cours.TabIndex = 66;
            // 
            // label_operation
            // 
            this.label_operation.AutoSize = true;
            this.label_operation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_operation.Location = new System.Drawing.Point(388, 404);
            this.label_operation.Name = "label_operation";
            this.label_operation.Size = new System.Drawing.Size(123, 13);
            this.label_operation.TabIndex = 65;
            this.label_operation.Text = "Opération en cours :";
            // 
            // label_obligatoire
            // 
            this.label_obligatoire.AutoSize = true;
            this.label_obligatoire.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_obligatoire.ForeColor = System.Drawing.Color.Red;
            this.label_obligatoire.Location = new System.Drawing.Point(818, 404);
            this.label_obligatoire.Name = "label_obligatoire";
            this.label_obligatoire.Size = new System.Drawing.Size(110, 13);
            this.label_obligatoire.TabIndex = 62;
            this.label_obligatoire.Text = "( * ) Champ obligatoire";
            // 
            // button_confirmer
            // 
            this.button_confirmer.Location = new System.Drawing.Point(542, 427);
            this.button_confirmer.Name = "button_confirmer";
            this.button_confirmer.Size = new System.Drawing.Size(107, 32);
            this.button_confirmer.TabIndex = 61;
            this.button_confirmer.Text = "Confirmer";
            this.button_confirmer.UseVisualStyleBackColor = true;
            this.button_confirmer.Click += new System.EventHandler(this.button_confirmer_Click);
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(68, 139);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(204, 277);
            this.listBox.TabIndex = 58;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // button_voir
            // 
            this.button_voir.Location = new System.Drawing.Point(278, 143);
            this.button_voir.Name = "button_voir";
            this.button_voir.Size = new System.Drawing.Size(107, 32);
            this.button_voir.TabIndex = 57;
            this.button_voir.Text = "Visualiser";
            this.button_voir.UseVisualStyleBackColor = true;
            this.button_voir.Click += new System.EventHandler(this.button_voir_Click);
            // 
            // button_liste
            // 
            this.button_liste.Location = new System.Drawing.Point(68, 427);
            this.button_liste.Name = "button_liste";
            this.button_liste.Size = new System.Drawing.Size(204, 32);
            this.button_liste.TabIndex = 56;
            this.button_liste.Text = "Liste complète";
            this.button_liste.UseVisualStyleBackColor = true;
            this.button_liste.Click += new System.EventHandler(this.button_liste_Click);
            // 
            // groupBox_detail
            // 
            this.groupBox_detail.Controls.Add(this.label_euros);
            this.groupBox_detail.Controls.Add(this.textBox_prix);
            this.groupBox_detail.Controls.Add(this.label3);
            this.groupBox_detail.Controls.Add(this.label_prix);
            this.groupBox_detail.Controls.Add(this.pictureBox);
            this.groupBox_detail.Controls.Add(this.comboBox_ssrub);
            this.groupBox_detail.Controls.Add(this.label12);
            this.groupBox_detail.Controls.Add(this.label_four_nom);
            this.groupBox_detail.Controls.Add(this.textBox_fournisseur);
            this.groupBox_detail.Controls.Add(this.label_four_id);
            this.groupBox_detail.Controls.Add(this.label_id);
            this.groupBox_detail.Controls.Add(this.label4);
            this.groupBox_detail.Controls.Add(this.label_identifiant);
            this.groupBox_detail.Controls.Add(this.label_ssrubrique);
            this.groupBox_detail.Controls.Add(this.label2);
            this.groupBox_detail.Controls.Add(this.label_photo);
            this.groupBox_detail.Controls.Add(this.label1);
            this.groupBox_detail.Controls.Add(this.textBox_description);
            this.groupBox_detail.Controls.Add(this.textBox_libelle);
            this.groupBox_detail.Controls.Add(this.label_description);
            this.groupBox_detail.Controls.Add(this.label_libelle);
            this.groupBox_detail.Location = new System.Drawing.Point(391, 53);
            this.groupBox_detail.Name = "groupBox_detail";
            this.groupBox_detail.Size = new System.Drawing.Size(537, 348);
            this.groupBox_detail.TabIndex = 55;
            this.groupBox_detail.TabStop = false;
            this.groupBox_detail.Text = "Détails";
            // 
            // label_euros
            // 
            this.label_euros.AutoSize = true;
            this.label_euros.Location = new System.Drawing.Point(197, 281);
            this.label_euros.Name = "label_euros";
            this.label_euros.Size = new System.Drawing.Size(33, 13);
            this.label_euros.TabIndex = 53;
            this.label_euros.Text = "euros";
            // 
            // textBox_prix
            // 
            this.textBox_prix.Location = new System.Drawing.Point(104, 278);
            this.textBox_prix.Name = "textBox_prix";
            this.textBox_prix.Size = new System.Drawing.Size(87, 20);
            this.textBox_prix.TabIndex = 52;
            this.textBox_prix.TextChanged += new System.EventHandler(this.textBox_prix_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(86, 281);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 13);
            this.label3.TabIndex = 51;
            this.label3.Text = "*";
            // 
            // label_prix
            // 
            this.label_prix.AutoSize = true;
            this.label_prix.Location = new System.Drawing.Point(63, 281);
            this.label_prix.Name = "label_prix";
            this.label_prix.Size = new System.Drawing.Size(24, 13);
            this.label_prix.TabIndex = 50;
            this.label_prix.Text = "Prix";
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(369, 238);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(108, 97);
            this.pictureBox.TabIndex = 49;
            this.pictureBox.TabStop = false;
            // 
            // comboBox_ssrub
            // 
            this.comboBox_ssrub.FormattingEnabled = true;
            this.comboBox_ssrub.Location = new System.Drawing.Point(104, 235);
            this.comboBox_ssrub.Name = "comboBox_ssrub";
            this.comboBox_ssrub.Size = new System.Drawing.Size(193, 21);
            this.comboBox_ssrub.TabIndex = 48;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(340, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(11, 13);
            this.label12.TabIndex = 46;
            this.label12.Text = "*";
            // 
            // label_four_nom
            // 
            this.label_four_nom.AutoSize = true;
            this.label_four_nom.Location = new System.Drawing.Point(398, 20);
            this.label_four_nom.Name = "label_four_nom";
            this.label_four_nom.Size = new System.Drawing.Size(0, 13);
            this.label_four_nom.TabIndex = 23;
            // 
            // textBox_fournisseur
            // 
            this.textBox_fournisseur.Location = new System.Drawing.Point(351, 17);
            this.textBox_fournisseur.Name = "textBox_fournisseur";
            this.textBox_fournisseur.Size = new System.Drawing.Size(40, 20);
            this.textBox_fournisseur.TabIndex = 22;
            this.textBox_fournisseur.TextChanged += new System.EventHandler(this.textBox_fournisseur_TextChanged);
            // 
            // label_four_id
            // 
            this.label_four_id.AutoSize = true;
            this.label_four_id.Location = new System.Drawing.Point(278, 20);
            this.label_four_id.Name = "label_four_id";
            this.label_four_id.Size = new System.Drawing.Size(67, 13);
            this.label_four_id.TabIndex = 21;
            this.label_four_id.Text = "Fournisseur :";
            // 
            // label_id
            // 
            this.label_id.AutoSize = true;
            this.label_id.Location = new System.Drawing.Point(148, 20);
            this.label_id.Name = "label_id";
            this.label_id.Size = new System.Drawing.Size(0, 13);
            this.label_id.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(87, 238);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "*";
            // 
            // label_identifiant
            // 
            this.label_identifiant.AutoSize = true;
            this.label_identifiant.Location = new System.Drawing.Point(83, 20);
            this.label_identifiant.Name = "label_identifiant";
            this.label_identifiant.Size = new System.Drawing.Size(59, 13);
            this.label_identifiant.TabIndex = 14;
            this.label_identifiant.Text = "Identifiant :";
            // 
            // label_ssrubrique
            // 
            this.label_ssrubrique.AutoSize = true;
            this.label_ssrubrique.Location = new System.Drawing.Point(10, 238);
            this.label_ssrubrique.Name = "label_ssrubrique";
            this.label_ssrubrique.Size = new System.Drawing.Size(77, 13);
            this.label_ssrubrique.TabIndex = 13;
            this.label_ssrubrique.Text = "Sous-Rubrique";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(69, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "*";
            // 
            // label_photo
            // 
            this.label_photo.AutoSize = true;
            this.label_photo.Location = new System.Drawing.Point(316, 238);
            this.label_photo.Name = "label_photo";
            this.label_photo.Size = new System.Drawing.Size(35, 13);
            this.label_photo.TabIndex = 12;
            this.label_photo.Text = "Photo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(69, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "*";
            // 
            // textBox_description
            // 
            this.textBox_description.Location = new System.Drawing.Point(86, 73);
            this.textBox_description.Multiline = true;
            this.textBox_description.Name = "textBox_description";
            this.textBox_description.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_description.Size = new System.Drawing.Size(410, 156);
            this.textBox_description.TabIndex = 6;
            this.textBox_description.TextChanged += new System.EventHandler(this.textBox_description_TextChanged);
            // 
            // textBox_libelle
            // 
            this.textBox_libelle.Location = new System.Drawing.Point(86, 47);
            this.textBox_libelle.Name = "textBox_libelle";
            this.textBox_libelle.Size = new System.Drawing.Size(410, 20);
            this.textBox_libelle.TabIndex = 4;
            this.textBox_libelle.TextChanged += new System.EventHandler(this.textBox_libelle_TextChanged);
            // 
            // label_description
            // 
            this.label_description.AutoSize = true;
            this.label_description.Location = new System.Drawing.Point(10, 76);
            this.label_description.Name = "label_description";
            this.label_description.Size = new System.Drawing.Size(60, 13);
            this.label_description.TabIndex = 2;
            this.label_description.Text = "Description";
            // 
            // label_libelle
            // 
            this.label_libelle.AutoSize = true;
            this.label_libelle.Location = new System.Drawing.Point(33, 50);
            this.label_libelle.Name = "label_libelle";
            this.label_libelle.Size = new System.Drawing.Size(37, 13);
            this.label_libelle.TabIndex = 0;
            this.label_libelle.Text = "Libellé";
            // 
            // button_supprimer
            // 
            this.button_supprimer.Location = new System.Drawing.Point(278, 219);
            this.button_supprimer.Name = "button_supprimer";
            this.button_supprimer.Size = new System.Drawing.Size(107, 32);
            this.button_supprimer.TabIndex = 54;
            this.button_supprimer.Text = "Supprimer";
            this.button_supprimer.UseVisualStyleBackColor = true;
            this.button_supprimer.Click += new System.EventHandler(this.button_supprimer_Click);
            // 
            // button_modifier
            // 
            this.button_modifier.Location = new System.Drawing.Point(278, 181);
            this.button_modifier.Name = "button_modifier";
            this.button_modifier.Size = new System.Drawing.Size(107, 32);
            this.button_modifier.TabIndex = 52;
            this.button_modifier.Text = "Modifier";
            this.button_modifier.UseVisualStyleBackColor = true;
            this.button_modifier.Click += new System.EventHandler(this.button_modifier_Click);
            // 
            // button_annuler
            // 
            this.button_annuler.Location = new System.Drawing.Point(655, 427);
            this.button_annuler.Name = "button_annuler";
            this.button_annuler.Size = new System.Drawing.Size(103, 32);
            this.button_annuler.TabIndex = 53;
            this.button_annuler.Text = "Annuler";
            this.button_annuler.UseVisualStyleBackColor = true;
            this.button_annuler.Click += new System.EventHandler(this.button_annuler_Click);
            // 
            // button_ajouter
            // 
            this.button_ajouter.Location = new System.Drawing.Point(278, 54);
            this.button_ajouter.Name = "button_ajouter";
            this.button_ajouter.Size = new System.Drawing.Size(107, 32);
            this.button_ajouter.TabIndex = 51;
            this.button_ajouter.Text = "Ajouter";
            this.button_ajouter.UseVisualStyleBackColor = true;
            this.button_ajouter.Click += new System.EventHandler(this.button_ajouter_Click);
            // 
            // comboBox_liste1
            // 
            this.comboBox_liste1.FormattingEnabled = true;
            this.comboBox_liste1.Location = new System.Drawing.Point(68, 47);
            this.comboBox_liste1.Name = "comboBox_liste1";
            this.comboBox_liste1.Size = new System.Drawing.Size(204, 21);
            this.comboBox_liste1.TabIndex = 67;
            this.comboBox_liste1.SelectedIndexChanged += new System.EventHandler(this.comboBox_liste1_SelectedIndexChanged);
            // 
            // comboBox_liste2
            // 
            this.comboBox_liste2.FormattingEnabled = true;
            this.comboBox_liste2.Location = new System.Drawing.Point(68, 74);
            this.comboBox_liste2.Name = "comboBox_liste2";
            this.comboBox_liste2.Size = new System.Drawing.Size(204, 21);
            this.comboBox_liste2.TabIndex = 68;
            // 
            // button_filtre
            // 
            this.button_filtre.Location = new System.Drawing.Point(109, 103);
            this.button_filtre.Name = "button_filtre";
            this.button_filtre.Size = new System.Drawing.Size(123, 23);
            this.button_filtre.TabIndex = 69;
            this.button_filtre.Text = "Filtrer";
            this.button_filtre.UseVisualStyleBackColor = true;
            this.button_filtre.Click += new System.EventHandler(this.button_filtre_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(49, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 70;
            this.pictureBox1.TabStop = false;
            // 
            // label_menu
            // 
            this.label_menu.AutoSize = true;
            this.label_menu.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_menu.ForeColor = System.Drawing.Color.ForestGreen;
            this.label_menu.Location = new System.Drawing.Point(736, 0);
            this.label_menu.Name = "label_menu";
            this.label_menu.Size = new System.Drawing.Size(240, 33);
            this.label_menu.TabIndex = 71;
            this.label_menu.Text = "Gestion des produits";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(55, 30);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(917, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 72;
            this.pictureBox2.TabStop = false;
            // 
            // gestion_p
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(984, 471);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label_menu);
            this.Controls.Add(this.button_filtre);
            this.Controls.Add(this.comboBox_liste2);
            this.Controls.Add(this.comboBox_liste1);
            this.Controls.Add(this.label_cours);
            this.Controls.Add(this.label_operation);
            this.Controls.Add(this.label_obligatoire);
            this.Controls.Add(this.button_confirmer);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.button_voir);
            this.Controls.Add(this.button_liste);
            this.Controls.Add(this.groupBox_detail);
            this.Controls.Add(this.button_supprimer);
            this.Controls.Add(this.button_modifier);
            this.Controls.Add(this.button_annuler);
            this.Controls.Add(this.button_ajouter);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "gestion_p";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion des Produits";
            this.groupBox_detail.ResumeLayout(false);
            this.groupBox_detail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_cours;
        private System.Windows.Forms.Label label_operation;
        private System.Windows.Forms.Label label_obligatoire;
        private System.Windows.Forms.Button button_confirmer;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button button_voir;
        private System.Windows.Forms.Button button_liste;
        private System.Windows.Forms.GroupBox groupBox_detail;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label_four_nom;
        private System.Windows.Forms.TextBox textBox_fournisseur;
        private System.Windows.Forms.Label label_four_id;
        private System.Windows.Forms.Label label_id;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_identifiant;
        private System.Windows.Forms.Label label_ssrubrique;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_photo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_description;
        private System.Windows.Forms.TextBox textBox_libelle;
        private System.Windows.Forms.Label label_description;
        private System.Windows.Forms.Label label_libelle;
        private System.Windows.Forms.Button button_supprimer;
        private System.Windows.Forms.Button button_modifier;
        private System.Windows.Forms.Button button_annuler;
        private System.Windows.Forms.Button button_ajouter;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ComboBox comboBox_ssrub;
        private System.Windows.Forms.ComboBox comboBox_liste1;
        private System.Windows.Forms.ComboBox comboBox_liste2;
        private System.Windows.Forms.Button button_filtre;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label_menu;
        private System.Windows.Forms.Label label_euros;
        private System.Windows.Forms.TextBox textBox_prix;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_prix;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}