using System;
using System.Collections.Generic;

/*
 *  
*    Need implement types: 
*    Root,
*    Click, 
*    WaitSource,
*    ExecuiteTestCase,
*    ExecuiteIfNotFindSource
*
*/

namespace AutoClicker.Model.Abstraction.Interface
{
    public interface IExecutableStep
    {
        string Id { get; }
        IExecutableStep Root { get; set; }
        IEnumerable<IExecutableStep> Childs { get; }
        ITestResult Execuite(bool isForced = false);

        /// <summary>
        ///     Find step in all tree
        /// </summary>
        IExecutableStep FindExecutableStepById(string id);

        /// <summary>
        ///     Retur step from inner steps or return this
        /// </summary>
        IExecutableStep TryGetStepById(string id);

        bool TryResetChild(IExecutableStep child, string rootId = null);
        bool TryAddChild(IExecutableStep child, string rootId = null);
        bool TryRemoveChild(string id);
        bool TryRemoveChild(IExecutableStep child);
        AggregateException GetValidateException();
    }
}