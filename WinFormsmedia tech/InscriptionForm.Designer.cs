namespace WinFormsmedia_tech
{
    partial class InscriptionForm
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
            labelPropositionConnexion = new Label();
            buttonCreationCompte = new Button();
            labelNomFamille = new Label();
            labelPrenom = new Label();
            textBoxNom = new TextBox();
            textBoxPrenom = new TextBox();
            labelNom = new Label();
            labelTitre = new Label();
            labelMail = new Label();
            textBoxMail = new TextBox();
            labelMdp = new Label();
            textBox2 = new TextBox();
            dataGridView2 = new DataGridView();
            linkLabelConnexion = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // labelPropositionConnexion
            // 
            labelPropositionConnexion.Anchor = AnchorStyles.Top;
            labelPropositionConnexion.AutoSize = true;
            labelPropositionConnexion.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPropositionConnexion.Location = new Point(615, 744);
            labelPropositionConnexion.Name = "labelPropositionConnexion";
            labelPropositionConnexion.Size = new Size(238, 21);
            labelPropositionConnexion.TabIndex = 16;
            labelPropositionConnexion.Text = "Vous possèdez déjà un compte ? \r\n";
            labelPropositionConnexion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonCreationCompte
            // 
            buttonCreationCompte.Anchor = AnchorStyles.Top;
            buttonCreationCompte.BackColor = Color.FromArgb(192, 255, 192);
            buttonCreationCompte.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonCreationCompte.Location = new Point(657, 669);
            buttonCreationCompte.Name = "buttonCreationCompte";
            buttonCreationCompte.Size = new Size(276, 49);
            buttonCreationCompte.TabIndex = 15;
            buttonCreationCompte.Text = "Créer mon compte";
            buttonCreationCompte.UseVisualStyleBackColor = false;
            // 
            // labelNomFamille
            // 
            labelNomFamille.Anchor = AnchorStyles.Top;
            labelNomFamille.AutoSize = true;
            labelNomFamille.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelNomFamille.Location = new Point(493, 507);
            labelNomFamille.Name = "labelNomFamille";
            labelNomFamille.Size = new Size(95, 40);
            labelNomFamille.TabIndex = 14;
            labelNomFamille.Text = "Nom :";
            // 
            // labelPrenom
            // 
            labelPrenom.Anchor = AnchorStyles.Top;
            labelPrenom.AutoSize = true;
            labelPrenom.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPrenom.Location = new Point(493, 368);
            labelPrenom.Name = "labelPrenom";
            labelPrenom.Size = new Size(130, 40);
            labelPrenom.TabIndex = 13;
            labelPrenom.Text = "Prenom :";
            // 
            // textBoxNom
            // 
            textBoxNom.Anchor = AnchorStyles.Top;
            textBoxNom.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxNom.Location = new Point(493, 572);
            textBoxNom.Name = "textBoxNom";
            textBoxNom.Size = new Size(256, 46);
            textBoxNom.TabIndex = 12;
            // 
            // textBoxPrenom
            // 
            textBoxPrenom.Anchor = AnchorStyles.Top;
            textBoxPrenom.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxPrenom.Location = new Point(493, 433);
            textBoxPrenom.Name = "textBoxPrenom";
            textBoxPrenom.Size = new Size(256, 46);
            textBoxPrenom.TabIndex = 11;
            // 
            // labelNom
            // 
            labelNom.AutoSize = true;
            labelNom.Location = new Point(254, 378);
            labelNom.Name = "labelNom";
            labelNom.Size = new Size(0, 15);
            labelNom.TabIndex = 10;
            // 
            // labelTitre
            // 
            labelTitre.Anchor = AnchorStyles.Top;
            labelTitre.AutoSize = true;
            labelTitre.Font = new Font("Sans Serif Collection", 47.9999924F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelTitre.ImageAlign = ContentAlignment.TopCenter;
            labelTitre.Location = new Point(588, 121);
            labelTitre.Name = "labelTitre";
            labelTitre.Size = new Size(417, 217);
            labelTitre.TabIndex = 9;
            labelTitre.Text = "Inscription";
            labelTitre.TextAlign = ContentAlignment.TopCenter;
            // 
            // labelMail
            // 
            labelMail.Anchor = AnchorStyles.Top;
            labelMail.AutoSize = true;
            labelMail.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelMail.Location = new Point(818, 368);
            labelMail.Name = "labelMail";
            labelMail.Size = new Size(86, 40);
            labelMail.TabIndex = 18;
            labelMail.Text = "Mail :";
            // 
            // textBoxMail
            // 
            textBoxMail.Anchor = AnchorStyles.Top;
            textBoxMail.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxMail.Location = new Point(818, 433);
            textBoxMail.Name = "textBoxMail";
            textBoxMail.Size = new Size(256, 46);
            textBoxMail.TabIndex = 19;
            // 
            // labelMdp
            // 
            labelMdp.Anchor = AnchorStyles.Top;
            labelMdp.AutoSize = true;
            labelMdp.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelMdp.Location = new Point(818, 507);
            labelMdp.Name = "labelMdp";
            labelMdp.Size = new Size(203, 40);
            labelMdp.TabIndex = 20;
            labelMdp.Text = "Mot de passe :";
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Top;
            textBox2.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(818, 572);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(256, 46);
            textBox2.TabIndex = 21;
            textBox2.UseSystemPasswordChar = true;
            // 
            // dataGridView2
            // 
            dataGridView2.Anchor = AnchorStyles.Top;
            dataGridView2.BackgroundColor = Color.FromArgb(75, 86, 93);
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(457, 339);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(655, 460);
            dataGridView2.TabIndex = 22;
            // 
            // linkLabelConnexion
            // 
            linkLabelConnexion.Anchor = AnchorStyles.Top;
            linkLabelConnexion.AutoSize = true;
            linkLabelConnexion.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabelConnexion.LinkColor = Color.Black;
            linkLabelConnexion.Location = new Point(847, 744);
            linkLabelConnexion.Name = "linkLabelConnexion";
            linkLabelConnexion.Size = new Size(130, 21);
            linkLabelConnexion.TabIndex = 23;
            linkLabelConnexion.TabStop = true;
            linkLabelConnexion.Text = "Connectez-vous !";
            linkLabelConnexion.VisitedLinkColor = Color.Red;
            // 
            // InscriptionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1496, 758);
            Controls.Add(linkLabelConnexion);
            Controls.Add(textBox2);
            Controls.Add(labelMdp);
            Controls.Add(textBoxMail);
            Controls.Add(labelMail);
            Controls.Add(labelPropositionConnexion);
            Controls.Add(buttonCreationCompte);
            Controls.Add(labelNomFamille);
            Controls.Add(labelPrenom);
            Controls.Add(textBoxNom);
            Controls.Add(textBoxPrenom);
            Controls.Add(labelNom);
            Controls.Add(labelTitre);
            Controls.Add(dataGridView2);
            Name = "InscriptionForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "InscriptionForm";
            Load += InscriptionForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelPropositionConnexion;
        private Button buttonCreationCompte;
        private Label labelNomFamille;
        private Label labelPrenom;
        private TextBox textBoxNom;
        private TextBox textBoxPrenom;
        private Label labelNom;
        private Label labelTitre;
        private Label labelMail;
        private TextBox textBoxMail;
        private Label labelMdp;
        private TextBox textBox2;
        private DataGridView dataGridView2;
        private LinkLabel linkLabelConnexion;
    }
}