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
            if(isFirstOperation)
            {
                expression = new Expression(StringHelpers.GetNumber(input, operatorPositions[i] - 1), input[operatorPositions[i]].ToString(), StringHelpers.GetNumber(input, operatorPositions[i] + 1));
                isFirstOperation = false;
                continue;
            }
            expression = new Expression(expression, input[operatorPositions[i]].ToString(), StringHelpers.GetNumber(input, operatorPositions[i] + 1));
        }
        return expression;
    }
    
    
    
}
