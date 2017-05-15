using NUnit.Framework;
using StringCalculator2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator2.Tests
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
        public void Add_GivenOneValueAndZero_ShouldReturnOneValue()
        {
            Calculator calculator = new Calculator();

            var result = calculator.Add("1,0");

            Assert.AreEqual(1, result);
        }

        [Test]
        public void Add_GivenTwoValues_ShouldReturnSum()
        {
            Calculator calculator = new Calculator();

            var result = calculator.Add("1,2");

            Assert.AreEqual(3, result);
        }

        [Test]
        public void Add_GivenTenValues_ShouldReturnSum()
        {
            string numbers = "1,2,3,4,5,6,7,8,9,10";

            Calculator calculator = new Calculator();

            var result = calculator.Add(numbers);

            Assert.AreEqual(55, result);
        }

        [Test]
        public void Add_GivenRandomNumberOfOnes_ShouldReturnSum()
        {
            Random rnd = new Random();
            int total = 0;
            string numbers = "";

            for (int i = 0; i < rnd.Next(1, 101); i ++)
            {
                if (i == 0)
                {
                    numbers = "1";
                }

                else
                {
                    numbers = numbers + ",1";
                }

                total = total + 1;

            }

            Calculator calculator = new Calculator();

            var result = calculator.Add(numbers);

            Assert.AreEqual(total, result);
        }

        [Test]
        public void Add_GivenRandomNumberOfRandomValues_ShouldReturnSum()
        {
            Random rnd = new Random();
            int total = 0;
            string numbers = "";

            for (int i = 0; i < rnd.Next(1, 101); i ++)
            {
                int newNumber = rnd.Next(0, 101);
                if (i == 0)
                {
                    numbers = "" + newNumber;
                }

                else
                {
                    numbers = numbers + "," + newNumber;
                }

                total = total + newNumber;
            }

            Calculator calculator = new Calculator();

            var result = calculator.Add(numbers);

            Assert.AreEqual(total, result);
        }

        [Test]
        public void Add_GivenNewLineInsteadOfComma_ShouldDelimitLikeComma()
        {
            string numbers = "1\n2";

            Calculator calculator = new Calculator();

            var result = calculator.Add(numbers);

            Assert.AreEqual(3, result);
        }

        [Test]
        public void Add_GivenNewLineAndComma_ShouldBothDelimit()
        {
            string numbers = "1\n2,3";

            Calculator calculator = new Calculator();

            var result = calculator.Add(numbers);

            Assert.AreEqual(6, result);
        }

        [Test]
        public void Add_GivenSemiColonDelimiter_ShouldReturnThree()
        {
            string numbers = "//;\n1;2";

            Calculator calculator = new Calculator();

            var result = calculator.Add(numbers);

            Assert.AreEqual(3, result);
        }

        [Test]
        public void Add_GivenColonDelimiter_ShouldReturnSix()
        {
            string numbers = "//:\n1:2:3";

            Calculator calculator = new Calculator();

            var result = calculator.Add(numbers);

            Assert.AreEqual(6, result);
        }

        [Test]
        public void Add_GivenOneNegativeNumber_ShouldReturnExceptionWithNumber()
        {
            string numbers = "-1,2";

            Calculator calculator = new Calculator();
            
            Assert.That(() => calculator.Add(numbers), Throws.Exception.Message.Contains("Negatives not allowed"));
        }

        [Test]
        public void Add_GivenMultipleNegativeNumbers_ShouldReturnExceptionWithNumbers()
        {
            string numbers = "-1,-2,-6,-8";

            Calculator calculator = new Calculator();

            Assert.That(() => calculator.Add(numbers), Throws.Exception.Message.Contains("Negatives not allowed"));
        }

        [Test]
        public void Add_GivenCustomDelimiterAndNegativeNumbers_ShouldReturnExceptionWithNumbers()
        {
            string numbers = "//;\n-1;-5";

            Calculator calculator = new Calculator();

            Assert.That(() => calculator.Add(numbers), Throws.Exception.Message.Contains("Negatives not allowed"));
        }

        [Test]
        public void Add_GivenCustomDelimiterDashWithPositiveNumbers_ShouldReturnSum()
        {
            string numbers = "//-\n1-2";

            Calculator calculator = new Calculator();

            var result = calculator.Add(numbers);

            Assert.AreEqual(3, result);
        }
    }
}
