using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LogicLayer.Validators
{
    public class ValidateDays : ValidationRule
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
                int example;
                flag = int.TryParse((string)value, out example);
                if (!flag)
                {
                    return new ValidationResult(false, "value must be decimal number.");
                }
                if (example < 0)
                {
                    return new ValidationResult(false, "value must be higher than 0.");
                }
            }
            return ValidationResult.ValidResult;
        }
        
    }
}
