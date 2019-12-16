using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LogicLayer.Validators
{
    public class ValidaterProductNumber : ValidationRule
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
                string inValue = (string)value;
                if(inValue.Length == 7 && inValue[2] == '-')
                {
                    flag = Char.IsLetter(inValue[0]);
                    flag = Char.IsLetter(inValue[1]);
                    flag = Char.IsDigit(inValue[3]);
                    flag = Char.IsDigit(inValue[4]);
                    flag = Char.IsDigit(inValue[5]);
                    flag = Char.IsDigit(inValue[6]);
                }
                else if(inValue.Length < 7)
                {
                    return new ValidationResult(false, "value is too short.");
                }
                else
                {
                    return new ValidationResult(false, "value is too long.");
                }
            }
            if (flag)
            {
                return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, "value is not corrext with schema XX-NNNN where X is a letter and N is a digit.");
        }
    }
}
