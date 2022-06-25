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

    }
}
