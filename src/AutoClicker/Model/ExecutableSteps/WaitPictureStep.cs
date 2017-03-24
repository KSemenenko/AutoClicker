using System;
using System.Drawing;
using System.Threading;
using AutoClicker.Model.Abstraction;
using AutoClicker.Model.Abstraction.Interface;
using AutoClicker.Model.Abstraction.Interface.Inputs;

namespace AutoClicker.Model.ExecutableSteps
{
    public class WaitPictureStep : SearchPictureStep
    {
        private readonly TimeSpan _delay;
        private readonly int _countTry;
        public WaitPictureStep(string id, uint countTry, TimeSpan time, IImageSearch imageSearch, IScreenMaker screenMaker, Bitmap sample) : base(id, imageSearch, screenMaker, sample)
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
