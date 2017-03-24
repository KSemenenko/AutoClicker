using System;
using System.Threading;
using AutoClicker.Model.Abstraction;
using AutoClicker.Model.Abstraction.Interface;

namespace AutoClicker.Model.ExecutableSteps
{
    public class WaitStep : StepBase
    {
        private readonly TimeSpan _time;

        public WaitStep(string id, TimeSpan time) : base(id)
        {
            _time = time;
        }

        public override ITestResult Execuite(bool isForced = false)
        {
            Thread.Sleep(_time);
            return base.Execuite(isForced);
        }
    }
}
