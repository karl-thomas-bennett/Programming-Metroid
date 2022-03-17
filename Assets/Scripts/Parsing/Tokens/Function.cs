using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Function : Token
{
    List<Expression> expressions;
    Type returnType;

    public override object Evaluate()
    {
        throw new System.NotImplementedException();
    }
}
