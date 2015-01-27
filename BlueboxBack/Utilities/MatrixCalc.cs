using BlueboxBack.Core;
using BlueboxBack.UI.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueboxBack.Utilities
{
    class MatrixCalc
    {
        DataMatrix dataMatrix;
        DataMatrix solutionMatrix;

        public event EventHandler ResultIncorrect;
        public MatrixCalc()
        {
            dataMatrix = new DataMatrix(Constants.MATRIX_WIDTH, Constants.MATRIX_HEIGHT);
            solutionMatrix = RandomMatrixGenerator.GetRandomMatrix(Constants.MATRIX_WIDTH, Constants.MATRIX_HEIGHT);
        }
        internal DataMatrix CalculateMatrix(BoxTypes type, ActionTypes actionTypes, int x, int y)
        {
            if(dataMatrix == null)
            {
                throw new NullReferenceException();
            }

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
                ShowRow(matrix, y / Constants.CELL_SIDE);
            }
            return matrix;
        }

        private DataMatrix CalculateTopHeaderClicked(DataMatrix matrix, ActionTypes actionTypes, int x, int y)
        {
            if (y < 20)
            {
                ShowColumn(matrix, x / Constants.CELL_SIDE);
            }
            return matrix;
        }

        private void ShowRow(DataMatrix matrix, int row)
        {
            for (int i = 0; i < matrix.Width; i++ )
            {
                matrix[i, row] = solutionMatrix[i, row];
            }
        }

        private void ShowColumn(DataMatrix matrix, int column)
        {
            for (int i = 0; i < matrix.Height; i++)
            {
                matrix[column, i] = solutionMatrix[column, i];
            }
        }

        private DataMatrix CalculateGridClicked(DataMatrix matrix, ActionTypes actionType, int x, int y)
        {
            int cellX = x / Constants.CELL_SIDE;
            int cellY = y / Constants.CELL_SIDE;

            Element element = ElementStateMatrix.getElement(matrix[cellX, cellY], actionType);

            matrix[cellX, cellY] = element;

            return matrix;
        }
        private bool IsMatrixOpened(DataMatrix matrix)
        {
            return !matrix.Contains(Element.Undefined);
        }
    }
}
