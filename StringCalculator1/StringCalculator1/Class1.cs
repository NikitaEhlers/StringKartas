using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator1
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            if (numbers == "")
            {
                return 0;
            }

            string[] delimiter = new string[] { ",", "\n" };


            if (numbers.Contains("//")) //delimiter specified
            {
                delimiter = new string[] { numbers.Substring(2, 1) };
                numbers = numbers.Substring(4);
            }
            

            var splitNumbers = numbers.Split(delimiter, StringSplitOptions.None);
            string negativeException = "";


            foreach (var number in splitNumbers)
            {
                if (number.Contains("-"))
                {
                    if (negativeException == "")
                    {
                        negativeException = number;
                    }

                    else
                    {
                        negativeException = "," + negativeException;
                    }
                }
            }

            if (negativeException != "")
            {
                string newNegativeException = "Negatives not allowed - " + negativeException;
                throw new Exception(newNegativeException);
            }
            


            else
            {
                int sumNumbers = 0;

                for (int i = 0; i < splitNumbers.Length; i++)
                {
                    sumNumbers = sumNumbers + Convert.ToInt32(splitNumbers[i]);
                }

                return sumNumbers;
            }
        }
    }
}
