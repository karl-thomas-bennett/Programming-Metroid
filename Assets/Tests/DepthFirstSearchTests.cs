using System.Collections;
using System.Collections.Generic;
using System;
using NUnit.Framework;

public class DepthFirstSearchTests
{
    [Test]
    public void _001_ExpressionTest()
    {
        Node node = new Node(new Expression(1, "+", 2));

        Assert.AreEqual(3, node.DepthFirstEvaluation());
    }

    [Test]
    public void _002_TwoExpressionsInExpressionTest()
    {
        Expression e = new Expression(1, "+", 2);
        Node node = new Node(new Expression(e, "+", e));

        Assert.AreEqual(6, node.DepthFirstEvaluation());
    }

    [Test]
    public void _003_RecursiveExpressionsTest()
    {
        Expression e = new Expression(1, "+", 2);
        e = new Expression(e, "+", e);
        Node node = new Node(new Expression(e, "+", e));

        Assert.AreEqual(12, node.DepthFirstEvaluation());
    }

    [Test]
    public void _004_ExpressionInLeftSideOfExpressionTest()
    {
        Expression e = new Expression(1, "+", 2);
        Node node = new Node(new Expression(e, "+", 1));

        Assert.AreEqual(4, node.DepthFirstEvaluation());
    }

    [Test]
    public void _005_ExpressionInRightSideOfExpressionTest()
    {
        Expression e = new Expression(1, "+", 2);
        Node node = new Node(new Expression(1, "+", e));

        Assert.AreEqual(4, node.DepthFirstEvaluation());
    }

}
