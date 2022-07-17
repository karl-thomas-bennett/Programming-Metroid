using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestExpression 
{
    public Expression expression;
    public TestExpression(float value1, string op, float value2)
    {
        expression = new Expression(value1, op, value2);
    }

    public TestExpression(float value1, string op, TestExpression expression2)
    {
        expression = new Expression(value1, op, expression2.expression);
    }

    public TestExpression(TestExpression expression1, string op, float value2)
    {
        expression = new Expression(expression1.expression, op, value2);
    }

    public TestExpression(TestExpression expression1, string op, TestExpression expression2)
    {
        expression = new Expression(expression1.expression, op, expression2.expression);
    }

    public TestExpression(TestExpression expression)
    {
        this.expression = new Expression(expression.expression);
    }

    public bool IsSimple()
    {
        return expression.IsSimple();
    }
    
    public float SimpleEvaluate()
    {
        return expression.SimpleEvaluate();
    }

    public override string ToString()
    {
        return expression.ToString();
    }
}
