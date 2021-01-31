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
        static Project project;
        public int currentLayer = 0;
        public SolidColorBrush currentColorBrush = new SolidColorBrush(Colors.Black);
        public static Editor editorInstance;
        public int rows = 16;
        public int cols = 16;
        public int pixelSize = 16;
        public double canvasHeight = 256;
        public double canvasWidth = 256;

        public Editor()
		{
			InitializeComponent();
            PixelCanvas.Width = canvasWidth;
            PixelCanvas.Height = canvasHeight;
            editorInstance = this;
            project = new Project();
            project.AddLayer(rows, cols);
		}

        private void InitializeCanvasGridLines()
        {
            for (int curRow = 0; curRow <= rows; curRow++)
			{
                Line gridLine = new Line
                {
                    X1 = 0,
                    X2 = canvasWidth,
                    Y1 = pixelSize * curRow,
                    Y2 = pixelSize * curRow,
                    Stroke = Brushes.DarkGray,
                    StrokeThickness = 1
				};
                PixelCanvas.Children.Add(gridLine);
            }
            for (int curCol = 0; curCol <= cols; curCol++)
            {
                Line gridLine = new Line
                {
                    X1 = pixelSize * curCol,
                    X2 = pixelSize * curCol,
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
            int rowPos = (int)(mousePos.X / pixelSize);
            int colPos = (int)(mousePos.Y / pixelSize);
            double pixelTopPos = colPos * pixelSize;
            double pixelLeftPos = rowPos * pixelSize;

            // paint if LMB down
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                if (Mouse.DirectlyOver.GetType() == typeof(Rectangle))
                {
                    Rectangle paintedPixel = (Rectangle)Mouse.DirectlyOver;
                    paintedPixel.Fill = currentColorBrush;
                    project.GetLayerAt(currentLayer).SetPixelAt(
                        rowPos, colPos, new Pixel(currentColorBrush.Color));
                }
                else
                {
                    Rectangle pixelToPaint = new Rectangle
                    {
                        Width = pixelSize,
                        Height = pixelSize,
                        Fill = new SolidColorBrush(Colors.Black)
                    };
                    Canvas.SetLeft(pixelToPaint, pixelLeftPos);
                    Canvas.SetTop(pixelToPaint, pixelTopPos);
                    project.GetLayerAt(currentLayer).SetPixelAt(
                        rowPos, colPos, new Pixel(currentColorBrush.Color));
                    PixelCanvas.Children.Add(pixelToPaint);
                }
            }

            else if (Mouse.RightButton == MouseButtonState.Pressed)
            {
                if (Mouse.DirectlyOver.GetType() == typeof(Rectangle))
                {
                    project.GetLayerAt(currentLayer).SetPixelAt(
                        rowPos, colPos, null);
                    PixelCanvas.Children.Remove((UIElement)Mouse.DirectlyOver);
                }
            }
        }

		private void PixelCanvas_Loaded(object sender, RoutedEventArgs e)
        {
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
            int rowPos = (int)(mousePos.X / pixelSize) + 1;
            int colPos = (int)(mousePos.Y / pixelSize) + 1;
            if (rowPos > rows) rowPos = rows;
            if (colPos > cols) colPos = cols;
            CursorPositionLabel.Content = rowPos + " : " + colPos;

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
                    EditorUtils.OpenSettingsMenu();
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

		private void ControlButtonClicked(object sender, RoutedEventArgs e)
		{
            EditorUtils.ControlButtonClicked(((Button)sender).Name);
		}
	}
}
