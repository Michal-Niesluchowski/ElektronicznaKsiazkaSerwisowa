using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EKS.FullClient.Framework.Validations
{
    public class DecimalValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            decimal cost;

            try
            {
                cost = Convert.ToDecimal(value);
            }
            catch (Exception)
            {
                return new ValidationResult(false, $"Wprowadzono niepoprawną wartość");
            }

            return ValidationResult.ValidResult;
        }
    }
}
