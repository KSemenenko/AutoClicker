using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoClicker.Interface
{
    public enum ResulType
    {
        Succeeded,
        Failed,
        Warning
    }

    public interface ITestResult
    {
        List<ITestResult> StackTrace { get; set; } 
        ResulType Result { get; set; } 
    }
}
