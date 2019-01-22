using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace AddCalculatorTest
{
    [TestFixture]
    public class AddCalculatorTest
    {
        CalculatorForAdd objAddCalculator = new CalculatorForAdd();

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

        [Test]
        [TestCase("1,2", 3)]
        [TestCase("4,55,66,77", 202)]
        [TestCase("1\n2,4", 7)]
        [TestCase("1\n2,4\n6,7", 20)] 
        [TestCase("//;\n1;2;3;41",47)]        
        public void Test_MultipleNumbers(string numbers, int expected)
        {
            //Act
            int result = objAddCalculator.Add(numbers);

            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }

       
    }
}
