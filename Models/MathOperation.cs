namespace Models
{
    public class MathOperation
    {
        public Enums.SupportedMathOperations MathOp { get; set; }

        public int FirstNumber { get; set; }

        public int SecondNumber { get; set; }

        public int ExpectedResult { get; set; }
    }
}
