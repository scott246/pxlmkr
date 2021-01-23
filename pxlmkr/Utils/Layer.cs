using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pxlmkr.Utils
{
	class Layer
	{
		private Pixel[,] pixelGrid;
		private bool visible;

		public Layer(int xLength, int yLength)
		{
			visible = true;
			pixelGrid = new Pixel[xLength, yLength];
		}

		public Pixel GetPixelAt(int x, int y)
		{
			return pixelGrid[x, y];
		}

		public void SetPixelAt(int x, int y, Pixel pixel)
		{
			pixelGrid[x, y] = pixel;
		}

		public bool IsVisible()
		{
			return visible;
		}

		public void SetVisible(bool visibility)
		{
			visible = visibility;
		}
	}
}
