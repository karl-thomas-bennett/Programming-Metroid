using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expression : Statement
{
    private string gOperator;
    private Token first;
    private Token second;
    public Expression(string gOperator, Token first, Token second, int line, int character) : base(line, character)
    {
        this.gOperator = gOperator;
        this.first = first;
        this.second = second;
    }

    public override object Evaluate()
    {
        
        switch (gOperator)
        {
            case "+":
                return Add();
            case "-":
                return Substract();
            case "/":
                return Divide();
            case "*":
                return Multiply();
            case "%":
                return Modulo();
            case "!":
                return Not();
            case "=":
                return Assign();
            case "==":
                return IsEqual();
            case ">":
                return IsGreater();
            case "<":
                return IsLess();
            case "<=":
                return IsLess() || IsEqual();
            case ">=":
                return IsGreater() || IsEqual();
            default:
                return null;
        }
    }

    private bool Not()
    {
        object e = first.Evaluate();
        if (!IsType<bool>(e))
        {
            throw new Exception("NaB" + id);
        }
        return !(bool)e;
    }

    private object Modulo()
    {
        object e1 = first.Evaluate();
        object e2 = second.Evaluate();
        if (!IsNumber(e1) || !IsNumber(e2))
        {
            throw new Exception("NaN|" + id);
        }
        if (IsType<float>(e1) || IsType<float>(e2))
        {
            return (float)e1 % (float)e2;
        }
        else
        {
            return (int)e1 % (int)e2;
        }

    }

    private bool IsLess()
    {
        object e1 = first.Evaluate();
        object e2 = second.Evaluate();
        if (!IsNumber(e1) || !IsNumber(e2))
        {
            throw new Exception("NaN|" + id);
        }
        if (IsType<float>(e1) || IsType<float>(e2))
        {
            return (float)e1 < (float)e2;
        }
        else
        {
            return (int)e1 < (int)e2;
        }
    }

    private bool IsGreater()
    {
        object e1 = first.Evaluate();
        object e2 = second.Evaluate();
        if (!IsNumber(e1) || !IsNumber(e2))
        {
            throw new Exception("NaN|" + id);
        }
        if (IsType<float>(e1) || IsType<float>(e2))
        {
            return (float)e1 > (float)e2;
        }
        else
        {
            return (int)e1 > (int)e2;
        }
    }

    private bool IsEqual()
    {
        return first.Evaluate().Equals(second.Evaluate());
    }

    private object Assign()
    {
        if (!IsType<Variable>(first))
        {
            throw new Exception("NotVariable|" + id);
        }
        ((Variable)first).SetValue(second.Evaluate());
        return null;
    }

    private object Multiply()
    {
        object e1 = first.Evaluate();
        object e2 = second.Evaluate();
        if (!IsNumber(e1) || !IsNumber(e2))
        {
            throw new Exception("NaN|" + id);
        }
        if (IsType<float>(e1) || IsType<float>(e2))
        {
            return (float)e1 * (float)e2;
        }
        else
        {
            return (int)e1 * (int)e2;
        }
    }

    private object Divide()
    {
        object e1 = first.Evaluate();
        object e2 = second.Evaluate();
        if (!IsNumber(e1) || !IsNumber(e2))
        {
            throw new Exception("NaN|" + id);
        }
        if (IsType<float>(e1) || IsType<float>(e2))
        {
            return (float)e1 / (float)e2;
        }
        else
        {
            return (int)e1 / (int)e2;
        }
    }

    private object Substract()
    {
        object e1 = first.Evaluate();
        object e2 = second.Evaluate();
        if (!IsNumber(e1) || !IsNumber(e2))
        {
            throw new Exception("NaN|" + id);
        }
        if(IsType<float>(e1) || IsType<float>(e2))
        {
            return (float)e1 + (float)e2;
        }
        else
        {
            return (int)e1 + (int)e2;
        }
    }

    public bool IsType<T>(object o){
        return o.GetType().Equals(typeof(T));
    }

    public object Add()
    {
        object e1 = first.Evaluate();
        object e2 = second.Evaluate();
        if (IsType<string>(first) || IsType<string>(e2))
        {
            return e1.ToString() + e2.ToString();
        }
        if(!IsNumber(e1) || !IsNumber(e2))
        {
            throw new Exception("NaN|" + id);
        }
        if (IsType<float>(e1) || IsType<float>(e2))
        {
            
            return (float)e1 + (float)e2;
        }
        else
        {
            return (int)e1 + (int)e2;
        }
    }

    private bool IsNumber(object o)
    {
        return IsType<int>(o) || IsType<float>(o);
    }
}
