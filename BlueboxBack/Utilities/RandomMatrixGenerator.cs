using BlueboxBack.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueboxBack.Utilities
{
    class RandomMatrixGenerator
    {
        private const int BASIC_DENSITY = 51;
        private const int SPACE_DENSITY = 10;
        private const int GROUP_DENSITY = 60;

        private const int LOW_THRESHOLD = 0;
        private const int HIGH_THRESHOLD = 100;

        private const int GROUP_DENSITY_CHANGE_FACTOR = 1;
        private const int SPACE_DENSITY_CHANGE_FACTOR = 3;

        private static int space_density = SPACE_DENSITY;
        private static int group_density = GROUP_DENSITY;

        public static DataMatrix GetRandomMatrix(short width, short height)
        {
            DataMatrix m1 = GetRandomMatrixBase(width, height);
            //DataMatrix m2 = GetRandomMatrixBase(width, height);

            //DataMatrix result = new DataMatrix(width, height);

            //for (int i = 0; i < width; i++)
            //{
            //    for (int j = 0; j < height; j++)
            //    {
            //        result[i, j] = new Element(MixElements(m1[i, j], m2[j, i]));
            //    }
            //}
            return m1;
        }

        private static Element.ElementType MixElements(Element element1, Element element2)
        {
            return (element1.Type == Element.ElementType.Filled && element2.Type == Element.ElementType.Filled)
                ? Element.ElementType.Filled
                : Element.ElementType.Cleared;
        }
        private static DataMatrix GetRandomMatrixBase(int width, int height)
        {
            //extend matrix and fill border with cleared elements for further
            int widthExtend = width + 2;
            int heightExtend = height + 2;
            DataMatrix matrix = new DataMatrix((short)widthExtend, (short)heightExtend);

            Random rand = new Random();

            for (int i = 0; i < widthExtend; i++ )
            {
                for (int j = 0; j < heightExtend; j++)
                {
                    if (i == 0 || j == 0 || i == (widthExtend - 1) || j == (heightExtend - 1))
                    {
                        matrix[i, j] = new Element(Element.ElementType.Cleared);
                    }
                    else
                    {
                        matrix[i, j] = new Element(GetRandomElementWithGrouping(rand, matrix[(i - 1), j], matrix[i, (j - 1)]), false);
                    }
                }
            }
            for (short i = 1; i < widthExtend - 1; i++)
            {
                bool foundSingle;
                do
                {
                    foundSingle = false;
                    for (int j = 1; j < heightExtend - 1; j++)
                    {
                        if (IsElementSingle(matrix, i, j))
                        {
                            matrix[i, j] = new Element(Element.ElementType.Cleared);
                            foundSingle = true;
                        }
                    }
                }
                while (matrix.GetCountersList(null, i).Count > Constants.MAX_ELEMENTS && foundSingle);
            }
            for (short i = 1; i < heightExtend - 1; i++)
            {
                bool foundSingle;
                do
                {
                    foundSingle = false;
                    for (int j = 1; j < widthExtend - 1; j++)
                    {
                        if (IsElementSingle(matrix, i, j))
                        {
                            matrix[i, j] = new Element(Element.ElementType.Cleared);
                            foundSingle = true;
                        }
                    }
                }
                while (matrix.GetCountersList(i, null).Count > Constants.MAX_ELEMENTS && foundSingle);
            }
            //cut result matrix
            DataMatrix resultMatrix = new DataMatrix(width, height);
            for (int i = 1; i < widthExtend - 1; i++)
            {
                for (int j = 1; j < heightExtend - 1; j++)
                {
                    resultMatrix[i-1, j-1] = matrix[i,j];
                }
            }
            //TODO add testing for uniqueness of solution
            return matrix;
        }
        private static bool IsElementSingle(DataMatrix matrix, int i, int j)
        {
            if ((matrix[i - 1, j] + matrix[i, j - 1] + matrix[i, j + 1] + matrix[i + 1, j]) == 0 && matrix[i, j].Type == Element.ElementType.Filled)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static Element.ElementType GetRandomElement(Random rand, int density = BASIC_DENSITY)
        {
            int randInt = rand.Next(LOW_THRESHOLD, HIGH_THRESHOLD);
            if (randInt > density)
            {
                return Element.ElementType.Cleared;
            }
            else
            {
                return Element.ElementType.Filled;
            }
        }
        private static Element.ElementType GetRandomElementWithGrouping(Random rand, Element leftEl, Element topEl)
        {
            int density = BASIC_DENSITY;
            if(leftEl.Type == Element.ElementType.Cleared && topEl.Type == Element.ElementType.Cleared)
            {
                density = space_density;
                space_density += SPACE_DENSITY_CHANGE_FACTOR;
            }
            else if (leftEl.Type == Element.ElementType.Filled && topEl.Type == Element.ElementType.Filled)
            {
                density = group_density;
                group_density -= GROUP_DENSITY_CHANGE_FACTOR;
            }
            else
            {
                space_density -= SPACE_DENSITY_CHANGE_FACTOR;
                group_density += GROUP_DENSITY_CHANGE_FACTOR;
            }

            return GetRandomElement(rand, density);
        }
    }
}
