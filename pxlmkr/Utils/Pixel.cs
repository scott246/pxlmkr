using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace pxlmkr.Utils
{
	class Pixel
	{
		private int x;
		private int y;
		private Color color = Colors.Transparent;

		public int GetX()
		{
			return x;
		}

		public void SetX(int x)
		{
			this.x = x;
		}

		public int GetY()
		{
			return y;
		}

		public void SetY(int y)
		{
			this.y = y;
		}

		public Color GetColor()
		{
			return color;
		}

		public void SetColor(Color color)
		{
			this.color = color;
		}
	}
}
