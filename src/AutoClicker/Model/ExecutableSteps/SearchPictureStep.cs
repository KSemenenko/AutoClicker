using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using AutoClicker.Model.Abstraction;
using AutoClicker.Model.Abstraction.Interface;
using AutoClicker.Model.Abstraction.Interface.Inputs;

namespace AutoClicker.Model.ExecutableSteps
{
    public class SearchPictureStep : StepBase
    {
        protected readonly ISearchPictureModule _searchPicture;
        protected readonly string _name;
        protected readonly IFileStore _fileStore;
        public SearchPictureStep(string id, ISearchPictureModule searchPictureModule, IFileStore fileStore, string name) : base(id)
        {
            _name = name;
            _searchPicture = searchPictureModule;
            _fileStore = fileStore;
        }

        public override AggregateException GetValidateException()
        {
            var exeptions = new List<Exception>();

            if (!_fileStore.FileExist(_name))
            {
                exeptions.Add(new FileNotFoundException(_name));
            }

            var childEx = base.GetValidateException();

            exeptions.AddRange(childEx.InnerExceptions);

            return new AggregateException(exeptions); 
        }

        public override ITestResult Execuite(bool isForced = false)
        {
            var rect = _searchPicture.SearchPicture(_name);

            if(rect == Rectangle.Empty)
            {
                Result.Result = ResulType.Warning;
            }

            rect = _searchPicture.SearchPicture(_name, 0.8);
            if (rect == Rectangle.Empty)
            {
                Result.Result = ResulType.Failed;
            }
            else
            {
                base.Execuite();
            }
            
            return Result;
        }
    }
}