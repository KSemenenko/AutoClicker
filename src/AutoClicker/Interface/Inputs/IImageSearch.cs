using System;
using System.Drawing;

namespace AutoClicker.Inputs
{
    interface IImageSearch
    {
        Model.Rectangle Search(Bitmap image, Bitmap sample, double accuracy = 0.9);
    }
}
