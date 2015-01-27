using System;
using System.Collections.Generic;
using System.Text;

namespace BlueboxBack.Core
{
    struct ElementStateMatrix
    {
        //columns: previous element state {undefined, filled, cleared}
        private static Element[,] matrixArray = new Element[,]{
            {Element.Filled,    Element.Undefined, Element.Filled},         //action Main
            {Element.Cleared,   Element.Cleared,   Element.Undefined},      //action Alter
            {Element.Undefined, Element.Filled,    Element.Cleared},        //action Medium
            {Element.Undefined, Element.Filled,    Element.Cleared}         //action Undefined
            };
        public static Element getElement(Element i, ActionTypes j)
        {
            return matrixArray[(short)i, (short)j];
        }
    }
}
