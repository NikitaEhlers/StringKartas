using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator5
{
    public interface IDelimiter
    {
        string[] CreateDelimiters(string numbers);

        string GetFormattedNumbers(string numbers);
    }

    public class DefaultDelimiter : IDelimiter
    {
        public string[] CreateDelimiters(string numbers)
        {
            string[] delimiter = new string[] { ",", "\n" };

            return delimiter;
        }

        public string GetFormattedNumbers(string numbers)
        {
            return numbers;
        }
    }

    public class CustomDelimiter : IDelimiter
    {
        public string[] CreateDelimiters(string numbers)
        {
            string[] delimiter;
            string[] calculationParts = numbers.Split('\n');
            calculationParts[0] = calculationParts[0].Replace("//", "");
            calculationParts[0] = calculationParts[0].Replace("[", "");
            delimiter = calculationParts[0].Split(']');

            return delimiter;
        }

        public string GetFormattedNumbers(string numbers)
        {
            string[] calculationParts = numbers.Split('\n');

            return calculationParts[1];
        }
    }

    public abstract class DelimiterFactory
    {
        public abstract IDelimiter CreateDelimiter(string numbers);

        public abstract IDelimiter GetFormattedNumbers(string numbers);
    }

    public class ConcreteDelimiterFactory : DelimiterFactory
    {
        public override IDelimiter CreateDelimiter(string numbers)
        {
            string delimiter = "Default";

            if (numbers.Contains("//"))
            {
                delimiter = "Custom";
            }


            switch (delimiter)
            {
                case "Custom":
                    {
                        return new CustomDelimiter();
                    }

                case "Default":
                    {
                        return new DefaultDelimiter();
                    }

                default:
                    {
                        throw new NotImplementedException();
                    }
            }

        }

        public override IDelimiter GetFormattedNumbers(string numbers)
        {
            string delimiterType = "Default";

            if (numbers.Contains("//"))
            {
                delimiterType = "Custom";
            }


            switch (delimiterType)
            {
                case "Custom":
                    {
                        return new CustomDelimiter();
                    }

                case "Default":
                    {
                        return new DefaultDelimiter();
                    }

                default:
                    {
                        throw new NotImplementedException();
                    }
            }
            
        }
    }
}
