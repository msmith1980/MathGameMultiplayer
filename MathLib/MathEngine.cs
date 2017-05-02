using Models;
using System;
using static Models.Enums;

namespace MathLib
{

    public sealed class MathEngine
    {
        int _upperLimit;
        Random _random;

        public MathEngine(int upperLimit)
        {
            _upperLimit = upperLimit;
            _random = new Random();
        }

        public MathOperation GenerateCompleteOperation()
        {
            var result = new MathOperation();

            var mathOp = GenerateOperation();
            var firstNumber = GenerateFirstNumber();
            var secondNumber = GenerateSecondNumber(mathOp, firstNumber);

            result = new MathOperation
            {
                MathOp = mathOp,
                FirstNumber = firstNumber,
                SecondNumber = secondNumber
            };

            var calc = new MathCalculator();
            calc.PerformCalculation(result);

            return result;
        }

        public SupportedMathOperations GenerateOperation()
        {
            SupportedMathOperations generatedOperation;

            var randomNumber = _random.Next(1,4);
            Enum.TryParse(randomNumber.ToString(), out generatedOperation);

            return generatedOperation;
        }

        public int GenerateFirstNumber()
        {
            return _random.Next(_upperLimit);
        }

        public int GenerateSecondNumber(SupportedMathOperations mathOp, int firstNumber)
        {            
            if (mathOp == SupportedMathOperations.Substract)
            {
                return _random.Next(0,firstNumber + 1);
            }

            return _random.Next(_upperLimit);
        }                    
    }
}
