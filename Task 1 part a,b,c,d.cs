using System;

public class EquationSolver
{
    public static double Solve(string equation)
    {
        equation = equation.Replace(" ", "");
        double currentNumber = 0;
        double currentResult = 0;
        char currentOperator = '+';

        for (int i = 0; i < equation.Length; i++)
        {
            char currentChar = equation[i];

            if (Char.IsDigit(currentChar) || currentChar == '.')
            {
                currentNumber = currentNumber * 10 + (currentChar - '0');
            }
            else
            {
                currentResult = ApplyOperator(currentResult, currentNumber, currentOperator);
                currentOperator = currentChar;
                currentNumber = 0;
            }
        }
        currentResult = ApplyOperator(currentResult, currentNumber, currentOperator);
        return Math.Round(currentResult, 6);
    }

    private static double ApplyOperator(double left, double right, char op)
    {
        if (op == '+')
            return left + right;
        else if (op == '-')
            return left - right;
        else if (op == 'x' || op == '*')
            return left * right;
        else if (op == '/')
            return left / right;
        else
            throw new ArgumentException("Invalid operator: " + op);
    }

    public static void Main(string[] args)
    {
        string equation1 = "122 + 323";
        string equation2 = "323 - 121";
        string equation3 = "22 x 45";
        string equation4 = "3/9";

        Console.WriteLine("Equation 1: " + Solve(equation1));
        Console.WriteLine("Equation 2: " + Solve(equation2));
        Console.WriteLine("Equation 3: " + Solve(equation3));
        Console.WriteLine("Equation 4: " + Solve(equation4));
    }
}
