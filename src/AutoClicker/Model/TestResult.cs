using System;
using System.Collections.Generic;
using AutoClicker.Model.Abstraction.Interface;

namespace AutoClicker.Model
{
    internal class TestResult : ITestResult
    {
        public List<ITestResult> StackTrace { get; set; } = new List<ITestResult>();

        private ResulType _result = ResulType.Succeeded;

        public ResulType Result
        {
            get { return _result; }
            set
            {
                if (value > _result)
                {
                    _result = value;
                }
            }
        }
    }
}