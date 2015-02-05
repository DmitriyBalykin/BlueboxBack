using BlueboxBack.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueboxBack.Utilities
{
    class TestMatrixGenerator
    {
        public static DataMatrix GetMatrix(int width, int height)
        {
            DataMatrix result = GetTwoVariantsSolutionMatrix(width, height);

            return result;
        }
        private static DataMatrix GetTwoVariantsSolutionMatrix(int width, int height)
        {
            DataMatrix result = new DataMatrix(width, height, Element.ElementType.Cleared);
            result[0, 0] = new Element(Element.ElementType.Filled);
            result[0, 1] = new Element(Element.ElementType.Filled);
            result[1, 1] = new Element(Element.ElementType.Filled);
            result[1, 2] = new Element(Element.ElementType.Filled);

            return result;
        }
    }
}
