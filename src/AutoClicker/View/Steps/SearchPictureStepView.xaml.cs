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
using AutoClicker.Model.Abstraction.Interface;
using AutoClicker.Model.ExecutableSteps;
using AutoClicker.ViewModel;

namespace AutoClicker.View.Steps
{
    /// <summary>
    /// Interaction logic for SearchPictureStepView.xaml
    /// </summary>
    public partial class SearchPictureStepView : UserControl
    {
        private MainViewModel _viewModel;
        public SearchPictureStepView(MainViewModel model)
        {
            InitializeComponent();
            _viewModel = model;
        }

        public SearchPictureStep Step { get; set; }

        //public SearchPictureStep Step
        //{
        //    get { return (SearchPictureStep)GetValue(StepProperty); }
        //    set { SetValue(StepProperty, value); }
        //}

        //public static DependencyProperty StepProperty = DependencyProperty.Register("ProtocolNumber", typeof(SearchPictureStep), typeof(SearchPictureStepView));
    }
}
