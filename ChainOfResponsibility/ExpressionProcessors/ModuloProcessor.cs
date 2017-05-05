using System.Linq;

namespace ChainOfResponsibility.ExpressionProcessors
{
    public class ModuloProcessor : ExpressionProcessor
    {
        protected override void Calculate(Expression expression)
        {
            if (expression.Result != null) return;
            if (expression.Items.Last() == "%")
            {
                expression.Result = int.Parse(expression.Items[0]) % int.Parse(expression.Items[1]);
            }
        }
    }
}