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
        Expression expression = new Expression(5, "+", 6);
        Node node = new Node(expression);
        Assert.AreEqual(11, node.DepthFirstEvaluation());
    }

    [Test]
    public void _002_NumberPlusExpression()
    {
        Expression expression = new Expression(5, "+", 6);
        Expression expression2 = new Expression(9, "+", expression);
        Node node = new Node(expression2);
        Assert.AreEqual(20, node.DepthFirstEvaluation());
    }

    [Test]
    public void _003_ExpressionPlusNumber()
    {
        Expression expression = new Expression(5, "+", 6);
        Expression expression2 = new Expression(expression, "+", 7);
        Node node = new Node(expression2);
        Assert.AreEqual(18, node.DepthFirstEvaluation());
    }

    [Test]
    public void _004_ExpressionPlusExpression()
    {
        Expression expression = new Expression(new Expression(1, "+", 2), "+", new Expression(3, "+", 4));
        Node node = new Node(expression);
        Assert.AreEqual(10, node.DepthFirstEvaluation());
    }

    [Test]
    public void _005_BigExpression()
    {
        Expression e = new Expression(0, "+", 0);
        int expected = 100000;
        for(int i = 0; i < expected; i++)
        {
            e = new Expression(e, "+", 1);
        }
        Node node = new Node(e);
        Assert.AreEqual(expected, node.DepthFirstEvaluation());
    }

    [Test]
    public void _006_BigExpression()
    {
        Expression e = new Expression(0, "+", 0);
        int expected = 100000;
        for (int i = 0; i < expected; i++)
        {
            e = new Expression(1, "+", e);
        }
        Node node = new Node(e);
        Assert.AreEqual(expected, node.DepthFirstEvaluation());
    }

    [Test]
    public void _007_BranchingExpression()
    {
        Expression e = new Expression(1, "+", 0);
        int expected = 10;
        for (int i = 0; i < expected; i++)
        {
            e = new Expression(e, "+", new Expression(e));
        }
        Node node = new Node(e);
        Assert.AreEqual(Mathf.Pow(2, expected), node.DepthFirstEvaluation());
    }


    [Test]
    public void _010_SimpleExpressionIsSimple()
    {
        Expression expression = new Expression(5, "+", 6);
        Assert.IsTrue(expression.IsSimple());
    }

    [Test]
    public void _011_ComplexExpressionIsNotSimple()
    {
        Expression expression = new Expression(5, "+", new Expression(5, "+", 6));
        Assert.IsFalse(expression.IsSimple());
    }




}
