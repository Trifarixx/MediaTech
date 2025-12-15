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
            button2 = new Button();
            button1 = new Button();
            colorPickerButton1 = new Syncfusion.Windows.Forms.ColorPickerButton();
            Profil = new Button();
            panel2 = new Panel();
            button10 = new Button();
            button8 = new Button();
            button7 = new Button();
            button4 = new Button();
            label3 = new Label();
            label5 = new Label();
            label2 = new Label();
            label1 = new Label();
            button3 = new Button();
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
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
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
            // button2
            // 
            button2.BackColor = SystemColors.AppWorkspace;
            button2.Font = new Font("DM Sans 14pt SemiBold", 14.2499981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.ActiveCaptionText;
            button2.Location = new Point(45, 654);
            button2.Name = "button2";
            button2.Size = new Size(220, 43);
            button2.TabIndex = 4;
            button2.Text = "Paramètres";
            button2.UseVisualStyleBackColor = false;
            button2.Click += Param_Click;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.AppWorkspace;
            button1.Font = new Font("DM Sans 14pt SemiBold", 14.2499981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ActiveCaptionText;
            button1.Location = new Point(45, 528);
            button1.Name = "button1";
            button1.Size = new Size(220, 43);
            button1.TabIndex = 3;
            button1.Text = "Favoris";
            button1.UseVisualStyleBackColor = false;
            button1.Click += Favoris_Click;
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
            panel2.Controls.Add(button10);
            panel2.Controls.Add(button8);
            panel2.Controls.Add(button7);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(button3);
            panel2.Location = new Point(465, 139);
            panel2.Name = "panel2";
            panel2.Size = new Size(1209, 812);
            panel2.TabIndex = 3;
            panel2.Paint += panel2_Paint;
            // 
            // button10
            // 
            button10.Location = new Point(561, 417);
            button10.Name = "button10";
            button10.Size = new Size(133, 43);
            button10.TabIndex = 14;
            button10.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.Location = new Point(73, 417);
            button8.Name = "button8";
            button8.Size = new Size(133, 43);
            button8.TabIndex = 12;
            button8.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Location = new Point(561, 195);
            button7.Name = "button7";
            button7.Size = new Size(133, 43);
            button7.TabIndex = 11;
            button7.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(73, 195);
            button4.Name = "button4";
            button4.Size = new Size(133, 43);
            button4.TabIndex = 8;
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
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
            label1.Click += label1_Click;
            // 
            // button3
            // 
            button3.Font = new Font("DM Sans 14pt Medium", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(40, 21);
            button3.Name = "button3";
            button3.Size = new Size(202, 36);
            button3.TabIndex = 0;
            button3.Text = "Mon profil";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
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
        private Button button1;
        private Syncfusion.Windows.Forms.ColorPickerButton colorPickerButton1;
        private Button button2;
        private Panel panel2;
        private Button button3;
        private Label label2;
        private Label label1;
        private Label label3;
        private Label label5;
        private Button button4;
        private Button button8;
        private Button button7;
        private Button button10;
    }
}