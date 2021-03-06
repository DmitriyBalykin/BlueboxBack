﻿using BlueboxBack.Core;
using BlueboxBack.Helpers;
using BlueboxBack.Properties;
using BlueboxBack.UI.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BlueboxBack.Utilities
{
    class MatrixManager
    {
        DataMatrix dataMatrix;
        DataMatrix solutionMatrix;

        public event EventHandler ResultPublished;
        public event EventHandler HintUsed;

        public int HintsLeft = Constants.HINTS_NUMBER;
        public MatrixManager()
        {
            GenerateNewSolution();
        }
        internal DataMatrix CalculateMatrix(BoxTypes type, ActionTypes actionTypes, int x, int y)
        {
            switch(type)
            {
                case BoxTypes.Grid:
                    dataMatrix.HighlightedCol = null;
                    dataMatrix.HighlightedRow = null;
                    dataMatrix = CalculateGridClicked(dataMatrix, actionTypes, x, y);
                    break;
                case BoxTypes.HeaderHorizontal:
                    dataMatrix = CalculateTopHeaderClicked(dataMatrix, actionTypes, x, y);
                    break;
                case BoxTypes.HeaderVertical:
                    dataMatrix = CalculateLeftHeaderClicked(dataMatrix, actionTypes, x, y);
                    break;
            }

            if(IsMatrixOpened(dataMatrix) && (ResultPublished != null))
            {
                if (dataMatrix == solutionMatrix)
                {
                    ResultPublished(this, new DataUpdatedEventArgs(dataMatrix, solutionMatrix, ResultEvent.ResultType.Correct));
                }
                else if(dataMatrix.IsEquivalent(solutionMatrix))
                {
                    ResultPublished(this, new DataUpdatedEventArgs(dataMatrix, solutionMatrix, ResultEvent.ResultType.Alternative));
                }
                else
                {
                    ResultPublished(this, new DataUpdatedEventArgs(dataMatrix, solutionMatrix, ResultEvent.ResultType.Incorrect));
                }
            }

            return dataMatrix;
        }
        public static List<CellsBlock> CheckForOpenedBlocks(DataMatrix dataMatrix, DataMatrix solutionMatrix, int? row, int? col)
        {
            List<CellsBlock> dataList = solutionMatrix.GetCountersList(row, col);
            List<CellsBlock> checkList = dataMatrix.GetCountersList(row, col);
            dataList.ForEach(block => CheckBlockOpened(row, col, block, checkList, dataMatrix));
            return dataList;
        }
        public static List<CellsBlock> GetLineHeaders(DataMatrix dataMatrix, DataMatrix solutionMatrix, int? row, int? col)
        {
            List<CellsBlock> list = CheckForOpenedBlocks(dataMatrix, solutionMatrix, row, col);
            if(!Settings.Default.SaveOrder)
            {
                list.Sort();
            }
            list.Reverse();
            return list;
        }
        public static void CheckBlockOpened(int? row, int? col, CellsBlock block, List<CellsBlock> checkList, DataMatrix dataMatrix)
        {
            foreach (CellsBlock checkBlock in checkList)
            {
                bool startCleared = IsElementCleared(row, col, (checkBlock.StartPosition - 1), dataMatrix);
                bool endCleared = IsElementCleared(row, col, (checkBlock.StartPosition + checkBlock.Length), dataMatrix);
                if (checkBlock.NotCounted && startCleared && endCleared && checkBlock.Length == block.Length)
                {
                    block.IsOpened = true;
                    checkBlock.NotCounted = false;
                    return;
                }
            }
            block.IsOpened = false;
        }
        private static bool IsElementCleared(int? row, int? col, int pos, DataMatrix matrix)
        {
            int colInt = col ?? 0;
            int rowInt = row ?? 0;

            if (pos >= Settings.Default.MatrixSize || pos < 0)
            {
                return true;
            }
            if (row == null)
            {
                return matrix[colInt, pos].Type == Element.ElementType.Cleared;
            }
            else
            {
                return matrix[pos, rowInt].Type == Element.ElementType.Cleared;
            }
        }

        internal DataMatrix GetDataMatrix()
        {
            return dataMatrix;
        }
        internal void GenerateNewSolution()
        {
            HintsLeft = Constants.HINTS_NUMBER;
            dataMatrix = new DataMatrix(Settings.Default.MatrixSize, Settings.Default.MatrixSize);
            solutionMatrix = RandomMatrixGenerator.GetMatrix(Settings.Default.MatrixSize, Settings.Default.MatrixSize);
            //solutionMatrix = TestMatrixGenerator.GetMatrix(Settings.Default.MatrixSize, Settings.Default.MatrixSize);
        }

        private DataMatrix CalculateLeftHeaderClicked(DataMatrix matrix, ActionTypes actionTypes, int x, int y)
        {
            if (x < 20)
            {
                matrix.HighlightedRow = y / Constants.CELL_SIDE;
                ShowLine(matrix);
            }
            ProcessHintUsed();
            return matrix;
        }

        private DataMatrix CalculateTopHeaderClicked(DataMatrix matrix, ActionTypes actionTypes, int x, int y)
        {
            if (y < 20)
            {
                matrix.HighlightedCol = x / Constants.CELL_SIDE;
                ShowLine(matrix);
            }
            ProcessHintUsed();
            return matrix;
        }
        private void ProcessHintUsed()
        {
            if (HintsLeft > 0 && Settings.Default.ShowLines)
            {
                HintsLeft--;
            }
            if (HintUsed != null)
            {
                HintUsed(this, new HintUsedEventArgs() { HintsLeft = HintsLeft});
            }
        }

        private DataMatrix CalculateGridClicked(DataMatrix matrix, ActionTypes actionType, int x, int y)
        {
            int cellX = x / Constants.CELL_SIDE;
            int cellY = y / Constants.CELL_SIDE;

            Element.ElementType currentType = matrix[cellX, cellY].Type;
            Element.ElementType newType = ElementStateMatrix.getElementWithState(currentType, actionType);
            matrix[cellX, cellY] = new Element(ElementStateMatrix.getElementWithState(matrix[cellX, cellY].Type, actionType));

            return matrix;
        }
        private void ShowLine(DataMatrix matrix)
        {
            if(HintsLeft <= 0 || !Settings.Default.ShowLines)
            {
                MessageBox.Show("Извините, подсказок больше нет.");
                return;
            }
            if(matrix.HighlightedRow != null)
            {
                int row = matrix.HighlightedRow ?? -1;
                for (int i = 0; i < matrix.Width; i++)
                {
                    matrix[i, row] = solutionMatrix[i, row];
                }
            }
            if (matrix.HighlightedCol != null)
            {
                int col = matrix.HighlightedCol ?? -1;
                for (int i = 0; i < matrix.Width; i++)
                {
                    matrix[col, i] = solutionMatrix[col, i];
                }
            }
        }

        private bool IsMatrixOpened(DataMatrix matrix)
        {
            return !matrix.Contains(Element.ElementType.Undefined);
        }

        internal DataMatrix GetSolutionMatrix()
        {
            return solutionMatrix;
        }
    }
}
