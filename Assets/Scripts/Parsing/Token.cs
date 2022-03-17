using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Token
{
    public int id;
    public static int ID = 0;
    public int line;
    public int character;
    public Token(int line, int character)
    {
        id = ID++;
        this.line = line;
        this.character = character;
    }
    public abstract object Evaluate();
}
