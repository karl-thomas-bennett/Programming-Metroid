using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Statement : Token
{
    public Statement(int line, int character) : base(line, character){}

    public abstract bool Returns();
}
