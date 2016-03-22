namespace GUI
{
    partial class start
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(start));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_quitter = new System.Windows.Forms.Button();
            this.button_start = new System.Windows.Forms.Button();
            this.textBox_identifiant = new System.Windows.Forms.TextBox();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.label_identifiant = new System.Windows.Forms.Label();
            this.label_password = new System.Windows.Forms.Label();
            this.button_connect = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(357, 251);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button_quitter
            // 
            this.button_quitter.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_quitter.Location = new System.Drawing.Point(697, 239);
            this.button_quitter.Name = "button_quitter";
            this.button_quitter.Size = new System.Drawing.Size(75, 23);
            this.button_quitter.TabIndex = 6;
            this.button_quitter.Text = "Quitter";
            this.button_quitter.UseVisualStyleBackColor = true;
            this.button_quitter.Click += new System.EventHandler(this.button_quitter_Click);
            // 
            // button_start
            // 
            this.button_start.BackColor = System.Drawing.Color.Honeydew;
            this.button_start.Font = new System.Drawing.Font("Calibri", 18F);
            this.button_start.Location = new System.Drawing.Point(370, 51);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(402, 54);
            this.button_start.TabIndex = 1;
            this.button_start.Text = "Démarrer";
            this.button_start.UseVisualStyleBackColor = false;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // textBox_identifiant
            // 
            this.textBox_identifiant.Location = new System.Drawing.Point(450, 53);
            this.textBox_identifiant.Name = "textBox_identifiant";
            this.textBox_identifiant.Size = new System.Drawing.Size(212, 20);
            this.textBox_identifiant.TabIndex = 2;
            this.textBox_identifiant.Visible = false;
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(450, 85);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(212, 20);
            this.textBox_password.TabIndex = 3;
            this.textBox_password.UseSystemPasswordChar = true;
            this.textBox_password.Visible = false;
            // 
            // label_identifiant
            // 
            this.label_identifiant.AutoSize = true;
            this.label_identifiant.Location = new System.Drawing.Point(385, 56);
            this.label_identifiant.Name = "label_identifiant";
            this.label_identifiant.Size = new System.Drawing.Size(59, 13);
            this.label_identifiant.TabIndex = 7;
            this.label_identifiant.Text = "Identifiant :";
            this.label_identifiant.Visible = false;
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.Location = new System.Drawing.Point(367, 88);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(77, 13);
            this.label_password.TabIndex = 7;
            this.label_password.Text = "Mot de passe :";
            this.label_password.Visible = false;
            // 
            // button_connect
            // 
            this.button_connect.BackColor = System.Drawing.Color.Honeydew;
            this.button_connect.Location = new System.Drawing.Point(680, 51);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(92, 23);
            this.button_connect.TabIndex = 4;
            this.button_connect.Text = "Se connecter";
            this.button_connect.UseVisualStyleBackColor = false;
            this.button_connect.Visible = false;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.BackColor = System.Drawing.Color.Honeydew;
            this.button_cancel.Location = new System.Drawing.Point(680, 83);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(92, 23);
            this.button_cancel.TabIndex = 5;
            this.button_cancel.Text = "Annuler";
            this.button_cancel.UseVisualStyleBackColor = false;
            this.button_cancel.Visible = false;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(236)))), ((int)(((byte)(202)))));
            this.ClientSize = new System.Drawing.Size(802, 274);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_connect);
            this.Controls.Add(this.label_password);
            this.Controls.Add(this.label_identifiant);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.textBox_identifiant);
            this.Controls.Add(this.button_quitter);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button_start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "start";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VillageGreen - Application";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.start_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_quitter;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.TextBox textBox_identifiant;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Label label_identifiant;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.Button button_cancel;
    }
}