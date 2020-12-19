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

namespace pxlmkr
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class Editor : Window
	{
		public Editor()
		{
			InitializeComponent();
		}

        private void InitializeCanvasGridLines()
		{
            int rows = 16;
            int cols = 16;
            double canvasHeight = PixelCanvas.ActualHeight;
            double canvasWidth = PixelCanvas.ActualWidth;
            double rowHeight = canvasHeight / rows;
            double colWidth = canvasWidth / cols;

            for (int curRow = 0; curRow <= rows; curRow++)
			{
                Line gridLine = new Line
                {
                    X1 = 0,
                    X2 = canvasWidth,
                    Y1 = rowHeight * curRow,
                    Y2 = rowHeight * curRow,
                    Stroke = Brushes.DarkGray,
                    StrokeThickness = 2
				};
                PixelCanvas.Children.Add(gridLine);
            }
            for (int curCol = 0; curCol <= cols; curCol++)
            {
                Line gridLine = new Line
                {
                    X1 = colWidth * curCol,
                    X2 = colWidth * curCol,
                    Y1 = 0,
                    Y2 = canvasHeight,
                    Stroke = Brushes.DarkGray,
                    StrokeThickness = 2
                };
                PixelCanvas.Children.Add(gridLine);
            }
		}

		private void PixelCanvas_Loaded(object sender, RoutedEventArgs e)
		{
            InitializeCanvasGridLines();
        }

		private void PixelCanvas_MouseDown(object sender, MouseButtonEventArgs e)
		{

		}
	}
}
