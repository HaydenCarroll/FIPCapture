using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIPCapture
{
    public partial class CaptureSettings : Form
    {
        private mainForm parentForm;
        private const int DEFAULTX = 320;
        private const int DEFAULTY = 240;
        private const bool DEFAULTASPECT = true;
        private const int DEFAULTFPS = 33;
        public CaptureSettings(mainForm parentForm)
        {
            this.parentForm = parentForm;
            InitializeComponent();
            ratioCB.Checked = Properties.Settings.Default.MaintainRatio;
            // Remove ud event handlers to set inital values
            widthUD.ValueChanged -= new EventHandler(widthUD_ValueChanged);
            heightUD.ValueChanged -= new EventHandler(heightUD_ValueChanged);
            widthUD.Value = Properties.Settings.Default.CaptureWidth;
            heightUD.Value = Properties.Settings.Default.CaptureHeight;
            // add back the handlers
            widthUD.ValueChanged += new EventHandler(widthUD_ValueChanged);
            heightUD.ValueChanged += new EventHandler(heightUD_ValueChanged);
            fpsUD.Value = Properties.Settings.Default.FPS;

            // set maximum height and width based on largest screen
            int maxHeight = 0;
            int maxWidth = 0;
            foreach (Screen s in Screen.AllScreens)
            {
                if (s.Bounds.Height > maxHeight)
                {
                    maxHeight = s.Bounds.Height;
                }
                if (s.Bounds.Width > maxWidth)
                {
                    maxWidth = s.Bounds.Width;
                }
            }
            widthUD.Maximum = maxWidth;
            heightUD.Maximum = maxHeight;
        }

        private void saveBTN_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.MaintainRatio = ratioCB.Checked;
            Properties.Settings.Default.CaptureWidth = (int)widthUD.Value;
            Properties.Settings.Default.CaptureHeight = (int)heightUD.Value;
            Properties.Settings.Default.FPS = (int)fpsUD.Value;
            parentForm.updateTimerTick((int)fpsUD.Value);
            this.Close();
        }

        private void resetBTN_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Reset values to defaults?", "Reset Defaults", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                ratioCB.Checked = DEFAULTASPECT;
                widthUD.Value = DEFAULTX;
                heightUD.Value = DEFAULTY;
                fpsUD.Value = DEFAULTFPS;
            }
        }

        private void closeBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void widthUD_ValueChanged(object sender, EventArgs e)
        {
            // If aspect is locked then change height to match ratio
            if (ratioCB.Checked)
            {
                double yRatio = (double)DEFAULTY / (double)DEFAULTX;
                int newHeight = (int)Math.Round((double)widthUD.Value * yRatio);
                // remove the value changed event to avoid infinite loop
                heightUD.ValueChanged -= new EventHandler(heightUD_ValueChanged);
                heightUD.Value = newHeight;
                // add the handler back
                heightUD.ValueChanged += new EventHandler(heightUD_ValueChanged);

            }
        }

        private void heightUD_ValueChanged(object sender, EventArgs e)
        {
            // If aspect is locked then change width to match ratio
            if (ratioCB.Checked)
            {
                double xRatio = (double)DEFAULTX / (double)DEFAULTY;
                int newWidth = (int)Math.Round((double)heightUD.Value * xRatio);
                // remove the value changed event to avoid infinite loop
                widthUD.ValueChanged -= new EventHandler(widthUD_ValueChanged);
                widthUD.Value = newWidth;
                // add the handler back
                widthUD.ValueChanged += new EventHandler(widthUD_ValueChanged);
            }
        }
    }
}
