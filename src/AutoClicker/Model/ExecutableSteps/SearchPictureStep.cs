using System.Drawing;
using AutoClicker.Model.Abstraction;
using AutoClicker.Model.Abstraction.Interface;
using AutoClicker.Model.Abstraction.Interface.Inputs;

namespace AutoClicker.Model.ExecutableSteps
{
    public class SearchPictureStep : StepBase
    {
        private readonly SearchPictureModule _searchPicture;
        public SearchPictureStep(string id, IImageSearch imageSearch, IScreenMaker screenMaker, Bitmap sample) : base(id)
        {
            _searchPicture = new SearchPictureModule(imageSearch, screenMaker, sample); 
        }

       

        public override ITestResult Execuite(bool isForced = false)
        {
            var rect = _searchPicture.SearchPicture();

            if(rect.Equals(Rectangle.Empty))
            {
                Result.Result = ResulType.Warning;
            }

            rect = _searchPicture.SearchPicture(0.8);
            if (rect.Equals(Rectangle.Empty))
            {
                Result.Result = ResulType.Failed;
            }
            else
            {
                base.Execuite();
            }
            
            return Result;
        }
    }
}