using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoClicker.Model.Abstraction.Interface.Inputs;

namespace AutoClicker.Model.ExecutableSteps
{
    public class SearchPictureModule
    {
        protected readonly IImageSearch _imageSearch;
        protected readonly Bitmap _sample;
        protected readonly IScreenMaker _screenMaker;

        public SearchPictureModule(IImageSearch imageSearch, IScreenMaker screenMaker, Bitmap sample)
        {
            _imageSearch = imageSearch;
            _screenMaker = screenMaker;
            _sample = sample;
        }

        public Rectangle SearchPicture(double accuracy = 1)
        {
            var screen = _screenMaker.GetBitmapFromScreen();
            var rect = _imageSearch.Search(screen, _sample, accuracy);
            
            return rect;
        }
    }
}
