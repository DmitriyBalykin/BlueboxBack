using System;
using System.Collections.Generic;
using System.Text;

namespace BlueboxBack.Core
{
    struct ElementStateMatrix
    {
        //columns: previous element state {undefined, filled, cleared}
        private const Element[,] matrixArray = new Element[,]{
            {Element.Filled,    Element.Undefined, Element.Filled},         //action Main
            {Element.Cleared,   Element.Cleared,   Element.Undefined},      //action Alter
            {Element.Undefined, Element.Filled,    Element.Cleared},        //action Medium
            {Element.Undefined, Element.Filled,    Element.Cleared}         //action Undefined
            };
        public Element this[Element i, ActionTypes j]
        {
            get
            {
                return matrixArray[(short)i, (short)j];
            }
            set
            {
                matrixArray[(short)i, (short)j] = value;
            }
        }
    }
}
