namespace ImageProcessingWPF.Utility.Validators
{
    class IsWithinRangeValidator : IValidator<int>
    {
        private int _min;
        private int _max;
        public IsWithinRangeValidator(int min, int max)
        {
            _min = min;
            _max = max;
        }

        public bool IsValid(int value)
        {
            return value >= _min && value <= _max;
        }
        public string GetInvalidInfoMessage()
        {
            return $"Value must lie beetween {_min} and {_max} (inclusive).";
        }
        public int MakeValid(int value)
        {
            if (value < _min)
                return _min;
            else if (value > _max)
                return _max;
            else
                return value;
        }
    }
}
