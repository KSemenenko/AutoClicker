using System;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using AutoClicker.Interface.Inputs;
using AutoClicker.Model.Inputs;
using Rectangle = System.Windows.Shapes.Rectangle;

namespace AutoClicker.View
{
    /// <summary>
    ///     Interaction logic for ScreenShotMakerWindow.xaml
    /// </summary>
    public partial class ScreenShotMakerWindow : Window
    {
        private double height;
        private bool isMouseDown;
        private readonly IScreenMaker screenMaker;
        private double width;
        private double x;
        private double y;

        public ScreenShotMakerWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            screenMaker = new ScreenMaker();
        }

        public Bitmap CaptureBitmap { get; private set; }

        public ImageSource ImageSourceFromBitmap
        {
            get
            {
                if (CaptureBitmap == null)
                    return null;

                return Imaging.CreateBitmapSourceFromHBitmap(CaptureBitmap.GetHbitmap(),
                    IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isMouseDown = true;
            x = e.GetPosition(null).X;
            y = e.GetPosition(null).Y;
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                var curx = e.GetPosition(null).X;
                var cury = e.GetPosition(null).Y;

                var brush = new SolidColorBrush(Colors.White);
                var r = new Rectangle
                {
                    Stroke = brush,
                    Fill = brush,
                    StrokeThickness = 1,
                    Width = Math.Abs(curx - x),
                    Height = Math.Abs(cury - y)
                };

                cnv.Children.Clear();
                cnv.Children.Add(r);

                Canvas.SetLeft(r, x);
                Canvas.SetTop(r, y);

                if (e.LeftButton == MouseButtonState.Released)
                {
                    cnv.Children.Clear();
                    width = e.GetPosition(null).X - x;
                    height = e.GetPosition(null).Y - y;
                    CaptureBitmap = screenMaker.GetBitmapFromScreen(new Model.Rectangle(x, y, width, height));
                    x = y = 0;
                    isMouseDown = false;
                    Close();
                }
            }
        }
    }
}