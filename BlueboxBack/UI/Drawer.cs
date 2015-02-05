using BlueboxBack.Core;
using BlueboxBack.Helpers;
using BlueboxBack.Properties;
using BlueboxBack.UI.Components;
using BlueboxBack.UI.Themes;
using BlueboxBack.Utilities;
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
        private static Brush FilledBrush = BasicTheme.FilledBrushDefault;
        private static Brush ClearedBrush = BasicTheme.ClearedBrush;
        private static Brush HighlightedFilledBrush = BasicTheme.HighlightedFilledBrush;
        private static Brush HighlightedClearedBrush = BasicTheme.HighlightedClearedBrush;
        private static Brush HeaderBackground = BasicTheme.HeaderBackground;
        private static Brush HeaderForeground = BasicTheme.HeaderForeground;
        private static Pen GridPen = BasicTheme.GridPen;
        private static Pen GridPenThick = BasicTheme.GridPenThich;
        private static Brush HeaderFontBrush = BasicTheme.HeaderBrush;
        private static Brush HeaderFontBrushHighlighted = BasicTheme.HeaderBrushHighlighted;
        private static Font HeaderFont = BasicTheme.HeaderFont;
        public static void Draw(Box pictureBox, DataMatrix dataMatrix, DataMatrix solutionMatrix)
        {
            int imageWidth = 0;
            int imageHeight = 0;

            switch (pictureBox.type)
            {
                case BoxTypes.Grid:
                    imageWidth = dataMatrix.Width * Constants.CELL_SIDE;
                    imageHeight = dataMatrix.Height * Constants.CELL_SIDE;
                    break;
                case BoxTypes.HeaderHorizontal:
                    imageWidth = dataMatrix.Width * Constants.CELL_SIDE;
                    imageHeight = Constants.HEADER_SIZING;
                    break;
                case BoxTypes.HeaderVertical:
                    imageWidth = Constants.HEADER_SIZING;
                    imageHeight = dataMatrix.Height * Constants.CELL_SIDE;
                    break;
            }

            Bitmap drawArea = new Bitmap(imageWidth, imageHeight);
            pictureBox.Image = drawArea;

            Graphics g = Graphics.FromImage(drawArea);

            switch (pictureBox.type)
            {
                case BoxTypes.Grid:
                    DrawGrid(g, dataMatrix);
                    break;
                case BoxTypes.HeaderHorizontal:
                    DrawHorizontalHeader(g, dataMatrix, solutionMatrix);
                    break;
                case BoxTypes.HeaderVertical:
                    DrawVerticalHeader(g, dataMatrix, solutionMatrix);
                    break;
            }

            pictureBox.Image = drawArea;
            g.Dispose();
        }
        public static void Draw(Box pictureBox, DataMatrix dataMatrix, DataMatrix solutionMatrix, ResultEvent.ResultType result)
        {
            switch (result)
            {
                case ResultEvent.ResultType.Correct:
                    FilledBrush = BasicTheme.FilledBrushCorrectResult;
                    break;
                case ResultEvent.ResultType.Incorrect:
                    FilledBrush = BasicTheme.FilledBrushIncorrectResult;
                    break;
                case ResultEvent.ResultType.Alternative:
                    FilledBrush = BasicTheme.FilledBrushAlternativeResult;
                    break;
                case ResultEvent.ResultType.Unpublished:
                    FilledBrush = BasicTheme.FilledBrushDefault;
                    break;
            }
            Draw(pictureBox, dataMatrix, solutionMatrix);
        }
        public static void Reset()
        {
            FilledBrush = BasicTheme.FilledBrushDefault;
        }
        private static void DrawVerticalHeader(Graphics g, DataMatrix dataMatrix, DataMatrix solutionMatrix)
        {
            g.FillRectangle(HeaderBackground, g.ClipBounds);

            for (short i = 0; i < solutionMatrix.Height; i++)
            {
                short j = Constants.HEADER_SIZING / 20;
                foreach (CellsBlock block in MatrixManager.GetLineHeaders(dataMatrix, solutionMatrix, i, null))
                {
                    PointF point = new PointF((j - 1) * 20, i * Constants.CELL_SIDE + 2);
                    j--;
                    DrawBlockCounter(g, block, point);
                }
                g.DrawString((i+1).ToString(), HeaderFont, Brushes.Blue, new PointF(3, i * Constants.CELL_SIDE + 2));
                g.DrawLine(GetGridPen(i), 0, i * Constants.CELL_SIDE, Constants.HEADER_SIZING, i * Constants.CELL_SIDE);
            }
        }
        private static void DrawHorizontalHeader(Graphics g, DataMatrix dataMatrix, DataMatrix solutionMatrix)
        {
            g.FillRectangle(HeaderBackground, g.ClipBounds);

            for (short i = 0; i < solutionMatrix.Width; i++)
            {
                short j = Constants.HEADER_SIZING/20;
                foreach (CellsBlock block in MatrixManager.GetLineHeaders(dataMatrix, solutionMatrix, null, i))
                {
                    PointF point = new PointF(i * Constants.CELL_SIDE, (j - 1) * 20);
                    j--;
                    DrawBlockCounter(g, block, point);
                }
                g.DrawString((i+1).ToString(), HeaderFont, Brushes.Blue, new PointF(i * Constants.CELL_SIDE, 3));
                g.DrawLine(GetGridPen(i), i * Constants.CELL_SIDE, 0, i * Constants.CELL_SIDE, Constants.HEADER_SIZING);
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
                        g.DrawLine(GetGridPen(j), 0, j * side, matrix.Width * side, j * side); //horizontal line
                    }
                }
                horizLinesDrawn = true;
                g.DrawLine(GetGridPen(i), i * side, 0, i * side, matrix.Height * side); //vertical line
            }
        }
        private static void DrawBlockCounter(Graphics g, CellsBlock block, PointF point)
        {
            Brush brush = null;
            Font font = null;
            GetHeaderStyle(block, out brush, out font);
            g.DrawString(String.Format("{0,2}", block.Length), font, brush, point);
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
        private static Pen GetGridPen(int i)
        {
            if(i % Constants.THICK_GRID_STEP == 0)
            {
                return GridPenThick;
            }
            else
            {
                return GridPen;
            }
        }
        private static void GetHeaderStyle(CellsBlock block, out Brush brush, out Font font)
        {
            if (block.IsOpened && Settings.Default.HighlightHeaders)
            {
                brush = BasicTheme.HeaderBrushHighlighted;
                font = BasicTheme.HeaderFontHighlighted;
            }
            else
            {
                brush = BasicTheme.HeaderBrush;
                font = BasicTheme.HeaderFont;
            }
        }
    }
}
