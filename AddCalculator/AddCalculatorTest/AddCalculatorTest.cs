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
            //Act
            int result = objAddCalculator.Add(numbers);

            //Assert
            Assert.That(result, Is.EqualTo(expected));   
        }

       
    }
}
