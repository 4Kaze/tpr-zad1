using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LogicLayer.Validators
{
    public class ValidateRealNumberEqualHigher : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            bool flag = true;
            if (value == null)
            {
                return new ValidationResult(false, "value cannot be empty.");
            }
            else
            {
                flag = decimal.TryParse((string)value, out decimal example);
                if (!flag)
                {
                    return new ValidationResult(false, "value must be decimal number.");
                }
                if(example < 0)
                {
                    return new ValidationResult(false, "value must be higher or equal 0.");
                }
            }
            return ValidationResult.ValidResult;
        }
    }
}
