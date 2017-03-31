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
        protected readonly IFileStore _fileStore;

        public SearchPictureModule(IImageSearch imageSearch, IScreenMaker screenMaker, IFileStore fileStore)
        {
            _imageSearch = imageSearch;
            _screenMaker = screenMaker;
            _fileStore = fileStore;
        }

        public Rectangle SearchPicture(string name, double accuracy = 0.9)
        {
            if (!_fileStore.FileExist(name))
            {
                return Rectangle.Empty;
            }

            var screen = _screenMaker.GetBitmapFromScreen();
            Bitmap sample = _fileStore.LoadImageFromFile(name);
            var rect = _imageSearch.Search(screen, sample, accuracy);

            return rect;
           
        }
    }
}
