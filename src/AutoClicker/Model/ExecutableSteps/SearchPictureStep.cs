using System;
using System.Drawing;
using AutoClicker.Model.Abstraction;
using AutoClicker.Model.Abstraction.Interface;
using AutoClicker.Model.Abstraction.Interface.Inputs;

namespace AutoClicker.Model.ExecutableSteps
{
    public class SearchPictureStep : StepBase
    {
        private readonly IImageSearch _imageSearch;
        private readonly IScreenMaker _screenMaker;
        private readonly Bitmap _sample;

        public SearchPictureStep(string id, IImageSearch imageSearch, IScreenMaker screenMaker, Bitmap sample) : base(id)
        {
            _imageSearch = imageSearch;
            _screenMaker = screenMaker;
            _sample = sample;
        }

        public Rectangle SearchPicture()
        {
            var screen = _screenMaker.GetBitmapFromScreen();
            var rect = _imageSearch.Search(screen, _sample);

            if (rect == Rectangle.Empty)
            {
                Result.Result = ResulType.Warning;
                rect = _imageSearch.Search(screen, _sample, 0.8);
            }

            return rect;
        }

        public override ITestResult Execuite(bool isForced = false)
        {
            var rect = SearchPicture();

            if (rect == Rectangle.Empty)
            {
                Result.Result = ResulType.Failed;
            }
            else
            {
                Result.StackTrace.Add(base.Execuite());
            }
            return Result;

        }
    }
}