namespace WinFormsmedia_tech
{
    partial class LecteurVideoForm
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
            videoView1 = new LibVLCSharp.WinForms.VideoView();
            btn_PlayPause = new Button();
            btn_Stop = new Button();
            timerAutoHide = new System.Windows.Forms.Timer(components);
            panelControls = new Panel();
            lblTempsTotal = new Label();
            lblTempsCourant = new Label();
            trackBarVideo = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)videoView1).BeginInit();
            panelControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarVideo).BeginInit();
            SuspendLayout();
            // 
            // videoView1
            // 
            videoView1.BackColor = Color.Black;
            videoView1.Dock = DockStyle.Fill;
            videoView1.Location = new Point(0, 0);
            videoView1.MediaPlayer = null;
            videoView1.Name = "videoView1";
            videoView1.Size = new Size(2089, 973);
            videoView1.TabIndex = 0;
            videoView1.Text = "videoView1";
            // 
            // btn_PlayPause
            // 
            btn_PlayPause.Anchor = AnchorStyles.Bottom;
            btn_PlayPause.FlatStyle = FlatStyle.Flat;
            btn_PlayPause.Image = Properties.Resources.Play;
            btn_PlayPause.Location = new Point(985, 12);
            btn_PlayPause.Name = "btn_PlayPause";
            btn_PlayPause.Size = new Size(40, 40);
            btn_PlayPause.TabIndex = 1;
            btn_PlayPause.TextImageRelation = TextImageRelation.ImageAboveText;
            btn_PlayPause.UseVisualStyleBackColor = true;
            // 
            // btn_Stop
            // 
            btn_Stop.Anchor = AnchorStyles.Bottom;
            btn_Stop.FlatStyle = FlatStyle.Flat;
            btn_Stop.Image = Properties.Resources.Stop;
            btn_Stop.Location = new Point(1031, 12);
            btn_Stop.Name = "btn_Stop";
            btn_Stop.Size = new Size(40, 40);
            btn_Stop.TabIndex = 3;
            btn_Stop.TextImageRelation = TextImageRelation.ImageAboveText;
            btn_Stop.UseVisualStyleBackColor = true;
            // 
            // timerAutoHide
            // 
            timerAutoHide.Interval = 3000;
            // 
            // panelControls
            // 
            panelControls.Controls.Add(lblTempsTotal);
            panelControls.Controls.Add(lblTempsCourant);
            panelControls.Controls.Add(btn_Stop);
            panelControls.Controls.Add(btn_PlayPause);
            panelControls.Controls.Add(trackBarVideo);
            panelControls.Dock = DockStyle.Bottom;
            panelControls.Location = new Point(0, 973);
            panelControls.Name = "panelControls";
            panelControls.Size = new Size(2089, 40);
            panelControls.TabIndex = 4;
            // 
            // lblTempsTotal
            // 
            lblTempsTotal.AutoSize = true;
            lblTempsTotal.ForeColor = Color.White;
            lblTempsTotal.Location = new Point(2039, 25);
            lblTempsTotal.Name = "lblTempsTotal";
            lblTempsTotal.Size = new Size(38, 15);
            lblTempsTotal.TabIndex = 6;
            lblTempsTotal.Text = "label1";
            // 
            // lblTempsCourant
            // 
            lblTempsCourant.AutoSize = true;
            lblTempsCourant.ForeColor = Color.White;
            lblTempsCourant.Location = new Point(14, 25);
            lblTempsCourant.Name = "lblTempsCourant";
            lblTempsCourant.Size = new Size(38, 15);
            lblTempsCourant.TabIndex = 5;
            lblTempsCourant.Text = "label1";
            // 
            // trackBarVideo
            // 
            trackBarVideo.AutoSize = false;
            trackBarVideo.Dock = DockStyle.Top;
            trackBarVideo.Location = new Point(0, 0);
            trackBarVideo.Name = "trackBarVideo";
            trackBarVideo.Size = new Size(2089, 40);
            trackBarVideo.TabIndex = 4;
            trackBarVideo.TickStyle = TickStyle.None;
            // 
            // LecteurVideoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2089, 1013);
            Controls.Add(videoView1);
            Controls.Add(panelControls);
            Name = "LecteurVideoForm";
            Text = "LecteurVideoForm";
            ((System.ComponentModel.ISupportInitialize)videoView1).EndInit();
            panelControls.ResumeLayout(false);
            panelControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarVideo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private LibVLCSharp.WinForms.VideoView videoView1;
        private Button btn_PlayPause;
        private Button btn_Stop;
        private System.Windows.Forms.Timer timerAutoHide;
        private Panel panelControls;
        private TrackBar trackBarVideo;
        private Label lblTempsCourant;
        private Label lblTempsTotal;
    }
}