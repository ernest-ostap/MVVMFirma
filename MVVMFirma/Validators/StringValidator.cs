using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Validators
{
    static public class StringValidator
    {
        //sprawdza czy string nie jest pusty i zaczyna sie duza litera
        public static string ValidateIsFirstLetterUpper(string value)
        {
            try
            { 
                if(string.IsNullOrEmpty(value))
                {
                    return string.Empty;
                }
                return char.IsUpper(value, 0) ? string.Empty : "Pierwsza litera musi być wielka";
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }


    }
}
