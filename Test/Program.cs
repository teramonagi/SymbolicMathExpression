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
            Expression z = x / 2 + 3;
            //((x / 2) + 3)
            Console.WriteLine(z);
            
            //Evaluation
            EvaluateVisitor evaluator = new EvaluateVisitor();
            //Assign x as 4
            evaluator["x"] = 4;
            //4 / 2 + 3 = 5!
            Console.WriteLine(evaluator.Evaluate(z));
        }
    }
}
