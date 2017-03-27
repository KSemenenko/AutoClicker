using System.Drawing;
using System.IO;
using AutoClicker.Model.Abstraction.Interface;
using AutoClicker.Model.Abstraction.Interface.Inputs;

namespace AutoClicker.Model.ExecutableSteps
{
    public class SearchPictureModule : ISearchPictureModule
    {
        protected readonly IImageSearch _imageSearch;
        protected readonly IScreenMaker _screenMaker;

        public SearchPictureModule(IImageSearch imageSearch, IScreenMaker screenMaker)
        {
            _imageSearch = imageSearch;
            _screenMaker = screenMaker; 
        }

        public Rectangle SearchPicture(string name, double accuracy = 0.9)
        {
            //TODO: Kos FIIX
            //if(!File.Exists(name)) 
            //    return Rectangle.Empty;

            var screen = _screenMaker.GetBitmapFromScreen();
            //TODO: Kos FIIX
            /*
            var sample = Bitmap.FromFile(name) as Bitmap; // found by name
            */
            Bitmap sample = null;
            var rect = _imageSearch.Search(screen, sample, accuracy);

            return rect;
           
        }
    }
}
