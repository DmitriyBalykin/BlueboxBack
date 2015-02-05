using BlueboxBack.Helpers;
using System;
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
        public DataMatrix(int width, int height, Element.ElementType type)
        {
            this.Width = width;
            this.Height = height;
            matrixArray = new Element[width, height];

            InitializeMatrix(type);
        }
        public DataMatrix(int width, int height)
            : this(width, height, Element.ElementType.Undefined)
        {}
        private void InitializeMatrix(Element.ElementType type)
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    matrixArray[i, j] = new Element(type);
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
                    if(m1[i, j].Type != m2[i, j].Type)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool operator !=(DataMatrix m1, DataMatrix m2)
        {
            return m1 != m2;
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

        public List<CellsBlock> GetCountersList(int? nrow, int? ncol)
        {
            List<CellsBlock> list = new List<CellsBlock>();
            int limit = 0;
            int row = 0, col = 0;
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
            CellsBlock currentBlock = null;
            Element el = null;
            for (int i = 0; i < limit; i++)
            {
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
                    if(currentBlock == null)
                    {
                        currentBlock = new CellsBlock() { StartPosition = i };
                    }
                    currentBlock.Length++;
                    el = null;
                }
                else if(currentBlock != null)
                {
                    list.Add(new CellsBlock(currentBlock));
                    currentBlock = null;
                }
            }
            return list;
        }
        public List<CellsBlock> GetCountersListSorted(int? nrow, int? ncol)
        {
            List<CellsBlock> list = GetCountersList(nrow, ncol);
            list.Sort();
            list.Reverse();
            return list;
        }
        public List<CellsBlock> GetCountersListReversed(int? nrow, int? ncol)
        {
            List<CellsBlock> list = GetCountersList(nrow, ncol);
            list.Reverse();
            return list;
        }

        internal bool IsEquivalent(DataMatrix solutionMatrix)
        {
            for(int i = 0; i < Width; i++)
            {
                List<CellsBlock> current = GetCountersListSorted(i, null);
                List<CellsBlock> target = solutionMatrix.GetCountersListSorted(i, null);
                if(current.Count != target.Count)
                {
                    return false;
                }
                for (int j = 0; j < current.Count; j++)
                {
                    if (current[j].Length != target[j].Length)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
