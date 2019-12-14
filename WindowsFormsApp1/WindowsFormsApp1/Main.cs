using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace WindowsFormsApp1
{
    public partial class Main : Form
    {
        char[,] Board = new char[9, 9];
        public Main(char[,] board)
        {
            Board = board;
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // start stop watch to calculate time
            Stopwatch stopwat = Stopwatch.StartNew();

            // start a new thread to process the operation without freezing UI
            Task ui = new Task(() => {
                Sequential sequential = new Sequential(9);
                sequential.solveSudoku(Board);
            });

            ui.Start();
            await ui;

            stopwat.Stop();

            double time_seq_sol = Convert.ToDouble(stopwat.ElapsedMilliseconds);
            
            // start UI
            Form1 f = new Form1(Board,time_seq_sol);
            f.ShowDialog();
            this.Close();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            // start stop watch to calculate time
            Stopwatch stopwatch = Stopwatch.StartNew();

            // start a new thread to process the operation without freezing UI
            Task<List<char[,]>> ui_par = new Task<List<char[,]>>(() =>
            {
                Parallel parallel = new Parallel(9);
                return parallel.solveSudoku(Board, 0, 0);
            });
            ui_par.Start();

            List<char[,]> solutions = await ui_par; 

            stopwatch.Stop();
            // get time per each solution
            double time_per_sol = Convert.ToDouble(stopwatch.ElapsedMilliseconds) / Convert.ToDouble(solutions.Count);
            
            Form2 f2 = new Form2(solutions,time_per_sol);
            f2.ShowDialog();
            this.Close();

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

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
