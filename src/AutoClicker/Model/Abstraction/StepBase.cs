using System;
using System.Collections.Generic;
using System.Linq;
using AutoClicker.Interface;

namespace AutoClicker.Model.ExecutableSteps
{
    public abstract class StepBase : IExecutableStep
    {
        protected StepBase(string id)
        {
            Id = id;
        }
 
        
        public IEnumerable<IExecutableStep> Childs => _childs;
        public string Id { get; }
        public IExecutableStep Root { get; set; }
         
        private readonly List<IExecutableStep> _childs = new List<IExecutableStep>();

        public virtual bool TryResetChild(string rootId, IExecutableStep child)
        {
            if (rootId == Id)
            {
                return ResetChild(child);
            }
        
            var root = FindExecutableStepById(rootId);
            if (root != null)
                return root.TryResetChild(rootId, child);
            
            return false;
        }
        private bool ResetChild(IExecutableStep child)
        {
            for (int i = 0; i < _childs.Count; i++)
            {
                if (child.Id == _childs[i].Id)
                {
                    _childs[i] = child;
                    return true;
                }
            }
           
            return false;
        }
        public bool TryAddChild(string rootId, IExecutableStep child)
        {
            if (rootId == Id)
            { 
                 return AddChild(child); 
            }
            else
            {
                var root = FindExecutableStepById(rootId);
                if (root != null)
                    return root.TryAddChild(rootId, child);
            }
            return false;
        }


        private bool AddChild(IExecutableStep child)
        {
            if (FindExecutableStepById(child.Id) == null)
            {
                _childs.Add(child);
                child.Root = this;
                return true;
            }
            return false;
        }

       
        public bool TryRemoveChild(string id)
        {
            var step = FindExecutableStepById(id);
            if (step?.Root != null)
            {
                return TryRemoveChild(step);
            } 
            return false;
        }

        public bool TryRemoveChild(IExecutableStep child)
        {
            if (child.Root.Id == Id)
            {
                _childs.Remove(child);
                return true;
            }
            else
            {
                return child.Root.TryRemoveChild(child);
            } 
        }

        
        public virtual ITestResult Execuite()
        {
            var childsResult = new TestResult {Result = ResulType.Succeeded};

            foreach (var child in Childs)
            {
                var result = child.Execuite();
                childsResult.StackTrace.Add(result);

                if (result.Result == ResulType.Failed)
                {
                    childsResult.Result = ResulType.Failed;
                    break;
                }
                if (result.Result == ResulType.Warning)
                    childsResult.Result = ResulType.Warning;
            }

            return childsResult;
        }


        public virtual AggregateException  GetValidateException()
        {
            var childsEx = new List<Exception>();
            foreach (var child in Childs)
            {
                if (child == null)
                {
                    childsEx.Add(new NullReferenceException());
                    continue;
                }

                var innerExceptions = child.GetValidateException().InnerExceptions;
                if (innerExceptions != null)
                    childsEx.AddRange(innerExceptions.ToArray());
            }
         
           return new AggregateException(childsEx);
            
        }

        public virtual IExecutableStep FindExecutableStepById(string id)
        {
            var step = TryGetStepById(id);
            
            if (step == null && Root != null)
                step = Root.FindExecutableStepById(id);

            return step;
        }

        public virtual IExecutableStep TryGetStepById(string id)
        {
            IExecutableStep step = null;
            if (id == Id)
                step = this;
            else
            {
                foreach (var child in Childs)
                {
                    step = child.TryGetStepById(id);
                    if (step != null)
                        break;
                }
            }
            return step;
        }
    }
}