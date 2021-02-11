using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;

namespace FIPCapture
{
    public class FipHandler
    {
        private List<FipPanel> _fipPanels = new List<FipPanel>();
        public int numPanels = 0;
        private DirectOutputClass.DeviceCallback _deviceCallback;
        private DirectOutputClass.EnumerateCallback _enumerateCallback;
        public bool InitOk;

        //private const String DirectOutputKey = "SOFTWARE\\Saitek\\DirectOutput";

        private const string DirectOutputKey = "SOFTWARE\\Logitech\\DirectOutput";


        public bool Initialize()
        {
            InitOk = false;
            try
            {
                _deviceCallback = DeviceCallback;
                _enumerateCallback = EnumerateCallback;

                var key = Registry.LocalMachine.OpenSubKey(DirectOutputKey);

                var value = key?.GetValue("DirectOutput");
                if (value is string)
                {

                    var retVal = DirectOutputClass.Initialize("fiphwinfo");
                    if (retVal != ReturnValues.S_OK)
                    {
                        Console.WriteLine("FIPHandler failed to init DirectOutputClass. " + retVal);
                        return false;
                    }

                    DirectOutputClass.RegisterDeviceCallback(_deviceCallback);

                    retVal = DirectOutputClass.Enumerate(_enumerateCallback);
                    if (retVal != ReturnValues.S_OK)
                    {
                        Console.WriteLine("FIPHandler failed to Enumerate DirectOutputClass. " + retVal);
                        return false;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                return false;
            }
            InitOk = true;
            Console.WriteLine("Number of devices: " + _fipPanels.Count);
            numPanels = _fipPanels.Count;
            return true;
        }

        public void Close()
        {
            try
            {
                foreach (var fipPanel in _fipPanels)
                {
                    fipPanel.Shutdown();
                }
                if (InitOk)
                {
                    //No need to deinit if init never worked. (e.g. missing Saitek Drivers)
                    DirectOutputClass.Deinitialize();
                    InitOk = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        //public void RefreshDevicePages()
        //{
        //    for (var index = 0; index < _fipPanels.Count; index++)
        //    {
        //        var fipPanel = _fipPanels[index];
        //        fipPanel.RefreshDevicePage();
        //    }
        //}

        private bool IsFipDevice(IntPtr device)
        {
            var mGuid = Guid.Empty;

            DirectOutputClass.GetDeviceType(device, ref mGuid);

            return string.Compare(mGuid.ToString(), "3E083CD8-6A37-4A58-80A8-3D6A2C07513E", true, CultureInfo.InvariantCulture) == 0;
        }

        public void displayScreenshotOnDevice(Point capturePoint, Screen captureScreen)
        {
            if (InitOk)
            {
                // 320x240 default logitech/saitek fip resolution

                // resize if size has changed
                if (Properties.Settings.Default.CaptureWidth != 320 || Properties.Settings.Default.CaptureHeight != 240)
                {
                    Bitmap captureBitmap = new Bitmap(Properties.Settings.Default.CaptureWidth, Properties.Settings.Default.CaptureHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                    Rectangle captureRectangle = captureScreen.Bounds;

                    Graphics captureGraphics = Graphics.FromImage(captureBitmap);

                    captureGraphics.CopyFromScreen(capturePoint.X, capturePoint.Y, 0, 0, captureRectangle.Size);
                    Rectangle resizedRect = new Rectangle(0, 0, 320, 240);
                    Bitmap resizedBitmap = new Bitmap(320, 240);

                    resizedBitmap.SetResolution(captureBitmap.HorizontalResolution, captureBitmap.VerticalResolution);
                    resizedBitmap.SetResolution(320, 240);

                    Graphics resizedGraphics = Graphics.FromImage(resizedBitmap);
                    resizedGraphics.CompositingMode = CompositingMode.SourceCopy;
                    resizedGraphics.CompositingQuality = CompositingQuality.HighQuality;
                    resizedGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    resizedGraphics.SmoothingMode = SmoothingMode.HighQuality;
                    resizedGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                    ImageAttributes wrapMode = new ImageAttributes();
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    resizedGraphics.DrawImage(captureBitmap, resizedRect, 0, 0, captureBitmap.Width, captureBitmap.Height, GraphicsUnit.Pixel, wrapMode);
                    captureBitmap.Dispose();
                    captureBitmap = new Bitmap(resizedBitmap);
                    resizedGraphics.Dispose();
                    captureGraphics.Dispose();
                    wrapMode.Dispose();
                    _fipPanels[0].SendImageToFip(0, captureBitmap);
                    resizedBitmap.Dispose();
                    captureBitmap.Dispose();
                }
                else // if default resolution
                {
                    Bitmap captureBitmap = new Bitmap(Properties.Settings.Default.CaptureWidth, Properties.Settings.Default.CaptureHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                    Rectangle captureRectangle = captureScreen.Bounds;

                    Graphics captureGraphics = Graphics.FromImage(captureBitmap);

                    captureGraphics.CopyFromScreen(capturePoint.X, capturePoint.Y, 0, 0, captureRectangle.Size);
                    _fipPanels[0].SendImageToFip(0, captureBitmap);
                    captureGraphics.Dispose();
                    captureBitmap.Dispose();
                }



            }
        }
        // TODO: Implement sending to specific device
        // ALSOTOD: Consider method to display device number
        public void displayScreenshotOnDevice(int device)
        {

        }

        private void EnumerateCallback(IntPtr device, IntPtr context)
        {
            try
            {
                var mGuid = Guid.Empty;

                DirectOutputClass.GetDeviceType(device, ref mGuid);

                Console.WriteLine($"Adding new DirectOutput device {device} of type: {mGuid.ToString()}");

                //Called initially when enumerating FIPs.

                if (!IsFipDevice(device))
                {
                    return;
                }
                var fipPanel = new FipPanel(device);
                _fipPanels.Add(fipPanel);
                fipPanel.Initalize();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void DeviceCallback(IntPtr device, bool added, IntPtr context)
        {
            try
            {
                //Called whenever a DirectOutput device is added or removed from the system.
                Console.WriteLine("DeviceCallback(): 0x" + device.ToString("x") + (added ? " Added" : " Removed"));

                if (!IsFipDevice(device))
                {
                    return;
                }

                if (!added && _fipPanels.Count == 0)
                {
                    return;
                }

                var i = _fipPanels.Count - 1;
                var found = false;
                do
                {
                    if (_fipPanels[i].FipDevicePointer == device)
                    {
                        found = true;
                        var fipPanel = _fipPanels[i];
                        if (!added)
                        {
                            fipPanel.Shutdown();
                            _fipPanels.Remove(fipPanel);
                        }
                    }
                    i--;
                } while (i >= 0);

                if (added && !found)
                {
                    Console.WriteLine("DeviceCallback() Spawning FipPanel. " + device);
                    var fipPanel = new FipPanel(device);
                    _fipPanels.Add(fipPanel);
                    fipPanel.Initalize();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

    }
}
