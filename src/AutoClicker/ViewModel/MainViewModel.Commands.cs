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
    public partial class MainViewModel : BaseViewModel
    {
        private void BindCommands()
        {
            Bind(nameof(CurrentProject)).To(nameof(SaveProjectCommand));
            Bind(nameof(CurrentStep)).To(nameof(AddClickStepCommands)).To(nameof(AddSearchPictureStepCommands)).To(nameof(RemoveNodeCommands));

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

        public ICommand AddClickStepCommands
        {
            get
            {
                return new DelegateCommand(executedParam =>
                {
                    
                    if (CurrentStep.TryAddChild(new ClickStep(Guid.NewGuid().ToString(), MouseEventType.LeftClick, 4, _searchPictureModule, _fileStore, Guid.NewGuid().ToString())))
                    {
                        OnPropertyChanged(nameof(CurrentProjectSteps));
                        OnPropertyChanged(nameof(CurrentStep));
                    }
                    
                },
                canExecutedParam => CurrentStep != null);
            }
        }

        public ICommand AddSearchPictureStepCommands
        {
            get
            {
                return new DelegateCommand(executedParam =>
                {

                    if (CurrentStep.TryAddChild(new SearchPictureStep(Guid.NewGuid().ToString(), _searchPictureModule, _fileStore, "img.png")))
                    {
                        OnPropertyChanged(nameof(CurrentProjectSteps));
                        OnPropertyChanged(nameof(CurrentStep));
                    }

                },
                canExecutedParam => CurrentStep != null);
            }
        }

        public ICommand RemoveNodeCommands
        {
            get
            {
                return new DelegateCommand(executedParam =>
                {
                    if(CurrentStep.TryRemoveChild(CurrentStep))
                    {
                        OnPropertyChanged(nameof(CurrentProjectSteps));
                        OnPropertyChanged(nameof(CurrentStep));
                    }

                },
                canExecutedParam => CurrentStep != null);
            }
        }


    }
}