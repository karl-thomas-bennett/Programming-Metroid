using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lexer
{
    
    public static Expression ParseExpression(string input){
        Expression expression = null;
        List<int> operatorPositions = StringHelpers.GetOperatorPositions(input);
        bool isFirstOperation = true;
        for(int i = 0; i < operatorPositions.Count; i++)
        {
            if(operatorPositions[i] == 0 || StringHelpers.IsOperator(input[operatorPositions[i]-1]))
            {
                //Operator symbol is part of number, eg "-5", or "5 + -3"
                continue;
            }
            string op = input[operatorPositions[i]].ToString();
            if (isFirstOperation)
            {
                float leftNumber = StringHelpers.GetNumber(input, operatorPositions[i] - 1);
                float rightNumber = StringHelpers.GetNumber(input, operatorPositions[i] + 1);

                expression = new Expression(leftNumber, op, rightNumber);
                isFirstOperation = false;
                continue;
            }
            float number = StringHelpers.GetNumber(input, operatorPositions[i] + 1);
            expression = new Expression(expression, op, number);
        }
        return expression;
    }
    
    
    
}
