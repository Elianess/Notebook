using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook
{
    public class Validation
    {
        public bool Required { get; set; }
        public int MinLength { get; set; }
        public int MaxLength { get; set; }
        public char[] ValidSymbols { get; set; }

        public Validation(bool required, int minLength, int maxLength, char[] validSymbols)
        {
            Required = required;
            MinLength = minLength;
            MaxLength = maxLength;
            ValidSymbols = validSymbols;
        }

        public bool TryValidate(string validation, out string error)
        {


            if (string.IsNullOrWhiteSpace(validation) || string.IsNullOrEmpty(validation))
            {
                if (Required)
                {
                    error = "Это поле является обязательным!";
                    return false;
                }
                else
                {
                    error = null;
                    return true;
                }
            }

            if (validation.Length < MinLength)
            {
                error = "Минимальная длина: " + MinLength + "!";
                return false;
            }

            if (validation.Length > MaxLength)
            {
                error = "Максимальная длина: " + MaxLength + "!";
                return false;
            }

            foreach (var item in validation)
            {
                if (!ValidSymbols.Contains(item))
                {
                    error = "Используйте только: " + new string(ValidSymbols) + "!";
                    return false;
                }
            }
            error = null;
            return true;
        }
    }
}
