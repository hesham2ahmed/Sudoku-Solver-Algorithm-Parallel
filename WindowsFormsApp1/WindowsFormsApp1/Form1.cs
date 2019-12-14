using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        String a;
        public Form1(char[,] board, double tim_seq_sol)
        {
           
            InitializeComponent();
            fillBoard(board);
            time_seq.Text = tim_seq_sol + "  ms";
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void fillBoard(char[,] board)
        {
            t1.Text = char.ToString(board[0, 0]);
            t2.Text = char.ToString(board[0, 1]);
            t3.Text = char.ToString(board[0, 2]);
            t4.Text = char.ToString(board[0, 3]);
            t5.Text = char.ToString(board[0, 4]);
            t6.Text = char.ToString(board[0, 5]);
            t7.Text = char.ToString(board[0, 6]);
            t8.Text = char.ToString(board[0, 7]);
            t9.Text = char.ToString(board[0, 8]);
            t10.Text = char.ToString(board[1, 0]);
            t11.Text = char.ToString(board[1, 1]);
            t12.Text = char.ToString(board[1, 2]);
            t13.Text = char.ToString(board[1, 3]);
            t14.Text = char.ToString(board[1, 4]);
            t15.Text = char.ToString(board[1, 5]);
            t16.Text = char.ToString(board[1, 6]);
            t17.Text = char.ToString(board[1, 7]);
            t18.Text = char.ToString(board[1, 8]);
            t19.Text = char.ToString(board[2, 0]);
            t20.Text = char.ToString(board[2, 1]);
            t21.Text = char.ToString(board[2, 2]);
            t22.Text = char.ToString(board[2, 3]);
            t23.Text = char.ToString(board[2, 4]);
            t24.Text = char.ToString(board[2, 5]);
            t25.Text = char.ToString(board[2, 6]);
            t26.Text = char.ToString(board[2, 7]);
            t27.Text = char.ToString(board[2, 8]);
            t28.Text = char.ToString(board[3, 0]);
            t29.Text = char.ToString(board[3, 1]);
            t30.Text = char.ToString(board[3, 2]);
            t31.Text = char.ToString(board[3, 3]);
            t32.Text = char.ToString(board[3, 4]);
            t33.Text = char.ToString(board[3, 5]);
            t34.Text = char.ToString(board[3, 6]);
            t35.Text = char.ToString(board[3, 7]);
            t36.Text = char.ToString(board[3, 8]);
            t37.Text = char.ToString(board[4, 0]);
            t38.Text = char.ToString(board[4, 1]);
            t39.Text = char.ToString(board[4, 2]);
            t40.Text = char.ToString(board[4, 3]);
            t41.Text = char.ToString(board[4, 4]);
            t42.Text = char.ToString(board[4, 5]);
            t43.Text = char.ToString(board[4, 6]);
            t44.Text = char.ToString(board[4, 7]);
            t45.Text = char.ToString(board[4, 8]);
            t46.Text = char.ToString(board[5, 0]);
            t47.Text = char.ToString(board[5, 1]);
            t48.Text = char.ToString(board[5, 2]);
            t49.Text = char.ToString(board[5, 3]);
            t50.Text = char.ToString(board[5, 4]);
            t51.Text = char.ToString(board[5, 5]);
            t52.Text = char.ToString(board[5, 6]);
            t53.Text = char.ToString(board[5, 7]);
            t54.Text = char.ToString(board[5, 8]);
            t55.Text = char.ToString(board[6, 0]);
            t56.Text = char.ToString(board[6, 1]);
            t57.Text = char.ToString(board[6, 2]);
            t58.Text = char.ToString(board[6, 3]);
            t59.Text = char.ToString(board[6, 4]);
            t60.Text = char.ToString(board[6, 5]);
            t61.Text = char.ToString(board[6, 6]);
            t62.Text = char.ToString(board[6, 7]);
            t63.Text = char.ToString(board[6, 8]);
            t64.Text = char.ToString(board[7, 0]);
            t65.Text = char.ToString(board[7, 1]);
            t66.Text = char.ToString(board[7, 2]);
            t67.Text = char.ToString(board[7, 3]);
            t68.Text = char.ToString(board[7, 4]);
            t69.Text = char.ToString(board[7, 5]);
            t70.Text = char.ToString(board[7, 6]);
            t71.Text = char.ToString(board[7, 7]);
            t72.Text = char.ToString(board[7, 8]);
            t73.Text = char.ToString(board[8, 0]);
            t74.Text = char.ToString(board[8, 1]);
            t75.Text = char.ToString(board[8, 2]);
            t76.Text = char.ToString(board[8, 3]);
            t77.Text = char.ToString(board[8, 4]);
            t78.Text = char.ToString(board[8, 5]);
            t79.Text = char.ToString(board[8, 6]);
            t80.Text = char.ToString(board[8, 7]);
            t81.Text = char.ToString(board[8, 8]);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox65_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
