using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator5
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            if (numbers == "")
            {
                return 0;
            }

            string[] splitNumbers = createSplitNumbers(numbers);

            checkForNegative(splitNumbers);

            return calculateSum(splitNumbers);
        }

        public string[] createSplitNumbers(string numbers)
        {
            DelimiterFactory factory = new ConcreteDelimiterFactory();
            IDelimiter splitter = factory.CreateDelimiter(numbers);
            string[] delimiter = splitter.CreateDelimiters(numbers);
            IDelimiter numSplitter = factory.GetFormattedNumbers(numbers);
            numbers = numSplitter.GetFormattedNumbers(numbers);

            string[] splitNumbers = numbers.Split(delimiter, StringSplitOptions.None);

            return splitNumbers;
        }

        public int calculateSum(string[] splitNumbers)
        {
            int total = 0;

            foreach (var num in splitNumbers)
            {
                int number = Convert.ToInt32(num);

                if (number > 1000)
                {
                    number = 0;
                }

                total = total + number;
            }
            
            return total;
        }

        public void checkForNegative(string[] splitNumbers)
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
