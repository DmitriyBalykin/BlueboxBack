using BlueboxBack.Core;
using BlueboxBack.Helpers;
using BlueboxBack.Properties;
using BlueboxBack.UI.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BlueboxBack.Utilities
{
    class MatrixManager
    {
        DataMatrix dataMatrix;
        DataMatrix solutionMatrix;

        public event EventHandler ResultPublished;
        public event EventHandler HintUsed;

        private int hintsLeft = Constants.HINTS_NUMBER;
        public MatrixManager()
        {
            GenerateNewSolution();

            HintUsed += MatrixManager_HintUsed;
        }

        void MatrixManager_HintUsed(object sender, EventArgs e)
        {
            if (hintsLeft > 0 && Settings.Default.ShowLines)
            {
                hintsLeft--;
            }
        }
        internal DataMatrix CalculateMatrix(BoxTypes type, ActionTypes actionTypes, int x, int y)
        {
            switch(type)
            {
                case BoxTypes.Grid:
                    dataMatrix.HighlightedCol = null;
                    dataMatrix.HighlightedRow = null;
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
                if (dataMatrix == solutionMatrix)
                {
                    ResultPublished(this, new DataUpdatedEventArgs(dataMatrix, solutionMatrix, ResultEvent.ResultType.Correct));
                }
                else
                {
                    ResultPublished(this, new DataUpdatedEventArgs(dataMatrix, solutionMatrix, ResultEvent.ResultType.Incorrect));
                }
            }

            return dataMatrix;
        }

        public static bool IsBlockOpened(short? i, short? j, CellsBlock block, DataMatrix matrixToCompare)
        {
            List<CellsBlock> referenceList = matrixToCompare.GetCountersListReversed(i, j);
            foreach (CellsBlock refBlock in referenceList)
            {
                if (refBlock.StartPosition == block.StartPosition && refBlock.Length == block.Length)
                {
                    return true;
                }
            }
            return false;
        }

        internal DataMatrix GetDataMatrix()
        {
            return dataMatrix;
        }
        internal void GenerateNewSolution()
        {
            hintsLeft = Constants.HINTS_NUMBER;
            dataMatrix = new DataMatrix(Settings.Default.MatrixSize, Settings.Default.MatrixSize);
            solutionMatrix = RandomMatrixGenerator.GetRandomMatrix(Settings.Default.MatrixSize, Settings.Default.MatrixSize);
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

            return matrix;
        }
        private void ShowLine(DataMatrix matrix)
        {
            if(hintsLeft <= 0 || !Settings.Default.ShowLines)
            {
                MessageBox.Show("Извините, подсказок больше нет.");
                return;
            }
            if(matrix.HighlightedRow != null)
            {
                int row = matrix.HighlightedRow ?? -1;
                for (int i = 0; i < matrix.Width; i++)
                {
                    matrix[i, row] = solutionMatrix[i, row];
                }
            }
            if (matrix.HighlightedCol != null)
            {
                int col = matrix.HighlightedCol ?? -1;
                for (int i = 0; i < matrix.Width; i++)
                {
                    matrix[col, i] = solutionMatrix[col, i];
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
    }
}
