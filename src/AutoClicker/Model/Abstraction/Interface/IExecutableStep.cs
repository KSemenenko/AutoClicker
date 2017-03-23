using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 *  
*    Need implement types: 
*    Root,
*    Click,
*    DoubleClick,
*    WaitSource,
*    ExecuiteTestCase,
*    ExecuiteIfNotFindSource
*
*/
namespace AutoClicker.Interface
{
    public interface IExecutableStep
    {
        string Id { get; } 
        IExecutableStep Root { get; set; }
        IEnumerable<IExecutableStep> Childs { get; }
        ITestResult Execuite();

        /// <summary>
        /// Find step in all tree
        /// </summary>
        IExecutableStep FindExecutableStepById(string id);

        /// <summary>
        /// Retur step from inner steps or return this
        /// </summary>
        IExecutableStep TryGetStepById(string id);

        bool TryResetChild(string rootId, IExecutableStep child);
        bool TryAddChild(string rootId, IExecutableStep child);
        bool TryRemoveChild(string id);
        bool TryRemoveChild(IExecutableStep child);
        AggregateException GetValidateException();
    }
}
