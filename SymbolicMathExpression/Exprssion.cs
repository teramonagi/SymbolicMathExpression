using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SymbolicMathExpression
{
    public abstract class Expression
    {
        public abstract void Accept(IVisitor visitor);
        static public Expression operator +(Expression lhs, Expression rhs) { return new Add(lhs, rhs); }
        static public Expression operator -(Expression lhs, Expression rhs) { return new Subtract(lhs, rhs); }
        static public Expression operator *(Expression lhs, Expression rhs) { return new Multiply(lhs, rhs); }
        static public Expression operator /(Expression lhs, Expression rhs) { return new Divide(lhs, rhs); }
        static public Expression operator ^(Expression lhs, Expression rhs) { return new Power(lhs, rhs); }
        static public Expression operator -(Expression operand) { return new Subtract(0.0, operand); }
        static public implicit operator Expression(double x) { return new Factor(x); }
        static public implicit operator Expression(int x) { return new Factor(x); }
    }
    public class Variable : Expression
    {
        public override void Accept(IVisitor visitor) { visitor.Visit(this); }
        public Variable(string name) { Name = name; }
        public Variable() : this(""){}
        public string Name { get; set; }
        public override string ToString(){return Name;}
    }
    public class Factor : Expression
    {
        public override void Accept(IVisitor visitor) { visitor.Visit(this); }
        public Factor(double x) { Value = x; }
        public double Value { get; set; }
        public override string ToString() { return Value.ToString(); }
    }
    public class Null : Expression
    {
        public override void Accept(IVisitor visitor) { visitor.Visit(this); }
        public override string ToString() { return ""; }
    }
}