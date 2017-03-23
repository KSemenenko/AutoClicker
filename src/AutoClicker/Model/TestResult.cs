using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoClicker.Interface;

namespace AutoClicker.Model
{
    class TestResult : ITestResult
    {
        public List<ITestResult> StackTrace { get; set; } = new List<ITestResult>();
        public ResulType Result { get; set; } 
    }
}
