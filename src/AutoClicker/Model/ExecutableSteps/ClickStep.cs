using System;
using System.Collections.Generic;
using System.Drawing;
using AutoClicker.Model.Abstraction;
using AutoClicker.Model.Abstraction.Interface;
using AutoClicker.Model.Abstraction.Interface.Inputs;

namespace AutoClicker.Model.ExecutableSteps
{
    public class ClickStep : StepBase
    {
        private readonly ISearchPictureModule _searchPicture;
        private readonly IMouseEventModule _clickModule;
        private readonly string _name;
        private MouseEventType _type;
        private readonly uint _count;
        public ClickStep(string id, MouseEventType type, uint count, ISearchPictureModule searchPictureModule, string name) : base(id)
        {
            _name = name;
            _searchPicture = searchPictureModule;
            _clickModule = new MouseEventModule();
            _type = type;
            _count = count;
        }

        public override AggregateException GetValidateException()
        {
            var exeptions = new List<Exception>();

            //TODO : Kos add exeption if file don't exist
            var childEx = base.GetValidateException();

            exeptions.AddRange(childEx.InnerExceptions);

            return new AggregateException(exeptions);
        }

        public override ITestResult Execuite(bool isForced = false)
        {
            var rect = _searchPicture.SearchPicture(_name);

            if (rect.Equals(Rectangle.Empty))
            {
                Result.Result = ResulType.Warning; 
                rect = _searchPicture.SearchPicture(_name, 0.8);
            }
             
            if (rect.Equals(Rectangle.Empty))
            {
                Result.Result = ResulType.Failed;
            }
            else
            {
                _clickModule.Execuite(MouseEventType.Move, new Point(rect.CenterX, rect.CenterY));
                _clickModule.Execuite(_type, count: _count); 
                base.Execuite();
            }

            return Result;
        }
    }
}