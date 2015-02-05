using System;
using System.Collections.Generic;
using System.Text;

namespace BlueboxBack.Helpers
{
    class CellsBlock: IComparable
    {
        public CellsBlock()
        {      }
        public CellsBlock(CellsBlock origin)
        {
            Length = origin.Length;
            StartPosition = origin.StartPosition;
            IsOpened = origin.IsOpened;
        }
        public int Length { get; set; }
        public int StartPosition { get; set; }
        public bool IsOpened { get; set; }
        private bool isActive = true;
        public bool NotCounted { get { return isActive; } set { isActive = value; } }
        public int CompareTo(object obj)
        {
            CellsBlock block = obj as CellsBlock;
            if (block == null)
            {
                return -1;
            }
            if (Length == block.Length)
            {
                if(IsOpened)
                {
                    return -1;
                }
            }
            return Length - block.Length;
        }
    }
}
