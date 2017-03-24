using System;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace AutoClicker.Inputs
{
    interface IScreenMaker
    {
        BitmapSource GetBitmapSourceFromScreen();
        Bitmap GetBitmapFromScreen();
        BitmapSource GetBitmapSourceFromScreen(Model.Rectangle rectangle);
        Bitmap GetBitmapFromScreen(Model.Rectangle rectangle);
    }
}
