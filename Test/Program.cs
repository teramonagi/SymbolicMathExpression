using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SymbolicMathExpression;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Variable x = new Variable("x");
            Expression z = Function.Exp(x) / 2 + 3 * 8 + Function.Sin(1);
            Console.WriteLine(z);
        }
    }
}
