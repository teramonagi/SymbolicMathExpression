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
            //Write Mathmatical expression
            Variable x = new Variable("x");
            Expression z = ((-x)^2) + 3;
            //(((-x)^2) + 3)
            Console.WriteLine(z);

            //Evaluation
            EvaluateVisitor evaluator = new EvaluateVisitor();
            //Assign x as 10
            evaluator["x"] = 10;
            //(-10)^2 + 3 = 103
            Console.WriteLine(evaluator.Evaluate(z));
        }
    }
}
