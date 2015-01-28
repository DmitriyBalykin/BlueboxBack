using System.Collections;
using System.Collections.Generic;

namespace BlueboxBack.Core
{
    class DataMatrix : IEnumerable
    {
        public int Width;
        public int Height;

        private int? higlightedRow;
        public int? HighlightedRow
        {
            get
            {
                return higlightedRow;
            }
            set
            {
                higlightedCol = null;
                higlightedRow = value;
            }
        }
        private int? higlightedCol;
        public int? HighlightedCol
        {
            get
            {
                return higlightedCol;
            }
            set
            {
                higlightedRow = null;
                higlightedCol = value;
            }
        }
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
                return new Element(matrixArray[i, j], (i == higlightedCol) || (j == higlightedRow));
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

        public bool Contains(Element.ElementType type)
        {
            foreach (Element el in matrixArray)
            {
                if (el.Type == type)
                {
                    return false;
                }
            }
            return true;
        }

        public List<string> GetCountersList(short? nrow, short? ncol)
        {
            List<string> list = new List<string>();
            short currentBlock = 0;
            short limit = 0;
            short row = 0, col = 0;
            if(ncol == null)
            {
                row = nrow ?? 0;
            }
            else if(nrow == null)
            {
                col = ncol ?? 0;
            }
            for (int i = 0; i < limit; i++ )
            {
                Element el;
                if (ncol == null)
                {
                    el = matrixArray[i, row];
                }
                else
                {
                    el = matrixArray[col, i];
                }
                if (el.Type == Element.ElementType.Filled)
                {
                    currentBlock++;
                }
                else if(currentBlock > 0)
                {
                    list.Add(currentBlock.ToString());
                    currentBlock = 0;
                }
            }
            return list;
        }
        public List<string> GetCountersListSorted(short? nrow, short? ncol)
        {
            List<string> list = GetCountersList(nrow, ncol);
            list.Sort();
            return list;
        }
    }
}
