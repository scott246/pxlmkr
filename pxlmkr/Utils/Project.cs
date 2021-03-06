﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pxlmkr.Utils
{
	class Project
	{
		private List<Layer> layers = new List<Layer>();

		public void AddLayer(int xLength, int yLength)
		{
			layers.Add(new Layer(xLength, yLength));
		}

		public void RemoveLayer(int layerNumber)
		{
			layers.RemoveAt(layerNumber);
		}

		public Layer GetLayerAt(int layerNumber)
		{
			return layers[layerNumber];
		}

		public int GetLayerCount()
		{
			return layers.Count;
		}
	}
}
