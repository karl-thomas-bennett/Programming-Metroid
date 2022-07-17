using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class GetNumberTests
    {
        [Test]
        public void _001_GetIntegerBefore()
        {
            float expected = 145;
            float actual = TestInterface.GetNumber("145+60", 2);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void _002_GetIntegerAfter()
        {
            float expected = 60;
            float actual = TestInterface.GetNumber("145+60", 4);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void _003_GetFloatBefore()
        {
            float expected = 1.45f;
            float actual = TestInterface.GetNumber("1.45+60", 3);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void _004_GetFloatAfter()
        {
            float expected = 6.5f;
            float actual = TestInterface.GetNumber("1.45+6.5", 5);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void _005_NegativeBefore()
        {
            float expected = -1.45f;
            float actual = TestInterface.GetNumber("-1.45+6.5", 4);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void _006_NegativeAfter()
        {
            float expected = -6.5f;
            float actual = TestInterface.GetNumber("1.45+-6.5", 5);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void _006_NegativeOperator()
        {
            float expected = 6;
            float actual = TestInterface.GetNumber("1-6", 2);
            Assert.AreEqual(expected, actual);
        }
    }
}
