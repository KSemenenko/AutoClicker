using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using AutoClicker.Model;
using AutoClicker.Model.Abstraction.Interface;
using AutoClicker.Model.ExecutableSteps;
using AutoClicker.View.Steps;
using MVVMBase;

namespace AutoClicker.ViewModel
{
    public partial class MainViewModel : BaseViewModel
    {
        private ISearchPictureModule _searchPictureModule;
        private IFileStore _fileStore;
        private Window _window;
        private Dictionary<string, UserControl> stepControls = new Dictionary<string, UserControl>();

        public MainViewModel(Window window, ISearchPictureModule searchPictureModule, IFileStore fileStore)
        {
            _window = window;
            _searchPictureModule = searchPictureModule;
            _fileStore = fileStore;

            BindProperties();
            BindCommands();

            stepControls.Add(typeof(SearchPictureStep).FullName, new SearchPictureStepView(this));
            stepControls.Add(typeof(ClickStep).FullName, new ClickStepView(this));
            stepControls.Add(typeof(RootStep).FullName, new RootStepView(this));
        }

        private UserControl ShowStepUserControl(IExecutableStep step)
        {
            if(step == null)
                return null;

            var type = step.GetType().FullName;
            return stepControls[type];
        }

        public void RestoreWindow()
        {
            _window.WindowState = WindowState.Normal;
        }

        public void MinimizeWindow()
        {
            _window.WindowState = WindowState.Minimized;
        }

        public void MaximizeWindow()
        {
            _window.WindowState = WindowState.Maximized;
        }
    }
}