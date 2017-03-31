using System;
using System.Globalization;
using System.Windows;
using AutoClicker.Model.Abstraction.Interface;
using AutoClicker.Model.ExecutableSteps;
using AutoClicker.ViewModel;

namespace AutoClicker.View
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel model;

        public MainWindow()
        {
            InitializeComponent();
            model = new MainViewModel();
            DataContext = model;
        }

        private void TreeView_OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            model.CurrentStep = e.NewValue as IExecutableStep;
        }
    }
}