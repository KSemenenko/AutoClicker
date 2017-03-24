using System; 
using AutoClicker.Interface;
using AutoClicker.Model.Abstraction;

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
