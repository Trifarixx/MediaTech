namespace WinFormsmedia_tech
{
    partial class NotificationForm
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
            dataGridViewNotifications = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewNotifications).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewNotifications
            // 
            dataGridViewNotifications.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewNotifications.Location = new Point(260, 120);
            dataGridViewNotifications.Name = "dataGridViewNotifications";
            dataGridViewNotifications.Size = new Size(240, 150);
            dataGridViewNotifications.TabIndex = 0;
          
            // 
            // NotificationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewNotifications);
            Name = "NotificationForm";
            Text = "NotificationForm";
            ((System.ComponentModel.ISupportInitialize)dataGridViewNotifications).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewNotifications;
    }
}