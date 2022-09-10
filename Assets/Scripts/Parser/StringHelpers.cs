using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringHelpers
{

    public static List<int> GetOperatorPositions(string input)
    {
        List<int> output = new List<int>();
        for (int i = 0; i < input.Length; i++)
        {
            if (IsOperator(input[i]))
            {
                output.Add(i);
            }
        }
        return output;
    }

    public static float GetNumber(string input, int position)
    {
        string number = "";
        number += GetNumberCharactersOnLeftSideInclusive(input, position);
        number += GetNumberCharactersOnRightSideExclusive(input, position);
        return float.Parse(number);
    }

    private static string GetNumberCharactersOnLeftSideInclusive(string input, int position)
    {
        string number = "";
        for (int i = position; i >= 0; i--)
        {
            if (char.IsDigit(input[i]) || input[i] == '.')
            {
                number = input[i] + number;
            }
            else if (input[i] == '-')
            {
                if(i-1 < 0 || IsOperator(input[i-1]))
                    number = input[i] + number;
                break;
            }
            else
            {
                break;
            }
        }
        return number;
    }

    public static bool IsOperator(char c)
    {
        return c == '+' || c == '-';
    }

    private static string GetNumberCharactersOnRightSideExclusive(string input, int position)
    {
        string number = "";
        for (int i = position + 1; i < input.Length; i++)
        {
            if (char.IsDigit(input[i]) || input[i] == '.')
            {
                number += input[i];
            }
            else
            {
                break;
            }
        }
        return number;
    }

}
