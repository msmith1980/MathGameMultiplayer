namespace Models
{
    public sealed class PlayerMathOperation : MathOperation
    {
        public int PlayerResult { get; set; }

        public PlayerMathOperation(MathOperation mathOperation)
        {
            this.MathOp = mathOperation.MathOp;
            this.ExpectedResult = mathOperation.ExpectedResult;
            this.FirstNumber = mathOperation.FirstNumber;
            this.SecondNumber = mathOperation.SecondNumber;
        }
    }
}
