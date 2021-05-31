using System;
using System.Collections.Generic;
using System.Text;
using Calculator_TDD;
using NUnit.Framework;

namespace TestCalculator
{   
    
    public class CalculatorTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Add_InputEmptyString_ReturnZero()
        {
            Calculator calculator = new Calculator();

            var expect = 0;

            var actual = calculator.Add("");

            Assert.AreEqual(expect, actual);
        }

        [Test]
        public void Add_InputOneParameter_ReturnThisParameter()
        {
            Calculator calculator = new Calculator();

            var expect = 4;

            var actual = calculator.Add("4");

            Assert.AreEqual(expect, actual);
        }
        [Test]
        public void Add_InputTwoParametersOrMore_ReturnSumOfParametrs()
        {
            Calculator calculator = new Calculator();

            var expect = 9;

            var actual = calculator.Add("4,5");

            Assert.AreEqual(expect, actual);
        }

        [Test]
        public void Add_InputSeparatorsOfNumbersIsSpace()
        {
            Calculator calculator = new Calculator();

            var expect = 6;

            var actual = calculator.Add("1\n2,3");

            Assert.AreEqual(expect, actual);
        }
            
        [Test]
        public void Add_InputInvalidData()
        {
            Calculator calculator = new Calculator();
            Assert.Throws<FormatException>( () => calculator.Add("1, \n"));

        }

        [Test]
        public void Add_UserCanAddDelimiter()
        {
            Calculator calculator = new Calculator();

            var expect = 6;

            var actual = calculator.Add("//;\n1;2;3");

            Assert.AreEqual(expect, actual);
        }

        [Test]
        public void Add_InputNegativeNumber_ThrowsException()
        {
            Calculator calculator = new Calculator();
            var exception = Assert.Throws<ArgumentException>(() => calculator.Add("12,11,-12,12"));
            Assert.AreEqual(exception.Message, "negatives not allowed");
        }

        [Test]
        public void Add_InputSeveralNegativeNumbers_PrintAllNegativeNumbers()
        {
            Calculator calculator = new Calculator();
            var exception = Assert.Throws<ArgumentException>(() => calculator.Add("12,-11,-12,12"));
            Assert.AreEqual(exception.Message, "negatives not allowed -11,-12");
        }

        [Test]
        public void GetCalledCount_CallThreeTimesMethodAdd_ReturnThree()
        {
            Calculator calculator = new Calculator();
            calculator.Add("1");
            calculator.Add("1");
            calculator.Add("1");

            Assert.AreEqual(3, calculator.GetCalledCount());
        }

        [Test]
        public void CheckEvent_AddOccured_AddMethodWhichThrowsException()
        {
            Calculator calculator = new Calculator((s,i) => throw new ArgumentException("Event is work"));
            var exception = Assert.Throws<ArgumentException>(() => calculator.Add("12,12"));
            Assert.AreEqual(exception.Message, "Event is work");
        }

        [Test]
        public void Add_IgnoreNumbersBiggerThanThousand()
        {
            Calculator calculator = new Calculator();
            var expect = 2;

            var actual = calculator.Add("//;\n2;1001");
            Assert.AreEqual(expect, actual);
        }

        [Test]
        public void Add_InputCanAddDelimiterAnyLength()
        {
            Calculator calculator = new Calculator();
            var expect = 5;

            var actual = calculator.Add("//[***]\n2***3");
            Assert.AreEqual(expect, actual);
        }

        [Test]
        public void Add_UserCanAddSeveralDelimitersAnyLength()
        {
            Calculator calculator = new Calculator();
            var expect =12;

            var actual = calculator.Add("//[***][**][*]\n2***3**2*5");
            Assert.AreEqual(expect, actual);
        }
    }

    
}
