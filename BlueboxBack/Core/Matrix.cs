using System;
using System.Collections.Generic;
using System.Text;

namespace BlueboxBack.Core
{
    class Matrix
    {
        private int width;
        private int height;
        private Element[,] matrixArray;
        public Matrix(int width, int height)
        {
            this.width = width;
            this.height = height;
            matrixArray = new Element[width, height];
        }
    }
}
