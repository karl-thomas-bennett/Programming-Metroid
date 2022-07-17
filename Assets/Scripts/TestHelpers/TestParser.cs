using System.Collections;
using System.Collections.Generic;

public class TestParser
{

    public static float Calculate(string expression)
    {
        return Parser.Calculate(expression);
    }

    public static string RemoveSpaces(string code)
    {
        return Parser.RemoveSpaces(code);
    }

    public static Expression ParseMathsExpression(string code)
    {
        return Parser.ParseMathsExpression(code);
    }
}
