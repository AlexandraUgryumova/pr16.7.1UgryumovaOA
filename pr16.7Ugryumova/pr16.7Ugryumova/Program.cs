using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr16._7Ugryumova
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("введите выражение в постфиксной форме:");
            var postfix = Console.ReadLine();
            var infix = ConvertPostfixToInfix(postfix);
            Console.WriteLine($"выражение в инфиксной форме :\n {infix}");
            Console.ReadKey();
        }
        static string ConvertPostfixToInfix(string postfix)
        {
            var stack = new Stack<string>();
            string[] items = postfix.Split(' ');

            foreach(string item in items)
            {
                if (IsOperator(item))
                {
                    string operand2 = stack.Pop();
                    string operand1 = stack.Pop();
                    string expression = $"({operand1} {item} {operand2}) ";
                    stack.Push(expression);
                }
                else
                {
                    stack.Push(item);
                }
            }
            return stack.Pop();
        }
        static bool IsOperator(string item)
        {
            return item == "+" || item == "-" || item == "*" || item == "/";
        }
    }
}
