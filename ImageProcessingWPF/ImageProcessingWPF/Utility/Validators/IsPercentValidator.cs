namespace ImageProcessingWPF.Utility.Validators
{
    class IsPercentValidator : IValidator<double>
    {
        public bool IsValid(double value)
        {
            return value >= 0 && value <= 1;
        }
        public string GetInvalidInfoMessage()
        {
            return "Value must be fraction between 0 and 1 (inclusive).";
        }

        public double MakeValid(double value)
        {
            if (value < 0)
                return 0;
            else if (value > 1)
                return 1;
            else
                return value;
        }
    }
}
