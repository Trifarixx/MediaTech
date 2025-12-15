namespace WinFormsmedia_tech
{
    partial class HistoriqueForm
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
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            dataGridView1 = new DataGridView();
            dataGridView2 = new DataGridView();
            dataGridView3 = new DataGridView();
            autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("DM Sans 14pt Black", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(86, 70);
            label1.Name = "label1";
            label1.Size = new Size(427, 35);
            label1.TabIndex = 0;
            label1.Text = "CONSULTATION DES EMPRUNTS";
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.Font = new Font("DM Sans 14pt SemiBold", 14.2499981F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            button1.Location = new Point(86, 520);
            button1.Name = "button1";
            button1.Size = new Size(257, 42);
            button1.TabIndex = 1;
            button1.Text = "Emprunts Actuels";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("DM Sans 14pt SemiBold", 14.2499981F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            button2.Location = new Point(373, 520);
            button2.Name = "button2";
            button2.Size = new Size(257, 42);
            button2.TabIndex = 2;
            button2.Text = "Emprunts Passés";
            button2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(86, 150);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1033, 105);
            dataGridView1.TabIndex = 3;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(86, 300);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(270, 130);
            dataGridView2.TabIndex = 4;
            // 
            // dataGridView3
            // 
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Location = new Point(399, 300);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.Size = new Size(270, 130);
            dataGridView3.TabIndex = 5;
            // 
            // autoLabel1
            // 
            autoLabel1.BackColor = SystemColors.ControlDark;
            autoLabel1.Location = new Point(116, 161);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(92, 15);
            autoLabel1.TabIndex = 6;
            autoLabel1.Text = "Nom et Prénom";
            autoLabel1.Click += autoLabel1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ButtonShadow;
            label2.Font = new Font("DM Sans 14pt", 14.2499981F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(130, 326);
            label2.Name = "label2";
            label2.Size = new Size(172, 25);
            label2.TabIndex = 7;
            label2.Text = "Empunts en cours";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ButtonShadow;
            label3.Font = new Font("DM Sans 14pt", 14.2499981F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(457, 326);
            label3.Name = "label3";
            label3.Size = new Size(158, 25);
            label3.TabIndex = 8;
            label3.Text = "Empunts passés";
            // 
            // HistoriqueForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(1197, 757);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(autoLabel1);
            Controls.Add(dataGridView3);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "HistoriqueForm";
            Text = "HistoriqueForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private DataGridView dataGridView3;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Label label2;
        private Label label3;
    }
}