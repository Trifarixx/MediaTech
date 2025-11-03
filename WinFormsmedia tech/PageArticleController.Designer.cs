namespace WinFormsmedia_tech
{
    partial class PageArticleController
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

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            InfoGeneral = new Label();
            Classique = new Label();
            Enfant = new Label();
            Disponible = new Label();
            Partager = new Button();
            favoris = new Button();
            Emprunter = new Button();
            dataGridView2 = new DataGridView();
            dataGridView1 = new DataGridView();
            picturebox = new PictureBox();
            txAuteur = new TextBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            textBox7 = new TextBox();
            textBox8 = new TextBox();
            textBox9 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picturebox).BeginInit();
            SuspendLayout();
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = SystemColors.ControlLightLight;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(847, 874);
            label12.Name = "label12";
            label12.Size = new Size(66, 21);
            label12.TabIndex = 42;
            label12.Text = "Résumé";
            label12.Click += Resume_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = SystemColors.ControlLightLight;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(847, 816);
            label11.Name = "label11";
            label11.Size = new Size(79, 21);
            label11.TabIndex = 41;
            label11.Text = "Collection";
            label11.Click += Collection_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = SystemColors.ControlLightLight;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(847, 758);
            label10.Name = "label10";
            label10.Size = new Size(60, 21);
            label10.TabIndex = 40;
            label10.Text = "Format";
            label10.Click += Format_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = SystemColors.ControlLightLight;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(847, 681);
            label9.Name = "label9";
            label9.Size = new Size(134, 21);
            label9.TabIndex = 39;
            label9.Text = "Nombre de pages";
            label9.Click += NbPages_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = SystemColors.ControlLightLight;
            label8.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(868, 621);
            label8.Name = "label8";
            label8.Size = new Size(160, 25);
            label8.TabIndex = 38;
            label8.Text = "Informations livre";
            label8.Click += InfoLivre_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = SystemColors.ControlLightLight;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(1208, 381);
            label7.Name = "label7";
            label7.Size = new Size(44, 21);
            label7.TabIndex = 37;
            label7.Text = "ISBN";
            label7.Click += label7_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.ControlLightLight;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(1208, 473);
            label6.Name = "label6";
            label6.Size = new Size(52, 21);
            label6.TabIndex = 36;
            label6.Text = "Genre";
            label6.Click += Genre;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.ControlLightLight;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(847, 473);
            label5.Name = "label5";
            label5.Size = new Size(61, 21);
            label5.TabIndex = 35;
            label5.Text = "Langue";
            label5.Click += Langue_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.ControlLightLight;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(847, 381);
            label4.Name = "label4";
            label4.Size = new Size(59, 21);
            label4.TabIndex = 34;
            label4.Text = "Éditeur";
            label4.Click += Editeur;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ControlLightLight;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(1208, 290);
            label3.Name = "label3";
            label3.Size = new Size(106, 21);
            label3.TabIndex = 33;
            label3.Text = "Date de sortie";
            label3.Click += DateSortie_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ControlLightLight;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(847, 290);
            label2.Name = "label2";
            label2.Size = new Size(57, 21);
            label2.TabIndex = 32;
            label2.Text = "Auteur";
            label2.Click += Auteur_Click;
            // 
            // InfoGeneral
            // 
            InfoGeneral.AccessibleRole = AccessibleRole.Window;
            InfoGeneral.AutoSize = true;
            InfoGeneral.BackColor = SystemColors.ControlLightLight;
            InfoGeneral.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            InfoGeneral.Location = new Point(847, 226);
            InfoGeneral.Name = "InfoGeneral";
            InfoGeneral.Size = new Size(206, 25);
            InfoGeneral.TabIndex = 31;
            InfoGeneral.Text = "Informations générales";
            InfoGeneral.Click += InfoGeneral_Click;
            // 
            // Classique
            // 
            Classique.AutoSize = true;
            Classique.BackColor = Color.DarkGray;
            Classique.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Classique.Location = new Point(526, 800);
            Classique.Name = "Classique";
            Classique.Size = new Size(92, 25);
            Classique.TabIndex = 30;
            Classique.Text = "Classique";
            Classique.Click += Classique_Click;
            // 
            // Enfant
            // 
            Enfant.AutoSize = true;
            Enfant.BackColor = Color.FromArgb(255, 128, 128);
            Enfant.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Enfant.Location = new Point(436, 800);
            Enfant.Name = "Enfant";
            Enfant.Size = new Size(66, 25);
            Enfant.TabIndex = 29;
            Enfant.Text = "Enfant";
            Enfant.Click += Enfant_Click;
            // 
            // Disponible
            // 
            Disponible.AutoSize = true;
            Disponible.BackColor = Color.FromArgb(128, 255, 128);
            Disponible.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Disponible.Location = new Point(307, 800);
            Disponible.Name = "Disponible";
            Disponible.Size = new Size(102, 25);
            Disponible.TabIndex = 28;
            Disponible.Text = "Disponible";
            Disponible.Click += Disponible_Click;
            // 
            // Partager
            // 
            Partager.BackColor = SystemColors.ControlLightLight;
            Partager.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Partager.ForeColor = SystemColors.ActiveCaptionText;
            Partager.Location = new Point(476, 914);
            Partager.Name = "Partager";
            Partager.Size = new Size(220, 44);
            Partager.TabIndex = 27;
            Partager.Text = "Partager";
            Partager.UseVisualStyleBackColor = false;
            Partager.Click += Partager_Click;
            // 
            // favoris
            // 
            favoris.BackColor = SystemColors.ControlLightLight;
            favoris.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            favoris.ForeColor = SystemColors.ActiveCaptionText;
            favoris.Location = new Point(230, 914);
            favoris.Name = "favoris";
            favoris.Size = new Size(220, 44);
            favoris.TabIndex = 26;
            favoris.Text = "favoris";
            favoris.UseVisualStyleBackColor = false;
            favoris.Click += favoris_Click;
            // 
            // Emprunter
            // 
            Emprunter.BackColor = SystemColors.ActiveCaptionText;
            Emprunter.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Emprunter.ForeColor = SystemColors.ButtonHighlight;
            Emprunter.Location = new Point(252, 843);
            Emprunter.Name = "Emprunter";
            Emprunter.Size = new Size(444, 52);
            Emprunter.TabIndex = 25;
            Emprunter.Text = "Empunter";
            Emprunter.UseVisualStyleBackColor = false;
            Emprunter.Click += Emprunter_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.BackgroundColor = SystemColors.ControlLightLight;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(823, 591);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(845, 347);
            dataGridView2.TabIndex = 24;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.ControlLightLight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(823, 200);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(845, 347);
            dataGridView1.TabIndex = 23;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.Click += ISBN;
            // 
            // picturebox
            // 
            picturebox.Anchor = AnchorStyles.Left;
            picturebox.BackColor = SystemColors.ControlDarkDark;
            picturebox.Location = new Point(150, 20);
            picturebox.Name = "picturebox";
            picturebox.Size = new Size(628, 1097);
            picturebox.TabIndex = 22;
            picturebox.TabStop = false;
            picturebox.Click += ImageLivre_Click;
            // 
            // txAuteur
            // 
            txAuteur.Location = new Point(847, 323);
            txAuteur.Name = "txAuteur";
            txAuteur.Size = new Size(100, 23);
            txAuteur.TabIndex = 43;
            txAuteur.Click += txtAuteur;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(847, 419);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 44;
            textBox1.Click += txtEditeur;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(847, 514);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 45;
            textBox2.Click += txtLangue;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(1208, 335);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 46;
            textBox3.Click += txtDateSortie;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(1208, 419);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(100, 23);
            textBox4.TabIndex = 47;
            textBox4.Click += txtISBN;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(1208, 514);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(100, 23);
            textBox5.TabIndex = 48;
            textBox5.Click += txtGenre;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(1008, 683);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(100, 23);
            textBox6.TabIndex = 49;
            textBox6.Click += txtNbPages;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(953, 756);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(100, 23);
            textBox7.TabIndex = 50;
            textBox7.Click += txtFormat;
            // 
            // textBox8
            // 
            textBox8.Location = new Point(953, 818);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(100, 23);
            textBox8.TabIndex = 51;
            textBox8.Click += txtCollection;
            // 
            // textBox9
            // 
            textBox9.Location = new Point(953, 872);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(100, 23);
            textBox9.TabIndex = 52;
            textBox9.Click += txtResume;
            // 
            // PageArticleController
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.None;
            Controls.Add(textBox9);
            Controls.Add(textBox8);
            Controls.Add(textBox7);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(txAuteur);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(label3);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(InfoGeneral);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label2);
            Controls.Add(Classique);
            Controls.Add(Enfant);
            Controls.Add(Disponible);
            Controls.Add(Partager);
            Controls.Add(favoris);
            Controls.Add(Emprunter);
            Controls.Add(picturebox);
            Controls.Add(dataGridView1);
            Controls.Add(dataGridView2);
            Name = "PageArticleController";
            Size = new Size(2153, 1055);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)picturebox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label InfoGeneral;
        private Label Classique;
        private Label Enfant;
        private Label Disponible;
        private Button Partager;
        private Button favoris;
        private Button Emprunter;
        private DataGridView dataGridView2;
        private DataGridView dataGridView1;
        private PictureBox picturebox;
        private TextBox txAuteur;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox textBox8;
        private TextBox textBox9;
    }
}
