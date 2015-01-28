using System;
using System.Collections.Generic;
using System.Text;

namespace BlueboxBack.Core
{
    struct ElementStateMatrix
    {
        //columns: previous Element.ElementType state {undefined, filled, cleared}
        private static Element.ElementType[,] matrixArray = new Element.ElementType[,]{
            {Element.ElementType.Filled,    Element.ElementType.Undefined, Element.ElementType.Filled},         //action Main
            {Element.ElementType.Cleared,   Element.ElementType.Cleared,   Element.ElementType.Undefined},      //action Alter
            {Element.ElementType.Undefined, Element.ElementType.Filled,    Element.ElementType.Cleared},        //action Medium
            {Element.ElementType.Undefined, Element.ElementType.Filled,    Element.ElementType.Cleared}         //action Undefined
            };
        public static Element.ElementType getElementWithState(Element.ElementType j, ActionTypes i)
        {
            return matrixArray[(short)i, (short)j];
        }
    }
}
