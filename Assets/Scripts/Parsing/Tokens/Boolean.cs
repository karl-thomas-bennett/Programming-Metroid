using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boolean : Token
{
    private readonly bool b;
    public Boolean(bool b, int line, int character) : base(line, character)
    {
        this.b = b;
    }

    public override object Evaluate()
    {
        return b;
    }
}
