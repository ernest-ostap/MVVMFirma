using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Validators
{
    static public class StringLengthValidator
    {
        public static string FieldLengthValidator(string value, int minLength)
        {
            try
            {
                if (string.IsNullOrEmpty(value))
                {
                    return "To pole jest wymagane.";
                }
                else
                {
                    if (value.Length < minLength)
                    {
                        return "To pole wymaga " + minLength + " znaków.";
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }
    }
}
