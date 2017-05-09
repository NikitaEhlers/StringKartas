using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator2
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

            checkNegativeValues(splitNumbers);

            return calculateSum(splitNumbers);
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

            for (int i = 0; i < splitNumbers.Length; i++)
            {
                total = total + Convert.ToInt32(splitNumbers[i]);
            }

            return total;
        }

        public void checkNegativeValues(string[] splitNumbers)
        {
            string exceptionMessage = "";

            foreach (string number in splitNumbers)
            {
                if (number.Contains("-"))
                {
                    if (exceptionMessage == "")
                    {
                        exceptionMessage = number;
                    }

                    else
                    {
                        exceptionMessage = exceptionMessage + "," + number;
                    }
                }
            }

            if (exceptionMessage != "")
            {
                string negativeException = "Negatives not allowed - " + exceptionMessage;
                throw new Exception(negativeException);
            }
        }
    }
}
