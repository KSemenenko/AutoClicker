using System;
using System.Globalization;
using System.Windows;
using AutoClicker.Model;
using AutoClicker.Model.Abstraction.Interface;
using AutoClicker.Model.ExecutableSteps;
using AutoClicker.Model.Inputs;
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
            model = new MainViewModel(this, new SearchPictureModule(new ImageSearch(), new ScreenMaker(), new FileStore()), new FileStore());
            DataContext = model;
        }

        private void TreeView_OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            model.CurrentStep = e.NewValue as IExecutableStep;
        }
    }
}