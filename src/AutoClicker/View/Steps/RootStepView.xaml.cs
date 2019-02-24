using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AutoClicker.Model.ExecutableSteps;
using AutoClicker.ViewModel;

namespace AutoClicker.View.Steps
{
    /// <summary>
    /// Interaction logic for RootStepView.xaml
    /// </summary>
    public partial class RootStepView : UserControl
    {
        private MainViewModel _viewModel;
        public RootStepView(MainViewModel model)
        {
            InitializeComponent();
            _viewModel = model;
        }

        public RootStep Step { get; set; }
    }
}
