namespace WinFormsmedia_tech
{
    partial class LecteurPdfForm
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
            panelViewer = new Panel();
            SuspendLayout();
            // 
            // panelViewer
            // 
            panelViewer.BackColor = SystemColors.Control;
            panelViewer.Dock = DockStyle.Fill;
            panelViewer.Location = new Point(0, 0);
            panelViewer.Name = "panelViewer";
            panelViewer.Size = new Size(800, 450);
            panelViewer.TabIndex = 1;
            // 
            // LecteurPdfForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelViewer);
            Name = "LecteurPdfForm";
            Text = "LecteurPdfForm";
            ResumeLayout(false);
        }

        #endregion

        private Panel panelViewer;
    }
}