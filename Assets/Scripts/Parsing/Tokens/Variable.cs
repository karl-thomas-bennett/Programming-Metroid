using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variable : Token
{
    private object value;

    public Variable(object value, int line, int character) : base(line, character)
    {
        this.value = value;
    }

    public void SetValue(object v)
    {
        value = v;
    }

    public override object Evaluate()
    {
        return value;
    }
}
