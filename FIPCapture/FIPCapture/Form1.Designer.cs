namespace FIPCapture
{
    partial class mainForm
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
            this.setCaptureBTN = new System.Windows.Forms.Button();
            this.captureStartBTN = new System.Windows.Forms.Button();
            this.captureStopBTN = new System.Windows.Forms.Button();
            this.captureSettingsBTN = new System.Windows.Forms.Button();
            this.panelCountLBL = new System.Windows.Forms.Label();
            this.screenshotTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // setCaptureBTN
            // 
            this.setCaptureBTN.Location = new System.Drawing.Point(90, 30);
            this.setCaptureBTN.Name = "setCaptureBTN";
            this.setCaptureBTN.Size = new System.Drawing.Size(114, 49);
            this.setCaptureBTN.TabIndex = 0;
            this.setCaptureBTN.Text = "Select Frame";
            this.setCaptureBTN.UseVisualStyleBackColor = true;
            this.setCaptureBTN.Click += new System.EventHandler(this.setCaptureBTN_Click);
            // 
            // captureStartBTN
            // 
            this.captureStartBTN.Location = new System.Drawing.Point(90, 85);
            this.captureStartBTN.Name = "captureStartBTN";
            this.captureStartBTN.Size = new System.Drawing.Size(114, 49);
            this.captureStartBTN.TabIndex = 1;
            this.captureStartBTN.Text = "Start Capture";
            this.captureStartBTN.UseVisualStyleBackColor = true;
            this.captureStartBTN.Click += new System.EventHandler(this.captureStartBTN_Click);
            // 
            // captureStopBTN
            // 
            this.captureStopBTN.Location = new System.Drawing.Point(90, 140);
            this.captureStopBTN.Name = "captureStopBTN";
            this.captureStopBTN.Size = new System.Drawing.Size(114, 48);
            this.captureStopBTN.TabIndex = 2;
            this.captureStopBTN.Text = "Stop Capture";
            this.captureStopBTN.UseVisualStyleBackColor = true;
            this.captureStopBTN.Click += new System.EventHandler(this.captureStopBTN_Click);
            // 
            // captureSettingsBTN
            // 
            this.captureSettingsBTN.Location = new System.Drawing.Point(90, 194);
            this.captureSettingsBTN.Name = "captureSettingsBTN";
            this.captureSettingsBTN.Size = new System.Drawing.Size(114, 48);
            this.captureSettingsBTN.TabIndex = 3;
            this.captureSettingsBTN.Text = "Capture Settings";
            this.captureSettingsBTN.UseVisualStyleBackColor = true;
            this.captureSettingsBTN.Click += new System.EventHandler(this.captureSettingsBTN_Click);
            // 
            // panelCountLBL
            // 
            this.panelCountLBL.AutoSize = true;
            this.panelCountLBL.Location = new System.Drawing.Point(720, 428);
            this.panelCountLBL.Name = "panelCountLBL";
            this.panelCountLBL.Size = new System.Drawing.Size(68, 13);
            this.panelCountLBL.TabIndex = 4;
            this.panelCountLBL.Text = "Panel Count:";
            // 
            // screenshotTimer
            // 
            this.screenshotTimer.Interval = 33;
            this.screenshotTimer.Tick += new System.EventHandler(this.screenshotTimer_Tick);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelCountLBL);
            this.Controls.Add(this.captureSettingsBTN);
            this.Controls.Add(this.captureStopBTN);
            this.Controls.Add(this.captureStartBTN);
            this.Controls.Add(this.setCaptureBTN);
            this.Name = "mainForm";
            this.Text = "Capture Panel";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button setCaptureBTN;
        private System.Windows.Forms.Button captureStartBTN;
        private System.Windows.Forms.Button captureStopBTN;
        private System.Windows.Forms.Button captureSettingsBTN;
        private System.Windows.Forms.Label panelCountLBL;
        private System.Windows.Forms.Timer screenshotTimer;
    }
}

