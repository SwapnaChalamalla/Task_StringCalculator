using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace AddCalculatorTest
{
    [TestFixture]
    public class AddCalculatorTest
    {
        AddCalculator objAddCalculator = new AddCalculator();

        [Test]
        [TestCase("", 0)]
        [TestCase("1", 1)]
        [TestCase("4", 4)]
        public void Test_EmptyStringAndSingleDigit(string numbers, int expected)
        {
            ValidateTest(numbers, expected);
        }

        [Test]
        [TestCase("1,2", 3)]
        [TestCase("4,55,66,77", 202)]
        public void Test_MultipleNumbers(string numbers, int expected)
        {
            ValidateTest(numbers, expected);
        }

        [TestCase("1\n2,4", 7)]
        [TestCase("1\n2,4\n6,7", 20)]
        [TestCase("//;\n1;2;3;41", 47)]
        [TestCase("//#\n1#2#3", 6)]
        public void Test_NumbersWithMultipleDelimeters(string numbers, int expected)
        {
            ValidateTest(numbers, expected);
        }

        private void ValidateTest(string numbers, int expected)
        {
            //Act
            int result = objAddCalculator.Add(numbers);

            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("1,-2,-3")]
        public void Test_ValidateNumbers(string numbers)
        {
            try
            {
                string[] strSeperator = { ",", "\n" };
                var list = numbers.Split(strSeperator, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToList();
                //Act
                StringCalculator.AddCalculator.ValidateNumbersArePositive(list);
            }
            catch (Exception e)
            {
                //Assert
                Assert.IsTrue(e.Message.Contains("negatives not allowed  -2,-3"));
            }
        }
    }
}
