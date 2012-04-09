using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SymbolicMathExpression
{
    public abstract class UnaryFunction : Expression
    {
        public UnaryFunction(Expression x)
        {
            _x = x;
        }
        protected string ToString(string x)
        {
            return x + "(" + _x.ToString() + ")";
        }
        public Expression Operand { get { return _x; } }
        private Expression _x;
    }
    public class ExpInner : UnaryFunction
    {
        public override void Accept(IVisitor visitor) { visitor.Visit(this); }
        public override string ToString() { return ToString("Exp"); }
        public ExpInner(Expression x) : base(x) { }
    }
    public class LogInner : UnaryFunction
    {
        public override void Accept(IVisitor visitor) { visitor.Visit(this); }
        public override string ToString() { return ToString("Log"); }
        public LogInner(Expression x) : base(x) { }
    }
    public class SinInner : UnaryFunction
    {
        public override void Accept(IVisitor visitor) { visitor.Visit(this); }
        public override string ToString() { return ToString("Sin"); }
        public SinInner(Expression x) : base(x) { }
    }
    public class CosInner : UnaryFunction
    {
        public override void Accept(IVisitor visitor) { visitor.Visit(this); }
        public override string ToString() { return ToString("Cos"); }
        public CosInner(Expression x) : base(x) { }
    }

    //Functions for creating inner objects
    static public partial class Function
    {
        static public Expression Exp(Expression x) { return new ExpInner(x); }
        static public Expression Log(Expression x) { return new LogInner(x); }
        static public Expression Sin(Expression x) { return new SinInner(x); }
        static public Expression Cos(Expression x) { return new CosInner(x); }
    }
}