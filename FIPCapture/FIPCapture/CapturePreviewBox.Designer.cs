namespace FIPCapture
{
    partial class CapturePreviewBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CapturePreviewBox));
            this.closeBTN = new System.Windows.Forms.Button();
            this.setBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // closeBTN
            // 
            this.closeBTN.Location = new System.Drawing.Point(146, 9);
            this.closeBTN.Name = "closeBTN";
            this.closeBTN.Size = new System.Drawing.Size(134, 30);
            this.closeBTN.TabIndex = 3;
            this.closeBTN.Text = "Close";
            this.closeBTN.UseVisualStyleBackColor = true;
            this.closeBTN.Click += new System.EventHandler(this.closeBTN_Click);
            // 
            // setBTN
            // 
            this.setBTN.Location = new System.Drawing.Point(9, 9);
            this.setBTN.Margin = new System.Windows.Forms.Padding(0);
            this.setBTN.Name = "setBTN";
            this.setBTN.Padding = new System.Windows.Forms.Padding(3);
            this.setBTN.Size = new System.Drawing.Size(134, 30);
            this.setBTN.TabIndex = 2;
            this.setBTN.Text = "Confirm";
            this.setBTN.UseVisualStyleBackColor = true;
            this.setBTN.Click += new System.EventHandler(this.setBTN_Click);
            // 
            // CapturePreviewBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.closeBTN);
            this.Controls.Add(this.setBTN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CapturePreviewBox";
            this.Text = "CapturePreviewBox";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CapturePreviewBox_FormClosing);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CapturePreviewBox_MouseDown);
            this.Resize += new System.EventHandler(this.CapturePreviewBox_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button closeBTN;
        private System.Windows.Forms.Button setBTN;
    }
}