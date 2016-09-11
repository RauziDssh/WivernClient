namespace WivernClient
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_room = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_roomInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_detected = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_info = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_room,
            this.toolStripMenuItem_roomInfo,
            this.toolStripSeparator2,
            this.toolStripMenuItem_detected,
            this.toolStripSeparator1,
            this.toolStripMenuItem_info,
            this.toolStripMenuItem_Exit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(216, 166);
            // 
            // toolStripMenuItem_room
            // 
            this.toolStripMenuItem_room.Name = "toolStripMenuItem_room";
            this.toolStripMenuItem_room.Size = new System.Drawing.Size(215, 30);
            this.toolStripMenuItem_room.Text = "部屋：N/A";
            // 
            // toolStripMenuItem_roomInfo
            // 
            this.toolStripMenuItem_roomInfo.Name = "toolStripMenuItem_roomInfo";
            this.toolStripMenuItem_roomInfo.Size = new System.Drawing.Size(215, 30);
            this.toolStripMenuItem_roomInfo.Text = "部屋の確認";
            this.toolStripMenuItem_roomInfo.Click += new System.EventHandler(this.toolStripMenuItem_roomInfo_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(212, 6);
            // 
            // toolStripMenuItem_detected
            // 
            this.toolStripMenuItem_detected.Name = "toolStripMenuItem_detected";
            this.toolStripMenuItem_detected.Size = new System.Drawing.Size(215, 30);
            this.toolStripMenuItem_detected.Text = "検出したデバイス";
            this.toolStripMenuItem_detected.Click += new System.EventHandler(this.toolStripMenuItem_detected_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(212, 6);
            // 
            // toolStripMenuItem_info
            // 
            this.toolStripMenuItem_info.Name = "toolStripMenuItem_info";
            this.toolStripMenuItem_info.Size = new System.Drawing.Size(215, 30);
            this.toolStripMenuItem_info.Text = "Info";
            this.toolStripMenuItem_info.Click += new System.EventHandler(this.toolStripMenuItem_info_Click);
            // 
            // toolStripMenuItem_Exit
            // 
            this.toolStripMenuItem_Exit.Name = "toolStripMenuItem_Exit";
            this.toolStripMenuItem_Exit.Size = new System.Drawing.Size(215, 30);
            this.toolStripMenuItem_Exit.Text = "Exit";
            this.toolStripMenuItem_Exit.Click += new System.EventHandler(this.toolStripMenuItem_Exit_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 476);
            this.Name = "Form1";
            this.Text = "Form1";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_info;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Exit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_detected;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_room;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_roomInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

