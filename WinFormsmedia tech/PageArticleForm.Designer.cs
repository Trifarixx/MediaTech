namespace WinFormsmedia_tech
{
    partial class PageArticleForm
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
            lbl_date = new Label();
            lbl_auteur = new Label();
            lbl_Editeur = new Label();
            lbl_carac = new Label();
            lbl_Titre = new Label();
            Partager = new Button();
            favoris = new Button();
            Emprunter = new Button();
            picturebox = new PictureBox();
            dataGridView1 = new DataGridView();
            panelLivre = new Panel();
            lbl_NbPages = new Label();
            panelAudio = new Panel();
            lbl_DureeAudio = new Label();
            lbl_Pistes = new Label();
            panelVideo = new Panel();
            lbl_DureeVideo = new Label();
            pictureBoxAffiche = new PictureBox();
            lbl_Categorie = new Label();
            ((System.ComponentModel.ISupportInitialize)picturebox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panelLivre.SuspendLayout();
            panelAudio.SuspendLayout();
            panelVideo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAffiche).BeginInit();
            SuspendLayout();
            // 
            // lbl_date
            // 
            lbl_date.AutoSize = true;
            lbl_date.BackColor = Color.FromArgb(61, 173, 213);
            lbl_date.Font = new Font("DM Sans 14pt ExtraBold", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbl_date.Location = new Point(1458, 366);
            lbl_date.Name = "lbl_date";
            lbl_date.Size = new Size(249, 31);
            lbl_date.TabIndex = 67;
            lbl_date.Text = "Date de Publication";
            // 
            // lbl_auteur
            // 
            lbl_auteur.AutoSize = true;
            lbl_auteur.BackColor = Color.FromArgb(61, 173, 213);
            lbl_auteur.Font = new Font("DM Sans 14pt ExtraBold", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbl_auteur.Location = new Point(909, 287);
            lbl_auteur.Name = "lbl_auteur";
            lbl_auteur.Size = new Size(96, 31);
            lbl_auteur.TabIndex = 64;
            lbl_auteur.Text = "Auteur";
            // 
            // lbl_Editeur
            // 
            lbl_Editeur.AutoSize = true;
            lbl_Editeur.BackColor = Color.FromArgb(61, 173, 213);
            lbl_Editeur.Font = new Font("DM Sans 14pt ExtraBold", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbl_Editeur.Location = new Point(909, 366);
            lbl_Editeur.Name = "lbl_Editeur";
            lbl_Editeur.Size = new Size(101, 31);
            lbl_Editeur.TabIndex = 65;
            lbl_Editeur.Text = "Éditeur";
            // 
            // lbl_carac
            // 
            lbl_carac.AccessibleRole = AccessibleRole.Window;
            lbl_carac.AutoSize = true;
            lbl_carac.BackColor = Color.FromArgb(61, 173, 213);
            lbl_carac.Font = new Font("DM Sans 14pt ExtraBold", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbl_carac.Location = new Point(909, 152);
            lbl_carac.Name = "lbl_carac";
            lbl_carac.Size = new Size(216, 31);
            lbl_carac.TabIndex = 62;
            lbl_carac.Text = "Caractéristiques";
            // 
            // lbl_Titre
            // 
            lbl_Titre.AutoSize = true;
            lbl_Titre.BackColor = Color.FromArgb(61, 173, 213);
            lbl_Titre.Font = new Font("DM Sans 14pt ExtraBold", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbl_Titre.Location = new Point(909, 209);
            lbl_Titre.Name = "lbl_Titre";
            lbl_Titre.Size = new Size(70, 31);
            lbl_Titre.TabIndex = 63;
            lbl_Titre.Text = "Titre";
            // 
            // Partager
            // 
            Partager.BackColor = SystemColors.ControlLightLight;
            Partager.Font = new Font("DM Sans 14pt ExtraBold", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            Partager.ForeColor = SystemColors.ActiveCaptionText;
            Partager.Location = new Point(538, 840);
            Partager.Name = "Partager";
            Partager.Size = new Size(220, 44);
            Partager.TabIndex = 58;
            Partager.Text = "Partager";
            Partager.UseVisualStyleBackColor = false;
            // 
            // favoris
            // 
            favoris.BackColor = SystemColors.ControlLightLight;
            favoris.Font = new Font("DM Sans 14pt ExtraBold", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            favoris.ForeColor = SystemColors.ActiveCaptionText;
            favoris.Location = new Point(292, 840);
            favoris.Name = "favoris";
            favoris.Size = new Size(220, 44);
            favoris.TabIndex = 57;
            favoris.Text = "favoris";
            favoris.UseVisualStyleBackColor = false;
            // 
            // Emprunter
            // 
            Emprunter.BackColor = SystemColors.ActiveCaptionText;
            Emprunter.Font = new Font("DM Sans 14pt ExtraBold", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            Emprunter.ForeColor = SystemColors.ButtonHighlight;
            Emprunter.Location = new Point(292, 769);
            Emprunter.Name = "Emprunter";
            Emprunter.Size = new Size(466, 52);
            Emprunter.TabIndex = 56;
            Emprunter.Text = "Empunter";
            Emprunter.UseVisualStyleBackColor = false;
            Emprunter.Click += Emprunter_Click_1;
            // 
            // picturebox
            // 
            picturebox.Anchor = AnchorStyles.Left;
            picturebox.BackColor = SystemColors.ControlDarkDark;
            picturebox.Location = new Point(212, -54);
            picturebox.Name = "picturebox";
            picturebox.Size = new Size(628, 1097);
            picturebox.TabIndex = 53;
            picturebox.TabStop = false;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.FromArgb(61, 173, 213);
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(885, 126);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1024, 347);
            dataGridView1.TabIndex = 54;
            // 
            // panelLivre
            // 
            panelLivre.BackColor = Color.FromArgb(234, 192, 88);
            panelLivre.Controls.Add(lbl_NbPages);
            panelLivre.Location = new Point(885, 517);
            panelLivre.Name = "panelLivre";
            panelLivre.Size = new Size(1024, 347);
            panelLivre.TabIndex = 80;
            // 
            // lbl_NbPages
            // 
            lbl_NbPages.AutoSize = true;
            lbl_NbPages.Font = new Font("DM Sans 14pt ExtraBold", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbl_NbPages.Location = new Point(78, 142);
            lbl_NbPages.Name = "lbl_NbPages";
            lbl_NbPages.Size = new Size(103, 28);
            lbl_NbPages.TabIndex = 0;
            lbl_NbPages.Text = "NbPages";
            // 
            // panelAudio
            // 
            panelAudio.BackColor = Color.LightGreen;
            panelAudio.Controls.Add(lbl_DureeAudio);
            panelAudio.Controls.Add(lbl_Pistes);
            panelAudio.Location = new Point(885, 517);
            panelAudio.Name = "panelAudio";
            panelAudio.Size = new Size(1024, 347);
            panelAudio.TabIndex = 81;
            // 
            // lbl_DureeAudio
            // 
            lbl_DureeAudio.AutoSize = true;
            lbl_DureeAudio.Font = new Font("DM Sans 14pt ExtraBold", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbl_DureeAudio.Location = new Point(78, 114);
            lbl_DureeAudio.Name = "lbl_DureeAudio";
            lbl_DureeAudio.Size = new Size(136, 28);
            lbl_DureeAudio.TabIndex = 2;
            lbl_DureeAudio.Text = "DureeAudio";
            // 
            // lbl_Pistes
            // 
            lbl_Pistes.AutoSize = true;
            lbl_Pistes.Font = new Font("DM Sans 14pt ExtraBold", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbl_Pistes.Location = new Point(78, 187);
            lbl_Pistes.Name = "lbl_Pistes";
            lbl_Pistes.Size = new Size(75, 28);
            lbl_Pistes.TabIndex = 1;
            lbl_Pistes.Text = "Pistes";
            // 
            // panelVideo
            // 
            panelVideo.BackColor = Color.IndianRed;
            panelVideo.Controls.Add(lbl_DureeVideo);
            panelVideo.Location = new Point(885, 517);
            panelVideo.Name = "panelVideo";
            panelVideo.Size = new Size(1024, 347);
            panelVideo.TabIndex = 82;
            // 
            // lbl_DureeVideo
            // 
            lbl_DureeVideo.AutoSize = true;
            lbl_DureeVideo.Font = new Font("DM Sans 14pt ExtraBold", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbl_DureeVideo.Location = new Point(78, 52);
            lbl_DureeVideo.Name = "lbl_DureeVideo";
            lbl_DureeVideo.Size = new Size(136, 28);
            lbl_DureeVideo.TabIndex = 3;
            lbl_DureeVideo.Text = "VideoDuree";
            // 
            // pictureBoxAffiche
            // 
            pictureBoxAffiche.BackColor = Color.FromArgb(75, 86, 93);
            pictureBoxAffiche.Location = new Point(238, 12);
            pictureBoxAffiche.Name = "pictureBoxAffiche";
            pictureBoxAffiche.Size = new Size(578, 751);
            pictureBoxAffiche.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxAffiche.TabIndex = 83;
            pictureBoxAffiche.TabStop = false;
            // 
            // lbl_Categorie
            // 
            lbl_Categorie.AutoSize = true;
            lbl_Categorie.BackColor = Color.FromArgb(61, 173, 213);
            lbl_Categorie.Font = new Font("DM Sans 14pt ExtraBold", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbl_Categorie.Location = new Point(1458, 287);
            lbl_Categorie.Name = "lbl_Categorie";
            lbl_Categorie.Size = new Size(132, 31);
            lbl_Categorie.TabIndex = 84;
            lbl_Categorie.Text = "Categorie";
            // 
            // PageArticleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(2158, 988);
            Controls.Add(lbl_Categorie);
            Controls.Add(pictureBoxAffiche);
            Controls.Add(lbl_date);
            Controls.Add(lbl_auteur);
            Controls.Add(lbl_Editeur);
            Controls.Add(lbl_carac);
            Controls.Add(lbl_Titre);
            Controls.Add(Partager);
            Controls.Add(favoris);
            Controls.Add(Emprunter);
            Controls.Add(dataGridView1);
            Controls.Add(picturebox);
            Controls.Add(panelVideo);
            Controls.Add(panelAudio);
            Controls.Add(panelLivre);
            Name = "PageArticleForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)picturebox).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panelLivre.ResumeLayout(false);
            panelLivre.PerformLayout();
            panelAudio.ResumeLayout(false);
            panelAudio.PerformLayout();
            panelVideo.ResumeLayout(false);
            panelVideo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAffiche).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lbl_date;
        private Label lbl_auteur;
        private Label lbl_Editeur;
        private Label lbl_carac;
        private Label lbl_Titre;
        private Button Partager;
        private Button favoris;
        private Button Emprunter;
        private PictureBox picturebox;
        private DataGridView dataGridView1;
        private Panel panelLivre;
        private Panel panelAudio;
        private Panel panelVideo;
        private Label lbl_NbPages;
        private Label lbl_DureeVideo;
        private Label lbl_DureeAudio;
        private Label lbl_Pistes;
        private PictureBox pictureBoxAffiche;
        private Label lbl_Categorie;
        private Label label1;
        private Label label2;
    }
}