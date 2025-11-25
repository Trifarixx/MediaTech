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
            textBox5 = new TextBox();
            textBox3 = new TextBox();
            textBox1 = new TextBox();
            txAuteur = new TextBox();
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
            dataGridView2 = new DataGridView();
            panelLivre = new Panel();
            panelAudio = new Panel();
            panelVideo = new Panel();
            lbl_DureeVideo = new Label();
            lbl_DureeAudio = new Label();
            lbl_Pistes = new Label();
            lbl_NbPages = new Label();
            ((System.ComponentModel.ISupportInitialize)picturebox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            panelVideo.SuspendLayout();
            SuspendLayout();
            // 
            // textBox5
            // 
            textBox5.Location = new Point(1382, 427);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(100, 23);
            textBox5.TabIndex = 79;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(1382, 251);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 77;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(909, 427);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 75;
            // 
            // txAuteur
            // 
            txAuteur.Location = new Point(909, 251);
            txAuteur.Name = "txAuteur";
            txAuteur.Size = new Size(100, 23);
            txAuteur.TabIndex = 74;
            // 
            // lbl_date
            // 
            lbl_date.AutoSize = true;
            lbl_date.BackColor = SystemColors.ControlLightLight;
            lbl_date.Font = new Font("DM Sans 14pt Medium", 11.9999981F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbl_date.Location = new Point(1382, 390);
            lbl_date.Name = "lbl_date";
            lbl_date.Size = new Size(156, 21);
            lbl_date.TabIndex = 67;
            lbl_date.Text = "Date de Publication";
            // 
            // lbl_auteur
            // 
            lbl_auteur.AutoSize = true;
            lbl_auteur.BackColor = SystemColors.ControlLightLight;
            lbl_auteur.Font = new Font("DM Sans 14pt Medium", 11.9999981F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbl_auteur.Location = new Point(1382, 216);
            lbl_auteur.Name = "lbl_auteur";
            lbl_auteur.Size = new Size(60, 21);
            lbl_auteur.TabIndex = 64;
            lbl_auteur.Text = "Auteur";
            // 
            // lbl_Editeur
            // 
            lbl_Editeur.AutoSize = true;
            lbl_Editeur.BackColor = SystemColors.ControlLightLight;
            lbl_Editeur.Font = new Font("DM Sans 14pt Medium", 11.9999981F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbl_Editeur.Location = new Point(909, 390);
            lbl_Editeur.Name = "lbl_Editeur";
            lbl_Editeur.Size = new Size(63, 21);
            lbl_Editeur.TabIndex = 65;
            lbl_Editeur.Text = "Éditeur";
            // 
            // lbl_carac
            // 
            lbl_carac.AccessibleRole = AccessibleRole.Window;
            lbl_carac.AutoSize = true;
            lbl_carac.BackColor = SystemColors.ControlLightLight;
            lbl_carac.Font = new Font("DM Sans 14pt", 14.2499981F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbl_carac.Location = new Point(909, 152);
            lbl_carac.Name = "lbl_carac";
            lbl_carac.Size = new Size(168, 25);
            lbl_carac.TabIndex = 62;
            lbl_carac.Text = "Caractéristiques";
            // 
            // lbl_Titre
            // 
            lbl_Titre.AutoSize = true;
            lbl_Titre.BackColor = SystemColors.ControlLightLight;
            lbl_Titre.Font = new Font("DM Sans 14pt Medium", 11.9999981F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbl_Titre.Location = new Point(909, 216);
            lbl_Titre.Name = "lbl_Titre";
            lbl_Titre.Size = new Size(44, 21);
            lbl_Titre.TabIndex = 63;
            lbl_Titre.Text = "Titre";
            // 
            // Partager
            // 
            Partager.BackColor = SystemColors.ControlLightLight;
            Partager.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
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
            favoris.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
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
            Emprunter.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Emprunter.ForeColor = SystemColors.ButtonHighlight;
            Emprunter.Location = new Point(292, 769);
            Emprunter.Name = "Emprunter";
            Emprunter.Size = new Size(466, 52);
            Emprunter.TabIndex = 56;
            Emprunter.Text = "Empunter";
            Emprunter.UseVisualStyleBackColor = false;
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
            dataGridView1.BackgroundColor = SystemColors.ControlLightLight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(885, 126);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(845, 347);
            dataGridView1.TabIndex = 54;
            // 
            // dataGridView2
            // 
            dataGridView2.BackgroundColor = SystemColors.ControlLightLight;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(885, 517);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(845, 347);
            dataGridView2.TabIndex = 55;
            // 
            // panelLivre
            // 
            panelLivre.Location = new Point(885, 517);
            panelLivre.Name = "panelLivre";
            panelLivre.Size = new Size(845, 347);
            panelLivre.TabIndex = 80;
            // 
            // panelAudio
            // 
            panelAudio.Location = new Point(885, 517);
            panelAudio.Name = "panelAudio";
            panelAudio.Size = new Size(845, 347);
            panelAudio.TabIndex = 81;
            // 
            // panelVideo
            // 
            panelVideo.Controls.Add(lbl_DureeVideo);
            panelVideo.Controls.Add(lbl_DureeAudio);
            panelVideo.Controls.Add(lbl_Pistes);
            panelVideo.Controls.Add(lbl_NbPages);
            panelVideo.Location = new Point(885, 517);
            panelVideo.Name = "panelVideo";
            panelVideo.Size = new Size(845, 347);
            panelVideo.TabIndex = 82;
            // 
            // lbl_DureeVideo
            // 
            lbl_DureeVideo.AutoSize = true;
            lbl_DureeVideo.Font = new Font("DM Sans 14pt Medium", 11.9999981F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbl_DureeVideo.Location = new Point(131, 170);
            lbl_DureeVideo.Name = "lbl_DureeVideo";
            lbl_DureeVideo.Size = new Size(51, 21);
            lbl_DureeVideo.TabIndex = 3;
            lbl_DureeVideo.Text = "label1";
            // 
            // lbl_DureeAudio
            // 
            lbl_DureeAudio.AutoSize = true;
            lbl_DureeAudio.Font = new Font("DM Sans 14pt Medium", 11.9999981F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbl_DureeAudio.Location = new Point(131, 201);
            lbl_DureeAudio.Name = "lbl_DureeAudio";
            lbl_DureeAudio.Size = new Size(51, 21);
            lbl_DureeAudio.TabIndex = 2;
            lbl_DureeAudio.Text = "label1";
            // 
            // lbl_Pistes
            // 
            lbl_Pistes.AutoSize = true;
            lbl_Pistes.Font = new Font("DM Sans 14pt Medium", 11.9999981F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbl_Pistes.Location = new Point(131, 232);
            lbl_Pistes.Name = "lbl_Pistes";
            lbl_Pistes.Size = new Size(51, 21);
            lbl_Pistes.TabIndex = 1;
            lbl_Pistes.Text = "label1";
            // 
            // lbl_NbPages
            // 
            lbl_NbPages.AutoSize = true;
            lbl_NbPages.Font = new Font("DM Sans 14pt Medium", 11.9999981F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbl_NbPages.Location = new Point(131, 140);
            lbl_NbPages.Name = "lbl_NbPages";
            lbl_NbPages.Size = new Size(51, 21);
            lbl_NbPages.TabIndex = 0;
            lbl_NbPages.Text = "label1";
            // 
            // PageArticleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1942, 988);
            Controls.Add(panelVideo);
            Controls.Add(panelAudio);
            Controls.Add(panelLivre);
            Controls.Add(textBox5);
            Controls.Add(textBox3);
            Controls.Add(textBox1);
            Controls.Add(txAuteur);
            Controls.Add(lbl_date);
            Controls.Add(lbl_auteur);
            Controls.Add(lbl_Editeur);
            Controls.Add(lbl_carac);
            Controls.Add(lbl_Titre);
            Controls.Add(Partager);
            Controls.Add(favoris);
            Controls.Add(Emprunter);
            Controls.Add(dataGridView1);
            Controls.Add(dataGridView2);
            Controls.Add(picturebox);
            Name = "PageArticleForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)picturebox).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            panelVideo.ResumeLayout(false);
            panelVideo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox5;
        private TextBox textBox3;
        private TextBox textBox1;
        private TextBox txAuteur;
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
        private DataGridView dataGridView2;
        private Panel panelLivre;
        private Panel panelAudio;
        private Panel panelVideo;
        private Label lbl_NbPages;
        private Label lbl_DureeVideo;
        private Label lbl_DureeAudio;
        private Label lbl_Pistes;
    }
}