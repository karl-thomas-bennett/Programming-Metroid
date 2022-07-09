using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expression 
{
    public Expression expression1 = null;
    public Expression expression2 = null;
    public float value1 = 0;
    public float value2 = 0;

    public Expression(float value1, string op, float value2)
    {
        this.value1 = value1;
        this.value2 = value2;
    }

    public Expression(float value1, string op, Expression expression2)
    {
        this.value1 = value1;
        this.expression2 = expression2;
    }

    public Expression(Expression expression1, string op, float value2)
    {
        this.expression1 = expression1;
        this.value2 = value2;
    }

    public Expression(Expression expression1, string op, Expression expression2)
    {
        this.expression1 = expression1;
        this.expression2 = expression2;
    }

    public Expression(Expression expression)
    {
        value1 = expression.value1;
        value2 = expression.value2;
        if(expression.expression1 != null)
        {
            expression1 = expression.expression1;
        }
        if (expression.expression2 != null)
        {
            expression2 = expression.expression2;
        }
    }

    public bool IsSimple()
    {
        return expression1 == null && expression2 == null;
    }
    
    public float SimpleEvaluate()
    {
        if (!IsSimple())
        {
            throw new System.Exception("Expression must be simple to use SimpleEvaluate: " + this);
        }
        return value1 + value2;
    }

    public override string ToString()
    {
        //TODO: iterative recursion to avoid stack overflow
        string e1 = expression1 != null ? expression1.ToString() : "null";
        string e2 = expression2 != null ? expression2.ToString() : "null";
        return "{E1: " + e1 + " E2: " + e2 + " V1: " + value1 + " V2: " + value2 + "}";
    }
}
