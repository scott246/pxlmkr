using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pxlmkr.Utils
{
	class EditorUtils
	{
		public static string GetControlDescription(string name)
		{
			switch (name)
			{
                case "CursorPositionLabel":
                    return "Cursor position (x : y)";
                case "PixelSizeLabel":
                    return "Project pixel size (in screen pixels)";
                case "ProjectSizeLabel":
                    return "Project dimensions";
                case "PaintToolButton":
                    return "Paint tool";
                case "SelectToolButton":
                    return "Select tool";
                case "EraserToolButton":
                    return "Eraser tool";
                case "FillToolButton":
                    return "Fill tool";
                case "ShapeToolButton":
                    return "Shape tools";
                case "TransformToolButton":
                    return "Transforming tools";
                case "ShowHideLayersToolButton":
                    return "Show/hide layer panel";
                case "ShowHideFramesToolButton":
                    return "Show/hide frames panel";
                case "PreferencesToolButton":
                    return "Project preferences";
                case "BrushSizeSlider":
                    return "Brush size";
                default:
                    return "";
            }
		}
    }
}
