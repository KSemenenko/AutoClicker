using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using AutoClicker.Model.Abstraction.Interface.Inputs;
using Size = System.Drawing.Size;

namespace AutoClicker.Model.Inputs
{
    internal class ScreenMaker : IScreenMaker
    {
        public BitmapSource GetBitmapSourceFromScreen()
        {
            var left = Screen.AllScreens.Min(screen => screen.Bounds.X);
            var top = Screen.AllScreens.Min(screen => screen.Bounds.Y);
            var right = Screen.AllScreens.Max(screen => screen.Bounds.X + screen.Bounds.Width);
            var bottom = Screen.AllScreens.Max(screen => screen.Bounds.Y + screen.Bounds.Height);
            var width = right - left;
            var height = bottom - top;

            using(var screenBmp = new Bitmap(width, height, PixelFormat.Format32bppArgb))
            {
                using(var bmpGraphics = Graphics.FromImage(screenBmp))
                {
                    bmpGraphics.CopyFromScreen(left, top, 0, 0, new Size(width, height));
                    return Imaging.CreateBitmapSourceFromHBitmap(screenBmp.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                }
            }
        }

        public Bitmap GetBitmapFromScreen()
        {
            var screenLeft = SystemParameters.VirtualScreenLeft;
            var screenTop = SystemParameters.VirtualScreenTop;
            var screenWidth = SystemParameters.VirtualScreenWidth;
            var screenHeight = SystemParameters.VirtualScreenHeight;

            var bmp = new Bitmap((int)screenWidth, (int)screenHeight);
            using(var g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen((int)screenLeft, (int)screenTop, 0, 0, bmp.Size);
                return bmp;
            }
        }

        public BitmapSource GetBitmapSourceFromScreen(Rectangle rectangle)
        {
            using(var screenBmp = new Bitmap(rectangle.Width, rectangle.Height, PixelFormat.Format32bppArgb))
            {
                using(var bmpGraphics = Graphics.FromImage(screenBmp))
                {
                    bmpGraphics.CopyFromScreen(rectangle.X, rectangle.Y, 0, 0, new Size(rectangle.Width, rectangle.Height));
                    return Imaging.CreateBitmapSourceFromHBitmap(screenBmp.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                }
            }
        }

        public Bitmap GetBitmapFromScreen(Rectangle rectangle)
        {
            var bmp = new Bitmap(rectangle.Width, rectangle.Height);
            using(var g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(rectangle.X, rectangle.Y, 0, 0, bmp.Size);
                return bmp;
            }
        }
    }
}