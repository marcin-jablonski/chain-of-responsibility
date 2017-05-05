using System;
using System.IO;
using ChainOfResponsibility.ExpressionProcessors;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter expression");
            string exp = Console.ReadLine();

            ExpressionProcessor processor = PrepareChain();
            try
            {
                processor.Process(Expression.Parse(exp));
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        private static ExpressionProcessor PrepareChain()
        {
            var div = new DivisionProcessor();
            var mul = new MultiplicationProcessor();
            var sub = new SubtractionProcessor();
            var sum = new SumProcessor();
            var res = new ResultProcessor();
            var hash = new HashProcessor();
            var dollar = new DollarProcessor();
            var excl = new ExclamationProcessor();
            var mod = new ModuloProcessor();

            mod.SetNextProcessor(div);
            div.SetNextProcessor(mul);
            mul.SetNextProcessor(sub);
            sub.SetNextProcessor(sum);
            sum.SetNextProcessor(hash);
            hash.SetNextProcessor(excl);
            excl.SetNextProcessor(dollar);
            dollar.SetNextProcessor(res);

            return mod;
        }
    }
}