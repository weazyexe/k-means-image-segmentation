namespace k_means_image_segmentation
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.SettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.SaveFileButton = new System.Windows.Forms.Button();
            this.ClusterButton = new System.Windows.Forms.Button();
            this.InputKLabel = new System.Windows.Forms.Label();
            this.KTextBox = new System.Windows.Forms.TextBox();
            this.ClearButton = new System.Windows.Forms.Button();
            this.ImportButton = new System.Windows.Forms.Button();
            this.PicBox = new System.Windows.Forms.PictureBox();
            this.SettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // SettingsGroupBox
            // 
            resources.ApplyResources(this.SettingsGroupBox, "SettingsGroupBox");
            this.SettingsGroupBox.Controls.Add(this.SaveFileButton);
            this.SettingsGroupBox.Controls.Add(this.ClusterButton);
            this.SettingsGroupBox.Controls.Add(this.InputKLabel);
            this.SettingsGroupBox.Controls.Add(this.KTextBox);
            this.SettingsGroupBox.Controls.Add(this.ClearButton);
            this.SettingsGroupBox.Controls.Add(this.ImportButton);
            this.SettingsGroupBox.Name = "SettingsGroupBox";
            this.SettingsGroupBox.TabStop = false;
            // 
            // SaveFileButton
            // 
            resources.ApplyResources(this.SaveFileButton, "SaveFileButton");
            this.SaveFileButton.Name = "SaveFileButton";
            this.SaveFileButton.UseVisualStyleBackColor = true;
            this.SaveFileButton.Click += new System.EventHandler(this.SaveFileButton_Click);
            // 
            // ClusterButton
            // 
            resources.ApplyResources(this.ClusterButton, "ClusterButton");
            this.ClusterButton.Name = "ClusterButton";
            this.ClusterButton.UseVisualStyleBackColor = true;
            this.ClusterButton.Click += new System.EventHandler(this.ClusterButton_Click);
            // 
            // InputKLabel
            // 
            resources.ApplyResources(this.InputKLabel, "InputKLabel");
            this.InputKLabel.Name = "InputKLabel";
            // 
            // KTextBox
            // 
            resources.ApplyResources(this.KTextBox, "KTextBox");
            this.KTextBox.Name = "KTextBox";
            // 
            // ClearButton
            // 
            resources.ApplyResources(this.ClearButton, "ClearButton");
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // ImportButton
            // 
            resources.ApplyResources(this.ImportButton, "ImportButton");
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.UseVisualStyleBackColor = true;
            this.ImportButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // PicBox
            // 
            resources.ApplyResources(this.PicBox, "PicBox");
            this.PicBox.Name = "PicBox";
            this.PicBox.TabStop = false;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SettingsGroupBox);
            this.Controls.Add(this.PicBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.SettingsGroupBox.ResumeLayout(false);
            this.SettingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox SettingsGroupBox;
        private System.Windows.Forms.Button ClusterButton;
        private System.Windows.Forms.Label InputKLabel;
        private System.Windows.Forms.TextBox KTextBox;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button ImportButton;
        private System.Windows.Forms.PictureBox PicBox;
        private System.Windows.Forms.Button SaveFileButton;
    }
}

