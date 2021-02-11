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
    public partial class mainForm : Form
    {
        private Point capturePoint;
        private Screen captureScreen;
        private FipHandler fipHandler;
        public mainForm()
        {
            capturePoint = Properties.Settings.Default.CapturePoint;
            captureScreen = Screen.AllScreens[Properties.Settings.Default.CaptureScreenIndex];
            InitializeComponent();
            int fpms = (int)(((double)1 / (double)Properties.Settings.Default.FPS) * 1000);
            this.screenshotTimer.Interval = fpms;
            fipHandler = new FipHandler();
            fipHandler.Initialize();
            panelCountLBL.Text = "Panel Count: " + fipHandler.numPanels;
            if (!fipHandler.InitOk || fipHandler.numPanels == 0)
            {
                if (fipHandler.numPanels == 0)
                {
                    MessageBox.Show("No FIP's found.", "Error", MessageBoxButtons.OK);
                }

                disableControls(this);
            }


        }

        private void disableControls(Control c)
        {
            foreach (Control subC in c.Controls)
            {
                disableControls(subC);
            }
            c.Enabled = false;
        }
        public void updateTimerTick(int fps)
        {

            int fpms = (int)(((double)1 / (double)Properties.Settings.Default.FPS) * 1000);
            bool timerWasRunning = screenshotTimer.Enabled;
            if (timerWasRunning)
            {
                screenshotTimer.Stop();
            }

            this.screenshotTimer.Interval = fpms;
            if (timerWasRunning)
            {
                screenshotTimer.Start();
            }

        }
        public void setCaptureScreen(Screen captureScreen)
        {
            this.captureScreen = captureScreen;
        }
        public Screen getCaptureScreen()
        {
            return this.captureScreen;
        }
        public void setCapturePoint(Point capturePoint)
        {
            this.capturePoint = capturePoint;
        }
        public Point getCapturePoint()
        {
            return this.capturePoint;
        }

        private void setCaptureBTN_Click(object sender, EventArgs e)
        {
            CapturePreviewBox capturePreviewBox = new CapturePreviewBox(this);
            capturePreviewBox.Show();
            this.Hide();
        }

        private void captureStartBTN_Click(object sender, EventArgs e)
        {
            this.screenshotTimer.Start();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void captureStopBTN_Click(object sender, EventArgs e)
        {
            this.screenshotTimer.Stop();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void captureSettingsBTN_Click(object sender, EventArgs e)
        {
            CaptureSettings captureSettings = new CaptureSettings(this);
            captureSettings.Show();
        }

        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.screenshotTimer.Stop();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            fipHandler.Close();
            Properties.Settings.Default.Save();
        }

        private void screenshotTimer_Tick(object sender, EventArgs e)
        {
            fipHandler.displayScreenshotOnDevice(capturePoint, captureScreen);
        }
    }
}
