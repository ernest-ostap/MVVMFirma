using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Validators
{
    static public class PositiveNumberValidator
    {
        //sprawdza czy kwota jest dodatnia
        public static string ValidatePositiveNumber(decimal? value)
        {
            try
            {
                
                if (!value.HasValue)
                {
                    return "Pole jest wymagane";
                }
                if(value.Value < 0)
                {
                    return "Wartość musi być dodatnia";
                }
                return string.Empty;
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }
    }
}
