using System;


namespace CheckingFunc
{
    class cheking
    {
        public bool isNumber(char c)
        {
            return (c <= '9' && c >= '0');
        }

        public bool isOperand(char c)
        {
            return (c <= '9' && c >= '0') || (c == '.') || (c == 'p') || (c == 'i');
        }

        public bool isOperator(char c)
        {
            return (c == '-' || c == '+' || c == '/' || c == '*' || c == '^');
        }

        public bool isPrioritize(char op1, char op2)
        {
            if ((op1 == op2) || (op1 == '*' && op2 == '/') || (op1 == '/' && op2 == '*')
                || (op1 == '/' && op2 == '^') || (op1 == '*' && op2 == '^')) return false;

            if (op1 == '+' || op1 == '-') return false;

            return true;
        }

        public bool isSyntaxError(string expr)
        {
            int len = expr.Length;
            // TH cac ky tu khong lien quan
            for (int i = 0; i < len; i++)
                if (expr[i] != '(' && expr[i] != ')' && !isOperand(expr[i]) && !isOperator(expr[i]))
                    return true;

            // TH cac ky tu dau va cuoi
            if ((!isOperand(expr[0]) && expr[0] != '(') || (expr[len - 1] != ')' && !isOperand(expr[len - 1])))
                return true;

            //TH khac
            for (int i = 1; i < len - 1; i++)
            {
                if (isOperand(expr[i]) && (expr[i + 1] == '(')) return true;
                if (isOperator(expr[i]) && (expr[i + 1] == ')' || isOperator(expr[i + 1]))) return true;
                if (expr[i] == '(' && (expr[i + 1] == ')' || isOperator(expr[i + 1]))) return true;
                if (expr[i] == ')' && (expr[i + 1] == '(' || isOperand(expr[i + 1]))) return true;
                if (expr[i] == '.' && (!isNumber(expr[i - 1]) || !isNumber(expr[i + 1]))) return true;
                if (expr[i] == 'p' && (expr[i + 1] != 'i' || (expr[i - 1] != '(' && !isOperator(expr[i - 1])))) return true;
                if (expr[i] == 'i' && (expr[i - 1] != 'p' || isOperand(expr[i + 1]))) return true;
            }

            //TH co nhieu dau cham trong 1 toan hang
            for (int i = 0; i < len; i++)
            {
                if (expr[i] == '.')
                {
                    i++;
                    while (i < len && isNumber(expr[i])) i++;
                    if (i < len && expr[i] == '.') return true;
                }
            }
            // TH ve so dau ngoac dong va mo
            int numOpen, numClose;
            numClose = numOpen = 0;
            for (int i = 0; i < len; i++)
            {
                if (expr[i] == '(') numOpen++;
                else if (expr[i] == ')') numClose++;
            }


            return numClose != numOpen;
        }
    }
}