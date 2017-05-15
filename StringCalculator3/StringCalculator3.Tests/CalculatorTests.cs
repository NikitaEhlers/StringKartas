using NUnit.Framework;
using StringCalculator3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator3.Tests
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
        public void Add_GivenOneNumber_ShouldReturnOneNumber()
        {
            Calculator calculator = new Calculator();

            var result = calculator.Add("1");

            Assert.AreEqual(1, result);
        }

        [Test]
        public void Add_GivenOneAndTwo_ShouldReturnThree()
        {
            Calculator calculator = new Calculator();

            var result = calculator.Add("1,2");

            Assert.AreEqual(3, result);
        }

        [Test]
        public void Add_GivenThreeNumbers_ShouldReturnSix()
        {
            Calculator calculator = new Calculator();

            var result = calculator.Add("1,2,3");

            Assert.AreEqual(6, result);
        }

        [Test]
        public void Add_GivenSixNumbers_ShouldReturnTwentyOne()
        {
            Calculator calculator = new Calculator();

            var result = calculator.Add("1,2,3,4,5,6");

            Assert.AreEqual(21, result);
        }

        [Test]
        public void Add_GivenRandomAmountOfOnes_ShouldReturnSum()
        {
            Random rnd = new Random();
            string numbers = "";
            int total = 0;

            for (int i = 0; i < rnd.Next(1, 101); i ++)
            {
                if (numbers == "")
                {
                    numbers = "1";
                    total++;
                }

                else
                {
                    numbers = numbers + ",1";
                    total++;
                }
            }

            Calculator calculator = new Calculator();

            var result = calculator.Add(numbers);

            Assert.AreEqual(total, result);
        }


        [Test]
        public void Add_GivenRandomAmountOfRandomNumbers_ShouldReturnSum()
        {
            Random rnd = new Random();
            string numbers = "";
            int total = 0;

            for (int i = 0; i < rnd.Next(1, 101); i++)
            {
                int rndNum = rnd.Next(0, 101);
                if (numbers == "")
                {
                    numbers = rndNum + "";
                    total = rndNum;
                }

                else
                {
                    numbers = numbers + "," + rndNum;
                    total += rndNum;
                }
            }

            Calculator calculator = new Calculator();

            var result = calculator.Add(numbers);

            Assert.AreEqual(total, result);
        }

        [Test]
        public void Add_GivenLineBreakDelimiters_ShouldReturnSum()
        {
            Calculator calculator = new Calculator();

            var result = calculator.Add("1\n2\n3");

            Assert.AreEqual(6, result);
        }

        [Test]
        public void Add_GivenMixedDelimiters_ShouldReturnSum()
        {
            Calculator calculator = new Calculator();

            var result = calculator.Add("1\n2,3");

            Assert.AreEqual(6, result);
        }

        [Test]
        public void Add_GivenSemiColonDelimiter_ShouldReturnThree()
        {
            Calculator calculator = new Calculator();

            var result = calculator.Add("//;\n1;2");

            Assert.AreEqual(3, result);
        }

        [Test]
        public void Add_GivenColonDelimiter_ShouldReturnSix()
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
        public void Add_GivenTwoNegativeNumbers_ShouldThrowException()
        {
            Calculator calculator = new Calculator();

            Assert.That(() => calculator.Add("-1,-2"), Throws.Exception.Message.Contains("Negatives not allowed"));
        }

        [Test]
        public void Add_GivenDashDelimiter_ShouldReturnThree()
        {
            Calculator calculator = new Calculator();

            var result = calculator.Add("//-\n1-2");

            Assert.AreEqual(3, result);
        }

        [Test]
        public void Add_GivenAboveAThousand_ShouldBeTreatedAsZero()
        {

        }
    }
}
