using System;
using System.Collections;
using System.Collections.Generic;

namespace BlueboxBack.Core
{
    class DataMatrix : IEnumerable
    {
        public short Width;
        public short Height;

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
        public DataMatrix(short width, short height)
        {
            this.Width = width;
            this.Height = height;
            matrixArray = new Element[width, height];

            InitializeMatrix();
        }
        public DataMatrix(int width, int height)
        {
            this.Width = (short)width;
            this.Height = (short)height;
            matrixArray = new Element[width, height];

            InitializeMatrix();
        }
        private void InitializeMatrix()
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    matrixArray[i, j] = new Element(Element.ElementType.Undefined);
                }
            }
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
            for (int i = 0; i < m1.Width; i++ )
            {
                for (int j = 0; j < m1.Height;j++)
                {
                    if(m1[i, j] != m2[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
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
                    return true;
                }
            }
            return false;
        }

        public List<short> GetCountersList(short? nrow, short? ncol)
        {
            List<short> list = new List<short>();
            short currentBlock = 0;
            short limit = 0;
            short row = 0, col = 0;
            if(ncol == null)
            {
                row = nrow ?? 0;
                limit = Height;
            }
            else if(nrow == null)
            {
                col = ncol ?? 0;
                limit = Width;
            }
            limit++; // iterate one more step at the end to count last block
            for (int i = 0; i < limit; i++)
            {
                Element el = null;
                if(i < limit - 1)
                {
                    if (ncol == null)
                    {
                        el = this[i, row];
                    }
                    else
                    {
                        el = this[col, i];
                    }
                }

                if (el != null && el.Type == Element.ElementType.Filled)
                {
                    currentBlock++;
                }
                else if(currentBlock > 0)
                {
                    list.Add(currentBlock);
                    currentBlock = 0;
                }
            }
            return list;
        }
        public List<short> GetCountersListSorted(short? nrow, short? ncol)
        {
            List<short> list = GetCountersList(nrow, ncol);
            list.Sort();
            list.Reverse();
            return list;
        }
        public List<short> GetCountersListReversed(short? nrow, short? ncol)
        {
            List<short> list = GetCountersList(nrow, ncol);
            list.Reverse();
            return list;
        }
    }
}
