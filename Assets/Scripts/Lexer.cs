using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lexer
{
    
    public static Expression ParseExpression(string input){
        Expression expression = null;
        List<int> additionPositions = GetAdditionPositions(input);
        for(int i = 0; i < additionPositions.Count; i++)
        {
            if(i == 0)
            {
                expression = new Expression(GetNumber(input, additionPositions[i] - 1), "+", GetNumber(input, additionPositions[i] + 1));
                continue;
            }
            expression = new Expression(expression, "+", GetNumber(input, additionPositions[i] + 1));
        }
        return expression;
    }

    public static List<int> GetAdditionPositions(string input)
    {
        List<int> output = new List<int>();
        for(int i = 0; i < input.Length; i++)
        {
            if(input[i] == '+')
            {
                output.Add(i);
            }
        }
        return output;
    }

    public static float GetNumber(string input, int position)
    {
        string number = "";
        for(int i = position; i >= 0; i--)
        {
            if (char.IsDigit(input[i]) || input[i] == '.')
            {
                number = input[i] + number;
            }
            else if (input[i] == '-')
            {
                number = input[i] + number;
                break;
            }
            else
            {
                break;
            }
        }
        for (int i = position + 1; i < input.Length; i++)
        {
            if (char.IsDigit(input[i]) || input[i] == '.' || input[i] == '-')
            {
                number += input[i];
            }
            else
            {
                break;
            }
        }
        return float.Parse(number);
    }
    
}
