using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator3
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

            checkNegativeNumber(splitNumbers);

            int total = calculateSum(splitNumbers);

            return total;
        }

        public string[] createSplitNumbers(string numbers)
        {
            string[] delimiter = new string[] { ",", "\n" };

            if (numbers.Contains("//"))
            {
                delimiter = new string[] { numbers.Substring(2, 1) };
                numbers = numbers.Substring(4);
            }

            string[] splitNumbers = numbers.Split(delimiter, StringSplitOptions.None);

            return splitNumbers;
        }

        public int calculateSum(string[] splitNumbers)
        {
            int total = 0;

            for (int i = 0; i < splitNumbers.Length; i ++)
            {
                total = total + Convert.ToInt32(splitNumbers[i]);
            }
            
            return total;
        }

        public void checkNegativeNumber(string[] splitNumbers)
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
                throw new Exception("Negatives not allowed - " + exceptionMessage);
            }
        }
    }
}
