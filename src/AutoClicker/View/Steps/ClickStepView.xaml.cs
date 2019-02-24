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
using AutoClicker.View.Controls;
using AutoClicker.ViewModel;

namespace AutoClicker.View.Steps
{
    /// <summary>
    /// Interaction logic for ClickStepView.xaml
    /// </summary>
    public partial class ClickStepView : UserControl
    {
        private MainViewModel _viewModel;
        private ScreenShotMakerWindow _ssmw;

        public ClickStepView(MainViewModel model)
        {
            InitializeComponent();
            _viewModel = model;
            DataContext = model;
        }

        private void TakePicture_OnClick(object sender, RoutedEventArgs e)
        {
            _viewModel.MinimizeWindow();
            _ssmw = new ScreenShotMakerWindow();
            _ssmw.Closed += Ssmw_Closed;
            _ssmw.Show();
            _ssmw.WindowState = WindowState.Maximized;
            _ssmw.Focus();
        }

        private void Ssmw_Closed(object sender, EventArgs e)
        {
            img.Source = ((ScreenShotMakerWindow)sender).ImageSourceFromBitmap;
            _viewModel.RestoreWindow();
            _ssmw = null;
        }
    }
}