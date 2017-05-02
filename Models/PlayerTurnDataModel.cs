using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public sealed class PlayerTurnDataModel
    {
        public string PlayerName { get; set; }

        public MathOperation Operation { get; set; }

        public override string ToString()
        {
            return string.Format("Question for {0}, please tell me me how much this is : {1} {2} {3}?", PlayerName, Operation.FirstNumber, DetermineMathSymbol(), Operation.SecondNumber);
        }

        private string DetermineMathSymbol()
        {
            string result = string.Empty;

            switch ( Operation.MathOp)
            {
                case Enums.SupportedMathOperations.Add:
                    result = "+";
                    break;
                case Enums.SupportedMathOperations.Multiply:
                    result = "*";
                    break;
                case Enums.SupportedMathOperations.Substract:
                    result = "-";
                    break;
            }

            return result;
        }
    }
}
