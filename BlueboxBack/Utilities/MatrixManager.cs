using BlueboxBack.Core;
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

        public event EventHandler ResultIncorrect;
        public event EventHandler HintUsed;
        public MatrixManager()
        {
            dataMatrix = new DataMatrix(Constants.MATRIX_WIDTH, Constants.MATRIX_HEIGHT);
            solutionMatrix = RandomMatrixGenerator.GetRandomMatrix(Constants.MATRIX_WIDTH, Constants.MATRIX_HEIGHT);
        }
        internal DataMatrix CalculateMatrix(BoxTypes type, ActionTypes actionTypes, int x, int y)
        {
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

            if(IsMatrixOpened(dataMatrix) && (dataMatrix != solutionMatrix))
            {
                ResultIncorrect(this, EventArgs.Empty);
            }

            return dataMatrix;
        }

        private DataMatrix CalculateLeftHeaderClicked(DataMatrix matrix, ActionTypes actionTypes, int x, int y)
        {
            if (x < 20)
            {
                matrix.HighlightedRow = y / Constants.CELL_SIDE;
                ShowLine(matrix);
            }
            HintUsed(this, EventArgs.Empty);
            
            return matrix;
        }

        private DataMatrix CalculateTopHeaderClicked(DataMatrix matrix, ActionTypes actionTypes, int x, int y)
        {
            if (y < 20)
            {
                matrix.HighlightedCol = x / Constants.CELL_SIDE;
                ShowLine(matrix);
            }
            HintUsed(this, EventArgs.Empty);
            return matrix;
        }

        private DataMatrix CalculateGridClicked(DataMatrix matrix, ActionTypes actionType, int x, int y)
        {
            int cellX = x / Constants.CELL_SIDE;
            int cellY = y / Constants.CELL_SIDE;

            matrix[cellX, cellY] = new Element(ElementStateMatrix.getElementWithState(matrix[cellX, cellY].Type, actionType));

            return matrix;
        }
        private void ShowLine(DataMatrix matrix)
        {
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
    }
}
