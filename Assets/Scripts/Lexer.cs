using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lexer
{
    string input;
    Queue<string> tokens = new Queue<string>();
    public Lexer(string input){
        this.input = input;
        List<string> additions = GetAdditions(input);
        for(int i = 0; i < additions.Count; i++)
        {
            for (int j = 0; j < additions[i].Length; j++)
            {
                tokens.Enqueue(additions[i][j].ToString());
            }
        }
    }

    public static List<string> GetAdditions(string input)
    {
        List<string> output = new List<string>();
        for(int i = 0; i < input.Length; i++)
        {
            if(input[i] == '+')
            {
                output.Add("+(" + GetNumber(input, i - 1) + "," + GetNumber(input, i + 1) + ")");
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

    public bool HasNext()
    {
        return tokens.Count > 0;
    }

    public string Next()
    {
        return tokens.Dequeue();
    }
}
