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
        int rows;
        int cols;
        double canvasHeight;
        double canvasWidth;
        double rowHeight;
        double colWidth;

        public Editor()
		{
			InitializeComponent();
            CalculateGridInfo();
		}

        private void CalculateGridInfo()
		{
            rows = 16;
            cols = 16;
            canvasHeight = PixelCanvas.ActualHeight;
            canvasWidth = PixelCanvas.ActualWidth;
            rowHeight = canvasHeight / rows;
            colWidth = canvasWidth / cols;
		}

        private void InitializeCanvasGridLines()
        {
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
            CalculateGridInfo();
            InitializeCanvasGridLines();
        }

		private void PixelCanvas_MouseDown(object sender, MouseButtonEventArgs e)
		{

		}

        private void PixelCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = Mouse.GetPosition(PixelCanvas);
            int rowPos = (int)(mousePos.X / rowHeight) + 1;
            if (rowPos > rows)
            {
                rowPos = rows;
            }
            int colPos = (int)(mousePos.Y / colWidth) + 1;
            if (colPos > cols)
			{
                colPos = cols;
			}
            CursorPositionLabel.Content = rowPos + " : " + colPos;
		}
	}
}
