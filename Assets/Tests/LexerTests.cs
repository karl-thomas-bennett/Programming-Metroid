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

        [Test]
        public void _002_FloatAddition()
        {
            Lexer lexer = new Lexer("43.5+82.7");
            string expected = "+(43.5,82.7)";
            string actual = "";
            while(lexer.HasNext())
            {
                actual += lexer.Next();
            }
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void _003_MultipleAdditions()
        {
            Lexer lexer = new Lexer("1+2+3");
            string expected = "+(+(1,2),3)";
            string actual = "";
            while (lexer.HasNext())
            {
                actual += lexer.Next();
            }
            Assert.AreEqual(expected, actual);
        }
    }
}
