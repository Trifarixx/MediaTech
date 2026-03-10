namespace WinFormsmedia_tech
{
    partial class LecteurAudio
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
            BtnPlayPause = new Button();
            BtnStop = new Button();
            PlayerPanel = new Panel();
            progressBar = new ProgressBar();
            lbl_Duree = new Label();
            lbl_Titre = new Label();
            lbl_TempsCourant = new Label();
            PictureBoxCover = new PictureBox();
            lbl_Artiste = new Label();
            PlayerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBoxCover).BeginInit();
            SuspendLayout();
            // 
            // BtnPlayPause
            // 
            BtnPlayPause.Location = new Point(33, 229);
            BtnPlayPause.Name = "BtnPlayPause";
            BtnPlayPause.Size = new Size(88, 25);
            BtnPlayPause.TabIndex = 0;
            BtnPlayPause.Text = "PlayPause";
            BtnPlayPause.UseVisualStyleBackColor = true;
            BtnPlayPause.Click += BtnPlay_Click;
            // 
            // BtnStop
            // 
            BtnStop.Location = new Point(167, 229);
            BtnStop.Name = "BtnStop";
            BtnStop.Size = new Size(75, 23);
            BtnStop.TabIndex = 1;
            BtnStop.Text = "Stop";
            BtnStop.UseVisualStyleBackColor = true;
            BtnStop.Click += BtnStop_Click;
            // 
            // PlayerPanel
            // 
            PlayerPanel.Controls.Add(progressBar);
            PlayerPanel.Controls.Add(lbl_Duree);
            PlayerPanel.Controls.Add(lbl_Titre);
            PlayerPanel.Controls.Add(lbl_TempsCourant);
            PlayerPanel.Controls.Add(PictureBoxCover);
            PlayerPanel.Controls.Add(BtnStop);
            PlayerPanel.Controls.Add(BtnPlayPause);
            PlayerPanel.Controls.Add(lbl_Artiste);
            PlayerPanel.Location = new Point(233, 12);
            PlayerPanel.Name = "PlayerPanel";
            PlayerPanel.Size = new Size(291, 397);
            PlayerPanel.TabIndex = 2;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(104, 273);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(100, 23);
            progressBar.TabIndex = 7;
            progressBar.Click += progressBar_Click;
            // 
            // lbl_Duree
            // 
            lbl_Duree.AutoSize = true;
            lbl_Duree.Location = new Point(245, 281);
            lbl_Duree.Name = "lbl_Duree";
            lbl_Duree.Size = new Size(34, 15);
            lbl_Duree.TabIndex = 4;
            lbl_Duree.Text = "00:00";
            // 
            // lbl_Titre
            // 
            lbl_Titre.AutoSize = true;
            lbl_Titre.Location = new Point(127, 195);
            lbl_Titre.Name = "lbl_Titre";
            lbl_Titre.Size = new Size(31, 15);
            lbl_Titre.TabIndex = 6;
            lbl_Titre.Text = "Titre";
            // 
            // lbl_TempsCourant
            // 
            lbl_TempsCourant.AutoSize = true;
            lbl_TempsCourant.Location = new Point(33, 281);
            lbl_TempsCourant.Name = "lbl_TempsCourant";
            lbl_TempsCourant.Size = new Size(34, 15);
            lbl_TempsCourant.TabIndex = 3;
            lbl_TempsCourant.Text = "00:00";
            lbl_TempsCourant.Click += lbl_TempsCourant_Click;
            // 
            // PictureBoxCover
            // 
            PictureBoxCover.Location = new Point(80, 39);
            PictureBoxCover.Name = "PictureBoxCover";
            PictureBoxCover.Size = new Size(144, 134);
            PictureBoxCover.TabIndex = 5;
            PictureBoxCover.TabStop = false;
            // 
            // lbl_Artiste
            // 
            lbl_Artiste.AutoSize = true;
            lbl_Artiste.Location = new Point(80, 195);
            lbl_Artiste.Name = "lbl_Artiste";
            lbl_Artiste.Size = new Size(41, 15);
            lbl_Artiste.TabIndex = 5;
            lbl_Artiste.Text = "Artiste";
            // 
            // LecteurAudio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(PlayerPanel);
            Name = "LecteurAudio";
            Text = "LecteurAudio";
            PlayerPanel.ResumeLayout(false);
            PlayerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBoxCover).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button BtnPlayPause;
        private Button BtnStop;
        private Panel PlayerPanel;
        private Label lbl_TempsCourant;
        private Label lbl_Duree;
        private PictureBox PictureBoxCover;
        private Label lbl_Artiste;
        private Label lbl_Titre;
        private ProgressBar progressBar;
    }
}