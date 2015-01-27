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
            return dataMatrix;
        }

        private DataMatrix CalculateLeftHeaderClicked(DataMatrix matrix, ActionTypes actionTypes, int x, int y)
        {
            if (x < 20)
            {
                int index = y / Constants.CELL_SIDE;
            }
            return matrix;
        }

        private DataMatrix CalculateTopHeaderClicked(DataMatrix matrix, ActionTypes actionTypes, int x, int y)
        {
            throw new NotImplementedException();
        }

        private DataMatrix CalculateGridClicked(DataMatrix matrix, ActionTypes actionType, int x, int y)
        {
            int cellX = x / Constants.CELL_SIDE;
            int cellY = y / Constants.CELL_SIDE;

            Element element = ElementStateMatrix.getElement(matrix[cellX, cellY], actionType);

            matrix[cellX, cellY] = element;

            return matrix;
        }
    }
}
