using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class LexerTests
    {
        [Test]
        public void _001_SimpleAddition()
        {
            Lexer lexer = new Lexer("1+2");
            string expected = "+(1,2)";
            string actual = "";
            for(int i = 0; i < expected.Length; i++)
            {
                actual += lexer.Next();
            }
            Assert.AreEqual(expected, actual);
        }

        

    }
}
