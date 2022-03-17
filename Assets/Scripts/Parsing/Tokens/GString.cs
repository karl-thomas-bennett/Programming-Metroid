using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GString : Token
{
    private readonly string s;
    public GString(string s, int line, int character) : base(line, character)
    {
        this.s = s;
    }

    public override object Evaluate()
    {
        return s;
    }
}
