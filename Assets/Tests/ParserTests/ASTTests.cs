using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ASTTests
{
    [Test]
    public void _001_NumberPlusNumber()
    {
        TestExpression expression = new TestExpression(5, "+", 6);
        TestNode node = new TestNode(expression);
        Assert.AreEqual(11, node.DepthFirstEvaluation());
    }

    [Test]
    public void _002_NumberPlusTestExpression()
    {
        TestExpression expression = new TestExpression(5, "+", 6);
        TestExpression expression2 = new TestExpression(9, "+", expression);
        TestNode node = new TestNode(expression2);
        Assert.AreEqual(20, node.DepthFirstEvaluation());
    }

    [Test]
    public void _003_TestExpressionPlusNumber()
    {
        TestExpression expression = new TestExpression(5, "+", 6);
        TestExpression expression2 = new TestExpression(expression, "+", 7);
        TestNode node = new TestNode(expression2);
        Assert.AreEqual(18, node.DepthFirstEvaluation());
    }

    [Test]
    public void _004_TestExpressionPlusTestExpression()
    {
        TestExpression expression = new TestExpression(new TestExpression(1, "+", 2), "+", new TestExpression(3, "+", 4));
        TestNode node = new TestNode(expression);
        Assert.AreEqual(10, node.DepthFirstEvaluation());
    }

    [Test]
    public void _005_BigTestExpression()
    {
        TestExpression e = new TestExpression(0, "+", 0);
        int expected = 100000;
        for(int i = 0; i < expected; i++)
        {
            e = new TestExpression(e, "+", 1);
        }
        TestNode node = new TestNode(e);
        Assert.AreEqual(expected, node.DepthFirstEvaluation());
    }

    [Test]
    public void _006_BigTestExpression()
    {
        TestExpression e = new TestExpression(0, "+", 0);
        int expected = 100000;
        for (int i = 0; i < expected; i++)
        {
            e = new TestExpression(1, "+", e);
        }
        TestNode node = new TestNode(e);
        Assert.AreEqual(expected, node.DepthFirstEvaluation());
    }

    [Test]
    public void _007_BranchingTestExpression()
    {
        TestExpression e = new TestExpression(1, "+", 0);
        int expected = 10;
        for (int i = 0; i < expected; i++)
        {
            e = new TestExpression(e, "+", new TestExpression(e));
        }
        TestNode node = new TestNode(e);
        Assert.AreEqual(Mathf.Pow(2, expected), node.DepthFirstEvaluation());
    }

    [Test]
    public void _009_TwoTestExpressionsInTestExpressionTest()
    {
        TestExpression e = new TestExpression(1, "+", 2);
        TestNode node = new TestNode(new TestExpression(e, "+", e));

        Assert.AreEqual(6, node.DepthFirstEvaluation());
    }

    [Test]
    public void _010_RecursiveTestExpressionsTest()
    {
        TestExpression e = new TestExpression(1, "+", 2);
        e = new TestExpression(e, "+", e);
        TestNode node = new TestNode(new TestExpression(e, "+", e));

        Assert.AreEqual(12, node.DepthFirstEvaluation());
    }

    [Test]
    public void _011_SimpleTestExpressionIsSimple()
    {
        TestExpression expression = new TestExpression(5, "+", 6);
        Assert.IsTrue(expression.IsSimple());
    }

    [Test]
    public void _012_ComplexTestExpressionIsNotSimple()
    {
        TestExpression expression = new TestExpression(5, "+", new TestExpression(5, "+", 6));
        Assert.IsFalse(expression.IsSimple());
    }




}
