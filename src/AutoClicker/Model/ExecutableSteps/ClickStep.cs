using System;
using AutoClicker.Model.Abstraction;
using AutoClicker.Model.Abstraction.Interface;

namespace AutoClicker.Model.ExecutableSteps
{
    public class ClickStep : StepBase
    {
        public ClickStep(string id) : base(id)
        {
        }

        public override ITestResult Execuite()
        {
            Console.WriteLine("ye");
            return base.Execuite();
        }
    }
}