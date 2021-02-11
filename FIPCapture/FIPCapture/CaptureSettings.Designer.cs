namespace FIPCapture
{
    partial class CaptureSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CaptureSettings));
            this.fpsUD = new System.Windows.Forms.NumericUpDown();
            this.heightUD = new System.Windows.Forms.NumericUpDown();
            this.widthUD = new System.Windows.Forms.NumericUpDown();
            this.resetBTN = new System.Windows.Forms.Button();
            this.closeBTN = new System.Windows.Forms.Button();
            this.saveBTN = new System.Windows.Forms.Button();
            this.fpsRecommendLBL = new System.Windows.Forms.Label();
            this.fpsLBL = new System.Windows.Forms.Label();
            this.heightLBL = new System.Windows.Forms.Label();
            this.widthLBL = new System.Windows.Forms.Label();
            this.ratioCB = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.fpsUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthUD)).BeginInit();
            this.SuspendLayout();
            // 
            // fpsUD
            // 
            this.fpsUD.Location = new System.Drawing.Point(76, 115);
            this.fpsUD.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.fpsUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.fpsUD.Name = "fpsUD";
            this.fpsUD.Size = new System.Drawing.Size(58, 20);
            this.fpsUD.TabIndex = 28;
            this.fpsUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // heightUD
            // 
            this.heightUD.Location = new System.Drawing.Point(76, 77);
            this.heightUD.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.heightUD.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.heightUD.Name = "heightUD";
            this.heightUD.Size = new System.Drawing.Size(58, 20);
            this.heightUD.TabIndex = 27;
            this.heightUD.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.heightUD.ValueChanged += new System.EventHandler(this.heightUD_ValueChanged);
            // 
            // widthUD
            // 
            this.widthUD.Location = new System.Drawing.Point(76, 46);
            this.widthUD.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.widthUD.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.widthUD.Name = "widthUD";
            this.widthUD.Size = new System.Drawing.Size(58, 20);
            this.widthUD.TabIndex = 26;
            this.widthUD.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.widthUD.ValueChanged += new System.EventHandler(this.widthUD_ValueChanged);
            // 
            // resetBTN
            // 
            this.resetBTN.Location = new System.Drawing.Point(88, 189);
            this.resetBTN.Name = "resetBTN";
            this.resetBTN.Size = new System.Drawing.Size(75, 39);
            this.resetBTN.TabIndex = 25;
            this.resetBTN.Text = "Reset to defaults";
            this.resetBTN.UseVisualStyleBackColor = true;
            this.resetBTN.Click += new System.EventHandler(this.resetBTN_Click);
            // 
            // closeBTN
            // 
            this.closeBTN.Location = new System.Drawing.Point(129, 160);
            this.closeBTN.Name = "closeBTN";
            this.closeBTN.Size = new System.Drawing.Size(75, 23);
            this.closeBTN.TabIndex = 24;
            this.closeBTN.Text = "Close";
            this.closeBTN.UseVisualStyleBackColor = true;
            this.closeBTN.Click += new System.EventHandler(this.closeBTN_Click);
            // 
            // saveBTN
            // 
            this.saveBTN.Location = new System.Drawing.Point(48, 160);
            this.saveBTN.Name = "saveBTN";
            this.saveBTN.Size = new System.Drawing.Size(75, 23);
            this.saveBTN.TabIndex = 23;
            this.saveBTN.Text = "Save";
            this.saveBTN.UseVisualStyleBackColor = true;
            this.saveBTN.Click += new System.EventHandler(this.saveBTN_Click);
            // 
            // fpsRecommendLBL
            // 
            this.fpsRecommendLBL.AutoSize = true;
            this.fpsRecommendLBL.Location = new System.Drawing.Point(140, 117);
            this.fpsRecommendLBL.Name = "fpsRecommendLBL";
            this.fpsRecommendLBL.Size = new System.Drawing.Size(100, 13);
            this.fpsRecommendLBL.TabIndex = 22;
            this.fpsRecommendLBL.Text = "(33 Recommended)";
            // 
            // fpsLBL
            // 
            this.fpsLBL.AutoSize = true;
            this.fpsLBL.Location = new System.Drawing.Point(12, 117);
            this.fpsLBL.Name = "fpsLBL";
            this.fpsLBL.Size = new System.Drawing.Size(27, 13);
            this.fpsLBL.TabIndex = 21;
            this.fpsLBL.Text = "FPS";
            // 
            // heightLBL
            // 
            this.heightLBL.AutoSize = true;
            this.heightLBL.Location = new System.Drawing.Point(10, 79);
            this.heightLBL.Name = "heightLBL";
            this.heightLBL.Size = new System.Drawing.Size(48, 13);
            this.heightLBL.TabIndex = 20;
            this.heightLBL.Text = "Height Y";
            // 
            // widthLBL
            // 
            this.widthLBL.AutoSize = true;
            this.widthLBL.Location = new System.Drawing.Point(12, 48);
            this.widthLBL.Name = "widthLBL";
            this.widthLBL.Size = new System.Drawing.Size(45, 13);
            this.widthLBL.TabIndex = 19;
            this.widthLBL.Text = "Width X";
            // 
            // ratioCB
            // 
            this.ratioCB.AutoSize = true;
            this.ratioCB.Location = new System.Drawing.Point(12, 12);
            this.ratioCB.Name = "ratioCB";
            this.ratioCB.Size = new System.Drawing.Size(211, 17);
            this.ratioCB.TabIndex = 18;
            this.ratioCB.Text = "Maintain Aspect Ratio (Recommended)";
            this.ratioCB.UseVisualStyleBackColor = true;
            // 
            // CaptureSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 269);
            this.Controls.Add(this.fpsUD);
            this.Controls.Add(this.heightUD);
            this.Controls.Add(this.widthUD);
            this.Controls.Add(this.resetBTN);
            this.Controls.Add(this.closeBTN);
            this.Controls.Add(this.saveBTN);
            this.Controls.Add(this.fpsRecommendLBL);
            this.Controls.Add(this.fpsLBL);
            this.Controls.Add(this.heightLBL);
            this.Controls.Add(this.widthLBL);
            this.Controls.Add(this.ratioCB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CaptureSettings";
            this.Text = "CaptureSettings";
            ((System.ComponentModel.ISupportInitialize)(this.fpsUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown fpsUD;
        private System.Windows.Forms.NumericUpDown heightUD;
        private System.Windows.Forms.NumericUpDown widthUD;
        private System.Windows.Forms.Button resetBTN;
        private System.Windows.Forms.Button closeBTN;
        private System.Windows.Forms.Button saveBTN;
        private System.Windows.Forms.Label fpsRecommendLBL;
        private System.Windows.Forms.Label fpsLBL;
        private System.Windows.Forms.Label heightLBL;
        private System.Windows.Forms.Label widthLBL;
        private System.Windows.Forms.CheckBox ratioCB;
    }
}