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
            btnPlay = new Button();
            btnStop = new Button();
            btnPrecedent = new Button();
            btnSuivant = new Button();
            pictureBoxPochette = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPochette).BeginInit();
            SuspendLayout();
            // 
            // btnPlay
            // 
            btnPlay.Location = new Point(375, 279);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(75, 23);
            btnPlay.TabIndex = 0;
            btnPlay.Text = "Lecture";
            btnPlay.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(471, 279);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(75, 23);
            btnStop.TabIndex = 1;
            btnStop.Text = "Pause";
            btnStop.UseVisualStyleBackColor = true;
            // 
            // btnPrecedent
            // 
            btnPrecedent.Location = new Point(225, 279);
            btnPrecedent.Name = "btnPrecedent";
            btnPrecedent.Size = new Size(75, 23);
            btnPrecedent.TabIndex = 2;
            btnPrecedent.Text = "Précédent";
            btnPrecedent.UseVisualStyleBackColor = true;
            // 
            // btnSuivant
            // 
            btnSuivant.Location = new Point(629, 279);
            btnSuivant.Name = "btnSuivant";
            btnSuivant.Size = new Size(75, 23);
            btnSuivant.TabIndex = 3;
            btnSuivant.Text = "Suivant";
            btnSuivant.UseVisualStyleBackColor = true;
            // 
            // pictureBoxPochette
            // 
            pictureBoxPochette.Location = new Point(356, 58);
            pictureBoxPochette.Name = "pictureBoxPochette";
            pictureBoxPochette.Size = new Size(100, 100);
            pictureBoxPochette.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxPochette.TabIndex = 4;
            pictureBoxPochette.TabStop = false;
            // 
            // LecteurAudio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBoxPochette);
            Controls.Add(btnSuivant);
            Controls.Add(btnPrecedent);
            Controls.Add(btnStop);
            Controls.Add(btnPlay);
            Name = "LecteurAudio";
            Text = "LecteurAudio";
            ((System.ComponentModel.ISupportInitialize)pictureBoxPochette).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnPlay;
        private Button btnStop;
        private Button btnPrecedent;
        private Button btnSuivant;
        private PictureBox pictureBoxPochette;
    }
}