using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using AutoClicker.Interface;

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
