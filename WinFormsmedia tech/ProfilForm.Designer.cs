namespace WinFormsmedia_tech
{
    partial class ProfilForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfilForm));
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            mdpUser = new Button();
            colorPickerButton1 = new Syncfusion.Windows.Forms.ColorPickerButton();
            Profil = new Button();
            panel2 = new Panel();
            label3 = new Label();
            label5 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtNom = new TextBox();
            txtPrenom = new TextBox();
            txtMail = new TextBox();
            txtmdp = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.InitialImage = (Image)resources.GetObject("pictureBox1.InitialImage");
            pictureBox1.Location = new Point(29, 42);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(263, 189);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.AppWorkspace;
            panel1.Controls.Add(mdpUser);
            panel1.Controls.Add(colorPickerButton1);
            panel1.Controls.Add(Profil);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.ForeColor = SystemColors.AppWorkspace;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(337, 1018);
            panel1.TabIndex = 2;
            // 
            // mdpUser
            // 
            mdpUser.BackColor = SystemColors.AppWorkspace;
            mdpUser.Font = new Font("DM Sans 14pt SemiBold", 14.2499981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            mdpUser.ForeColor = SystemColors.ActiveCaptionText;
            mdpUser.Location = new Point(45, 528);
            mdpUser.Name = "mdpUser";
            mdpUser.Size = new Size(220, 43);
            mdpUser.TabIndex = 3;
            mdpUser.Text = "Favoris";
            mdpUser.UseVisualStyleBackColor = false;
            mdpUser.Click += favoris_Click;
            // 
            // colorPickerButton1
            // 
            colorPickerButton1.AccessibilityEnabled = true;
            colorPickerButton1.BeforeTouchSize = new Size(220, 43);
            colorPickerButton1.Font = new Font("DM Sans 14pt SemiBold", 14.2499981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            colorPickerButton1.ForeColor = SystemColors.ActiveCaptionText;
            colorPickerButton1.Location = new Point(45, 291);
            colorPickerButton1.Name = "colorPickerButton1";
            colorPickerButton1.Size = new Size(220, 43);
            colorPickerButton1.TabIndex = 2;
            colorPickerButton1.Text = "Mon Profil";
            colorPickerButton1.Click += btnMonProfil;
            // 
            // Profil
            // 
            Profil.BackColor = SystemColors.AppWorkspace;
            Profil.Font = new Font("DM Sans 14pt SemiBold", 14.2499981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Profil.ForeColor = SystemColors.ActiveCaptionText;
            Profil.Location = new Point(45, 409);
            Profil.Name = "Profil";
            Profil.Size = new Size(220, 43);
            Profil.TabIndex = 1;
            Profil.Text = "Historique";
            Profil.UseVisualStyleBackColor = false;
            Profil.Click += MonHistorique_Click;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.AppWorkspace;
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txtNom);
            panel2.Controls.Add(txtPrenom);
            panel2.Controls.Add(txtMail);
            panel2.Controls.Add(txtmdp);
            panel2.Location = new Point(465, 125);
            panel2.Name = "panel2";
            panel2.Size = new Size(1209, 826);
            panel2.TabIndex = 3;
            panel2.Paint += panel2_Paint;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("DM Sans 14pt Medium", 14.2499981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(538, 348);
            label3.Name = "label3";
            label3.Size = new Size(143, 25);
            label3.TabIndex = 6;
            label3.Text = "Mot de passe :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("DM Sans 14pt Medium", 14.2499981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(538, 135);
            label5.Name = "label5";
            label5.Size = new Size(58, 25);
            label5.TabIndex = 5;
            label5.Text = "Mail :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("DM Sans 14pt Medium", 14.2499981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(53, 348);
            label2.Name = "label2";
            label2.Size = new Size(89, 25);
            label2.TabIndex = 2;
            label2.Text = "Prénom :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("DM Sans 14pt Medium", 14.2499981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(53, 135);
            label1.Name = "label1";
            label1.Size = new Size(62, 25);
            label1.TabIndex = 1;
            label1.Text = "Nom :";
            // 
            // txtNom
            // 
            txtNom.Font = new Font("DM Sans 14pt Medium", 11F);
            txtNom.Location = new Point(53, 170);
            txtNom.Name = "txtNom";
            txtNom.Size = new Size(300, 27);
            txtNom.TabIndex = 7;
            // 
            // txtPrenom
            // 
            txtPrenom.Font = new Font("DM Sans 14pt Medium", 11F);
            txtPrenom.Location = new Point(53, 383);
            txtPrenom.Name = "txtPrenom";
            txtPrenom.Size = new Size(300, 27);
            txtPrenom.TabIndex = 8;
            // 
            // txtMail
            // 
            txtMail.Font = new Font("DM Sans 14pt Medium", 11F);
            txtMail.Location = new Point(538, 170);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(300, 27);
            txtMail.TabIndex = 9;
            // 
            // txtmdp
            // 
            txtmdp.Font = new Font("DM Sans 14pt Medium", 11F);
            txtmdp.Location = new Point(538, 383);
            txtmdp.Name = "txtmdp";
            txtmdp.Size = new Size(300, 27);
            txtmdp.TabIndex = 10;
            // 
            // ProfilForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(2155, 1018);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "ProfilForm";
            RightToLeft = RightToLeft.No;
            Text = "ProfilForm";
            Load += ProfilForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Panel panel1;
        private Button Profil;
        private Button mdpUser;
        private Syncfusion.Windows.Forms.ColorPickerButton colorPickerButton1;
        private Panel panel2;
        private Label label2;
        private Label label1;
        private Label label3;
        private Label label5;
        private TextBox txtNom;
        private TextBox txtPrenom;
        private TextBox txtMail;
        private TextBox txtmdp;

    }
}