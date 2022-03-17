using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Integer : Token
{
    private readonly int n;
    public Integer(int n, int line, int character) : base(line, character)
    {
        this.n = n;
    }

    public override object Evaluate()
    {
        return n;
    }
}
