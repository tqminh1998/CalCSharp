using System;
using System.Collections.Generic;
using CheckingFunc;
using polish_notation;

namespace frmat
{
    class FormatExpression
    {
        public void DeleteSpace(ref string expr)
        {
            if (expr.Length > 0 && expr[0] == ' ')
            {
                expr = expr.Remove(0, 1);
                while (expr.Length > 0 && expr[0] == ' ')
                {
                    expr = expr.Remove(0, 1);
                }
            }

            if (expr.Length > 0 && expr[expr.Length - 1] == ' ')
            {
                expr = expr.Remove(expr.Length - 1, 1);
                while (expr.Length > 0 && expr[expr.Length - 1] == ' ')
                {
                    expr = expr.Remove(expr.Length - 1, 1);
                }
            }

            CheckingFunc.cheking ck = new CheckingFunc.cheking();

            for (int i = 1; i < expr.Length - 1; i++)
            {
                if (expr[i] == ' ' && ck.isOperand(expr[i - 1]))
                {
                    if (ck.isOperand(expr[i + 1])) return;
                }
            }

            int spacePos = expr.IndexOf(" ");
            while (spacePos > 0)
            {
                expr = expr.Remove(spacePos, 1);
                spacePos = expr.IndexOf(" ");
            }
        }
    }
}