using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNode
{
    public Node node;
    public TestNode(TestExpression expression)
    {
        node = new Node(expression.expression);
    }

    public float DepthFirstEvaluation()
    {
        return node.DepthFirstEvaluation();
    }
}
