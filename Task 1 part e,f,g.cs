using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class EquationSolver
{
    public static string Solve(string equation)
    {
        equation = equation.Replace(" ", "");

        if (HasMismatchedBrackets(equation))
        {
            return "Invalid equation.";
        }

        if (IsValidArithmeticExpression(equation))
        {
            try
            {
                int result = EvaluateArithmeticExpression(equation);
                return result.ToString();
            }
            catch (Exception)
            {
                return "Invalid equation";
            }
        }
        else
        {
            return "Invalid equation";
        }
    }

    private static bool HasMismatchedBrackets(string equation)
    {
        int openBracketCount = 0;

        foreach (char c in equation)
        {
            if (c == '(')
            {
                openBracketCount++;
            }
            else if (c == ')')
            {
                if (openBracketCount <= 0)
                {
                    return true;
                }
                openBracketCount--;
            }
        }

        return openBracketCount != 0;
    }

    private static bool IsValidArithmeticExpression(string equation)
    {
        if (Regex.IsMatch(equation, @"[+\-*/]{2,}|\+$|-$|\*$|/$"))
        {
            return false;
        }

        if (Regex.IsMatch(equation, @"[+\-*/]\)"))
        {
            return false;
        }

        if (Regex.IsMatch(equation, @"[+\-*/]\("))
        {
            return false;
        }

        equation = equation.Replace("(", "( ");
        equation = equation.Replace(")", " )");

        if (Regex.IsMatch(equation, @"\(\d+\s+\d+\)"))
        {
            return false;
        }

        if (Regex.IsMatch(equation, @"\d+\("))
        {
            return false;
        }

        if (Regex.IsMatch(equation, @"\)\d+"))
        {
            return false;
        }

        return true;
    }

    private static int EvaluateArithmeticExpression(string expression)
    {
        List<string> tokens = new List<string>();
        string[] operators = { "+", "-", "*", "/", "x" };

        int i = 0;
        while (i < expression.Length)
        {
            if (Char.IsDigit(expression[i]) || expression[i] == '.')
            {
                string number = expression[i].ToString();
                i++;
                while (i < expression.Length && (Char.IsDigit(expression[i]) || expression[i] == '.'))
                {
                    number += expression[i];
                    i++;
                }
                tokens.Add(number);
            }
            else
            {
                tokens.Add(expression[i].ToString());
                i++;
            }
        }

        Stack<int> valueStack = new Stack<int>();
        Stack<string> operatorStack = new Stack<string>();

        foreach (string token in tokens)
        {
            if (int.TryParse(token, out int number))
            {
                valueStack.Push(number);
            }
            else if (Array.IndexOf(operators, token) >= 0)
            {
                while (operatorStack.Count > 0 && Precedence(operatorStack.Peek()) >= Precedence(token))
                {
                    int right = valueStack.Pop();
                    int left = valueStack.Pop();
                    string op = operatorStack.Pop();
                    int result = ApplyOperator(left, right, op);
                    valueStack.Push(result);
                }
                operatorStack.Push(token);
            }
            else if (token == "(")
            {
                operatorStack.Push(token);
            }
            else if (token == ")")
            {
                while (operatorStack.Count > 0 && operatorStack.Peek() != "(")
                {
                    int right = valueStack.Pop();
                    int left = valueStack.Pop();
                    string op = operatorStack.Pop();
                    int result = ApplyOperator(left, right, op);
                    valueStack.Push(result);
                }
                if (operatorStack.Count > 0 && operatorStack.Peek() == "(")
                {
                    operatorStack.Pop();
                }
            }
        }

        while (operatorStack.Count > 0)
        {
            int right = valueStack.Pop();
            int left = valueStack.Pop();
            string op = operatorStack.Pop();
            int result = ApplyOperator(left, right, op);
            valueStack.Push(result);
        }

        return valueStack.Pop();
    }

    private static int Precedence(string op)
    {
        switch (op)
        {
            case "+":
            case "-":
                return 1;
            case "*":
            case "/":
            case "x":
                return 2;
            default:
                return 0;
        }
    }

    private static int ApplyOperator(int left, int right, string op)
    {
        switch (op)
        {
            case "+":
                return left + right;
            case "-":
                return left - right;
            case "*":
            case "x":
                return left * right;
            case "/":
                return left / right;
            default:
                throw new ArgumentException("Invalid operator: " + op);
        }
    }

    public static void Main(string[] args)
    {
        //Part e
        string equation1 = "22 / 2 x 34 - 4";
        string equation2 = "3 x 4 / 9 + 4";
        
        //Part f
        string equation3 = "(1 + 1) - 3 x (44 x 5) / 20";
       
        //Part g
        string equation4 = "1 + 2 + 4 + 6 + 8";
        string equation5 = "(1 + 1) 3 + 4 x 5";
        string equation6 = "(((1 + 1) x 3) + 4 x 5";
        string equation7 = "1 + 2 + 3 - - 4";
        string equation8 = "1 + 2 + 3 -";

        Console.WriteLine("Equation 1: " + Solve(equation1));
        Console.WriteLine("Equation 2: " + Solve(equation2));
        Console.WriteLine("Equation 3: " + Solve(equation3));
        Console.WriteLine("Equation 4: " + Solve(equation4));
        Console.WriteLine("Equation 5: " + Solve(equation5));
        Console.WriteLine("Equation 6: " + Solve(equation6));
        Console.WriteLine("Equation 7: " + Solve(equation7));
        Console.WriteLine("Equation 8: " + Solve(equation8));
    }
}
