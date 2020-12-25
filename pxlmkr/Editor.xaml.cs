using pxlmkr.Utils;
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
                    StrokeThickness = 1
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
                    StrokeThickness = 1
                };
                PixelCanvas.Children.Add(gridLine);
            }
		}
        
        private void PaintCurrentPixel()
		{
            Point mousePos = Mouse.GetPosition(PixelCanvas);
            int rowPos = (int)(mousePos.X / rowHeight);
            int colPos = (int)(mousePos.Y / colWidth);
            double pixelTopPos = colPos * colWidth;
            double pixelLeftPos = rowPos * rowHeight;

            // paint if LMB down
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                if (Mouse.DirectlyOver.GetType() == typeof(Rectangle))
                {
                    Rectangle paintedPixel = (Rectangle)Mouse.DirectlyOver;
                    paintedPixel.Fill = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    Rectangle pixelToPaint = new Rectangle
                    {
                        Width = colWidth,
                        Height = rowHeight,
                        Fill = new SolidColorBrush(Colors.Black)
                    };
                    Canvas.SetLeft(pixelToPaint, pixelLeftPos);
                    Canvas.SetTop(pixelToPaint, pixelTopPos);
                    PixelCanvas.Children.Add(pixelToPaint);
                }
            }

            else if (Mouse.RightButton == MouseButtonState.Pressed)
            {
                if (Mouse.DirectlyOver.GetType() == typeof(Rectangle))
                {
                    PixelCanvas.Children.Remove((UIElement)Mouse.DirectlyOver);
                }
            }
        }

		private void PixelCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            CalculateGridInfo();
            UpdateHelpText("");
            InitializeCanvasGridLines();
        }

		private void PixelCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PaintCurrentPixel();
        }

        private void PixelCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            // update cursor position
            Point mousePos = Mouse.GetPosition(PixelCanvas);
            int rowPos = (int)(mousePos.X / rowHeight);
            int colPos = (int)(mousePos.Y / colWidth);
            if (rowPos > rows) rowPos = rows;
            if (colPos > cols) colPos = cols;
            CursorPositionLabel.Content = (rowPos + 1) + " : " + (colPos + 1);

            PaintCurrentPixel();
        }

        public void UpdateHelpText(string newHelpText)
		{
            HelpTextLabel.Content = newHelpText;
		}

        private void ClearHelpText(object sender, MouseEventArgs e)
        {
            UpdateHelpText("");
        }

		private void DescribeControl(object sender, MouseEventArgs e)
		{
            UpdateHelpText(EditorUtils.GetControlDescription(((Control)sender).Name));
		}

		private void BrushSizeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
            // change brush size
            BrushSizeLabel.Content = BrushSizeSlider.Value;
		}

        private void MenuItemClicked(object sender, RoutedEventArgs e)
        {
            switch (((MenuItem)sender).Name)
            {
                case "NewMenuItem":
                    break;
                case "OpenMenuItem":
                    break;
                case "SaveMenuItem":
                    break;
                case "SaveAsMenuItem":
                    break;
                case "ExportMenuItem":
                    break;
                case "SettingsMenuItem":
                    break;
                case "ExitMenuItem":
                    Application.Current.Shutdown();
                    break;
                case "HelpMenuItem":
                    break;
                case "AboutMenuItem":
                    break;
                default:
                    break;
            }
        }
    }
}
