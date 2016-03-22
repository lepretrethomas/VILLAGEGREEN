namespace GUI
{
    partial class menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(menu));
            this.button_client = new System.Windows.Forms.Button();
            this.button_fournisseur = new System.Windows.Forms.Button();
            this.button_produit = new System.Windows.Forms.Button();
            this.button_ca = new System.Windows.Forms.Button();
            this.label_menu = new System.Windows.Forms.Label();
            this.button_quitter = new System.Windows.Forms.Button();
            this.button_deco = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_catalogue = new System.Windows.Forms.Button();
            this.button_facturation = new System.Windows.Forms.Button();
            this.button_livraison = new System.Windows.Forms.Button();
            this.button_commande = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // button_client
            // 
            this.button_client.BackColor = System.Drawing.Color.Ivory;
            this.button_client.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_client.Location = new System.Drawing.Point(54, 82);
            this.button_client.Name = "button_client";
            this.button_client.Size = new System.Drawing.Size(177, 238);
            this.button_client.TabIndex = 0;
            this.button_client.TabStop = false;
            this.button_client.Text = "Client";
            this.button_client.UseVisualStyleBackColor = false;
            this.button_client.Click += new System.EventHandler(this.button_client_Click);
            // 
            // button_fournisseur
            // 
            this.button_fournisseur.BackColor = System.Drawing.Color.Ivory;
            this.button_fournisseur.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_fournisseur.Location = new System.Drawing.Point(548, 222);
            this.button_fournisseur.Name = "button_fournisseur";
            this.button_fournisseur.Size = new System.Drawing.Size(184, 98);
            this.button_fournisseur.TabIndex = 2;
            this.button_fournisseur.TabStop = false;
            this.button_fournisseur.Text = "Fournisseur";
            this.button_fournisseur.UseVisualStyleBackColor = false;
            this.button_fournisseur.Click += new System.EventHandler(this.button_fournisseur_Click);
            // 
            // button_produit
            // 
            this.button_produit.BackColor = System.Drawing.Color.Ivory;
            this.button_produit.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_produit.Location = new System.Drawing.Point(237, 251);
            this.button_produit.Name = "button_produit";
            this.button_produit.Size = new System.Drawing.Size(305, 69);
            this.button_produit.TabIndex = 1;
            this.button_produit.TabStop = false;
            this.button_produit.Text = "Produit";
            this.button_produit.UseVisualStyleBackColor = false;
            this.button_produit.Click += new System.EventHandler(this.button_produit_Click);
            // 
            // button_ca
            // 
            this.button_ca.BackColor = System.Drawing.Color.Ivory;
            this.button_ca.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ca.Location = new System.Drawing.Point(548, 177);
            this.button_ca.Name = "button_ca";
            this.button_ca.Size = new System.Drawing.Size(184, 39);
            this.button_ca.TabIndex = 3;
            this.button_ca.TabStop = false;
            this.button_ca.Text = "Chiffre d\'affaire";
            this.button_ca.UseVisualStyleBackColor = false;
            this.button_ca.Click += new System.EventHandler(this.button_ca_Click);
            // 
            // label_menu
            // 
            this.label_menu.AutoSize = true;
            this.label_menu.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_menu.ForeColor = System.Drawing.Color.ForestGreen;
            this.label_menu.Location = new System.Drawing.Point(574, 0);
            this.label_menu.Name = "label_menu";
            this.label_menu.Size = new System.Drawing.Size(198, 33);
            this.label_menu.TabIndex = 9;
            this.label_menu.Text = "Menu de gestion";
            // 
            // button_quitter
            // 
            this.button_quitter.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_quitter.Location = new System.Drawing.Point(12, 326);
            this.button_quitter.Name = "button_quitter";
            this.button_quitter.Size = new System.Drawing.Size(101, 23);
            this.button_quitter.TabIndex = 4;
            this.button_quitter.TabStop = false;
            this.button_quitter.Text = "Quitter";
            this.button_quitter.UseVisualStyleBackColor = true;
            this.button_quitter.Click += new System.EventHandler(this.button_quitter_Click);
            // 
            // button_deco
            // 
            this.button_deco.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_deco.Location = new System.Drawing.Point(671, 326);
            this.button_deco.Name = "button_deco";
            this.button_deco.Size = new System.Drawing.Size(101, 23);
            this.button_deco.TabIndex = 5;
            this.button_deco.TabStop = false;
            this.button_deco.Text = "Se déconnecter";
            this.button_deco.UseVisualStyleBackColor = true;
            this.button_deco.Click += new System.EventHandler(this.button_deco_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(98, 69);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // button_catalogue
            // 
            this.button_catalogue.BackColor = System.Drawing.Color.CadetBlue;
            this.button_catalogue.Enabled = false;
            this.button_catalogue.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_catalogue.Location = new System.Drawing.Point(237, 177);
            this.button_catalogue.Name = "button_catalogue";
            this.button_catalogue.Size = new System.Drawing.Size(305, 68);
            this.button_catalogue.TabIndex = 10;
            this.button_catalogue.TabStop = false;
            this.button_catalogue.Text = "Catalogue";
            this.button_catalogue.UseVisualStyleBackColor = false;
            // 
            // button_facturation
            // 
            this.button_facturation.BackColor = System.Drawing.Color.CadetBlue;
            this.button_facturation.Enabled = false;
            this.button_facturation.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_facturation.Location = new System.Drawing.Point(237, 125);
            this.button_facturation.Name = "button_facturation";
            this.button_facturation.Size = new System.Drawing.Size(238, 46);
            this.button_facturation.TabIndex = 11;
            this.button_facturation.TabStop = false;
            this.button_facturation.Text = "Facturation";
            this.button_facturation.UseVisualStyleBackColor = false;
            // 
            // button_livraison
            // 
            this.button_livraison.BackColor = System.Drawing.Color.CadetBlue;
            this.button_livraison.Enabled = false;
            this.button_livraison.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_livraison.Location = new System.Drawing.Point(481, 125);
            this.button_livraison.Name = "button_livraison";
            this.button_livraison.Size = new System.Drawing.Size(251, 46);
            this.button_livraison.TabIndex = 12;
            this.button_livraison.TabStop = false;
            this.button_livraison.Text = "Livraison";
            this.button_livraison.UseVisualStyleBackColor = false;
            // 
            // button_commande
            // 
            this.button_commande.BackColor = System.Drawing.Color.CadetBlue;
            this.button_commande.Enabled = false;
            this.button_commande.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_commande.Location = new System.Drawing.Point(237, 82);
            this.button_commande.Name = "button_commande";
            this.button_commande.Size = new System.Drawing.Size(495, 37);
            this.button_commande.TabIndex = 13;
            this.button_commande.TabStop = false;
            this.button_commande.Text = "Commande";
            this.button_commande.UseVisualStyleBackColor = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(104, 30);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(668, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(236)))), ((int)(((byte)(202)))));
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.button_commande);
            this.Controls.Add(this.button_livraison);
            this.Controls.Add(this.button_facturation);
            this.Controls.Add(this.button_catalogue);
            this.Controls.Add(this.button_fournisseur);
            this.Controls.Add(this.button_deco);
            this.Controls.Add(this.button_produit);
            this.Controls.Add(this.button_client);
            this.Controls.Add(this.button_quitter);
            this.Controls.Add(this.label_menu);
            this.Controls.Add(this.button_ca);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.menu_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_client;
        private System.Windows.Forms.Button button_fournisseur;
        private System.Windows.Forms.Button button_produit;
        private System.Windows.Forms.Button button_ca;
        private System.Windows.Forms.Label label_menu;
        private System.Windows.Forms.Button button_quitter;
        private System.Windows.Forms.Button button_deco;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_catalogue;
        private System.Windows.Forms.Button button_facturation;
        private System.Windows.Forms.Button button_livraison;
        private System.Windows.Forms.Button button_commande;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}