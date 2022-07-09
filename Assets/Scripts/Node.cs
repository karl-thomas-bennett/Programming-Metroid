using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Node
{
    public Expression expression;
    public Node parent;
    public List<Node> children = new List<Node>();
    public float output = default;
    public bool outputIsComputed = false;
    public Node(Expression expression, Node parent = null)
    {
        this.expression = expression;
        this.parent = parent;
        if(parent != null)
        {
            parent.children.Add(this);
        }
        
    }

    public float DepthFirstEvaluation()
    {
        Stack<Node> stack = new Stack<Node>();
        stack.Push(this);
        while(stack.Count > 0)
        {
            if (outputIsComputed)
            {
                break;
            }
            Node current = stack.Peek();
            if (current.expression.IsSimple())
            {
                stack.Pop();
                current.SetOutput(current.expression.SimpleEvaluate());
                continue;
            }
            if (current.children.Count == 2)
            {
                stack.Pop();
                current.SetOutput(current.children[0].output + current.children[1].output);
                continue;
            }
            if (current.expression.expression1 == null)
            {
                Node child = new Node(null, current);
                child.SetOutput(current.expression.value1);
                stack.Push(new Node(current.expression.expression2, current));
            }
            else if(current.expression.expression2 == null)
            {
                stack.Push(new Node(current.expression.expression1, current));
                Node child = new Node(null, current);
                child.SetOutput(current.expression.value2);
            }
            else
            {
                stack.Push(new Node(current.expression.expression1, current));
                stack.Push(new Node(current.expression.expression2, current));
            }
        }
        return output;
    }

    public void SetOutput(float output)
    {
        this.output = output;
        outputIsComputed = true;
    }

}
