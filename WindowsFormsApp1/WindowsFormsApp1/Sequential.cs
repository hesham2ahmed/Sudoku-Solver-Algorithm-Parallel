using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Sequential
    {

        int length;
        char EMPTY_ENTRY = '*';
        public Sequential(int length)
        {

            this.length = length;

        }

        public void solveSudoku(char[,] board)
        {

          //  board[0, 0] = '9';
            canSolveSudokuFromCell(0, 0, board);
        }

        private bool canSolveSudokuFromCell(int row, int col, char[,] board)
        {
            if (col == length)
            {
                col = 0;
                row++;

                if (row == length)
                {
                    return true;
                }
            }

            // if cell is not empty skip it 
            if (board[row, col] != EMPTY_ENTRY)
            {
                return canSolveSudokuFromCell(row, col + 1, board);
            }

            for (int value = 1; value <= length; value++)
            {
                char charToPlace = (char)(value + '0');

                if (canPlaceValue(board, row, col, charToPlace))
                {
                    board[row, col] = charToPlace;
                    if (canSolveSudokuFromCell(row, col + 1, board))
                    {
                        return true;
                    }
                    board[row, col] = EMPTY_ENTRY;
                }
            }

            return false;
        }

        private bool canPlaceValue(char[,] board, int row, int col, char charToPlace)
        {
            // Check column of the placement
            for (int i = 0; i < length; i++)
            {
                if (charToPlace == board[i, col])
                {
                    return false;
                }
            }


            // Check row of the placement
            for (int i = 0; i < length; i++)
            {
                if (charToPlace == board[row, i])
                {
                    return false;
                }
            }

            // Check region constraints - get the size of the sub-box
            int regionSize = (int)Math.Sqrt(length);

            int verticalBoxIndex = row / regionSize;
            int horizontalBoxIndex = col / regionSize;

            int topLeftOfSubBoxRow = regionSize * verticalBoxIndex;
            int topLeftOfSubBoxCol = regionSize * horizontalBoxIndex;

            for (int i = 0; i < regionSize; i++)
            {
                for (int j = 0; j < regionSize; j++)
                {
                    if (charToPlace == board[topLeftOfSubBoxRow + i, topLeftOfSubBoxCol + j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }




    }

}
