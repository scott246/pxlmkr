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
using System.Windows.Shapes;

namespace pxlmkr
{
	/// <summary>
	/// Interaction logic for Settings.xaml
	/// </summary>
	public partial class Settings : Window
	{
		public int pixelCountX;
		public int pixelCountY;
		public int pixelSize;

		public Settings()
		{
			InitializeComponent();
			
			PixelSizeTextBox.Text = Properties.Settings.Default.DefaultPixelSize.ToString();
			PixelsPerColumnTextBox.Text = Properties.Settings.Default.DefaultPixelCountHeight.ToString();
			PixelsPerRowTextBox.Text = Properties.Settings.Default.DefaultPixelCountWidth.ToString();
			ProjectHeightTextBox.Text = Properties.Settings.Default.DefaultProjectHeight.ToString();
			ProjectWidthTextBox.Text = Properties.Settings.Default.DefaultProjectWidth.ToString();

			pixelCountX = int.Parse(PixelsPerRowTextBox.Text);
			pixelCountY = int.Parse(PixelsPerColumnTextBox.Text);
			pixelSize = int.Parse(PixelSizeTextBox.Text);
		}

		private bool ValidDimensionValue(string text)
		{
			return text != "" && double.TryParse(text, out double d) && d > 0;
		}

		private void SaveSettingsChanges_Click(object sender, RoutedEventArgs e)
		{
			int newPixelSize = int.Parse(PixelSizeTextBox.Text);
			int newPixelsPerColumn = int.Parse(PixelsPerColumnTextBox.Text);
			int newPixelsPerRow = int.Parse(PixelsPerRowTextBox.Text);
			int newProjectHeight = int.Parse(ProjectHeightTextBox.Text);
			int newProjectWidth = int.Parse(ProjectWidthTextBox.Text);

			if (!ValidDimensionValue(PixelsPerRowTextBox.Text) || 
				!ValidDimensionValue(PixelsPerColumnTextBox.Text) ||
				!ValidDimensionValue(PixelSizeTextBox.Text) ||
				!ValidDimensionValue(ProjectWidthTextBox.Text) ||
				!ValidDimensionValue(ProjectHeightTextBox.Text))
			{
				MessageBox.Show("Invalid inputs for pixel or project dimensions", "Error", MessageBoxButton.OK);
				return;
			}
			if (newPixelsPerColumn < pixelCountY ||
				newPixelsPerRow < pixelCountX)
			{
				MessageBoxResult r = 
					MessageBox.Show("Reducing the pixel count may crop out part of the project. Are you sure you want to do this?", "Warning", MessageBoxButton.YesNo);
				if (r == MessageBoxResult.No || r == MessageBoxResult.None)
				{
					return;
				}
			}
			Properties.Settings.Default.DefaultPixelSize = newPixelSize;
			Properties.Settings.Default.DefaultPixelCountHeight = newPixelsPerColumn;
			Properties.Settings.Default.DefaultPixelCountWidth = newPixelsPerRow;
			Properties.Settings.Default.DefaultProjectHeight = newProjectHeight;
			Properties.Settings.Default.DefaultProjectWidth = newProjectWidth;
			Properties.Settings.Default.Save();
			pixelCountX = newPixelsPerRow;
			pixelCountY = newPixelsPerColumn;
			pixelSize = newPixelSize;
			Close();
		}

		private void CancelSettingsChanges_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void ValidateDimensionInputs(object sender, RoutedEventArgs e)
		{
			bool pixelsPerRowFilled = PixelsPerRowTextBox.Text != "";
			bool pixelsPerColumnFilled = PixelsPerColumnTextBox.Text != "";
			bool pixelSizeFilled = PixelSizeTextBox.Text != "";
			bool projectWidthFilled = ProjectWidthTextBox.Text != "";
			bool projectHeightFilled = ProjectHeightTextBox.Text != "";

			if (sender.Equals(PixelsPerColumnTextBox))
			{
				if (pixelSizeFilled && pixelsPerColumnFilled && ValidDimensionValue(PixelsPerColumnTextBox.Text))
				{
					double calculatedProjectHeight =
					   double.Parse(PixelsPerColumnTextBox.Text) * double.Parse(PixelSizeTextBox.Text);
					ProjectHeightTextBox.Text = 
						calculatedProjectHeight % 1 == 0 ? calculatedProjectHeight.ToString() : "";
				}
			}

			else if (sender.Equals(PixelsPerRowTextBox))
			{
				if (pixelSizeFilled && pixelsPerRowFilled && ValidDimensionValue(PixelsPerRowTextBox.Text))
				{
					double calculatedProjectWidth =
						double.Parse(PixelsPerRowTextBox.Text) * double.Parse(PixelSizeTextBox.Text);
					ProjectWidthTextBox.Text = 
						calculatedProjectWidth % 1 == 0 ? calculatedProjectWidth.ToString() : "";
				}
			}

			else if (sender.Equals(PixelSizeTextBox))
			{
				if (pixelsPerColumnFilled && pixelSizeFilled && ValidDimensionValue(PixelSizeTextBox.Text))
				{
					double calculatedProjectHeight =
					   double.Parse(PixelsPerColumnTextBox.Text) * double.Parse(PixelSizeTextBox.Text);
					ProjectHeightTextBox.Text = 
						calculatedProjectHeight % 1 == 0 ? calculatedProjectHeight.ToString() : "";
				}
				else if (projectHeightFilled && pixelSizeFilled && ValidDimensionValue(PixelSizeTextBox.Text))
				{
					double calculatedPixelsPerColumn =
						double.Parse(ProjectHeightTextBox.Text) * double.Parse(PixelSizeTextBox.Text);
					PixelsPerColumnTextBox.Text =
						calculatedPixelsPerColumn % 1 == 0 ? calculatedPixelsPerColumn.ToString() : "";
				}
				if (pixelsPerRowFilled && pixelSizeFilled && ValidDimensionValue(PixelSizeTextBox.Text))
				{
					double calculatedProjectWidth =
						double.Parse(PixelsPerRowTextBox.Text) * double.Parse(PixelSizeTextBox.Text);
					ProjectWidthTextBox.Text = 
						calculatedProjectWidth % 1 == 0 ? calculatedProjectWidth.ToString() : "";
				}
				else if (projectWidthFilled && pixelSizeFilled && ValidDimensionValue(PixelSizeTextBox.Text))
				{
					double calculatedPixelsPerRow =
						double.Parse(ProjectWidthTextBox.Text) * double.Parse(PixelSizeTextBox.Text);
					PixelsPerRowTextBox.Text =
						calculatedPixelsPerRow % 1 == 0 ? calculatedPixelsPerRow.ToString() : "";
				}
			}

			else if (sender.Equals(ProjectHeightTextBox))
			{
				if (pixelSizeFilled && projectHeightFilled && ValidDimensionValue(ProjectHeightTextBox.Text))
				{
					double calculatedPixelsPerColumn =
						double.Parse(ProjectHeightTextBox.Text) / double.Parse(PixelSizeTextBox.Text);
					PixelsPerColumnTextBox.Text =
						calculatedPixelsPerColumn % 1 == 0 ? calculatedPixelsPerColumn.ToString() : "";
				}
			}

			else if (sender.Equals(ProjectWidthTextBox))
			{
				if (pixelSizeFilled && projectWidthFilled && ValidDimensionValue(ProjectWidthTextBox.Text))
				{
					double calculatedPixelsPerRow =
					double.Parse(ProjectWidthTextBox.Text) / double.Parse(PixelSizeTextBox.Text);
					PixelsPerRowTextBox.Text =
						calculatedPixelsPerRow % 1 == 0 ? calculatedPixelsPerRow.ToString() : "";
				}			
			}
		}
	}
}
