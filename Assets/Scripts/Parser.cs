using System.Collections;
using System.Collections.Generic;

public class Parser
{
    public Parser()
    {

    }

    public float Calculate(string expression)
    {
        expression = RemoveSpaces(expression);
        if (float.TryParse(expression, out float output))
        {
            return float.Parse(expression);
        }
        return new Node(ParseMathsExpression(expression)).DepthFirstEvaluation();
    }

    public string RemoveSpaces(string code)
    {
        return string.Concat(code.Split(' '));
    }

    public Expression ParseMathsExpression(string code)
    {
        return Lexer.ParseExpression(code);
    }
}
