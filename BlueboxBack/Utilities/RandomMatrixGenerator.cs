using BlueboxBack.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueboxBack.Utilities
{
    class RandomMatrixGenerator
    {
        public static DataMatrix GetRandomMatrix(short width, short height)
        {
            DataMatrix matrix = new DataMatrix(width, height);

            Random rand = new Random();

            for (int i = 0; i < width; i++ )
            {
                for (int j = 0; j < width; j++)
                {
                    matrix[i, j] = new Element(GetRandomElement(rand), false);
                }
            }
            //TODO add testing for uniqueness of solution
            return matrix;
        }

        private static Element.ElementType GetRandomElement(Random rand)
        {
            int lowthres = 0;
            int hitres = 10;
            int density = 6;

            if (rand.Next(lowthres, hitres) < density)
            {
                return Element.ElementType.Cleared;
            }
            else
            {
                return Element.ElementType.Filled;
            }
        }
    }
}
