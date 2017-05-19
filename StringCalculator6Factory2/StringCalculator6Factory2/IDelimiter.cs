using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator6Factory2
{
    public interface IDelimiter
    {
        string[] CreateDelimiter(string numbers);
        string GetFormattedNumbers(string numbers);
    }

    public class DefaultDelimiter : IDelimiter
    {
        public string[] CreateDelimiter(string numbers)
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
        public string[] CreateDelimiter(string numbers)
        {
            string[] calculationParts = numbers.Split('\n');
            calculationParts[0] = calculationParts[0].Replace("//", "");
            calculationParts[0] = calculationParts[0].Replace("[", "");
            string[] delimiter = calculationParts[0].Split(']');

            return delimiter;
        }

        public string GetFormattedNumbers(string numbers)
        {
            string[] numberParts = numbers.Split('\n');
            return numberParts[1];
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
                case "Default":
                    {
                        return new DefaultDelimiter();
                    }

                case "Custom":
                    {
                        return new CustomDelimiter();
                    }

                default:
                    {
                        throw new Exception();
                    }
            }

            
        }

        public override IDelimiter GetFormattedNumbers(string numbers)
        {
            string delimiter = "Default";

            if (numbers.Contains("//"))
            {
                delimiter = "Custom";
            }

            switch (delimiter)
            {
                case "Default":
                    {
                        return new DefaultDelimiter();
                    }

                case "Custom":
                    {
                        return new CustomDelimiter();
                    }

                default:
                    {
                        throw new Exception();
                    }
            }

            
        }
    }
}
