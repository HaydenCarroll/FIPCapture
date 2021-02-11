using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIPCapture
{
    public partial class CapturePreviewBox : Form
    {
        #region Form Dragging API Support
        //The SendMessage function sends a message to a window or windows.

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]

        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        //ReleaseCapture releases a mouse capture

        [DllImportAttribute("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]

        public static extern bool ReleaseCapture();

        #endregion
        mainForm parentForm;
        Rectangle captureRectangle;
        List<Form> screenForms = new List<Form>();
        public CapturePreviewBox(mainForm parent)
        {
            parentForm = parent;
            InitializeComponent();
            this.ControlBox = false;
            this.Text = String.Empty;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.Fuchsia;
            this.TransparencyKey = (BackColor);
            // Ensure display shows on screen that capture is saved to and fits within bounds
            initDisplayLocationAndSize();


            foreach (Screen screen in Screen.AllScreens)
            {
                Form form = new Form();
                form.FormBorderStyle = FormBorderStyle.None;
                form.BackColor = Color.Red;
                form.TransparencyKey = form.BackColor;
                form.StartPosition = FormStartPosition.Manual;
                Rectangle bounds = screen.Bounds;
                form.SetBounds(bounds.X, bounds.Y, bounds.Width, bounds.Height);
                form.Show();
                form.BringToFront();
                form.MouseClick += (s, e) =>
                {
                    this.BringToFront();
                    SystemSounds.Hand.Play();
                };
                form.MouseDown += (s, e) =>
                {
                    if (e.Button == MouseButtons.Left)

                    {

                        ReleaseCapture();

                        SendMessage(this.Handle, 0xa1, 0x2, 0);

                    }
                };
                screenForms.Add(form);
            }


            this.Padding = new Padding(0);
            this.Paint += (o, e) =>
            {
                Graphics graphics = e.Graphics;
                Pen pen = new Pen(Color.Red, 5);
                //Rectangle rectangle = new Rectangle(2, 2, 325, 245);
                //Rectangle rectangle = new Rectangle(2, 2, Properties.Settings.Default.CaptureWidth + 5, Properties.Settings.Default.CaptureHeight + 5);
                captureRectangle = new Rectangle(2, 2, this.Width - 7, this.Height - 7 - this.setBTN.Height);
                graphics.DrawRectangle(pen, captureRectangle);
                this.setBTN.Location = new Point((this.Width / 3) - (setBTN.Width / 2), this.Height - setBTN.Height - 2);
                this.closeBTN.Location = new Point((this.Width / 3) + (closeBTN.Width / 2), this.Height - closeBTN.Height - 2);
            };
            this.setBTN.BringToFront();
            this.BringToFront();
        }

        // Used to make sure form displays on a valid screen and within screen bounds
        private void initDisplayLocationAndSize()
        {
            this.StartPosition = FormStartPosition.Manual;
            // Verify starting screen exists, set to primary by default
            bool startingScreenExists = Screen.AllScreens.Length > Properties.Settings.Default.CaptureScreenIndex ? true : false;
            Screen startingScreen = Screen.PrimaryScreen;
            if (startingScreenExists)
            {
                startingScreen = Screen.AllScreens[Properties.Settings.Default.CaptureScreenIndex];
            }
            Rectangle startingScreenBounds = startingScreen.Bounds;
            this.SetBounds(startingScreenBounds.X, startingScreenBounds.Y, startingScreenBounds.Width, startingScreenBounds.Height);
            this.Location = new Point(Properties.Settings.Default.CapturePoint.X - 5, Properties.Settings.Default.CapturePoint.Y - 5);
            this.Size = new Size(Properties.Settings.Default.CaptureWidth + 7, Properties.Settings.Default.CaptureHeight + 12 + (this.setBTN.Height));
            // Verify form fits to screen
            if (Bounds.Width < Location.X + Size.Width || Bounds.Height < Location.Y + Size.Height)
            {
                // If not then restore Default location and size
                this.Location = new Point(10, 10);
                this.Size = new Size(327, 252 + this.setBTN.Height);
            }
        }
        protected override void WndProc(ref Message m)
        {
            const int wmNcHitTest = 0x84;
            const int htBottomLeft = 16;
            const int htBottomRight = 17;
            if (m.Msg == wmNcHitTest)
            {
                int x = (int)(m.LParam.ToInt64() & 0xFFFF);
                int y = (int)((m.LParam.ToInt64() & 0xFFFF0000) >> 16);
                Point pt = PointToClient(new Point(x, y));
                Size clientSize = ClientSize;
                if (pt.X >= clientSize.Width - 16 && pt.Y >= clientSize.Height - 16 && clientSize.Height >= 16)
                {
                    m.Result = (IntPtr)(IsMirrored ? htBottomLeft : htBottomRight);
                    return;
                }
            }
            base.WndProc(ref m);
        }

        private void setBTN_Click(object sender, EventArgs e)
        {
            Point desktopLocation = this.DesktopLocation;
            Rectangle screenRectangle = this.RectangleToScreen(this.ClientRectangle);
            int titleHeight = screenRectangle.Top - this.Top;
            Point capturePoint = new Point(desktopLocation.X + 5, desktopLocation.Y + 5);
            Console.WriteLine(capturePoint);
            parentForm.setCapturePoint(capturePoint);
            Screen captureScreen = Screen.FromControl(this);
            parentForm.setCaptureScreen(captureScreen);
            int screenIndex = 0;
            // Determine screen index
            for (int i = 0; i < Screen.AllScreens.Length; i++)
            {
                if (Screen.ReferenceEquals(Screen.AllScreens[i], captureScreen))
                {
                    screenIndex = i;
                }
            }
            // Save settings
            Properties.Settings.Default.CaptureScreenIndex = screenIndex;
            Properties.Settings.Default.CapturePoint = capturePoint;
            Properties.Settings.Default.CaptureHeight = captureRectangle.Height - 5;
            Properties.Settings.Default.CaptureWidth = captureRectangle.Width;
            parentForm.Show();
            foreach (Form form in screenForms)
            {
                form.Close();
            }
            this.Close();

        }

        private void CapturePreviewBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentForm.Show();
            foreach (Form form in screenForms)
            {
                form.Close();
            }
        }

        private void CapturePreviewBox_MouseDown(object sender, MouseEventArgs e)
        {
            // drag the form without the caption bar

            // present on left mouse button

            if (e.Button == MouseButtons.Left)

            {

                ReleaseCapture();

                SendMessage(this.Handle, 0xa1, 0x2, 0);

            }
        }

        private void closeBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CapturePreviewBox_Resize(object sender, EventArgs e)
        {
            this.setBTN.Invalidate();
            this.closeBTN.Invalidate();
            Invalidate();
        }
    }
}
