using BlueboxBack.Core;
using BlueboxBack.Helpers;
using BlueboxBack.Properties;
using BlueboxBack.UI.Components;
using BlueboxBack.UI.Themes;
using BlueboxBack.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Managed.Graphics.Direct2D;
using Managed.Graphics.DirectWrite;
using Managed.Graphics.Imaging;

namespace BlueboxBack.UI
{
    class DrawerD2D
    {
        private Direct2DFactory factory;
        private WindowRenderTarget rt;

        private static Brush UndefinedBrush = BasicTheme.UndefinedBrush;
        private static Brush FilledBrush = BasicTheme.FilledBrushDefault;
        private static Brush ClearedBrush = BasicTheme.ClearedBrush;
        private static Brush HighlightedFilledBrush = BasicTheme.HighlightedFilledBrush;
        private static Brush HighlightedClearedBrush = BasicTheme.HighlightedClearedBrush;
        private static Brush HeaderBackground = BasicTheme.HeaderBackground;
        private static Brush HeaderForeground = BasicTheme.HeaderForeground;
        private static Brush HeaderIndexForeground = BasicTheme.HeaderIndexForeground;
        private static Pen GridPen = BasicTheme.GridPen;
        private static Pen GridPenThick = BasicTheme.GridPenThich;
        private static Brush HeaderFontBrush = BasicTheme.HeaderBrush;
        private static Brush HeaderFontBrushHighlighted = BasicTheme.HeaderBrushHighlighted;
        private static Font HeaderFont = BasicTheme.HeaderFont;
        public void Draw(Box pictureBox, DataMatrix dataMatrix, DataMatrix solutionMatrix)
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
        }
        public void Draw(Box pictureBox, DataMatrix dataMatrix, DataMatrix solutionMatrix, ResultEvent.ResultType result)
        {
            switch (result)
            {
                case ResultEvent.ResultType.Correct:
                    FilledBrush = BasicTheme.FilledBrushCorrectResult;
                    break;
                case ResultEvent.ResultType.Incorrect:
                    FilledBrush = BasicTheme.FilledBrushIncorrectResult;
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

        private void DrawVerticalHeader(DataMatrix dataMatrix, DataMatrix solutionMatrix)
        {

            for (short i = 0; i < solutionMatrix.Height; i++)
            {
                short j = Constants.HEADER_SIZING / 20;
                foreach (CellsBlock block in solutionMatrix.GetCountersListReversed(i, null))
                {
                    PointF point = new PointF((j - 1) * 20, i * Constants.CELL_SIDE + 2);
                    j--;
                    Brush brush = null;
                    Font font = null;
                    GetHeaderStyle(i, null, block, dataMatrix, out brush, out font);
                    DrawString(String.Format("{0,2}", block.Length), font, brush, point);
                }
                DrawString((i + 1).ToString(), HeaderFont, HeaderIndexForeground, new PointF(3, i * Constants.CELL_SIDE + 2));
                DrawLine(GetGridPen(i), 0, i * Constants.CELL_SIDE, Constants.HEADER_SIZING, i * Constants.CELL_SIDE);
            }
        }

        private void DrawHorizontalHeader(DataMatrix dataMatrix, DataMatrix solutionMatrix)
        {
            for (short i = 0; i < solutionMatrix.Width; i++)
            {
                short j = Constants.HEADER_SIZING / 20;
                foreach (CellsBlock block in solutionMatrix.GetCountersListReversed(null, i))
                {
                    PointF point = new PointF(i * Constants.CELL_SIDE, (j - 1) * 20);
                    j--;
                    Brush brush = null;
                    Font font = null;
                    GetHeaderStyle(null, i, block, dataMatrix, out brush, out font);
                    DrawString(String.Format("{0,2}", block.Length), font, brush, point);
                }
                DrawString((i + 1).ToString(), HeaderFont, HeaderIndexForeground, new PointF(i * Constants.CELL_SIDE, 3));
                DrawLine(GetGridPen(i), i * Constants.CELL_SIDE, 0, i * Constants.CELL_SIDE, Constants.HEADER_SIZING);
            }
        }

        private void DrawGrid(DataMatrix matrix)
        {
            int side = Constants.CELL_SIDE;
            bool horizLinesDrawn = false;

            //draw cells
            for (int i = 0; i < matrix.Width; i++)
            {
                for (int j = 0; j < matrix.Height; j++)
                {
                    DrawRectangle(new PointF(i * side, j * side), new PointF((i + 1) * side, (j + 1) * side), GetCellBrush(matrix[i, j]));
                }
            }
            //draw grid
            for (int i = 0; i <= matrix.Width; i++)
            {
                for (int j = 0; j <= matrix.Height; j++)
                {
                    if (!horizLinesDrawn)
                    {
                        DrawLine(GetGridPen(j), new PointF(0, j * side), new PointF(matrix.Width * side, j * side)); //horizontal line
                    }
                }
                horizLinesDrawn = true;
                DrawLine(GetGridPen(i), new PointF(i * side, 0), new PointF(i * side, matrix.Height * side)); //vertical line
            }
        }

        private static Brush GetCellBrush(Element element)
        {
            switch (element.Type)
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
            if (i % Constants.THICK_GRID_STEP == 0)
            {
                return GridPenThick;
            }
            else
            {
                return GridPen;
            }
        }
        private static void GetHeaderStyle(short? i, short? j, CellsBlock block, DataMatrix matrixToCompare, out Brush brush, out Font font)
        {
            if (MatrixManager.IsBlockOpened(i, j, block, matrixToCompare) && Settings.Default.HighlightHeaders)
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

        private void DrawLine(PointF point1, PointF point2, Brush brush)
        { }
        private void DrawRectangle(PointF point1, PointF point2, Brush brush)
        { }
        private void DrawString(string str, Font font, Brush brush, PointF point)
        { }
    }
}
