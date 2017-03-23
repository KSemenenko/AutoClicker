using System;
using System.Windows;
using AutoClicker.ViewModel;

namespace AutoClicker.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
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
    }
}
