using System.Collections.Generic;

namespace AutoClicker.Model.Abstraction.Interface
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