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
            string inValue = (string)value;
            if (inValue.Length != 7)
            {
                return new ValidationResult(false, "value needs to have 7 characters");
            }
           
            if (inValue[2] == '-' && Char.IsLetter(inValue[0]) && Char.IsLetter(inValue[1]) && Char.IsDigit(inValue[3]) && Char.IsDigit(inValue[4])
                && Char.IsDigit(inValue[5]) && Char.IsDigit(inValue[6]))
            {
                return ValidationResult.ValidResult;
            }

            return new ValidationResult(false, "value is not corrext with schema LL-NNNN");
        }
    }
}
