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
            FondPanel = new Panel();
            lbl_TempsCourant = new Label();
            SuspendLayout();
            // 
            // BtnPlayPause
            // 
            BtnPlayPause.Location = new Point(292, 241);
            BtnPlayPause.Name = "BtnPlayPause";
            BtnPlayPause.Size = new Size(88, 25);
            BtnPlayPause.TabIndex = 0;
            BtnPlayPause.Text = "PlayPause";
            BtnPlayPause.UseVisualStyleBackColor = true;
            BtnPlayPause.Click += BtnPlay_Click;
            // 
            // BtnStop
            // 
            BtnStop.Location = new Point(342, 299);
            BtnStop.Name = "BtnStop";
            BtnStop.Size = new Size(75, 23);
            BtnStop.TabIndex = 1;
            BtnStop.Text = "Stop";
            BtnStop.UseVisualStyleBackColor = true;
            BtnStop.Click += BtnStop_Click;
            // 
            // FondPanel
            // 
            FondPanel.Location = new Point(324, 141);
            FondPanel.Name = "FondPanel";
            FondPanel.Size = new Size(200, 100);
            FondPanel.TabIndex = 2;
            // 
            // lbl_TempsCourant
            // 
            lbl_TempsCourant.AutoSize = true;
            lbl_TempsCourant.Location = new Point(124, 367);
            lbl_TempsCourant.Name = "lbl_TempsCourant";
            lbl_TempsCourant.Size = new Size(34, 15);
            lbl_TempsCourant.TabIndex = 3;
            lbl_TempsCourant.Text = "00:00";
            // 
            // LecteurAudio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lbl_TempsCourant);
            Controls.Add(FondPanel);
            Controls.Add(BtnStop);
            Controls.Add(BtnPlayPause);
            Name = "LecteurAudio";
            Text = "LecteurAudio";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnPlayPause;
        private Button BtnStop;
        private Panel FondPanel;
        private Label lbl_TempsCourant;
    }
}