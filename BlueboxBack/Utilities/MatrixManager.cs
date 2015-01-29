using BlueboxBack.Core;
using BlueboxBack.Core.Log;
using BlueboxBack.UI.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueboxBack.Utilities
{
    class MatrixManager
    {
        DataMatrix dataMatrix;
        DataMatrix solutionMatrix;

        public event EventHandler<ResultEventArgs> ResultPublished;
        public event EventHandler HintUsed;
        public MatrixManager()
        {
            GenerateNewSolution();
        }
        internal DataMatrix CalculateMatrix(BoxTypes type, ActionTypes actionTypes, int x, int y)
        {
            HeadersDrawn = false;
            switch(type)
            {
                case BoxTypes.Grid:
                    dataMatrix = CalculateGridClicked(dataMatrix, actionTypes, x, y);
                    break;
                case BoxTypes.HeaderHorizontal:
                    dataMatrix = CalculateTopHeaderClicked(dataMatrix, actionTypes, x, y);
                    break;
                case BoxTypes.HeaderVertical:
                    dataMatrix = CalculateLeftHeaderClicked(dataMatrix, actionTypes, x, y);
                    break;
            }

            if(IsMatrixOpened(dataMatrix) && (ResultPublished != null))
            {
                ResultEventArgs resArgs = new ResultEventArgs();

                resArgs.Result = (dataMatrix == solutionMatrix) ? ResultEventArgs.ResultTypes.Correct : ResultEventArgs.ResultTypes.Incorrect;
                ResultPublished(this, resArgs);
            }

            return dataMatrix;
        }

        internal DataMatrix GetDataMatrix()
        {
            return dataMatrix;
        }
        internal void GenerateNewSolution()
        {
            dataMatrix = new DataMatrix(Constants.MATRIX_WIDTH, Constants.MATRIX_HEIGHT);
            solutionMatrix = RandomMatrixGenerator.GetRandomMatrix(Constants.MATRIX_WIDTH, Constants.MATRIX_HEIGHT);

            CountMatrixElements(solutionMatrix);
        }

        private void CountMatrixElements(DataMatrix solutionMatrix)
        {
            for (short i = 0; i < solutionMatrix.Height; i++)
            {
                List<short> list = solutionMatrix.GetCountersList(i, null);
                if (list.Count > solutionMatrix.MaxElementsWidth)
                {
                    solutionMatrix.MaxElementsWidth = list.Count;
                }
            }
            for (short i = 0; i < solutionMatrix.Width; i++)
            {
                List<short> list = solutionMatrix.GetCountersList(null, i);
                if (list.Count > solutionMatrix.MaxElementsHeight)
                {
                    solutionMatrix.MaxElementsHeight = list.Count;
                }
            }
        }

        private DataMatrix CalculateLeftHeaderClicked(DataMatrix matrix, ActionTypes actionTypes, int x, int y)
        {
            if (x < 20)
            {
                matrix.HighlightedRow = y / Constants.CELL_SIDE;
                ShowLine(matrix);
            }
            if (HintUsed != null)
            {
                HintUsed(this, EventArgs.Empty);
            }
            return matrix;
        }

        private DataMatrix CalculateTopHeaderClicked(DataMatrix matrix, ActionTypes actionTypes, int x, int y)
        {
            if (y < 20)
            {
                matrix.HighlightedCol = x / Constants.CELL_SIDE;
                ShowLine(matrix);
            }
            if (HintUsed != null)
            {
                HintUsed(this, EventArgs.Empty);
            }
            return matrix;
        }

        private DataMatrix CalculateGridClicked(DataMatrix matrix, ActionTypes actionType, int x, int y)
        {
            int cellX = x / Constants.CELL_SIDE;
            int cellY = y / Constants.CELL_SIDE;

            Element.ElementType currentType = matrix[cellX, cellY].Type;
            Element.ElementType newType = ElementStateMatrix.getElementWithState(currentType, actionType);
            matrix[cellX, cellY] = new Element(ElementStateMatrix.getElementWithState(matrix[cellX, cellY].Type, actionType));

            matrix.HighlightedRow = null;
            matrix.HighlightedCol = null;

            return matrix;
        }
        private void ShowLine(DataMatrix matrix)
        {
            Logger.Info("Show line");
            if(matrix.HighlightedRow != null)
            {
                int row = matrix.HighlightedRow ?? -1;
                for (int i = 0; i < matrix.Width; i++)
                {
                    matrix[i, row] = solutionMatrix[i, row];
                    Logger.InfoLine(matrix[i, row] + " ");
                }
            }
            if (matrix.HighlightedCol != null)
            {
                int col = matrix.HighlightedCol ?? -1;
                for (int i = 0; i < matrix.Width; i++)
                {
                    matrix[col, i] = solutionMatrix[col, i];
                    Logger.InfoLine(matrix[col, i] + " ");
                }
            }
        }

        private bool IsMatrixOpened(DataMatrix matrix)
        {
            return !matrix.Contains(Element.ElementType.Undefined);
        }

        internal DataMatrix GetSolutionMatrix()
        {
            return solutionMatrix;
        }

        public bool HeadersDrawn { get; set; }

        public short[][] GetTopHeaderData()
        {
            short[][] arrLines = new short[solutionMatrix.Height][];
            for (short i = 0; i < solutionMatrix.Height; i++)
            {
                arrLines[i] = new short[solutionMatrix.MaxElementsWidth];
                short[] source = solutionMatrix.GetCountersListSorted(i, null).ToArray();
                Array.Copy(
                    source,
                    0,
                    arrLines[i],
                    solutionMatrix.MaxElementsWidth - source.Length,
                    source.Length
                    );
            }
            return arrLines;
        }
        public short[][] GetLeftHeaderData()
        {
            short[][] arrLines = new short[solutionMatrix.Width][];
            for (short i = 0; i < solutionMatrix.Width; i++)
            {
                arrLines[i] = new short[solutionMatrix.MaxElementsHeight];
                short[] source = solutionMatrix.GetCountersListSorted(null, i).ToArray();
                Array.Copy(
                    source,
                    0,
                    arrLines[i],
                    solutionMatrix.MaxElementsHeight - source.Length,
                    source.Length
                    );
            }
            return arrLines;
        }
    }
}
