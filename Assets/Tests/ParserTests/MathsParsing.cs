using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class MathsParsing
    {
        [Test]
        public void _001_Digit()
        {
            float expected = 5;
            float actual = TestParser.Calculate("5");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void _002_Digit2()
        {
            float expected = 2;
            float actual = TestParser.Calculate("2");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void _003_Decimal()
        {
            float expected = 0.5f;
            float actual = TestParser.Calculate("0.5");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void _004_SimpleAddition()
        {
            float expected = 3;
            float actual = TestParser.Calculate("1+2");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void _005_ComplexAddition()
        {
            float expected = 15;
            float actual = TestParser.Calculate("1+2+3+4+5");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void _006_BigAddition()
        {
            float expected = 10584;
            float actual = TestParser.Calculate("455.9 + 782.5 + 9345.6");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void _007_WhiteSpace()
        {
            string expected = "5";
            string actual = TestParser.RemoveSpaces("  5 ");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void _008_WhiteSpace()
        {
            string expected = "2";
            string actual = TestParser.RemoveSpaces("2  ");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void _009_WhiteSpace()
        {
            string expected = "0.5";
            string actual = TestParser.RemoveSpaces(" 0 . 5 ");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void _010_WhiteSpace()
        {
            string expected = "1+2";
            string actual = TestParser.RemoveSpaces(" 1 + 2 ");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void _011_WhiteSpace()
        {
            string expected = "1+2+3+4+5";
            string actual = TestParser.RemoveSpaces("1 + 2 + 3 + 4 + 5");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void _012_SimpleSubtraction()
        {
            float expected = 2;
            float actual = TestParser.Calculate("5-3");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void _013_LeadingMinus()
        {
            float expected = -2;
            float actual = TestParser.Calculate("-2");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void _014_LeadingPlus()
        {
            float expected = 2;
            float actual = TestParser.Calculate("+2");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void _015_AddNegativeWithPositive()
        {
            float expected = 1;
            float actual = TestParser.Calculate("-2+3");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void _016_AddPositiveWithNegative()
        {
            float expected = -1;
            float actual = TestParser.Calculate("2+-3");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void _017_AdditionAndSubtraction()
        {
            float expected = -2;
            float actual = TestParser.Calculate("1 + 2 - 3 + 4 - 5 + 6 - 7");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void _018_SubtractTwoNegativeNumbers()
        {
            float expected = 1;
            float actual = TestParser.Calculate("-5--6");
            Assert.AreEqual(expected, actual);
        }

    }
}
