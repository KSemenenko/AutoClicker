using System.Collections.Generic;

namespace AutoClicker.Model.Abstraction.Interface
{
    public enum ResulType
    {
        Succeeded = 0,
        Warning = 1,
        Failed = 2
    }

    public interface ITestResult
    {
        List<ITestResult> StackTrace { get; set; }
        ResulType Result { get; set; }
    }
}