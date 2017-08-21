using System;
using System.Collections.Generic;
using CheckingFunc;

namespace polish_notation
{
    class _CONVERT
    {
        public void ToPolishNotation(string expr, ref Queue<string> P, ref Stack<string> S)
        {
            CheckingFunc.cheking ck = new CheckingFunc.cheking();
            int len = expr.Length;
            for (int i = 0; i < len; i++)
            {
                if (ck.isOperand(expr[i])) // la toan hang, dua tat ca vao queue
                {
                    string tmp = "";
                    tmp += Convert.ToString(expr[i]);
                    i++;
                    while (i < len && ck.isOperand(expr[i]))
                    {
                        tmp += Convert.ToString(expr[i]);
                        i++;
                    }
                    i--;
                    P.Enqueue(tmp);
                }
                else if (ck.isOperator(expr[i])) //la toan tu
                {
                    string tmp = "";
                    tmp += Convert.ToString(expr[i]);

                    if (S.Count == 0) // stack rong thi dua vao stack
                        S.Push(tmp);
                    else
                    {
                        string tmp1 = S.Peek();
                        //neu tren dinh stack la dau ngoac hoac toan tu co do uu tien thap hon thi dua vao stack
                        if (tmp1[0] == '(' || ck.isPrioritize(tmp[0], tmp1[0]))
                            S.Push(tmp);
                        else
                        {
                            while (S.Count != 0)
                            {
                                string tmp2 = S.Peek();
                                if (tmp2[0] == '(' || ck.isPrioritize(tmp[0], tmp2[0])) break; //neu den dau ngoac thi dung
                                P.Enqueue(tmp2);
                                S.Pop();
                            }
                            S.Push(tmp);
                        }
                    }

                }
                else if (expr[i] == '(')
                {
                    string tmp = "";
                    tmp += Convert.ToString(expr[i]);
                    S.Push(tmp);
                }
                else if (expr[i] == ')')
                {
                    string tmp = S.Peek();
                    // giai phong tat ca cac toan tu nam tren dau ngoac trong stack
                    while (tmp[0] != '(')
                    {
                        P.Enqueue(tmp);
                        S.Pop();
                        tmp = S.Peek();
                    }
                    S.Pop(); // giai phong dau '('
                }

            }
            // dua cac toan tu trong stack vao queue->ky phap ba lan
            while (S.Count != 0)
            {
                string tmp = S.Peek();
                P.Enqueue(tmp);
                S.Pop();
            }
        }

        public void ToResult(ref Queue<string> P, ref Stack<string> RES)
        {
            CheckingFunc.cheking ck = new CheckingFunc.cheking();
            while (P.Count != 0)
            {
                string tmp = P.Peek();
                //duyet queue cho den khi gap toan tu
                while (P.Count != 0 && !ck.isOperator(tmp[0]))
                {
                    P.Dequeue();
                    RES.Push(tmp); // dua cac toan hang vao stack
                    tmp = P.Peek();
                }
                // lay 2 toan hang tren cung tu stack
                string tmp1 = RES.Peek();
                RES.Pop();
                string tmp2 = RES.Peek();
                RES.Pop();

                if (tmp1 == "pi") tmp1 = "3.14";
                if (tmp2 == "pi") tmp2 = "3.14";
                // chuyen doi sang so
                double a, b, ans;
                ans = 0;
                a = Convert.ToDouble(tmp2);
                b = Convert.ToDouble(tmp1);

                if (tmp[0] == '+') ans = a + b;
                else if (tmp[0] == '-') ans = a - b;
                else if (tmp[0] == '/') ans = a / b;
                else if (tmp[0] == '*') ans = a * b;
                else if (tmp[0] == '^') ans = (double)Math.Pow(a, b);

                string result = Convert.ToString(ans);//dua tro lai dang chuoi
                RES.Push(result);// cho lai vao stack
                P.Dequeue(); // tiep tuc  vong lap
            }
        }
    }
}