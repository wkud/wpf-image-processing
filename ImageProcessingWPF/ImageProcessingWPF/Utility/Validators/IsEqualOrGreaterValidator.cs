using System;

namespace ImageProcessingWPF.Utility.Validators
{
    class IsEqualOrGreaterValidator : IValidator<int>
    {
        private int _threshold;
        public IsEqualOrGreaterValidator(int threshold)
        {
            _threshold = threshold;
        }
        public string GetInvalidInfoMessage()
        {
            return $"Value must be equal to or greater than {_threshold}.";
        }

        public bool IsValid(int value)
        {
            return value >= _threshold;
        }

        public int MakeValid(int value)
        {
            if (value < _threshold)
                return _threshold;

            return value;
        }
    }
}
