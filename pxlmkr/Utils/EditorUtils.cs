using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pxlmkr.Dialogs;

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
                    return "Project settings";
                case "BrushSizeSlider":
                    return "Brush size";
                default:
                    return "";
            }
		}

        public static void ControlButtonClicked(string name)
        {
            switch (name)
            {
                case "PaintToolButton":
                    break;
                case "SelectToolButton":
                    break;
                case "EraserToolButton":
                    break;
                case "FillToolButton":
                    break;
                case "ShapeToolButton":
                    break;
                case "TransformToolButton":
                    break;
                case "ShowHideLayersToolButton":
                    break;
                case "ShowHideFramesToolButton":
                    break;
                case "PreferencesToolButton":
                    new Settings().ShowDialog();
                    break;
                default:
                    break;
            }
        }
    }
}
