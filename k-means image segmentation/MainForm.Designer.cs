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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.SettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.ClusterCountLabel = new System.Windows.Forms.Label();
            this.KTextBox = new System.Windows.Forms.TextBox();
            this.SaveFileButton = new System.Windows.Forms.Button();
            this.ClusterButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.ImportButton = new System.Windows.Forms.Button();
            this.PicBox = new System.Windows.Forms.PictureBox();
            this.EditStatusStrip = new System.Windows.Forms.StatusStrip();
            this.ClusteringProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.ClusteringStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.TimerLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.bgw = new System.ComponentModel.BackgroundWorker();
            this.tm = new System.Windows.Forms.Timer(this.components);
            this.SettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox)).BeginInit();
            this.EditStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // SettingsGroupBox
            // 
            this.SettingsGroupBox.Controls.Add(this.ClusterCountLabel);
            this.SettingsGroupBox.Controls.Add(this.KTextBox);
            this.SettingsGroupBox.Controls.Add(this.SaveFileButton);
            this.SettingsGroupBox.Controls.Add(this.ClusterButton);
            this.SettingsGroupBox.Controls.Add(this.ClearButton);
            this.SettingsGroupBox.Controls.Add(this.ImportButton);
            resources.ApplyResources(this.SettingsGroupBox, "SettingsGroupBox");
            this.SettingsGroupBox.Name = "SettingsGroupBox";
            this.SettingsGroupBox.TabStop = false;
            // 
            // ClusterCountLabel
            // 
            resources.ApplyResources(this.ClusterCountLabel, "ClusterCountLabel");
            this.ClusterCountLabel.Name = "ClusterCountLabel";
            // 
            // KTextBox
            // 
            resources.ApplyResources(this.KTextBox, "KTextBox");
            this.KTextBox.Name = "KTextBox";
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
            // EditStatusStrip
            // 
            this.EditStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClusteringProgressBar,
            this.ClusteringStatusLabel,
            this.TimerLabel});
            resources.ApplyResources(this.EditStatusStrip, "EditStatusStrip");
            this.EditStatusStrip.Name = "EditStatusStrip";
            // 
            // ClusteringProgressBar
            // 
            this.ClusteringProgressBar.MarqueeAnimationSpeed = 50;
            this.ClusteringProgressBar.Name = "ClusteringProgressBar";
            resources.ApplyResources(this.ClusteringProgressBar, "ClusteringProgressBar");
            // 
            // ClusteringStatusLabel
            // 
            this.ClusteringStatusLabel.Name = "ClusteringStatusLabel";
            resources.ApplyResources(this.ClusteringStatusLabel, "ClusteringStatusLabel");
            // 
            // TimerLabel
            // 
            this.TimerLabel.Name = "TimerLabel";
            resources.ApplyResources(this.TimerLabel, "TimerLabel");
            this.TimerLabel.Spring = true;
            // 
            // bgw
            // 
            this.bgw.WorkerReportsProgress = true;
            this.bgw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_DoWork);
            this.bgw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_RunWorkerCompleted);
            // 
            // tm
            // 
            this.tm.Interval = 1000;
            this.tm.Tick += new System.EventHandler(this.tm_Tick);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.EditStatusStrip);
            this.Controls.Add(this.SettingsGroupBox);
            this.Controls.Add(this.PicBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.SettingsGroupBox.ResumeLayout(false);
            this.SettingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox)).EndInit();
            this.EditStatusStrip.ResumeLayout(false);
            this.EditStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox SettingsGroupBox;
        private System.Windows.Forms.Button ClusterButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button ImportButton;
        private System.Windows.Forms.PictureBox PicBox;
        private System.Windows.Forms.Button SaveFileButton;
        private System.Windows.Forms.StatusStrip EditStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel ClusteringStatusLabel;
        public System.Windows.Forms.ToolStripProgressBar ClusteringProgressBar;
        public System.ComponentModel.BackgroundWorker bgw;
        private System.Windows.Forms.ToolStripStatusLabel TimerLabel;
        private System.Windows.Forms.Timer tm;
        private System.Windows.Forms.Label ClusterCountLabel;
        private System.Windows.Forms.TextBox KTextBox;
    }
}

