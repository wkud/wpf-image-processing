using ImageProcessingWPF.Utility.Validators;
using System.Globalization;

namespace ImageProcessingWPF.Utility
{
    static class ParsableTextBoxValidatorUtility
    {
        private const string onlyIntegerMessage = "This input field accepts only integer values.";
        private const string onlyDoubleMessage = "This input field accepts only decimal numbers.";

        public static int Parse(this string input, int oldValue)
        {
            int newValue;
            var parsed = int.TryParse(input, out newValue);
            if (!parsed)
            {
                MessageBoxExtension.ShowWarning(onlyIntegerMessage);
                return oldValue;
            }
            return newValue;
        }

        public static int ParseAndValidate(this string input, int oldValue, IValidator<int> validator)
        {
            int newValue;
            var parsed = int.TryParse(input, out newValue);
            return ParseAndValidate<int>(parsed, newValue, oldValue, validator, onlyIntegerMessage);
        }
        public static double ParseAndValidate(this string input, double oldValue, IValidator<double> validator)
        {
            double newValue;
            var parsed = double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out newValue);
            return ParseAndValidate<double>(parsed, newValue, oldValue, validator, onlyDoubleMessage);
        }

        private static T ParseAndValidate<T>(bool parsed, T newValue, T oldValue, IValidator<T> validator, string parseFailedMessage)
        {
            if (!parsed)
            {
                MessageBoxExtension.ShowWarning(parseFailedMessage);
                return oldValue;
            }

            if (!validator.IsValid(newValue))
            {
                MessageBoxExtension.ShowWarning(validator.GetInvalidInfoMessage());
                return oldValue;
            }

            return newValue;
        }
    }
}
