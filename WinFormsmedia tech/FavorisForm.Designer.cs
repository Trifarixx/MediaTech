namespace WinFormsmedia_tech
{
    partial class FavorisForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FavorisForm));
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("DM Sans 14pt Black", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(212, 43);
            label1.Name = "label1";
            label1.Size = new Size(186, 35);
            label1.TabIndex = 1;
            label1.Text = "MES FAVORIS";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.ErrorImage = (Image)resources.GetObject("pictureBox1.ErrorImage");
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.InitialImage = (Image)resources.GetObject("pictureBox1.InitialImage");
            pictureBox1.Location = new Point(123, 27);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(70, 63);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkKhaki;
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(-19, 110);
            panel1.Name = "panel1";
            panel1.Size = new Size(1341, 50);
            panel1.TabIndex = 3;
            // 
            // button3
            // 
            button3.ForeColor = Color.Black;
            button3.Location = new Point(545, 3);
            button3.Name = "button3";
            button3.Size = new Size(111, 44);
            button3.TabIndex = 6;
            button3.Text = "CD AUDIO";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.ForeColor = Color.Black;
            button2.Location = new Point(812, 3);
            button2.Name = "button2";
            button2.Size = new Size(111, 44);
            button2.TabIndex = 5;
            button2.Text = "DVD";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.ForeColor = Color.Black;
            button1.Location = new Point(277, 3);
            button1.Name = "button1";
            button1.Size = new Size(111, 44);
            button1.TabIndex = 4;
            button1.Text = "LIVRES";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FavorisForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(1302, 797);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Name = "FavorisForm";
            Text = "FavorisForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox pictureBox1;
        private Panel panel1;
        private Button button1;
        private Button button3;
        private Button button2;
    }
}