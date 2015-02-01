using System;
using System.Collections.Generic;
using System.Text;

namespace BlueboxBack.Core
{
    class Settings
    {
        private static int matrixSize = Constants.MATRIX_SIZE_MASTER;
        public static int MatrixSize { get { return matrixSize; } set { matrixSize = value; } }
    }
}
