using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ip_validator
{
    public class DecimalToBinaryConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                {
                    return string.Empty;
                }

                if (!int.TryParse(value.ToString(), out int decimalValue))
                {
                    return string.Empty;
                }

                return System.Convert.ToString(decimalValue, 2).PadLeft(8, '0');
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Convert exception: {ex.Message}");
                return string.Empty;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                {
                    return string.Empty;
                }

                string binaryString = value.ToString();

                if (!IsBinary(binaryString))
                {
                    return string.Empty;
                }

                return System.Convert.ToInt32(binaryString, 2).ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ConvertBack exception: {ex.Message}");
                return string.Empty;
            }
        }

        private bool IsBinary(string binaryString)
        {
            foreach (char c in binaryString)
            {
                if (c != '0' && c != '1')
                {
                    return false;
                }
            }
            return true;
        }
    }
}
