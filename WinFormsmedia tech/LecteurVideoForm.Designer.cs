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
            btn_stop = new Button();
            timerAutoHide = new System.Windows.Forms.Timer(components);
            panelControls = new Panel();
            ((System.ComponentModel.ISupportInitialize)videoView1).BeginInit();
            panelControls.SuspendLayout();
            SuspendLayout();
            // 
            // videoView1
            // 
            videoView1.BackColor = Color.Black;
            videoView1.Dock = DockStyle.Fill;
            videoView1.Location = new Point(0, 0);
            videoView1.MediaPlayer = null;
            videoView1.Name = "videoView1";
            videoView1.Size = new Size(1738, 973);
            videoView1.TabIndex = 0;
            videoView1.Text = "videoView1";
            // 
            // btn_PlayPause
            // 
            btn_PlayPause.Anchor = AnchorStyles.Bottom;
            btn_PlayPause.FlatStyle = FlatStyle.Flat;
            btn_PlayPause.Image = Properties.Resources.Play;
            btn_PlayPause.Location = new Point(800, 0);
            btn_PlayPause.Name = "btn_PlayPause";
            btn_PlayPause.Size = new Size(40, 40);
            btn_PlayPause.TabIndex = 1;
            btn_PlayPause.TextImageRelation = TextImageRelation.ImageAboveText;
            btn_PlayPause.UseVisualStyleBackColor = true;
            // 
            // btn_stop
            // 
            btn_stop.Anchor = AnchorStyles.Bottom;
            btn_stop.FlatStyle = FlatStyle.Flat;
            btn_stop.Image = Properties.Resources.Stop;
            btn_stop.Location = new Point(900, 0);
            btn_stop.Name = "btn_stop";
            btn_stop.Size = new Size(40, 40);
            btn_stop.TabIndex = 3;
            btn_stop.TextImageRelation = TextImageRelation.ImageAboveText;
            btn_stop.UseVisualStyleBackColor = true;
            // 
            // timerAutoHide
            // 
            timerAutoHide.Interval = 3000;
            // 
            // panelControls
            // 
            panelControls.Controls.Add(btn_stop);
            panelControls.Controls.Add(btn_PlayPause);
            panelControls.Dock = DockStyle.Bottom;
            panelControls.Location = new Point(0, 973);
            panelControls.Name = "panelControls";
            panelControls.Size = new Size(1738, 40);
            panelControls.TabIndex = 4;
            // 
            // LecteurVideoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1738, 1013);
            Controls.Add(videoView1);
            Controls.Add(panelControls);
            Name = "LecteurVideoForm";
            Text = "LecteurVideoForm";
            ((System.ComponentModel.ISupportInitialize)videoView1).EndInit();
            panelControls.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private LibVLCSharp.WinForms.VideoView videoView1;
        private Button btn_PlayPause;
        private Button btn_stop;
        private System.Windows.Forms.Timer timerAutoHide;
        private Panel panelControls;
    }
}