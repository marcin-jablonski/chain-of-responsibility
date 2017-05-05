using System;
using System.Linq;

namespace ChainOfResponsibility.ExpressionProcessors
{
    public class ExclamationProcessor : ExpressionProcessor
    {
        protected override void Calculate(Expression expression)
        {
            if (expression.Result != null) return;
            if (expression.Items.Last() == "!")
            {
                expression.Result = (int) Math.Pow(int.Parse(expression.Items[0]), 2) * int.Parse(expression.Items[1]);
            }
        }
    }
}