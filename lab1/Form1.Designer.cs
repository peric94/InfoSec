namespace lab1
{
    partial class Form1
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
            this.textBoxSource = new System.Windows.Forms.TextBox();
            this.textBoxDestination = new System.Windows.Forms.TextBox();
            this.buttonSource = new System.Windows.Forms.Button();
            this.buttonDestination = new System.Windows.Forms.Button();
            this.labelEncryption = new System.Windows.Forms.Label();
            this.labelDecryption = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.fileSystemWatcher = new System.IO.FileSystemWatcher();
            this.buttonMonitorStart = new System.Windows.Forms.Button();
            this.buttonMonitorStop = new System.Windows.Forms.Button();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.labelKey = new System.Windows.Forms.Label();
            this.buttonSelectKey = new System.Windows.Forms.Button();
            this.textBoxAKey = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxSource
            // 
            this.textBoxSource.Location = new System.Drawing.Point(9, 95);
            this.textBoxSource.Name = "textBoxSource";
            this.textBoxSource.Size = new System.Drawing.Size(217, 20);
            this.textBoxSource.TabIndex = 0;
            // 
            // textBoxDestination
            // 
            this.textBoxDestination.Location = new System.Drawing.Point(289, 95);
            this.textBoxDestination.Name = "textBoxDestination";
            this.textBoxDestination.Size = new System.Drawing.Size(217, 20);
            this.textBoxDestination.TabIndex = 1;
            // 
            // buttonSource
            // 
            this.buttonSource.Location = new System.Drawing.Point(9, 121);
            this.buttonSource.Name = "buttonSource";
            this.buttonSource.Size = new System.Drawing.Size(93, 23);
            this.buttonSource.TabIndex = 2;
            this.buttonSource.Text = "Source path";
            this.buttonSource.UseVisualStyleBackColor = true;
            this.buttonSource.Click += new System.EventHandler(this.buttonSource_Click);
            // 
            // buttonDestination
            // 
            this.buttonDestination.Location = new System.Drawing.Point(289, 121);
            this.buttonDestination.Name = "buttonDestination";
            this.buttonDestination.Size = new System.Drawing.Size(93, 23);
            this.buttonDestination.TabIndex = 3;
            this.buttonDestination.Text = "Destination path";
            this.buttonDestination.UseVisualStyleBackColor = true;
            this.buttonDestination.Click += new System.EventHandler(this.buttonDestination_Click);
            // 
            // labelEncryption
            // 
            this.labelEncryption.AutoSize = true;
            this.labelEncryption.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelEncryption.Location = new System.Drawing.Point(5, 58);
            this.labelEncryption.Name = "labelEncryption";
            this.labelEncryption.Size = new System.Drawing.Size(100, 24);
            this.labelEncryption.TabIndex = 8;
            this.labelEncryption.Text = "Encryption";
            // 
            // labelDecryption
            // 
            this.labelDecryption.AutoSize = true;
            this.labelDecryption.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelDecryption.Location = new System.Drawing.Point(5, 58);
            this.labelDecryption.Name = "labelDecryption";
            this.labelDecryption.Size = new System.Drawing.Size(100, 24);
            this.labelDecryption.TabIndex = 9;
            this.labelDecryption.Text = "Decryption";
            this.labelDecryption.Visible = false;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(320, 61);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(90, 23);
            this.buttonStart.TabIndex = 10;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(416, 61);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(90, 23);
            this.buttonStop.TabIndex = 11;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // comboBox
            // 
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Items.AddRange(new object[] {
            "Double transposition",
            "A5/1"});
            this.comboBox.Location = new System.Drawing.Point(385, 18);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(121, 21);
            this.comboBox.TabIndex = 13;
            this.comboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Location = new System.Drawing.Point(9, 22);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(225, 17);
            this.checkBox.TabIndex = 14;
            this.checkBox.Text = "Check/uncheck for decryption/encryption";
            this.checkBox.UseVisualStyleBackColor = true;
            this.checkBox.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // fileSystemWatcher
            // 
            this.fileSystemWatcher.EnableRaisingEvents = true;
            this.fileSystemWatcher.SynchronizingObject = this;
            // 
            // buttonMonitorStart
            // 
            this.buttonMonitorStart.Location = new System.Drawing.Point(9, 166);
            this.buttonMonitorStart.Name = "buttonMonitorStart";
            this.buttonMonitorStart.Size = new System.Drawing.Size(92, 23);
            this.buttonMonitorStart.TabIndex = 15;
            this.buttonMonitorStart.Text = "Start monitoring";
            this.buttonMonitorStart.UseVisualStyleBackColor = true;
            this.buttonMonitorStart.Click += new System.EventHandler(this.buttonMonitorStart_Click);
            // 
            // buttonMonitorStop
            // 
            this.buttonMonitorStop.Location = new System.Drawing.Point(9, 195);
            this.buttonMonitorStop.Name = "buttonMonitorStop";
            this.buttonMonitorStop.Size = new System.Drawing.Size(92, 23);
            this.buttonMonitorStop.TabIndex = 16;
            this.buttonMonitorStop.Text = "Stop monitoring";
            this.buttonMonitorStop.UseVisualStyleBackColor = true;
            this.buttonMonitorStop.Click += new System.EventHandler(this.buttonMonitorStop_Click);
            // 
            // textBoxKey
            // 
            this.textBoxKey.Location = new System.Drawing.Point(289, 166);
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.Size = new System.Drawing.Size(217, 20);
            this.textBoxKey.TabIndex = 17;
            this.textBoxKey.Visible = false;
            // 
            // labelKey
            // 
            this.labelKey.AutoSize = true;
            this.labelKey.Location = new System.Drawing.Point(255, 169);
            this.labelKey.Name = "labelKey";
            this.labelKey.Size = new System.Drawing.Size(28, 13);
            this.labelKey.TabIndex = 19;
            this.labelKey.Text = "Key:";
            this.labelKey.Visible = false;
            // 
            // buttonSelectKey
            // 
            this.buttonSelectKey.Location = new System.Drawing.Point(289, 195);
            this.buttonSelectKey.Name = "buttonSelectKey";
            this.buttonSelectKey.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectKey.TabIndex = 20;
            this.buttonSelectKey.Text = "Select key";
            this.buttonSelectKey.UseVisualStyleBackColor = true;
            this.buttonSelectKey.Visible = false;
            this.buttonSelectKey.Click += new System.EventHandler(this.buttonSelectKey_Click);
            // 
            // textBoxAKey
            // 
            this.textBoxAKey.Location = new System.Drawing.Point(289, 166);
            this.textBoxAKey.Name = "textBoxAKey";
            this.textBoxAKey.Size = new System.Drawing.Size(100, 20);
            this.textBoxAKey.TabIndex = 21;
            this.textBoxAKey.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 238);
            this.Controls.Add(this.textBoxAKey);
            this.Controls.Add(this.buttonSelectKey);
            this.Controls.Add(this.labelKey);
            this.Controls.Add(this.textBoxKey);
            this.Controls.Add(this.buttonMonitorStop);
            this.Controls.Add(this.buttonMonitorStart);
            this.Controls.Add(this.checkBox);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.labelDecryption);
            this.Controls.Add(this.labelEncryption);
            this.Controls.Add(this.buttonDestination);
            this.Controls.Add(this.buttonSource);
            this.Controls.Add(this.textBoxDestination);
            this.Controls.Add(this.textBoxSource);
            this.Name = "Form1";
            this.Text = "C1ph3r";
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSource;
        private System.Windows.Forms.TextBox textBoxDestination;
        private System.Windows.Forms.Button buttonSource;
        private System.Windows.Forms.Button buttonDestination;
        private System.Windows.Forms.Label labelEncryption;
        private System.Windows.Forms.Label labelDecryption;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.IO.FileSystemWatcher fileSystemWatcher;
        private System.Windows.Forms.Button buttonMonitorStop;
        private System.Windows.Forms.Button buttonMonitorStart;
        private System.Windows.Forms.Label labelKey;
        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.Button buttonSelectKey;
        private System.Windows.Forms.TextBox textBoxAKey;
    }
}

