using System.Collections;
using System.Collections.Generic;

public class Parser
{
    public static float Calculate(string expression)
    {
        expression = RemoveSpaces(expression);
        if (float.TryParse(expression, out float output))
        {
            return float.Parse(expression);
        }
        return new Node(ParseMathsExpression(expression)).DepthFirstEvaluation();
    }

    public static string RemoveSpaces(string code)
    {
        return string.Concat(code.Split(' '));
    }

    public static Expression ParseMathsExpression(string code)
    {
        return Lexer.ParseExpression(code);
    }
}
