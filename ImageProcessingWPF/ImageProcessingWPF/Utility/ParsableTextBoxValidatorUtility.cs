using System.Windows.Media.TextFormatting;

namespace ImageProcessingWPF.Utility
{
    static class ParsableTextBoxValidatorUtility
    {
        public static int ParseAndValidate(this string input, int oldValue, int minValue, int maxValue)
        {
            int newValue;
            var parsed = int.TryParse(input, out newValue);
            if(!parsed)
            {
                MessageBoxExtension.ShowWarning("This input field accepts only integer values.");
                return oldValue;
            }

            if(!newValue.IsValid(minValue, maxValue))
            {
                MessageBoxExtension.ShowWarning($"Value must lie beetween {minValue} and {maxValue} (inclusive).");
                return oldValue;
            }

            return newValue;
        }
        public static bool IsValid(this int value, int min, int max)
        {
            return value >= min && value <= max;
        }
        public static int ClampToValidRange(this int value, int min, int max)
        {
            if (value < min)
                return min;
            else if (value > max)
                return max;
            else
                return value;
        }
    }
}
