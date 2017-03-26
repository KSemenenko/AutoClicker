using System;
using System.Collections.Generic;
using System.Linq;
using AutoClicker.Model.Abstraction.Interface;

namespace AutoClicker.Model.Abstraction
{
    public abstract class StepBase : IExecutableStep
    {
        private readonly List<IExecutableStep> _childs = new List<IExecutableStep>();
        protected ITestResult Result = new TestResult();

        protected StepBase(string id)
        {
            Id = id;
        }

        public IEnumerable<IExecutableStep> Childs => _childs;
        public string Id { get; }
        public IExecutableStep Root { get; set; }

        public virtual bool TryResetChild(IExecutableStep child, string rootId = null)
        {

            if (child.Root != null)
                return false;

            if (!string.IsNullOrEmpty(rootId))
            {
                if (rootId == Id)
                    return ResetChild(child);

                var rootStep = FindExecutableStepById(rootId);
                if (rootStep != null)
                    return rootStep.TryResetChild(child, rootId);

                return false;
            }

            var root = FindExecutableStepById(child.Id)?.Root;
            if (root != null)
                return root.TryResetChild(child, root.Id);

            return false;
        }

        public bool TryAddChild(IExecutableStep child, string rootId = null)
        {
            if (child == null)
                return false;

            if (child.Root != null)
                return false;

            if (string.IsNullOrEmpty(rootId))
                return AddChild(child);

            if (rootId == Id)
                return AddChild(child);

            var root = FindExecutableStepById(rootId);
            if (root != null)
                return root.TryAddChild(child);

            return false;
        }

        public bool TryRemoveChild(string id)
        {
            var step = FindExecutableStepById(id);
            if (step?.Root != null)
                return step.Root.TryRemoveChild(step);

            return false;
        }

        public bool TryRemoveChild(IExecutableStep child)
        {
            if (child?.Root == null)
                return false;

            if (_childs.Contains(child))
            {
                _childs.Remove(child);
                return true;
            }

            var step = FindExecutableStepById(child.Root.Id);
            if (step?.Root != null)
                return step.TryRemoveChild(child);

            return false;
        }

        public virtual ITestResult Execuite(bool isForced = false)
        {
            foreach (var child in Childs)
            {
                var result = child.Execuite();
                Result.StackTrace.Add(result);
                Result.Result = result.Result;
                if (result.Result == ResulType.Failed)
                {
                    break;
                }
            }

            return Result;
        }

        public virtual AggregateException GetValidateException()
        {
            var childsEx = new List<Exception>();
            foreach (var child in Childs)
            {
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
                foreach (var child in Childs)
                {
                    step = child.TryGetStepById(id);
                    if (step != null)
                        break;
                }
            return step;
        }
        
        private bool CheckAllChildsIsNotRecource(IExecutableStep child)
        {
            return child.FindExecutableStepById(Id) == null; 
        }

        private bool ResetChild(IExecutableStep child)
        { 
            if (CheckAllChildsIsNotRecource(child))
            {
                for (var i = 0; i < _childs.Count; i++)
                    if (child.Id == _childs[i].Id)
                    {
                        _childs[i] = child;
                        child.Root = this;
                        return true;
                    }
            } 

            return false;
        }

        private bool AddChild(IExecutableStep child)
        {  
            if (CheckAllChildsIsNotRecource(child))
            {
                _childs.Add(child);
                child.Root = this;
                return true;
            }
            return false;
        }
    }
}