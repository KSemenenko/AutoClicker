using System;
using System.Threading;
using AutoClicker.Model.Abstraction.Interface;

namespace AutoClicker.Model.ExecutableSteps
{
    public class WaitPictureStep : SearchPictureStep
    {
        private readonly TimeSpan _delay;
        private int _countTry;
        public WaitPictureStep(string id, uint countTry, TimeSpan time, ISearchPictureModule searchPictureModule, IFileStore fileStore, string picturePath) 
            : base(id, searchPictureModule, fileStore, picturePath)
        {
            _delay = time;
            _countTry = (int)countTry;
        }

        public override ITestResult Execuite(bool isForced = false)
        {
            Rectangle rect = Rectangle.Empty;
            while(_countTry != 0)
            {
                rect = _searchPicture.SearchPicture(_picturePath);

                if(rect == Rectangle.Empty)
                {
                    _countTry--;
                    Thread.Sleep(_delay);
                }
                else
                {
                    base.Execuite();
                    break;
                }
               
            }

            if (rect == Rectangle.Empty)
            {
                Result.Result = ResulType.Failed;
            }

            return Result;

        }
    }
}
