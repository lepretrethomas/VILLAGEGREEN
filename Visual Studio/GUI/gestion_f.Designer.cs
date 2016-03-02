namespace GUI
{
    partial class gestion_f
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(gestion_f));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox_detail = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label_id = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_identifiant = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_tel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_cp = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_tel = new System.Windows.Forms.TextBox();
            this.textBox_cp = new System.Windows.Forms.TextBox();
            this.textBox_ville = new System.Windows.Forms.TextBox();
            this.textBox_adresse = new System.Windows.Forms.TextBox();
            this.textBox_prenom = new System.Windows.Forms.TextBox();
            this.textBox_nom = new System.Windows.Forms.TextBox();
            this.label_ville = new System.Windows.Forms.Label();
            this.label_adresse = new System.Windows.Forms.Label();
            this.label_prenom = new System.Windows.Forms.Label();
            this.label_nom = new System.Windows.Forms.Label();
            this.button_annuler = new System.Windows.Forms.Button();
            this.button_supprimer = new System.Windows.Forms.Button();
            this.button_modifier = new System.Windows.Forms.Button();
            this.button_ajouter = new System.Windows.Forms.Button();
            this.button_liste = new System.Windows.Forms.Button();
            this.button_voir = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.button_confirmer = new System.Windows.Forms.Button();
            this.label_obligatoire = new System.Windows.Forms.Label();
            this.label_cours = new System.Windows.Forms.Label();
            this.label_operation = new System.Windows.Forms.Label();
            this.button_recherche = new System.Windows.Forms.Button();
            this.textBox_recherche = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label13 = new System.Windows.Forms.Label();
            this.button_produit = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label_menu = new System.Windows.Forms.Label();
            this.label_vg = new System.Windows.Forms.Label();
            this.groupBox_detail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(-193, 5);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(172, 251);
            this.listBox1.TabIndex = 6;
            // 
            // groupBox_detail
            // 
            this.groupBox_detail.Controls.Add(this.label5);
            this.groupBox_detail.Controls.Add(this.label_id);
            this.groupBox_detail.Controls.Add(this.label4);
            this.groupBox_detail.Controls.Add(this.label_identifiant);
            this.groupBox_detail.Controls.Add(this.label3);
            this.groupBox_detail.Controls.Add(this.label_tel);
            this.groupBox_detail.Controls.Add(this.label2);
            this.groupBox_detail.Controls.Add(this.label_cp);
            this.groupBox_detail.Controls.Add(this.label1);
            this.groupBox_detail.Controls.Add(this.textBox_tel);
            this.groupBox_detail.Controls.Add(this.textBox_cp);
            this.groupBox_detail.Controls.Add(this.textBox_ville);
            this.groupBox_detail.Controls.Add(this.textBox_adresse);
            this.groupBox_detail.Controls.Add(this.textBox_prenom);
            this.groupBox_detail.Controls.Add(this.textBox_nom);
            this.groupBox_detail.Controls.Add(this.label_ville);
            this.groupBox_detail.Controls.Add(this.label_adresse);
            this.groupBox_detail.Controls.Add(this.label_prenom);
            this.groupBox_detail.Controls.Add(this.label_nom);
            this.groupBox_detail.Location = new System.Drawing.Point(391, 47);
            this.groupBox_detail.Name = "groupBox_detail";
            this.groupBox_detail.Size = new System.Drawing.Size(537, 177);
            this.groupBox_detail.TabIndex = 11;
            this.groupBox_detail.TabStop = false;
            this.groupBox_detail.Text = "Détails";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(175, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "*";
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
            this.label4.Location = new System.Drawing.Point(69, 128);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(69, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "*";
            // 
            // label_tel
            // 
            this.label_tel.AutoSize = true;
            this.label_tel.Location = new System.Drawing.Point(12, 128);
            this.label_tel.Name = "label_tel";
            this.label_tel.Size = new System.Drawing.Size(58, 13);
            this.label_tel.TabIndex = 13;
            this.label_tel.Text = "Téléphone";
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
            // label_cp
            // 
            this.label_cp.AutoSize = true;
            this.label_cp.Location = new System.Drawing.Point(6, 102);
            this.label_cp.Name = "label_cp";
            this.label_cp.Size = new System.Drawing.Size(64, 13);
            this.label_cp.TabIndex = 12;
            this.label_cp.Text = "Code Postal";
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
            // textBox_tel
            // 
            this.textBox_tel.Location = new System.Drawing.Point(86, 125);
            this.textBox_tel.Name = "textBox_tel";
            this.textBox_tel.Size = new System.Drawing.Size(108, 20);
            this.textBox_tel.TabIndex = 11;
            this.textBox_tel.TextChanged += new System.EventHandler(this.textBox_tel_TextChanged);
            // 
            // textBox_cp
            // 
            this.textBox_cp.Location = new System.Drawing.Point(86, 99);
            this.textBox_cp.Name = "textBox_cp";
            this.textBox_cp.Size = new System.Drawing.Size(62, 20);
            this.textBox_cp.TabIndex = 10;
            this.textBox_cp.TextChanged += new System.EventHandler(this.textBox_cp_TextChanged);
            // 
            // textBox_ville
            // 
            this.textBox_ville.Location = new System.Drawing.Point(192, 99);
            this.textBox_ville.Name = "textBox_ville";
            this.textBox_ville.Size = new System.Drawing.Size(304, 20);
            this.textBox_ville.TabIndex = 7;
            this.textBox_ville.TextChanged += new System.EventHandler(this.textBox_ville_TextChanged);
            // 
            // textBox_adresse
            // 
            this.textBox_adresse.Location = new System.Drawing.Point(86, 73);
            this.textBox_adresse.Name = "textBox_adresse";
            this.textBox_adresse.Size = new System.Drawing.Size(410, 20);
            this.textBox_adresse.TabIndex = 6;
            this.textBox_adresse.TextChanged += new System.EventHandler(this.textBox_adresse_TextChanged);
            // 
            // textBox_prenom
            // 
            this.textBox_prenom.Location = new System.Drawing.Point(327, 46);
            this.textBox_prenom.Name = "textBox_prenom";
            this.textBox_prenom.Size = new System.Drawing.Size(169, 20);
            this.textBox_prenom.TabIndex = 5;
            this.textBox_prenom.TextChanged += new System.EventHandler(this.textBox_prenom_TextChanged);
            // 
            // textBox_nom
            // 
            this.textBox_nom.Location = new System.Drawing.Point(86, 47);
            this.textBox_nom.Name = "textBox_nom";
            this.textBox_nom.Size = new System.Drawing.Size(186, 20);
            this.textBox_nom.TabIndex = 4;
            this.textBox_nom.TextChanged += new System.EventHandler(this.textBox_nom_TextChanged);
            // 
            // label_ville
            // 
            this.label_ville.AutoSize = true;
            this.label_ville.Location = new System.Drawing.Point(154, 102);
            this.label_ville.Name = "label_ville";
            this.label_ville.Size = new System.Drawing.Size(26, 13);
            this.label_ville.TabIndex = 3;
            this.label_ville.Text = "Ville";
            // 
            // label_adresse
            // 
            this.label_adresse.AutoSize = true;
            this.label_adresse.Location = new System.Drawing.Point(25, 76);
            this.label_adresse.Name = "label_adresse";
            this.label_adresse.Size = new System.Drawing.Size(45, 13);
            this.label_adresse.TabIndex = 2;
            this.label_adresse.Text = "Adresse";
            // 
            // label_prenom
            // 
            this.label_prenom.AutoSize = true;
            this.label_prenom.Location = new System.Drawing.Point(278, 49);
            this.label_prenom.Name = "label_prenom";
            this.label_prenom.Size = new System.Drawing.Size(43, 13);
            this.label_prenom.TabIndex = 1;
            this.label_prenom.Text = "Prenom";
            // 
            // label_nom
            // 
            this.label_nom.AutoSize = true;
            this.label_nom.Location = new System.Drawing.Point(41, 50);
            this.label_nom.Name = "label_nom";
            this.label_nom.Size = new System.Drawing.Size(29, 13);
            this.label_nom.TabIndex = 0;
            this.label_nom.Text = "Nom";
            // 
            // button_annuler
            // 
            this.button_annuler.Location = new System.Drawing.Point(655, 422);
            this.button_annuler.Name = "button_annuler";
            this.button_annuler.Size = new System.Drawing.Size(103, 32);
            this.button_annuler.TabIndex = 9;
            this.button_annuler.Text = "Annuler";
            this.button_annuler.UseVisualStyleBackColor = true;
            this.button_annuler.Click += new System.EventHandler(this.button_annuler_Click);
            // 
            // button_supprimer
            // 
            this.button_supprimer.Location = new System.Drawing.Point(278, 241);
            this.button_supprimer.Name = "button_supprimer";
            this.button_supprimer.Size = new System.Drawing.Size(107, 32);
            this.button_supprimer.TabIndex = 10;
            this.button_supprimer.Text = "Supprimer";
            this.button_supprimer.UseVisualStyleBackColor = true;
            this.button_supprimer.Click += new System.EventHandler(this.button_supprimer_Click);
            // 
            // button_modifier
            // 
            this.button_modifier.Location = new System.Drawing.Point(278, 203);
            this.button_modifier.Name = "button_modifier";
            this.button_modifier.Size = new System.Drawing.Size(107, 32);
            this.button_modifier.TabIndex = 9;
            this.button_modifier.Text = "Modifier";
            this.button_modifier.UseVisualStyleBackColor = true;
            this.button_modifier.Click += new System.EventHandler(this.button_modifier_Click);
            // 
            // button_ajouter
            // 
            this.button_ajouter.Location = new System.Drawing.Point(278, 77);
            this.button_ajouter.Name = "button_ajouter";
            this.button_ajouter.Size = new System.Drawing.Size(107, 32);
            this.button_ajouter.TabIndex = 8;
            this.button_ajouter.Text = "Ajouter";
            this.button_ajouter.UseVisualStyleBackColor = true;
            this.button_ajouter.Click += new System.EventHandler(this.button_ajouter_Click);
            // 
            // button_liste
            // 
            this.button_liste.Location = new System.Drawing.Point(68, 421);
            this.button_liste.Name = "button_liste";
            this.button_liste.Size = new System.Drawing.Size(204, 33);
            this.button_liste.TabIndex = 13;
            this.button_liste.Text = "Liste complète";
            this.button_liste.UseVisualStyleBackColor = true;
            this.button_liste.Click += new System.EventHandler(this.button_liste_Click);
            // 
            // button_voir
            // 
            this.button_voir.Location = new System.Drawing.Point(278, 165);
            this.button_voir.Name = "button_voir";
            this.button_voir.Size = new System.Drawing.Size(107, 32);
            this.button_voir.TabIndex = 14;
            this.button_voir.Text = "Visualiser";
            this.button_voir.UseVisualStyleBackColor = true;
            this.button_voir.Click += new System.EventHandler(this.button_voir_Click);
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(68, 77);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(204, 342);
            this.listBox.TabIndex = 15;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // button_confirmer
            // 
            this.button_confirmer.Location = new System.Drawing.Point(542, 422);
            this.button_confirmer.Name = "button_confirmer";
            this.button_confirmer.Size = new System.Drawing.Size(107, 32);
            this.button_confirmer.TabIndex = 18;
            this.button_confirmer.Text = "Confirmer";
            this.button_confirmer.UseVisualStyleBackColor = true;
            this.button_confirmer.Click += new System.EventHandler(this.button_confirmer_Click);
            // 
            // label_obligatoire
            // 
            this.label_obligatoire.AutoSize = true;
            this.label_obligatoire.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_obligatoire.ForeColor = System.Drawing.Color.Red;
            this.label_obligatoire.Location = new System.Drawing.Point(818, 227);
            this.label_obligatoire.Name = "label_obligatoire";
            this.label_obligatoire.Size = new System.Drawing.Size(110, 13);
            this.label_obligatoire.TabIndex = 19;
            this.label_obligatoire.Text = "( * ) Champ obligatoire";
            // 
            // label_cours
            // 
            this.label_cours.AutoSize = true;
            this.label_cours.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_cours.Location = new System.Drawing.Point(393, 433);
            this.label_cours.Name = "label_cours";
            this.label_cours.Size = new System.Drawing.Size(0, 13);
            this.label_cours.TabIndex = 47;
            // 
            // label_operation
            // 
            this.label_operation.AutoSize = true;
            this.label_operation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_operation.Location = new System.Drawing.Point(388, 412);
            this.label_operation.Name = "label_operation";
            this.label_operation.Size = new System.Drawing.Size(123, 13);
            this.label_operation.TabIndex = 46;
            this.label_operation.Text = "Opération en cours :";
            // 
            // button_recherche
            // 
            this.button_recherche.Location = new System.Drawing.Point(204, 47);
            this.button_recherche.Name = "button_recherche";
            this.button_recherche.Size = new System.Drawing.Size(68, 20);
            this.button_recherche.TabIndex = 55;
            this.button_recherche.Text = "Recherche";
            this.button_recherche.UseVisualStyleBackColor = true;
            this.button_recherche.Click += new System.EventHandler(this.button_recherche_Click);
            // 
            // textBox_recherche
            // 
            this.textBox_recherche.Location = new System.Drawing.Point(68, 47);
            this.textBox_recherche.Name = "textBox_recherche";
            this.textBox_recherche.Size = new System.Drawing.Size(130, 20);
            this.textBox_recherche.TabIndex = 54;
            this.textBox_recherche.TextChanged += new System.EventHandler(this.textBox_recherche_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(92, 494);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(815, 110);
            this.dataGridView1.TabIndex = 57;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(104, 478);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(139, 13);
            this.label13.TabIndex = 56;
            this.label13.Text = "Liste des produits associès :";
            // 
            // button_produit
            // 
            this.button_produit.Location = new System.Drawing.Point(278, 323);
            this.button_produit.Name = "button_produit";
            this.button_produit.Size = new System.Drawing.Size(107, 46);
            this.button_produit.TabIndex = 58;
            this.button_produit.Text = "Liste des produits associès";
            this.button_produit.UseVisualStyleBackColor = true;
            this.button_produit.Click += new System.EventHandler(this.button_produit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 59;
            this.pictureBox1.TabStop = false;
            // 
            // label_menu
            // 
            this.label_menu.AutoSize = true;
            this.label_menu.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_menu.Location = new System.Drawing.Point(690, 9);
            this.label_menu.Name = "label_menu";
            this.label_menu.Size = new System.Drawing.Size(282, 33);
            this.label_menu.TabIndex = 60;
            this.label_menu.Text = "Gestion des fournisseurs";
            // 
            // label_vg
            // 
            this.label_vg.AutoSize = true;
            this.label_vg.Font = new System.Drawing.Font("Vivaldi", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_vg.ForeColor = System.Drawing.Color.Green;
            this.label_vg.Location = new System.Drawing.Point(30, 0);
            this.label_vg.Name = "label_vg";
            this.label_vg.Size = new System.Drawing.Size(94, 19);
            this.label_vg.TabIndex = 64;
            this.label_vg.Text = "Village Green";
            // 
            // gestion_f
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.Controls.Add(this.label_vg);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label_menu);
            this.Controls.Add(this.button_produit);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.button_recherche);
            this.Controls.Add(this.textBox_recherche);
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
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "gestion_f";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion des Fournisseurs";
            this.groupBox_detail.ResumeLayout(false);
            this.groupBox_detail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox_detail;
        private System.Windows.Forms.Button button_annuler;
        private System.Windows.Forms.TextBox textBox_ville;
        private System.Windows.Forms.TextBox textBox_adresse;
        private System.Windows.Forms.TextBox textBox_prenom;
        private System.Windows.Forms.TextBox textBox_nom;
        private System.Windows.Forms.Label label_ville;
        private System.Windows.Forms.Label label_adresse;
        private System.Windows.Forms.Label label_prenom;
        private System.Windows.Forms.Label label_nom;
        private System.Windows.Forms.Button button_supprimer;
        private System.Windows.Forms.Button button_modifier;
        private System.Windows.Forms.Button button_ajouter;
        private System.Windows.Forms.TextBox textBox_tel;
        private System.Windows.Forms.TextBox textBox_cp;
        private System.Windows.Forms.Label label_tel;
        private System.Windows.Forms.Label label_cp;
        private System.Windows.Forms.Button button_liste;
        private System.Windows.Forms.Button button_voir;
        private System.Windows.Forms.Label label_identifiant;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Label label_id;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_confirmer;
        private System.Windows.Forms.Label label_obligatoire;
        private System.Windows.Forms.Label label_cours;
        private System.Windows.Forms.Label label_operation;
        private System.Windows.Forms.Button button_recherche;
        private System.Windows.Forms.TextBox textBox_recherche;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button_produit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label_menu;
        private System.Windows.Forms.Label label_vg;
    }
}