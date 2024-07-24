using System;

namespace WatcherApplication
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
            this.button1 = new System.Windows.Forms.Button();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.fileSystemWatcher2 = new System.IO.FileSystemWatcher();
            this.textBoxLog = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.InputFolderPath = new System.Windows.Forms.TextBox();
            this.Watch = new System.Windows.Forms.Button();
            this.ClearLog = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(31, 76);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 43);
            this.button1.TabIndex = 0;
            this.button1.Text = "Create a sample .json files";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.CreateASampleFiles_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // fileSystemWatcher2
            // 
            this.fileSystemWatcher2.EnableRaisingEvents = true;
            this.fileSystemWatcher2.SynchronizingObject = this;
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(173, 76);
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.Size = new System.Drawing.Size(571, 299);
            this.textBoxLog.TabIndex = 2;
            this.textBoxLog.Text = "";
            this.textBoxLog.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Folder Path";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // InputFolderPath
            // 
            this.InputFolderPath.Location = new System.Drawing.Point(173, 30);
            this.InputFolderPath.Name = "InputFolderPath";
            this.InputFolderPath.Size = new System.Drawing.Size(483, 20);
            this.InputFolderPath.TabIndex = 4;
            this.InputFolderPath.Text = "C:\\TestWatcherApps\\";
            this.InputFolderPath.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Watch
            // 
            this.Watch.Location = new System.Drawing.Point(672, 30);
            this.Watch.Name = "Watch";
            this.Watch.Size = new System.Drawing.Size(72, 22);
            this.Watch.TabIndex = 5;
            this.Watch.Text = "Watch";
            this.Watch.UseVisualStyleBackColor = true;
            this.Watch.Click += new System.EventHandler(this.Watch_Click);
            // 
            // ClearLog
            // 
            this.ClearLog.Location = new System.Drawing.Point(31, 332);
            this.ClearLog.Name = "ClearLog";
            this.ClearLog.Size = new System.Drawing.Size(97, 43);
            this.ClearLog.TabIndex = 6;
            this.ClearLog.Text = "Clear Log";
            this.ClearLog.UseVisualStyleBackColor = true;
            this.ClearLog.Click += new System.EventHandler(this.ClearLog_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ClearLog);
            this.Controls.Add(this.Watch);
            this.Controls.Add(this.InputFolderPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.RichTextBox textBoxLog;
        private System.IO.FileSystemWatcher fileSystemWatcher2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox InputFolderPath;
        private System.Windows.Forms.Button Watch;
        private System.Windows.Forms.Button ClearLog;
    }
}

