using System.Collections;
using System.Collections.Generic;

public class Lexer
{
    string input;
    Queue<string> tokens = new Queue<string>();
    public Lexer(string input){
        this.input = input;
    }

    public static List<string> GetAdditions(string input)
    {
        List<string> output = new List<string>();
        for(int i = 0; i < input.Length; i++)
        {

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
            else
            {
                break;
            }
        }
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
        return float.Parse(number);
    }

    public string Next()
    {
        return tokens.Dequeue();
    }
}
