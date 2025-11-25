namespace WinFormsmedia_tech

{
    partial class AccueilForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        ///  
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccueilForm));
            label1 = new Label();
            label2 = new Label();
            btn_decouvrir = new Button();
            panel1 = new Panel();
            ImageAccueil1 = new PictureBox();
            btn_compte = new Button();
            label3 = new Label();
            label4 = new Label();
            btn_filter1 = new Button();
            btn_filter2 = new Button();
            btn_filter3 = new Button();
            btn_filter4 = new Button();
            panel2 = new Panel();
            button2 = new Button();
            txtRecherche = new TextBox();
            btn_filter = new Button();
            box_genre = new ComboBox();
            box_trier = new ComboBox();
            dataGridViewCatalogue = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ImageAccueil1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCatalogue).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.SkyBlue;
            label1.Font = new Font("DM Sans 14pt SemiBold", 50.2499924F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(149, 241);
            label1.Name = "label1";
            label1.Size = new Size(900, 89);
            label1.TabIndex = 0;
            label1.Text = "Bienvenue sur Média-Tech";
            // 
            // label2
            // 
            label2.BackColor = Color.SkyBlue;
            label2.Font = new Font("DM Sans 14pt", 20F, FontStyle.Italic);
            label2.Location = new Point(163, 330);
            label2.Name = "label2";
            label2.Size = new Size(838, 179);
            label2.TabIndex = 1;
            label2.Text = resources.GetString("label2.Text");
            // 
            // btn_decouvrir
            // 
            btn_decouvrir.BackColor = Color.Black;
            btn_decouvrir.FlatAppearance.BorderColor = Color.White;
            btn_decouvrir.Font = new Font("DM Sans 14pt Medium", 15F, FontStyle.Bold | FontStyle.Italic);
            btn_decouvrir.ForeColor = SystemColors.ButtonHighlight;
            btn_decouvrir.Location = new Point(159, 291);
            btn_decouvrir.Name = "btn_decouvrir";
            btn_decouvrir.Size = new Size(346, 60);
            btn_decouvrir.TabIndex = 2;
            btn_decouvrir.Text = "Découvrir la Bibliothèque !";
            btn_decouvrir.UseVisualStyleBackColor = false;
            btn_decouvrir.Click += btn_decouverte;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.SkyBlue;
            panel1.Controls.Add(ImageAccueil1);
            panel1.Controls.Add(btn_compte);
            panel1.Controls.Add(btn_decouvrir);
            panel1.Location = new Point(-4, 231);
            panel1.Name = "panel1";
            panel1.Size = new Size(2558, 366);
            panel1.TabIndex = 3;
            // 
            // ImageAccueil1
            // 
            ImageAccueil1.ErrorImage = null;
            ImageAccueil1.Image = Properties.Resources.affiche__1_;
            ImageAccueil1.ImageLocation = "";
            ImageAccueil1.InitialImage = Properties.Resources.affiche__1_;
            ImageAccueil1.Location = new Point(1288, 0);
            ImageAccueil1.Name = "ImageAccueil1";
            ImageAccueil1.Size = new Size(677, 366);
            ImageAccueil1.SizeMode = PictureBoxSizeMode.Zoom;
            ImageAccueil1.TabIndex = 4;
            ImageAccueil1.TabStop = false;
            ImageAccueil1.Click += ImageAccueil1_Click;
            // 
            // btn_compte
            // 
            btn_compte.Font = new Font("DM Sans 14pt Medium", 15F, FontStyle.Italic);
            btn_compte.Location = new Point(525, 291);
            btn_compte.Name = "btn_compte";
            btn_compte.Size = new Size(311, 60);
            btn_compte.TabIndex = 3;
            btn_compte.Text = "Créer un compte";
            btn_compte.UseVisualStyleBackColor = true;
            btn_compte.Click += btn_creer_compte;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Font = new Font("DM Sans 14pt SemiBold", 50.2499924F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(1045, 622);
            label3.Name = "label3";
            label3.Size = new Size(568, 89);
            label3.TabIndex = 4;
            label3.Text = "Notre Catalogue";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.Font = new Font("DM Sans 14pt", 20F, FontStyle.Italic);
            label4.Location = new Point(832, 711);
            label4.Name = "label4";
            label4.Size = new Size(1000, 76);
            label4.TabIndex = 5;
            label4.Text = "Explorez notre vaste collection de contenus multimédias disponibles en prêt physique et en accès numérique.";
            label4.Click += label4_Click;
            // 
            // btn_filter1
            // 
            btn_filter1.Anchor = AnchorStyles.Top;
            btn_filter1.BackColor = SystemColors.ActiveCaptionText;
            btn_filter1.Font = new Font("DM Sans 14pt Medium", 15F, FontStyle.Bold | FontStyle.Italic);
            btn_filter1.ForeColor = SystemColors.ButtonHighlight;
            btn_filter1.Location = new Point(872, 817);
            btn_filter1.Name = "btn_filter1";
            btn_filter1.Size = new Size(177, 48);
            btn_filter1.TabIndex = 6;
            btn_filter1.Text = "Tous";
            btn_filter1.UseVisualStyleBackColor = false;
            btn_filter1.Click += btn_tous;
            // 
            // btn_filter2
            // 
            btn_filter2.Anchor = AnchorStyles.Top;
            btn_filter2.Font = new Font("DM Sans 14pt Medium", 14.9999981F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btn_filter2.Location = new Point(1055, 817);
            btn_filter2.Name = "btn_filter2";
            btn_filter2.Size = new Size(182, 48);
            btn_filter2.TabIndex = 7;
            btn_filter2.Text = "Livres";
            btn_filter2.UseVisualStyleBackColor = true;
            btn_filter2.Click += btn_livres;
            // 
            // btn_filter3
            // 
            btn_filter3.Anchor = AnchorStyles.Top;
            btn_filter3.Font = new Font("DM Sans 14pt Medium", 14.9999981F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btn_filter3.Location = new Point(1243, 817);
            btn_filter3.Name = "btn_filter3";
            btn_filter3.Size = new Size(182, 48);
            btn_filter3.TabIndex = 8;
            btn_filter3.Text = "CD Audio";
            btn_filter3.UseVisualStyleBackColor = true;
            btn_filter3.Click += btn_cd;
            // 
            // btn_filter4
            // 
            btn_filter4.Anchor = AnchorStyles.Top;
            btn_filter4.Font = new Font("DM Sans 14pt Medium", 14.9999981F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btn_filter4.Location = new Point(1431, 817);
            btn_filter4.Name = "btn_filter4";
            btn_filter4.Size = new Size(182, 48);
            btn_filter4.TabIndex = 9;
            btn_filter4.Text = "DVD/Blu-Ray";
            btn_filter4.UseVisualStyleBackColor = true;
            btn_filter4.Click += btn_dvd;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top;
            panel2.BackColor = Color.FromArgb(234, 192, 88);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(txtRecherche);
            panel2.Controls.Add(btn_filter);
            panel2.Controls.Add(box_genre);
            panel2.Controls.Add(box_trier);
            panel2.Location = new Point(329, 915);
            panel2.Name = "panel2";
            panel2.Size = new Size(1967, 105);
            panel2.TabIndex = 10;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top;
            button2.Font = new Font("DM Sans 14pt Black", 14.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(1500, 38);
            button2.Name = "button2";
            button2.Size = new Size(182, 34);
            button2.TabIndex = 13;
            button2.Text = "Rechercher";
            button2.UseVisualStyleBackColor = true;
            // 
            // txtRecherche
            // 
            txtRecherche.Anchor = AnchorStyles.Top;
            txtRecherche.Location = new Point(781, 45);
            txtRecherche.Name = "txtRecherche";
            txtRecherche.Size = new Size(610, 23);
            txtRecherche.TabIndex = 12;
            txtRecherche.TextChanged += txtRecherche_TextChanged;
            // 
            // btn_filter
            // 
            btn_filter.Anchor = AnchorStyles.Top;
            btn_filter.Font = new Font("DM Sans 14pt ExtraBold", 14.9999981F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btn_filter.Location = new Point(543, 37);
            btn_filter.Name = "btn_filter";
            btn_filter.Size = new Size(182, 34);
            btn_filter.TabIndex = 11;
            btn_filter.Text = "Plus de Filtres";
            btn_filter.UseVisualStyleBackColor = true;
            // 
            // box_genre
            // 
            box_genre.Anchor = AnchorStyles.Top;
            box_genre.Font = new Font("DM Sans 14pt Light", 14.9999981F, FontStyle.Italic, GraphicsUnit.Point, 0);
            box_genre.FormattingEnabled = true;
            box_genre.Location = new Point(319, 37);
            box_genre.Name = "box_genre";
            box_genre.Size = new Size(199, 34);
            box_genre.TabIndex = 1;
            box_genre.Text = "Genre...";
            // 
            // box_trier
            // 
            box_trier.Anchor = AnchorStyles.Top;
            box_trier.Font = new Font("DM Sans 14pt Light", 14.9999981F, FontStyle.Italic, GraphicsUnit.Point, 0);
            box_trier.FormattingEnabled = true;
            box_trier.Location = new Point(97, 38);
            box_trier.Name = "box_trier";
            box_trier.Size = new Size(199, 34);
            box_trier.TabIndex = 0;
            box_trier.Text = "Trier Par...";
            // 
            // dataGridViewCatalogue
            // 
            dataGridViewCatalogue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCatalogue.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCatalogue.Location = new Point(332, 1026);
            dataGridViewCatalogue.Name = "dataGridViewCatalogue";
            dataGridViewCatalogue.Size = new Size(240, 150);
            dataGridViewCatalogue.TabIndex = 11;
            dataGridViewCatalogue.CellContentClick += dataGridViewCatalogue_CellContentClick;
            // 
            // AccueilForm
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2547, 1159);
            Controls.Add(dataGridViewCatalogue);
            Controls.Add(panel2);
            Controls.Add(btn_filter4);
            Controls.Add(btn_filter3);
            Controls.Add(btn_filter2);
            Controls.Add(btn_filter1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel1);
            Font = new Font("DM Sans 14pt", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 2, 3, 2);
            Name = "AccueilForm";
            Text = "Média_Tech";
            Load += AccueilForm_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ImageAccueil1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCatalogue).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button btn_decouvrir;
        private Panel panel1;
        private Button btn_compte;
        private PictureBox ImageAccueil1;
        private Label label3;
        private Label label4;
        private Button btn_filter1;
        private Button btn_filter2;
        private Button btn_filter3;
        private Button btn_filter4;
        private Panel panel2;
        private ComboBox box_genre;
        private ComboBox box_trier;
        private Button btn_filter;
        private TextBox txtRecherche;
        private Button button2;
        private DataGridView dataGridViewCatalogue;
    }
}
