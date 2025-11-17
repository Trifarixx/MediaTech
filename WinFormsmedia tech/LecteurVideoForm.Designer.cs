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
            videoView1 = new LibVLCSharp.WinForms.VideoView();
            btn_play = new Button();
            btn_stop = new Button();
            btn_exit = new Button();
            ((System.ComponentModel.ISupportInitialize)videoView1).BeginInit();
            SuspendLayout();
            // 
            // videoView1
            // 
            videoView1.BackColor = Color.Black;
            videoView1.Location = new Point(-2, -1);
            videoView1.MediaPlayer = null;
            videoView1.Name = "videoView1";
            videoView1.Size = new Size(2560, 1440);
            videoView1.TabIndex = 0;
            videoView1.Text = "videoView1";
            // 
            // btn_play
            // 
            btn_play.Location = new Point(806, 978);
            btn_play.Name = "btn_play";
            btn_play.Size = new Size(75, 23);
            btn_play.TabIndex = 1;
            btn_play.Text = "Play";
            btn_play.UseVisualStyleBackColor = true;
            btn_play.Click += btn_play_Click;
            // 
            // btn_stop
            // 
            btn_stop.Location = new Point(606, 978);
            btn_stop.Name = "btn_stop";
            btn_stop.Size = new Size(75, 23);
            btn_stop.TabIndex = 2;
            btn_stop.Text = "Pause";
            btn_stop.UseVisualStyleBackColor = true;
            btn_stop.Click += btn_stop_Click;
            // 
            // btn_exit
            // 
            btn_exit.Location = new Point(1651, 12);
            btn_exit.Name = "btn_exit";
            btn_exit.Size = new Size(75, 23);
            btn_exit.TabIndex = 3;
            btn_exit.Text = "Quitter";
            btn_exit.UseVisualStyleBackColor = true;
            btn_exit.Click += btn_exit_Click;
            // 
            // LecteurVideoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1738, 1013);
            Controls.Add(btn_exit);
            Controls.Add(btn_stop);
            Controls.Add(btn_play);
            Controls.Add(videoView1);
            Name = "LecteurVideoForm";
            Text = "LecteurVideoForm";
            ((System.ComponentModel.ISupportInitialize)videoView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private LibVLCSharp.WinForms.VideoView videoView1;
        private Button btn_play;
        private Button btn_stop;
        private Button btn_exit;
    }
}