using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SymbolicMathExpression
{
    public abstract class BinaryFunction : Expression
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
        public Expression Left  {get{ return _lhs; }}
        public Expression Right {get{ return _rhs; }}
        private Expression _lhs;
        private Expression _rhs;
    }
    public class Add : BinaryFunction
    {
        public override void Accept(IVisitor visitor) { visitor.Visit(this); }
        public override string ToString() { return ToStringByInfixNotation("+"); }
        public Add(Expression lhs, Expression rhs) : base(lhs, rhs) { }
    }
    public class Multiply : BinaryFunction
    {
        public override void Accept(IVisitor visitor) { visitor.Visit(this); }
        public override string ToString() { return ToStringByInfixNotation("*"); }
        public Multiply(Expression lhs, Expression rhs) : base(lhs, rhs) { }
    }
    public class Subtract : BinaryFunction
    {
        public override void Accept(IVisitor visitor) { visitor.Visit(this); }
        public override string ToString() { return ToStringByInfixNotation("-"); }
        public Subtract(Expression lhs, Expression rhs) : base(lhs, rhs) { }
    }
    public class Divide : BinaryFunction
    {
        public override void Accept(IVisitor visitor) { visitor.Visit(this); }
        public override string ToString() { return ToStringByInfixNotation("/"); }
        public Divide(Expression lhs, Expression rhs) : base(lhs, rhs) { }
    }
}