using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        static StreamReader streamReader;
        static String path = @"C:\Users\hesha\Desktop\Sudoku with GUI\WindowsFormsApp1\WindowsFormsApp1\TestCases\";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            char[,] board = new char[9, 9];
            String test_case_name = "case17.txt";
            
            // read test case from file
            readTestCase(path + test_case_name, board);



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main(board));
           
            


        }

        public static bool readTestCase(String path, char[,] board)
        {
            try
            {
                streamReader = new StreamReader(path);
                String line;
                int j = 0;
                while ((line = streamReader.ReadLine()) != null)
                {
                    for (int i = 0; i < 9; i++)
                    {
                        board[j, i] = line[i];
                    }
                    j++;
                }
                streamReader.Close();
                return true;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public static void printBoard(char[,] board)
        {
            int length = (int)Math.Sqrt(board.Length);
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                    Console.Write(board[i, j] + " ");
                Console.WriteLine();
            }

        }
    }

}
    

