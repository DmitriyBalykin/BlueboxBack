using System;
using System.Collections.Generic;
using System.Text;

namespace BlueboxBack.Core
{
    class DataMatrix
    {
        private int width;
        private int height;
        private Element[,] matrixArray;
        public DataMatrix(int width, int height)
        {
            this.width = width;
            this.height = height;
            matrixArray = new Element[width, height];
        }

        public Element this[int i, int j]
        {
            get
            {
                return matrixArray[i, j];
            }
            set
            {
                matrixArray[i, j] = value;
            }
        }
    }
}
