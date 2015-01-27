using BlueboxBack.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueboxBack.Utilities
{
    class RandomMatrixGenerator
    {
        public static DataMatrix GetRandomMatrix(int width, int height)
        {
            DataMatrix matrix = new DataMatrix(width, height);

            Random rand = new Random();

            for (int i = 0; i < width; i++ )
            {
                for (int j = 0; j < width; j++)
                {
                    matrix[i, j] = GetRandomElement(rand);
                }
            }
            //TODO add testing for uniqueness of solution
            return matrix;
        }

        private static Element GetRandomElement(Random rand)
        {
            int lowthres = 0;
            int hitres = 10;
            int density = 7;

            if (rand.Next(lowthres, hitres) < density)
            {
                return Element.Cleared;
            }
            else
            {
                return Element.Filled;
            }
        }
    }
}
