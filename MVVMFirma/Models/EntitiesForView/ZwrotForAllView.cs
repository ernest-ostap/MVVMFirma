using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class ZwrotForAllView
    {
        public int IdZwrotu { get; set; }
        public string NazwaProduktu { get; set; }
        public string NumerFaktury { get; set; }
        public DateTime? DataZwrotu { get; set; }
        public decimal? Ilosc { get; set; }
    }
}
