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
            Parser parser = new Parser();
            float expected = 5;
            float actual = parser.Calculate("5");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void _002_Digit2()
        {
            Parser parser = new Parser();
            float expected = 2;
            float actual = parser.Calculate("2");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void _003_Decimal()
        {
            Parser parser = new Parser();
            float expected = 0.5f;
            float actual = parser.Calculate("0.5");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void _004_SimpleAddition()
        {
            Parser parser = new Parser();
            float expected = 3;
            float actual = parser.Calculate("1+2");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void _005_ComplexAddition()
        {
            Parser parser = new Parser();
            float expected = 15;
            float actual = parser.Calculate("1+2+3+4+5");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void _006_BigAddition()
        {
            Parser parser = new Parser();
            float expected = 10584;
            float actual = parser.Calculate("455.9 + 782.5 + 9345.6");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void _007_WhiteSpace()
        {
            Parser parser = new Parser();
            string expected = "5";
            string actual = parser.RemoveSpaces("  5 ");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void _008_WhiteSpace()
        {
            Parser parser = new Parser();
            string expected = "2";
            string actual = parser.RemoveSpaces("2  ");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void _009_WhiteSpace()
        {
            Parser parser = new Parser();
            string expected = "0.5";
            string actual = parser.RemoveSpaces(" 0 . 5 ");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void _010_WhiteSpace()
        {
            Parser parser = new Parser();
            string expected = "1+2";
            string actual = parser.RemoveSpaces(" 1 + 2 ");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void _011_WhiteSpace()
        {
            Parser parser = new Parser();
            string expected = "1+2+3+4+5";
            string actual = parser.RemoveSpaces("1 + 2 + 3 + 4 + 5");
            Assert.AreEqual(expected, actual);
        }
        

    }
}
