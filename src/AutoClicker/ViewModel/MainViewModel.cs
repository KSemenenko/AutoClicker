using System.Collections.ObjectModel;
using AutoClicker.Model;
using AutoClicker.Model.Abstraction.Interface;
using MVVMBase;

namespace AutoClicker.ViewModel
{
    internal partial class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            BindProperties();
            BindCommands();
        }


    }
}