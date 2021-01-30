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
		private Color color = Colors.Transparent;

		public Pixel(Color color)
		{
			this.color = color;
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
