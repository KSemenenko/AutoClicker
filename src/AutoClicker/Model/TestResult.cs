using System.Collections.Generic;
using AutoClicker.Model.Abstraction.Interface;

namespace AutoClicker.Model
{
    class TestResult : ITestResult
    {
        public List<ITestResult> StackTrace { get; set; } = new List<ITestResult>();
        public ResulType Result { get; set; } 
    }
}
