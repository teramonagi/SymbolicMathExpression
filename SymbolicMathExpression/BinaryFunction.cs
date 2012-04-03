using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SymbolicMathExpression
{
    internal abstract class BinaryFunction : Expression
    {
        public BinaryFunction(Expression lhs, Expression rhs)
        {
            _lhs = lhs;
            _rhs = rhs;
        }
        protected string ToStringByInfixNotation(string x)
        {
            return "(" + _lhs.ToString() + x + _rhs.ToString() + ")";
        }
        private Expression _lhs;
        private Expression _rhs;
    }
    internal class Add : BinaryFunction
    {
        public override string ToString() { return ToStringByInfixNotation("+"); }
        public Add(Expression lhs, Expression rhs) : base(lhs, rhs) { }
    }
    internal class Multiply : BinaryFunction
    {
        public override string ToString() { return ToStringByInfixNotation("*"); }
        public Multiply(Expression lhs, Expression rhs) : base(lhs, rhs) { }
    }
    internal class Subtract : BinaryFunction
    {
        public override string ToString() { return ToStringByInfixNotation("-"); }
        public Subtract(Expression lhs, Expression rhs) : base(lhs, rhs) { }
    }
    internal class Divide : BinaryFunction
    {
        public override string ToString() { return ToStringByInfixNotation("/"); }
        public Divide(Expression lhs, Expression rhs) : base(lhs, rhs) { }
    }
}