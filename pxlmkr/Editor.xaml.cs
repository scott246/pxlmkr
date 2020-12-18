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
        UIElement gridLines;
		public Editor()
		{
			InitializeComponent();
		}

        private void ClearCanvasGridLines()
		{
            PixelCanvas.Children.Remove(gridLines);
        }

		private void InitializeCanvasGridLines()
		{
            Image lines = new Image();

            DrawingVisual gridLinesVisual = new DrawingVisual();
            DrawingContext dct = gridLinesVisual.RenderOpen();
            Brush lightPenBrush = new SolidColorBrush(Colors.LightGray);
            Pen lightPen = new Pen(lightPenBrush, 0.5);
            lightPen.Freeze();

            int rows = 15;
            int columns = 20;

            double canvasHeight = PixelCanvas.ActualHeight;
            double canvasWidth = PixelCanvas.ActualWidth;

            // Horizontal lines
            Point left = new Point(0, 0);
            Point right = new Point(canvasWidth, 0);
            double rowHeight = canvasHeight / rows;

            for (int i = 0; i <= rows; i++)
            {
                dct.DrawLine(lightPen, left, right);
                left.Offset(0, rowHeight);
                right.Offset(0, rowHeight);
            }

            // Vertical lines
            Point top = new Point(0, 0);
            Point bottom = new Point(0, canvasHeight);
            double colWidth = canvasWidth / columns;

            for (int i = 0; i <= columns; i++)
            {
                dct.DrawLine(lightPen, top, bottom);
                top.Offset(colWidth, 0);
                bottom.Offset(colWidth, 0);
            }

            dct.Close();

            // Render
            RenderTargetBitmap bmp = new RenderTargetBitmap((int)canvasWidth, (int)canvasHeight, 96, 96, PixelFormats.Pbgra32);
            bmp.Render(gridLinesVisual);
            bmp.Freeze();
            lines.Source = bmp;
            gridLines = lines;
            PixelCanvas.Children.Add(lines);
        }

		private void PixelCanvas_Loaded(object sender, RoutedEventArgs e)
		{
            ClearCanvasGridLines();
            InitializeCanvasGridLines();
        }

		private void PixelCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
		{
            ClearCanvasGridLines();
            InitializeCanvasGridLines();
		}
	}
}
