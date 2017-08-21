using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CheckingFunc;
using polish_notation;
using frmat;

namespace CalForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btEqual_Click(object sender, EventArgs e)
        {
            string expr = textEntry.Text;
            frmat.FormatExpression fm = new frmat.FormatExpression();
            fm.DeleteSpace(ref expr);
            lblRes.Text = expr;
            CheckingFunc.cheking ck = new CheckingFunc.cheking();

            if (expr == "")
            {
                lblRes.Text = "";
                return;
            }

            if (ck.isSyntaxError(expr))
            {
                lblRes.Text = "Syntax Error";
                return;
            }

            Queue<string> P = new Queue<string>();
            Stack<string> S = new Stack<string>();


            //expression to polish notation
            polish_notation._CONVERT cv = new polish_notation._CONVERT();
            cv.ToPolishNotation(expr, ref P, ref S);

            //POLISH NOTATION TO RESULT
            Stack<string> RES = new Stack<string>();
            if (P.Count == 0) return;
            if (P.Count == 1)
            {
                if (P.Peek() == "pi") lblRes.Text = "3.14";
                else lblRes.Text = P.Peek();
            }
            else
            {
                cv.ToResult(ref P, ref RES);
                lblRes.Text = RES.Peek();
            }
        }

        private void lblRes_Click(object sender, EventArgs e)
        {

        }

        private void btNum1_Click(object sender, EventArgs e)
        {
            if (textEntry.Text == "") textEntry.Text = "1";
            else textEntry.Text = textEntry.Text + "1";
        }

        private void btNum2_Click(object sender, EventArgs e)
        {
            if (textEntry.Text == "") textEntry.Text = "2";
            else textEntry.Text = textEntry.Text + "2";
        }

        private void btNum3_Click(object sender, EventArgs e)
        {
            if (textEntry.Text == "") textEntry.Text = "3";
            else textEntry.Text = textEntry.Text + "3";
        }

        private void btNum4_Click(object sender, EventArgs e)
        {
            if (textEntry.Text == "") textEntry.Text = "4";
            else textEntry.Text = textEntry.Text + "4";
        }

        private void btNum5_Click(object sender, EventArgs e)
        {
            if (textEntry.Text == "") textEntry.Text = "5";
            else textEntry.Text = textEntry.Text + "5";
        }

        private void btNum6_Click(object sender, EventArgs e)
        {
            if (textEntry.Text == "") textEntry.Text = "6";
            else textEntry.Text = textEntry.Text + "6";
        }

        private void btNum7_Click(object sender, EventArgs e)
        {
            if (textEntry.Text == "") textEntry.Text = "7";
            else textEntry.Text = textEntry.Text + "7";
        }

        private void btNum8_Click(object sender, EventArgs e)
        {
            if (textEntry.Text == "") textEntry.Text = "8";
            else textEntry.Text = textEntry.Text + "8";
        }

        private void btNum9_Click(object sender, EventArgs e)
        {
            if (textEntry.Text == "") textEntry.Text = "9";
            else textEntry.Text = textEntry.Text + "9";
        }

        private void btNum0_Click(object sender, EventArgs e)
        {
            if (textEntry.Text == "") textEntry.Text = "0";
            else textEntry.Text = textEntry.Text + "0";
        }

        private void btPoint_Click(object sender, EventArgs e)
        {
            if (textEntry.Text == "") textEntry.Text = ".";
            else textEntry.Text = textEntry.Text + ".";
        }

        private void btPi_Click(object sender, EventArgs e)
        {
            if (textEntry.Text == "") textEntry.Text = "pi";
            else textEntry.Text = textEntry.Text + "pi";
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            if (textEntry.Text == "") textEntry.Text = ")";
            else textEntry.Text = textEntry.Text + ")";
        }

        private void btPlus_Click(object sender, EventArgs e)
        {
            if (textEntry.Text == "") textEntry.Text = "+";
            else textEntry.Text = textEntry.Text + "+";
        }

        private void btSub_Click(object sender, EventArgs e)
        {
            if (textEntry.Text == "") textEntry.Text = "-";
            else textEntry.Text = textEntry.Text + "-";
        }

        private void btMul_Click(object sender, EventArgs e)
        {
            if (textEntry.Text == "") textEntry.Text = "*";
            else textEntry.Text = textEntry.Text + "*";
        }

        private void btDiv_Click(object sender, EventArgs e)
        {
            if (textEntry.Text == "") textEntry.Text = "/";
            else textEntry.Text = textEntry.Text + "/";
        }

        private void btPow_Click(object sender, EventArgs e)
        {
            if (textEntry.Text == "") textEntry.Text = "^";
            else textEntry.Text = textEntry.Text + "^";
        }

        private void btOpen_Click(object sender, EventArgs e)
        {
            if (textEntry.Text == "") textEntry.Text = "(";
            else textEntry.Text = textEntry.Text + "(";
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            string expr = textEntry.Text;
            int len = expr.Length;
            if (len != 0)
                textEntry.Text = expr.Remove(len - 1);
        }

        private void btAC_Click(object sender, EventArgs e)
        {
            textEntry.Text = "";
        }

        private void textEntry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string expr = textEntry.Text;
                frmat.FormatExpression fm = new frmat.FormatExpression();
                fm.DeleteSpace(ref expr);
                lblRes.Text = expr;
                CheckingFunc.cheking ck = new CheckingFunc.cheking();

                if (expr == "")
                {
                    lblRes.Text = "";
                    return;
                }

                if (ck.isSyntaxError(expr))
                {
                    lblRes.Text = "Syntax Error";
                    return;
                }

                Queue<string> P = new Queue<string>();
                Stack<string> S = new Stack<string>();


                //expression to polish notation
                polish_notation._CONVERT cv = new polish_notation._CONVERT();
                cv.ToPolishNotation(expr, ref P, ref S);

                //POLISH NOTATION TO RESULT
                Stack<string> RES = new Stack<string>();
                if (P.Count == 0) return;
                if (P.Count == 1)
                {
                    if (P.Peek() == "pi") lblRes.Text = "3.14";
                    else lblRes.Text = P.Peek();
                }
                else
                {
                    cv.ToResult(ref P, ref RES);
                    lblRes.Text = RES.Peek();
                }
            }
        }
    }
}
