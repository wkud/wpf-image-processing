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

            if(newValue < minValue || newValue > maxValue)
            {
                MessageBoxExtension.ShowWarning($"Value must lie beetween {minValue} and {maxValue} (inclusive).");
                return oldValue;
            }

            return newValue;
        }
    }
}
