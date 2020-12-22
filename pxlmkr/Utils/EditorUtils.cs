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
                    return "Project pixel size (in screen pixels), click to change";
                case "ProjectSizeLabel":
                    return "Project dimensions, click to change";
                case "PaintToolButton":
                    return "Paint tool";
                case "SelectToolButton":
                    return "Select tool";
                case "EraserToolButton":
                    return "Eraser tool";
                case "FillToolButton":
                    return "Fill tool";
                case "EyedropperToolButton":
                    return "Eyedropper tool";
                case "LineToolButton":
                    return "Line tool";
                case "ShapeToolButton":
                    return "Shape tool";
                case "TextToolButton":
                    return "Text tool";
                case "CropToolButton":
                    return "Crop tool";
                case "BrushSizeSlider":
                    return "Brush size";
                default:
                    return "";
            }
		}
    }
}
