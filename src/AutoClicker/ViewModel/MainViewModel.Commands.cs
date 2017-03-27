using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using AutoClicker.Model;
using AutoClicker.Model.Abstraction.Interface;
using AutoClicker.Model.ExecutableSteps;
using MVVMBase;

namespace AutoClicker.ViewModel
{
    internal partial class MainViewModel : BaseViewModel
    {
        private void BindCommands()
        {
            BindToPropertyChange(nameof(CurrentProject), nameof(SaveProjectCommand));
            BindToPropertyChange(nameof(CurrentStep), nameof(AddNewNodeCommands));

        }

        public ICommand NewProjectCommand
        {
            get
            {
                return new DelegateCommand(executedParam =>
                {
                    CurrentProject = new Project();
                },
                canExecutedParam => true);
            }
        }

        public ICommand SaveProjectCommand
        {
            get
            {
                return new DelegateCommand(executedParam =>
                {
                    CurrentProject = new Project();
                },
                canExecutedParam => CurrentProject != null);
            }
        }

        public ICommand CloseCommand
        {
            get
            {
                return new DelegateCommand(executedParam =>
                {
                    Application.Current.Shutdown();
                },
                canExecutedParam => true);
            }
        }

        public ICommand AddNewNodeCommands
        {
            get
            {
                return new DelegateCommand(executedParam =>
                {
                    //CurrentStep.TryAddChild((IExecutableStep)executedParam);
                    CurrentStep.TryAddChild(new RootStep(Guid.NewGuid().ToString()));
                    CurrentStep.TryAddChild(new ClickStep(Guid.NewGuid().ToString(),MouseEventType.LeftClick, 4,null,null, "3434"));
                    OnPropertyChanged(nameof(CurrentProjectSteps));
                },
                canExecutedParam => CurrentStep != null);
            }
        }
    }
}