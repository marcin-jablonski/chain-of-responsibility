using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ChainOfResponsibility
{
    public class Expression
    {
        public List<string> Items { get; private set; }

        public int? Result { get; set; }

        public static Expression Parse(string expressionString)
        {
            var expression = new Expression();

            foreach (var character in expressionString)
            {
                int outint;
                if (!int.TryParse(character.ToString(), out outint))
                {
                    expression.Items = new List<string>(expressionString.Split(character)) {character.ToString()};
                    expression.Items.GetRange(0, expression.Items.Count - 1).ForEach(x =>
                    {
                        if (!int.TryParse(x, out outint))
                        {
                            throw new IOException("Cannot parse string");
                        }
                    });
                    break;
                }
            }

            if (expression.Items == null)
            {
                throw new IOException("Cannot parse string");

            }

            if (!expression.Items.Any())
            {
                throw new IOException("Cannot parse string");
            }

            return expression;
        }
    }
}