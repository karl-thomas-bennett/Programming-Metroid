using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : Statement
{
    List<Statement> statements;
    List<Variable> variables;
    public Scope(List<Statement> statements, int line, int character) : base(line, character)
    {
        this.statements = new List<Statement>(statements);
    }
    public override object Evaluate()
    {
        for(int i = 0; i < statements.Count; i++)
        {
            if (statements[i].Returns())
            {
                return statements[i].Evaluate();
            }
            else
            {
                statements[i].Evaluate();
            }
        }
        return null;
    }

    public override bool Returns()
    {
        for (int i = 0; i < statements.Count; i++)
        {
            if (statements[i].Returns())
            {
                return true;
            }
        }
        return false;
    }
}
