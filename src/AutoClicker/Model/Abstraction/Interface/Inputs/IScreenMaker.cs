﻿using System.Drawing;
using System.Windows.Media.Imaging;

namespace AutoClicker.Model.Abstraction.Interface.Inputs
{
    internal interface IScreenMaker
    {
        BitmapSource GetBitmapSourceFromScreen();
        Bitmap GetBitmapFromScreen();
        BitmapSource GetBitmapSourceFromScreen(Rectangle rectangle);
        Bitmap GetBitmapFromScreen(Rectangle rectangle);
    }
}