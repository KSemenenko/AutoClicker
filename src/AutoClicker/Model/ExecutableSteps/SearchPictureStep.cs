using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using AutoClicker.Model.Abstraction;
using AutoClicker.Model.Abstraction.Interface;
using AutoClicker.Model.Abstraction.Interface.Inputs;

namespace AutoClicker.Model.ExecutableSteps
{
    public class SearchPictureStep : StepBase
    {
        protected readonly ISearchPictureModule _searchPicture;
        protected readonly string _picturePath;
        protected readonly IFileStore _fileStore;
        public SearchPictureStep(string id, ISearchPictureModule searchPictureModule, IFileStore fileStore, string picturePath) : base(id)
        {
            _picturePath = picturePath;
            _searchPicture = searchPictureModule;
            _fileStore = fileStore;
        }

        public override AggregateException GetValidateException()
        {
            var exeptions = new List<Exception>();

            if (!_fileStore.FileExist(_picturePath))
            {
                exeptions.Add(new FileNotFoundException(_picturePath));
            }

            var childEx = base.GetValidateException();

            exeptions.AddRange(childEx.InnerExceptions);

            return new AggregateException(exeptions); 
        }

        public static explicit operator SearchPictureStep(UserControl v)
        {
            throw new NotImplementedException();
        }

        public override ITestResult Execuite(bool isForced = false)
        {
            var rect = _searchPicture.SearchPicture(_picturePath);

            if(rect == Rectangle.Empty)
            {
                Result.Result = ResulType.Warning;
            }

            rect = _searchPicture.SearchPicture(_picturePath, 0.8);
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