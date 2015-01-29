﻿using BlueboxBack.Core;
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
        private static Brush UndefinedBrush = BasicTheme.UndefinedBrush;
        private static Brush FilledBrush = BasicTheme.FilledBrush;
        private static Brush ClearedBrush = BasicTheme.ClearedBrush;
        private static Brush HighlightedFilledBrush = BasicTheme.HighlightedFilledBrush;
        private static Brush HighlightedClearedBrush = BasicTheme.HighlightedClearedBrush;
        private static Brush HeaderBackground = BasicTheme.HeaderBackground;
        private static Brush HeaderForeground = BasicTheme.HeaderForeground;
        private static Pen GridPen = BasicTheme.GridPen;

        private static Font HeaderFont = SystemFonts.MenuFont;
        public static void Draw(Box pictureBox, DataMatrix dataMatrix, DataMatrix solutionMatrix)
        {
            Bitmap drawArea = new Bitmap(pictureBox.Size.Width, pictureBox.Size.Height);
            pictureBox.Image = drawArea;

            Graphics g = Graphics.FromImage(drawArea);

            switch (pictureBox.type)
            {
                case BoxTypes.Grid:
                    DrawGrid(g, dataMatrix);
                    break;
                case BoxTypes.HeaderHorizontal:
                    DrawHorizontalHeader(g, solutionMatrix);
                    break;
                case BoxTypes.HeaderVertical:
                    DrawVerticalHeader(g, solutionMatrix);
                    break;
            }

            pictureBox.Image = drawArea;
            g.Dispose();
        }

        private static void DrawVerticalHeader(Graphics g, DataMatrix matrix)
        {
            g.FillRectangle(HeaderBackground, g.ClipBounds);

            for (short i = 0; i < matrix.Height; i++)
            {
                short j = Constants.HEADER_SIZING / 20;
                foreach (short s in matrix.GetCountersListSorted(i, null))
                {
                    PointF point = new PointF(j * 20, i * Constants.CELL_SIDE);
                    j--;
                    g.DrawString(String.Format("{0,2}", s), HeaderFont, Brushes.Black, point);
                }
            }
        }

        private static void DrawHorizontalHeader(Graphics g, DataMatrix matrix)
        {
            g.FillRectangle(HeaderBackground, g.ClipBounds);

            for (short i = 0; i < matrix.Width; i++)
            {
                short j = Constants.HEADER_SIZING/20;
                foreach(short s in matrix.GetCountersListSorted(null, i))
                {
                    PointF point = new PointF(i * Constants.CELL_SIDE, j * 20);
                    j--;
                    g.DrawString(String.Format("{0,2}  ", s), HeaderFont, Brushes.Black, point);
                }
            }
        }

        private static void DrawGrid(Graphics g, DataMatrix matrix)
        {
            int side = Constants.CELL_SIDE;
            bool horizLinesDrawn = false;

            //draw cells
            for(int i = 0; i < matrix.Width; i++)
            {
                for(int j = 0; j < matrix.Height; j++)
                {
                    g.FillRectangle(GetCellBrush(matrix[i, j]), i * side, j * side, (i + 1) * side, (j + 1) * side);
                }
            }
            //draw grid
            for (int i = 0; i <= matrix.Width; i++)
            {
                for (int j = 0; j <= matrix.Height; j++)
                {
                    if (!horizLinesDrawn)
                    {
                        g.DrawLine(GridPen, 0, j * side, matrix.Width * side, j * side); //horizontal line
                    }
                }
                horizLinesDrawn = true;
                g.DrawLine(GridPen, i * side, 0, i * side, matrix.Height * side); //vertical line
            }
        }

        private static Brush GetCellBrush(Element element)
        {
            switch(element.Type)
            {
                case Element.ElementType.Cleared:
                    return element.Highlighted ? HighlightedClearedBrush : ClearedBrush;

                case Element.ElementType.Filled:
                    return element.Highlighted ? HighlightedFilledBrush : FilledBrush;

                case Element.ElementType.Undefined:
                    return UndefinedBrush;

                default:
                    return Brushes.Red;
            }
        }
    }
}
