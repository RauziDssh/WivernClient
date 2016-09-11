namespace WivernClient
{
    partial class IPListForm
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.findMakerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(823, 741);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // SubmitButton
            // 
            this.SubmitButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.SubmitButton.Location = new System.Drawing.Point(823, 0);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Padding = new System.Windows.Forms.Padding(3);
            this.SubmitButton.Size = new System.Drawing.Size(210, 76);
            this.SubmitButton.TabIndex = 1;
            this.SubmitButton.Text = "このデバイスを登録";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // findMakerButton
            // 
            this.findMakerButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.findMakerButton.Location = new System.Drawing.Point(823, 76);
            this.findMakerButton.Name = "findMakerButton";
            this.findMakerButton.Padding = new System.Windows.Forms.Padding(3);
            this.findMakerButton.Size = new System.Drawing.Size(210, 80);
            this.findMakerButton.TabIndex = 2;
            this.findMakerButton.Text = "製造者名を取得";
            this.findMakerButton.UseVisualStyleBackColor = true;
            this.findMakerButton.Click += new System.EventHandler(this.findMakerButton_Click);
            // 
            // IPListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 741);
            this.Controls.Add(this.findMakerButton);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.listView1);
            this.Name = "IPListForm";
            this.Text = "IPListForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Button findMakerButton;
    }
}