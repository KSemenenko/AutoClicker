using System;
using System.Drawing;
using System.Windows.Media.Imaging;
using Rectangle = AutoClicker.Model.Rectangle;

namespace AutoClicker.Inputs
{
    interface IScreenMaker
    {
        BitmapSource GetBitmapSourceFromScreen();
        Bitmap GetBitmapFromScreen();
        BitmapSource GetBitmapSourceFromScreen(Rectangle rectangle);
        Bitmap GetBitmapFromScreen(Rectangle rectangle);
    }
}
