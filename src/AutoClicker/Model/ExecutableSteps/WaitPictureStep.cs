using System;
using System.Threading;
using AutoClicker.Model.Abstraction.Interface;

namespace AutoClicker.Model.ExecutableSteps
{
    public class WaitPictureStep : SearchPictureStep
    {
        private readonly TimeSpan _delay;
        private readonly int _countTry;
        public WaitPictureStep(string id, uint countTry, TimeSpan time, ISearchPictureModule searchPictureModule, string name) : base(id, searchPictureModule, name)
        {
            _delay = time;
            _countTry = (int)countTry;
        }

        public override ITestResult Execuite(bool isForced = false)
        { 
            Thread.Sleep(_delay);
            return base.Execuite();
        }
    }
}
