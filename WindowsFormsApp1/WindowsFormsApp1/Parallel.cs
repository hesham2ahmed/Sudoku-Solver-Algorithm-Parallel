using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Parallel
    {

        List<Task<Board>> task_list = new List<Task<Board>>();
        List<char[,]> solutions = new List<char[,]>();

        int length;
        char EMPTY_ENTRY = '*';
        public Parallel(int length)
        {
            this.length = length;
        }

        public List<char[,]> solveSudoku(char[,] board, int row, int col)
        {
            // create object of board with step 0 
            // step == number of solved cells
            Board board1 = new Board(board, 0);

            // creat thread to start solve suduko
            Task<Board> parent = new Task<Board>(() =>
            {
                return canSolveSudokuFromCell(0, 0, board1);

            });
            parent.Start();
            parent.Wait();

            // get number of empty cell in grid to know how many step should threads to solve 
            int no_empty_cells = getNumOfEmptyCell(board);


            // loop over list of tasks to get successful tasks to solve suduku 
            for (int i = 0; i < task_list.Count; i++)
            {

                try
                {
                    // check number of solved cell for each task to get successful tasks
                    if (task_list[i].Result.step == no_empty_cells)
                    {
                        // put successful task.grid in a list
                        solutions.Add(task_list[i].Result.grid);
                    }
                }
                catch (Exception e)
                {
                    
                }

            }

            // return a list of solutions
            return solutions;

        }


        private Board canSolveSudokuFromCell(int row, int col, Board board)
        {
            // chech column
            if (col == length)
            {
                col = 0;
                row++;

                // if row == legth then task is looped over whole grid
                if (row == length)
                {
                    return board;
                }

            }

            // if it's nut empty cell then return
            if (board.grid[row, col] != EMPTY_ENTRY)
            {
                return canSolveSudokuFromCell(row, col + 1, board);
            }

            for (int value = 1; value <= length; value++)
            {
                char charToPlace = (char)(value + '0');

                // check if value is correct to place at this location or not
                if (canPlaceValue(board.grid, row, col, charToPlace))
                {
                    // create a copy of grid
                    var grid = board.grid.Clone() as char[,];

                    // place a value at copt
                    grid[row, col] = charToPlace;

                    // create object of board with step+1 
                    //step is how many cells are solved
                    Board new_board = new Board(grid, board.step + 1);

                    // create anthor task with a new_board object to loop again
                    Task<Board> t = new Task<Board>(() =>
                    {
                        return canSolveSudokuFromCell(row, col + 1, new_board);

                    });
                    t.Start();
                    // put that task in a list
                    task_list.Add(t);
                }
            }

            return board;
        }


        private int getNumOfEmptyCell(char[,] grid)
        {
            int count = 0;
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (grid[row, col] == EMPTY_ENTRY)
                        count++;
                }
            }
            return count;
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

            int topLeftOfSubBoxRow = regionSize * verticalBoxIndex; //3*0=0
            int topLeftOfSubBoxCol = regionSize * horizontalBoxIndex;//3*1=3

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

        public void printBoard(char[,] b)
        {
            int length = (int)Math.Sqrt(b.Length);
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                    Console.Write(b[i, j] + " ");
                Console.WriteLine();
            }

        }
    }

}

