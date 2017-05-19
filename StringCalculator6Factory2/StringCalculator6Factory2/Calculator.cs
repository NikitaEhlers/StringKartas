using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator6Factory2
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            if (numbers == "")
            {
                return 0;
            }

            string[] splitNumbers = CreateSplitNumbers(numbers);

            CheckForNegative(splitNumbers);

            return CalculateTotal(splitNumbers);
        }

        public string[] CreateSplitNumbers(string numbers)
        {
            DelimiterFactory factory = new ConcreteDelimiterFactory();
            IDelimiter splitter = factory.CreateDelimiter(numbers);
            string[] delimiter = splitter.CreateDelimiter(numbers);
            IDelimiter numberFormat = factory.GetFormattedNumbers(numbers);
            numbers = numberFormat.GetFormattedNumbers(numbers);

            string[] splitNumbers = numbers.Split(delimiter, StringSplitOptions.None);

            return splitNumbers;
        }

        public int CalculateTotal(string[] splitNumbers)
        {
            int total = 0;

            foreach (var number in splitNumbers)
            {
                int num = Convert.ToInt32(number);

                if (num > 1000)
                {
                    num = 0;
                }

                total = total + num;
            }

            return total;
        }

        public void CheckForNegative(string[] splitNumbers)
        {
            string exceptionMessage = "";

            foreach (var number in splitNumbers)
            {
                if (!number.Contains("-"))
                {
                    continue;
                }

                if (exceptionMessage == "")
                {
                    exceptionMessage = number;
                }

                else
                {
                    exceptionMessage = exceptionMessage + ", " + number;
                }
            }

            if (exceptionMessage != "")
            {
                throw new Exception("Negatives not allowed " + exceptionMessage);
            }
        }
    }

    
}
