namespace ChainOfResponsibility.ExpressionProcessors
{
    public class ResultProcessor : ExpressionProcessor
    {
        protected override void Calculate(Expression expression)
        {
            if (expression.Result != null)
            {
                System.Console.WriteLine("Result is {0}", expression.Result);
            }
            else
            {
                System.Console.WriteLine("Result could not be produced, sorry.");
            }
        }
    }
}