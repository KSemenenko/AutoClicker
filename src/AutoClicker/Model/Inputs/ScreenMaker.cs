using AutoClicker.Interface.Inputs;
using System;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace AutoClicker.Model.Inputs
{
    class ScreenMaker : IScreenMaker
    {
        public BitmapSource GetBitmapSourceFromScreen()
        {
            var left = System.Windows.Forms.Screen.AllScreens.Min(screen => screen.Bounds.X);
            var top = System.Windows.Forms.Screen.AllScreens.Min(screen => screen.Bounds.Y);
            var right = System.Windows.Forms.Screen.AllScreens.Max(screen => screen.Bounds.X + screen.Bounds.Width);
            var bottom = System.Windows.Forms.Screen.AllScreens.Max(screen => screen.Bounds.Y + screen.Bounds.Height);
            var width = right - left;
            var height = bottom - top;

            using (var screenBmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb))
            {
                using (var bmpGraphics = Graphics.FromImage(screenBmp))
                {
                    bmpGraphics.CopyFromScreen(left, top, 0, 0, new System.Drawing.Size(width, height));
                    return Imaging.CreateBitmapSourceFromHBitmap(screenBmp.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                }
            }
        }

        public Bitmap GetBitmapFromScreen()
        {
            double screenLeft = SystemParameters.VirtualScreenLeft;
            double screenTop = SystemParameters.VirtualScreenTop;
            double screenWidth = SystemParameters.VirtualScreenWidth;
            double screenHeight = SystemParameters.VirtualScreenHeight;

            Bitmap bmp = new Bitmap((int) screenWidth, (int) screenHeight);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen((int) screenLeft, (int) screenTop, 0, 0, bmp.Size);
                return bmp;
            }
        }
    }
}