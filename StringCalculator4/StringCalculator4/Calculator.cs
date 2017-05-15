using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator4
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
            string[] delimiter = new string[] { ",", "\n" };

            if (numbers.Contains("//"))
            {
                string[] calculationParts = numbers.Split('\n');
                calculationParts[0] = calculationParts[0].Replace("//", "");
                calculationParts[0] = calculationParts[0].Replace("[", "");
                delimiter = calculationParts[0].Split(']');
                numbers = calculationParts[1];
            }

            string[] splitNumbers = numbers.Split(delimiter, StringSplitOptions.None);

            return splitNumbers;
        }

        public int calculateSum(string[] splitNumbers)
        {
            int total = 0;

            for (int i = 0; i < splitNumbers.Length; i ++)
            {
                int number = Convert.ToInt32(splitNumbers[i]);

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
                if (number.Contains("-"))
                {
                    if (exceptionMessage == "")
                    {
                        exceptionMessage = number;
                    }

                    else
                    {
                        exceptionMessage = exceptionMessage + ", " + number;
                    }
                }
            }

            if (exceptionMessage != "")
            {
                throw new Exception("Negatives not allowed " + exceptionMessage);
            }
        }

    }

}
