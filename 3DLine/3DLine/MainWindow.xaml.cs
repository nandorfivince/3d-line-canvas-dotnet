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

namespace _3DLine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double lineWidth = 3d;
        private Line line = null;

        private double x1, x2, y1, y2 = 0.0d;

        public MainWindow()
        {
            InitializeComponent();
            line = new Line
            {
                X1 = 0,
                Y1 = 0,
                X2 = 100,
                Y2 = 100,
                Stroke = new SolidColorBrush(Colors.Black),
                StrokeThickness = 10
            };
            myCanvas.Children.Add(line);
        }

        async void lineThickness_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lineWidth = e.NewValue;

            await Draw();
        }

        async Task Draw()
        {
            if (line != null)
            {
                line.StrokeThickness = lineWidth;
                line.X1 = x1;
                line.X2 = x2;
                line.Y1 = y1;
                line.Y2 = y2;
            }
        }

        async void btnX1_Click(object sender, RoutedEventArgs e)
        {
            var btn = (sender as Button);

            x1 = line.X1;
            x2 = line.X2;
            y1 = line.Y1;
            y2 = line.Y2;

            switch (btn.Content.ToString())
            {
                case "X1":
                    x1 += 1;
                    break;
                case "Y1":
                    y1++;
                    break;
                case "X2":
                    ++x2;
                    break;
                case "Y2":
                    y2 += 1;
                    break;
            }


            await Draw();
        }
    }
}
