using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInterface
{
    public static float GetNumber(string input, int position)
    {
        return StringHelpers.GetNumber(input, position);
    }
}
