using System.Drawing;

namespace AutoClicker.Model.Abstraction.Interface.Inputs
{
    public interface IImageSearch
    {
        Rectangle Search(Bitmap image, Bitmap sample, double accuracy = 0.9);
    }
}