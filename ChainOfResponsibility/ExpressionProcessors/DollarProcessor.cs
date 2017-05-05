using System.Linq;

namespace ChainOfResponsibility.ExpressionProcessors
{
    public class DollarProcessor : ExpressionProcessor
    {
        protected override void Calculate(Expression expression)
        {
            double dollarCourse = 3.84865547;

            if (expression.Result != null) return;
            if (expression.Items.Last() == "$")
            {
                expression.Result = (int) ((int.Parse(expression.Items[0]) + int.Parse(expression.Items[1])) * dollarCourse);
            }
        }
    }
}