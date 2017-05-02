using Models;

namespace MathLib
{
    public sealed class MathCalculator
    {
        public MathCalculator()
        {
        }

        public void PerformCalculation(MathOperation mathOperation)
        {
            switch ( mathOperation.MathOp )
            {
                case Enums.SupportedMathOperations.Add:
                    mathOperation.ExpectedResult = mathOperation.FirstNumber + mathOperation.SecondNumber;
                    break;
                case Enums.SupportedMathOperations.Multiply:
                    mathOperation.ExpectedResult = mathOperation.FirstNumber * mathOperation.SecondNumber;
                    break;
                case Enums.SupportedMathOperations.Substract:
                    mathOperation.ExpectedResult = mathOperation.FirstNumber - mathOperation.SecondNumber;
                    break;
            }
        }
    }
}
