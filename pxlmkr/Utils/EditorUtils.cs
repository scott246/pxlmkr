using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

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
                    return "Width and height of a project pixel";
                case "ProjectSizeLabel":
                    return "(Number of squares per row) x (Number of squares per column)";
                case "ProjectSizeRenderedLabel":
                    return "(Width of rendered project) x (Height of rendered project)";
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
                case "SettingsToolButton":
                    return "Project settings";
                case "BrushSizeSlider":
                    return "Brush size in project pixels";
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
                case "SettingsToolButton":
                    OpenSettingsMenu();
                    break;
                default:
                    break;
            }
        }

        public static void OpenSettingsMenu()
		{
            Settings s = new Settings();
            s.ShowDialog();
            UpdateCanvasSize(s.pixelCountX, s.pixelCountY, s.pixelSize);
		}

        public static void UpdateCanvasSize(int newPixelCountX, int newPixelCountY, int newPixelSize)
        {
            Editor instance = Editor.editorInstance;
            Canvas editorPixelCanvas = instance.PixelCanvas;
            double originalProjectWidth = instance.canvasWidth;
            double originalProjectHeight = instance.canvasHeight;
            double newProjectWidth = newPixelCountX * newPixelSize;
            double newProjectHeight = newPixelCountY * newPixelSize;
            int originalPixelCountX = instance.cols;
            int originalPixelCountY = instance.rows;
            int originalPixelSize = instance.pixelSize;

			editorPixelCanvas.Width = newProjectWidth;
            editorPixelCanvas.Height = newProjectHeight;

            foreach (UIElement element in editorPixelCanvas.Children)
            {
                if (element.GetType() == typeof(Line))
                {

                }
                else if (element.GetType() == typeof(Rectangle))
				{

				}
            }
        }
    }
}
