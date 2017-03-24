using System;
using System.Drawing;
using AutoClicker.Model.Abstraction;
using AutoClicker.Model.Abstraction.Interface;
using AutoClicker.Model.Abstraction.Interface.Inputs;

namespace AutoClicker.Model.ExecutableSteps
{
    public class ClickStep : StepBase
    {
        public ClickStep(string id) : base(id)
        {
        }

        public override ITestResult Execuite(bool isForced = false)
        { 
            return base.Execuite();
        }
    }
}