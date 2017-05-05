namespace ChainOfResponsibility
{
    public abstract class ExpressionProcessor
    {
        private ExpressionProcessor _nextProcessor;

        public void SetNextProcessor(ExpressionProcessor processor)
        {
            _nextProcessor = processor;
        }

        public void Process(Expression expression)
        {
            Calculate(expression);
            _nextProcessor?.Process(expression);
        }

        protected abstract void Calculate(Expression expression);
    }
}