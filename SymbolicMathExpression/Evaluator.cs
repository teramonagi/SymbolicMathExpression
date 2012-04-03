using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SymbolicMathExpression
{
    /// <summary>
    /// 
    /// </summary>
    internal interface IVisitor
    {
        void Visit(Factor x);
        void Visit(Variable x);
    }

    /*class Evaluator : IVisitor
    {
        void Visit(Factor x)
        {
            x.Value;
        }

    }*/
}
