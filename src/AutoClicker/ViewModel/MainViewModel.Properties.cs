using System.Collections.ObjectModel;
using System.Windows.Controls;
using AutoClicker.Model;
using AutoClicker.Model.Abstraction.Interface;
using MVVMBase;

namespace AutoClicker.ViewModel
{
    public partial class MainViewModel : BaseViewModel
    {
      
        private void BindProperties()
        {
            Bind(nameof(CurrentProject)).To(nameof(CurrentProjectSteps));
        }

        private Project _currentProject;
        public Project CurrentProject
        {
            get { return _currentProject; }
            set
            {
                _currentProject = value;
                OnPropertyChanged();
                CurrentStep = null;
            }
        }

        public ObservableCollection<IExecutableStep> CurrentProjectSteps
        {
            get { return CurrentProject?.Roots; }
            set
            {
                if(CurrentProject != null)
                {
                    CurrentProject.Roots = value;
                }
                OnPropertyChanged();
            }
        }

        private IExecutableStep _currentStep;
        public IExecutableStep CurrentStep
        {
            get { return _currentStep; }
            set
            {
                _currentStep = value;
                OnPropertyChanged();
                CurrentControl = ShowStepUserControl(_currentStep);
            }
        }

        private UserControl _currentControl;
        public UserControl CurrentControl
        {
            get { return _currentControl; }
            set
            {
                _currentControl = value;
                OnPropertyChanged();
            }
        }
    }
}