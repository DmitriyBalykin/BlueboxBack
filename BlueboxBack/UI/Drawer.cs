using BlueboxBack.Core;
using BlueboxBack.UI.Components;
using BlueboxBack.UI.Themes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BlueboxBack.UI
{
    class Drawer
    {
        private static Color UndefinedColor = BasicTheme.UndefinedColor;
        private static Color FilledColor = BasicTheme.FilledColor;
        private static Color ClearedColor = BasicTheme.ClearedColor;
        private static Color HighlightedFilledColor = BasicTheme.HighlightedFilledColor;
        private static Color HighlightedClearedColor = BasicTheme.HighlightedClearedColor;
        public static void Draw(Box pictureBox, DataMatrix matrix)
        {
            Bitmap drawArea = new Bitmap(pictureBox.Size.Width, pictureBox.Size.Height);
            pictureBox.Image = drawArea;

            Graphics g = Graphics.FromImage(drawArea);

            switch (pictureBox.type)
            {
                case BoxTypes.Grid:
                    DrawGrid(g);
                    break;
                case BoxTypes.HeaderHorizontal:
                    DrawHorizontalHeader(g);
                    break;
                case BoxTypes.HeaderVertical:
                    DrawVerticalHeader(g);
                    break;
            }

            pictureBox.Image = drawArea;
            g.Dispose();
        }

        private static void DrawVerticalHeader(Graphics g)
        {
            throw new NotImplementedException();
        }

        private static void DrawHorizontalHeader(Graphics g)
        {
            throw new NotImplementedException();
        }

        private static void DrawGrid(Graphics g)
        {
            throw new NotImplementedException();
        }
    }
}
