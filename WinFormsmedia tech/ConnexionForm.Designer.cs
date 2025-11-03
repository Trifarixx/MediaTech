namespace WinFormsmedia_tech
{
    partial class ConnexionForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            labelTitre = new Label();
            labelNom = new Label();
            textBoxEmail = new TextBox();
            textBoxMdp = new TextBox();
            labelEmail = new Label();
            labelMdp = new Label();
            buttonValider = new Button();
            labelPropositionConnexion = new Label();
            dataGridView1 = new DataGridView();
            linkLabelInscription = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // labelTitre
            // 
            labelTitre.Anchor = AnchorStyles.Top;
            labelTitre.AutoSize = true;
            labelTitre.Font = new Font("Sans Serif Collection", 47.9999924F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelTitre.ImageAlign = ContentAlignment.TopCenter;
            labelTitre.Location = new Point(572, 111);
            labelTitre.Name = "labelTitre";
            labelTitre.Size = new Size(416, 217);
            labelTitre.TabIndex = 0;
            labelTitre.Text = "Connexion";
            labelTitre.TextAlign = ContentAlignment.TopCenter;
            labelTitre.Click += label1_Click;
            // 
            // labelNom
            // 
            labelNom.AutoSize = true;
            labelNom.Location = new Point(171, 413);
            labelNom.Name = "labelNom";
            labelNom.Size = new Size(0, 15);
            labelNom.TabIndex = 1;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Anchor = AnchorStyles.Top;
            textBoxEmail.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxEmail.Location = new Point(670, 413);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(256, 46);
            textBoxEmail.TabIndex = 2;
            textBoxEmail.TextChanged += textBox1_TextChanged;
            // 
            // textBoxMdp
            // 
            textBoxMdp.Anchor = AnchorStyles.Top;
            textBoxMdp.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxMdp.Location = new Point(670, 555);
            textBoxMdp.Name = "textBoxMdp";
            textBoxMdp.Size = new Size(256, 46);
            textBoxMdp.TabIndex = 3;
            textBoxMdp.UseSystemPasswordChar = true;
            textBoxMdp.TextChanged += textBox2_TextChanged;
            // 
            // labelEmail
            // 
            labelEmail.Anchor = AnchorStyles.Top;
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelEmail.Location = new Point(670, 357);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(100, 40);
            labelEmail.TabIndex = 4;
            labelEmail.Text = "Email :";
            // 
            // labelMdp
            // 
            labelMdp.Anchor = AnchorStyles.Top;
            labelMdp.AutoSize = true;
            labelMdp.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelMdp.Location = new Point(670, 488);
            labelMdp.Name = "labelMdp";
            labelMdp.Size = new Size(203, 40);
            labelMdp.TabIndex = 5;
            labelMdp.Text = "Mot de passe :";
            // 
            // buttonValider
            // 
            buttonValider.Anchor = AnchorStyles.Top;
            buttonValider.BackColor = Color.FromArgb(192, 255, 192);
            buttonValider.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonValider.Location = new Point(670, 647);
            buttonValider.Name = "buttonValider";
            buttonValider.Size = new Size(256, 49);
            buttonValider.TabIndex = 6;
            buttonValider.Text = "Me connecter";
            buttonValider.UseVisualStyleBackColor = false;
            // 
            // labelPropositionConnexion
            // 
            labelPropositionConnexion.Anchor = AnchorStyles.Top;
            labelPropositionConnexion.AutoSize = true;
            labelPropositionConnexion.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPropositionConnexion.Location = new Point(639, 720);
            labelPropositionConnexion.Name = "labelPropositionConnexion";
            labelPropositionConnexion.Size = new Size(212, 21);
            labelPropositionConnexion.TabIndex = 7;
            labelPropositionConnexion.Text = "Vous n'avez pas de compte ? \r\n";
            labelPropositionConnexion.TextAlign = ContentAlignment.BottomCenter;
            labelPropositionConnexion.Click += label1_Click_1;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.Location = new Point(457, 331);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(655, 443);
            dataGridView1.TabIndex = 8;
            // 
            // linkLabelInscription
            // 
            linkLabelInscription.Anchor = AnchorStyles.Top;
            linkLabelInscription.AutoSize = true;
            linkLabelInscription.Font = new Font("Segoe UI", 12F);
            linkLabelInscription.LinkColor = Color.Black;
            linkLabelInscription.Location = new Point(844, 720);
            linkLabelInscription.Name = "linkLabelInscription";
            linkLabelInscription.Size = new Size(103, 21);
            linkLabelInscription.TabIndex = 9;
            linkLabelInscription.TabStop = true;
            linkLabelInscription.Text = "Créez-en un !";
            linkLabelInscription.VisitedLinkColor = Color.Red;
            linkLabelInscription.LinkClicked += linkLabelInscription_LinkClicked;
            // 
            // ConnexionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1647, 943);
            Controls.Add(linkLabelInscription);
            Controls.Add(labelPropositionConnexion);
            Controls.Add(buttonValider);
            Controls.Add(labelMdp);
            Controls.Add(labelEmail);
            Controls.Add(textBoxMdp);
            Controls.Add(textBoxEmail);
            Controls.Add(labelNom);
            Controls.Add(labelTitre);
            Controls.Add(dataGridView1);
            Name = "ConnexionForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ConnexionForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitre;
        private Label labelNom;
        private TextBox textBoxEmail;
        private TextBox textBoxMdp;
        private Label labelEmail;
        private Label labelMdp;
        private Button buttonValider;
        private Label labelPropositionConnexion;
        private DataGridView dataGridView1;
        private LinkLabel linkLabelInscription;
    }
}