using NUnit.Framework;
using StringCalculator1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator1.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void Add_GivenEmptyString_ShouldReturnZero()
        {
            var numbers = "";

            var calculator = new Calculator();
            var result = calculator.Add(numbers);

            Assert.AreEqual(0, result);
        }

        [Test]
        public void Add_GivenZero_ShouldReturnZero()
        {
            var numbers = "0";

            var calculator = new Calculator();
            var result = calculator.Add(numbers);

            Assert.AreEqual(0, result);
        }

        [Test]
        public void Add_GivenOneValue_ShouldReturnOneValue()
        {
            int valueOne = 5;
            var numbers = "" + valueOne;

            var calculator = new Calculator();
            var result = calculator.Add(numbers);

            Assert.AreEqual(valueOne, result);
        }

        [Test]
        public void Add_GivenOneValueAndZero_ShouldReturnOneValue()
        {
            int valueOne = 5;
            var numbers = valueOne + ",0";

            var calculator = new Calculator();
            var result = calculator.Add(numbers);

            Assert.AreEqual(valueOne, result);
        }

        [Test]
        public void Add_GivenOneAndTwo_ShouldReturnThree()
        {
            var numbers = "1,2";

            var calculator = new Calculator();
            var result = calculator.Add(numbers);

            Assert.AreEqual(3, result);
        }

        [Test]
        public void Add_GivenSixValues_ShouldReturnSum()
        {
            var numbers = "1,2,3,4,5,6";

            var calculator = new Calculator();
            var result = calculator.Add(numbers);

            Assert.AreEqual(21, result);
        }

        [Test]
        public void Add_GivenEightRandomValues_ShouldReturnSum()
        {
            string numbers = "";
            Random rdm = new Random();
            int total = 0;

            for (int i = 0; i < 8; i ++)
            {
                var newNumber = rdm.Next(0, 101);
                if (i == 7)
                {
                    numbers = numbers + newNumber;
                }

                else
                {
                    numbers = numbers + newNumber + ",";
                }

                total = total + newNumber;
            }


            var calculator = new Calculator();
            var result = calculator.Add(numbers);

            Assert.AreEqual(total, result);
        }

        [Test]
        public void Add_GivenAnyAmountOfNumbers_ShouldReturnSum()
        {
            string numbers = "";
            Random rdm = new Random();
            int total = 0;

            for (int i = 0; i < rdm.Next(0, 101); i ++)
            {
                int newNumber = rdm.Next(0, 101);
                if (i == 0)
                {
                    numbers = newNumber + "";
                }

                else
                {
                    numbers = numbers + "," + newNumber;
                }

                total = total + newNumber;
            }

            var calculator = new Calculator();
            var result = calculator.Add(numbers);

            Assert.AreEqual(total, result);
        }

        [Test]
        public void Add_NewLineDelimiter_ShouldWorkLikeComma()
        {
            string numbers = "1\n2";

            var calculator = new Calculator();
            var result = calculator.Add(numbers);

            Assert.AreEqual(3, result);
        }

        [Test]
        public void Add_MixedDelimiters_ShouldWorkTogetherReturnSum()
        {
            string numbers = "1\n2,3";

            var calculator = new Calculator();
            var result = calculator.Add(numbers);

            Assert.AreEqual(6, result);
        }

        [Test]
        public void Add_MixedDelimitersMultiple_ShouldReturnSum()
        {
            string numbers = "1\n2,3\n1,2";

            var calculator = new Calculator();
            var result = calculator.Add(numbers);

            Assert.AreEqual(9, result);
        }

        [Test]
        public void Add_DifferentDelimitersSemiColon_ShouldReturnSum()
        {
            string numbers = "//;\n1;2";

            var calculator = new Calculator();
            var result = calculator.Add(numbers);

            Assert.AreEqual(3, result);
        }

        [Test]
        public void Add_SingleNegativeNumber_ShouldReturnExceptionAndNumber()
        {
            var calculator = new Calculator();

            Assert.Throws<Exception>(() => calculator.Add("200,-100"));
            //Assert.AreEqual("Negatives not allowed - -100", exc.Message);
        }

        [Test]
        public void Add_TwoNegativeNumbers_ShouldReturnExceptionWithNumbers()
        {
            var calculator = new Calculator();
            Assert.Throws<Exception>(() => calculator.Add("-200,-100,300"));
        }

        [Test]
        public void Add_DelimiterDash_ShouldReturnSum()
        {
            string numbers = "//-\n1-2";

            var calculator = new Calculator();
            var result = calculator.Add(numbers);

            Assert.AreEqual(3, result);
        }
    }
}
