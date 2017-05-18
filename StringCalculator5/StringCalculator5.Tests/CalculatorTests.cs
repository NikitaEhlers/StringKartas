using NUnit.Framework;
using StringCalculator5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator5.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void Add_GivenEmptyString_ShouldReturnZero()
        {
            Calculator calculator = new Calculator();

            var result = calculator.Add("");

            Assert.AreEqual(0, result);
        }

        [Test]
        public void Add_GivenOneValue_ShouldReturnOneValue()
        {
            Calculator calculator = new Calculator();

            var result = calculator.Add("1");

            Assert.AreEqual(1, result);
        }

        [Test]
        public void Add_GivenTwoValues_ShouldReturnFive()
        {
            Calculator calculator = new Calculator();

            var result = calculator.Add("2,3");

            Assert.AreEqual(5, result);
        }

        [Test]
        public void Add_GivenFiveValues_ShouldReturnSum()
        {
            Calculator calculator = new Calculator();

            var result = calculator.Add("1,2,3,4,5");

            Assert.AreEqual(15, result);
        }

        [Test]
        public void Add_GivenRandomNumberOfOnes_ShouldReturnRandomNumber()
        {
            string numbers = "";
            Random rnd = new Random();
            int total = 0;

            for (int i = 0; i < rnd.Next(1, 101); i++)
            {
                if (numbers == "")
                {
                    numbers = "1";
                    total = 1;
                }

                else
                {
                    numbers = numbers + ",1";
                    total = total + 1;
                }
            }


            Calculator calculator = new Calculator();

            var result = calculator.Add(numbers);

            Assert.AreEqual(total, result);
        }

        [Test]
        public void Add_GivenRandomNumberOfRandomValues_ShouldReturnSum()
        {
            string numbers = "";
            Random rnd = new Random();
            int total = 0;

            for (int i = 0; i < rnd.Next(1, 101); i++)
            {
                int newNumber = rnd.Next(1, 101);
                if (numbers == "")
                {
                    numbers = "" + newNumber;
                    total = newNumber;
                }

                else
                {
                    numbers = numbers + "," + newNumber;
                    total = total + newNumber;
                }
            }


            Calculator calculator = new Calculator();

            var result = calculator.Add(numbers);

            Assert.AreEqual(total, result);
        }

        [Test]
        public void Add_GivenLineBreakDelimiter_ShouldReturnSumOfThree()
        {
            Calculator calculator = new Calculator();

            var result = calculator.Add("1\n2");

            Assert.AreEqual(3, result);
        }

        [Test]
        public void Add_GivenLineBreakAndCommaDelimiter_ShouldReturnSumOfSix()
        {
            Calculator calculator = new Calculator();

            var result = calculator.Add("1\n2,3");

            Assert.AreEqual(6, result);
        }

        [Test]
        public void Add_GivenChangingDelimiter_ShouldReturnSumOfThree()
        {
            Calculator calculator = new Calculator();

            var result = calculator.Add("//;\n1;2");

            Assert.AreEqual(3, result);
        }

        [Test]
        public void Add_GivenChangingDelimiter_ShouldReturnSumOfSix()
        {
            Calculator calculator = new Calculator();

            var result = calculator.Add("//:\n1:2:3");

            Assert.AreEqual(6, result);
        }

        [Test]
        public void Add_GivenNegativeNumber_ShouldThrowException()
        {
            Calculator calculator = new Calculator();

            Assert.That(() => calculator.Add("-1,2"), Throws.Exception.Message.Contains("Negatives not allowed"));
        }

        [Test]
        public void Add_GivenNegativeNumbers_ShouldThrowException()
        {
            Calculator calculator = new Calculator();

            Assert.That(() => calculator.Add("-1,-2,-3"), Throws.Exception.Message.Contains("Negatives not allowed"));
        }

        [Test]
        public void Add_GivenDashDelimiter_ShouldReturnSumOfThree()
        {
            Calculator calculator = new Calculator();

            var result = calculator.Add("//-\n1-2");

            Assert.AreEqual(3, result);
        }

        [Test]
        public void Add_GivenNumberLargerAThousand_ShouldReturnSumWhileIgnoringThousand()
        {
            string numbers = "2,1001";

            Calculator calculator = new Calculator();

            var result = calculator.Add(numbers);

            Assert.AreEqual(2, result);
        }

        [Test]
        public void Add_GivenDelimiterOfAnyLength_ShouldReturnSumOfSix()
        {
            Calculator calculator = new Calculator();

            var result = calculator.Add("//[***]\n1***2***3");

            Assert.AreEqual(6, result);
        }

        [Test]
        public void Add_GivenMultipleDelimiters_ShouldReturnSumOfSix()
        {
            Calculator calculator = new Calculator();

            var result = calculator.Add("//[*][%]\n1*2%3");

            Assert.AreEqual(6, result);
        }

        [Test]
        public void Add_GivenMultipleDelimitersOfLongerLength_ShouldReturnSumOfSix()
        {
            Calculator calculator = new Calculator();

            var result = calculator.Add("//[**][%%]\n1**2%%3");

            Assert.AreEqual(6, result);
        }
    }
}
