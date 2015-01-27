using System;
using System.Collections;
using System.Text;

namespace BlueboxBack.Core
{
    class DataMatrix : IEnumerable
    {
        public int Width;
        public int Height;
        private Element[,] matrixArray;
        public DataMatrix(int width, int height)
        {
            this.Width = width;
            this.Height = height;
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

        public static bool operator ==(DataMatrix m1, DataMatrix m2)
        {
            return m1.matrixArray == m2.matrixArray;
        }

        public static bool operator !=(DataMatrix m1, DataMatrix m2)
        {
            return m1.matrixArray != m2.matrixArray;
        }
        public IEnumerator GetEnumerator()
        { 
            //linear enumerator
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    yield return matrixArray[i, j];
                }
            }
        }

        public bool Contains(Element element)
        {
            foreach (Element el in matrixArray)
            {
                if (el == element)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
