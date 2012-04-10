using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace SymbolicMathExpression
{
    public interface IVisitor
    {
        void Visit(Factor x);
        void Visit(Variable x);
        void Visit(Null x);
        //
        void Visit(ExpInner x);
        void Visit(LogInner x);
        void Visit(SinInner x);
        void Visit(CosInner x);
        //
        void Visit(Add x);
        void Visit(Multiply x);
        void Visit(Subtract x);
        void Visit(Divide x);
        void Visit(Power x);
    }
    public class EvaluateVisitor : IVisitor
    {
        public void Visit(Factor x) { _stack.Push(x); }
        public void Visit(Variable x) { _stack.Push(new Factor(this._key_valus[x.Name])); }
        public void Visit(Null x) {}
        //
        public void Visit(ExpInner x) { VisitUnary(x, Math.Exp); }
        public void Visit(LogInner x) { VisitUnary(x, Math.Log); }
        public void Visit(SinInner x) { VisitUnary(x, Math.Sin); }
        public void Visit(CosInner x) { VisitUnary(x, Math.Cos); }
        //
        public void Visit(Add x) { VisitBinary(x, (y, z) => y + z); }
        public void Visit(Multiply x) { VisitBinary(x, (y, z) => y * z); }
        public void Visit(Subtract x) { VisitBinary(x, (y, z) => y - z); }
        public void Visit(Divide x) { VisitBinary(x, (y, z) => y / z); }
        public void Visit(Power x) { VisitBinary(x, (y, z) => Math.Pow(y, z)); }
        //
        public double Evaluate(Expression x)
        {
            x.Accept(this);
            Factor factor = _stack.Pop() as Factor;
            return factor.Value;
        }
        public double this[string key]
        {
            get { return this._key_valus[key]; }
            set { _key_valus[key] = value; }
        }
        //
        private void VisitUnary(UnaryFunction x, Func<double, double> unary_function)
        {
            //
            x.Operand.Accept(this);
            Factor factor = _stack.Pop() as Factor;
            //
            _stack.Push(new Factor(unary_function(factor.Value)));
        }
        private void VisitBinary(BinaryFunction x, Func<double, double, double> binary_function)
        {
            //Evaluate each side
            x.Left.Accept(this);
            Factor left = _stack.Pop() as Factor;
            x.Right.Accept(this);
            Factor right = _stack.Pop() as Factor;
            //push result into stack as Factor object
            _stack.Push(new Factor(binary_function(left.Value, right.Value)));
        }
        private Dictionary<string, double> _key_valus = new Dictionary<string, double>();
        private Stack _stack = new Stack();
    }
    //public class DifferentiateVisitor : IVisitor
}
